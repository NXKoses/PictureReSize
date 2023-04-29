using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureReSize.component
{
    class MultiConvert
    {
        private readonly List<string> MoveErrorList = new();
        private int ActiveFilesLength;
        //private int ActiveFolderLengh;
        public void PictureFileCheck()
        {
            //ActiveFolderLengh = Data.inputFolderListPath.Count;

            foreach (var item in Data.inputFolderListPath)
            {
                var vs = Directory.GetFiles(item, "*." + Data.InputFileType);
                ActiveFilesLength += vs.Length;
            }

            if (ActiveFilesLength == 0)
            {
                MessageBox.Show("フォルダの中に変換できるものがありませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Resizer();
        }

        private async void Resizer()
        {
            int cnt = 0;
            Data.converting = true;

            await Task.Run(() =>
            {
                ParallelOptions option = new ParallelOptions
                {
                    MaxDegreeOfParallelism = Data.thread_Value
                };

                //並列化
                Parallel.ForEach(Data.inputFolderListPath, option, folderitem =>
                {
                    var vs = Directory.GetFiles(folderitem, "*." + Data.InputFileType);

                    Parallel.ForEach(vs, option, stFilePath =>
                    {
                        var filename = Path.GetFileNameWithoutExtension(stFilePath);
                        try
                        {
                            //各タスクで独立したBitmapオブジェクト
                            using Bitmap bitmap = new Bitmap(stFilePath);
                            var resizeWidth = Data.X;
                            var resizeHeight = (int)((float)bitmap.Height / bitmap.Width * Data.X);

                            if (!Data.aspect_lock) //アスペクト比解除時
                            {
                                resizeWidth = Data.X;
                                resizeHeight = Data.Y;
                            }

                            //画像を縮小する
                            using Bitmap resizeBmp = new Bitmap(resizeWidth, resizeHeight);
                            using Graphics g = Graphics.FromImage(resizeBmp);
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                            g.DrawImage(bitmap, 0, 0, resizeWidth, resizeHeight);


                            resizeBmp.Save(Path.Combine(Data.OutputFolderPath + @"\", filename + "." + Data.OutputFileType.ToString().ToLower()), Data.OutputFileType);

                            cnt++;
                        }
                        catch
                        {
                            MoveErrorList.Add(stFilePath);
                            Debug.WriteLine("MoveErrorCnt Add :" + filename);
                        }
                        Function.Taskbar(cnt, ActiveFilesLength - 1);
                    });
                });
            });

            Function.TempDelete();
            MessageBox.Show(cnt + "/" + ActiveFilesLength + "個変換しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (MoveErrorList.Count != 0)　//エラーが有る場合
            {
                string erroritemlist = "";

                foreach (var item in MoveErrorList)
                {
                    erroritemlist += item + Environment.NewLine;
                }

                MessageBox.Show(erroritemlist + Environment.NewLine + "以下の画像の保存に失敗しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Data.converting = false;
        }
    }
}
