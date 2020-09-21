namespace Legal
{
    partial class JGoodwillForm
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtStartDate = new ClassLibrary.DateEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.grpTahrirCosts = new System.Windows.Forms.GroupBox();
            this.rbTahrirBoth = new System.Windows.Forms.RadioButton();
            this.rbTahrirSeller = new System.Windows.Forms.RadioButton();
            this.rbTahrirBuyer = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.grpCosts = new System.Windows.Forms.GroupBox();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.rbSeller = new System.Windows.Forms.RadioButton();
            this.rbBuyer = new System.Windows.Forms.RadioButton();
            this.cmbJobs = new ClassLibrary.JComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtBaseRent = new ClassLibrary.TextEdit(this.components);
            this.btnCalc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox7.SuspendLayout();
            this.grpTahrirCosts.SuspendLayout();
            this.grpCosts.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.txtStartDate);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.grpTahrirCosts);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.txtDesc);
            this.groupBox7.Controls.Add(this.grpCosts);
            this.groupBox7.Controls.Add(this.cmbJobs);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.txtBaseRent);
            this.groupBox7.Controls.Add(this.btnCalc);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.label54);
            this.groupBox7.Location = new System.Drawing.Point(3, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(512, 440);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            // 
            // txtStartDate
            // 
            this.txtStartDate.ChangeColorIfNotEmpty = true;
            this.txtStartDate.ChangeColorOnEnter = true;
            this.txtStartDate.Date = new System.DateTime(((long)(0)));
            this.txtStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDate.InsertInDatesTable = true;
            this.txtStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartDate.Location = new System.Drawing.Point(268, 34);
            this.txtStartDate.Mask = "0000/00/00";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.NotEmpty = false;
            this.txtStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartDate.ReadOnly = true;
            this.txtStartDate.Size = new System.Drawing.Size(100, 23);
            this.txtStartDate.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 51;
            this.label4.Text = "تاریخ شروع بازه اجاره:";
            // 
            // grpTahrirCosts
            // 
            this.grpTahrirCosts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTahrirCosts.Controls.Add(this.rbTahrirBoth);
            this.grpTahrirCosts.Controls.Add(this.rbTahrirSeller);
            this.grpTahrirCosts.Controls.Add(this.rbTahrirBuyer);
            this.grpTahrirCosts.Location = new System.Drawing.Point(22, 149);
            this.grpTahrirCosts.Name = "grpTahrirCosts";
            this.grpTahrirCosts.Size = new System.Drawing.Size(246, 109);
            this.grpTahrirCosts.TabIndex = 50;
            this.grpTahrirCosts.TabStop = false;
            this.grpTahrirCosts.Text = "حق التحریر بر عهده:";
            // 
            // rbTahrirBoth
            // 
            this.rbTahrirBoth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTahrirBoth.AutoSize = true;
            this.rbTahrirBoth.Location = new System.Drawing.Point(167, 83);
            this.rbTahrirBoth.Name = "rbTahrirBoth";
            this.rbTahrirBoth.Size = new System.Drawing.Size(66, 20);
            this.rbTahrirBoth.TabIndex = 2;
            this.rbTahrirBoth.TabStop = true;
            this.rbTahrirBoth.Text = "دو طرف";
            this.rbTahrirBoth.UseVisualStyleBackColor = true;
            // 
            // rbTahrirSeller
            // 
            this.rbTahrirSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTahrirSeller.AutoSize = true;
            this.rbTahrirSeller.Location = new System.Drawing.Point(180, 55);
            this.rbTahrirSeller.Name = "rbTahrirSeller";
            this.rbTahrirSeller.Size = new System.Drawing.Size(53, 20);
            this.rbTahrirSeller.TabIndex = 1;
            this.rbTahrirSeller.TabStop = true;
            this.rbTahrirSeller.Text = "موجر";
            this.rbTahrirSeller.UseVisualStyleBackColor = true;
            // 
            // rbTahrirBuyer
            // 
            this.rbTahrirBuyer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTahrirBuyer.AutoSize = true;
            this.rbTahrirBuyer.Checked = true;
            this.rbTahrirBuyer.Location = new System.Drawing.Point(163, 29);
            this.rbTahrirBuyer.Name = "rbTahrirBuyer";
            this.rbTahrirBuyer.Size = new System.Drawing.Size(70, 20);
            this.rbTahrirBuyer.TabIndex = 0;
            this.rbTahrirBuyer.TabStop = true;
            this.rbTahrirBuyer.Text = "مستاجر";
            this.rbTahrirBuyer.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "توضیحات قرارداد سرقفلی:";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(4, 296);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(506, 151);
            this.txtDesc.TabIndex = 27;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // grpCosts
            // 
            this.grpCosts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCosts.Controls.Add(this.rbBoth);
            this.grpCosts.Controls.Add(this.rbSeller);
            this.grpCosts.Controls.Add(this.rbBuyer);
            this.grpCosts.Location = new System.Drawing.Point(276, 149);
            this.grpCosts.Name = "grpCosts";
            this.grpCosts.Size = new System.Drawing.Size(227, 109);
            this.grpCosts.TabIndex = 26;
            this.grpCosts.TabStop = false;
            this.grpCosts.Text = "هزینه های انتقال سرقفلی بر عهده:";
            // 
            // rbBoth
            // 
            this.rbBoth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbBoth.AutoSize = true;
            this.rbBoth.Location = new System.Drawing.Point(148, 83);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(66, 20);
            this.rbBoth.TabIndex = 2;
            this.rbBoth.Text = "دو طرف";
            this.rbBoth.UseVisualStyleBackColor = true;
            // 
            // rbSeller
            // 
            this.rbSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSeller.AutoSize = true;
            this.rbSeller.Location = new System.Drawing.Point(142, 55);
            this.rbSeller.Name = "rbSeller";
            this.rbSeller.Size = new System.Drawing.Size(72, 20);
            this.rbSeller.TabIndex = 1;
            this.rbSeller.Text = "فروشنده";
            this.rbSeller.UseVisualStyleBackColor = true;
            // 
            // rbBuyer
            // 
            this.rbBuyer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbBuyer.AutoSize = true;
            this.rbBuyer.Checked = true;
            this.rbBuyer.Location = new System.Drawing.Point(155, 29);
            this.rbBuyer.Name = "rbBuyer";
            this.rbBuyer.Size = new System.Drawing.Size(59, 20);
            this.rbBuyer.TabIndex = 0;
            this.rbBuyer.TabStop = true;
            this.rbBuyer.Text = "خریدار";
            this.rbBuyer.UseVisualStyleBackColor = true;
            // 
            // cmbJobs
            // 
            this.cmbJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbJobs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbJobs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbJobs.BaseCode = 0;
            this.cmbJobs.ChangeColorIfNotEmpty = true;
            this.cmbJobs.ChangeColorOnEnter = true;
            this.cmbJobs.FormattingEnabled = true;
            this.cmbJobs.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbJobs.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbJobs.Location = new System.Drawing.Point(188, 66);
            this.cmbJobs.Name = "cmbJobs";
            this.cmbJobs.NotEmpty = false;
            this.cmbJobs.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbJobs.SelectOnEnter = true;
            this.cmbJobs.Size = new System.Drawing.Size(180, 24);
            this.cmbJobs.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "شغل:";
            // 
            // txtBaseRent
            // 
            this.txtBaseRent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBaseRent.ChangeColorIfNotEmpty = false;
            this.txtBaseRent.ChangeColorOnEnter = true;
            this.txtBaseRent.InBackColor = System.Drawing.SystemColors.Info;
            this.txtBaseRent.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBaseRent.Location = new System.Drawing.Point(188, 104);
            this.txtBaseRent.Name = "txtBaseRent";
            this.txtBaseRent.Negative = true;
            this.txtBaseRent.NotEmpty = false;
            this.txtBaseRent.NotEmptyColor = System.Drawing.Color.Red;
            this.txtBaseRent.ReadOnly = true;
            this.txtBaseRent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBaseRent.SelectOnEnter = true;
            this.txtBaseRent.Size = new System.Drawing.Size(180, 23);
            this.txtBaseRent.TabIndex = 1;
            this.txtBaseRent.TextMode = ClassLibrary.TextModes.Money;
            // 
            // btnCalc
            // 
            this.btnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalc.Location = new System.Drawing.Point(67, 104);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(80, 23);
            this.btnCalc.TabIndex = 2;
            this.btnCalc.TabStop = false;
            this.btnCalc.Text = "محاسبه";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Visible = false;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "ریال";
            // 
            // label54
            // 
            this.label54.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(377, 107);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(128, 16);
            this.label54.TabIndex = 15;
            this.label54.Text = "مبلغ پایه اجاره در ماه:";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(102, 459);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "قبلی";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(427, 459);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(21, 459);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "بعدی";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // JGoodwillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 494);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.groupBox7);
            this.Name = "JGoodwillForm";
            this.Text = "اجاره سالیانه صلح و سرقفلی";
            this.Load += new System.EventHandler(this.JGoodwillForm_Load);
            this.Shown += new System.EventHandler(this.JGoodwillForm_Shown);
            this.VisibleChanged += new System.EventHandler(this.JGoodwillForm_VisibleChanged);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.grpTahrirCosts.ResumeLayout(false);
            this.grpTahrirCosts.PerformLayout();
            this.grpCosts.ResumeLayout(false);
            this.grpCosts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCalc;
        private ClassLibrary.TextEdit txtBaseRent;
        private ClassLibrary.JComboBox cmbJobs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpCosts;
        private System.Windows.Forms.RadioButton rbBoth;
        private System.Windows.Forms.RadioButton rbSeller;
        private System.Windows.Forms.RadioButton rbBuyer;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.GroupBox grpTahrirCosts;
        private System.Windows.Forms.RadioButton rbTahrirBoth;
        private System.Windows.Forms.RadioButton rbTahrirSeller;
        private System.Windows.Forms.RadioButton rbTahrirBuyer;
        private ClassLibrary.DateEdit txtStartDate;
        private System.Windows.Forms.Label label4;
    }
}