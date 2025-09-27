namespace PictureReSize
{
    partial class UpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            progressBar1 = new System.Windows.Forms.ProgressBar();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point(12, 36);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(400, 23);
            progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(113, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(206, 15);
            label1.TabIndex = 1;
            label1.Text = "ダウンロード中です。しばらくお待ちください。";
            // 
            // UpdateForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(424, 70);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "UpdateForm";
            FormClosing += UpdateForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
    }
}