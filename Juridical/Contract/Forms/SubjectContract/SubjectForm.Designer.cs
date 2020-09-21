namespace Legal
{
    partial class JSubjectContractForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContractTitle = new ClassLibrary.TextEdit(this.components);
            this.txtCopycount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInfo = new ClassLibrary.TextEdit(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMaxCount = new ClassLibrary.TextEdit(this.components);
            this.lblMaxCount = new System.Windows.Forms.Label();
            this.txtbSubjectComment = new System.Windows.Forms.TextBox();
            this.btmSearchGround = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbLocation = new ClassLibrary.JComboBox(this.components);
            this.cmbSubject = new ClassLibrary.JComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtDateDeliver = new ClassLibrary.DateEdit(this.components);
            this.label73 = new System.Windows.Forms.Label();
            this.txtdateStart = new ClassLibrary.DateEdit(this.components);
            this.txtContractNumber = new ClassLibrary.TextEdit(this.components);
            this.lbDeliverDate = new System.Windows.Forms.Label();
            this.txtdateEnd = new ClassLibrary.DateEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.jArchiveListContract = new ArchivedDocuments.JArchiveList();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCopycount)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(675, 432);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(667, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "موضوع قرارداد";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtContractTitle);
            this.groupBox2.Controls.Add(this.txtCopycount);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(661, 190);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اطلاعات تکمیلی قرارداد";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "عنوان قرارداد:";
            // 
            // txtContractTitle
            // 
            this.txtContractTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContractTitle.ChangeColorIfNotEmpty = false;
            this.txtContractTitle.ChangeColorOnEnter = true;
            this.txtContractTitle.InBackColor = System.Drawing.SystemColors.Info;
            this.txtContractTitle.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtContractTitle.Location = new System.Drawing.Point(6, 164);
            this.txtContractTitle.Name = "txtContractTitle";
            this.txtContractTitle.Negative = true;
            this.txtContractTitle.NotEmpty = false;
            this.txtContractTitle.NotEmptyColor = System.Drawing.Color.Red;
            this.txtContractTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtContractTitle.SelectOnEnter = true;
            this.txtContractTitle.Size = new System.Drawing.Size(332, 23);
            this.txtContractTitle.TabIndex = 5;
            this.txtContractTitle.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtCopycount
            // 
            this.txtCopycount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopycount.Location = new System.Drawing.Point(446, 165);
            this.txtCopycount.Name = "txtCopycount";
            this.txtCopycount.Size = new System.Drawing.Size(61, 23);
            this.txtCopycount.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(513, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "تعداد نسخه های قرارداد:";
            // 
            // txtInfo
            // 
            this.txtInfo.ChangeColorIfNotEmpty = false;
            this.txtInfo.ChangeColorOnEnter = true;
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtInfo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtInfo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInfo.Location = new System.Drawing.Point(3, 19);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Negative = true;
            this.txtInfo.NotEmpty = false;
            this.txtInfo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtInfo.SelectOnEnter = true;
            this.txtInfo.Size = new System.Drawing.Size(655, 140);
            this.txtInfo.TabIndex = 1;
            this.txtInfo.TabStop = false;
            this.txtInfo.TextMode = ClassLibrary.TextModes.Text;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMaxCount);
            this.groupBox3.Controls.Add(this.lblMaxCount);
            this.groupBox3.Controls.Add(this.txtbSubjectComment);
            this.groupBox3.Controls.Add(this.btmSearchGround);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(661, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "مشخصات موضوع قرارداد";
            // 
            // txtMaxCount
            // 
            this.txtMaxCount.ChangeColorIfNotEmpty = false;
            this.txtMaxCount.ChangeColorOnEnter = true;
            this.txtMaxCount.InBackColor = System.Drawing.SystemColors.Info;
            this.txtMaxCount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMaxCount.Location = new System.Drawing.Point(361, 19);
            this.txtMaxCount.Name = "txtMaxCount";
            this.txtMaxCount.Negative = true;
            this.txtMaxCount.NotEmpty = false;
            this.txtMaxCount.NotEmptyColor = System.Drawing.Color.Red;
            this.txtMaxCount.ReadOnly = true;
            this.txtMaxCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMaxCount.SelectOnEnter = true;
            this.txtMaxCount.Size = new System.Drawing.Size(100, 23);
            this.txtMaxCount.TabIndex = 1;
            this.txtMaxCount.TabStop = false;
            this.txtMaxCount.TextMode = ClassLibrary.TextModes.Real;
            this.txtMaxCount.Visible = false;
            // 
            // lblMaxCount
            // 
            this.lblMaxCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxCount.AutoSize = true;
            this.lblMaxCount.Location = new System.Drawing.Point(505, 22);
            this.lblMaxCount.Name = "lblMaxCount";
            this.lblMaxCount.Size = new System.Drawing.Size(18, 16);
            this.lblMaxCount.TabIndex = 25;
            this.lblMaxCount.Text = "--";
            this.lblMaxCount.Visible = false;
            // 
            // txtbSubjectComment
            // 
            this.txtbSubjectComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbSubjectComment.Location = new System.Drawing.Point(18, 50);
            this.txtbSubjectComment.Multiline = true;
            this.txtbSubjectComment.Name = "txtbSubjectComment";
            this.txtbSubjectComment.ReadOnly = true;
            this.txtbSubjectComment.Size = new System.Drawing.Size(640, 47);
            this.txtbSubjectComment.TabIndex = 2;
            this.txtbSubjectComment.TabStop = false;
            // 
            // btmSearchGround
            // 
            this.btmSearchGround.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btmSearchGround.Location = new System.Drawing.Point(579, 21);
            this.btmSearchGround.Name = "btmSearchGround";
            this.btmSearchGround.Size = new System.Drawing.Size(75, 26);
            this.btmSearchGround.TabIndex = 0;
            this.btmSearchGround.Text = "دارایی";
            this.btmSearchGround.UseVisualStyleBackColor = true;
            this.btmSearchGround.Click += new System.EventHandler(this.btmSearchGround_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbLocation);
            this.groupBox1.Controls.Add(this.cmbSubject);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDateDeliver);
            this.groupBox1.Controls.Add(this.label73);
            this.groupBox1.Controls.Add(this.txtdateStart);
            this.groupBox1.Controls.Add(this.txtContractNumber);
            this.groupBox1.Controls.Add(this.lbDeliverDate);
            this.groupBox1.Controls.Add(this.txtdateEnd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbEndDate);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbStartDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbLocation
            // 
            this.cmbLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocation.BaseCode = 0;
            this.cmbLocation.ChangeColorIfNotEmpty = true;
            this.cmbLocation.ChangeColorOnEnter = true;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbLocation.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLocation.Location = new System.Drawing.Point(267, 71);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.NotEmpty = false;
            this.cmbLocation.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbLocation.SelectOnEnter = true;
            this.cmbLocation.Size = new System.Drawing.Size(296, 24);
            this.cmbLocation.TabIndex = 3;
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
            this.cmbSubject.Location = new System.Drawing.Point(267, 42);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.NotEmpty = false;
            this.cmbSubject.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbSubject.SelectOnEnter = true;
            this.cmbSubject.Size = new System.Drawing.Size(296, 24);
            this.cmbSubject.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(563, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "نوع متن قرارداد:";
            // 
            // txtDateDeliver
            // 
            this.txtDateDeliver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateDeliver.ChangeColorIfNotEmpty = true;
            this.txtDateDeliver.ChangeColorOnEnter = true;
            this.txtDateDeliver.Date = new System.DateTime(((long)(0)));
            this.txtDateDeliver.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateDeliver.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateDeliver.InsertInDatesTable = true;
            this.txtDateDeliver.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateDeliver.Location = new System.Drawing.Point(25, 71);
            this.txtDateDeliver.Mask = "0000/00/00";
            this.txtDateDeliver.Name = "txtDateDeliver";
            this.txtDateDeliver.NotEmpty = false;
            this.txtDateDeliver.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateDeliver.Size = new System.Drawing.Size(121, 23);
            this.txtDateDeliver.TabIndex = 6;
            // 
            // label73
            // 
            this.label73.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(587, 77);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(74, 16);
            this.label73.TabIndex = 37;
            this.label73.Text = "محل انجام :";
            // 
            // txtdateStart
            // 
            this.txtdateStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdateStart.ChangeColorIfNotEmpty = true;
            this.txtdateStart.ChangeColorOnEnter = true;
            this.txtdateStart.Date = new System.DateTime(((long)(0)));
            this.txtdateStart.InBackColor = System.Drawing.SystemColors.Info;
            this.txtdateStart.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtdateStart.InsertInDatesTable = true;
            this.txtdateStart.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtdateStart.Location = new System.Drawing.Point(25, 13);
            this.txtdateStart.Mask = "0000/00/00";
            this.txtdateStart.Name = "txtdateStart";
            this.txtdateStart.NotEmpty = false;
            this.txtdateStart.NotEmptyColor = System.Drawing.Color.Red;
            this.txtdateStart.Size = new System.Drawing.Size(121, 23);
            this.txtdateStart.TabIndex = 4;
            // 
            // txtContractNumber
            // 
            this.txtContractNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContractNumber.ChangeColorIfNotEmpty = true;
            this.txtContractNumber.ChangeColorOnEnter = true;
            this.txtContractNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtContractNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtContractNumber.Location = new System.Drawing.Point(455, 14);
            this.txtContractNumber.Name = "txtContractNumber";
            this.txtContractNumber.Negative = true;
            this.txtContractNumber.NotEmpty = false;
            this.txtContractNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtContractNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtContractNumber.SelectOnEnter = true;
            this.txtContractNumber.Size = new System.Drawing.Size(108, 23);
            this.txtContractNumber.TabIndex = 0;
            this.txtContractNumber.TextMode = ClassLibrary.TextModes.Text;
            // 
            // lbDeliverDate
            // 
            this.lbDeliverDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDeliverDate.AutoSize = true;
            this.lbDeliverDate.Location = new System.Drawing.Point(145, 74);
            this.lbDeliverDate.Name = "lbDeliverDate";
            this.lbDeliverDate.Size = new System.Drawing.Size(79, 16);
            this.lbDeliverDate.TabIndex = 36;
            this.lbDeliverDate.Text = "تاريخ تحويل :";
            // 
            // txtdateEnd
            // 
            this.txtdateEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdateEnd.ChangeColorIfNotEmpty = true;
            this.txtdateEnd.ChangeColorOnEnter = true;
            this.txtdateEnd.Date = new System.DateTime(((long)(0)));
            this.txtdateEnd.InBackColor = System.Drawing.SystemColors.Info;
            this.txtdateEnd.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtdateEnd.InsertInDatesTable = true;
            this.txtdateEnd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtdateEnd.Location = new System.Drawing.Point(25, 42);
            this.txtdateEnd.Mask = "0000/00/00";
            this.txtdateEnd.Name = "txtdateEnd";
            this.txtdateEnd.NotEmpty = false;
            this.txtdateEnd.NotEmptyColor = System.Drawing.Color.Red;
            this.txtdateEnd.Size = new System.Drawing.Size(121, 23);
            this.txtdateEnd.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(577, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "شماره قرارداد:";
            // 
            // lbEndDate
            // 
            this.lbEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Location = new System.Drawing.Point(145, 46);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(111, 16);
            this.lbEndDate.TabIndex = 35;
            this.lbEndDate.Text = "تاريخ اتمام قرارداد :";
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
            this.txtDate.Location = new System.Drawing.Point(267, 13);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(111, 23);
            this.txtDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "تاریخ قرارداد:";
            // 
            // lbStartDate
            // 
            this.lbStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Location = new System.Drawing.Point(146, 16);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(115, 16);
            this.lbStartDate.TabIndex = 34;
            this.lbStartDate.Text = "تاريخ شروع قرارداد :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.jArchiveListContract);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(667, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تصاویر";
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
            this.jArchiveListContract.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jArchiveListContract.Name = "jArchiveListContract";
            this.jArchiveListContract.ObjectCode = 0;
            this.jArchiveListContract.ObjectCodes = null;
            this.jArchiveListContract.PlaceCode = 0;
            this.jArchiveListContract.Size = new System.Drawing.Size(661, 397);
            this.jArchiveListContract.SubjectCode = 0;
            this.jArchiveListContract.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.Location = new System.Drawing.Point(97, 465);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "قبلی";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(588, 465);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.Location = new System.Drawing.Point(16, 465);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "بعدی";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // JSubjectContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 502);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Name = "JSubjectContractForm";
            this.Text = "موضوع قرارداد";
            this.Load += new System.EventHandler(this.JSubjectContractForm_Load);
            this.Shown += new System.EventHandler(this.JSubjectContractForm_Shown);
            this.VisibleChanged += new System.EventHandler(this.JSubjectContractForm_VisibleChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JSubjectContractForm_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCopycount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.DateEdit txtDate;
        private ClassLibrary.TextEdit txtContractNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btmSearchGround;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label lbDeliverDate;
        private System.Windows.Forms.Label lbEndDate;
        private System.Windows.Forms.Label lbStartDate;
        private ClassLibrary.DateEdit txtdateEnd;
        private ClassLibrary.DateEdit txtdateStart;
        private ClassLibrary.DateEdit txtDateDeliver;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtbSubjectComment;
        private ClassLibrary.TextEdit txtInfo;
        private ClassLibrary.TextEdit txtMaxCount;
        private System.Windows.Forms.Label lblMaxCount;
        private System.Windows.Forms.TabPage tabPage2;
        private ArchivedDocuments.JArchiveList jArchiveListContract;
        private ClassLibrary.JComboBox cmbSubject;
        private ClassLibrary.JComboBox cmbLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtCopycount;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.TextEdit txtContractTitle;
    }
}