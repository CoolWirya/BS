namespace ShareProfit
{
	partial class ShareProfitReportForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCourse = new ClassLibrary.JComboBox(this.components);
            this.cmbCompany = new ClassLibrary.JComboBox(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdReport = new ClassLibrary.JJanusGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbCourse);
            this.groupBox1.Controls.Add(this.cmbCompany);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجو";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Course:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(491, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Company:";
            // 
            // cmbCourse
            // 
            this.cmbCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCourse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCourse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCourse.BackColor = System.Drawing.SystemColors.Info;
            this.cmbCourse.BaseCode = 0;
            this.cmbCourse.ChangeColorIfNotEmpty = true;
            this.cmbCourse.ChangeColorOnEnter = true;
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCourse.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCourse.Location = new System.Drawing.Point(134, 57);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.NotEmpty = false;
            this.cmbCourse.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCourse.SelectOnEnter = true;
            this.cmbCourse.Size = new System.Drawing.Size(333, 24);
            this.cmbCourse.TabIndex = 16;
            this.cmbCourse.SelectedIndexChanged += new System.EventHandler(this.cmbCourse_SelectedIndexChanged);
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
            this.cmbCompany.Location = new System.Drawing.Point(134, 22);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.NotEmpty = false;
            this.cmbCompany.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCompany.SelectOnEnter = true;
            this.cmbCompany.Size = new System.Drawing.Size(333, 24);
            this.cmbCompany.TabIndex = 16;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 33);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdReport);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 351);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "نتایج";
            // 
            // grdReport
            // 
            this.grdReport.ActionClassName = "";
            this.grdReport.ActionMenu = null;
            this.grdReport.DataSource = null;
            this.grdReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReport.Edited = false;
            this.grdReport.Location = new System.Drawing.Point(3, 19);
            this.grdReport.MultiSelect = true;
            this.grdReport.Name = "grdReport";
            this.grdReport.ShowNavigator = true;
            this.grdReport.ShowToolbar = true;
            this.grdReport.Size = new System.Drawing.Size(568, 329);
            this.grdReport.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "چاپ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShareProfitReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 451);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ShareProfitReportForm";
            this.Text = "ShareProfitReportForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.GroupBox groupBox2;
		private ClassLibrary.JJanusGrid grdReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.JComboBox cmbCourse;
        private ClassLibrary.JComboBox cmbCompany;
        private System.Windows.Forms.Button button1;
    }
}