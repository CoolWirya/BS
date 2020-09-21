namespace StoreManagement
{
    partial class RegForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.jucPersonSeller = new ClassLibrary.JUCPerson();
            this.jucPersonBuyer = new ClassLibrary.JUCPerson();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbGroup = new ClassLibrary.JComboBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbTogether = new System.Windows.Forms.RadioButton();
            this.rbNNaghd = new System.Windows.Forms.RadioButton();
            this.rbNaghd = new System.Windows.Forms.RadioButton();
            this.txtTankhahCode = new ClassLibrary.TextEdit(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerial = new ClassLibrary.TextEdit(this.components);
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.btnReg = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDiscount = new ClassLibrary.TextEdit(this.components);
            this.chkTax = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.jucPersonSeller);
            this.groupBox3.Controls.Add(this.jucPersonBuyer);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(913, 136);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            // 
            // jucPersonSeller
            // 
            this.jucPersonSeller.Dock = System.Windows.Forms.DockStyle.Right;
            this.jucPersonSeller.FilterPerson = null;
            this.jucPersonSeller.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.jucPersonSeller.LableGroup = "فروشنده";
            this.jucPersonSeller.Location = new System.Drawing.Point(452, 19);
            this.jucPersonSeller.Name = "jucPersonSeller";
            this.jucPersonSeller.PersonType = ClassLibrary.JPersonTypes.None;
            this.jucPersonSeller.ReadOnly = false;
            this.jucPersonSeller.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.jucPersonSeller.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.jucPersonSeller.SelectedCode = 0;
            this.jucPersonSeller.Size = new System.Drawing.Size(458, 114);
            this.jucPersonSeller.TabIndex = 11;
            this.jucPersonSeller.TafsiliCode = true;
            this.jucPersonSeller.Leave += new System.EventHandler(this.jucPersonSeller_Leave);
            // 
            // jucPersonBuyer
            // 
            this.jucPersonBuyer.Dock = System.Windows.Forms.DockStyle.Left;
            this.jucPersonBuyer.FilterPerson = null;
            this.jucPersonBuyer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.jucPersonBuyer.LableGroup = "خریدار";
            this.jucPersonBuyer.Location = new System.Drawing.Point(3, 19);
            this.jucPersonBuyer.Name = "jucPersonBuyer";
            this.jucPersonBuyer.PersonType = ClassLibrary.JPersonTypes.None;
            this.jucPersonBuyer.ReadOnly = false;
            this.jucPersonBuyer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.jucPersonBuyer.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.jucPersonBuyer.SelectedCode = 0;
            this.jucPersonBuyer.Size = new System.Drawing.Size(448, 114);
            this.jucPersonBuyer.TabIndex = 12;
            this.jucPersonBuyer.TafsiliCode = true;
            this.jucPersonBuyer.Leave += new System.EventHandler(this.jucPersonBuyer_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbGroup);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.txtTankhahCode);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSerial);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(913, 79);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // cmbGroup
            // 
            this.cmbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroup.BaseCode = 0;
            this.cmbGroup.ChangeColorIfNotEmpty = true;
            this.cmbGroup.ChangeColorOnEnter = true;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGroup.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGroup.Location = new System.Drawing.Point(77, 17);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.NotEmpty = false;
            this.cmbGroup.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGroup.SelectOnEnter = true;
            this.cmbGroup.Size = new System.Drawing.Size(412, 24);
            this.cmbGroup.TabIndex = 5;
            this.cmbGroup.Leave += new System.EventHandler(this.cmbGroup_Leave);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(495, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 16);
            this.label11.TabIndex = 801;
            this.label11.Text = "گروه :";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.rbTogether);
            this.groupBox6.Controls.Add(this.rbNNaghd);
            this.groupBox6.Controls.Add(this.rbNaghd);
            this.groupBox6.Location = new System.Drawing.Point(12, 39);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(225, 37);
            this.groupBox6.TabIndex = 93;
            this.groupBox6.TabStop = false;
            // 
            // rbTogether
            // 
            this.rbTogether.AutoSize = true;
            this.rbTogether.Location = new System.Drawing.Point(6, 14);
            this.rbTogether.Name = "rbTogether";
            this.rbTogether.Size = new System.Drawing.Size(55, 20);
            this.rbTogether.TabIndex = 110;
            this.rbTogether.TabStop = true;
            this.rbTogether.Text = "هر دو";
            this.rbTogether.UseVisualStyleBackColor = true;
            // 
            // rbNNaghd
            // 
            this.rbNNaghd.AutoSize = true;
            this.rbNNaghd.Location = new System.Drawing.Point(72, 12);
            this.rbNNaghd.Name = "rbNNaghd";
            this.rbNNaghd.Size = new System.Drawing.Size(77, 20);
            this.rbNNaghd.TabIndex = 100;
            this.rbNNaghd.TabStop = true;
            this.rbNNaghd.Text = "غیر نقدی";
            this.rbNNaghd.UseVisualStyleBackColor = true;
            // 
            // rbNaghd
            // 
            this.rbNaghd.AutoSize = true;
            this.rbNaghd.Checked = true;
            this.rbNaghd.Location = new System.Drawing.Point(162, 11);
            this.rbNaghd.Name = "rbNaghd";
            this.rbNaghd.Size = new System.Drawing.Size(55, 20);
            this.rbNaghd.TabIndex = 90;
            this.rbNaghd.TabStop = true;
            this.rbNaghd.Text = "نقدی";
            this.rbNaghd.UseVisualStyleBackColor = true;
            // 
            // txtTankhahCode
            // 
            this.txtTankhahCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTankhahCode.ChangeColorIfNotEmpty = false;
            this.txtTankhahCode.ChangeColorOnEnter = true;
            this.txtTankhahCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTankhahCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTankhahCode.Location = new System.Drawing.Point(712, 45);
            this.txtTankhahCode.Name = "txtTankhahCode";
            this.txtTankhahCode.Negative = true;
            this.txtTankhahCode.NotEmpty = false;
            this.txtTankhahCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTankhahCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTankhahCode.SelectOnEnter = true;
            this.txtTankhahCode.Size = new System.Drawing.Size(100, 23);
            this.txtTankhahCode.TabIndex = 2;
            this.txtTankhahCode.Text = "0";
            this.txtTankhahCode.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(818, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "کد تنخواه :";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(243, 47);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(395, 23);
            this.txtDesc.TabIndex = 60;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(642, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "توضیحان :";
            // 
            // txtSerial
            // 
            this.txtSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerial.ChangeColorIfNotEmpty = false;
            this.txtSerial.ChangeColorOnEnter = true;
            this.txtSerial.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSerial.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSerial.Location = new System.Drawing.Point(712, 17);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Negative = true;
            this.txtSerial.NotEmpty = false;
            this.txtSerial.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSerial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSerial.SelectOnEnter = true;
            this.txtSerial.Size = new System.Drawing.Size(100, 23);
            this.txtSerial.TabIndex = 1;
            this.txtSerial.Text = "0";
            this.txtSerial.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(538, 17);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 3;
            this.txtDate.Leave += new System.EventHandler(this.txtDate_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(643, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "تاریخ :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(818, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "شماره سریال :";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.ChangeColorIfNotEmpty = false;
            this.txtTotal.ChangeColorOnEnter = true;
            this.txtTotal.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTotal.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTotal.Location = new System.Drawing.Point(424, 227);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Negative = true;
            this.txtTotal.NotEmpty = false;
            this.txtTotal.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.SelectOnEnter = true;
            this.txtTotal.Size = new System.Drawing.Size(149, 23);
            this.txtTotal.TabIndex = 22;
            this.txtTotal.Text = "0";
            this.txtTotal.TextMode = ClassLibrary.TextModes.Money;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 803;
            this.label4.Text = "جمع کل :";
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(595, 224);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(234, 29);
            this.btnReg.TabIndex = 28;
            this.btnReg.Text = "ثبت";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(227, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 16);
            this.label12.TabIndex = 804;
            this.label12.Text = "تخفیف";
            // 
            // txtDiscount
            // 
            this.txtDiscount.ChangeColorIfNotEmpty = false;
            this.txtDiscount.ChangeColorOnEnter = true;
            this.txtDiscount.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDiscount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDiscount.Location = new System.Drawing.Point(278, 228);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Negative = true;
            this.txtDiscount.NotEmpty = false;
            this.txtDiscount.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDiscount.SelectOnEnter = true;
            this.txtDiscount.Size = new System.Drawing.Size(67, 23);
            this.txtDiscount.TabIndex = 21;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // chkTax
            // 
            this.chkTax.AutoSize = true;
            this.chkTax.Location = new System.Drawing.Point(60, 229);
            this.chkTax.Name = "chkTax";
            this.chkTax.Size = new System.Drawing.Size(161, 20);
            this.chkTax.TabIndex = 20;
            this.chkTax.Text = "محاسبه مالیات / عوارض";
            this.chkTax.UseVisualStyleBackColor = true;
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 259);
            this.Controls.Add(this.chkTax);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegForm";
            this.Text = "RegForm";
            this.Load += new System.EventHandler(this.RegForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.JUCPerson jucPersonSeller;
        private ClassLibrary.JUCPerson jucPersonBuyer;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JComboBox cmbGroup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbTogether;
        private System.Windows.Forms.RadioButton rbNNaghd;
        private System.Windows.Forms.RadioButton rbNaghd;
        private ClassLibrary.TextEdit txtTankhahCode;
        private System.Windows.Forms.Label label7;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.TextEdit txtSerial;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Label label12;
        private ClassLibrary.TextEdit txtDiscount;
        private System.Windows.Forms.CheckBox chkTax;
    }
}