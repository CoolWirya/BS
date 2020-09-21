namespace Meeting
{
    partial class JMeetingForm
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
            ClassLibrary.JPopupMenu jPopupMenu5 = new ClassLibrary.JPopupMenu();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.jdgvVicarious = new ClassLibrary.JDataGrid();
            this.btndelClient = new System.Windows.Forms.Button();
            this.btnaddClient = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCommission = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSubject = new ClassLibrary.JComboBox(this.components);
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvVicarious)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(20, 438);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(478, 437);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 46;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(96, 438);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 45;
            this.btnSaveClose.Text = "ذخیره ";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.jdgvVicarious);
            this.groupBox6.Controls.Add(this.btndelClient);
            this.groupBox6.Controls.Add(this.btnaddClient);
            this.groupBox6.Location = new System.Drawing.Point(6, 68);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(559, 364);
            this.groupBox6.TabIndex = 44;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "لیست افراد";
            // 
            // jdgvVicarious
            // 
            this.jdgvVicarious.ActionMenu = jPopupMenu5;
            this.jdgvVicarious.AllowUserToAddRows = false;
            this.jdgvVicarious.AllowUserToDeleteRows = false;
            this.jdgvVicarious.AllowUserToOrderColumns = true;
            this.jdgvVicarious.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jdgvVicarious.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvVicarious.EnableContexMenu = true;
            this.jdgvVicarious.KeyName = null;
            this.jdgvVicarious.Location = new System.Drawing.Point(6, 16);
            this.jdgvVicarious.Name = "jdgvVicarious";
            this.jdgvVicarious.ReadHeadersFromDB = false;
            this.jdgvVicarious.ReadOnly = true;
            this.jdgvVicarious.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvVicarious.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvVicarious.ShowRowNumber = true;
            this.jdgvVicarious.Size = new System.Drawing.Size(547, 311);
            this.jdgvVicarious.TabIndex = 16;
            this.jdgvVicarious.TableName = null;
            // 
            // btndelClient
            // 
            this.btndelClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelClient.Location = new System.Drawing.Point(397, 333);
            this.btndelClient.Name = "btndelClient";
            this.btndelClient.Size = new System.Drawing.Size(75, 25);
            this.btndelClient.TabIndex = 13;
            this.btndelClient.Text = "حذف";
            this.btndelClient.UseVisualStyleBackColor = true;
            this.btndelClient.Click += new System.EventHandler(this.btndelClient_Click);
            // 
            // btnaddClient
            // 
            this.btnaddClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnaddClient.Location = new System.Drawing.Point(477, 333);
            this.btnaddClient.Name = "btnaddClient";
            this.btnaddClient.Size = new System.Drawing.Size(75, 25);
            this.btnaddClient.TabIndex = 14;
            this.btnaddClient.Text = "اضافه";
            this.btnaddClient.UseVisualStyleBackColor = true;
            this.btnaddClient.Click += new System.EventHandler(this.btnaddClient_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 10);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 43;
            this.label3.Text = "کمیسیون:";
            // 
            // cmbCommission
            // 
            this.cmbCommission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCommission.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCommission.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCommission.BaseCode = 0;
            this.cmbCommission.ChangeColorIfNotEmpty = true;
            this.cmbCommission.ChangeColorOnEnter = true;
            this.cmbCommission.FormattingEnabled = true;
            this.cmbCommission.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCommission.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCommission.Location = new System.Drawing.Point(75, 6);
            this.cmbCommission.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCommission.Name = "cmbCommission";
            this.cmbCommission.NotEmpty = false;
            this.cmbCommission.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCommission.SelectOnEnter = true;
            this.cmbCommission.Size = new System.Drawing.Size(180, 24);
            this.cmbCommission.TabIndex = 42;
            this.cmbCommission.SelectedIndexChanged += new System.EventHandler(this.cmbCommission_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 41);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "موضوع:";
            // 
            // cmbSubject
            // 
            this.cmbSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSubject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSubject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubject.BaseCode = 0;
            this.cmbSubject.ChangeColorIfNotEmpty = true;
            this.cmbSubject.ChangeColorOnEnter = true;
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbSubject.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSubject.Location = new System.Drawing.Point(75, 37);
            this.cmbSubject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.NotEmpty = false;
            this.cmbSubject.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbSubject.SelectOnEnter = true;
            this.cmbSubject.Size = new System.Drawing.Size(335, 24);
            this.cmbSubject.TabIndex = 48;
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(310, 6);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 50;
            this.label2.Text = "تاریخ :";
            // 
            // JMeetingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 468);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCommission);
            this.Name = "JMeetingForm";
            this.Text = "MeetingForm";
            this.Load += new System.EventHandler(this.JMeetingForm_Load);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvVicarious)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.GroupBox groupBox6;
        private ClassLibrary.JDataGrid jdgvVicarious;
        private System.Windows.Forms.Button btndelClient;
        private System.Windows.Forms.Button btnaddClient;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.JComboBox cmbCommission;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JComboBox cmbSubject;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label2;
    }
}