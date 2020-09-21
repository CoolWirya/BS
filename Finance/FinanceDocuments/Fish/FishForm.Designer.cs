namespace Finance
{
    partial class JFishForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JFishForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDateRecieve = new ClassLibrary.DateEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAcc3 = new ClassLibrary.TextEdit(this.components);
            this.txtAcc2 = new ClassLibrary.TextEdit(this.components);
            this.txtAcc1 = new ClassLibrary.TextEdit(this.components);
            this.txtSerial = new ClassLibrary.TextEdit(this.components);
            this.cmbForm = new ClassLibrary.JComboBox(this.components);
            this.btnSwap = new System.Windows.Forms.Button();
            this.PersonReciver = new ClassLibrary.JUCPerson();
            this.PersonExport = new ClassLibrary.JUCPerson();
            this.cmbBank = new ClassLibrary.JComboBox(this.components);
            this.cmbConcern = new ClassLibrary.JComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNo = new ClassLibrary.TextEdit(this.components);
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeliverDate = new ClassLibrary.DateEdit(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.JArchive = new ArchivedDocuments.JArchiveList();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(962, 385);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(954, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "سند";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDateRecieve);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtAcc3);
            this.groupBox1.Controls.Add(this.txtAcc2);
            this.groupBox1.Controls.Add(this.txtAcc1);
            this.groupBox1.Controls.Add(this.txtSerial);
            this.groupBox1.Controls.Add(this.cmbForm);
            this.groupBox1.Controls.Add(this.btnSwap);
            this.groupBox1.Controls.Add(this.PersonReciver);
            this.groupBox1.Controls.Add(this.PersonExport);
            this.groupBox1.Controls.Add(this.cmbBank);
            this.groupBox1.Controls.Add(this.cmbConcern);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNo);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDeliverDate);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(948, 348);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtDateRecieve
            // 
            this.txtDateRecieve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateRecieve.BackColor = System.Drawing.SystemColors.Info;
            this.txtDateRecieve.ChangeColorIfNotEmpty = true;
            this.txtDateRecieve.ChangeColorOnEnter = true;
            this.txtDateRecieve.Date = new System.DateTime(((long)(0)));
            this.txtDateRecieve.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateRecieve.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateRecieve.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateRecieve.InsertInDatesTable = true;
            this.txtDateRecieve.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateRecieve.Location = new System.Drawing.Point(223, 13);
            this.txtDateRecieve.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDateRecieve.Mask = "0000/00/00";
            this.txtDateRecieve.Name = "txtDateRecieve";
            this.txtDateRecieve.NotEmpty = false;
            this.txtDateRecieve.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateRecieve.Size = new System.Drawing.Size(166, 23);
            this.txtDateRecieve.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 100;
            this.label3.Text = "تاریخ واریز:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(485, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 16);
            this.label11.TabIndex = 97;
            this.label11.Text = "سریال:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(652, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 16);
            this.label7.TabIndex = 98;
            this.label7.Text = "فرم:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(67, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 16);
            this.label14.TabIndex = 94;
            this.label14.Text = "دسته 3:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(189, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 16);
            this.label13.TabIndex = 95;
            this.label13.Text = "دسته 2:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(311, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 16);
            this.label12.TabIndex = 96;
            this.label12.Text = "دسته 1:";
            // 
            // txtAcc3
            // 
            this.txtAcc3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcc3.ChangeColorIfNotEmpty = false;
            this.txtAcc3.ChangeColorOnEnter = true;
            this.txtAcc3.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAcc3.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAcc3.Location = new System.Drawing.Point(9, 71);
            this.txtAcc3.Name = "txtAcc3";
            this.txtAcc3.Negative = true;
            this.txtAcc3.NotEmpty = false;
            this.txtAcc3.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAcc3.ReadOnly = true;
            this.txtAcc3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcc3.SelectOnEnter = true;
            this.txtAcc3.Size = new System.Drawing.Size(55, 23);
            this.txtAcc3.TabIndex = 91;
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
            this.txtAcc2.Location = new System.Drawing.Point(128, 71);
            this.txtAcc2.Name = "txtAcc2";
            this.txtAcc2.Negative = true;
            this.txtAcc2.NotEmpty = false;
            this.txtAcc2.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAcc2.ReadOnly = true;
            this.txtAcc2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcc2.SelectOnEnter = true;
            this.txtAcc2.Size = new System.Drawing.Size(55, 23);
            this.txtAcc2.TabIndex = 92;
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
            this.txtAcc1.Location = new System.Drawing.Point(250, 70);
            this.txtAcc1.Name = "txtAcc1";
            this.txtAcc1.Negative = true;
            this.txtAcc1.NotEmpty = false;
            this.txtAcc1.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAcc1.ReadOnly = true;
            this.txtAcc1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcc1.SelectOnEnter = true;
            this.txtAcc1.Size = new System.Drawing.Size(55, 23);
            this.txtAcc1.TabIndex = 9;
            this.txtAcc1.TextMode = ClassLibrary.TextModes.Text;
            this.txtAcc1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtAcc1_MouseDoubleClick);
            // 
            // txtSerial
            // 
            this.txtSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerial.ChangeColorIfNotEmpty = false;
            this.txtSerial.ChangeColorOnEnter = true;
            this.txtSerial.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSerial.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSerial.Location = new System.Drawing.Point(369, 69);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Negative = true;
            this.txtSerial.NotEmpty = false;
            this.txtSerial.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSerial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSerial.SelectOnEnter = true;
            this.txtSerial.Size = new System.Drawing.Size(115, 23);
            this.txtSerial.TabIndex = 8;
            this.txtSerial.TextMode = ClassLibrary.TextModes.Text;
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
            this.cmbForm.Location = new System.Drawing.Point(537, 69);
            this.cmbForm.Name = "cmbForm";
            this.cmbForm.NotEmpty = false;
            this.cmbForm.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbForm.SelectOnEnter = true;
            this.cmbForm.Size = new System.Drawing.Size(109, 24);
            this.cmbForm.TabIndex = 7;
            this.cmbForm.SelectedIndexChanged += new System.EventHandler(this.cmbForm_SelectedIndexChanged);
            // 
            // btnSwap
            // 
            this.btnSwap.Image = ((System.Drawing.Image)(resources.GetObject("btnSwap.Image")));
            this.btnSwap.Location = new System.Drawing.Point(505, 116);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(48, 35);
            this.btnSwap.TabIndex = 86;
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // PersonReciver
            // 
            this.PersonReciver.CompanyCode = 1;
            this.PersonReciver.FilterPerson = null;
            this.PersonReciver.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PersonReciver.LableGroup = null;
            this.PersonReciver.Location = new System.Drawing.Point(19, 100);
            this.PersonReciver.Name = "PersonReciver";
            this.PersonReciver.PersonType = ClassLibrary.JPersonTypes.None;
            this.PersonReciver.ReadOnly = false;
            this.PersonReciver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PersonReciver.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.PersonReciver.SelectedCode = 0;
            this.PersonReciver.ShareSelectedCode = ((long)(0));
            this.PersonReciver.Size = new System.Drawing.Size(467, 181);
            this.PersonReciver.TabIndex = 8;
            this.PersonReciver.TafsiliCode = false;
            // 
            // PersonExport
            // 
            this.PersonExport.CompanyCode = 1;
            this.PersonExport.FilterPerson = null;
            this.PersonExport.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PersonExport.LableGroup = null;
            this.PersonExport.Location = new System.Drawing.Point(492, 99);
            this.PersonExport.Name = "PersonExport";
            this.PersonExport.PersonType = ClassLibrary.JPersonTypes.None;
            this.PersonExport.ReadOnly = false;
            this.PersonExport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PersonExport.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.PersonExport.SelectedCode = 0;
            this.PersonExport.ShareSelectedCode = ((long)(0));
            this.PersonExport.Size = new System.Drawing.Size(447, 182);
            this.PersonExport.TabIndex = 7;
            this.PersonExport.TafsiliCode = false;
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
            this.cmbBank.Location = new System.Drawing.Point(12, 40);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.NotEmpty = false;
            this.cmbBank.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbBank.SelectOnEnter = true;
            this.cmbBank.Size = new System.Drawing.Size(634, 24);
            this.cmbBank.TabIndex = 5;
            this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.txtNo_TextChanged);
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
            this.cmbConcern.Location = new System.Drawing.Point(731, 40);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.NotEmpty = false;
            this.cmbConcern.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbConcern.SelectOnEnter = true;
            this.cmbConcern.Size = new System.Drawing.Size(159, 24);
            this.cmbConcern.TabIndex = 4;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(649, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 73;
            this.label5.Text = "نام بانک:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(892, 16);
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
            this.txtNo.Location = new System.Drawing.Point(732, 13);
            this.txtNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNo.Name = "txtNo";
            this.txtNo.Negative = true;
            this.txtNo.NotEmpty = false;
            this.txtNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNo.SelectOnEnter = true;
            this.txtNo.Size = new System.Drawing.Size(158, 23);
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
            this.txtDesc.Location = new System.Drawing.Point(19, 300);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(926, 39);
            this.txtDesc.TabIndex = 9;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(873, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 67;
            this.label2.Text = "توضیحات:";
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
            this.txtDeliverDate.Location = new System.Drawing.Point(480, 13);
            this.txtDeliverDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDeliverDate.Mask = "0000/00/00";
            this.txtDeliverDate.Name = "txtDeliverDate";
            this.txtDeliverDate.NotEmpty = false;
            this.txtDeliverDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDeliverDate.Size = new System.Drawing.Size(166, 23);
            this.txtDeliverDate.TabIndex = 2;
            this.txtDeliverDate.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(893, 44);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 16);
            this.label20.TabIndex = 63;
            this.label20.Text = "بابت:";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(893, 72);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 16);
            this.label23.TabIndex = 65;
            this.label23.Text = "مبلغ :";
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(649, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 16);
            this.label22.TabIndex = 64;
            this.label22.Text = "تاريخ تحويل :";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(731, 69);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(159, 23);
            this.txtPrice.TabIndex = 6;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Text;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.JArchive);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(954, 356);
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
            this.JArchive.Location = new System.Drawing.Point(3, 4);
            this.JArchive.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.JArchive.Name = "JArchive";
            this.JArchive.ObjectCode = 0;
            this.JArchive.ObjectCodes = null;
            this.JArchive.PlaceCode = 0;
            this.JArchive.Size = new System.Drawing.Size(948, 348);
            this.JArchive.SubjectCode = 0;
            this.JArchive.TabIndex = 1;
            this.JArchive.AfterFileAdded += new ArchivedDocuments.JArchiveList.FileAdded(this.txtNo_TextChanged);
            this.JArchive.AfterDescriptioEdited += new ArchivedDocuments.JArchiveList.DescriptioEdited(this.txtNo_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(103, 393);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Location = new System.Drawing.Point(22, 393);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 11;
            this.btnSaveClose.Text = "ذخیره";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(861, 393);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // JFishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(962, 434);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.tabControl1);
            this.Name = "JFishForm";
            this.Text = "فیش";
            this.Load += new System.EventHandler(this.JFishForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TabPage tabPage3;
        private ArchivedDocuments.JArchiveList JArchive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button btnExit;
        private ClassLibrary.JUCPerson PersonExport;
        private ClassLibrary.JUCPerson PersonReciver;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        public ClassLibrary.TextEdit txtNo;
        public ClassLibrary.DateEdit txtDeliverDate;
        public ClassLibrary.TextEdit txtPrice;
        public ClassLibrary.JComboBox cmbConcern;
        public ClassLibrary.JComboBox cmbBank;
        public ClassLibrary.TextEdit txtAcc3;
        public ClassLibrary.TextEdit txtAcc2;
        public ClassLibrary.TextEdit txtAcc1;
        public ClassLibrary.TextEdit txtSerial;
        public ClassLibrary.JComboBox cmbForm;
        public ClassLibrary.DateEdit txtDateRecieve;
    }
}