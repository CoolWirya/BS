namespace Employment
{
    partial class JTitleJobForm
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
            this.label10 = new System.Windows.Forms.Label();
            this.cmbMetierTopic = new ClassLibrary.JComboBox(this.components);
            this.txtGroup = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtLevel = new ClassLibrary.TextEdit(this.components);
            this.txtJobCode = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDegree = new ClassLibrary.JComboBox(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtExpreince = new ClassLibrary.TextEdit(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 45);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(89, 16);
            this.label10.TabIndex = 69;
            this.label10.Text = "عنوان شغلی :";
            // 
            // cmbMetierTopic
            // 
            this.cmbMetierTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMetierTopic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbMetierTopic.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMetierTopic.BaseCode = 0;
            this.cmbMetierTopic.ChangeColorIfNotEmpty = true;
            this.cmbMetierTopic.ChangeColorOnEnter = true;
            this.cmbMetierTopic.FormattingEnabled = true;
            this.cmbMetierTopic.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbMetierTopic.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbMetierTopic.Location = new System.Drawing.Point(109, 42);
            this.cmbMetierTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMetierTopic.Name = "cmbMetierTopic";
            this.cmbMetierTopic.NotEmpty = false;
            this.cmbMetierTopic.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbMetierTopic.SelectOnEnter = true;
            this.cmbMetierTopic.Size = new System.Drawing.Size(157, 24);
            this.cmbMetierTopic.TabIndex = 3;
            // 
            // txtGroup
            // 
            this.txtGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroup.ChangeColorIfNotEmpty = false;
            this.txtGroup.ChangeColorOnEnter = true;
            this.txtGroup.InBackColor = System.Drawing.SystemColors.Info;
            this.txtGroup.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGroup.Location = new System.Drawing.Point(109, 134);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Negative = true;
            this.txtGroup.NotEmpty = false;
            this.txtGroup.NotEmptyColor = System.Drawing.Color.Red;
            this.txtGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGroup.SelectOnEnter = true;
            this.txtGroup.Size = new System.Drawing.Size(157, 23);
            this.txtGroup.TabIndex = 8;
            this.txtGroup.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 66;
            this.label4.Text = "گروه :";
            // 
            // txtLevel
            // 
            this.txtLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLevel.ChangeColorIfNotEmpty = false;
            this.txtLevel.ChangeColorOnEnter = true;
            this.txtLevel.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLevel.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLevel.Location = new System.Drawing.Point(109, 105);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Negative = true;
            this.txtLevel.NotEmpty = false;
            this.txtLevel.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLevel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLevel.SelectOnEnter = true;
            this.txtLevel.Size = new System.Drawing.Size(157, 23);
            this.txtLevel.TabIndex = 6;
            this.txtLevel.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtJobCode
            // 
            this.txtJobCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJobCode.ChangeColorIfNotEmpty = false;
            this.txtJobCode.ChangeColorOnEnter = true;
            this.txtJobCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtJobCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJobCode.Location = new System.Drawing.Point(109, 12);
            this.txtJobCode.Name = "txtJobCode";
            this.txtJobCode.Negative = true;
            this.txtJobCode.NotEmpty = false;
            this.txtJobCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtJobCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtJobCode.SelectOnEnter = true;
            this.txtJobCode.Size = new System.Drawing.Size(157, 23);
            this.txtJobCode.TabIndex = 1;
            this.txtJobCode.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 65;
            this.label2.Text = "سطح :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 64;
            this.label1.Text = "کد شغل :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 77);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 71;
            this.label3.Text = "مدرک تحصیلی :";
            // 
            // cmbDegree
            // 
            this.cmbDegree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDegree.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbDegree.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDegree.BaseCode = 0;
            this.cmbDegree.ChangeColorIfNotEmpty = true;
            this.cmbDegree.ChangeColorOnEnter = true;
            this.cmbDegree.FormattingEnabled = true;
            this.cmbDegree.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbDegree.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDegree.Location = new System.Drawing.Point(109, 74);
            this.cmbDegree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDegree.Name = "cmbDegree";
            this.cmbDegree.NotEmpty = false;
            this.cmbDegree.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbDegree.SelectOnEnter = true;
            this.cmbDegree.Size = new System.Drawing.Size(157, 24);
            this.cmbDegree.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(308, 45);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 27);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "درج";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(308, 78);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 27);
            this.btnExit.TabIndex = 74;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtExpreince
            // 
            this.txtExpreince.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpreince.ChangeColorIfNotEmpty = false;
            this.txtExpreince.ChangeColorOnEnter = true;
            this.txtExpreince.InBackColor = System.Drawing.SystemColors.Info;
            this.txtExpreince.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtExpreince.Location = new System.Drawing.Point(109, 164);
            this.txtExpreince.Name = "txtExpreince";
            this.txtExpreince.Negative = true;
            this.txtExpreince.NotEmpty = false;
            this.txtExpreince.NotEmptyColor = System.Drawing.Color.Red;
            this.txtExpreince.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtExpreince.SelectOnEnter = true;
            this.txtExpreince.Size = new System.Drawing.Size(157, 23);
            this.txtExpreince.TabIndex = 9;
            this.txtExpreince.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 76;
            this.label5.Text = "تجربه :";
            // 
            // JTitleJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 199);
            this.Controls.Add(this.txtExpreince);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDegree);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbMetierTopic);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.txtJobCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JTitleJobForm";
            this.Text = "TitleJobForm";
            this.Load += new System.EventHandler(this.JTitleJobForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private ClassLibrary.JComboBox cmbMetierTopic;
        private ClassLibrary.TextEdit txtGroup;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.TextEdit txtLevel;
        private ClassLibrary.TextEdit txtJobCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.JComboBox cmbDegree;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private ClassLibrary.TextEdit txtExpreince;
        private System.Windows.Forms.Label label5;
    }
}