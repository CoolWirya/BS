namespace Finance
{
    partial class JChequesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JChequesForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAcc3 = new ClassLibrary.TextEdit(this.components);
            this.txtAcc2 = new ClassLibrary.TextEdit(this.components);
            this.txtAcc1 = new ClassLibrary.TextEdit(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.txtBranch_Number = new ClassLibrary.TextEdit(this.components);
            this.btnSwap = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerial = new ClassLibrary.TextEdit(this.components);
            this.txtAccountNumber = new ClassLibrary.TextEdit(this.components);
            this.PersonReciver = new ClassLibrary.JUCPerson();
            this.personExport = new ClassLibrary.JUCPerson();
            this.cmbBranch = new ClassLibrary.JComboBox(this.components);
            this.cmbState = new ClassLibrary.JComboBox(this.components);
            this.cmbCity = new ClassLibrary.JComboBox(this.components);
            this.cmbForm = new ClassLibrary.JComboBox(this.components);
            this.cmbConcern = new ClassLibrary.JComboBox(this.components);
            this.cmbBank = new ClassLibrary.JComboBox(this.components);
            this.txtNote = new ClassLibrary.TextEdit(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNo = new ClassLibrary.TextEdit(this.components);
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDeliverDate = new ClassLibrary.DateEdit(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDateRecieve = new ClassLibrary.DateEdit(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.JArchive = new ArchivedDocuments.JArchiveList();
            this.TabProperty = new System.Windows.Forms.TabPage();
            this.jPropertyValueUserControl1 = new Globals.Property.JPropertyValueUserControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.TabProperty.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(19, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(751, 490);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveClose.Location = new System.Drawing.Point(100, 490);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 14;
            this.btnSaveClose.Text = "ذخیره";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Visible = false;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.TabProperty);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(836, 484);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(828, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "سند";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtAcc3);
            this.groupBox1.Controls.Add(this.txtAcc2);
            this.groupBox1.Controls.Add(this.txtAcc1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtBranch_Number);
            this.groupBox1.Controls.Add(this.btnSwap);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSerial);
            this.groupBox1.Controls.Add(this.txtAccountNumber);
            this.groupBox1.Controls.Add(this.PersonReciver);
            this.groupBox1.Controls.Add(this.personExport);
            this.groupBox1.Controls.Add(this.cmbBranch);
            this.groupBox1.Controls.Add(this.cmbState);
            this.groupBox1.Controls.Add(this.cmbCity);
            this.groupBox1.Controls.Add(this.cmbForm);
            this.groupBox1.Controls.Add(this.cmbConcern);
            this.groupBox1.Controls.Add(this.cmbBank);
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNo);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtDeliverDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label54);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDateRecieve);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(822, 449);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(74, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 16);
            this.label14.TabIndex = 88;
            this.label14.Text = "دسته 3:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(214, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 16);
            this.label13.TabIndex = 88;
            this.label13.Text = "دسته 2:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(349, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 16);
            this.label12.TabIndex = 88;
            this.label12.Text = "دسته 1:";
            // 
            // txtAcc3
            // 
            this.txtAcc3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcc3.ChangeColorIfNotEmpty = false;
            this.txtAcc3.ChangeColorOnEnter = true;
            this.txtAcc3.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAcc3.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAcc3.Location = new System.Drawing.Point(13, 107);
            this.txtAcc3.Name = "txtAcc3";
            this.txtAcc3.Negative = true;
            this.txtAcc3.NotEmpty = false;
            this.txtAcc3.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAcc3.ReadOnly = true;
            this.txtAcc3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcc3.SelectOnEnter = true;
            this.txtAcc3.Size = new System.Drawing.Size(55, 23);
            this.txtAcc3.TabIndex = 87;
            this.txtAcc3.TextMode = ClassLibrary.TextModes.Text;
            this.txtAcc3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textEdit5_MouseDoubleClick);
            // 
            // txtAcc2
            // 
            this.txtAcc2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcc2.ChangeColorIfNotEmpty = false;
            this.txtAcc2.ChangeColorOnEnter = true;
            this.txtAcc2.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAcc2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAcc2.Location = new System.Drawing.Point(156, 108);
            this.txtAcc2.Name = "txtAcc2";
            this.txtAcc2.Negative = true;
            this.txtAcc2.NotEmpty = false;
            this.txtAcc2.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAcc2.ReadOnly = true;
            this.txtAcc2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcc2.SelectOnEnter = true;
            this.txtAcc2.Size = new System.Drawing.Size(55, 23);
            this.txtAcc2.TabIndex = 87;
            this.txtAcc2.TextMode = ClassLibrary.TextModes.Text;
            this.txtAcc2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textEdit5_MouseDoubleClick);
            // 
            // txtAcc1
            // 
            this.txtAcc1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcc1.ChangeColorIfNotEmpty = false;
            this.txtAcc1.ChangeColorOnEnter = true;
            this.txtAcc1.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAcc1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAcc1.Location = new System.Drawing.Point(291, 109);
            this.txtAcc1.Name = "txtAcc1";
            this.txtAcc1.Negative = true;
            this.txtAcc1.NotEmpty = false;
            this.txtAcc1.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAcc1.ReadOnly = true;
            this.txtAcc1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcc1.SelectOnEnter = true;
            this.txtAcc1.Size = new System.Drawing.Size(55, 23);
            this.txtAcc1.TabIndex = 87;
            this.txtAcc1.TextMode = ClassLibrary.TextModes.Text;
            this.txtAcc1.TextChanged += new System.EventHandler(this.txtAcc1_TextChanged);
            this.txtAcc1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textEdit5_MouseDoubleClick);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(349, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 16);
            this.label10.TabIndex = 86;
            this.label10.Text = "کد شعبه:";
            // 
            // txtBranch_Number
            // 
            this.txtBranch_Number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBranch_Number.ChangeColorIfNotEmpty = false;
            this.txtBranch_Number.ChangeColorOnEnter = true;
            this.txtBranch_Number.InBackColor = System.Drawing.SystemColors.Info;
            this.txtBranch_Number.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBranch_Number.Location = new System.Drawing.Point(214, 49);
            this.txtBranch_Number.Name = "txtBranch_Number";
            this.txtBranch_Number.Negative = true;
            this.txtBranch_Number.NotEmpty = false;
            this.txtBranch_Number.NotEmptyColor = System.Drawing.Color.Red;
            this.txtBranch_Number.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBranch_Number.SelectOnEnter = true;
            this.txtBranch_Number.Size = new System.Drawing.Size(132, 23);
            this.txtBranch_Number.TabIndex = 7;
            this.txtBranch_Number.TextMode = ClassLibrary.TextModes.Text;
            // 
            // btnSwap
            // 
            this.btnSwap.Image = ((System.Drawing.Image)(resources.GetObject("btnSwap.Image")));
            this.btnSwap.Location = new System.Drawing.Point(419, 157);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(48, 35);
            this.btnSwap.TabIndex = 84;
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(732, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 83;
            this.label3.Text = "شماره حساب:";
            // 
            // txtSerial
            // 
            this.txtSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerial.ChangeColorIfNotEmpty = false;
            this.txtSerial.ChangeColorOnEnter = true;
            this.txtSerial.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSerial.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSerial.Location = new System.Drawing.Point(415, 77);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Negative = true;
            this.txtSerial.NotEmpty = false;
            this.txtSerial.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSerial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSerial.SelectOnEnter = true;
            this.txtSerial.Size = new System.Drawing.Size(130, 23);
            this.txtSerial.TabIndex = 10;
            this.txtSerial.TextMode = ClassLibrary.TextModes.Text;
            this.txtSerial.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountNumber.ChangeColorIfNotEmpty = false;
            this.txtAccountNumber.ChangeColorOnEnter = true;
            this.txtAccountNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAccountNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAccountNumber.Location = new System.Drawing.Point(620, 47);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Negative = true;
            this.txtAccountNumber.NotEmpty = false;
            this.txtAccountNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAccountNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAccountNumber.SelectOnEnter = true;
            this.txtAccountNumber.Size = new System.Drawing.Size(109, 23);
            this.txtAccountNumber.TabIndex = 5;
            this.txtAccountNumber.TextMode = ClassLibrary.TextModes.Text;
            this.txtAccountNumber.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // PersonReciver
            // 
            this.PersonReciver.CompanyCode = 1;
            this.PersonReciver.FilterPerson = null;
            this.PersonReciver.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PersonReciver.LableGroup = null;
            this.PersonReciver.Location = new System.Drawing.Point(16, 132);
            this.PersonReciver.Name = "PersonReciver";
            this.PersonReciver.PersonType = ClassLibrary.JPersonTypes.None;
            this.PersonReciver.ReadOnly = false;
            this.PersonReciver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PersonReciver.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.PersonReciver.SelectedCode = 0;
            this.PersonReciver.ShareSelectedCode = ((long)(0));
            this.PersonReciver.Size = new System.Drawing.Size(389, 182);
            this.PersonReciver.TabIndex = 10;
            this.PersonReciver.TafsiliCode = false;
            // 
            // personExport
            // 
            this.personExport.CompanyCode = 1;
            this.personExport.FilterPerson = null;
            this.personExport.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.personExport.LableGroup = null;
            this.personExport.Location = new System.Drawing.Point(412, 133);
            this.personExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.personExport.Name = "personExport";
            this.personExport.PersonType = ClassLibrary.JPersonTypes.None;
            this.personExport.ReadOnly = false;
            this.personExport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.personExport.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.personExport.SelectedCode = 0;
            this.personExport.ShareSelectedCode = ((long)(0));
            this.personExport.Size = new System.Drawing.Size(398, 181);
            this.personExport.TabIndex = 9;
            this.personExport.TafsiliCode = false;
            // 
            // cmbBranch
            // 
            this.cmbBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBranch.BaseCode = 0;
            this.cmbBranch.ChangeColorIfNotEmpty = true;
            this.cmbBranch.ChangeColorOnEnter = true;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbBranch.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBranch.Location = new System.Drawing.Point(415, 47);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.NotEmpty = false;
            this.cmbBranch.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbBranch.SelectOnEnter = true;
            this.cmbBranch.Size = new System.Drawing.Size(130, 24);
            this.cmbBranch.TabIndex = 6;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // cmbState
            // 
            this.cmbState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbState.BaseCode = 0;
            this.cmbState.ChangeColorIfNotEmpty = true;
            this.cmbState.ChangeColorOnEnter = true;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbState.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbState.Location = new System.Drawing.Point(620, 108);
            this.cmbState.Name = "cmbState";
            this.cmbState.NotEmpty = false;
            this.cmbState.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbState.SelectOnEnter = true;
            this.cmbState.Size = new System.Drawing.Size(109, 24);
            this.cmbState.TabIndex = 12;
            this.cmbState.SelectedIndexChanged += new System.EventHandler(this.cmbState_SelectedIndexChanged);
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
            this.cmbCity.Location = new System.Drawing.Point(415, 106);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.NotEmpty = false;
            this.cmbCity.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCity.SelectOnEnter = true;
            this.cmbCity.Size = new System.Drawing.Size(130, 24);
            this.cmbCity.TabIndex = 13;
            this.cmbCity.SelectedIndexChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // cmbForm
            // 
            this.cmbForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbForm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbForm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbForm.BaseCode = 0;
            this.cmbForm.ChangeColorIfNotEmpty = true;
            this.cmbForm.ChangeColorOnEnter = true;
            this.cmbForm.FormattingEnabled = true;
            this.cmbForm.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbForm.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbForm.Location = new System.Drawing.Point(620, 76);
            this.cmbForm.Name = "cmbForm";
            this.cmbForm.NotEmpty = false;
            this.cmbForm.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbForm.SelectOnEnter = true;
            this.cmbForm.Size = new System.Drawing.Size(109, 24);
            this.cmbForm.TabIndex = 9;
            this.cmbForm.SelectedIndexChanged += new System.EventHandler(this.cmbForm_SelectedIndexChanged);
            // 
            // cmbConcern
            // 
            this.cmbConcern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConcern.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbConcern.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbConcern.BaseCode = 0;
            this.cmbConcern.ChangeColorIfNotEmpty = true;
            this.cmbConcern.ChangeColorOnEnter = true;
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbConcern.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbConcern.Location = new System.Drawing.Point(12, 79);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.NotEmpty = false;
            this.cmbConcern.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbConcern.SelectOnEnter = true;
            this.cmbConcern.Size = new System.Drawing.Size(334, 24);
            this.cmbConcern.TabIndex = 11;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // cmbBank
            // 
            this.cmbBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBank.BaseCode = 0;
            this.cmbBank.ChangeColorIfNotEmpty = true;
            this.cmbBank.ChangeColorOnEnter = true;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbBank.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBank.Location = new System.Drawing.Point(415, 18);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.NotEmpty = false;
            this.cmbBank.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbBank.SelectOnEnter = true;
            this.cmbBank.Size = new System.Drawing.Size(130, 24);
            this.cmbBank.TabIndex = 2;
            this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.ChangeColorIfNotEmpty = true;
            this.txtNote.ChangeColorOnEnter = true;
            this.txtNote.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNote.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNote.Location = new System.Drawing.Point(16, 318);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Negative = true;
            this.txtNote.NotEmpty = false;
            this.txtNote.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNote.SelectOnEnter = true;
            this.txtNote.Size = new System.Drawing.Size(711, 62);
            this.txtNote.TabIndex = 14;
            this.txtNote.TabStop = false;
            this.txtNote.TextMode = ClassLibrary.TextModes.Text;
            this.txtNote.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(731, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 77;
            this.label6.Text = "پشت نویسی:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(555, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 75;
            this.label4.Text = "شعبه:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(555, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 73;
            this.label5.Text = "نام بانک:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(735, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 71;
            this.label1.Text = "شماره :";
            // 
            // txtNo
            // 
            this.txtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNo.ChangeColorIfNotEmpty = false;
            this.txtNo.ChangeColorOnEnter = true;
            this.txtNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNo.Location = new System.Drawing.Point(620, 18);
            this.txtNo.Name = "txtNo";
            this.txtNo.Negative = true;
            this.txtNo.NotEmpty = false;
            this.txtNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNo.SelectOnEnter = true;
            this.txtNo.Size = new System.Drawing.Size(109, 23);
            this.txtNo.TabIndex = 1;
            this.txtNo.TextMode = ClassLibrary.TextModes.Text;
            this.txtNo.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(16, 386);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(711, 53);
            this.txtDesc.TabIndex = 15;
            this.txtDesc.TabStop = false;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(735, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 67;
            this.label2.Text = "توضیحات:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(735, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 16);
            this.label9.TabIndex = 63;
            this.label9.Text = "استان:";
            // 
            // txtDeliverDate
            // 
            this.txtDeliverDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliverDate.BackColor = System.Drawing.SystemColors.Info;
            this.txtDeliverDate.ChangeColorIfNotEmpty = true;
            this.txtDeliverDate.ChangeColorOnEnter = true;
            this.txtDeliverDate.Date = new System.DateTime(((long)(0)));
            this.txtDeliverDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeliverDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDeliverDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeliverDate.InsertInDatesTable = true;
            this.txtDeliverDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDeliverDate.Location = new System.Drawing.Point(12, 18);
            this.txtDeliverDate.Mask = "0000/00/00";
            this.txtDeliverDate.Name = "txtDeliverDate";
            this.txtDeliverDate.NotEmpty = false;
            this.txtDeliverDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDeliverDate.Size = new System.Drawing.Size(100, 23);
            this.txtDeliverDate.TabIndex = 4;
            this.txtDeliverDate.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(556, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 16);
            this.label8.TabIndex = 63;
            this.label8.Text = "شهر:";
            // 
            // label54
            // 
            this.label54.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(113, 47);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(95, 16);
            this.label54.TabIndex = 66;
            this.label54.Text = "تاريخ سررسيد :";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(555, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 16);
            this.label11.TabIndex = 63;
            this.label11.Text = "سریال:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(732, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 16);
            this.label7.TabIndex = 63;
            this.label7.Text = "فرم:";
            // 
            // txtDateRecieve
            // 
            this.txtDateRecieve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateRecieve.ChangeColorIfNotEmpty = true;
            this.txtDateRecieve.ChangeColorOnEnter = true;
            this.txtDateRecieve.Date = new System.DateTime(((long)(0)));
            this.txtDateRecieve.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateRecieve.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateRecieve.InsertInDatesTable = true;
            this.txtDateRecieve.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateRecieve.Location = new System.Drawing.Point(12, 47);
            this.txtDateRecieve.Mask = "0000/00/00";
            this.txtDateRecieve.Name = "txtDateRecieve";
            this.txtDateRecieve.NotEmpty = false;
            this.txtDateRecieve.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateRecieve.Size = new System.Drawing.Size(100, 23);
            this.txtDateRecieve.TabIndex = 8;
            this.txtDateRecieve.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtDateRecieve_MaskInputRejected);
            this.txtDateRecieve.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(350, 82);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 16);
            this.label20.TabIndex = 63;
            this.label20.Text = "بابت:";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(349, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 16);
            this.label23.TabIndex = 65;
            this.label23.Text = "مبلغ :";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(214, 18);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(132, 23);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(113, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 16);
            this.label22.TabIndex = 64;
            this.label22.Text = "تاريخ تحويل :";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.JArchive);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(828, 455);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "تصاویر";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // JArchive
            // 
            this.JArchive.AllowUserAddFile = true;
            this.JArchive.AllowUserAddFromArchive = true;
            this.JArchive.AllowUserAddImage = true;
            this.JArchive.AllowUserCamera = true;
            this.JArchive.AllowUserDeleteFile = true;
            this.JArchive.ClassName = "";
            this.JArchive.ClassNames = null;
            this.JArchive.DataBaseClassName = "";
            this.JArchive.DataBaseObjectCode = 0;
            this.JArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JArchive.EnabledChange = true;
            this.JArchive.ExtraObject = null;
            this.JArchive.Location = new System.Drawing.Point(3, 3);
            this.JArchive.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.JArchive.Name = "JArchive";
            this.JArchive.ObjectCode = 0;
            this.JArchive.ObjectCodes = null;
            this.JArchive.PlaceCode = 0;
            this.JArchive.Size = new System.Drawing.Size(822, 449);
            this.JArchive.SubjectCode = 0;
            this.JArchive.TabIndex = 1;
            // 
            // TabProperty
            // 
            this.TabProperty.Controls.Add(this.jPropertyValueUserControl1);
            this.TabProperty.Location = new System.Drawing.Point(4, 25);
            this.TabProperty.Name = "TabProperty";
            this.TabProperty.Padding = new System.Windows.Forms.Padding(3);
            this.TabProperty.Size = new System.Drawing.Size(828, 455);
            this.TabProperty.TabIndex = 3;
            this.TabProperty.Text = "ویژگیها";
            this.TabProperty.UseVisualStyleBackColor = true;
            // 
            // jPropertyValueUserControl1
            // 
            this.jPropertyValueUserControl1.AutoScroll = true;
            this.jPropertyValueUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.jPropertyValueUserControl1.ClassName = null;
            this.jPropertyValueUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jPropertyValueUserControl1.Location = new System.Drawing.Point(3, 3);
            this.jPropertyValueUserControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jPropertyValueUserControl1.Name = "jPropertyValueUserControl1";
            this.jPropertyValueUserControl1.ObjectCode = -1;
            this.jPropertyValueUserControl1.Size = new System.Drawing.Size(822, 449);
            this.jPropertyValueUserControl1.TabIndex = 0;
            this.jPropertyValueUserControl1.ValueObjectCode = 0;
            this.jPropertyValueUserControl1.Load += new System.EventHandler(this.jPropertyValueUserControl1_Load);
            // 
            // JChequesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(836, 526);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.tabControl1);
            this.Name = "JChequesForm";
            this.Text = "چک";
            this.Load += new System.EventHandler(this.JChequesForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.TabProperty.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit txtNote;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TabPage tabPage3;
        private ArchivedDocuments.JArchiveList JArchive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveClose;
        private ClassLibrary.JUCPerson personExport;
        private ClassLibrary.JUCPerson PersonReciver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.TabPage TabProperty;
        private Globals.Property.JPropertyValueUserControl jPropertyValueUserControl1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        public ClassLibrary.TextEdit txtNo;
        public ClassLibrary.DateEdit txtDeliverDate;
        public ClassLibrary.DateEdit txtDateRecieve;
        public ClassLibrary.TextEdit txtPrice;
        public ClassLibrary.JComboBox cmbBranch;
        public ClassLibrary.JComboBox cmbConcern;
        public ClassLibrary.JComboBox cmbBank;
        public ClassLibrary.TextEdit txtAccountNumber;
        public ClassLibrary.TextEdit txtBranch_Number;
        public ClassLibrary.JComboBox cmbState;
        public ClassLibrary.JComboBox cmbCity;
        public ClassLibrary.JComboBox cmbForm;
        public ClassLibrary.TextEdit txtSerial;
        public ClassLibrary.TextEdit txtAcc3;
        public ClassLibrary.TextEdit txtAcc2;
        public ClassLibrary.TextEdit txtAcc1;
    }
}