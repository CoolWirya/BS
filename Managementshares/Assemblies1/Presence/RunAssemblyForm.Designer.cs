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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("حاضرین", System.Windows.Forms.HorizontalAlignment.Right);
			this.imgListAgents = new System.Windows.Forms.ImageList(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbPercent = new System.Windows.Forms.Label();
			this.lbRightCount = new System.Windows.Forms.Label();
			this.lbPresentCount = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lstPresents = new System.Windows.Forms.ListView();
			this.lvcolName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvcolHandle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// imgListAgents
			// 
			this.imgListAgents.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imgListAgents.ImageSize = new System.Drawing.Size(55, 70);
			this.imgListAgents.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 502);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(767, 29);
			this.panel2.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.panel1.Controls.Add(this.lbPercent);
			this.panel1.Controls.Add(this.lbRightCount);
			this.panel1.Controls.Add(this.lbPresentCount);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.lbTitle);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(767, 122);
			this.panel1.TabIndex = 0;
			// 
			// lbPercent
			// 
			this.lbPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.lbPercent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbPercent.Location = new System.Drawing.Point(532, 90);
			this.lbPercent.Name = "lbPercent";
			this.lbPercent.Size = new System.Drawing.Size(69, 26);
			this.lbPercent.TabIndex = 6;
			this.lbPercent.Text = "10";
			this.lbPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbRightCount
			// 
			this.lbRightCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbRightCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.lbRightCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbRightCount.Location = new System.Drawing.Point(532, 62);
			this.lbRightCount.Name = "lbRightCount";
			this.lbRightCount.Size = new System.Drawing.Size(69, 26);
			this.lbRightCount.TabIndex = 5;
			this.lbRightCount.Text = "2000";
			this.lbRightCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbPresentCount
			// 
			this.lbPresentCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbPresentCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.lbPresentCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbPresentCount.Location = new System.Drawing.Point(532, 34);
			this.lbPresentCount.Name = "lbPresentCount";
			this.lbPresentCount.Size = new System.Drawing.Size(69, 26);
			this.lbPresentCount.TabIndex = 4;
			this.lbPresentCount.Text = "10";
			this.lbPresentCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label4.Location = new System.Drawing.Point(602, 94);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 20);
			this.label4.TabIndex = 3;
			this.label4.Text = "درصد آرای حاضر:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label3.Location = new System.Drawing.Point(602, 66);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(184, 20);
			this.label3.TabIndex = 2;
			this.label3.Text = "مجموع تعداد حق رأی حاضر:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label2.Location = new System.Drawing.Point(602, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "تعداد حاضرین:";
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.lbTitle.ForeColor = System.Drawing.Color.Blue;
			this.lbTitle.Location = new System.Drawing.Point(0, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(767, 33);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "عنوان مجمع";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timer1
			// 
			this.timer1.Interval = 20000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 122);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(767, 6);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lstPresents);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 128);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(767, 374);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// lstPresents
			// 
			this.lstPresents.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lstPresents.Alignment = System.Windows.Forms.ListViewAlignment.Default;
			this.lstPresents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvcolName,
            this.lvcolHandle});
			this.lstPresents.Dock = System.Windows.Forms.DockStyle.Fill;
			listViewGroup1.Header = "حاضرین";
			listViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Right;
			listViewGroup1.Name = "listGrpPresents";
			this.lstPresents.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
			this.lstPresents.LargeImageList = this.imgListAgents;
			this.lstPresents.Location = new System.Drawing.Point(3, 19);
			this.lstPresents.Margin = new System.Windows.Forms.Padding(2);
			this.lstPresents.Name = "lstPresents";
			this.lstPresents.Size = new System.Drawing.Size(761, 352);
			this.lstPresents.TabIndex = 1;
			this.lstPresents.TileSize = new System.Drawing.Size(260, 60);
			this.lstPresents.UseCompatibleStateImageBehavior = false;
			this.lstPresents.View = System.Windows.Forms.View.Tile;
			this.lstPresents.Visible = false;
			// 
			// lvcolHandle
			// 
			this.lvcolHandle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// JRunAssemblyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(767, 531);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "JRunAssemblyForm";
			this.Text = "";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imgListAgents;
        private System.Windows.Forms.Label lbPercent;
        private System.Windows.Forms.Label lbRightCount;
        private System.Windows.Forms.Label lbPresentCount;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ListView lstPresents;
        internal System.Windows.Forms.ColumnHeader lvcolName;
        internal System.Windows.Forms.ColumnHeader lvcolHandle;
    }
}