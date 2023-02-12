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
            this.save_button = new System.Windows.Forms.Button();
            this.reset_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.before_Outputtype_label = new System.Windows.Forms.Label();
            this.before_inputtype_label = new System.Windows.Forms.Label();
            this.output_label = new System.Windows.Forms.Label();
            this.input_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(12, 12);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 0;
            this.save_button.Text = "設定保存";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // reset_button
            // 
            this.reset_button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.reset_button.Location = new System.Drawing.Point(12, 71);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(75, 23);
            this.reset_button.TabIndex = 1;
            this.reset_button.Text = "設定リセット";
            this.reset_button.UseVisualStyleBackColor = false;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(93, 71);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(160, 23);
            this.close_button.TabIndex = 2;
            this.close_button.Text = "閉じる";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // before_Outputtype_label
            // 
            this.before_Outputtype_label.AutoSize = true;
            this.before_Outputtype_label.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.before_Outputtype_label.Location = new System.Drawing.Point(102, 16);
            this.before_Outputtype_label.Name = "before_Outputtype_label";
            this.before_Outputtype_label.Size = new System.Drawing.Size(43, 15);
            this.before_Outputtype_label.TabIndex = 3;
            this.before_Outputtype_label.Text = "output";
            // 
            // before_inputtype_label
            // 
            this.before_inputtype_label.AutoSize = true;
            this.before_inputtype_label.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.before_inputtype_label.Location = new System.Drawing.Point(110, 31);
            this.before_inputtype_label.Name = "before_inputtype_label";
            this.before_inputtype_label.Size = new System.Drawing.Size(35, 15);
            this.before_inputtype_label.TabIndex = 4;
            this.before_inputtype_label.Text = "input";
            // 
            // output_label
            // 
            this.output_label.AutoSize = true;
            this.output_label.BackColor = System.Drawing.Color.Silver;
            this.output_label.Location = new System.Drawing.Point(215, 16);
            this.output_label.Name = "output_label";
            this.output_label.Size = new System.Drawing.Size(38, 15);
            this.output_label.TabIndex = 5;
            this.output_label.Text = "label3";
            // 
            // input_label
            // 
            this.input_label.AutoSize = true;
            this.input_label.BackColor = System.Drawing.Color.Silver;
            this.input_label.Location = new System.Drawing.Point(215, 31);
            this.input_label.Name = "input_label";
            this.input_label.Size = new System.Drawing.Size(38, 15);
            this.input_label.TabIndex = 6;
            this.input_label.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "以下の値で保存しますか？";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "   ->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "   ->";
            // 
            // SettingSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 99);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.input_label);
            this.Controls.Add(this.output_label);
            this.Controls.Add(this.before_inputtype_label);
            this.Controls.Add(this.before_Outputtype_label);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.reset_button);
            this.Controls.Add(this.save_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingSaveForm";
            this.Text = "SettingSaveForm";
            this.ResumeLayout(false);
            this.PerformLayout();

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