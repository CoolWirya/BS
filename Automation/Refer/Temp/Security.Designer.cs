namespace Automation
{
    partial class JSecurity
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
            this.cmbsecuritylevel = new ClassLibrary.JComboBox(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.cmbUrgency = new ClassLibrary.JComboBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSecretEmperise = new ClassLibrary.TextEdit(this.components);
            this.txtNormalEmperise = new ClassLibrary.TextEdit(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbsecuritylevel);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbUrgency);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSecretEmperise);
            this.groupBox1.Controls.Add(this.txtNormalEmperise);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(855, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Security";
            // 
            // cmbsecuritylevel
            // 
            this.cmbsecuritylevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbsecuritylevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbsecuritylevel.ChangeColorIfNotEmpty = true;
            this.cmbsecuritylevel.ChangeColorOnEnter = true;
            this.cmbsecuritylevel.FormattingEnabled = true;
            this.cmbsecuritylevel.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbsecuritylevel.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbsecuritylevel.Location = new System.Drawing.Point(23, 17);
            this.cmbsecuritylevel.Name = "cmbsecuritylevel";
            this.cmbsecuritylevel.NotEmpty = false;
            this.cmbsecuritylevel.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbsecuritylevel.SelectOnEnter = true;
            this.cmbsecuritylevel.Size = new System.Drawing.Size(306, 21);
            this.cmbsecuritylevel.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(333, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Security Level :";
            // 
            // cmbUrgency
            // 
            this.cmbUrgency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUrgency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUrgency.ChangeColorIfNotEmpty = true;
            this.cmbUrgency.ChangeColorOnEnter = true;
            this.cmbUrgency.FormattingEnabled = true;
            this.cmbUrgency.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbUrgency.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbUrgency.Location = new System.Drawing.Point(436, 17);
            this.cmbUrgency.Name = "cmbUrgency";
            this.cmbUrgency.NotEmpty = false;
            this.cmbUrgency.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbUrgency.SelectOnEnter = true;
            this.cmbUrgency.Size = new System.Drawing.Size(302, 21);
            this.cmbUrgency.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(744, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Urgency:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Secret Emprise:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(745, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Normal Emprise:";
            // 
            // txtSecretEmperise
            // 
            this.txtSecretEmperise.ChangeColorIfNotEmpty = true;
            this.txtSecretEmperise.ChangeColorOnEnter = true;
            this.txtSecretEmperise.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSecretEmperise.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSecretEmperise.Location = new System.Drawing.Point(23, 47);
            this.txtSecretEmperise.Multiline = true;
            this.txtSecretEmperise.Name = "txtSecretEmperise";
            this.txtSecretEmperise.Negative = true;
            this.txtSecretEmperise.NotEmpty = false;
            this.txtSecretEmperise.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSecretEmperise.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSecretEmperise.SelectOnEnter = true;
            this.txtSecretEmperise.Size = new System.Drawing.Size(306, 50);
            this.txtSecretEmperise.TabIndex = 11;
            this.txtSecretEmperise.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtNormalEmperise
            // 
            this.txtNormalEmperise.BackColor = System.Drawing.SystemColors.Window;
            this.txtNormalEmperise.ChangeColorIfNotEmpty = true;
            this.txtNormalEmperise.ChangeColorOnEnter = true;
            this.txtNormalEmperise.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNormalEmperise.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNormalEmperise.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNormalEmperise.Location = new System.Drawing.Point(436, 47);
            this.txtNormalEmperise.Multiline = true;
            this.txtNormalEmperise.Name = "txtNormalEmperise";
            this.txtNormalEmperise.Negative = true;
            this.txtNormalEmperise.NotEmpty = false;
            this.txtNormalEmperise.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNormalEmperise.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNormalEmperise.SelectOnEnter = true;
            this.txtNormalEmperise.Size = new System.Drawing.Size(303, 50);
            this.txtNormalEmperise.TabIndex = 9;
            this.txtNormalEmperise.TextMode = ClassLibrary.TextModes.Text;
            // 
            // JSecurity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "JSecurity";
            this.Size = new System.Drawing.Size(855, 110);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public ClassLibrary.JComboBox cmbsecuritylevel;
        public ClassLibrary.JComboBox cmbUrgency;
        public ClassLibrary.TextEdit txtSecretEmperise;
        public ClassLibrary.TextEdit txtNormalEmperise;
    }
}
