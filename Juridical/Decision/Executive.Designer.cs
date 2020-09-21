namespace Legal
{
    partial class JExecutiveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JExecutiveForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btndelClient = new System.Windows.Forms.Button();
            this.btnaddClient = new System.Windows.Forms.Button();
            this.jdgvFey = new ClassLibrary.JDataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btndelWinner = new System.Windows.Forms.Button();
            this.btnAddWinner = new System.Windows.Forms.Button();
            this.jdgvWinner = new ClassLibrary.JDataGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.jArchiveExe = new ArchivedDocuments.JArchiveList();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNumClase2 = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumClase = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumber = new ClassLibrary.TextEdit(this.components);
            this.btnSearchPetition = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.btnDelAsset = new System.Windows.Forms.Button();
            this.btnAddAsset = new System.Windows.Forms.Button();
            this.jDGlistAsset = new ClassLibrary.JDataGrid();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvFey)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvWinner)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDGlistAsset)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "aktion.png");
            this.imageList.Images.SetKeyName(1, "alert.png");
            this.imageList.Images.SetKeyName(2, "All software is current.png");
            this.imageList.Images.SetKeyName(3, "amor.png");
            this.imageList.Images.SetKeyName(4, "antivirus.png");
            this.imageList.Images.SetKeyName(5, "applixware.png");
            this.imageList.Images.SetKeyName(6, "ark.png");
            this.imageList.Images.SetKeyName(7, "arts.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "تاریخ اجراء:";
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
            this.txtDate.Location = new System.Drawing.Point(47, 11);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 1;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
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
            this.tabControl1.Size = new System.Drawing.Size(568, 392);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "مشخصات طرفین";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btndelClient);
            this.groupBox2.Controls.Add(this.btnaddClient);
            this.groupBox2.Controls.Add(this.jdgvFey);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 179);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "مشخصات محکوم علیه ";
            // 
            // btndelClient
            // 
            this.btndelClient.Location = new System.Drawing.Point(384, 149);
            this.btndelClient.Name = "btndelClient";
            this.btndelClient.Size = new System.Drawing.Size(75, 23);
            this.btndelClient.TabIndex = 15;
            this.btndelClient.Text = "حذف";
            this.btndelClient.UseVisualStyleBackColor = true;
            this.btndelClient.Click += new System.EventHandler(this.btndelClient_Click);
            // 
            // btnaddClient
            // 
            this.btnaddClient.Location = new System.Drawing.Point(465, 149);
            this.btnaddClient.Name = "btnaddClient";
            this.btnaddClient.Size = new System.Drawing.Size(75, 23);
            this.btnaddClient.TabIndex = 16;
            this.btnaddClient.Text = "اضافه";
            this.btnaddClient.UseVisualStyleBackColor = true;
            this.btnaddClient.Click += new System.EventHandler(this.btnaddClient_Click);
            // 
            // jdgvFey
            // 
            this.jdgvFey.AllowUserToAddRows = false;
            this.jdgvFey.AllowUserToDeleteRows = false;
            this.jdgvFey.AllowUserToOrderColumns = true;
            this.jdgvFey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvFey.Dock = System.Windows.Forms.DockStyle.Top;
            this.jdgvFey.EnableContexMenu = true;
            this.jdgvFey.KeyName = null;
            this.jdgvFey.Location = new System.Drawing.Point(3, 19);
            this.jdgvFey.Name = "jdgvFey";
            this.jdgvFey.ReadHeadersFromDB = false;
            this.jdgvFey.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvFey.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvFey.ShowRowNumber = true;
            this.jdgvFey.Size = new System.Drawing.Size(548, 124);
            this.jdgvFey.TabIndex = 2;
            this.jdgvFey.TableName = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btndelWinner);
            this.groupBox1.Controls.Add(this.btnAddWinner);
            this.groupBox1.Controls.Add(this.jdgvWinner);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 182);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مشخصات محکوم له";
            // 
            // btndelWinner
            // 
            this.btndelWinner.Location = new System.Drawing.Point(384, 153);
            this.btndelWinner.Name = "btndelWinner";
            this.btndelWinner.Size = new System.Drawing.Size(75, 23);
            this.btndelWinner.TabIndex = 15;
            this.btndelWinner.Text = "حذف";
            this.btndelWinner.UseVisualStyleBackColor = true;
            this.btndelWinner.Click += new System.EventHandler(this.btndelWinner_Click);
            // 
            // btnAddWinner
            // 
            this.btnAddWinner.Location = new System.Drawing.Point(465, 153);
            this.btnAddWinner.Name = "btnAddWinner";
            this.btnAddWinner.Size = new System.Drawing.Size(75, 23);
            this.btnAddWinner.TabIndex = 16;
            this.btnAddWinner.Text = "اضافه";
            this.btnAddWinner.UseVisualStyleBackColor = true;
            this.btnAddWinner.Click += new System.EventHandler(this.btnAddWinner_Click);
            // 
            // jdgvWinner
            // 
            this.jdgvWinner.AllowUserToAddRows = false;
            this.jdgvWinner.AllowUserToDeleteRows = false;
            this.jdgvWinner.AllowUserToOrderColumns = true;
            this.jdgvWinner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvWinner.Dock = System.Windows.Forms.DockStyle.Top;
            this.jdgvWinner.EnableContexMenu = true;
            this.jdgvWinner.KeyName = null;
            this.jdgvWinner.Location = new System.Drawing.Point(3, 19);
            this.jdgvWinner.Name = "jdgvWinner";
            this.jdgvWinner.ReadHeadersFromDB = false;
            this.jdgvWinner.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvWinner.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvWinner.ShowRowNumber = true;
            this.jdgvWinner.Size = new System.Drawing.Size(548, 128);
            this.jdgvWinner.TabIndex = 2;
            this.jdgvWinner.TableName = null;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(560, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "محکوم به";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtDesc);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(3, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(554, 357);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "توضیحات محکوم به";
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(3, 19);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(548, 335);
            this.txtDesc.TabIndex = 0;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.jArchiveExe);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(560, 363);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "تصاویر";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // jArchiveExe
            // 
            this.jArchiveExe.AllowUserAddFile = true;
            this.jArchiveExe.AllowUserAddFromArchive = true;
            this.jArchiveExe.AllowUserAddImage = true;
            this.jArchiveExe.AllowUserDeleteFile = true;
            this.jArchiveExe.ClassName = "";
            this.jArchiveExe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveExe.Location = new System.Drawing.Point(3, 3);
            this.jArchiveExe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jArchiveExe.Name = "jArchiveExe";
            this.jArchiveExe.ObjectCode = 0;
            this.jArchiveExe.PlaceCode = 0;
            this.jArchiveExe.Size = new System.Drawing.Size(554, 357);
            this.jArchiveExe.SubjectCode = 0;
            this.jArchiveExe.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNumClase2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtNumClase);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtNumber);
            this.groupBox3.Controls.Add(this.btnSearchPetition);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtDate);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(574, 103);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // txtNumClase2
            // 
            this.txtNumClase2.ChangeColorIfNotEmpty = false;
            this.txtNumClase2.ChangeColorOnEnter = true;
            this.txtNumClase2.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumClase2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumClase2.Location = new System.Drawing.Point(47, 71);
            this.txtNumClase2.Name = "txtNumClase2";
            this.txtNumClase2.Negative = true;
            this.txtNumClase2.NotEmpty = false;
            this.txtNumClase2.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumClase2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumClase2.SelectOnEnter = true;
            this.txtNumClase2.Size = new System.Drawing.Size(374, 23);
            this.txtNumClase2.TabIndex = 31;
            this.txtNumClase2.TextMode = ClassLibrary.TextModes.Text;
            this.txtNumClase2.TextChanged += new System.EventHandler(this.txtNumClase2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "شماره کلاسه اجرا احکام:";
            // 
            // txtNumClase
            // 
            this.txtNumClase.ChangeColorIfNotEmpty = false;
            this.txtNumClase.ChangeColorOnEnter = true;
            this.txtNumClase.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumClase.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumClase.Location = new System.Drawing.Point(47, 42);
            this.txtNumClase.Name = "txtNumClase";
            this.txtNumClase.Negative = true;
            this.txtNumClase.NotEmpty = false;
            this.txtNumClase.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumClase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumClase.SelectOnEnter = true;
            this.txtNumClase.Size = new System.Drawing.Size(374, 23);
            this.txtNumClase.TabIndex = 29;
            this.txtNumClase.TextMode = ClassLibrary.TextModes.Text;
            this.txtNumClase.TextChanged += new System.EventHandler(this.txtNumClase_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "شماره کلاسه اجرائی:";
            // 
            // txtNumber
            // 
            this.txtNumber.ChangeColorIfNotEmpty = false;
            this.txtNumber.ChangeColorOnEnter = true;
            this.txtNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumber.Location = new System.Drawing.Point(285, 13);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Negative = true;
            this.txtNumber.NotEmpty = false;
            this.txtNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumber.ReadOnly = true;
            this.txtNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumber.SelectOnEnter = true;
            this.txtNumber.Size = new System.Drawing.Size(136, 23);
            this.txtNumber.TabIndex = 27;
            this.txtNumber.TextMode = ClassLibrary.TextModes.Text;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumClase_TextChanged);
            // 
            // btnSearchPetition
            // 
            this.btnSearchPetition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchPetition.Location = new System.Drawing.Point(242, 13);
            this.btnSearchPetition.Name = "btnSearchPetition";
            this.btnSearchPetition.Size = new System.Drawing.Size(37, 23);
            this.btnSearchPetition.TabIndex = 24;
            this.btnSearchPetition.Text = "...";
            this.btnSearchPetition.UseVisualStyleBackColor = true;
            this.btnSearchPetition.Click += new System.EventHandler(this.btnSearchPetition_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(424, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "کد رای دادگاه:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Controls.Add(this.btnExit);
            this.groupBox4.Controls.Add(this.btnSaveClose);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 517);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(574, 50);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(489, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(8, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(408, 16);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 20;
            this.btnSaveClose.Text = "ذخیره";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tabControl1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 103);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(574, 414);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox15);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(560, 363);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "اموال";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.btnDelAsset);
            this.groupBox15.Controls.Add(this.btnAddAsset);
            this.groupBox15.Controls.Add(this.jDGlistAsset);
            this.groupBox15.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox15.Location = new System.Drawing.Point(0, 0);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(560, 321);
            this.groupBox15.TabIndex = 25;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "اموال";
            // 
            // btnDelAsset
            // 
            this.btnDelAsset.Location = new System.Drawing.Point(211, 292);
            this.btnDelAsset.Name = "btnDelAsset";
            this.btnDelAsset.Size = new System.Drawing.Size(75, 23);
            this.btnDelAsset.TabIndex = 107;
            this.btnDelAsset.Text = "حذف";
            this.btnDelAsset.UseVisualStyleBackColor = true;
            this.btnDelAsset.Click += new System.EventHandler(this.btnDelAsset_Click);
            // 
            // btnAddAsset
            // 
            this.btnAddAsset.Location = new System.Drawing.Point(292, 292);
            this.btnAddAsset.Name = "btnAddAsset";
            this.btnAddAsset.Size = new System.Drawing.Size(75, 23);
            this.btnAddAsset.TabIndex = 106;
            this.btnAddAsset.Text = "اضافه ";
            this.btnAddAsset.UseVisualStyleBackColor = true;
            this.btnAddAsset.Click += new System.EventHandler(this.btnAddAsset_Click);
            // 
            // jDGlistAsset
            // 
            this.jDGlistAsset.AllowUserToAddRows = false;
            this.jDGlistAsset.AllowUserToDeleteRows = false;
            this.jDGlistAsset.AllowUserToOrderColumns = true;
            this.jDGlistAsset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDGlistAsset.Dock = System.Windows.Forms.DockStyle.Top;
            this.jDGlistAsset.EnableContexMenu = true;
            this.jDGlistAsset.KeyName = null;
            this.jDGlistAsset.Location = new System.Drawing.Point(3, 19);
            this.jDGlistAsset.Name = "jDGlistAsset";
            this.jDGlistAsset.ReadHeadersFromDB = false;
            this.jDGlistAsset.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDGlistAsset.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDGlistAsset.ShowRowNumber = true;
            this.jDGlistAsset.Size = new System.Drawing.Size(554, 267);
            this.jDGlistAsset.TabIndex = 1;
            this.jDGlistAsset.TableName = null;
            // 
            // JExecutiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 567);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Name = "JExecutiveForm";
            this.Text = "اجرائیه";
            this.Load += new System.EventHandler(this.JExecutiveForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvFey)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvWinner)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jDGlistAsset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.TextEdit txtNumber;
        private System.Windows.Forms.Button btnSearchPetition;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.TabPage tabPage3;
        private ClassLibrary.JDataGrid jdgvFey;
        private ClassLibrary.JDataGrid jdgvWinner;
        private System.Windows.Forms.GroupBox groupBox7;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtNumClase2;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.TextEdit txtNumClase;
        private System.Windows.Forms.Button btndelWinner;
        private System.Windows.Forms.Button btnAddWinner;
        private System.Windows.Forms.Button btndelClient;
        private System.Windows.Forms.Button btnaddClient;
        private ArchivedDocuments.JArchiveList jArchiveExe;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Button btnDelAsset;
        private System.Windows.Forms.Button btnAddAsset;
        private ClassLibrary.JDataGrid jDGlistAsset;
    }
}