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
            enter_button = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            thread_Value_textBox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // enter_button
            // 
            enter_button.Location = new System.Drawing.Point(114, 78);
            enter_button.Margin = new System.Windows.Forms.Padding(4);
            enter_button.Name = "enter_button";
            enter_button.Size = new System.Drawing.Size(88, 29);
            enter_button.TabIndex = 0;
            enter_button.Text = "決定";
            enter_button.UseVisualStyleBackColor = true;
            enter_button.Click += enter_button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(14, 11);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(101, 15);
            label1.TabIndex = 1;
            label1.Text = "画像変換スレッド数";
            // 
            // thread_Value_textBox
            // 
            thread_Value_textBox.Location = new System.Drawing.Point(136, 8);
            thread_Value_textBox.Margin = new System.Windows.Forms.Padding(4);
            thread_Value_textBox.Name = "thread_Value_textBox";
            thread_Value_textBox.Size = new System.Drawing.Size(66, 23);
            thread_Value_textBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.Red;
            label2.Location = new System.Drawing.Point(0, 35);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(164, 30);
            label2.TabIndex = 3;
            label2.Text = "※速さは上がりますが、\r\n増やせば増やすほど重くなります。";
            // 
            // KakuchoSettingForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(241, 150);
            ControlBox = false;
            Controls.Add(label2);
            Controls.Add(thread_Value_textBox);
            Controls.Add(label1);
            Controls.Add(enter_button);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            Name = "KakuchoSettingForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "KakuchoSettingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button enter_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox thread_Value_textBox;
        private System.Windows.Forms.Label label2;
    }
}