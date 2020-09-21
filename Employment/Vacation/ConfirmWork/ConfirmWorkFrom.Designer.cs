namespace Employment
{
    partial class JConfirmWorkFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JConfirmWorkFrom));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new ClassLibrary.Controllers.JAutoTypeLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbConfirm = new System.Windows.Forms.GroupBox();
            this.rbNoConfirm = new System.Windows.Forms.RadioButton();
            this.rbConfirm = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkOverTime = new System.Windows.Forms.CheckBox();
            this.chkNoAbsent = new System.Windows.Forms.CheckBox();
            this.cmbRequester = new ClassLibrary.JComboBox(this.components);
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.MaskedTextBox();
            this.txtStartTime = new System.Windows.Forms.MaskedTextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.JArchive = new ArchivedDocuments.JArchiveList();
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a = new ClassLibrary.TextEdit(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.refersText = new Automation.RefersText();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbConfirm.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(604, 435);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.gbConfirm);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(596, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "تایید کارکرد";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lblStatus);
            this.groupBox4.Location = new System.Drawing.Point(8, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(583, 50);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblStatus.Location = new System.Drawing.Point(4, 11);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(575, 34);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.TextList = null;
            this.lblStatus.TimerInterval = 25;
            this.lblStatus.WaitTick = 100;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new System.Drawing.Point(0, 348);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(600, 58);
            this.panel1.TabIndex = 42;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(305, 8);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 40);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(451, 8);
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
            this.btnExit.Location = new System.Drawing.Point(3, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 40);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gbConfirm
            // 
            this.gbConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConfirm.Controls.Add(this.rbNoConfirm);
            this.gbConfirm.Controls.Add(this.rbConfirm);
            this.gbConfirm.Enabled = false;
            this.gbConfirm.Location = new System.Drawing.Point(8, 264);
            this.gbConfirm.Name = "gbConfirm";
            this.gbConfirm.Size = new System.Drawing.Size(582, 63);
            this.gbConfirm.TabIndex = 40;
            this.gbConfirm.TabStop = false;
            this.gbConfirm.Visible = false;
            // 
            // rbNoConfirm
            // 
            this.rbNoConfirm.AutoSize = true;
            this.rbNoConfirm.Location = new System.Drawing.Point(206, 22);
            this.rbNoConfirm.Name = "rbNoConfirm";
            this.rbNoConfirm.Size = new System.Drawing.Size(77, 20);
            this.rbNoConfirm.TabIndex = 9;
            this.rbNoConfirm.TabStop = true;
            this.rbNoConfirm.Text = "عدم تایید";
            this.rbNoConfirm.UseVisualStyleBackColor = true;
            // 
            // rbConfirm
            // 
            this.rbConfirm.AutoSize = true;
            this.rbConfirm.Checked = true;
            this.rbConfirm.Location = new System.Drawing.Point(334, 22);
            this.rbConfirm.Name = "rbConfirm";
            this.rbConfirm.Size = new System.Drawing.Size(50, 20);
            this.rbConfirm.TabIndex = 8;
            this.rbConfirm.TabStop = true;
            this.rbConfirm.Text = "تایید";
            this.rbConfirm.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkOverTime);
            this.groupBox2.Controls.Add(this.chkNoAbsent);
            this.groupBox2.Controls.Add(this.cmbRequester);
            this.groupBox2.Controls.Add(this.txtDesc);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtEndTime);
            this.groupBox2.Controls.Add(this.txtStartTime);
            this.groupBox2.Controls.Add(this.lblTime);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(8, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 207);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            // 
            // chkOverTime
            // 
            this.chkOverTime.AutoSize = true;
            this.chkOverTime.Location = new System.Drawing.Point(201, 181);
            this.chkOverTime.Name = "chkOverTime";
            this.chkOverTime.Size = new System.Drawing.Size(124, 20);
            this.chkOverTime.TabIndex = 7;
            this.chkOverTime.Text = "محاسبه اضافه کار";
            this.chkOverTime.UseVisualStyleBackColor = true;
            // 
            // chkNoAbsent
            // 
            this.chkNoAbsent.AutoSize = true;
            this.chkNoAbsent.Location = new System.Drawing.Point(334, 181);
            this.chkNoAbsent.Name = "chkNoAbsent";
            this.chkNoAbsent.Size = new System.Drawing.Size(123, 20);
            this.chkNoAbsent.TabIndex = 6;
            this.chkNoAbsent.Text = "تقاضای رفع غیبت";
            this.chkNoAbsent.UseVisualStyleBackColor = true;
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
            this.cmbRequester.Location = new System.Drawing.Point(6, 16);
            this.cmbRequester.Name = "cmbRequester";
            this.cmbRequester.NotEmpty = false;
            this.cmbRequester.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbRequester.SelectOnEnter = true;
            this.cmbRequester.Size = new System.Drawing.Size(460, 24);
            this.cmbRequester.TabIndex = 0;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(6, 80);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(460, 95);
            this.txtDesc.TabIndex = 5;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(472, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 16);
            this.label12.TabIndex = 34;
            this.label12.Text = "توضیحات :";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndTime.Location = new System.Drawing.Point(120, 46);
            this.txtEndTime.Mask = "90:00";
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(43, 23);
            this.txtEndTime.TabIndex = 4;
            this.txtEndTime.Leave += new System.EventHandler(this.txtEndTime_Leave);
            // 
            // txtStartTime
            // 
            this.txtStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartTime.Location = new System.Drawing.Point(245, 46);
            this.txtStartTime.Mask = "00:00";
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(43, 23);
            this.txtStartTime.TabIndex = 3;
            this.txtStartTime.ValidatingType = typeof(System.DateTime);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(57, 49);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(13, 16);
            this.lblTime.TabIndex = 30;
            this.lblTime.Text = "-";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "مدت :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "تا ساعت :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "از ساعت :";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(472, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 16);
            this.label18.TabIndex = 25;
            this.label18.Text = "تاریخ :";
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(366, 47);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.ReadOnly = true;
            this.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 2;
            this.txtDate.Text = "۱۳__/__/__";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(472, 19);
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
            this.tabPage2.Size = new System.Drawing.Size(596, 406);
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
            this.JArchive.Controls.Add(this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a);
            this.JArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JArchive.EnabledChange = true;
            this.JArchive.Location = new System.Drawing.Point(3, 3);
            this.JArchive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.JArchive.Name = "JArchive";
            this.JArchive.ObjectCode = 0;
            this.JArchive.ObjectCodes = null;
            this.JArchive.PlaceCode = 0;
            this.JArchive.Size = new System.Drawing.Size(590, 400);
            this.JArchive.SubjectCode = 0;
            this.JArchive.TabIndex = 0;
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
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.Size = new System.Drawing.Size(590, 23);
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.TabIndex = 3;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.TextMode = ClassLibrary.TextModes.Text;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.refersText);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(596, 406);
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
            this.refersText.Size = new System.Drawing.Size(596, 406);
            this.refersText.TabIndex = 0;
            // 
            // JConfirmWorkFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 435);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JConfirmWorkFrom";
            this.Text = "ConfirmWorkFrom";
            this.Load += new System.EventHandler(this.JConfirmWorkFrom_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbConfirm.ResumeLayout(false);
            this.gbConfirm.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.JArchive.ResumeLayout(false);
            this.JArchive.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbConfirm;
        private System.Windows.Forms.RadioButton rbNoConfirm;
        private System.Windows.Forms.RadioButton rbConfirm;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.JComboBox cmbRequester;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtEndTime;
        private System.Windows.Forms.MaskedTextBox txtStartTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label18;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private ArchivedDocuments.JArchiveList JArchive;
        private ClassLibrary.TextEdit object_9b85e34b_9421_4bf2_b7e5_baba81bba67a;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkOverTime;
        private System.Windows.Forms.CheckBox chkNoAbsent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private Automation.RefersText refersText;
        private System.Windows.Forms.GroupBox groupBox4;
        private ClassLibrary.Controllers.JAutoTypeLabel lblStatus;

    }
}