namespace StoreManagement
{
    partial class JServicesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbMeasure = new ClassLibrary.JComboBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.cmbState = new ClassLibrary.JComboBox(this.components);
            this.cmbGoodsType = new ClassLibrary.JComboBox(this.components);
            this.cmbGroup = new ClassLibrary.JComboBox(this.components);
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.txtName = new ClassLibrary.TextEdit(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvGoods = new ClassLibrary.JDataGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.cmbMeasure);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbState);
            this.groupBox1.Controls.Add(this.cmbGoodsType);
            this.groupBox1.Controls.Add(this.cmbGroup);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(298, 136);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(187, 28);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "ثبت";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbMeasure
            // 
            this.cmbMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMeasure.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbMeasure.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMeasure.BaseCode = 0;
            this.cmbMeasure.ChangeColorIfNotEmpty = true;
            this.cmbMeasure.ChangeColorOnEnter = true;
            this.cmbMeasure.FormattingEnabled = true;
            this.cmbMeasure.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbMeasure.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbMeasure.Location = new System.Drawing.Point(63, 16);
            this.cmbMeasure.Name = "cmbMeasure";
            this.cmbMeasure.NotEmpty = false;
            this.cmbMeasure.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbMeasure.SelectOnEnter = true;
            this.cmbMeasure.Size = new System.Drawing.Size(205, 24);
            this.cmbMeasure.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(274, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 16);
            this.label12.TabIndex = 36;
            this.label12.Text = "واحد اندازه گیری :";
            // 
            // cmbState
            // 
            this.cmbState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbState.BaseCode = 0;
            this.cmbState.ChangeColorIfNotEmpty = true;
            this.cmbState.ChangeColorOnEnter = true;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbState.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbState.Location = new System.Drawing.Point(63, 46);
            this.cmbState.Name = "cmbState";
            this.cmbState.NotEmpty = false;
            this.cmbState.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbState.SelectOnEnter = true;
            this.cmbState.Size = new System.Drawing.Size(205, 24);
            this.cmbState.TabIndex = 29;
            // 
            // cmbGoodsType
            // 
            this.cmbGoodsType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGoodsType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbGoodsType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGoodsType.BaseCode = 0;
            this.cmbGoodsType.ChangeColorIfNotEmpty = true;
            this.cmbGoodsType.ChangeColorOnEnter = true;
            this.cmbGoodsType.FormattingEnabled = true;
            this.cmbGoodsType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGoodsType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGoodsType.Location = new System.Drawing.Point(393, 77);
            this.cmbGoodsType.Name = "cmbGoodsType";
            this.cmbGoodsType.NotEmpty = false;
            this.cmbGoodsType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGoodsType.SelectOnEnter = true;
            this.cmbGoodsType.Size = new System.Drawing.Size(205, 24);
            this.cmbGoodsType.TabIndex = 27;
            // 
            // cmbGroup
            // 
            this.cmbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroup.BaseCode = 0;
            this.cmbGroup.ChangeColorIfNotEmpty = true;
            this.cmbGroup.ChangeColorOnEnter = true;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGroup.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGroup.Location = new System.Drawing.Point(393, 47);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.NotEmpty = false;
            this.cmbGroup.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGroup.SelectOnEnter = true;
            this.cmbGroup.Size = new System.Drawing.Size(205, 24);
            this.cmbGroup.TabIndex = 25;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(5, 76);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(263, 59);
            this.txtDesc.TabIndex = 34;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(393, 107);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(205, 23);
            this.txtPrice.TabIndex = 28;
            this.txtPrice.Text = "0";
            this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.ChangeColorIfNotEmpty = false;
            this.txtName.ChangeColorOnEnter = true;
            this.txtName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(393, 18);
            this.txtName.Name = "txtName";
            this.txtName.Negative = true;
            this.txtName.NotEmpty = false;
            this.txtName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectOnEnter = true;
            this.txtName.Size = new System.Drawing.Size(205, 23);
            this.txtName.TabIndex = 23;
            this.txtName.TextMode = ClassLibrary.TextModes.Text;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(610, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 16);
            this.label10.TabIndex = 33;
            this.label10.Text = "قیمت :";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(272, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "توضیحات :";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 16);
            this.label8.TabIndex = 30;
            this.label8.Text = "وضعیت :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(604, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "نوع خدمات :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(604, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "گروه :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(604, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "نام :";
            // 
            // dgvGoods
            // 
            this.dgvGoods.ActionMenu = jPopupMenu1;
            this.dgvGoods.AllowUserToAddRows = false;
            this.dgvGoods.AllowUserToDeleteRows = false;
            this.dgvGoods.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgvGoods.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGoods.EnableContexMenu = true;
            this.dgvGoods.KeyName = null;
            this.dgvGoods.Location = new System.Drawing.Point(0, 172);
            this.dgvGoods.Name = "dgvGoods";
            this.dgvGoods.ReadHeadersFromDB = false;
            this.dgvGoods.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgvGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoods.ShowRowNumber = true;
            this.dgvGoods.Size = new System.Drawing.Size(690, 247);
            this.dgvGoods.TabIndex = 1;
            this.dgvGoods.TableName = null;
            // 
            // JServicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 419);
            this.Controls.Add(this.dgvGoods);
            this.Controls.Add(this.groupBox1);
            this.Name = "JServicesForm";
            this.Text = "ServicesForm";
            this.Load += new System.EventHandler(this.JGoodsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private ClassLibrary.JComboBox cmbMeasure;
        private System.Windows.Forms.Label label12;
        private ClassLibrary.JComboBox cmbState;
        private ClassLibrary.JComboBox cmbGoodsType;
        private ClassLibrary.JComboBox cmbGroup;
        private ClassLibrary.TextEdit txtDesc;
        private ClassLibrary.TextEdit txtPrice;
        private ClassLibrary.TextEdit txtName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JDataGrid dgvGoods;
    }
}