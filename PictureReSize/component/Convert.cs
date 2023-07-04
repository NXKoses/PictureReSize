using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureReSize.component
{
    class Convert
    {
#pragma warning disable CA1416 // プラットフォームの互換性を検証
        private readonly List<string> MoveErrorList = new();
        private int ActiveFilesLength;
        private Form1 form;

        public async void Run(Form1 form)
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

            await Resizer();
        }

        private async Task Resizer()
        {
            int cnt = 0;
            AppData.converting = true;
            Object lockobject = new();

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
                            //各タスクで独立したBitmapオブジェクトを作成
                            using Bitmap bitmap = new Bitmap(item);

                            //アスペクト比計算
                            var resizeWidth = AppData.X;
                            var resizeHeight = (int)((float)bitmap.Height / bitmap.Width * AppData.X);

                            //アスペクト比解除時
                            if (!AppData.aspect_lock)
                            {
                                resizeWidth = AppData.X;
                                resizeHeight = AppData.Y;
                            }

                            //画像を縮小する
                            using Bitmap resizeBmp = new Bitmap(resizeWidth, resizeHeight);
                            using Graphics g = Graphics.FromImage(resizeBmp);
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            g.DrawImage(bitmap, 0, 0, resizeWidth, resizeHeight);

                            //複数フォルダ入力だったら
                            if (AppData.multiple_folder_entry)
                            {
                                resizeBmp.Save(Path.Combine(AppData.OutputFolderPath + @"\", filename + "." + AppData.OutputFileType.ToString().ToLower()), AppData.OutputFileType);
                            }
                            //複数フォルダ同期入力だったら
                            else if (AppData.multiple_folder_synchronous_entry)
                            {
                                resizeBmp.Save(Path.Combine(folderitem + @"\", filename + "." + AppData.OutputFileType.ToString().ToLower()), AppData.OutputFileType);
                            }
                            //それ以外だったら（通常変換）
                            else
                            {
                                resizeBmp.Save(Path.Combine(AppData.OutputFolderPath + @"\", $"{filename}.{AppData.OutputFileType.ToString().ToLower()}"), AppData.OutputFileType);
                            }

                            //カウント
                            lock (lockobject)
                            {
                                cnt++;

                                //formに進捗表示
                                form.Invoke(() =>
                                {
                                    form.sintyoku.Text = cnt + " / " + ActiveFilesLength;
                                });
                            }

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
                MoveErrorList.Clear();
            }

            AppData.converting = false;
        }
    }
}
#pragma warning restore CA1416 // プラットフォームの互換性を検証
