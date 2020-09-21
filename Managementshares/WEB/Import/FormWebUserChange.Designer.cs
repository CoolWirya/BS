namespace ManagementShares
{
    partial class FormWebUserChange
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
            this.jJanusGridWeb = new ClassLibrary.JJanusGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.jJanusGridCompare = new ClassLibrary.JJanusGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.panelDown = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFrom = new ClassLibrary.TextEdit(this.components);
            this.txtTo = new ClassLibrary.TextEdit(this.components);
            this.btnNextPage = new System.Windows.Forms.Button();
            this.prePage = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // jJanusGridWeb
            // 
            this.jJanusGridWeb.ActionClassName = "";
            this.jJanusGridWeb.ActionMenu = null;
            this.jJanusGridWeb.DataSource = null;
            this.jJanusGridWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jJanusGridWeb.Edited = false;
            this.jJanusGridWeb.Location = new System.Drawing.Point(0, 0);
            this.jJanusGridWeb.MultiSelect = false;
            this.jJanusGridWeb.Name = "jJanusGridWeb";
            this.jJanusGridWeb.ShowNavigator = true;
            this.jJanusGridWeb.ShowToolbar = true;
            this.jJanusGridWeb.Size = new System.Drawing.Size(424, 506);
            this.jJanusGridWeb.TabIndex = 0;
            this.jJanusGridWeb.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.jJanusGridWeb_OnRowDBClick);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(424, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 506);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.jJanusGridCompare);
            this.panelLeft.Controls.Add(this.groupBox1);
            this.panelLeft.Controls.Add(this.panel1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelLeft.Location = new System.Drawing.Point(434, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(418, 506);
            this.panelLeft.TabIndex = 4;
            // 
            // jJanusGridCompare
            // 
            this.jJanusGridCompare.ActionClassName = "";
            this.jJanusGridCompare.ActionMenu = null;
            this.jJanusGridCompare.DataSource = null;
            this.jJanusGridCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jJanusGridCompare.Edited = true;
            this.jJanusGridCompare.Location = new System.Drawing.Point(0, 43);
            this.jJanusGridCompare.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jJanusGridCompare.MultiSelect = false;
            this.jJanusGridCompare.Name = "jJanusGridCompare";
            this.jJanusGridCompare.ShowNavigator = true;
            this.jJanusGridCompare.ShowToolbar = true;
            this.jJanusGridCompare.Size = new System.Drawing.Size(418, 425);
            this.jJanusGridCompare.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 43);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.Location = new System.Drawing.Point(27, 14);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(381, 21);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "نام و نام خانوادگی";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 468);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 38);
            this.panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(256, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(337, 6);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // panelDown
            // 
            this.panelDown.Controls.Add(this.prePage);
            this.panelDown.Controls.Add(this.btnNextPage);
            this.panelDown.Controls.Add(this.txtTo);
            this.panelDown.Controls.Add(this.txtFrom);
            this.panelDown.Controls.Add(this.label2);
            this.panelDown.Controls.Add(this.label1);
            this.panelDown.Controls.Add(this.btnRefresh);
            this.panelDown.Controls.Add(this.btnClose);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDown.Location = new System.Drawing.Point(0, 506);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(852, 47);
            this.panelDown.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(418, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(115, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(733, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "از سطر:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(633, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "تا سطر:";
            // 
            // txtFrom
            // 
            this.txtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrom.ChangeColorIfNotEmpty = false;
            this.txtFrom.ChangeColorOnEnter = true;
            this.txtFrom.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFrom.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFrom.Location = new System.Drawing.Point(698, 16);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Negative = true;
            this.txtFrom.NotEmpty = false;
            this.txtFrom.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFrom.SelectOnEnter = true;
            this.txtFrom.Size = new System.Drawing.Size(29, 23);
            this.txtFrom.TabIndex = 3;
            this.txtFrom.Text = "1";
            this.txtFrom.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtTo
            // 
            this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTo.ChangeColorIfNotEmpty = false;
            this.txtTo.ChangeColorOnEnter = true;
            this.txtTo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTo.Location = new System.Drawing.Point(598, 16);
            this.txtTo.Name = "txtTo";
            this.txtTo.Negative = true;
            this.txtTo.NotEmpty = false;
            this.txtTo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTo.SelectOnEnter = true;
            this.txtTo.Size = new System.Drawing.Size(29, 23);
            this.txtTo.TabIndex = 4;
            this.txtTo.Text = "30";
            this.txtTo.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(554, 16);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(38, 23);
            this.btnNextPage.TabIndex = 5;
            this.btnNextPage.Text = ">>";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // prePage
            // 
            this.prePage.Location = new System.Drawing.Point(791, 16);
            this.prePage.Name = "prePage";
            this.prePage.Size = new System.Drawing.Size(38, 23);
            this.prePage.TabIndex = 6;
            this.prePage.Text = "<<";
            this.prePage.UseVisualStyleBackColor = true;
            this.prePage.Click += new System.EventHandler(this.prePage_Click);
            // 
            // FormWebUserChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 553);
            this.Controls.Add(this.jJanusGridWeb);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelDown);
            this.Name = "FormWebUserChange";
            this.Text = "FormWebUserChange";
            this.Load += new System.EventHandler(this.FormWebUserChange_Load);
            this.panelLeft.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelDown.ResumeLayout(false);
            this.panelDown.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JJanusGrid jJanusGridWeb;
        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private ClassLibrary.JJanusGrid jJanusGridCompare;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbName;
        private ClassLibrary.TextEdit txtFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtTo;
        private System.Windows.Forms.Button prePage;
        private System.Windows.Forms.Button btnNextPage;

    }
}