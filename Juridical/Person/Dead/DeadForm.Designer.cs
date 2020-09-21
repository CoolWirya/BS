namespace Legal
{
    partial class JDeadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JDeadForm));
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDeadNo = new ClassLibrary.TextEdit(this.components);
            this.txtDeathCertificateDate = new ClassLibrary.DateEdit(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtCode = new ClassLibrary.NumEdit();
            this.txtDeadDate = new ClassLibrary.DateEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbLastname = new System.Windows.Forms.Label();
            this.lbShSh = new System.Windows.Forms.Label();
            this.lbFatherName = new System.Windows.Forms.Label();
            this.lbSHMelli = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.jArchiveList1 = new ArchivedDocuments.JArchiveList();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "ذخیره";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(552, 362);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtDeadNo);
            this.groupBox2.Controls.Add(this.txtDeathCertificateDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCode);
            this.groupBox2.Controls.Add(this.txtDeadDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(594, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtDeadNo
            // 
            this.txtDeadNo.ChangeColorIfNotEmpty = false;
            this.txtDeadNo.ChangeColorOnEnter = true;
            this.txtDeadNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDeadNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeadNo.Location = new System.Drawing.Point(87, 58);
            this.txtDeadNo.Name = "txtDeadNo";
            this.txtDeadNo.Negative = true;
            this.txtDeadNo.NotEmpty = false;
            this.txtDeadNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDeadNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDeadNo.SelectOnEnter = true;
            this.txtDeadNo.Size = new System.Drawing.Size(100, 23);
            this.txtDeadNo.TabIndex = 3;
            this.txtDeadNo.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtDeathCertificateDate
            // 
            this.txtDeathCertificateDate.ChangeColorIfNotEmpty = true;
            this.txtDeathCertificateDate.ChangeColorOnEnter = true;
            this.txtDeathCertificateDate.Date = new System.DateTime(((long)(0)));
            this.txtDeathCertificateDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDeathCertificateDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeathCertificateDate.InsertInDatesTable = true;
            this.txtDeathCertificateDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDeathCertificateDate.Location = new System.Drawing.Point(87, 27);
            this.txtDeathCertificateDate.Mask = "0000/00/00";
            this.txtDeathCertificateDate.Name = "txtDeathCertificateDate";
            this.txtDeathCertificateDate.NotEmpty = false;
            this.txtDeathCertificateDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDeathCertificateDate.Size = new System.Drawing.Size(100, 23);
            this.txtDeathCertificateDate.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "تاریخ گواهی فوت:";
            // 
            // txtCode
            // 
            this.txtCode.ChangeColorIfNotEmpty = true;
            this.txtCode.ChangeColorOnEnter = true;
            this.txtCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCode.Location = new System.Drawing.Point(385, 23);
            this.txtCode.Name = "txtCode";
            this.txtCode.Negative = true;
            this.txtCode.NotEmpty = false;
            this.txtCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCode.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtCode.ReadOnly = true;
            this.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCode.SelectOnEnter = true;
            this.txtCode.Size = new System.Drawing.Size(100, 23);
            this.txtCode.TabIndex = 0;
            this.txtCode.TabStop = false;
            this.txtCode.TextMode = ClassLibrary.TextModes.Text;
            this.txtCode.Leave += new System.EventHandler(this.numEdit2_Leave);
            // 
            // txtDeadDate
            // 
            this.txtDeadDate.ChangeColorIfNotEmpty = true;
            this.txtDeadDate.ChangeColorOnEnter = true;
            this.txtDeadDate.Date = new System.DateTime(((long)(0)));
            this.txtDeadDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDeadDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeadDate.InsertInDatesTable = true;
            this.txtDeadDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDeadDate.Location = new System.Drawing.Point(385, 58);
            this.txtDeadDate.Mask = "0000/00/00";
            this.txtDeadDate.Name = "txtDeadDate";
            this.txtDeadDate.NotEmpty = false;
            this.txtDeadDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDeadDate.Size = new System.Drawing.Size(100, 23);
            this.txtDeadDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "کد شخص:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(491, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 16);
            this.label10.TabIndex = 82;
            this.label10.Text = "تاریخ فوت:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(193, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 16);
            this.label11.TabIndex = 87;
            this.label11.Text = "شماره گواهی فوت:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Controls.Add(this.lbLastname);
            this.groupBox1.Controls.Add(this.lbShSh);
            this.groupBox1.Controls.Add(this.lbFatherName);
            this.groupBox1.Controls.Add(this.lbSHMelli);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(6, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 180);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مشخصات شناسنامه";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(365, 63);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(49, 16);
            this.lbName.TabIndex = 92;
            this.lbName.Text = "label13";
            // 
            // lbLastname
            // 
            this.lbLastname.AutoSize = true;
            this.lbLastname.Location = new System.Drawing.Point(365, 34);
            this.lbLastname.Name = "lbLastname";
            this.lbLastname.Size = new System.Drawing.Size(49, 16);
            this.lbLastname.TabIndex = 93;
            this.lbLastname.Text = "label14";
            // 
            // lbShSh
            // 
            this.lbShSh.AutoSize = true;
            this.lbShSh.Location = new System.Drawing.Point(365, 121);
            this.lbShSh.Name = "lbShSh";
            this.lbShSh.Size = new System.Drawing.Size(49, 16);
            this.lbShSh.TabIndex = 94;
            this.lbShSh.Text = "label15";
            // 
            // lbFatherName
            // 
            this.lbFatherName.AutoSize = true;
            this.lbFatherName.Location = new System.Drawing.Point(365, 92);
            this.lbFatherName.Name = "lbFatherName";
            this.lbFatherName.Size = new System.Drawing.Size(49, 16);
            this.lbFatherName.TabIndex = 95;
            this.lbFatherName.Text = "label16";
            // 
            // lbSHMelli
            // 
            this.lbSHMelli.AutoSize = true;
            this.lbSHMelli.Location = new System.Drawing.Point(365, 150);
            this.lbSHMelli.Name = "lbSHMelli";
            this.lbSHMelli.Size = new System.Drawing.Size(49, 16);
            this.lbSHMelli.TabIndex = 96;
            this.lbSHMelli.Text = "label17";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(546, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "نام";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(491, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 58;
            this.label3.Text = "نام خانوادگی";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "شماره شناسنامه";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(526, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 59;
            this.label5.Text = "نام پدر";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(520, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 65;
            this.label8.Text = "کد ملی";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 344);
            this.tabControl1.TabIndex = 88;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(614, 315);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "کلیات";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.jArchiveList1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(614, 315);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "فایل های مرتبط";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // jArchiveList1
            // 
            this.jArchiveList1.AllowUserAddFile = true;
            this.jArchiveList1.AllowUserAddFromArchive = true;
            this.jArchiveList1.AllowUserAddImage = true;
            this.jArchiveList1.AllowUserDeleteFile = true;
            this.jArchiveList1.ClassName = "";
            this.jArchiveList1.ClassNames = null;
            this.jArchiveList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveList1.EnabledChange = true;
            this.jArchiveList1.Location = new System.Drawing.Point(3, 3);
            this.jArchiveList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jArchiveList1.Name = "jArchiveList1";
            this.jArchiveList1.ObjectCode = 0;
            this.jArchiveList1.ObjectCodes = null;
            this.jArchiveList1.PlaceCode = 0;
            this.jArchiveList1.Size = new System.Drawing.Size(608, 309);
            this.jArchiveList1.SubjectCode = 0;
            this.jArchiveList1.TabIndex = 0;
            // 
            // JDeadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 404);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button1);
            this.Name = "JDeadForm";
            this.Text = "گواهی فوت";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.DateEdit dateEdit1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.NumEdit txtCode;
        private ClassLibrary.DateEdit txtDeadDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbLastname;
        private System.Windows.Forms.Label lbShSh;
        private System.Windows.Forms.Label lbFatherName;
        private System.Windows.Forms.Label lbSHMelli;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ClassLibrary.DateEdit txtDeathCertificateDate;
        private System.Windows.Forms.Label label6;
        public ArchivedDocuments.JArchiveList jArchiveList1;
        private ClassLibrary.TextEdit txtDeadNo;
    }
}