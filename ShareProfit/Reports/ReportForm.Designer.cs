namespace ShareProfit
{
    partial class JReportForm
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.seperator = new System.Windows.Forms.Panel();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.rbPayed = new System.Windows.Forms.RadioButton();
            this.rbUnPayed = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPaySource = new ClassLibrary.JComboBox(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chAllCourses = new System.Windows.Forms.CheckBox();
            this.chListCourses = new System.Windows.Forms.CheckedListBox();
            this.txtToDate = new ClassLibrary.DateEdit(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSheet = new System.Windows.Forms.RadioButton();
            this.rbPerson = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtShareCountTo = new ClassLibrary.TextEdit(this.components);
            this.txtShareCountFrom = new ClassLibrary.TextEdit(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtShareNoEla = new ClassLibrary.TextEdit(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPayToDate = new ClassLibrary.DateEdit(this.components);
            this.txtPayFromDate = new ClassLibrary.DateEdit(this.components);
            this.cmbConditionCity = new ClassLibrary.JComboBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFromDate = new ClassLibrary.DateEdit(this.components);
            this.cmbPName = new ClassLibrary.JComboBox(this.components);
            this.txtShareNoAz = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtSheetNo = new ClassLibrary.TextEdit(this.components);
            this.lbSheetNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCity = new ClassLibrary.JComboBox(this.components);
            this.txtPCode = new ClassLibrary.TextEdit(this.components);
            this.lbManagementsharesHolder = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Location = new System.Drawing.Point(560, 506);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 32);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.seperator);
            this.groupBox3.Controls.Add(this.rbBoth);
            this.groupBox3.Controls.Add(this.rbPayed);
            this.groupBox3.Controls.Add(this.rbUnPayed);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbPaySource);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 360);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(662, 140);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PaymentInfo";
            // 
            // seperator
            // 
            this.seperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.seperator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.seperator.Location = new System.Drawing.Point(50, 56);
            this.seperator.Name = "seperator";
            this.seperator.Size = new System.Drawing.Size(574, 4);
            this.seperator.TabIndex = 59;
            // 
            // rbBoth
            // 
            this.rbBoth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbBoth.AutoSize = true;
            this.rbBoth.Checked = true;
            this.rbBoth.Location = new System.Drawing.Point(573, 118);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(51, 20);
            this.rbBoth.TabIndex = 3;
            this.rbBoth.TabStop = true;
            this.rbBoth.Text = "Both";
            this.rbBoth.UseVisualStyleBackColor = true;
            // 
            // rbPayed
            // 
            this.rbPayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPayed.AutoSize = true;
            this.rbPayed.Location = new System.Drawing.Point(564, 66);
            this.rbPayed.Name = "rbPayed";
            this.rbPayed.Size = new System.Drawing.Size(60, 20);
            this.rbPayed.TabIndex = 1;
            this.rbPayed.Text = "Payed";
            this.rbPayed.UseVisualStyleBackColor = true;
            // 
            // rbUnPayed
            // 
            this.rbUnPayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbUnPayed.AutoSize = true;
            this.rbUnPayed.Location = new System.Drawing.Point(549, 92);
            this.rbUnPayed.Name = "rbUnPayed";
            this.rbUnPayed.Size = new System.Drawing.Size(75, 20);
            this.rbUnPayed.TabIndex = 2;
            this.rbUnPayed.Text = "UnPayed";
            this.rbUnPayed.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(564, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 48;
            this.label1.Text = "PayLoc:";
            // 
            // cmbPaySource
            // 
            this.cmbPaySource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPaySource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbPaySource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPaySource.BaseCode = 0;
            this.cmbPaySource.ChangeColorIfNotEmpty = true;
            this.cmbPaySource.ChangeColorOnEnter = true;
            this.cmbPaySource.FormattingEnabled = true;
            this.cmbPaySource.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbPaySource.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbPaySource.Location = new System.Drawing.Point(388, 26);
            this.cmbPaySource.Name = "cmbPaySource";
            this.cmbPaySource.NotEmpty = false;
            this.cmbPaySource.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbPaySource.SelectOnEnter = true;
            this.cmbPaySource.Size = new System.Drawing.Size(149, 24);
            this.cmbPaySource.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chAllCourses);
            this.groupBox2.Controls.Add(this.chListCourses);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(662, 150);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Courses";
            // 
            // chAllCourses
            // 
            this.chAllCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chAllCourses.AutoSize = true;
            this.chAllCourses.Checked = true;
            this.chAllCourses.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chAllCourses.Location = new System.Drawing.Point(537, 17);
            this.chAllCourses.Name = "chAllCourses";
            this.chAllCourses.Size = new System.Drawing.Size(87, 20);
            this.chAllCourses.TabIndex = 0;
            this.chAllCourses.Text = "AllCourses";
            this.chAllCourses.UseVisualStyleBackColor = true;
            this.chAllCourses.CheckedChanged += new System.EventHandler(this.chAllCourses_CheckedChanged);
            // 
            // chListCourses
            // 
            this.chListCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chListCourses.CheckOnClick = true;
            this.chListCourses.Enabled = false;
            this.chListCourses.FormattingEnabled = true;
            this.chListCourses.Location = new System.Drawing.Point(343, 43);
            this.chListCourses.Name = "chListCourses";
            this.chListCourses.Size = new System.Drawing.Size(287, 94);
            this.chListCourses.TabIndex = 1;
            // 
            // txtToDate
            // 
            this.txtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToDate.ChangeColorIfNotEmpty = true;
            this.txtToDate.ChangeColorOnEnter = true;
            this.txtToDate.Date = new System.DateTime(((long)(0)));
            this.txtToDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtToDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtToDate.InsertInDatesTable = true;
            this.txtToDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtToDate.Location = new System.Drawing.Point(209, 144);
            this.txtToDate.Mask = "0000/00/00";
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.NotEmpty = false;
            this.txtToDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtToDate.Size = new System.Drawing.Size(100, 23);
            this.txtToDate.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSheet);
            this.groupBox1.Controls.Add(this.rbPerson);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtShareCountTo);
            this.groupBox1.Controls.Add(this.txtShareCountFrom);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtShareNoEla);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtPayToDate);
            this.groupBox1.Controls.Add(this.txtPayFromDate);
            this.groupBox1.Controls.Add(this.cmbConditionCity);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtToDate);
            this.groupBox1.Controls.Add(this.txtFromDate);
            this.groupBox1.Controls.Add(this.cmbPName);
            this.groupBox1.Controls.Add(this.txtShareNoAz);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSheetNo);
            this.groupBox1.Controls.Add(this.lbSheetNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbCity);
            this.groupBox1.Controls.Add(this.txtPCode);
            this.groupBox1.Controls.Add(this.lbManagementsharesHolder);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PersonInfo";
            // 
            // rbSheet
            // 
            this.rbSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSheet.AutoSize = true;
            this.rbSheet.Checked = true;
            this.rbSheet.Location = new System.Drawing.Point(209, 115);
            this.rbSheet.Name = "rbSheet";
            this.rbSheet.Size = new System.Drawing.Size(173, 20);
            this.rbSheet.TabIndex = 61;
            this.rbSheet.TabStop = true;
            this.rbSheet.Text = "گزارش بر اساس برگه سهم";
            this.rbSheet.UseVisualStyleBackColor = true;
            // 
            // rbPerson
            // 
            this.rbPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPerson.AutoSize = true;
            this.rbPerson.Location = new System.Drawing.Point(27, 115);
            this.rbPerson.Name = "rbPerson";
            this.rbPerson.Size = new System.Drawing.Size(155, 20);
            this.rbPerson.TabIndex = 60;
            this.rbPerson.Text = "گزارش بر اساس شخص";
            this.rbPerson.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(445, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 16);
            this.label13.TabIndex = 59;
            this.label13.Text = "Ela:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(513, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 16);
            this.label14.TabIndex = 58;
            this.label14.Text = "Az:";
            // 
            // txtShareCountTo
            // 
            this.txtShareCountTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShareCountTo.ChangeColorIfNotEmpty = false;
            this.txtShareCountTo.ChangeColorOnEnter = true;
            this.txtShareCountTo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtShareCountTo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShareCountTo.Location = new System.Drawing.Point(410, 114);
            this.txtShareCountTo.Name = "txtShareCountTo";
            this.txtShareCountTo.Negative = true;
            this.txtShareCountTo.NotEmpty = false;
            this.txtShareCountTo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtShareCountTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShareCountTo.SelectOnEnter = true;
            this.txtShareCountTo.Size = new System.Drawing.Size(29, 23);
            this.txtShareCountTo.TabIndex = 8;
            this.txtShareCountTo.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtShareCountFrom
            // 
            this.txtShareCountFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShareCountFrom.ChangeColorIfNotEmpty = false;
            this.txtShareCountFrom.ChangeColorOnEnter = true;
            this.txtShareCountFrom.InBackColor = System.Drawing.SystemColors.Info;
            this.txtShareCountFrom.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShareCountFrom.Location = new System.Drawing.Point(481, 114);
            this.txtShareCountFrom.Name = "txtShareCountFrom";
            this.txtShareCountFrom.Negative = true;
            this.txtShareCountFrom.NotEmpty = false;
            this.txtShareCountFrom.NotEmptyColor = System.Drawing.Color.Red;
            this.txtShareCountFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShareCountFrom.SelectOnEnter = true;
            this.txtShareCountFrom.Size = new System.Drawing.Size(29, 23);
            this.txtShareCountFrom.TabIndex = 7;
            this.txtShareCountFrom.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(570, 117);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 16);
            this.label15.TabIndex = 57;
            this.label15.Text = "ShareCount:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(139, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 16);
            this.label12.TabIndex = 54;
            this.label12.Text = "Ela:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(314, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 16);
            this.label6.TabIndex = 53;
            this.label6.Text = "Az:";
            // 
            // txtShareNoEla
            // 
            this.txtShareNoEla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShareNoEla.ChangeColorIfNotEmpty = false;
            this.txtShareNoEla.ChangeColorOnEnter = true;
            this.txtShareNoEla.InBackColor = System.Drawing.SystemColors.Info;
            this.txtShareNoEla.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShareNoEla.Location = new System.Drawing.Point(50, 86);
            this.txtShareNoEla.Name = "txtShareNoEla";
            this.txtShareNoEla.Negative = true;
            this.txtShareNoEla.NotEmpty = false;
            this.txtShareNoEla.NotEmptyColor = System.Drawing.Color.Red;
            this.txtShareNoEla.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShareNoEla.SelectOnEnter = true;
            this.txtShareNoEla.Size = new System.Drawing.Size(83, 23);
            this.txtShareNoEla.TabIndex = 6;
            this.txtShareNoEla.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(568, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 16);
            this.label9.TabIndex = 51;
            this.label9.Text = "تاریخ پرداخت:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(334, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 16);
            this.label10.TabIndex = 50;
            this.label10.Text = "تا تاریخ:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(519, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 16);
            this.label11.TabIndex = 49;
            this.label11.Text = "از تاریخ:";
            // 
            // txtPayToDate
            // 
            this.txtPayToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPayToDate.ChangeColorIfNotEmpty = true;
            this.txtPayToDate.ChangeColorOnEnter = true;
            this.txtPayToDate.Date = new System.DateTime(((long)(0)));
            this.txtPayToDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPayToDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPayToDate.InsertInDatesTable = true;
            this.txtPayToDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtPayToDate.Location = new System.Drawing.Point(209, 175);
            this.txtPayToDate.Mask = "0000/00/00";
            this.txtPayToDate.Name = "txtPayToDate";
            this.txtPayToDate.NotEmpty = false;
            this.txtPayToDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPayToDate.Size = new System.Drawing.Size(100, 23);
            this.txtPayToDate.TabIndex = 12;
            // 
            // txtPayFromDate
            // 
            this.txtPayFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPayFromDate.ChangeColorIfNotEmpty = true;
            this.txtPayFromDate.ChangeColorOnEnter = true;
            this.txtPayFromDate.Date = new System.DateTime(((long)(0)));
            this.txtPayFromDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPayFromDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPayFromDate.InsertInDatesTable = true;
            this.txtPayFromDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtPayFromDate.Location = new System.Drawing.Point(408, 175);
            this.txtPayFromDate.Mask = "0000/00/00";
            this.txtPayFromDate.Name = "txtPayFromDate";
            this.txtPayFromDate.NotEmpty = false;
            this.txtPayFromDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPayFromDate.Size = new System.Drawing.Size(100, 23);
            this.txtPayFromDate.TabIndex = 11;
            // 
            // cmbConditionCity
            // 
            this.cmbConditionCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConditionCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbConditionCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbConditionCity.BaseCode = 0;
            this.cmbConditionCity.ChangeColorIfNotEmpty = true;
            this.cmbConditionCity.ChangeColorOnEnter = true;
            this.cmbConditionCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConditionCity.FormattingEnabled = true;
            this.cmbConditionCity.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbConditionCity.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbConditionCity.Items.AddRange(new object[] {
            "برابر",
            "غیر از"});
            this.cmbConditionCity.Location = new System.Drawing.Point(410, 53);
            this.cmbConditionCity.Name = "cmbConditionCity";
            this.cmbConditionCity.NotEmpty = false;
            this.cmbConditionCity.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbConditionCity.SelectOnEnter = true;
            this.cmbConditionCity.Size = new System.Drawing.Size(100, 24);
            this.cmbConditionCity.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(582, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 16);
            this.label8.TabIndex = 45;
            this.label8.Text = "تاریخ سند:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(334, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 44;
            this.label7.Text = "تا تاریخ:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(519, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "از تاریخ:";
            // 
            // txtFromDate
            // 
            this.txtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromDate.ChangeColorIfNotEmpty = true;
            this.txtFromDate.ChangeColorOnEnter = true;
            this.txtFromDate.Date = new System.DateTime(((long)(0)));
            this.txtFromDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFromDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFromDate.InsertInDatesTable = true;
            this.txtFromDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFromDate.Location = new System.Drawing.Point(408, 144);
            this.txtFromDate.Mask = "0000/00/00";
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.NotEmpty = false;
            this.txtFromDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFromDate.Size = new System.Drawing.Size(100, 23);
            this.txtFromDate.TabIndex = 9;
            // 
            // cmbPName
            // 
            this.cmbPName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbPName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPName.BaseCode = 0;
            this.cmbPName.ChangeColorIfNotEmpty = true;
            this.cmbPName.ChangeColorOnEnter = true;
            this.cmbPName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbPName.FormattingEnabled = true;
            this.cmbPName.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbPName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbPName.Location = new System.Drawing.Point(50, 21);
            this.cmbPName.Name = "cmbPName";
            this.cmbPName.NotEmpty = false;
            this.cmbPName.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbPName.SelectOnEnter = true;
            this.cmbPName.Size = new System.Drawing.Size(261, 22);
            this.cmbPName.TabIndex = 1;
            this.cmbPName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPName_KeyPress);
            this.cmbPName.SelectedValueChanged += new System.EventHandler(this.cmbPName_SelectedValueChanged);
            this.cmbPName.TextChanged += new System.EventHandler(this.cmbPName_TextChanged);
            // 
            // txtShareNoAz
            // 
            this.txtShareNoAz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShareNoAz.ChangeColorIfNotEmpty = false;
            this.txtShareNoAz.ChangeColorOnEnter = true;
            this.txtShareNoAz.InBackColor = System.Drawing.SystemColors.Info;
            this.txtShareNoAz.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShareNoAz.Location = new System.Drawing.Point(229, 86);
            this.txtShareNoAz.Name = "txtShareNoAz";
            this.txtShareNoAz.Negative = true;
            this.txtShareNoAz.NotEmpty = false;
            this.txtShareNoAz.NotEmptyColor = System.Drawing.Color.Red;
            this.txtShareNoAz.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShareNoAz.SelectOnEnter = true;
            this.txtShareNoAz.Size = new System.Drawing.Size(82, 23);
            this.txtShareNoAz.TabIndex = 5;
            this.txtShareNoAz.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "ShareNo:";
            // 
            // txtSheetNo
            // 
            this.txtSheetNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSheetNo.ChangeColorIfNotEmpty = false;
            this.txtSheetNo.ChangeColorOnEnter = true;
            this.txtSheetNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSheetNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSheetNo.Location = new System.Drawing.Point(410, 86);
            this.txtSheetNo.Name = "txtSheetNo";
            this.txtSheetNo.Negative = true;
            this.txtSheetNo.NotEmpty = false;
            this.txtSheetNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSheetNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSheetNo.SelectOnEnter = true;
            this.txtSheetNo.Size = new System.Drawing.Size(100, 23);
            this.txtSheetNo.TabIndex = 4;
            this.txtSheetNo.TabStop = false;
            this.txtSheetNo.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // lbSheetNo
            // 
            this.lbSheetNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSheetNo.AutoSize = true;
            this.lbSheetNo.Location = new System.Drawing.Point(589, 89);
            this.lbSheetNo.Name = "lbSheetNo";
            this.lbSheetNo.Size = new System.Drawing.Size(61, 16);
            this.lbSheetNo.TabIndex = 38;
            this.lbSheetNo.Text = "SheetNo:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "HomeCityName:";
            // 
            // cmbCity
            // 
            this.cmbCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCity.BaseCode = 0;
            this.cmbCity.ChangeColorIfNotEmpty = true;
            this.cmbCity.ChangeColorOnEnter = true;
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCity.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCity.Location = new System.Drawing.Point(50, 54);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.NotEmpty = false;
            this.cmbCity.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCity.SelectOnEnter = true;
            this.cmbCity.Size = new System.Drawing.Size(261, 24);
            this.cmbCity.TabIndex = 3;
            // 
            // txtPCode
            // 
            this.txtPCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPCode.ChangeColorIfNotEmpty = false;
            this.txtPCode.ChangeColorOnEnter = true;
            this.txtPCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPCode.Location = new System.Drawing.Point(410, 22);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.Negative = true;
            this.txtPCode.NotEmpty = false;
            this.txtPCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPCode.SelectOnEnter = true;
            this.txtPCode.Size = new System.Drawing.Size(100, 23);
            this.txtPCode.TabIndex = 0;
            this.txtPCode.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // lbManagementsharesHolder
            // 
            this.lbManagementsharesHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbManagementsharesHolder.AutoSize = true;
            this.lbManagementsharesHolder.Location = new System.Drawing.Point(459, 25);
            this.lbManagementsharesHolder.Name = "lbManagementsharesHolder";
            this.lbManagementsharesHolder.Size = new System.Drawing.Size(191, 16);
            this.lbManagementsharesHolder.TabIndex = 6;
            this.lbManagementsharesHolder.Text = "ManagementsharesHolderCode:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(317, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Name:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // JReportForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 548);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.JReportForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit txtPCode;
        private System.Windows.Forms.Label lbManagementsharesHolder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chAllCourses;
        private System.Windows.Forms.CheckedListBox chListCourses;
        private ClassLibrary.JComboBox cmbCity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.JComboBox cmbPaySource;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtSheetNo;
        private System.Windows.Forms.Label lbSheetNo;
        private System.Windows.Forms.RadioButton rbBoth;
        private System.Windows.Forms.RadioButton rbPayed;
        private System.Windows.Forms.RadioButton rbUnPayed;
        private System.Windows.Forms.Panel seperator;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.TextEdit txtShareNoAz;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.JComboBox cmbPName;
        private ClassLibrary.DateEdit txtToDate;
        private ClassLibrary.DateEdit txtFromDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private ClassLibrary.JComboBox cmbConditionCity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private ClassLibrary.DateEdit txtPayToDate;
        private ClassLibrary.DateEdit txtPayFromDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.TextEdit txtShareNoEla;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private ClassLibrary.TextEdit txtShareCountTo;
        private ClassLibrary.TextEdit txtShareCountFrom;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton rbSheet;
        private System.Windows.Forms.RadioButton rbPerson;

    }
}