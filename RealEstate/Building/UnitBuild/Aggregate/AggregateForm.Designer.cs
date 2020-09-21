namespace RealEstate
{
    partial class JAggregateForm
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
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jdgvUnit = new ClassLibrary.JDataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelAgregatedUnit = new System.Windows.Forms.Button();
            this.btnAddAgregatedGrands = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblBalcon = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblRent = new System.Windows.Forms.Label();
            this.lblInfraAbout = new System.Windows.Forms.Label();
            this.lblInfra = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblRegPlaque = new System.Windows.Forms.Label();
            this.lblNumPlaquc = new System.Windows.Forms.Label();
            this.lblUnitNumber = new System.Windows.Forms.Label();
            this.lblMarket = new System.Windows.Forms.Label();
            this.lblFloor = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnDefineUnit = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDescAgg = new ClassLibrary.TextEdit(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.JArchive = new ArchivedDocuments.JArchiveList();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvUnit)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.JArchive.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(574, 346);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(568, 324);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.jdgvUnit);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnDelAgregatedUnit);
            this.tabPage1.Controls.Add(this.btnAddAgregatedGrands);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 295);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "لیست اعیان";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // jdgvUnit
            // 
            this.jdgvUnit.ActionMenu = jPopupMenu1;
            this.jdgvUnit.AllowUserToAddRows = false;
            this.jdgvUnit.AllowUserToDeleteRows = false;
            this.jdgvUnit.AllowUserToOrderColumns = true;
            this.jdgvUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jdgvUnit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvUnit.EnableContexMenu = true;
            this.jdgvUnit.KeyName = null;
            this.jdgvUnit.Location = new System.Drawing.Point(6, 26);
            this.jdgvUnit.Name = "jdgvUnit";
            this.jdgvUnit.ReadHeadersFromDB = false;
            this.jdgvUnit.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvUnit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvUnit.ShowRowNumber = true;
            this.jdgvUnit.Size = new System.Drawing.Size(546, 207);
            this.jdgvUnit.TabIndex = 17;
            this.jdgvUnit.TableName = null;
            this.jdgvUnit.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jdgvUnit_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "لیست اعیان هایی که قرار است تجمیع شوند:";
            // 
            // btnDelAgregatedUnit
            // 
            this.btnDelAgregatedUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelAgregatedUnit.Location = new System.Drawing.Point(213, 254);
            this.btnDelAgregatedUnit.Name = "btnDelAgregatedUnit";
            this.btnDelAgregatedUnit.Size = new System.Drawing.Size(75, 26);
            this.btnDelAgregatedUnit.TabIndex = 6;
            this.btnDelAgregatedUnit.Text = "حذف";
            this.btnDelAgregatedUnit.UseVisualStyleBackColor = true;
            this.btnDelAgregatedUnit.Click += new System.EventHandler(this.btnDelAgregatedUnit_Click);
            // 
            // btnAddAgregatedGrands
            // 
            this.btnAddAgregatedGrands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAgregatedGrands.Location = new System.Drawing.Point(299, 254);
            this.btnAddAgregatedGrands.Name = "btnAddAgregatedGrands";
            this.btnAddAgregatedGrands.Size = new System.Drawing.Size(75, 26);
            this.btnAddAgregatedGrands.TabIndex = 5;
            this.btnAddAgregatedGrands.Text = "اضافه";
            this.btnAddAgregatedGrands.UseVisualStyleBackColor = true;
            this.btnAddAgregatedGrands.Click += new System.EventHandler(this.btnAddAgregatedGrands_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblBalcon);
            this.tabPage2.Controls.Add(this.lblDate);
            this.tabPage2.Controls.Add(this.lblRent);
            this.tabPage2.Controls.Add(this.lblInfraAbout);
            this.tabPage2.Controls.Add(this.lblInfra);
            this.tabPage2.Controls.Add(this.label36);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.lblRegPlaque);
            this.tabPage2.Controls.Add(this.lblNumPlaquc);
            this.tabPage2.Controls.Add(this.lblUnitNumber);
            this.tabPage2.Controls.Add(this.lblMarket);
            this.tabPage2.Controls.Add(this.lblFloor);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.BtnDefineUnit);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(560, 295);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "اعیان تجمیع شده";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblBalcon
            // 
            this.lblBalcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBalcon.AutoSize = true;
            this.lblBalcon.Location = new System.Drawing.Point(119, 80);
            this.lblBalcon.Name = "lblBalcon";
            this.lblBalcon.Size = new System.Drawing.Size(13, 16);
            this.lblBalcon.TabIndex = 60;
            this.lblBalcon.Text = "-";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(119, 139);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(13, 16);
            this.lblDate.TabIndex = 58;
            this.lblDate.Text = "-";
            // 
            // lblRent
            // 
            this.lblRent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRent.AutoSize = true;
            this.lblRent.Location = new System.Drawing.Point(119, 110);
            this.lblRent.Name = "lblRent";
            this.lblRent.Size = new System.Drawing.Size(13, 16);
            this.lblRent.TabIndex = 56;
            this.lblRent.Text = "-";
            // 
            // lblInfraAbout
            // 
            this.lblInfraAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfraAbout.AutoSize = true;
            this.lblInfraAbout.Location = new System.Drawing.Point(119, 21);
            this.lblInfraAbout.Name = "lblInfraAbout";
            this.lblInfraAbout.Size = new System.Drawing.Size(13, 16);
            this.lblInfraAbout.TabIndex = 53;
            this.lblInfraAbout.Text = "-";
            // 
            // lblInfra
            // 
            this.lblInfra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfra.AutoSize = true;
            this.lblInfra.Location = new System.Drawing.Point(119, 51);
            this.lblInfra.Name = "lblInfra";
            this.lblInfra.Size = new System.Drawing.Size(13, 16);
            this.lblInfra.TabIndex = 54;
            this.lblInfra.Text = "-";
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(178, 80);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(71, 16);
            this.label36.TabIndex = 50;
            this.label36.Text = "متراژ بالکن:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(178, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 16);
            this.label13.TabIndex = 48;
            this.label13.Text = "تاریخ تحویل:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 46;
            this.label5.Text = "اجاره اولیه:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(178, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 16);
            this.label14.TabIndex = 43;
            this.label14.Text = "متراژ(تقریبی):";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(178, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 16);
            this.label15.TabIndex = 44;
            this.label15.Text = "متراژ:";
            // 
            // lblRegPlaque
            // 
            this.lblRegPlaque.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegPlaque.AutoSize = true;
            this.lblRegPlaque.Location = new System.Drawing.Point(406, 80);
            this.lblRegPlaque.Name = "lblRegPlaque";
            this.lblRegPlaque.Size = new System.Drawing.Size(13, 16);
            this.lblRegPlaque.TabIndex = 42;
            this.lblRegPlaque.Text = "-";
            // 
            // lblNumPlaquc
            // 
            this.lblNumPlaquc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumPlaquc.AutoSize = true;
            this.lblNumPlaquc.Location = new System.Drawing.Point(406, 109);
            this.lblNumPlaquc.Name = "lblNumPlaquc";
            this.lblNumPlaquc.Size = new System.Drawing.Size(13, 16);
            this.lblNumPlaquc.TabIndex = 41;
            this.lblNumPlaquc.Text = "-";
            // 
            // lblUnitNumber
            // 
            this.lblUnitNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnitNumber.AutoSize = true;
            this.lblUnitNumber.Location = new System.Drawing.Point(406, 138);
            this.lblUnitNumber.Name = "lblUnitNumber";
            this.lblUnitNumber.Size = new System.Drawing.Size(13, 16);
            this.lblUnitNumber.TabIndex = 36;
            this.lblUnitNumber.Text = "-";
            // 
            // lblMarket
            // 
            this.lblMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarket.AutoSize = true;
            this.lblMarket.Location = new System.Drawing.Point(406, 21);
            this.lblMarket.Name = "lblMarket";
            this.lblMarket.Size = new System.Drawing.Size(13, 16);
            this.lblMarket.TabIndex = 37;
            this.lblMarket.Text = "-";
            // 
            // lblFloor
            // 
            this.lblFloor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFloor.AutoSize = true;
            this.lblFloor.Location = new System.Drawing.Point(406, 51);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(13, 16);
            this.lblFloor.TabIndex = 38;
            this.lblFloor.Text = "-";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(447, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 16);
            this.label9.TabIndex = 35;
            this.label9.Text = "پلاک ثبتی:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(447, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "شماره شناسایی:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "شماره واحد:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "نام مجتمع/بازار:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(447, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "طبقه:";
            // 
            // BtnDefineUnit
            // 
            this.BtnDefineUnit.Location = new System.Drawing.Point(420, 252);
            this.BtnDefineUnit.Name = "BtnDefineUnit";
            this.BtnDefineUnit.Size = new System.Drawing.Size(101, 26);
            this.BtnDefineUnit.TabIndex = 0;
            this.BtnDefineUnit.Text = "تعریف اعیان";
            this.BtnDefineUnit.UseVisualStyleBackColor = true;
            this.BtnDefineUnit.Click += new System.EventHandler(this.BtnDefineUnit_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(560, 298);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "توضیحات";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDescAgg);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(560, 298);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "توضیحات";
            // 
            // txtDescAgg
            // 
            this.txtDescAgg.ChangeColorIfNotEmpty = false;
            this.txtDescAgg.ChangeColorOnEnter = true;
            this.txtDescAgg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescAgg.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDescAgg.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDescAgg.Location = new System.Drawing.Point(3, 19);
            this.txtDescAgg.Multiline = true;
            this.txtDescAgg.Name = "txtDescAgg";
            this.txtDescAgg.Negative = true;
            this.txtDescAgg.NotEmpty = false;
            this.txtDescAgg.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDescAgg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescAgg.SelectOnEnter = true;
            this.txtDescAgg.Size = new System.Drawing.Size(554, 276);
            this.txtDescAgg.TabIndex = 0;
            this.txtDescAgg.TextMode = ClassLibrary.TextModes.Text;
            this.txtDescAgg.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.JArchive);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(560, 298);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "فایل های مرتبط";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // JArchive
            // 
            this.JArchive.AllowUserAddFile = true;
            this.JArchive.AllowUserAddFromArchive = true;
            this.JArchive.AllowUserAddImage = true;
            this.JArchive.AllowUserDeleteFile = true;
            this.JArchive.ClassName = "";
            this.JArchive.ClassNames = null;
            this.JArchive.Controls.Add(this.txtDesc);
            this.JArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JArchive.EnabledChange = true;
            this.JArchive.Location = new System.Drawing.Point(0, 0);
            this.JArchive.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.JArchive.Name = "JArchive";
            this.JArchive.ObjectCode = 0;
            this.JArchive.ObjectCodes = null;
            this.JArchive.PlaceCode = 0;
            this.JArchive.Size = new System.Drawing.Size(560, 298);
            this.JArchive.SubjectCode = 0;
            this.JArchive.TabIndex = 1;
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDesc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(0, 0);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 59, 3, 59);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(560, 23);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnSaveClose);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 397);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 54);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(484, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 54;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(404, 18);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 52;
            this.btnSaveClose.Text = "ذخیره ";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(19, 17);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 53;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.SystemColors.Info;
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(383, 18);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 5;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(489, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 16);
            this.label11.TabIndex = 6;
            this.label11.Text = "تاریخ تجمیع:";
            // 
            // JAggregateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 451);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JAggregateForm";
            this.Text = "AggregateForm";
            this.Load += new System.EventHandler(this.JAggregateForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvUnit)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.JArchive.ResumeLayout(false);
            this.JArchive.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelAgregatedUnit;
        private System.Windows.Forms.Button btnAddAgregatedGrands;
        private System.Windows.Forms.Button BtnDefineUnit;
        private System.Windows.Forms.Label lblRegPlaque;
        private System.Windows.Forms.Label lblNumPlaquc;
        private System.Windows.Forms.Label lblUnitNumber;
        private System.Windows.Forms.Label lblMarket;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBalcon;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblRent;
        private System.Windows.Forms.Label lblInfraAbout;
        private System.Windows.Forms.Label lblInfra;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private ClassLibrary.JDataGrid jdgvUnit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabPage tabPage3;
        private ArchivedDocuments.JArchiveList JArchive;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox4;
        private ClassLibrary.TextEdit txtDescAgg;
    }
}