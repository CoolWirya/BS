namespace Meeting
{
    partial class JCommissionForm
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
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDelProgram = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbGroup = new ClassLibrary.JComboBox(this.components);
            this.jdgvProgram = new ClassLibrary.JDataGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.jdgvVicarious = new ClassLibrary.JDataGrid();
            this.btndelClient = new System.Windows.Forms.Button();
            this.btnaddClient = new System.Windows.Forms.Button();
            this.txtName = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvProgram)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvVicarious)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnSaveClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 410);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 49);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(497, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(40, 17);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(416, 17);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 17;
            this.btnSaveClose.Text = "ذخیره ";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(586, 365);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDelProgram);
            this.tabPage1.Controls.Add(this.btnAdd);
            this.tabPage1.Controls.Add(this.cmbGroup);
            this.tabPage1.Controls.Add(this.jdgvProgram);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(578, 336);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "مصوبه های کمیسیون";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDelProgram
            // 
            this.btnDelProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelProgram.Location = new System.Drawing.Point(105, 7);
            this.btnDelProgram.Name = "btnDelProgram";
            this.btnDelProgram.Size = new System.Drawing.Size(33, 24);
            this.btnDelProgram.TabIndex = 7;
            this.btnDelProgram.Text = "-";
            this.btnDelProgram.UseVisualStyleBackColor = true;
            this.btnDelProgram.Click += new System.EventHandler(this.btnDelProgram_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(144, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 24);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbGroup
            // 
            this.cmbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroup.BaseCode = 0;
            this.cmbGroup.ChangeColorIfNotEmpty = true;
            this.cmbGroup.ChangeColorOnEnter = true;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGroup.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGroup.Location = new System.Drawing.Point(183, 7);
            this.cmbGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.NotEmpty = false;
            this.cmbGroup.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGroup.SelectOnEnter = true;
            this.cmbGroup.Size = new System.Drawing.Size(328, 24);
            this.cmbGroup.TabIndex = 4;
            // 
            // jdgvProgram
            // 
            this.jdgvProgram.ActionMenu = jPopupMenu1;
            this.jdgvProgram.AllowUserToAddRows = false;
            this.jdgvProgram.AllowUserToDeleteRows = false;
            this.jdgvProgram.AllowUserToOrderColumns = true;
            this.jdgvProgram.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvProgram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvProgram.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.jdgvProgram.EnableContexMenu = true;
            this.jdgvProgram.KeyName = null;
            this.jdgvProgram.Location = new System.Drawing.Point(3, 41);
            this.jdgvProgram.Name = "jdgvProgram";
            this.jdgvProgram.ReadHeadersFromDB = false;
            this.jdgvProgram.ReadOnly = true;
            this.jdgvProgram.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvProgram.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvProgram.ShowRowNumber = true;
            this.jdgvProgram.Size = new System.Drawing.Size(572, 292);
            this.jdgvProgram.TabIndex = 9;
            this.jdgvProgram.TableName = null;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 10);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 62;
            this.label2.Text = "مصوبه:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(578, 336);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "اشخاص کمیسیون";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.jdgvVicarious);
            this.groupBox6.Controls.Add(this.btndelClient);
            this.groupBox6.Controls.Add(this.btnaddClient);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(572, 330);
            this.groupBox6.TabIndex = 40;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "لیست افراد";
            // 
            // jdgvVicarious
            // 
            this.jdgvVicarious.ActionMenu = jPopupMenu2;
            this.jdgvVicarious.AllowUserToAddRows = false;
            this.jdgvVicarious.AllowUserToDeleteRows = false;
            this.jdgvVicarious.AllowUserToOrderColumns = true;
            this.jdgvVicarious.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvVicarious.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvVicarious.Dock = System.Windows.Forms.DockStyle.Top;
            this.jdgvVicarious.EnableContexMenu = true;
            this.jdgvVicarious.KeyName = null;
            this.jdgvVicarious.Location = new System.Drawing.Point(3, 19);
            this.jdgvVicarious.Name = "jdgvVicarious";
            this.jdgvVicarious.ReadHeadersFromDB = false;
            this.jdgvVicarious.ReadOnly = true;
            this.jdgvVicarious.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvVicarious.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvVicarious.ShowRowNumber = true;
            this.jdgvVicarious.Size = new System.Drawing.Size(566, 270);
            this.jdgvVicarious.TabIndex = 16;
            this.jdgvVicarious.TableName = null;
            // 
            // btndelClient
            // 
            this.btndelClient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btndelClient.Location = new System.Drawing.Point(218, 296);
            this.btndelClient.Name = "btndelClient";
            this.btndelClient.Size = new System.Drawing.Size(75, 27);
            this.btndelClient.TabIndex = 15;
            this.btndelClient.Text = "حذف";
            this.btndelClient.UseVisualStyleBackColor = true;
            this.btndelClient.Click += new System.EventHandler(this.btndelClient_Click);
            // 
            // btnaddClient
            // 
            this.btnaddClient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnaddClient.Location = new System.Drawing.Point(298, 296);
            this.btnaddClient.Name = "btnaddClient";
            this.btnaddClient.Size = new System.Drawing.Size(75, 27);
            this.btnaddClient.TabIndex = 14;
            this.btnaddClient.Text = "اضافه";
            this.btnaddClient.UseVisualStyleBackColor = true;
            this.btnaddClient.Click += new System.EventHandler(this.btnaddClient_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.ChangeColorIfNotEmpty = true;
            this.txtName.ChangeColorOnEnter = true;
            this.txtName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(102, 11);
            this.txtName.Name = "txtName";
            this.txtName.Negative = true;
            this.txtName.NotEmpty = false;
            this.txtName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectOnEnter = true;
            this.txtName.Size = new System.Drawing.Size(328, 23);
            this.txtName.TabIndex = 1;
            this.txtName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 58;
            this.label1.Text = "نام کمیسیون:";
            // 
            // JCommissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 459);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "JCommissionForm";
            this.Text = "CommissionForm";
            this.Load += new System.EventHandler(this.JCommissionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvProgram)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvVicarious)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnDelProgram;
        private System.Windows.Forms.Button btnAdd;
        private ClassLibrary.JComboBox cmbGroup;
        private ClassLibrary.JDataGrid jdgvProgram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox6;
        private ClassLibrary.JDataGrid jdgvVicarious;
        private System.Windows.Forms.Button btndelClient;
        private System.Windows.Forms.Button btnaddClient;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveClose;
        private ClassLibrary.TextEdit txtName;
        private System.Windows.Forms.Label label1;

    }
}