namespace ArchivedDocuments
{
    partial class JRequestArchiveFileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JRequestArchiveFileForm));
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRequestDate = new ClassLibrary.DateEdit(this.components);
            this.jdgRequestList = new ClassLibrary.JDataGrid();
            this.lblRequester = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.juC_ReferHistory = new Automation.JUC_ReferHistory();
            this.RegisterDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArchiveFileDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Confirm_Post_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Confirm_Full_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Confirm_User_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArchiveCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgRequestList)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 374);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 60);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(396, 16);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(111, 33);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(513, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 33);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "ثبت درخواست";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(28, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 32);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(642, 374);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(634, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "درخواست فایل";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtRequestDate);
            this.groupBox2.Controls.Add(this.jdgRequestList);
            this.groupBox2.Controls.Add(this.lblRequester);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(628, 339);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "تاریخ درخواست :";
            // 
            // txtRequestDate
            // 
            this.txtRequestDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequestDate.ChangeColorIfNotEmpty = true;
            this.txtRequestDate.ChangeColorOnEnter = true;
            this.txtRequestDate.Date = new System.DateTime(((long)(0)));
            this.txtRequestDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtRequestDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRequestDate.InsertInDatesTable = true;
            this.txtRequestDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtRequestDate.Location = new System.Drawing.Point(410, 50);
            this.txtRequestDate.Mask = "0000/00/00";
            this.txtRequestDate.Name = "txtRequestDate";
            this.txtRequestDate.NotEmpty = false;
            this.txtRequestDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtRequestDate.ReadOnly = true;
            this.txtRequestDate.Size = new System.Drawing.Size(100, 23);
            this.txtRequestDate.TabIndex = 46;
            // 
            // jdgRequestList
            // 
            this.jdgRequestList.ActionMenu = jPopupMenu1;
            this.jdgRequestList.AllowUserToAddRows = false;
            this.jdgRequestList.AllowUserToDeleteRows = false;
            this.jdgRequestList.AllowUserToOrderColumns = true;
            this.jdgRequestList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgRequestList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgRequestList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RegisterDate,
            this.Subject,
            this.ArchiveFileDesc,
            this.Code,
            this.RequestCode,
            this.Confirm_Post_Code,
            this.Confirm_Full_Title,
            this.Confirm_User_Code,
            this.StartDate,
            this.EndDate,
            this.Description,
            this.ArchiveCode});
            this.jdgRequestList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.jdgRequestList.EnableContexMenu = true;
            this.jdgRequestList.KeyName = null;
            this.jdgRequestList.Location = new System.Drawing.Point(3, 95);
            this.jdgRequestList.Name = "jdgRequestList";
            this.jdgRequestList.ReadHeadersFromDB = false;
            this.jdgRequestList.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgRequestList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgRequestList.ShowRowNumber = true;
            this.jdgRequestList.Size = new System.Drawing.Size(622, 241);
            this.jdgRequestList.TabIndex = 41;
            this.jdgRequestList.TableName = null;
            this.jdgRequestList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jdgRequestList_CellDoubleClick);
            // 
            // lblRequester
            // 
            this.lblRequester.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRequester.AutoSize = true;
            this.lblRequester.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRequester.ForeColor = System.Drawing.Color.Red;
            this.lblRequester.Location = new System.Drawing.Point(452, 19);
            this.lblRequester.Name = "lblRequester";
            this.lblRequester.Size = new System.Drawing.Size(135, 17);
            this.lblRequester.TabIndex = 45;
            this.lblRequester.Text = "نام درخواست کننده";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.juC_ReferHistory);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(634, 345);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "درخت ارجاعات";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // juC_ReferHistory
            // 
            this.juC_ReferHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.juC_ReferHistory.Location = new System.Drawing.Point(0, 0);
            this.juC_ReferHistory.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.juC_ReferHistory.Name = "juC_ReferHistory";
            this.juC_ReferHistory.ReferGroup = null;
            this.juC_ReferHistory.Size = new System.Drawing.Size(634, 345);
            this.juC_ReferHistory.TabIndex = 1;
            // 
            // RegisterDate
            // 
            this.RegisterDate.HeaderText = "تاریخ درخواست";
            this.RegisterDate.Name = "RegisterDate";
            this.RegisterDate.Visible = false;
            this.RegisterDate.Width = 117;
            // 
            // Subject
            // 
            this.Subject.HeaderText = "موضوع";
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            this.Subject.Width = 70;
            // 
            // ArchiveFileDesc
            // 
            this.ArchiveFileDesc.HeaderText = "توضیح فایل آرشیو";
            this.ArchiveFileDesc.Name = "ArchiveFileDesc";
            this.ArchiveFileDesc.ReadOnly = true;
            this.ArchiveFileDesc.Width = 118;
            // 
            // Code
            // 
            this.Code.HeaderText = "کد";
            this.Code.Name = "Code";
            this.Code.Visible = false;
            this.Code.Width = 46;
            // 
            // RequestCode
            // 
            this.RequestCode.HeaderText = "کد درخواست";
            this.RequestCode.Name = "RequestCode";
            this.RequestCode.Visible = false;
            this.RequestCode.Width = 96;
            // 
            // Confirm_Post_Code
            // 
            this.Confirm_Post_Code.HeaderText = "Column1";
            this.Confirm_Post_Code.Name = "Confirm_Post_Code";
            this.Confirm_Post_Code.Visible = false;
            this.Confirm_Post_Code.Width = 83;
            // 
            // Confirm_Full_Title
            // 
            this.Confirm_Full_Title.HeaderText = "عنوان تایید کننده";
            this.Confirm_Full_Title.Name = "Confirm_Full_Title";
            this.Confirm_Full_Title.ReadOnly = true;
            this.Confirm_Full_Title.Width = 115;
            // 
            // Confirm_User_Code
            // 
            this.Confirm_User_Code.HeaderText = "Column1";
            this.Confirm_User_Code.Name = "Confirm_User_Code";
            this.Confirm_User_Code.Visible = false;
            this.Confirm_User_Code.Width = 83;
            // 
            // StartDate
            // 
            dataGridViewCellStyle1.Format = "---/--/--";
            dataGridViewCellStyle1.NullValue = "---/--/--";
            this.StartDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.StartDate.HeaderText = "تاریخ شروع";
            this.StartDate.Name = "StartDate";
            this.StartDate.Width = 87;
            // 
            // EndDate
            // 
            this.EndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = "/  /";
            this.EndDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.EndDate.HeaderText = "تاریخ پایان";
            this.EndDate.Name = "EndDate";
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "توضیح";
            this.Description.Name = "Description";
            // 
            // ArchiveCode
            // 
            this.ArchiveCode.HeaderText = "ArchiveCode";
            this.ArchiveCode.Name = "ArchiveCode";
            this.ArchiveCode.ReadOnly = true;
            this.ArchiveCode.Visible = false;
            this.ArchiveCode.Width = 104;
            // 
            // JRequestArchiveFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 434);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JRequestArchiveFileForm";
            this.Text = "RequestArchiveFileForm";
            this.Load += new System.EventHandler(this.JRequestArchiveFileForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgRequestList)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPage3;
        private Automation.JUC_ReferHistory juC_ReferHistory;
        private System.Windows.Forms.Label lblRequester;
        private ClassLibrary.JDataGrid jdgRequestList;
        private ClassLibrary.DateEdit txtRequestDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArchiveFileDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Confirm_Post_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Confirm_Full_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Confirm_User_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArchiveCode;
    }
}