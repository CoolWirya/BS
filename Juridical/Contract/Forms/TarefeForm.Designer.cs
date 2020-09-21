namespace Legal
{
    partial class JContractTarefeForm
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSumSahm = new System.Windows.Forms.Label();
            this.jucPersonBuy = new ClassLibrary.JUCPerson();
            this.lblTarefeBuy = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTarefeCode = new ClassLibrary.TextEdit(this.components);
            this.lblTarefeSell = new System.Windows.Forms.Label();
            this.jComboBox1 = new ClassLibrary.JComboBox(this.components);
            this.grpAdT1 = new System.Windows.Forms.GroupBox();
            this.btnDelAdSeller = new System.Windows.Forms.Button();
            this.btnAddDaSeller = new System.Windows.Forms.Button();
            this.jdgvAdSeller = new ClassLibrary.JDataGrid();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBuyers = new System.Windows.Forms.GroupBox();
            this.btnDelBuyer = new System.Windows.Forms.Button();
            this.btnAddBuyer = new System.Windows.Forms.Button();
            this.jdgvBuyer = new ClassLibrary.JDataGrid();
            this.grpAdT2 = new System.Windows.Forms.GroupBox();
            this.btnDelAdBuyer = new System.Windows.Forms.Button();
            this.btnAddAdBuyer = new System.Windows.Forms.Button();
            this.jdgvAdBuyer = new ClassLibrary.JDataGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtUsage = new ClassLibrary.TextEdit(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArea = new ClassLibrary.TextEdit(this.components);
            this.txtMainAve = new ClassLibrary.TextEdit(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtSubAve = new ClassLibrary.TextEdit(this.components);
            this.txtBlockNum = new ClassLibrary.TextEdit(this.components);
            this.txtPartNum = new ClassLibrary.TextEdit(this.components);
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grpAdT1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvAdSeller)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBuyers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvBuyer)).BeginInit();
            this.grpAdT2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvAdBuyer)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(115, 490);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "قبلی";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(467, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(34, 490);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "بعدی";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSumSahm);
            this.groupBox1.Controls.Add(this.jucPersonBuy);
            this.groupBox1.Controls.Add(this.lblTarefeBuy);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 289);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " تعرفه خرید";
            // 
            // lblSumSahm
            // 
            this.lblSumSahm.AutoSize = true;
            this.lblSumSahm.BackColor = System.Drawing.Color.White;
            this.lblSumSahm.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumSahm.ForeColor = System.Drawing.Color.Red;
            this.lblSumSahm.Location = new System.Drawing.Point(25, 27);
            this.lblSumSahm.Name = "lblSumSahm";
            this.lblSumSahm.Size = new System.Drawing.Size(16, 19);
            this.lblSumSahm.TabIndex = 47;
            this.lblSumSahm.Text = "-";
            // 
            // jucPersonBuy
            // 
            this.jucPersonBuy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.jucPersonBuy.FilterPerson = null;
            this.jucPersonBuy.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.jucPersonBuy.LableGroup = null;
            this.jucPersonBuy.Location = new System.Drawing.Point(3, 65);
            this.jucPersonBuy.Name = "jucPersonBuy";
            this.jucPersonBuy.PersonType = ClassLibrary.JPersonTypes.None;
            this.jucPersonBuy.ReadOnly = true;
            this.jucPersonBuy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.jucPersonBuy.SelectedCode = 0;
            this.jucPersonBuy.Size = new System.Drawing.Size(554, 221);
            this.jucPersonBuy.TabIndex = 12;
            // 
            // lblTarefeBuy
            // 
            this.lblTarefeBuy.AutoSize = true;
            this.lblTarefeBuy.BackColor = System.Drawing.Color.White;
            this.lblTarefeBuy.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTarefeBuy.ForeColor = System.Drawing.Color.Red;
            this.lblTarefeBuy.Location = new System.Drawing.Point(522, 29);
            this.lblTarefeBuy.Name = "lblTarefeBuy";
            this.lblTarefeBuy.Size = new System.Drawing.Size(16, 19);
            this.lblTarefeBuy.TabIndex = 11;
            this.lblTarefeBuy.Text = "-";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(574, 324);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.txtTarefeCode);
            this.tabPage3.Controls.Add(this.lblTarefeSell);
            this.tabPage3.Controls.Add(this.jComboBox1);
            this.tabPage3.Controls.Add(this.grpAdT1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(566, 295);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "تعرفه فروش";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(486, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "کد تعرفه :";
            // 
            // txtTarefeCode
            // 
            this.txtTarefeCode.ChangeColorIfNotEmpty = false;
            this.txtTarefeCode.ChangeColorOnEnter = true;
            this.txtTarefeCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTarefeCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTarefeCode.Location = new System.Drawing.Point(380, 9);
            this.txtTarefeCode.Name = "txtTarefeCode";
            this.txtTarefeCode.Negative = true;
            this.txtTarefeCode.NotEmpty = false;
            this.txtTarefeCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTarefeCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTarefeCode.SelectOnEnter = true;
            this.txtTarefeCode.Size = new System.Drawing.Size(100, 23);
            this.txtTarefeCode.TabIndex = 14;
            this.txtTarefeCode.TextMode = ClassLibrary.TextModes.Integer;
            this.txtTarefeCode.Leave += new System.EventHandler(this.txtTarefeCode_Leave);
            // 
            // lblTarefeSell
            // 
            this.lblTarefeSell.AutoSize = true;
            this.lblTarefeSell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTarefeSell.ForeColor = System.Drawing.Color.Red;
            this.lblTarefeSell.Location = new System.Drawing.Point(505, 88);
            this.lblTarefeSell.Name = "lblTarefeSell";
            this.lblTarefeSell.Size = new System.Drawing.Size(16, 19);
            this.lblTarefeSell.TabIndex = 13;
            this.lblTarefeSell.Text = "-";
            // 
            // jComboBox1
            // 
            this.jComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.jComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.jComboBox1.BackColor = System.Drawing.SystemColors.Info;
            this.jComboBox1.BaseCode = 0;
            this.jComboBox1.ChangeColorIfNotEmpty = true;
            this.jComboBox1.ChangeColorOnEnter = true;
            this.jComboBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.jComboBox1.FormattingEnabled = true;
            this.jComboBox1.InBackColor = System.Drawing.SystemColors.Info;
            this.jComboBox1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.jComboBox1.Location = new System.Drawing.Point(103, 46);
            this.jComboBox1.Name = "jComboBox1";
            this.jComboBox1.NotEmpty = false;
            this.jComboBox1.NotEmptyColor = System.Drawing.Color.Red;
            this.jComboBox1.SelectOnEnter = true;
            this.jComboBox1.Size = new System.Drawing.Size(441, 24);
            this.jComboBox1.TabIndex = 12;
            this.jComboBox1.SelectedIndexChanged += new System.EventHandler(this.jComboBox1_SelectedIndexChanged);
            // 
            // grpAdT1
            // 
            this.grpAdT1.Controls.Add(this.btnDelAdSeller);
            this.grpAdT1.Controls.Add(this.btnAddDaSeller);
            this.grpAdT1.Controls.Add(this.jdgvAdSeller);
            this.grpAdT1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpAdT1.Location = new System.Drawing.Point(3, 119);
            this.grpAdT1.Name = "grpAdT1";
            this.grpAdT1.Size = new System.Drawing.Size(560, 173);
            this.grpAdT1.TabIndex = 11;
            this.grpAdT1.TabStop = false;
            this.grpAdT1.Text = "وکیل ";
            // 
            // btnDelAdSeller
            // 
            this.btnDelAdSeller.Location = new System.Drawing.Point(400, 142);
            this.btnDelAdSeller.Name = "btnDelAdSeller";
            this.btnDelAdSeller.Size = new System.Drawing.Size(75, 23);
            this.btnDelAdSeller.TabIndex = 7;
            this.btnDelAdSeller.Text = "حذف";
            this.btnDelAdSeller.UseVisualStyleBackColor = true;
            this.btnDelAdSeller.Click += new System.EventHandler(this.btnDelAdSeller_Click);
            // 
            // btnAddDaSeller
            // 
            this.btnAddDaSeller.Location = new System.Drawing.Point(481, 142);
            this.btnAddDaSeller.Name = "btnAddDaSeller";
            this.btnAddDaSeller.Size = new System.Drawing.Size(75, 23);
            this.btnAddDaSeller.TabIndex = 5;
            this.btnAddDaSeller.Text = "اضافه ";
            this.btnAddDaSeller.UseVisualStyleBackColor = true;
            this.btnAddDaSeller.Click += new System.EventHandler(this.btnAddDaSeller_Click);
            // 
            // jdgvAdSeller
            // 
            this.jdgvAdSeller.ActionMenu = jPopupMenu1;
            this.jdgvAdSeller.AllowUserToAddRows = false;
            this.jdgvAdSeller.AllowUserToDeleteRows = false;
            this.jdgvAdSeller.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jdgvAdSeller.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jdgvAdSeller.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvAdSeller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvAdSeller.Dock = System.Windows.Forms.DockStyle.Top;
            this.jdgvAdSeller.EnableContexMenu = true;
            this.jdgvAdSeller.KeyName = null;
            this.jdgvAdSeller.Location = new System.Drawing.Point(3, 19);
            this.jdgvAdSeller.Name = "jdgvAdSeller";
            this.jdgvAdSeller.ReadHeadersFromDB = false;
            this.jdgvAdSeller.ReadOnly = true;
            this.jdgvAdSeller.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvAdSeller.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvAdSeller.ShowRowNumber = true;
            this.jdgvAdSeller.Size = new System.Drawing.Size(554, 109);
            this.jdgvAdSeller.TabIndex = 6;
            this.jdgvAdSeller.TableName = null;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(566, 295);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "تعرفه خرید";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBuyers);
            this.tabPage2.Controls.Add(this.grpAdT2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(566, 295);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "خریدار";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBuyers
            // 
            this.groupBuyers.Controls.Add(this.btnDelBuyer);
            this.groupBuyers.Controls.Add(this.btnAddBuyer);
            this.groupBuyers.Controls.Add(this.jdgvBuyer);
            this.groupBuyers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBuyers.Location = new System.Drawing.Point(3, 3);
            this.groupBuyers.Name = "groupBuyers";
            this.groupBuyers.Size = new System.Drawing.Size(560, 169);
            this.groupBuyers.TabIndex = 4;
            this.groupBuyers.TabStop = false;
            this.groupBuyers.Text = "اشخاص حقیقی / حقوقی";
            // 
            // btnDelBuyer
            // 
            this.btnDelBuyer.Location = new System.Drawing.Point(402, 140);
            this.btnDelBuyer.Name = "btnDelBuyer";
            this.btnDelBuyer.Size = new System.Drawing.Size(75, 23);
            this.btnDelBuyer.TabIndex = 11;
            this.btnDelBuyer.Text = "حذف";
            this.btnDelBuyer.UseVisualStyleBackColor = true;
            this.btnDelBuyer.Click += new System.EventHandler(this.btnDelBuyer_Click);
            // 
            // btnAddBuyer
            // 
            this.btnAddBuyer.Location = new System.Drawing.Point(483, 139);
            this.btnAddBuyer.Name = "btnAddBuyer";
            this.btnAddBuyer.Size = new System.Drawing.Size(75, 23);
            this.btnAddBuyer.TabIndex = 9;
            this.btnAddBuyer.Text = "اضافه ";
            this.btnAddBuyer.UseVisualStyleBackColor = true;
            this.btnAddBuyer.Click += new System.EventHandler(this.jdgvAddBuyer_Click);
            // 
            // jdgvBuyer
            // 
            this.jdgvBuyer.ActionMenu = jPopupMenu2;
            this.jdgvBuyer.AllowUserToAddRows = false;
            this.jdgvBuyer.AllowUserToDeleteRows = false;
            this.jdgvBuyer.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jdgvBuyer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
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
            this.jdgvBuyer.Size = new System.Drawing.Size(554, 115);
            this.jdgvBuyer.TabIndex = 10;
            this.jdgvBuyer.TableName = null;
            // 
            // grpAdT2
            // 
            this.grpAdT2.Controls.Add(this.btnDelAdBuyer);
            this.grpAdT2.Controls.Add(this.btnAddAdBuyer);
            this.grpAdT2.Controls.Add(this.jdgvAdBuyer);
            this.grpAdT2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpAdT2.Location = new System.Drawing.Point(3, 172);
            this.grpAdT2.Name = "grpAdT2";
            this.grpAdT2.Size = new System.Drawing.Size(560, 120);
            this.grpAdT2.TabIndex = 3;
            this.grpAdT2.TabStop = false;
            this.grpAdT2.Text = "وکیل ";
            // 
            // btnDelAdBuyer
            // 
            this.btnDelAdBuyer.Location = new System.Drawing.Point(402, 88);
            this.btnDelAdBuyer.Name = "btnDelAdBuyer";
            this.btnDelAdBuyer.Size = new System.Drawing.Size(75, 23);
            this.btnDelAdBuyer.TabIndex = 14;
            this.btnDelAdBuyer.Text = "حذف";
            this.btnDelAdBuyer.UseVisualStyleBackColor = true;
            this.btnDelAdBuyer.Click += new System.EventHandler(this.btnDelAdBuyer_Click);
            // 
            // btnAddAdBuyer
            // 
            this.btnAddAdBuyer.Location = new System.Drawing.Point(479, 88);
            this.btnAddAdBuyer.Name = "btnAddAdBuyer";
            this.btnAddAdBuyer.Size = new System.Drawing.Size(75, 23);
            this.btnAddAdBuyer.TabIndex = 12;
            this.btnAddAdBuyer.Text = "اضافه ";
            this.btnAddAdBuyer.UseVisualStyleBackColor = true;
            this.btnAddAdBuyer.Click += new System.EventHandler(this.btnAddAdBuyer_Click);
            // 
            // jdgvAdBuyer
            // 
            this.jdgvAdBuyer.ActionMenu = jPopupMenu3;
            this.jdgvAdBuyer.AllowUserToAddRows = false;
            this.jdgvAdBuyer.AllowUserToDeleteRows = false;
            this.jdgvAdBuyer.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jdgvAdBuyer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.jdgvAdBuyer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvAdBuyer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvAdBuyer.Dock = System.Windows.Forms.DockStyle.Top;
            this.jdgvAdBuyer.EnableContexMenu = true;
            this.jdgvAdBuyer.KeyName = null;
            this.jdgvAdBuyer.Location = new System.Drawing.Point(3, 19);
            this.jdgvAdBuyer.Name = "jdgvAdBuyer";
            this.jdgvAdBuyer.ReadHeadersFromDB = false;
            this.jdgvAdBuyer.ReadOnly = true;
            this.jdgvAdBuyer.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvAdBuyer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvAdBuyer.ShowRowNumber = true;
            this.jdgvAdBuyer.Size = new System.Drawing.Size(554, 63);
            this.jdgvAdBuyer.TabIndex = 13;
            this.jdgvAdBuyer.TableName = null;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtUsage);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtArea);
            this.groupBox3.Controls.Add(this.txtMainAve);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.txtSubAve);
            this.groupBox3.Controls.Add(this.txtBlockNum);
            this.groupBox3.Controls.Add(this.txtPartNum);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(574, 157);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "اطلاعات زمین";
            // 
            // txtUsage
            // 
            this.txtUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsage.ChangeColorIfNotEmpty = true;
            this.txtUsage.ChangeColorOnEnter = true;
            this.txtUsage.InBackColor = System.Drawing.SystemColors.Info;
            this.txtUsage.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUsage.Location = new System.Drawing.Point(35, 88);
            this.txtUsage.Name = "txtUsage";
            this.txtUsage.Negative = true;
            this.txtUsage.NotEmpty = false;
            this.txtUsage.NotEmptyColor = System.Drawing.Color.Red;
            this.txtUsage.ReadOnly = true;
            this.txtUsage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUsage.SelectOnEnter = true;
            this.txtUsage.Size = new System.Drawing.Size(148, 23);
            this.txtUsage.TabIndex = 49;
            this.txtUsage.TextMode = ClassLibrary.TextModes.Real;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(479, 91);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 16);
            this.label17.TabIndex = 41;
            this.label17.Text = "شماره بلوک:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(486, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 40;
            this.label8.Text = "پلاک اصلی:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(486, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "پلاک فرعی:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(479, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "شماره قطعه:";
            // 
            // txtArea
            // 
            this.txtArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArea.ChangeColorIfNotEmpty = true;
            this.txtArea.ChangeColorOnEnter = true;
            this.txtArea.InBackColor = System.Drawing.SystemColors.Info;
            this.txtArea.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtArea.Location = new System.Drawing.Point(35, 125);
            this.txtArea.Name = "txtArea";
            this.txtArea.Negative = true;
            this.txtArea.NotEmpty = false;
            this.txtArea.NotEmptyColor = System.Drawing.Color.Red;
            this.txtArea.ReadOnly = true;
            this.txtArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtArea.SelectOnEnter = true;
            this.txtArea.Size = new System.Drawing.Size(148, 23);
            this.txtArea.TabIndex = 46;
            this.txtArea.TextMode = ClassLibrary.TextModes.Real;
            // 
            // txtMainAve
            // 
            this.txtMainAve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMainAve.ChangeColorIfNotEmpty = true;
            this.txtMainAve.ChangeColorOnEnter = true;
            this.txtMainAve.InBackColor = System.Drawing.SystemColors.Info;
            this.txtMainAve.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMainAve.Location = new System.Drawing.Point(35, 16);
            this.txtMainAve.Name = "txtMainAve";
            this.txtMainAve.Negative = true;
            this.txtMainAve.NotEmpty = true;
            this.txtMainAve.NotEmptyColor = System.Drawing.Color.Red;
            this.txtMainAve.ReadOnly = true;
            this.txtMainAve.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMainAve.SelectOnEnter = true;
            this.txtMainAve.Size = new System.Drawing.Size(431, 23);
            this.txtMainAve.TabIndex = 34;
            this.txtMainAve.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(196, 128);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 16);
            this.label20.TabIndex = 48;
            this.label20.Text = "مساحت:";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(207, 92);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 16);
            this.label21.TabIndex = 47;
            this.label21.Text = "کاربری:";
            // 
            // txtSubAve
            // 
            this.txtSubAve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubAve.ChangeColorIfNotEmpty = true;
            this.txtSubAve.ChangeColorOnEnter = true;
            this.txtSubAve.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSubAve.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubAve.Location = new System.Drawing.Point(35, 52);
            this.txtSubAve.Name = "txtSubAve";
            this.txtSubAve.Negative = true;
            this.txtSubAve.NotEmpty = true;
            this.txtSubAve.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSubAve.ReadOnly = true;
            this.txtSubAve.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubAve.SelectOnEnter = true;
            this.txtSubAve.Size = new System.Drawing.Size(433, 23);
            this.txtSubAve.TabIndex = 35;
            this.txtSubAve.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtBlockNum
            // 
            this.txtBlockNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlockNum.ChangeColorIfNotEmpty = true;
            this.txtBlockNum.ChangeColorOnEnter = true;
            this.txtBlockNum.InBackColor = System.Drawing.SystemColors.Info;
            this.txtBlockNum.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBlockNum.Location = new System.Drawing.Point(266, 88);
            this.txtBlockNum.Name = "txtBlockNum";
            this.txtBlockNum.Negative = true;
            this.txtBlockNum.NotEmpty = false;
            this.txtBlockNum.NotEmptyColor = System.Drawing.Color.Red;
            this.txtBlockNum.ReadOnly = true;
            this.txtBlockNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBlockNum.SelectOnEnter = true;
            this.txtBlockNum.Size = new System.Drawing.Size(200, 23);
            this.txtBlockNum.TabIndex = 37;
            this.txtBlockNum.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtPartNum
            // 
            this.txtPartNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartNum.ChangeColorIfNotEmpty = true;
            this.txtPartNum.ChangeColorOnEnter = true;
            this.txtPartNum.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPartNum.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPartNum.Location = new System.Drawing.Point(266, 124);
            this.txtPartNum.Name = "txtPartNum";
            this.txtPartNum.Negative = true;
            this.txtPartNum.NotEmpty = false;
            this.txtPartNum.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPartNum.ReadOnly = true;
            this.txtPartNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPartNum.SelectOnEnter = true;
            this.txtPartNum.Size = new System.Drawing.Size(200, 23);
            this.txtPartNum.TabIndex = 38;
            this.txtPartNum.TextMode = ClassLibrary.TextModes.Text;
            // 
            // JContractTarefeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 525);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Name = "JContractTarefeForm";
            this.Text = "TarefeForm";
            this.Load += new System.EventHandler(this.JContractTarefeForm_Load);
            this.VisibleChanged += new System.EventHandler(this.JContractTarefeForm_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.grpAdT1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvAdSeller)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBuyers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvBuyer)).EndInit();
            this.grpAdT2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvAdBuyer)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBuyers;
        private ClassLibrary.JDataGrid jdgvBuyer;
        private System.Windows.Forms.GroupBox grpAdT2;
        private System.Windows.Forms.Button btnDelAdBuyer;
        private System.Windows.Forms.Button btnAddAdBuyer;
        private ClassLibrary.JDataGrid jdgvAdBuyer;
        private System.Windows.Forms.Button btnDelBuyer;
        private System.Windows.Forms.Button btnAddBuyer;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblTarefeBuy;
        private System.Windows.Forms.GroupBox grpAdT1;
        private System.Windows.Forms.Button btnDelAdSeller;
        private System.Windows.Forms.Button btnAddDaSeller;
        private ClassLibrary.JDataGrid jdgvAdSeller;
        private ClassLibrary.JComboBox jComboBox1;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtTarefeCode;
        private System.Windows.Forms.Label lblTarefeSell;
        private ClassLibrary.JUCPerson jucPersonBuy;
        private System.Windows.Forms.Label lblSumSahm;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.TextEdit txtUsage;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtArea;
        public ClassLibrary.TextEdit txtMainAve;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private ClassLibrary.TextEdit txtSubAve;
        private ClassLibrary.TextEdit txtBlockNum;
        private ClassLibrary.TextEdit txtPartNum;
    }
}