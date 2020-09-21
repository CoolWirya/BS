namespace Legal
{
    partial class JInheritForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRelationFamily = new ClassLibrary.JComboBox(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtShare = new ClassLibrary.NumEdit();
            this.txtAllShare = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "نسبت شخص:";
            // 
            // cmbRelationFamily
            // 
            this.cmbRelationFamily.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRelationFamily.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbRelationFamily.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRelationFamily.BaseCode = 0;
            this.cmbRelationFamily.ChangeColorIfNotEmpty = true;
            this.cmbRelationFamily.ChangeColorOnEnter = true;
            this.cmbRelationFamily.FormattingEnabled = true;
            this.cmbRelationFamily.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbRelationFamily.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbRelationFamily.Location = new System.Drawing.Point(31, 90);
            this.cmbRelationFamily.Name = "cmbRelationFamily";
            this.cmbRelationFamily.NotEmpty = false;
            this.cmbRelationFamily.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbRelationFamily.SelectOnEnter = true;
            this.cmbRelationFamily.Size = new System.Drawing.Size(245, 24);
            this.cmbRelationFamily.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(286, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(117, 170);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtShare
            // 
            this.txtShare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShare.ChangeColorIfNotEmpty = false;
            this.txtShare.ChangeColorOnEnter = true;
            this.txtShare.InBackColor = System.Drawing.SystemColors.Info;
            this.txtShare.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShare.Location = new System.Drawing.Point(243, 22);
            this.txtShare.Name = "txtShare";
            this.txtShare.Negative = false;
            this.txtShare.NotEmpty = false;
            this.txtShare.NotEmptyColor = System.Drawing.Color.Red;
            this.txtShare.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtShare.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShare.SelectOnEnter = true;
            this.txtShare.Size = new System.Drawing.Size(33, 23);
            this.txtShare.TabIndex = 0;
            this.txtShare.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtAllShare
            // 
            this.txtAllShare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAllShare.ChangeColorIfNotEmpty = false;
            this.txtAllShare.ChangeColorOnEnter = true;
            this.txtAllShare.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAllShare.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAllShare.Location = new System.Drawing.Point(243, 61);
            this.txtAllShare.Name = "txtAllShare";
            this.txtAllShare.Negative = false;
            this.txtAllShare.NotEmpty = false;
            this.txtAllShare.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAllShare.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAllShare.SelectOnEnter = true;
            this.txtAllShare.Size = new System.Drawing.Size(33, 23);
            this.txtAllShare.TabIndex = 1;
            this.txtAllShare.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "InherText:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "-----";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "شرح:";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(31, 120);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(245, 23);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAllShare);
            this.groupBox1.Controls.Add(this.cmbRelationFamily);
            this.groupBox1.Controls.Add(this.txtShare);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // JInheritForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 208);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "JInheritForm";
            this.Text = "InherText";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtAllShare;
        private ClassLibrary.NumEdit txtShare;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private ClassLibrary.JComboBox cmbRelationFamily;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}