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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = SixLabors.ImageSharp.Image;

namespace PictureReSize.component
{
    class Convert
    {
        /// <summary>
        /// 変換中フラグ
        /// </summary>
        public static bool Converting { get; set; } = false;

        /// <summary>
        /// 並列処理のロックオブジェクト
        /// </summary>
        private static object Lockobject { get; set; } = new();

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
        public ConvertMode ConvertMode { get; set; }

        /// <summary>
        /// スレッド数
        /// </summary>
        public int Thread_Value { get; set; } = 10;

        private ConcurrentQueue<string> moveErrorList = new();
        private int activeFilesLength;
        private MainWindow? form;
        private int cnt;

        /// <summary>
        /// 画像変換処理を開始します。
        /// </summary>
        /// <param name="form">進捗を表示するためのインスタンス</param>
        public async void Convert_Run(MainWindow form)
        {
            this.form = form;

            // 出力フォルダの存在確認
            // ConvertMode.Multiple_Folder_Syncの場合は入力フォルダと出力フォルダが同じになるので確認しない
            if (!Directory.Exists(OutputFolderPath) && ConvertMode != ConvertMode.Multiple_Folder_Sync)
            {
                MessageBox.Show("出力フォルダが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 入力フォルダの中の変換できるファイル数をカウント
            foreach (var item in InputFolderListPath)
            {
                activeFilesLength += Directory.GetFiles(item, "*." + InputFileType).Length;
            }

            // 変換できるファイルが無い場合
            if (activeFilesLength == 0)
            {
                MessageBox.Show("フォルダの中に変換できるものがありませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 変換処理
            Converting = true;
            await ProcessImagesAsync();
        }

        /// <summary>
        /// フォルダごとに並列処理で画像を変換します。
        /// </summary>
        /// <returns></returns>
        private async Task ProcessImagesAsync()
        {
            // 並列処理の設定
            var options = new ParallelOptions { MaxDegreeOfParallelism = Thread_Value };

            // エンコーダーを取得しておく
            IImageEncoder encoder = GetImageEncoder(OutputFileType);

            // フォルダごとに別スレッドで処理させる
            IEnumerable<Task> tasks = InputFolderListPath.Select(folder => Task.Run(() =>
            {
                // フォルダ内の画像ファイルを取得
                var files = Directory.GetFiles(folder, "*." + InputFileType);
                // フォルダ内の画像ファイルを並列処理で変換する
                Parallel.ForEach(files, options, file =>
                {
                    ProcessImage(file, folder, encoder);
                });
            }));

            // すべての処理が終わるまで待機
            await Task.WhenAll(tasks);

            MessageBox.Show($"{cnt}個変換しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Converting = false;

            // もし変換に失敗したファイルがあれば表示
            ShowErrorMessages();
        }

        /// <summary>
        /// 画像一枚の変換処理を行い、formに進捗を表示します。
        /// また、変換に失敗した場合はmoveErrorListに追加します。
        /// </summary>
        /// <param name="file"></param>
        /// <param name="folder"></param>
        /// <param name="encoder"></param>
        private void ProcessImage(string file, string folder, IImageEncoder encoder)
        {
            try
            {
                using Image image = Image.Load(file);

                int resizeWidth, resizeHeight;
                if (Aspect_lock)
                {
                    resizeWidth = X;
                    resizeHeight = (int)((float)image.Height / image.Width * X);
                }
                else
                {
                    resizeWidth = X;
                    resizeHeight = Y;
                }

                image.Mutate(x => x.Resize(resizeWidth, resizeHeight));

                string outputPath = ConvertMode switch
                {
                    ConvertMode.Normal => Path.Combine(OutputFolderPath, $"{Path.GetFileNameWithoutExtension(file)}.{OutputFileType.ToString().ToLower()}"),
                    ConvertMode.Multiple => Path.Combine(OutputFolderPath, $"{Path.GetFileNameWithoutExtension(file)}.{OutputFileType.ToString().ToLower()}"),
                    ConvertMode.Multiple_Folder_Sync => Path.Combine(folder, $"{Path.GetFileNameWithoutExtension(file)}.{OutputFileType.ToString().ToLower()}"),
                    _ => throw new InvalidOperationException()
                };

                image.Save(outputPath, encoder);
                image.Dispose();

                lock (Lockobject)
                {
                    form?.Invoke(() => form.sintyoku.Text = $"{++cnt} / {activeFilesLength}");
                    Debug.WriteLine($"Converted: {Path.GetFileName(file)}");
                }
            }
            catch
            {
                lock (Lockobject)
                {
                    moveErrorList.Enqueue(file);
                    Debug.WriteLine($"Error converting: {Path.GetFileName(file)}");
                }
            }

            Function.Taskbar(cnt, activeFilesLength - 1);
        }

        /// <summary>
        /// もし変換に失敗したファイルがあれば表示します。
        /// </summary>
        private void ShowErrorMessages()
        {
            if (!moveErrorList.IsEmpty)
            {
                string errorMessages = string.Join(Environment.NewLine, moveErrorList);
                MessageBox.Show($"{errorMessages}{Environment.NewLine}以下の画像の変換（保存）に失敗しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                moveErrorList.Clear();
            }
        }

        /// <summary>
        /// ImageFormat => IImageEncoderに変換
        /// </summary>
        /// <param name="outputFileType"></param>
        /// <returns></returns>
        private static IImageEncoder GetImageEncoder(ImageFormat? outputFileType)
        {
            // エンコーダーを取得しておく
            if (outputFileType == ImageFormat.Png) return new PngEncoder()
            {
                CompressionLevel = PngCompressionLevel.DefaultCompression,
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
                CompressionLevel = PngCompressionLevel.DefaultCompression,
                SkipMetadata = false
            };
        }
    }

    /// <summary>
    /// 変換モード
    /// </summary>
    public enum ConvertMode
    {
        Normal,
        Multiple,
        Multiple_Folder_Sync
    }
}