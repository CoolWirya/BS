namespace Legal
{
    partial class JChequesForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNote = new ClassLibrary.TextEdit(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNo = new ClassLibrary.TextEdit(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReceiverCode = new ClassLibrary.TextEdit(this.components);
            this.lblNational = new System.Windows.Forms.Label();
            this.lblFather = new System.Windows.Forms.Label();
            this.lblBrith = new System.Windows.Forms.Label();
            this.lblshsh = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAddReceiver = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtExportCode = new ClassLibrary.TextEdit(this.components);
            this.labDeadNationalCode = new System.Windows.Forms.Label();
            this.labDeaFatherName = new System.Windows.Forms.Label();
            this.labDeadDateofbirth = new System.Windows.Forms.Label();
            this.labDeadshsh = new System.Windows.Forms.Label();
            this.labDeadFamily = new System.Windows.Forms.Label();
            this.labDeadName = new System.Windows.Forms.Label();
            this.Dateofbirth = new System.Windows.Forms.Label();
            this.NationalCode = new System.Windows.Forms.Label();
            this.FatherName = new System.Windows.Forms.Label();
            this.Code = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.Family = new System.Windows.Forms.Label();
            this.shsh = new System.Windows.Forms.Label();
            this.btnAddSender = new System.Windows.Forms.Button();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeliverDate = new ClassLibrary.DateEdit(this.components);
            this.label54 = new System.Windows.Forms.Label();
            this.txtDateRecieve = new ClassLibrary.DateEdit(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.cmbConcern = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.JArchive = new ArchivedDocuments.JArchiveList();
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c = new ClassLibrary.TextEdit(this.components);
            this.object_a1001fab_a314_4191_a5ea_f85340222b20 = new ClassLibrary.TextEdit(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.JArchive.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(9, 371);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(740, 371);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(90, 371);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 15;
            this.btnSaveClose.Text = "ذخیره";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(828, 368);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(820, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "سند";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbBranch);
            this.groupBox1.Controls.Add(this.cmbBank);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNo);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDeliverDate);
            this.groupBox1.Controls.Add(this.label54);
            this.groupBox1.Controls.Add(this.txtDateRecieve);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.cmbConcern);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 333);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.ChangeColorIfNotEmpty = true;
            this.txtNote.ChangeColorOnEnter = true;
            this.txtNote.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNote.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNote.Location = new System.Drawing.Point(6, 215);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Negative = true;
            this.txtNote.NotEmpty = false;
            this.txtNote.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNote.SelectOnEnter = true;
            this.txtNote.Size = new System.Drawing.Size(723, 53);
            this.txtNote.TabIndex = 11;
            this.txtNote.TextMode = ClassLibrary.TextModes.Text;
            this.txtNote.TextChanged += new System.EventHandler(this.txtNote_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(728, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 77;
            this.label6.Text = "پشت نویسی:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(539, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 75;
            this.label4.Text = "شعبه:";
            // 
            // cmbBranch
            // 
            this.cmbBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(402, 49);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(134, 24);
            this.cmbBranch.TabIndex = 7;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            // 
            // cmbBank
            // 
            this.cmbBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(402, 15);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(134, 24);
            this.cmbBank.TabIndex = 3;
            this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.cmbBank_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(539, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 73;
            this.label5.Text = "نام بانک:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(738, 19);
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
            this.txtNo.Location = new System.Drawing.Point(600, 15);
            this.txtNo.Name = "txtNo";
            this.txtNo.Negative = true;
            this.txtNo.NotEmpty = false;
            this.txtNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNo.SelectOnEnter = true;
            this.txtNo.Size = new System.Drawing.Size(132, 23);
            this.txtNo.TabIndex = 2;
            this.txtNo.TextMode = ClassLibrary.TextModes.Real;
            this.txtNo.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtReceiverCode);
            this.groupBox2.Controls.Add(this.lblNational);
            this.groupBox2.Controls.Add(this.lblFather);
            this.groupBox2.Controls.Add(this.lblBrith);
            this.groupBox2.Controls.Add(this.lblshsh);
            this.groupBox2.Controls.Add(this.lblLastName);
            this.groupBox2.Controls.Add(this.lblName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.btnAddReceiver);
            this.groupBox2.Location = new System.Drawing.Point(5, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 131);
            this.groupBox2.TabIndex = 69;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "گیرنده:";
            // 
            // txtReceiverCode
            // 
            this.txtReceiverCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceiverCode.ChangeColorIfNotEmpty = false;
            this.txtReceiverCode.ChangeColorOnEnter = true;
            this.txtReceiverCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtReceiverCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReceiverCode.Location = new System.Drawing.Point(69, 17);
            this.txtReceiverCode.Name = "txtReceiverCode";
            this.txtReceiverCode.Negative = true;
            this.txtReceiverCode.NotEmpty = false;
            this.txtReceiverCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtReceiverCode.ReadOnly = true;
            this.txtReceiverCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReceiverCode.SelectOnEnter = true;
            this.txtReceiverCode.Size = new System.Drawing.Size(109, 23);
            this.txtReceiverCode.TabIndex = 52;
            this.txtReceiverCode.TextMode = ClassLibrary.TextModes.Integer;
            this.txtReceiverCode.TextChanged += new System.EventHandler(this.txtReceiverCode_TextChanged);
            // 
            // lblNational
            // 
            this.lblNational.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNational.AutoSize = true;
            this.lblNational.Location = new System.Drawing.Point(62, 74);
            this.lblNational.Name = "lblNational";
            this.lblNational.Size = new System.Drawing.Size(24, 16);
            this.lblNational.TabIndex = 51;
            this.lblNational.Text = "....";
            // 
            // lblFather
            // 
            this.lblFather.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFather.AutoSize = true;
            this.lblFather.Location = new System.Drawing.Point(62, 46);
            this.lblFather.Name = "lblFather";
            this.lblFather.Size = new System.Drawing.Size(24, 16);
            this.lblFather.TabIndex = 50;
            this.lblFather.Text = "....";
            // 
            // lblBrith
            // 
            this.lblBrith.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBrith.AutoSize = true;
            this.lblBrith.Location = new System.Drawing.Point(62, 102);
            this.lblBrith.Name = "lblBrith";
            this.lblBrith.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBrith.Size = new System.Drawing.Size(24, 16);
            this.lblBrith.TabIndex = 49;
            this.lblBrith.Text = "....";
            // 
            // lblshsh
            // 
            this.lblshsh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblshsh.AutoSize = true;
            this.lblshsh.Location = new System.Drawing.Point(249, 100);
            this.lblshsh.Name = "lblshsh";
            this.lblshsh.Size = new System.Drawing.Size(20, 16);
            this.lblshsh.TabIndex = 48;
            this.lblshsh.Text = "...";
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(249, 72);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(20, 16);
            this.lblLastName.TabIndex = 47;
            this.lblLastName.Text = "...";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(248, 42);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(20, 16);
            this.lblName.TabIndex = 46;
            this.lblName.Text = "...";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(123, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 16);
            this.label9.TabIndex = 45;
            this.label9.Text = "birthdate";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(94, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 44;
            this.label10.Text = "NationalCode:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(99, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 16);
            this.label11.TabIndex = 43;
            this.label11.Text = "FatherName:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(331, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 16);
            this.label12.TabIndex = 42;
            this.label12.Text = "Code:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(331, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 16);
            this.label13.TabIndex = 39;
            this.label13.Text = "name:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(329, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 16);
            this.label14.TabIndex = 40;
            this.label14.Text = "LastName:";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(358, 100);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 16);
            this.label15.TabIndex = 41;
            this.label15.Text = "shsh:";
            // 
            // btnAddReceiver
            // 
            this.btnAddReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddReceiver.Location = new System.Drawing.Point(28, 18);
            this.btnAddReceiver.Name = "btnAddReceiver";
            this.btnAddReceiver.Size = new System.Drawing.Size(35, 23);
            this.btnAddReceiver.TabIndex = 10;
            this.btnAddReceiver.Text = "...";
            this.btnAddReceiver.UseVisualStyleBackColor = true;
            this.btnAddReceiver.Click += new System.EventHandler(this.btnAddReceiver_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtExportCode);
            this.groupBox3.Controls.Add(this.labDeadNationalCode);
            this.groupBox3.Controls.Add(this.labDeaFatherName);
            this.groupBox3.Controls.Add(this.labDeadDateofbirth);
            this.groupBox3.Controls.Add(this.labDeadshsh);
            this.groupBox3.Controls.Add(this.labDeadFamily);
            this.groupBox3.Controls.Add(this.labDeadName);
            this.groupBox3.Controls.Add(this.Dateofbirth);
            this.groupBox3.Controls.Add(this.NationalCode);
            this.groupBox3.Controls.Add(this.FatherName);
            this.groupBox3.Controls.Add(this.Code);
            this.groupBox3.Controls.Add(this.name);
            this.groupBox3.Controls.Add(this.Family);
            this.groupBox3.Controls.Add(this.shsh);
            this.groupBox3.Controls.Add(this.btnAddSender);
            this.groupBox3.Location = new System.Drawing.Point(408, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 131);
            this.groupBox3.TabIndex = 68;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "صادرکننده:";
            // 
            // txtExportCode
            // 
            this.txtExportCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportCode.ChangeColorIfNotEmpty = false;
            this.txtExportCode.ChangeColorOnEnter = true;
            this.txtExportCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtExportCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtExportCode.Location = new System.Drawing.Point(89, 17);
            this.txtExportCode.Name = "txtExportCode";
            this.txtExportCode.Negative = true;
            this.txtExportCode.NotEmpty = false;
            this.txtExportCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtExportCode.ReadOnly = true;
            this.txtExportCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtExportCode.SelectOnEnter = true;
            this.txtExportCode.Size = new System.Drawing.Size(109, 23);
            this.txtExportCode.TabIndex = 37;
            this.txtExportCode.TextMode = ClassLibrary.TextModes.Integer;
            this.txtExportCode.TextChanged += new System.EventHandler(this.txtExportCode_TextChanged);
            // 
            // labDeadNationalCode
            // 
            this.labDeadNationalCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labDeadNationalCode.AutoSize = true;
            this.labDeadNationalCode.Location = new System.Drawing.Point(62, 69);
            this.labDeadNationalCode.Name = "labDeadNationalCode";
            this.labDeadNationalCode.Size = new System.Drawing.Size(24, 16);
            this.labDeadNationalCode.TabIndex = 36;
            this.labDeadNationalCode.Text = "....";
            // 
            // labDeaFatherName
            // 
            this.labDeaFatherName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labDeaFatherName.AutoSize = true;
            this.labDeaFatherName.Location = new System.Drawing.Point(62, 41);
            this.labDeaFatherName.Name = "labDeaFatherName";
            this.labDeaFatherName.Size = new System.Drawing.Size(24, 16);
            this.labDeaFatherName.TabIndex = 35;
            this.labDeaFatherName.Text = "....";
            // 
            // labDeadDateofbirth
            // 
            this.labDeadDateofbirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labDeadDateofbirth.AutoSize = true;
            this.labDeadDateofbirth.Location = new System.Drawing.Point(62, 97);
            this.labDeadDateofbirth.Name = "labDeadDateofbirth";
            this.labDeadDateofbirth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labDeadDateofbirth.Size = new System.Drawing.Size(24, 16);
            this.labDeadDateofbirth.TabIndex = 34;
            this.labDeadDateofbirth.Text = "....";
            // 
            // labDeadshsh
            // 
            this.labDeadshsh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labDeadshsh.AutoSize = true;
            this.labDeadshsh.Location = new System.Drawing.Point(252, 101);
            this.labDeadshsh.Name = "labDeadshsh";
            this.labDeadshsh.Size = new System.Drawing.Size(20, 16);
            this.labDeadshsh.TabIndex = 33;
            this.labDeadshsh.Text = "...";
            // 
            // labDeadFamily
            // 
            this.labDeadFamily.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labDeadFamily.AutoSize = true;
            this.labDeadFamily.Location = new System.Drawing.Point(252, 73);
            this.labDeadFamily.Name = "labDeadFamily";
            this.labDeadFamily.Size = new System.Drawing.Size(20, 16);
            this.labDeadFamily.TabIndex = 32;
            this.labDeadFamily.Text = "...";
            // 
            // labDeadName
            // 
            this.labDeadName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labDeadName.AutoSize = true;
            this.labDeadName.Location = new System.Drawing.Point(251, 43);
            this.labDeadName.Name = "labDeadName";
            this.labDeadName.Size = new System.Drawing.Size(20, 16);
            this.labDeadName.TabIndex = 31;
            this.labDeadName.Text = "...";
            // 
            // Dateofbirth
            // 
            this.Dateofbirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Dateofbirth.AutoSize = true;
            this.Dateofbirth.Location = new System.Drawing.Point(116, 99);
            this.Dateofbirth.Name = "Dateofbirth";
            this.Dateofbirth.Size = new System.Drawing.Size(64, 16);
            this.Dateofbirth.TabIndex = 30;
            this.Dateofbirth.Text = "birthdate:";
            // 
            // NationalCode
            // 
            this.NationalCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NationalCode.AutoSize = true;
            this.NationalCode.Location = new System.Drawing.Point(92, 71);
            this.NationalCode.Name = "NationalCode";
            this.NationalCode.Size = new System.Drawing.Size(88, 16);
            this.NationalCode.TabIndex = 29;
            this.NationalCode.Text = "NationalCode:";
            // 
            // FatherName
            // 
            this.FatherName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FatherName.AutoSize = true;
            this.FatherName.Location = new System.Drawing.Point(97, 43);
            this.FatherName.Name = "FatherName";
            this.FatherName.Size = new System.Drawing.Size(83, 16);
            this.FatherName.TabIndex = 28;
            this.FatherName.Text = "FatherName:";
            // 
            // Code
            // 
            this.Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Code.AutoSize = true;
            this.Code.Location = new System.Drawing.Point(333, 17);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(42, 16);
            this.Code.TabIndex = 27;
            this.Code.Text = "Code:";
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(333, 43);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(45, 16);
            this.name.TabIndex = 24;
            this.name.Text = "name:";
            // 
            // Family
            // 
            this.Family.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Family.AutoSize = true;
            this.Family.Location = new System.Drawing.Point(329, 73);
            this.Family.Name = "Family";
            this.Family.Size = new System.Drawing.Size(69, 16);
            this.Family.TabIndex = 25;
            this.Family.Text = "LastName:";
            // 
            // shsh
            // 
            this.shsh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shsh.AutoSize = true;
            this.shsh.Location = new System.Drawing.Point(359, 99);
            this.shsh.Name = "shsh";
            this.shsh.Size = new System.Drawing.Size(39, 16);
            this.shsh.TabIndex = 26;
            this.shsh.Text = "shsh:";
            // 
            // btnAddSender
            // 
            this.btnAddSender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSender.Location = new System.Drawing.Point(48, 17);
            this.btnAddSender.Name = "btnAddSender";
            this.btnAddSender.Size = new System.Drawing.Size(35, 23);
            this.btnAddSender.TabIndex = 9;
            this.btnAddSender.Text = "...";
            this.btnAddSender.UseVisualStyleBackColor = true;
            this.btnAddSender.Click += new System.EventHandler(this.AddDiePerson_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(6, 274);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(723, 53);
            this.txtDesc.TabIndex = 12;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(731, 271);
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
            this.txtDeliverDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDeliverDate.Location = new System.Drawing.Point(6, 15);
            this.txtDeliverDate.Mask = "0000/00/00";
            this.txtDeliverDate.Name = "txtDeliverDate";
            this.txtDeliverDate.NotEmpty = false;
            this.txtDeliverDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDeliverDate.Size = new System.Drawing.Size(100, 23);
            this.txtDeliverDate.TabIndex = 5;
            this.txtDeliverDate.TextChanged += new System.EventHandler(this.txtDeliverDate_TextChanged);
            // 
            // label54
            // 
            this.label54.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(109, 52);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(95, 16);
            this.label54.TabIndex = 66;
            this.label54.Text = "تاريخ سررسيد :";
            // 
            // txtDateRecieve
            // 
            this.txtDateRecieve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateRecieve.ChangeColorIfNotEmpty = true;
            this.txtDateRecieve.ChangeColorOnEnter = true;
            this.txtDateRecieve.Date = new System.DateTime(((long)(0)));
            this.txtDateRecieve.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateRecieve.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateRecieve.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateRecieve.Location = new System.Drawing.Point(6, 49);
            this.txtDateRecieve.Mask = "0000/00/00";
            this.txtDateRecieve.Name = "txtDateRecieve";
            this.txtDateRecieve.NotEmpty = false;
            this.txtDateRecieve.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateRecieve.Size = new System.Drawing.Size(100, 23);
            this.txtDateRecieve.TabIndex = 8;
            this.txtDateRecieve.TextChanged += new System.EventHandler(this.txtDateRecieve_TextChanged);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(741, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 16);
            this.label20.TabIndex = 63;
            this.label20.Text = "بابت:";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(352, 19);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 16);
            this.label23.TabIndex = 65;
            this.label23.Text = "مبلغ :";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(214, 15);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(132, 23);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Real;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(107, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 16);
            this.label22.TabIndex = 64;
            this.label22.Text = "تاريخ تحويل :";
            // 
            // cmbConcern
            // 
            this.cmbConcern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.Location = new System.Drawing.Point(601, 49);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.Size = new System.Drawing.Size(134, 24);
            this.cmbConcern.TabIndex = 6;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.cmbConcern_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.JArchive);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(820, 339);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "تصاویر";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // JArchive
            // 
            this.JArchive.ClassName = "";
            this.JArchive.Controls.Add(this.object_41eddf10_982e_4d40_9f01_ee348a76105c);
            this.JArchive.Controls.Add(this.object_a1001fab_a314_4191_a5ea_f85340222b20);
            this.JArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JArchive.Location = new System.Drawing.Point(3, 3);
            this.JArchive.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.JArchive.Name = "JArchive";
            this.JArchive.ObjectCode = 0;
            this.JArchive.PlaceCode = 0;
            this.JArchive.Size = new System.Drawing.Size(814, 333);
            this.JArchive.SubjectCode = 0;
            this.JArchive.TabIndex = 1;
            // 
            // object_41eddf10_982e_4d40_9f01_ee348a76105c
            // 
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.ChangeColorIfNotEmpty = true;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.ChangeColorOnEnter = true;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.Dock = System.Windows.Forms.DockStyle.Top;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.InBackColor = System.Drawing.SystemColors.Info;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.InForeColor = System.Drawing.SystemColors.WindowText;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.Location = new System.Drawing.Point(0, 23);
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.Margin = new System.Windows.Forms.Padding(3, 26, 3, 26);
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.Name = "object_41eddf10_982e_4d40_9f01_ee348a76105c";
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.Negative = true;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.NotEmpty = false;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.NotEmptyColor = System.Drawing.Color.Red;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.SelectOnEnter = true;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.Size = new System.Drawing.Size(814, 23);
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.TabIndex = 3;
            this.object_41eddf10_982e_4d40_9f01_ee348a76105c.TextMode = ClassLibrary.TextModes.Text;
            // 
            // object_a1001fab_a314_4191_a5ea_f85340222b20
            // 
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.BackColor = System.Drawing.SystemColors.Info;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.ChangeColorIfNotEmpty = true;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.ChangeColorOnEnter = true;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.Dock = System.Windows.Forms.DockStyle.Top;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.ForeColor = System.Drawing.SystemColors.WindowText;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.InBackColor = System.Drawing.SystemColors.Info;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.InForeColor = System.Drawing.SystemColors.WindowText;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.Location = new System.Drawing.Point(0, 0);
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.Margin = new System.Windows.Forms.Padding(3, 111, 3, 111);
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.Name = "object_a1001fab_a314_4191_a5ea_f85340222b20";
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.Negative = true;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.NotEmpty = false;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.NotEmptyColor = System.Drawing.Color.Red;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.SelectOnEnter = true;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.Size = new System.Drawing.Size(814, 23);
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.TabIndex = 3;
            this.object_a1001fab_a314_4191_a5ea_f85340222b20.TextMode = ClassLibrary.TextModes.Text;
            // 
            // JChequesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(828, 400);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.tabControl1);
            this.Name = "JChequesForm";
            this.Load += new System.EventHandler(this.JChequesForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.JArchive.ResumeLayout(false);
            this.JArchive.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit txtNote;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.TextEdit txtReceiverCode;
        private System.Windows.Forms.Label lblNational;
        private System.Windows.Forms.Label lblFather;
        private System.Windows.Forms.Label lblBrith;
        private System.Windows.Forms.Label lblshsh;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAddReceiver;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.TextEdit txtExportCode;
        private System.Windows.Forms.Label labDeadNationalCode;
        private System.Windows.Forms.Label labDeaFatherName;
        private System.Windows.Forms.Label labDeadDateofbirth;
        private System.Windows.Forms.Label labDeadshsh;
        private System.Windows.Forms.Label labDeadFamily;
        private System.Windows.Forms.Label labDeadName;
        private System.Windows.Forms.Label Dateofbirth;
        private System.Windows.Forms.Label NationalCode;
        private System.Windows.Forms.Label FatherName;
        private System.Windows.Forms.Label Code;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label Family;
        private System.Windows.Forms.Label shsh;
        private System.Windows.Forms.Button btnAddSender;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.DateEdit txtDeliverDate;
        private System.Windows.Forms.Label label54;
        private ClassLibrary.DateEdit txtDateRecieve;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private ClassLibrary.TextEdit txtPrice;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbConcern;
        private System.Windows.Forms.TabPage tabPage3;
        private ArchivedDocuments.JArchiveList JArchive;
        private ClassLibrary.TextEdit object_41eddf10_982e_4d40_9f01_ee348a76105c;
        private ClassLibrary.TextEdit object_a1001fab_a314_4191_a5ea_f85340222b20;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveClose;
    }
}