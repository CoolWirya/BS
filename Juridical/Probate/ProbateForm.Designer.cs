namespace Legal
{
    partial class JProbateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDateIssued = new ClassLibrary.DateEdit(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.jArchiveList = new ArchivedDocuments.JArchiveList();
            this.Parties = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdHeirs = new ClassLibrary.JDataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCalculateShare = new System.Windows.Forms.Button();
            this.DelHeirs = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.AddHeirs = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDeadCode = new ClassLibrary.TextEdit(this.components);
            this.labDeadNationalCode = new System.Windows.Forms.Label();
            this.labDeaFatherName = new System.Windows.Forms.Label();
            this.labDeadDateofbirth = new System.Windows.Forms.Label();
            this.labDeadshsh = new System.Windows.Forms.Label();
            this.labDeadFamily = new System.Windows.Forms.Label();
            this.labDeadName = new System.Windows.Forms.Label();
            this.Dateofbirth = new System.Windows.Forms.Label();
            this.NationalCode = new System.Windows.Forms.Label();
            this.FatherName = new System.Windows.Forms.Label();
            this.Code = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.Family = new System.Windows.Forms.Label();
            this.shsh = new System.Windows.Forms.Label();
            this.AddDiePerson = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labDeadDate = new System.Windows.Forms.Label();
            this.labDeadNo = new System.Windows.Forms.Label();
            this.labDeathCertificateDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtApplicatorCode = new ClassLibrary.TextEdit(this.components);
            this.labApplicatorNationalCode = new System.Windows.Forms.Label();
            this.labApplicatorFatherName = new System.Windows.Forms.Label();
            this.labApplicatorFan = new System.Windows.Forms.Label();
            this.labApplicatorName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.addApplicator = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labAddressJudicialComplex = new System.Windows.Forms.Label();
            this.labJudicialComplex = new System.Windows.Forms.Label();
            this.cmbJudicialBranch = new ClassLibrary.JComboBox(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.SaveClose = new System.Windows.Forms.Button();
            this.tabPage2.SuspendLayout();
            this.Parties.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHeirs)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "کد:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(51, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(115, 23);
            this.txtCode.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "تاریخ صدور:";
            // 
            // txtDateIssued
            // 
            this.txtDateIssued.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateIssued.BackColor = System.Drawing.SystemColors.Info;
            this.txtDateIssued.ChangeColorIfNotEmpty = true;
            this.txtDateIssued.ChangeColorOnEnter = true;
            this.txtDateIssued.Date = new System.DateTime(((long)(0)));
            this.txtDateIssued.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateIssued.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateIssued.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateIssued.InsertInDatesTable = true;
            this.txtDateIssued.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateIssued.Location = new System.Drawing.Point(38, 27);
            this.txtDateIssued.Mask = "0000/00/00";
            this.txtDateIssued.Name = "txtDateIssued";
            this.txtDateIssued.NotEmpty = false;
            this.txtDateIssued.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateIssued.Size = new System.Drawing.Size(118, 23);
            this.txtDateIssued.TabIndex = 1;
            this.txtDateIssued.TextChanged += new System.EventHandler(this.txtDeadCode_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.jArchiveList);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(542, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "فایل های مرتبط";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // jArchiveList
            // 
            this.jArchiveList.AllowUserAddFile = true;
            this.jArchiveList.AllowUserAddFromArchive = true;
            this.jArchiveList.AllowUserAddImage = true;
            this.jArchiveList.AllowUserDeleteFile = true;
            this.jArchiveList.ClassName = "";
            this.jArchiveList.ClassNames = null;
            this.jArchiveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveList.EnabledChange = true;
            this.jArchiveList.Location = new System.Drawing.Point(3, 3);
            this.jArchiveList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jArchiveList.Name = "jArchiveList";
            this.jArchiveList.ObjectCode = 0;
            this.jArchiveList.ObjectCodes = null;
            this.jArchiveList.PlaceCode = 0;
            this.jArchiveList.Size = new System.Drawing.Size(536, 498);
            this.jArchiveList.SubjectCode = 0;
            this.jArchiveList.TabIndex = 0;
            this.jArchiveList.AfterFileAdded += new ArchivedDocuments.JArchiveList.FileAdded(this.jArchiveList1_AfterFileAdded);
            // 
            // Parties
            // 
            this.Parties.Controls.Add(this.groupBox2);
            this.Parties.Location = new System.Drawing.Point(4, 25);
            this.Parties.Name = "Parties";
            this.Parties.Padding = new System.Windows.Forms.Padding(3);
            this.Parties.Size = new System.Drawing.Size(542, 504);
            this.Parties.TabIndex = 0;
            this.Parties.Text = "  وراث";
            this.Parties.UseVisualStyleBackColor = true;
            this.Parties.Enter += new System.EventHandler(this.Parties_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdHeirs);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 498);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "وراث:";
            // 
            // grdHeirs
            // 
            this.grdHeirs.ActionMenu = jPopupMenu1;
            this.grdHeirs.AllowUserToAddRows = false;
            this.grdHeirs.AllowUserToDeleteRows = false;
            this.grdHeirs.AllowUserToOrderColumns = true;
            this.grdHeirs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdHeirs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdHeirs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHeirs.EnableContexMenu = true;
            this.grdHeirs.KeyName = null;
            this.grdHeirs.Location = new System.Drawing.Point(3, 19);
            this.grdHeirs.Name = "grdHeirs";
            this.grdHeirs.ReadHeadersFromDB = false;
            this.grdHeirs.ReadOnly = true;
            this.grdHeirs.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdHeirs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdHeirs.ShowRowNumber = true;
            this.grdHeirs.Size = new System.Drawing.Size(530, 437);
            this.grdHeirs.TabIndex = 8;
            this.grdHeirs.TableName = null;
            this.grdHeirs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdHeirs_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCalculateShare);
            this.panel1.Controls.Add(this.DelHeirs);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.AddHeirs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 456);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 39);
            this.panel1.TabIndex = 7;
            // 
            // btnCalculateShare
            // 
            this.btnCalculateShare.Location = new System.Drawing.Point(33, 5);
            this.btnCalculateShare.Name = "btnCalculateShare";
            this.btnCalculateShare.Size = new System.Drawing.Size(96, 29);
            this.btnCalculateShare.TabIndex = 10;
            this.btnCalculateShare.Text = "calculateshare";
            this.btnCalculateShare.UseVisualStyleBackColor = true;
            this.btnCalculateShare.Click += new System.EventHandler(this.btnCalculateShare_Click);
            // 
            // DelHeirs
            // 
            this.DelHeirs.Location = new System.Drawing.Point(163, 5);
            this.DelHeirs.Name = "DelHeirs";
            this.DelHeirs.Size = new System.Drawing.Size(91, 29);
            this.DelHeirs.TabIndex = 4;
            this.DelHeirs.Text = "DelHeir";
            this.DelHeirs.UseVisualStyleBackColor = true;
            this.DelHeirs.Click += new System.EventHandler(this.DelHeirs_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(275, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(91, 29);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // AddHeirs
            // 
            this.AddHeirs.Location = new System.Drawing.Point(401, 5);
            this.AddHeirs.Name = "AddHeirs";
            this.AddHeirs.Size = new System.Drawing.Size(97, 29);
            this.AddHeirs.TabIndex = 0;
            this.AddHeirs.Text = "AddHeir";
            this.AddHeirs.UseVisualStyleBackColor = true;
            this.AddHeirs.Click += new System.EventHandler(this.AddHeirs_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtDeadCode);
            this.groupBox1.Controls.Add(this.labDeadNationalCode);
            this.groupBox1.Controls.Add(this.labDeaFatherName);
            this.groupBox1.Controls.Add(this.labDeadDateofbirth);
            this.groupBox1.Controls.Add(this.labDeadshsh);
            this.groupBox1.Controls.Add(this.labDeadFamily);
            this.groupBox1.Controls.Add(this.labDeadName);
            this.groupBox1.Controls.Add(this.Dateofbirth);
            this.groupBox1.Controls.Add(this.NationalCode);
            this.groupBox1.Controls.Add(this.FatherName);
            this.groupBox1.Controls.Add(this.Code);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.Family);
            this.groupBox1.Controls.Add(this.shsh);
            this.groupBox1.Controls.Add(this.AddDiePerson);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "متوفی:";
            // 
            // txtDeadCode
            // 
            this.txtDeadCode.ChangeColorIfNotEmpty = false;
            this.txtDeadCode.ChangeColorOnEnter = true;
            this.txtDeadCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDeadCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeadCode.Location = new System.Drawing.Point(333, 18);
            this.txtDeadCode.Name = "txtDeadCode";
            this.txtDeadCode.Negative = true;
            this.txtDeadCode.NotEmpty = false;
            this.txtDeadCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDeadCode.ReadOnly = true;
            this.txtDeadCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDeadCode.SelectOnEnter = true;
            this.txtDeadCode.Size = new System.Drawing.Size(139, 23);
            this.txtDeadCode.TabIndex = 22;
            this.txtDeadCode.TextMode = ClassLibrary.TextModes.Integer;
            this.txtDeadCode.TextChanged += new System.EventHandler(this.txtDeadCode_TextChanged);
            this.txtDeadCode.Leave += new System.EventHandler(this.txtDeadCode_Leave);
            // 
            // labDeadNationalCode
            // 
            this.labDeadNationalCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labDeadNationalCode.AutoSize = true;
            this.labDeadNationalCode.Location = new System.Drawing.Point(78, 87);
            this.labDeadNationalCode.Name = "labDeadNationalCode";
            this.labDeadNationalCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labDeadNationalCode.Size = new System.Drawing.Size(24, 16);
            this.labDeadNationalCode.TabIndex = 21;
            this.labDeadNationalCode.Text = "....";
            // 
            // labDeaFatherName
            // 
            this.labDeaFatherName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labDeaFatherName.AutoSize = true;
            this.labDeaFatherName.Location = new System.Drawing.Point(78, 59);
            this.labDeaFatherName.Name = "labDeaFatherName";
            this.labDeaFatherName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labDeaFatherName.Size = new System.Drawing.Size(24, 16);
            this.labDeaFatherName.TabIndex = 20;
            this.labDeaFatherName.Text = "....";
            // 
            // labDeadDateofbirth
            // 
            this.labDeadDateofbirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labDeadDateofbirth.AutoSize = true;
            this.labDeadDateofbirth.Location = new System.Drawing.Point(78, 115);
            this.labDeadDateofbirth.Name = "labDeadDateofbirth";
            this.labDeadDateofbirth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labDeadDateofbirth.Size = new System.Drawing.Size(24, 16);
            this.labDeadDateofbirth.TabIndex = 19;
            this.labDeadDateofbirth.Text = "....";
            // 
            // labDeadshsh
            // 
            this.labDeadshsh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labDeadshsh.AutoSize = true;
            this.labDeadshsh.Location = new System.Drawing.Point(347, 115);
            this.labDeadshsh.Name = "labDeadshsh";
            this.labDeadshsh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labDeadshsh.Size = new System.Drawing.Size(20, 16);
            this.labDeadshsh.TabIndex = 18;
            this.labDeadshsh.Text = "...";
            // 
            // labDeadFamily
            // 
            this.labDeadFamily.AutoSize = true;
            this.labDeadFamily.Location = new System.Drawing.Point(347, 87);
            this.labDeadFamily.Name = "labDeadFamily";
            this.labDeadFamily.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labDeadFamily.Size = new System.Drawing.Size(20, 16);
            this.labDeadFamily.TabIndex = 17;
            this.labDeadFamily.Text = "...";
            // 
            // labDeadName
            // 
            this.labDeadName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labDeadName.AutoSize = true;
            this.labDeadName.Location = new System.Drawing.Point(347, 57);
            this.labDeadName.Name = "labDeadName";
            this.labDeadName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labDeadName.Size = new System.Drawing.Size(20, 16);
            this.labDeadName.TabIndex = 16;
            this.labDeadName.Text = "...";
            // 
            // Dateofbirth
            // 
            this.Dateofbirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Dateofbirth.AutoSize = true;
            this.Dateofbirth.Location = new System.Drawing.Point(237, 115);
            this.Dateofbirth.Name = "Dateofbirth";
            this.Dateofbirth.Size = new System.Drawing.Size(59, 16);
            this.Dateofbirth.TabIndex = 14;
            this.Dateofbirth.Text = "birthdate";
            // 
            // NationalCode
            // 
            this.NationalCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NationalCode.AutoSize = true;
            this.NationalCode.Location = new System.Drawing.Point(208, 87);
            this.NationalCode.Name = "NationalCode";
            this.NationalCode.Size = new System.Drawing.Size(88, 16);
            this.NationalCode.TabIndex = 13;
            this.NationalCode.Text = "NationalCode:";
            // 
            // FatherName
            // 
            this.FatherName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FatherName.AutoSize = true;
            this.FatherName.Location = new System.Drawing.Point(213, 59);
            this.FatherName.Name = "FatherName";
            this.FatherName.Size = new System.Drawing.Size(83, 16);
            this.FatherName.TabIndex = 12;
            this.FatherName.Text = "FatherName:";
            // 
            // Code
            // 
            this.Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Code.AutoSize = true;
            this.Code.Location = new System.Drawing.Point(478, 19);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(42, 16);
            this.Code.TabIndex = 11;
            this.Code.Text = "Code:";
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(478, 57);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(45, 16);
            this.name.TabIndex = 8;
            this.name.Text = "name:";
            // 
            // Family
            // 
            this.Family.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Family.AutoSize = true;
            this.Family.Location = new System.Drawing.Point(452, 87);
            this.Family.Name = "Family";
            this.Family.Size = new System.Drawing.Size(69, 16);
            this.Family.TabIndex = 9;
            this.Family.Text = "LastName:";
            // 
            // shsh
            // 
            this.shsh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shsh.AutoSize = true;
            this.shsh.Location = new System.Drawing.Point(485, 115);
            this.shsh.Name = "shsh";
            this.shsh.Size = new System.Drawing.Size(39, 16);
            this.shsh.TabIndex = 10;
            this.shsh.Text = "shsh:";
            // 
            // AddDiePerson
            // 
            this.AddDiePerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddDiePerson.Location = new System.Drawing.Point(275, 19);
            this.AddDiePerson.Name = "AddDiePerson";
            this.AddDiePerson.Size = new System.Drawing.Size(52, 23);
            this.AddDiePerson.TabIndex = 1;
            this.AddDiePerson.Text = "Add";
            this.AddDiePerson.UseVisualStyleBackColor = true;
            this.AddDiePerson.Click += new System.EventHandler(this.AddDiePerson_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.Parties);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(550, 533);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(542, 504);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "مشخصات";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.labDeadDate);
            this.groupBox5.Controls.Add(this.labDeadNo);
            this.groupBox5.Controls.Add(this.labDeathCertificateDate);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(7, 405);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(529, 93);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "گواهی فوت";
            // 
            // labDeadDate
            // 
            this.labDeadDate.AutoSize = true;
            this.labDeadDate.Location = new System.Drawing.Point(294, 64);
            this.labDeadDate.Name = "labDeadDate";
            this.labDeadDate.Size = new System.Drawing.Size(20, 16);
            this.labDeadDate.TabIndex = 93;
            this.labDeadDate.Text = "...";
            // 
            // labDeadNo
            // 
            this.labDeadNo.AutoSize = true;
            this.labDeadNo.Location = new System.Drawing.Point(294, 43);
            this.labDeadNo.Name = "labDeadNo";
            this.labDeadNo.Size = new System.Drawing.Size(20, 16);
            this.labDeadNo.TabIndex = 92;
            this.labDeadNo.Text = "...";
            // 
            // labDeathCertificateDate
            // 
            this.labDeathCertificateDate.AutoSize = true;
            this.labDeathCertificateDate.Location = new System.Drawing.Point(294, 22);
            this.labDeathCertificateDate.Name = "labDeathCertificateDate";
            this.labDeathCertificateDate.Size = new System.Drawing.Size(20, 16);
            this.labDeathCertificateDate.TabIndex = 91;
            this.labDeathCertificateDate.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(413, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "تاریخ گواهی فوت:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(454, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 82;
            this.label4.Text = "تاریخ فوت:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(403, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 16);
            this.label5.TabIndex = 87;
            this.label5.Text = "شماره گواهی فوت:";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtApplicatorCode);
            this.groupBox4.Controls.Add(this.labApplicatorNationalCode);
            this.groupBox4.Controls.Add(this.labApplicatorFatherName);
            this.groupBox4.Controls.Add(this.labApplicatorFan);
            this.groupBox4.Controls.Add(this.labApplicatorName);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.addApplicator);
            this.groupBox4.Location = new System.Drawing.Point(6, 286);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(530, 113);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "درخواست کننده:";
            // 
            // txtApplicatorCode
            // 
            this.txtApplicatorCode.ChangeColorIfNotEmpty = false;
            this.txtApplicatorCode.ChangeColorOnEnter = true;
            this.txtApplicatorCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtApplicatorCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtApplicatorCode.Location = new System.Drawing.Point(330, 22);
            this.txtApplicatorCode.Name = "txtApplicatorCode";
            this.txtApplicatorCode.Negative = true;
            this.txtApplicatorCode.NotEmpty = false;
            this.txtApplicatorCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtApplicatorCode.ReadOnly = true;
            this.txtApplicatorCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtApplicatorCode.SelectOnEnter = true;
            this.txtApplicatorCode.Size = new System.Drawing.Size(139, 23);
            this.txtApplicatorCode.TabIndex = 22;
            this.txtApplicatorCode.TextMode = ClassLibrary.TextModes.Integer;
            this.txtApplicatorCode.TextChanged += new System.EventHandler(this.txtApplicatorCode_TextChanged);
            // 
            // labApplicatorNationalCode
            // 
            this.labApplicatorNationalCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labApplicatorNationalCode.AutoSize = true;
            this.labApplicatorNationalCode.Location = new System.Drawing.Point(56, 80);
            this.labApplicatorNationalCode.Name = "labApplicatorNationalCode";
            this.labApplicatorNationalCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labApplicatorNationalCode.Size = new System.Drawing.Size(24, 16);
            this.labApplicatorNationalCode.TabIndex = 21;
            this.labApplicatorNationalCode.Text = "....";
            // 
            // labApplicatorFatherName
            // 
            this.labApplicatorFatherName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labApplicatorFatherName.AutoSize = true;
            this.labApplicatorFatherName.Location = new System.Drawing.Point(56, 52);
            this.labApplicatorFatherName.Name = "labApplicatorFatherName";
            this.labApplicatorFatherName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labApplicatorFatherName.Size = new System.Drawing.Size(24, 16);
            this.labApplicatorFatherName.TabIndex = 20;
            this.labApplicatorFatherName.Text = "....";
            // 
            // labApplicatorFan
            // 
            this.labApplicatorFan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labApplicatorFan.AutoSize = true;
            this.labApplicatorFan.Location = new System.Drawing.Point(348, 80);
            this.labApplicatorFan.Name = "labApplicatorFan";
            this.labApplicatorFan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labApplicatorFan.Size = new System.Drawing.Size(20, 16);
            this.labApplicatorFan.TabIndex = 17;
            this.labApplicatorFan.Text = "...";
            // 
            // labApplicatorName
            // 
            this.labApplicatorName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labApplicatorName.AutoSize = true;
            this.labApplicatorName.Location = new System.Drawing.Point(348, 52);
            this.labApplicatorName.Name = "labApplicatorName";
            this.labApplicatorName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labApplicatorName.Size = new System.Drawing.Size(20, 16);
            this.labApplicatorName.TabIndex = 16;
            this.labApplicatorName.Text = "...";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(179, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "NationalCode:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(184, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 16);
            this.label12.TabIndex = 12;
            this.label12.Text = "FatherName:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(481, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 16);
            this.label13.TabIndex = 11;
            this.label13.Text = "Code:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(480, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 16);
            this.label14.TabIndex = 8;
            this.label14.Text = "name:";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(456, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 16);
            this.label15.TabIndex = 9;
            this.label15.Text = "lastName:";
            // 
            // addApplicator
            // 
            this.addApplicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addApplicator.Location = new System.Drawing.Point(272, 22);
            this.addApplicator.Name = "addApplicator";
            this.addApplicator.Size = new System.Drawing.Size(52, 23);
            this.addApplicator.TabIndex = 1;
            this.addApplicator.Text = "Add";
            this.addApplicator.UseVisualStyleBackColor = true;
            this.addApplicator.Click += new System.EventHandler(this.addApplicator_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.labAddressJudicialComplex);
            this.groupBox3.Controls.Add(this.txtDateIssued);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.labJudicialComplex);
            this.groupBox3.Controls.Add(this.cmbJudicialBranch);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(7, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(533, 120);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "شعبه قضایی";
            // 
            // labAddressJudicialComplex
            // 
            this.labAddressJudicialComplex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labAddressJudicialComplex.AutoSize = true;
            this.labAddressJudicialComplex.Location = new System.Drawing.Point(303, 83);
            this.labAddressJudicialComplex.Name = "labAddressJudicialComplex";
            this.labAddressJudicialComplex.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labAddressJudicialComplex.Size = new System.Drawing.Size(24, 16);
            this.labAddressJudicialComplex.TabIndex = 10;
            this.labAddressJudicialComplex.Text = "....";
            // 
            // labJudicialComplex
            // 
            this.labJudicialComplex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labJudicialComplex.AutoSize = true;
            this.labJudicialComplex.Location = new System.Drawing.Point(307, 54);
            this.labJudicialComplex.Name = "labJudicialComplex";
            this.labJudicialComplex.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labJudicialComplex.Size = new System.Drawing.Size(20, 16);
            this.labJudicialComplex.TabIndex = 9;
            this.labJudicialComplex.Text = "...";
            // 
            // cmbJudicialBranch
            // 
            this.cmbJudicialBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbJudicialBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbJudicialBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbJudicialBranch.BaseCode = 0;
            this.cmbJudicialBranch.ChangeColorIfNotEmpty = true;
            this.cmbJudicialBranch.ChangeColorOnEnter = true;
            this.cmbJudicialBranch.FormattingEnabled = true;
            this.cmbJudicialBranch.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbJudicialBranch.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbJudicialBranch.Location = new System.Drawing.Point(294, 27);
            this.cmbJudicialBranch.Name = "cmbJudicialBranch";
            this.cmbJudicialBranch.NotEmpty = false;
            this.cmbJudicialBranch.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbJudicialBranch.SelectOnEnter = true;
            this.cmbJudicialBranch.Size = new System.Drawing.Size(163, 24);
            this.cmbJudicialBranch.TabIndex = 0;
            this.cmbJudicialBranch.SelectedIndexChanged += new System.EventHandler(this.cmbJudicialBranch_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(481, 83);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 16);
            this.label19.TabIndex = 2;
            this.label19.Text = "آدرس:";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(463, 30);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 16);
            this.label18.TabIndex = 1;
            this.label18.Text = "نام شعبه:";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(454, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "نام مجتمع:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(138, 580);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Close.Location = new System.Drawing.Point(492, 580);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(70, 35);
            this.Close.TabIndex = 6;
            this.Close.Text = "Exit";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // SaveClose
            // 
            this.SaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveClose.Location = new System.Drawing.Point(27, 580);
            this.SaveClose.Name = "SaveClose";
            this.SaveClose.Size = new System.Drawing.Size(105, 35);
            this.SaveClose.TabIndex = 7;
            this.SaveClose.Text = "SaveAndExit";
            this.SaveClose.UseVisualStyleBackColor = true;
            this.SaveClose.Click += new System.EventHandler(this.SaveClose_Click);
            // 
            // JProbateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 622);
            this.Controls.Add(this.SaveClose);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "JProbateForm";
            this.Text = "Probate";
            this.Load += new System.EventHandler(this.JProbateForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JProbateForm_FormClosing);
            this.tabPage2.ResumeLayout(false);
            this.Parties.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHeirs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.DateEdit txtDateIssued;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage Parties;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DelHeirs;
        private System.Windows.Forms.Button AddHeirs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labDeadNationalCode;
        private System.Windows.Forms.Label labDeaFatherName;
        private System.Windows.Forms.Label labDeadDateofbirth;
        private System.Windows.Forms.Label labDeadshsh;
        private System.Windows.Forms.Label labDeadFamily;
        private System.Windows.Forms.Label labDeadName;
        private System.Windows.Forms.Label Dateofbirth;
        private System.Windows.Forms.Label NationalCode;
        private System.Windows.Forms.Label FatherName;
        private System.Windows.Forms.Label Code;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label Family;
        private System.Windows.Forms.Label shsh;
        private System.Windows.Forms.Button AddDiePerson;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labApplicatorNationalCode;
        private System.Windows.Forms.Label labApplicatorFatherName;
        private System.Windows.Forms.Label labApplicatorFan;
        private System.Windows.Forms.Label labApplicatorName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button addApplicator;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label labAddressJudicialComplex;
        private System.Windows.Forms.Label labJudicialComplex;
        private ClassLibrary.JComboBox cmbJudicialBranch;
        private ArchivedDocuments.JArchiveList jArchiveList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button SaveClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panel1;
        private ClassLibrary.JDataGrid grdHeirs;
        private ClassLibrary.TextEdit txtDeadCode;
        private ClassLibrary.TextEdit txtApplicatorCode;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labDeadDate;
        private System.Windows.Forms.Label labDeadNo;
        private System.Windows.Forms.Label labDeathCertificateDate;
        private System.Windows.Forms.Button btnCalculateShare;
    }
}