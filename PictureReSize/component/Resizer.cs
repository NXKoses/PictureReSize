using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using static PictureReSize.Program;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using System.Drawing.Imaging;
using System.Collections.Concurrent;

namespace PictureReSize.component
{
    internal class Resizer
    {
        Form1? form1;
        private object lockobject;
        private int activeFilesLength;
        private ConcurrentQueue<string> moveErrorList = new();

        internal Resizer(Form1? form1)
        {
            this.form1 = form1;
        }

        public int Thread_Value { get; private set; }
        public IEnumerable<object> InputFolderListPath { get; private set; }
        public ImageFormat? OutputFileType { get; set; }
        public ImageFormat? InputFileType { get; set; }
        public string OutputFolderPath { get; private set; }
        public bool Aspect_lock { get; private set; }
        public Program.ConvertMode ConvertMode { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        internal void Resize()
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
                var itemlist = Directory.GetFiles((string)folderitem, "*." + InputFileType);

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
                    form1?.Invoke(() =>
                    {
                        form1.sintyoku.Text = cnt + " / " + activeFilesLength;
                        Debug.WriteLine("Converted :" + filename);
                    });

                    Function.Taskbar(cnt, activeFilesLength - 1);
                });
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
