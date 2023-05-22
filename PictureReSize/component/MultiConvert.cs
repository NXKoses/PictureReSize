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
        private Form1 form;

        public void Run(Form1 form)
        {
            this.form = form;
            foreach (var item in AppData.inputFolderListPath)
            {
                var vs = Directory.GetFiles(item, "*." + AppData.InputFileType);
                ActiveFilesLength += vs.Length;
            }

            if (ActiveFilesLength == 0)
            {
                MessageBox.Show("フォルダの中に変換できるものがありませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Resizer();
        }

        private async Task Resizer()
        {
            int cnt = 0;
            AppData.converting = true;

            await Task.Run(() =>
            {
                ParallelOptions option = new()
                {
                    MaxDegreeOfParallelism = AppData.thread_Value
                };

                foreach (var folderitem in AppData.inputFolderListPath)
                {
                    var itemlist = Directory.GetFiles(folderitem, "*." + AppData.InputFileType);

                    //並列処理
                    Parallel.ForEach(itemlist, option, item =>
                    {
                        var filename = Path.GetFileNameWithoutExtension(item);
                        try
                        {
                            //各タスクで独立したBitmapオブジェクト
                            using Bitmap bitmap = new Bitmap(item);
                            var resizeWidth = AppData.X;
                            var resizeHeight = (int)((float)bitmap.Height / bitmap.Width * AppData.X);

                            if (!AppData.aspect_lock) //アスペクト比解除時
                            {
                                resizeWidth = AppData.X;
                                resizeHeight = AppData.Y;
                            }

                            //画像を縮小する
                            using Bitmap resizeBmp = new Bitmap(resizeWidth, resizeHeight);
                            using Graphics g = Graphics.FromImage(resizeBmp);
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                            g.DrawImage(bitmap, 0, 0, resizeWidth, resizeHeight);

                            //複数フォルダ入力だったら
                            if (AppData.multiple_folder_entry)
                            {
                                resizeBmp.Save(Path.Combine(AppData.OutputFolderPath + @"\", filename + "." + AppData.OutputFileType.ToString().ToLower()), AppData.OutputFileType);
                            }

                            //複数フォルダ同期入力だったら
                            if (AppData.multiple_folder_synchronous_entry)
                            {
                                resizeBmp.Save(Path.Combine(folderitem + @"\", filename + "." + AppData.OutputFileType.ToString().ToLower()), AppData.OutputFileType);
                            }

                            //カウント
                            cnt++;

                            //formに進捗表示
                            form.Invoke(() =>
                            {
                                form.sintyoku.Text = cnt + " / " + ActiveFilesLength;
                            });
                        }
                        catch
                        {
                            MoveErrorList.Add(item);
                            Debug.WriteLine("MoveErrorCnt Add :" + filename);
                        }
                        Function.Taskbar(cnt, ActiveFilesLength - 1);
                    });
                }
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

            AppData.converting = false;
        }
    }
}
