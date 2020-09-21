namespace Globals
{
    partial class JUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JUserForm));
            this.SaveBtn_insert_update = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.personUser = new ClassLibrary.JUCPerson();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbDomainName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUserName = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.chActive = new System.Windows.Forms.CheckBox();
            this.txtLastLogin = new ClassLibrary.TextEdit(this.components);
            this.txtRePasswor = new ClassLibrary.TextEdit(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPassword = new ClassLibrary.TextEdit(this.components);
            this.groupBox2.SuspendLayout();
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
            // SaveBtn_insert_update
            // 
            this.SaveBtn_insert_update.Location = new System.Drawing.Point(119, 366);
            this.SaveBtn_insert_update.Name = "SaveBtn_insert_update";
            this.SaveBtn_insert_update.Size = new System.Drawing.Size(75, 39);
            this.SaveBtn_insert_update.TabIndex = 1;
            this.SaveBtn_insert_update.Text = "Save";
            this.SaveBtn_insert_update.UseVisualStyleBackColor = true;
            this.SaveBtn_insert_update.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(274, 366);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 39);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            // 
            // personUser
            // 
            this.personUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.personUser.FilterPerson = null;
            this.personUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.personUser.LableGroup = null;
            this.personUser.Location = new System.Drawing.Point(0, 0);
            this.personUser.Name = "personUser";
            this.personUser.PersonType = ClassLibrary.JPersonTypes.RealPerson;
            this.personUser.ReadOnly = false;
            this.personUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.personUser.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.personUser.SelectedCode = 0;
            //this.personUser.ShowPersonImage = false;
            this.personUser.Size = new System.Drawing.Size(537, 186);
            this.personUser.TabIndex = 42;
            this.personUser.TafsiliCode = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbDomainName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtUserName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chActive);
            this.groupBox2.Controls.Add(this.txtLastLogin);
            this.groupBox2.Controls.Add(this.txtRePasswor);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 174);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            // 
            // cmbDomainName
            // 
            this.cmbDomainName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDomainName.FormattingEnabled = true;
            this.cmbDomainName.Location = new System.Drawing.Point(212, 137);
            this.cmbDomainName.Name = "cmbDomainName";
            this.cmbDomainName.Size = new System.Drawing.Size(180, 24);
            this.cmbDomainName.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(428, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 16);
            this.label8.TabIndex = 40;
            this.label8.Text = "domainname";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.ChangeColorIfNotEmpty = true;
            this.txtUserName.ChangeColorOnEnter = true;
            this.txtUserName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtUserName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserName.Location = new System.Drawing.Point(212, 18);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Negative = true;
            this.txtUserName.NotEmpty = false;
            this.txtUserName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserName.SelectOnEnter = true;
            this.txtUserName.Size = new System.Drawing.Size(180, 23);
            this.txtUserName.TabIndex = 34;
            this.txtUserName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "UserName";
            // 
            // chActive
            // 
            this.chActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chActive.AutoSize = true;
            this.chActive.Checked = true;
            this.chActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chActive.Location = new System.Drawing.Point(103, 112);
            this.chActive.Name = "chActive";
            this.chActive.Size = new System.Drawing.Size(87, 20);
            this.chActive.TabIndex = 37;
            this.chActive.Text = "ActiveUser";
            this.chActive.UseVisualStyleBackColor = true;
            // 
            // txtLastLogin
            // 
            this.txtLastLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastLogin.ChangeColorIfNotEmpty = true;
            this.txtLastLogin.ChangeColorOnEnter = true;
            this.txtLastLogin.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLastLogin.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLastLogin.Location = new System.Drawing.Point(212, 108);
            this.txtLastLogin.Name = "txtLastLogin";
            this.txtLastLogin.Negative = true;
            this.txtLastLogin.NotEmpty = false;
            this.txtLastLogin.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLastLogin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLastLogin.SelectOnEnter = true;
            this.txtLastLogin.Size = new System.Drawing.Size(180, 23);
            this.txtLastLogin.TabIndex = 39;
            this.txtLastLogin.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtRePasswor
            // 
            this.txtRePasswor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRePasswor.ChangeColorIfNotEmpty = true;
            this.txtRePasswor.ChangeColorOnEnter = true;
            this.txtRePasswor.InBackColor = System.Drawing.SystemColors.Info;
            this.txtRePasswor.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRePasswor.Location = new System.Drawing.Point(212, 78);
            this.txtRePasswor.Name = "txtRePasswor";
            this.txtRePasswor.Negative = true;
            this.txtRePasswor.NotEmpty = false;
            this.txtRePasswor.NotEmptyColor = System.Drawing.Color.Red;
            this.txtRePasswor.PasswordChar = '*';
            this.txtRePasswor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRePasswor.SelectOnEnter = true;
            this.txtRePasswor.Size = new System.Drawing.Size(180, 23);
            this.txtRePasswor.TabIndex = 36;
            this.txtRePasswor.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(447, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "Password";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(407, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "RepeatPassword";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(423, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 16);
            this.label7.TabIndex = 38;
            this.label7.Text = "LastLoginDate";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.ChangeColorIfNotEmpty = true;
            this.txtPassword.ChangeColorOnEnter = true;
            this.txtPassword.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPassword.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPassword.Location = new System.Drawing.Point(212, 48);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Negative = true;
            this.txtPassword.NotEmpty = false;
            this.txtPassword.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPassword.SelectOnEnter = true;
            this.txtPassword.Size = new System.Drawing.Size(180, 23);
            this.txtPassword.TabIndex = 35;
            this.txtPassword.TextMode = ClassLibrary.TextModes.Text;
            // 
            // JUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeBtn;
            this.ClientSize = new System.Drawing.Size(537, 406);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.personUser);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.SaveBtn_insert_update);
            this.Name = "JUserForm";
            this.Text = "UserForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveBtn_insert_update;
        private System.Windows.Forms.Button closeBtn;
        private ClassLibrary.JUCPerson personUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbDomainName;
        private System.Windows.Forms.Label label8;
        private ClassLibrary.TextEdit txtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chActive;
        private ClassLibrary.TextEdit txtLastLogin;
        private ClassLibrary.TextEdit txtRePasswor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private ClassLibrary.TextEdit txtPassword;
    }
}