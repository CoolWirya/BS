namespace Employment
{
    partial class JFormulaForm
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
            this.label9 = new System.Windows.Forms.Label();
            this.cmbCalcType = new ClassLibrary.JComboBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddFeild = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSabt = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbListField = new ClassLibrary.JComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtFormula = new ClassLibrary.TextEdit(this.components);
            this.cmbFieldType = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.jDataGrid1 = new ClassLibrary.JDataGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(483, 18);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(92, 16);
            this.label9.TabIndex = 62;
            this.label9.Text = "روش محاسبه :";
            // 
            // cmbCalcType
            // 
            this.cmbCalcType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCalcType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCalcType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCalcType.BaseCode = 0;
            this.cmbCalcType.ChangeColorIfNotEmpty = true;
            this.cmbCalcType.ChangeColorOnEnter = true;
            this.cmbCalcType.FormattingEnabled = true;
            this.cmbCalcType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCalcType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCalcType.Location = new System.Drawing.Point(320, 15);
            this.cmbCalcType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCalcType.Name = "cmbCalcType";
            this.cmbCalcType.NotEmpty = false;
            this.cmbCalcType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCalcType.SelectOnEnter = true;
            this.cmbCalcType.Size = new System.Drawing.Size(157, 24);
            this.cmbCalcType.TabIndex = 61;
            this.cmbCalcType.SelectedIndexChanged += new System.EventHandler(this.cmbCalcType_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddFeild);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnSabt);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.cmbListField);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFormula);
            this.groupBox1.Controls.Add(this.cmbFieldType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbCalcType);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 142);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            // 
            // btnAddFeild
            // 
            this.btnAddFeild.Location = new System.Drawing.Point(279, 80);
            this.btnAddFeild.Name = "btnAddFeild";
            this.btnAddFeild.Size = new System.Drawing.Size(35, 23);
            this.btnAddFeild.TabIndex = 71;
            this.btnAddFeild.Text = "+";
            this.btnAddFeild.UseVisualStyleBackColor = true;
            this.btnAddFeild.Click += new System.EventHandler(this.btnAddFeild_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(40, 75);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(116, 23);
            this.btnDel.TabIndex = 70;
            this.btnDel.Text = "حذف";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSabt
            // 
            this.btnSabt.Location = new System.Drawing.Point(40, 50);
            this.btnSabt.Name = "btnSabt";
            this.btnSabt.Size = new System.Drawing.Size(116, 23);
            this.btnSabt.TabIndex = 69;
            this.btnSabt.Text = "ثبت";
            this.btnSabt.UseVisualStyleBackColor = true;
            this.btnSabt.Click += new System.EventHandler(this.btnSabt_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(162, 75);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 23);
            this.btnAdd.TabIndex = 68;
            this.btnAdd.Text = "++";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbListField
            // 
            this.cmbListField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbListField.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbListField.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbListField.BaseCode = 0;
            this.cmbListField.ChangeColorIfNotEmpty = true;
            this.cmbListField.ChangeColorOnEnter = true;
            this.cmbListField.FormattingEnabled = true;
            this.cmbListField.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbListField.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbListField.Items.AddRange(new object[] {
            "بن کارگری",
            "روش محاسبه",
            "کسر صندوق",
            "حق اولاد",
            "مزد ثابت",
            "فوق العاده شغل",
            "حق جذب",
            "مزد جبهه",
            "حق خواروبار",
            "حق مسکن",
            "مبلغ مزایا 1",
            "مبلغ مزایا 2",
            "مبلغ مزایا 3",
            "عنوان مزایا 1",
            "عنوان مزایا 2",
            "عنوان مزایا 3",
            "مزد سربازی",
            "سایر مزایا",
            "حق کارایی",
            "مزد رتبه",
            "مزد سختی کار",
            "پایه سنواتی",
            "حق سرپرستی",
            "نوبت کاری",
            "تفاوت تطبیق",
            "حق ایاب و ذهاب",
            "گروه"});
            this.cmbListField.Location = new System.Drawing.Point(320, 79);
            this.cmbListField.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbListField.Name = "cmbListField";
            this.cmbListField.NotEmpty = false;
            this.cmbListField.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbListField.SelectOnEnter = true;
            this.cmbListField.Size = new System.Drawing.Size(157, 24);
            this.cmbListField.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(483, 82);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 67;
            this.label2.Text = "لیست فیلدها :";
            // 
            // txtFormula
            // 
            this.txtFormula.ChangeColorIfNotEmpty = false;
            this.txtFormula.ChangeColorOnEnter = true;
            this.txtFormula.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFormula.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFormula.Location = new System.Drawing.Point(12, 110);
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.Negative = true;
            this.txtFormula.NotEmpty = false;
            this.txtFormula.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFormula.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFormula.SelectOnEnter = true;
            this.txtFormula.Size = new System.Drawing.Size(465, 23);
            this.txtFormula.TabIndex = 65;
            this.txtFormula.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbFieldType
            // 
            this.cmbFieldType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFieldType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbFieldType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFieldType.BaseCode = 0;
            this.cmbFieldType.ChangeColorIfNotEmpty = true;
            this.cmbFieldType.ChangeColorOnEnter = true;
            this.cmbFieldType.FormattingEnabled = true;
            this.cmbFieldType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbFieldType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFieldType.Items.AddRange(new object[] {
            "بن کارگری",
            "روش محاسبه",
            "کسر صندوق",
            "حق اولاد",
            "مزد ثابت",
            "فوق العاده شغل",
            "حق جذب",
            "مزد جبهه",
            "حق خواروبار",
            "حق مسکن",
            "مبلغ مزایا 1",
            "مبلغ مزایا 2",
            "مبلغ مزایا 3",
            "عنوان مزایا 1",
            "عنوان مزایا 2",
            "عنوان مزایا 3",
            "مزد سربازی",
            "سایر مزایا",
            "حق کارایی",
            "مزد رتبه",
            "مزد سختی کار",
            "پایه سنواتی",
            "حق سرپرستی",
            "نوبت کاری",
            "تفاوت تطبیق",
            "حق ایاب و ذهاب"});
            this.cmbFieldType.Location = new System.Drawing.Point(320, 47);
            this.cmbFieldType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbFieldType.Name = "cmbFieldType";
            this.cmbFieldType.NotEmpty = false;
            this.cmbFieldType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbFieldType.SelectOnEnter = true;
            this.cmbFieldType.Size = new System.Drawing.Size(157, 24);
            this.cmbFieldType.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(483, 50);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 64;
            this.label1.Text = "نوع فیلد :";
            // 
            // jDataGrid1
            // 
            this.jDataGrid1.ActionMenu = jPopupMenu1;
            this.jDataGrid1.AllowUserToAddRows = false;
            this.jDataGrid1.AllowUserToDeleteRows = false;
            this.jDataGrid1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jDataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jDataGrid1.EnableContexMenu = true;
            this.jDataGrid1.KeyName = null;
            this.jDataGrid1.Location = new System.Drawing.Point(0, 142);
            this.jDataGrid1.Name = "jDataGrid1";
            this.jDataGrid1.ReadHeadersFromDB = false;
            this.jDataGrid1.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDataGrid1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.jDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGrid1.ShowRowNumber = true;
            this.jDataGrid1.Size = new System.Drawing.Size(583, 309);
            this.jDataGrid1.TabIndex = 64;
            this.jDataGrid1.TableName = null;
            // 
            // JFormulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 451);
            this.Controls.Add(this.jDataGrid1);
            this.Controls.Add(this.groupBox1);
            this.Name = "JFormulaForm";
            this.Text = "FormulaForm";
            this.Load += new System.EventHandler(this.JFormulaForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private ClassLibrary.JComboBox cmbCalcType;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit txtFormula;
        private ClassLibrary.JComboBox cmbFieldType;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JComboBox cmbListField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private ClassLibrary.JDataGrid jDataGrid1;
        private System.Windows.Forms.Button btnSabt;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAddFeild;
    }
}