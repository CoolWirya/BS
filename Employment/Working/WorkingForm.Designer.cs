namespace Employment
{
    partial class JWorkingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            ClassLibrary.JPopupMenu jPopupMenu3 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSearchPersonnel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRegForm = new System.Windows.Forms.Button();
            this.btnBefore = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.txtStartDate = new ClassLibrary.DateEdit(this.components);
            this.maskedTextBox = new ClassLibrary.TimeEdit(this.components);
            this.grHour = new System.Windows.Forms.GroupBox();
            this.lblHour = new System.Windows.Forms.Label();
            this.btnHour = new System.Windows.Forms.Button();
            this.dgvHour = new ClassLibrary.JDataGrid();
            this.grConfirm = new System.Windows.Forms.GroupBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.cmbFeild = new ClassLibrary.JComboBox(this.components);
            this.btnConfirm = new System.Windows.Forms.Button();
            this.dgvConfirm = new ClassLibrary.JDataGrid();
            this.jdgvList = new ClassLibrary.JDataGrid();
            this.contextMenuStripContract = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.grHour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHour)).BeginInit();
            this.grConfirm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvList)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnSearchPersonnel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnRegForm);
            this.groupBox1.Controls.Add(this.btnBefore);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1014, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "صورتی ثبت اضافه کار توسط کارگزینی";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(12, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "قهوه ای ثبت کارکرد توسط کارگزینی";
            // 
            // btnSearchPersonnel
            // 
            this.btnSearchPersonnel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchPersonnel.Location = new System.Drawing.Point(484, 23);
            this.btnSearchPersonnel.Name = "btnSearchPersonnel";
            this.btnSearchPersonnel.Size = new System.Drawing.Size(39, 25);
            this.btnSearchPersonnel.TabIndex = 22;
            this.btnSearchPersonnel.Text = "...";
            this.btnSearchPersonnel.UseVisualStyleBackColor = true;
            this.btnSearchPersonnel.Click += new System.EventHandler(this.btnSearchPersonnel_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(194, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "سبزثبت مرخصی ساعتی توسط کارگزینی";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(268, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "قرمز ثبت فرم توسط کارمند";
            // 
            // btnRegForm
            // 
            this.btnRegForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegForm.Location = new System.Drawing.Point(528, 21);
            this.btnRegForm.Name = "btnRegForm";
            this.btnRegForm.Size = new System.Drawing.Size(75, 25);
            this.btnRegForm.TabIndex = 15;
            this.btnRegForm.Text = "ثبت فرم";
            this.btnRegForm.UseVisualStyleBackColor = true;
            this.btnRegForm.Click += new System.EventHandler(this.btnRegForm_Click);
            // 
            // btnBefore
            // 
            this.btnBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBefore.Location = new System.Drawing.Point(446, 23);
            this.btnBefore.Name = "btnBefore";
            this.btnBefore.Size = new System.Drawing.Size(39, 25);
            this.btnBefore.TabIndex = 14;
            this.btnBefore.Text = "<-";
            this.btnBefore.UseVisualStyleBackColor = true;
            this.btnBefore.Click += new System.EventHandler(this.btnBefore_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(408, 23);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(39, 25);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = "->";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(605, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(790, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "تا تاریخ :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(955, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "از تاریخ :";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate.ChangeColorIfNotEmpty = true;
            this.txtEndDate.ChangeColorOnEnter = true;
            this.txtEndDate.Date = new System.DateTime(((long)(0)));
            this.txtEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate.InsertInDatesTable = true;
            this.txtEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDate.Location = new System.Drawing.Point(684, 22);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate.Size = new System.Drawing.Size(100, 23);
            this.txtEndDate.TabIndex = 1;
            // 
            // txtStartDate
            // 
            this.txtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDate.ChangeColorIfNotEmpty = true;
            this.txtStartDate.ChangeColorOnEnter = true;
            this.txtStartDate.Date = new System.DateTime(((long)(0)));
            this.txtStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDate.InsertInDatesTable = true;
            this.txtStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartDate.Location = new System.Drawing.Point(849, 22);
            this.txtStartDate.Mask = "0000/00/00";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.NotEmpty = false;
            this.txtStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartDate.Size = new System.Drawing.Size(100, 23);
            this.txtStartDate.TabIndex = 0;
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox.ChangeColorIfNotEmpty = true;
            this.maskedTextBox.ChangeColorOnEnter = true;
            this.maskedTextBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.maskedTextBox.InBackColor = System.Drawing.SystemColors.Info;
            this.maskedTextBox.InForeColor = System.Drawing.SystemColors.WindowText;
            this.maskedTextBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.maskedTextBox.Location = new System.Drawing.Point(442, -14);
            this.maskedTextBox.Mask = "00:00";
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.NotEmpty = false;
            this.maskedTextBox.NotEmptyColor = System.Drawing.Color.Red;
            this.maskedTextBox.Size = new System.Drawing.Size(58, 27);
            this.maskedTextBox.TabIndex = 2;
            this.maskedTextBox.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox.Visible = false;
            // 
            // grHour
            // 
            this.grHour.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grHour.Controls.Add(this.lblHour);
            this.grHour.Controls.Add(this.btnHour);
            this.grHour.Controls.Add(this.dgvHour);
            this.grHour.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grHour.Location = new System.Drawing.Point(0, 394);
            this.grHour.Name = "grHour";
            this.grHour.Size = new System.Drawing.Size(1014, 134);
            this.grHour.TabIndex = 1;
            this.grHour.TabStop = false;
            this.grHour.Text = "مرخصی ساعتی";
            this.grHour.Visible = false;
            // 
            // lblHour
            // 
            this.lblHour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHour.AutoSize = true;
            this.lblHour.Font = new System.Drawing.Font("B Koodak", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHour.ForeColor = System.Drawing.Color.Red;
            this.lblHour.Location = new System.Drawing.Point(672, 104);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(19, 26);
            this.lblHour.TabIndex = 8;
            this.lblHour.Text = "-";
            // 
            // btnHour
            // 
            this.btnHour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHour.Location = new System.Drawing.Point(472, 104);
            this.btnHour.Name = "btnHour";
            this.btnHour.Size = new System.Drawing.Size(144, 25);
            this.btnHour.TabIndex = 5;
            this.btnHour.Text = "تایید";
            this.btnHour.UseVisualStyleBackColor = true;
            this.btnHour.Click += new System.EventHandler(this.btnHour_Click);
            // 
            // dgvHour
            // 
            this.dgvHour.ActionMenu = jPopupMenu1;
            this.dgvHour.AllowUserToAddRows = false;
            this.dgvHour.AllowUserToDeleteRows = false;
            this.dgvHour.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgvHour.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHour.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvHour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHour.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvHour.EnableContexMenu = true;
            this.dgvHour.KeyName = null;
            this.dgvHour.Location = new System.Drawing.Point(3, 19);
            this.dgvHour.Name = "dgvHour";
            this.dgvHour.ReadHeadersFromDB = false;
            this.dgvHour.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgvHour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHour.ShowRowNumber = true;
            this.dgvHour.Size = new System.Drawing.Size(1008, 82);
            this.dgvHour.TabIndex = 1;
            this.dgvHour.TableName = null;
            // 
            // grConfirm
            // 
            this.grConfirm.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grConfirm.Controls.Add(this.lblConfirm);
            this.grConfirm.Controls.Add(this.cmbFeild);
            this.grConfirm.Controls.Add(this.btnConfirm);
            this.grConfirm.Controls.Add(this.dgvConfirm);
            this.grConfirm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grConfirm.Location = new System.Drawing.Point(0, 248);
            this.grConfirm.Name = "grConfirm";
            this.grConfirm.Size = new System.Drawing.Size(1014, 146);
            this.grConfirm.TabIndex = 2;
            this.grConfirm.TabStop = false;
            this.grConfirm.Text = "تایید کارکرد";
            this.grConfirm.Visible = false;
            // 
            // lblConfirm
            // 
            this.lblConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Font = new System.Drawing.Font("B Koodak", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblConfirm.ForeColor = System.Drawing.Color.Red;
            this.lblConfirm.Location = new System.Drawing.Point(837, 114);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(19, 26);
            this.lblConfirm.TabIndex = 7;
            this.lblConfirm.Text = "-";
            // 
            // cmbFeild
            // 
            this.cmbFeild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFeild.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbFeild.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFeild.BaseCode = 0;
            this.cmbFeild.ChangeColorIfNotEmpty = true;
            this.cmbFeild.ChangeColorOnEnter = true;
            this.cmbFeild.FormattingEnabled = true;
            this.cmbFeild.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbFeild.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFeild.Location = new System.Drawing.Point(627, 116);
            this.cmbFeild.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbFeild.Name = "cmbFeild";
            this.cmbFeild.NotEmpty = false;
            this.cmbFeild.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbFeild.SelectOnEnter = true;
            this.cmbFeild.Size = new System.Drawing.Size(157, 24);
            this.cmbFeild.TabIndex = 6;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(472, 115);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(144, 25);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "تایید";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // dgvConfirm
            // 
            this.dgvConfirm.ActionMenu = jPopupMenu2;
            this.dgvConfirm.AllowUserToAddRows = false;
            this.dgvConfirm.AllowUserToDeleteRows = false;
            this.dgvConfirm.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgvConfirm.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConfirm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConfirm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfirm.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvConfirm.EnableContexMenu = true;
            this.dgvConfirm.KeyName = null;
            this.dgvConfirm.Location = new System.Drawing.Point(3, 19);
            this.dgvConfirm.Name = "dgvConfirm";
            this.dgvConfirm.ReadHeadersFromDB = false;
            this.dgvConfirm.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgvConfirm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConfirm.ShowRowNumber = true;
            this.dgvConfirm.Size = new System.Drawing.Size(1008, 90);
            this.dgvConfirm.TabIndex = 0;
            this.dgvConfirm.TableName = null;
            // 
            // jdgvList
            // 
            this.jdgvList.ActionMenu = jPopupMenu3;
            this.jdgvList.AllowUserToAddRows = false;
            this.jdgvList.AllowUserToDeleteRows = false;
            this.jdgvList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jdgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.jdgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvList.EnableContexMenu = true;
            this.jdgvList.KeyName = null;
            this.jdgvList.Location = new System.Drawing.Point(3, 19);
            this.jdgvList.Name = "jdgvList";
            this.jdgvList.ReadHeadersFromDB = false;
            this.jdgvList.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvList.ShowRowNumber = true;
            this.jdgvList.Size = new System.Drawing.Size(1008, 162);
            this.jdgvList.TabIndex = 2;
            this.jdgvList.TableName = null;
            this.jdgvList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.jdgvList_Scroll);
            this.jdgvList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.jdgvList_MouseDown);
            this.jdgvList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.jdgvList_CellBeginEdit);
            this.jdgvList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.jdgvList_CellEndEdit);
            this.jdgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jdgvList_CellClick);
            this.jdgvList.SelectionChanged += new System.EventHandler(this.jdgvList_SelectionChanged);
            // 
            // contextMenuStripContract
            // 
            this.contextMenuStripContract.Name = "contextMenuStripContract";
            this.contextMenuStripContract.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStripContract.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.jdgvList);
            this.groupBox4.Controls.Add(this.maskedTextBox);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1014, 184);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "اطلاعات ورود و خروج";
            // 
            // JWorkingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 528);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grConfirm);
            this.Controls.Add(this.grHour);
            this.Controls.Add(this.groupBox1);
            this.Name = "JWorkingForm";
            this.Text = "WorkingForm";
            this.Load += new System.EventHandler(this.JWorkingForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JWorkingForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grHour.ResumeLayout(false);
            this.grHour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHour)).EndInit();
            this.grConfirm.ResumeLayout(false);
            this.grConfirm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvList)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grHour;
        private System.Windows.Forms.GroupBox grConfirm;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.DateEdit txtEndDate;
        private ClassLibrary.DateEdit txtStartDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripContract;
        private ClassLibrary.JDataGrid jdgvList;
        private System.Windows.Forms.Button btnBefore;
        private System.Windows.Forms.Button btnNext;
        private ClassLibrary.TimeEdit maskedTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private ClassLibrary.JDataGrid dgvConfirm;
        private System.Windows.Forms.Button btnHour;
        private ClassLibrary.JDataGrid dgvHour;
        private System.Windows.Forms.Button btnConfirm;
        private ClassLibrary.JComboBox cmbFeild;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.Button btnRegForm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSearchPersonnel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
    }
}