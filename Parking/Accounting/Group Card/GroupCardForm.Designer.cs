namespace Parking
{
    partial class JGroupCardForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tccoParking = new TCCOParking.TccoParking();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkUpRound = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtRound = new ClassLibrary.NumEdit();
            this.TxtOffer = new ClassLibrary.NumEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtAbate = new ClassLibrary.NumEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkIsFirstHourApart = new System.Windows.Forms.CheckBox();
            this.chkIsDailyApart = new System.Windows.Forms.CheckBox();
            this.TxtDailyPrice = new ClassLibrary.NumEdit();
            this.label25 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtUnitTime = new ClassLibrary.NumEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.chkinputDisplay = new System.Windows.Forms.CheckBox();
            this.chkMinute = new System.Windows.Forms.CheckBox();
            this.txtSecondAmount = new ClassLibrary.NumEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFirstAmount = new ClassLibrary.NumEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtName = new ClassLibrary.TextEdit(this.components);
            this.cmbComplex = new ClassLibrary.JComboBox(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.TxtNumber = new ClassLibrary.NumEdit();
            this.chkElectronic = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(474, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "عنوان گروه :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(403, 404);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 34);
            this.button2.TabIndex = 56;
            this.button2.Text = "خروج";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkUpRound);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.TxtRound);
            this.groupBox3.Controls.Add(this.TxtOffer);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.TxtAbate);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(524, 140);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تنظيمات بعد از محاسبه تعرفه";
            // 
            // chkUpRound
            // 
            this.chkUpRound.AutoSize = true;
            this.chkUpRound.Location = new System.Drawing.Point(56, 63);
            this.chkUpRound.Name = "chkUpRound";
            this.chkUpRound.Size = new System.Drawing.Size(150, 20);
            this.chkUpRound.TabIndex = 50;
            this.chkUpRound.Text = "گرد كردن رو به بالا فعال";
            this.chkUpRound.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(242, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 16);
            this.label12.TabIndex = 45;
            this.label12.Text = " دقيقه";
            // 
            // TxtRound
            // 
            this.TxtRound.ChangeColorIfNotEmpty = false;
            this.TxtRound.ChangeColorOnEnter = true;
            this.TxtRound.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtRound.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtRound.Location = new System.Drawing.Point(289, 97);
            this.TxtRound.MaxLength = 5;
            this.TxtRound.Name = "TxtRound";
            this.TxtRound.Negative = true;
            this.TxtRound.NotEmpty = false;
            this.TxtRound.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtRound.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.TxtRound.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtRound.SelectOnEnter = true;
            this.TxtRound.Size = new System.Drawing.Size(121, 23);
            this.TxtRound.TabIndex = 40;
            this.TxtRound.TextMode = ClassLibrary.TextModes.Integer;
            this.TxtRound.TextChanged += new System.EventHandler(this.TxtRound_TextChanged);
            // 
            // TxtOffer
            // 
            this.TxtOffer.ChangeColorIfNotEmpty = false;
            this.TxtOffer.ChangeColorOnEnter = true;
            this.TxtOffer.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtOffer.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtOffer.Location = new System.Drawing.Point(290, 61);
            this.TxtOffer.MaxLength = 4;
            this.TxtOffer.Name = "TxtOffer";
            this.TxtOffer.Negative = true;
            this.TxtOffer.NotEmpty = false;
            this.TxtOffer.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtOffer.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.TxtOffer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtOffer.SelectOnEnter = true;
            this.TxtOffer.Size = new System.Drawing.Size(100, 23);
            this.TxtOffer.TabIndex = 43;
            this.TxtOffer.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(429, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "در صد تخفيف :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(400, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 16);
            this.label11.TabIndex = 44;
            this.label11.Text = "محاسبه مبلغ پس از";
            // 
            // TxtAbate
            // 
            this.TxtAbate.ChangeColorIfNotEmpty = false;
            this.TxtAbate.ChangeColorOnEnter = true;
            this.TxtAbate.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtAbate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtAbate.Location = new System.Drawing.Point(290, 25);
            this.TxtAbate.MaxLength = 2;
            this.TxtAbate.Name = "TxtAbate";
            this.TxtAbate.Negative = true;
            this.TxtAbate.NotEmpty = false;
            this.TxtAbate.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtAbate.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.TxtAbate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtAbate.SelectOnEnter = true;
            this.TxtAbate.Size = new System.Drawing.Size(129, 23);
            this.TxtAbate.TabIndex = 38;
            this.TxtAbate.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(232, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 16);
            this.label10.TabIndex = 42;
            this.label10.Text = "گرد گردد";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(425, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 16);
            this.label8.TabIndex = 41;
            this.label8.Text = "مبالغ دريافتي تا";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(183, 62);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(108, 20);
            this.chkIsActive.TabIndex = 51;
            this.chkIsActive.Text = "گروه فعال است";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(6, 404);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 34);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkIsFirstHourApart);
            this.groupBox2.Controls.Add(this.chkIsDailyApart);
            this.groupBox2.Controls.Add(this.TxtDailyPrice);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtUnitTime);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.chkinputDisplay);
            this.groupBox2.Controls.Add(this.chkMinute);
            this.groupBox2.Controls.Add(this.txtSecondAmount);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtFirstAmount);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 166);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "نحوه محاسبه تعرفه";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // chkIsFirstHourApart
            // 
            this.chkIsFirstHourApart.AutoSize = true;
            this.chkIsFirstHourApart.Checked = true;
            this.chkIsFirstHourApart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsFirstHourApart.Location = new System.Drawing.Point(49, 34);
            this.chkIsFirstHourApart.Name = "chkIsFirstHourApart";
            this.chkIsFirstHourApart.Size = new System.Drawing.Size(219, 20);
            this.chkIsFirstHourApart.TabIndex = 97;
            this.chkIsFirstHourApart.Text = "مبلغ ساعت اول مجزا محاسبه شود";
            this.chkIsFirstHourApart.UseVisualStyleBackColor = true;
            // 
            // chkIsDailyApart
            // 
            this.chkIsDailyApart.AutoSize = true;
            this.chkIsDailyApart.Checked = true;
            this.chkIsDailyApart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsDailyApart.Location = new System.Drawing.Point(48, 133);
            this.chkIsDailyApart.Name = "chkIsDailyApart";
            this.chkIsDailyApart.Size = new System.Drawing.Size(220, 20);
            this.chkIsDailyApart.TabIndex = 96;
            this.chkIsDailyApart.Text = "هزینه توقف روزانه مجزا حساب شود";
            this.chkIsDailyApart.UseVisualStyleBackColor = true;
            // 
            // TxtDailyPrice
            // 
            this.TxtDailyPrice.ChangeColorIfNotEmpty = false;
            this.TxtDailyPrice.ChangeColorOnEnter = true;
            this.TxtDailyPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtDailyPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtDailyPrice.Location = new System.Drawing.Point(290, 131);
            this.TxtDailyPrice.MaxLength = 8;
            this.TxtDailyPrice.Name = "TxtDailyPrice";
            this.TxtDailyPrice.Negative = true;
            this.TxtDailyPrice.NotEmpty = false;
            this.TxtDailyPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtDailyPrice.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.TxtDailyPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtDailyPrice.SelectOnEnter = true;
            this.TxtDailyPrice.Size = new System.Drawing.Size(102, 23);
            this.TxtDailyPrice.TabIndex = 95;
            this.TxtDailyPrice.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(447, 134);
            this.label25.Name = "label25";
            this.label25.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label25.Size = new System.Drawing.Size(71, 16);
            this.label25.TabIndex = 94;
            this.label25.Text = "مبلغ روزانه:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(440, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 16);
            this.label16.TabIndex = 55;
            this.label16.Text = "مبلغ ورودي :";
            // 
            // txtUnitTime
            // 
            this.txtUnitTime.ChangeColorIfNotEmpty = false;
            this.txtUnitTime.ChangeColorOnEnter = true;
            this.txtUnitTime.InBackColor = System.Drawing.SystemColors.Info;
            this.txtUnitTime.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUnitTime.Location = new System.Drawing.Point(290, 98);
            this.txtUnitTime.MaxLength = 3;
            this.txtUnitTime.Name = "txtUnitTime";
            this.txtUnitTime.Negative = true;
            this.txtUnitTime.NotEmpty = false;
            this.txtUnitTime.NotEmptyColor = System.Drawing.Color.Red;
            this.txtUnitTime.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtUnitTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUnitTime.SelectOnEnter = true;
            this.txtUnitTime.Size = new System.Drawing.Size(102, 23);
            this.txtUnitTime.TabIndex = 52;
            this.txtUnitTime.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 53;
            this.label5.Text = "واحد زماني :";
            // 
            // chkinputDisplay
            // 
            this.chkinputDisplay.AutoSize = true;
            this.chkinputDisplay.Location = new System.Drawing.Point(55, 100);
            this.chkinputDisplay.Name = "chkinputDisplay";
            this.chkinputDisplay.Size = new System.Drawing.Size(213, 20);
            this.chkinputDisplay.TabIndex = 51;
            this.chkinputDisplay.Text = "كل مبلغ در حين ورود اخذ مي گردد";
            this.chkinputDisplay.UseVisualStyleBackColor = true;
            this.chkinputDisplay.CheckedChanged += new System.EventHandler(this.chkinputDisplay_CheckedChanged);
            // 
            // chkMinute
            // 
            this.chkMinute.AutoSize = true;
            this.chkMinute.Location = new System.Drawing.Point(75, 67);
            this.chkMinute.Name = "chkMinute";
            this.chkMinute.Size = new System.Drawing.Size(193, 20);
            this.chkMinute.TabIndex = 49;
            this.chkMinute.Text = "كسر قيمت  در هروز فقط يك بار";
            this.chkMinute.UseVisualStyleBackColor = true;
            this.chkMinute.CheckedChanged += new System.EventHandler(this.chkMinute_CheckedChanged);
            // 
            // txtSecondAmount
            // 
            this.txtSecondAmount.ChangeColorIfNotEmpty = false;
            this.txtSecondAmount.ChangeColorOnEnter = true;
            this.txtSecondAmount.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSecondAmount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSecondAmount.Location = new System.Drawing.Point(289, 65);
            this.txtSecondAmount.MaxLength = 6;
            this.txtSecondAmount.Name = "txtSecondAmount";
            this.txtSecondAmount.Negative = true;
            this.txtSecondAmount.NotEmpty = false;
            this.txtSecondAmount.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSecondAmount.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtSecondAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSecondAmount.SelectOnEnter = true;
            this.txtSecondAmount.Size = new System.Drawing.Size(102, 23);
            this.txtSecondAmount.TabIndex = 6;
            this.txtSecondAmount.TextMode = ClassLibrary.TextModes.Money;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "مبلغ هر واحد زماني :";
            // 
            // txtFirstAmount
            // 
            this.txtFirstAmount.ChangeColorIfNotEmpty = false;
            this.txtFirstAmount.ChangeColorOnEnter = true;
            this.txtFirstAmount.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFirstAmount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFirstAmount.Location = new System.Drawing.Point(289, 32);
            this.txtFirstAmount.MaxLength = 6;
            this.txtFirstAmount.Name = "txtFirstAmount";
            this.txtFirstAmount.Negative = true;
            this.txtFirstAmount.NotEmpty = false;
            this.txtFirstAmount.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFirstAmount.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtFirstAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFirstAmount.SelectOnEnter = true;
            this.txtFirstAmount.Size = new System.Drawing.Size(103, 23);
            this.txtFirstAmount.TabIndex = 5;
            this.txtFirstAmount.TextMode = ClassLibrary.TextModes.Money;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIsActive);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.TxtName);
            this.groupBox1.Controls.Add(this.cmbComplex);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.TxtNumber);
            this.groupBox1.Controls.Add(this.chkElectronic);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 91);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات گروه";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(212, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 16);
            this.label13.TabIndex = 48;
            this.label13.Text = "نام گروه :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(467, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 16);
            this.label15.TabIndex = 52;
            this.label15.Text = "مجتمع :";
            // 
            // TxtName
            // 
            this.TxtName.ChangeColorIfNotEmpty = false;
            this.TxtName.ChangeColorOnEnter = true;
            this.TxtName.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtName.Location = new System.Drawing.Point(21, 21);
            this.TxtName.Name = "TxtName";
            this.TxtName.Negative = true;
            this.TxtName.NotEmpty = false;
            this.TxtName.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtName.SelectOnEnter = true;
            this.TxtName.Size = new System.Drawing.Size(185, 23);
            this.TxtName.TabIndex = 53;
            this.TxtName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbComplex
            // 
            this.cmbComplex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbComplex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbComplex.BaseCode = 0;
            this.cmbComplex.ChangeColorIfNotEmpty = true;
            this.cmbComplex.ChangeColorOnEnter = true;
            this.cmbComplex.Enabled = false;
            this.cmbComplex.FormattingEnabled = true;
            this.cmbComplex.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbComplex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbComplex.Location = new System.Drawing.Point(297, 20);
            this.cmbComplex.Name = "cmbComplex";
            this.cmbComplex.NotEmpty = false;
            this.cmbComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbComplex.SelectOnEnter = true;
            this.cmbComplex.Size = new System.Drawing.Size(164, 24);
            this.cmbComplex.TabIndex = 54;
            this.cmbComplex.SelectedIndexChanged += new System.EventHandler(this.cmbComplex_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(442, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 16);
            this.label14.TabIndex = 50;
            this.label14.Text = "شماره گروه :";
            // 
            // TxtNumber
            // 
            this.TxtNumber.ChangeColorIfNotEmpty = false;
            this.TxtNumber.ChangeColorOnEnter = true;
            this.TxtNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtNumber.Location = new System.Drawing.Point(297, 60);
            this.TxtNumber.MaxLength = 2;
            this.TxtNumber.Name = "TxtNumber";
            this.TxtNumber.Negative = true;
            this.TxtNumber.NotEmpty = false;
            this.TxtNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtNumber.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.TxtNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtNumber.SelectOnEnter = true;
            this.TxtNumber.Size = new System.Drawing.Size(139, 23);
            this.TxtNumber.TabIndex = 49;
            this.TxtNumber.TextMode = ClassLibrary.TextModes.Real;
            // 
            // chkElectronic
            // 
            this.chkElectronic.AutoSize = true;
            this.chkElectronic.Location = new System.Drawing.Point(6, 62);
            this.chkElectronic.Name = "chkElectronic";
            this.chkElectronic.Size = new System.Drawing.Size(155, 20);
            this.chkElectronic.TabIndex = 50;
            this.chkElectronic.Text = "پرداخت الكترونيكي فعال";
            this.chkElectronic.UseVisualStyleBackColor = true;
            // 
            // JGroupCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 444);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "JGroupCardForm";
            this.Text = "تعریف گروه";
            this.Load += new System.EventHandler(this.JGroupCardForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JGroupCardForm_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        
        private System.Windows.Forms.Label label7;
       
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        public  ClassLibrary.NumEdit txtSecondAmount;
        private System.Windows.Forms.Label label3;
        public  ClassLibrary.NumEdit txtFirstAmount;
        public  ClassLibrary.NumEdit TxtAbate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        public  ClassLibrary.NumEdit TxtRound;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        public  ClassLibrary.NumEdit TxtOffer;
        private System.Windows.Forms.Label label11;
        public  System.Windows.Forms.CheckBox chkMinute;
        public  System.Windows.Forms.CheckBox chkElectronic;
        public  System.Windows.Forms.CheckBox chkinputDisplay;
        public  ClassLibrary.NumEdit txtUnitTime;
        private System.Windows.Forms.Label label5;
        public  System.Windows.Forms.CheckBox chkUpRound;

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        public  ClassLibrary.NumEdit TxtNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        public  ClassLibrary.TextEdit TxtName;
        private System.Windows.Forms.Label label16;
        public ClassLibrary.JComboBox cmbComplex;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.CheckBox chkIsActive;
        private TCCOParking.TccoParking tccoParking;
        public ClassLibrary.NumEdit TxtDailyPrice;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckBox chkIsDailyApart;
        private System.Windows.Forms.CheckBox chkIsFirstHourApart;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
