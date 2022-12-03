using Microsoft.WindowsAPICodePack.Dialogs;

namespace PictureReSize.component
{
    public class FolderSelecter
    {
        public static string FolderSelect()
        {
            // ダイアログのインスタンスを生成
            using CommonOpenFileDialog dialog = new("フォルダーの選択")
            {
                // 選択形式をフォルダースタイルに
                IsFolderPicker = true,
            };

            // ダイアログを表示
            return dialog.ShowDialog() == CommonFileDialogResult.Ok ? dialog.FileName : "none";
        }
    }
}
