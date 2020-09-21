namespace StoreComplex
{
    partial class JSCReceiptGoodsForm
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rbTon = new System.Windows.Forms.RadioButton();
            this.rbMeter = new System.Windows.Forms.RadioButton();
            this.rbBox = new System.Windows.Forms.RadioButton();
            this.rbCounting = new System.Windows.Forms.RadioButton();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtCost = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtCount = new ClassLibrary.TextEdit(this.components);
            this.cmbGoods = new ClassLibrary.JComboBox(this.components);
            this.lbUnit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCost);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCount);
            this.groupBox1.Controls.Add(this.cmbGoods);
            this.groupBox1.Controls.Add(this.lbUnit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 178);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rbTon);
            this.groupBox7.Controls.Add(this.rbMeter);
            this.groupBox7.Controls.Add(this.rbBox);
            this.groupBox7.Controls.Add(this.rbCounting);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(3, 115);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(443, 60);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "نوع انبارداری:";
            // 
            // rbTon
            // 
            this.rbTon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTon.AutoSize = true;
            this.rbTon.Location = new System.Drawing.Point(294, 29);
            this.rbTon.Name = "rbTon";
            this.rbTon.Size = new System.Drawing.Size(48, 20);
            this.rbTon.TabIndex = 1;
            this.rbTon.TabStop = true;
            this.rbTon.Text = "تنی";
            this.rbTon.UseVisualStyleBackColor = true;
            // 
            // rbMeter
            // 
            this.rbMeter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbMeter.AutoSize = true;
            this.rbMeter.Location = new System.Drawing.Point(196, 29);
            this.rbMeter.Name = "rbMeter";
            this.rbMeter.Size = new System.Drawing.Size(62, 20);
            this.rbMeter.TabIndex = 2;
            this.rbMeter.TabStop = true;
            this.rbMeter.Text = "متراژی";
            this.rbMeter.UseVisualStyleBackColor = true;
            // 
            // rbBox
            // 
            this.rbBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbBox.AutoSize = true;
            this.rbBox.ForeColor = System.Drawing.Color.Blue;
            this.rbBox.Location = new System.Drawing.Point(106, 29);
            this.rbBox.Name = "rbBox";
            this.rbBox.Size = new System.Drawing.Size(67, 20);
            this.rbBox.TabIndex = 3;
            this.rbBox.TabStop = true;
            this.rbBox.Text = "باکسی";
            this.rbBox.UseVisualStyleBackColor = true;
            // 
            // rbCounting
            // 
            this.rbCounting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCounting.AutoSize = true;
            this.rbCounting.Checked = true;
            this.rbCounting.Location = new System.Drawing.Point(365, 29);
            this.rbCounting.Name = "rbCounting";
            this.rbCounting.Size = new System.Drawing.Size(58, 20);
            this.rbCounting.TabIndex = 0;
            this.rbCounting.TabStop = true;
            this.rbCounting.Text = "عددی";
            this.rbCounting.UseVisualStyleBackColor = true;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(87, 84);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(295, 23);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(400, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "هزینه:";
            // 
            // txtCost
            // 
            this.txtCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCost.ChangeColorIfNotEmpty = false;
            this.txtCost.ChangeColorOnEnter = true;
            this.txtCost.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCost.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCost.Location = new System.Drawing.Point(282, 51);
            this.txtCost.Name = "txtCost";
            this.txtCost.Negative = true;
            this.txtCost.NotEmpty = false;
            this.txtCost.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCost.SelectOnEnter = true;
            this.txtCost.Size = new System.Drawing.Size(100, 23);
            this.txtCost.TabIndex = 2;
            this.txtCost.TextMode = ClassLibrary.TextModes.Money;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(381, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "توضیحات:";
            // 
            // txtCount
            // 
            this.txtCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCount.ChangeColorIfNotEmpty = false;
            this.txtCount.ChangeColorOnEnter = true;
            this.txtCount.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCount.Location = new System.Drawing.Point(87, 19);
            this.txtCount.Name = "txtCount";
            this.txtCount.Negative = true;
            this.txtCount.NotEmpty = false;
            this.txtCount.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCount.SelectOnEnter = true;
            this.txtCount.Size = new System.Drawing.Size(48, 23);
            this.txtCount.TabIndex = 1;
            this.txtCount.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbGoods
            // 
            this.cmbGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGoods.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbGoods.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGoods.BaseCode = 0;
            this.cmbGoods.ChangeColorIfNotEmpty = true;
            this.cmbGoods.ChangeColorOnEnter = true;
            this.cmbGoods.FormattingEnabled = true;
            this.cmbGoods.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGoods.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGoods.Location = new System.Drawing.Point(185, 18);
            this.cmbGoods.Name = "cmbGoods";
            this.cmbGoods.NotEmpty = false;
            this.cmbGoods.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGoods.SelectOnEnter = true;
            this.cmbGoods.Size = new System.Drawing.Size(197, 24);
            this.cmbGoods.TabIndex = 0;
            this.cmbGoods.SelectedIndexChanged += new System.EventHandler(this.cmbGoods_SelectedIndexChanged);
            // 
            // lbUnit
            // 
            this.lbUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbUnit.Location = new System.Drawing.Point(7, 24);
            this.lbUnit.Name = "lbUnit";
            this.lbUnit.Size = new System.Drawing.Size(74, 16);
            this.lbUnit.TabIndex = 7;
            this.lbUnit.Text = "واحد";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "تعداد:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "نوع کالا:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(27, 188);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 26);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "ثبت";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(103, 188);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "انصراف";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // JSCReceiptGoodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 226);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Name = "JSCReceiptGoodsForm";
            this.Text = "درج کالا";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit txtCount;
        private ClassLibrary.JComboBox cmbGoods;
        private System.Windows.Forms.Label lbUnit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private ClassLibrary.TextEdit txtCost;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rbTon;
        private System.Windows.Forms.RadioButton rbMeter;
        private System.Windows.Forms.RadioButton rbBox;
        private System.Windows.Forms.RadioButton rbCounting;

    }
}