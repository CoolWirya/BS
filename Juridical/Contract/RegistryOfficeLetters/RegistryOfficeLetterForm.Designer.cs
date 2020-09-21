namespace Legal
{
    partial class JRegistryOfficeLetterForm
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
            ClassLibrary.JPopupMenu jPopupMenu5 = new ClassLibrary.JPopupMenu();
            ClassLibrary.JPopupMenu jPopupMenu6 = new ClassLibrary.JPopupMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbJob = new System.Windows.Forms.Label();
            this.lbContractDate = new System.Windows.Forms.Label();
            this.lbDuration = new System.Windows.Forms.Label();
            this.lbGoodwillPrice = new System.Windows.Forms.Label();
            this.lbContractNo = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.txtRepNo = new ClassLibrary.TextEdit(this.components);
            this.txtLetterNo = new ClassLibrary.TextEdit(this.components);
            this.txtRepDate = new ClassLibrary.DateEdit(this.components);
            this.txtLetterDate = new ClassLibrary.DateEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.grpUnit = new System.Windows.Forms.GroupBox();
            this.lblBalcon = new System.Windows.Forms.Label();
            this.lblRent = new System.Windows.Forms.Label();
            this.lblInfra = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblRegPlaque = new System.Windows.Forms.Label();
            this.lblNumPlaquc = new System.Windows.Forms.Label();
            this.lblUnitNumber = new System.Windows.Forms.Label();
            this.lblMarket = new System.Windows.Forms.Label();
            this.lblFloor = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ArchiveList = new ArchivedDocuments.JArchiveList();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupSellers = new System.Windows.Forms.GroupBox();
            this.jdgvSeller = new ClassLibrary.JDataGrid();
            this.grpAdT1 = new System.Windows.Forms.GroupBox();
            this.jdgvBuyer = new ClassLibrary.JDataGrid();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpUnit.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupSellers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvSeller)).BeginInit();
            this.grpAdT1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvBuyer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 448);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 40);
            this.panel1.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(414, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 28);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(36, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(505, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "ثبت";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(597, 448);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.grpUnit);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(589, 419);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "نامه محضر";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbJob);
            this.groupBox3.Controls.Add(this.lbContractDate);
            this.groupBox3.Controls.Add(this.lbDuration);
            this.groupBox3.Controls.Add(this.lbGoodwillPrice);
            this.groupBox3.Controls.Add(this.lbContractNo);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(583, 133);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "مشخصات قرارداد";
            // 
            // lbJob
            // 
            this.lbJob.AutoSize = true;
            this.lbJob.Location = new System.Drawing.Point(114, 72);
            this.lbJob.Name = "lbJob";
            this.lbJob.Size = new System.Drawing.Size(13, 16);
            this.lbJob.TabIndex = 11;
            this.lbJob.Text = "-";
            // 
            // lbContractDate
            // 
            this.lbContractDate.AutoSize = true;
            this.lbContractDate.Location = new System.Drawing.Point(114, 42);
            this.lbContractDate.Name = "lbContractDate";
            this.lbContractDate.Size = new System.Drawing.Size(13, 16);
            this.lbContractDate.TabIndex = 9;
            this.lbContractDate.Text = "-";
            // 
            // lbDuration
            // 
            this.lbDuration.AutoSize = true;
            this.lbDuration.Location = new System.Drawing.Point(363, 101);
            this.lbDuration.Name = "lbDuration";
            this.lbDuration.Size = new System.Drawing.Size(13, 16);
            this.lbDuration.TabIndex = 8;
            this.lbDuration.Text = "-";
            // 
            // lbGoodwillPrice
            // 
            this.lbGoodwillPrice.AutoSize = true;
            this.lbGoodwillPrice.Location = new System.Drawing.Point(363, 72);
            this.lbGoodwillPrice.Name = "lbGoodwillPrice";
            this.lbGoodwillPrice.Size = new System.Drawing.Size(13, 16);
            this.lbGoodwillPrice.TabIndex = 7;
            this.lbGoodwillPrice.Text = "-";
            // 
            // lbContractNo
            // 
            this.lbContractNo.AutoSize = true;
            this.lbContractNo.Location = new System.Drawing.Point(363, 42);
            this.lbContractNo.Name = "lbContractNo";
            this.lbContractNo.Size = new System.Drawing.Size(13, 16);
            this.lbContractNo.TabIndex = 6;
            this.lbContractNo.Text = "-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(182, 72);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 16);
            this.label18.TabIndex = 5;
            this.label18.Text = "شغل:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(440, 101);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 16);
            this.label17.TabIndex = 4;
            this.label17.Text = "مدت اجاره:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(440, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 16);
            this.label14.TabIndex = 2;
            this.label14.Text = "مبلغ مال الاجاره:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(182, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "تاریخ قرارداد:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(440, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "شماره قرارداد:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.txtRepNo);
            this.groupBox2.Controls.Add(this.txtLetterNo);
            this.groupBox2.Controls.Add(this.txtRepDate);
            this.groupBox2.Controls.Add(this.txtLetterDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 132);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "نامه محضر";
            // 
            // txtPrice
            // 
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(334, 94);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(100, 23);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
            // 
            // txtRepNo
            // 
            this.txtRepNo.ChangeColorIfNotEmpty = false;
            this.txtRepNo.ChangeColorOnEnter = true;
            this.txtRepNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtRepNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRepNo.Location = new System.Drawing.Point(334, 61);
            this.txtRepNo.Name = "txtRepNo";
            this.txtRepNo.Negative = true;
            this.txtRepNo.NotEmpty = false;
            this.txtRepNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtRepNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRepNo.SelectOnEnter = true;
            this.txtRepNo.Size = new System.Drawing.Size(100, 23);
            this.txtRepNo.TabIndex = 2;
            this.txtRepNo.TextMode = ClassLibrary.TextModes.Text;
            this.txtRepNo.TextChanged += new System.EventHandler(this.txtLetterNo_TextChanged);
            // 
            // txtLetterNo
            // 
            this.txtLetterNo.ChangeColorIfNotEmpty = false;
            this.txtLetterNo.ChangeColorOnEnter = true;
            this.txtLetterNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLetterNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLetterNo.Location = new System.Drawing.Point(334, 25);
            this.txtLetterNo.Name = "txtLetterNo";
            this.txtLetterNo.Negative = true;
            this.txtLetterNo.NotEmpty = false;
            this.txtLetterNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLetterNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterNo.SelectOnEnter = true;
            this.txtLetterNo.Size = new System.Drawing.Size(100, 23);
            this.txtLetterNo.TabIndex = 0;
            this.txtLetterNo.TextMode = ClassLibrary.TextModes.Text;
            this.txtLetterNo.TextChanged += new System.EventHandler(this.txtLetterNo_TextChanged);
            // 
            // txtRepDate
            // 
            this.txtRepDate.ChangeColorIfNotEmpty = true;
            this.txtRepDate.ChangeColorOnEnter = true;
            this.txtRepDate.Date = new System.DateTime(((long)(0)));
            this.txtRepDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtRepDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRepDate.InsertInDatesTable = true;
            this.txtRepDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtRepDate.Location = new System.Drawing.Point(60, 61);
            this.txtRepDate.Mask = "0000/00/00";
            this.txtRepDate.Name = "txtRepDate";
            this.txtRepDate.NotEmpty = false;
            this.txtRepDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtRepDate.Size = new System.Drawing.Size(100, 23);
            this.txtRepDate.TabIndex = 3;
            this.txtRepDate.TextChanged += new System.EventHandler(this.txtLetterNo_TextChanged);
            // 
            // txtLetterDate
            // 
            this.txtLetterDate.ChangeColorIfNotEmpty = true;
            this.txtLetterDate.ChangeColorOnEnter = true;
            this.txtLetterDate.Date = new System.DateTime(((long)(0)));
            this.txtLetterDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLetterDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLetterDate.InsertInDatesTable = true;
            this.txtLetterDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtLetterDate.Location = new System.Drawing.Point(60, 25);
            this.txtLetterDate.Mask = "0000/00/00";
            this.txtLetterDate.Name = "txtLetterDate";
            this.txtLetterDate.NotEmpty = false;
            this.txtLetterDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLetterDate.Size = new System.Drawing.Size(100, 23);
            this.txtLetterDate.TabIndex = 1;
            this.txtLetterDate.TextChanged += new System.EventHandler(this.txtLetterNo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "تاریخ نامه محضر:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "شماره نامه محضر:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "تاریخ نامه:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(440, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "شماره نامه:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(440, 97);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 16);
            this.label16.TabIndex = 3;
            this.label16.Text = "مبلغ سرقفلی:";
            // 
            // grpUnit
            // 
            this.grpUnit.Controls.Add(this.lblBalcon);
            this.grpUnit.Controls.Add(this.lblRent);
            this.grpUnit.Controls.Add(this.lblInfra);
            this.grpUnit.Controls.Add(this.label36);
            this.grpUnit.Controls.Add(this.label6);
            this.grpUnit.Controls.Add(this.label15);
            this.grpUnit.Controls.Add(this.lblRegPlaque);
            this.grpUnit.Controls.Add(this.lblNumPlaquc);
            this.grpUnit.Controls.Add(this.lblUnitNumber);
            this.grpUnit.Controls.Add(this.lblMarket);
            this.grpUnit.Controls.Add(this.lblFloor);
            this.grpUnit.Controls.Add(this.label9);
            this.grpUnit.Controls.Add(this.label8);
            this.grpUnit.Controls.Add(this.label7);
            this.grpUnit.Controls.Add(this.label10);
            this.grpUnit.Controls.Add(this.label11);
            this.grpUnit.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpUnit.Location = new System.Drawing.Point(3, 3);
            this.grpUnit.Name = "grpUnit";
            this.grpUnit.Size = new System.Drawing.Size(583, 145);
            this.grpUnit.TabIndex = 1;
            this.grpUnit.TabStop = false;
            this.grpUnit.Text = "مشخصات واحد تجاری";
            this.grpUnit.Visible = false;
            // 
            // lblBalcon
            // 
            this.lblBalcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBalcon.AutoSize = true;
            this.lblBalcon.Location = new System.Drawing.Point(114, 58);
            this.lblBalcon.Name = "lblBalcon";
            this.lblBalcon.Size = new System.Drawing.Size(13, 16);
            this.lblBalcon.TabIndex = 100;
            this.lblBalcon.Text = "-";
            // 
            // lblRent
            // 
            this.lblRent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRent.AutoSize = true;
            this.lblRent.Location = new System.Drawing.Point(114, 116);
            this.lblRent.Name = "lblRent";
            this.lblRent.Size = new System.Drawing.Size(13, 16);
            this.lblRent.TabIndex = 98;
            this.lblRent.Text = "-";
            // 
            // lblInfra
            // 
            this.lblInfra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfra.AutoSize = true;
            this.lblInfra.Location = new System.Drawing.Point(114, 29);
            this.lblInfra.Name = "lblInfra";
            this.lblInfra.Size = new System.Drawing.Size(13, 16);
            this.lblInfra.TabIndex = 97;
            this.lblInfra.Text = "-";
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(173, 58);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(71, 16);
            this.label36.TabIndex = 95;
            this.label36.Text = "متراژ بالکن:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 93;
            this.label6.Text = "اجاره اولیه:";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(173, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 16);
            this.label15.TabIndex = 92;
            this.label15.Text = "متراژ:";
            // 
            // lblRegPlaque
            // 
            this.lblRegPlaque.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegPlaque.AutoSize = true;
            this.lblRegPlaque.Location = new System.Drawing.Point(399, 88);
            this.lblRegPlaque.Name = "lblRegPlaque";
            this.lblRegPlaque.Size = new System.Drawing.Size(13, 16);
            this.lblRegPlaque.TabIndex = 90;
            this.lblRegPlaque.Text = "-";
            // 
            // lblNumPlaquc
            // 
            this.lblNumPlaquc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumPlaquc.AutoSize = true;
            this.lblNumPlaquc.Location = new System.Drawing.Point(399, 117);
            this.lblNumPlaquc.Name = "lblNumPlaquc";
            this.lblNumPlaquc.Size = new System.Drawing.Size(13, 16);
            this.lblNumPlaquc.TabIndex = 89;
            this.lblNumPlaquc.Text = "-";
            // 
            // lblUnitNumber
            // 
            this.lblUnitNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnitNumber.AutoSize = true;
            this.lblUnitNumber.Location = new System.Drawing.Point(114, 87);
            this.lblUnitNumber.Name = "lblUnitNumber";
            this.lblUnitNumber.Size = new System.Drawing.Size(13, 16);
            this.lblUnitNumber.TabIndex = 86;
            this.lblUnitNumber.Text = "-";
            // 
            // lblMarket
            // 
            this.lblMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarket.AutoSize = true;
            this.lblMarket.Location = new System.Drawing.Point(399, 29);
            this.lblMarket.Name = "lblMarket";
            this.lblMarket.Size = new System.Drawing.Size(13, 16);
            this.lblMarket.TabIndex = 87;
            this.lblMarket.Text = "-";
            // 
            // lblFloor
            // 
            this.lblFloor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFloor.AutoSize = true;
            this.lblFloor.Location = new System.Drawing.Point(399, 59);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(13, 16);
            this.lblFloor.TabIndex = 88;
            this.lblFloor.Text = "-";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(440, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 16);
            this.label9.TabIndex = 85;
            this.label9.Text = "پلاک ثبتی:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(440, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 16);
            this.label8.TabIndex = 84;
            this.label8.Text = "شماره شناسایی:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(173, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 81;
            this.label7.Text = "شماره واحد:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(440, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 82;
            this.label10.Text = "نام مجتمع/بازار:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(440, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 16);
            this.label11.TabIndex = 83;
            this.label11.Text = "طبقه:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(510, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ArchiveList);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(589, 457);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "اسناد و تصاویر";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ArchiveList
            // 
            this.ArchiveList.AllowUserAddFile = true;
            this.ArchiveList.AllowUserAddFromArchive = true;
            this.ArchiveList.AllowUserAddImage = true;
            this.ArchiveList.AllowUserDeleteFile = true;
            this.ArchiveList.ClassName = "";
            this.ArchiveList.ClassNames = null;
            this.ArchiveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveList.EnabledChange = true;
            this.ArchiveList.Location = new System.Drawing.Point(3, 3);
            this.ArchiveList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArchiveList.Name = "ArchiveList";
            this.ArchiveList.ObjectCode = 0;
            this.ArchiveList.ObjectCodes = null;
            this.ArchiveList.PlaceCode = 0;
            this.ArchiveList.Size = new System.Drawing.Size(583, 451);
            this.ArchiveList.SubjectCode = 0;
            this.ArchiveList.TabIndex = 0;
            this.ArchiveList.AfterFileAdded += new ArchivedDocuments.JArchiveList.FileAdded(this.txtLetterNo_TextChanged);
            this.ArchiveList.AfterDescriptioEdited += new ArchivedDocuments.JArchiveList.DescriptioEdited(this.txtLetterNo_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupSellers);
            this.tabPage3.Controls.Add(this.grpAdT1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(589, 419);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "طرفین";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupSellers
            // 
            this.groupSellers.Controls.Add(this.jdgvSeller);
            this.groupSellers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSellers.Location = new System.Drawing.Point(0, 0);
            this.groupSellers.Name = "groupSellers";
            this.groupSellers.Size = new System.Drawing.Size(589, 204);
            this.groupSellers.TabIndex = 4;
            this.groupSellers.TabStop = false;
            this.groupSellers.Text = "فروشنده";
            // 
            // jdgvSeller
            // 
            this.jdgvSeller.ActionMenu = jPopupMenu5;
            this.jdgvSeller.AllowUserToAddRows = false;
            this.jdgvSeller.AllowUserToDeleteRows = false;
            this.jdgvSeller.AllowUserToOrderColumns = true;
            this.jdgvSeller.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvSeller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvSeller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvSeller.EnableContexMenu = true;
            this.jdgvSeller.KeyName = null;
            this.jdgvSeller.Location = new System.Drawing.Point(3, 19);
            this.jdgvSeller.Name = "jdgvSeller";
            this.jdgvSeller.ReadHeadersFromDB = false;
            this.jdgvSeller.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvSeller.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvSeller.ShowRowNumber = true;
            this.jdgvSeller.Size = new System.Drawing.Size(583, 182);
            this.jdgvSeller.TabIndex = 3;
            this.jdgvSeller.TableName = null;
            // 
            // grpAdT1
            // 
            this.grpAdT1.Controls.Add(this.jdgvBuyer);
            this.grpAdT1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpAdT1.Location = new System.Drawing.Point(0, 204);
            this.grpAdT1.Name = "grpAdT1";
            this.grpAdT1.Size = new System.Drawing.Size(589, 215);
            this.grpAdT1.TabIndex = 3;
            this.grpAdT1.TabStop = false;
            this.grpAdT1.Text = "خریدار";
            // 
            // jdgvBuyer
            // 
            this.jdgvBuyer.ActionMenu = jPopupMenu6;
            this.jdgvBuyer.AllowUserToAddRows = false;
            this.jdgvBuyer.AllowUserToDeleteRows = false;
            this.jdgvBuyer.AllowUserToOrderColumns = true;
            this.jdgvBuyer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvBuyer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvBuyer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvBuyer.EnableContexMenu = true;
            this.jdgvBuyer.KeyName = null;
            this.jdgvBuyer.Location = new System.Drawing.Point(3, 19);
            this.jdgvBuyer.Name = "jdgvBuyer";
            this.jdgvBuyer.ReadHeadersFromDB = false;
            this.jdgvBuyer.ReadOnly = true;
            this.jdgvBuyer.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvBuyer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvBuyer.ShowRowNumber = true;
            this.jdgvBuyer.Size = new System.Drawing.Size(583, 193);
            this.jdgvBuyer.TabIndex = 6;
            this.jdgvBuyer.TableName = null;
            // 
            // JRegistryOfficeLetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 488);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JRegistryOfficeLetterForm";
            this.Text = "نامه محضر";
            this.Load += new System.EventHandler(this.JRegistryOfficeLetterForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpUnit.ResumeLayout(false);
            this.grpUnit.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupSellers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvSeller)).EndInit();
            this.grpAdT1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvBuyer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpUnit;
        private System.Windows.Forms.Label lblBalcon;
        private System.Windows.Forms.Label lblRent;
        private System.Windows.Forms.Label lblInfra;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblRegPlaque;
        private System.Windows.Forms.Label lblNumPlaquc;
        private System.Windows.Forms.Label lblUnitNumber;
        private System.Windows.Forms.Label lblMarket;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.TextEdit txtRepNo;
        private ClassLibrary.TextEdit txtLetterNo;
        private ClassLibrary.DateEdit txtRepDate;
        private ClassLibrary.DateEdit txtLetterDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbJob;
        private System.Windows.Forms.Label lbContractDate;
        private System.Windows.Forms.Label lbDuration;
        private System.Windows.Forms.Label lbGoodwillPrice;
        private System.Windows.Forms.Label lbContractNo;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private ArchivedDocuments.JArchiveList ArchiveList;
        private ClassLibrary.TextEdit txtPrice;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupSellers;
        private ClassLibrary.JDataGrid jdgvSeller;
        private System.Windows.Forms.GroupBox grpAdT1;
        private ClassLibrary.JDataGrid jdgvBuyer;
    }
}