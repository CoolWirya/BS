namespace ShareProfit
{
    partial class JCourseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JCourseForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtFinYear = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCost = new ClassLibrary.MoneyEdit(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCompany = new ClassLibrary.JComboBox(this.components);
            this.chkOnlineShare = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtApproveDate = new ClassLibrary.DateEdit(this.components);
            this.txtShareCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnProperty = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(442, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "CourseCode:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "CourseTitle:";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(330, 55);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(100, 23);
            this.txtCode.TabIndex = 1;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(14, 87);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(416, 23);
            this.txtTitle.TabIndex = 3;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(457, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtFinYear
            // 
            this.txtFinYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinYear.Location = new System.Drawing.Point(311, 120);
            this.txtFinYear.Name = "txtFinYear";
            this.txtFinYear.Size = new System.Drawing.Size(100, 23);
            this.txtFinYear.TabIndex = 4;
            this.txtFinYear.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(468, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "FinYear:";
            // 
            // txtCost
            // 
            this.txtCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCost.ChangeColorIfNotEmpty = true;
            this.txtCost.ChangeColorOnEnter = true;
            this.txtCost.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCost.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCost.LabelToDisplay = null;
            this.txtCost.Location = new System.Drawing.Point(14, 116);
            this.txtCost.Name = "txtCost";
            this.txtCost.Negative = true;
            this.txtCost.NotEmpty = false;
            this.txtCost.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCost.SelectOnEnter = true;
            this.txtCost.Size = new System.Drawing.Size(132, 23);
            this.txtCost.TabIndex = 5;
            this.txtCost.TextMode = ClassLibrary.TextModes.Integer;
            this.txtCost.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "costBenefit:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbCompany);
            this.groupBox1.Controls.Add(this.chkOnlineShare);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtApproveDate);
            this.groupBox1.Controls.Add(this.txtCost);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtShareCount);
            this.groupBox1.Controls.Add(this.txtFinYear);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbCompany
            // 
            this.cmbCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompany.BackColor = System.Drawing.SystemColors.Info;
            this.cmbCompany.BaseCode = 0;
            this.cmbCompany.ChangeColorIfNotEmpty = true;
            this.cmbCompany.ChangeColorOnEnter = true;
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCompany.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCompany.Location = new System.Drawing.Point(14, 22);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.NotEmpty = false;
            this.cmbCompany.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCompany.SelectOnEnter = true;
            this.cmbCompany.Size = new System.Drawing.Size(419, 24);
            this.cmbCompany.TabIndex = 0;
            // 
            // chkOnlineShare
            // 
            this.chkOnlineShare.AutoSize = true;
            this.chkOnlineShare.Checked = true;
            this.chkOnlineShare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlineShare.Location = new System.Drawing.Point(151, 151);
            this.chkOnlineShare.Name = "chkOnlineShare";
            this.chkOnlineShare.Size = new System.Drawing.Size(100, 20);
            this.chkOnlineShare.TabIndex = 8;
            this.chkOnlineShare.Text = "OnLineShare";
            this.chkOnlineShare.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "ApproveDate:";
            // 
            // txtApproveDate
            // 
            this.txtApproveDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApproveDate.ChangeColorIfNotEmpty = true;
            this.txtApproveDate.ChangeColorOnEnter = true;
            this.txtApproveDate.Date = new System.DateTime(((long)(0)));
            this.txtApproveDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtApproveDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtApproveDate.InsertInDatesTable = true;
            this.txtApproveDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtApproveDate.Location = new System.Drawing.Point(14, 55);
            this.txtApproveDate.Mask = "0000/00/00";
            this.txtApproveDate.Name = "txtApproveDate";
            this.txtApproveDate.NotEmpty = false;
            this.txtApproveDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtApproveDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtApproveDate.Size = new System.Drawing.Size(132, 23);
            this.txtApproveDate.TabIndex = 2;
            this.txtApproveDate.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // txtShareCount
            // 
            this.txtShareCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShareCount.Location = new System.Drawing.Point(311, 148);
            this.txtShareCount.Name = "txtShareCount";
            this.txtShareCount.Size = new System.Drawing.Size(100, 23);
            this.txtShareCount.TabIndex = 6;
            this.txtShareCount.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Count Share:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnProperty);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 55);
            this.panel2.TabIndex = 1;
            // 
            // btnProperty
            // 
            this.btnProperty.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnProperty.Location = new System.Drawing.Point(100, 14);
            this.btnProperty.Name = "btnProperty";
            this.btnProperty.Size = new System.Drawing.Size(82, 32);
            this.btnProperty.TabIndex = 2;
            this.btnProperty.Text = "Edit";
            this.btnProperty.UseVisualStyleBackColor = true;
            this.btnProperty.Click += new System.EventHandler(this.btnProperty_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Company:";
            // 
            // JCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(535, 245);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JCourseForm";
            this.Text = "Course";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtFinYear;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.MoneyEdit txtCost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private ClassLibrary.DateEdit txtApproveDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtShareCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkOnlineShare;
        private ClassLibrary.JComboBox cmbCompany;
		private System.Windows.Forms.Button btnProperty;
        private System.Windows.Forms.Label label4;
    }
}