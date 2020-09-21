namespace Legal
{
    partial class SCContractForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbType2 = new System.Windows.Forms.RadioButton();
            this.rbType1 = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.txtContractNumber = new ClassLibrary.TextEdit(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSubject = new ClassLibrary.JComboBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.txtDuration = new ClassLibrary.TextEdit(this.components);
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.txtStartDate = new ClassLibrary.DateEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbGoods = new ClassLibrary.JComboBox(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpCost2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtArea = new ClassLibrary.TextEdit(this.components);
            this.txtPrice2 = new ClassLibrary.TextEdit(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.grpCost = new System.Windows.Forms.GroupBox();
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbUnits = new ClassLibrary.JComboBox(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCondition = new ClassLibrary.TextEdit(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpCost2.SuspendLayout();
            this.grpCost.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBack);
            this.groupBox4.Controls.Add(this.btnCancel);
            this.groupBox4.Controls.Add(this.btnNext);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 570);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(541, 40);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(373, 13);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "قبلی";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(6, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(454, 13);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "بعدی";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbType2);
            this.groupBox6.Controls.Add(this.rbType1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(541, 45);
            this.groupBox6.TabIndex = 101;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "نوع قرارداد:";
            // 
            // rbType2
            // 
            this.rbType2.AutoSize = true;
            this.rbType2.Location = new System.Drawing.Point(98, 19);
            this.rbType2.Name = "rbType2";
            this.rbType2.Size = new System.Drawing.Size(173, 20);
            this.rbType2.TabIndex = 1;
            this.rbType2.Text = "قرارداد اجاره انبار اختصاصی";
            this.rbType2.UseVisualStyleBackColor = true;
            this.rbType2.CheckedChanged += new System.EventHandler(this.tbType1_CheckedChanged);
            // 
            // rbType1
            // 
            this.rbType1.AutoSize = true;
            this.rbType1.Checked = true;
            this.rbType1.Location = new System.Drawing.Point(350, 19);
            this.rbType1.Name = "rbType1";
            this.rbType1.Size = new System.Drawing.Size(109, 20);
            this.rbType1.TabIndex = 0;
            this.rbType1.TabStop = true;
            this.rbType1.Text = "قرارداد انبارداری";
            this.rbType1.UseVisualStyleBackColor = true;
            this.rbType1.CheckedChanged += new System.EventHandler(this.tbType1_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtDate);
            this.groupBox5.Controls.Add(this.txtContractNumber);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.cmbSubject);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 45);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(541, 83);
            this.groupBox5.TabIndex = 102;
            this.groupBox5.TabStop = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(192, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 39;
            this.label8.Text = "تاریخ قرارداد:";
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
            this.txtDate.Location = new System.Drawing.Point(86, 20);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 1;
            // 
            // txtContractNumber
            // 
            this.txtContractNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContractNumber.ChangeColorIfNotEmpty = true;
            this.txtContractNumber.ChangeColorOnEnter = true;
            this.txtContractNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtContractNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtContractNumber.Location = new System.Drawing.Point(297, 20);
            this.txtContractNumber.Name = "txtContractNumber";
            this.txtContractNumber.Negative = true;
            this.txtContractNumber.NotEmpty = false;
            this.txtContractNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtContractNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtContractNumber.SelectOnEnter = true;
            this.txtContractNumber.Size = new System.Drawing.Size(108, 23);
            this.txtContractNumber.TabIndex = 0;
            this.txtContractNumber.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(411, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "شماره قرارداد:";
            // 
            // cmbSubject
            // 
            this.cmbSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSubject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSubject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubject.BaseCode = 0;
            this.cmbSubject.ChangeColorIfNotEmpty = true;
            this.cmbSubject.ChangeColorOnEnter = true;
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbSubject.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSubject.Location = new System.Drawing.Point(86, 49);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.NotEmpty = false;
            this.cmbSubject.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbSubject.SelectOnEnter = true;
            this.cmbSubject.Size = new System.Drawing.Size(319, 24);
            this.cmbSubject.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(411, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 35;
            this.label6.Text = "نوع متن قرارداد:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbStartDate);
            this.groupBox1.Controls.Add(this.txtDuration);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 89);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تاریخ قرارداد:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "تاریخ پایان:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "مدت قرارداد (ماه):";
            // 
            // lbStartDate
            // 
            this.lbStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Location = new System.Drawing.Point(411, 30);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(74, 16);
            this.lbStartDate.TabIndex = 12;
            this.lbStartDate.Text = "تاریخ شروع:";
            // 
            // txtDuration
            // 
            this.txtDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuration.ChangeColorIfNotEmpty = false;
            this.txtDuration.ChangeColorOnEnter = true;
            this.txtDuration.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDuration.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDuration.Location = new System.Drawing.Point(86, 25);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Negative = true;
            this.txtDuration.NotEmpty = false;
            this.txtDuration.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDuration.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDuration.SelectOnEnter = true;
            this.txtDuration.Size = new System.Drawing.Size(48, 23);
            this.txtDuration.TabIndex = 1;
            this.txtDuration.TextMode = ClassLibrary.TextModes.Text;
            this.txtDuration.TextChanged += new System.EventHandler(this.txtStartDate_TextChanged);
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate.ChangeColorIfNotEmpty = true;
            this.txtEndDate.ChangeColorOnEnter = true;
            this.txtEndDate.Date = new System.DateTime(((long)(0)));
            this.txtEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate.InsertInDatesTable = true;
            this.txtEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDate.Location = new System.Drawing.Point(305, 54);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate.ReadOnly = true;
            this.txtEndDate.Size = new System.Drawing.Size(100, 23);
            this.txtEndDate.TabIndex = 10;
            this.txtEndDate.TabStop = false;
            // 
            // txtStartDate
            // 
            this.txtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDate.ChangeColorIfNotEmpty = true;
            this.txtStartDate.ChangeColorOnEnter = true;
            this.txtStartDate.Date = new System.DateTime(((long)(0)));
            this.txtStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDate.InsertInDatesTable = true;
            this.txtStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartDate.Location = new System.Drawing.Point(305, 25);
            this.txtStartDate.Mask = "0000/00/00";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.NotEmpty = false;
            this.txtStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartDate.Size = new System.Drawing.Size(100, 23);
            this.txtStartDate.TabIndex = 0;
            this.txtStartDate.TextChanged += new System.EventHandler(this.txtStartDate_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(409, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "نوع کالا:";
            // 
            // cmbGoods
            // 
            this.cmbGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGoods.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbGoods.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGoods.BaseCode = 0;
            this.cmbGoods.ChangeColorIfNotEmpty = true;
            this.cmbGoods.ChangeColorOnEnter = true;
            this.cmbGoods.FormattingEnabled = true;
            this.cmbGoods.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGoods.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGoods.Location = new System.Drawing.Point(175, 17);
            this.cmbGoods.Name = "cmbGoods";
            this.cmbGoods.NotEmpty = true;
            this.cmbGoods.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGoods.SelectOnEnter = true;
            this.cmbGoods.Size = new System.Drawing.Size(230, 24);
            this.cmbGoods.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbGoods);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(541, 52);
            this.groupBox2.TabIndex = 110;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "نوع کالا:";
            // 
            // grpCost2
            // 
            this.grpCost2.Controls.Add(this.label11);
            this.grpCost2.Controls.Add(this.txtArea);
            this.grpCost2.Controls.Add(this.txtPrice2);
            this.grpCost2.Controls.Add(this.label9);
            this.grpCost2.Controls.Add(this.label10);
            this.grpCost2.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCost2.Location = new System.Drawing.Point(0, 328);
            this.grpCost2.Name = "grpCost2";
            this.grpCost2.Size = new System.Drawing.Size(541, 76);
            this.grpCost2.TabIndex = 112;
            this.grpCost2.TabStop = false;
            this.grpCost2.Text = "مبلغ قرارداد:";
            this.grpCost2.Visible = false;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(383, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "مساحت مورد اجاره:";
            // 
            // txtArea
            // 
            this.txtArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArea.ChangeColorIfNotEmpty = false;
            this.txtArea.ChangeColorOnEnter = true;
            this.txtArea.InBackColor = System.Drawing.SystemColors.Info;
            this.txtArea.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtArea.Location = new System.Drawing.Point(181, 17);
            this.txtArea.Name = "txtArea";
            this.txtArea.Negative = true;
            this.txtArea.NotEmpty = false;
            this.txtArea.NotEmptyColor = System.Drawing.Color.Red;
            this.txtArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtArea.SelectOnEnter = true;
            this.txtArea.Size = new System.Drawing.Size(155, 23);
            this.txtArea.TabIndex = 0;
            this.txtArea.TextMode = ClassLibrary.TextModes.Real;
            // 
            // txtPrice2
            // 
            this.txtPrice2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice2.ChangeColorIfNotEmpty = false;
            this.txtPrice2.ChangeColorOnEnter = true;
            this.txtPrice2.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice2.Location = new System.Drawing.Point(181, 46);
            this.txtPrice2.Name = "txtPrice2";
            this.txtPrice2.Negative = true;
            this.txtPrice2.NotEmpty = false;
            this.txtPrice2.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice2.SelectOnEnter = true;
            this.txtPrice2.Size = new System.Drawing.Size(155, 23);
            this.txtPrice2.TabIndex = 1;
            this.txtPrice2.TextMode = ClassLibrary.TextModes.Money;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(146, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "ریال";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(334, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 14);
            this.label10.TabIndex = 10;
            this.label10.Text = "مبلغ قرارداد به ازای هر متر مربع:";
            // 
            // grpCost
            // 
            this.grpCost.Controls.Add(this.txtPrice);
            this.grpCost.Controls.Add(this.label5);
            this.grpCost.Controls.Add(this.label4);
            this.grpCost.Controls.Add(this.cmbUnits);
            this.grpCost.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCost.Location = new System.Drawing.Point(0, 269);
            this.grpCost.Name = "grpCost";
            this.grpCost.Size = new System.Drawing.Size(541, 59);
            this.grpCost.TabIndex = 111;
            this.grpCost.TabStop = false;
            this.grpCost.Text = "مبلغ قرارداد:";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(175, 23);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(155, 23);
            this.txtPrice.TabIndex = 2;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "ریال";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "به ازای هر:";
            // 
            // cmbUnits
            // 
            this.cmbUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUnits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbUnits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUnits.BaseCode = 0;
            this.cmbUnits.ChangeColorIfNotEmpty = true;
            this.cmbUnits.ChangeColorOnEnter = true;
            this.cmbUnits.FormattingEnabled = true;
            this.cmbUnits.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbUnits.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbUnits.Location = new System.Drawing.Point(334, 22);
            this.cmbUnits.Name = "cmbUnits";
            this.cmbUnits.NotEmpty = true;
            this.cmbUnits.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbUnits.SelectOnEnter = true;
            this.cmbUnits.Size = new System.Drawing.Size(71, 24);
            this.cmbUnits.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCondition);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 404);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(541, 166);
            this.groupBox3.TabIndex = 113;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "سایر شرایط:";
            // 
            // txtCondition
            // 
            this.txtCondition.ChangeColorIfNotEmpty = false;
            this.txtCondition.ChangeColorOnEnter = true;
            this.txtCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCondition.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCondition.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCondition.Location = new System.Drawing.Point(3, 19);
            this.txtCondition.Multiline = true;
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Negative = true;
            this.txtCondition.NotEmpty = false;
            this.txtCondition.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCondition.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCondition.SelectOnEnter = true;
            this.txtCondition.Size = new System.Drawing.Size(535, 144);
            this.txtCondition.TabIndex = 0;
            this.txtCondition.TabStop = false;
            this.txtCondition.TextMode = ClassLibrary.TextModes.Text;
            // 
            // SCContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(541, 610);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpCost2);
            this.Controls.Add(this.grpCost);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Name = "SCContractForm";
            this.Text = "قرارداد مجتمع انبارها";
            this.VisibleChanged += new System.EventHandler(this.SCContractForm_VisibleChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SCContractForm_FormClosed);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpCost2.ResumeLayout(false);
            this.grpCost2.PerformLayout();
            this.grpCost.ResumeLayout(false);
            this.grpCost.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbType2;
        private System.Windows.Forms.RadioButton rbType1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label8;
        private ClassLibrary.DateEdit txtDate;
        private ClassLibrary.TextEdit txtContractNumber;
        private System.Windows.Forms.Label label7;
        private ClassLibrary.JComboBox cmbSubject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbStartDate;
        private ClassLibrary.TextEdit txtDuration;
        private ClassLibrary.DateEdit txtEndDate;
        private ClassLibrary.DateEdit txtStartDate;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JComboBox cmbGoods;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpCost2;
        private ClassLibrary.TextEdit txtPrice2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grpCost;
        private ClassLibrary.TextEdit txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.JComboBox cmbUnits;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.TextEdit txtCondition;
        private System.Windows.Forms.Label label11;
        private ClassLibrary.TextEdit txtArea;
    }
}