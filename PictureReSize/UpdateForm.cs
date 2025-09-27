using System.Windows.Forms;

namespace PictureReSize
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
        }

        internal void SetProgress(int p)
        {
            this.progressBar1.Value = p;
        }

        private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
