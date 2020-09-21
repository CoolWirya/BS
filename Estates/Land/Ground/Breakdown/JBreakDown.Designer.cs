namespace Estates
{
    partial class JGroundBreakDownForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JGroundBreakDownForm));
            this.btnGroundMainSearch = new System.Windows.Forms.Button();
            this.btnGroundBreakDown = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtGroundCodeMain = new ClassLibrary.TextEdit(this.components);
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
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTextReuest = new ClassLibrary.TextEdit(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtLetterDate = new ClassLibrary.DateEdit(this.components);
            this.txtRegistrationOffice = new ClassLibrary.TextEdit(this.components);
            this.txtLetterNum = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.labSumArea = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.libGroundsBreakdown = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnUpadateNewGrounds = new System.Windows.Forms.Button();
            this.btnNewGrounds = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.jArchiveList = new ArchivedDocuments.JArchiveList();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            // btnGroundMainSearch
            // 
            this.btnGroundMainSearch.Location = new System.Drawing.Point(303, 12);
            this.btnGroundMainSearch.Name = "btnGroundMainSearch";
            this.btnGroundMainSearch.Size = new System.Drawing.Size(75, 23);
            this.btnGroundMainSearch.TabIndex = 12;
            this.btnGroundMainSearch.Text = "جستجو";
            this.btnGroundMainSearch.UseVisualStyleBackColor = true;
            this.btnGroundMainSearch.Click += new System.EventHandler(this.btnGroundMainSearch_Click);
            // 
            // btnGroundBreakDown
            // 
            this.btnGroundBreakDown.Location = new System.Drawing.Point(24, 373);
            this.btnGroundBreakDown.Name = "btnGroundBreakDown";
            this.btnGroundBreakDown.Size = new System.Drawing.Size(75, 29);
            this.btnGroundBreakDown.TabIndex = 11;
            this.btnGroundBreakDown.Text = "تفکیک";
            this.btnGroundBreakDown.UseVisualStyleBackColor = true;
            this.btnGroundBreakDown.Click += new System.EventHandler(this.btnGroundBreakDown_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(218, 373);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 29);
            this.BtnClose.TabIndex = 7;
            this.BtnClose.Text = "خروج";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(490, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "کد زمین:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(6, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(577, 355);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtGroundCodeMain);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.btnGroundMainSearch);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(569, 326);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "موقعیت زمین اصلی";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtGroundCodeMain
            // 
            this.txtGroundCodeMain.ChangeColorIfNotEmpty = false;
            this.txtGroundCodeMain.ChangeColorOnEnter = true;
            this.txtGroundCodeMain.InBackColor = System.Drawing.SystemColors.Info;
            this.txtGroundCodeMain.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGroundCodeMain.Location = new System.Drawing.Point(384, 13);
            this.txtGroundCodeMain.Name = "txtGroundCodeMain";
            this.txtGroundCodeMain.Negative = true;
            this.txtGroundCodeMain.NotEmpty = false;
            this.txtGroundCodeMain.NotEmptyColor = System.Drawing.Color.Red;
            this.txtGroundCodeMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGroundCodeMain.SelectOnEnter = true;
            this.txtGroundCodeMain.Size = new System.Drawing.Size(100, 23);
            this.txtGroundCodeMain.TabIndex = 13;
            this.txtGroundCodeMain.TextMode = ClassLibrary.TextModes.Text;
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
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Location = new System.Drawing.Point(11, 43);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(542, 270);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // labWest
            // 
            this.labWest.AutoSize = true;
            this.labWest.ForeColor = System.Drawing.Color.Blue;
            this.labWest.Location = new System.Drawing.Point(401, 231);
            this.labWest.Name = "labWest";
            this.labWest.Size = new System.Drawing.Size(20, 16);
            this.labWest.TabIndex = 52;
            this.labWest.Text = "...";
            // 
            // labEast
            // 
            this.labEast.AutoSize = true;
            this.labEast.ForeColor = System.Drawing.Color.Blue;
            this.labEast.Location = new System.Drawing.Point(401, 202);
            this.labEast.Name = "labEast";
            this.labEast.Size = new System.Drawing.Size(20, 16);
            this.labEast.TabIndex = 51;
            this.labEast.Text = "...";
            // 
            // labSouth
            // 
            this.labSouth.AutoSize = true;
            this.labSouth.ForeColor = System.Drawing.Color.Blue;
            this.labSouth.Location = new System.Drawing.Point(401, 173);
            this.labSouth.Name = "labSouth";
            this.labSouth.Size = new System.Drawing.Size(20, 16);
            this.labSouth.TabIndex = 50;
            this.labSouth.Text = "...";
            // 
            // labNorth
            // 
            this.labNorth.AutoSize = true;
            this.labNorth.ForeColor = System.Drawing.Color.Blue;
            this.labNorth.Location = new System.Drawing.Point(401, 144);
            this.labNorth.Name = "labNorth";
            this.labNorth.Size = new System.Drawing.Size(20, 16);
            this.labNorth.TabIndex = 49;
            this.labNorth.Text = "...";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(454, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 16);
            this.label12.TabIndex = 45;
            this.label12.Text = "شمال ها:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(463, 231);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 16);
            this.label15.TabIndex = 48;
            this.label15.Text = "غرب ها:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(456, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 16);
            this.label13.TabIndex = 46;
            this.label13.Text = "جنوب ها:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(458, 202);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 16);
            this.label14.TabIndex = 47;
            this.label14.Text = "شرق ها:";
            // 
            // labUsage
            // 
            this.labUsage.AutoSize = true;
            this.labUsage.ForeColor = System.Drawing.Color.Blue;
            this.labUsage.Location = new System.Drawing.Point(131, 86);
            this.labUsage.Name = "labUsage";
            this.labUsage.Size = new System.Drawing.Size(20, 16);
            this.labUsage.TabIndex = 31;
            this.labUsage.Text = "...";
            // 
            // labArea
            // 
            this.labArea.AutoSize = true;
            this.labArea.ForeColor = System.Drawing.Color.Blue;
            this.labArea.Location = new System.Drawing.Point(131, 115);
            this.labArea.Name = "labArea";
            this.labArea.Size = new System.Drawing.Size(20, 16);
            this.labArea.TabIndex = 30;
            this.labArea.Text = "...";
            // 
            // labSection
            // 
            this.labSection.AutoSize = true;
            this.labSection.ForeColor = System.Drawing.Color.Blue;
            this.labSection.Location = new System.Drawing.Point(131, 57);
            this.labSection.Name = "labSection";
            this.labSection.Size = new System.Drawing.Size(20, 16);
            this.labSection.TabIndex = 29;
            this.labSection.Text = "...";
            // 
            // labBlockNum
            // 
            this.labBlockNum.AutoSize = true;
            this.labBlockNum.ForeColor = System.Drawing.Color.Blue;
            this.labBlockNum.Location = new System.Drawing.Point(401, 115);
            this.labBlockNum.Name = "labBlockNum";
            this.labBlockNum.Size = new System.Drawing.Size(20, 16);
            this.labBlockNum.TabIndex = 28;
            this.labBlockNum.Text = "...";
            // 
            // labPartNum
            // 
            this.labPartNum.AutoSize = true;
            this.labPartNum.ForeColor = System.Drawing.Color.Blue;
            this.labPartNum.Location = new System.Drawing.Point(131, 28);
            this.labPartNum.Name = "labPartNum";
            this.labPartNum.Size = new System.Drawing.Size(20, 16);
            this.labPartNum.TabIndex = 27;
            this.labPartNum.Text = "...";
            // 
            // labLand
            // 
            this.labLand.AutoSize = true;
            this.labLand.ForeColor = System.Drawing.Color.Blue;
            this.labLand.Location = new System.Drawing.Point(401, 28);
            this.labLand.Name = "labLand";
            this.labLand.Size = new System.Drawing.Size(20, 16);
            this.labLand.TabIndex = 24;
            this.labLand.Text = "...";
            // 
            // labSubAve
            // 
            this.labSubAve.AutoSize = true;
            this.labSubAve.ForeColor = System.Drawing.Color.Blue;
            this.labSubAve.Location = new System.Drawing.Point(401, 86);
            this.labSubAve.Name = "labSubAve";
            this.labSubAve.Size = new System.Drawing.Size(20, 16);
            this.labSubAve.TabIndex = 25;
            this.labSubAve.Text = "...";
            // 
            // labMainAve
            // 
            this.labMainAve.AutoSize = true;
            this.labMainAve.ForeColor = System.Drawing.Color.Blue;
            this.labMainAve.Location = new System.Drawing.Point(401, 57);
            this.labMainAve.Name = "labMainAve";
            this.labMainAve.Size = new System.Drawing.Size(20, 16);
            this.labMainAve.TabIndex = 26;
            this.labMainAve.Text = "...";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "مساحت:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(470, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "اراضی:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "شماره قطعه:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(199, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "کاربری:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(444, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = "پلاک فرعی:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(444, 57);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 16);
            this.label18.TabIndex = 8;
            this.label18.Text = "پلاک اصلی:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(437, 115);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 16);
            this.label19.TabIndex = 13;
            this.label19.Text = "شماره بلوک:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(204, 57);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 16);
            this.label20.TabIndex = 11;
            this.label20.Text = "بخش:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(569, 326);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "اداره ثبت";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTextReuest);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtLetterDate);
            this.groupBox2.Controls.Add(this.txtRegistrationOffice);
            this.groupBox2.Controls.Add(this.txtLetterNum);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 314);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "در خواست از اداره ثبت:";
            // 
            // txtTextReuest
            // 
            this.txtTextReuest.ChangeColorIfNotEmpty = false;
            this.txtTextReuest.ChangeColorOnEnter = true;
            this.txtTextReuest.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTextReuest.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTextReuest.Location = new System.Drawing.Point(36, 150);
            this.txtTextReuest.Multiline = true;
            this.txtTextReuest.Name = "txtTextReuest";
            this.txtTextReuest.Negative = true;
            this.txtTextReuest.NotEmpty = false;
            this.txtTextReuest.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTextReuest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTextReuest.SelectOnEnter = true;
            this.txtTextReuest.Size = new System.Drawing.Size(395, 146);
            this.txtTextReuest.TabIndex = 7;
            this.txtTextReuest.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(449, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "متن درخواست:";
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
            this.txtLetterDate.Location = new System.Drawing.Point(303, 64);
            this.txtLetterDate.Mask = "0000/00/00";
            this.txtLetterDate.Name = "txtLetterDate";
            this.txtLetterDate.NotEmpty = false;
            this.txtLetterDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLetterDate.Size = new System.Drawing.Size(128, 23);
            this.txtLetterDate.TabIndex = 5;
            // 
            // txtRegistrationOffice
            // 
            this.txtRegistrationOffice.ChangeColorIfNotEmpty = false;
            this.txtRegistrationOffice.ChangeColorOnEnter = true;
            this.txtRegistrationOffice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtRegistrationOffice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRegistrationOffice.Location = new System.Drawing.Point(36, 108);
            this.txtRegistrationOffice.Name = "txtRegistrationOffice";
            this.txtRegistrationOffice.Negative = true;
            this.txtRegistrationOffice.NotEmpty = false;
            this.txtRegistrationOffice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtRegistrationOffice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRegistrationOffice.SelectOnEnter = true;
            this.txtRegistrationOffice.Size = new System.Drawing.Size(395, 23);
            this.txtRegistrationOffice.TabIndex = 4;
            this.txtRegistrationOffice.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtLetterNum
            // 
            this.txtLetterNum.ChangeColorIfNotEmpty = false;
            this.txtLetterNum.ChangeColorOnEnter = true;
            this.txtLetterNum.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLetterNum.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLetterNum.Location = new System.Drawing.Point(303, 32);
            this.txtLetterNum.Name = "txtLetterNum";
            this.txtLetterNum.Negative = true;
            this.txtLetterNum.NotEmpty = false;
            this.txtLetterNum.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLetterNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterNum.SelectOnEnter = true;
            this.txtLetterNum.Size = new System.Drawing.Size(128, 23);
            this.txtLetterNum.TabIndex = 3;
            this.txtLetterNum.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(461, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "اداره مخاطب:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(481, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "تارخ نامه:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(467, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "شماره نامه:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.labSumArea);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.libGroundsBreakdown);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.btnUpadateNewGrounds);
            this.tabPage3.Controls.Add(this.btnNewGrounds);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(569, 326);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "تقسیمات  ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // labSumArea
            // 
            this.labSumArea.AutoSize = true;
            this.labSumArea.Location = new System.Drawing.Point(24, 292);
            this.labSumArea.Name = "labSumArea";
            this.labSumArea.Size = new System.Drawing.Size(20, 16);
            this.labSumArea.TabIndex = 19;
            this.labSumArea.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "مجموع مساحت ها:";
            // 
            // libGroundsBreakdown
            // 
            this.libGroundsBreakdown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.libGroundsBreakdown.FormattingEnabled = true;
            this.libGroundsBreakdown.ItemHeight = 16;
            this.libGroundsBreakdown.Location = new System.Drawing.Point(6, 41);
            this.libGroundsBreakdown.Name = "libGroundsBreakdown";
            this.libGroundsBreakdown.Size = new System.Drawing.Size(557, 228);
            this.libGroundsBreakdown.TabIndex = 17;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(420, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(138, 16);
            this.label16.TabIndex = 16;
            this.label16.Text = "لیست زمین های جدید:";
            // 
            // btnUpadateNewGrounds
            // 
            this.btnUpadateNewGrounds.Location = new System.Drawing.Point(369, 275);
            this.btnUpadateNewGrounds.Name = "btnUpadateNewGrounds";
            this.btnUpadateNewGrounds.Size = new System.Drawing.Size(75, 23);
            this.btnUpadateNewGrounds.TabIndex = 15;
            this.btnUpadateNewGrounds.Text = "ویرایش";
            this.btnUpadateNewGrounds.UseVisualStyleBackColor = true;
            this.btnUpadateNewGrounds.Click += new System.EventHandler(this.btnUpadateNewGrounds_Click);
            // 
            // btnNewGrounds
            // 
            this.btnNewGrounds.Location = new System.Drawing.Point(450, 275);
            this.btnNewGrounds.Name = "btnNewGrounds";
            this.btnNewGrounds.Size = new System.Drawing.Size(75, 23);
            this.btnNewGrounds.TabIndex = 14;
            this.btnNewGrounds.Text = "جدید";
            this.btnNewGrounds.UseVisualStyleBackColor = true;
            this.btnNewGrounds.Click += new System.EventHandler(this.btnNewGrounds_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.jArchiveList);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(569, 326);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "تصاویر و اسناد مربوطه";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // jArchiveList
            // 
            this.jArchiveList.AllowUserAddFile = true;
            this.jArchiveList.AllowUserAddFromArchive = true;
            this.jArchiveList.AllowUserAddImage = true;
            this.jArchiveList.AllowUserDeleteFile = true;
            this.jArchiveList.ClassName = "";
            this.jArchiveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveList.Location = new System.Drawing.Point(3, 3);
            this.jArchiveList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jArchiveList.Name = "jArchiveList";
            this.jArchiveList.ObjectCode = 0;
            this.jArchiveList.PlaceCode = 0;
            this.jArchiveList.Size = new System.Drawing.Size(563, 320);
            this.jArchiveList.SubjectCode = 0;
            this.jArchiveList.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "ذخیره";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // JGroundBreakDownForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 414);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGroundBreakDown);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.tabControl1);
            this.Name = "JGroundBreakDownForm";
            this.Text = "تفکیک";
            this.Load += new System.EventHandler(this.JGroundBreakDownForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGroundMainSearch;
        private System.Windows.Forms.Button btnGroundBreakDown;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnUpadateNewGrounds;
        private System.Windows.Forms.Button btnNewGrounds;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtGroundCodeMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labWest;
        private System.Windows.Forms.Label labEast;
        private System.Windows.Forms.Label labSouth;
        private System.Windows.Forms.Label labNorth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labUsage;
        private System.Windows.Forms.Label labArea;
        private System.Windows.Forms.Label labSection;
        private System.Windows.Forms.Label labBlockNum;
        private System.Windows.Forms.Label labPartNum;
        private System.Windows.Forms.Label labLand;
        private System.Windows.Forms.Label labSubAve;
        private System.Windows.Forms.Label labMainAve;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private ClassLibrary.DateEdit txtLetterDate;
        private ClassLibrary.TextEdit txtRegistrationOffice;
        private ClassLibrary.TextEdit txtLetterNum;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.TextEdit txtTextReuest;
        private System.Windows.Forms.ListBox libGroundsBreakdown;
        private System.Windows.Forms.Label labSumArea;
        private System.Windows.Forms.Label label1;
        private ArchivedDocuments.JArchiveList jArchiveList;
        private System.Windows.Forms.Button button1;
    }
}