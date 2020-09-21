namespace RealEstate
{
    partial class JSearchUnitForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumber = new ClassLibrary.TextEdit(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbFloor = new ClassLibrary.JComboBox(this.components);
            this.txtPlaque = new ClassLibrary.TextEdit(this.components);
            this.cmbConstructionName = new ClassLibrary.JComboBox(this.components);
            this.cmbType = new ClassLibrary.JComboBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grdUnits = new ClassLibrary.JDataGrid();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNumber);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cmbFloor);
            this.groupBox1.Controls.Add(this.txtPlaque);
            this.groupBox1.Controls.Add(this.cmbConstructionName);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 183);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "شماره واحد:";
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumber.ChangeColorIfNotEmpty = false;
            this.txtNumber.ChangeColorOnEnter = true;
            this.txtNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumber.Location = new System.Drawing.Point(326, 145);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Negative = true;
            this.txtNumber.NotEmpty = false;
            this.txtNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumber.SelectOnEnter = true;
            this.txtNumber.Size = new System.Drawing.Size(149, 23);
            this.txtNumber.TabIndex = 29;
            this.txtNumber.TextMode = ClassLibrary.TextModes.Text;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 148);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbFloor
            // 
            this.cmbFloor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFloor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbFloor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFloor.BaseCode = 0;
            this.cmbFloor.ChangeColorIfNotEmpty = true;
            this.cmbFloor.ChangeColorOnEnter = true;
            this.cmbFloor.FormattingEnabled = true;
            this.cmbFloor.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbFloor.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFloor.Location = new System.Drawing.Point(326, 86);
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.NotEmpty = false;
            this.cmbFloor.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbFloor.SelectOnEnter = true;
            this.cmbFloor.Size = new System.Drawing.Size(149, 24);
            this.cmbFloor.TabIndex = 23;
            // 
            // txtPlaque
            // 
            this.txtPlaque.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaque.ChangeColorIfNotEmpty = false;
            this.txtPlaque.ChangeColorOnEnter = true;
            this.txtPlaque.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPlaque.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPlaque.Location = new System.Drawing.Point(326, 116);
            this.txtPlaque.Name = "txtPlaque";
            this.txtPlaque.Negative = true;
            this.txtPlaque.NotEmpty = false;
            this.txtPlaque.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPlaque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlaque.SelectOnEnter = true;
            this.txtPlaque.Size = new System.Drawing.Size(149, 23);
            this.txtPlaque.TabIndex = 21;
            this.txtPlaque.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbConstructionName
            // 
            this.cmbConstructionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConstructionName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbConstructionName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbConstructionName.BackColor = System.Drawing.SystemColors.Info;
            this.cmbConstructionName.BaseCode = 0;
            this.cmbConstructionName.ChangeColorIfNotEmpty = true;
            this.cmbConstructionName.ChangeColorOnEnter = true;
            this.cmbConstructionName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbConstructionName.FormattingEnabled = true;
            this.cmbConstructionName.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbConstructionName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbConstructionName.Location = new System.Drawing.Point(218, 26);
            this.cmbConstructionName.Name = "cmbConstructionName";
            this.cmbConstructionName.NotEmpty = false;
            this.cmbConstructionName.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbConstructionName.SelectOnEnter = true;
            this.cmbConstructionName.Size = new System.Drawing.Size(257, 24);
            this.cmbConstructionName.TabIndex = 18;
            this.cmbConstructionName.SelectedIndexChanged += new System.EventHandler(this.cmbConstructionName_SelectedIndexChanged);
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbType.BackColor = System.Drawing.SystemColors.Info;
            this.cmbType.BaseCode = 0;
            this.cmbType.ChangeColorIfNotEmpty = true;
            this.cmbType.ChangeColorOnEnter = true;
            this.cmbType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbType.Location = new System.Drawing.Point(218, 56);
            this.cmbType.Name = "cmbType";
            this.cmbType.NotEmpty = false;
            this.cmbType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbType.SelectOnEnter = true;
            this.cmbType.Size = new System.Drawing.Size(257, 24);
            this.cmbType.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(489, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 16);
            this.label8.TabIndex = 27;
            this.label8.Text = "شماره شناسایی:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(489, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "نوع واحد:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "نام مجتمع/بازار:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(489, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "طبقه:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 453);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 42);
            this.panel1.TabIndex = 2;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(507, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // grdUnits
            // 
            this.grdUnits.ActionMenu = jPopupMenu1;
            this.grdUnits.AllowUserToAddRows = false;
            this.grdUnits.AllowUserToDeleteRows = false;
            this.grdUnits.AllowUserToOrderColumns = true;
            this.grdUnits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUnits.EnableContexMenu = true;
            this.grdUnits.KeyName = null;
            this.grdUnits.Location = new System.Drawing.Point(0, 183);
            this.grdUnits.Name = "grdUnits";
            this.grdUnits.ReadHeadersFromDB = false;
            this.grdUnits.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdUnits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUnits.ShowRowNumber = true;
            this.grdUnits.Size = new System.Drawing.Size(594, 270);
            this.grdUnits.TabIndex = 3;
            this.grdUnits.TableName = null;
            this.grdUnits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUnits_CellDoubleClick);
            // 
            // JSearchUnitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 495);
            this.Controls.Add(this.grdUnits);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "JSearchUnitForm";
            this.Text = "SearchUnit";
            this.Load += new System.EventHandler(this.JSearchUnitForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUnits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private ClassLibrary.JDataGrid grdUnits;
        private ClassLibrary.JComboBox cmbFloor;
        private ClassLibrary.TextEdit txtPlaque;
        private ClassLibrary.JComboBox cmbConstructionName;
        private ClassLibrary.JComboBox cmbType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnOK;
        private ClassLibrary.TextEdit txtNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEdit;
    }
}