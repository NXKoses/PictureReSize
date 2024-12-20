namespace PictureReSize
{
    partial class UpdateHistoryWindow
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
            info_richTextBox = new System.Windows.Forms.RichTextBox();
            ok_button = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // info_richTextBox
            // 
            info_richTextBox.BackColor = System.Drawing.Color.Gainsboro;
            info_richTextBox.Location = new System.Drawing.Point(12, 12);
            info_richTextBox.Name = "info_richTextBox";
            info_richTextBox.ReadOnly = true;
            info_richTextBox.Size = new System.Drawing.Size(453, 349);
            info_richTextBox.TabIndex = 1;
            info_richTextBox.Text = "";
            // 
            // ok_button
            // 
            ok_button.Location = new System.Drawing.Point(380, 367);
            ok_button.Name = "ok_button";
            ok_button.Size = new System.Drawing.Size(85, 23);
            ok_button.TabIndex = 2;
            ok_button.Text = "OK";
            ok_button.UseVisualStyleBackColor = true;
            ok_button.Click += ok_button_Click;
            // 
            // UpdateHistoryWindow
            // 
            AcceptButton = ok_button;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(477, 397);
            ControlBox = false;
            Controls.Add(ok_button);
            Controls.Add(info_richTextBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateHistoryWindow";
            Text = "更新履歴";
            Load += UpdateHistoryWindow_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.RichTextBox info_richTextBox;
        private System.Windows.Forms.Button ok_button;
    }
}