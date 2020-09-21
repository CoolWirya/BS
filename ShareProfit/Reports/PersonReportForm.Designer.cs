namespace ShareProfit
{
    partial class JSPersonReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JSPersonReportForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtToCode = new ClassLibrary.NumEdit();
            this.txtFromCode = new ClassLibrary.NumEdit();
            this.rbSearchOnInfo = new System.Windows.Forms.RadioButton();
            this.rbSearchOnCode = new System.Windows.Forms.RadioButton();
            this.btnSearchPerson = new System.Windows.Forms.Button();
            this.chGroup = new System.Windows.Forms.CheckBox();
            this.chAllDosc = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chAllCourses = new System.Windows.Forms.CheckBox();
            this.chListDocs = new System.Windows.Forms.CheckedListBox();
            this.chListCourses = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtManagementsharesHolderNo = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnSearchPerson);
            this.groupBox1.Controls.Add(this.chGroup);
            this.groupBox1.Controls.Add(this.chAllDosc);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.chAllCourses);
            this.groupBox1.Controls.Add(this.chListDocs);
            this.groupBox1.Controls.Add(this.chListCourses);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtManagementsharesHolderNo);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(828, 375);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtToCode);
            this.groupBox2.Controls.Add(this.txtFromCode);
            this.groupBox2.Controls.Add(this.rbSearchOnInfo);
            this.groupBox2.Controls.Add(this.rbSearchOnCode);
            this.groupBox2.Location = new System.Drawing.Point(12, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(125, 51);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            this.groupBox2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "ToCode";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "FromCode";
            this.label1.Visible = false;
            // 
            // txtToCode
            // 
            this.txtToCode.ChangeColorIfNotEmpty = true;
            this.txtToCode.ChangeColorOnEnter = true;
            this.txtToCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtToCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtToCode.Location = new System.Drawing.Point(37, 25);
            this.txtToCode.Name = "txtToCode";
            this.txtToCode.Negative = true;
            this.txtToCode.NotEmpty = false;
            this.txtToCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtToCode.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtToCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtToCode.SelectOnEnter = true;
            this.txtToCode.Size = new System.Drawing.Size(100, 23);
            this.txtToCode.TabIndex = 25;
            this.txtToCode.TextMode = ClassLibrary.TextModes.Text;
            this.txtToCode.Visible = false;
            // 
            // txtFromCode
            // 
            this.txtFromCode.ChangeColorIfNotEmpty = true;
            this.txtFromCode.ChangeColorOnEnter = true;
            this.txtFromCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFromCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFromCode.Location = new System.Drawing.Point(29, 52);
            this.txtFromCode.Name = "txtFromCode";
            this.txtFromCode.Negative = true;
            this.txtFromCode.NotEmpty = false;
            this.txtFromCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFromCode.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtFromCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFromCode.SelectOnEnter = true;
            this.txtFromCode.Size = new System.Drawing.Size(100, 23);
            this.txtFromCode.TabIndex = 26;
            this.txtFromCode.TextMode = ClassLibrary.TextModes.Text;
            this.txtFromCode.Visible = false;
            // 
            // rbSearchOnInfo
            // 
            this.rbSearchOnInfo.AutoSize = true;
            this.rbSearchOnInfo.Checked = true;
            this.rbSearchOnInfo.Location = new System.Drawing.Point(51, 101);
            this.rbSearchOnInfo.Name = "rbSearchOnInfo";
            this.rbSearchOnInfo.Size = new System.Drawing.Size(111, 20);
            this.rbSearchOnInfo.TabIndex = 1;
            this.rbSearchOnInfo.TabStop = true;
            this.rbSearchOnInfo.Text = "SearchOnPInfo";
            this.rbSearchOnInfo.UseVisualStyleBackColor = true;
            this.rbSearchOnInfo.Visible = false;
            this.rbSearchOnInfo.CheckedChanged += new System.EventHandler(this.rbSearchOnCode_CheckedChanged);
            // 
            // rbSearchOnCode
            // 
            this.rbSearchOnCode.AutoSize = true;
            this.rbSearchOnCode.Location = new System.Drawing.Point(37, 75);
            this.rbSearchOnCode.Name = "rbSearchOnCode";
            this.rbSearchOnCode.Size = new System.Drawing.Size(111, 20);
            this.rbSearchOnCode.TabIndex = 0;
            this.rbSearchOnCode.Text = "SearchOnCode";
            this.rbSearchOnCode.UseVisualStyleBackColor = true;
            this.rbSearchOnCode.Visible = false;
            this.rbSearchOnCode.CheckedChanged += new System.EventHandler(this.rbSearchOnCode_CheckedChanged);
            // 
            // btnSearchPerson
            // 
            this.btnSearchPerson.Location = new System.Drawing.Point(379, 12);
            this.btnSearchPerson.Name = "btnSearchPerson";
            this.btnSearchPerson.Size = new System.Drawing.Size(23, 23);
            this.btnSearchPerson.TabIndex = 1;
            this.btnSearchPerson.UseVisualStyleBackColor = true;
            this.btnSearchPerson.Click += new System.EventHandler(this.btnSearchPerson_Click);
            // 
            // chGroup
            // 
            this.chGroup.AutoSize = true;
            this.chGroup.Enabled = false;
            this.chGroup.Location = new System.Drawing.Point(582, 231);
            this.chGroup.Name = "chGroup";
            this.chGroup.Size = new System.Drawing.Size(101, 20);
            this.chGroup.TabIndex = 10;
            this.chGroup.Text = "GroupbyDocs";
            this.chGroup.UseVisualStyleBackColor = true;
            this.chGroup.Visible = false;
            this.chGroup.CheckedChanged += new System.EventHandler(this.chGroup_CheckedChanged);
            // 
            // chAllDosc
            // 
            this.chAllDosc.AutoSize = true;
            this.chAllDosc.Checked = true;
            this.chAllDosc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chAllDosc.Location = new System.Drawing.Point(733, 231);
            this.chAllDosc.Name = "chAllDosc";
            this.chAllDosc.Size = new System.Drawing.Size(68, 20);
            this.chAllDosc.TabIndex = 9;
            this.chAllDosc.Text = "AllDocs";
            this.chAllDosc.UseVisualStyleBackColor = true;
            this.chAllDosc.CheckedChanged += new System.EventHandler(this.chAllDosc_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(29, 332);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 32);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chAllCourses
            // 
            this.chAllCourses.AutoSize = true;
            this.chAllCourses.Checked = true;
            this.chAllCourses.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chAllCourses.Location = new System.Drawing.Point(714, 94);
            this.chAllCourses.Name = "chAllCourses";
            this.chAllCourses.Size = new System.Drawing.Size(87, 20);
            this.chAllCourses.TabIndex = 7;
            this.chAllCourses.Text = "AllCourses";
            this.chAllCourses.UseVisualStyleBackColor = true;
            this.chAllCourses.CheckedChanged += new System.EventHandler(this.chAllCourses_CheckedChanged);
            // 
            // chListDocs
            // 
            this.chListDocs.CheckOnClick = true;
            this.chListDocs.Enabled = false;
            this.chListDocs.FormattingEnabled = true;
            this.chListDocs.HorizontalScrollbar = true;
            this.chListDocs.Location = new System.Drawing.Point(166, 257);
            this.chListDocs.Name = "chListDocs";
            this.chListDocs.Size = new System.Drawing.Size(635, 94);
            this.chListDocs.TabIndex = 11;
            // 
            // chListCourses
            // 
            this.chListCourses.CheckOnClick = true;
            this.chListCourses.Enabled = false;
            this.chListCourses.FormattingEnabled = true;
            this.chListCourses.Location = new System.Drawing.Point(166, 120);
            this.chListCourses.Name = "chListCourses";
            this.chListCourses.Size = new System.Drawing.Size(635, 94);
            this.chListCourses.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(581, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "ManagementsharesHolderCode";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(703, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "LastName";
            // 
            // txtManagementsharesHolderNo
            // 
            this.txtManagementsharesHolderNo.Location = new System.Drawing.Point(525, 41);
            this.txtManagementsharesHolderNo.Name = "txtManagementsharesHolderNo";
            this.txtManagementsharesHolderNo.Size = new System.Drawing.Size(100, 23);
            this.txtManagementsharesHolderNo.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(408, 12);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(217, 23);
            this.txtLastName.TabIndex = 0;
            // 
            // JSPersonReportForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 387);
            this.Controls.Add(this.groupBox1);
            this.Name = "JSPersonReportForm";
            this.Text = "PaymentReport";
            this.Load += new System.EventHandler(this.JSPersonReportForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSearchOnInfo;
        private System.Windows.Forms.RadioButton rbSearchOnCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtManagementsharesHolderNo;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.NumEdit txtToCode;
        private ClassLibrary.NumEdit txtFromCode;
        private System.Windows.Forms.CheckBox chAllDosc;
        private System.Windows.Forms.CheckBox chAllCourses;
        private System.Windows.Forms.CheckedListBox chListDocs;
        private System.Windows.Forms.CheckedListBox chListCourses;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chGroup;
        private System.Windows.Forms.Button btnSearchPerson;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}