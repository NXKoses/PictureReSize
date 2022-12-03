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
        private readonly List<string> MoveErrorList = new List<string>();
        private int ActiveFilesLength;
        //private int ActiveFolderLengh;
        public void PictureFileCheck()
        {
            //ActiveFolderLengh = Data.inputFolderListPath.Count;

            foreach (var item in Data.inputFolderListPath)
            {
                var vs = System.IO.Directory.GetFiles(item, "*." + Data.InputFileType);
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
                ParallelOptions option = new ParallelOptions();
                option.MaxDegreeOfParallelism = Data.thread_Value;

                //並列化
                Parallel.ForEach(Data.inputFolderListPath, option, folderitem =>
                {
                    var vs = System.IO.Directory.GetFiles(folderitem, "*." + Data.InputFileType);

                    Parallel.ForEach(vs, option, pictureitem =>
                    {
                        var filename = Path.GetFileNameWithoutExtension(pictureitem);

                        //各タスクで独立したBitmapオブジェクト
                        using Bitmap bitmap = new Bitmap(pictureitem);
                        var resizeWidth = Data.X;
                        var resizeHeight = (int)((float)bitmap.Height / bitmap.Width * Data.X);

                        if (!Data.aspect_lock) //アスペクト比解除時
                        {
                            resizeWidth = Data.X;
                            resizeHeight = Data.Y;
                        }

                        //画像を縮小する
                        using var resizeBmp = bitmap.GetThumbnailImage(resizeWidth, resizeHeight, null, IntPtr.Zero);

                        try
                        {
                            resizeBmp.Save(Path.Combine(Data.OutputFolderPath + @"\", filename + "." + Data.OutputFileType));
                        }
                        catch
                        {
                            MoveErrorList.Add(filename);
                            Debug.WriteLine("MoveErrorCnt Add :" + filename);
                        }

                        cnt++;
                        Function.Taskbar(cnt, ActiveFilesLength - 1);
                    });
                });
            });

            Function.TempDelete();
            MessageBox.Show(ActiveFilesLength + "/" + cnt + "個変換しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (MoveErrorList.Count != 0)　//エラーが有る場合
            {
                string erroritemlist = "";

                foreach (var item in MoveErrorList)
                {
                    erroritemlist += item + Environment.NewLine;
                }

                MessageBox.Show(erroritemlist + Environment.NewLine + "以下の画像の移動に失敗しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Data.converting = false;
        }
    }
}
