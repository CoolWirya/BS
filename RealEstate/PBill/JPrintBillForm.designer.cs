namespace RealEstate
{
    partial class JPrintBillForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.cmbComplex = new ClassLibrary.JComboBox(this.components);
            this.CmbBeginPlaque = new ClassLibrary.JComboBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbMonth = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.GrdPrintedGhabz = new ClassLibrary.JJanusGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.DelGhabz = new System.Windows.Forms.Button();
            this.PrintGhabz = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.btnRePrint = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSal = new ClassLibrary.JComboBox(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GrdCharge = new ClassLibrary.JJanusGrid();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtReport = new ClassLibrary.TextEdit(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeadDate = new ClassLibrary.DateEdit(this.components);
            this.chkMali = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.txtpath = new ClassLibrary.TextEdit(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.chkTemp = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CmbEndPluge = new ClassLibrary.JComboBox(this.components);
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "تا شماره :";
            // 
            // cmbComplex
            // 
            this.cmbComplex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbComplex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbComplex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbComplex.BackColor = System.Drawing.SystemColors.Info;
            this.cmbComplex.BaseCode = 0;
            this.cmbComplex.ChangeColorIfNotEmpty = true;
            this.cmbComplex.ChangeColorOnEnter = true;
            this.cmbComplex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbComplex.FormattingEnabled = true;
            this.cmbComplex.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbComplex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbComplex.Location = new System.Drawing.Point(547, 42);
            this.cmbComplex.Name = "cmbComplex";
            this.cmbComplex.NotEmpty = false;
            this.cmbComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbComplex.SelectOnEnter = true;
            this.cmbComplex.Size = new System.Drawing.Size(181, 24);
            this.cmbComplex.Sorted = true;
            this.cmbComplex.TabIndex = 8;
            this.cmbComplex.SelectedIndexChanged += new System.EventHandler(this.cmbComplex_SelectedIndexChanged);
            // 
            // CmbBeginPlaque
            // 
            this.CmbBeginPlaque.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.CmbBeginPlaque.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbBeginPlaque.BaseCode = 0;
            this.CmbBeginPlaque.ChangeColorIfNotEmpty = true;
            this.CmbBeginPlaque.ChangeColorOnEnter = true;
            this.CmbBeginPlaque.FormattingEnabled = true;
            this.CmbBeginPlaque.InBackColor = System.Drawing.SystemColors.Info;
            this.CmbBeginPlaque.InForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbBeginPlaque.Location = new System.Drawing.Point(84, 22);
            this.CmbBeginPlaque.Name = "CmbBeginPlaque";
            this.CmbBeginPlaque.NotEmpty = false;
            this.CmbBeginPlaque.NotEmptyColor = System.Drawing.Color.Red;
            this.CmbBeginPlaque.SelectOnEnter = true;
            this.CmbBeginPlaque.Size = new System.Drawing.Size(90, 24);
            this.CmbBeginPlaque.TabIndex = 18;
            this.CmbBeginPlaque.SelectedIndexChanged += new System.EventHandler(this.CmbBeginPlaque_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(728, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "مجتمع :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "از شماره :";
            // 
            // CmbMonth
            // 
            this.CmbMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.CmbMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbMonth.BaseCode = 0;
            this.CmbMonth.ChangeColorIfNotEmpty = true;
            this.CmbMonth.ChangeColorOnEnter = true;
            this.CmbMonth.FormattingEnabled = true;
            this.CmbMonth.InBackColor = System.Drawing.SystemColors.Info;
            this.CmbMonth.InForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbMonth.Items.AddRange(new object[] {
            "فروردین",
            "اردیبهشت",
            "خرداد",
            "تیر",
            "مرداد",
            "شهریور",
            "مهر",
            "آبان",
            "آذر",
            "دی",
            "بهمن",
            "اسفند"});
            this.CmbMonth.Location = new System.Drawing.Point(271, 42);
            this.CmbMonth.Name = "CmbMonth";
            this.CmbMonth.NotEmpty = false;
            this.CmbMonth.NotEmptyColor = System.Drawing.Color.Red;
            this.CmbMonth.SelectOnEnter = true;
            this.CmbMonth.Size = new System.Drawing.Size(112, 24);
            this.CmbMonth.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(389, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "ماه :";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.GrdPrintedGhabz);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(788, 533);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "قبض هاي صادر شده";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // GrdPrintedGhabz
            // 
            this.GrdPrintedGhabz.ActionMenu = null;
            this.GrdPrintedGhabz.DataSource = null;
            this.GrdPrintedGhabz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdPrintedGhabz.Edited = false;
            this.GrdPrintedGhabz.Location = new System.Drawing.Point(3, 61);
            this.GrdPrintedGhabz.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.GrdPrintedGhabz.MultiSelect = false;
            this.GrdPrintedGhabz.Name = "GrdPrintedGhabz";
            this.GrdPrintedGhabz.ShowNavigator = true;
            this.GrdPrintedGhabz.ShowToolbar = false;
            this.GrdPrintedGhabz.Size = new System.Drawing.Size(782, 469);
            this.GrdPrintedGhabz.TabIndex = 22;
            this.GrdPrintedGhabz.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.GrdPrintedGhabz_OnRowDBClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.DelGhabz);
            this.groupBox1.Controls.Add(this.PrintGhabz);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(782, 58);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "عمليات برروي قبض هاي صادر شده";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(297, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 36);
            this.button1.TabIndex = 20;
            this.button1.Text = "حذف قبض هاي مبلغ صفر";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DelGhabz
            // 
            this.DelGhabz.Dock = System.Windows.Forms.DockStyle.Right;
            this.DelGhabz.Location = new System.Drawing.Point(473, 19);
            this.DelGhabz.Name = "DelGhabz";
            this.DelGhabz.Size = new System.Drawing.Size(153, 36);
            this.DelGhabz.TabIndex = 19;
            this.DelGhabz.Text = "حذف قبوض";
            this.DelGhabz.UseVisualStyleBackColor = true;
            this.DelGhabz.Click += new System.EventHandler(this.DelGhabz_Click);
            // 
            // PrintGhabz
            // 
            this.PrintGhabz.Dock = System.Windows.Forms.DockStyle.Right;
            this.PrintGhabz.Location = new System.Drawing.Point(626, 19);
            this.PrintGhabz.Name = "PrintGhabz";
            this.PrintGhabz.Size = new System.Drawing.Size(153, 36);
            this.PrintGhabz.TabIndex = 18;
            this.PrintGhabz.Text = "چاپ قبوض صادر شده";
            this.PrintGhabz.UseVisualStyleBackColor = true;
            this.PrintGhabz.Click += new System.EventHandler(this.PrintGhabz_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnUpdate.Location = new System.Drawing.Point(3, 503);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(782, 27);
            this.BtnUpdate.TabIndex = 20;
            this.BtnUpdate.Text = "بروز رساني اطلاعات مالي";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnRePrint
            // 
            this.btnRePrint.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRePrint.Location = new System.Drawing.Point(3, 19);
            this.btnRePrint.Name = "btnRePrint";
            this.btnRePrint.Size = new System.Drawing.Size(74, 71);
            this.btnRePrint.TabIndex = 14;
            this.btnRePrint.Text = "جستجو";
            this.btnRePrint.UseVisualStyleBackColor = true;
            this.btnRePrint.Click += new System.EventHandler(this.btnRePrint_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(500, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "سال :";
            // 
            // cmbSal
            // 
            this.cmbSal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSal.BaseCode = 0;
            this.cmbSal.ChangeColorIfNotEmpty = true;
            this.cmbSal.ChangeColorOnEnter = true;
            this.cmbSal.FormattingEnabled = true;
            this.cmbSal.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbSal.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSal.Items.AddRange(new object[] {
            "1386",
            "1387",
            "1388",
            "1389",
            "1390",
            "1391",
            "1392",
            "1393",
            "1394",
            "1395",
            "1396",
            "1397",
            "1398",
            "1399"});
            this.cmbSal.Location = new System.Drawing.Point(433, 42);
            this.cmbSal.Name = "cmbSal";
            this.cmbSal.NotEmpty = false;
            this.cmbSal.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbSal.SelectOnEnter = true;
            this.cmbSal.Size = new System.Drawing.Size(61, 24);
            this.cmbSal.TabIndex = 16;
            this.cmbSal.Text = "1390";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GrdCharge);
            this.tabPage2.Controls.Add(this.BtnUpdate);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(788, 533);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "اطلاعات شارژ واحدهاي تجاري";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GrdCharge
            // 
            this.GrdCharge.ActionMenu = null;
            this.GrdCharge.DataSource = null;
            this.GrdCharge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdCharge.Edited = false;
            this.GrdCharge.Location = new System.Drawing.Point(3, 3);
            this.GrdCharge.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.GrdCharge.MultiSelect = false;
            this.GrdCharge.Name = "GrdCharge";
            this.GrdCharge.ShowNavigator = true;
            this.GrdCharge.ShowToolbar = false;
            this.GrdCharge.Size = new System.Drawing.Size(782, 500);
            this.GrdCharge.TabIndex = 21;
            this.GrdCharge.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.GrdCharge_OnRowDBClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtReport);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.BtnPrint);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtDeadDate);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(788, 533);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "صدور قبض شارژ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtReport
            // 
            this.txtReport.ChangeColorIfNotEmpty = false;
            this.txtReport.ChangeColorOnEnter = true;
            this.txtReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtReport.InBackColor = System.Drawing.SystemColors.Info;
            this.txtReport.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReport.Location = new System.Drawing.Point(3, 3);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.Negative = true;
            this.txtReport.NotEmpty = false;
            this.txtReport.NotEmptyColor = System.Drawing.Color.Red;
            this.txtReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReport.SelectOnEnter = true;
            this.txtReport.Size = new System.Drawing.Size(782, 402);
            this.txtReport.TabIndex = 23;
            this.txtReport.TextMode = ClassLibrary.TextModes.Text;
            this.txtReport.TextChanged += new System.EventHandler(this.txtReport_TextChanged);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.Location = new System.Drawing.Point(3, 446);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(782, 42);
            this.button2.TabIndex = 22;
            this.button2.Text = "ورود به قسمت مديريت چاپ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnPrint.Location = new System.Drawing.Point(3, 488);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(782, 42);
            this.BtnPrint.TabIndex = 13;
            this.BtnPrint.Text = "صدور قبض شارژ";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(652, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "آخرين مهلت پرداخت :";
            // 
            // txtDeadDate
            // 
            this.txtDeadDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeadDate.BackColor = System.Drawing.SystemColors.Info;
            this.txtDeadDate.ChangeColorIfNotEmpty = true;
            this.txtDeadDate.ChangeColorOnEnter = true;
            this.txtDeadDate.Date = new System.DateTime(((long)(0)));
            this.txtDeadDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeadDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDeadDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeadDate.InsertInDatesTable = true;
            this.txtDeadDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDeadDate.Location = new System.Drawing.Point(557, 413);
            this.txtDeadDate.Mask = "0000/00/00";
            this.txtDeadDate.Name = "txtDeadDate";
            this.txtDeadDate.NotEmpty = false;
            this.txtDeadDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDeadDate.Size = new System.Drawing.Size(89, 23);
            this.txtDeadDate.TabIndex = 11;
            // 
            // chkMali
            // 
            this.chkMali.AutoSize = true;
            this.chkMali.Location = new System.Drawing.Point(653, 26);
            this.chkMali.Name = "chkMali";
            this.chkMali.Size = new System.Drawing.Size(122, 20);
            this.chkMali.TabIndex = 24;
            this.chkMali.Text = "كسر بدهي جاري";
            this.chkMali.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(796, 562);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.txtpath);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.chkTemp);
            this.tabPage4.Controls.Add(this.chkMali);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(788, 533);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "تنظيمات";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(627, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "آدرس فايل execl بدهي ها";
            // 
            // txtpath
            // 
            this.txtpath.ChangeColorIfNotEmpty = false;
            this.txtpath.ChangeColorOnEnter = true;
            this.txtpath.InBackColor = System.Drawing.SystemColors.Info;
            this.txtpath.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtpath.Location = new System.Drawing.Point(402, 145);
            this.txtpath.Name = "txtpath";
            this.txtpath.Negative = true;
            this.txtpath.NotEmpty = false;
            this.txtpath.NotEmptyColor = System.Drawing.Color.Red;
            this.txtpath.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtpath.SelectOnEnter = true;
            this.txtpath.Size = new System.Drawing.Size(219, 23);
            this.txtpath.TabIndex = 33;
            this.txtpath.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(321, 145);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 32;
            this.button4.Text = "جستجو...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // chkTemp
            // 
            this.chkTemp.AutoSize = true;
            this.chkTemp.Location = new System.Drawing.Point(389, 86);
            this.chkTemp.Name = "chkTemp";
            this.chkTemp.Size = new System.Drawing.Size(386, 20);
            this.chkTemp.TabIndex = 25;
            this.chkTemp.Text = "عدم صدور قبض براي غرفه هايي كه حق شارژ تعيين نگرديده است ";
            this.chkTemp.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CmbEndPluge);
            this.groupBox2.Controls.Add(this.btnRePrint);
            this.groupBox2.Controls.Add(this.cmbComplex);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbSal);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.CmbBeginPlaque);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.CmbMonth);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 568);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(796, 93);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "انتخاب عمليات";
            // 
            // CmbEndPluge
            // 
            this.CmbEndPluge.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.CmbEndPluge.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbEndPluge.BaseCode = 0;
            this.CmbEndPluge.ChangeColorIfNotEmpty = true;
            this.CmbEndPluge.ChangeColorOnEnter = true;
            this.CmbEndPluge.FormattingEnabled = true;
            this.CmbEndPluge.InBackColor = System.Drawing.SystemColors.Info;
            this.CmbEndPluge.InForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbEndPluge.Location = new System.Drawing.Point(84, 59);
            this.CmbEndPluge.Name = "CmbEndPluge";
            this.CmbEndPluge.NotEmpty = false;
            this.CmbEndPluge.NotEmptyColor = System.Drawing.Color.Red;
            this.CmbEndPluge.SelectOnEnter = true;
            this.CmbEndPluge.Size = new System.Drawing.Size(90, 24);
            this.CmbEndPluge.TabIndex = 19;
            // 
            // JPrintBillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 661);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JPrintBillForm";
            this.Text = "قسمت شارژ";
            this.Load += new System.EventHandler(this.JPrintBillForm_Load);
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JComboBox cmbComplex;
        private ClassLibrary.JComboBox CmbMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.JComboBox CmbBeginPlaque;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button DelGhabz;
        private System.Windows.Forms.Button PrintGhabz;
        private ClassLibrary.JComboBox cmbSal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRePrint;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private ClassLibrary.TextEdit txtReport;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.DateEdit txtDeadDate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.JComboBox CmbEndPluge;
        private System.Windows.Forms.CheckBox chkMali;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox chkTemp;
        private System.Windows.Forms.Button button1;
        private ClassLibrary.JJanusGrid GrdCharge;
        private ClassLibrary.JJanusGrid GrdPrintedGhabz;
        private ClassLibrary.TextEdit txtpath;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label9;

    }
}