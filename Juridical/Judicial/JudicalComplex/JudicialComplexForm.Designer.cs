namespace Legal
{
    partial class JJudicialComplexForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JJudicialComplexForm));
            this.Close = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new ClassLibrary.TextEdit(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSupervisorNameComplex = new ClassLibrary.TextEdit(this.components);
            this.txtFax = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtTel = new ClassLibrary.TextEdit(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAddress = new ClassLibrary.TextEdit(this.components);
            this.cmbCity = new ClassLibrary.JComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new ClassLibrary.TextEdit(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewBranch = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelBranch = new System.Windows.Forms.Button();
            this.btnEditBranch = new System.Windows.Forms.Button();
            this.btnAddBranch = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBranch)).BeginInit();
            this.panel2.SuspendLayout();
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
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.Location = new System.Drawing.Point(35, 7);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 1;
            this.Close.Text = "خروج";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.Location = new System.Drawing.Point(297, 7);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 0;
            this.Save.Text = "ذخیره";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "کد:";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.ChangeColorIfNotEmpty = true;
            this.txtCode.ChangeColorOnEnter = true;
            this.txtCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCode.Location = new System.Drawing.Point(234, 22);
            this.txtCode.Name = "txtCode";
            this.txtCode.Negative = true;
            this.txtCode.NotEmpty = false;
            this.txtCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCode.ReadOnly = true;
            this.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCode.SelectOnEnter = true;
            this.txtCode.Size = new System.Drawing.Size(152, 23);
            this.txtCode.TabIndex = 0;
            this.txtCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 52);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Close);
            this.panel1.Controls.Add(this.Save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 422);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 42);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(451, 370);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtSupervisorNameComplex);
            this.tabPage1.Controls.Add(this.txtFax);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtTel);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(443, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "مجتمع قضائی";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "نام سرپرست مجتمع:";
            // 
            // txtSupervisorNameComplex
            // 
            this.txtSupervisorNameComplex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSupervisorNameComplex.ChangeColorIfNotEmpty = false;
            this.txtSupervisorNameComplex.ChangeColorOnEnter = true;
            this.txtSupervisorNameComplex.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSupervisorNameComplex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSupervisorNameComplex.Location = new System.Drawing.Point(21, 81);
            this.txtSupervisorNameComplex.Name = "txtSupervisorNameComplex";
            this.txtSupervisorNameComplex.Negative = true;
            this.txtSupervisorNameComplex.NotEmpty = false;
            this.txtSupervisorNameComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSupervisorNameComplex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSupervisorNameComplex.SelectOnEnter = true;
            this.txtSupervisorNameComplex.Size = new System.Drawing.Size(265, 23);
            this.txtSupervisorNameComplex.TabIndex = 1;
            this.txtSupervisorNameComplex.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtFax
            // 
            this.txtFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFax.ChangeColorIfNotEmpty = true;
            this.txtFax.ChangeColorOnEnter = true;
            this.txtFax.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFax.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFax.Location = new System.Drawing.Point(246, 280);
            this.txtFax.Name = "txtFax";
            this.txtFax.Negative = true;
            this.txtFax.NotEmpty = false;
            this.txtFax.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFax.SelectOnEnter = true;
            this.txtFax.Size = new System.Drawing.Size(121, 23);
            this.txtFax.TabIndex = 3;
            this.txtFax.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "نام مجتمع قضائی:";
            // 
            // txtTel
            // 
            this.txtTel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTel.ChangeColorIfNotEmpty = true;
            this.txtTel.ChangeColorOnEnter = true;
            this.txtTel.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTel.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTel.Location = new System.Drawing.Point(45, 280);
            this.txtTel.Name = "txtTel";
            this.txtTel.Negative = true;
            this.txtTel.NotEmpty = false;
            this.txtTel.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTel.SelectOnEnter = true;
            this.txtTel.Size = new System.Drawing.Size(121, 23);
            this.txtTel.TabIndex = 4;
            this.txtTel.TextMode = ClassLibrary.TextModes.Text;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.cmbCity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 155);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "موقعیت";
            // 
            // txtAddress
            // 
            this.txtAddress.AcceptsReturn = true;
            this.txtAddress.ChangeColorIfNotEmpty = true;
            this.txtAddress.ChangeColorOnEnter = true;
            this.txtAddress.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAddress.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAddress.Location = new System.Drawing.Point(6, 59);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Negative = true;
            this.txtAddress.NotEmpty = false;
            this.txtAddress.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.SelectOnEnter = false;
            this.txtAddress.Size = new System.Drawing.Size(342, 90);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbCity
            // 
            this.cmbCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCity.BaseCode = 0;
            this.cmbCity.ChangeColorIfNotEmpty = true;
            this.cmbCity.ChangeColorOnEnter = true;
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCity.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCity.Location = new System.Drawing.Point(145, 25);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.NotEmpty = false;
            this.cmbCity.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCity.SelectOnEnter = true;
            this.cmbCity.Size = new System.Drawing.Size(208, 24);
            this.cmbCity.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(354, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "آدرس:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "شهر:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.ChangeColorIfNotEmpty = true;
            this.txtName.ChangeColorOnEnter = true;
            this.txtName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(21, 46);
            this.txtName.Name = "txtName";
            this.txtName.Negative = true;
            this.txtName.NotEmpty = false;
            this.txtName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectOnEnter = true;
            this.txtName.Size = new System.Drawing.Size(265, 23);
            this.txtName.TabIndex = 0;
            this.txtName.TextMode = ClassLibrary.TextModes.Text;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "تلفن:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(368, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "نمابر:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewBranch);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(443, 341);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "لیست شعب قضائی";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // dataGridViewBranch
            // 
            this.dataGridViewBranch.AllowUserToAddRows = false;
            this.dataGridViewBranch.AllowUserToDeleteRows = false;
            this.dataGridViewBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBranch.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewBranch.Name = "dataGridViewBranch";
            this.dataGridViewBranch.ReadOnly = true;
            this.dataGridViewBranch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBranch.Size = new System.Drawing.Size(437, 292);
            this.dataGridViewBranch.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelBranch);
            this.panel2.Controls.Add(this.btnEditBranch);
            this.panel2.Controls.Add(this.btnAddBranch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 295);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 43);
            this.panel2.TabIndex = 1;
            this.panel2.Visible = false;
            // 
            // btnDelBranch
            // 
            this.btnDelBranch.Location = new System.Drawing.Point(267, 6);
            this.btnDelBranch.Name = "btnDelBranch";
            this.btnDelBranch.Size = new System.Drawing.Size(47, 25);
            this.btnDelBranch.TabIndex = 5;
            this.btnDelBranch.Text = "حذف";
            this.btnDelBranch.UseVisualStyleBackColor = true;
            // 
            // btnEditBranch
            // 
            this.btnEditBranch.Location = new System.Drawing.Point(325, 6);
            this.btnEditBranch.Name = "btnEditBranch";
            this.btnEditBranch.Size = new System.Drawing.Size(57, 25);
            this.btnEditBranch.TabIndex = 4;
            this.btnEditBranch.Text = "ویرایش";
            this.btnEditBranch.UseVisualStyleBackColor = true;
            // 
            // btnAddBranch
            // 
            this.btnAddBranch.Location = new System.Drawing.Point(385, 6);
            this.btnAddBranch.Name = "btnAddBranch";
            this.btnAddBranch.Size = new System.Drawing.Size(47, 25);
            this.btnAddBranch.TabIndex = 3;
            this.btnAddBranch.Text = "اضافه";
            this.btnAddBranch.UseVisualStyleBackColor = true;
            this.btnAddBranch.Click += new System.EventHandler(this.btnAddBranch_Click);
            // 
            // JJudicialComplexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 464);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JJudicialComplexForm";
            this.Text = "مجتمع قضائی";
            this.Load += new System.EventHandler(this.JJudicialComplex_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBranch)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.TextEdit txtSupervisorNameComplex;
        private ClassLibrary.TextEdit txtFax;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtTel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit txtAddress;
        private ClassLibrary.JComboBox cmbCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.TextEdit txtName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewBranch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelBranch;
        private System.Windows.Forms.Button btnEditBranch;
        private System.Windows.Forms.Button btnAddBranch;


    }
}