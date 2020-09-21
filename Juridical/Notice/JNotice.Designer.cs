namespace Legal
{
    partial class JNoticeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JNoticeForm));
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSearchPetition = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNumber = new ClassLibrary.TextEdit(this.components);
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkInformed = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDateEnd = new ClassLibrary.DateEdit(this.components);
            this.txtDateMax = new ClassLibrary.TextEdit(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDateNotified = new ClassLibrary.DateEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.MaskedTextBox();
            this.txtReason = new ClassLibrary.TextEdit(this.components);
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.txtJudicial = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.jdgvFey = new ClassLibrary.JDataGrid();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtResult = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.jArchiveNotice = new ArchivedDocuments.JArchiveList();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvFey)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "aktion.png");
            this.imageList.Images.SetKeyName(1, "alert.png");
            this.imageList.Images.SetKeyName(2, "All software is current.png");
            this.imageList.Images.SetKeyName(3, "amor.png");
            this.imageList.Images.SetKeyName(4, "antivirus.png");
            this.imageList.Images.SetKeyName(5, "applixware.png");
            this.imageList.Images.SetKeyName(6, "ark.png");
            this.imageList.Images.SetKeyName(7, "arts.png");
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(363, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "علت حضور:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(316, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 16);
            this.label11.TabIndex = 6;
            this.label11.Text = "تاریخ وساعت حضور:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(321, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 16);
            this.label12.TabIndex = 8;
            this.label12.Text = "کددادخواست/شکوائیه:";
            // 
            // btnSearchPetition
            // 
            this.btnSearchPetition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchPetition.Location = new System.Drawing.Point(124, 19);
            this.btnSearchPetition.Name = "btnSearchPetition";
            this.btnSearchPetition.Size = new System.Drawing.Size(37, 23);
            this.btnSearchPetition.TabIndex = 10;
            this.btnSearchPetition.Text = "...";
            this.btnSearchPetition.UseVisualStyleBackColor = true;
            this.btnSearchPetition.Click += new System.EventHandler(this.btnSearchPetition_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNumber);
            this.groupBox3.Controls.Add(this.txtSubject);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.chkInformed);
            this.groupBox3.Controls.Add(this.btnSearchPetition);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(461, 80);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // txtNumber
            // 
            this.txtNumber.ChangeColorIfNotEmpty = false;
            this.txtNumber.ChangeColorOnEnter = true;
            this.txtNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumber.Location = new System.Drawing.Point(176, 19);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Negative = true;
            this.txtNumber.NotEmpty = false;
            this.txtNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumber.ReadOnly = true;
            this.txtNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumber.SelectOnEnter = true;
            this.txtNumber.Size = new System.Drawing.Size(136, 23);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.TextMode = ClassLibrary.TextModes.Text;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtResult_TextChanged);
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Enabled = false;
            this.txtSubject.Location = new System.Drawing.Point(124, 48);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(268, 23);
            this.txtSubject.TabIndex = 1;
            this.txtSubject.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(401, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 16);
            this.label16.TabIndex = 11;
            this.label16.Text = " موضوع:";
            // 
            // chkInformed
            // 
            this.chkInformed.AutoSize = true;
            this.chkInformed.Location = new System.Drawing.Point(12, 37);
            this.chkInformed.Name = "chkInformed";
            this.chkInformed.Size = new System.Drawing.Size(79, 20);
            this.chkInformed.TabIndex = 15;
            this.chkInformed.Text = "Informed";
            this.chkInformed.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDateEnd);
            this.groupBox2.Controls.Add(this.txtDateMax);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDateNotified);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtTime);
            this.groupBox2.Controls.Add(this.txtReason);
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(441, 359);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "روز";
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.ChangeColorIfNotEmpty = true;
            this.txtDateEnd.ChangeColorOnEnter = true;
            this.txtDateEnd.Date = new System.DateTime(((long)(0)));
            this.txtDateEnd.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateEnd.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateEnd.InsertInDatesTable = true;
            this.txtDateEnd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateEnd.Location = new System.Drawing.Point(209, 94);
            this.txtDateEnd.Mask = "0000/00/00";
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.NotEmpty = false;
            this.txtDateEnd.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateEnd.ReadOnly = true;
            this.txtDateEnd.Size = new System.Drawing.Size(100, 23);
            this.txtDateEnd.TabIndex = 2;
            this.txtDateEnd.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // txtDateMax
            // 
            this.txtDateMax.ChangeColorIfNotEmpty = false;
            this.txtDateMax.ChangeColorOnEnter = true;
            this.txtDateMax.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateMax.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateMax.Location = new System.Drawing.Point(210, 60);
            this.txtDateMax.Name = "txtDateMax";
            this.txtDateMax.Negative = true;
            this.txtDateMax.NotEmpty = false;
            this.txtDateMax.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateMax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDateMax.SelectOnEnter = true;
            this.txtDateMax.Size = new System.Drawing.Size(101, 23);
            this.txtDateMax.TabIndex = 1;
            this.txtDateMax.TextMode = ClassLibrary.TextModes.Text;
            this.txtDateMax.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            this.txtDateMax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDateMax_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(365, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "پایان مهلت:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "حداکثر مدت:";
            // 
            // txtDateNotified
            // 
            this.txtDateNotified.ChangeColorIfNotEmpty = true;
            this.txtDateNotified.ChangeColorOnEnter = true;
            this.txtDateNotified.Date = new System.DateTime(((long)(0)));
            this.txtDateNotified.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateNotified.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateNotified.InsertInDatesTable = true;
            this.txtDateNotified.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateNotified.Location = new System.Drawing.Point(209, 26);
            this.txtDateNotified.Mask = "0000/00/00";
            this.txtDateNotified.Name = "txtDateNotified";
            this.txtDateNotified.NotEmpty = false;
            this.txtDateNotified.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateNotified.Size = new System.Drawing.Size(101, 23);
            this.txtDateNotified.TabIndex = 0;
            this.txtDateNotified.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(368, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "تاریخ ابلاغ:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "ساعت:";
            // 
            // txtTime
            // 
            this.txtTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTime.Location = new System.Drawing.Point(91, 129);
            this.txtTime.Mask = "00:00";
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(47, 23);
            this.txtTime.TabIndex = 4;
            this.txtTime.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
            // 
            // txtReason
            // 
            this.txtReason.ChangeColorIfNotEmpty = false;
            this.txtReason.ChangeColorOnEnter = true;
            this.txtReason.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtReason.InBackColor = System.Drawing.SystemColors.Info;
            this.txtReason.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReason.Location = new System.Drawing.Point(3, 205);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Negative = true;
            this.txtReason.NotEmpty = false;
            this.txtReason.NotEmptyColor = System.Drawing.Color.Red;
            this.txtReason.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReason.SelectOnEnter = true;
            this.txtReason.Size = new System.Drawing.Size(435, 151);
            this.txtReason.TabIndex = 4;
            this.txtReason.TextMode = ClassLibrary.TextModes.Text;
            this.txtReason.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(211, 128);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 3;
            this.txtDate.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(455, 407);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(447, 378);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "مشخصات";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBranch);
            this.groupBox1.Controls.Add(this.txtJudicial);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(3, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 124);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "محل حضور:";
            // 
            // txtBranch
            // 
            this.txtBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBranch.Location = new System.Drawing.Point(74, 50);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(257, 23);
            this.txtBranch.TabIndex = 21;
            this.txtBranch.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // txtJudicial
            // 
            this.txtJudicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJudicial.Location = new System.Drawing.Point(74, 20);
            this.txtJudicial.Name = "txtJudicial";
            this.txtJudicial.Size = new System.Drawing.Size(257, 23);
            this.txtJudicial.TabIndex = 20;
            this.txtJudicial.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(333, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "مجتمع قضائی:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(332, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "شعبه:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.jdgvFey);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(441, 177);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "مشخصات اخطار شونده:";
            // 
            // jdgvFey
            // 
            this.jdgvFey.AllowUserToAddRows = false;
            this.jdgvFey.AllowUserToDeleteRows = false;
            this.jdgvFey.AllowUserToOrderColumns = true;
            this.jdgvFey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvFey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvFey.EnableContexMenu = true;
            this.jdgvFey.KeyName = null;
            this.jdgvFey.Location = new System.Drawing.Point(3, 19);
            this.jdgvFey.Name = "jdgvFey";
            this.jdgvFey.ReadHeadersFromDB = false;
            this.jdgvFey.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvFey.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvFey.ShowRowNumber = true;
            this.jdgvFey.Size = new System.Drawing.Size(435, 155);
            this.jdgvFey.TabIndex = 1;
            this.jdgvFey.TableName = null;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(447, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "تاریخ دادگاه";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtResult);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(447, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "نتایج دادگاه";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtResult
            // 
            this.txtResult.ChangeColorIfNotEmpty = false;
            this.txtResult.ChangeColorOnEnter = true;
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtResult.InBackColor = System.Drawing.SystemColors.Info;
            this.txtResult.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtResult.Location = new System.Drawing.Point(3, 43);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Negative = true;
            this.txtResult.NotEmpty = false;
            this.txtResult.NotEmptyColor = System.Drawing.Color.Red;
            this.txtResult.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtResult.SelectOnEnter = true;
            this.txtResult.Size = new System.Drawing.Size(441, 332);
            this.txtResult.TabIndex = 0;
            this.txtResult.TextMode = ClassLibrary.TextModes.Text;
            this.txtResult.TextChanged += new System.EventHandler(this.txtResult_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "نتیجه حضور:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.jArchiveNotice);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(447, 378);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "تصاویر";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // jArchiveNotice
            // 
            this.jArchiveNotice.AllowUserAddFile = true;
            this.jArchiveNotice.AllowUserAddFromArchive = true;
            this.jArchiveNotice.AllowUserAddImage = true;
            this.jArchiveNotice.AllowUserDeleteFile = true;
            this.jArchiveNotice.ClassName = "";
            this.jArchiveNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveNotice.Location = new System.Drawing.Point(3, 3);
            this.jArchiveNotice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jArchiveNotice.Name = "jArchiveNotice";
            this.jArchiveNotice.ObjectCode = 0;
            this.jArchiveNotice.PlaceCode = 0;
            this.jArchiveNotice.Size = new System.Drawing.Size(441, 372);
            this.jArchiveNotice.SubjectCode = 0;
            this.jArchiveNotice.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tabControl1);
            this.groupBox5.Location = new System.Drawing.Point(0, 79);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(461, 429);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(13, 514);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(379, 514);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(94, 513);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 1;
            this.btnSaveClose.Text = "ذخیره";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // JNoticeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 544);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Name = "JNoticeForm";
            this.Text = " فرم اخطاریه";
            this.Load += new System.EventHandler(this.JNotice_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvFey)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSearchPetition;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label16;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtReason;
        private ClassLibrary.TextEdit txtResult;
        private ClassLibrary.TextEdit txtNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtTime;
        private System.Windows.Forms.TabPage tabPage3;
        private ArchivedDocuments.JArchiveList jArchiveNotice;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.TextBox txtJudicial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private ClassLibrary.JDataGrid jdgvFey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.DateEdit txtDateNotified;
        private ClassLibrary.DateEdit txtDateEnd;
        private ClassLibrary.TextEdit txtDateMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkInformed;
    }
}