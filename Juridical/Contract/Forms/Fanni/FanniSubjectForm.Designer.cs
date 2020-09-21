namespace Legal
{
    partial class JFanniSubjectForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbSubject = new ClassLibrary.JComboBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContractNumber = new ClassLibrary.TextEdit(this.components);
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSubject = new ClassLibrary.TextEdit(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCopyCount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.txtDuration = new ClassLibrary.TextEdit(this.components);
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.txtStartDate = new ClassLibrary.DateEdit(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCostDesc = new ClassLibrary.TextEdit(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.jArchiveListContract = new ArchivedDocuments.JArchiveList();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCopyCount)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbSubject);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtContractNumber);
            this.groupBox4.Controls.Add(this.txtDate);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(671, 72);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // cmbSubject
            // 
            this.cmbSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSubject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSubject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubject.BaseCode = 0;
            this.cmbSubject.ChangeColorIfNotEmpty = true;
            this.cmbSubject.ChangeColorOnEnter = true;
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbSubject.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSubject.Location = new System.Drawing.Point(10, 18);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.NotEmpty = false;
            this.cmbSubject.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbSubject.SelectOnEnter = true;
            this.cmbSubject.Size = new System.Drawing.Size(234, 24);
            this.cmbSubject.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(252, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "متن قرارداد:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(595, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "شماره:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(595, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "تاریخ:";
            // 
            // txtContractNumber
            // 
            this.txtContractNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContractNumber.ChangeColorIfNotEmpty = false;
            this.txtContractNumber.ChangeColorOnEnter = true;
            this.txtContractNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtContractNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtContractNumber.Location = new System.Drawing.Point(463, 14);
            this.txtContractNumber.Name = "txtContractNumber";
            this.txtContractNumber.Negative = true;
            this.txtContractNumber.NotEmpty = false;
            this.txtContractNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtContractNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtContractNumber.SelectOnEnter = true;
            this.txtContractNumber.Size = new System.Drawing.Size(100, 23);
            this.txtContractNumber.TabIndex = 0;
            this.txtContractNumber.TextMode = ClassLibrary.TextModes.Text;
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
            this.txtDate.Location = new System.Drawing.Point(463, 43);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(584, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "بعدی";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(12, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(503, 8);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "قبلی";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 453);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 42);
            this.panel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 72);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(671, 381);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(663, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "اطلاعات قرارداد";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSubject);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "موضوع قرارداد";
            // 
            // txtSubject
            // 
            this.txtSubject.ChangeColorIfNotEmpty = false;
            this.txtSubject.ChangeColorOnEnter = true;
            this.txtSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSubject.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSubject.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubject.Location = new System.Drawing.Point(3, 19);
            this.txtSubject.Multiline = true;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Negative = true;
            this.txtSubject.NotEmpty = false;
            this.txtSubject.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSubject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubject.SelectOnEnter = true;
            this.txtSubject.Size = new System.Drawing.Size(651, 80);
            this.txtSubject.TabIndex = 0;
            this.txtSubject.TextMode = ClassLibrary.TextModes.Text;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCopyCount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbEndDate);
            this.groupBox2.Controls.Add(this.lbStartDate);
            this.groupBox2.Controls.Add(this.txtDuration);
            this.groupBox2.Controls.Add(this.txtEndDate);
            this.groupBox2.Controls.Add(this.txtStartDate);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(657, 121);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "تاریخ قرارداد";
            // 
            // txtCopyCount
            // 
            this.txtCopyCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopyCount.Location = new System.Drawing.Point(416, 69);
            this.txtCopyCount.Name = "txtCopyCount";
            this.txtCopyCount.Size = new System.Drawing.Size(80, 23);
            this.txtCopyCount.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "تعداد نسخه های قرارداد:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "بمدت:";
            // 
            // lbEndDate
            // 
            this.lbEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Location = new System.Drawing.Point(446, 40);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(43, 16);
            this.lbEndDate.TabIndex = 4;
            this.lbEndDate.Text = "لغایت:";
            // 
            // lbStartDate
            // 
            this.lbStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Location = new System.Drawing.Point(600, 39);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(51, 16);
            this.lbStartDate.TabIndex = 3;
            this.lbStartDate.Text = "از تاریخ:";
            // 
            // txtDuration
            // 
            this.txtDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuration.ChangeColorIfNotEmpty = false;
            this.txtDuration.ChangeColorOnEnter = true;
            this.txtDuration.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDuration.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDuration.Location = new System.Drawing.Point(224, 35);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Negative = true;
            this.txtDuration.NotEmpty = false;
            this.txtDuration.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDuration.ReadOnly = true;
            this.txtDuration.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDuration.SelectOnEnter = true;
            this.txtDuration.Size = new System.Drawing.Size(48, 23);
            this.txtDuration.TabIndex = 2;
            this.txtDuration.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate.ChangeColorIfNotEmpty = true;
            this.txtEndDate.ChangeColorOnEnter = true;
            this.txtEndDate.Date = new System.DateTime(((long)(0)));
            this.txtEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate.InsertInDatesTable = true;
            this.txtEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDate.Location = new System.Drawing.Point(340, 34);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate.Size = new System.Drawing.Size(100, 23);
            this.txtEndDate.TabIndex = 1;
            this.txtEndDate.Leave += new System.EventHandler(this.txtStartDate_Leave);
            // 
            // txtStartDate
            // 
            this.txtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDate.ChangeColorIfNotEmpty = true;
            this.txtStartDate.ChangeColorOnEnter = true;
            this.txtStartDate.Date = new System.DateTime(((long)(0)));
            this.txtStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDate.InsertInDatesTable = true;
            this.txtStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartDate.Location = new System.Drawing.Point(494, 34);
            this.txtStartDate.Mask = "0000/00/00";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.NotEmpty = false;
            this.txtStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartDate.Size = new System.Drawing.Size(100, 23);
            this.txtStartDate.TabIndex = 0;
            this.txtStartDate.Leave += new System.EventHandler(this.txtStartDate_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCostDesc);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 226);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(657, 123);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "مبلغ قرارداد و نحوه پرداخت آن:";
            // 
            // txtCostDesc
            // 
            this.txtCostDesc.ChangeColorIfNotEmpty = false;
            this.txtCostDesc.ChangeColorOnEnter = true;
            this.txtCostDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCostDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCostDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCostDesc.Location = new System.Drawing.Point(3, 19);
            this.txtCostDesc.Multiline = true;
            this.txtCostDesc.Name = "txtCostDesc";
            this.txtCostDesc.Negative = true;
            this.txtCostDesc.NotEmpty = false;
            this.txtCostDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCostDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCostDesc.SelectOnEnter = true;
            this.txtCostDesc.Size = new System.Drawing.Size(651, 101);
            this.txtCostDesc.TabIndex = 0;
            this.txtCostDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.jArchiveListContract);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(663, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "اسناد و تصاویر";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // jArchiveListContract
            // 
            this.jArchiveListContract.AllowUserAddFile = true;
            this.jArchiveListContract.AllowUserAddFromArchive = true;
            this.jArchiveListContract.AllowUserAddImage = true;
            this.jArchiveListContract.AllowUserDeleteFile = true;
            this.jArchiveListContract.ClassName = "";
            this.jArchiveListContract.ClassNames = null;
            this.jArchiveListContract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveListContract.EnabledChange = true;
            this.jArchiveListContract.Location = new System.Drawing.Point(3, 3);
            this.jArchiveListContract.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.jArchiveListContract.Name = "jArchiveListContract";
            this.jArchiveListContract.ObjectCode = 0;
            this.jArchiveListContract.ObjectCodes = null;
            this.jArchiveListContract.PlaceCode = 0;
            this.jArchiveListContract.Size = new System.Drawing.Size(657, 346);
            this.jArchiveListContract.SubjectCode = 0;
            this.jArchiveListContract.TabIndex = 1;
            // 
            // JFanniSubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 495);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel1);
            this.Name = "JFanniSubjectForm";
            this.Text = "معاونت فنی - قرارداد";
            this.VisibleChanged += new System.EventHandler(this.FanniSubjectForm_VisibleChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FanniSubjectForm_FormClosed);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCopyCount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.TextEdit txtContractNumber;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit txtSubject;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown txtCopyCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbEndDate;
        private System.Windows.Forms.Label lbStartDate;
        private ClassLibrary.TextEdit txtDuration;
        private ClassLibrary.DateEdit txtEndDate;
        private ClassLibrary.DateEdit txtStartDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.TextEdit txtCostDesc;
        private System.Windows.Forms.TabPage tabPage2;
        private ArchivedDocuments.JArchiveList jArchiveListContract;
        private ClassLibrary.JComboBox cmbSubject;
        private System.Windows.Forms.Label label8;


    }
}