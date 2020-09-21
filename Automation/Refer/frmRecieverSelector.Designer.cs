namespace Automation.Refer
{
    partial class frmRecieverSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecieverSelector));
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNextNodes = new ClassLibrary.JComboBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescriptionSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgrDescription = new ClassLibrary.JDataGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtComment = new ClassLibrary.TextEdit(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chbUsers = new System.Windows.Forms.CheckedListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnGroupForm = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chbAll = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.jArchiveList1 = new ArchivedDocuments.JArchiveList();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnSeletGroup = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDescription)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.jArchiveList1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 407);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(866, 58);
            this.panel1.TabIndex = 44;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(717, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "ارجاع";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(6, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 40);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "بازگشت";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(0, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 21);
            this.label1.TabIndex = 47;
            this.label1.Text = "پست سازمانی:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbNextNodes
            // 
            this.cmbNextNodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNextNodes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbNextNodes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNextNodes.BaseCode = 0;
            this.cmbNextNodes.ChangeColorIfNotEmpty = true;
            this.cmbNextNodes.ChangeColorOnEnter = true;
            this.cmbNextNodes.FormattingEnabled = true;
            this.cmbNextNodes.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbNextNodes.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbNextNodes.Location = new System.Drawing.Point(3, 12);
            this.cmbNextNodes.Name = "cmbNextNodes";
            this.cmbNextNodes.NotEmpty = false;
            this.cmbNextNodes.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbNextNodes.SelectOnEnter = true;
            this.cmbNextNodes.Size = new System.Drawing.Size(341, 24);
            this.cmbNextNodes.TabIndex = 45;
            this.cmbNextNodes.SelectedIndexChanged += new System.EventHandler(this.cmbNextNodes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(341, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 21);
            this.label3.TabIndex = 47;
            this.label3.Text = "گروه ارسال:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescriptionSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgrDescription);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 358);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "متن ارجاع";
            // 
            // txtDescriptionSearch
            // 
            this.txtDescriptionSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescriptionSearch.Location = new System.Drawing.Point(6, 113);
            this.txtDescriptionSearch.Name = "txtDescriptionSearch";
            this.txtDescriptionSearch.Size = new System.Drawing.Size(414, 23);
            this.txtDescriptionSearch.TabIndex = 55;
            this.txtDescriptionSearch.TextChanged += new System.EventHandler(this.txtDescriptionSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(97, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(323, 21);
            this.label4.TabIndex = 54;
            this.label4.Text = "پر استفاده ترین متن ها توسط شما:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgrDescription
            // 
            this.dgrDescription.ActionMenu = jPopupMenu2;
            this.dgrDescription.AllowUserToAddRows = false;
            this.dgrDescription.AllowUserToDeleteRows = false;
            this.dgrDescription.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgrDescription.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrDescription.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrDescription.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrDescription.ContextMenuStrip = this.contextMenuStrip1;
            this.dgrDescription.EnableContexMenu = true;
            this.dgrDescription.KeyName = null;
            this.dgrDescription.Location = new System.Drawing.Point(6, 142);
            this.dgrDescription.Name = "dgrDescription";
            this.dgrDescription.ReadHeadersFromDB = false;
            this.dgrDescription.ReadOnly = true;
            this.dgrDescription.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgrDescription.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrDescription.ShowRowNumber = true;
            this.dgrDescription.Size = new System.Drawing.Size(414, 210);
            this.dgrDescription.TabIndex = 53;
            this.dgrDescription.TableName = null;
            this.dgrDescription.Click += new System.EventHandler(this.dgrDescription_Click);
            this.dgrDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgrDescription_KeyUp);
            this.dgrDescription.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgrDescription_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(100, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.toolStripMenuItem1.Text = "حذف";
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComment.ChangeColorIfNotEmpty = false;
            this.txtComment.ChangeColorOnEnter = true;
            this.txtComment.InBackColor = System.Drawing.SystemColors.Info;
            this.txtComment.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtComment.Location = new System.Drawing.Point(6, 25);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Negative = true;
            this.txtComment.NotEmpty = false;
            this.txtComment.NotEmptyColor = System.Drawing.Color.Red;
            this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtComment.SelectOnEnter = true;
            this.txtComment.Size = new System.Drawing.Size(414, 61);
            this.txtComment.TabIndex = 51;
            this.txtComment.TextMode = ClassLibrary.TextModes.Text;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.chbAll);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(429, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 358);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "گیرندگان";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chbUsers);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(39, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 269);
            this.panel2.TabIndex = 51;
            // 
            // chbUsers
            // 
            this.chbUsers.CheckOnClick = true;
            this.chbUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbUsers.FormattingEnabled = true;
            this.chbUsers.IntegralHeight = false;
            this.chbUsers.Location = new System.Drawing.Point(0, 23);
            this.chbUsers.Name = "chbUsers";
            this.chbUsers.Size = new System.Drawing.Size(384, 246);
            this.chbUsers.TabIndex = 48;
            this.chbUsers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chbUsers_ItemCheck);
            this.chbUsers.SelectedIndexChanged += new System.EventHandler(this.chbUsers_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(384, 23);
            this.txtSearch.TabIndex = 49;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSeletGroup);
            this.panel3.Controls.Add(this.btnDown);
            this.panel3.Controls.Add(this.btnGroupForm);
            this.panel3.Controls.Add(this.btnUp);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(36, 269);
            this.panel3.TabIndex = 52;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // btnDown
            // 
            this.btnDown.Image = global::Automation.Properties.Resources.Arrow_Down1;
            this.btnDown.Location = new System.Drawing.Point(5, 129);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(27, 23);
            this.btnDown.TabIndex = 0;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnGroupForm
            // 
            this.btnGroupForm.Image = global::Automation.Properties.Resources.eb_file_transfer;
            this.btnGroupForm.Location = new System.Drawing.Point(5, 6);
            this.btnGroupForm.Name = "btnGroupForm";
            this.btnGroupForm.Size = new System.Drawing.Size(27, 30);
            this.btnGroupForm.TabIndex = 0;
            this.btnGroupForm.UseVisualStyleBackColor = true;
            this.btnGroupForm.Click += new System.EventHandler(this.btnGroupForm_Click);
            // 
            // btnUp
            // 
            this.btnUp.Image = global::Automation.Properties.Resources.Arrow_Up1;
            this.btnUp.Location = new System.Drawing.Point(5, 95);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(27, 30);
            this.btnUp.TabIndex = 0;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkBox1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.cmbNextNodes);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(420, 67);
            this.panel4.TabIndex = 53;
            // 
            // chbAll
            // 
            this.chbAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbAll.AutoSize = true;
            this.chbAll.Location = new System.Drawing.Point(575, 99);
            this.chbAll.Name = "chbAll";
            this.chbAll.Size = new System.Drawing.Size(15, 14);
            this.chbAll.TabIndex = 50;
            this.chbAll.UseVisualStyleBackColor = true;
            this.chbAll.CheckedChanged += new System.EventHandler(this.chbAll_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 35);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(866, 407);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 53;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(858, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "گیرندگان";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.jArchiveList1);
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(858, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ضمائم";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.jArchiveList1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.jArchiveList1.Name = "jArchiveList1";
            this.jArchiveList1.ObjectCode = 0;
            this.jArchiveList1.ObjectCodes = null;
            this.jArchiveList1.PlaceCode = 0;
            this.jArchiveList1.Size = new System.Drawing.Size(852, 358);
            this.jArchiveList1.SubjectCode = 0;
            this.jArchiveList1.TabIndex = 3;
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDesc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(0, 0);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 21, 3, 21);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(852, 23);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            this.contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip2_ItemClicked);
            this.contextMenuStrip2.Click += new System.EventHandler(this.contextMenuStrip2_Click);
            // 
            // btnSeletGroup
            // 
            this.btnSeletGroup.Image = global::Automation.Properties.Resources.back28;
            this.btnSeletGroup.Location = new System.Drawing.Point(5, 42);
            this.btnSeletGroup.Name = "btnSeletGroup";
            this.btnSeletGroup.Size = new System.Drawing.Size(27, 30);
            this.btnSeletGroup.TabIndex = 1;
            this.btnSeletGroup.UseVisualStyleBackColor = true;
            this.btnSeletGroup.Click += new System.EventHandler(this.btnSeletGroup_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(402, 50);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 48;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmRecieverSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 465);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmRecieverSelector";
            this.Text = "دریافت کننده";
            this.Load += new System.EventHandler(this.frmRecieverSelector_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDescription)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.jArchiveList1.ResumeLayout(false);
            this.jArchiveList1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JComboBox cmbNextNodes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.JDataGrid dgrDescription;
        private ClassLibrary.TextEdit txtComment;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox chbUsers;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox chbAll;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ArchivedDocuments.JArchiveList jArchiveList1;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.TextBox txtDescriptionSearch;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnGroupForm;
        private System.Windows.Forms.Button btnSeletGroup;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}