namespace Employment
{
    partial class JEContractForm

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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ComPerson = new ClassLibrary.JUCPerson();
            this.cmbWorkShift = new ClassLibrary.JComboBox(this.components);
            this.txtDateEnd = new ClassLibrary.DateEdit(this.components);
            this.txtDateStart = new ClassLibrary.DateEdit(this.components);
            this.txtEmpDate = new ClassLibrary.DateEdit(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.cmbActivity = new ClassLibrary.JComboBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.jDataGrid2 = new ClassLibrary.JDataGrid();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.jDataGrid1 = new ClassLibrary.JDataGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddRights = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.JArchive = new ArchivedDocuments.JArchiveList();
            this.textEdit1 = new ClassLibrary.TextEdit(this.components);
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNo = new ClassLibrary.TextEdit(this.components);
            this.txtContractDate = new ClassLibrary.DateEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReContract = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid2)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(517, 489);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(14, 489);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(620, 436);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(3, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(614, 414);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ComPerson);
            this.tabPage1.Controls.Add(this.cmbWorkShift);
            this.tabPage1.Controls.Add(this.txtDateEnd);
            this.tabPage1.Controls.Add(this.txtDateStart);
            this.tabPage1.Controls.Add(this.txtEmpDate);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtDesc);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cmbActivity);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(606, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ContractInfo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ComPerson
            // 
            this.ComPerson.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComPerson.FilterPerson = null;
            this.ComPerson.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ComPerson.LableGroup = null;
            this.ComPerson.Location = new System.Drawing.Point(3, 2);
            this.ComPerson.Name = "ComPerson";
            this.ComPerson.PersonType = ClassLibrary.JPersonTypes.None;
            this.ComPerson.ReadOnly = false;
            this.ComPerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ComPerson.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.ComPerson.SelectedCode = 0;
            this.ComPerson.ShareSelectedCode = ((long)(0));
            //this.ComPerson.ShowPersonImage = false;
            this.ComPerson.Size = new System.Drawing.Size(600, 180);
            this.ComPerson.TabIndex = 5;
            this.ComPerson.TafsiliCode = false;
            // 
            // cmbWorkShift
            // 
            this.cmbWorkShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWorkShift.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbWorkShift.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbWorkShift.BaseCode = 0;
            this.cmbWorkShift.ChangeColorIfNotEmpty = true;
            this.cmbWorkShift.ChangeColorOnEnter = true;
            this.cmbWorkShift.FormattingEnabled = true;
            this.cmbWorkShift.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbWorkShift.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbWorkShift.Location = new System.Drawing.Point(58, 225);
            this.cmbWorkShift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbWorkShift.Name = "cmbWorkShift";
            this.cmbWorkShift.NotEmpty = false;
            this.cmbWorkShift.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbWorkShift.SelectOnEnter = true;
            this.cmbWorkShift.Size = new System.Drawing.Size(121, 24);
            this.cmbWorkShift.TabIndex = 10;
            this.cmbWorkShift.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateEnd.BackColor = System.Drawing.SystemColors.Info;
            this.txtDateEnd.ChangeColorIfNotEmpty = true;
            this.txtDateEnd.ChangeColorOnEnter = true;
            this.txtDateEnd.Date = new System.DateTime(((long)(0)));
            this.txtDateEnd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateEnd.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateEnd.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateEnd.InsertInDatesTable = true;
            this.txtDateEnd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateEnd.Location = new System.Drawing.Point(405, 259);
            this.txtDateEnd.Mask = "0000/00/00";
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.NotEmpty = false;
            this.txtDateEnd.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateEnd.Size = new System.Drawing.Size(100, 23);
            this.txtDateEnd.TabIndex = 8;
            this.txtDateEnd.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // txtDateStart
            // 
            this.txtDateStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateStart.BackColor = System.Drawing.SystemColors.Info;
            this.txtDateStart.ChangeColorIfNotEmpty = true;
            this.txtDateStart.ChangeColorOnEnter = true;
            this.txtDateStart.Date = new System.DateTime(((long)(0)));
            this.txtDateStart.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateStart.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateStart.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateStart.InsertInDatesTable = true;
            this.txtDateStart.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateStart.Location = new System.Drawing.Point(405, 226);
            this.txtDateStart.Mask = "0000/00/00";
            this.txtDateStart.Name = "txtDateStart";
            this.txtDateStart.NotEmpty = false;
            this.txtDateStart.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateStart.Size = new System.Drawing.Size(100, 23);
            this.txtDateStart.TabIndex = 7;
            this.txtDateStart.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // txtEmpDate
            // 
            this.txtEmpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmpDate.BackColor = System.Drawing.SystemColors.Info;
            this.txtEmpDate.ChangeColorIfNotEmpty = true;
            this.txtEmpDate.ChangeColorOnEnter = true;
            this.txtEmpDate.Date = new System.DateTime(((long)(0)));
            this.txtEmpDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEmpDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEmpDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEmpDate.InsertInDatesTable = true;
            this.txtEmpDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEmpDate.Location = new System.Drawing.Point(405, 191);
            this.txtEmpDate.Mask = "0000/00/00";
            this.txtEmpDate.Name = "txtEmpDate";
            this.txtEmpDate.NotEmpty = false;
            this.txtEmpDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEmpDate.Size = new System.Drawing.Size(100, 23);
            this.txtEmpDate.TabIndex = 6;
            this.txtEmpDate.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(553, 289);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 62;
            this.label10.Text = "Desc:";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(58, 291);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(447, 84);
            this.txtDesc.TabIndex = 11;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(193, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 16);
            this.label9.TabIndex = 58;
            this.label9.Text = "ActivityType:";
            // 
            // cmbActivity
            // 
            this.cmbActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbActivity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbActivity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbActivity.BaseCode = 0;
            this.cmbActivity.ChangeColorIfNotEmpty = true;
            this.cmbActivity.ChangeColorOnEnter = true;
            this.cmbActivity.FormattingEnabled = true;
            this.cmbActivity.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbActivity.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbActivity.Location = new System.Drawing.Point(58, 194);
            this.cmbActivity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbActivity.Name = "cmbActivity";
            this.cmbActivity.NotEmpty = false;
            this.cmbActivity.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbActivity.SelectOnEnter = true;
            this.cmbActivity.Size = new System.Drawing.Size(121, 24);
            this.cmbActivity.TabIndex = 9;
            this.cmbActivity.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 54;
            this.label7.Text = "WorkShift:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(527, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 34;
            this.label6.Text = "StartDate:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(536, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "EndDate:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 42;
            this.label4.Text = "empDate:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(606, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rights&Permiums";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.jDataGrid2);
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 203);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(600, 201);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permiums";
            // 
            // jDataGrid2
            // 
            this.jDataGrid2.ActionMenu = jPopupMenu1;
            this.jDataGrid2.AllowUserToAddRows = false;
            this.jDataGrid2.AllowUserToDeleteRows = false;
            this.jDataGrid2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jDataGrid2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jDataGrid2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jDataGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jDataGrid2.EnableContexMenu = true;
            this.jDataGrid2.KeyName = null;
            this.jDataGrid2.Location = new System.Drawing.Point(3, 18);
            this.jDataGrid2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jDataGrid2.Name = "jDataGrid2";
            this.jDataGrid2.ReadHeadersFromDB = false;
            this.jDataGrid2.RegistryPath = "Software\\Microsoft Corporation\\Microsoft® Visual Studio® 2008\\GridSettings";
            this.jDataGrid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGrid2.ShowRowNumber = true;
            this.jDataGrid2.Size = new System.Drawing.Size(594, 143);
            this.jDataGrid2.TabIndex = 2;
            this.jDataGrid2.TableName = null;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 161);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(594, 38);
            this.panel4.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(553, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(588, 2);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 30);
            this.button3.TabIndex = 0;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.jDataGrid1);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(600, 201);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rights";
            // 
            // jDataGrid1
            // 
            this.jDataGrid1.ActionMenu = jPopupMenu2;
            this.jDataGrid1.AllowUserToAddRows = false;
            this.jDataGrid1.AllowUserToDeleteRows = false;
            this.jDataGrid1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.jDataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jDataGrid1.EnableContexMenu = true;
            this.jDataGrid1.KeyName = null;
            this.jDataGrid1.Location = new System.Drawing.Point(3, 18);
            this.jDataGrid1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jDataGrid1.Name = "jDataGrid1";
            this.jDataGrid1.ReadHeadersFromDB = false;
            this.jDataGrid1.RegistryPath = "Software\\Microsoft Corporation\\Microsoft® Visual Studio® 2008\\GridSettings";
            this.jDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGrid1.ShowRowNumber = true;
            this.jDataGrid1.Size = new System.Drawing.Size(594, 143);
            this.jDataGrid1.TabIndex = 2;
            this.jDataGrid1.TableName = null;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnAddRights);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 161);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(594, 38);
            this.panel3.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(553, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAddRights
            // 
            this.btnAddRights.Location = new System.Drawing.Point(588, 6);
            this.btnAddRights.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddRights.Name = "btnAddRights";
            this.btnAddRights.Size = new System.Drawing.Size(29, 30);
            this.btnAddRights.TabIndex = 0;
            this.btnAddRights.Text = "+";
            this.btnAddRights.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.JArchive);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(606, 385);
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
            this.JArchive.Location = new System.Drawing.Point(0, 0);
            this.JArchive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.JArchive.Name = "JArchive";
            this.JArchive.ObjectCode = 0;
            this.JArchive.ObjectCodes = null;
            this.JArchive.PlaceCode = 0;
            this.JArchive.Size = new System.Drawing.Size(606, 385);
            this.JArchive.SubjectCode = 0;
            this.JArchive.TabIndex = 0;
            // 
            // textEdit1
            // 
            this.textEdit1.ChangeColorIfNotEmpty = true;
            this.textEdit1.ChangeColorOnEnter = true;
            this.textEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.textEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.textEdit1.Location = new System.Drawing.Point(0, 0);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 169, 3, 169);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Negative = true;
            this.textEdit1.NotEmpty = false;
            this.textEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.textEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textEdit1.SelectOnEnter = true;
            this.textEdit1.Size = new System.Drawing.Size(606, 20);
            this.textEdit1.TabIndex = 3;
            this.textEdit1.TextMode = ClassLibrary.TextModes.Text;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(95, 489);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 15;
            this.btnSaveClose.Text = "ذخیره ";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNo);
            this.panel1.Controls.Add(this.txtContractDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 47);
            this.panel1.TabIndex = 0;
            // 
            // txtNo
            // 
            this.txtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNo.ChangeColorIfNotEmpty = true;
            this.txtNo.ChangeColorOnEnter = true;
            this.txtNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNo.Location = new System.Drawing.Point(407, 11);
            this.txtNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNo.Name = "txtNo";
            this.txtNo.Negative = true;
            this.txtNo.NotEmpty = false;
            this.txtNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNo.SelectOnEnter = true;
            this.txtNo.Size = new System.Drawing.Size(119, 23);
            this.txtNo.TabIndex = 1;
            this.txtNo.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtContractDate
            // 
            this.txtContractDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContractDate.BackColor = System.Drawing.SystemColors.Info;
            this.txtContractDate.ChangeColorIfNotEmpty = true;
            this.txtContractDate.ChangeColorOnEnter = true;
            this.txtContractDate.Date = new System.DateTime(((long)(0)));
            this.txtContractDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtContractDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtContractDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtContractDate.InsertInDatesTable = true;
            this.txtContractDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtContractDate.Location = new System.Drawing.Point(171, 11);
            this.txtContractDate.Mask = "0000/00/00";
            this.txtContractDate.Name = "txtContractDate";
            this.txtContractDate.NotEmpty = false;
            this.txtContractDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtContractDate.Size = new System.Drawing.Size(100, 23);
            this.txtContractDate.TabIndex = 2;
            this.txtContractDate.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 43;
            this.label3.Text = "ContractDate:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(537, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 41;
            this.label2.Text = "ContractNo:";
            // 
            // btnReContract
            // 
            this.btnReContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReContract.Enabled = false;
            this.btnReContract.Location = new System.Drawing.Point(176, 490);
            this.btnReContract.Name = "btnReContract";
            this.btnReContract.Size = new System.Drawing.Size(93, 24);
            this.btnReContract.TabIndex = 16;
            this.btnReContract.Text = "تمدید قرارداد";
            this.btnReContract.UseVisualStyleBackColor = true;
            this.btnReContract.Click += new System.EventHandler(this.btnReContract_Click);
            // 
            // JEContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 520);
            this.Controls.Add(this.btnReContract);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "JEContractForm";
            this.Text = "ContractForm";
            this.Load += new System.EventHandler(this.JEContractForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.JDataGrid jDataGrid2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private ClassLibrary.JDataGrid jDataGrid1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddRights;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private ClassLibrary.JComboBox cmbActivity;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage3;
        private ClassLibrary.TextEdit textEdit1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button btnExit;
        private ClassLibrary.DateEdit txtContractDate;
        private ClassLibrary.DateEdit txtDateEnd;
        private ClassLibrary.DateEdit txtDateStart;
        private ClassLibrary.DateEdit txtEmpDate;
        private ClassLibrary.JComboBox cmbWorkShift;
        private ClassLibrary.JUCPerson ComPerson;
        private ClassLibrary.TextEdit txtNo;
        private ArchivedDocuments.JArchiveList JArchive;
        private System.Windows.Forms.Button btnReContract;
    }
}