
namespace PictureReSize
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new System.Windows.Forms.GroupBox();
            settingsave_button = new System.Windows.Forms.Button();
            OutputTypeComboBox = new System.Windows.Forms.ComboBox();
            kakucho_button = new System.Windows.Forms.Button();
            FukusuCheckbox = new System.Windows.Forms.CheckBox();
            aspect_ratioCheckBox = new System.Windows.Forms.CheckBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            InputTypetextbox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            Ytextbox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            Xtextbox = new System.Windows.Forms.TextBox();
            HenkanButton = new System.Windows.Forms.Button();
            InputButton = new System.Windows.Forms.Button();
            OutputButton = new System.Windows.Forms.Button();
            InputtextBox = new System.Windows.Forms.TextBox();
            OutputtextBox = new System.Windows.Forms.TextBox();
            InputFileListBox = new System.Windows.Forms.ListBox();
            InputFileListRemoveButton = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(settingsave_button);
            groupBox1.Controls.Add(OutputTypeComboBox);
            groupBox1.Controls.Add(kakucho_button);
            groupBox1.Controls.Add(FukusuCheckbox);
            groupBox1.Controls.Add(aspect_ratioCheckBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(InputTypetextbox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Ytextbox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Xtextbox);
            groupBox1.Location = new System.Drawing.Point(12, 13);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Size = new System.Drawing.Size(239, 220);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "基本設定";
            // 
            // settingsave_button
            // 
            settingsave_button.Location = new System.Drawing.Point(189, 102);
            settingsave_button.Name = "settingsave_button";
            settingsave_button.Size = new System.Drawing.Size(44, 23);
            settingsave_button.TabIndex = 12;
            settingsave_button.Text = "保存";
            settingsave_button.UseVisualStyleBackColor = true;
            settingsave_button.Click += settingsave_button_Click;
            // 
            // OutputTypeComboBox
            // 
            OutputTypeComboBox.FormattingEnabled = true;
            OutputTypeComboBox.Items.AddRange(new object[] { "bmp", "icon", "jpeg", "png" });
            OutputTypeComboBox.Location = new System.Drawing.Point(108, 101);
            OutputTypeComboBox.Name = "OutputTypeComboBox";
            OutputTypeComboBox.Size = new System.Drawing.Size(75, 26);
            OutputTypeComboBox.TabIndex = 11;
            // 
            // kakucho_button
            // 
            kakucho_button.Location = new System.Drawing.Point(129, 183);
            kakucho_button.Name = "kakucho_button";
            kakucho_button.Size = new System.Drawing.Size(78, 30);
            kakucho_button.TabIndex = 10;
            kakucho_button.Text = "拡張設定";
            kakucho_button.UseVisualStyleBackColor = true;
            kakucho_button.Click += kakucho_button_Click;
            // 
            // FukusuCheckbox
            // 
            FukusuCheckbox.AutoSize = true;
            FukusuCheckbox.Location = new System.Drawing.Point(9, 191);
            FukusuCheckbox.Name = "FukusuCheckbox";
            FukusuCheckbox.Size = new System.Drawing.Size(75, 22);
            FukusuCheckbox.TabIndex = 9;
            FukusuCheckbox.Text = "複数選択";
            FukusuCheckbox.UseVisualStyleBackColor = true;
            FukusuCheckbox.CheckedChanged += FukusuCheckbox_CheckedChanged;
            // 
            // aspect_ratioCheckBox
            // 
            aspect_ratioCheckBox.AutoSize = true;
            aspect_ratioCheckBox.Checked = true;
            aspect_ratioCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            aspect_ratioCheckBox.Location = new System.Drawing.Point(9, 155);
            aspect_ratioCheckBox.Name = "aspect_ratioCheckBox";
            aspect_ratioCheckBox.Size = new System.Drawing.Size(159, 22);
            aspect_ratioCheckBox.TabIndex = 8;
            aspect_ratioCheckBox.Text = "アスペクト比を維持する";
            aspect_ratioCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 134);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(184, 18);
            label4.TabIndex = 7;
            label4.Text = "➖➖➖➖➖➖➖➖➖➖➖";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 104);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(68, 18);
            label3.TabIndex = 5;
            label3.Text = "出力拡張子";
            // 
            // InputTypetextbox
            // 
            InputTypetextbox.Location = new System.Drawing.Point(108, 66);
            InputTypetextbox.Name = "InputTypetextbox";
            InputTypetextbox.Size = new System.Drawing.Size(75, 25);
            InputTypetextbox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 69);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(92, 18);
            label2.TabIndex = 3;
            label2.Text = "読み取る拡張子";
            // 
            // Ytextbox
            // 
            Ytextbox.Location = new System.Drawing.Point(108, 25);
            Ytextbox.Name = "Ytextbox";
            Ytextbox.Size = new System.Drawing.Size(75, 25);
            Ytextbox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(87, 33);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(15, 18);
            label1.TabIndex = 1;
            label1.Text = "x";
            // 
            // Xtextbox
            // 
            Xtextbox.Location = new System.Drawing.Point(6, 25);
            Xtextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Xtextbox.Name = "Xtextbox";
            Xtextbox.Size = new System.Drawing.Size(75, 25);
            Xtextbox.TabIndex = 0;
            // 
            // HenkanButton
            // 
            HenkanButton.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            HenkanButton.Location = new System.Drawing.Point(12, 342);
            HenkanButton.Name = "HenkanButton";
            HenkanButton.Size = new System.Drawing.Size(593, 65);
            HenkanButton.TabIndex = 1;
            HenkanButton.Text = "変換";
            HenkanButton.UseVisualStyleBackColor = true;
            HenkanButton.Click += HenkanButton_Click;
            // 
            // InputButton
            // 
            InputButton.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            InputButton.Location = new System.Drawing.Point(12, 240);
            InputButton.Name = "InputButton";
            InputButton.Size = new System.Drawing.Size(295, 65);
            InputButton.TabIndex = 2;
            InputButton.Text = "入力";
            InputButton.UseVisualStyleBackColor = true;
            InputButton.Click += InputButton_Click;
            // 
            // OutputButton
            // 
            OutputButton.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            OutputButton.Location = new System.Drawing.Point(313, 240);
            OutputButton.Name = "OutputButton";
            OutputButton.Size = new System.Drawing.Size(292, 65);
            OutputButton.TabIndex = 3;
            OutputButton.Text = "出力";
            OutputButton.UseVisualStyleBackColor = true;
            OutputButton.Click += OutputButton_Click;
            // 
            // InputtextBox
            // 
            InputtextBox.Location = new System.Drawing.Point(12, 311);
            InputtextBox.Name = "InputtextBox";
            InputtextBox.ReadOnly = true;
            InputtextBox.Size = new System.Drawing.Size(295, 25);
            InputtextBox.TabIndex = 4;
            // 
            // OutputtextBox
            // 
            OutputtextBox.Location = new System.Drawing.Point(313, 311);
            OutputtextBox.Name = "OutputtextBox";
            OutputtextBox.ReadOnly = true;
            OutputtextBox.Size = new System.Drawing.Size(292, 25);
            OutputtextBox.TabIndex = 5;
            // 
            // InputFileListBox
            // 
            InputFileListBox.FormattingEnabled = true;
            InputFileListBox.ItemHeight = 18;
            InputFileListBox.Location = new System.Drawing.Point(257, 12);
            InputFileListBox.Name = "InputFileListBox";
            InputFileListBox.Size = new System.Drawing.Size(348, 184);
            InputFileListBox.TabIndex = 6;
            // 
            // InputFileListRemoveButton
            // 
            InputFileListRemoveButton.Location = new System.Drawing.Point(528, 204);
            InputFileListRemoveButton.Name = "InputFileListRemoveButton";
            InputFileListRemoveButton.Size = new System.Drawing.Size(77, 23);
            InputFileListRemoveButton.TabIndex = 7;
            InputFileListRemoveButton.Text = "削除";
            InputFileListRemoveButton.UseVisualStyleBackColor = true;
            InputFileListRemoveButton.Click += InputFileListRemoveButton_Click;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(617, 411);
            Controls.Add(InputFileListRemoveButton);
            Controls.Add(InputFileListBox);
            Controls.Add(OutputtextBox);
            Controls.Add(InputtextBox);
            Controls.Add(OutputButton);
            Controls.Add(InputButton);
            Controls.Add(HenkanButton);
            Controls.Add(groupBox1);
            Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Picture Resize 2";
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Ytextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Xtextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox InputTypetextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button HenkanButton;
        private System.Windows.Forms.Button InputButton;
        private System.Windows.Forms.Button OutputButton;
        private System.Windows.Forms.TextBox InputtextBox;
        private System.Windows.Forms.TextBox OutputtextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox aspect_ratioCheckBox;
        private System.Windows.Forms.CheckBox FukusuCheckbox;
        private System.Windows.Forms.ListBox InputFileListBox;
        private System.Windows.Forms.Button InputFileListRemoveButton;
        private System.Windows.Forms.Button kakucho_button;
        private System.Windows.Forms.ComboBox OutputTypeComboBox;
        private System.Windows.Forms.Button settingsave_button;
    }
}

