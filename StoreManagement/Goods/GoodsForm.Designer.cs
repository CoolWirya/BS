namespace StoreManagement
{
    partial class JGoodsForm
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
            this.txtSefaresh = new ClassLibrary.TextEdit(this.components);
            this.txtIranCode = new ClassLibrary.TextEdit(this.components);
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.txtMax = new ClassLibrary.TextEdit(this.components);
            this.txtMin = new ClassLibrary.TextEdit(this.components);
            this.txtNameLatin = new ClassLibrary.TextEdit(this.components);
            this.txtName = new ClassLibrary.TextEdit(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvGoods = new ClassLibrary.JDataGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.txtSefaresh);
            this.groupBox1.Controls.Add(this.txtIranCode);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.txtMax);
            this.groupBox1.Controls.Add(this.txtMin);
            this.groupBox1.Controls.Add(this.txtNameLatin);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 241);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(400, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(187, 28);
            this.btnSave.TabIndex = 20;
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
            this.cmbMeasure.Location = new System.Drawing.Point(70, 24);
            this.cmbMeasure.Name = "cmbMeasure";
            this.cmbMeasure.NotEmpty = false;
            this.cmbMeasure.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbMeasure.SelectOnEnter = true;
            this.cmbMeasure.Size = new System.Drawing.Size(205, 24);
            this.cmbMeasure.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(281, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 16);
            this.label12.TabIndex = 21;
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
            this.cmbState.Location = new System.Drawing.Point(400, 175);
            this.cmbState.Name = "cmbState";
            this.cmbState.NotEmpty = false;
            this.cmbState.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbState.SelectOnEnter = true;
            this.cmbState.Size = new System.Drawing.Size(205, 24);
            this.cmbState.TabIndex = 7;
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
            this.cmbGoodsType.Location = new System.Drawing.Point(400, 115);
            this.cmbGoodsType.Name = "cmbGoodsType";
            this.cmbGoodsType.NotEmpty = false;
            this.cmbGoodsType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGoodsType.SelectOnEnter = true;
            this.cmbGoodsType.Size = new System.Drawing.Size(205, 24);
            this.cmbGoodsType.TabIndex = 5;
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
            this.cmbGroup.Location = new System.Drawing.Point(400, 85);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.NotEmpty = false;
            this.cmbGroup.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGroup.SelectOnEnter = true;
            this.cmbGroup.Size = new System.Drawing.Size(205, 24);
            this.cmbGroup.TabIndex = 3;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(12, 174);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(263, 59);
            this.txtDesc.TabIndex = 18;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtSefaresh
            // 
            this.txtSefaresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSefaresh.ChangeColorIfNotEmpty = false;
            this.txtSefaresh.ChangeColorOnEnter = true;
            this.txtSefaresh.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSefaresh.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSefaresh.Location = new System.Drawing.Point(70, 145);
            this.txtSefaresh.Name = "txtSefaresh";
            this.txtSefaresh.Negative = true;
            this.txtSefaresh.NotEmpty = false;
            this.txtSefaresh.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSefaresh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSefaresh.SelectOnEnter = true;
            this.txtSefaresh.Size = new System.Drawing.Size(205, 23);
            this.txtSefaresh.TabIndex = 17;
            this.txtSefaresh.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtIranCode
            // 
            this.txtIranCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIranCode.ChangeColorIfNotEmpty = false;
            this.txtIranCode.ChangeColorOnEnter = true;
            this.txtIranCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtIranCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIranCode.Location = new System.Drawing.Point(70, 114);
            this.txtIranCode.Name = "txtIranCode";
            this.txtIranCode.Negative = true;
            this.txtIranCode.NotEmpty = false;
            this.txtIranCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtIranCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIranCode.SelectOnEnter = true;
            this.txtIranCode.Size = new System.Drawing.Size(205, 23);
            this.txtIranCode.TabIndex = 15;
            this.txtIranCode.Text = "0";
            this.txtIranCode.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(400, 145);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(205, 23);
            this.txtPrice.TabIndex = 6;
            this.txtPrice.Text = "0";
            this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
            // 
            // txtMax
            // 
            this.txtMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMax.ChangeColorIfNotEmpty = false;
            this.txtMax.ChangeColorOnEnter = true;
            this.txtMax.InBackColor = System.Drawing.SystemColors.Info;
            this.txtMax.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMax.Location = new System.Drawing.Point(70, 84);
            this.txtMax.Name = "txtMax";
            this.txtMax.Negative = true;
            this.txtMax.NotEmpty = false;
            this.txtMax.NotEmptyColor = System.Drawing.Color.Red;
            this.txtMax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMax.SelectOnEnter = true;
            this.txtMax.Size = new System.Drawing.Size(205, 23);
            this.txtMax.TabIndex = 10;
            this.txtMax.Text = "0";
            this.txtMax.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtMin
            // 
            this.txtMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMin.ChangeColorIfNotEmpty = false;
            this.txtMin.ChangeColorOnEnter = true;
            this.txtMin.InBackColor = System.Drawing.SystemColors.Info;
            this.txtMin.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMin.Location = new System.Drawing.Point(70, 54);
            this.txtMin.Name = "txtMin";
            this.txtMin.Negative = true;
            this.txtMin.NotEmpty = false;
            this.txtMin.NotEmptyColor = System.Drawing.Color.Red;
            this.txtMin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMin.SelectOnEnter = true;
            this.txtMin.Size = new System.Drawing.Size(205, 23);
            this.txtMin.TabIndex = 9;
            this.txtMin.Text = "0";
            this.txtMin.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtNameLatin
            // 
            this.txtNameLatin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameLatin.ChangeColorIfNotEmpty = false;
            this.txtNameLatin.ChangeColorOnEnter = true;
            this.txtNameLatin.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNameLatin.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNameLatin.Location = new System.Drawing.Point(400, 55);
            this.txtNameLatin.Name = "txtNameLatin";
            this.txtNameLatin.Negative = true;
            this.txtNameLatin.NotEmpty = false;
            this.txtNameLatin.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNameLatin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNameLatin.SelectOnEnter = true;
            this.txtNameLatin.Size = new System.Drawing.Size(205, 23);
            this.txtNameLatin.TabIndex = 2;
            this.txtNameLatin.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.ChangeColorIfNotEmpty = false;
            this.txtName.ChangeColorOnEnter = true;
            this.txtName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(400, 26);
            this.txtName.Name = "txtName";
            this.txtName.Negative = true;
            this.txtName.NotEmpty = false;
            this.txtName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectOnEnter = true;
            this.txtName.Size = new System.Drawing.Size(205, 23);
            this.txtName.TabIndex = 1;
            this.txtName.TextMode = ClassLibrary.TextModes.Text;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(287, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "ایران کد :";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(617, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "قیمت :";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(287, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "توضیحات :";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(617, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "وضعیت :";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(281, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "حداکثر :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "حداقل :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "نقطه سفارش :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(611, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "نوع کالا :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(611, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "گروه :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(611, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "نام لاتین :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(611, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام :";
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 525);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(680, 28);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvGoods);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 241);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(680, 284);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
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
            this.dgvGoods.Location = new System.Drawing.Point(3, 19);
            this.dgvGoods.Name = "dgvGoods";
            this.dgvGoods.ReadHeadersFromDB = false;
            this.dgvGoods.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgvGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoods.ShowRowNumber = true;
            this.dgvGoods.Size = new System.Drawing.Size(674, 262);
            this.dgvGoods.TabIndex = 0;
            this.dgvGoods.TableName = null;
            // 
            // JGoodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 553);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JGoodsForm";
            this.Text = "GoodsForm";
            this.Load += new System.EventHandler(this.JGoodsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private ClassLibrary.TextEdit txtDesc;
        private ClassLibrary.TextEdit txtSefaresh;
        private ClassLibrary.TextEdit txtIranCode;
        private ClassLibrary.TextEdit txtPrice;
        private ClassLibrary.TextEdit txtMax;
        private ClassLibrary.TextEdit txtMin;
        private ClassLibrary.TextEdit txtNameLatin;
        private ClassLibrary.TextEdit txtName;
        private System.Windows.Forms.Label label11;
        private ClassLibrary.JDataGrid dgvGoods;
        private System.Windows.Forms.Button btnSave;
        private ClassLibrary.JComboBox cmbState;
        private ClassLibrary.JComboBox cmbGoodsType;
        private ClassLibrary.JComboBox cmbGroup;
        private ClassLibrary.JComboBox cmbMeasure;
        private System.Windows.Forms.Label label12;
    }
}