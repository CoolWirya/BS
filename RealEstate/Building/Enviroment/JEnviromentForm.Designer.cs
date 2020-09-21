namespace RealEstate
{
    partial class JEnviromentForm
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
            this.DefineProperty = new Globals.Property.JPropertyValueUserControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTafsili = new ClassLibrary.NumEdit();
            this.CmbInput = new ClassLibrary.JComboBox(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.cmbComplex = new ClassLibrary.JComboBox(this.components);
            this.cmbFloor = new ClassLibrary.JComboBox(this.components);
            this.cmbState = new ClassLibrary.JComboBox(this.components);
            this.cmbTypeEnviroment = new ClassLibrary.JComboBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmoneyBase = new ClassLibrary.MoneyEdit(this.components);
            this.txtCharge = new ClassLibrary.MoneyEdit(this.components);
            this.txtNameEnv = new ClassLibrary.TextEdit(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtAddress = new ClassLibrary.TextEdit(this.components);
            this.txtCodeEnv = new ClassLibrary.NumEdit();
            this.txtnumArea = new ClassLibrary.NumEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ArchiveList = new ArchivedDocuments.JArchiveList();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.jJanusGrid1 = new ClassLibrary.JJanusGrid();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStripContract = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(594, 466);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DefineProperty);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(586, 437);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "تعريف محيط";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DefineProperty
            // 
            this.DefineProperty.AutoScroll = true;
            this.DefineProperty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DefineProperty.ClassName = null;
            this.DefineProperty.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DefineProperty.Location = new System.Drawing.Point(3, 281);
            this.DefineProperty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DefineProperty.Name = "DefineProperty";
            this.DefineProperty.ObjectCode = -1;
            this.DefineProperty.Size = new System.Drawing.Size(580, 152);
            this.DefineProperty.TabIndex = 13;
            this.DefineProperty.ValueObjectCode = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTafsili);
            this.groupBox1.Controls.Add(this.CmbInput);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbComplex);
            this.groupBox1.Controls.Add(this.cmbFloor);
            this.groupBox1.Controls.Add(this.cmbState);
            this.groupBox1.Controls.Add(this.cmbTypeEnviroment);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtmoneyBase);
            this.groupBox1.Controls.Add(this.txtCharge);
            this.groupBox1.Controls.Add(this.txtNameEnv);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.txtCodeEnv);
            this.groupBox1.Controls.Add(this.txtnumArea);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 270);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تعريف";
            // 
            // txtTafsili
            // 
            this.txtTafsili.ChangeColorIfNotEmpty = false;
            this.txtTafsili.ChangeColorOnEnter = true;
            this.txtTafsili.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTafsili.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTafsili.Location = new System.Drawing.Point(316, 198);
            this.txtTafsili.Name = "txtTafsili";
            this.txtTafsili.Negative = true;
            this.txtTafsili.NotEmpty = false;
            this.txtTafsili.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTafsili.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtTafsili.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTafsili.SelectOnEnter = true;
            this.txtTafsili.Size = new System.Drawing.Size(165, 23);
            this.txtTafsili.TabIndex = 21;
            this.txtTafsili.TextMode = ClassLibrary.TextModes.Real;
            // 
            // CmbInput
            // 
            this.CmbInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.CmbInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInput.BaseCode = 0;
            this.CmbInput.ChangeColorIfNotEmpty = true;
            this.CmbInput.ChangeColorOnEnter = true;
            this.CmbInput.FormattingEnabled = true;
            this.CmbInput.InBackColor = System.Drawing.SystemColors.Info;
            this.CmbInput.InForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbInput.Location = new System.Drawing.Point(18, 164);
            this.CmbInput.Name = "CmbInput";
            this.CmbInput.NotEmpty = false;
            this.CmbInput.NotEmptyColor = System.Drawing.Color.Red;
            this.CmbInput.SelectOnEnter = true;
            this.CmbInput.Size = new System.Drawing.Size(187, 24);
            this.CmbInput.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(503, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = " كد مالي :";
            // 
            // cmbComplex
            // 
            this.cmbComplex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbComplex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbComplex.BaseCode = 0;
            this.cmbComplex.ChangeColorIfNotEmpty = true;
            this.cmbComplex.ChangeColorOnEnter = true;
            this.cmbComplex.FormattingEnabled = true;
            this.cmbComplex.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbComplex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbComplex.Location = new System.Drawing.Point(18, 55);
            this.cmbComplex.Name = "cmbComplex";
            this.cmbComplex.NotEmpty = false;
            this.cmbComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbComplex.SelectOnEnter = true;
            this.cmbComplex.Size = new System.Drawing.Size(187, 24);
            this.cmbComplex.TabIndex = 18;
            // 
            // cmbFloor
            // 
            this.cmbFloor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbFloor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFloor.BaseCode = 0;
            this.cmbFloor.ChangeColorIfNotEmpty = true;
            this.cmbFloor.ChangeColorOnEnter = true;
            this.cmbFloor.FormattingEnabled = true;
            this.cmbFloor.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbFloor.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFloor.Location = new System.Drawing.Point(317, 164);
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.NotEmpty = false;
            this.cmbFloor.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbFloor.SelectOnEnter = true;
            this.cmbFloor.Size = new System.Drawing.Size(165, 24);
            this.cmbFloor.TabIndex = 17;
            // 
            // cmbState
            // 
            this.cmbState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbState.BaseCode = 0;
            this.cmbState.ChangeColorIfNotEmpty = true;
            this.cmbState.ChangeColorOnEnter = true;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbState.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbState.Items.AddRange(new object[] {
            "معلق",
            "آماده براي اجاره",
            "رزو",
            "رزو تا رسيدن زمان مناسب",
            "در دست تعمير",
            "در حال اخذ قرارداد"});
            this.cmbState.Location = new System.Drawing.Point(317, 128);
            this.cmbState.Name = "cmbState";
            this.cmbState.NotEmpty = false;
            this.cmbState.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbState.SelectOnEnter = true;
            this.cmbState.Size = new System.Drawing.Size(164, 24);
            this.cmbState.TabIndex = 16;
            // 
            // cmbTypeEnviroment
            // 
            this.cmbTypeEnviroment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbTypeEnviroment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTypeEnviroment.BaseCode = 0;
            this.cmbTypeEnviroment.ChangeColorIfNotEmpty = true;
            this.cmbTypeEnviroment.ChangeColorOnEnter = true;
            this.cmbTypeEnviroment.FormattingEnabled = true;
            this.cmbTypeEnviroment.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbTypeEnviroment.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTypeEnviroment.Location = new System.Drawing.Point(317, 55);
            this.cmbTypeEnviroment.Name = "cmbTypeEnviroment";
            this.cmbTypeEnviroment.NotEmpty = false;
            this.cmbTypeEnviroment.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbTypeEnviroment.SelectOnEnter = true;
            this.cmbTypeEnviroment.Size = new System.Drawing.Size(164, 24);
            this.cmbTypeEnviroment.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(246, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "موقعیت:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(523, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "طبقه :";
            // 
            // txtmoneyBase
            // 
            this.txtmoneyBase.ChangeColorIfNotEmpty = false;
            this.txtmoneyBase.ChangeColorOnEnter = true;
            this.txtmoneyBase.InBackColor = System.Drawing.SystemColors.Info;
            this.txtmoneyBase.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtmoneyBase.LabelToDisplay = null;
            this.txtmoneyBase.Location = new System.Drawing.Point(18, 128);
            this.txtmoneyBase.Name = "txtmoneyBase";
            this.txtmoneyBase.Negative = true;
            this.txtmoneyBase.NotEmpty = false;
            this.txtmoneyBase.NotEmptyColor = System.Drawing.Color.Red;
            this.txtmoneyBase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtmoneyBase.SelectOnEnter = true;
            this.txtmoneyBase.Size = new System.Drawing.Size(187, 23);
            this.txtmoneyBase.TabIndex = 8;
            this.txtmoneyBase.TextMode = ClassLibrary.TextModes.Integer;
            this.txtmoneyBase.TextChanged += new System.EventHandler(this.txtNameEnv_TextChanged);
            // 
            // txtCharge
            // 
            this.txtCharge.ChangeColorIfNotEmpty = false;
            this.txtCharge.ChangeColorOnEnter = true;
            this.txtCharge.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCharge.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCharge.LabelToDisplay = null;
            this.txtCharge.Location = new System.Drawing.Point(18, 93);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.Negative = true;
            this.txtCharge.NotEmpty = false;
            this.txtCharge.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCharge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCharge.SelectOnEnter = true;
            this.txtCharge.Size = new System.Drawing.Size(185, 23);
            this.txtCharge.TabIndex = 6;
            this.txtCharge.TextMode = ClassLibrary.TextModes.Integer;
            this.txtCharge.TextChanged += new System.EventHandler(this.txtNameEnv_TextChanged);
            // 
            // txtNameEnv
            // 
            this.txtNameEnv.ChangeColorIfNotEmpty = false;
            this.txtNameEnv.ChangeColorOnEnter = true;
            this.txtNameEnv.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNameEnv.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNameEnv.Location = new System.Drawing.Point(18, 22);
            this.txtNameEnv.Name = "txtNameEnv";
            this.txtNameEnv.Negative = true;
            this.txtNameEnv.NotEmpty = false;
            this.txtNameEnv.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNameEnv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNameEnv.SelectOnEnter = true;
            this.txtNameEnv.Size = new System.Drawing.Size(187, 23);
            this.txtNameEnv.TabIndex = 2;
            this.txtNameEnv.TextMode = ClassLibrary.TextModes.Text;
            this.txtNameEnv.TextChanged += new System.EventHandler(this.txtNameEnv_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(233, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "نام محيط :";
            // 
            // txtAddress
            // 
            this.txtAddress.ChangeColorIfNotEmpty = false;
            this.txtAddress.ChangeColorOnEnter = true;
            this.txtAddress.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAddress.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAddress.Location = new System.Drawing.Point(18, 227);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Negative = true;
            this.txtAddress.NotEmpty = false;
            this.txtAddress.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.SelectOnEnter = true;
            this.txtAddress.Size = new System.Drawing.Size(463, 37);
            this.txtAddress.TabIndex = 11;
            this.txtAddress.TextMode = ClassLibrary.TextModes.Text;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtNameEnv_TextChanged);
            // 
            // txtCodeEnv
            // 
            this.txtCodeEnv.ChangeColorIfNotEmpty = false;
            this.txtCodeEnv.ChangeColorOnEnter = true;
            this.txtCodeEnv.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCodeEnv.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCodeEnv.Location = new System.Drawing.Point(317, 22);
            this.txtCodeEnv.Name = "txtCodeEnv";
            this.txtCodeEnv.Negative = true;
            this.txtCodeEnv.NotEmpty = false;
            this.txtCodeEnv.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCodeEnv.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtCodeEnv.ReadOnly = true;
            this.txtCodeEnv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodeEnv.SelectOnEnter = false;
            this.txtCodeEnv.Size = new System.Drawing.Size(165, 23);
            this.txtCodeEnv.TabIndex = 1;
            this.txtCodeEnv.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtnumArea
            // 
            this.txtnumArea.ChangeColorIfNotEmpty = false;
            this.txtnumArea.ChangeColorOnEnter = true;
            this.txtnumArea.InBackColor = System.Drawing.SystemColors.Info;
            this.txtnumArea.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtnumArea.Location = new System.Drawing.Point(317, 93);
            this.txtnumArea.Name = "txtnumArea";
            this.txtnumArea.Negative = true;
            this.txtnumArea.NotEmpty = false;
            this.txtnumArea.NotEmptyColor = System.Drawing.Color.Red;
            this.txtnumArea.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtnumArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtnumArea.SelectOnEnter = true;
            this.txtnumArea.Size = new System.Drawing.Size(165, 23);
            this.txtnumArea.TabIndex = 5;
            this.txtnumArea.TextMode = ClassLibrary.TextModes.Real;
            this.txtnumArea.TextChanged += new System.EventHandler(this.txtNameEnv_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(230, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 16);
            this.label13.TabIndex = 8;
            this.label13.Text = "قيمت پايه :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(513, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 16);
            this.label12.TabIndex = 7;
            this.label12.Text = "وضعيت :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(491, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "آدرس کامل :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(246, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "مجتمع :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(481, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "شماره محيط :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "قيمت شاژ پايه :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(505, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "مساحت :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "عنوان محيط :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ArchiveList);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(586, 437);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تصاوير";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ArchiveList
            // 
            this.ArchiveList.AllowUserAddFile = true;
            this.ArchiveList.AllowUserAddFromArchive = true;
            this.ArchiveList.AllowUserAddImage = true;
            this.ArchiveList.AllowUserCamera = true;
            this.ArchiveList.AllowUserDeleteFile = true;
            this.ArchiveList.ClassName = "";
            this.ArchiveList.ClassNames = null;
            this.ArchiveList.DataBaseClassName = "";
            this.ArchiveList.DataBaseObjectCode = 0;
            this.ArchiveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveList.EnabledChange = true;
            this.ArchiveList.ExtraObject = null;
            this.ArchiveList.Location = new System.Drawing.Point(3, 4);
            this.ArchiveList.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ArchiveList.Name = "ArchiveList";
            this.ArchiveList.ObjectCode = 0;
            this.ArchiveList.ObjectCodes = null;
            this.ArchiveList.PlaceCode = 0;
            this.ArchiveList.Size = new System.Drawing.Size(580, 429);
            this.ArchiveList.SubjectCode = 0;
            this.ArchiveList.TabIndex = 1;
            this.ArchiveList.AfterFileAdded += new ArchivedDocuments.JArchiveList.FileAdded(this.txtNameEnv_TextChanged);
            this.ArchiveList.AfterDescriptioEdited += new ArchivedDocuments.JArchiveList.DescriptioEdited(this.txtNameEnv_TextChanged);
            this.ArchiveList.Load += new System.EventHandler(this.ArchiveList_Load);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.jJanusGrid1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(586, 437);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "سوابق";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // jJanusGrid1
            // 
            this.jJanusGrid1.ActionClassName = "";
            this.jJanusGrid1.ActionMenu = null;
            this.jJanusGrid1.DataSource = null;
            this.jJanusGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jJanusGrid1.Edited = false;
            this.jJanusGrid1.Location = new System.Drawing.Point(0, 0);
            this.jJanusGrid1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jJanusGrid1.MultiSelect = true;
            this.jJanusGrid1.Name = "jJanusGrid1";
            this.jJanusGrid1.ShowNavigator = true;
            this.jJanusGrid1.ShowToolbar = true;
            this.jJanusGrid1.Size = new System.Drawing.Size(586, 437);
            this.jJanusGrid1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 473);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 40);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(200, 473);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 40);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 40);
            this.button1.TabIndex = 15;
            this.button1.Text = "ثبت قرارداد";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStripContract
            // 
            this.contextMenuStripContract.Name = "contextMenuStripContract";
            this.contextMenuStripContract.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStripContract.Size = new System.Drawing.Size(61, 4);
            // 
            // JEnviromentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 520);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnExit);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JEnviromentForm";
            this.Text = "فرم تعريف محيط";
            this.Load += new System.EventHandler(this.JEnviromentForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private ArchivedDocuments.JArchiveList ArchiveList;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit txtNameEnv;
        private System.Windows.Forms.Label label8;
        private ClassLibrary.TextEdit txtAddress;
        private ClassLibrary.NumEdit txtCodeEnv;
        private ClassLibrary.NumEdit txtnumArea;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Globals.Property.JPropertyValueUserControl DefineProperty;
        private ClassLibrary.MoneyEdit txtmoneyBase;
        private ClassLibrary.MoneyEdit txtCharge;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JComboBox CmbInput;
        private ClassLibrary.JComboBox cmbComplex;
        private ClassLibrary.JComboBox cmbFloor;
        private ClassLibrary.JComboBox cmbState;
        private ClassLibrary.JComboBox cmbTypeEnviroment;
        private ClassLibrary.NumEdit txtTafsili;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage3;
        private ClassLibrary.JJanusGrid jJanusGrid1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripContract;
    }
}