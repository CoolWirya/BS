namespace Estates
{
    partial class ReportSheetForm
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtEDate = new ClassLibrary.DateEdit(this.components);
            this.txtSDate = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.jdgvSearch = new ClassLibrary.JJanusGrid();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtEDate);
            this.groupBox1.Controls.Add(this.txtSDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(124, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 26);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtEDate
            // 
            this.txtEDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEDate.ChangeColorIfNotEmpty = true;
            this.txtEDate.ChangeColorOnEnter = true;
            this.txtEDate.Date = new System.DateTime(((long)(0)));
            this.txtEDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEDate.InsertInDatesTable = true;
            this.txtEDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEDate.Location = new System.Drawing.Point(238, 23);
            this.txtEDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEDate.Mask = "0000/00/00";
            this.txtEDate.Name = "txtEDate";
            this.txtEDate.NotEmpty = false;
            this.txtEDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEDate.Size = new System.Drawing.Size(97, 23);
            this.txtEDate.TabIndex = 7;
            // 
            // txtSDate
            // 
            this.txtSDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSDate.ChangeColorIfNotEmpty = true;
            this.txtSDate.ChangeColorOnEnter = true;
            this.txtSDate.Date = new System.DateTime(((long)(0)));
            this.txtSDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSDate.InsertInDatesTable = true;
            this.txtSDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtSDate.Location = new System.Drawing.Point(393, 23);
            this.txtSDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSDate.Mask = "0000/00/00";
            this.txtSDate.Name = "txtSDate";
            this.txtSDate.NotEmpty = false;
            this.txtSDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSDate.Size = new System.Drawing.Size(97, 23);
            this.txtSDate.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "تا تاریخ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(493, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "از تاریخ قرارداد";
            // 
            // jdgvSearch
            // 
            this.jdgvSearch.ActionClassName = "";
            this.jdgvSearch.ActionMenu = null;
            this.jdgvSearch.DataSource = null;
            this.jdgvSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvSearch.Edited = false;
            this.jdgvSearch.Location = new System.Drawing.Point(0, 68);
            this.jdgvSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jdgvSearch.MultiSelect = false;
            this.jdgvSearch.Name = "jdgvSearch";
            this.jdgvSearch.ShowNavigator = true;
            this.jdgvSearch.ShowToolbar = true;
            this.jdgvSearch.Size = new System.Drawing.Size(583, 383);
            this.jdgvSearch.TabIndex = 7;
            // 
            // ReportSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 451);
            this.Controls.Add(this.jdgvSearch);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReportSheetForm";
            this.Text = "ReportSheetForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.DateEdit txtEDate;
        private ClassLibrary.DateEdit txtSDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JJanusGrid jdgvSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}