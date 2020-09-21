namespace Finance
{
    partial class JLedgerAccountForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textEdit1 = new ClassLibrary.TextEdit(this.components);
            this.textEdit2 = new ClassLibrary.TextEdit(this.components);
            this.cmbTotalAccount = new ClassLibrary.JComboBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "حساب کل:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "کد معین:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "عنوان:";
            // 
            // textEdit1
            // 
            this.textEdit1.ChangeColorIfNotEmpty = false;
            this.textEdit1.ChangeColorOnEnter = true;
            this.textEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.textEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.textEdit1.Location = new System.Drawing.Point(109, 77);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Negative = true;
            this.textEdit1.NotEmpty = false;
            this.textEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.textEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit1.SelectOnEnter = true;
            this.textEdit1.Size = new System.Drawing.Size(70, 23);
            this.textEdit1.TabIndex = 5;
            this.textEdit1.TextMode = ClassLibrary.TextModes.Text;
            // 
            // textEdit2
            // 
            this.textEdit2.ChangeColorIfNotEmpty = false;
            this.textEdit2.ChangeColorOnEnter = true;
            this.textEdit2.InBackColor = System.Drawing.SystemColors.Info;
            this.textEdit2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.textEdit2.Location = new System.Drawing.Point(109, 124);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Negative = true;
            this.textEdit2.NotEmpty = false;
            this.textEdit2.NotEmptyColor = System.Drawing.Color.Red;
            this.textEdit2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit2.SelectOnEnter = true;
            this.textEdit2.Size = new System.Drawing.Size(121, 23);
            this.textEdit2.TabIndex = 6;
            this.textEdit2.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbTotalAccount
            // 
            this.cmbTotalAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbTotalAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTotalAccount.BaseCode = 0;
            this.cmbTotalAccount.ChangeColorIfNotEmpty = true;
            this.cmbTotalAccount.ChangeColorOnEnter = true;
            this.cmbTotalAccount.FormattingEnabled = true;
            this.cmbTotalAccount.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbTotalAccount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTotalAccount.Location = new System.Drawing.Point(109, 38);
            this.cmbTotalAccount.Name = "cmbTotalAccount";
            this.cmbTotalAccount.NotEmpty = false;
            this.cmbTotalAccount.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbTotalAccount.SelectOnEnter = true;
            this.cmbTotalAccount.Size = new System.Drawing.Size(121, 24);
            this.cmbTotalAccount.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(45, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 179);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ماهیت حساب";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(72, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(88, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "مهم نیست";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(46, 48);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(114, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "بدهکار طی دوره";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(35, 74);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(125, 20);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "بستانکار طی دوره";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(43, 100);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(117, 20);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "بدهکار پایان دوره";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(32, 126);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(128, 20);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "بستانکار پایان دوره";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(35, 369);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 9;
            this.btnsave.Text = "ذخیره ";
            this.btnsave.UseVisualStyleBackColor = true;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(166, 369);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 10;
            this.btnclose.Text = "خروج";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "label4";
            // 
            // JLedgerAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 409);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbTotalAccount);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JLedgerAccountForm";
            this.Text = "معرفی حسابهای معین";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.TextEdit textEdit1;
        private ClassLibrary.TextEdit textEdit2;
        private ClassLibrary.JComboBox cmbTotalAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label label4;
    }
}