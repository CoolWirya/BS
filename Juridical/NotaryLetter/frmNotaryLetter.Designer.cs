namespace Legal
{
    partial class JNotaryLetterForm
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
            this.btnAddNotery = new System.Windows.Forms.Button();
            this.chkSended = new System.Windows.Forms.CheckBox();
            this.cmbSubject = new ClassLibrary.JComboBox(this.components);
            this.txtLetterNo = new ClassLibrary.TextEdit(this.components);
            this.jcmbNotary = new ClassLibrary.JComboBox(this.components);
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DateLetter = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.jArchiveList1 = new ArchivedDocuments.JArchiveList();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddNotery);
            this.groupBox1.Controls.Add(this.chkSended);
            this.groupBox1.Controls.Add(this.cmbSubject);
            this.groupBox1.Controls.Add(this.txtLetterNo);
            this.groupBox1.Controls.Add(this.jcmbNotary);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DateLetter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnAddNotery
            // 
            this.btnAddNotery.Location = new System.Drawing.Point(247, 30);
            this.btnAddNotery.Name = "btnAddNotery";
            this.btnAddNotery.Size = new System.Drawing.Size(24, 23);
            this.btnAddNotery.TabIndex = 26;
            this.btnAddNotery.Text = "+";
            this.btnAddNotery.UseVisualStyleBackColor = true;
            this.btnAddNotery.Click += new System.EventHandler(this.btnAddNotery_Click);
            // 
            // chkSended
            // 
            this.chkSended.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSended.AutoSize = true;
            this.chkSended.Location = new System.Drawing.Point(458, 177);
            this.chkSended.Name = "chkSended";
            this.chkSended.Size = new System.Drawing.Size(69, 20);
            this.chkSended.TabIndex = 25;
            this.chkSended.Text = "ارسالی";
            this.chkSended.UseVisualStyleBackColor = true;
            // 
            // cmbSubject
            // 
            this.cmbSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSubject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSubject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubject.BaseCode = 0;
            this.cmbSubject.ChangeColorIfNotEmpty = true;
            this.cmbSubject.ChangeColorOnEnter = true;
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbSubject.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSubject.Location = new System.Drawing.Point(23, 25);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.NotEmpty = false;
            this.cmbSubject.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbSubject.SelectOnEnter = true;
            this.cmbSubject.Size = new System.Drawing.Size(135, 24);
            this.cmbSubject.TabIndex = 3;
            // 
            // txtLetterNo
            // 
            this.txtLetterNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLetterNo.ChangeColorIfNotEmpty = false;
            this.txtLetterNo.ChangeColorOnEnter = true;
            this.txtLetterNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLetterNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLetterNo.Location = new System.Drawing.Point(277, 59);
            this.txtLetterNo.Name = "txtLetterNo";
            this.txtLetterNo.Negative = true;
            this.txtLetterNo.NotEmpty = false;
            this.txtLetterNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLetterNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterNo.SelectOnEnter = true;
            this.txtLetterNo.Size = new System.Drawing.Size(169, 23);
            this.txtLetterNo.TabIndex = 3;
            this.txtLetterNo.TextMode = ClassLibrary.TextModes.Text;
            this.txtLetterNo.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // jcmbNotary
            // 
            this.jcmbNotary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jcmbNotary.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.jcmbNotary.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.jcmbNotary.BaseCode = 0;
            this.jcmbNotary.ChangeColorIfNotEmpty = true;
            this.jcmbNotary.ChangeColorOnEnter = true;
            this.jcmbNotary.FormattingEnabled = true;
            this.jcmbNotary.InBackColor = System.Drawing.SystemColors.Info;
            this.jcmbNotary.InForeColor = System.Drawing.SystemColors.WindowText;
            this.jcmbNotary.Location = new System.Drawing.Point(277, 29);
            this.jcmbNotary.Name = "jcmbNotary";
            this.jcmbNotary.NotEmpty = false;
            this.jcmbNotary.NotEmptyColor = System.Drawing.Color.Red;
            this.jcmbNotary.SelectOnEnter = true;
            this.jcmbNotary.Size = new System.Drawing.Size(169, 24);
            this.jcmbNotary.TabIndex = 2;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(25, 88);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(421, 109);
            this.txtDesc.TabIndex = 6;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(455, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "توضیحات :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "موضوع نامه:";
            // 
            // DateLetter
            // 
            this.DateLetter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateLetter.ChangeColorIfNotEmpty = true;
            this.DateLetter.ChangeColorOnEnter = true;
            this.DateLetter.Date = new System.DateTime(((long)(0)));
            this.DateLetter.InBackColor = System.Drawing.SystemColors.Info;
            this.DateLetter.InForeColor = System.Drawing.SystemColors.WindowText;
            this.DateLetter.InsertInDatesTable = true;
            this.DateLetter.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.DateLetter.Location = new System.Drawing.Point(23, 55);
            this.DateLetter.Mask = "0000/00/00";
            this.DateLetter.Name = "DateLetter";
            this.DateLetter.NotEmpty = false;
            this.DateLetter.NotEmptyColor = System.Drawing.Color.Red;
            this.DateLetter.Size = new System.Drawing.Size(135, 23);
            this.DateLetter.TabIndex = 4;
            this.DateLetter.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "تاریخ نامه:";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(455, 63);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 16);
            this.label17.TabIndex = 17;
            this.label17.Text = "شماره نامه:";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(454, 35);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 16);
            this.label21.TabIndex = 16;
            this.label21.Text = "شماره دفتر:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnSaveClose);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 556);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 44);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(476, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(31, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(395, 16);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 9;
            this.btnSaveClose.Text = "ذخیره ";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.jArchiveList1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(563, 340);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // jArchiveList1
            // 
            this.jArchiveList1.AllowUserAddFile = true;
            this.jArchiveList1.AllowUserAddFromArchive = true;
            this.jArchiveList1.AllowUserAddImage = true;
            this.jArchiveList1.AllowUserDeleteFile = true;
            this.jArchiveList1.ClassName = "";
            this.jArchiveList1.ClassNames = null;
            this.jArchiveList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveList1.EnabledChange = true;
            this.jArchiveList1.Location = new System.Drawing.Point(3, 19);
            this.jArchiveList1.Name = "jArchiveList1";
            this.jArchiveList1.ObjectCode = 0;
            this.jArchiveList1.ObjectCodes = null;
            this.jArchiveList1.PlaceCode = 0;
            this.jArchiveList1.Size = new System.Drawing.Size(557, 318);
            this.jArchiveList1.SubjectCode = 0;
            this.jArchiveList1.TabIndex = 7;
            // 
            // JNotaryLetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 600);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JNotaryLetterForm";
            this.Text = "frmNotaryLetter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.DateEdit DateLetter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveClose;
        private ArchivedDocuments.JArchiveList jArchiveList1;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private ClassLibrary.JComboBox jcmbNotary;
        private ClassLibrary.TextEdit txtLetterNo;
        private ClassLibrary.JComboBox cmbSubject;
        private System.Windows.Forms.CheckBox chkSended;
        private System.Windows.Forms.Button btnAddNotery;
    }
}