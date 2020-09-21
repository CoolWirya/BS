namespace Employment
{
    partial class JfrmDefineChart
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddChart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteChart = new System.Windows.Forms.ToolStripMenuItem();
            this.dtvOrganizatinChart = new ClassLibrary.JDataTreeView();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddChart,
            this.tsmDeleteChart});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 48);
            // 
            // tsmAddChart
            // 
            this.tsmAddChart.Name = "tsmAddChart";
            this.tsmAddChart.Size = new System.Drawing.Size(101, 22);
            this.tsmAddChart.Text = "اضافه";
            this.tsmAddChart.Click += new System.EventHandler(this.tsmAddChart_Click);
            // 
            // tsmDeleteChart
            // 
            this.tsmDeleteChart.Name = "tsmDeleteChart";
            this.tsmDeleteChart.Size = new System.Drawing.Size(101, 22);
            this.tsmDeleteChart.Text = "حذف";
            this.tsmDeleteChart.Click += new System.EventHandler(this.tsmDeleteChart_Click);
            // 
            // dtvOrganizatinChart
            // 
            this.dtvOrganizatinChart.ContextMenuStrip = this.contextMenuStrip1;
            this.dtvOrganizatinChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtvOrganizatinChart.Location = new System.Drawing.Point(0, 0);
            this.dtvOrganizatinChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtvOrganizatinChart.Name = "dtvOrganizatinChart";
            this.dtvOrganizatinChart.Size = new System.Drawing.Size(583, 451);
            this.dtvOrganizatinChart.TabIndex = 7;
            this.dtvOrganizatinChart.SelectedItemChange += new System.Windows.Forms.TreeViewEventHandler(this.dtvOrganizatinChart_SelectedItemChange);
            this.dtvOrganizatinChart.SelectedNodWithMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.dtvOrganizatinChart_SelectedNodWithMouseDoubleClick);
            // 
            // JfrmDefineChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 451);
            this.Controls.Add(this.dtvOrganizatinChart);
            this.Name = "JfrmDefineChart";
            this.Text = "FrmDefineChart";
            this.Load += new System.EventHandler(this.JfrmDefineChart_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmAddChart;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteChart;
        private ClassLibrary.JDataTreeView dtvOrganizatinChart;
    }
}