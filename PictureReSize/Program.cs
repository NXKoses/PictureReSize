using System;
using System.Windows.Forms;

namespace PictureReSize
{
    static class Program
    {
        public static string GetAppPath() => Application.StartupPath;

        public static bool Converting = false;

        /// <summary>
        /// 変換モード
        /// </summary>
        public enum ConvertMode
        {
            Normal,
            Multiple,
            Multiple_Folder_Sync
        }
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
