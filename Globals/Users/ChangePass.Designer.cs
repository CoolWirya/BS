namespace Globals
{
    partial class JChangePass
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
            this.txtUserName = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtRePasswor = new ClassLibrary.TextEdit(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new ClassLibrary.TextEdit(this.components);
            this.closeBtn = new System.Windows.Forms.Button();
            this.SaveBtn_update = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOldPassword = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtPersonCode = new ClassLibrary.NumEdit();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.ChangeColorIfNotEmpty = true;
            this.txtUserName.ChangeColorOnEnter = true;
            this.txtUserName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtUserName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserName.Location = new System.Drawing.Point(113, 39);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Negative = true;
            this.txtUserName.NotEmpty = false;
            this.txtUserName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserName.SelectOnEnter = true;
            this.txtUserName.Size = new System.Drawing.Size(180, 23);
            this.txtUserName.TabIndex = 40;
            this.txtUserName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 37;
            this.label4.Text = "UserName";
            // 
            // txtRePasswor
            // 
            this.txtRePasswor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRePasswor.ChangeColorIfNotEmpty = true;
            this.txtRePasswor.ChangeColorOnEnter = true;
            this.txtRePasswor.InBackColor = System.Drawing.SystemColors.Info;
            this.txtRePasswor.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRePasswor.Location = new System.Drawing.Point(113, 126);
            this.txtRePasswor.Name = "txtRePasswor";
            this.txtRePasswor.Negative = true;
            this.txtRePasswor.NotEmpty = false;
            this.txtRePasswor.NotEmptyColor = System.Drawing.Color.Red;
            this.txtRePasswor.PasswordChar = '*';
            this.txtRePasswor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRePasswor.SelectOnEnter = true;
            this.txtRePasswor.Size = new System.Drawing.Size(180, 23);
            this.txtRePasswor.TabIndex = 3;
            this.txtRePasswor.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 39;
            this.label6.Text = "Password";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = "RepeatPassword";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.ChangeColorIfNotEmpty = true;
            this.txtPassword.ChangeColorOnEnter = true;
            this.txtPassword.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPassword.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPassword.Location = new System.Drawing.Point(113, 96);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Negative = true;
            this.txtPassword.NotEmpty = false;
            this.txtPassword.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPassword.SelectOnEnter = true;
            this.txtPassword.Size = new System.Drawing.Size(180, 23);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TextMode = ClassLibrary.TextModes.Text;
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(202, 155);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 25);
            this.closeBtn.TabIndex = 5;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // SaveBtn_update
            // 
            this.SaveBtn_update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBtn_update.Location = new System.Drawing.Point(113, 155);
            this.SaveBtn_update.Name = "SaveBtn_update";
            this.SaveBtn_update.Size = new System.Drawing.Size(75, 25);
            this.SaveBtn_update.TabIndex = 4;
            this.SaveBtn_update.Text = "Save";
            this.SaveBtn_update.UseVisualStyleBackColor = true;
            this.SaveBtn_update.Click += new System.EventHandler(this.SaveBtn_update_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "Old Password";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldPassword.ChangeColorIfNotEmpty = true;
            this.txtOldPassword.ChangeColorOnEnter = true;
            this.txtOldPassword.InBackColor = System.Drawing.SystemColors.Info;
            this.txtOldPassword.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOldPassword.Location = new System.Drawing.Point(113, 68);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Negative = true;
            this.txtOldPassword.NotEmpty = false;
            this.txtOldPassword.NotEmptyColor = System.Drawing.Color.Red;
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtOldPassword.SelectOnEnter = true;
            this.txtOldPassword.Size = new System.Drawing.Size(180, 23);
            this.txtOldPassword.TabIndex = 1;
            this.txtOldPassword.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 47;
            this.label2.Text = "PersonCode";
            // 
            // txtPersonCode
            // 
            this.txtPersonCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPersonCode.ChangeColorIfNotEmpty = true;
            this.txtPersonCode.ChangeColorOnEnter = true;
            this.txtPersonCode.Enabled = false;
            this.txtPersonCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPersonCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPersonCode.Location = new System.Drawing.Point(113, 10);
            this.txtPersonCode.Name = "txtPersonCode";
            this.txtPersonCode.Negative = true;
            this.txtPersonCode.NotEmpty = false;
            this.txtPersonCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPersonCode.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtPersonCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPersonCode.SelectOnEnter = true;
            this.txtPersonCode.Size = new System.Drawing.Size(180, 23);
            this.txtPersonCode.TabIndex = 48;
            this.txtPersonCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // JChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 187);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPersonCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.SaveBtn_update);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRePasswor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPassword);
            this.Name = "JChangePass";
            this.Text = "ChangePass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClassLibrary.TextEdit txtUserName;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.TextEdit txtRePasswor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.TextEdit txtPassword;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button SaveBtn_update;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtOldPassword;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.NumEdit txtPersonCode;
    }
}