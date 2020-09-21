namespace ShareProfit
{
    partial class JGridPrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JGridPrintForm));
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdReport = new ClassLibrary.JDataGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lbSumCostAllPayed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbSumCredit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbSumCostPayed = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSumSahmPayed = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnCodes = new System.Windows.Forms.Button();
            this.btnTransferDetails = new System.Windows.Forms.Button();
            this.txtDate = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReport)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "aktion.png");
            this.imageList.Images.SetKeyName(1, "alert.png");
            this.imageList.Images.SetKeyName(2, "All software is current.png");
            this.imageList.Images.SetKeyName(3, "amor.png");
            this.imageList.Images.SetKeyName(4, "antivirus.png");
            this.imageList.Images.SetKeyName(5, "applixware.png");
            this.imageList.Images.SetKeyName(6, "ark.png");
            this.imageList.Images.SetKeyName(7, "arts.png");
            this.imageList.Images.SetKeyName(8, "printer32.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDate);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 49);
            this.panel1.TabIndex = 3;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(585, 10);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(263, 23);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Text = "مصوبه مجمع عمومی مورخه ";
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(874, 13);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(38, 16);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Title:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.grdReport);
            this.groupBox1.Location = new System.Drawing.Point(0, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(943, 357);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // grdReport
            // 
            this.grdReport.ActionMenu = jPopupMenu2;
            this.grdReport.AllowUserToAddRows = false;
            this.grdReport.AllowUserToDeleteRows = false;
            this.grdReport.AllowUserToOrderColumns = true;
            this.grdReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReport.EnableContexMenu = true;
            this.grdReport.KeyName = "GridPrintShare";
            this.grdReport.Location = new System.Drawing.Point(3, 19);
            this.grdReport.Name = "grdReport";
            this.grdReport.ReadHeadersFromDB = false;
            this.grdReport.ReadOnly = true;
            this.grdReport.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdReport.ShowRowNumber = true;
            this.grdReport.Size = new System.Drawing.Size(937, 335);
            this.grdReport.TabIndex = 0;
            this.grdReport.TableName = null;
            this.grdReport.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdReport_CellMouseClick);
            this.grdReport.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdReport_CellDoubleClick);
            this.grdReport.SelectionChanged += new System.EventHandler(this.grdReport_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExcel);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.lbSumCostAllPayed);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 484);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(943, 51);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(135, 12);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(127, 37);
            this.btnExcel.TabIndex = 45;
            this.btnExcel.Text = "ExportToExcel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.ImageIndex = 8;
            this.btnPrint.ImageList = this.imageList;
            this.btnPrint.Location = new System.Drawing.Point(16, 12);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(113, 37);
            this.btnPrint.TabIndex = 44;
            this.btnPrint.Text = "PrintForm";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lbSumCostAllPayed
            // 
            this.lbSumCostAllPayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSumCostAllPayed.AutoSize = true;
            this.lbSumCostAllPayed.Location = new System.Drawing.Point(579, 16);
            this.lbSumCostAllPayed.Name = "lbSumCostAllPayed";
            this.lbSumCostAllPayed.Size = new System.Drawing.Size(15, 16);
            this.lbSumCostAllPayed.TabIndex = 7;
            this.lbSumCostAllPayed.Text = "0";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(795, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "SumCostAllPay";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbSumCredit);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lbSumCostPayed);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 442);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(943, 42);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Payed";
            // 
            // lbSumCredit
            // 
            this.lbSumCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSumCredit.AutoSize = true;
            this.lbSumCredit.Location = new System.Drawing.Point(196, 19);
            this.lbSumCredit.Name = "lbSumCredit";
            this.lbSumCredit.Size = new System.Drawing.Size(15, 16);
            this.lbSumCredit.TabIndex = 5;
            this.lbSumCredit.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "SumCredit:";
            // 
            // lbSumCostPayed
            // 
            this.lbSumCostPayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSumCostPayed.AutoSize = true;
            this.lbSumCostPayed.Location = new System.Drawing.Point(579, 19);
            this.lbSumCostPayed.Name = "lbSumCostPayed";
            this.lbSumCostPayed.Size = new System.Drawing.Size(15, 16);
            this.lbSumCostPayed.TabIndex = 3;
            this.lbSumCostPayed.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(795, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "SumCostPayed";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "SumShareCount";
            // 
            // lbSumSahmPayed
            // 
            this.lbSumSahmPayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSumSahmPayed.AutoSize = true;
            this.lbSumSahmPayed.Location = new System.Drawing.Point(347, 423);
            this.lbSumSahmPayed.Name = "lbSumSahmPayed";
            this.lbSumSahmPayed.Size = new System.Drawing.Size(15, 16);
            this.lbSumSahmPayed.TabIndex = 1;
            this.lbSumSahmPayed.Text = "0";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.xls";
            this.saveFileDialog1.Filter = "Microsoft Excel 2003 Files|*.xls";
            // 
            // btnDetails
            // 
            this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetails.Location = new System.Drawing.Point(814, 418);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(113, 26);
            this.btnDetails.TabIndex = 8;
            this.btnDetails.Text = "جزئیات پرداخت...";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnCodes
            // 
            this.btnCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCodes.Location = new System.Drawing.Point(570, 418);
            this.btnCodes.Name = "btnCodes";
            this.btnCodes.Size = new System.Drawing.Size(102, 26);
            this.btnCodes.TabIndex = 9;
            this.btnCodes.Text = "کد اشخاص...";
            this.btnCodes.UseVisualStyleBackColor = true;
            this.btnCodes.Click += new System.EventHandler(this.btnCodes_Click);
            // 
            // btnTransferDetails
            // 
            this.btnTransferDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransferDetails.Location = new System.Drawing.Point(693, 418);
            this.btnTransferDetails.Name = "btnTransferDetails";
            this.btnTransferDetails.Size = new System.Drawing.Size(102, 26);
            this.btnTransferDetails.TabIndex = 10;
            this.btnTransferDetails.Text = "جزئیات انتقال...";
            this.btnTransferDetails.UseVisualStyleBackColor = true;
            this.btnTransferDetails.Click += new System.EventHandler(this.btnTransferDetails_Click);
            // 
            // txtDate
            // 
            this.txtDate.ChangeColorIfNotEmpty = false;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.Location = new System.Drawing.Point(55, 12);
            this.txtDate.Name = "txtDate";
            this.txtDate.Negative = true;
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.ReadOnly = true;
            this.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDate.SelectOnEnter = true;
            this.txtDate.Size = new System.Drawing.Size(251, 23);
            this.txtDate.TabIndex = 2;
            this.txtDate.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "تاریخ:";
            // 
            // JGridPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 535);
            this.Controls.Add(this.btnTransferDetails);
            this.Controls.Add(this.btnCodes);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbSumSahmPayed);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JGridPrintForm";
            this.Text = "PrintForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReport)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbSumSahmPayed;
        public System.Windows.Forms.Label lbSumCostPayed;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lbSumCostAllPayed;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.Label lbSumCredit;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnCodes;
        private ClassLibrary.JDataGrid grdReport;
        private System.Windows.Forms.Button btnTransferDetails;
        private ClassLibrary.TextEdit txtDate;
        private System.Windows.Forms.Label label2;

    }
}