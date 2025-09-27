using PictureReSize.component;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Convert = PictureReSize.component.Convert;

namespace PictureReSize
{
    public partial class MainWindow : Form
    {
        private readonly List<string> inputFolder_list_path = new();
        private string output_path = "";

        public MainWindow()
        {
            InitializeComponent();

            // コントロールの初期化
            Xtextbox.Text = "1920";
            Ytextbox.Text = "1080";

            // 設定から呼び出す
            InputTypetextbox.Text = Properties.Settings.Default.IntputFileType;
            OutputTypeComboBox.SelectedIndex = Properties.Settings.Default.OutputFileType;

            OutputTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            InputtextBox.Text = "選択してください";
            OutputtextBox.Text = "選択してください";
            InputFileListBox.Visible = false;
            InputFileListRemoveButton.Visible = false;
            ConvertModeSelect_comboBox.SelectedIndex = 0;
            InputButton.Select();

            this.Text += $" Ver: {Program.AppVersion}";
        }

        private async void MainWindow_LoadAsync(object sender, EventArgs e)
        {
            // 更新を確認する
            await UpdateProcess.CheckForUpdateAsync(this);
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            // 画面表示
            var selectpath = FolderSelecter.FolderSelect();

            // 何もしなかったら戻る
            if (selectpath == string.Empty) return;

            // Formに表示
            InputtextBox.Text = selectpath + @"\";

            // 変換リストに追加する
            Change_input_list_Add(selectpath);

            Debug.WriteLine("InputPath: " + selectpath);
        }

        private void OutputButton_Click(object sender, EventArgs e)
        {
            // 画面表示
            var selectpath = FolderSelecter.FolderSelect();

            // 何もしなかったら戻る
            if (selectpath == string.Empty) return;

            // 出力先フォルダを入れておく
            output_path = selectpath + @"\";

            // Formに表示
            OutputtextBox.Text = selectpath + @"\";

            Debug.WriteLine("OutputPath: " + selectpath);
        }

