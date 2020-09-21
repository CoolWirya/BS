namespace ArchivedDocuments
{
    partial class JSubjectEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JSubjectEditForm));
            this.cmbState = new ClassLibrary.JComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtTitle = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccessCode = new ClassLibrary.NumEdit();
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
            // cmbState
            // 
            this.cmbState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbState.BaseCode = 0;
            this.cmbState.ChangeColorIfNotEmpty = true;
            this.cmbState.ChangeColorOnEnter = true;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbState.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbState.Items.AddRange(new object[] {
            "فعال",
            "غیرفعال"});
            this.cmbState.Location = new System.Drawing.Point(64, 57);
            this.cmbState.Name = "cmbState";
            this.cmbState.NotEmpty = false;
            this.cmbState.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbState.SelectOnEnter = true;
            this.cmbState.Size = new System.Drawing.Size(95, 24);
            this.cmbState.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "State:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(168, 124);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(66, 124);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.ChangeColorIfNotEmpty = true;
            this.txtTitle.ChangeColorOnEnter = true;
            this.txtTitle.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTitle.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTitle.Location = new System.Drawing.Point(64, 19);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Negative = true;
            this.txtTitle.NotEmpty = false;
            this.txtTitle.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitle.SelectOnEnter = true;
            this.txtTitle.Size = new System.Drawing.Size(301, 23);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "AccessCode:";
            // 
            // txtAccessCode
            // 
            this.txtAccessCode.ChangeColorIfNotEmpty = true;
            this.txtAccessCode.ChangeColorOnEnter = true;
            this.txtAccessCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAccessCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAccessCode.Location = new System.Drawing.Point(265, 58);
            this.txtAccessCode.Name = "txtAccessCode";
            this.txtAccessCode.Negative = true;
            this.txtAccessCode.NotEmpty = false;
            this.txtAccessCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAccessCode.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtAccessCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAccessCode.SelectOnEnter = true;
            this.txtAccessCode.Size = new System.Drawing.Size(100, 23);
            this.txtAccessCode.TabIndex = 3;
            this.txtAccessCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // JSubjectEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 171);
            this.Controls.Add(this.txtAccessCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Name = "JSubjectEditForm";
            this.Text = "SubjectEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ClassLibrary.JComboBox cmbState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        public ClassLibrary.TextEdit txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public ClassLibrary.NumEdit txtAccessCode;
    }
}