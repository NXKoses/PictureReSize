using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PictureReSize
{
    /// <summary>
    /// アプリ全体で使うデータ
    /// </summary>
    public static class AppSettingData
    {
        public static string GetAppPath() => Application.StartupPath;

        public static bool Converting { get; set; } = false;
    }

    /// <summary>
    /// 変換モード
    /// </summary>
    enum ConvertMode
    {
        Normal,
        Multiple,
        Multiple_Folder_Sync
    }
}
