using System;
using System.Windows.Forms;

namespace PictureReSize
{
    public partial class SettingSaveForm : Form
    {
        private string Input_Datatype { get; }
        private string Output_Datatype { get; }

        public SettingSaveForm(string input_datatype, string output_datatype)
        {
            InitializeComponent();
            input_label.Text = input_datatype;
            output_label.Text = output_datatype.ToString();

            before_inputtype_label.Text = "Input : " + Properties.Settings.Default.IntputFileType;
            before_Outputtype_label.Text = "Output : " + OutputDataType.GetNameOutputDataType(Properties.Settings.Default.OutputFileType);

            Input_Datatype = input_datatype;
            Output_Datatype = output_datatype;
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.IntputFileType = Input_Datatype;
            Properties.Settings.Default.OutputFileType = OutputDataType.GetIntOutputDataType(Output_Datatype);
            Properties.Settings.Default.Save();
            this.Close();
            this.Dispose();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.IntputFileType = "jpg";
            Properties.Settings.Default.OutputFileType = 2;
            Properties.Settings.Default.Save();
            this.Close();
            MessageBox.Show("初期値で設定を保存しました　再起動後に適用されます", "お知らせ。", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }
    }
}
