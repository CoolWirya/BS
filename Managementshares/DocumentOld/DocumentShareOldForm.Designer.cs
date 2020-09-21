namespace ManagementShares
{
    partial class JDocumentShareOldForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSabt = new System.Windows.Forms.Button();
            this.txtDescription = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.jucPerson1 = new ClassLibrary.JUCPerson();
            this.jArchiveList1 = new ArchivedDocuments.JArchiveList();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.groupBox1.SuspendLayout();
            this.jArchiveList1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.btnSabt);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.jucPerson1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(736, 196);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnSabt
            // 
            this.btnSabt.Location = new System.Drawing.Point(21, 159);
            this.btnSabt.Name = "btnSabt";
            this.btnSabt.Size = new System.Drawing.Size(225, 30);
            this.btnSabt.TabIndex = 4;
            this.btnSabt.Text = "ثبت";
            this.btnSabt.UseVisualStyleBackColor = true;
            this.btnSabt.Click += new System.EventHandler(this.btnSabt_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.ChangeColorIfNotEmpty = false;
            this.txtDescription.ChangeColorOnEnter = true;
            this.txtDescription.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDescription.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDescription.Location = new System.Drawing.Point(12, 12);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Negative = true;
            this.txtDescription.NotEmpty = false;
            this.txtDescription.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.SelectOnEnter = true;
            this.txtDescription.Size = new System.Drawing.Size(243, 142);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "توضیحات :";
            // 
            // jucPerson1
            // 
            this.jucPerson1.Dock = System.Windows.Forms.DockStyle.Top;
            this.jucPerson1.FilterPerson = null;
            this.jucPerson1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.jucPerson1.LableGroup = null;
            this.jucPerson1.Location = new System.Drawing.Point(3, 20);
            this.jucPerson1.Name = "jucPerson1";
            this.jucPerson1.PersonType = ClassLibrary.JPersonTypes.None;
            this.jucPerson1.ReadOnly = false;
            this.jucPerson1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.jucPerson1.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.jucPerson1.SelectedCode = 0;
            this.jucPerson1.Size = new System.Drawing.Size(730, 175);
            this.jucPerson1.TabIndex = 1;
            this.jucPerson1.TafsiliCode = false;
            // 
            // jArchiveList1
            // 
            this.jArchiveList1.AllowUserAddFile = true;
            this.jArchiveList1.AllowUserAddFromArchive = true;
            this.jArchiveList1.AllowUserAddImage = true;
            this.jArchiveList1.AllowUserCamera = true;
            this.jArchiveList1.AllowUserDeleteFile = true;
            this.jArchiveList1.ClassName = "";
            this.jArchiveList1.ClassNames = null;
            this.jArchiveList1.Controls.Add(this.txtDesc);
            this.jArchiveList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveList1.EnabledChange = true;
            this.jArchiveList1.Location = new System.Drawing.Point(0, 196);
            this.jArchiveList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jArchiveList1.Name = "jArchiveList1";
            this.jArchiveList1.ObjectCode = 0;
            this.jArchiveList1.ObjectCodes = null;
            this.jArchiveList1.PlaceCode = 0;
            this.jArchiveList1.Size = new System.Drawing.Size(736, 451);
            this.jArchiveList1.SubjectCode = 0;
            this.jArchiveList1.TabIndex = 4;
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(0, 0);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(736, 23);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // JDocumentShareOldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 647);
            this.Controls.Add(this.jArchiveList1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JDocumentShareOldForm";
            this.Text = "DocumentShareOldForm";
            this.Load += new System.EventHandler(this.JDocumentShareOldForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.jArchiveList1.ResumeLayout(false);
            this.jArchiveList1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ArchivedDocuments.JArchiveList jArchiveList1;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSabt;
        private ClassLibrary.TextEdit txtDescription;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JUCPerson jucPerson1;
    }
}