namespace Automation
{
    partial class JfrmSubsidiaries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JfrmSubsidiaries));
            this.txtNameCompany = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtmanaging_Director = new ClassLibrary.TextEdit(this.components);
            this.txtPhone = new ClassLibrary.TextEdit(this.components);
            this.txtAddress = new ClassLibrary.TextEdit(this.components);
            this.txtServer_name = new ClassLibrary.TextEdit(this.components);
            this.txtDataBaseName = new ClassLibrary.TextEdit(this.components);
            this.txtServer_User = new ClassLibrary.TextEdit(this.components);
            this.txtServer_Pass = new ClassLibrary.TextEdit(this.components);
            this.txtDescription = new ClassLibrary.TextEdit(this.components);
            this.btnAction = new System.Windows.Forms.Button();
            this.nedAccessCode = new ClassLibrary.NumEdit();
            this.label10 = new System.Windows.Forms.Label();
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
            // txtNameCompany
            // 
            this.txtNameCompany.ChangeColorIfNotEmpty = true;
            this.txtNameCompany.ChangeColorOnEnter = true;
            this.txtNameCompany.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNameCompany.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNameCompany.Location = new System.Drawing.Point(156, 17);
            this.txtNameCompany.Name = "txtNameCompany";
            this.txtNameCompany.NotEmpty = false;
            this.txtNameCompany.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNameCompany.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNameCompany.SelectOnEnter = true;
            this.txtNameCompany.Size = new System.Drawing.Size(294, 23);
            this.txtNameCompany.TabIndex = 0;
            this.txtNameCompany.TextChanged += new System.EventHandler(this.textEdit1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Managing Director:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Phone Number:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Server Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Username:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Database:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 310);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Access Code:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 346);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Description:";
            // 
            // txtmanaging_Director
            // 
            this.txtmanaging_Director.ChangeColorIfNotEmpty = true;
            this.txtmanaging_Director.ChangeColorOnEnter = true;
            this.txtmanaging_Director.InBackColor = System.Drawing.SystemColors.Info;
            this.txtmanaging_Director.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtmanaging_Director.Location = new System.Drawing.Point(156, 53);
            this.txtmanaging_Director.Name = "txtmanaging_Director";
            this.txtmanaging_Director.NotEmpty = false;
            this.txtmanaging_Director.NotEmptyColor = System.Drawing.Color.Red;
            this.txtmanaging_Director.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtmanaging_Director.SelectOnEnter = true;
            this.txtmanaging_Director.Size = new System.Drawing.Size(294, 23);
            this.txtmanaging_Director.TabIndex = 1;
            // 
            // txtPhone
            // 
            this.txtPhone.ChangeColorIfNotEmpty = true;
            this.txtPhone.ChangeColorOnEnter = true;
            this.txtPhone.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPhone.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPhone.Location = new System.Drawing.Point(156, 89);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.NotEmpty = false;
            this.txtPhone.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPhone.SelectOnEnter = true;
            this.txtPhone.Size = new System.Drawing.Size(294, 23);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.TextChanged += new System.EventHandler(this.textEdit3_TextChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.ChangeColorIfNotEmpty = true;
            this.txtAddress.ChangeColorOnEnter = true;
            this.txtAddress.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAddress.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAddress.Location = new System.Drawing.Point(156, 125);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.NotEmpty = false;
            this.txtAddress.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.SelectOnEnter = true;
            this.txtAddress.Size = new System.Drawing.Size(294, 23);
            this.txtAddress.TabIndex = 3;
            // 
            // txtServer_name
            // 
            this.txtServer_name.ChangeColorIfNotEmpty = true;
            this.txtServer_name.ChangeColorOnEnter = true;
            this.txtServer_name.InBackColor = System.Drawing.SystemColors.Info;
            this.txtServer_name.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtServer_name.Location = new System.Drawing.Point(156, 161);
            this.txtServer_name.Name = "txtServer_name";
            this.txtServer_name.NotEmpty = false;
            this.txtServer_name.NotEmptyColor = System.Drawing.Color.Red;
            this.txtServer_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtServer_name.SelectOnEnter = true;
            this.txtServer_name.Size = new System.Drawing.Size(294, 23);
            this.txtServer_name.TabIndex = 4;
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.ChangeColorIfNotEmpty = true;
            this.txtDataBaseName.ChangeColorOnEnter = true;
            this.txtDataBaseName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDataBaseName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDataBaseName.Location = new System.Drawing.Point(156, 197);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.NotEmpty = false;
            this.txtDataBaseName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDataBaseName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDataBaseName.SelectOnEnter = true;
            this.txtDataBaseName.Size = new System.Drawing.Size(294, 23);
            this.txtDataBaseName.TabIndex = 5;
            // 
            // txtServer_User
            // 
            this.txtServer_User.ChangeColorIfNotEmpty = true;
            this.txtServer_User.ChangeColorOnEnter = true;
            this.txtServer_User.InBackColor = System.Drawing.SystemColors.Info;
            this.txtServer_User.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtServer_User.Location = new System.Drawing.Point(156, 233);
            this.txtServer_User.Name = "txtServer_User";
            this.txtServer_User.NotEmpty = false;
            this.txtServer_User.NotEmptyColor = System.Drawing.Color.Red;
            this.txtServer_User.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtServer_User.SelectOnEnter = true;
            this.txtServer_User.Size = new System.Drawing.Size(294, 23);
            this.txtServer_User.TabIndex = 6;
            // 
            // txtServer_Pass
            // 
            this.txtServer_Pass.ChangeColorIfNotEmpty = true;
            this.txtServer_Pass.ChangeColorOnEnter = true;
            this.txtServer_Pass.InBackColor = System.Drawing.SystemColors.Info;
            this.txtServer_Pass.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtServer_Pass.Location = new System.Drawing.Point(156, 269);
            this.txtServer_Pass.Name = "txtServer_Pass";
            this.txtServer_Pass.NotEmpty = false;
            this.txtServer_Pass.NotEmptyColor = System.Drawing.Color.Red;
            this.txtServer_Pass.PasswordChar = '*';
            this.txtServer_Pass.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtServer_Pass.SelectOnEnter = true;
            this.txtServer_Pass.Size = new System.Drawing.Size(294, 23);
            this.txtServer_Pass.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.ChangeColorIfNotEmpty = true;
            this.txtDescription.ChangeColorOnEnter = true;
            this.txtDescription.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDescription.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDescription.Location = new System.Drawing.Point(156, 341);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.NotEmpty = false;
            this.txtDescription.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.SelectOnEnter = true;
            this.txtDescription.Size = new System.Drawing.Size(294, 69);
            this.txtDescription.TabIndex = 9;
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(209, 423);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 10;
            this.btnAction.Text = "Action";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // nedAccessCode
            // 
            this.nedAccessCode.ChangeColorIfNotEmpty = true;
            this.nedAccessCode.ChangeColorOnEnter = true;
            this.nedAccessCode.InBackColor = System.Drawing.SystemColors.Info;
            this.nedAccessCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.nedAccessCode.Location = new System.Drawing.Point(156, 305);
            this.nedAccessCode.Name = "nedAccessCode";
            this.nedAccessCode.Negative = true;
            this.nedAccessCode.NotEmpty = false;
            this.nedAccessCode.NotEmptyColor = System.Drawing.Color.Red;
            this.nedAccessCode.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.nedAccessCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nedAccessCode.SelectOnEnter = true;
            this.nedAccessCode.Size = new System.Drawing.Size(294, 23);
            this.nedAccessCode.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(79, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Name:";
            // 
            // JfrmSubsidiaries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(493, 451);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nedAccessCode);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtServer_Pass);
            this.Controls.Add(this.txtServer_User);
            this.Controls.Add(this.txtDataBaseName);
            this.Controls.Add(this.txtServer_name);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtmanaging_Director);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNameCompany);
            this.Name = "JfrmSubsidiaries";
            this.Load += new System.EventHandler(this.JfrmSubsidiaries_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClassLibrary.TextEdit txtNameCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private ClassLibrary.TextEdit txtmanaging_Director;
        private ClassLibrary.TextEdit txtPhone;
        private ClassLibrary.TextEdit txtAddress;
        private ClassLibrary.TextEdit txtServer_name;
        private ClassLibrary.TextEdit txtDataBaseName;
        private ClassLibrary.TextEdit txtServer_User;
        private ClassLibrary.TextEdit txtServer_Pass;
        private ClassLibrary.TextEdit txtDescription;
        private System.Windows.Forms.Button btnAction;
        private ClassLibrary.NumEdit nedAccessCode;
        private System.Windows.Forms.Label label10;
    }
}
