namespace PictureReSize
{
    partial class SettingSaveForm
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
            save_button = new System.Windows.Forms.Button();
            reset_button = new System.Windows.Forms.Button();
            close_button = new System.Windows.Forms.Button();
            before_Outputtype_label = new System.Windows.Forms.Label();
            before_inputtype_label = new System.Windows.Forms.Label();
            output_label = new System.Windows.Forms.Label();
            input_label = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // save_button
            // 
            save_button.Location = new System.Drawing.Point(12, 12);
            save_button.Name = "save_button";
            save_button.Size = new System.Drawing.Size(75, 23);
            save_button.TabIndex = 0;
            save_button.Text = "設定保存";
            save_button.UseVisualStyleBackColor = true;
            save_button.Click += save_button_Click;
            // 
            // reset_button
            // 
            reset_button.BackColor = System.Drawing.SystemColors.ControlLight;
            reset_button.Location = new System.Drawing.Point(12, 71);
            reset_button.Name = "reset_button";
            reset_button.Size = new System.Drawing.Size(75, 23);
            reset_button.TabIndex = 1;
            reset_button.Text = "設定リセット";
            reset_button.UseVisualStyleBackColor = false;
            reset_button.Click += reset_button_Click;
            // 
            // close_button
            // 
            close_button.Location = new System.Drawing.Point(93, 71);
            close_button.Name = "close_button";
            close_button.Size = new System.Drawing.Size(160, 23);
            close_button.TabIndex = 2;
            close_button.Text = "閉じる";
            close_button.UseVisualStyleBackColor = true;
            close_button.Click += close_button_Click;
            // 
            // before_Outputtype_label
            // 
            before_Outputtype_label.AutoSize = true;
            before_Outputtype_label.BackColor = System.Drawing.SystemColors.AppWorkspace;
            before_Outputtype_label.Location = new System.Drawing.Point(102, 16);
            before_Outputtype_label.Name = "before_Outputtype_label";
            before_Outputtype_label.Size = new System.Drawing.Size(43, 15);
            before_Outputtype_label.TabIndex = 3;
            before_Outputtype_label.Text = "output";
            // 
            // before_inputtype_label
            // 
            before_inputtype_label.AutoSize = true;
            before_inputtype_label.BackColor = System.Drawing.SystemColors.AppWorkspace;
            before_inputtype_label.Location = new System.Drawing.Point(110, 31);
            before_inputtype_label.Name = "before_inputtype_label";
            before_inputtype_label.Size = new System.Drawing.Size(35, 15);
            before_inputtype_label.TabIndex = 4;
            before_inputtype_label.Text = "input";
            // 
            // output_label
            // 
            output_label.AutoSize = true;
            output_label.BackColor = System.Drawing.Color.Silver;
            output_label.Location = new System.Drawing.Point(215, 16);
            output_label.Name = "output_label";
            output_label.Size = new System.Drawing.Size(38, 15);
            output_label.TabIndex = 5;
            output_label.Text = "label3";
            // 
            // input_label
            // 
            input_label.AutoSize = true;
            input_label.BackColor = System.Drawing.Color.Silver;
            input_label.Location = new System.Drawing.Point(215, 31);
            input_label.Name = "input_label";
            input_label.Size = new System.Drawing.Size(38, 15);
            input_label.TabIndex = 6;
            input_label.Text = "label4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(93, 1);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(136, 15);
            label3.TabIndex = 7;
            label3.Text = "以下の値で保存しますか？";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(180, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(29, 15);
            label1.TabIndex = 8;
            label1.Text = "   ->";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(180, 31);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(29, 15);
            label2.TabIndex = 9;
            label2.Text = "   ->";
            // 
            // SettingSaveForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(287, 138);
            ControlBox = false;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(input_label);
            Controls.Add(output_label);
            Controls.Add(before_inputtype_label);
            Controls.Add(before_Outputtype_label);
            Controls.Add(close_button);
            Controls.Add(reset_button);
            Controls.Add(save_button);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "SettingSaveForm";
            Text = "SettingSaveForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button reset_button;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Label before_Outputtype_label;
        private System.Windows.Forms.Label before_inputtype_label;
        private System.Windows.Forms.Label output_label;
        private System.Windows.Forms.Label input_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}