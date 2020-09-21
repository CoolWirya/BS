namespace Estates
{
    partial class JAggregateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JAggregateForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvGroundsAggregationby = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelAgregatedGrands = new System.Windows.Forms.Button();
            this.btnAddAgregatedGrands = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddGround = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labWest = new System.Windows.Forms.Label();
            this.labEast = new System.Windows.Forms.Label();
            this.labSouth = new System.Windows.Forms.Label();
            this.labNorth = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labUsage = new System.Windows.Forms.Label();
            this.labArea = new System.Windows.Forms.Label();
            this.labSection = new System.Windows.Forms.Label();
            this.labBlockNum = new System.Windows.Forms.Label();
            this.labPartNum = new System.Windows.Forms.Label();
            this.labLand = new System.Windows.Forms.Label();
            this.labSubAve = new System.Windows.Forms.Label();
            this.labMainAve = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTextReuest = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtRegistrationOffice = new ClassLibrary.TextEdit(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.jArchiveListAggregate = new ArchivedDocuments.JArchiveList();
            this.label11 = new System.Windows.Forms.Label();
            this.شماره = new System.Windows.Forms.Label();
            this.txtLetterDate = new ClassLibrary.DateEdit(this.components);
            this.txtLetterNum = new ClassLibrary.TextEdit(this.components);
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroundsAggregationby)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 64);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(559, 376);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvGroundsAggregationby);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnDelAgregatedGrands);
            this.tabPage1.Controls.Add(this.btnAddAgregatedGrands);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(551, 347);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "لیست زمین ها";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvGroundsAggregationby
            // 
            this.dgvGroundsAggregationby.AllowUserToAddRows = false;
            this.dgvGroundsAggregationby.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroundsAggregationby.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroundsAggregationby.Location = new System.Drawing.Point(6, 64);
            this.dgvGroundsAggregationby.Name = "dgvGroundsAggregationby";
            this.dgvGroundsAggregationby.ReadOnly = true;
            this.dgvGroundsAggregationby.Size = new System.Drawing.Size(537, 228);
            this.dgvGroundsAggregationby.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "لیست زمین هایی که قرار است تجمیع شوند:";
            // 
            // btnDelAgregatedGrands
            // 
            this.btnDelAgregatedGrands.Location = new System.Drawing.Point(355, 298);
            this.btnDelAgregatedGrands.Name = "btnDelAgregatedGrands";
            this.btnDelAgregatedGrands.Size = new System.Drawing.Size(75, 23);
            this.btnDelAgregatedGrands.TabIndex = 2;
            this.btnDelAgregatedGrands.Text = "حذف";
            this.btnDelAgregatedGrands.UseVisualStyleBackColor = true;
            this.btnDelAgregatedGrands.Click += new System.EventHandler(this.btnDelAgregatedGrands_Click);
            // 
            // btnAddAgregatedGrands
            // 
            this.btnAddAgregatedGrands.Location = new System.Drawing.Point(441, 298);
            this.btnAddAgregatedGrands.Name = "btnAddAgregatedGrands";
            this.btnAddAgregatedGrands.Size = new System.Drawing.Size(75, 23);
            this.btnAddAgregatedGrands.TabIndex = 1;
            this.btnAddAgregatedGrands.Text = "اضافه";
            this.btnAddAgregatedGrands.UseVisualStyleBackColor = true;
            this.btnAddAgregatedGrands.Click += new System.EventHandler(this.btnAddAgregatedGrands_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddGround);
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(551, 347);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "مشخصات زمین تجمیع شده";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddGround
            // 
            this.btnAddGround.Location = new System.Drawing.Point(421, 318);
            this.btnAddGround.Name = "btnAddGround";
            this.btnAddGround.Size = new System.Drawing.Size(100, 23);
            this.btnAddGround.TabIndex = 0;
            this.btnAddGround.Text = "تعریف زمین";
            this.btnAddGround.UseVisualStyleBackColor = true;
            this.btnAddGround.Click += new System.EventHandler(this.btnAddGround_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(18, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl2.RightToLeftLayout = true;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(525, 310);
            this.tabControl2.TabIndex = 20;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(517, 281);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "موقعیت";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labWest);
            this.groupBox1.Controls.Add(this.labEast);
            this.groupBox1.Controls.Add(this.labSouth);
            this.groupBox1.Controls.Add(this.labNorth);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.labUsage);
            this.groupBox1.Controls.Add(this.labArea);
            this.groupBox1.Controls.Add(this.labSection);
            this.groupBox1.Controls.Add(this.labBlockNum);
            this.groupBox1.Controls.Add(this.labPartNum);
            this.groupBox1.Controls.Add(this.labLand);
            this.groupBox1.Controls.Add(this.labSubAve);
            this.groupBox1.Controls.Add(this.labMainAve);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(508, 254);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // labWest
            // 
            this.labWest.AutoSize = true;
            this.labWest.Location = new System.Drawing.Point(259, 223);
            this.labWest.Name = "labWest";
            this.labWest.Size = new System.Drawing.Size(20, 16);
            this.labWest.TabIndex = 52;
            this.labWest.Text = "...";
            // 
            // labEast
            // 
            this.labEast.AutoSize = true;
            this.labEast.Location = new System.Drawing.Point(259, 194);
            this.labEast.Name = "labEast";
            this.labEast.Size = new System.Drawing.Size(20, 16);
            this.labEast.TabIndex = 51;
            this.labEast.Text = "...";
            // 
            // labSouth
            // 
            this.labSouth.AutoSize = true;
            this.labSouth.Location = new System.Drawing.Point(259, 165);
            this.labSouth.Name = "labSouth";
            this.labSouth.Size = new System.Drawing.Size(20, 16);
            this.labSouth.TabIndex = 50;
            this.labSouth.Text = "...";
            // 
            // labNorth
            // 
            this.labNorth.AutoSize = true;
            this.labNorth.Location = new System.Drawing.Point(259, 136);
            this.labNorth.Name = "labNorth";
            this.labNorth.Size = new System.Drawing.Size(20, 16);
            this.labNorth.TabIndex = 49;
            this.labNorth.Text = "...";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(423, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 16);
            this.label12.TabIndex = 45;
            this.label12.Text = "شمال ها:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(432, 223);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 16);
            this.label15.TabIndex = 48;
            this.label15.Text = "غرب ها:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(425, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 16);
            this.label13.TabIndex = 46;
            this.label13.Text = "جنوب ها:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(427, 194);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 16);
            this.label14.TabIndex = 47;
            this.label14.Text = "شرق ها:";
            // 
            // labUsage
            // 
            this.labUsage.AutoSize = true;
            this.labUsage.Location = new System.Drawing.Point(30, 78);
            this.labUsage.Name = "labUsage";
            this.labUsage.Size = new System.Drawing.Size(20, 16);
            this.labUsage.TabIndex = 31;
            this.labUsage.Text = "...";
            // 
            // labArea
            // 
            this.labArea.AutoSize = true;
            this.labArea.Location = new System.Drawing.Point(30, 107);
            this.labArea.Name = "labArea";
            this.labArea.Size = new System.Drawing.Size(20, 16);
            this.labArea.TabIndex = 30;
            this.labArea.Text = "...";
            // 
            // labSection
            // 
            this.labSection.AutoSize = true;
            this.labSection.Location = new System.Drawing.Point(30, 49);
            this.labSection.Name = "labSection";
            this.labSection.Size = new System.Drawing.Size(20, 16);
            this.labSection.TabIndex = 29;
            this.labSection.Text = "...";
            // 
            // labBlockNum
            // 
            this.labBlockNum.AutoSize = true;
            this.labBlockNum.Location = new System.Drawing.Point(259, 107);
            this.labBlockNum.Name = "labBlockNum";
            this.labBlockNum.Size = new System.Drawing.Size(20, 16);
            this.labBlockNum.TabIndex = 28;
            this.labBlockNum.Text = "...";
            // 
            // labPartNum
            // 
            this.labPartNum.AutoSize = true;
            this.labPartNum.Location = new System.Drawing.Point(30, 20);
            this.labPartNum.Name = "labPartNum";
            this.labPartNum.Size = new System.Drawing.Size(20, 16);
            this.labPartNum.TabIndex = 27;
            this.labPartNum.Text = "...";
            // 
            // labLand
            // 
            this.labLand.AutoSize = true;
            this.labLand.Location = new System.Drawing.Point(259, 20);
            this.labLand.Name = "labLand";
            this.labLand.Size = new System.Drawing.Size(20, 16);
            this.labLand.TabIndex = 24;
            this.labLand.Text = "...";
            // 
            // labSubAve
            // 
            this.labSubAve.AutoSize = true;
            this.labSubAve.Location = new System.Drawing.Point(259, 78);
            this.labSubAve.Name = "labSubAve";
            this.labSubAve.Size = new System.Drawing.Size(20, 16);
            this.labSubAve.TabIndex = 25;
            this.labSubAve.Text = "...";
            // 
            // labMainAve
            // 
            this.labMainAve.AutoSize = true;
            this.labMainAve.Location = new System.Drawing.Point(259, 49);
            this.labMainAve.Name = "labMainAve";
            this.labMainAve.Size = new System.Drawing.Size(20, 16);
            this.labMainAve.TabIndex = 26;
            this.labMainAve.Text = "...";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(176, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "مساحت:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(439, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "اراضی:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "شماره قطعه:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(187, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "کاربری:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(413, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "پلاک فرعی:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(413, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "پلاک اصلی:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(406, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "شماره بلوک:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(192, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "بخش:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(551, 347);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "اداره ثبت";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTextReuest);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtRegistrationOffice);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 341);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "در خواست از اداره ثبت:";
            // 
            // txtTextReuest
            // 
            this.txtTextReuest.ChangeColorIfNotEmpty = false;
            this.txtTextReuest.ChangeColorOnEnter = true;
            this.txtTextReuest.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTextReuest.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTextReuest.Location = new System.Drawing.Point(6, 94);
            this.txtTextReuest.Multiline = true;
            this.txtTextReuest.Name = "txtTextReuest";
            this.txtTextReuest.Negative = true;
            this.txtTextReuest.NotEmpty = false;
            this.txtTextReuest.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTextReuest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTextReuest.SelectOnEnter = true;
            this.txtTextReuest.Size = new System.Drawing.Size(524, 241);
            this.txtTextReuest.TabIndex = 7;
            this.txtTextReuest.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "متن درخواست:";
            // 
            // txtRegistrationOffice
            // 
            this.txtRegistrationOffice.ChangeColorIfNotEmpty = false;
            this.txtRegistrationOffice.ChangeColorOnEnter = true;
            this.txtRegistrationOffice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtRegistrationOffice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRegistrationOffice.Location = new System.Drawing.Point(6, 29);
            this.txtRegistrationOffice.Name = "txtRegistrationOffice";
            this.txtRegistrationOffice.Negative = true;
            this.txtRegistrationOffice.NotEmpty = false;
            this.txtRegistrationOffice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtRegistrationOffice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRegistrationOffice.SelectOnEnter = true;
            this.txtRegistrationOffice.Size = new System.Drawing.Size(425, 23);
            this.txtRegistrationOffice.TabIndex = 4;
            this.txtRegistrationOffice.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(458, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 16);
            this.label16.TabIndex = 2;
            this.label16.Text = "اداره مخاطب:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.jArchiveListAggregate);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(551, 347);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "فایل های مرتبط";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // jArchiveListAggregate
            // 
            this.jArchiveListAggregate.AllowUserAddFile = true;
            this.jArchiveListAggregate.AllowUserAddFromArchive = true;
            this.jArchiveListAggregate.AllowUserAddImage = true;
            this.jArchiveListAggregate.AllowUserDeleteFile = true;
            this.jArchiveListAggregate.ClassName = "";
            this.jArchiveListAggregate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveListAggregate.Location = new System.Drawing.Point(3, 3);
            this.jArchiveListAggregate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jArchiveListAggregate.Name = "jArchiveListAggregate";
            this.jArchiveListAggregate.ObjectCode = 0;
            this.jArchiveListAggregate.PlaceCode = 0;
            this.jArchiveListAggregate.Size = new System.Drawing.Size(545, 341);
            this.jArchiveListAggregate.SubjectCode = 0;
            this.jArchiveListAggregate.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(315, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 4;
            this.label11.Text = "تاریخ نامه:";
            // 
            // شماره
            // 
            this.شماره.AutoSize = true;
            this.شماره.Location = new System.Drawing.Point(19, 21);
            this.شماره.Name = "شماره";
            this.شماره.Size = new System.Drawing.Size(75, 16);
            this.شماره.TabIndex = 5;
            this.شماره.Text = "شماره نامه:";
            // 
            // txtLetterDate
            // 
            this.txtLetterDate.ChangeColorIfNotEmpty = true;
            this.txtLetterDate.ChangeColorOnEnter = true;
            this.txtLetterDate.Date = new System.DateTime(((long)(0)));
            this.txtLetterDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLetterDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLetterDate.InsertInDatesTable = true;
            this.txtLetterDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtLetterDate.Location = new System.Drawing.Point(386, 21);
            this.txtLetterDate.Mask = "0000/00/00";
            this.txtLetterDate.Name = "txtLetterDate";
            this.txtLetterDate.NotEmpty = false;
            this.txtLetterDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLetterDate.Size = new System.Drawing.Size(100, 23);
            this.txtLetterDate.TabIndex = 1;
            // 
            // txtLetterNum
            // 
            this.txtLetterNum.ChangeColorIfNotEmpty = false;
            this.txtLetterNum.ChangeColorOnEnter = true;
            this.txtLetterNum.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLetterNum.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLetterNum.Location = new System.Drawing.Point(100, 18);
            this.txtLetterNum.Name = "txtLetterNum";
            this.txtLetterNum.Negative = true;
            this.txtLetterNum.NotEmpty = false;
            this.txtLetterNum.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLetterNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterNum.SelectOnEnter = true;
            this.txtLetterNum.Size = new System.Drawing.Size(100, 23);
            this.txtLetterNum.TabIndex = 0;
            this.txtLetterNum.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Location = new System.Drawing.Point(120, 466);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(98, 23);
            this.btnSaveClose.TabIndex = 3;
            this.btnSaveClose.Text = "ذخیره وخروج ";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(462, 466);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 466);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // JAggregateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 513);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.txtLetterNum);
            this.Controls.Add(this.txtLetterDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.شماره);
            this.Controls.Add(this.tabControl1);
            this.Name = "JAggregateForm";
            this.Text = "تجمیع";
            this.Load += new System.EventHandler(this.JAggregateForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroundsAggregationby)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvGroundsAggregationby;
        private System.Windows.Forms.Button btnDelAgregatedGrands;
        private System.Windows.Forms.Button btnAddAgregatedGrands;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label شماره;
        private ClassLibrary.DateEdit txtLetterDate;
        private ClassLibrary.TextEdit txtLetterNum;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label labLand;
        private System.Windows.Forms.Label labSubAve;
        private System.Windows.Forms.Label labMainAve;
        private System.Windows.Forms.Label labBlockNum;
        private System.Windows.Forms.Label labPartNum;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labUsage;
        private System.Windows.Forms.Label labArea;
        private System.Windows.Forms.Label labSection;
        private System.Windows.Forms.Button btnAddGround;
        private System.Windows.Forms.Label labWest;
        private System.Windows.Forms.Label labEast;
        private System.Windows.Forms.Label labSouth;
        private System.Windows.Forms.Label labNorth;
        private System.Windows.Forms.Button btnSave;
        private ArchivedDocuments.JArchiveList jArchiveListAggregate;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.TextEdit txtTextReuest;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtRegistrationOffice;
        private System.Windows.Forms.Label label16;
    }
}