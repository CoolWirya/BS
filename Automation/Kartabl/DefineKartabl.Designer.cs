namespace Automation
{
    partial class JfrmDefineKartabl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JfrmDefineKartabl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkObject = new System.Windows.Forms.CheckBox();
            this.chkPosts = new System.Windows.Forms.CheckBox();
            this.cmbObject = new ClassLibrary.JComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPosts = new ClassLibrary.JComboBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtObjectType = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtKartablName = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.chbDeleteFromKaratble = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbDeleteFromKaratble);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chkObject);
            this.groupBox1.Controls.Add(this.chkPosts);
            this.groupBox1.Controls.Add(this.cmbObject);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbPosts);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtObjectType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtKartablName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 182);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chkObject
            // 
            this.chkObject.AutoSize = true;
            this.chkObject.Location = new System.Drawing.Point(26, 107);
            this.chkObject.Name = "chkObject";
            this.chkObject.Size = new System.Drawing.Size(15, 14);
            this.chkObject.TabIndex = 3;
            this.chkObject.UseVisualStyleBackColor = true;
            this.chkObject.CheckedChanged += new System.EventHandler(this.chkObject_CheckedChanged);
            // 
            // chkPosts
            // 
            this.chkPosts.AutoSize = true;
            this.chkPosts.Location = new System.Drawing.Point(26, 77);
            this.chkPosts.Name = "chkPosts";
            this.chkPosts.Size = new System.Drawing.Size(15, 14);
            this.chkPosts.TabIndex = 3;
            this.chkPosts.UseVisualStyleBackColor = true;
            this.chkPosts.CheckedChanged += new System.EventHandler(this.chkPosts_CheckedChanged);
            // 
            // cmbObject
            // 
            this.cmbObject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbObject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbObject.BaseCode = 0;
            this.cmbObject.ChangeColorIfNotEmpty = true;
            this.cmbObject.ChangeColorOnEnter = true;
            this.cmbObject.Enabled = false;
            this.cmbObject.FormattingEnabled = true;
            this.cmbObject.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbObject.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbObject.Location = new System.Drawing.Point(47, 102);
            this.cmbObject.Name = "cmbObject";
            this.cmbObject.NotEmpty = false;
            this.cmbObject.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbObject.SelectOnEnter = true;
            this.cmbObject.Size = new System.Drawing.Size(399, 24);
            this.cmbObject.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(453, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "نوع شی:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cmbPosts
            // 
            this.cmbPosts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbPosts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPosts.BaseCode = 0;
            this.cmbPosts.ChangeColorIfNotEmpty = true;
            this.cmbPosts.ChangeColorOnEnter = true;
            this.cmbPosts.Enabled = false;
            this.cmbPosts.FormattingEnabled = true;
            this.cmbPosts.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbPosts.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbPosts.Location = new System.Drawing.Point(47, 72);
            this.cmbPosts.Name = "cmbPosts";
            this.cmbPosts.NotEmpty = false;
            this.cmbPosts.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbPosts.SelectOnEnter = true;
            this.cmbPosts.Size = new System.Drawing.Size(399, 24);
            this.cmbPosts.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "گیرنده - فرستنده:";
            // 
            // txtObjectType
            // 
            this.txtObjectType.ChangeColorIfNotEmpty = true;
            this.txtObjectType.ChangeColorOnEnter = true;
            this.txtObjectType.InBackColor = System.Drawing.SystemColors.Info;
            this.txtObjectType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtObjectType.Location = new System.Drawing.Point(12, 45);
            this.txtObjectType.Name = "txtObjectType";
            this.txtObjectType.Negative = true;
            this.txtObjectType.NotEmpty = false;
            this.txtObjectType.NotEmptyColor = System.Drawing.Color.Red;
            this.txtObjectType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtObjectType.SelectOnEnter = true;
            this.txtObjectType.Size = new System.Drawing.Size(434, 23);
            this.txtObjectType.TabIndex = 1;
            this.txtObjectType.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "عنوان شی شامل:";
            // 
            // txtKartablName
            // 
            this.txtKartablName.ChangeColorIfNotEmpty = true;
            this.txtKartablName.ChangeColorOnEnter = true;
            this.txtKartablName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtKartablName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtKartablName.Location = new System.Drawing.Point(12, 16);
            this.txtKartablName.Name = "txtKartablName";
            this.txtKartablName.Negative = true;
            this.txtKartablName.NotEmpty = false;
            this.txtKartablName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtKartablName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtKartablName.SelectOnEnter = true;
            this.txtKartablName.Size = new System.Drawing.Size(434, 23);
            this.txtKartablName.TabIndex = 0;
            this.txtKartablName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(468, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kartabl Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnConfirm);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 182);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(569, 57);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(468, 19);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(87, 32);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(453, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "حذف از کارتابل:";
            // 
            // chbDeleteFromKaratble
            // 
            this.chbDeleteFromKaratble.AutoSize = true;
            this.chbDeleteFromKaratble.Location = new System.Drawing.Point(431, 139);
            this.chbDeleteFromKaratble.Name = "chbDeleteFromKaratble";
            this.chbDeleteFromKaratble.Size = new System.Drawing.Size(15, 14);
            this.chbDeleteFromKaratble.TabIndex = 5;
            this.chbDeleteFromKaratble.UseVisualStyleBackColor = true;
            // 
            // JfrmDefineKartabl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 239);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "JfrmDefineKartabl";
            this.Text = "DefineKartabl";
            this.Load += new System.EventHandler(this.JDefineKartabl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit txtKartablName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnConfirm;
        private ClassLibrary.JComboBox cmbPosts;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.TextEdit txtObjectType;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkPosts;
		private System.Windows.Forms.CheckBox chkObject;
		private ClassLibrary.JComboBox cmbObject;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbDeleteFromKaratble;
        private System.Windows.Forms.Label label5;
    }
}