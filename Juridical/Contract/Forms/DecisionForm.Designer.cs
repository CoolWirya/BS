namespace Legal
{
    partial class JDecisionForm1
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
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumber = new ClassLibrary.TextEdit(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.jArchiveListDecision = new ArchivedDocuments.JArchiveList();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(8, 447);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "بعدی";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(439, 446);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(89, 447);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "قبلی";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNumber);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 84);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
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
            this.txtDate.Location = new System.Drawing.Point(49, 46);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(155, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 16);
            this.label11.TabIndex = 33;
            this.label11.Text = "تاریخ رای:";
            // 
            // txtNum
            // 
            this.txtNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNum.Location = new System.Drawing.Point(223, 46);
            this.txtNum.Name = "txtNum";
            this.txtNum.ReadOnly = true;
            this.txtNum.Size = new System.Drawing.Size(203, 23);
            this.txtNum.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "شماره دادنامه:";
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumber.ChangeColorIfNotEmpty = false;
            this.txtNumber.ChangeColorOnEnter = true;
            this.txtNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumber.Location = new System.Drawing.Point(291, 17);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Negative = true;
            this.txtNumber.NotEmpty = false;
            this.txtNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumber.ReadOnly = true;
            this.txtNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumber.SelectOnEnter = true;
            this.txtNumber.Size = new System.Drawing.Size(136, 23);
            this.txtNumber.TabIndex = 30;
            this.txtNumber.TextMode = ClassLibrary.TextModes.Text;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(248, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(37, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(430, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 16);
            this.label12.TabIndex = 28;
            this.label12.Text = "کد رای دادگاه:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(431, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "سایر توضیحات:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDesc);
            this.groupBox2.Controls.Add(this.jArchiveListDecision);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(526, 357);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "مشخصات حکم";
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(3, 218);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(520, 136);
            this.txtDesc.TabIndex = 5;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // jArchiveListDecision
            // 
            this.jArchiveListDecision.AllowUserAddFile = false;
            this.jArchiveListDecision.AllowUserAddFromArchive = false;
            this.jArchiveListDecision.AllowUserAddImage = false;
            this.jArchiveListDecision.AllowUserDeleteFile = false;
            this.jArchiveListDecision.ClassName = "";
            this.jArchiveListDecision.Dock = System.Windows.Forms.DockStyle.Top;
            this.jArchiveListDecision.Location = new System.Drawing.Point(3, 19);
            this.jArchiveListDecision.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jArchiveListDecision.Name = "jArchiveListDecision";
            this.jArchiveListDecision.ObjectCode = 0;
            this.jArchiveListDecision.PlaceCode = 0;
            this.jArchiveListDecision.Size = new System.Drawing.Size(520, 172);
            this.jArchiveListDecision.SubjectCode = 0;
            this.jArchiveListDecision.TabIndex = 4;
            // 
            // JDecisionForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 475);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JDecisionForm1";
            this.Text = "حکم دادگاه";
            this.Load += new System.EventHandler(this.JDecisionForm1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit txtNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label12;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private ArchivedDocuments.JArchiveList jArchiveListDecision;
        private ClassLibrary.TextEdit txtDesc;
    }
}