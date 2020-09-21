namespace Meeting
{
    partial class JCommissionPersonsForm
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
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCommission = new ClassLibrary.JComboBox(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.jdgvVicarious = new ClassLibrary.JDataGrid();
            this.btndelClient = new System.Windows.Forms.Button();
            this.btnaddClient = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvVicarious)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 17);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "کمیسیون:";
            // 
            // cmbCommission
            // 
            this.cmbCommission.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCommission.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCommission.BaseCode = 0;
            this.cmbCommission.ChangeColorIfNotEmpty = true;
            this.cmbCommission.ChangeColorOnEnter = true;
            this.cmbCommission.FormattingEnabled = true;
            this.cmbCommission.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCommission.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCommission.Location = new System.Drawing.Point(85, 13);
            this.cmbCommission.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCommission.Name = "cmbCommission";
            this.cmbCommission.NotEmpty = false;
            this.cmbCommission.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCommission.SelectOnEnter = true;
            this.cmbCommission.Size = new System.Drawing.Size(140, 24);
            this.cmbCommission.TabIndex = 36;
            this.cmbCommission.SelectedIndexChanged += new System.EventHandler(this.cmbCommission_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.jdgvVicarious);
            this.groupBox6.Controls.Add(this.btndelClient);
            this.groupBox6.Controls.Add(this.btnaddClient);
            this.groupBox6.Location = new System.Drawing.Point(12, 44);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(559, 364);
            this.groupBox6.TabIndex = 38;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "لیست افراد";
            // 
            // jdgvVicarious
            // 
            this.jdgvVicarious.ActionMenu = jPopupMenu1;
            this.jdgvVicarious.AllowUserToAddRows = false;
            this.jdgvVicarious.AllowUserToDeleteRows = false;
            this.jdgvVicarious.AllowUserToOrderColumns = true;
            this.jdgvVicarious.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jdgvVicarious.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvVicarious.EnableContexMenu = true;
            this.jdgvVicarious.KeyName = null;
            this.jdgvVicarious.Location = new System.Drawing.Point(7, 18);
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
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(19, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(477, 414);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 40;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(95, 415);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 39;
            this.btnSaveClose.Text = "ذخیره ";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // JCommissionPersonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 447);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCommission);
            this.Name = "JCommissionPersonsForm";
            this.Text = "CommissionPersonsForm";
            this.Load += new System.EventHandler(this.JCommissionPersonsForm_Load);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvVicarious)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private ClassLibrary.JComboBox cmbCommission;
        private System.Windows.Forms.GroupBox groupBox6;
        private ClassLibrary.JDataGrid jdgvVicarious;
        private System.Windows.Forms.Button btndelClient;
        private System.Windows.Forms.Button btnaddClient;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveClose;
    }
}