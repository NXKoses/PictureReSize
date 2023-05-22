using System;
using System.Windows.Forms;

namespace PictureReSize
{
    public partial class KakuchoSettingForm : Form
    {
        public KakuchoSettingForm()
        {
            InitializeComponent();
            thread_Value_textBox.Text = AppData.thread_Value.ToString();
        }

        private void enter_button_Click(object sender, EventArgs e)
        {
            int val;
            if (int.TryParse(thread_Value_textBox.Text, out val) == true)
            {
                AppData.thread_Value = val;
            }
            else
            {
                MessageBox.Show("数字を入力してください", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Close();
            this.Dispose();
        }
    }
}
