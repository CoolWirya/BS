namespace Parking
{
    partial class JCardParkingForm
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
            this.GrpParking = new System.Windows.Forms.GroupBox();
            this.txtExpireDate = new ClassLibrary.DateEdit(this.components);
            this.txtIDCardParking = new ClassLibrary.NumEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkEnableService = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDeactive = new ClassLibrary.JComboBox(this.components);
            this.cmbGroupCard = new ClassLibrary.JComboBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.BtnApplay = new System.Windows.Forms.Button();
            this.btnDefineCar = new System.Windows.Forms.Button();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.LblAsset = new System.Windows.Forms.Label();
            this.lblPerson = new System.Windows.Forms.Label();
            this.btnWrite = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnShowTraffic = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tccoRFID = new TCCORFID.TccoRFID();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LblDevice = new System.Windows.Forms.Label();
            this.GrpParking.SuspendLayout();
            this.grpDetail.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpParking
            // 
            this.GrpParking.Controls.Add(this.txtExpireDate);
            this.GrpParking.Controls.Add(this.txtIDCardParking);
            this.GrpParking.Controls.Add(this.label4);
            this.GrpParking.Controls.Add(this.label2);
            this.GrpParking.Controls.Add(this.chkEnableService);
            this.GrpParking.Controls.Add(this.label1);
            this.GrpParking.Controls.Add(this.cmbDeactive);
            this.GrpParking.Controls.Add(this.cmbGroupCard);
            this.GrpParking.Controls.Add(this.label3);
            this.GrpParking.Controls.Add(this.chkStatus);
            this.GrpParking.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpParking.Location = new System.Drawing.Point(0, 0);
            this.GrpParking.Name = "GrpParking";
            this.GrpParking.Size = new System.Drawing.Size(650, 118);
            this.GrpParking.TabIndex = 85;
            this.GrpParking.TabStop = false;
            this.GrpParking.Text = "خدمات پاركينگ";
            // 
            // txtExpireDate
            // 
            this.txtExpireDate.ChangeColorIfNotEmpty = true;
            this.txtExpireDate.ChangeColorOnEnter = true;
            this.txtExpireDate.Date = new System.DateTime(((long)(0)));
            this.txtExpireDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtExpireDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtExpireDate.InsertInDatesTable = true;
            this.txtExpireDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtExpireDate.Location = new System.Drawing.Point(175, 55);
            this.txtExpireDate.Mask = "0000/00/00";
            this.txtExpireDate.Name = "txtExpireDate";
            this.txtExpireDate.NotEmpty = false;
            this.txtExpireDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtExpireDate.Size = new System.Drawing.Size(91, 23);
            this.txtExpireDate.TabIndex = 88;
            // 
            // txtIDCardParking
            // 
            this.txtIDCardParking.ChangeColorIfNotEmpty = false;
            this.txtIDCardParking.ChangeColorOnEnter = true;
            this.txtIDCardParking.Enabled = false;
            this.txtIDCardParking.InBackColor = System.Drawing.SystemColors.Info;
            this.txtIDCardParking.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIDCardParking.Location = new System.Drawing.Point(411, 22);
            this.txtIDCardParking.Name = "txtIDCardParking";
            this.txtIDCardParking.Negative = true;
            this.txtIDCardParking.NotEmpty = false;
            this.txtIDCardParking.NotEmptyColor = System.Drawing.Color.Red;
            this.txtIDCardParking.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtIDCardParking.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIDCardParking.SelectOnEnter = true;
            this.txtIDCardParking.Size = new System.Drawing.Size(101, 23);
            this.txtIDCardParking.TabIndex = 81;
            this.txtIDCardParking.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 87;
            this.label4.Text = "تاريخ انقضاء :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 80;
            this.label2.Text = "شماره کارت پارکینگ :";
            // 
            // chkEnableService
            // 
            this.chkEnableService.AutoSize = true;
            this.chkEnableService.Enabled = false;
            this.chkEnableService.Location = new System.Drawing.Point(449, 57);
            this.chkEnableService.Name = "chkEnableService";
            this.chkEnableService.Size = new System.Drawing.Size(194, 20);
            this.chkEnableService.TabIndex = 86;
            this.chkEnableService.Text = "اين كارت در پاركينگ فعال است";
            this.chkEnableService.UseVisualStyleBackColor = true;
            this.chkEnableService.CheckedChanged += new System.EventHandler(this.chkEnableService_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 82;
            this.label1.Text = "نحوه محاسبه تعرفه :";
            // 
            // cmbDeactive
            // 
            this.cmbDeactive.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbDeactive.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDeactive.BaseCode = 0;
            this.cmbDeactive.ChangeColorIfNotEmpty = true;
            this.cmbDeactive.ChangeColorOnEnter = true;
            this.cmbDeactive.FormattingEnabled = true;
            this.cmbDeactive.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbDeactive.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDeactive.Location = new System.Drawing.Point(12, 91);
            this.cmbDeactive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDeactive.Name = "cmbDeactive";
            this.cmbDeactive.NotEmpty = false;
            this.cmbDeactive.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbDeactive.SelectOnEnter = true;
            this.cmbDeactive.Size = new System.Drawing.Size(256, 24);
            this.cmbDeactive.TabIndex = 85;
            // 
            // cmbGroupCard
            // 
            this.cmbGroupCard.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbGroupCard.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroupCard.BaseCode = 0;
            this.cmbGroupCard.ChangeColorIfNotEmpty = true;
            this.cmbGroupCard.ChangeColorOnEnter = true;
            this.cmbGroupCard.FormattingEnabled = true;
            this.cmbGroupCard.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGroupCard.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGroupCard.Location = new System.Drawing.Point(93, 22);
            this.cmbGroupCard.Name = "cmbGroupCard";
            this.cmbGroupCard.NotEmpty = false;
            this.cmbGroupCard.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGroupCard.SelectOnEnter = true;
            this.cmbGroupCard.Size = new System.Drawing.Size(173, 24);
            this.cmbGroupCard.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 84;
            this.label3.Text = "علت غير فعال شدن:";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Checked = true;
            this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatus.Location = new System.Drawing.Point(451, 93);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(192, 20);
            this.chkStatus.TabIndex = 44;
            this.chkStatus.Text = "خدمات پاركينگ غير فعال است";
            this.chkStatus.UseVisualStyleBackColor = true;
            this.chkStatus.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);
            // 
            // BtnApplay
            // 
            this.BtnApplay.Location = new System.Drawing.Point(534, 17);
            this.BtnApplay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnApplay.Name = "BtnApplay";
            this.BtnApplay.Size = new System.Drawing.Size(110, 32);
            this.BtnApplay.TabIndex = 84;
            this.BtnApplay.Text = "ثبت";
            this.BtnApplay.UseVisualStyleBackColor = true;
            this.BtnApplay.Click += new System.EventHandler(this.BtnApplay_Click);
            // 
            // btnDefineCar
            // 
            this.btnDefineCar.Enabled = false;
            this.btnDefineCar.Location = new System.Drawing.Point(3, 15);
            this.btnDefineCar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDefineCar.Name = "btnDefineCar";
            this.btnDefineCar.Size = new System.Drawing.Size(153, 32);
            this.btnDefineCar.TabIndex = 79;
            this.btnDefineCar.Text = "تخصيص خودرو";
            this.btnDefineCar.UseVisualStyleBackColor = true;
            this.btnDefineCar.Click += new System.EventHandler(this.btnDefineCar_Click);
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.LblAsset);
            this.grpDetail.Controls.Add(this.lblPerson);
            this.grpDetail.Controls.Add(this.btnDefineCar);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDetail.Location = new System.Drawing.Point(0, 118);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(650, 78);
            this.grpDetail.TabIndex = 86;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "اطلاعات كارت هاي كسبه پرسنل";
            // 
            // LblAsset
            // 
            this.LblAsset.AutoSize = true;
            this.LblAsset.Location = new System.Drawing.Point(517, 50);
            this.LblAsset.Name = "LblAsset";
            this.LblAsset.Size = new System.Drawing.Size(121, 16);
            this.LblAsset.TabIndex = 81;
            this.LblAsset.Text = "مشخصات فروشگاه :";
            // 
            // lblPerson
            // 
            this.lblPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPerson.AutoSize = true;
            this.lblPerson.Location = new System.Drawing.Point(508, 23);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(130, 16);
            this.lblPerson.TabIndex = 80;
            this.lblPerson.Text = "اطلاعات صاحب كارت :";
            // 
            // btnWrite
            // 
            this.btnWrite.Enabled = false;
            this.btnWrite.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnWrite.Location = new System.Drawing.Point(409, 17);
            this.btnWrite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(119, 32);
            this.btnWrite.TabIndex = 87;
            this.btnWrite.Text = "ثبت و ذخيره بروي كارت";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnShowTraffic);
            this.groupBox2.Controls.Add(this.btnWrite);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.BtnApplay);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(650, 56);
            this.groupBox2.TabIndex = 89;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "عمليات";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // BtnShowTraffic
            // 
            this.BtnShowTraffic.Location = new System.Drawing.Point(157, 17);
            this.BtnShowTraffic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnShowTraffic.Name = "BtnShowTraffic";
            this.BtnShowTraffic.Size = new System.Drawing.Size(130, 32);
            this.BtnShowTraffic.TabIndex = 88;
            this.BtnShowTraffic.Text = "سوابق ورود و خروج كارت";
            this.BtnShowTraffic.UseVisualStyleBackColor = true;
            this.BtnShowTraffic.Click += new System.EventHandler(this.BtnShowTraffic_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.Location = new System.Drawing.Point(293, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 32);
            this.button1.TabIndex = 89;
            this.button1.Text = "آماده سازي دستگاه";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.Location = new System.Drawing.Point(49, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 32);
            this.button2.TabIndex = 90;
            this.button2.Text = "تنظيمات دستگاه";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tccoRFID
            // 
            this.tccoRFID.OnReceiveCardData += new TCCORFID.TccoRFID.OnReceiveCardDataHandler(this.tccoRFID_OnReceiveCardData);
            this.tccoRFID.OnDeviceConnect += new TCCORFID.TccoRFID.OnDeviceConnectHandler(this.tccoRFID_OnDeviceConnect);
            this.tccoRFID.OnWriteDataSuccessfullyFinish += new TCCORFID.TccoRFID.OnWriteDataSuccessfullyFinishHandler(this.tccoRFID_OnWriteDataSuccessfullyFinish);
            this.tccoRFID.OnReceiveCard += new TCCORFID.TccoRFID.OnReceiveCardHandler(this.tccoRFID_OnReceiveCard);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LblDevice);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 52);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات دستگاه كارتخوان";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(431, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(207, 16);
            this.label5.TabIndex = 93;
            this.label5.Text = "آدرس دستگاه فرمت كارت هوشمند :";
            // 
            // LblDevice
            // 
            this.LblDevice.AutoSize = true;
            this.LblDevice.ForeColor = System.Drawing.Color.Red;
            this.LblDevice.Location = new System.Drawing.Point(309, 23);
            this.LblDevice.Name = "LblDevice";
            this.LblDevice.Size = new System.Drawing.Size(52, 16);
            this.LblDevice.TabIndex = 92;
            this.LblDevice.Text = "نا معلوم";
            // 
            // JCardParkingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 316);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.GrpParking);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JCardParkingForm";
            this.Text = "اطلاعات پاركينگ";
            this.Load += new System.EventHandler(this.JCardParkingForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JCardParkingForm_FormClosed);
            this.GrpParking.ResumeLayout(false);
            this.GrpParking.PerformLayout();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDefineCar;
        private ClassLibrary.NumEdit txtIDCardParking;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JComboBox cmbGroupCard;
        private System.Windows.Forms.Button BtnApplay;
        private System.Windows.Forms.GroupBox GrpParking;
        private ClassLibrary.JComboBox cmbDeactive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label LblAsset;
        private System.Windows.Forms.Label lblPerson;
        private System.Windows.Forms.CheckBox chkEnableService;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnShowTraffic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public TCCORFID.TccoRFID tccoRFID;
        private ClassLibrary.DateEdit txtExpireDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblDevice;
    }
}