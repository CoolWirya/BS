namespace Legal
{
    partial class JPonyForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDateContract = new ClassLibrary.DateEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtDateDeliver = new ClassLibrary.DateEdit(this.components);
            this.txtdateStart = new ClassLibrary.DateEdit(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtdateEnd = new ClassLibrary.DateEdit(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContractCode = new System.Windows.Forms.TextBox();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAdvertisement = new System.Windows.Forms.CheckBox();
            this.chkTelephone = new System.Windows.Forms.CheckBox();
            this.chkPriceMonth = new System.Windows.Forms.CheckBox();
            this.chkPrice = new System.Windows.Forms.CheckBox();
            this.chkSharj = new System.Windows.Forms.CheckBox();
            this.chkPower = new System.Windows.Forms.CheckBox();
            this.chkRightStationery = new System.Windows.Forms.CheckBox();
            this.chkMayor = new System.Windows.Forms.CheckBox();
            this.chkInsuranceOffice = new System.Windows.Forms.CheckBox();
            this.chkTaxOffice = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkManagerSignature = new System.Windows.Forms.CheckBox();
            this.chkRenterSignature = new System.Windows.Forms.CheckBox();
            this.chkOfficeSignature = new System.Windows.Forms.CheckBox();
            this.chkLodgerSignature = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.jArchivePony = new ArchivedDocuments.JArchiveList();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDateContract);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDateDeliver);
            this.groupBox1.Controls.Add(this.txtdateStart);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtdateEnd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtContractCode);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtDateContract
            // 
            this.txtDateContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateContract.ChangeColorIfNotEmpty = true;
            this.txtDateContract.ChangeColorOnEnter = true;
            this.txtDateContract.Date = new System.DateTime(((long)(0)));
            this.txtDateContract.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateContract.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateContract.InsertInDatesTable = true;
            this.txtDateContract.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateContract.Location = new System.Drawing.Point(358, 45);
            this.txtDateContract.Mask = "0000/00/00";
            this.txtDateContract.Name = "txtDateContract";
            this.txtDateContract.NotEmpty = false;
            this.txtDateContract.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateContract.ReadOnly = true;
            this.txtDateContract.Size = new System.Drawing.Size(106, 23);
            this.txtDateContract.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(469, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 44;
            this.label1.Text = "تاريخ قرارداد:";
            // 
            // txtDateDeliver
            // 
            this.txtDateDeliver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateDeliver.ChangeColorIfNotEmpty = true;
            this.txtDateDeliver.ChangeColorOnEnter = true;
            this.txtDateDeliver.Date = new System.DateTime(((long)(0)));
            this.txtDateDeliver.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateDeliver.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateDeliver.InsertInDatesTable = true;
            this.txtDateDeliver.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateDeliver.Location = new System.Drawing.Point(100, 70);
            this.txtDateDeliver.Mask = "0000/00/00";
            this.txtDateDeliver.Name = "txtDateDeliver";
            this.txtDateDeliver.NotEmpty = false;
            this.txtDateDeliver.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateDeliver.ReadOnly = true;
            this.txtDateDeliver.Size = new System.Drawing.Size(110, 23);
            this.txtDateDeliver.TabIndex = 39;
            // 
            // txtdateStart
            // 
            this.txtdateStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdateStart.ChangeColorIfNotEmpty = true;
            this.txtdateStart.ChangeColorOnEnter = true;
            this.txtdateStart.Date = new System.DateTime(((long)(0)));
            this.txtdateStart.InBackColor = System.Drawing.SystemColors.Info;
            this.txtdateStart.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtdateStart.InsertInDatesTable = true;
            this.txtdateStart.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtdateStart.Location = new System.Drawing.Point(100, 12);
            this.txtdateStart.Mask = "0000/00/00";
            this.txtdateStart.Name = "txtdateStart";
            this.txtdateStart.NotEmpty = false;
            this.txtdateStart.NotEmptyColor = System.Drawing.Color.Red;
            this.txtdateStart.ReadOnly = true;
            this.txtdateStart.Size = new System.Drawing.Size(110, 23);
            this.txtdateStart.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 42;
            this.label7.Text = "تاريخ تحويل :";
            // 
            // txtdateEnd
            // 
            this.txtdateEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdateEnd.ChangeColorIfNotEmpty = true;
            this.txtdateEnd.ChangeColorOnEnter = true;
            this.txtdateEnd.Date = new System.DateTime(((long)(0)));
            this.txtdateEnd.InBackColor = System.Drawing.SystemColors.Info;
            this.txtdateEnd.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtdateEnd.InsertInDatesTable = true;
            this.txtdateEnd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtdateEnd.Location = new System.Drawing.Point(100, 41);
            this.txtdateEnd.Mask = "0000/00/00";
            this.txtdateEnd.Name = "txtdateEnd";
            this.txtdateEnd.NotEmpty = false;
            this.txtdateEnd.NotEmptyColor = System.Drawing.Color.Red;
            this.txtdateEnd.ReadOnly = true;
            this.txtdateEnd.Size = new System.Drawing.Size(110, 23);
            this.txtdateEnd.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 41;
            this.label5.Text = "تاريخ اتمام قرارداد :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 16);
            this.label6.TabIndex = 40;
            this.label6.Text = "تاريخ شروع قرارداد :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(469, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "شماره قرارداد :";
            // 
            // txtContractCode
            // 
            this.txtContractCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContractCode.Location = new System.Drawing.Point(358, 15);
            this.txtContractCode.Name = "txtContractCode";
            this.txtContractCode.ReadOnly = true;
            this.txtContractCode.Size = new System.Drawing.Size(106, 23);
            this.txtContractCode.TabIndex = 33;
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
            this.txtDate.Location = new System.Drawing.Point(315, 16);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(111, 23);
            this.txtDate.TabIndex = 30;
            this.txtDate.TextChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(431, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "تاریخ تسویه حساب:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAdvertisement);
            this.groupBox2.Controls.Add(this.chkTelephone);
            this.groupBox2.Controls.Add(this.chkPriceMonth);
            this.groupBox2.Controls.Add(this.chkPrice);
            this.groupBox2.Controls.Add(this.chkSharj);
            this.groupBox2.Controls.Add(this.chkPower);
            this.groupBox2.Controls.Add(this.chkRightStationery);
            this.groupBox2.Controls.Add(this.chkMayor);
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.chkInsuranceOffice);
            this.groupBox2.Controls.Add(this.chkTaxOffice);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(573, 135);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // chkAdvertisement
            // 
            this.chkAdvertisement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAdvertisement.AutoSize = true;
            this.chkAdvertisement.Location = new System.Drawing.Point(23, 51);
            this.chkAdvertisement.Name = "chkAdvertisement";
            this.chkAdvertisement.Size = new System.Drawing.Size(67, 20);
            this.chkAdvertisement.TabIndex = 4;
            this.chkAdvertisement.Text = "تبلیغات";
            this.chkAdvertisement.UseVisualStyleBackColor = true;
            this.chkAdvertisement.CheckedChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // chkTelephone
            // 
            this.chkTelephone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTelephone.AutoSize = true;
            this.chkTelephone.Location = new System.Drawing.Point(333, 103);
            this.chkTelephone.Name = "chkTelephone";
            this.chkTelephone.Size = new System.Drawing.Size(53, 20);
            this.chkTelephone.TabIndex = 9;
            this.chkTelephone.Text = "تلفن";
            this.chkTelephone.UseVisualStyleBackColor = true;
            this.chkTelephone.CheckedChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // chkPriceMonth
            // 
            this.chkPriceMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPriceMonth.AutoSize = true;
            this.chkPriceMonth.Location = new System.Drawing.Point(460, 51);
            this.chkPriceMonth.Name = "chkPriceMonth";
            this.chkPriceMonth.Size = new System.Drawing.Size(98, 20);
            this.chkPriceMonth.TabIndex = 0;
            this.chkPriceMonth.Text = "اجاره ماهیانه";
            this.chkPriceMonth.UseVisualStyleBackColor = true;
            this.chkPriceMonth.CheckedChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // chkPrice
            // 
            this.chkPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPrice.AutoSize = true;
            this.chkPrice.Location = new System.Drawing.Point(431, 77);
            this.chkPrice.Name = "chkPrice";
            this.chkPrice.Size = new System.Drawing.Size(127, 20);
            this.chkPrice.TabIndex = 1;
            this.chkPrice.Text = "مبلغ قرض الحسنه";
            this.chkPrice.UseVisualStyleBackColor = true;
            this.chkPrice.CheckedChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // chkSharj
            // 
            this.chkSharj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSharj.AutoSize = true;
            this.chkSharj.Location = new System.Drawing.Point(436, 103);
            this.chkSharj.Name = "chkSharj";
            this.chkSharj.Size = new System.Drawing.Size(122, 20);
            this.chkSharj.TabIndex = 2;
            this.chkSharj.Text = "مبلغ شارژ ماهانه";
            this.chkSharj.UseVisualStyleBackColor = true;
            this.chkSharj.CheckedChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // chkPower
            // 
            this.chkPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPower.AutoSize = true;
            this.chkPower.Location = new System.Drawing.Point(339, 77);
            this.chkPower.Name = "chkPower";
            this.chkPower.Size = new System.Drawing.Size(47, 20);
            this.chkPower.TabIndex = 8;
            this.chkPower.Text = "برق";
            this.chkPower.UseVisualStyleBackColor = true;
            this.chkPower.CheckedChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // chkRightStationery
            // 
            this.chkRightStationery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRightStationery.AutoSize = true;
            this.chkRightStationery.Location = new System.Drawing.Point(299, 51);
            this.chkRightStationery.Name = "chkRightStationery";
            this.chkRightStationery.Size = new System.Drawing.Size(87, 20);
            this.chkRightStationery.TabIndex = 3;
            this.chkRightStationery.Text = "حق التحریر";
            this.chkRightStationery.UseVisualStyleBackColor = true;
            this.chkRightStationery.CheckedChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // chkMayor
            // 
            this.chkMayor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMayor.AutoSize = true;
            this.chkMayor.Location = new System.Drawing.Point(140, 51);
            this.chkMayor.Name = "chkMayor";
            this.chkMayor.Size = new System.Drawing.Size(77, 20);
            this.chkMayor.TabIndex = 5;
            this.chkMayor.Text = "شهرداری";
            this.chkMayor.UseVisualStyleBackColor = true;
            this.chkMayor.CheckedChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // chkInsuranceOffice
            // 
            this.chkInsuranceOffice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInsuranceOffice.AutoSize = true;
            this.chkInsuranceOffice.Location = new System.Drawing.Point(166, 103);
            this.chkInsuranceOffice.Name = "chkInsuranceOffice";
            this.chkInsuranceOffice.Size = new System.Drawing.Size(51, 20);
            this.chkInsuranceOffice.TabIndex = 7;
            this.chkInsuranceOffice.Text = "بیمه";
            this.chkInsuranceOffice.UseVisualStyleBackColor = true;
            this.chkInsuranceOffice.CheckedChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // chkTaxOffice
            // 
            this.chkTaxOffice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTaxOffice.AutoSize = true;
            this.chkTaxOffice.Location = new System.Drawing.Point(156, 77);
            this.chkTaxOffice.Name = "chkTaxOffice";
            this.chkTaxOffice.Size = new System.Drawing.Size(61, 20);
            this.chkTaxOffice.TabIndex = 6;
            this.chkTaxOffice.Text = "دارایی";
            this.chkTaxOffice.UseVisualStyleBackColor = true;
            this.chkTaxOffice.CheckedChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkManagerSignature);
            this.groupBox3.Controls.Add(this.chkRenterSignature);
            this.groupBox3.Controls.Add(this.chkOfficeSignature);
            this.groupBox3.Controls.Add(this.chkLodgerSignature);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 238);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(573, 55);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // chkManagerSignature
            // 
            this.chkManagerSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkManagerSignature.AutoSize = true;
            this.chkManagerSignature.Location = new System.Drawing.Point(13, 22);
            this.chkManagerSignature.Name = "chkManagerSignature";
            this.chkManagerSignature.Size = new System.Drawing.Size(78, 20);
            this.chkManagerSignature.TabIndex = 13;
            this.chkManagerSignature.Text = "امضا مدیر";
            this.chkManagerSignature.UseVisualStyleBackColor = true;
            this.chkManagerSignature.CheckedChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // chkRenterSignature
            // 
            this.chkRenterSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRenterSignature.AutoSize = true;
            this.chkRenterSignature.Location = new System.Drawing.Point(474, 22);
            this.chkRenterSignature.Name = "chkRenterSignature";
            this.chkRenterSignature.Size = new System.Drawing.Size(82, 20);
            this.chkRenterSignature.TabIndex = 10;
            this.chkRenterSignature.Text = "امضا موجر";
            this.chkRenterSignature.UseVisualStyleBackColor = true;
            this.chkRenterSignature.CheckedChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // chkOfficeSignature
            // 
            this.chkOfficeSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOfficeSignature.AutoSize = true;
            this.chkOfficeSignature.Location = new System.Drawing.Point(135, 22);
            this.chkOfficeSignature.Name = "chkOfficeSignature";
            this.chkOfficeSignature.Size = new System.Drawing.Size(83, 20);
            this.chkOfficeSignature.TabIndex = 12;
            this.chkOfficeSignature.Text = "امضا اداری";
            this.chkOfficeSignature.UseVisualStyleBackColor = true;
            this.chkOfficeSignature.CheckedChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // chkLodgerSignature
            // 
            this.chkLodgerSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLodgerSignature.AutoSize = true;
            this.chkLodgerSignature.Location = new System.Drawing.Point(293, 22);
            this.chkLodgerSignature.Name = "chkLodgerSignature";
            this.chkLodgerSignature.Size = new System.Drawing.Size(94, 20);
            this.chkLodgerSignature.TabIndex = 11;
            this.chkLodgerSignature.Text = "امضا مساجر";
            this.chkLodgerSignature.UseVisualStyleBackColor = true;
            this.chkLodgerSignature.CheckedChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(587, 441);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(579, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "امضا";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDesc);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 293);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(573, 113);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "توضیحات:";
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(3, 19);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(567, 91);
            this.txtDesc.TabIndex = 18;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            this.txtDesc.TextChanged += new System.EventHandler(this.chkPriceMonth_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.jArchivePony);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(579, 412);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تصاویر";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // jArchivePony
            // 
            this.jArchivePony.AllowUserAddFile = true;
            this.jArchivePony.AllowUserAddFromArchive = true;
            this.jArchivePony.AllowUserAddImage = true;
            this.jArchivePony.AllowUserDeleteFile = true;
            this.jArchivePony.ClassName = "";
            this.jArchivePony.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchivePony.Location = new System.Drawing.Point(3, 3);
            this.jArchivePony.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jArchivePony.Name = "jArchivePony";
            this.jArchivePony.ObjectCode = 0;
            this.jArchivePony.PlaceCode = 0;
            this.jArchivePony.Size = new System.Drawing.Size(573, 406);
            this.jArchivePony.SubjectCode = 0;
            this.jArchivePony.TabIndex = 1;
            this.jArchivePony.AfterFileAdded += new ArchivedDocuments.JArchiveList.FileAdded(this.chkPriceMonth_CheckedChanged);
            this.jArchivePony.AfterDescriptioEdited += new ArchivedDocuments.JArchiveList.DescriptioEdited(this.chkPriceMonth_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(20, 447);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(505, 447);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(96, 447);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 14;
            this.btnSaveClose.Text = "ذخیره ";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Visible = false;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // JPonyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 484);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.tabControl1);
            this.Name = "JPonyForm";
            this.Text = "فرم تسویه حساب";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkTelephone;
        private System.Windows.Forms.CheckBox chkPower;
        private System.Windows.Forms.CheckBox chkInsuranceOffice;
        private System.Windows.Forms.CheckBox chkTaxOffice;
        private System.Windows.Forms.CheckBox chkMayor;
        private System.Windows.Forms.CheckBox chkAdvertisement;
        private System.Windows.Forms.CheckBox chkRightStationery;
        private System.Windows.Forms.CheckBox chkSharj;
        private System.Windows.Forms.CheckBox chkPrice;
        private System.Windows.Forms.CheckBox chkPriceMonth;
        private System.Windows.Forms.CheckBox chkManagerSignature;
        private System.Windows.Forms.CheckBox chkRenterSignature;
        private System.Windows.Forms.CheckBox chkLodgerSignature;
        private System.Windows.Forms.CheckBox chkOfficeSignature;
        private ArchivedDocuments.JArchiveList jArchivePony;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContractCode;
        private ClassLibrary.DateEdit txtDateDeliver;
        private ClassLibrary.DateEdit txtdateStart;
        private System.Windows.Forms.Label label7;
        private ClassLibrary.DateEdit txtdateEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.DateEdit txtDateContract;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private ClassLibrary.TextEdit txtDesc;
    }
}