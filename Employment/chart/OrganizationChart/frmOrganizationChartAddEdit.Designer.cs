namespace Employment
{
    partial class JfrmOrganizationChartAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JfrmOrganizationChartAddEdit));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbJobMetier = new ClassLibrary.JComboBox(this.components);
            this.cmbPost = new ClassLibrary.JComboBox(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.cmbsecretariat = new ClassLibrary.JComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.rdo_Is_Not_Unit = new System.Windows.Forms.RadioButton();
            this.rdo_Is_Unit = new System.Windows.Forms.RadioButton();
            this.btnUser = new System.Windows.Forms.Button();
            this.cmbUsers = new ClassLibrary.JComboBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(448, 256);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbJobMetier);
            this.tabPage1.Controls.Add(this.cmbPost);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.cmbsecretariat);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.rdo_Is_Not_Unit);
            this.tabPage1.Controls.Add(this.rdo_Is_Unit);
            this.tabPage1.Controls.Add(this.btnUser);
            this.tabPage1.Controls.Add(this.cmbUsers);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(440, 227);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "نود چارت سازمانی";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbJobMetier
            // 
            this.cmbJobMetier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbJobMetier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbJobMetier.BaseCode = 0;
            this.cmbJobMetier.ChangeColorIfNotEmpty = true;
            this.cmbJobMetier.ChangeColorOnEnter = true;
            this.cmbJobMetier.FormattingEnabled = true;
            this.cmbJobMetier.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbJobMetier.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbJobMetier.Location = new System.Drawing.Point(13, 71);
            this.cmbJobMetier.Name = "cmbJobMetier";
            this.cmbJobMetier.NotEmpty = false;
            this.cmbJobMetier.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbJobMetier.SelectOnEnter = true;
            this.cmbJobMetier.Size = new System.Drawing.Size(315, 24);
            this.cmbJobMetier.TabIndex = 2;
            this.cmbJobMetier.SelectedIndexChanged += new System.EventHandler(this.cmbJobMetier_SelectedIndexChanged);
            // 
            // cmbPost
            // 
            this.cmbPost.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPost.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPost.BaseCode = 0;
            this.cmbPost.ChangeColorIfNotEmpty = true;
            this.cmbPost.ChangeColorOnEnter = true;
            this.cmbPost.FormattingEnabled = true;
            this.cmbPost.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbPost.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbPost.Location = new System.Drawing.Point(13, 42);
            this.cmbPost.Name = "cmbPost";
            this.cmbPost.NotEmpty = false;
            this.cmbPost.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbPost.SelectOnEnter = true;
            this.cmbPost.Size = new System.Drawing.Size(315, 24);
            this.cmbPost.TabIndex = 1;
            this.cmbPost.SelectedIndexChanged += new System.EventHandler(this.cmbPost_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnAction);
            this.panel1.Location = new System.Drawing.Point(0, 178);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(440, 49);
            this.panel1.TabIndex = 43;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(3, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 40);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(297, 6);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(140, 40);
            this.btnAction.TabIndex = 5;
            this.btnAction.Text = "Action";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // cmbsecretariat
            // 
            this.cmbsecretariat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbsecretariat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbsecretariat.BaseCode = 0;
            this.cmbsecretariat.ChangeColorIfNotEmpty = true;
            this.cmbsecretariat.ChangeColorOnEnter = true;
            this.cmbsecretariat.FormattingEnabled = true;
            this.cmbsecretariat.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbsecretariat.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbsecretariat.Location = new System.Drawing.Point(18, 130);
            this.cmbsecretariat.Name = "cmbsecretariat";
            this.cmbsecretariat.NotEmpty = false;
            this.cmbsecretariat.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbsecretariat.SelectOnEnter = true;
            this.cmbsecretariat.Size = new System.Drawing.Size(310, 24);
            this.cmbsecretariat.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "secretariat:";
            // 
            // rdo_Is_Not_Unit
            // 
            this.rdo_Is_Not_Unit.AutoSize = true;
            this.rdo_Is_Not_Unit.Checked = true;
            this.rdo_Is_Not_Unit.Location = new System.Drawing.Point(243, 102);
            this.rdo_Is_Not_Unit.Name = "rdo_Is_Not_Unit";
            this.rdo_Is_Not_Unit.Size = new System.Drawing.Size(85, 20);
            this.rdo_Is_Not_Unit.TabIndex = 6;
            this.rdo_Is_Not_Unit.TabStop = true;
            this.rdo_Is_Not_Unit.Text = "Is Not Unit";
            this.rdo_Is_Not_Unit.UseVisualStyleBackColor = true;
            // 
            // rdo_Is_Unit
            // 
            this.rdo_Is_Unit.AutoSize = true;
            this.rdo_Is_Unit.Location = new System.Drawing.Point(184, 102);
            this.rdo_Is_Unit.Name = "rdo_Is_Unit";
            this.rdo_Is_Unit.Size = new System.Drawing.Size(48, 20);
            this.rdo_Is_Unit.TabIndex = 7;
            this.rdo_Is_Unit.Text = "Unit";
            this.rdo_Is_Unit.UseVisualStyleBackColor = true;
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(13, 13);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(28, 23);
            this.btnUser.TabIndex = 9;
            this.btnUser.TabStop = false;
            this.btnUser.Text = "...";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // cmbUsers
            // 
            this.cmbUsers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUsers.BaseCode = 0;
            this.cmbUsers.ChangeColorIfNotEmpty = true;
            this.cmbUsers.ChangeColorOnEnter = true;
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbUsers.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbUsers.Location = new System.Drawing.Point(47, 13);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.NotEmpty = false;
            this.cmbUsers.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbUsers.SelectOnEnter = true;
            this.cmbUsers.Size = new System.Drawing.Size(281, 24);
            this.cmbUsers.TabIndex = 0;
            this.cmbUsers.SelectedValueChanged += new System.EventHandler(this.cmbUsers_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "MetierTopic:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "PostTitle:";
            // 
            // JfrmOrganizationChartAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(448, 256);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JfrmOrganizationChartAddEdit";
            this.Text = "نود چارت سازمانی";
            this.Load += new System.EventHandler(this.JfrmOrganizationChartAddEdit_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ClassLibrary.JComboBox cmbsecretariat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.RadioButton rdo_Is_Not_Unit;
        private System.Windows.Forms.RadioButton rdo_Is_Unit;
        private System.Windows.Forms.Button btnUser;
        private ClassLibrary.JComboBox cmbUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private ClassLibrary.JComboBox cmbJobMetier;
        private ClassLibrary.JComboBox cmbPost;

    }
}
