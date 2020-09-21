namespace ArchivedDocuments
{
    partial class JArchiveImage
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
            this.components = new System.ComponentModel.Container();
            this.mnuImages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteImageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuImages
            // 
            this.mnuImages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newItem,
            this.editMenuItem,
            this.deleteImageItem});
            this.mnuImages.Name = "mnuImages";
            this.mnuImages.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnuImages.Size = new System.Drawing.Size(108, 70);
            this.mnuImages.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuImages_ItemClicked);
            this.mnuImages.Opening += new System.ComponentModel.CancelEventHandler(this.mnuImages_Opening);
            // 
            // newItem
            // 
            this.newItem.Name = "newItem";
            this.newItem.Size = new System.Drawing.Size(107, 22);
            this.newItem.Text = "New";
            // 
            // editMenuItem
            // 
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editMenuItem.Text = "Edit";
            // 
            // deleteImageItem
            // 
            this.deleteImageItem.Name = "deleteImageItem";
            this.deleteImageItem.Size = new System.Drawing.Size(107, 22);
            this.deleteImageItem.Text = "Delete";
            // 
            // JArchiveImage
            // 
            this.ContextMenuStrip = this.mnuImages;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mnuImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuImages;
        private System.Windows.Forms.ToolStripMenuItem newItem;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteImageItem;
    }
}
