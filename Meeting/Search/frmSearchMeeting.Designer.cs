namespace Meeting
{
    partial class JfrmSearchMeeting
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
            this.PersonCode = new ClassLibrary.JUCPerson();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLegislation = new ClassLibrary.TextEdit(this.components);
            this.label217 = new System.Windows.Forms.Label();
            this.cmbLegislationGroup = new ClassLibrary.JComboBox(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.cmbCommissionCode = new ClassLibrary.JComboBox(this.components);
            this.txtSubject = new ClassLibrary.TextEdit(this.components);
            this.txtDate2 = new ClassLibrary.DateEdit(this.components);
            this.label220 = new System.Windows.Forms.Label();
            this.txtLocation = new ClassLibrary.TextEdit(this.components);
            this.label218 = new System.Windows.Forms.Label();
            this.label212 = new System.Windows.Forms.Label();
            this.label209 = new System.Windows.Forms.Label();
            this.label211 = new System.Windows.Forms.Label();
            this.jdgvSearch = new ClassLibrary.JJanusGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PersonCode);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 234);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // PersonCode
            // 
            this.PersonCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.PersonCode.FilterPerson = null;
            this.PersonCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PersonCode.LableGroup = null;
            this.PersonCode.Location = new System.Drawing.Point(3, 241);
            this.PersonCode.Name = "PersonCode";
            this.PersonCode.PersonType = ClassLibrary.JPersonTypes.None;
            this.PersonCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PersonCode.SelectedCode = 0;
            this.PersonCode.Size = new System.Drawing.Size(782, 61);
            this.PersonCode.TabIndex = 126;
            this.PersonCode.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLegislation);
            this.groupBox3.Controls.Add(this.label217);
            this.groupBox3.Controls.Add(this.cmbLegislationGroup);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(782, 94);
            this.groupBox3.TabIndex = 124;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "مصوبه";
            this.groupBox3.Visible = false;
            // 
            // txtLegislation
            // 
            this.txtLegislation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLegislation.ChangeColorIfNotEmpty = true;
            this.txtLegislation.ChangeColorOnEnter = true;
            this.txtLegislation.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLegislation.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLegislation.Location = new System.Drawing.Point(175, 48);
            this.txtLegislation.Multiline = true;
            this.txtLegislation.Name = "txtLegislation";
            this.txtLegislation.Negative = true;
            this.txtLegislation.NotEmpty = false;
            this.txtLegislation.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLegislation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLegislation.SelectOnEnter = true;
            this.txtLegislation.Size = new System.Drawing.Size(507, 36);
            this.txtLegislation.TabIndex = 122;
            this.txtLegislation.Tag = "Like";
            this.txtLegislation.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label217
            // 
            this.label217.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label217.AutoSize = true;
            this.label217.Location = new System.Drawing.Point(697, 21);
            this.label217.Name = "label217";
            this.label217.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label217.Size = new System.Drawing.Size(47, 16);
            this.label217.TabIndex = 121;
            this.label217.Text = "مصوبه:";
            // 
            // cmbLegislationGroup
            // 
            this.cmbLegislationGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLegislationGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbLegislationGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLegislationGroup.BaseCode = 0;
            this.cmbLegislationGroup.ChangeColorIfNotEmpty = true;
            this.cmbLegislationGroup.ChangeColorOnEnter = true;
            this.cmbLegislationGroup.FormattingEnabled = true;
            this.cmbLegislationGroup.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbLegislationGroup.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLegislationGroup.Location = new System.Drawing.Point(346, 17);
            this.cmbLegislationGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbLegislationGroup.Name = "cmbLegislationGroup";
            this.cmbLegislationGroup.NotEmpty = false;
            this.cmbLegislationGroup.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbLegislationGroup.SelectOnEnter = true;
            this.cmbLegislationGroup.Size = new System.Drawing.Size(335, 24);
            this.cmbLegislationGroup.TabIndex = 120;
            this.cmbLegislationGroup.Tag = "=";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Controls.Add(this.cmbCommissionCode);
            this.groupBox2.Controls.Add(this.txtSubject);
            this.groupBox2.Controls.Add(this.txtDate2);
            this.groupBox2.Controls.Add(this.label220);
            this.groupBox2.Controls.Add(this.txtLocation);
            this.groupBox2.Controls.Add(this.label218);
            this.groupBox2.Controls.Add(this.label212);
            this.groupBox2.Controls.Add(this.label209);
            this.groupBox2.Controls.Add(this.label211);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(782, 128);
            this.groupBox2.TabIndex = 123;
            this.groupBox2.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(68, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 120;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.txtDate.Location = new System.Drawing.Point(343, 22);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 114;
            this.txtDate.Tag = ">=";
            // 
            // cmbCommissionCode
            // 
            this.cmbCommissionCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCommissionCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCommissionCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCommissionCode.BackColor = System.Drawing.SystemColors.Info;
            this.cmbCommissionCode.BaseCode = 0;
            this.cmbCommissionCode.ChangeColorIfNotEmpty = true;
            this.cmbCommissionCode.ChangeColorOnEnter = true;
            this.cmbCommissionCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCommissionCode.FormattingEnabled = true;
            this.cmbCommissionCode.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCommissionCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCommissionCode.Location = new System.Drawing.Point(502, 22);
            this.cmbCommissionCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCommissionCode.Name = "cmbCommissionCode";
            this.cmbCommissionCode.NotEmpty = false;
            this.cmbCommissionCode.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCommissionCode.SelectOnEnter = true;
            this.cmbCommissionCode.Size = new System.Drawing.Size(180, 24);
            this.cmbCommissionCode.TabIndex = 110;
            this.cmbCommissionCode.Tag = "=";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.ChangeColorIfNotEmpty = false;
            this.txtSubject.ChangeColorOnEnter = true;
            this.txtSubject.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSubject.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubject.Location = new System.Drawing.Point(208, 55);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Negative = true;
            this.txtSubject.NotEmpty = false;
            this.txtSubject.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSubject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubject.SelectOnEnter = true;
            this.txtSubject.Size = new System.Drawing.Size(474, 23);
            this.txtSubject.TabIndex = 115;
            this.txtSubject.Tag = "Like";
            this.txtSubject.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtDate2
            // 
            this.txtDate2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate2.ChangeColorIfNotEmpty = true;
            this.txtDate2.ChangeColorOnEnter = true;
            this.txtDate2.Date = new System.DateTime(((long)(0)));
            this.txtDate2.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate2.InsertInDatesTable = true;
            this.txtDate2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate2.Location = new System.Drawing.Point(197, 21);
            this.txtDate2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDate2.Mask = "0000/00/00";
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.NotEmpty = false;
            this.txtDate2.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDate2.Size = new System.Drawing.Size(83, 23);
            this.txtDate2.TabIndex = 116;
            this.txtDate2.Tag = "<=";
            // 
            // label220
            // 
            this.label220.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label220.AutoSize = true;
            this.label220.Location = new System.Drawing.Point(691, 90);
            this.label220.Name = "label220";
            this.label220.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label220.Size = new System.Drawing.Size(79, 16);
            this.label220.TabIndex = 119;
            this.label220.Text = "مکان جلسه:";
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.ChangeColorIfNotEmpty = false;
            this.txtLocation.ChangeColorOnEnter = true;
            this.txtLocation.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLocation.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLocation.Location = new System.Drawing.Point(208, 86);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Negative = true;
            this.txtLocation.NotEmpty = false;
            this.txtLocation.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLocation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLocation.SelectOnEnter = true;
            this.txtLocation.Size = new System.Drawing.Size(474, 23);
            this.txtLocation.TabIndex = 118;
            this.txtLocation.Tag = "Like";
            this.txtLocation.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label218
            // 
            this.label218.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label218.AutoSize = true;
            this.label218.Location = new System.Drawing.Point(287, 24);
            this.label218.Name = "label218";
            this.label218.Size = new System.Drawing.Size(51, 16);
            this.label218.TabIndex = 117;
            this.label218.Text = "تا تاریخ:";
            // 
            // label212
            // 
            this.label212.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label212.AutoSize = true;
            this.label212.Location = new System.Drawing.Point(688, 25);
            this.label212.Name = "label212";
            this.label212.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label212.Size = new System.Drawing.Size(66, 16);
            this.label212.TabIndex = 111;
            this.label212.Text = "کمیسیون:";
            // 
            // label209
            // 
            this.label209.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label209.AutoSize = true;
            this.label209.Location = new System.Drawing.Point(451, 26);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(43, 16);
            this.label209.TabIndex = 113;
            this.label209.Text = "تاریخ :";
            // 
            // label211
            // 
            this.label211.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label211.AutoSize = true;
            this.label211.Location = new System.Drawing.Point(702, 59);
            this.label211.Name = "label211";
            this.label211.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label211.Size = new System.Drawing.Size(50, 16);
            this.label211.TabIndex = 112;
            this.label211.Text = "موضوع:";
            // 
            // jdgvSearch
            // 
            this.jdgvSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvSearch.Location = new System.Drawing.Point(0, 234);
            this.jdgvSearch.MultiSelect = false;
            this.jdgvSearch.Name = "jdgvSearch";
            this.jdgvSearch.Size = new System.Drawing.Size(788, 408);
            this.jdgvSearch.TabIndex = 1;
            this.jdgvSearch.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.jdgvSearch_OnRowDBClick);
            // 
            // JfrmSearchMeeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 642);
            this.Controls.Add(this.jdgvSearch);
            this.Controls.Add(this.groupBox1);
            this.Name = "JfrmSearchMeeting";
            this.Text = "frmSearchMeeting";
            this.Load += new System.EventHandler(this.frmSearchMeeting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JJanusGrid jdgvSearch;
        private System.Windows.Forms.Label label220;
        private System.Windows.Forms.Label label218;
        private System.Windows.Forms.Label label209;
        private System.Windows.Forms.Label label211;
        private System.Windows.Forms.Label label212;
        private ClassLibrary.TextEdit txtLocation;
        private ClassLibrary.DateEdit txtDate2;
        private ClassLibrary.TextEdit txtSubject;
        private ClassLibrary.DateEdit txtDate;
        private ClassLibrary.JComboBox cmbCommissionCode;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.TextEdit txtLegislation;
        private System.Windows.Forms.Label label217;
        private ClassLibrary.JComboBox cmbLegislationGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearch;
        private ClassLibrary.JUCPerson PersonCode;
    }
}