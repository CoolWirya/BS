namespace Legal
{
    partial class JJudicialBranchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JJudicialBranchForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labCity = new System.Windows.Forms.Label();
            this.txtAddress = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.cmbJudicalComplex = new ClassLibrary.JComboBox(this.components);
            this.txtCode = new ClassLibrary.TextEdit(this.components);
            this.txtName = new ClassLibrary.TextEdit(this.components);
            this.txtFax = new ClassLibrary.TextEdit(this.components);
            this.OK = new System.Windows.Forms.Button();
            this.txtTel = new ClassLibrary.TextEdit(this.components);
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
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = " شعبه:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "کد:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labCity);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 155);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "موقعیت";
            // 
            // labCity
            // 
            this.labCity.AutoSize = true;
            this.labCity.Location = new System.Drawing.Point(266, 30);
            this.labCity.Name = "labCity";
            this.labCity.Size = new System.Drawing.Size(12, 16);
            this.labCity.TabIndex = 3;
            this.labCity.Text = " ";
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
            this.txtAddress.Size = new System.Drawing.Size(269, 90);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.TextMode = ClassLibrary.TextModes.Text;
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
            this.label3.Location = new System.Drawing.Point(327, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "شهر:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 328);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "نمابر:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "تلفن:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "مجتمع قضائی:";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(84, 391);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 6;
            this.Save.Text = "ذخیره";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Visible = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(321, 391);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 7;
            this.Close.Text = "خروج";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // cmbJudicalComplex
            // 
            this.cmbJudicalComplex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbJudicalComplex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbJudicalComplex.BaseCode = 0;
            this.cmbJudicalComplex.ChangeColorIfNotEmpty = true;
            this.cmbJudicalComplex.ChangeColorOnEnter = true;
            this.cmbJudicalComplex.FormattingEnabled = true;
            this.cmbJudicalComplex.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbJudicalComplex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbJudicalComplex.Location = new System.Drawing.Point(108, 88);
            this.cmbJudicalComplex.Name = "cmbJudicalComplex";
            this.cmbJudicalComplex.NotEmpty = false;
            this.cmbJudicalComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbJudicalComplex.SelectOnEnter = true;
            this.cmbJudicalComplex.Size = new System.Drawing.Size(269, 24);
            this.cmbJudicalComplex.TabIndex = 1;
            this.cmbJudicalComplex.SelectedIndexChanged += new System.EventHandler(this.cmbJudicalComplex_SelectedIndexChanged);
            // 
            // txtCode
            // 
            this.txtCode.ChangeColorIfNotEmpty = true;
            this.txtCode.ChangeColorOnEnter = true;
            this.txtCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCode.Location = new System.Drawing.Point(108, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Negative = true;
            this.txtCode.NotEmpty = false;
            this.txtCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCode.ReadOnly = true;
            this.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCode.SelectOnEnter = true;
            this.txtCode.Size = new System.Drawing.Size(121, 23);
            this.txtCode.TabIndex = 0;
            this.txtCode.TabStop = false;
            this.txtCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtName
            // 
            this.txtName.ChangeColorIfNotEmpty = true;
            this.txtName.ChangeColorOnEnter = true;
            this.txtName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(108, 50);
            this.txtName.Name = "txtName";
            this.txtName.Negative = true;
            this.txtName.NotEmpty = false;
            this.txtName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectOnEnter = true;
            this.txtName.Size = new System.Drawing.Size(269, 23);
            this.txtName.TabIndex = 0;
            this.txtName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtFax
            // 
            this.txtFax.ChangeColorIfNotEmpty = true;
            this.txtFax.ChangeColorOnEnter = true;
            this.txtFax.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFax.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFax.Location = new System.Drawing.Point(108, 325);
            this.txtFax.Name = "txtFax";
            this.txtFax.Negative = true;
            this.txtFax.NotEmpty = false;
            this.txtFax.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFax.SelectOnEnter = true;
            this.txtFax.Size = new System.Drawing.Size(202, 23);
            this.txtFax.TabIndex = 4;
            this.txtFax.TextMode = ClassLibrary.TextModes.Text;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(3, 391);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 5;
            this.OK.Text = "تایید";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // txtTel
            // 
            this.txtTel.ChangeColorIfNotEmpty = true;
            this.txtTel.ChangeColorOnEnter = true;
            this.txtTel.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTel.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTel.Location = new System.Drawing.Point(108, 292);
            this.txtTel.Name = "txtTel";
            this.txtTel.Negative = true;
            this.txtTel.NotEmpty = false;
            this.txtTel.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTel.SelectOnEnter = true;
            this.txtTel.Size = new System.Drawing.Size(202, 23);
            this.txtTel.TabIndex = 3;
            this.txtTel.TextMode = ClassLibrary.TextModes.Text;
            // 
            // JJudicialBranchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 426);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.cmbJudicalComplex);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JJudicialBranchForm";
            this.Text = "شعبه قضائی";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Close;
        private ClassLibrary.TextEdit txtAddress;
        private ClassLibrary.TextEdit txtCode;
        private ClassLibrary.TextEdit txtName;
        private ClassLibrary.TextEdit txtFax;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label labCity;
        private ClassLibrary.TextEdit txtTel;
        public ClassLibrary.JComboBox cmbJudicalComplex;
    }
}