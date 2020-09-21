namespace Communication
{
    partial class JLetterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JLetterForm));
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpInfo = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnParentLetter = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlLetterInfo = new System.Windows.Forms.Panel();
            this.txtLetterNo = new ClassLibrary.TextEdit(this.components);
            this.label9 = new System.Windows.Forms.Label();
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
            this.cmbReceiver = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSender = new ClassLibrary.JComboBox(this.components);
            this.tbpAttach = new System.Windows.Forms.TabPage();
            this.jArchiveList1 = new ArchivedDocuments.JArchiveList();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jPropertyValueUserControl1 = new Globals.Property.JPropertyValueUserControl();
            this.tbpRefer = new System.Windows.Forms.TabPage();
            this.refersText1 = new Automation.RefersText();
            this.jRefersTextRTB1 = new Automation.Refer.JRefersTextRTB();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeViewRefer = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReply = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRefer = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900 = new ClassLibrary.TextEdit(this.components);
            this.textEdit2 = new ClassLibrary.TextEdit(this.components);
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a = new ClassLibrary.TextEdit(this.components);
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.textEdit1 = new ClassLibrary.TextEdit(this.components);
            this.tabControl1.SuspendLayout();
            this.tbpInfo.SuspendLayout();
            this.pnlLetterInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCopies)).BeginInit();
            this.tbpAttach.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tbpRefer.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(946, 675);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tbpInfo
            // 
            this.tbpInfo.BackColor = System.Drawing.Color.Transparent;
            this.tbpInfo.Controls.Add(this.btnParentLetter);
            this.tbpInfo.Controls.Add(this.panel2);
            this.tbpInfo.Controls.Add(this.splitter1);
            this.tbpInfo.Controls.Add(this.pnlLetterInfo);
            this.tbpInfo.ImageKey = "info_s24.png";
            this.tbpInfo.Location = new System.Drawing.Point(4, 34);
            this.tbpInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpInfo.Name = "tbpInfo";
            this.tbpInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpInfo.Size = new System.Drawing.Size(938, 637);
            this.tbpInfo.TabIndex = 0;
            this.tbpInfo.Text = "اطلاعات نامه";
            this.tbpInfo.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(538, 629);
            this.panel2.TabIndex = 86;
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
            this.splitter1.Location = new System.Drawing.Point(541, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 629);
            this.splitter1.TabIndex = 46;
            this.splitter1.TabStop = false;
            this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
            // 
            // pnlLetterInfo
            // 
            this.pnlLetterInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlLetterInfo.Controls.Add(this.txtLetterNo);
            this.pnlLetterInfo.Controls.Add(this.label9);
            this.pnlLetterInfo.Controls.Add(this.txtParent);
            this.pnlLetterInfo.Controls.Add(this.label7);
            this.pnlLetterInfo.Controls.Add(this.groupBox2);
            this.pnlLetterInfo.Controls.Add(this.cmbUrgency);
            this.pnlLetterInfo.Controls.Add(this.label6);
            this.pnlLetterInfo.Controls.Add(this.groupBox1);
            this.pnlLetterInfo.Controls.Add(this.txtSubject);
            this.pnlLetterInfo.Controls.Add(this.label3);
            this.pnlLetterInfo.Controls.Add(this.label2);
            this.pnlLetterInfo.Controls.Add(this.cmbReceiver);
            this.pnlLetterInfo.Controls.Add(this.label1);
            this.pnlLetterInfo.Controls.Add(this.cmbSender);
            this.pnlLetterInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLetterInfo.Location = new System.Drawing.Point(542, 4);
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
            this.txtLetterNo.Location = new System.Drawing.Point(183, 16);
            this.txtLetterNo.Name = "txtLetterNo";
            this.txtLetterNo.Negative = true;
            this.txtLetterNo.NotEmpty = false;
            this.txtLetterNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLetterNo.ReadOnly = true;
            this.txtLetterNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterNo.SelectOnEnter = true;
            this.txtLetterNo.Size = new System.Drawing.Size(124, 23);
            this.txtLetterNo.TabIndex = 93;
            this.txtLetterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLetterNo.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(306, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 21);
            this.label9.TabIndex = 92;
            this.label9.Text = "شماره نامه :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtParent
            // 
            this.txtParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParent.ChangeColorIfNotEmpty = false;
            this.txtParent.ChangeColorOnEnter = true;
            this.txtParent.InBackColor = System.Drawing.SystemColors.Info;
            this.txtParent.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtParent.Location = new System.Drawing.Point(6, 45);
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
            this.label7.Location = new System.Drawing.Point(306, 46);
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
            this.groupBox2.Location = new System.Drawing.Point(10, 444);
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
            this.cmbUrgency.Location = new System.Drawing.Point(6, 165);
            this.cmbUrgency.Name = "cmbUrgency";
            this.cmbUrgency.NotEmpty = false;
            this.cmbUrgency.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbUrgency.SelectOnEnter = true;
            this.cmbUrgency.Size = new System.Drawing.Size(301, 24);
            this.cmbUrgency.TabIndex = 78;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(306, 166);
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
            this.groupBox1.Location = new System.Drawing.Point(6, 195);
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
            this.txtSubject.Location = new System.Drawing.Point(6, 134);
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
            this.label3.Location = new System.Drawing.Point(306, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.TabIndex = 81;
            this.label3.Text = "موضوع :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(306, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 80;
            this.label2.Text = "گیرنده :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbReceiver
            // 
            this.cmbReceiver.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbReceiver.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReceiver.BaseCode = 0;
            this.cmbReceiver.ChangeColorIfNotEmpty = true;
            this.cmbReceiver.ChangeColorOnEnter = true;
            this.cmbReceiver.FormattingEnabled = true;
            this.cmbReceiver.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbReceiver.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbReceiver.Location = new System.Drawing.Point(6, 104);
            this.cmbReceiver.Name = "cmbReceiver";
            this.cmbReceiver.NotEmpty = false;
            this.cmbReceiver.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbReceiver.SelectOnEnter = true;
            this.cmbReceiver.Size = new System.Drawing.Size(301, 24);
            this.cmbReceiver.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(306, 75);
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
            this.cmbSender.Location = new System.Drawing.Point(6, 74);
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
            this.tbpAttach.Size = new System.Drawing.Size(938, 637);
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
            this.jArchiveList1.DataBaseClassName = "";
            this.jArchiveList1.DataBaseObjectCode = 0;
            this.jArchiveList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveList1.EnabledChange = true;
            this.jArchiveList1.ExtraObject = null;
            this.jArchiveList1.Location = new System.Drawing.Point(0, 0);
            this.jArchiveList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jArchiveList1.Name = "jArchiveList1";
            this.jArchiveList1.ObjectCode = 0;
            this.jArchiveList1.ObjectCodes = null;
            this.jArchiveList1.PlaceCode = 0;
            this.jArchiveList1.Size = new System.Drawing.Size(938, 637);
            this.jArchiveList1.SubjectCode = 0;
            this.jArchiveList1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.jPropertyValueUserControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(938, 645);
            this.tabPage1.TabIndex = 3;
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
            this.jPropertyValueUserControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jPropertyValueUserControl1.Name = "jPropertyValueUserControl1";
            this.jPropertyValueUserControl1.ObjectCode = -1;
            this.jPropertyValueUserControl1.Size = new System.Drawing.Size(932, 639);
            this.jPropertyValueUserControl1.TabIndex = 0;
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
            this.tbpRefer.Size = new System.Drawing.Size(938, 645);
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
            this.refersText1.Size = new System.Drawing.Size(932, 639);
            this.refersText1.TabIndex = 1;
            // 
            // jRefersTextRTB1
            // 
            this.jRefersTextRTB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jRefersTextRTB1.Location = new System.Drawing.Point(3, 3);
            this.jRefersTextRTB1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jRefersTextRTB1.Name = "jRefersTextRTB1";
            this.jRefersTextRTB1.Size = new System.Drawing.Size(932, 639);
            this.jRefersTextRTB1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeViewRefer);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(938, 645);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "درخت ارجاعات";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeViewRefer
            // 
            this.treeViewRefer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewRefer.Location = new System.Drawing.Point(3, 3);
            this.treeViewRefer.Name = "treeViewRefer";
            this.treeViewRefer.RightToLeftLayout = true;
            this.treeViewRefer.Size = new System.Drawing.Size(932, 639);
            this.treeViewRefer.TabIndex = 0;
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
            this.panel1.Controls.Add(this.btnReply);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnRefer);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 675);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(946, 58);
            this.panel1.TabIndex = 43;
            // 
            // btnReply
            // 
            this.btnReply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReply.BackColor = System.Drawing.SystemColors.Control;
            this.btnReply.Enabled = false;
            this.btnReply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReply.Image = ((System.Drawing.Image)(resources.GetObject("btnReply.Image")));
            this.btnReply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReply.Location = new System.Drawing.Point(507, 11);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(139, 39);
            this.btnReply.TabIndex = 16;
            this.btnReply.Text = "عطف / پیرو";
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
            this.btnPrint.Location = new System.Drawing.Point(362, 11);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(139, 39);
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
            this.btnRefer.Location = new System.Drawing.Point(652, 11);
            this.btnRefer.Name = "btnRefer";
            this.btnRefer.Size = new System.Drawing.Size(139, 39);
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
            this.btnSave.Location = new System.Drawing.Point(797, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 40);
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
            this.btnExit.Location = new System.Drawing.Point(6, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 40);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // object_4768fc6f_a803_4ffb_b570_8860fe708900
            // 
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.BackColor = System.Drawing.SystemColors.Info;
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.ChangeColorIfNotEmpty = true;
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.ChangeColorOnEnter = true;
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.Dock = System.Windows.Forms.DockStyle.Top;
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.ForeColor = System.Drawing.SystemColors.WindowText;
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.InBackColor = System.Drawing.SystemColors.Info;
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.InForeColor = System.Drawing.SystemColors.WindowText;
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.Location = new System.Drawing.Point(0, 46);
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.Name = "object_4768fc6f_a803_4ffb_b570_8860fe708900";
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.Negative = true;
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.NotEmpty = false;
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.NotEmptyColor = System.Drawing.Color.Red;
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.SelectOnEnter = true;
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.Size = new System.Drawing.Size(938, 20);
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.TabIndex = 3;
            this.object_4768fc6f_a803_4ffb_b570_8860fe708900.TextMode = ClassLibrary.TextModes.Text;
            // 
            // textEdit2
            // 
            this.textEdit2.ChangeColorIfNotEmpty = true;
            this.textEdit2.ChangeColorOnEnter = true;
            this.textEdit2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEdit2.InBackColor = System.Drawing.SystemColors.Info;
            this.textEdit2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.textEdit2.Location = new System.Drawing.Point(0, 23);
            this.textEdit2.Margin = new System.Windows.Forms.Padding(3, 8751, 3, 8751);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Negative = true;
            this.textEdit2.NotEmpty = false;
            this.textEdit2.NotEmptyColor = System.Drawing.Color.Red;
            this.textEdit2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textEdit2.SelectOnEnter = true;
            this.textEdit2.Size = new System.Drawing.Size(938, 20);
            this.textEdit2.TabIndex = 3;
            this.textEdit2.TextMode = ClassLibrary.TextModes.Text;
            // 
            // object_9b85e34b_9421_4bf2_b7e5_baba81bba67a
            // 
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.ChangeColorIfNotEmpty = true;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.ChangeColorOnEnter = true;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.Dock = System.Windows.Forms.DockStyle.Top;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.InBackColor = System.Drawing.SystemColors.Info;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.InForeColor = System.Drawing.SystemColors.WindowText;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.Location = new System.Drawing.Point(0, 0);
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.Name = "object_9b85e34b_9421_4bf2_b7e5_baba81bba67a";
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.Negative = true;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.NotEmpty = false;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.NotEmptyColor = System.Drawing.Color.Red;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.SelectOnEnter = true;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.Size = new System.Drawing.Size(938, 20);
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.TabIndex = 3;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(0, 20);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(938, 20);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // textEdit1
            // 
            this.textEdit1.ChangeColorIfNotEmpty = true;
            this.textEdit1.ChangeColorOnEnter = true;
            this.textEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.textEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.textEdit1.Location = new System.Drawing.Point(0, 0);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 478, 3, 478);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Negative = true;
            this.textEdit1.NotEmpty = false;
            this.textEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.textEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textEdit1.SelectOnEnter = true;
            this.textEdit1.Size = new System.Drawing.Size(938, 20);
            this.textEdit1.TabIndex = 3;
            this.textEdit1.TextMode = ClassLibrary.TextModes.Text;
            // 
            // JLetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 733);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JLetterForm";
            this.Text = "نامه";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JLetterForm_FormClosed);
            this.Load += new System.EventHandler(this.JLetterForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JLetterForm_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tbpInfo.ResumeLayout(false);
            this.pnlLetterInfo.ResumeLayout(false);
            this.pnlLetterInfo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCopies)).EndInit();
            this.tbpAttach.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tbpRefer.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpInfo;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private ArchivedDocuments.JArchiveList JArchive;
        private ClassLibrary.TextEdit txtDesc;
        private ClassLibrary.TextEdit textEdit1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel pnlLetterInfo;
        private ClassLibrary.JComboBox cmbUrgency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddCopyReceiver;
        private System.Windows.Forms.Button btnDeleteCopyReceiver;
        private ClassLibrary.TextEdit txtReason;
        private ClassLibrary.JDataGrid dgrCopies;
        private ClassLibrary.JComboBox cmbCopyReceiver;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.TextEdit txtSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.JComboBox cmbReceiver;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JComboBox cmbSender;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPostCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Full_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn CopyReason;
        private Automation.RefersText refersText1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Label lblSignStatus;
        private System.Windows.Forms.TabPage tbpRefer;
        private Automation.Refer.JRefersTextRTB jRefersTextRTB1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TabPage tbpAttach;
        //private ArchivedDocuments.JArchiveList jArchiveList1;
        private ClassLibrary.TextEdit object_4768fc6f_a803_4ffb_b570_8860fe708900;
        private ClassLibrary.TextEdit textEdit2;
        private ClassLibrary.TextEdit object_9b85e34b_9421_4bf2_b7e5_baba81bba67a;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnReply;
        private ClassLibrary.TextEdit txtParent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnParentLetter;
        private ClassLibrary.TextEdit txtLetterNo;
        private System.Windows.Forms.Label label9;
		private ArchivedDocuments.JArchiveList jArchiveList1;
		private Automation.RefersText refersText2;
		private System.Windows.Forms.TabPage tabPage1;
		private Globals.Property.JPropertyValueUserControl jPropertyValueUserControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeViewRefer;
        private System.Windows.Forms.Panel panel2;
    }
}