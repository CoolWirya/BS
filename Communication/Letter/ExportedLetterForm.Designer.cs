namespace Communication
{
    partial class JExportedLetterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JExportedLetterForm));
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpInfo = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonParent = new System.Windows.Forms.Button();
            this.btnParentLetter = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlLetterInfo = new System.Windows.Forms.Panel();
            this.txtLetterNo = new ClassLibrary.TextEdit(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtYear = new ClassLibrary.TextEdit(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtReciever = new ClassLibrary.TextEdit(this.components);
            this.txtParent = new ClassLibrary.TextEdit(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSign = new System.Windows.Forms.Button();
            this.lblSignStatus = new System.Windows.Forms.Label();
            this.cmbUrgency = new ClassLibrary.JComboBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddCopyReceiver = new System.Windows.Forms.Button();
            this.btnDeleteCopyReceiver = new System.Windows.Forms.Button();
            this.txtReason = new ClassLibrary.TextEdit(this.components);
            this.dgrCopies = new ClassLibrary.JDataGrid();
            this.UserPostCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Full_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CopyReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbCopyReceiver = new ClassLibrary.JComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtSubject = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSender = new ClassLibrary.JComboBox(this.components);
            this.tbpAttach = new System.Windows.Forms.TabPage();
            this.jArchiveList1 = new ArchivedDocuments.JArchiveList();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jPropertyValueUserControl1 = new Globals.Property.JPropertyValueUserControl();
            this.tbpRefer = new System.Windows.Forms.TabPage();
            this.refersText1 = new Automation.RefersText();
            this.jRefersTextRTB1 = new Automation.Refer.JRefersTextRTB();
            this.tbpDelivery = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.grbDelivery = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dteDelivery = new ClassLibrary.DateEdit(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.cmbDeliveryType = new ClassLibrary.JComboBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txtDeliveryPerson = new ClassLibrary.TextEdit(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeViewRefer = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReplayExport = new System.Windows.Forms.Button();
            this.btnReply = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRefer = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewNumber = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbpInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlLetterInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCopies)).BeginInit();
            this.tbpAttach.SuspendLayout();
            this.jArchiveList1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tbpRefer.SuspendLayout();
            this.tbpDelivery.SuspendLayout();
            this.grbDelivery.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpInfo);
            this.tabControl1.Controls.Add(this.tbpAttach);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tbpRefer);
            this.tabControl1.Controls.Add(this.tbpDelivery);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.ItemSize = new System.Drawing.Size(150, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(924, 675);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 44;
            // 
            // tbpInfo
            // 
            this.tbpInfo.BackColor = System.Drawing.Color.Transparent;
            this.tbpInfo.Controls.Add(this.panel2);
            this.tbpInfo.Controls.Add(this.btnParentLetter);
            this.tbpInfo.Controls.Add(this.splitter1);
            this.tbpInfo.Controls.Add(this.pnlLetterInfo);
            this.tbpInfo.ImageKey = "info_s24.png";
            this.tbpInfo.Location = new System.Drawing.Point(4, 34);
            this.tbpInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpInfo.Name = "tbpInfo";
            this.tbpInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpInfo.Size = new System.Drawing.Size(916, 637);
            this.tbpInfo.TabIndex = 0;
            this.tbpInfo.Text = "اطلاعات نامه";
            this.tbpInfo.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonParent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(516, 629);
            this.panel2.TabIndex = 87;
            // 
            // buttonParent
            // 
            this.buttonParent.BackColor = System.Drawing.SystemColors.Control;
            this.buttonParent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonParent.Image = ((System.Drawing.Image)(resources.GetObject("buttonParent.Image")));
            this.buttonParent.Location = new System.Drawing.Point(5, 38);
            this.buttonParent.Name = "buttonParent";
            this.buttonParent.Size = new System.Drawing.Size(72, 57);
            this.buttonParent.TabIndex = 86;
            this.buttonParent.Text = "نامه قبلی";
            this.buttonParent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonParent.UseVisualStyleBackColor = false;
            this.buttonParent.Visible = false;
            this.buttonParent.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnParentLetter
            // 
            this.btnParentLetter.BackColor = System.Drawing.SystemColors.Control;
            this.btnParentLetter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParentLetter.Image = ((System.Drawing.Image)(resources.GetObject("btnParentLetter.Image")));
            this.btnParentLetter.Location = new System.Drawing.Point(29, 37);
            this.btnParentLetter.Name = "btnParentLetter";
            this.btnParentLetter.Size = new System.Drawing.Size(72, 57);
            this.btnParentLetter.TabIndex = 85;
            this.btnParentLetter.Text = "نامه قبلی";
            this.btnParentLetter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnParentLetter.UseVisualStyleBackColor = false;
            this.btnParentLetter.Visible = false;
            this.btnParentLetter.Click += new System.EventHandler(this.btnParentLetter_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(519, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 629);
            this.splitter1.TabIndex = 46;
            this.splitter1.TabStop = false;
            // 
            // pnlLetterInfo
            // 
            this.pnlLetterInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlLetterInfo.Controls.Add(this.txtLetterNo);
            this.pnlLetterInfo.Controls.Add(this.label9);
            this.pnlLetterInfo.Controls.Add(this.txtYear);
            this.pnlLetterInfo.Controls.Add(this.label8);
            this.pnlLetterInfo.Controls.Add(this.txtReciever);
            this.pnlLetterInfo.Controls.Add(this.txtParent);
            this.pnlLetterInfo.Controls.Add(this.label7);
            this.pnlLetterInfo.Controls.Add(this.groupBox2);
            this.pnlLetterInfo.Controls.Add(this.cmbUrgency);
            this.pnlLetterInfo.Controls.Add(this.label6);
            this.pnlLetterInfo.Controls.Add(this.groupBox1);
            this.pnlLetterInfo.Controls.Add(this.txtSubject);
            this.pnlLetterInfo.Controls.Add(this.label3);
            this.pnlLetterInfo.Controls.Add(this.label2);
            this.pnlLetterInfo.Controls.Add(this.label1);
            this.pnlLetterInfo.Controls.Add(this.cmbSender);
            this.pnlLetterInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLetterInfo.Location = new System.Drawing.Point(520, 4);
            this.pnlLetterInfo.Name = "pnlLetterInfo";
            this.pnlLetterInfo.Size = new System.Drawing.Size(393, 629);
            this.pnlLetterInfo.TabIndex = 76;
            // 
            // txtLetterNo
            // 
            this.txtLetterNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLetterNo.ChangeColorIfNotEmpty = false;
            this.txtLetterNo.ChangeColorOnEnter = true;
            this.txtLetterNo.Enabled = false;
            this.txtLetterNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLetterNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLetterNo.Location = new System.Drawing.Point(183, 67);
            this.txtLetterNo.Name = "txtLetterNo";
            this.txtLetterNo.Negative = true;
            this.txtLetterNo.NotEmpty = false;
            this.txtLetterNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLetterNo.ReadOnly = true;
            this.txtLetterNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterNo.SelectOnEnter = true;
            this.txtLetterNo.Size = new System.Drawing.Size(124, 23);
            this.txtLetterNo.TabIndex = 91;
            this.txtLetterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLetterNo.TextMode = ClassLibrary.TextModes.Text;
            this.txtLetterNo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtLetterNo_MouseDoubleClick);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(306, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 21);
            this.label9.TabIndex = 90;
            this.label9.Text = "شماره نامه :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtYear
            // 
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYear.ChangeColorIfNotEmpty = false;
            this.txtYear.ChangeColorOnEnter = true;
            this.txtYear.Enabled = false;
            this.txtYear.InBackColor = System.Drawing.SystemColors.Info;
            this.txtYear.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtYear.Location = new System.Drawing.Point(183, 38);
            this.txtYear.Name = "txtYear";
            this.txtYear.Negative = true;
            this.txtYear.NotEmpty = false;
            this.txtYear.NotEmptyColor = System.Drawing.Color.Red;
            this.txtYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtYear.SelectOnEnter = true;
            this.txtYear.Size = new System.Drawing.Size(124, 23);
            this.txtYear.TabIndex = 89;
            this.txtYear.Text = "13";
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYear.TextMode = ClassLibrary.TextModes.Text;
            this.txtYear.Leave += new System.EventHandler(this.txtYear_Leave);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(306, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 21);
            this.label8.TabIndex = 88;
            this.label8.Text = "سال :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReciever
            // 
            this.txtReciever.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReciever.ChangeColorIfNotEmpty = false;
            this.txtReciever.ChangeColorOnEnter = true;
            this.txtReciever.InBackColor = System.Drawing.SystemColors.Info;
            this.txtReciever.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReciever.Location = new System.Drawing.Point(6, 126);
            this.txtReciever.Name = "txtReciever";
            this.txtReciever.Negative = true;
            this.txtReciever.NotEmpty = false;
            this.txtReciever.NotEmptyColor = System.Drawing.Color.Red;
            this.txtReciever.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReciever.SelectOnEnter = true;
            this.txtReciever.Size = new System.Drawing.Size(301, 23);
            this.txtReciever.TabIndex = 87;
            this.txtReciever.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtParent
            // 
            this.txtParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParent.ChangeColorIfNotEmpty = false;
            this.txtParent.ChangeColorOnEnter = true;
            this.txtParent.InBackColor = System.Drawing.SystemColors.Info;
            this.txtParent.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtParent.Location = new System.Drawing.Point(6, 9);
            this.txtParent.Name = "txtParent";
            this.txtParent.Negative = true;
            this.txtParent.NotEmpty = false;
            this.txtParent.NotEmptyColor = System.Drawing.Color.Red;
            this.txtParent.ReadOnly = true;
            this.txtParent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtParent.SelectOnEnter = true;
            this.txtParent.Size = new System.Drawing.Size(301, 23);
            this.txtParent.TabIndex = 85;
            this.txtParent.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(306, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 21);
            this.label7.TabIndex = 86;
            this.label7.Text = "پاسخ / پیرو :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSign);
            this.groupBox2.Controls.Add(this.lblSignStatus);
            this.groupBox2.Location = new System.Drawing.Point(10, 465);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 56);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "وضعیت نامه";
            // 
            // btnSign
            // 
            this.btnSign.BackColor = System.Drawing.SystemColors.Control;
            this.btnSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSign.Image = ((System.Drawing.Image)(resources.GetObject("btnSign.Image")));
            this.btnSign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSign.Location = new System.Drawing.Point(6, 17);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(154, 34);
            this.btnSign.TabIndex = 1;
            this.btnSign.Text = "امضاء نامه";
            this.btnSign.UseVisualStyleBackColor = false;
            this.btnSign.Visible = false;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // lblSignStatus
            // 
            this.lblSignStatus.Location = new System.Drawing.Point(6, 25);
            this.lblSignStatus.Name = "lblSignStatus";
            this.lblSignStatus.Size = new System.Drawing.Size(360, 19);
            this.lblSignStatus.TabIndex = 0;
            this.lblSignStatus.Text = "نامه هنوز امضا نشده است.";
            // 
            // cmbUrgency
            // 
            this.cmbUrgency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbUrgency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUrgency.BaseCode = 0;
            this.cmbUrgency.ChangeColorIfNotEmpty = true;
            this.cmbUrgency.ChangeColorOnEnter = true;
            this.cmbUrgency.FormattingEnabled = true;
            this.cmbUrgency.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbUrgency.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbUrgency.Location = new System.Drawing.Point(6, 186);
            this.cmbUrgency.Name = "cmbUrgency";
            this.cmbUrgency.NotEmpty = false;
            this.cmbUrgency.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbUrgency.SelectOnEnter = true;
            this.cmbUrgency.Size = new System.Drawing.Size(301, 24);
            this.cmbUrgency.TabIndex = 78;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(306, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 21);
            this.label6.TabIndex = 83;
            this.label6.Text = "فوریت :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnAddCopyReceiver);
            this.groupBox1.Controls.Add(this.btnDeleteCopyReceiver);
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.dgrCopies);
            this.groupBox1.Controls.Add(this.cmbCopyReceiver);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(6, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 246);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "رونوشت نامه";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(309, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 21);
            this.label4.TabIndex = 69;
            this.label4.Text = "گیرنده :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddCopyReceiver
            // 
            this.btnAddCopyReceiver.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddCopyReceiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCopyReceiver.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddCopyReceiver.ForeColor = System.Drawing.Color.Black;
            this.btnAddCopyReceiver.Location = new System.Drawing.Point(38, 51);
            this.btnAddCopyReceiver.Name = "btnAddCopyReceiver";
            this.btnAddCopyReceiver.Size = new System.Drawing.Size(26, 23);
            this.btnAddCopyReceiver.TabIndex = 67;
            this.btnAddCopyReceiver.Text = "+";
            this.btnAddCopyReceiver.UseVisualStyleBackColor = false;
            this.btnAddCopyReceiver.Click += new System.EventHandler(this.btnAddCopyReceiver_Click);
            // 
            // btnDeleteCopyReceiver
            // 
            this.btnDeleteCopyReceiver.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteCopyReceiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCopyReceiver.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeleteCopyReceiver.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteCopyReceiver.Location = new System.Drawing.Point(6, 51);
            this.btnDeleteCopyReceiver.Name = "btnDeleteCopyReceiver";
            this.btnDeleteCopyReceiver.Size = new System.Drawing.Size(26, 23);
            this.btnDeleteCopyReceiver.TabIndex = 68;
            this.btnDeleteCopyReceiver.TabStop = false;
            this.btnDeleteCopyReceiver.Text = "-";
            this.btnDeleteCopyReceiver.UseVisualStyleBackColor = false;
            this.btnDeleteCopyReceiver.Click += new System.EventHandler(this.btnDeleteCopyReceiver_Click);
            // 
            // txtReason
            // 
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReason.ChangeColorIfNotEmpty = false;
            this.txtReason.ChangeColorOnEnter = true;
            this.txtReason.InBackColor = System.Drawing.SystemColors.Info;
            this.txtReason.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReason.Location = new System.Drawing.Point(70, 52);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Negative = true;
            this.txtReason.NotEmpty = false;
            this.txtReason.NotEmptyColor = System.Drawing.Color.Red;
            this.txtReason.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReason.SelectOnEnter = true;
            this.txtReason.Size = new System.Drawing.Size(231, 23);
            this.txtReason.TabIndex = 10;
            this.txtReason.TextMode = ClassLibrary.TextModes.Text;
            // 
            // dgrCopies
            // 
            this.dgrCopies.ActionMenu = jPopupMenu2;
            this.dgrCopies.AllowUserToAddRows = false;
            this.dgrCopies.AllowUserToDeleteRows = false;
            this.dgrCopies.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgrCopies.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrCopies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrCopies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrCopies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserPostCode,
            this.Full_Title,
            this.CopyReason});
            this.dgrCopies.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgrCopies.EnableContexMenu = true;
            this.dgrCopies.KeyName = null;
            this.dgrCopies.Location = new System.Drawing.Point(3, 81);
            this.dgrCopies.Name = "dgrCopies";
            this.dgrCopies.ReadHeadersFromDB = false;
            this.dgrCopies.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgrCopies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrCopies.ShowRowNumber = true;
            this.dgrCopies.Size = new System.Drawing.Size(374, 162);
            this.dgrCopies.TabIndex = 66;
            this.dgrCopies.TableName = null;
            // 
            // UserPostCode
            // 
            this.UserPostCode.HeaderText = "کد";
            this.UserPostCode.Name = "UserPostCode";
            this.UserPostCode.ReadOnly = true;
            this.UserPostCode.Visible = false;
            this.UserPostCode.Width = 44;
            // 
            // Full_Title
            // 
            this.Full_Title.HeaderText = "گیرنده";
            this.Full_Title.Name = "Full_Title";
            this.Full_Title.ReadOnly = true;
            this.Full_Title.Width = 66;
            // 
            // CopyReason
            // 
            this.CopyReason.HeaderText = "توضیحات";
            this.CopyReason.Name = "CopyReason";
            this.CopyReason.Width = 82;
            // 
            // cmbCopyReceiver
            // 
            this.cmbCopyReceiver.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCopyReceiver.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCopyReceiver.BaseCode = 0;
            this.cmbCopyReceiver.ChangeColorIfNotEmpty = true;
            this.cmbCopyReceiver.ChangeColorOnEnter = true;
            this.cmbCopyReceiver.FormattingEnabled = true;
            this.cmbCopyReceiver.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCopyReceiver.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCopyReceiver.Location = new System.Drawing.Point(6, 22);
            this.cmbCopyReceiver.Name = "cmbCopyReceiver";
            this.cmbCopyReceiver.NotEmpty = false;
            this.cmbCopyReceiver.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCopyReceiver.SelectOnEnter = true;
            this.cmbCopyReceiver.Size = new System.Drawing.Size(295, 24);
            this.cmbCopyReceiver.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(307, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 21);
            this.label5.TabIndex = 64;
            this.label5.Text = "توضیحات :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSubject
            // 
            this.txtSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubject.ChangeColorIfNotEmpty = false;
            this.txtSubject.ChangeColorOnEnter = true;
            this.txtSubject.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSubject.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubject.Location = new System.Drawing.Point(6, 155);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Negative = true;
            this.txtSubject.NotEmpty = false;
            this.txtSubject.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSubject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubject.SelectOnEnter = true;
            this.txtSubject.Size = new System.Drawing.Size(301, 23);
            this.txtSubject.TabIndex = 77;
            this.txtSubject.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(306, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.TabIndex = 81;
            this.label3.Text = "موضوع :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(306, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 80;
            this.label2.Text = "گیرنده :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(306, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 79;
            this.label1.Text = "فرستنده :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSender
            // 
            this.cmbSender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSender.BaseCode = 0;
            this.cmbSender.ChangeColorIfNotEmpty = true;
            this.cmbSender.ChangeColorOnEnter = true;
            this.cmbSender.FormattingEnabled = true;
            this.cmbSender.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbSender.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSender.Location = new System.Drawing.Point(6, 95);
            this.cmbSender.Name = "cmbSender";
            this.cmbSender.NotEmpty = false;
            this.cmbSender.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbSender.SelectOnEnter = true;
            this.cmbSender.Size = new System.Drawing.Size(301, 24);
            this.cmbSender.TabIndex = 75;
            this.cmbSender.SelectedIndexChanged += new System.EventHandler(this.cmbSender_SelectedIndexChanged);
            // 
            // tbpAttach
            // 
            this.tbpAttach.Controls.Add(this.jArchiveList1);
            this.tbpAttach.ImageKey = "attachment_s24.png";
            this.tbpAttach.Location = new System.Drawing.Point(4, 34);
            this.tbpAttach.Name = "tbpAttach";
            this.tbpAttach.Size = new System.Drawing.Size(916, 637);
            this.tbpAttach.TabIndex = 2;
            this.tbpAttach.Text = "ضمائم";
            this.tbpAttach.UseVisualStyleBackColor = true;
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
            this.jArchiveList1.Location = new System.Drawing.Point(0, 0);
            this.jArchiveList1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.jArchiveList1.Name = "jArchiveList1";
            this.jArchiveList1.ObjectCode = 0;
            this.jArchiveList1.ObjectCodes = null;
            this.jArchiveList1.PlaceCode = 0;
            this.jArchiveList1.Size = new System.Drawing.Size(916, 637);
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
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 1097, 3, 1097);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(916, 23);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.jPropertyValueUserControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(916, 637);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "ویژگیها";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // jPropertyValueUserControl1
            // 
            this.jPropertyValueUserControl1.AutoScroll = true;
            this.jPropertyValueUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.jPropertyValueUserControl1.ClassName = null;
            this.jPropertyValueUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jPropertyValueUserControl1.Location = new System.Drawing.Point(3, 3);
            this.jPropertyValueUserControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.jPropertyValueUserControl1.Name = "jPropertyValueUserControl1";
            this.jPropertyValueUserControl1.ObjectCode = -1;
            this.jPropertyValueUserControl1.Size = new System.Drawing.Size(910, 631);
            this.jPropertyValueUserControl1.TabIndex = 1;
            this.jPropertyValueUserControl1.ValueObjectCode = 0;
            // 
            // tbpRefer
            // 
            this.tbpRefer.Controls.Add(this.refersText1);
            this.tbpRefer.Controls.Add(this.jRefersTextRTB1);
            this.tbpRefer.ImageKey = "icon-departments_s24.png";
            this.tbpRefer.Location = new System.Drawing.Point(4, 34);
            this.tbpRefer.Name = "tbpRefer";
            this.tbpRefer.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRefer.Size = new System.Drawing.Size(916, 637);
            this.tbpRefer.TabIndex = 1;
            this.tbpRefer.Text = "ارجاعات";
            this.tbpRefer.UseVisualStyleBackColor = true;
            // 
            // refersText1
            // 
            this.refersText1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refersText1.Location = new System.Drawing.Point(3, 3);
            this.refersText1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.refersText1.Name = "refersText1";
            this.refersText1.Size = new System.Drawing.Size(910, 631);
            this.refersText1.TabIndex = 1;
            // 
            // jRefersTextRTB1
            // 
            this.jRefersTextRTB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jRefersTextRTB1.Location = new System.Drawing.Point(3, 3);
            this.jRefersTextRTB1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jRefersTextRTB1.Name = "jRefersTextRTB1";
            this.jRefersTextRTB1.Size = new System.Drawing.Size(910, 631);
            this.jRefersTextRTB1.TabIndex = 0;
            // 
            // tbpDelivery
            // 
            this.tbpDelivery.Controls.Add(this.button1);
            this.tbpDelivery.Controls.Add(this.grbDelivery);
            this.tbpDelivery.Location = new System.Drawing.Point(4, 34);
            this.tbpDelivery.Name = "tbpDelivery";
            this.tbpDelivery.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDelivery.Size = new System.Drawing.Size(916, 637);
            this.tbpDelivery.TabIndex = 3;
            this.tbpDelivery.Text = "ارسال و تحویل نامه";
            this.tbpDelivery.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(737, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 23);
            this.button1.TabIndex = 97;
            this.button1.Text = "ثبت شماره نامه";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // grbDelivery
            // 
            this.grbDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDelivery.Controls.Add(this.label10);
            this.grbDelivery.Controls.Add(this.dteDelivery);
            this.grbDelivery.Controls.Add(this.label11);
            this.grbDelivery.Controls.Add(this.cmbDeliveryType);
            this.grbDelivery.Controls.Add(this.label12);
            this.grbDelivery.Controls.Add(this.txtDeliveryPerson);
            this.grbDelivery.Enabled = false;
            this.grbDelivery.Location = new System.Drawing.Point(481, 62);
            this.grbDelivery.Name = "grbDelivery";
            this.grbDelivery.Size = new System.Drawing.Size(427, 133);
            this.grbDelivery.TabIndex = 96;
            this.grbDelivery.TabStop = false;
            this.grbDelivery.Text = "ارسال و تحویل نامه";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Location = new System.Drawing.Point(312, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 21);
            this.label10.TabIndex = 88;
            this.label10.Text = "نوع ارسال :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteDelivery
            // 
            this.dteDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dteDelivery.ChangeColorIfNotEmpty = true;
            this.dteDelivery.ChangeColorOnEnter = true;
            this.dteDelivery.Date = new System.DateTime(((long)(0)));
            this.dteDelivery.InBackColor = System.Drawing.SystemColors.Info;
            this.dteDelivery.InForeColor = System.Drawing.SystemColors.WindowText;
            this.dteDelivery.InsertInDatesTable = true;
            this.dteDelivery.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteDelivery.Location = new System.Drawing.Point(207, 63);
            this.dteDelivery.Mask = "0000/00/00";
            this.dteDelivery.Name = "dteDelivery";
            this.dteDelivery.NotEmpty = false;
            this.dteDelivery.NotEmptyColor = System.Drawing.Color.Red;
            this.dteDelivery.Size = new System.Drawing.Size(99, 23);
            this.dteDelivery.TabIndex = 95;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Location = new System.Drawing.Point(312, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 21);
            this.label11.TabIndex = 90;
            this.label11.Text = "تاریخ ارسال :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbDeliveryType
            // 
            this.cmbDeliveryType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDeliveryType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbDeliveryType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDeliveryType.BaseCode = 0;
            this.cmbDeliveryType.ChangeColorIfNotEmpty = true;
            this.cmbDeliveryType.ChangeColorOnEnter = true;
            this.cmbDeliveryType.FormattingEnabled = true;
            this.cmbDeliveryType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbDeliveryType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDeliveryType.Location = new System.Drawing.Point(6, 34);
            this.cmbDeliveryType.Name = "cmbDeliveryType";
            this.cmbDeliveryType.NotEmpty = false;
            this.cmbDeliveryType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbDeliveryType.SelectOnEnter = true;
            this.cmbDeliveryType.Size = new System.Drawing.Size(300, 24);
            this.cmbDeliveryType.TabIndex = 94;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Location = new System.Drawing.Point(312, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 21);
            this.label12.TabIndex = 92;
            this.label12.Text = "تحویل گیرنده :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDeliveryPerson
            // 
            this.txtDeliveryPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliveryPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryPerson.ChangeColorIfNotEmpty = false;
            this.txtDeliveryPerson.ChangeColorOnEnter = true;
            this.txtDeliveryPerson.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDeliveryPerson.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeliveryPerson.Location = new System.Drawing.Point(5, 93);
            this.txtDeliveryPerson.Name = "txtDeliveryPerson";
            this.txtDeliveryPerson.Negative = true;
            this.txtDeliveryPerson.NotEmpty = false;
            this.txtDeliveryPerson.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDeliveryPerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDeliveryPerson.SelectOnEnter = true;
            this.txtDeliveryPerson.Size = new System.Drawing.Size(301, 23);
            this.txtDeliveryPerson.TabIndex = 93;
            this.txtDeliveryPerson.TextMode = ClassLibrary.TextModes.Text;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeViewRefer);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(916, 637);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Text = "درخت ارجاعات";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // treeViewRefer
            // 
            this.treeViewRefer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewRefer.Location = new System.Drawing.Point(3, 3);
            this.treeViewRefer.Name = "treeViewRefer";
            this.treeViewRefer.RightToLeftLayout = true;
            this.treeViewRefer.Size = new System.Drawing.Size(910, 631);
            this.treeViewRefer.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "attachment_s24.png");
            this.imageList1.Images.SetKeyName(1, "icon-departments_s24.png");
            this.imageList1.Images.SetKeyName(2, "info_s24.png");
            this.imageList1.Images.SetKeyName(3, "icon-2_24.png");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnNewNumber);
            this.panel1.Controls.Add(this.btnReplayExport);
            this.panel1.Controls.Add(this.btnReply);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnRefer);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 675);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(924, 58);
            this.panel1.TabIndex = 45;
            // 
            // btnReplayExport
            // 
            this.btnReplayExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplayExport.BackColor = System.Drawing.SystemColors.Control;
            this.btnReplayExport.Enabled = false;
            this.btnReplayExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplayExport.Image = ((System.Drawing.Image)(resources.GetObject("btnReplayExport.Image")));
            this.btnReplayExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReplayExport.Location = new System.Drawing.Point(488, 7);
            this.btnReplayExport.Name = "btnReplayExport";
            this.btnReplayExport.Size = new System.Drawing.Size(102, 39);
            this.btnReplayExport.TabIndex = 16;
            this.btnReplayExport.Text = "پیرو / صادره";
            this.btnReplayExport.UseVisualStyleBackColor = false;
            this.btnReplayExport.Click += new System.EventHandler(this.btnReplayExport_Click);
            // 
            // btnReply
            // 
            this.btnReply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReply.BackColor = System.Drawing.SystemColors.Control;
            this.btnReply.Enabled = false;
            this.btnReply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReply.Image = ((System.Drawing.Image)(resources.GetObject("btnReply.Image")));
            this.btnReply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReply.Location = new System.Drawing.Point(596, 7);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(102, 39);
            this.btnReply.TabIndex = 16;
            this.btnReply.Text = "عطف / وارده";
            this.btnReply.UseVisualStyleBackColor = false;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(380, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(102, 39);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "چاپ پیشرفته";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRefer
            // 
            this.btnRefer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefer.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefer.Image = ((System.Drawing.Image)(resources.GetObject("btnRefer.Image")));
            this.btnRefer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefer.Location = new System.Drawing.Point(704, 7);
            this.btnRefer.Name = "btnRefer";
            this.btnRefer.Size = new System.Drawing.Size(102, 39);
            this.btnRefer.TabIndex = 13;
            this.btnRefer.Text = "ارجاع";
            this.btnRefer.UseVisualStyleBackColor = false;
            this.btnRefer.Click += new System.EventHandler(this.btnRefer_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(812, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(7, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 40);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNewNumber
            // 
            this.btnNewNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewNumber.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewNumber.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewNumber.Location = new System.Drawing.Point(271, 7);
            this.btnNewNumber.Name = "btnNewNumber";
            this.btnNewNumber.Size = new System.Drawing.Size(103, 39);
            this.btnNewNumber.TabIndex = 101;
            this.btnNewNumber.Text = "دریافت شماره";
            this.btnNewNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewNumber.UseVisualStyleBackColor = false;
            this.btnNewNumber.Visible = false;
            this.btnNewNumber.Click += new System.EventHandler(this.btnNewNumber_Click);
            // 
            // JExportedLetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 733);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "JExportedLetterForm";
            this.Text = "ExportedLetterForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.JExportedLetterForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JExportedLetterForm_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tbpInfo.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlLetterInfo.ResumeLayout(false);
            this.pnlLetterInfo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCopies)).EndInit();
            this.tbpAttach.ResumeLayout(false);
            this.jArchiveList1.ResumeLayout(false);
            this.jArchiveList1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tbpRefer.ResumeLayout(false);
            this.tbpDelivery.ResumeLayout(false);
            this.grbDelivery.ResumeLayout(false);
            this.grbDelivery.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpInfo;
        private System.Windows.Forms.Button btnParentLetter;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlLetterInfo;
        private ClassLibrary.TextEdit txtParent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Label lblSignStatus;
        private ClassLibrary.JComboBox cmbUrgency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddCopyReceiver;
        private System.Windows.Forms.Button btnDeleteCopyReceiver;
        private ClassLibrary.TextEdit txtReason;
        private ClassLibrary.JDataGrid dgrCopies;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPostCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Full_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn CopyReason;
        private ClassLibrary.JComboBox cmbCopyReceiver;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.TextEdit txtSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JComboBox cmbSender;
        //private Automation.RefersText refersText1;
        private System.Windows.Forms.TabPage tbpAttach;
        private ArchivedDocuments.JArchiveList jArchiveList1;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.TabPage tbpRefer;
        private Automation.Refer.JRefersTextRTB jRefersTextRTB1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnRefer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private ClassLibrary.TextEdit txtReciever;
        private System.Windows.Forms.ImageList imageList1;
        private ClassLibrary.TextEdit txtLetterNo;
        private System.Windows.Forms.Label label9;
        private ClassLibrary.TextEdit txtYear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tbpDelivery;
        private ClassLibrary.TextEdit txtDeliveryPerson;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private ClassLibrary.JComboBox cmbDeliveryType;
        private ClassLibrary.DateEdit dteDelivery;
        private System.Windows.Forms.GroupBox grbDelivery;
		private Automation.RefersText refersText1;
		private System.Windows.Forms.TabPage tabPage1;
		private Globals.Property.JPropertyValueUserControl jPropertyValueUserControl1;
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeViewRefer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReplayExport;
        private System.Windows.Forms.Button buttonParent;
        private System.Windows.Forms.Button btnNewNumber;
    }
}