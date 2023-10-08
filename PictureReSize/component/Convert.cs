using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        /// アスペクト比ロック
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

        private static Object lockobject = new();
        private ConcurrentQueue<string> moveErrorList = new();
        private int activeFilesLength;
        private Form1? form;

        public async void Convert_Run(Form1 form)
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
            _ = Task.Run (() => Resizer());
        }

        private void Resizer()
        {
            int cnt = 0;

            ParallelOptions option = new()
            {
                MaxDegreeOfParallelism = Thread_Value
            };

            foreach (var folderitem in InputFolderListPath)
            {
                var itemlist = Directory.GetFiles(folderitem, "*." + InputFileType);

                //並列処理
                Parallel.ForEach(itemlist, option, item =>
                {
                    var filename = Path.GetFileNameWithoutExtension(item);
                    try
                    {
                        //各タスクで独立したBitmapオブジェクトを作成
                        using Bitmap bitmap = new(item);

                        //アスペクト比計算
                        var resizeWidth = X;
                        var resizeHeight = (int)((float)bitmap.Height / bitmap.Width * X);

                        //アスペクト比解除時
                        if (!Aspect_lock)
                        {
                            resizeWidth = X;
                            resizeHeight = Y;
                        }


                        //画像を縮小する
                        using Bitmap resizeBmp = new(resizeWidth, resizeHeight);
                        using Graphics g = Graphics.FromImage(resizeBmp);
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(bitmap, 0, 0, resizeWidth, resizeHeight);

                        //画像を保存（モードに合わせて）
                        switch (ConvertMode)
                        {
                            case Program.ConvertMode.Normal:
                                resizeBmp.Save(Path.Combine(OutputFolderPath + @"\", $"{filename}.{OutputFileType.ToString().ToLower()}"), OutputFileType);
                                break;

                            case Program.ConvertMode.Multiple:
                                resizeBmp.Save(Path.Combine(OutputFolderPath + @"\", $"{filename}.{OutputFileType.ToString().ToLower()}"), OutputFileType);
                                break;

                            case Program.ConvertMode.Multiple_Folder_Sync:
                                resizeBmp.Save(Path.Combine(folderitem + @"\", $"{filename}.{OutputFileType.ToString().ToLower()}"), OutputFileType);
                                break;

                            default:
                                throw new Exception("変換モードが設定されていません。");
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
    }
}
#pragma warning restore CA1416 // プラットフォームの互換性を検証