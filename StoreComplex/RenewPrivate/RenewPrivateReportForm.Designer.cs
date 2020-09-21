namespace StoreComplex
{
    partial class JRenewPrivateReportForm
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grdReport = new ClassLibrary.JJanusGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdRenewed = new ClassLibrary.JJanusGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditGoods = new System.Windows.Forms.Button();
            this.btnDelGoods = new System.Windows.Forms.Button();
            this.lbDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToDate = new ClassLibrary.DateEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFromDate = new ClassLibrary.DateEdit(this.components);
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdReport);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(775, 366);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "تمدید نشده ها";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grdReport
            // 
            this.grdReport.ActionMenu = null;
            this.grdReport.DataSource = null;
            this.grdReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReport.Edited = false;
            this.grdReport.Location = new System.Drawing.Point(3, 3);
            this.grdReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdReport.MultiSelect = true;
            this.grdReport.Name = "grdReport";
            this.grdReport.ShowNavigator = true;
            this.grdReport.ShowToolbar = false;
            this.grdReport.Size = new System.Drawing.Size(769, 325);
            this.grdReport.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRenew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 328);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 35);
            this.panel2.TabIndex = 9;
            // 
            // btnRenew
            // 
            this.btnRenew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenew.Location = new System.Drawing.Point(682, 3);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(75, 29);
            this.btnRenew.TabIndex = 0;
            this.btnRenew.Text = "تمدید...";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(330, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(35, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 56);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(783, 395);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(775, 366);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تمدید شده";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdRenewed);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(769, 360);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "اطلاعات تمدید";
            // 
            // grdRenewed
            // 
            this.grdRenewed.ActionMenu = null;
            this.grdRenewed.DataSource = null;
            this.grdRenewed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRenewed.Edited = false;
            this.grdRenewed.Location = new System.Drawing.Point(3, 19);
            this.grdRenewed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdRenewed.MultiSelect = true;
            this.grdRenewed.Name = "grdRenewed";
            this.grdRenewed.ShowNavigator = true;
            this.grdRenewed.ShowToolbar = false;
            this.grdRenewed.Size = new System.Drawing.Size(763, 303);
            this.grdRenewed.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEditGoods);
            this.panel1.Controls.Add(this.btnDelGoods);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 322);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 35);
            this.panel1.TabIndex = 4;
            // 
            // btnEditGoods
            // 
            this.btnEditGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditGoods.Location = new System.Drawing.Point(639, 3);
            this.btnEditGoods.Name = "btnEditGoods";
            this.btnEditGoods.Size = new System.Drawing.Size(57, 29);
            this.btnEditGoods.TabIndex = 2;
            this.btnEditGoods.Text = "ویرایش";
            this.btnEditGoods.UseVisualStyleBackColor = true;
            this.btnEditGoods.Visible = false;
            // 
            // btnDelGoods
            // 
            this.btnDelGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelGoods.Location = new System.Drawing.Point(702, 3);
            this.btnDelGoods.Name = "btnDelGoods";
            this.btnDelGoods.Size = new System.Drawing.Size(52, 29);
            this.btnDelGoods.TabIndex = 1;
            this.btnDelGoods.Text = "حذف";
            this.btnDelGoods.UseVisualStyleBackColor = true;
            this.btnDelGoods.Visible = false;
            // 
            // lbDate
            // 
            this.lbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDate.AutoSize = true;
            this.lbDate.ForeColor = System.Drawing.Color.Blue;
            this.lbDate.Location = new System.Drawing.Point(133, 21);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(73, 16);
            this.lbDate.TabIndex = 15;
            this.lbDate.Text = "تاریخ تمدید:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "تاریخ تمدید:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(471, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "تا تاریخ:";
            // 
            // txtToDate
            // 
            this.txtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToDate.ChangeColorIfNotEmpty = true;
            this.txtToDate.ChangeColorOnEnter = true;
            this.txtToDate.Date = new System.DateTime(((long)(0)));
            this.txtToDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtToDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtToDate.InsertInDatesTable = true;
            this.txtToDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtToDate.Location = new System.Drawing.Point(371, 18);
            this.txtToDate.Mask = "0000/00/00";
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.NotEmpty = false;
            this.txtToDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtToDate.Size = new System.Drawing.Size(100, 23);
            this.txtToDate.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(641, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "از تاریخ:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtToDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFromDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 56);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(700, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "تاریخ ورود:";
            // 
            // txtFromDate
            // 
            this.txtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromDate.ChangeColorIfNotEmpty = true;
            this.txtFromDate.ChangeColorOnEnter = true;
            this.txtFromDate.Date = new System.DateTime(((long)(0)));
            this.txtFromDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFromDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFromDate.InsertInDatesTable = true;
            this.txtFromDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFromDate.Location = new System.Drawing.Point(541, 18);
            this.txtFromDate.Mask = "0000/00/00";
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.NotEmpty = false;
            this.txtFromDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFromDate.Size = new System.Drawing.Size(100, 23);
            this.txtFromDate.TabIndex = 8;
            // 
            // JRenewPrivateReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 451);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "JRenewPrivateReportForm";
            this.Text = "اجاره های قابل تمدید";
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private ClassLibrary.JJanusGrid grdReport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.JJanusGrid grdRenewed;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEditGoods;
        private System.Windows.Forms.Button btnDelGoods;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.DateEdit txtToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.DateEdit txtFromDate;

    }
}