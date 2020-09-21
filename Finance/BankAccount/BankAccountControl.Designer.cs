namespace Finance
{
    partial class JBankAccountControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.MaskedTextBox();
            this.txtAccountNo = new ClassLibrary.TextEdit(this.components);
            this.cmbBankName = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCardNo);
            this.groupBox1.Controls.Add(this.txtAccountNo);
            this.groupBox1.Controls.Add(this.cmbBankName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات حساب";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "شماره کارت:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "شماره حساب:";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCardNo.Location = new System.Drawing.Point(16, 74);
            this.txtCardNo.Mask = "0000-0000-0000-0000";
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(141, 22);
            this.txtCardNo.TabIndex = 9;
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountNo.ChangeColorIfNotEmpty = false;
            this.txtAccountNo.ChangeColorOnEnter = true;
            this.txtAccountNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAccountNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAccountNo.Location = new System.Drawing.Point(16, 46);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Negative = true;
            this.txtAccountNo.NotEmpty = false;
            this.txtAccountNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAccountNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAccountNo.SelectOnEnter = true;
            this.txtAccountNo.Size = new System.Drawing.Size(140, 22);
            this.txtAccountNo.TabIndex = 8;
            this.txtAccountNo.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbBankName
            // 
            this.cmbBankName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBankName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbBankName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBankName.BaseCode = 0;
            this.cmbBankName.ChangeColorIfNotEmpty = true;
            this.cmbBankName.ChangeColorOnEnter = true;
            this.cmbBankName.FormattingEnabled = true;
            this.cmbBankName.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbBankName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBankName.Location = new System.Drawing.Point(16, 17);
            this.cmbBankName.Name = "cmbBankName";
            this.cmbBankName.NotEmpty = false;
            this.cmbBankName.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbBankName.SelectOnEnter = true;
            this.cmbBankName.Size = new System.Drawing.Size(140, 22);
            this.cmbBankName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "نام بانک:";
            // 
            // JBankAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "JBankAccountControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(261, 107);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtCardNo;
        private ClassLibrary.TextEdit txtAccountNo;
        private ClassLibrary.JComboBox cmbBankName;
        private System.Windows.Forms.Label label1;

    }
}
