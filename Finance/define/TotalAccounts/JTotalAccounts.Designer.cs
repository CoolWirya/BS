namespace Finance
{
    partial class JTotalAccountsForm
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
			this.labCode = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbCreditor = new System.Windows.Forms.RadioButton();
			this.rbDebTor = new System.Windows.Forms.RadioButton();
			this.rbNoMatter = new System.Windows.Forms.RadioButton();
			this.btnSave = new System.Windows.Forms.Button();
			this.txtClose = new System.Windows.Forms.Button();
			this.txtCode = new ClassLibrary.TextEdit(this.components);
			this.txtName = new ClassLibrary.TextEdit(this.components);
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// labCode
			// 
			this.labCode.AutoSize = true;
			this.labCode.Location = new System.Drawing.Point(39, 31);
			this.labCode.Name = "labCode";
			this.labCode.Size = new System.Drawing.Size(30, 16);
			this.labCode.TabIndex = 0;
			this.labCode.Text = "کد :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(39, 79);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "عنوان:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbCreditor);
			this.groupBox1.Controls.Add(this.rbDebTor);
			this.groupBox1.Controls.Add(this.rbNoMatter);
			this.groupBox1.Location = new System.Drawing.Point(42, 122);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(148, 146);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "ماهیت:";
			// 
			// rbCreditor
			// 
			this.rbCreditor.AutoSize = true;
			this.rbCreditor.Location = new System.Drawing.Point(44, 105);
			this.rbCreditor.Name = "rbCreditor";
			this.rbCreditor.Size = new System.Drawing.Size(73, 20);
			this.rbCreditor.TabIndex = 2;
			this.rbCreditor.TabStop = true;
			this.rbCreditor.Text = "بستانکار";
			this.rbCreditor.UseVisualStyleBackColor = true;
			// 
			// rbDebTor
			// 
			this.rbDebTor.AutoSize = true;
			this.rbDebTor.Location = new System.Drawing.Point(53, 66);
			this.rbDebTor.Name = "rbDebTor";
			this.rbDebTor.Size = new System.Drawing.Size(62, 20);
			this.rbDebTor.TabIndex = 1;
			this.rbDebTor.TabStop = true;
			this.rbDebTor.Text = "بدهکار";
			this.rbDebTor.UseVisualStyleBackColor = true;
			// 
			// rbNoMatter
			// 
			this.rbNoMatter.AutoSize = true;
			this.rbNoMatter.Location = new System.Drawing.Point(29, 28);
			this.rbNoMatter.Name = "rbNoMatter";
			this.rbNoMatter.Size = new System.Drawing.Size(88, 20);
			this.rbNoMatter.TabIndex = 0;
			this.rbNoMatter.TabStop = true;
			this.rbNoMatter.Text = "مهم نیست";
			this.rbNoMatter.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(32, 295);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "ذخیره";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtClose
			// 
			this.txtClose.Location = new System.Drawing.Point(117, 295);
			this.txtClose.Name = "txtClose";
			this.txtClose.Size = new System.Drawing.Size(75, 23);
			this.txtClose.TabIndex = 6;
			this.txtClose.Text = "خروج";
			this.txtClose.UseVisualStyleBackColor = true;
			this.txtClose.Click += new System.EventHandler(this.txtClose_Click);
			// 
			// txtCode
			// 
			this.txtCode.ChangeColorIfNotEmpty = false;
			this.txtCode.ChangeColorOnEnter = true;
			this.txtCode.InBackColor = System.Drawing.SystemColors.Info;
			this.txtCode.InForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCode.Location = new System.Drawing.Point(89, 31);
			this.txtCode.Name = "txtCode";
			this.txtCode.Negative = true;
			this.txtCode.NotEmpty = false;
			this.txtCode.NotEmptyColor = System.Drawing.Color.Red;
			this.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtCode.SelectOnEnter = true;
			this.txtCode.Size = new System.Drawing.Size(100, 23);
			this.txtCode.TabIndex = 8;
			this.txtCode.TextMode = ClassLibrary.TextModes.Integer;
			// 
			// txtName
			// 
			this.txtName.ChangeColorIfNotEmpty = false;
			this.txtName.ChangeColorOnEnter = true;
			this.txtName.InBackColor = System.Drawing.SystemColors.Info;
			this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
			this.txtName.Location = new System.Drawing.Point(89, 79);
			this.txtName.Name = "txtName";
			this.txtName.Negative = true;
			this.txtName.NotEmpty = false;
			this.txtName.NotEmptyColor = System.Drawing.Color.Red;
			this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtName.SelectOnEnter = true;
			this.txtName.Size = new System.Drawing.Size(100, 23);
			this.txtName.TabIndex = 9;
			this.txtName.TextMode = ClassLibrary.TextModes.Text;
			// 
			// JTotalAccountsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(298, 330);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.txtClose);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labCode);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "JTotalAccountsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
			this.Text = "معرفی حسابهای کل";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCreditor;
        private System.Windows.Forms.RadioButton rbDebTor;
        private System.Windows.Forms.RadioButton rbNoMatter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button txtClose;
        private ClassLibrary.TextEdit txtCode;
        private ClassLibrary.TextEdit txtName;
    }
}