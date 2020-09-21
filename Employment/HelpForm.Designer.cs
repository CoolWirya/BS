namespace Employment
{
    partial class JHelpForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.ArchiveList = new ArchivedDocuments.JArchiveList();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.ArchiveList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(272, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "ثبت";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ArchiveList
            // 
            this.ArchiveList.AllowUserAddFile = true;
            this.ArchiveList.AllowUserAddFromArchive = true;
            this.ArchiveList.AllowUserAddImage = true;
            this.ArchiveList.AllowUserCamera = true;
            this.ArchiveList.AllowUserDeleteFile = true;
            this.ArchiveList.ClassName = "";
            this.ArchiveList.ClassNames = null;
            this.ArchiveList.Controls.Add(this.txtDesc);
            this.ArchiveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveList.EnabledChange = true;
            this.ArchiveList.Location = new System.Drawing.Point(0, 0);
            this.ArchiveList.Name = "ArchiveList";
            this.ArchiveList.ObjectCode = 0;
            this.ArchiveList.ObjectCodes = null;
            this.ArchiveList.PlaceCode = 0;
            this.ArchiveList.Size = new System.Drawing.Size(583, 451);
            this.ArchiveList.SubjectCode = 0;
            this.ArchiveList.TabIndex = 2;
            this.ArchiveList.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(0, 0);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(583, 23);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // JHelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 451);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ArchiveList);
            this.Name = "JHelpForm";
            this.Text = "HelpForm";
            this.Load += new System.EventHandler(this.HelpForm_Load);
            this.ArchiveList.ResumeLayout(false);
            this.ArchiveList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private ArchivedDocuments.JArchiveList ArchiveList;
        private ClassLibrary.TextEdit txtDesc;
    }
}