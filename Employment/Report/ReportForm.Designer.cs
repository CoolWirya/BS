namespace Employment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DateEmployeeEnd = new ClassLibrary.DateEdit(this.components);
            this.DateEmployeeStart = new ClassLibrary.DateEdit(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbNoActive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.chkFamRelation = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDateExpire1 = new ClassLibrary.DateEdit(this.components);
            this.txtDateExpire = new ClassLibrary.DateEdit(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbActivity = new ClassLibrary.JComboBox(this.components);
            this.label24 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEndDate1 = new ClassLibrary.DateEdit(this.components);
            this.txtStartDate1 = new ClassLibrary.DateEdit(this.components);
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.txtStartDate = new ClassLibrary.DateEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.jdgvMonfaselin = new ClassLibrary.JJanusGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tnMonfaselin = new System.Windows.Forms.TabPage();
            this.tbExpireChild = new System.Windows.Forms.TabPage();
            this.jdgvExpireChild = new ClassLibrary.JJanusGrid();
            this.tbFamily = new System.Windows.Forms.TabPage();
            this.jdgvFamily = new ClassLibrary.JJanusGrid();
            this.tbSanavat = new System.Windows.Forms.TabPage();
            this.jdgvSanavat = new ClassLibrary.JJanusGrid();
            this.tbChild = new System.Windows.Forms.TabPage();
            this.jdgvChildRight = new ClassLibrary.JJanusGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tnMonfaselin.SuspendLayout();
            this.tbExpireChild.SuspendLayout();
            this.tbFamily.SuspendLayout();
            this.tbSanavat.SuspendLayout();
            this.tbChild.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DateEmployeeEnd);
            this.groupBox1.Controls.Add(this.DateEmployeeStart);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chkFamRelation);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDateExpire1);
            this.groupBox1.Controls.Add(this.txtDateExpire);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbActivity);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEndDate1);
            this.groupBox1.Controls.Add(this.txtStartDate1);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // DateEmployeeEnd
            // 
            this.DateEmployeeEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateEmployeeEnd.ChangeColorIfNotEmpty = true;
            this.DateEmployeeEnd.ChangeColorOnEnter = true;
            this.DateEmployeeEnd.Date = new System.DateTime(((long)(0)));
            this.DateEmployeeEnd.InBackColor = System.Drawing.SystemColors.Info;
            this.DateEmployeeEnd.InForeColor = System.Drawing.SystemColors.WindowText;
            this.DateEmployeeEnd.InsertInDatesTable = true;
            this.DateEmployeeEnd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.DateEmployeeEnd.Location = new System.Drawing.Point(148, 48);
            this.DateEmployeeEnd.Mask = "0000/00/00";
            this.DateEmployeeEnd.Name = "DateEmployeeEnd";
            this.DateEmployeeEnd.NotEmpty = false;
            this.DateEmployeeEnd.NotEmptyColor = System.Drawing.Color.Red;
            this.DateEmployeeEnd.Size = new System.Drawing.Size(100, 23);
            this.DateEmployeeEnd.TabIndex = 97;
            // 
            // DateEmployeeStart
            // 
            this.DateEmployeeStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateEmployeeStart.ChangeColorIfNotEmpty = true;
            this.DateEmployeeStart.ChangeColorOnEnter = true;
            this.DateEmployeeStart.Date = new System.DateTime(((long)(0)));
            this.DateEmployeeStart.InBackColor = System.Drawing.SystemColors.Info;
            this.DateEmployeeStart.InForeColor = System.Drawing.SystemColors.WindowText;
            this.DateEmployeeStart.InsertInDatesTable = true;
            this.DateEmployeeStart.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.DateEmployeeStart.Location = new System.Drawing.Point(282, 48);
            this.DateEmployeeStart.Mask = "0000/00/00";
            this.DateEmployeeStart.Name = "DateEmployeeStart";
            this.DateEmployeeStart.NotEmpty = false;
            this.DateEmployeeStart.NotEmptyColor = System.Drawing.Color.Red;
            this.DateEmployeeStart.Size = new System.Drawing.Size(100, 23);
            this.DateEmployeeStart.TabIndex = 96;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(251, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 16);
            this.label9.TabIndex = 95;
            this.label9.Text = "الی";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(385, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 94;
            this.label8.Text = "تاریخ استخدام:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rbNoActive);
            this.groupBox2.Controls.Add(this.rbActive);
            this.groupBox2.Location = new System.Drawing.Point(291, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(147, 40);
            this.groupBox2.TabIndex = 93;
            this.groupBox2.TabStop = false;
            // 
            // rbNoActive
            // 
            this.rbNoActive.AutoSize = true;
            this.rbNoActive.Location = new System.Drawing.Point(6, 17);
            this.rbNoActive.Name = "rbNoActive";
            this.rbNoActive.Size = new System.Drawing.Size(75, 20);
            this.rbNoActive.TabIndex = 4;
            this.rbNoActive.Text = "منفصلین";
            this.rbNoActive.UseVisualStyleBackColor = true;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Location = new System.Drawing.Point(92, 17);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(49, 20);
            this.rbActive.TabIndex = 3;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "فعال";
            this.rbActive.UseVisualStyleBackColor = true;
            // 
            // chkFamRelation
            // 
            this.chkFamRelation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFamRelation.CheckOnClick = true;
            this.chkFamRelation.FormattingEnabled = true;
            this.chkFamRelation.Location = new System.Drawing.Point(12, 12);
            this.chkFamRelation.Name = "chkFamRelation";
            this.chkFamRelation.Size = new System.Drawing.Size(108, 58);
            this.chkFamRelation.TabIndex = 92;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(583, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 16);
            this.label6.TabIndex = 90;
            this.label6.Text = "الی";
            // 
            // txtDateExpire1
            // 
            this.txtDateExpire1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateExpire1.ChangeColorIfNotEmpty = true;
            this.txtDateExpire1.ChangeColorOnEnter = true;
            this.txtDateExpire1.Date = new System.DateTime(((long)(0)));
            this.txtDateExpire1.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateExpire1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateExpire1.InsertInDatesTable = true;
            this.txtDateExpire1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateExpire1.Location = new System.Drawing.Point(480, 77);
            this.txtDateExpire1.Mask = "0000/00/00";
            this.txtDateExpire1.Name = "txtDateExpire1";
            this.txtDateExpire1.NotEmpty = false;
            this.txtDateExpire1.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateExpire1.Size = new System.Drawing.Size(100, 23);
            this.txtDateExpire1.TabIndex = 89;
            // 
            // txtDateExpire
            // 
            this.txtDateExpire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateExpire.ChangeColorIfNotEmpty = true;
            this.txtDateExpire.ChangeColorOnEnter = true;
            this.txtDateExpire.Date = new System.DateTime(((long)(0)));
            this.txtDateExpire.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateExpire.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateExpire.InsertInDatesTable = true;
            this.txtDateExpire.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateExpire.Location = new System.Drawing.Point(614, 77);
            this.txtDateExpire.Mask = "0000/00/00";
            this.txtDateExpire.Name = "txtDateExpire";
            this.txtDateExpire.NotEmpty = false;
            this.txtDateExpire.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateExpire.Size = new System.Drawing.Size(100, 23);
            this.txtDateExpire.TabIndex = 88;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(718, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 16);
            this.label7.TabIndex = 87;
            this.label7.Text = "تاریخ اتمام افراد تکفل:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(385, 79);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 86;
            this.label5.Text = " واحد فعالیت:";
            // 
            // cmbActivity
            // 
            this.cmbActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbActivity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbActivity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbActivity.BaseCode = 0;
            this.cmbActivity.ChangeColorIfNotEmpty = true;
            this.cmbActivity.ChangeColorOnEnter = true;
            this.cmbActivity.FormattingEnabled = true;
            this.cmbActivity.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbActivity.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbActivity.Location = new System.Drawing.Point(148, 76);
            this.cmbActivity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbActivity.Name = "cmbActivity";
            this.cmbActivity.NotEmpty = false;
            this.cmbActivity.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbActivity.SelectOnEnter = true;
            this.cmbActivity.Size = new System.Drawing.Size(234, 24);
            this.cmbActivity.TabIndex = 85;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(125, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(52, 16);
            this.label24.TabIndex = 84;
            this.label24.Text = "نسبت :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(583, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "الی";
            // 
            // txtEndDate1
            // 
            this.txtEndDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate1.ChangeColorIfNotEmpty = true;
            this.txtEndDate1.ChangeColorOnEnter = true;
            this.txtEndDate1.Date = new System.DateTime(((long)(0)));
            this.txtEndDate1.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate1.InsertInDatesTable = true;
            this.txtEndDate1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDate1.Location = new System.Drawing.Point(480, 45);
            this.txtEndDate1.Mask = "0000/00/00";
            this.txtEndDate1.Name = "txtEndDate1";
            this.txtEndDate1.NotEmpty = false;
            this.txtEndDate1.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate1.Size = new System.Drawing.Size(100, 23);
            this.txtEndDate1.TabIndex = 9;
            // 
            // txtStartDate1
            // 
            this.txtStartDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDate1.ChangeColorIfNotEmpty = true;
            this.txtStartDate1.ChangeColorOnEnter = true;
            this.txtStartDate1.Date = new System.DateTime(((long)(0)));
            this.txtStartDate1.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartDate1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDate1.InsertInDatesTable = true;
            this.txtStartDate1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartDate1.Location = new System.Drawing.Point(480, 16);
            this.txtStartDate1.Mask = "0000/00/00";
            this.txtStartDate1.Name = "txtStartDate1";
            this.txtStartDate1.NotEmpty = false;
            this.txtStartDate1.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartDate1.Size = new System.Drawing.Size(100, 23);
            this.txtStartDate1.TabIndex = 8;
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
            this.txtEndDate.Location = new System.Drawing.Point(614, 45);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate.Size = new System.Drawing.Size(100, 23);
            this.txtEndDate.TabIndex = 7;
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
            this.txtStartDate.Location = new System.Drawing.Point(614, 16);
            this.txtStartDate.Mask = "0000/00/00";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.NotEmpty = false;
            this.txtStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartDate.Size = new System.Drawing.Size(100, 23);
            this.txtStartDate.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(583, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "الی";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(718, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "تاریخ پایان قرارداد از:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(718, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "تاریخ شروع قرارداد از:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(11, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(109, 29);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // jdgvMonfaselin
            // 
            this.jdgvMonfaselin.ActionClassName = "";
            this.jdgvMonfaselin.ActionMenu = null;
            this.jdgvMonfaselin.DataSource = null;
            this.jdgvMonfaselin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvMonfaselin.Edited = false;
            this.jdgvMonfaselin.Location = new System.Drawing.Point(3, 3);
            this.jdgvMonfaselin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jdgvMonfaselin.MultiSelect = true;
            this.jdgvMonfaselin.Name = "jdgvMonfaselin";
            this.jdgvMonfaselin.ShowNavigator = true;
            this.jdgvMonfaselin.ShowToolbar = true;
            this.jdgvMonfaselin.Size = new System.Drawing.Size(833, 354);
            this.jdgvMonfaselin.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tnMonfaselin);
            this.tabControl1.Controls.Add(this.tbExpireChild);
            this.tabControl1.Controls.Add(this.tbFamily);
            this.tabControl1.Controls.Add(this.tbSanavat);
            this.tabControl1.Controls.Add(this.tbChild);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 112);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(847, 389);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tnMonfaselin
            // 
            this.tnMonfaselin.Controls.Add(this.jdgvMonfaselin);
            this.tnMonfaselin.Location = new System.Drawing.Point(4, 25);
            this.tnMonfaselin.Name = "tnMonfaselin";
            this.tnMonfaselin.Padding = new System.Windows.Forms.Padding(3);
            this.tnMonfaselin.Size = new System.Drawing.Size(839, 360);
            this.tnMonfaselin.TabIndex = 0;
            this.tnMonfaselin.Text = "اتمام قرارداد ";
            this.tnMonfaselin.UseVisualStyleBackColor = true;
            // 
            // tbExpireChild
            // 
            this.tbExpireChild.Controls.Add(this.jdgvExpireChild);
            this.tbExpireChild.Location = new System.Drawing.Point(4, 25);
            this.tbExpireChild.Name = "tbExpireChild";
            this.tbExpireChild.Padding = new System.Windows.Forms.Padding(3);
            this.tbExpireChild.Size = new System.Drawing.Size(839, 360);
            this.tbExpireChild.TabIndex = 1;
            this.tbExpireChild.Text = "اتمام افراد تحت تکفل";
            this.tbExpireChild.UseVisualStyleBackColor = true;
            // 
            // jdgvExpireChild
            // 
            this.jdgvExpireChild.ActionClassName = "";
            this.jdgvExpireChild.ActionMenu = null;
            this.jdgvExpireChild.DataSource = null;
            this.jdgvExpireChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvExpireChild.Edited = false;
            this.jdgvExpireChild.Location = new System.Drawing.Point(3, 3);
            this.jdgvExpireChild.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jdgvExpireChild.MultiSelect = true;
            this.jdgvExpireChild.Name = "jdgvExpireChild";
            this.jdgvExpireChild.ShowNavigator = true;
            this.jdgvExpireChild.ShowToolbar = true;
            this.jdgvExpireChild.Size = new System.Drawing.Size(833, 354);
            this.jdgvExpireChild.TabIndex = 2;
            // 
            // tbFamily
            // 
            this.tbFamily.Controls.Add(this.jdgvFamily);
            this.tbFamily.Location = new System.Drawing.Point(4, 25);
            this.tbFamily.Name = "tbFamily";
            this.tbFamily.Size = new System.Drawing.Size(839, 360);
            this.tbFamily.TabIndex = 2;
            this.tbFamily.Text = " آمار خانوار پرسنل";
            this.tbFamily.UseVisualStyleBackColor = true;
            // 
            // jdgvFamily
            // 
            this.jdgvFamily.ActionClassName = "";
            this.jdgvFamily.ActionMenu = null;
            this.jdgvFamily.DataSource = null;
            this.jdgvFamily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvFamily.Edited = false;
            this.jdgvFamily.Location = new System.Drawing.Point(0, 0);
            this.jdgvFamily.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jdgvFamily.MultiSelect = true;
            this.jdgvFamily.Name = "jdgvFamily";
            this.jdgvFamily.ShowNavigator = true;
            this.jdgvFamily.ShowToolbar = true;
            this.jdgvFamily.Size = new System.Drawing.Size(839, 360);
            this.jdgvFamily.TabIndex = 3;
            // 
            // tbSanavat
            // 
            this.tbSanavat.Controls.Add(this.jdgvSanavat);
            this.tbSanavat.Location = new System.Drawing.Point(4, 25);
            this.tbSanavat.Name = "tbSanavat";
            this.tbSanavat.Size = new System.Drawing.Size(839, 360);
            this.tbSanavat.TabIndex = 3;
            this.tbSanavat.Text = "تاریخ استخدام سنوات";
            this.tbSanavat.UseVisualStyleBackColor = true;
            // 
            // jdgvSanavat
            // 
            this.jdgvSanavat.ActionClassName = "";
            this.jdgvSanavat.ActionMenu = null;
            this.jdgvSanavat.DataSource = null;
            this.jdgvSanavat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvSanavat.Edited = false;
            this.jdgvSanavat.Location = new System.Drawing.Point(0, 0);
            this.jdgvSanavat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jdgvSanavat.MultiSelect = true;
            this.jdgvSanavat.Name = "jdgvSanavat";
            this.jdgvSanavat.ShowNavigator = true;
            this.jdgvSanavat.ShowToolbar = true;
            this.jdgvSanavat.Size = new System.Drawing.Size(839, 360);
            this.jdgvSanavat.TabIndex = 4;
            // 
            // tbChild
            // 
            this.tbChild.Controls.Add(this.jdgvChildRight);
            this.tbChild.Location = new System.Drawing.Point(4, 25);
            this.tbChild.Name = "tbChild";
            this.tbChild.Size = new System.Drawing.Size(839, 360);
            this.tbChild.TabIndex = 4;
            this.tbChild.Text = "تاریخ استخدام حق اولاد";
            this.tbChild.UseVisualStyleBackColor = true;
            // 
            // jdgvChildRight
            // 
            this.jdgvChildRight.ActionClassName = "";
            this.jdgvChildRight.ActionMenu = null;
            this.jdgvChildRight.DataSource = null;
            this.jdgvChildRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvChildRight.Edited = false;
            this.jdgvChildRight.Location = new System.Drawing.Point(0, 0);
            this.jdgvChildRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jdgvChildRight.MultiSelect = true;
            this.jdgvChildRight.Name = "jdgvChildRight";
            this.jdgvChildRight.ShowNavigator = true;
            this.jdgvChildRight.ShowToolbar = true;
            this.jdgvChildRight.Size = new System.Drawing.Size(839, 360);
            this.jdgvChildRight.TabIndex = 4;
            // 
            // JReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 501);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "JReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.JReportForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tnMonfaselin.ResumeLayout(false);
            this.tbExpireChild.ResumeLayout(false);
            this.tbFamily.ResumeLayout(false);
            this.tbSanavat.ResumeLayout(false);
            this.tbChild.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JJanusGrid jdgvMonfaselin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.DateEdit txtEndDate1;
        private ClassLibrary.DateEdit txtStartDate1;
        private ClassLibrary.DateEdit txtEndDate;
        private ClassLibrary.DateEdit txtStartDate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tnMonfaselin;
        private System.Windows.Forms.TabPage tbExpireChild;
        private ClassLibrary.JJanusGrid jdgvExpireChild;
        private System.Windows.Forms.TabPage tbFamily;
        private ClassLibrary.JJanusGrid jdgvFamily;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.JComboBox cmbActivity;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.DateEdit txtDateExpire1;
        private ClassLibrary.DateEdit txtDateExpire;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox chkFamRelation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbNoActive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.Label label8;
        private ClassLibrary.DateEdit DateEmployeeEnd;
        private ClassLibrary.DateEdit DateEmployeeStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tbSanavat;
        private ClassLibrary.JJanusGrid jdgvSanavat;
        private System.Windows.Forms.TabPage tbChild;
        private ClassLibrary.JJanusGrid jdgvChildRight;
    }
}