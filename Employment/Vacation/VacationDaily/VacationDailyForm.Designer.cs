namespace Employment
{
    partial class JVacationDailyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JVacationDailyForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new ClassLibrary.Controllers.JAutoTypeLabel();
            this.gbConfirm = new System.Windows.Forms.GroupBox();
            this.rbNoConfirm = new System.Windows.Forms.RadioButton();
            this.rbConfirm = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.txtStartDate = new ClassLibrary.DateEdit(this.components);
            this.cmbRequester = new ClassLibrary.JComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbTashvighi = new System.Windows.Forms.RadioButton();
            this.rbBedone = new System.Windows.Forms.RadioButton();
            this.rbEstelaji = new System.Windows.Forms.RadioButton();
            this.rbEsteh = new System.Windows.Forms.RadioButton();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.JArchive = new ArchivedDocuments.JArchiveList();
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852 = new ClassLibrary.TextEdit(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.refersText = new Automation.RefersText();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbConfirm.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.JArchive.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(604, 482);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.gbConfirm);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(596, 453);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "مرخصی روزانه";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new System.Drawing.Point(0, 395);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(600, 58);
            this.panel1.TabIndex = 43;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(306, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBack.Size = new System.Drawing.Size(140, 40);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "برگشت مرخصی";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(452, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "ثبت درخواست";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(6, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 40);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lblStatus);
            this.groupBox4.Location = new System.Drawing.Point(3, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(590, 50);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblStatus.Location = new System.Drawing.Point(4, 11);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(581, 34);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.TextList = null;
            this.lblStatus.TimerInterval = 25;
            this.lblStatus.WaitTick = 100;
            // 
            // gbConfirm
            // 
            this.gbConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConfirm.Controls.Add(this.rbNoConfirm);
            this.gbConfirm.Controls.Add(this.rbConfirm);
            this.gbConfirm.Enabled = false;
            this.gbConfirm.Location = new System.Drawing.Point(2, 327);
            this.gbConfirm.Name = "gbConfirm";
            this.gbConfirm.Size = new System.Drawing.Size(590, 55);
            this.gbConfirm.TabIndex = 41;
            this.gbConfirm.TabStop = false;
            this.gbConfirm.VisibleChanged += new System.EventHandler(this.gbConfirm_VisibleChanged);
            // 
            // rbNoConfirm
            // 
            this.rbNoConfirm.AutoSize = true;
            this.rbNoConfirm.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rbNoConfirm.Location = new System.Drawing.Point(184, 20);
            this.rbNoConfirm.Name = "rbNoConfirm";
            this.rbNoConfirm.Size = new System.Drawing.Size(87, 23);
            this.rbNoConfirm.TabIndex = 9;
            this.rbNoConfirm.TabStop = true;
            this.rbNoConfirm.Text = "عدم تایید";
            this.rbNoConfirm.UseVisualStyleBackColor = true;
            // 
            // rbConfirm
            // 
            this.rbConfirm.AutoSize = true;
            this.rbConfirm.Checked = true;
            this.rbConfirm.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rbConfirm.Location = new System.Drawing.Point(376, 20);
            this.rbConfirm.Name = "rbConfirm";
            this.rbConfirm.Size = new System.Drawing.Size(55, 23);
            this.rbConfirm.TabIndex = 8;
            this.rbConfirm.TabStop = true;
            this.rbConfirm.Text = "تایید";
            this.rbConfirm.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtEndDate);
            this.groupBox2.Controls.Add(this.txtStartDate);
            this.groupBox2.Controls.Add(this.cmbRequester);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txtDesc);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblTime);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 277);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // txtEndDate
            // 
            this.txtEndDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtEndDate.ChangeColorIfNotEmpty = true;
            this.txtEndDate.ChangeColorOnEnter = true;
            this.txtEndDate.Date = new System.DateTime(((long)(0)));
            this.txtEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate.InsertInDatesTable = true;
            this.txtEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDate.Location = new System.Drawing.Point(146, 133);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate.ReadOnly = true;
            this.txtEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEndDate.Size = new System.Drawing.Size(139, 23);
            this.txtEndDate.TabIndex = 6;
            this.txtEndDate.Text = "۱۳__/__/__";
            this.txtEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEndDate.Leave += new System.EventHandler(this.txtEndDate_Leave);
            // 
            // txtStartDate
            // 
            this.txtStartDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartDate.ChangeColorIfNotEmpty = true;
            this.txtStartDate.ChangeColorOnEnter = true;
            this.txtStartDate.Date = new System.DateTime(((long)(0)));
            this.txtStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDate.InsertInDatesTable = true;
            this.txtStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartDate.Location = new System.Drawing.Point(365, 133);
            this.txtStartDate.Mask = "0000/00/00";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.NotEmpty = false;
            this.txtStartDate.NotEmptyColor = System.Drawing.Color.Red;
            //this.txtStartDate.ReadOnly = true;
            //this.txtStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStartDate.Size = new System.Drawing.Size(139, 23);
            this.txtStartDate.TabIndex = 5;
            //this.txtStartDate.Text = "۱۳__/__/__";
            this.txtStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbRequester
            // 
            this.cmbRequester.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRequester.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRequester.BaseCode = 0;
            this.cmbRequester.ChangeColorIfNotEmpty = true;
            this.cmbRequester.ChangeColorOnEnter = true;
            this.cmbRequester.FormattingEnabled = true;
            this.cmbRequester.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbRequester.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbRequester.Location = new System.Drawing.Point(12, 27);
            this.cmbRequester.Name = "cmbRequester";
            this.cmbRequester.NotEmpty = false;
            this.cmbRequester.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbRequester.SelectOnEnter = true;
            this.cmbRequester.Size = new System.Drawing.Size(455, 24);
            this.cmbRequester.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "تا تاریخ :";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.rbTashvighi);
            this.groupBox3.Controls.Add(this.rbBedone);
            this.groupBox3.Controls.Add(this.rbEstelaji);
            this.groupBox3.Controls.Add(this.rbEsteh);
            this.groupBox3.Location = new System.Drawing.Point(12, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(567, 55);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "نوع مرخصی";
            // 
            // rbTashvighi
            // 
            this.rbTashvighi.AutoSize = true;
            this.rbTashvighi.Location = new System.Drawing.Point(43, 22);
            this.rbTashvighi.Name = "rbTashvighi";
            this.rbTashvighi.Size = new System.Drawing.Size(74, 20);
            this.rbTashvighi.TabIndex = 4;
            this.rbTashvighi.Text = "تشویقی";
            this.rbTashvighi.UseVisualStyleBackColor = true;
            // 
            // rbBedone
            // 
            this.rbBedone.AutoSize = true;
            this.rbBedone.Location = new System.Drawing.Point(147, 22);
            this.rbBedone.Name = "rbBedone";
            this.rbBedone.Size = new System.Drawing.Size(88, 20);
            this.rbBedone.TabIndex = 3;
            this.rbBedone.Text = "بدون حقوق";
            this.rbBedone.UseVisualStyleBackColor = true;
            // 
            // rbEstelaji
            // 
            this.rbEstelaji.AutoSize = true;
            this.rbEstelaji.Location = new System.Drawing.Point(259, 22);
            this.rbEstelaji.Name = "rbEstelaji";
            this.rbEstelaji.Size = new System.Drawing.Size(84, 20);
            this.rbEstelaji.TabIndex = 2;
            this.rbEstelaji.Text = "استعلاجی";
            this.rbEstelaji.UseVisualStyleBackColor = true;
            // 
            // rbEsteh
            // 
            this.rbEsteh.AutoSize = true;
            this.rbEsteh.Checked = true;
            this.rbEsteh.Location = new System.Drawing.Point(368, 22);
            this.rbEsteh.Name = "rbEsteh";
            this.rbEsteh.Size = new System.Drawing.Size(83, 22);
            this.rbEsteh.TabIndex = 1;
            this.rbEsteh.TabStop = true;
            this.rbEsteh.Text = "استحقاقی";
            this.rbEsteh.UseCompatibleTextRendering = true;
            this.rbEsteh.UseVisualStyleBackColor = true;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(12, 166);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(492, 103);
            this.txtDesc.TabIndex = 7;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(510, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 16);
            this.label12.TabIndex = 34;
            this.label12.Text = "توضیحات :";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(31, 136);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(13, 16);
            this.lblTime.TabIndex = 30;
            this.lblTime.Text = "-";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "جمع مرخصی :";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(510, 136);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 16);
            this.label18.TabIndex = 25;
            this.label18.Text = "از تاریخ :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(478, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "درخواست کننده :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.JArchive);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(596, 453);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تصاویر";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // JArchive
            // 
            this.JArchive.AllowUserAddFile = true;
            this.JArchive.AllowUserAddFromArchive = true;
            this.JArchive.AllowUserAddImage = true;
            this.JArchive.AllowUserDeleteFile = true;
            this.JArchive.ClassName = "";
            this.JArchive.ClassNames = null;
            this.JArchive.Controls.Add(this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852);
            this.JArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JArchive.EnabledChange = true;
            this.JArchive.Location = new System.Drawing.Point(3, 3);
            this.JArchive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.JArchive.Name = "JArchive";
            this.JArchive.ObjectCode = 0;
            this.JArchive.ObjectCodes = null;
            this.JArchive.PlaceCode = 0;
            this.JArchive.Size = new System.Drawing.Size(590, 447);
            this.JArchive.SubjectCode = 0;
            this.JArchive.TabIndex = 0;
            // 
            // object_1bfc8ec6_d139_4c50_9400_ccc5212ce852
            // 
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.ChangeColorIfNotEmpty = true;
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.ChangeColorOnEnter = true;
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.Dock = System.Windows.Forms.DockStyle.Top;
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.InBackColor = System.Drawing.SystemColors.Info;
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.InForeColor = System.Drawing.SystemColors.WindowText;
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.Location = new System.Drawing.Point(0, 0);
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.Margin = new System.Windows.Forms.Padding(3, 20079, 3, 20079);
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.Name = "object_1bfc8ec6_d139_4c50_9400_ccc5212ce852";
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.Negative = true;
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.NotEmpty = false;
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.NotEmptyColor = System.Drawing.Color.Red;
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.SelectOnEnter = true;
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.Size = new System.Drawing.Size(590, 23);
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.TabIndex = 3;
            this.object_1bfc8ec6_d139_4c50_9400_ccc5212ce852.TextMode = ClassLibrary.TextModes.Text;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.refersText);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(596, 453);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ارجاعات";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // refersText
            // 
            this.refersText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refersText.Location = new System.Drawing.Point(0, 0);
            this.refersText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.refersText.Name = "refersText";
            this.refersText.Size = new System.Drawing.Size(596, 453);
            this.refersText.TabIndex = 0;
            // 
            // JVacationDailyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 482);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JVacationDailyForm";
            this.Text = "VacationDailyForm";
            this.Load += new System.EventHandler(this.JVacationHourForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.gbConfirm.ResumeLayout(false);
            this.gbConfirm.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.JArchive.ResumeLayout(false);
            this.JArchive.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private ArchivedDocuments.JArchiveList JArchive;
        private ClassLibrary.TextEdit object_1bfc8ec6_d139_4c50_9400_ccc5212ce852;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.JComboBox cmbRequester;
        private System.Windows.Forms.GroupBox gbConfirm;
        private System.Windows.Forms.RadioButton rbNoConfirm;
        private System.Windows.Forms.RadioButton rbConfirm;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbTashvighi;
        private System.Windows.Forms.RadioButton rbBedone;
        private System.Windows.Forms.RadioButton rbEstelaji;
        private System.Windows.Forms.RadioButton rbEsteh;
        private ClassLibrary.DateEdit txtEndDate;
        private ClassLibrary.DateEdit txtStartDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private Automation.RefersText refersText;
        private ClassLibrary.Controllers.JAutoTypeLabel lblStatus;
    }
}