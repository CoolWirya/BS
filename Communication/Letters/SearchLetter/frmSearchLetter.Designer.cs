namespace Communication
{
    partial class JfrmSearchLetter
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkExport = new System.Windows.Forms.CheckBox();
            this.chkImport = new System.Windows.Forms.CheckBox();
            this.chkInternal = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.faDatePickerEndDate = new ClassLibrary.DateEdit(this.components);
            this.faDatePickerStartDate = new ClassLibrary.DateEdit(this.components);
            this.txtKeyWords = new ClassLibrary.TextEdit(this.components);
            this.txtLetterNo = new ClassLibrary.TextEdit(this.components);
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbReceiveType = new ClassLibrary.JComboBox(this.components);
            this.label23 = new System.Windows.Forms.Label();
            this.cmbUrgencyLetter = new ClassLibrary.JComboBox(this.components);
            this.label24 = new System.Windows.Forms.Label();
            this.cmbSecurityLevel = new ClassLibrary.JComboBox(this.components);
            this.label25 = new System.Windows.Forms.Label();
            this.btnReceiver = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cdbSubject = new ClassLibrary.JCodingBox();
            this.cmbTitles = new ClassLibrary.JComboBox(this.components);
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a = new ClassLibrary.JComboBox(this.components);
            this.btnSubjectList = new System.Windows.Forms.Button();
            this.txtSubjectMinute = new ClassLibrary.TextEdit(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cdbReceiver = new ClassLibrary.JCodingBox();
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad = new ClassLibrary.JComboBox(this.components);
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9 = new ClassLibrary.JComboBox(this.components);
            this.cdbSender = new ClassLibrary.JCodingBox();
            this.object_eea7e708_5851_419f_831b_42a5247acfc8 = new ClassLibrary.JComboBox(this.components);
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b = new ClassLibrary.JComboBox(this.components);
            this.btnSelOrganization = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.jdgvSearch = new ClassLibrary.JJanusGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.cdbSubject.SuspendLayout();
            this.cdbReceiver.SuspendLayout();
            this.cdbSender.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.faDatePickerEndDate);
            this.groupBox1.Controls.Add(this.faDatePickerStartDate);
            this.groupBox1.Controls.Add(this.txtKeyWords);
            this.groupBox1.Controls.Add(this.txtLetterNo);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.btnReceiver);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cdbSubject);
            this.groupBox1.Controls.Add(this.btnSubjectList);
            this.groupBox1.Controls.Add(this.txtSubjectMinute);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cdbReceiver);
            this.groupBox1.Controls.Add(this.cdbSender);
            this.groupBox1.Controls.Add(this.btnSelOrganization);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(821, 323);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(122, 271);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(87, 27);
            this.btnConfirm.TabIndex = 68;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkExport);
            this.groupBox2.Controls.Add(this.chkImport);
            this.groupBox2.Controls.Add(this.chkInternal);
            this.groupBox2.Location = new System.Drawing.Point(44, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 49);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "نامه";
            // 
            // chkExport
            // 
            this.chkExport.AutoSize = true;
            this.chkExport.Checked = true;
            this.chkExport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExport.Location = new System.Drawing.Point(55, 22);
            this.chkExport.Name = "chkExport";
            this.chkExport.Size = new System.Drawing.Size(58, 20);
            this.chkExport.TabIndex = 2;
            this.chkExport.Text = "صادره";
            this.chkExport.UseVisualStyleBackColor = true;
            // 
            // chkImport
            // 
            this.chkImport.AutoSize = true;
            this.chkImport.Checked = true;
            this.chkImport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImport.Location = new System.Drawing.Point(151, 22);
            this.chkImport.Name = "chkImport";
            this.chkImport.Size = new System.Drawing.Size(52, 20);
            this.chkImport.TabIndex = 1;
            this.chkImport.Text = "وارده";
            this.chkImport.UseVisualStyleBackColor = true;
            // 
            // chkInternal
            // 
            this.chkInternal.AutoSize = true;
            this.chkInternal.Checked = true;
            this.chkInternal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInternal.Location = new System.Drawing.Point(237, 22);
            this.chkInternal.Name = "chkInternal";
            this.chkInternal.Size = new System.Drawing.Size(63, 20);
            this.chkInternal.TabIndex = 0;
            this.chkInternal.Text = "داخلی";
            this.chkInternal.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(28, 271);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 27);
            this.btnClear.TabIndex = 66;
            this.btnClear.Text = "انصراف";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // faDatePickerEndDate
            // 
            this.faDatePickerEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.faDatePickerEndDate.ChangeColorIfNotEmpty = true;
            this.faDatePickerEndDate.ChangeColorOnEnter = true;
            this.faDatePickerEndDate.Date = new System.DateTime(((long)(0)));
            this.faDatePickerEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.faDatePickerEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.faDatePickerEndDate.InsertInDatesTable = true;
            this.faDatePickerEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.faDatePickerEndDate.Location = new System.Drawing.Point(35, 294);
            this.faDatePickerEndDate.Mask = "0000/00/00";
            this.faDatePickerEndDate.Name = "faDatePickerEndDate";
            this.faDatePickerEndDate.NotEmpty = false;
            this.faDatePickerEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.faDatePickerEndDate.Size = new System.Drawing.Size(96, 23);
            this.faDatePickerEndDate.TabIndex = 65;
            this.faDatePickerEndDate.Visible = false;
            // 
            // faDatePickerStartDate
            // 
            this.faDatePickerStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.faDatePickerStartDate.ChangeColorIfNotEmpty = true;
            this.faDatePickerStartDate.ChangeColorOnEnter = true;
            this.faDatePickerStartDate.Date = new System.DateTime(((long)(0)));
            this.faDatePickerStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.faDatePickerStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.faDatePickerStartDate.InsertInDatesTable = true;
            this.faDatePickerStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.faDatePickerStartDate.Location = new System.Drawing.Point(212, 294);
            this.faDatePickerStartDate.Mask = "0000/00/00";
            this.faDatePickerStartDate.Name = "faDatePickerStartDate";
            this.faDatePickerStartDate.NotEmpty = false;
            this.faDatePickerStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.faDatePickerStartDate.Size = new System.Drawing.Size(91, 23);
            this.faDatePickerStartDate.TabIndex = 64;
            this.faDatePickerStartDate.Visible = false;
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyWords.ChangeColorIfNotEmpty = true;
            this.txtKeyWords.ChangeColorOnEnter = true;
            this.txtKeyWords.InBackColor = System.Drawing.SystemColors.Info;
            this.txtKeyWords.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtKeyWords.Location = new System.Drawing.Point(12, 173);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Negative = true;
            this.txtKeyWords.NotEmpty = false;
            this.txtKeyWords.NotEmptyColor = System.Drawing.Color.Red;
            this.txtKeyWords.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtKeyWords.SelectOnEnter = true;
            this.txtKeyWords.Size = new System.Drawing.Size(660, 23);
            this.txtKeyWords.TabIndex = 63;
            this.txtKeyWords.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtLetterNo
            // 
            this.txtLetterNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLetterNo.ChangeColorIfNotEmpty = true;
            this.txtLetterNo.ChangeColorOnEnter = true;
            this.txtLetterNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLetterNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLetterNo.Location = new System.Drawing.Point(12, 144);
            this.txtLetterNo.Name = "txtLetterNo";
            this.txtLetterNo.Negative = true;
            this.txtLetterNo.NotEmpty = false;
            this.txtLetterNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLetterNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterNo.SelectOnEnter = true;
            this.txtLetterNo.Size = new System.Drawing.Size(660, 23);
            this.txtLetterNo.TabIndex = 61;
            this.txtLetterNo.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(681, 176);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(130, 16);
            this.label31.TabIndex = 60;
            this.label31.Text = "کلمات کلیدی در نامه :";
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(134, 297);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(72, 16);
            this.label30.TabIndex = 59;
            this.label30.Text = "تاریخ پایان :";
            this.label30.Visible = false;
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(308, 297);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(78, 16);
            this.label29.TabIndex = 58;
            this.label29.Text = "تاریخ شروع :";
            this.label29.Visible = false;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(681, 151);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(79, 16);
            this.label27.TabIndex = 56;
            this.label27.Text = "شماره نامه :";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(215, 271);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 27);
            this.btnSearch.TabIndex = 55;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cmbReceiveType);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.cmbUrgencyLetter);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.cmbSecurityLevel);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Location = new System.Drawing.Point(391, 203);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(388, 108);
            this.groupBox4.TabIndex = 54;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Letter Type";
            // 
            // cmbReceiveType
            // 
            this.cmbReceiveType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbReceiveType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReceiveType.BaseCode = 0;
            this.cmbReceiveType.ChangeColorIfNotEmpty = true;
            this.cmbReceiveType.ChangeColorOnEnter = true;
            this.cmbReceiveType.FormattingEnabled = true;
            this.cmbReceiveType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbReceiveType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbReceiveType.Location = new System.Drawing.Point(9, 76);
            this.cmbReceiveType.Name = "cmbReceiveType";
            this.cmbReceiveType.NotEmpty = false;
            this.cmbReceiveType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbReceiveType.SelectOnEnter = true;
            this.cmbReceiveType.Size = new System.Drawing.Size(273, 24);
            this.cmbReceiveType.TabIndex = 0;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(296, 79);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(89, 16);
            this.label23.TabIndex = 4;
            this.label23.Text = "Receive Type:";
            // 
            // cmbUrgencyLetter
            // 
            this.cmbUrgencyLetter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUrgencyLetter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUrgencyLetter.BaseCode = 0;
            this.cmbUrgencyLetter.ChangeColorIfNotEmpty = true;
            this.cmbUrgencyLetter.ChangeColorOnEnter = true;
            this.cmbUrgencyLetter.FormattingEnabled = true;
            this.cmbUrgencyLetter.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbUrgencyLetter.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbUrgencyLetter.Location = new System.Drawing.Point(9, 46);
            this.cmbUrgencyLetter.Name = "cmbUrgencyLetter";
            this.cmbUrgencyLetter.NotEmpty = false;
            this.cmbUrgencyLetter.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbUrgencyLetter.SelectOnEnter = true;
            this.cmbUrgencyLetter.Size = new System.Drawing.Size(273, 24);
            this.cmbUrgencyLetter.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(297, 49);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 16);
            this.label24.TabIndex = 2;
            this.label24.Text = "Urgency:";
            // 
            // cmbSecurityLevel
            // 
            this.cmbSecurityLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSecurityLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSecurityLevel.BaseCode = 0;
            this.cmbSecurityLevel.ChangeColorIfNotEmpty = true;
            this.cmbSecurityLevel.ChangeColorOnEnter = true;
            this.cmbSecurityLevel.FormattingEnabled = true;
            this.cmbSecurityLevel.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbSecurityLevel.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSecurityLevel.Location = new System.Drawing.Point(9, 16);
            this.cmbSecurityLevel.Name = "cmbSecurityLevel";
            this.cmbSecurityLevel.NotEmpty = false;
            this.cmbSecurityLevel.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbSecurityLevel.SelectOnEnter = true;
            this.cmbSecurityLevel.Size = new System.Drawing.Size(273, 24);
            this.cmbSecurityLevel.TabIndex = 2;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(293, 19);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(92, 16);
            this.label25.TabIndex = 0;
            this.label25.Text = "Security Level:";
            // 
            // btnReceiver
            // 
            this.btnReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceiver.Location = new System.Drawing.Point(11, 51);
            this.btnReceiver.Name = "btnReceiver";
            this.btnReceiver.Size = new System.Drawing.Size(28, 23);
            this.btnReceiver.TabIndex = 50;
            this.btnReceiver.TabStop = false;
            this.btnReceiver.Text = "...";
            this.btnReceiver.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(681, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 16);
            this.label7.TabIndex = 49;
            this.label7.Text = "موضوع :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(681, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 47;
            this.label6.Text = "موضوع مینوت :";
            // 
            // cdbSubject
            // 
            this.cdbSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cdbSubject.Controls.Add(this.cmbTitles);
            this.cdbSubject.Controls.Add(this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a);
            this.cdbSubject.dataTable = null;
            this.cdbSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cdbSubject.Location = new System.Drawing.Point(45, 81);
            this.cdbSubject.Name = "cdbSubject";
            this.cdbSubject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cdbSubject.SelectedIndex = -1;
            this.cdbSubject.SelectedValue = null;
            this.cdbSubject.Size = new System.Drawing.Size(629, 27);
            this.cdbSubject.TabIndex = 40;
            // 
            // cmbTitles
            // 
            this.cmbTitles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTitles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTitles.BaseCode = 0;
            this.cmbTitles.ChangeColorIfNotEmpty = true;
            this.cmbTitles.ChangeColorOnEnter = true;
            this.cmbTitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTitles.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbTitles.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTitles.Location = new System.Drawing.Point(0, 0);
            this.cmbTitles.Name = "cmbTitles";
            this.cmbTitles.NotEmpty = false;
            this.cmbTitles.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbTitles.SelectOnEnter = true;
            this.cmbTitles.Size = new System.Drawing.Size(629, 24);
            this.cmbTitles.TabIndex = 1;
            // 
            // object_4e74a258_aefa_4ad3_938f_ebc398ef155a
            // 
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.BaseCode = 0;
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.ChangeColorIfNotEmpty = true;
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.ChangeColorOnEnter = true;
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.InBackColor = System.Drawing.SystemColors.Info;
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.InForeColor = System.Drawing.SystemColors.WindowText;
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.Location = new System.Drawing.Point(55, 2);
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.Name = "object_4e74a258_aefa_4ad3_938f_ebc398ef155a";
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.NotEmpty = false;
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.NotEmptyColor = System.Drawing.Color.Red;
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.SelectOnEnter = true;
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.Size = new System.Drawing.Size(907, 24);
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.TabIndex = 4;
            this.object_4e74a258_aefa_4ad3_938f_ebc398ef155a.TabStop = false;
            // 
            // btnSubjectList
            // 
            this.btnSubjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubjectList.Location = new System.Drawing.Point(11, 83);
            this.btnSubjectList.Name = "btnSubjectList";
            this.btnSubjectList.Size = new System.Drawing.Size(28, 23);
            this.btnSubjectList.TabIndex = 52;
            this.btnSubjectList.TabStop = false;
            this.btnSubjectList.Text = "...";
            this.btnSubjectList.UseVisualStyleBackColor = true;
            // 
            // txtSubjectMinute
            // 
            this.txtSubjectMinute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubjectMinute.ChangeColorIfNotEmpty = true;
            this.txtSubjectMinute.ChangeColorOnEnter = true;
            this.txtSubjectMinute.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSubjectMinute.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubjectMinute.Location = new System.Drawing.Point(12, 115);
            this.txtSubjectMinute.Name = "txtSubjectMinute";
            this.txtSubjectMinute.Negative = true;
            this.txtSubjectMinute.NotEmpty = false;
            this.txtSubjectMinute.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSubjectMinute.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubjectMinute.SelectOnEnter = true;
            this.txtSubjectMinute.Size = new System.Drawing.Size(660, 23);
            this.txtSubjectMinute.TabIndex = 41;
            this.txtSubjectMinute.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(681, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 46;
            this.label8.Text = "گیرنده :";
            // 
            // cdbReceiver
            // 
            this.cdbReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cdbReceiver.Controls.Add(this.object_bf0253a7_dfc2_4418_a039_bce429d846ad);
            this.cdbReceiver.Controls.Add(this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9);
            this.cdbReceiver.dataTable = null;
            this.cdbReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cdbReceiver.Location = new System.Drawing.Point(44, 49);
            this.cdbReceiver.Name = "cdbReceiver";
            this.cdbReceiver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cdbReceiver.SelectedIndex = -1;
            this.cdbReceiver.SelectedValue = null;
            this.cdbReceiver.Size = new System.Drawing.Size(630, 27);
            this.cdbReceiver.TabIndex = 39;
            // 
            // object_bf0253a7_dfc2_4418_a039_bce429d846ad
            // 
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.BaseCode = 0;
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.ChangeColorIfNotEmpty = true;
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.ChangeColorOnEnter = true;
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.InBackColor = System.Drawing.SystemColors.Info;
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.InForeColor = System.Drawing.SystemColors.WindowText;
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.Location = new System.Drawing.Point(0, 0);
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.Name = "object_bf0253a7_dfc2_4418_a039_bce429d846ad";
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.NotEmpty = false;
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.NotEmptyColor = System.Drawing.Color.Red;
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.SelectOnEnter = true;
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.Size = new System.Drawing.Size(630, 24);
            this.object_bf0253a7_dfc2_4418_a039_bce429d846ad.TabIndex = 1;
            // 
            // object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9
            // 
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.BaseCode = 0;
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.ChangeColorIfNotEmpty = true;
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.ChangeColorOnEnter = true;
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.InBackColor = System.Drawing.SystemColors.Info;
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.InForeColor = System.Drawing.SystemColors.WindowText;
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.Location = new System.Drawing.Point(55, 2);
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.Name = "object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9";
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.NotEmpty = false;
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.NotEmptyColor = System.Drawing.Color.Red;
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.SelectOnEnter = true;
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.Size = new System.Drawing.Size(909, 24);
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.TabIndex = 4;
            this.object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9.TabStop = false;
            // 
            // cdbSender
            // 
            this.cdbSender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cdbSender.Controls.Add(this.object_eea7e708_5851_419f_831b_42a5247acfc8);
            this.cdbSender.Controls.Add(this.object_6616d3f2_bac7_4f26_918a_25ac170b113b);
            this.cdbSender.dataTable = null;
            this.cdbSender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cdbSender.Location = new System.Drawing.Point(45, 17);
            this.cdbSender.Name = "cdbSender";
            this.cdbSender.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cdbSender.SelectedIndex = -1;
            this.cdbSender.SelectedValue = null;
            this.cdbSender.Size = new System.Drawing.Size(629, 27);
            this.cdbSender.TabIndex = 38;
            // 
            // object_eea7e708_5851_419f_831b_42a5247acfc8
            // 
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.BaseCode = 0;
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.ChangeColorIfNotEmpty = true;
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.ChangeColorOnEnter = true;
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.InBackColor = System.Drawing.SystemColors.Info;
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.InForeColor = System.Drawing.SystemColors.WindowText;
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.Location = new System.Drawing.Point(0, 0);
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.Name = "object_eea7e708_5851_419f_831b_42a5247acfc8";
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.NotEmpty = false;
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.NotEmptyColor = System.Drawing.Color.Red;
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.SelectOnEnter = true;
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.Size = new System.Drawing.Size(629, 24);
            this.object_eea7e708_5851_419f_831b_42a5247acfc8.TabIndex = 1;
            // 
            // object_6616d3f2_bac7_4f26_918a_25ac170b113b
            // 
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.BaseCode = 0;
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.ChangeColorIfNotEmpty = true;
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.ChangeColorOnEnter = true;
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.InBackColor = System.Drawing.SystemColors.Info;
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.InForeColor = System.Drawing.SystemColors.WindowText;
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.Location = new System.Drawing.Point(55, 2);
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.Name = "object_6616d3f2_bac7_4f26_918a_25ac170b113b";
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.NotEmpty = false;
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.NotEmptyColor = System.Drawing.Color.Red;
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.SelectOnEnter = true;
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.Size = new System.Drawing.Size(907, 24);
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.TabIndex = 4;
            this.object_6616d3f2_bac7_4f26_918a_25ac170b113b.TabStop = false;
            // 
            // btnSelOrganization
            // 
            this.btnSelOrganization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelOrganization.Location = new System.Drawing.Point(11, 20);
            this.btnSelOrganization.Name = "btnSelOrganization";
            this.btnSelOrganization.Size = new System.Drawing.Size(28, 23);
            this.btnSelOrganization.TabIndex = 45;
            this.btnSelOrganization.TabStop = false;
            this.btnSelOrganization.Text = "...";
            this.btnSelOrganization.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(680, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 44;
            this.label5.Text = "فرستنده :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.jdgvSearch);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 323);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(821, 337);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // jdgvSearch
            // 
            this.jdgvSearch.ActionMenu = null;
            this.jdgvSearch.DataSource = null;
            this.jdgvSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvSearch.Location = new System.Drawing.Point(3, 19);
            this.jdgvSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jdgvSearch.MultiSelect = false;
            this.jdgvSearch.Name = "jdgvSearch";
            this.jdgvSearch.ShowNavigator = true;
            this.jdgvSearch.ShowToolbar = true;
            this.jdgvSearch.Size = new System.Drawing.Size(815, 315);
            this.jdgvSearch.TabIndex = 0;
            this.jdgvSearch.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.jdgvSearch_OnRowDBClick);
            // 
            // JfrmSearchLetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 660);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JfrmSearchLetter";
            this.Text = "frmSearchLetter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.cdbSubject.ResumeLayout(false);
            this.cdbSubject.PerformLayout();
            this.cdbReceiver.ResumeLayout(false);
            this.cdbReceiver.PerformLayout();
            this.cdbSender.ResumeLayout(false);
            this.cdbSender.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        public ClassLibrary.JComboBox cmbReceiveType;
        private System.Windows.Forms.Label label23;
        private ClassLibrary.JComboBox cmbUrgencyLetter;
        private System.Windows.Forms.Label label24;
        private ClassLibrary.JComboBox cmbSecurityLevel;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnReceiver;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.JCodingBox cdbSubject;
        private ClassLibrary.JComboBox cmbTitles;
        private ClassLibrary.JComboBox object_4e74a258_aefa_4ad3_938f_ebc398ef155a;
        private System.Windows.Forms.Button btnSubjectList;
        private ClassLibrary.TextEdit txtSubjectMinute;
        private System.Windows.Forms.Label label8;
        private ClassLibrary.JCodingBox cdbReceiver;
        private ClassLibrary.JComboBox object_bf0253a7_dfc2_4418_a039_bce429d846ad;
        private ClassLibrary.JComboBox object_e3d05421_c3a5_4c5c_8181_1a0d773cf2d9;
        private ClassLibrary.JCodingBox cdbSender;
        private ClassLibrary.JComboBox object_eea7e708_5851_419f_831b_42a5247acfc8;
        private ClassLibrary.JComboBox object_6616d3f2_bac7_4f26_918a_25ac170b113b;
        private System.Windows.Forms.Button btnSelOrganization;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private ClassLibrary.TextEdit txtKeyWords;
        private ClassLibrary.TextEdit txtLetterNo;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label27;
        private ClassLibrary.JJanusGrid jdgvSearch;
        private ClassLibrary.DateEdit faDatePickerEndDate;
        private ClassLibrary.DateEdit faDatePickerStartDate;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkExport;
        private System.Windows.Forms.CheckBox chkImport;
        private System.Windows.Forms.CheckBox chkInternal;
        private System.Windows.Forms.Button btnConfirm;
    }
}