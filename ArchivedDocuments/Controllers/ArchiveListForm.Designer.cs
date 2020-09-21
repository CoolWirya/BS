namespace ArchivedDocuments.Controllers
{
    partial class JArchiveListForm
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
			this.jArchiveList = new ArchivedDocuments.JArchiveList();
			this.SuspendLayout();
			// 
			// jArchiveList
			// 
			this.jArchiveList.AllowUserAddFile = true;
			this.jArchiveList.AllowUserAddFromArchive = true;
			this.jArchiveList.AllowUserAddImage = true;
			this.jArchiveList.AllowUserCamera = true;
			this.jArchiveList.AllowUserDeleteFile = true;
			this.jArchiveList.ClassName = "";
			this.jArchiveList.ClassNames = null;
			this.jArchiveList.DataBaseClassName = "";
			this.jArchiveList.DataBaseObjectCode = 0;
			this.jArchiveList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.jArchiveList.EnabledChange = true;
			this.jArchiveList.ExtraObject = null;
			this.jArchiveList.Location = new System.Drawing.Point(0, 0);
			this.jArchiveList.Name = "jArchiveList";
			this.jArchiveList.ObjectCode = 0;
			this.jArchiveList.ObjectCodes = null;
			this.jArchiveList.PlaceCode = 0;
			this.jArchiveList.Size = new System.Drawing.Size(574, 451);
			this.jArchiveList.SubjectCode = 0;
			this.jArchiveList.TabIndex = 0;
			this.jArchiveList.Load += new System.EventHandler(this.jArchiveList_Load);
			// 
			// JArchiveListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(574, 451);
			this.Controls.Add(this.jArchiveList);
			this.Name = "JArchiveListForm";
			this.Text = "ArchiveListForm";
			this.ResumeLayout(false);

        }

        #endregion

        public JArchiveList jArchiveList;

    }
}