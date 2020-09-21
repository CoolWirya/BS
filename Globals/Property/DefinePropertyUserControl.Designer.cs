namespace Globals.Property
{
    partial class JDefinePropertyUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JDefinePropertyUserControl));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.AddtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.DeletetoolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 25);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(290, 178);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseDoubleClick);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddtoolStripButton,
            this.DeletetoolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(290, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // AddtoolStripButton
            // 
            this.AddtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddtoolStripButton.Image")));
            this.AddtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddtoolStripButton.Name = "AddtoolStripButton";
            this.AddtoolStripButton.Size = new System.Drawing.Size(40, 22);
            this.AddtoolStripButton.Text = "Insert";
            this.AddtoolStripButton.Click += new System.EventHandler(this.AddtoolStripButton_Click);
            // 
            // DeletetoolStripButton
            // 
            this.DeletetoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeletetoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeletetoolStripButton.Image")));
            this.DeletetoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeletetoolStripButton.Name = "DeletetoolStripButton";
            this.DeletetoolStripButton.Size = new System.Drawing.Size(42, 22);
            this.DeletetoolStripButton.Text = "Delete";
            this.DeletetoolStripButton.Click += new System.EventHandler(this.DeletetoolStripButton_Click);
            // 
            // JDefinePropertyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.toolStrip);
            this.Name = "JDefinePropertyUserControl";
            this.Size = new System.Drawing.Size(290, 203);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton AddtoolStripButton;
        private System.Windows.Forms.ToolStripButton DeletetoolStripButton;
    }
}
