namespace Globals
{
    partial class JPermissionSetUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JPermissionSetUserForm));
            this.Insertbutton = new System.Windows.Forms.Button();
            this.Deletebutton = new System.Windows.Forms.Button();
            this.Okbutton = new System.Windows.Forms.Button();
            this.DefineClassListBox = new System.Windows.Forms.ListBox();
            this.ObjectlistBox = new System.Windows.Forms.ListBox();
            this.DecissionlistBox = new System.Windows.Forms.ListBox();
            this.PermissionUserlistBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDefineClassList = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.checkBoxNone = new System.Windows.Forms.CheckBox();
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
            // Insertbutton
            // 
            this.Insertbutton.Location = new System.Drawing.Point(655, 214);
            this.Insertbutton.Name = "Insertbutton";
            this.Insertbutton.Size = new System.Drawing.Size(75, 23);
            this.Insertbutton.TabIndex = 2;
            this.Insertbutton.Text = "Insert";
            this.Insertbutton.UseVisualStyleBackColor = true;
            this.Insertbutton.Click += new System.EventHandler(this.Insertbutton_Click);
            // 
            // Deletebutton
            // 
            this.Deletebutton.Location = new System.Drawing.Point(655, 416);
            this.Deletebutton.Name = "Deletebutton";
            this.Deletebutton.Size = new System.Drawing.Size(75, 23);
            this.Deletebutton.TabIndex = 2;
            this.Deletebutton.Text = "Delete";
            this.Deletebutton.UseVisualStyleBackColor = true;
            this.Deletebutton.Click += new System.EventHandler(this.Deletebutton_Click);
            // 
            // Okbutton
            // 
            this.Okbutton.Location = new System.Drawing.Point(574, 416);
            this.Okbutton.Name = "Okbutton";
            this.Okbutton.Size = new System.Drawing.Size(75, 23);
            this.Okbutton.TabIndex = 2;
            this.Okbutton.Text = "OK";
            this.Okbutton.UseVisualStyleBackColor = true;
            this.Okbutton.Click += new System.EventHandler(this.Okbutton_Click);
            // 
            // DefineClassListBox
            // 
            this.DefineClassListBox.FormattingEnabled = true;
            this.DefineClassListBox.ItemHeight = 16;
            this.DefineClassListBox.Location = new System.Drawing.Point(12, 76);
            this.DefineClassListBox.Name = "DefineClassListBox";
            this.DefineClassListBox.Size = new System.Drawing.Size(250, 132);
            this.DefineClassListBox.TabIndex = 3;
            this.DefineClassListBox.SelectedIndexChanged += new System.EventHandler(this.DefineClasslistBox_SelectedIndexChanged);
            // 
            // ObjectlistBox
            // 
            this.ObjectlistBox.FormattingEnabled = true;
            this.ObjectlistBox.ItemHeight = 16;
            this.ObjectlistBox.Location = new System.Drawing.Point(268, 76);
            this.ObjectlistBox.Name = "ObjectlistBox";
            this.ObjectlistBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ObjectlistBox.Size = new System.Drawing.Size(245, 132);
            this.ObjectlistBox.TabIndex = 4;
            this.ObjectlistBox.SelectedIndexChanged += new System.EventHandler(this.ObjectlistBox_SelectedIndexChanged);
            // 
            // DecissionlistBox
            // 
            this.DecissionlistBox.FormattingEnabled = true;
            this.DecissionlistBox.ItemHeight = 16;
            this.DecissionlistBox.Location = new System.Drawing.Point(519, 76);
            this.DecissionlistBox.Name = "DecissionlistBox";
            this.DecissionlistBox.Size = new System.Drawing.Size(211, 132);
            this.DecissionlistBox.TabIndex = 4;
            this.DecissionlistBox.SelectedIndexChanged += new System.EventHandler(this.DecissionlistBox_SelectedIndexChanged);
            // 
            // PermissionUserlistBox
            // 
            this.PermissionUserlistBox.FormattingEnabled = true;
            this.PermissionUserlistBox.ItemHeight = 16;
            this.PermissionUserlistBox.Location = new System.Drawing.Point(12, 243);
            this.PermissionUserlistBox.Name = "PermissionUserlistBox";
            this.PermissionUserlistBox.Size = new System.Drawing.Size(718, 164);
            this.PermissionUserlistBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "UserName:";
            // 
            // labelDefineClassList
            // 
            this.labelDefineClassList.AutoSize = true;
            this.labelDefineClassList.Location = new System.Drawing.Point(12, 57);
            this.labelDefineClassList.Name = "labelDefineClassList";
            this.labelDefineClassList.Size = new System.Drawing.Size(106, 16);
            this.labelDefineClassList.TabIndex = 5;
            this.labelDefineClassList.Text = "Define Class List:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Object List:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "DecissionList:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "UserName";
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(268, 53);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(93, 20);
            this.checkBoxAll.TabIndex = 6;
            this.checkBoxAll.Text = "checkBoxAll";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxNone
            // 
            this.checkBoxNone.AutoSize = true;
            this.checkBoxNone.Location = new System.Drawing.Point(367, 53);
            this.checkBoxNone.Name = "checkBoxNone";
            this.checkBoxNone.Size = new System.Drawing.Size(108, 20);
            this.checkBoxNone.TabIndex = 6;
            this.checkBoxNone.Text = "checkBoxNone";
            this.checkBoxNone.UseVisualStyleBackColor = true;
            this.checkBoxNone.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // JPermissionSetUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 451);
            this.Controls.Add(this.checkBoxNone);
            this.Controls.Add(this.checkBoxAll);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelDefineClassList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PermissionUserlistBox);
            this.Controls.Add(this.DecissionlistBox);
            this.Controls.Add(this.ObjectlistBox);
            this.Controls.Add(this.DefineClassListBox);
            this.Controls.Add(this.Okbutton);
            this.Controls.Add(this.Deletebutton);
            this.Controls.Add(this.Insertbutton);
            this.Name = "JPermissionSetUserForm";
            this.Text = "PermissionSetUserForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Insertbutton;
        private System.Windows.Forms.Button Deletebutton;
        private System.Windows.Forms.Button Okbutton;
        private System.Windows.Forms.ListBox DefineClassListBox;
        private System.Windows.Forms.ListBox ObjectlistBox;
        private System.Windows.Forms.ListBox DecissionlistBox;
        private System.Windows.Forms.ListBox PermissionUserlistBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDefineClassList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.CheckBox checkBoxNone;
    }
}