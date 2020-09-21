namespace Legal
{
    partial class JNotaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JNotaryForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCity = new ClassLibrary.JComboBox(this.components);
            this.txtAddress = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAssistant = new ClassLibrary.TextEdit(this.components);
            this.txtHeadOffice = new ClassLibrary.TextEdit(this.components);
            this.txtNumNotary = new ClassLibrary.TextEdit(this.components);
            this.txtMobile = new ClassLibrary.TextEdit(this.components);
            this.txtFax = new ClassLibrary.TextEdit(this.components);
            this.txtTel = new ClassLibrary.TextEdit(this.components);
            this.btmSave = new System.Windows.Forms.Button();
            this.btmClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "شماره دفتر اسناد رسمی:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCity);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 186);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "موقعیت";
            // 
            // cmbCity
            // 
            this.cmbCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCity.BaseCode = 0;
            this.cmbCity.ChangeColorIfNotEmpty = true;
            this.cmbCity.ChangeColorOnEnter = true;
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCity.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCity.Location = new System.Drawing.Point(179, 29);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.NotEmpty = false;
            this.cmbCity.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCity.SelectOnEnter = true;
            this.cmbCity.Size = new System.Drawing.Size(137, 24);
            this.cmbCity.TabIndex = 0;
            this.cmbCity.SelectedValueChanged += new System.EventHandler(this.txtHeadOffice_TextChanged);
            this.cmbCity.TextChanged += new System.EventHandler(this.txtHeadOffice_TextChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.ChangeColorIfNotEmpty = true;
            this.txtAddress.ChangeColorOnEnter = true;
            this.txtAddress.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAddress.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAddress.Location = new System.Drawing.Point(6, 59);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Negative = true;
            this.txtAddress.NotEmpty = false;
            this.txtAddress.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.SelectOnEnter = true;
            this.txtAddress.Size = new System.Drawing.Size(310, 109);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.TextMode = ClassLibrary.TextModes.Text;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtHeadOffice_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(322, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "آدرس:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "شهر:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "سر دفتر:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "دفتر یار:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "تلفن:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "نمابر:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(196, 328);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "همراه:";
            // 
            // txtAssistant
            // 
            this.txtAssistant.ChangeColorIfNotEmpty = true;
            this.txtAssistant.ChangeColorOnEnter = true;
            this.txtAssistant.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAssistant.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAssistant.Location = new System.Drawing.Point(171, 89);
            this.txtAssistant.Name = "txtAssistant";
            this.txtAssistant.Negative = true;
            this.txtAssistant.NotEmpty = false;
            this.txtAssistant.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAssistant.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAssistant.SelectOnEnter = true;
            this.txtAssistant.Size = new System.Drawing.Size(211, 23);
            this.txtAssistant.TabIndex = 2;
            this.txtAssistant.TextMode = ClassLibrary.TextModes.Text;
            this.txtAssistant.TextChanged += new System.EventHandler(this.txtHeadOffice_TextChanged);
            // 
            // txtHeadOffice
            // 
            this.txtHeadOffice.ChangeColorIfNotEmpty = true;
            this.txtHeadOffice.ChangeColorOnEnter = true;
            this.txtHeadOffice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtHeadOffice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtHeadOffice.Location = new System.Drawing.Point(171, 52);
            this.txtHeadOffice.Name = "txtHeadOffice";
            this.txtHeadOffice.Negative = true;
            this.txtHeadOffice.NotEmpty = false;
            this.txtHeadOffice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtHeadOffice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtHeadOffice.SelectOnEnter = true;
            this.txtHeadOffice.Size = new System.Drawing.Size(210, 23);
            this.txtHeadOffice.TabIndex = 1;
            this.txtHeadOffice.TextMode = ClassLibrary.TextModes.Text;
            this.txtHeadOffice.TextChanged += new System.EventHandler(this.txtHeadOffice_TextChanged);
            // 
            // txtNumNotary
            // 
            this.txtNumNotary.ChangeColorIfNotEmpty = true;
            this.txtNumNotary.ChangeColorOnEnter = true;
            this.txtNumNotary.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumNotary.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumNotary.Location = new System.Drawing.Point(171, 23);
            this.txtNumNotary.Name = "txtNumNotary";
            this.txtNumNotary.Negative = true;
            this.txtNumNotary.NotEmpty = false;
            this.txtNumNotary.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumNotary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumNotary.SelectOnEnter = true;
            this.txtNumNotary.Size = new System.Drawing.Size(100, 23);
            this.txtNumNotary.TabIndex = 0;
            this.txtNumNotary.TextMode = ClassLibrary.TextModes.Integer;
            this.txtNumNotary.TextChanged += new System.EventHandler(this.txtHeadOffice_TextChanged);
            // 
            // txtMobile
            // 
            this.txtMobile.ChangeColorIfNotEmpty = true;
            this.txtMobile.ChangeColorOnEnter = true;
            this.txtMobile.InBackColor = System.Drawing.SystemColors.Info;
            this.txtMobile.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMobile.Location = new System.Drawing.Point(246, 328);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Negative = true;
            this.txtMobile.NotEmpty = false;
            this.txtMobile.NotEmptyColor = System.Drawing.Color.Red;
            this.txtMobile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMobile.SelectOnEnter = true;
            this.txtMobile.Size = new System.Drawing.Size(131, 23);
            this.txtMobile.TabIndex = 5;
            this.txtMobile.TextMode = ClassLibrary.TextModes.Text;
            this.txtMobile.TextChanged += new System.EventHandler(this.txtHeadOffice_TextChanged);
            // 
            // txtFax
            // 
            this.txtFax.ChangeColorIfNotEmpty = true;
            this.txtFax.ChangeColorOnEnter = true;
            this.txtFax.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFax.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFax.Location = new System.Drawing.Point(57, 363);
            this.txtFax.Name = "txtFax";
            this.txtFax.Negative = true;
            this.txtFax.NotEmpty = false;
            this.txtFax.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFax.SelectOnEnter = true;
            this.txtFax.Size = new System.Drawing.Size(116, 23);
            this.txtFax.TabIndex = 6;
            this.txtFax.TextMode = ClassLibrary.TextModes.Text;
            this.txtFax.TextChanged += new System.EventHandler(this.txtHeadOffice_TextChanged);
            // 
            // txtTel
            // 
            this.txtTel.ChangeColorIfNotEmpty = true;
            this.txtTel.ChangeColorOnEnter = true;
            this.txtTel.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTel.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTel.Location = new System.Drawing.Point(57, 331);
            this.txtTel.Name = "txtTel";
            this.txtTel.Negative = true;
            this.txtTel.NotEmpty = false;
            this.txtTel.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTel.SelectOnEnter = true;
            this.txtTel.Size = new System.Drawing.Size(116, 23);
            this.txtTel.TabIndex = 4;
            this.txtTel.TextMode = ClassLibrary.TextModes.Text;
            this.txtTel.TextChanged += new System.EventHandler(this.txtHeadOffice_TextChanged);
            // 
            // btmSave
            // 
            this.btmSave.Location = new System.Drawing.Point(82, 416);
            this.btmSave.Name = "btmSave";
            this.btmSave.Size = new System.Drawing.Size(75, 23);
            this.btmSave.TabIndex = 7;
            this.btmSave.Text = "ذخیره";
            this.btmSave.UseVisualStyleBackColor = true;
            this.btmSave.Click += new System.EventHandler(this.btmSave_Click);
            // 
            // btmClose
            // 
            this.btmClose.Location = new System.Drawing.Point(227, 416);
            this.btmClose.Name = "btmClose";
            this.btmClose.Size = new System.Drawing.Size(75, 23);
            this.btmClose.TabIndex = 8;
            this.btmClose.Text = "خروج";
            this.btmClose.UseVisualStyleBackColor = true;
            this.btmClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // JNotaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 451);
            this.Controls.Add(this.btmClose);
            this.Controls.Add(this.btmSave);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.txtNumNotary);
            this.Controls.Add(this.txtHeadOffice);
            this.Controls.Add(this.txtAssistant);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "JNotaryForm";
            this.Text = "دفتر اسناد رسمی";
            this.Load += new System.EventHandler(this.JNotaryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private ClassLibrary.TextEdit txtAddress;
        private ClassLibrary.TextEdit txtAssistant;
        private ClassLibrary.TextEdit txtHeadOffice;
        private ClassLibrary.TextEdit txtNumNotary;
        private ClassLibrary.JComboBox cmbCity;
        private ClassLibrary.TextEdit txtMobile;
        private ClassLibrary.TextEdit txtFax;
        private ClassLibrary.TextEdit txtTel;
        private System.Windows.Forms.Button btmSave;
        private System.Windows.Forms.Button btmClose;
    }
}