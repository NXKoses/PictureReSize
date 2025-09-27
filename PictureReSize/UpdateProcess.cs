using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Velopack;
using Velopack.Sources;

namespace PictureReSize
{
    internal class UpdateProcess
    {
        private const string GITHUB_URL = "https://github.com/NXKoses/VelopackTest";

        public static async Task CheckForUpdateAsync(Form form)
        {
            try
            {
                var mgr = new UpdateManager(new GithubSource(@GITHUB_URL, null, false));

                if (!mgr.IsInstalled)
                {
                    // インストールされていない場合
                    MessageBox.Show("更新を確認できませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 新しいバージョンがないかをチェックする
                var newVersion = await mgr.CheckForUpdatesAsync();
                if (newVersion == null)
                {
                    return; // 新しいバージョンがない場合は何もしない
                }

                var result = MessageBox.Show("新しいバージョンが見つかりました。更新しますか？", "更新", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    form.Hide(); // メインフォームを隠す
                    var updateForm = new UpdateForm();
                    updateForm.Show();

                    // 進捗を反映させる
                    var progress = new Action<int>(p =>
                    {
                        updateForm.SetProgress(p); // プログレスバー更新
                    });

                    // ダウンロード開始
                    await mgr.DownloadUpdatesAsync(newVersion, progress);

                    updateForm.Close();
                    // アップデート
                    mgr.ApplyUpdatesAndRestart(newVersion);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show($"更新確認処理または更新処理に失敗しました。： {e.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
