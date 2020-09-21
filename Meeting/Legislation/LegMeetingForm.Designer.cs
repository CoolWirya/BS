namespace Meeting
{
    partial class JLegMeetingForm
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
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            ClassLibrary.JPopupMenu jPopupMenu3 = new ClassLibrary.JPopupMenu();
            ClassLibrary.JPopupMenu jPopupMenu4 = new ClassLibrary.JPopupMenu();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btndelClient = new System.Windows.Forms.Button();
            this.btnaddClient = new System.Windows.Forms.Button();
            this.jdgvLegislation = new ClassLibrary.JDataGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtTime = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocation = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddCommision = new System.Windows.Forms.Button();
            this.txtSubject = new ClassLibrary.TextEdit(this.components);
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnAddOtherPerson = new System.Windows.Forms.Button();
            this.jdgvPersons = new ClassLibrary.JDataGrid();
            this.btnDelPerson = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCommission = new ClassLibrary.JComboBox(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelProgram = new System.Windows.Forms.Button();
            this.btnAddProgram = new System.Windows.Forms.Button();
            this.jdgvProgram = new ClassLibrary.JDataGrid();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.JArchive = new ArchivedDocuments.JArchiveList();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.jDataGrid1 = new ClassLibrary.JDataGrid();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvLegislation)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvPersons)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvProgram)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.JArchive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnSaveClose);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 467);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 48);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(329, 17);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 51;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(493, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 50;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(28, 17);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 49;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(413, 18);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 48;
            this.btnSaveClose.Text = "ذخیره ";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btndelClient);
            this.groupBox3.Controls.Add(this.btnaddClient);
            this.groupBox3.Controls.Add(this.jdgvLegislation);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(566, 429);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "مصوبات";
            // 
            // btndelClient
            // 
            this.btndelClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelClient.Location = new System.Drawing.Point(209, 395);
            this.btndelClient.Name = "btndelClient";
            this.btndelClient.Size = new System.Drawing.Size(75, 28);
            this.btndelClient.TabIndex = 18;
            this.btndelClient.Text = "حذف";
            this.btndelClient.UseVisualStyleBackColor = true;
            this.btndelClient.Click += new System.EventHandler(this.btndelClient_Click);
            // 
            // btnaddClient
            // 
            this.btnaddClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnaddClient.Location = new System.Drawing.Point(289, 395);
            this.btnaddClient.Name = "btnaddClient";
            this.btnaddClient.Size = new System.Drawing.Size(75, 28);
            this.btnaddClient.TabIndex = 19;
            this.btnaddClient.Text = "اضافه";
            this.btnaddClient.UseVisualStyleBackColor = true;
            this.btnaddClient.Click += new System.EventHandler(this.btnaddClient_Click);
            // 
            // jdgvLegislation
            // 
            this.jdgvLegislation.ActionMenu = jPopupMenu1;
            this.jdgvLegislation.AllowUserToAddRows = false;
            this.jdgvLegislation.AllowUserToDeleteRows = false;
            this.jdgvLegislation.AllowUserToOrderColumns = true;
            this.jdgvLegislation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvLegislation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvLegislation.Dock = System.Windows.Forms.DockStyle.Top;
            this.jdgvLegislation.EnableContexMenu = true;
            this.jdgvLegislation.KeyName = null;
            this.jdgvLegislation.Location = new System.Drawing.Point(3, 19);
            this.jdgvLegislation.Name = "jdgvLegislation";
            this.jdgvLegislation.ReadHeadersFromDB = false;
            this.jdgvLegislation.ReadOnly = true;
            this.jdgvLegislation.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvLegislation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvLegislation.ShowRowNumber = true;
            this.jdgvLegislation.Size = new System.Drawing.Size(560, 370);
            this.jdgvLegislation.TabIndex = 17;
            this.jdgvLegislation.TableName = null;
            this.jdgvLegislation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jdgvVicarious_CellDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(580, 467);
            this.tabControl1.TabIndex = 61;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtTime);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.txtLocation);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.btnAddCommision);
            this.tabPage3.Controls.Add(this.txtSubject);
            this.tabPage3.Controls.Add(this.txtDate);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.cmbCommission);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(572, 438);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "افراد جلسه";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(13, 7);
            this.txtTime.Mask = "00:00";
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(38, 23);
            this.txtTime.TabIndex = 5;
            this.txtTime.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 63;
            this.label5.Text = "ساعت:";
            // 
            // txtLocation
            // 
            this.txtLocation.ChangeColorIfNotEmpty = false;
            this.txtLocation.ChangeColorOnEnter = true;
            this.txtLocation.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLocation.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLocation.Location = new System.Drawing.Point(14, 69);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Negative = true;
            this.txtLocation.NotEmpty = false;
            this.txtLocation.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLocation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLocation.SelectOnEnter = true;
            this.txtLocation.Size = new System.Drawing.Size(454, 23);
            this.txtLocation.TabIndex = 7;
            this.txtLocation.TextMode = ClassLibrary.TextModes.Text;
            this.txtLocation.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(474, 73);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 61;
            this.label4.Text = "مکان جلسه:";
            // 
            // btnAddCommision
            // 
            this.btnAddCommision.Location = new System.Drawing.Point(283, 6);
            this.btnAddCommision.Name = "btnAddCommision";
            this.btnAddCommision.Size = new System.Drawing.Size(35, 26);
            this.btnAddCommision.TabIndex = 2;
            this.btnAddCommision.Text = "+";
            this.btnAddCommision.UseVisualStyleBackColor = true;
            this.btnAddCommision.Click += new System.EventHandler(this.btnAddCommision_Click);
            // 
            // txtSubject
            // 
            this.txtSubject.ChangeColorIfNotEmpty = false;
            this.txtSubject.ChangeColorOnEnter = true;
            this.txtSubject.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSubject.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubject.Location = new System.Drawing.Point(14, 40);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Negative = true;
            this.txtSubject.NotEmpty = false;
            this.txtSubject.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSubject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubject.SelectOnEnter = true;
            this.txtSubject.Size = new System.Drawing.Size(454, 23);
            this.txtSubject.TabIndex = 6;
            this.txtSubject.TextMode = ClassLibrary.TextModes.Text;
            this.txtSubject.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
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
            this.txtDate.Location = new System.Drawing.Point(111, 8);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(83, 23);
            this.txtDate.TabIndex = 3;
            this.txtDate.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "تاریخ جلسه:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(474, 44);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 56;
            this.label1.Text = "موضوع جلسه:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnAddOtherPerson);
            this.groupBox6.Controls.Add(this.jdgvPersons);
            this.groupBox6.Controls.Add(this.btnDelPerson);
            this.groupBox6.Controls.Add(this.btnAddPerson);
            this.groupBox6.Location = new System.Drawing.Point(8, 101);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(559, 334);
            this.groupBox6.TabIndex = 54;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "لیست افراد جلسه";
            // 
            // btnAddOtherPerson
            // 
            this.btnAddOtherPerson.Location = new System.Drawing.Point(338, 301);
            this.btnAddOtherPerson.Name = "btnAddOtherPerson";
            this.btnAddOtherPerson.Size = new System.Drawing.Size(75, 27);
            this.btnAddOtherPerson.TabIndex = 10;
            this.btnAddOtherPerson.Text = "میهمان";
            this.btnAddOtherPerson.UseVisualStyleBackColor = true;
            this.btnAddOtherPerson.Click += new System.EventHandler(this.btnAddOtherPerson_Click);
            // 
            // jdgvPersons
            // 
            this.jdgvPersons.ActionMenu = jPopupMenu2;
            this.jdgvPersons.AllowUserToAddRows = false;
            this.jdgvPersons.AllowUserToDeleteRows = false;
            this.jdgvPersons.AllowUserToOrderColumns = true;
            this.jdgvPersons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jdgvPersons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvPersons.EnableContexMenu = true;
            this.jdgvPersons.KeyName = null;
            this.jdgvPersons.Location = new System.Drawing.Point(6, 16);
            this.jdgvPersons.Name = "jdgvPersons";
            this.jdgvPersons.ReadHeadersFromDB = false;
            this.jdgvPersons.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvPersons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvPersons.ShowRowNumber = true;
            this.jdgvPersons.Size = new System.Drawing.Size(547, 281);
            this.jdgvPersons.TabIndex = 16;
            this.jdgvPersons.TableName = null;
            this.jdgvPersons.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jdgvPersons_CellDoubleClick);
            this.jdgvPersons.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jdgvPersons_CellClick);
            // 
            // btnDelPerson
            // 
            this.btnDelPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelPerson.Location = new System.Drawing.Point(177, 301);
            this.btnDelPerson.Name = "btnDelPerson";
            this.btnDelPerson.Size = new System.Drawing.Size(75, 27);
            this.btnDelPerson.TabIndex = 9;
            this.btnDelPerson.Text = "حذف";
            this.btnDelPerson.UseVisualStyleBackColor = true;
            this.btnDelPerson.Click += new System.EventHandler(this.btnDelPerson_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPerson.Location = new System.Drawing.Point(257, 301);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(75, 27);
            this.btnAddPerson.TabIndex = 8;
            this.btnAddPerson.Text = "اضافه";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 11);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 53;
            this.label3.Text = "کمیسیون:";
            // 
            // cmbCommission
            // 
            this.cmbCommission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCommission.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCommission.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCommission.BackColor = System.Drawing.SystemColors.Info;
            this.cmbCommission.BaseCode = 0;
            this.cmbCommission.ChangeColorIfNotEmpty = true;
            this.cmbCommission.ChangeColorOnEnter = true;
            this.cmbCommission.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCommission.FormattingEnabled = true;
            this.cmbCommission.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCommission.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCommission.Location = new System.Drawing.Point(325, 8);
            this.cmbCommission.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCommission.Name = "cmbCommission";
            this.cmbCommission.NotEmpty = false;
            this.cmbCommission.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCommission.SelectOnEnter = true;
            this.cmbCommission.Size = new System.Drawing.Size(142, 24);
            this.cmbCommission.TabIndex = 1;
            this.cmbCommission.SelectedIndexChanged += new System.EventHandler(this.cmbCommission_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(572, 438);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "دستورکار";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelProgram);
            this.groupBox1.Controls.Add(this.btnAddProgram);
            this.groupBox1.Controls.Add(this.jdgvProgram);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 438);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "دستور کار";
            // 
            // btnDelProgram
            // 
            this.btnDelProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelProgram.Location = new System.Drawing.Point(213, 400);
            this.btnDelProgram.Name = "btnDelProgram";
            this.btnDelProgram.Size = new System.Drawing.Size(75, 28);
            this.btnDelProgram.TabIndex = 20;
            this.btnDelProgram.Text = "حذف";
            this.btnDelProgram.UseVisualStyleBackColor = true;
            this.btnDelProgram.Click += new System.EventHandler(this.btnDelProgram_Click);
            // 
            // btnAddProgram
            // 
            this.btnAddProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProgram.Location = new System.Drawing.Point(293, 400);
            this.btnAddProgram.Name = "btnAddProgram";
            this.btnAddProgram.Size = new System.Drawing.Size(75, 28);
            this.btnAddProgram.TabIndex = 21;
            this.btnAddProgram.Text = "اضافه";
            this.btnAddProgram.UseVisualStyleBackColor = true;
            this.btnAddProgram.Click += new System.EventHandler(this.btnAddProgram_Click);
            // 
            // jdgvProgram
            // 
            this.jdgvProgram.ActionMenu = jPopupMenu3;
            this.jdgvProgram.AllowUserToAddRows = false;
            this.jdgvProgram.AllowUserToDeleteRows = false;
            this.jdgvProgram.AllowUserToOrderColumns = true;
            this.jdgvProgram.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvProgram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvProgram.Dock = System.Windows.Forms.DockStyle.Top;
            this.jdgvProgram.EnableContexMenu = true;
            this.jdgvProgram.KeyName = null;
            this.jdgvProgram.Location = new System.Drawing.Point(3, 19);
            this.jdgvProgram.Name = "jdgvProgram";
            this.jdgvProgram.ReadHeadersFromDB = false;
            this.jdgvProgram.ReadOnly = true;
            this.jdgvProgram.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvProgram.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvProgram.ShowRowNumber = true;
            this.jdgvProgram.Size = new System.Drawing.Size(566, 375);
            this.jdgvProgram.TabIndex = 18;
            this.jdgvProgram.TableName = null;
            this.jdgvProgram.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jdgvProgram_CellDoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(572, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "مصوبات جلسه";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.JArchive);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(572, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تصاویر";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.JArchive.Location = new System.Drawing.Point(3, 3);
            this.JArchive.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.JArchive.Name = "JArchive";
            this.JArchive.ObjectCode = 0;
            this.JArchive.ObjectCodes = null;
            this.JArchive.PlaceCode = 0;
            this.JArchive.Size = new System.Drawing.Size(566, 432);
            this.JArchive.SubjectCode = 0;
            this.JArchive.TabIndex = 2;
            this.JArchive.AfterFileAdded += new ArchivedDocuments.JArchiveList.FileAdded(this.txtSubject_TextChanged);
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
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 137, 3, 137);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(566, 23);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(209, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 18;
            this.button1.Text = "حذف";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(289, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 28);
            this.button2.TabIndex = 19;
            this.button2.Text = "اضافه";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // jDataGrid1
            // 
            this.jDataGrid1.ActionMenu = jPopupMenu4;
            this.jDataGrid1.AllowUserToAddRows = false;
            this.jDataGrid1.AllowUserToDeleteRows = false;
            this.jDataGrid1.AllowUserToOrderColumns = true;
            this.jDataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.jDataGrid1.EnableContexMenu = true;
            this.jDataGrid1.KeyName = null;
            this.jDataGrid1.Location = new System.Drawing.Point(3, 19);
            this.jDataGrid1.Name = "jDataGrid1";
            this.jDataGrid1.ReadHeadersFromDB = false;
            this.jDataGrid1.ReadOnly = true;
            this.jDataGrid1.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGrid1.ShowRowNumber = true;
            this.jDataGrid1.Size = new System.Drawing.Size(560, 370);
            this.jDataGrid1.TabIndex = 17;
            this.jDataGrid1.TableName = null;
            // 
            // JLegMeetingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 515);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Name = "JLegMeetingForm";
            this.Text = "LegMeetingForm";
            this.Load += new System.EventHandler(this.JLegMeetingForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvLegislation)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvPersons)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvProgram)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.JArchive.ResumeLayout(false);
            this.JArchive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ClassLibrary.JDataGrid jdgvLegislation;
        private ArchivedDocuments.JArchiveList JArchive;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Button btndelClient;
        private System.Windows.Forms.Button btnaddClient;
        private System.Windows.Forms.TabPage tabPage3;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private ClassLibrary.JDataGrid jdgvPersons;
        private System.Windows.Forms.Button btnDelPerson;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.JComboBox cmbCommission;
        private ClassLibrary.TextEdit txtSubject;
        private System.Windows.Forms.Button btnAddCommision;
        private System.Windows.Forms.Button btnAddOtherPerson;
        private System.Windows.Forms.TabPage tabPage4;
        private ClassLibrary.TextEdit txtLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private ClassLibrary.JDataGrid jDataGrid1;
        private System.Windows.Forms.Button btnDelProgram;
        private System.Windows.Forms.Button btnAddProgram;
        private ClassLibrary.JDataGrid jdgvProgram;
        private System.Windows.Forms.Button btnPrint;
    }
}