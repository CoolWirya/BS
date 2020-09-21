namespace Employment
{
    partial class JReportDetailForm
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
            this.label33 = new System.Windows.Forms.Label();
            this.cmbRangKaraneh = new ClassLibrary.JComboBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.jdgvResult = new ClassLibrary.JJanusGrid();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(533, 26);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(39, 16);
            this.label33.TabIndex = 92;
            this.label33.Text = "دوره :";
            // 
            // cmbRangKaraneh
            // 
            this.cmbRangKaraneh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRangKaraneh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbRangKaraneh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRangKaraneh.BackColor = System.Drawing.SystemColors.Info;
            this.cmbRangKaraneh.BaseCode = 0;
            this.cmbRangKaraneh.ChangeColorIfNotEmpty = true;
            this.cmbRangKaraneh.ChangeColorOnEnter = true;
            this.cmbRangKaraneh.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbRangKaraneh.FormattingEnabled = true;
            this.cmbRangKaraneh.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbRangKaraneh.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbRangKaraneh.Location = new System.Drawing.Point(275, 23);
            this.cmbRangKaraneh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbRangKaraneh.Name = "cmbRangKaraneh";
            this.cmbRangKaraneh.NotEmpty = false;
            this.cmbRangKaraneh.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbRangKaraneh.SelectOnEnter = true;
            this.cmbRangKaraneh.Size = new System.Drawing.Size(252, 24);
            this.cmbRangKaraneh.TabIndex = 91;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cmbRangKaraneh);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 62);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(193, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 93;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // jdgvResult
            // 
            this.jdgvResult.ActionMenu = null;
            this.jdgvResult.DataSource = null;
            this.jdgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvResult.Edited = false;
            this.jdgvResult.Location = new System.Drawing.Point(0, 62);
            this.jdgvResult.MultiSelect = true;
            this.jdgvResult.Name = "jdgvResult";
            this.jdgvResult.ShowNavigator = true;
            this.jdgvResult.ShowToolbar = true;
            this.jdgvResult.Size = new System.Drawing.Size(583, 389);
            this.jdgvResult.TabIndex = 94;
            // 
            // ReportDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 451);
            this.Controls.Add(this.jdgvResult);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReportDetailForm";
            this.Text = "ReportDetailForm";
            this.Load += new System.EventHandler(this.ReportDetailForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label33;
        private ClassLibrary.JComboBox cmbRangKaraneh;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JJanusGrid jdgvResult;
        private System.Windows.Forms.Button btnSearch;
    }
}