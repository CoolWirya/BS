namespace Finance
{
    partial class JPromissoryNoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JPromissoryNoteForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSwap = new System.Windows.Forms.Button();
            this.PersonReciver = new ClassLibrary.JUCPerson();
            this.PersonExport = new ClassLibrary.JUCPerson();
            this.cmbConcern = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtNo = new ClassLibrary.TextEdit(this.components);
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeliverDate = new ClassLibrary.DateEdit(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.JArchive = new ArchivedDocuments.JArchiveList();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(492, 539);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(484, 510);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "سند";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSwap);
            this.groupBox1.Controls.Add(this.PersonReciver);
            this.groupBox1.Controls.Add(this.PersonExport);
            this.groupBox1.Controls.Add(this.cmbConcern);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNo);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDeliverDate);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(478, 502);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSwap
            // 
            this.btnSwap.Image = ((System.Drawing.Image)(resources.GetObject("btnSwap.Image")));
            this.btnSwap.Location = new System.Drawing.Point(22, 273);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(48, 35);
            this.btnSwap.TabIndex = 87;
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // PersonReciver
            // 
            this.PersonReciver.FilterPerson = null;
            this.PersonReciver.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PersonReciver.LableGroup = null;
            this.PersonReciver.Location = new System.Drawing.Point(6, 256);
            this.PersonReciver.Name = "PersonReciver";
            this.PersonReciver.PersonType = ClassLibrary.JPersonTypes.None;
            this.PersonReciver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PersonReciver.SelectedCode = 0;
            this.PersonReciver.Size = new System.Drawing.Size(466, 178);
            this.PersonReciver.TabIndex = 6;
            this.PersonReciver.Text = "دریافت کننده";
            // 
            // PersonExport
            // 
            this.PersonExport.FilterPerson = null;
            this.PersonExport.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PersonExport.LableGroup = null;
            this.PersonExport.Location = new System.Drawing.Point(6, 74);
            this.PersonExport.Name = "PersonExport";
            this.PersonExport.PersonType = ClassLibrary.JPersonTypes.None;
            this.PersonExport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PersonExport.SelectedCode = 0;
            this.PersonExport.Size = new System.Drawing.Size(466, 181);
            this.PersonExport.TabIndex = 5;
            this.PersonExport.Text = "صادر کننده";
            // 
            // cmbConcern
            // 
            this.cmbConcern.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbConcern.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbConcern.BaseCode = 0;
            this.cmbConcern.ChangeColorIfNotEmpty = true;
            this.cmbConcern.ChangeColorOnEnter = true;
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbConcern.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbConcern.Location = new System.Drawing.Point(262, 44);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.NotEmpty = false;
            this.cmbConcern.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbConcern.SelectOnEnter = true;
            this.cmbConcern.Size = new System.Drawing.Size(158, 24);
            this.cmbConcern.TabIndex = 2;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 71;
            this.label1.Text = "شماره :";
            // 
            // txtNo
            // 
            this.txtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNo.ChangeColorIfNotEmpty = false;
            this.txtNo.ChangeColorOnEnter = true;
            this.txtNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNo.Location = new System.Drawing.Point(262, 14);
            this.txtNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNo.Name = "txtNo";
            this.txtNo.Negative = true;
            this.txtNo.NotEmpty = false;
            this.txtNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNo.SelectOnEnter = true;
            this.txtNo.Size = new System.Drawing.Size(157, 23);
            this.txtNo.TabIndex = 1;
            this.txtNo.TextMode = ClassLibrary.TextModes.Text;
            this.txtNo.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(3, 456);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(467, 39);
            this.txtDesc.TabIndex = 7;
            this.txtDesc.TabStop = false;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 67;
            this.label2.Text = "توضیحات:";
            // 
            // txtDeliverDate
            // 
            this.txtDeliverDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliverDate.BackColor = System.Drawing.SystemColors.Info;
            this.txtDeliverDate.ChangeColorIfNotEmpty = true;
            this.txtDeliverDate.ChangeColorOnEnter = true;
            this.txtDeliverDate.Date = new System.DateTime(((long)(0)));
            this.txtDeliverDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeliverDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDeliverDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeliverDate.InsertInDatesTable = true;
            this.txtDeliverDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDeliverDate.Location = new System.Drawing.Point(24, 42);
            this.txtDeliverDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDeliverDate.Mask = "0000/00/00";
            this.txtDeliverDate.Name = "txtDeliverDate";
            this.txtDeliverDate.NotEmpty = false;
            this.txtDeliverDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDeliverDate.Size = new System.Drawing.Size(116, 23);
            this.txtDeliverDate.TabIndex = 4;
            this.txtDeliverDate.TextChanged += new System.EventHandler(this.txtDeliverDate_TextChanged);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(426, 47);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 16);
            this.label20.TabIndex = 63;
            this.label20.Text = "بابت:";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(150, 15);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 16);
            this.label23.TabIndex = 65;
            this.label23.Text = "مبلغ :";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(24, 14);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(117, 23);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(146, 44);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 16);
            this.label22.TabIndex = 64;
            this.label22.Text = "تاريخ تحويل :";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.JArchive);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(484, 510);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "تصاویر";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // JArchive
            // 
            this.JArchive.AllowUserAddFile = true;
            this.JArchive.AllowUserAddFromArchive = true;
            this.JArchive.AllowUserAddImage = true;
            this.JArchive.AllowUserDeleteFile = true;
            this.JArchive.ClassName = "";
            this.JArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JArchive.Location = new System.Drawing.Point(3, 4);
            this.JArchive.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.JArchive.Name = "JArchive";
            this.JArchive.ObjectCode = 0;
            this.JArchive.PlaceCode = 0;
            this.JArchive.Size = new System.Drawing.Size(478, 502);
            this.JArchive.SubjectCode = 0;
            this.JArchive.TabIndex = 1;
            this.JArchive.AfterFileAdded += new ArchivedDocuments.JArchiveList.FileAdded(this.txtNo_TextChanged);
            this.JArchive.AfterDescriptioEdited += new ArchivedDocuments.JArchiveList.DescriptioEdited(this.txtNo_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(5, 542);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Location = new System.Drawing.Point(85, 542);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 9;
            this.btnSaveClose.Text = "ذخیره";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(407, 542);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // JPromissoryNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 572);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JPromissoryNoteForm";
            this.Text = "سفته";
            this.Load += new System.EventHandler(this.JPromissoryNoteForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtNo;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.DateEdit txtDeliverDate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private ClassLibrary.TextEdit txtPrice;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TabPage tabPage3;
        private ArchivedDocuments.JArchiveList JArchive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button btnExit;
        private ClassLibrary.JComboBox cmbConcern;
        private ClassLibrary.JUCPerson PersonExport;
        private ClassLibrary.JUCPerson PersonReciver;
        private System.Windows.Forms.Button btnSwap;
    }
}