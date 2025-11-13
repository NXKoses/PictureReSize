using System.Windows.Forms;

namespace PictureReSize.component
{
    public class FolderSelecter
    {
        public static string FolderSelect()
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "フォルダを選択してください";
            dialog.FileName = "フォルダを選択してください";
            dialog.Filter = "フォルダ|.";
            dialog.CheckFileExists = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = System.IO.Path.GetDirectoryName(dialog.FileName) ?? string.Empty;
                return folderPath;
            }
            return string.Empty;
        }
    }
}
