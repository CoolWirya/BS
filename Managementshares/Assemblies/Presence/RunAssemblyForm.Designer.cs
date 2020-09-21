namespace ManagementShares
{
    partial class JRunAssemblyForm
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
			this.imgListAgents = new System.Windows.Forms.ImageList(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lblVoteRightPercent = new System.Windows.Forms.Label();
			this.lblPersonName = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.cmbPresence = new System.Windows.Forms.ComboBox();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.chkShowAra = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Arm = new System.Windows.Forms.PictureBox();
			this.lbPercent = new System.Windows.Forms.Label();
			this.lbPresentCount = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lbRightCount = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Arm)).BeginInit();
			this.SuspendLayout();
			// 
			// imgListAgents
			// 
			this.imgListAgents.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imgListAgents.ImageSize = new System.Drawing.Size(160, 150);
			this.imgListAgents.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// timer1
			// 
			this.timer1.Interval = 10000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.chart1);
			this.panel1.Controls.Add(this.chkShowAra);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.Arm);
			this.panel1.Controls.Add(this.lbPercent);
			this.panel1.Controls.Add(this.lbRightCount);
			this.panel1.Controls.Add(this.lbPresentCount);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.lbTitle);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1020, 531);
			this.panel1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(933, 103);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 27);
			this.button1.TabIndex = 12;
			this.button1.Text = "بروزرسانی";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lblVoteRightPercent);
			this.panel3.Controls.Add(this.lblPersonName);
			this.panel3.Controls.Add(this.pictureBox1);
			this.panel3.Controls.Add(this.cmbPresence);
			this.panel3.Location = new System.Drawing.Point(594, 136);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(426, 395);
			this.panel3.TabIndex = 11;
			this.panel3.Visible = false;
			// 
			// lblVoteRightPercent
			// 
			this.lblVoteRightPercent.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblVoteRightPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.lblVoteRightPercent.ForeColor = System.Drawing.Color.DarkRed;
			this.lblVoteRightPercent.Location = new System.Drawing.Point(0, 310);
			this.lblVoteRightPercent.Name = "lblVoteRightPercent";
			this.lblVoteRightPercent.Size = new System.Drawing.Size(426, 33);
			this.lblVoteRightPercent.TabIndex = 13;
			this.lblVoteRightPercent.Text = "درصد حق رای";
			this.lblVoteRightPercent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblPersonName
			// 
			this.lblPersonName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.lblPersonName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblPersonName.Location = new System.Drawing.Point(0, 268);
			this.lblPersonName.Name = "lblPersonName";
			this.lblPersonName.Size = new System.Drawing.Size(426, 42);
			this.lblPersonName.TabIndex = 12;
			this.lblPersonName.Text = "نام سهامدار";
			this.lblPersonName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Location = new System.Drawing.Point(0, 24);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(426, 244);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 12;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			// 
			// cmbPresence
			// 
			this.cmbPresence.Dock = System.Windows.Forms.DockStyle.Top;
			this.cmbPresence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPresence.FormattingEnabled = true;
			this.cmbPresence.Location = new System.Drawing.Point(0, 0);
			this.cmbPresence.Name = "cmbPresence";
			this.cmbPresence.Size = new System.Drawing.Size(426, 24);
			this.cmbPresence.TabIndex = 0;
			this.cmbPresence.SelectedIndexChanged += new System.EventHandler(this.cmbPresence_SelectedIndexChanged);
			this.cmbPresence.SelectionChangeCommitted += new System.EventHandler(this.cmbPresence_SelectionChangeCommitted);
			// 
			// chart1
			// 
			chartArea1.Area3DStyle.Enable3D = true;
			chartArea1.Area3DStyle.Inclination = 60;
			chartArea1.Area3DStyle.PointDepth = 200;
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Font = new System.Drawing.Font("B Titr", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			legend1.IsTextAutoFit = false;
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(0, 187);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
			series1.Font = new System.Drawing.Font("B Titr", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(1020, 344);
			this.chart1.TabIndex = 10;
			this.chart1.Text = "chart1";
			title1.Font = new System.Drawing.Font("B Titr", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			title1.Name = "Title1";
			title1.Text = "درصد حضور اعضاء";
			this.chart1.Titles.Add(title1);
			this.chart1.Click += new System.EventHandler(this.chart1_Click);
			// 
			// chkShowAra
			// 
			this.chkShowAra.AutoSize = true;
			this.chkShowAra.Location = new System.Drawing.Point(3, 16);
			this.chkShowAra.Name = "chkShowAra";
			this.chkShowAra.Size = new System.Drawing.Size(15, 14);
			this.chkShowAra.TabIndex = 9;
			this.chkShowAra.UseVisualStyleBackColor = true;
			this.chkShowAra.CheckedChanged += new System.EventHandler(this.chkShowAra_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(194, 198);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(238, 39);
			this.label1.TabIndex = 8;
			this.label1.Text = "از 40000 سهم";
			// 
			// Arm
			// 
			this.Arm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Arm.Location = new System.Drawing.Point(715, 49);
			this.Arm.Name = "Arm";
			this.Arm.Size = new System.Drawing.Size(299, 24);
			this.Arm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Arm.TabIndex = 7;
			this.Arm.TabStop = false;
			this.Arm.Visible = false;
			// 
			// lbPercent
			// 
			this.lbPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbPercent.Font = new System.Drawing.Font("Tahoma", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.lbPercent.ForeColor = System.Drawing.Color.Red;
			this.lbPercent.Location = new System.Drawing.Point(279, 259);
			this.lbPercent.Name = "lbPercent";
			this.lbPercent.Size = new System.Drawing.Size(355, 167);
			this.lbPercent.TabIndex = 6;
			this.lbPercent.Text = "10";
			this.lbPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbPresentCount
			// 
			this.lbPresentCount.Font = new System.Drawing.Font("B Titr", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.lbPresentCount.ForeColor = System.Drawing.Color.DarkRed;
			this.lbPresentCount.Location = new System.Drawing.Point(12, 58);
			this.lbPresentCount.Name = "lbPresentCount";
			this.lbPresentCount.Size = new System.Drawing.Size(164, 66);
			this.lbPresentCount.TabIndex = 4;
			this.lbPresentCount.Text = "10";
			this.lbPresentCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label3.Location = new System.Drawing.Point(599, 198);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(325, 33);
			this.label3.TabIndex = 2;
			this.label3.Text = "مجموع تعداد حق رأی حاضر:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("B Titr", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label2.Location = new System.Drawing.Point(165, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(329, 62);
			this.label2.TabIndex = 1;
			this.label2.Text = "تعداد حاضرین در جلسه:";
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbTitle.Font = new System.Drawing.Font("B Titr", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.lbTitle.ForeColor = System.Drawing.Color.Blue;
			this.lbTitle.Location = new System.Drawing.Point(0, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(1020, 187);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "عنوان مجمع";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("B Titr", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label4.Location = new System.Drawing.Point(165, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(344, 62);
			this.label4.TabIndex = 1;
			this.label4.Text = "تعداد آرا حاضر در جلسه:";
			// 
			// lbRightCount
			// 
			this.lbRightCount.Font = new System.Drawing.Font("B Titr", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.lbRightCount.ForeColor = System.Drawing.Color.DarkRed;
			this.lbRightCount.Location = new System.Drawing.Point(12, 116);
			this.lbRightCount.Name = "lbRightCount";
			this.lbRightCount.Size = new System.Drawing.Size(164, 66);
			this.lbRightCount.TabIndex = 4;
			this.lbRightCount.Text = "10";
			this.lbRightCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// JRunAssemblyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1020, 531);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "JRunAssemblyForm";
			this.Text = "";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.JRunAssemblyForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JRunAssemblyForm_KeyDown);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Arm)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imgListAgents;
		private System.Windows.Forms.Label lbPercent;
        private System.Windows.Forms.Label lbPresentCount;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox Arm;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkShowAra;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lblVoteRightPercent;
		private System.Windows.Forms.Label lblPersonName;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ComboBox cmbPresence;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lbRightCount;
		private System.Windows.Forms.Label label4;
    }
}