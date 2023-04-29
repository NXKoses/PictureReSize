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
        private readonly List<string> MoveErrorList = new();
        private int ActiveFilesLength;
        public void PictureFileCheckAsync()
        {
            //変換元フォルダに変換対象画像があるか確認
            var vs = Directory.GetFiles(Data.InputFolderPath, "*." + Data.InputFileType);
            if (vs.Length == 0)
            {
                MessageBox.Show("フォルダの中に変換できるものがありませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //グローバル変数に変換対象の画像数を代入
            ActiveFilesLength = vs.Length;

            Debug.WriteLine("thread_Value : " + Data.thread_Value + "で実行します。");
            Resizer(); // 変換実行
        }

        private async Task Resizer()
        {
            var files = Directory.GetFiles(Data.InputFolderPath, "*." + Data.InputFileType);

            int cnt = 0;
            Data.converting = true;

            await Task.Run(() =>
            {
                ParallelOptions option = new()
                {
                    MaxDegreeOfParallelism = Data.thread_Value
                };

                //並列処理を利用する
                Parallel.ForEach(files, option, stFilePath =>
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

                        //画像を変換する
                        using Bitmap resizeBmp = new Bitmap(resizeWidth, resizeHeight);
                        using Graphics g = Graphics.FromImage(resizeBmp);
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(bitmap, 0, 0, resizeWidth, resizeHeight);

                        resizeBmp.Save(
                            Path.Combine(Data.OutputFolderPath + @"\",
                                $"{filename}.{Data.OutputFileType.ToString().ToLower()}"), Data.OutputFileType);

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

            Function.TempDelete();
            MessageBox.Show(cnt + "/" + ActiveFilesLength + "個変換しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (MoveErrorList.Count != 0) //エラーが有る場合、MoveErrorListの中身を表示します
            {
                string erroritemlist = "";
                foreach (var item in MoveErrorList)
                {
                    erroritemlist += Environment.NewLine + item;
                }
                MessageBox.Show(erroritemlist + Environment.NewLine + "以下の画像の保存に失敗しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Data.converting = false;
        }
    }
}
