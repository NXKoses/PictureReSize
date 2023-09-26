using PictureReSize.component;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PictureReSize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Xtextbox.Text = "1920";
            Ytextbox.Text = "1080";
            InputTypetextbox.Text = Properties.Settings.Default.IntputFileType;
            OutputTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            OutputTypeComboBox.SelectedIndex = Properties.Settings.Default.OutputFileType;
            InputtextBox.Text = "選択してください";
            OutputtextBox.Text = "選択してください";
            InputFileListBox.Visible = false;
            InputFileListRemoveButton.Visible = false;
            ConvertModeSelect_comboBox.SelectedIndex = 0;
            InputButton.Select();

            AppData.Appname = this.Text;
            Function.TempDelete();
            this.Text += " 1.0.4.0";
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            //画面表示
            var selectpath = FolderSelecter.FolderSelect();

            //何もしなかったら戻る
            if (selectpath == string.Empty) return;

            //Formに表示
            InputtextBox.Text = selectpath + @"\";

            //変換リストに追加する
            Change_input_list_Add(selectpath);

            Debug.WriteLine("InputPath: " + selectpath);
        }

        private void OutputButton_Click(object sender, EventArgs e)
        {
            //画面表示
            var selectpath = FolderSelecter.FolderSelect();

            //何もしなかったら戻る
            if (selectpath == string.Empty) return;

            //出力先フォルダを入れておく
            AppData.OutputFolderPath = selectpath + @"\";

            //Formに表示
            OutputtextBox.Text = selectpath + @"\";

            Debug.WriteLine("OutputPath: " + selectpath);
        }

        private void HenkanButton_Click(object sender, EventArgs e)
        {
            if (AppData.converting)
            {
                MessageBox.Show("変換中です。　そんなに急がないで(´；ω；｀)", "（＜・＞ω＜・＞）", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Function.TempDelete();

            AppData.InputFileType = InputTypetextbox.Text;
            AppData.OutputFileType = OutputDataType.GetImageFormatOutputDataType(this.OutputTypeComboBox.SelectedItem.ToString());
            AppData.X = int.Parse(Xtextbox.Text);
            AppData.Y = int.Parse(Ytextbox.Text);
            AppData.aspect_lock = aspect_ratioCheckBox.Checked;

            var inputcheck = 0;
            if (AppData.InputFileType.Length == 0) inputcheck++;
            if (AppData.OutputFolderPath == string.Empty) inputcheck++;
            if (AppData.multiple_folder_synchronous_entry) inputcheck--;

            if (inputcheck != 0)
            {
                MessageBox.Show("入力内容を確認してください", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            //変換実行
            new component.Convert().Run(this);
        }

        private void InputFileListRemoveButton_Click(object sender, EventArgs e)
        {
            if (AppData.multiple_folder_entry | AppData.multiple_folder_synchronous_entry)
            {
                if (InputFileListBox.SelectedIndex == -1) return;

                Debug.WriteLine(InputFileListBox.Text);

                //変換リスト、Formから削除
                AppData.inputFolderListPath.Remove(InputFileListBox.Text);
                InputFileListBox.Items.RemoveAt(InputFileListBox.SelectedIndex);
            }
        }

        private void kakucho_button_Click(object sender, EventArgs e)
        {
            using KakuchoSettingForm ksf = new()
            {
                StartPosition = FormStartPosition.Manual,
                Location = this.Location
            };

            ksf.ShowDialog();
        }

        private void settingsave_button_Click(object sender, EventArgs e)
        {
            using SettingSaveForm sform = new(InputTypetextbox.Text, OutputTypeComboBox.SelectedItem.ToString())
            {
                StartPosition = FormStartPosition.Manual,
                Location = this.Location
            };

            sform.ShowDialog();
        }

        /// <summary>
        /// 変換リストに指定したパスを追加します。
        /// </summary>
        /// <param name="inputpath"></param>
        private void Change_input_list_Add(string inputpath)
        {
            //変換リストに追加する
            AppData.inputFolderListPath.Add(inputpath);

            //表示用
            InputFileListBox.Items.Add(inputpath);
        }

        /// <summary>
        /// comboboxの選択肢によってformの表示を切り替えます
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertModeSelect_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //初期化
            AppData.inputFolderListPath.Clear();
            InputFileListBox.Items.Clear();
            AppData.OutputFolderPath = string.Empty;

            if ((ConvertModeSelect_comboBox.SelectedIndex == 1) | (ConvertModeSelect_comboBox.SelectedIndex == 2))
            {
                if (ConvertModeSelect_comboBox.SelectedIndex == 1)
                {
                    AppData.multiple_folder_entry = true;
                    AppData.multiple_folder_synchronous_entry = false;
                    OutputButton.Visible = true;
                    OutputtextBox.Visible = true;
                }

                if (ConvertModeSelect_comboBox.SelectedIndex == 2)
                {
                    AppData.multiple_folder_synchronous_entry = true;
                    AppData.multiple_folder_entry = false;
                    OutputButton.Visible = false;
                    OutputtextBox.Visible = false;
                }

                InputtextBox.Visible = false;
                InputFileListBox.Visible = true;
                InputFileListRemoveButton.Visible = true;
                InputButton.Text = "追加";
            }
            else
            {
                OutputButton.Visible = true;
                OutputtextBox.Visible = true;
                InputtextBox.Visible = true;

                OutputtextBox.Text = AppData.OutputFolderPath;
                InputtextBox.Text = "";
                InputFileListBox.Visible = false;
                InputFileListRemoveButton.Visible = false;
                AppData.multiple_folder_entry = false;
                AppData.multiple_folder_synchronous_entry = false;
                InputButton.Text = "入力";
            }
        }
    }
}
