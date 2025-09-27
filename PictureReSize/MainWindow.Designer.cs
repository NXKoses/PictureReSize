
namespace PictureReSize
{
    partial class MainWindow
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            groupBox1 = new System.Windows.Forms.GroupBox();
            Xtextbox = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            Ytextbox = new System.Windows.Forms.TextBox();
            ConvertModeSelect_comboBox = new System.Windows.Forms.ComboBox();
            OutputTypeComboBox = new System.Windows.Forms.ComboBox();
            aspect_ratioCheckBox = new System.Windows.Forms.CheckBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            InputTypetextbox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            HenkanButton = new System.Windows.Forms.Button();
            InputButton = new System.Windows.Forms.Button();
            OutputButton = new System.Windows.Forms.Button();
            InputtextBox = new System.Windows.Forms.TextBox();
            OutputtextBox = new System.Windows.Forms.TextBox();
            InputFileListBox = new System.Windows.Forms.ListBox();
            InputFileListRemoveButton = new System.Windows.Forms.Button();
            sintyoku = new System.Windows.Forms.Label();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            SettingSave_toolStripButton = new System.Windows.Forms.ToolStripButton();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            groupBox1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Xtextbox);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Ytextbox);
            groupBox1.Controls.Add(ConvertModeSelect_comboBox);
            groupBox1.Controls.Add(OutputTypeComboBox);
            groupBox1.Controls.Add(aspect_ratioCheckBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(InputTypetextbox);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new System.Drawing.Point(12, 33);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Size = new System.Drawing.Size(224, 227);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "基本設定";
            // 
            // Xtextbox
            // 
            Xtextbox.Location = new System.Drawing.Point(49, 25);
            Xtextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Xtextbox.Name = "Xtextbox";
            Xtextbox.Size = new System.Drawing.Size(67, 25);
            Xtextbox.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 186);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(44, 18);
            label5.TabIndex = 14;
            label5.Text = "モード";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(122, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(15, 18);
            label1.TabIndex = 1;
            label1.Text = "x";
            label1.Click += label1_Click;
            // 
            // Ytextbox
            // 
            Ytextbox.Location = new System.Drawing.Point(143, 25);
            Ytextbox.Name = "Ytextbox";
            Ytextbox.Size = new System.Drawing.Size(75, 25);
            Ytextbox.TabIndex = 2;
            // 
            // ConvertModeSelect_comboBox
            // 
            ConvertModeSelect_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ConvertModeSelect_comboBox.FormattingEnabled = true;
            ConvertModeSelect_comboBox.Items.AddRange(new object[] { "通常変換", "複数フォルダ入力", "複数フォルダ同期入出力" });
            ConvertModeSelect_comboBox.Location = new System.Drawing.Point(56, 183);
            ConvertModeSelect_comboBox.Name = "ConvertModeSelect_comboBox";
            ConvertModeSelect_comboBox.Size = new System.Drawing.Size(162, 26);
            ConvertModeSelect_comboBox.TabIndex = 13;
            ConvertModeSelect_comboBox.SelectedIndexChanged += ConvertModeSelect_comboBox_SelectedIndexChanged;
            // 
            // OutputTypeComboBox
            // 
            OutputTypeComboBox.FormattingEnabled = true;
            OutputTypeComboBox.Items.AddRange(new object[] { "bmp", "jpeg", "png" });
            OutputTypeComboBox.Location = new System.Drawing.Point(143, 101);
            OutputTypeComboBox.Name = "OutputTypeComboBox";
            OutputTypeComboBox.Size = new System.Drawing.Size(75, 26);
            OutputTypeComboBox.TabIndex = 11;
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
            label4.Location = new System.Drawing.Point(18, 134);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(184, 18);
            label4.TabIndex = 7;
            label4.Text = "➖➖➖➖➖➖➖➖➖➖➖";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(30, 109);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(68, 18);
            label3.TabIndex = 5;
            label3.Text = "出力拡張子";
            // 
            // InputTypetextbox
            // 
            InputTypetextbox.Location = new System.Drawing.Point(143, 62);
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
            // HenkanButton
            // 
            HenkanButton.Font = new System.Drawing.Font("メイリオ", 15.75F);
            HenkanButton.Location = new System.Drawing.Point(12, 369);
            HenkanButton.Name = "HenkanButton";
            HenkanButton.Size = new System.Drawing.Size(593, 65);
            HenkanButton.TabIndex = 1;
            HenkanButton.Text = "変換";
            HenkanButton.UseVisualStyleBackColor = true;
            HenkanButton.Click += HenkanButton_Click;
            // 
            // InputButton
            // 
            InputButton.AllowDrop = true;
            InputButton.Font = new System.Drawing.Font("メイリオ", 14.25F);
            InputButton.Location = new System.Drawing.Point(12, 267);
            InputButton.Name = "InputButton";
            InputButton.Size = new System.Drawing.Size(295, 65);
            InputButton.TabIndex = 2;
            InputButton.Text = "入力";
            InputButton.UseVisualStyleBackColor = true;
            InputButton.Click += InputButton_Click;
            InputButton.DragDrop += InputButton_DragDrop;
            InputButton.DragEnter += InputButton_DragEnter;
            // 
            // OutputButton
            // 
            OutputButton.AllowDrop = true;
            OutputButton.Font = new System.Drawing.Font("メイリオ", 14.25F);
            OutputButton.Location = new System.Drawing.Point(313, 267);
            OutputButton.Name = "OutputButton";
            OutputButton.Size = new System.Drawing.Size(292, 65);
            OutputButton.TabIndex = 3;
            OutputButton.Text = "出力";
            OutputButton.UseVisualStyleBackColor = true;
            OutputButton.Click += OutputButton_Click;
            OutputButton.DragDrop += OutputButton_DragDrop;
            OutputButton.DragEnter += OutputButton_DragEnter;
            // 
            // InputtextBox
            // 
            InputtextBox.Location = new System.Drawing.Point(12, 338);
            InputtextBox.Name = "InputtextBox";
            InputtextBox.ReadOnly = true;
            InputtextBox.Size = new System.Drawing.Size(295, 25);
            InputtextBox.TabIndex = 4;
            // 
            // OutputtextBox
            // 
            OutputtextBox.Location = new System.Drawing.Point(313, 338);
            OutputtextBox.Name = "OutputtextBox";
            OutputtextBox.ReadOnly = true;
            OutputtextBox.Size = new System.Drawing.Size(292, 25);
            OutputtextBox.TabIndex = 5;
            // 
            // InputFileListBox
            // 
            InputFileListBox.FormattingEnabled = true;
            InputFileListBox.ItemHeight = 18;
            InputFileListBox.Location = new System.Drawing.Point(242, 33);
            InputFileListBox.Name = "InputFileListBox";
            InputFileListBox.Size = new System.Drawing.Size(363, 184);
            InputFileListBox.TabIndex = 6;
            // 
            // InputFileListRemoveButton
            // 
            InputFileListRemoveButton.Location = new System.Drawing.Point(528, 223);
            InputFileListRemoveButton.Name = "InputFileListRemoveButton";
            InputFileListRemoveButton.Size = new System.Drawing.Size(77, 23);
            InputFileListRemoveButton.TabIndex = 7;
            InputFileListRemoveButton.Text = "削除";
            InputFileListRemoveButton.UseVisualStyleBackColor = true;
            InputFileListRemoveButton.Click += InputFileListRemoveButton_Click;
            // 
            // sintyoku
            // 
            sintyoku.AutoSize = true;
            sintyoku.Location = new System.Drawing.Point(265, 242);
            sintyoku.Name = "sintyoku";
            sintyoku.Size = new System.Drawing.Size(0, 18);
            sintyoku.TabIndex = 8;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { SettingSave_toolStripButton });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(611, 25);
            toolStrip1.TabIndex = 9;
            toolStrip1.Text = "toolStrip1";
            // 
            // SettingSave_toolStripButton
            // 
            SettingSave_toolStripButton.Image = (System.Drawing.Image)resources.GetObject("SettingSave_toolStripButton.Image");
            SettingSave_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            SettingSave_toolStripButton.Name = "SettingSave_toolStripButton";
            SettingSave_toolStripButton.Size = new System.Drawing.Size(85, 22);
            SettingSave_toolStripButton.Text = "設定の保存";
            SettingSave_toolStripButton.Click += SettingSave_toolStripButton_Click;
            // 
            // MainWindow
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(611, 445);
            Controls.Add(toolStrip1);
            Controls.Add(sintyoku);
            Controls.Add(InputFileListRemoveButton);
            Controls.Add(InputFileListBox);
            Controls.Add(OutputtextBox);
            Controls.Add(InputtextBox);
            Controls.Add(OutputButton);
            Controls.Add(InputButton);
            Controls.Add(HenkanButton);
            Controls.Add(groupBox1);
            Font = new System.Drawing.Font("メイリオ", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "PictureResize";
            Load += MainWindow_LoadAsync;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
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
        private System.Windows.Forms.ListBox InputFileListBox;
        private System.Windows.Forms.Button InputFileListRemoveButton;
        private System.Windows.Forms.ComboBox OutputTypeComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ConvertModeSelect_comboBox;
        public System.Windows.Forms.Label sintyoku;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SettingSave_toolStripButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

