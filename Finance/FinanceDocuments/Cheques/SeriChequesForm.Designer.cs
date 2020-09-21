namespace Finance
{
    partial class JSeriChequesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JSeriChequesForm));
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSwap = new System.Windows.Forms.Button();
            this.PersonReciver = new ClassLibrary.JUCPerson();
            this.personExport = new ClassLibrary.JUCPerson();
            this.txtNote = new ClassLibrary.TextEdit(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAcc3 = new ClassLibrary.TextEdit(this.components);
            this.txtAcc2 = new ClassLibrary.TextEdit(this.components);
            this.txtAcc1 = new ClassLibrary.TextEdit(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.txtBranch_Number = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerial = new ClassLibrary.TextEdit(this.components);
            this.txtAccountNumber = new ClassLibrary.TextEdit(this.components);
            this.cmbBranch = new ClassLibrary.JComboBox(this.components);
            this.cmbState = new ClassLibrary.JComboBox(this.components);
            this.cmbCity = new ClassLibrary.JComboBox(this.components);
            this.cmbForm = new ClassLibrary.JComboBox(this.components);
            this.cmbConcern = new ClassLibrary.JComboBox(this.components);
            this.cmbBank = new ClassLibrary.JComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNo = new ClassLibrary.TextEdit(this.components);
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
            this.txtStartDate = new ClassLibrary.DateEdit(this.components);
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtMounth = new ClassLibrary.TextEdit(this.components);
            this.label30 = new System.Windows.Forms.Label();
            this.txtCheckCount = new ClassLibrary.TextEdit(this.components);
            this.btnCalc = new System.Windows.Forms.Button();
            this.jDataGrid1 = new ClassLibrary.JDataGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.JArchive = new ArchivedDocuments.JArchiveList();
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3 = new ClassLibrary.TextEdit(this.components);
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c = new ClassLibrary.TextEdit(this.components);
            this.object_a1001fab_a314_4191_a5ea_f85340222b20 = new ClassLibrary.TextEdit(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.JArchive.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(836, 429);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(828, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "سند";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSwap);
            this.groupBox1.Controls.Add(this.PersonReciver);
            this.groupBox1.Controls.Add(this.personExport);
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(822, 394);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSwap
            // 
            this.btnSwap.Image = ((System.Drawing.Image)(resources.GetObject("btnSwap.Image")));
            this.btnSwap.Location = new System.Drawing.Point(435, 33);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(48, 35);
            this.btnSwap.TabIndex = 85;
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // PersonReciver
            // 
            this.PersonReciver.CompanyCode = 1;
            this.PersonReciver.FilterPerson = null;
            this.PersonReciver.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PersonReciver.LableGroup = null;
            this.PersonReciver.Location = new System.Drawing.Point(18, 17);
            this.PersonReciver.Name = "PersonReciver";
            this.PersonReciver.PersonType = ClassLibrary.JPersonTypes.None;
            this.PersonReciver.ReadOnly = false;
            this.PersonReciver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PersonReciver.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.PersonReciver.SelectedCode = 0;
            this.PersonReciver.ShareSelectedCode = ((long)(0));
            this.PersonReciver.Size = new System.Drawing.Size(395, 184);
            this.PersonReciver.TabIndex = 2;
            this.PersonReciver.TafsiliCode = false;
            // 
            // personExport
            // 
            this.personExport.CompanyCode = 1;
            this.personExport.FilterPerson = null;
            this.personExport.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.personExport.LableGroup = null;
            this.personExport.Location = new System.Drawing.Point(423, 16);
            this.personExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.personExport.Name = "personExport";
            this.personExport.PersonType = ClassLibrary.JPersonTypes.None;
            this.personExport.ReadOnly = false;
            this.personExport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.personExport.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.personExport.SelectedCode = 0;
            this.personExport.ShareSelectedCode = ((long)(0));
            this.personExport.Size = new System.Drawing.Size(388, 185);
            this.personExport.TabIndex = 1;
            this.personExport.TafsiliCode = false;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.ChangeColorIfNotEmpty = true;
            this.txtNote.ChangeColorOnEnter = true;
            this.txtNote.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNote.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNote.Location = new System.Drawing.Point(18, 232);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Negative = true;
            this.txtNote.NotEmpty = false;
            this.txtNote.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNote.SelectOnEnter = true;
            this.txtNote.Size = new System.Drawing.Size(723, 53);
            this.txtNote.TabIndex = 3;
            this.txtNote.TabStop = false;
            this.txtNote.TextMode = ClassLibrary.TextModes.Text;
            this.txtNote.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(734, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 77;
            this.label6.Text = "پشت نویسی:";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(18, 315);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(723, 53);
            this.txtDesc.TabIndex = 4;
            this.txtDesc.TabStop = false;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(743, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 67;
            this.label2.Text = "توضیحات:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.txtAcc3);
            this.tabPage2.Controls.Add(this.txtAcc2);
            this.tabPage2.Controls.Add(this.txtAcc1);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtBranch_Number);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtSerial);
            this.tabPage2.Controls.Add(this.txtAccountNumber);
            this.tabPage2.Controls.Add(this.cmbBranch);
            this.tabPage2.Controls.Add(this.cmbState);
            this.tabPage2.Controls.Add(this.cmbCity);
            this.tabPage2.Controls.Add(this.cmbForm);
            this.tabPage2.Controls.Add(this.cmbConcern);
            this.tabPage2.Controls.Add(this.cmbBank);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtNo);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtDeliverDate);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label54);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtDateRecieve);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.txtPrice);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.txtStartDate);
            this.tabPage2.Controls.Add(this.label28);
            this.tabPage2.Controls.Add(this.label29);
            this.tabPage2.Controls.Add(this.txtMounth);
            this.tabPage2.Controls.Add(this.label30);
            this.tabPage2.Controls.Add(this.txtCheckCount);
            this.tabPage2.Controls.Add(this.btnCalc);
            this.tabPage2.Controls.Add(this.jDataGrid1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(828, 400);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "سری چک";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(70, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 16);
            this.label14.TabIndex = 179;
            this.label14.Text = "دسته 3:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(210, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 16);
            this.label13.TabIndex = 178;
            this.label13.Text = "دسته 2:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(345, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 16);
            this.label12.TabIndex = 177;
            this.label12.Text = "دسته 1:";
            // 
            // txtAcc3
            // 
            this.txtAcc3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcc3.ChangeColorIfNotEmpty = false;
            this.txtAcc3.ChangeColorOnEnter = true;
            this.txtAcc3.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAcc3.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAcc3.Location = new System.Drawing.Point(9, 103);
            this.txtAcc3.Name = "txtAcc3";
            this.txtAcc3.Negative = true;
            this.txtAcc3.NotEmpty = false;
            this.txtAcc3.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAcc3.ReadOnly = true;
            this.txtAcc3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcc3.SelectOnEnter = true;
            this.txtAcc3.Size = new System.Drawing.Size(55, 23);
            this.txtAcc3.TabIndex = 176;
            this.txtAcc3.TextMode = ClassLibrary.TextModes.Text;
            this.txtAcc3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtAcc1_MouseDoubleClick);
            // 
            // txtAcc2
            // 
            this.txtAcc2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcc2.ChangeColorIfNotEmpty = false;
            this.txtAcc2.ChangeColorOnEnter = true;
            this.txtAcc2.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAcc2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAcc2.Location = new System.Drawing.Point(152, 104);
            this.txtAcc2.Name = "txtAcc2";
            this.txtAcc2.Negative = true;
            this.txtAcc2.NotEmpty = false;
            this.txtAcc2.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAcc2.ReadOnly = true;
            this.txtAcc2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcc2.SelectOnEnter = true;
            this.txtAcc2.Size = new System.Drawing.Size(55, 23);
            this.txtAcc2.TabIndex = 175;
            this.txtAcc2.TextMode = ClassLibrary.TextModes.Text;
            this.txtAcc2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtAcc1_MouseDoubleClick);
            // 
            // txtAcc1
            // 
            this.txtAcc1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcc1.ChangeColorIfNotEmpty = false;
            this.txtAcc1.ChangeColorOnEnter = true;
            this.txtAcc1.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAcc1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAcc1.Location = new System.Drawing.Point(287, 105);
            this.txtAcc1.Name = "txtAcc1";
            this.txtAcc1.Negative = true;
            this.txtAcc1.NotEmpty = false;
            this.txtAcc1.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAcc1.ReadOnly = true;
            this.txtAcc1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcc1.SelectOnEnter = true;
            this.txtAcc1.Size = new System.Drawing.Size(55, 23);
            this.txtAcc1.TabIndex = 174;
            this.txtAcc1.TextMode = ClassLibrary.TextModes.Text;
            this.txtAcc1.TextChanged += new System.EventHandler(this.txtAcc1_TextChanged);
            this.txtAcc1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtAcc1_MouseDoubleClick);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(345, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 16);
            this.label10.TabIndex = 173;
            this.label10.Text = "کد شعبه:";
            // 
            // txtBranch_Number
            // 
            this.txtBranch_Number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBranch_Number.ChangeColorIfNotEmpty = false;
            this.txtBranch_Number.ChangeColorOnEnter = true;
            this.txtBranch_Number.InBackColor = System.Drawing.SystemColors.Info;
            this.txtBranch_Number.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBranch_Number.Location = new System.Drawing.Point(210, 45);
            this.txtBranch_Number.Name = "txtBranch_Number";
            this.txtBranch_Number.Negative = true;
            this.txtBranch_Number.NotEmpty = false;
            this.txtBranch_Number.NotEmptyColor = System.Drawing.Color.Red;
            this.txtBranch_Number.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBranch_Number.SelectOnEnter = true;
            this.txtBranch_Number.Size = new System.Drawing.Size(132, 23);
            this.txtBranch_Number.TabIndex = 154;
            this.txtBranch_Number.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(728, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 172;
            this.label3.Text = "شماره حساب:";
            // 
            // txtSerial
            // 
            this.txtSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerial.ChangeColorIfNotEmpty = false;
            this.txtSerial.ChangeColorOnEnter = true;
            this.txtSerial.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSerial.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSerial.Location = new System.Drawing.Point(411, 73);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Negative = true;
            this.txtSerial.NotEmpty = false;
            this.txtSerial.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSerial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSerial.SelectOnEnter = true;
            this.txtSerial.Size = new System.Drawing.Size(130, 23);
            this.txtSerial.TabIndex = 157;
            this.txtSerial.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountNumber.ChangeColorIfNotEmpty = false;
            this.txtAccountNumber.ChangeColorOnEnter = true;
            this.txtAccountNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAccountNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAccountNumber.Location = new System.Drawing.Point(616, 43);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Negative = true;
            this.txtAccountNumber.NotEmpty = false;
            this.txtAccountNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAccountNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAccountNumber.SelectOnEnter = true;
            this.txtAccountNumber.Size = new System.Drawing.Size(109, 23);
            this.txtAccountNumber.TabIndex = 152;
            this.txtAccountNumber.TextMode = ClassLibrary.TextModes.Text;
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
            this.cmbBranch.Location = new System.Drawing.Point(411, 43);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.NotEmpty = false;
            this.cmbBranch.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbBranch.SelectOnEnter = true;
            this.cmbBranch.Size = new System.Drawing.Size(130, 24);
            this.cmbBranch.TabIndex = 153;
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
            this.cmbState.Location = new System.Drawing.Point(616, 104);
            this.cmbState.Name = "cmbState";
            this.cmbState.NotEmpty = false;
            this.cmbState.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbState.SelectOnEnter = true;
            this.cmbState.Size = new System.Drawing.Size(109, 24);
            this.cmbState.TabIndex = 159;
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
            this.cmbCity.Location = new System.Drawing.Point(411, 102);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.NotEmpty = false;
            this.cmbCity.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCity.SelectOnEnter = true;
            this.cmbCity.Size = new System.Drawing.Size(130, 24);
            this.cmbCity.TabIndex = 160;
            this.cmbCity.SelectedIndexChanged += new System.EventHandler(this.cmbCity_SelectedIndexChanged);
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
            this.cmbForm.Location = new System.Drawing.Point(616, 72);
            this.cmbForm.Name = "cmbForm";
            this.cmbForm.NotEmpty = false;
            this.cmbForm.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbForm.SelectOnEnter = true;
            this.cmbForm.Size = new System.Drawing.Size(109, 24);
            this.cmbForm.TabIndex = 156;
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
            this.cmbConcern.Location = new System.Drawing.Point(8, 75);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.NotEmpty = false;
            this.cmbConcern.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbConcern.SelectOnEnter = true;
            this.cmbConcern.Size = new System.Drawing.Size(334, 24);
            this.cmbConcern.TabIndex = 158;
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
            this.cmbBank.Location = new System.Drawing.Point(411, 14);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.NotEmpty = false;
            this.cmbBank.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbBank.SelectOnEnter = true;
            this.cmbBank.Size = new System.Drawing.Size(130, 24);
            this.cmbBank.TabIndex = 149;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(551, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 171;
            this.label4.Text = "شعبه:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(551, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 170;
            this.label5.Text = "نام بانک:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(731, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 169;
            this.label1.Text = "شماره :";
            // 
            // txtNo
            // 
            this.txtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNo.ChangeColorIfNotEmpty = false;
            this.txtNo.ChangeColorOnEnter = true;
            this.txtNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNo.Location = new System.Drawing.Point(616, 14);
            this.txtNo.Name = "txtNo";
            this.txtNo.Negative = true;
            this.txtNo.NotEmpty = false;
            this.txtNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNo.SelectOnEnter = true;
            this.txtNo.Size = new System.Drawing.Size(109, 23);
            this.txtNo.TabIndex = 148;
            this.txtNo.TextMode = ClassLibrary.TextModes.Text;
            this.txtNo.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(731, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 16);
            this.label9.TabIndex = 165;
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
            this.txtDeliverDate.Location = new System.Drawing.Point(8, 14);
            this.txtDeliverDate.Mask = "0000/00/00";
            this.txtDeliverDate.Name = "txtDeliverDate";
            this.txtDeliverDate.NotEmpty = false;
            this.txtDeliverDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDeliverDate.Size = new System.Drawing.Size(100, 23);
            this.txtDeliverDate.TabIndex = 151;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(552, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 16);
            this.label8.TabIndex = 164;
            this.label8.Text = "شهر:";
            // 
            // label54
            // 
            this.label54.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(109, 43);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(95, 16);
            this.label54.TabIndex = 168;
            this.label54.Text = "تاريخ سررسيد :";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(551, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 16);
            this.label11.TabIndex = 161;
            this.label11.Text = "سریال:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(728, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 16);
            this.label7.TabIndex = 162;
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
            this.txtDateRecieve.Location = new System.Drawing.Point(8, 43);
            this.txtDateRecieve.Mask = "0000/00/00";
            this.txtDateRecieve.Name = "txtDateRecieve";
            this.txtDateRecieve.NotEmpty = false;
            this.txtDateRecieve.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateRecieve.Size = new System.Drawing.Size(100, 23);
            this.txtDateRecieve.TabIndex = 155;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(346, 78);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 16);
            this.label20.TabIndex = 163;
            this.label20.Text = "بابت:";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(345, 14);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 16);
            this.label23.TabIndex = 167;
            this.label23.Text = "مبلغ :";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(210, 14);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(132, 23);
            this.txtPrice.TabIndex = 150;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(109, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 16);
            this.label22.TabIndex = 166;
            this.label22.Text = "تاريخ تحويل :";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDate.BackColor = System.Drawing.SystemColors.Info;
            this.txtStartDate.ChangeColorIfNotEmpty = true;
            this.txtStartDate.ChangeColorOnEnter = true;
            this.txtStartDate.Date = new System.DateTime(((long)(0)));
            this.txtStartDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDate.InsertInDatesTable = true;
            this.txtStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartDate.Location = new System.Drawing.Point(625, 133);
            this.txtStartDate.Mask = "0000/00/00";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.NotEmpty = false;
            this.txtStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartDate.Size = new System.Drawing.Size(100, 23);
            this.txtStartDate.TabIndex = 142;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(730, 137);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(78, 16);
            this.label28.TabIndex = 147;
            this.label28.Text = "تاريخ شروع :";
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(348, 137);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(30, 16);
            this.label29.TabIndex = 146;
            this.label29.Text = "ماه:";
            // 
            // txtMounth
            // 
            this.txtMounth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMounth.ChangeColorIfNotEmpty = false;
            this.txtMounth.ChangeColorOnEnter = true;
            this.txtMounth.InBackColor = System.Drawing.SystemColors.Info;
            this.txtMounth.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMounth.Location = new System.Drawing.Point(213, 134);
            this.txtMounth.Name = "txtMounth";
            this.txtMounth.Negative = true;
            this.txtMounth.NotEmpty = false;
            this.txtMounth.NotEmptyColor = System.Drawing.Color.Red;
            this.txtMounth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMounth.SelectOnEnter = true;
            this.txtMounth.Size = new System.Drawing.Size(129, 23);
            this.txtMounth.TabIndex = 144;
            this.txtMounth.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(550, 137);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(39, 16);
            this.label30.TabIndex = 145;
            this.label30.Text = "تعداد:";
            // 
            // txtCheckCount
            // 
            this.txtCheckCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCheckCount.ChangeColorIfNotEmpty = false;
            this.txtCheckCount.ChangeColorOnEnter = true;
            this.txtCheckCount.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCheckCount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCheckCount.Location = new System.Drawing.Point(411, 134);
            this.txtCheckCount.Name = "txtCheckCount";
            this.txtCheckCount.Negative = true;
            this.txtCheckCount.NotEmpty = false;
            this.txtCheckCount.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCheckCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCheckCount.SelectOnEnter = true;
            this.txtCheckCount.Size = new System.Drawing.Size(133, 23);
            this.txtCheckCount.TabIndex = 143;
            this.txtCheckCount.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(9, 132);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(198, 24);
            this.btnCalc.TabIndex = 11;
            this.btnCalc.Text = "محاسبه";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // jDataGrid1
            // 
            this.jDataGrid1.ActionMenu = jPopupMenu1;
            this.jDataGrid1.AllowUserToAddRows = false;
            this.jDataGrid1.AllowUserToDeleteRows = false;
            this.jDataGrid1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jDataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGrid1.EnableContexMenu = true;
            this.jDataGrid1.KeyName = null;
            this.jDataGrid1.Location = new System.Drawing.Point(8, 163);
            this.jDataGrid1.Name = "jDataGrid1";
            this.jDataGrid1.ReadHeadersFromDB = false;
            this.jDataGrid1.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGrid1.ShowRowNumber = true;
            this.jDataGrid1.Size = new System.Drawing.Size(812, 234);
            this.jDataGrid1.TabIndex = 90;
            this.jDataGrid1.TableName = null;
            this.jDataGrid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jDataGrid1_CellContentClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.JArchive);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(828, 400);
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
            this.JArchive.Controls.Add(this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3);
            this.JArchive.Controls.Add(this.object_41eddf10_982e_4d40_9f01_ee348a76105c);
            this.JArchive.Controls.Add(this.object_a1001fab_a314_4191_a5ea_f85340222b20);
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
            this.JArchive.Size = new System.Drawing.Size(822, 394);
            this.JArchive.SubjectCode = 0;
            this.JArchive.TabIndex = 1;
            // 
            // object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3
            // 
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.ChangeColorIfNotEmpty = true;
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.ChangeColorOnEnter = true;
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.Dock = System.Windows.Forms.DockStyle.Top;
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.InBackColor = System.Drawing.SystemColors.Info;
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.InForeColor = System.Drawing.SystemColors.WindowText;
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.Location = new System.Drawing.Point(0, 46);
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.Margin = new System.Windows.Forms.Padding(3, 21, 3, 21);
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.Name = "object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3";
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.Negative = true;
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.NotEmpty = false;
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.NotEmptyColor = System.Drawing.Color.Red;
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.SelectOnEnter = true;
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.Size = new System.Drawing.Size(822, 23);
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.TabIndex = 3;
            this.object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3.TextMode = ClassLibrary.TextModes.Text;
            // 
            // object_41eddf10_982e_4d40_9f01_ee348a76105c
            // 
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.ChangeColorIfNotEmpty = true;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.ChangeColorOnEnter = true;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.Dock = System.Windows.Forms.DockStyle.Top;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.InBackColor = System.Drawing.SystemColors.Info;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.InForeColor = System.Drawing.SystemColors.WindowText;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.Location = new System.Drawing.Point(0, 23);
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.Margin = new System.Windows.Forms.Padding(3, 891, 3, 891);
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.Name = "object_41eddf10_982e_4d40_9f01_ee348a76105c";
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.Negative = true;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.NotEmpty = false;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.NotEmptyColor = System.Drawing.Color.Red;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.SelectOnEnter = true;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.Size = new System.Drawing.Size(822, 23);
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.TabIndex = 3;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.TextMode = ClassLibrary.TextModes.Text;
            // 
            // object_a1001fab_a314_4191_a5ea_f85340222b20
            // 
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.BackColor = System.Drawing.SystemColors.Info;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.ChangeColorIfNotEmpty = true;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.ChangeColorOnEnter = true;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.Dock = System.Windows.Forms.DockStyle.Top;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.ForeColor = System.Drawing.SystemColors.WindowText;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.InBackColor = System.Drawing.SystemColors.Info;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.InForeColor = System.Drawing.SystemColors.WindowText;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.Location = new System.Drawing.Point(0, 0);
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.Margin = new System.Windows.Forms.Padding(3, 3814, 3, 3814);
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.Name = "object_a1001fab_a314_4191_a5ea_f85340222b20";
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.Negative = true;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.NotEmpty = false;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.NotEmptyColor = System.Drawing.Color.Red;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.SelectOnEnter = true;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.Size = new System.Drawing.Size(822, 23);
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.TabIndex = 3;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.TextMode = ClassLibrary.TextModes.Text;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(22, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(733, 434);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Location = new System.Drawing.Point(103, 435);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 21;
            this.btnSaveClose.Text = "ذخیره";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Visible = false;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // JSeriChequesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 464);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.tabControl1);
            this.Name = "JSeriChequesForm";
            this.Text = "SeriCheques";
            this.Load += new System.EventHandler(this.JSeriChequesForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.JArchive.ResumeLayout(false);
            this.JArchive.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JUCPerson PersonReciver;
        private ClassLibrary.JUCPerson personExport;
        private ClassLibrary.TextEdit txtNote;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private ArchivedDocuments.JArchiveList JArchive;
        private ClassLibrary.TextEdit object_2f715f87_8a9b_40b3_9f0b_8d83f769b9a3;
        private ClassLibrary.TextEdit object_41eddf10_982e_4d40_9f01_ee348a76105c;
        private ClassLibrary.TextEdit object_a1001fab_a314_4191_a5ea_f85340222b20;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.TabPage tabPage2;
        private ClassLibrary.JDataGrid jDataGrid1;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnSwap;
        private ClassLibrary.DateEdit txtStartDate;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private ClassLibrary.TextEdit txtMounth;
        private System.Windows.Forms.Label label30;
        private ClassLibrary.TextEdit txtCheckCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        public ClassLibrary.TextEdit txtAcc3;
        public ClassLibrary.TextEdit txtAcc2;
        public ClassLibrary.TextEdit txtAcc1;
        private System.Windows.Forms.Label label10;
        public ClassLibrary.TextEdit txtBranch_Number;
        private System.Windows.Forms.Label label3;
        public ClassLibrary.TextEdit txtSerial;
        public ClassLibrary.TextEdit txtAccountNumber;
        public ClassLibrary.JComboBox cmbBranch;
        public ClassLibrary.JComboBox cmbState;
        public ClassLibrary.JComboBox cmbCity;
        public ClassLibrary.JComboBox cmbForm;
        public ClassLibrary.JComboBox cmbConcern;
        public ClassLibrary.JComboBox cmbBank;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        public ClassLibrary.TextEdit txtNo;
        private System.Windows.Forms.Label label9;
        public ClassLibrary.DateEdit txtDeliverDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        public ClassLibrary.DateEdit txtDateRecieve;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        public ClassLibrary.TextEdit txtPrice;
        private System.Windows.Forms.Label label22;
    }
}