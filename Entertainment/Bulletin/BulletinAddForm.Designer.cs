namespace Entertainment
{
    partial class BulletinAddForm
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
            this.label9 = new System.Windows.Forms.Label();
            this.cmbFeild = new ClassLibrary.JComboBox(this.components);
            this.btnConfirm = new System.Windows.Forms.Button();
            this.ArchiveList = new ArchivedDocuments.JArchiveList();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 10);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 58;
            this.label9.Text = "گروه :";
            // 
            // cmbFeild
            // 
            this.cmbFeild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFeild.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbFeild.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFeild.BaseCode = 0;
            this.cmbFeild.ChangeColorIfNotEmpty = true;
            this.cmbFeild.ChangeColorOnEnter = true;
            this.cmbFeild.FormattingEnabled = true;
            this.cmbFeild.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbFeild.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFeild.Location = new System.Drawing.Point(59, 6);
            this.cmbFeild.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbFeild.Name = "cmbFeild";
            this.cmbFeild.NotEmpty = false;
            this.cmbFeild.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbFeild.SelectOnEnter = true;
            this.cmbFeild.Size = new System.Drawing.Size(200, 24);
            this.cmbFeild.TabIndex = 57;
            this.cmbFeild.SelectedIndexChanged += new System.EventHandler(this.cmbFeild_SelectedIndexChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(265, 5);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 25);
            this.btnConfirm.TabIndex = 59;
            this.btnConfirm.Text = "تایید";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // ArchiveList
            // 
            this.ArchiveList.AllowUserAddFile = true;
            this.ArchiveList.AllowUserAddFromArchive = true;
            this.ArchiveList.AllowUserAddImage = true;
            this.ArchiveList.AllowUserDeleteFile = true;
            this.ArchiveList.ClassName = "";
            this.ArchiveList.ClassNames = null;
            this.ArchiveList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ArchiveList.EnabledChange = true;
            this.ArchiveList.Location = new System.Drawing.Point(0, 38);
            this.ArchiveList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArchiveList.Name = "ArchiveList";
            this.ArchiveList.ObjectCode = 0;
            this.ArchiveList.ObjectCodes = null;
            this.ArchiveList.PlaceCode = 0;
            this.ArchiveList.Size = new System.Drawing.Size(574, 413);
            this.ArchiveList.SubjectCode = 0;
            this.ArchiveList.TabIndex = 60;
            // 
            // BulletinAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 451);
            this.Controls.Add(this.ArchiveList);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbFeild);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BulletinAddForm";
            this.Text = "BulletinAddForm";
            this.Load += new System.EventHandler(this.BulletinAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private ClassLibrary.JComboBox cmbFeild;
        private System.Windows.Forms.Button btnConfirm;
        private ArchivedDocuments.JArchiveList ArchiveList;
    }
}