namespace Employment
{
    partial class JEfrmOrganizatinChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JEfrmOrganizatinChart));
            this.Menu_TreeNodes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtvOrganizatinChart = new ClassLibrary.JDataTreeView();
            this.Menu_TreeNodes.SuspendLayout();
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
            // Menu_TreeNodes
            // 
            this.Menu_TreeNodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.moveToolStripMenuItem});
            this.Menu_TreeNodes.Name = "contextMenuStrip1";
            this.Menu_TreeNodes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu_TreeNodes.Size = new System.Drawing.Size(153, 114);
            this.Menu_TreeNodes.Opening += new System.ComponentModel.CancelEventHandler(this.Menu_TreeNodes_Opening);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "Edit...";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete...";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // dtvOrganizatinChart
            // 
            this.dtvOrganizatinChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtvOrganizatinChart.Location = new System.Drawing.Point(5, 3);
            this.dtvOrganizatinChart.Name = "dtvOrganizatinChart";
            this.dtvOrganizatinChart.Size = new System.Drawing.Size(589, 504);
            this.dtvOrganizatinChart.TabIndex = 6;
            this.dtvOrganizatinChart.SelectedNodWithMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.dtvOrganizatinChart_SelectedNodWithMouseDoubleClick);
            // 
            // JEfrmOrganizatinChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(594, 515);
            this.Controls.Add(this.dtvOrganizatinChart);
            this.Name = "JEfrmOrganizatinChart";
            this.Text = "چارت سازمانی";
            this.Load += new System.EventHandler(this.JfrmOrganizatinChart_Load);
            this.Menu_TreeNodes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip Menu_TreeNodes;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private ClassLibrary.JDataTreeView dtvOrganizatinChart;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
    }
}
