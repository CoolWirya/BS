namespace Legal
{
    partial class JRepairContractForm
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
            ClassLibrary.JPopupMenu jPopupMenu4 = new ClassLibrary.JPopupMenu();
            ClassLibrary.JPopupMenu jPopupMenu5 = new ClassLibrary.JPopupMenu();
            ClassLibrary.JPopupMenu jPopupMenu6 = new ClassLibrary.JPopupMenu();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSellers = new System.Windows.Forms.TabPage();
            this.groupSellers = new System.Windows.Forms.GroupBox();
            this.btnDelSellers = new System.Windows.Forms.Button();
            this.btnAddSeller = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSeller = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.jdgvSeller = new ClassLibrary.JDataGrid();
            this.tabBuyers = new System.Windows.Forms.TabPage();
            this.groupBuyers = new System.Windows.Forms.GroupBox();
            this.lblBuyer = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelBuyer = new System.Windows.Forms.Button();
            this.btnAddBuyer = new System.Windows.Forms.Button();
            this.jdgvBuyer = new ClassLibrary.JDataGrid();
            this.tabContractInfo = new System.Windows.Forms.TabPage();
            this.cmbJob = new ClassLibrary.JComboBox(this.components);
            this.cmbContractType = new ClassLibrary.JComboBox(this.components);
            this.cmbDynamicType = new ClassLibrary.JComboBox(this.components);
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.txtStartDate = new ClassLibrary.DateEdit(this.components);
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.txtRent = new ClassLibrary.TextEdit(this.components);
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.txtTotalPrice = new ClassLibrary.TextEdit(this.components);
            this.txtNo = new ClassLibrary.TextEdit(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TabContracts = new System.Windows.Forms.TabPage();
            this.grdNextContracts = new ClassLibrary.JDataGrid();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnRepairAll = new System.Windows.Forms.Button();
            this.groupBox13.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabSellers.SuspendLayout();
            this.groupSellers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvSeller)).BeginInit();
            this.tabBuyers.SuspendLayout();
            this.groupBuyers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvBuyer)).BeginInit();
            this.tabContractInfo.SuspendLayout();
            this.TabContracts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNextContracts)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.tabControl);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox13.Location = new System.Drawing.Point(0, 0);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(690, 454);
            this.groupBox13.TabIndex = 25;
            this.groupBox13.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSellers);
            this.tabControl.Controls.Add(this.tabBuyers);
            this.tabControl.Controls.Add(this.tabContractInfo);
            this.tabControl.Controls.Add(this.TabContracts);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 19);
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeftLayout = true;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(684, 432);
            this.tabControl.TabIndex = 15;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabSellers
            // 
            this.tabSellers.Controls.Add(this.groupSellers);
            this.tabSellers.Location = new System.Drawing.Point(4, 25);
            this.tabSellers.Name = "tabSellers";
            this.tabSellers.Padding = new System.Windows.Forms.Padding(3);
            this.tabSellers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabSellers.Size = new System.Drawing.Size(676, 403);
            this.tabSellers.TabIndex = 0;
            this.tabSellers.Text = "فروشندگان";
            this.tabSellers.UseVisualStyleBackColor = true;
            // 
            // groupSellers
            // 
            this.groupSellers.Controls.Add(this.btnDelSellers);
            this.groupSellers.Controls.Add(this.btnAddSeller);
            this.groupSellers.Controls.Add(this.lbl);
            this.groupSellers.Controls.Add(this.label4);
            this.groupSellers.Controls.Add(this.lblSeller);
            this.groupSellers.Controls.Add(this.label1);
            this.groupSellers.Controls.Add(this.jdgvSeller);
            this.groupSellers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSellers.Location = new System.Drawing.Point(3, 3);
            this.groupSellers.Name = "groupSellers";
            this.groupSellers.Size = new System.Drawing.Size(670, 397);
            this.groupSellers.TabIndex = 2;
            this.groupSellers.TabStop = false;
            this.groupSellers.Text = "اشخاص حقیقی / حقوقی";
            // 
            // btnDelSellers
            // 
            this.btnDelSellers.Location = new System.Drawing.Point(393, 367);
            this.btnDelSellers.Name = "btnDelSellers";
            this.btnDelSellers.Size = new System.Drawing.Size(75, 23);
            this.btnDelSellers.TabIndex = 10;
            this.btnDelSellers.Text = "حذف";
            this.btnDelSellers.UseVisualStyleBackColor = true;
            this.btnDelSellers.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddSeller
            // 
            this.btnAddSeller.Location = new System.Drawing.Point(473, 368);
            this.btnAddSeller.Name = "btnAddSeller";
            this.btnAddSeller.Size = new System.Drawing.Size(75, 23);
            this.btnAddSeller.TabIndex = 9;
            this.btnAddSeller.Text = "اضافه ";
            this.btnAddSeller.UseVisualStyleBackColor = true;
            this.btnAddSeller.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl.ForeColor = System.Drawing.Color.Maroon;
            this.lbl.Location = new System.Drawing.Point(26, 375);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(16, 16);
            this.lbl.TabIndex = 8;
            this.lbl.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "جمع سهام فروش";
            // 
            // lblSeller
            // 
            this.lblSeller.AutoSize = true;
            this.lblSeller.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSeller.ForeColor = System.Drawing.Color.Maroon;
            this.lblSeller.Location = new System.Drawing.Point(180, 375);
            this.lblSeller.Name = "lblSeller";
            this.lblSeller.Size = new System.Drawing.Size(16, 16);
            this.lblSeller.TabIndex = 6;
            this.lblSeller.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "جمع سهام";
            // 
            // jdgvSeller
            // 
            this.jdgvSeller.ActionMenu = jPopupMenu4;
            this.jdgvSeller.AllowUserToAddRows = false;
            this.jdgvSeller.AllowUserToDeleteRows = false;
            this.jdgvSeller.AllowUserToOrderColumns = true;
            this.jdgvSeller.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvSeller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvSeller.Dock = System.Windows.Forms.DockStyle.Top;
            this.jdgvSeller.EnableContexMenu = true;
            this.jdgvSeller.KeyName = null;
            this.jdgvSeller.Location = new System.Drawing.Point(3, 19);
            this.jdgvSeller.Name = "jdgvSeller";
            this.jdgvSeller.ReadHeadersFromDB = false;
            this.jdgvSeller.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvSeller.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvSeller.ShowRowNumber = true;
            this.jdgvSeller.Size = new System.Drawing.Size(664, 343);
            this.jdgvSeller.TabIndex = 3;
            this.jdgvSeller.TableName = null;
            // 
            // tabBuyers
            // 
            this.tabBuyers.Controls.Add(this.groupBuyers);
            this.tabBuyers.Location = new System.Drawing.Point(4, 25);
            this.tabBuyers.Name = "tabBuyers";
            this.tabBuyers.Padding = new System.Windows.Forms.Padding(3);
            this.tabBuyers.Size = new System.Drawing.Size(676, 406);
            this.tabBuyers.TabIndex = 3;
            this.tabBuyers.Text = "خریداران";
            this.tabBuyers.UseVisualStyleBackColor = true;
            // 
            // groupBuyers
            // 
            this.groupBuyers.Controls.Add(this.lblBuyer);
            this.groupBuyers.Controls.Add(this.label6);
            this.groupBuyers.Controls.Add(this.btnDelBuyer);
            this.groupBuyers.Controls.Add(this.btnAddBuyer);
            this.groupBuyers.Controls.Add(this.jdgvBuyer);
            this.groupBuyers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBuyers.Location = new System.Drawing.Point(3, 3);
            this.groupBuyers.Name = "groupBuyers";
            this.groupBuyers.Size = new System.Drawing.Size(670, 400);
            this.groupBuyers.TabIndex = 2;
            this.groupBuyers.TabStop = false;
            this.groupBuyers.Text = "اشخاص حقیقی / حقوقی";
            // 
            // lblBuyer
            // 
            this.lblBuyer.AutoSize = true;
            this.lblBuyer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBuyer.ForeColor = System.Drawing.Color.Maroon;
            this.lblBuyer.Location = new System.Drawing.Point(98, 365);
            this.lblBuyer.Name = "lblBuyer";
            this.lblBuyer.Size = new System.Drawing.Size(16, 16);
            this.lblBuyer.TabIndex = 13;
            this.lblBuyer.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "جمع سهام";
            // 
            // btnDelBuyer
            // 
            this.btnDelBuyer.Location = new System.Drawing.Point(392, 365);
            this.btnDelBuyer.Name = "btnDelBuyer";
            this.btnDelBuyer.Size = new System.Drawing.Size(75, 23);
            this.btnDelBuyer.TabIndex = 11;
            this.btnDelBuyer.Text = "حذف";
            this.btnDelBuyer.UseVisualStyleBackColor = true;
            this.btnDelBuyer.Click += new System.EventHandler(this.btnDelBuyer_Click);
            // 
            // btnAddBuyer
            // 
            this.btnAddBuyer.Location = new System.Drawing.Point(473, 365);
            this.btnAddBuyer.Name = "btnAddBuyer";
            this.btnAddBuyer.Size = new System.Drawing.Size(75, 23);
            this.btnAddBuyer.TabIndex = 9;
            this.btnAddBuyer.Text = "اضافه ";
            this.btnAddBuyer.UseVisualStyleBackColor = true;
            this.btnAddBuyer.Click += new System.EventHandler(this.btnAddBuyer_Click);
            // 
            // jdgvBuyer
            // 
            this.jdgvBuyer.ActionMenu = jPopupMenu5;
            this.jdgvBuyer.AllowUserToAddRows = false;
            this.jdgvBuyer.AllowUserToDeleteRows = false;
            this.jdgvBuyer.AllowUserToOrderColumns = true;
            this.jdgvBuyer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvBuyer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvBuyer.Dock = System.Windows.Forms.DockStyle.Top;
            this.jdgvBuyer.EnableContexMenu = true;
            this.jdgvBuyer.KeyName = null;
            this.jdgvBuyer.Location = new System.Drawing.Point(3, 19);
            this.jdgvBuyer.Name = "jdgvBuyer";
            this.jdgvBuyer.ReadHeadersFromDB = false;
            this.jdgvBuyer.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvBuyer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvBuyer.ShowRowNumber = true;
            this.jdgvBuyer.Size = new System.Drawing.Size(664, 340);
            this.jdgvBuyer.TabIndex = 10;
            this.jdgvBuyer.TableName = null;
            // 
            // tabContractInfo
            // 
            this.tabContractInfo.Controls.Add(this.cmbJob);
            this.tabContractInfo.Controls.Add(this.cmbContractType);
            this.tabContractInfo.Controls.Add(this.cmbDynamicType);
            this.tabContractInfo.Controls.Add(this.txtEndDate);
            this.tabContractInfo.Controls.Add(this.txtStartDate);
            this.tabContractInfo.Controls.Add(this.txtDate);
            this.tabContractInfo.Controls.Add(this.txtRent);
            this.tabContractInfo.Controls.Add(this.txtPrice);
            this.tabContractInfo.Controls.Add(this.txtTotalPrice);
            this.tabContractInfo.Controls.Add(this.txtNo);
            this.tabContractInfo.Controls.Add(this.label13);
            this.tabContractInfo.Controls.Add(this.label12);
            this.tabContractInfo.Controls.Add(this.label11);
            this.tabContractInfo.Controls.Add(this.label10);
            this.tabContractInfo.Controls.Add(this.label9);
            this.tabContractInfo.Controls.Add(this.label8);
            this.tabContractInfo.Controls.Add(this.label7);
            this.tabContractInfo.Controls.Add(this.label5);
            this.tabContractInfo.Controls.Add(this.label3);
            this.tabContractInfo.Controls.Add(this.label2);
            this.tabContractInfo.Location = new System.Drawing.Point(4, 25);
            this.tabContractInfo.Name = "tabContractInfo";
            this.tabContractInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabContractInfo.Size = new System.Drawing.Size(676, 406);
            this.tabContractInfo.TabIndex = 5;
            this.tabContractInfo.Text = "خلاصه اطلاعات قرارداد";
            this.tabContractInfo.UseVisualStyleBackColor = true;
            // 
            // cmbJob
            // 
            this.cmbJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbJob.BaseCode = 0;
            this.cmbJob.ChangeColorIfNotEmpty = true;
            this.cmbJob.ChangeColorOnEnter = true;
            this.cmbJob.FormattingEnabled = true;
            this.cmbJob.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbJob.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbJob.Location = new System.Drawing.Point(117, 161);
            this.cmbJob.Name = "cmbJob";
            this.cmbJob.NotEmpty = false;
            this.cmbJob.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbJob.SelectOnEnter = true;
            this.cmbJob.Size = new System.Drawing.Size(121, 24);
            this.cmbJob.TabIndex = 9;
            // 
            // cmbContractType
            // 
            this.cmbContractType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbContractType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbContractType.BaseCode = 0;
            this.cmbContractType.ChangeColorIfNotEmpty = true;
            this.cmbContractType.ChangeColorOnEnter = true;
            this.cmbContractType.Enabled = false;
            this.cmbContractType.FormattingEnabled = true;
            this.cmbContractType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbContractType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbContractType.Location = new System.Drawing.Point(53, 22);
            this.cmbContractType.Name = "cmbContractType";
            this.cmbContractType.NotEmpty = false;
            this.cmbContractType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbContractType.SelectOnEnter = true;
            this.cmbContractType.Size = new System.Drawing.Size(185, 24);
            this.cmbContractType.TabIndex = 1;
            // 
            // cmbDynamicType
            // 
            this.cmbDynamicType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbDynamicType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDynamicType.BackColor = System.Drawing.SystemColors.Info;
            this.cmbDynamicType.BaseCode = 0;
            this.cmbDynamicType.ChangeColorIfNotEmpty = true;
            this.cmbDynamicType.ChangeColorOnEnter = true;
            this.cmbDynamicType.Enabled = false;
            this.cmbDynamicType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDynamicType.FormattingEnabled = true;
            this.cmbDynamicType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbDynamicType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDynamicType.Location = new System.Drawing.Point(363, 18);
            this.cmbDynamicType.Name = "cmbDynamicType";
            this.cmbDynamicType.NotEmpty = false;
            this.cmbDynamicType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbDynamicType.SelectOnEnter = true;
            this.cmbDynamicType.Size = new System.Drawing.Size(174, 24);
            this.cmbDynamicType.TabIndex = 0;
            // 
            // txtEndDate
            // 
            this.txtEndDate.ChangeColorIfNotEmpty = true;
            this.txtEndDate.ChangeColorOnEnter = true;
            this.txtEndDate.Date = new System.DateTime(((long)(0)));
            this.txtEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate.InsertInDatesTable = true;
            this.txtEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDate.Location = new System.Drawing.Point(138, 95);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate.Size = new System.Drawing.Size(100, 23);
            this.txtEndDate.TabIndex = 5;
            // 
            // txtStartDate
            // 
            this.txtStartDate.ChangeColorIfNotEmpty = true;
            this.txtStartDate.ChangeColorOnEnter = true;
            this.txtStartDate.Date = new System.DateTime(((long)(0)));
            this.txtStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDate.InsertInDatesTable = true;
            this.txtStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartDate.Location = new System.Drawing.Point(434, 87);
            this.txtStartDate.Mask = "0000/00/00";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.NotEmpty = false;
            this.txtStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartDate.Size = new System.Drawing.Size(100, 23);
            this.txtStartDate.TabIndex = 4;
            // 
            // txtDate
            // 
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(138, 57);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 3;
            // 
            // txtRent
            // 
            this.txtRent.ChangeColorIfNotEmpty = false;
            this.txtRent.ChangeColorOnEnter = true;
            this.txtRent.InBackColor = System.Drawing.SystemColors.Info;
            this.txtRent.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRent.Location = new System.Drawing.Point(138, 129);
            this.txtRent.Name = "txtRent";
            this.txtRent.Negative = true;
            this.txtRent.NotEmpty = false;
            this.txtRent.NotEmptyColor = System.Drawing.Color.Red;
            this.txtRent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRent.SelectOnEnter = true;
            this.txtRent.Size = new System.Drawing.Size(100, 23);
            this.txtRent.TabIndex = 7;
            this.txtRent.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtPrice
            // 
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(434, 123);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(100, 23);
            this.txtPrice.TabIndex = 6;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.ChangeColorIfNotEmpty = false;
            this.txtTotalPrice.ChangeColorOnEnter = true;
            this.txtTotalPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTotalPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTotalPrice.Location = new System.Drawing.Point(434, 158);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Negative = true;
            this.txtTotalPrice.NotEmpty = false;
            this.txtTotalPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTotalPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalPrice.SelectOnEnter = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(100, 23);
            this.txtTotalPrice.TabIndex = 8;
            this.txtTotalPrice.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtNo
            // 
            this.txtNo.ChangeColorIfNotEmpty = false;
            this.txtNo.ChangeColorOnEnter = true;
            this.txtNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNo.Location = new System.Drawing.Point(434, 53);
            this.txtNo.Name = "txtNo";
            this.txtNo.Negative = true;
            this.txtNo.NotEmpty = false;
            this.txtNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNo.SelectOnEnter = true;
            this.txtNo.Size = new System.Drawing.Size(100, 23);
            this.txtNo.TabIndex = 2;
            this.txtNo.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(316, 169);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 16);
            this.label13.TabIndex = 9;
            this.label13.Text = "شغل:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(560, 169);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 16);
            this.label12.TabIndex = 8;
            this.label12.Text = "مبلغ کل قرارداد:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(244, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = "مبلغ اجاره ماهیانه:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(541, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "مبلغ قرض الحسنه:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(263, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "نوع متن قرارداد:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(586, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "نوع قرارداد:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(289, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "تاریخ پایان:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "تاریخ قرارداد:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(580, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "تاریخ شروع:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "شماره قرارداد:";
            // 
            // TabContracts
            // 
            this.TabContracts.Controls.Add(this.grdNextContracts);
            this.TabContracts.Location = new System.Drawing.Point(4, 25);
            this.TabContracts.Name = "TabContracts";
            this.TabContracts.Padding = new System.Windows.Forms.Padding(3);
            this.TabContracts.Size = new System.Drawing.Size(676, 406);
            this.TabContracts.TabIndex = 4;
            this.TabContracts.Text = "قرارداد های بعدی";
            this.TabContracts.UseVisualStyleBackColor = true;
            // 
            // grdNextContracts
            // 
            this.grdNextContracts.ActionMenu = jPopupMenu6;
            this.grdNextContracts.AllowUserToAddRows = false;
            this.grdNextContracts.AllowUserToDeleteRows = false;
            this.grdNextContracts.AllowUserToOrderColumns = true;
            this.grdNextContracts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdNextContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdNextContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNextContracts.EnableContexMenu = true;
            this.grdNextContracts.KeyName = null;
            this.grdNextContracts.Location = new System.Drawing.Point(3, 3);
            this.grdNextContracts.MultiSelect = false;
            this.grdNextContracts.Name = "grdNextContracts";
            this.grdNextContracts.ReadHeadersFromDB = false;
            this.grdNextContracts.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdNextContracts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdNextContracts.ShowRowNumber = true;
            this.grdNextContracts.Size = new System.Drawing.Size(670, 400);
            this.grdNextContracts.TabIndex = 0;
            this.grdNextContracts.TableName = null;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(603, 460);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 31);
            this.button6.TabIndex = 1;
            this.button6.Text = "close";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(13, 460);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 31);
            this.button5.TabIndex = 1;
            this.button5.Text = "ok";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnRepairAll
            // 
            this.btnRepairAll.Location = new System.Drawing.Point(447, 460);
            this.btnRepairAll.Name = "btnRepairAll";
            this.btnRepairAll.Size = new System.Drawing.Size(136, 31);
            this.btnRepairAll.TabIndex = 26;
            this.btnRepairAll.Text = "اصلاح قراردادها از ابتدا";
            this.btnRepairAll.UseVisualStyleBackColor = true;
            this.btnRepairAll.Click += new System.EventHandler(this.btnRepairAll_Click);
            // 
            // JRepairContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 503);
            this.Controls.Add(this.btnRepairAll);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Name = "JRepairContractForm";
            this.Text = "فرم اصلاح قرارداد";
            this.groupBox13.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabSellers.ResumeLayout(false);
            this.groupSellers.ResumeLayout(false);
            this.groupSellers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvSeller)).EndInit();
            this.tabBuyers.ResumeLayout(false);
            this.groupBuyers.ResumeLayout(false);
            this.groupBuyers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvBuyer)).EndInit();
            this.tabContractInfo.ResumeLayout(false);
            this.tabContractInfo.PerformLayout();
            this.TabContracts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNextContracts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSellers;
        private System.Windows.Forms.GroupBox groupSellers;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSeller;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JDataGrid jdgvSeller;
        private System.Windows.Forms.TabPage tabBuyers;
        private System.Windows.Forms.GroupBox groupBuyers;
        private System.Windows.Forms.Label lblBuyer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDelBuyer;
        private System.Windows.Forms.Button btnAddBuyer;
        private ClassLibrary.JDataGrid jdgvBuyer;
        private System.Windows.Forms.Button btnDelSellers;
        private System.Windows.Forms.Button btnAddSeller;
        private System.Windows.Forms.TabPage TabContracts;
        private ClassLibrary.JDataGrid grdNextContracts;
        private System.Windows.Forms.TabPage tabContractInfo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.JComboBox cmbJob;
        private ClassLibrary.JComboBox cmbContractType;
        private ClassLibrary.JComboBox cmbDynamicType;
        private ClassLibrary.DateEdit txtEndDate;
        private ClassLibrary.DateEdit txtStartDate;
        private ClassLibrary.DateEdit txtDate;
        private ClassLibrary.TextEdit txtRent;
        private ClassLibrary.TextEdit txtPrice;
        private ClassLibrary.TextEdit txtTotalPrice;
        private ClassLibrary.TextEdit txtNo;
        private System.Windows.Forms.Button btnRepairAll;
    }
}