        /// <summary>
        /// 画面に正しい情報が入力されているかチェックします。
        /// </summary>
        /// <returns>0 正常</returns>
        private int Form_InputCheck()
        {
            if (Convert.Converting)
            {
                MessageBox.Show("変換中です。そんなに急がないで(´；ω；｀)", "（＜・＞ω＜・＞）", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }

            if (inputFolder_list_path.Count <= 0)
            {
                MessageBox.Show("変換するフォルダを選択してください", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -2;
            }

            if (output_path.Length <= 0 && ConvertModeSelect_comboBox.SelectedIndex != 2)
            {
                MessageBox.Show("出力先フォルダを選択してください", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -3;
            }

            if (Xtextbox.Text.Length <= 0 || Ytextbox.Text.Length <= 0 || InputTypetextbox.Text.Length <= 0)
            {
                MessageBox.Show("入力値が不足しています。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -4;
            }

            return 0;
        }

        /// <summary>
        /// 変換ボタンを押したときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HenkanButton_Click(object sender, EventArgs e)
        {
            // 画面に正しい情報が入力されているかチェック
            if (Form_InputCheck() != 0) return;

            // 出力ファイル形式を設定
            ImageFormat imageFormat = OutputTypeComboBox.SelectedIndex switch
            {
                0 => ImageFormat.Bmp,
                1 => ImageFormat.Jpeg,
                2 => ImageFormat.Png,
                _ => ImageFormat.Png,
            };

            // TODO モデルに分ける
            var cvt = new Convert()
            {
                InputFolderListPath = inputFolder_list_path,                        // 変換フォルダリスト

                InputFileType = InputTypetextbox.Text,                              // 入力ファイル拡張子
                OutputFolderPath = output_path,                                     // 出力フォルダパス
                OutputFileType = imageFormat,                                       // 出力ファイル拡張子

                X = int.Parse(Xtextbox.Text),                                       // 変換後のX解像度
                Y = int.Parse(Ytextbox.Text),                                       // 変換後のY解像度
                Aspect_lock = aspect_ratioCheckBox.Checked,                         // アスペクト比ロック

                ConvertMode = (ConvertMode)ConvertModeSelect_comboBox.SelectedIndex,// 変換モード
                Thread_Value = -1                                                   // 並列同期数
            };

            // 変換実行
            cvt.Convert_Run(this);
        }

        /// <summary>
        /// 変換リストから指定したパスを削除します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputFileListRemoveButton_Click(object sender, EventArgs e)
        {
            if (ConvertModeSelect_comboBox.SelectedIndex is 1 or 2)
            {
                if (InputFileListBox.SelectedIndex == -1) return;

                Debug.WriteLine(InputFileListBox.Text);

                // 変換リスト、Formから削除
                inputFolder_list_path.Remove(InputFileListBox.Text);
                InputFileListBox.Items.RemoveAt(InputFileListBox.SelectedIndex);
            }
        }

        /// <summary>
        /// 変換リストに指定したパスを追加します。
        /// </summary>
        /// <param name="inputpath"></param>
        private void Change_input_list_Add(string inputpath)
        {
            // 変換リストに追加する
            inputFolder_list_path.Add(inputpath);

            // 表示用
            InputFileListBox.Items.Add(inputpath);
        }

        /// <summary>
        /// comboboxの選択肢によってformの表示を切り替えます
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertModeSelect_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 初期化
            inputFolder_list_path.Clear();
            InputFileListBox.Items.Clear();

            // 複数変換、複数同期変換のとき
            if (ConvertModeSelect_comboBox.SelectedIndex is 1 or 2)
            {
                // 複数変換のとき
                if (ConvertModeSelect_comboBox.SelectedIndex == 1)
                {
                    OutputButton.Visible = true;
                    OutputtextBox.Visible = true;
                }

                // 複数同期変換のとき
                if (ConvertModeSelect_comboBox.SelectedIndex == 2)
                {
                    OutputButton.Visible = false;
                    OutputtextBox.Visible = false;
                }

                // 複数変換、複数同期変換の共通して変更するところ
                InputtextBox.Visible = false;
                InputFileListBox.Visible = true;
                InputFileListRemoveButton.Visible = true;
                InputButton.Text = "追加";
            }

            // 通常変換のとき
            else
            {
                OutputButton.Visible = true;
                OutputtextBox.Visible = true;
                InputtextBox.Visible = true;

                OutputtextBox.Text = output_path;
                InputtextBox.Text = "";
                InputFileListBox.Visible = false;
                InputFileListRemoveButton.Visible = false;
                InputButton.Text = "入力";
            }
        }

        /// <summary>
        /// 設定を保存します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingSave_toolStripButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.IntputFileType = InputTypetextbox.Text;
            Properties.Settings.Default.OutputFileType = OutputTypeComboBox.SelectedIndex;
            Properties.Settings.Default.Save();

            MessageBox.Show("設定を保存しました", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// InputButtonにドラッグされたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputButton_DragDrop(object sender, DragEventArgs e)
        {
            // もしドラッグされたものがフォルダならドラッグされたアイテムのフォルダパスを取得する
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 通常変換のときは複数ドラッグは受け付けないようにする
                if (((string[])e.Data.GetData(DataFormats.FileDrop)).Length != 1 & ConvertModeSelect_comboBox.SelectedIndex == 0)
                {
                    MessageBox.Show("複数選択できません。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectpath = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (var path in selectpath)
                {
                    // フォルダなら
                    if (System.IO.Directory.Exists(path))
                    {
                        // Formに表示
                        InputtextBox.Text = path + @"\";

                        // 変換リストに追加する
                        Change_input_list_Add(path);

                        Debug.WriteLine("InputPath: " + path);
                    }
                    else
                    {
                        MessageBox.Show("フォルダをドラッグしてください。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// OutputButtonにドラッグされたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputButton_DragDrop(object sender, DragEventArgs e)
        {
            // もしドラッグされたものがフォルダならドラッグされたアイテムのフォルダパスを取得する
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 複数ドラッグは受け付けないようにする
                if (((string[])e.Data.GetData(DataFormats.FileDrop)).Length != 1)
                {
                    MessageBox.Show("複数選択できません。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectpath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

                // フォルダなら
                if (System.IO.Directory.Exists(selectpath))
                {
                    // Formに表示
                    OutputtextBox.Text = selectpath + @"\";

                    // 変換リストに追加する
                    output_path = selectpath;

                    Debug.WriteLine("OutputPath: " + selectpath);
                }
                else
                {
                    MessageBox.Show("フォルダをドラッグしてください。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void InputButton_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void OutputButton_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        // 解像度の「x」を押したとき
        // 解像度を入れ替える
        private void label1_Click(object sender, EventArgs e)
        {
            (Ytextbox.Text, Xtextbox.Text) = (Xtextbox.Text, Ytextbox.Text);
        }

    }
}
