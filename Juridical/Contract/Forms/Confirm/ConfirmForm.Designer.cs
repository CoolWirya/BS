namespace Legal
{
    partial class JConfirmForm
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
            this.chkSeller = new System.Windows.Forms.CheckBox();
            this.chkBuyer = new System.Windows.Forms.CheckBox();
            this.chkView = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstImages = new ArchivedDocuments.JArchiveList();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSeller
            // 
            this.chkSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSeller.AutoSize = true;
            this.chkSeller.Location = new System.Drawing.Point(507, 23);
            this.chkSeller.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSeller.Name = "chkSeller";
            this.chkSeller.Size = new System.Drawing.Size(101, 20);
            this.chkSeller.TabIndex = 0;
            this.chkSeller.Text = "امضا فروشنده";
            this.chkSeller.UseVisualStyleBackColor = true;
            this.chkSeller.CheckedChanged += new System.EventHandler(this.chkSeller_CheckedChanged);
            // 
            // chkBuyer
            // 
            this.chkBuyer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBuyer.AutoSize = true;
            this.chkBuyer.Location = new System.Drawing.Point(287, 23);
            this.chkBuyer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkBuyer.Name = "chkBuyer";
            this.chkBuyer.Size = new System.Drawing.Size(88, 20);
            this.chkBuyer.TabIndex = 1;
            this.chkBuyer.Text = "امضا خریدار";
            this.chkBuyer.UseVisualStyleBackColor = true;
            this.chkBuyer.CheckedChanged += new System.EventHandler(this.chkBuyer_CheckedChanged);
            // 
            // chkView
            // 
            this.chkView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkView.AutoSize = true;
            this.chkView.Location = new System.Drawing.Point(93, 23);
            this.chkView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkView.Name = "chkView";
            this.chkView.Size = new System.Drawing.Size(87, 20);
            this.chkView.TabIndex = 2;
            this.chkView.Text = "امضا شهود";
            this.chkView.UseVisualStyleBackColor = true;
            this.chkView.CheckedChanged += new System.EventHandler(this.chkView_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(549, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(468, 9);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 14;
            this.btnSaveClose.Text = "ذخیره ";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkSeller);
            this.groupBox1.Controls.Add(this.chkBuyer);
            this.groupBox1.Controls.Add(this.chkView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 144);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "کد تفصیلی خریدار در حسابداری";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(606, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(18, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnSaveClose);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 451);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 44);
            this.panel1.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstImages);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(636, 307);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "تصویر قرارداد امضاء شده";
            // 
            // lstImages
            // 
            this.lstImages.AllowUserAddFile = true;
            this.lstImages.AllowUserAddFromArchive = true;
            this.lstImages.AllowUserAddImage = true;
            this.lstImages.AllowUserCamera = true;
            this.lstImages.AllowUserDeleteFile = true;
            this.lstImages.ClassName = "";
            this.lstImages.ClassNames = null;
            this.lstImages.DataBaseClassName = "";
            this.lstImages.DataBaseObjectCode = 0;
            this.lstImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstImages.EnabledChange = true;
            this.lstImages.ExtraObject = null;
            this.lstImages.Location = new System.Drawing.Point(3, 19);
            this.lstImages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstImages.Name = "lstImages";
            this.lstImages.ObjectCode = 0;
            this.lstImages.ObjectCodes = null;
            this.lstImages.PlaceCode = 0;
            this.lstImages.Size = new System.Drawing.Size(630, 285);
            this.lstImages.SubjectCode = 0;
            this.lstImages.TabIndex = 0;
            this.lstImages.AfterFileAdded += new ArchivedDocuments.JArchiveList.FileAdded(this.chkSeller_CheckedChanged);
            this.lstImages.AfterDescriptioEdited += new ArchivedDocuments.JArchiveList.DescriptioEdited(this.chkSeller_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(18, 100);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(418, 24);
            this.comboBox1.TabIndex = 6;
            // 
            // JConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 495);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JConfirmForm";
            this.Text = "تائید قرارداد";
            this.Load += new System.EventHandler(this.JConfirmForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSeller;
        private System.Windows.Forms.CheckBox chkBuyer;
        private System.Windows.Forms.CheckBox chkView;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ArchivedDocuments.JArchiveList lstImages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}