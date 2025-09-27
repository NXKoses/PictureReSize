using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows.Forms;
using Velopack;

namespace PictureReSize
{
    static class Program
    {
        public static string GetAppPath() => Application.StartupPath;

        public static string AppVersion { get; private set; } = string.Empty;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            VelopackApp.Build().Run();

            // アプリケーションのバージョン情報を取得
            var assembly = Assembly.GetExecutingAssembly().GetName();
            var version = assembly.Version;
            AppVersion = version.ToString(3);

            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
