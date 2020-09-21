namespace Communication
{
    partial class JImportedLetterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JImportedLetterForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpInfo = new System.Windows.Forms.TabPage();
            this.btnParentLetter = new System.Windows.Forms.Button();
            this.jArchiveImage1 = new ArchivedDocuments.JArchiveImage(this.components);
            this.txtContent = new ClassLibrary.JEditor();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlLetterInfo = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtYear = new ClassLibrary.TextEdit(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtLetterNo = new ClassLibrary.TextEdit(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtIncomingLetterNo = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.dteIncomingLetterDate = new ClassLibrary.DateEdit(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtSignaturePerson = new ClassLibrary.TextEdit(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtSender = new ClassLibrary.TextEdit(this.components);
            this.cmbUrgency = new ClassLibrary.JComboBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtSubject = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbReceiver = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tbpAttach = new System.Windows.Forms.TabPage();
            this.jArchiveList1 = new ArchivedDocuments.JArchiveList();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jPropertyValueUserControl1 = new Globals.Property.JPropertyValueUserControl();
            this.tbpRefer = new System.Windows.Forms.TabPage();
            this.refersText1 = new Automation.RefersText();
            this.jRefersTextRTB1 = new Automation.Refer.JRefersTextRTB();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeViewRefer = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewNumber = new System.Windows.Forms.Button();
            this.btnExportReplay = new System.Windows.Forms.Button();
            this.btnReply = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRefer = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chbAllAttachment = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tbpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jArchiveImage1)).BeginInit();
            this.pnlLetterInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tbpAttach.SuspendLayout();
            this.jArchiveList1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tbpRefer.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.tabControl1.Location = new System.Drawing.Point(0, 39);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(929, 540);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 2;
            // 
            // tbpInfo
            // 
            this.tbpInfo.BackColor = System.Drawing.Color.Transparent;
            this.tbpInfo.Controls.Add(this.btnParentLetter);
            this.tbpInfo.Controls.Add(this.jArchiveImage1);
            this.tbpInfo.Controls.Add(this.txtContent);
            this.tbpInfo.Controls.Add(this.splitter1);
            this.tbpInfo.Controls.Add(this.pnlLetterInfo);
            this.tbpInfo.ImageKey = "info_s24.png";
            this.tbpInfo.Location = new System.Drawing.Point(4, 34);
            this.tbpInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpInfo.Name = "tbpInfo";
            this.tbpInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpInfo.Size = new System.Drawing.Size(921, 502);
            this.tbpInfo.TabIndex = 0;
            this.tbpInfo.Text = "اطلاعات نامه";
            this.tbpInfo.UseVisualStyleBackColor = true;
            // 
            // btnParentLetter
            // 
            this.btnParentLetter.BackColor = System.Drawing.SystemColors.Control;
            this.btnParentLetter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParentLetter.Image = ((System.Drawing.Image)(resources.GetObject("btnParentLetter.Image")));
            this.btnParentLetter.Location = new System.Drawing.Point(6, 40);
            this.btnParentLetter.Name = "btnParentLetter";
            this.btnParentLetter.Size = new System.Drawing.Size(72, 57);
            this.btnParentLetter.TabIndex = 86;
            this.btnParentLetter.Text = "نامه قبلی";
            this.btnParentLetter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnParentLetter.UseVisualStyleBackColor = false;
            this.btnParentLetter.Visible = false;
            this.btnParentLetter.Click += new System.EventHandler(this.btnParentLetter_Click);
            // 
            // jArchiveImage1
            // 
            this.jArchiveImage1.ArchiveCode = 0;
            this.jArchiveImage1.AutoChange = false;
            this.jArchiveImage1.ClassName = null;
            this.jArchiveImage1.DeleteCompeletly = false;
            this.jArchiveImage1.Description = null;
            this.jArchiveImage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveImage1.ImageFile = null;
            this.jArchiveImage1.Location = new System.Drawing.Point(3, 4);
            this.jArchiveImage1.Name = "jArchiveImage1";
            this.jArchiveImage1.ObjectCode = 0;
            this.jArchiveImage1.PlaceCode = 0;
            this.jArchiveImage1.Size = new System.Drawing.Size(521, 494);
            this.jArchiveImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.jArchiveImage1.State = ClassLibrary.JFormState.None;
            this.jArchiveImage1.SubjectCode = 0;
            this.jArchiveImage1.TabIndex = 85;
            this.jArchiveImage1.TabStop = false;
            // 
            // txtContent
            // 
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Location = new System.Drawing.Point(3, 4);
            this.txtContent.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(521, 494);
            this.txtContent.TabIndex = 77;
            this.txtContent.TabStop = false;
            this.txtContent.ViewMode = false;
            this.txtContent.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(524, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 494);
            this.splitter1.TabIndex = 46;
            this.splitter1.TabStop = false;
            // 
            // pnlLetterInfo
            // 
            this.pnlLetterInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlLetterInfo.Controls.Add(this.panel2);
            this.pnlLetterInfo.Controls.Add(this.dteIncomingLetterDate);
            this.pnlLetterInfo.Controls.Add(this.label7);
            this.pnlLetterInfo.Controls.Add(this.txtSignaturePerson);
            this.pnlLetterInfo.Controls.Add(this.label5);
            this.pnlLetterInfo.Controls.Add(this.txtSender);
            this.pnlLetterInfo.Controls.Add(this.cmbUrgency);
            this.pnlLetterInfo.Controls.Add(this.label6);
            this.pnlLetterInfo.Controls.Add(this.txtSubject);
            this.pnlLetterInfo.Controls.Add(this.label3);
            this.pnlLetterInfo.Controls.Add(this.label2);
            this.pnlLetterInfo.Controls.Add(this.cmbReceiver);
            this.pnlLetterInfo.Controls.Add(this.label1);
            this.pnlLetterInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLetterInfo.Location = new System.Drawing.Point(525, 4);
            this.pnlLetterInfo.Name = "pnlLetterInfo";
            this.pnlLetterInfo.Size = new System.Drawing.Size(393, 494);
            this.pnlLetterInfo.TabIndex = 76;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.txtYear);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtLetterNo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtIncomingLetterNo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(393, 99);
            this.panel2.TabIndex = 1;
            // 
            // txtYear
            // 
            this.txtYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYear.ChangeColorIfNotEmpty = false;
            this.txtYear.ChangeColorOnEnter = true;
            this.txtYear.InBackColor = System.Drawing.SystemColors.Info;
            this.txtYear.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtYear.Location = new System.Drawing.Point(177, 6);
            this.txtYear.Name = "txtYear";
            this.txtYear.Negative = true;
            this.txtYear.NotEmpty = false;
            this.txtYear.NotEmptyColor = System.Drawing.Color.Red;
            this.txtYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtYear.SelectOnEnter = true;
            this.txtYear.Size = new System.Drawing.Size(74, 23);
            this.txtYear.TabIndex = 2;
            this.txtYear.Text = "13";
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYear.TextMode = ClassLibrary.TextModes.Text;
            this.txtYear.Leave += new System.EventHandler(this.txtYear_Leave);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(257, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 21);
            this.label9.TabIndex = 98;
            this.label9.Text = "سال:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLetterNo
            // 
            this.txtLetterNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLetterNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLetterNo.ChangeColorIfNotEmpty = false;
            this.txtLetterNo.ChangeColorOnEnter = true;
            this.txtLetterNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLetterNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLetterNo.Location = new System.Drawing.Point(177, 35);
            this.txtLetterNo.Name = "txtLetterNo";
            this.txtLetterNo.Negative = true;
            this.txtLetterNo.NotEmpty = false;
            this.txtLetterNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLetterNo.ReadOnly = true;
            this.txtLetterNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterNo.SelectOnEnter = true;
            this.txtLetterNo.Size = new System.Drawing.Size(74, 23);
            this.txtLetterNo.TabIndex = 3;
            this.txtLetterNo.TextMode = ClassLibrary.TextModes.Text;
            this.txtLetterNo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtLetterNo_MouseClick);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(255, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 21);
            this.label8.TabIndex = 96;
            this.label8.Text = "شماره نامه دبیرخانه :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIncomingLetterNo
            // 
            this.txtIncomingLetterNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncomingLetterNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIncomingLetterNo.ChangeColorIfNotEmpty = false;
            this.txtIncomingLetterNo.ChangeColorOnEnter = true;
            this.txtIncomingLetterNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtIncomingLetterNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIncomingLetterNo.Location = new System.Drawing.Point(6, 64);
            this.txtIncomingLetterNo.Name = "txtIncomingLetterNo";
            this.txtIncomingLetterNo.Negative = true;
            this.txtIncomingLetterNo.NotEmpty = false;
            this.txtIncomingLetterNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtIncomingLetterNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIncomingLetterNo.SelectOnEnter = true;
            this.txtIncomingLetterNo.Size = new System.Drawing.Size(245, 23);
            this.txtIncomingLetterNo.TabIndex = 4;
            this.txtIncomingLetterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIncomingLetterNo.TextMode = ClassLibrary.TextModes.Text;
            this.txtIncomingLetterNo.Enter += new System.EventHandler(this.txtIncomingLetterNo_Enter);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(257, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 21);
            this.label4.TabIndex = 94;
            this.label4.Text = "شماره نامه وارده :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteIncomingLetterDate
            // 
            this.dteIncomingLetterDate.ChangeColorIfNotEmpty = true;
            this.dteIncomingLetterDate.ChangeColorOnEnter = true;
            this.dteIncomingLetterDate.Date = new System.DateTime(((long)(0)));
            this.dteIncomingLetterDate.InBackColor = System.Drawing.SystemColors.Info;
            this.dteIncomingLetterDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.dteIncomingLetterDate.InsertInDatesTable = true;
            this.dteIncomingLetterDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteIncomingLetterDate.Location = new System.Drawing.Point(177, 118);
            this.dteIncomingLetterDate.Mask = "0000/00/00";
            this.dteIncomingLetterDate.Name = "dteIncomingLetterDate";
            this.dteIncomingLetterDate.NotEmpty = false;
            this.dteIncomingLetterDate.NotEmptyColor = System.Drawing.Color.Red;
            this.dteIncomingLetterDate.Size = new System.Drawing.Size(94, 23);
            this.dteIncomingLetterDate.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(277, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 21);
            this.label7.TabIndex = 90;
            this.label7.Tag = "تاریخ ورود نامه به دبیرخانه";
            this.label7.Text = "تاریخ نامه وارده :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSignaturePerson
            // 
            this.txtSignaturePerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignaturePerson.ChangeColorIfNotEmpty = false;
            this.txtSignaturePerson.ChangeColorOnEnter = true;
            this.txtSignaturePerson.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSignaturePerson.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSignaturePerson.Location = new System.Drawing.Point(5, 236);
            this.txtSignaturePerson.Name = "txtSignaturePerson";
            this.txtSignaturePerson.Negative = true;
            this.txtSignaturePerson.NotEmpty = false;
            this.txtSignaturePerson.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSignaturePerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSignaturePerson.SelectOnEnter = true;
            this.txtSignaturePerson.Size = new System.Drawing.Size(265, 23);
            this.txtSignaturePerson.TabIndex = 9;
            this.txtSignaturePerson.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(277, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 88;
            this.label5.Text = "امضا کننده :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSender
            // 
            this.txtSender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSender.ChangeColorIfNotEmpty = false;
            this.txtSender.ChangeColorOnEnter = true;
            this.txtSender.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSender.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSender.Location = new System.Drawing.Point(5, 148);
            this.txtSender.Name = "txtSender";
            this.txtSender.Negative = true;
            this.txtSender.NotEmpty = false;
            this.txtSender.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSender.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSender.SelectOnEnter = true;
            this.txtSender.Size = new System.Drawing.Size(265, 23);
            this.txtSender.TabIndex = 6;
            this.txtSender.TextMode = ClassLibrary.TextModes.Text;
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
            this.cmbUrgency.Location = new System.Drawing.Point(6, 265);
            this.cmbUrgency.Name = "cmbUrgency";
            this.cmbUrgency.NotEmpty = false;
            this.cmbUrgency.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbUrgency.SelectOnEnter = true;
            this.cmbUrgency.Size = new System.Drawing.Size(265, 24);
            this.cmbUrgency.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(278, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 21);
            this.label6.TabIndex = 83;
            this.label6.Text = "فوریت :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSubject
            // 
            this.txtSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubject.ChangeColorIfNotEmpty = false;
            this.txtSubject.ChangeColorOnEnter = true;
            this.txtSubject.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSubject.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubject.Location = new System.Drawing.Point(6, 207);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Negative = true;
            this.txtSubject.NotEmpty = false;
            this.txtSubject.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSubject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubject.SelectOnEnter = true;
            this.txtSubject.Size = new System.Drawing.Size(265, 23);
            this.txtSubject.TabIndex = 8;
            this.txtSubject.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(278, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 81;
            this.label3.Text = "موضوع :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(278, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
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
            this.cmbReceiver.Location = new System.Drawing.Point(6, 177);
            this.cmbReceiver.Name = "cmbReceiver";
            this.cmbReceiver.NotEmpty = false;
            this.cmbReceiver.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbReceiver.SelectOnEnter = true;
            this.cmbReceiver.Size = new System.Drawing.Size(265, 24);
            this.cmbReceiver.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(278, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 79;
            this.label1.Text = "فرستنده :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpAttach
            // 
            this.tbpAttach.Controls.Add(this.jArchiveList1);
            this.tbpAttach.ImageKey = "attachment_s24.png";
            this.tbpAttach.Location = new System.Drawing.Point(4, 34);
            this.tbpAttach.Name = "tbpAttach";
            this.tbpAttach.Size = new System.Drawing.Size(921, 502);
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
            this.jArchiveList1.Size = new System.Drawing.Size(921, 502);
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
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 37435, 3, 37435);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(921, 23);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.jPropertyValueUserControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(921, 502);
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
            this.jPropertyValueUserControl1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.jPropertyValueUserControl1.Name = "jPropertyValueUserControl1";
            this.jPropertyValueUserControl1.ObjectCode = -1;
            this.jPropertyValueUserControl1.Size = new System.Drawing.Size(915, 496);
            this.jPropertyValueUserControl1.TabIndex = 2;
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
            this.tbpRefer.Size = new System.Drawing.Size(921, 502);
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
            this.refersText1.Size = new System.Drawing.Size(915, 496);
            this.refersText1.TabIndex = 1;
            // 
            // jRefersTextRTB1
            // 
            this.jRefersTextRTB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jRefersTextRTB1.Location = new System.Drawing.Point(3, 3);
            this.jRefersTextRTB1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jRefersTextRTB1.Name = "jRefersTextRTB1";
            this.jRefersTextRTB1.Size = new System.Drawing.Size(915, 496);
            this.jRefersTextRTB1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeViewRefer);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(921, 502);
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
            this.treeViewRefer.Size = new System.Drawing.Size(915, 496);
            this.treeViewRefer.TabIndex = 1;
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
            this.panel1.Controls.Add(this.btnExportReplay);
            this.panel1.Controls.Add(this.btnReply);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnRefer);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 579);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(929, 58);
            this.panel1.TabIndex = 43;
            // 
            // btnNewNumber
            // 
            this.btnNewNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewNumber.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewNumber.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewNumber.Location = new System.Drawing.Point(268, 10);
            this.btnNewNumber.Name = "btnNewNumber";
            this.btnNewNumber.Size = new System.Drawing.Size(103, 39);
            this.btnNewNumber.TabIndex = 100;
            this.btnNewNumber.Text = "دریافت شماره";
            this.btnNewNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewNumber.UseVisualStyleBackColor = false;
            this.btnNewNumber.Visible = false;
            this.btnNewNumber.Click += new System.EventHandler(this.btnNewNumber_Click);
            // 
            // btnExportReplay
            // 
            this.btnExportReplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportReplay.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportReplay.Enabled = false;
            this.btnExportReplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportReplay.Image = ((System.Drawing.Image)(resources.GetObject("btnExportReplay.Image")));
            this.btnExportReplay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportReplay.Location = new System.Drawing.Point(486, 10);
            this.btnExportReplay.Name = "btnExportReplay";
            this.btnExportReplay.Size = new System.Drawing.Size(103, 39);
            this.btnExportReplay.TabIndex = 17;
            this.btnExportReplay.Text = "پیرو / صادره";
            this.btnExportReplay.UseVisualStyleBackColor = false;
            this.btnExportReplay.Click += new System.EventHandler(this.btnExportReplay_Click);
            // 
            // btnReply
            // 
            this.btnReply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReply.BackColor = System.Drawing.SystemColors.Control;
            this.btnReply.Enabled = false;
            this.btnReply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReply.Image = ((System.Drawing.Image)(resources.GetObject("btnReply.Image")));
            this.btnReply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReply.Location = new System.Drawing.Point(595, 10);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(103, 39);
            this.btnReply.TabIndex = 17;
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
            this.btnPrint.Location = new System.Drawing.Point(377, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(103, 39);
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
            this.btnRefer.Location = new System.Drawing.Point(704, 11);
            this.btnRefer.Name = "btnRefer";
            this.btnRefer.Size = new System.Drawing.Size(103, 39);
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
            this.btnSave.Location = new System.Drawing.Point(813, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 40);
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
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel3.Controls.Add(this.chbAllAttachment);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel3.Size = new System.Drawing.Size(929, 39);
            this.panel3.TabIndex = 45;
            // 
            // chbAllAttachment
            // 
            this.chbAllAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbAllAttachment.AutoSize = true;
            this.chbAllAttachment.Location = new System.Drawing.Point(722, 11);
            this.chbAllAttachment.Name = "chbAllAttachment";
            this.chbAllAttachment.Size = new System.Drawing.Size(200, 20);
            this.chbAllAttachment.TabIndex = 0;
            this.chbAllAttachment.Text = "نمایش تمام تصاویر در صفحه اول";
            this.chbAllAttachment.UseVisualStyleBackColor = true;
            this.chbAllAttachment.CheckedChanged += new System.EventHandler(this.chbAllAttachment_CheckedChanged);
            // 
            // JImportedLetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 637);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "JImportedLetterForm";
            this.Text = "نامه وارده";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InLetterForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbpInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jArchiveImage1)).EndInit();
            this.pnlLetterInfo.ResumeLayout(false);
            this.pnlLetterInfo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tbpAttach.ResumeLayout(false);
            this.jArchiveList1.ResumeLayout(false);
            this.jArchiveList1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tbpRefer.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpInfo;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlLetterInfo;
        private ClassLibrary.JComboBox cmbUrgency;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.TextEdit txtSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
      
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnRefer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabPage tbpAttach;
        private ArchivedDocuments.JArchiveList jArchiveList1;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.TabPage tbpRefer;
		private Automation.Refer.JRefersTextRTB jRefersTextRTB1;
        private ClassLibrary.TextEdit txtSignaturePerson;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.TextEdit txtSender;
        private ClassLibrary.JComboBox cmbReceiver;
        private System.Windows.Forms.Label label7;
		private ClassLibrary.DateEdit dteIncomingLetterDate;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private ClassLibrary.TextEdit txtLetterNo;
        private System.Windows.Forms.Label label8;
        private ClassLibrary.TextEdit txtIncomingLetterNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReply;
        private ClassLibrary.TextEdit txtYear;
        private System.Windows.Forms.Label label9;
		private Automation.RefersText refersText1;
		private System.Windows.Forms.TabPage tabPage1;
		private Globals.Property.JPropertyValueUserControl jPropertyValueUserControl1;
		private ArchivedDocuments.JArchiveImage jArchiveImage1;
		private ClassLibrary.JEditor txtContent;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.CheckBox chbAllAttachment;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeViewRefer;
        private System.Windows.Forms.Button btnExportReplay;
        private System.Windows.Forms.Button btnParentLetter;
        private System.Windows.Forms.Button btnNewNumber;
    }
}