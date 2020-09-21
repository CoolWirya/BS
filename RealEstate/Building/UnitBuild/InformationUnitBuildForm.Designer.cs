namespace RealEstate
{
    partial class JInformationUnitBuildForm
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
            this.cmbTitle = new ClassLibrary.JComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.S = new System.Windows.Forms.Button();
            this.chkDefault = new System.Windows.Forms.CheckBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTel = new ClassLibrary.TextEdit(this.components);
            this.jdgvTel = new ClassLibrary.JDataGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvTel)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jdgvTel);
            this.groupBox1.Controls.Add(this.cmbTitle);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.S);
            this.groupBox1.Controls.Add(this.chkDefault);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 310);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbTitle
            // 
            this.cmbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTitle.BaseCode = 0;
            this.cmbTitle.ChangeColorIfNotEmpty = true;
            this.cmbTitle.ChangeColorOnEnter = true;
            this.cmbTitle.FormattingEnabled = true;
            this.cmbTitle.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbTitle.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTitle.Location = new System.Drawing.Point(390, 15);
            this.cmbTitle.Name = "cmbTitle";
            this.cmbTitle.NotEmpty = false;
            this.cmbTitle.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbTitle.SelectOnEnter = true;
            this.cmbTitle.Size = new System.Drawing.Size(139, 24);
            this.cmbTitle.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(534, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 116;
            this.label4.Text = "عنوان:";
            // 
            // S
            // 
            this.S.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.S.Location = new System.Drawing.Point(113, 53);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(75, 26);
            this.S.TabIndex = 5;
            this.S.Text = "اضافه ";
            this.S.UseVisualStyleBackColor = true;
            this.S.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkDefault
            // 
            this.chkDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDefault.AutoSize = true;
            this.chkDefault.Location = new System.Drawing.Point(69, 17);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(82, 20);
            this.chkDefault.TabIndex = 4;
            this.chkDefault.Text = "پیش فرض";
            this.chkDefault.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(32, 53);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 26);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "حذف";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 111;
            this.label1.Text = "تلفن:";
            // 
            // txtTel
            // 
            this.txtTel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTel.ChangeColorIfNotEmpty = false;
            this.txtTel.ChangeColorOnEnter = true;
            this.txtTel.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTel.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTel.Location = new System.Drawing.Point(172, 15);
            this.txtTel.Name = "txtTel";
            this.txtTel.Negative = true;
            this.txtTel.NotEmpty = false;
            this.txtTel.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTel.SelectOnEnter = true;
            this.txtTel.Size = new System.Drawing.Size(165, 23);
            this.txtTel.TabIndex = 3;
            this.txtTel.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // jdgvTel
            // 
            this.jdgvTel.ActionMenu = jPopupMenu1;
            this.jdgvTel.AllowUserToAddRows = false;
            this.jdgvTel.AllowUserToDeleteRows = false;
            this.jdgvTel.AllowUserToOrderColumns = true;
            this.jdgvTel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jdgvTel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvTel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvTel.EnableContexMenu = true;
            this.jdgvTel.KeyName = null;
            this.jdgvTel.Location = new System.Drawing.Point(6, 85);
            this.jdgvTel.Name = "jdgvTel";
            this.jdgvTel.ReadHeadersFromDB = false;
            this.jdgvTel.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvTel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvTel.ShowRowNumber = true;
            this.jdgvTel.Size = new System.Drawing.Size(577, 219);
            this.jdgvTel.TabIndex = 7;
            this.jdgvTel.TableName = null;
            this.jdgvTel.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.jdgvTel_CellValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnSaveClose);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 316);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(496, 15);
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
            this.btnExit.Location = new System.Drawing.Point(17, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(415, 15);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 14;
            this.btnSaveClose.Text = "ذخیره ";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // JInformationUnitBuildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 364);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JInformationUnitBuildForm";
            this.Text = "InformationUnitBuildForm";
            this.Load += new System.EventHandler(this.JInformationUnitBuildForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvTel)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button S;
        private System.Windows.Forms.Button btnDel;
        private ClassLibrary.JDataGrid jdgvTel;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtTel;
        private System.Windows.Forms.CheckBox chkDefault;
        private ClassLibrary.JComboBox cmbTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveClose;
    }
}