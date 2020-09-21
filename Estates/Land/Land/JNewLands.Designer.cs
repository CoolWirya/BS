namespace Estates
{
    partial class JLandForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JLandForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtName = new ClassLibrary.TextEdit(this.components);
            this.txtSection = new ClassLibrary.TextEdit(this.components);
            this.txtPlaque = new ClassLibrary.TextEdit(this.components);
            this.numArea = new ClassLibrary.TextEdit(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ArchiveListLand = new ArchivedDocuments.JArchiveList();
            this.label7 = new System.Windows.Forms.Label();
            this.labCode = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "مساحت تقریبی:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "پلاک ثبتی:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "بخش:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(452, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "موسوم به:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(228, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "متر مربع";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(96, 382);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "ثبت";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(498, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "خروج";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(562, 331);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.txtSection);
            this.tabPage1.Controls.Add(this.txtPlaque);
            this.tabPage1.Controls.Add(this.numArea);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(554, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "مشخصات";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.ChangeColorIfNotEmpty = true;
            this.txtName.ChangeColorOnEnter = true;
            this.txtName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(50, 127);
            this.txtName.Name = "txtName";
            this.txtName.Negative = true;
            this.txtName.NotEmpty = false;
            this.txtName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectOnEnter = true;
            this.txtName.Size = new System.Drawing.Size(352, 23);
            this.txtName.TabIndex = 12;
            this.txtName.TextMode = ClassLibrary.TextModes.Text;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtSection
            // 
            this.txtSection.ChangeColorIfNotEmpty = true;
            this.txtSection.ChangeColorOnEnter = true;
            this.txtSection.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSection.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSection.Location = new System.Drawing.Point(50, 98);
            this.txtSection.Name = "txtSection";
            this.txtSection.Negative = true;
            this.txtSection.NotEmpty = false;
            this.txtSection.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSection.SelectOnEnter = true;
            this.txtSection.Size = new System.Drawing.Size(352, 23);
            this.txtSection.TabIndex = 11;
            this.txtSection.TextMode = ClassLibrary.TextModes.Text;
            this.txtSection.TextChanged += new System.EventHandler(this.txtSection_TextChanged);
            // 
            // txtPlaque
            // 
            this.txtPlaque.ChangeColorIfNotEmpty = true;
            this.txtPlaque.ChangeColorOnEnter = true;
            this.txtPlaque.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPlaque.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPlaque.Location = new System.Drawing.Point(50, 69);
            this.txtPlaque.Name = "txtPlaque";
            this.txtPlaque.Negative = true;
            this.txtPlaque.NotEmpty = false;
            this.txtPlaque.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPlaque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlaque.SelectOnEnter = true;
            this.txtPlaque.Size = new System.Drawing.Size(352, 23);
            this.txtPlaque.TabIndex = 10;
            this.txtPlaque.TextMode = ClassLibrary.TextModes.Text;
            this.txtPlaque.TextChanged += new System.EventHandler(this.txtPlaque_TextChanged);
            // 
            // numArea
            // 
            this.numArea.ChangeColorIfNotEmpty = true;
            this.numArea.ChangeColorOnEnter = true;
            this.numArea.InBackColor = System.Drawing.SystemColors.Info;
            this.numArea.InForeColor = System.Drawing.SystemColors.WindowText;
            this.numArea.Location = new System.Drawing.Point(302, 40);
            this.numArea.Name = "numArea";
            this.numArea.Negative = true;
            this.numArea.NotEmpty = false;
            this.numArea.NotEmptyColor = System.Drawing.Color.Red;
            this.numArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numArea.SelectOnEnter = true;
            this.numArea.Size = new System.Drawing.Size(100, 23);
            this.numArea.TabIndex = 9;
            this.numArea.TextMode = ClassLibrary.TextModes.Real;
            this.numArea.TextChanged += new System.EventHandler(this.numArea_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ArchiveListLand);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(554, 302);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تصاویر و فایلهای مرتبط";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ArchiveListLand
            // 
            this.ArchiveListLand.AllowUserAddFile = true;
            this.ArchiveListLand.AllowUserAddFromArchive = true;
            this.ArchiveListLand.AllowUserAddImage = true;
            this.ArchiveListLand.AllowUserDeleteFile = true;
            this.ArchiveListLand.ClassName = "";
            this.ArchiveListLand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveListLand.Location = new System.Drawing.Point(3, 3);
            this.ArchiveListLand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArchiveListLand.Name = "ArchiveListLand";
            this.ArchiveListLand.ObjectCode = 0;
            this.ArchiveListLand.PlaceCode = 0;
            this.ArchiveListLand.Size = new System.Drawing.Size(548, 296);
            this.ArchiveListLand.SubjectCode = 0;
            this.ArchiveListLand.TabIndex = 0;
            this.ArchiveListLand.AfterFileAdded += new ArchivedDocuments.JArchiveList.FileAdded(this.ArchiveListLand_AfterFileAdded);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "کداراضی:";
            // 
            // labCode
            // 
            this.labCode.AutoSize = true;
            this.labCode.Location = new System.Drawing.Point(78, 9);
            this.labCode.Name = "labCode";
            this.labCode.Size = new System.Drawing.Size(0, 16);
            this.labCode.TabIndex = 14;
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(15, 382);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "تایید";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // JLandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 417);
            this.Controls.Add(this.labCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnSave);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JLandForm";
            this.Text = "اراضی";
            this.Load += new System.EventHandler(this.JLandForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JLandForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ClassLibrary.TextEdit txtName;
        private ClassLibrary.TextEdit txtSection;
        private ClassLibrary.TextEdit txtPlaque;
        private ClassLibrary.TextEdit numArea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labCode;
        private ArchivedDocuments.JArchiveList ArchiveListLand;
        private System.Windows.Forms.Button btnApply;

    }
}