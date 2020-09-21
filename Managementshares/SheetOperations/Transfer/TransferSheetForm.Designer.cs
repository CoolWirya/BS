namespace ManagementShares
{
    partial class JTransferSheetForm
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
			ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.personBuyer = new ClassLibrary.JUCPerson();
			this.personSeller = new ClassLibrary.JUCPerson();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.grdSheets = new ClassLibrary.JDataGrid();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.TxTSellShare = new System.Windows.Forms.TextBox();
			this.txtTime = new ClassLibrary.TimeEdit(this.components);
			this.chAgent = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.chMosalehe = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtShIndex = new ClassLibrary.TextEdit(this.components);
			this.txtShNote = new ClassLibrary.TextEdit(this.components);
			this.txtPrice = new ClassLibrary.TextEdit(this.components);
			this.txtTax = new ClassLibrary.TextEdit(this.components);
			this.txtDate = new ClassLibrary.DateEdit(this.components);
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.jPropertyValueUserControl1 = new Globals.Property.JPropertyValueUserControl();
			this.panel3 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.jArchiveList1 = new ArchivedDocuments.JArchiveList();
			this.txtDesc = new ClassLibrary.TextEdit(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdSheets)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.jArchiveList1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tabControl1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1009, 611);
			this.panel1.TabIndex = 3;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.RightToLeftLayout = true;
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1009, 611);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.personBuyer);
			this.tabPage1.Controls.Add(this.personSeller);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1001, 582);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "طرفین انتقال";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// personBuyer
			// 
			this.personBuyer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.personBuyer.CompanyCode = 1;
			this.personBuyer.FilterPerson = null;
			this.personBuyer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.personBuyer.LableGroup = "سهامدار جدید";
			this.personBuyer.Location = new System.Drawing.Point(10, 184);
			this.personBuyer.Name = "personBuyer";
			this.personBuyer.PersonType = ClassLibrary.JPersonTypes.None;
			this.personBuyer.ReadOnly = false;
			this.personBuyer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.personBuyer.SearchOnCode = ClassLibrary.SearchOnCode.SharePCode;
			this.personBuyer.SelectedCode = 0;
			this.personBuyer.ShareSelectedCode = ((long)(0));
			this.personBuyer.Size = new System.Drawing.Size(491, 179);
			this.personBuyer.TabIndex = 0;
			this.personBuyer.TafsiliCode = false;
			// 
			// personSeller
			// 
			this.personSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.personSeller.CompanyCode = 1;
			this.personSeller.FilterPerson = null;
			this.personSeller.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.personSeller.LableGroup = "سهامدار فعلی";
			this.personSeller.Location = new System.Drawing.Point(504, 184);
			this.personSeller.Name = "personSeller";
			this.personSeller.PersonType = ClassLibrary.JPersonTypes.None;
			this.personSeller.ReadOnly = false;
			this.personSeller.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.personSeller.SearchOnCode = ClassLibrary.SearchOnCode.Code;
			this.personSeller.SelectedCode = 0;
			this.personSeller.Size = new System.Drawing.Size(490, 179);
			this.personSeller.TabIndex = 1;
			this.personSeller.TafsiliCode = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.grdSheets);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(995, 175);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "برگه های انتخاب شده";
			// 
			// grdSheets
			// 
			this.grdSheets.ActionMenu = jPopupMenu2;
			this.grdSheets.AllowUserToAddRows = false;
			this.grdSheets.AllowUserToDeleteRows = false;
			this.grdSheets.AllowUserToOrderColumns = true;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
			this.grdSheets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.grdSheets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.grdSheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdSheets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdSheets.EnableContexMenu = true;
			this.grdSheets.KeyName = null;
			this.grdSheets.Location = new System.Drawing.Point(3, 19);
			this.grdSheets.Name = "grdSheets";
			this.grdSheets.ReadHeadersFromDB = false;
			this.grdSheets.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
			this.grdSheets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdSheets.ShowRowNumber = true;
			this.grdSheets.Size = new System.Drawing.Size(989, 153);
			this.grdSheets.TabIndex = 2;
			this.grdSheets.TableName = null;
			this.grdSheets.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSheets_CellEndEdit);
			this.grdSheets.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSheets_CellEnter);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.TxTSellShare);
			this.groupBox3.Controls.Add(this.txtTime);
			this.groupBox3.Controls.Add(this.chAgent);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.chMosalehe);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.txtShIndex);
			this.groupBox3.Controls.Add(this.txtShNote);
			this.groupBox3.Controls.Add(this.txtPrice);
			this.groupBox3.Controls.Add(this.txtTax);
			this.groupBox3.Controls.Add(this.txtDate);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox3.Location = new System.Drawing.Point(3, 359);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(995, 220);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			// 
			// TxTSellShare
			// 
			this.TxTSellShare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.TxTSellShare.Location = new System.Drawing.Point(777, 22);
			this.TxTSellShare.Name = "TxTSellShare";
			this.TxTSellShare.Size = new System.Drawing.Size(100, 23);
			this.TxTSellShare.TabIndex = 0;
			this.TxTSellShare.TextChanged += new System.EventHandler(this.TxTSellShare_TextChanged);
			// 
			// txtTime
			// 
			this.txtTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTime.ChangeColorIfNotEmpty = true;
			this.txtTime.ChangeColorOnEnter = true;
			this.txtTime.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.txtTime.InBackColor = System.Drawing.SystemColors.Info;
			this.txtTime.InForeColor = System.Drawing.SystemColors.WindowText;
			this.txtTime.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.txtTime.Location = new System.Drawing.Point(842, 55);
			this.txtTime.Mask = "00:00";
			this.txtTime.Name = "txtTime";
			this.txtTime.NotEmpty = false;
			this.txtTime.NotEmptyColor = System.Drawing.Color.Red;
			this.txtTime.Size = new System.Drawing.Size(42, 24);
			this.txtTime.TabIndex = 0;
			this.txtTime.ValidatingType = typeof(System.DateTime);
			// 
			// chAgent
			// 
			this.chAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chAgent.AutoSize = true;
			this.chAgent.Location = new System.Drawing.Point(628, 168);
			this.chAgent.Name = "chAgent";
			this.chAgent.Size = new System.Drawing.Size(93, 20);
			this.chAgent.TabIndex = 7;
			this.chAgent.Text = "انتقال وکالت";
			this.chAgent.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(644, 98);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "شماره ردیف:";
			// 
			// chMosalehe
			// 
			this.chMosalehe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chMosalehe.AutoSize = true;
			this.chMosalehe.Location = new System.Drawing.Point(809, 168);
			this.chMosalehe.Name = "chMosalehe";
			this.chMosalehe.Size = new System.Drawing.Size(154, 20);
			this.chMosalehe.TabIndex = 6;
			this.chMosalehe.Text = "انتقال به صورت مصالحه";
			this.chMosalehe.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(662, 132);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "قیمت کل:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(913, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "مالیات:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(887, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "شماره دفتر:";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(883, 25);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(107, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "تعداد سهم فروش:";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(887, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "تاریخ انتقال:";
			// 
			// txtShIndex
			// 
			this.txtShIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtShIndex.ChangeColorIfNotEmpty = false;
			this.txtShIndex.ChangeColorOnEnter = true;
			this.txtShIndex.InBackColor = System.Drawing.SystemColors.Info;
			this.txtShIndex.InForeColor = System.Drawing.SystemColors.WindowText;
			this.txtShIndex.Location = new System.Drawing.Point(538, 98);
			this.txtShIndex.Name = "txtShIndex";
			this.txtShIndex.Negative = true;
			this.txtShIndex.NotEmpty = false;
			this.txtShIndex.NotEmptyColor = System.Drawing.Color.Red;
			this.txtShIndex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtShIndex.SelectOnEnter = true;
			this.txtShIndex.Size = new System.Drawing.Size(100, 23);
			this.txtShIndex.TabIndex = 3;
			this.txtShIndex.Text = "`";
			this.txtShIndex.TextMode = ClassLibrary.TextModes.Integer;
			// 
			// txtShNote
			// 
			this.txtShNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtShNote.ChangeColorIfNotEmpty = false;
			this.txtShNote.ChangeColorOnEnter = true;
			this.txtShNote.InBackColor = System.Drawing.SystemColors.Info;
			this.txtShNote.InForeColor = System.Drawing.SystemColors.WindowText;
			this.txtShNote.Location = new System.Drawing.Point(784, 95);
			this.txtShNote.Name = "txtShNote";
			this.txtShNote.Negative = true;
			this.txtShNote.NotEmpty = false;
			this.txtShNote.NotEmptyColor = System.Drawing.Color.Red;
			this.txtShNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtShNote.SelectOnEnter = true;
			this.txtShNote.Size = new System.Drawing.Size(100, 23);
			this.txtShNote.TabIndex = 2;
			this.txtShNote.TextMode = ClassLibrary.TextModes.Text;
			// 
			// txtPrice
			// 
			this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPrice.ChangeColorIfNotEmpty = false;
			this.txtPrice.ChangeColorOnEnter = true;
			this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
			this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPrice.Location = new System.Drawing.Point(538, 129);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Negative = true;
			this.txtPrice.NotEmpty = false;
			this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
			this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtPrice.SelectOnEnter = true;
			this.txtPrice.Size = new System.Drawing.Size(100, 23);
			this.txtPrice.TabIndex = 5;
			this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
			// 
			// txtTax
			// 
			this.txtTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTax.ChangeColorIfNotEmpty = false;
			this.txtTax.ChangeColorOnEnter = true;
			this.txtTax.InBackColor = System.Drawing.SystemColors.Info;
			this.txtTax.InForeColor = System.Drawing.SystemColors.WindowText;
			this.txtTax.Location = new System.Drawing.Point(784, 125);
			this.txtTax.Name = "txtTax";
			this.txtTax.Negative = true;
			this.txtTax.NotEmpty = false;
			this.txtTax.NotEmptyColor = System.Drawing.Color.Red;
			this.txtTax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtTax.SelectOnEnter = true;
			this.txtTax.Size = new System.Drawing.Size(100, 23);
			this.txtTax.TabIndex = 4;
			this.txtTax.Text = "0";
			this.txtTax.TextMode = ClassLibrary.TextModes.Money;
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
			this.txtDate.Location = new System.Drawing.Point(755, 54);
			this.txtDate.Mask = "0000/00/00";
			this.txtDate.Name = "txtDate";
			this.txtDate.NotEmpty = false;
			this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
			this.txtDate.Size = new System.Drawing.Size(81, 23);
			this.txtDate.TabIndex = 1;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.jPropertyValueUserControl1);
			this.tabPage2.Controls.Add(this.panel3);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1001, 582);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Properties";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// jPropertyValueUserControl1
			// 
			this.jPropertyValueUserControl1.AutoScroll = true;
			this.jPropertyValueUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.jPropertyValueUserControl1.ClassName = null;
			this.jPropertyValueUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.jPropertyValueUserControl1.Location = new System.Drawing.Point(3, 43);
			this.jPropertyValueUserControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.jPropertyValueUserControl1.Name = "jPropertyValueUserControl1";
			this.jPropertyValueUserControl1.ObjectCode = -1;
			this.jPropertyValueUserControl1.Size = new System.Drawing.Size(995, 536);
			this.jPropertyValueUserControl1.TabIndex = 0;
			this.jPropertyValueUserControl1.ValueObjectCode = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.button1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(995, 40);
			this.panel3.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(5, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Edut...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.jArchiveList1);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(1001, 582);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Archive";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// jArchiveList1
			// 
			this.jArchiveList1.AllowUserAddFile = true;
			this.jArchiveList1.AllowUserAddFromArchive = true;
			this.jArchiveList1.AllowUserAddImage = true;
			this.jArchiveList1.AllowUserCamera = true;
			this.jArchiveList1.AllowUserDeleteFile = true;
			this.jArchiveList1.ClassName = "";
			this.jArchiveList1.ClassNames = null;
			this.jArchiveList1.Controls.Add(this.txtDesc);
			this.jArchiveList1.DataBaseClassName = "";
			this.jArchiveList1.DataBaseObjectCode = 0;
			this.jArchiveList1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.jArchiveList1.EnabledChange = true;
			this.jArchiveList1.ExtraObject = null;
			this.jArchiveList1.Location = new System.Drawing.Point(3, 3);
			this.jArchiveList1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.jArchiveList1.Name = "jArchiveList1";
			this.jArchiveList1.ObjectCode = 0;
			this.jArchiveList1.ObjectCodes = null;
			this.jArchiveList1.PlaceCode = 0;
			this.jArchiveList1.Size = new System.Drawing.Size(995, 576);
			this.jArchiveList1.SubjectCode = 0;
			this.jArchiveList1.TabIndex = 2;
			// 
			// txtDesc
			// 
			this.txtDesc.ChangeColorIfNotEmpty = true;
			this.txtDesc.ChangeColorOnEnter = true;
			this.txtDesc.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
			this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
			this.txtDesc.Location = new System.Drawing.Point(0, 0);
			this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 73, 3, 73);
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.Negative = true;
			this.txtDesc.NotEmpty = false;
			this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
			this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDesc.SelectOnEnter = true;
			this.txtDesc.Size = new System.Drawing.Size(995, 23);
			this.txtDesc.TabIndex = 3;
			this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.btnSave);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 611);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1009, 58);
			this.panel2.TabIndex = 2;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(508, 14);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "خروج";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(598, 14);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 32);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "ثبت انتقال";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// JTransferSheetForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1009, 669);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Name = "JTransferSheetForm";
			this.Text = "انتقال سهام";
			this.Load += new System.EventHandler(this.JTransferSheetForm_Load);
			this.Shown += new System.EventHandler(this.JTransferSheetForm_Shown);
			this.panel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdSheets)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.jArchiveList1.ResumeLayout(false);
			this.jArchiveList1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ClassLibrary.JUCPerson personBuyer;
        private ClassLibrary.JUCPerson personSeller;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JDataGrid grdSheets;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chAgent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chMosalehe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtShIndex;
        private ClassLibrary.TextEdit txtShNote;
        private ClassLibrary.TextEdit txtPrice;
        private ClassLibrary.TextEdit txtTax;
        private ClassLibrary.DateEdit txtDate;
        private ClassLibrary.TimeEdit txtTime;
		private System.Windows.Forms.TabPage tabPage2;
		private Globals.Property.JPropertyValueUserControl jPropertyValueUserControl1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabPage tabPage3;
		private ArchivedDocuments.JArchiveList jArchiveList1;
		private ClassLibrary.TextEdit txtDesc;
		private System.Windows.Forms.TextBox TxTSellShare;
		private System.Windows.Forms.Label label6;

    }
}