namespace Legal
{
    partial class JDistraintForm
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
            this.tabTotal = new System.Windows.Forms.TabControl();
            this.tabDistratint = new System.Windows.Forms.TabPage();
            this.gbxOrder = new System.Windows.Forms.GroupBox();
            this.txtOrderComment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrderSender = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbxDesion = new System.Windows.Forms.GroupBox();
            this.txtSummaryJudgement = new ClassLibrary.TextEdit(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.txtCommittalCode = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.radDecision = new System.Windows.Forms.RadioButton();
            this.radOrder = new System.Windows.Forms.RadioButton();
            this.tabPerson = new System.Windows.Forms.TabPage();
            this.FindPerson = new ClassLibrary.JUCPerson();
            this.tabAsset = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dgvAssetOwner = new ClassLibrary.JDataGrid();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnDelAsset = new System.Windows.Forms.Button();
            this.lbAssetDesc = new System.Windows.Forms.Label();
            this.txtAssetType = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtAssetCode = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btmSearchAsset = new System.Windows.Forms.Button();
            this.tabAssetShare = new System.Windows.Forms.TabPage();
            this.dgvAssetShare = new ClassLibrary.JDataGrid();
            this.FindPerson2 = new ClassLibrary.JUCPerson();
            this.tabUnDist = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtUnDesc = new ClassLibrary.TextEdit(this.components);
            this.grpUnOrder = new System.Windows.Forms.GroupBox();
            this.txtUnOrderDesc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUnOrderSender = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grpUnDecision = new System.Windows.Forms.GroupBox();
            this.txtUnDecisionDesc = new ClassLibrary.TextEdit(this.components);
            this.btnUndist = new System.Windows.Forms.Button();
            this.txtUnDecisionCode = new ClassLibrary.TextEdit(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDateUn = new ClassLibrary.DateEdit(this.components);
            this.rbUnDecision = new System.Windows.Forms.RadioButton();
            this.rbUnOrder = new System.Windows.Forms.RadioButton();
            this.TabDistDesc = new System.Windows.Forms.TabPage();
            this.txtComment = new ClassLibrary.TextEdit(this.components);
            this.tabImages = new System.Windows.Forms.TabPage();
            this.jArchiveList = new ArchivedDocuments.JArchiveList();
            this.SaveDistraint = new System.Windows.Forms.Button();
            this.grpDistType = new System.Windows.Forms.GroupBox();
            this.radPerson = new System.Windows.Forms.RadioButton();
            this.radAsset = new System.Windows.Forms.RadioButton();
            this.radPartAsset = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.tabTotal.SuspendLayout();
            this.tabDistratint.SuspendLayout();
            this.gbxOrder.SuspendLayout();
            this.gbxDesion.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPerson.SuspendLayout();
            this.tabAsset.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssetOwner)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.tabAssetShare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssetShare)).BeginInit();
            this.tabUnDist.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.grpUnOrder.SuspendLayout();
            this.grpUnDecision.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.TabDistDesc.SuspendLayout();
            this.tabImages.SuspendLayout();
            this.grpDistType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTotal
            // 
            this.tabTotal.Controls.Add(this.tabDistratint);
            this.tabTotal.Controls.Add(this.tabPerson);
            this.tabTotal.Controls.Add(this.tabAsset);
            this.tabTotal.Controls.Add(this.tabAssetShare);
            this.tabTotal.Controls.Add(this.tabUnDist);
            this.tabTotal.Controls.Add(this.TabDistDesc);
            this.tabTotal.Controls.Add(this.tabImages);
            this.tabTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTotal.Location = new System.Drawing.Point(3, 19);
            this.tabTotal.Name = "tabTotal";
            this.tabTotal.RightToLeftLayout = true;
            this.tabTotal.SelectedIndex = 0;
            this.tabTotal.Size = new System.Drawing.Size(514, 516);
            this.tabTotal.TabIndex = 3;
            // 
            // tabDistratint
            // 
            this.tabDistratint.Controls.Add(this.gbxOrder);
            this.tabDistratint.Controls.Add(this.gbxDesion);
            this.tabDistratint.Controls.Add(this.groupBox3);
            this.tabDistratint.Location = new System.Drawing.Point(4, 25);
            this.tabDistratint.Name = "tabDistratint";
            this.tabDistratint.Padding = new System.Windows.Forms.Padding(3);
            this.tabDistratint.Size = new System.Drawing.Size(506, 487);
            this.tabDistratint.TabIndex = 0;
            this.tabDistratint.Text = "حکم توقیف";
            this.tabDistratint.UseVisualStyleBackColor = true;
            // 
            // gbxOrder
            // 
            this.gbxOrder.Controls.Add(this.txtOrderComment);
            this.gbxOrder.Controls.Add(this.label5);
            this.gbxOrder.Controls.Add(this.txtOrderSender);
            this.gbxOrder.Controls.Add(this.label4);
            this.gbxOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxOrder.Location = new System.Drawing.Point(3, 237);
            this.gbxOrder.Name = "gbxOrder";
            this.gbxOrder.Size = new System.Drawing.Size(500, 151);
            this.gbxOrder.TabIndex = 30;
            this.gbxOrder.TabStop = false;
            this.gbxOrder.Text = "مشخصات دستور:";
            this.gbxOrder.Visible = false;
            // 
            // txtOrderComment
            // 
            this.txtOrderComment.Location = new System.Drawing.Point(7, 63);
            this.txtOrderComment.Multiline = true;
            this.txtOrderComment.Name = "txtOrderComment";
            this.txtOrderComment.Size = new System.Drawing.Size(335, 72);
            this.txtOrderComment.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "متن دستور:";
            // 
            // txtOrderSender
            // 
            this.txtOrderSender.Location = new System.Drawing.Point(70, 27);
            this.txtOrderSender.Name = "txtOrderSender";
            this.txtOrderSender.Size = new System.Drawing.Size(271, 23);
            this.txtOrderSender.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "مرجع صادر کننده:";
            // 
            // gbxDesion
            // 
            this.gbxDesion.Controls.Add(this.txtSummaryJudgement);
            this.gbxDesion.Controls.Add(this.button3);
            this.gbxDesion.Controls.Add(this.txtCommittalCode);
            this.gbxDesion.Controls.Add(this.label3);
            this.gbxDesion.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxDesion.Location = new System.Drawing.Point(3, 64);
            this.gbxDesion.Name = "gbxDesion";
            this.gbxDesion.Size = new System.Drawing.Size(500, 173);
            this.gbxDesion.TabIndex = 9;
            this.gbxDesion.TabStop = false;
            this.gbxDesion.Text = "مشخصات رای دادگاه";
            // 
            // txtSummaryJudgement
            // 
            this.txtSummaryJudgement.ChangeColorIfNotEmpty = false;
            this.txtSummaryJudgement.ChangeColorOnEnter = true;
            this.txtSummaryJudgement.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSummaryJudgement.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSummaryJudgement.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSummaryJudgement.Location = new System.Drawing.Point(3, 63);
            this.txtSummaryJudgement.Multiline = true;
            this.txtSummaryJudgement.Name = "txtSummaryJudgement";
            this.txtSummaryJudgement.Negative = true;
            this.txtSummaryJudgement.NotEmpty = false;
            this.txtSummaryJudgement.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSummaryJudgement.ReadOnly = true;
            this.txtSummaryJudgement.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSummaryJudgement.SelectOnEnter = true;
            this.txtSummaryJudgement.Size = new System.Drawing.Size(494, 107);
            this.txtSummaryJudgement.TabIndex = 28;
            this.txtSummaryJudgement.TextMode = ClassLibrary.TextModes.Text;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(142, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "جستجو";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtCommittalCode
            // 
            this.txtCommittalCode.ChangeColorIfNotEmpty = false;
            this.txtCommittalCode.ChangeColorOnEnter = true;
            this.txtCommittalCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCommittalCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCommittalCode.Location = new System.Drawing.Point(236, 34);
            this.txtCommittalCode.Name = "txtCommittalCode";
            this.txtCommittalCode.Negative = true;
            this.txtCommittalCode.NotEmpty = false;
            this.txtCommittalCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCommittalCode.ReadOnly = true;
            this.txtCommittalCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCommittalCode.SelectOnEnter = true;
            this.txtCommittalCode.Size = new System.Drawing.Size(140, 23);
            this.txtCommittalCode.TabIndex = 27;
            this.txtCommittalCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "کد رای:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtDate);
            this.groupBox3.Controls.Add(this.radDecision);
            this.groupBox3.Controls.Add(this.radOrder);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(500, 61);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(381, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "تاریخ توقیف:";
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
            this.txtDate.Location = new System.Drawing.Point(276, 16);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 2;
            // 
            // radDecision
            // 
            this.radDecision.AutoSize = true;
            this.radDecision.Checked = true;
            this.radDecision.Location = new System.Drawing.Point(130, 9);
            this.radDecision.Name = "radDecision";
            this.radDecision.Size = new System.Drawing.Size(51, 20);
            this.radDecision.TabIndex = 1;
            this.radDecision.TabStop = true;
            this.radDecision.Text = "حکم";
            this.radDecision.UseVisualStyleBackColor = true;
            this.radDecision.Click += new System.EventHandler(this.radDecision_Click);
            // 
            // radOrder
            // 
            this.radOrder.AutoSize = true;
            this.radOrder.Location = new System.Drawing.Point(120, 35);
            this.radOrder.Name = "radOrder";
            this.radOrder.Size = new System.Drawing.Size(61, 20);
            this.radOrder.TabIndex = 0;
            this.radOrder.TabStop = true;
            this.radOrder.Text = "دستور";
            this.radOrder.UseVisualStyleBackColor = true;
            this.radOrder.Click += new System.EventHandler(this.radOrder_Click);
            // 
            // tabPerson
            // 
            this.tabPerson.Controls.Add(this.FindPerson);
            this.tabPerson.Location = new System.Drawing.Point(4, 25);
            this.tabPerson.Name = "tabPerson";
            this.tabPerson.Padding = new System.Windows.Forms.Padding(3);
            this.tabPerson.Size = new System.Drawing.Size(506, 487);
            this.tabPerson.TabIndex = 1;
            this.tabPerson.Text = "شخص";
            this.tabPerson.UseVisualStyleBackColor = true;
            // 
            // FindPerson
            // 
            this.FindPerson.Dock = System.Windows.Forms.DockStyle.Top;
            this.FindPerson.FilterPerson = null;
            this.FindPerson.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FindPerson.LableGroup = null;
            this.FindPerson.Location = new System.Drawing.Point(3, 3);
            this.FindPerson.Name = "FindPerson";
            this.FindPerson.PersonType = ClassLibrary.JPersonTypes.None;
            this.FindPerson.ReadOnly = false;
            this.FindPerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FindPerson.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.FindPerson.SelectedCode = 0;
            this.FindPerson.Size = new System.Drawing.Size(500, 182);
            this.FindPerson.TabIndex = 0;
            this.FindPerson.TafsiliCode = false;
            // 
            // tabAsset
            // 
            this.tabAsset.Controls.Add(this.groupBox8);
            this.tabAsset.Controls.Add(this.groupBox9);
            this.tabAsset.Location = new System.Drawing.Point(4, 25);
            this.tabAsset.Name = "tabAsset";
            this.tabAsset.Padding = new System.Windows.Forms.Padding(3);
            this.tabAsset.Size = new System.Drawing.Size(506, 487);
            this.tabAsset.TabIndex = 2;
            this.tabAsset.Text = "دارائی";
            this.tabAsset.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dgvAssetOwner);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(3, 98);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(500, 386);
            this.groupBox8.TabIndex = 11;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "مشخصات مالکین:";
            // 
            // dgvAssetOwner
            // 
            this.dgvAssetOwner.ActionMenu = jPopupMenu1;
            this.dgvAssetOwner.AllowUserToAddRows = false;
            this.dgvAssetOwner.AllowUserToDeleteRows = false;
            this.dgvAssetOwner.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgvAssetOwner.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAssetOwner.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAssetOwner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssetOwner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAssetOwner.EnableContexMenu = true;
            this.dgvAssetOwner.KeyName = null;
            this.dgvAssetOwner.Location = new System.Drawing.Point(3, 19);
            this.dgvAssetOwner.Name = "dgvAssetOwner";
            this.dgvAssetOwner.ReadHeadersFromDB = false;
            this.dgvAssetOwner.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgvAssetOwner.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssetOwner.ShowRowNumber = true;
            this.dgvAssetOwner.Size = new System.Drawing.Size(494, 364);
            this.dgvAssetOwner.TabIndex = 10;
            this.dgvAssetOwner.TableName = null;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnDelAsset);
            this.groupBox9.Controls.Add(this.lbAssetDesc);
            this.groupBox9.Controls.Add(this.txtAssetType);
            this.groupBox9.Controls.Add(this.label1);
            this.groupBox9.Controls.Add(this.txtAssetCode);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.btmSearchAsset);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox9.Location = new System.Drawing.Point(3, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(500, 95);
            this.groupBox9.TabIndex = 10;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "مشخصاات دارائی";
            // 
            // btnDelAsset
            // 
            this.btnDelAsset.Location = new System.Drawing.Point(194, 28);
            this.btnDelAsset.Name = "btnDelAsset";
            this.btnDelAsset.Size = new System.Drawing.Size(17, 23);
            this.btnDelAsset.TabIndex = 10;
            this.btnDelAsset.Text = "-";
            this.btnDelAsset.UseVisualStyleBackColor = true;
            this.btnDelAsset.Click += new System.EventHandler(this.btnDelAsset_Click);
            // 
            // lbAssetDesc
            // 
            this.lbAssetDesc.Location = new System.Drawing.Point(19, 59);
            this.lbAssetDesc.Name = "lbAssetDesc";
            this.lbAssetDesc.Size = new System.Drawing.Size(457, 27);
            this.lbAssetDesc.TabIndex = 9;
            this.lbAssetDesc.Text = "دارایی";
            // 
            // txtAssetType
            // 
            this.txtAssetType.ChangeColorIfNotEmpty = false;
            this.txtAssetType.ChangeColorOnEnter = true;
            this.txtAssetType.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAssetType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAssetType.Location = new System.Drawing.Point(19, 28);
            this.txtAssetType.Name = "txtAssetType";
            this.txtAssetType.Negative = true;
            this.txtAssetType.NotEmpty = false;
            this.txtAssetType.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAssetType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAssetType.SelectOnEnter = true;
            this.txtAssetType.Size = new System.Drawing.Size(100, 23);
            this.txtAssetType.TabIndex = 8;
            this.txtAssetType.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "کد دارائی:";
            // 
            // txtAssetCode
            // 
            this.txtAssetCode.ChangeColorIfNotEmpty = false;
            this.txtAssetCode.ChangeColorOnEnter = true;
            this.txtAssetCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAssetCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAssetCode.Location = new System.Drawing.Point(285, 28);
            this.txtAssetCode.Name = "txtAssetCode";
            this.txtAssetCode.Negative = true;
            this.txtAssetCode.NotEmpty = false;
            this.txtAssetCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAssetCode.ReadOnly = true;
            this.txtAssetCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAssetCode.SelectOnEnter = true;
            this.txtAssetCode.Size = new System.Drawing.Size(117, 23);
            this.txtAssetCode.TabIndex = 1;
            this.txtAssetCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "نوع:";
            // 
            // btmSearchAsset
            // 
            this.btmSearchAsset.Location = new System.Drawing.Point(212, 28);
            this.btmSearchAsset.Name = "btmSearchAsset";
            this.btmSearchAsset.Size = new System.Drawing.Size(71, 23);
            this.btmSearchAsset.TabIndex = 2;
            this.btmSearchAsset.Text = "Search";
            this.btmSearchAsset.UseVisualStyleBackColor = true;
            this.btmSearchAsset.Click += new System.EventHandler(this.btmSearchAsset_Click);
            // 
            // tabAssetShare
            // 
            this.tabAssetShare.Controls.Add(this.dgvAssetShare);
            this.tabAssetShare.Controls.Add(this.FindPerson2);
            this.tabAssetShare.Location = new System.Drawing.Point(4, 25);
            this.tabAssetShare.Name = "tabAssetShare";
            this.tabAssetShare.Padding = new System.Windows.Forms.Padding(3);
            this.tabAssetShare.Size = new System.Drawing.Size(506, 487);
            this.tabAssetShare.TabIndex = 3;
            this.tabAssetShare.Text = "جزئی از دارایی";
            this.tabAssetShare.UseVisualStyleBackColor = true;
            // 
            // dgvAssetShare
            // 
            this.dgvAssetShare.ActionMenu = jPopupMenu2;
            this.dgvAssetShare.AllowUserToAddRows = false;
            this.dgvAssetShare.AllowUserToDeleteRows = false;
            this.dgvAssetShare.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgvAssetShare.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAssetShare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAssetShare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssetShare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAssetShare.EnableContexMenu = true;
            this.dgvAssetShare.KeyName = null;
            this.dgvAssetShare.Location = new System.Drawing.Point(3, 185);
            this.dgvAssetShare.Name = "dgvAssetShare";
            this.dgvAssetShare.ReadHeadersFromDB = false;
            this.dgvAssetShare.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgvAssetShare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssetShare.ShowRowNumber = true;
            this.dgvAssetShare.Size = new System.Drawing.Size(500, 299);
            this.dgvAssetShare.TabIndex = 76;
            this.dgvAssetShare.TableName = null;
            // 
            // FindPerson2
            // 
            this.FindPerson2.Dock = System.Windows.Forms.DockStyle.Top;
            this.FindPerson2.FilterPerson = null;
            this.FindPerson2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FindPerson2.LableGroup = null;
            this.FindPerson2.Location = new System.Drawing.Point(3, 3);
            this.FindPerson2.Name = "FindPerson2";
            this.FindPerson2.PersonType = ClassLibrary.JPersonTypes.None;
            this.FindPerson2.ReadOnly = false;
            this.FindPerson2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FindPerson2.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.FindPerson2.SelectedCode = 0;
            this.FindPerson2.Size = new System.Drawing.Size(500, 182);
            this.FindPerson2.TabIndex = 73;
            this.FindPerson2.TafsiliCode = false;
            this.FindPerson2.AfterCodeSelected += new ClassLibrary.JUCPerson.CodeSelected(this.FindPerson2_AfterCodeSelected);
            // 
            // tabUnDist
            // 
            this.tabUnDist.Controls.Add(this.groupBox7);
            this.tabUnDist.Controls.Add(this.grpUnOrder);
            this.tabUnDist.Controls.Add(this.grpUnDecision);
            this.tabUnDist.Controls.Add(this.groupBox6);
            this.tabUnDist.Location = new System.Drawing.Point(4, 25);
            this.tabUnDist.Name = "tabUnDist";
            this.tabUnDist.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnDist.Size = new System.Drawing.Size(506, 487);
            this.tabUnDist.TabIndex = 6;
            this.tabUnDist.Text = "حکم رفع توقیف";
            this.tabUnDist.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtUnDesc);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 379);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(500, 102);
            this.groupBox7.TabIndex = 33;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "توضیحات رفع توقیف:";
            this.groupBox7.Visible = false;
            // 
            // txtUnDesc
            // 
            this.txtUnDesc.ChangeColorIfNotEmpty = false;
            this.txtUnDesc.ChangeColorOnEnter = true;
            this.txtUnDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtUnDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUnDesc.Location = new System.Drawing.Point(3, 19);
            this.txtUnDesc.Multiline = true;
            this.txtUnDesc.Name = "txtUnDesc";
            this.txtUnDesc.Negative = true;
            this.txtUnDesc.NotEmpty = false;
            this.txtUnDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtUnDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUnDesc.SelectOnEnter = true;
            this.txtUnDesc.Size = new System.Drawing.Size(494, 80);
            this.txtUnDesc.TabIndex = 0;
            this.txtUnDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // grpUnOrder
            // 
            this.grpUnOrder.Controls.Add(this.txtUnOrderDesc);
            this.grpUnOrder.Controls.Add(this.label8);
            this.grpUnOrder.Controls.Add(this.txtUnOrderSender);
            this.grpUnOrder.Controls.Add(this.label9);
            this.grpUnOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpUnOrder.Location = new System.Drawing.Point(3, 237);
            this.grpUnOrder.Name = "grpUnOrder";
            this.grpUnOrder.Size = new System.Drawing.Size(500, 142);
            this.grpUnOrder.TabIndex = 32;
            this.grpUnOrder.TabStop = false;
            this.grpUnOrder.Text = "مشخصات دستور:";
            this.grpUnOrder.Visible = false;
            // 
            // txtUnOrderDesc
            // 
            this.txtUnOrderDesc.Location = new System.Drawing.Point(7, 63);
            this.txtUnOrderDesc.Multiline = true;
            this.txtUnOrderDesc.Name = "txtUnOrderDesc";
            this.txtUnOrderDesc.Size = new System.Drawing.Size(335, 72);
            this.txtUnOrderDesc.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(377, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "متن دستور:";
            // 
            // txtUnOrderSender
            // 
            this.txtUnOrderSender.Location = new System.Drawing.Point(70, 27);
            this.txtUnOrderSender.Name = "txtUnOrderSender";
            this.txtUnOrderSender.Size = new System.Drawing.Size(271, 23);
            this.txtUnOrderSender.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(347, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "مرجع صادر کننده:";
            // 
            // grpUnDecision
            // 
            this.grpUnDecision.Controls.Add(this.txtUnDecisionDesc);
            this.grpUnDecision.Controls.Add(this.btnUndist);
            this.grpUnDecision.Controls.Add(this.txtUnDecisionCode);
            this.grpUnDecision.Controls.Add(this.label10);
            this.grpUnDecision.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpUnDecision.Location = new System.Drawing.Point(3, 64);
            this.grpUnDecision.Name = "grpUnDecision";
            this.grpUnDecision.Size = new System.Drawing.Size(500, 173);
            this.grpUnDecision.TabIndex = 30;
            this.grpUnDecision.TabStop = false;
            this.grpUnDecision.Text = "مشخصات رای دادگاه";
            // 
            // txtUnDecisionDesc
            // 
            this.txtUnDecisionDesc.ChangeColorIfNotEmpty = false;
            this.txtUnDecisionDesc.ChangeColorOnEnter = true;
            this.txtUnDecisionDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtUnDecisionDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtUnDecisionDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUnDecisionDesc.Location = new System.Drawing.Point(3, 63);
            this.txtUnDecisionDesc.Multiline = true;
            this.txtUnDecisionDesc.Name = "txtUnDecisionDesc";
            this.txtUnDecisionDesc.Negative = true;
            this.txtUnDecisionDesc.NotEmpty = false;
            this.txtUnDecisionDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtUnDecisionDesc.ReadOnly = true;
            this.txtUnDecisionDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUnDecisionDesc.SelectOnEnter = true;
            this.txtUnDecisionDesc.Size = new System.Drawing.Size(494, 107);
            this.txtUnDecisionDesc.TabIndex = 28;
            this.txtUnDecisionDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // btnUndist
            // 
            this.btnUndist.Location = new System.Drawing.Point(142, 34);
            this.btnUndist.Name = "btnUndist";
            this.btnUndist.Size = new System.Drawing.Size(75, 23);
            this.btnUndist.TabIndex = 26;
            this.btnUndist.Text = "جستجو";
            this.btnUndist.UseVisualStyleBackColor = true;
            this.btnUndist.Click += new System.EventHandler(this.btnUndist_Click);
            // 
            // txtUnDecisionCode
            // 
            this.txtUnDecisionCode.ChangeColorIfNotEmpty = false;
            this.txtUnDecisionCode.ChangeColorOnEnter = true;
            this.txtUnDecisionCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtUnDecisionCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUnDecisionCode.Location = new System.Drawing.Point(236, 34);
            this.txtUnDecisionCode.Name = "txtUnDecisionCode";
            this.txtUnDecisionCode.Negative = true;
            this.txtUnDecisionCode.NotEmpty = false;
            this.txtUnDecisionCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtUnDecisionCode.ReadOnly = true;
            this.txtUnDecisionCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUnDecisionCode.SelectOnEnter = true;
            this.txtUnDecisionCode.Size = new System.Drawing.Size(140, 23);
            this.txtUnDecisionCode.TabIndex = 27;
            this.txtUnDecisionCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(398, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 16);
            this.label10.TabIndex = 25;
            this.label10.Text = "کد رای:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.txtDateUn);
            this.groupBox6.Controls.Add(this.rbUnDecision);
            this.groupBox6.Controls.Add(this.rbUnOrder);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(500, 61);
            this.groupBox6.TabIndex = 31;
            this.groupBox6.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(381, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "تاریخ رفع توقیف:";
            // 
            // txtDateUn
            // 
            this.txtDateUn.ChangeColorIfNotEmpty = true;
            this.txtDateUn.ChangeColorOnEnter = true;
            this.txtDateUn.Date = new System.DateTime(((long)(0)));
            this.txtDateUn.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateUn.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateUn.InsertInDatesTable = true;
            this.txtDateUn.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateUn.Location = new System.Drawing.Point(276, 16);
            this.txtDateUn.Mask = "0000/00/00";
            this.txtDateUn.Name = "txtDateUn";
            this.txtDateUn.NotEmpty = false;
            this.txtDateUn.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateUn.Size = new System.Drawing.Size(100, 23);
            this.txtDateUn.TabIndex = 2;
            // 
            // rbUnDecision
            // 
            this.rbUnDecision.AutoSize = true;
            this.rbUnDecision.Checked = true;
            this.rbUnDecision.Location = new System.Drawing.Point(130, 9);
            this.rbUnDecision.Name = "rbUnDecision";
            this.rbUnDecision.Size = new System.Drawing.Size(51, 20);
            this.rbUnDecision.TabIndex = 1;
            this.rbUnDecision.TabStop = true;
            this.rbUnDecision.Text = "حکم";
            this.rbUnDecision.UseVisualStyleBackColor = true;
            this.rbUnDecision.CheckedChanged += new System.EventHandler(this.rbUnDecision_CheckedChanged);
            // 
            // rbUnOrder
            // 
            this.rbUnOrder.AutoSize = true;
            this.rbUnOrder.Location = new System.Drawing.Point(120, 35);
            this.rbUnOrder.Name = "rbUnOrder";
            this.rbUnOrder.Size = new System.Drawing.Size(61, 20);
            this.rbUnOrder.TabIndex = 0;
            this.rbUnOrder.TabStop = true;
            this.rbUnOrder.Text = "دستور";
            this.rbUnOrder.UseVisualStyleBackColor = true;
            this.rbUnOrder.CheckedChanged += new System.EventHandler(this.rbUnDecision_CheckedChanged);
            // 
            // TabDistDesc
            // 
            this.TabDistDesc.Controls.Add(this.txtComment);
            this.TabDistDesc.Location = new System.Drawing.Point(4, 25);
            this.TabDistDesc.Name = "TabDistDesc";
            this.TabDistDesc.Padding = new System.Windows.Forms.Padding(3);
            this.TabDistDesc.Size = new System.Drawing.Size(506, 487);
            this.TabDistDesc.TabIndex = 5;
            this.TabDistDesc.Text = "علت توقیف";
            this.TabDistDesc.UseVisualStyleBackColor = true;
            // 
            // txtComment
            // 
            this.txtComment.ChangeColorIfNotEmpty = false;
            this.txtComment.ChangeColorOnEnter = true;
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComment.InBackColor = System.Drawing.SystemColors.Info;
            this.txtComment.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtComment.Location = new System.Drawing.Point(3, 3);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Negative = true;
            this.txtComment.NotEmpty = false;
            this.txtComment.NotEmptyColor = System.Drawing.Color.Red;
            this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtComment.SelectOnEnter = true;
            this.txtComment.Size = new System.Drawing.Size(500, 481);
            this.txtComment.TabIndex = 0;
            this.txtComment.TextMode = ClassLibrary.TextModes.Text;
            // 
            // tabImages
            // 
            this.tabImages.Controls.Add(this.jArchiveList);
            this.tabImages.Location = new System.Drawing.Point(4, 25);
            this.tabImages.Name = "tabImages";
            this.tabImages.Padding = new System.Windows.Forms.Padding(3);
            this.tabImages.Size = new System.Drawing.Size(506, 490);
            this.tabImages.TabIndex = 4;
            this.tabImages.Text = "تصاویر";
            this.tabImages.UseVisualStyleBackColor = true;
            // 
            // jArchiveList
            // 
            this.jArchiveList.AllowUserAddFile = true;
            this.jArchiveList.AllowUserAddFromArchive = true;
            this.jArchiveList.AllowUserAddImage = true;
            this.jArchiveList.AllowUserCamera = true;
            this.jArchiveList.AllowUserDeleteFile = true;
            this.jArchiveList.ClassName = "";
            this.jArchiveList.ClassNames = null;
            this.jArchiveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveList.EnabledChange = true;
            this.jArchiveList.Location = new System.Drawing.Point(3, 3);
            this.jArchiveList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jArchiveList.Name = "jArchiveList";
            this.jArchiveList.ObjectCode = 0;
            this.jArchiveList.ObjectCodes = null;
            this.jArchiveList.PlaceCode = 0;
            this.jArchiveList.Size = new System.Drawing.Size(500, 484);
            this.jArchiveList.SubjectCode = 0;
            this.jArchiveList.TabIndex = 0;
            // 
            // SaveDistraint
            // 
            this.SaveDistraint.Location = new System.Drawing.Point(104, 594);
            this.SaveDistraint.Name = "SaveDistraint";
            this.SaveDistraint.Size = new System.Drawing.Size(102, 36);
            this.SaveDistraint.TabIndex = 0;
            this.SaveDistraint.Text = "ذخیره";
            this.SaveDistraint.UseVisualStyleBackColor = true;
            this.SaveDistraint.Click += new System.EventHandler(this.SaveDistraint_Click);
            // 
            // grpDistType
            // 
            this.grpDistType.Controls.Add(this.radPerson);
            this.grpDistType.Controls.Add(this.radAsset);
            this.grpDistType.Controls.Add(this.radPartAsset);
            this.grpDistType.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDistType.Location = new System.Drawing.Point(0, 0);
            this.grpDistType.Name = "grpDistType";
            this.grpDistType.Size = new System.Drawing.Size(520, 50);
            this.grpDistType.TabIndex = 6;
            this.grpDistType.TabStop = false;
            this.grpDistType.Text = "موضوع توقیف:";
            // 
            // radPerson
            // 
            this.radPerson.AutoSize = true;
            this.radPerson.Checked = true;
            this.radPerson.Location = new System.Drawing.Point(407, 22);
            this.radPerson.Name = "radPerson";
            this.radPerson.Size = new System.Drawing.Size(63, 20);
            this.radPerson.TabIndex = 7;
            this.radPerson.TabStop = true;
            this.radPerson.Text = "شخص";
            this.radPerson.UseVisualStyleBackColor = true;
            this.radPerson.CheckedChanged += new System.EventHandler(this.radPerson_CheckedChanged);
            // 
            // radAsset
            // 
            this.radAsset.AutoSize = true;
            this.radAsset.Location = new System.Drawing.Point(299, 22);
            this.radAsset.Name = "radAsset";
            this.radAsset.Size = new System.Drawing.Size(60, 20);
            this.radAsset.TabIndex = 8;
            this.radAsset.Text = "دارائی";
            this.radAsset.UseVisualStyleBackColor = true;
            this.radAsset.CheckedChanged += new System.EventHandler(this.radPerson_CheckedChanged);
            // 
            // radPartAsset
            // 
            this.radPartAsset.AutoSize = true;
            this.radPartAsset.Location = new System.Drawing.Point(140, 22);
            this.radPartAsset.Name = "radPartAsset";
            this.radPartAsset.Size = new System.Drawing.Size(107, 20);
            this.radPartAsset.TabIndex = 9;
            this.radPartAsset.Text = "جزئی از دارائی";
            this.radPartAsset.UseVisualStyleBackColor = true;
            this.radPartAsset.CheckedChanged += new System.EventHandler(this.radPerson_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabTotal);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 538);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(316, 594);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(102, 36);
            this.btnclose.TabIndex = 1;
            this.btnclose.Text = "خروج";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // JDistraintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 635);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpDistType);
            this.Controls.Add(this.SaveDistraint);
            this.Name = "JDistraintForm";
            this.Text = "توقیف اموال";
            this.tabTotal.ResumeLayout(false);
            this.tabDistratint.ResumeLayout(false);
            this.gbxOrder.ResumeLayout(false);
            this.gbxOrder.PerformLayout();
            this.gbxDesion.ResumeLayout(false);
            this.gbxDesion.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPerson.ResumeLayout(false);
            this.tabAsset.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssetOwner)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabAssetShare.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssetShare)).EndInit();
            this.tabUnDist.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.grpUnOrder.ResumeLayout(false);
            this.grpUnOrder.PerformLayout();
            this.grpUnDecision.ResumeLayout(false);
            this.grpUnDecision.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.TabDistDesc.ResumeLayout(false);
            this.TabDistDesc.PerformLayout();
            this.tabImages.ResumeLayout(false);
            this.grpDistType.ResumeLayout(false);
            this.grpDistType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabTotal;
        private System.Windows.Forms.TabPage tabDistratint;
        private System.Windows.Forms.TabPage tabPerson;
        private System.Windows.Forms.Button SaveDistraint;
        private System.Windows.Forms.GroupBox grpDistType;
        private System.Windows.Forms.RadioButton radPerson;
        private System.Windows.Forms.RadioButton radAsset;
        private System.Windows.Forms.RadioButton radPartAsset;
        private System.Windows.Forms.TabPage tabAsset;
        private System.Windows.Forms.TabPage tabAssetShare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btmSearchAsset;
        private ClassLibrary.TextEdit txtAssetCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabImages;
        private ArchivedDocuments.JArchiveList jArchiveList;
        private System.Windows.Forms.TabPage TabDistDesc;
        private ClassLibrary.TextEdit txtComment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnclose;
        private ClassLibrary.TextEdit txtAssetType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radDecision;
        private System.Windows.Forms.RadioButton radOrder;
        private System.Windows.Forms.GroupBox gbxDesion;
        private ClassLibrary.TextEdit txtSummaryJudgement;
        private System.Windows.Forms.Button button3;
        private ClassLibrary.TextEdit txtCommittalCode;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.JUCPerson FindPerson;
        private ClassLibrary.JUCPerson FindPerson2;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.TabPage tabUnDist;
        private System.Windows.Forms.GroupBox grpUnOrder;
        private System.Windows.Forms.TextBox txtUnOrderDesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUnOrderSender;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpUnDecision;
        private ClassLibrary.TextEdit txtUnDecisionDesc;
        private System.Windows.Forms.Button btnUndist;
        private ClassLibrary.TextEdit txtUnDecisionCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label11;
        private ClassLibrary.DateEdit txtDateUn;
        private System.Windows.Forms.RadioButton rbUnDecision;
        private System.Windows.Forms.RadioButton rbUnOrder;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox gbxOrder;
        private System.Windows.Forms.TextBox txtOrderComment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOrderSender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox8;
        private ClassLibrary.JDataGrid dgvAssetOwner;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label lbAssetDesc;
        private ClassLibrary.TextEdit txtUnDesc;
        private ClassLibrary.JDataGrid dgvAssetShare;
        private System.Windows.Forms.Button btnDelAsset;
    }
}