namespace PictureReSize
{
    partial class KakuchoSettingForm
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
            this.enter_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.thread_Value_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // enter_button
            // 
            this.enter_button.Location = new System.Drawing.Point(115, 148);
            this.enter_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.enter_button.Name = "enter_button";
            this.enter_button.Size = new System.Drawing.Size(88, 29);
            this.enter_button.TabIndex = 0;
            this.enter_button.Text = "決定";
            this.enter_button.UseVisualStyleBackColor = true;
            this.enter_button.Click += new System.EventHandler(this.enter_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "画像変換スレッド数";
            // 
            // thread_Value_textBox
            // 
            this.thread_Value_textBox.Location = new System.Drawing.Point(136, 8);
            this.thread_Value_textBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.thread_Value_textBox.Name = "thread_Value_textBox";
            this.thread_Value_textBox.Size = new System.Drawing.Size(66, 23);
            this.thread_Value_textBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(0, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "※速さは上がりますが、\r\n増やせば増やすほど重くなります。";
            // 
            // KakuchoSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 191);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.thread_Value_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enter_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "KakuchoSettingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "KakuchoSettingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enter_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox thread_Value_textBox;
        private System.Windows.Forms.Label label2;
    }
}