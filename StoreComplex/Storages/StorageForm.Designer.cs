namespace StoreComplex
{
    partial class JStorageForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbType = new ClassLibrary.JComboBox(this.components);
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.txtBoxMeter = new ClassLibrary.TextEdit(this.components);
            this.txtBoxCount = new ClassLibrary.TextEdit(this.components);
            this.txtTitle = new ClassLibrary.TextEdit(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.txtBoxMeter);
            this.groupBox1.Controls.Add(this.txtBoxCount);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbType.BaseCode = 0;
            this.cmbType.ChangeColorIfNotEmpty = false;
            this.cmbType.ChangeColorOnEnter = true;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbType.Items.AddRange(new object[] {
            "سالن",
            "سکو",
            "محوطه"});
            this.cmbType.Location = new System.Drawing.Point(14, 19);
            this.cmbType.Name = "cmbType";
            this.cmbType.NotEmpty = false;
            this.cmbType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbType.SelectOnEnter = true;
            this.cmbType.Size = new System.Drawing.Size(167, 24);
            this.cmbType.TabIndex = 1;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(256, 96);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(185, 90);
            this.txtDesc.TabIndex = 4;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtBoxMeter
            // 
            this.txtBoxMeter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxMeter.ChangeColorIfNotEmpty = false;
            this.txtBoxMeter.ChangeColorOnEnter = true;
            this.txtBoxMeter.InBackColor = System.Drawing.SystemColors.Info;
            this.txtBoxMeter.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBoxMeter.Location = new System.Drawing.Point(81, 53);
            this.txtBoxMeter.Name = "txtBoxMeter";
            this.txtBoxMeter.Negative = true;
            this.txtBoxMeter.NotEmpty = false;
            this.txtBoxMeter.NotEmptyColor = System.Drawing.Color.Red;
            this.txtBoxMeter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBoxMeter.SelectOnEnter = true;
            this.txtBoxMeter.Size = new System.Drawing.Size(100, 23);
            this.txtBoxMeter.TabIndex = 3;
            this.txtBoxMeter.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtBoxCount
            // 
            this.txtBoxCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxCount.ChangeColorIfNotEmpty = false;
            this.txtBoxCount.ChangeColorOnEnter = true;
            this.txtBoxCount.InBackColor = System.Drawing.SystemColors.Info;
            this.txtBoxCount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBoxCount.Location = new System.Drawing.Point(341, 56);
            this.txtBoxCount.Name = "txtBoxCount";
            this.txtBoxCount.Negative = true;
            this.txtBoxCount.NotEmpty = false;
            this.txtBoxCount.NotEmptyColor = System.Drawing.Color.Red;
            this.txtBoxCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBoxCount.SelectOnEnter = true;
            this.txtBoxCount.Size = new System.Drawing.Size(100, 23);
            this.txtBoxCount.TabIndex = 2;
            this.txtBoxCount.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.ChangeColorIfNotEmpty = false;
            this.txtTitle.ChangeColorOnEnter = true;
            this.txtTitle.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTitle.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTitle.Location = new System.Drawing.Point(256, 20);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Negative = true;
            this.txtTitle.NotEmpty = false;
            this.txtTitle.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitle.SelectOnEnter = true;
            this.txtTitle.Size = new System.Drawing.Size(185, 23);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "توضیحات:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "متراژ هر باکس:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "عنوان:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "نوع:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(448, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "تعداد باکس:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(28, 208);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "تائید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(121, 208);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 34);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // JStorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 258);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Name = "JStorageForm";
            this.Text = "انبارها";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private ClassLibrary.JComboBox cmbType;
        private ClassLibrary.TextEdit txtDesc;
        private ClassLibrary.TextEdit txtBoxMeter;
        private ClassLibrary.TextEdit txtBoxCount;
        private ClassLibrary.TextEdit txtTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}