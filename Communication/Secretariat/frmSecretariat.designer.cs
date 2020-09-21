namespace Communication
{
    partial class JfrmSecretariat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JfrmSecretariat));
            this.Savebutton = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SecPropertiestabPage = new System.Windows.Forms.TabPage();
            this.txtSuffix = new ClassLibrary.TextEdit(this.components);
            this.txtPrifix = new ClassLibrary.TextEdit(this.components);
            this.cdbOrganiztionChartPerson = new ClassLibrary.JCodingBox();
            this.cmbStorageLetterNo = new ClassLibrary.JComboBox(this.components);
            this.txtSecretariatName = new ClassLibrary.TextEdit(this.components);
            this.lblSuffix = new System.Windows.Forms.Label();
            this.lblPrifix = new System.Windows.Forms.Label();
            this.lblStotageLetterNo = new System.Windows.Forms.Label();
            this.lblSecetariatManager = new System.Windows.Forms.Label();
            this.btnShowOrganazationChart = new System.Windows.Forms.Button();
            this.labelConstSecretariatName = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.jdgvPersons = new System.Windows.Forms.DataGridView();
            this.SecPropertiestabPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvPersons)).BeginInit();
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
            // Savebutton
            // 
            this.Savebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Savebutton.Location = new System.Drawing.Point(15, 288);
            this.Savebutton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(93, 26);
            this.Savebutton.TabIndex = 11;
            this.Savebutton.Text = "OK";
            this.Savebutton.UseVisualStyleBackColor = true;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(424, 288);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 26);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SecPropertiestabPage
            // 
            this.SecPropertiestabPage.Controls.Add(this.txtSuffix);
            this.SecPropertiestabPage.Controls.Add(this.txtPrifix);
            this.SecPropertiestabPage.Controls.Add(this.cdbOrganiztionChartPerson);
            this.SecPropertiestabPage.Controls.Add(this.cmbStorageLetterNo);
            this.SecPropertiestabPage.Controls.Add(this.txtSecretariatName);
            this.SecPropertiestabPage.Controls.Add(this.lblSuffix);
            this.SecPropertiestabPage.Controls.Add(this.lblPrifix);
            this.SecPropertiestabPage.Controls.Add(this.lblStotageLetterNo);
            this.SecPropertiestabPage.Controls.Add(this.lblSecetariatManager);
            this.SecPropertiestabPage.Controls.Add(this.btnShowOrganazationChart);
            this.SecPropertiestabPage.Controls.Add(this.labelConstSecretariatName);
            this.SecPropertiestabPage.Location = new System.Drawing.Point(4, 25);
            this.SecPropertiestabPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SecPropertiestabPage.Name = "SecPropertiestabPage";
            this.SecPropertiestabPage.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SecPropertiestabPage.Size = new System.Drawing.Size(505, 249);
            this.SecPropertiestabPage.TabIndex = 0;
            this.SecPropertiestabPage.Text = "Secretariat";
            this.SecPropertiestabPage.UseVisualStyleBackColor = true;
            // 
            // txtSuffix
            // 
            this.txtSuffix.ChangeColorIfNotEmpty = false;
            this.txtSuffix.ChangeColorOnEnter = true;
            this.txtSuffix.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSuffix.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSuffix.Location = new System.Drawing.Point(46, 50);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Negative = true;
            this.txtSuffix.NotEmpty = false;
            this.txtSuffix.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSuffix.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSuffix.SelectOnEnter = true;
            this.txtSuffix.Size = new System.Drawing.Size(100, 23);
            this.txtSuffix.TabIndex = 22;
            this.txtSuffix.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtPrifix
            // 
            this.txtPrifix.ChangeColorIfNotEmpty = false;
            this.txtPrifix.ChangeColorOnEnter = true;
            this.txtPrifix.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrifix.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrifix.Location = new System.Drawing.Point(296, 50);
            this.txtPrifix.Name = "txtPrifix";
            this.txtPrifix.Negative = true;
            this.txtPrifix.NotEmpty = false;
            this.txtPrifix.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrifix.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrifix.SelectOnEnter = true;
            this.txtPrifix.Size = new System.Drawing.Size(100, 23);
            this.txtPrifix.TabIndex = 21;
            this.txtPrifix.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cdbOrganiztionChartPerson
            // 
            this.cdbOrganiztionChartPerson.dataTable = null;
            this.cdbOrganiztionChartPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cdbOrganiztionChartPerson.Location = new System.Drawing.Point(27, 186);
            this.cdbOrganiztionChartPerson.Name = "cdbOrganiztionChartPerson";
            this.cdbOrganiztionChartPerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cdbOrganiztionChartPerson.SelectedIndex = -1;
            this.cdbOrganiztionChartPerson.SelectedValue = null;
            this.cdbOrganiztionChartPerson.Size = new System.Drawing.Size(364, 27);
            this.cdbOrganiztionChartPerson.TabIndex = 2;
            this.cdbOrganiztionChartPerson.Visible = false;
            // 
            // cmbStorageLetterNo
            // 
            this.cmbStorageLetterNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbStorageLetterNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStorageLetterNo.BaseCode = 0;
            this.cmbStorageLetterNo.ChangeColorIfNotEmpty = true;
            this.cmbStorageLetterNo.ChangeColorOnEnter = true;
            this.cmbStorageLetterNo.FormattingEnabled = true;
            this.cmbStorageLetterNo.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbStorageLetterNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbStorageLetterNo.Location = new System.Drawing.Point(226, 156);
            this.cmbStorageLetterNo.Name = "cmbStorageLetterNo";
            this.cmbStorageLetterNo.NotEmpty = false;
            this.cmbStorageLetterNo.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbStorageLetterNo.SelectOnEnter = true;
            this.cmbStorageLetterNo.Size = new System.Drawing.Size(165, 24);
            this.cmbStorageLetterNo.TabIndex = 4;
            this.cmbStorageLetterNo.Visible = false;
            // 
            // txtSecretariatName
            // 
            this.txtSecretariatName.ChangeColorIfNotEmpty = true;
            this.txtSecretariatName.ChangeColorOnEnter = true;
            this.txtSecretariatName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSecretariatName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSecretariatName.Location = new System.Drawing.Point(32, 21);
            this.txtSecretariatName.MaxLength = 150;
            this.txtSecretariatName.Name = "txtSecretariatName";
            this.txtSecretariatName.Negative = true;
            this.txtSecretariatName.NotEmpty = false;
            this.txtSecretariatName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSecretariatName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSecretariatName.SelectOnEnter = true;
            this.txtSecretariatName.Size = new System.Drawing.Size(364, 23);
            this.txtSecretariatName.TabIndex = 1;
            this.txtSecretariatName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // lblSuffix
            // 
            this.lblSuffix.AutoSize = true;
            this.lblSuffix.Location = new System.Drawing.Point(180, 50);
            this.lblSuffix.Name = "lblSuffix";
            this.lblSuffix.Size = new System.Drawing.Size(49, 16);
            this.lblSuffix.TabIndex = 20;
            this.lblSuffix.Text = "Suffix :";
            // 
            // lblPrifix
            // 
            this.lblPrifix.AutoSize = true;
            this.lblPrifix.Location = new System.Drawing.Point(457, 50);
            this.lblPrifix.Name = "lblPrifix";
            this.lblPrifix.Size = new System.Drawing.Size(45, 16);
            this.lblPrifix.TabIndex = 18;
            this.lblPrifix.Text = "Prifix :";
            // 
            // lblStotageLetterNo
            // 
            this.lblStotageLetterNo.AutoSize = true;
            this.lblStotageLetterNo.Location = new System.Drawing.Point(438, 159);
            this.lblStotageLetterNo.Name = "lblStotageLetterNo";
            this.lblStotageLetterNo.Size = new System.Drawing.Size(62, 16);
            this.lblStotageLetterNo.TabIndex = 16;
            this.lblStotageLetterNo.Text = "Storage :";
            this.lblStotageLetterNo.Visible = false;
            // 
            // lblSecetariatManager
            // 
            this.lblSecetariatManager.AutoSize = true;
            this.lblSecetariatManager.Location = new System.Drawing.Point(433, 192);
            this.lblSecetariatManager.Name = "lblSecetariatManager";
            this.lblSecetariatManager.Size = new System.Drawing.Size(67, 16);
            this.lblSecetariatManager.TabIndex = 15;
            this.lblSecetariatManager.Text = "Manager :";
            // 
            // btnShowOrganazationChart
            // 
            this.btnShowOrganazationChart.Location = new System.Drawing.Point(-2, 186);
            this.btnShowOrganazationChart.Name = "btnShowOrganazationChart";
            this.btnShowOrganazationChart.Size = new System.Drawing.Size(28, 23);
            this.btnShowOrganazationChart.TabIndex = 3;
            this.btnShowOrganazationChart.TabStop = false;
            this.btnShowOrganazationChart.Text = "...";
            this.btnShowOrganazationChart.UseVisualStyleBackColor = true;
            this.btnShowOrganazationChart.Visible = false;
            this.btnShowOrganazationChart.Click += new System.EventHandler(this.btnShowOrganazationChart_Click);
            // 
            // labelConstSecretariatName
            // 
            this.labelConstSecretariatName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelConstSecretariatName.AutoSize = true;
            this.labelConstSecretariatName.Location = new System.Drawing.Point(452, 24);
            this.labelConstSecretariatName.Name = "labelConstSecretariatName";
            this.labelConstSecretariatName.Size = new System.Drawing.Size(50, 16);
            this.labelConstSecretariatName.TabIndex = 10;
            this.labelConstSecretariatName.Text = "Name :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.SecPropertiestabPage);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(8, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(513, 278);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDeleteUser);
            this.tabPage1.Controls.Add(this.btnAddUser);
            this.tabPage1.Controls.Add(this.jdgvPersons);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(505, 249);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Users";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(343, 340);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteUser.TabIndex = 9;
            this.btnDeleteUser.Text = "Delete";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(424, 340);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 8;
            this.btnAddUser.Text = "Add";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // jdgvPersons
            // 
            this.jdgvPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvPersons.Location = new System.Drawing.Point(3, 3);
            this.jdgvPersons.Name = "jdgvPersons";
            this.jdgvPersons.Size = new System.Drawing.Size(499, 243);
            this.jdgvPersons.TabIndex = 0;
            // 
            // JfrmSecretariat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 324);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Savebutton);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "JfrmSecretariat";
            this.Text = "Secretariat Manager";
            this.Load += new System.EventHandler(this.JfrmSecretariat_Load);
            this.SecPropertiestabPage.ResumeLayout(false);
            this.SecPropertiestabPage.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvPersons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage SecPropertiestabPage;
        private System.Windows.Forms.Label labelConstSecretariatName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnShowOrganazationChart;
        private System.Windows.Forms.Label lblSecetariatManager;
        private System.Windows.Forms.Label lblPrifix;
        private System.Windows.Forms.Label lblStotageLetterNo;
        private System.Windows.Forms.Label lblSuffix;
        private ClassLibrary.TextEdit txtSecretariatName;
        private ClassLibrary.JComboBox cmbStorageLetterNo;
        private ClassLibrary.JCodingBox cdbOrganiztionChartPerson;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.DataGridView jdgvPersons;
        private ClassLibrary.TextEdit txtSuffix;
        private ClassLibrary.TextEdit txtPrifix;

    }
}