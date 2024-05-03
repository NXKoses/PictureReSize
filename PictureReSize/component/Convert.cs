using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = SixLabors.ImageSharp.Image;

#pragma warning disable CA1416 // プラットフォームの互換性を検証
namespace PictureReSize.component
{
    class Convert
    {
        /// <summary>
        /// 出力フォルダ
        /// </summary>
        public string? OutputFolderPath { get; set; }

        /// <summary>
        /// 入力フォルダリスト
        /// </summary>
        public List<string> InputFolderListPath { get; set; } = new();

        /// <summary>
        /// 入力ファイル形式
        /// </summary>
        public string? InputFileType { get; set; }

        /// <summary>
        /// 出力ファイル形式
        /// </summary>
        public ImageFormat? OutputFileType { get; set; }

        /// <summary>
        /// 変換後の解像度X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 変換後の解像度Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// アスペクト比維持
        /// </summary>
        public bool Aspect_lock { get; set; } = false;

        /// <summary>
        /// 変換モード
        /// </summary>
        public Program.ConvertMode ConvertMode { get; set; }

        /// <summary>
        /// スレッド数
        /// </summary>
        public int Thread_Value { get; set; } = 10;

        private static object lockobject = new();
        private ConcurrentQueue<string> moveErrorList = new();
        private int activeFilesLength;
        private MainWindow? form;

        public void Convert_Run(MainWindow form)
        {
            this.form = form;

            //出力フォルダの存在確認
            //ConvertMode.Multiple_Folder_Syncの場合は入力フォルダと出力フォルダが同じになるので確認しない
            if (!Directory.Exists(OutputFolderPath) & ConvertMode != Program.ConvertMode.Multiple_Folder_Sync)
            {
                MessageBox.Show("出力フォルダが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //入力フォルダの変換できるファイル数をカウント
            foreach (var item in InputFolderListPath)
            {
                activeFilesLength += Directory.GetFiles(item, "*." + InputFileType).Length;
            }

            //変換できるファイルが無い場合
            if (activeFilesLength == 0)
            {
                MessageBox.Show("フォルダの中に変換できるものがありませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //変換処理
            Program.Converting = true;
            _ = Task.Run(() => Resizer());
        }

        private void Resizer()
        {
            int cnt = 0;

            ParallelOptions option = new()
            {
                MaxDegreeOfParallelism = Thread_Value
            };

            //エンコーダーを取得しておく
            IImageEncoder encoder = GetImageEncoder(OutputFileType);

            foreach (var folderitem in InputFolderListPath)
            {
                var itemlist = Directory.GetFiles(folderitem, "*." + InputFileType);

                //並列処理
                Parallel.ForEach(itemlist, option, item =>
                {
                    var filename = Path.GetFileNameWithoutExtension(item);
                    try
                    {
                        using var image = Image.Load(item);
                        using var ms = new MemoryStream();

                        //アスペクト比計算
                        var resizeWidth = X;
                        var resizeHeight = (int)((float)image.Height / image.Width * X);

                        //アスペクト比維持 解除時
                        if (!Aspect_lock)
                        {
                            resizeWidth = X;
                            resizeHeight = Y;
                        }

                        //画像を縮小する
                        image.Mutate(x => x.Resize(resizeWidth, resizeHeight));

                        //画像を保存（モードに合わせて）
                        switch (ConvertMode)
                        {
                            case Program.ConvertMode.Normal:
                                image.Save(Path.Combine(OutputFolderPath + @"\", $"{filename}.{OutputFileType.ToString().ToLower()}"), encoder);
                                break;

                            case Program.ConvertMode.Multiple:
                                image.Save(Path.Combine(OutputFolderPath + @"\", $"{filename}.{OutputFileType.ToString().ToLower()}"), encoder);
                                break;

                            case Program.ConvertMode.Multiple_Folder_Sync:
                                image.Save(Path.Combine(folderitem + @"\", $"{filename}.{OutputFileType.ToString().ToLower()}"), encoder);
                                break;
                        }

                        //カウント
                        lock (lockobject)
                        {
                            cnt++;
                        }
                    }
                    catch
                    {
                        lock (lockobject)
                        {
                            moveErrorList.Enqueue(item);
                            Debug.WriteLine("MoveErrorCnt Add :" + filename);
                        }
                    }

                    //formに進捗表示
                    form?.Invoke(() =>
                    {
                        form.sintyoku.Text = cnt + " / " + activeFilesLength;
                        Debug.WriteLine("Converted :" + filename);
                    });

                    Function.Taskbar(cnt, activeFilesLength - 1);
                });
            }

            MessageBox.Show(cnt + "/" + activeFilesLength + "個変換しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Program.Converting = false;

            if (!moveErrorList.IsEmpty)     //エラーが有る場合
            {
                string erroritemlist = "";

                foreach (var item in moveErrorList)
                {
                    erroritemlist += item + Environment.NewLine;
                }

                MessageBox.Show(erroritemlist + Environment.NewLine + "以下の画像の変換（保存）に失敗しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                moveErrorList.Clear();      //エラー履歴を削除
            }
        }

        /// <summary>
        /// ImageFormat => IImageEncoderに変換
        /// </summary>
        /// <param name="outputFileType"></param>
        /// <returns></returns>
        private static IImageEncoder GetImageEncoder(ImageFormat? outputFileType)
        {
            //エンコーダーを取得しておく
            if (outputFileType == ImageFormat.Png) return new PngEncoder()
            {
                CompressionLevel = PngCompressionLevel.BestSpeed,
                SkipMetadata = false
            };
            if (outputFileType == ImageFormat.Jpeg) return new JpegEncoder()
            {
                Quality = 100,
                SkipMetadata = false
            };
            if (outputFileType == ImageFormat.Bmp) return new BmpEncoder();

            return new PngEncoder()
            {
                CompressionLevel = PngCompressionLevel.BestSpeed,
                SkipMetadata = false
            };
        }
    }
}
#pragma warning restore CA1416 // プラットフォームの互換性を検証