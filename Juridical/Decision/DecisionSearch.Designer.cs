namespace Legal
{
    partial class JDecisionSearchForm
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
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.chkConclusive = new System.Windows.Forms.CheckBox();
            this.chkNoCon = new System.Windows.Forms.CheckBox();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.chkAgaints = new System.Windows.Forms.CheckBox();
            this.chkBenefit = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkGharar = new System.Windows.Forms.CheckBox();
            this.chkRay = new System.Windows.Forms.CheckBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chklistType = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.jdgvSearch = new ClassLibrary.JDataGrid();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox11);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.groupBox9);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.txtNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 286);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate.ChangeColorIfNotEmpty = true;
            this.txtEndDate.ChangeColorOnEnter = true;
            this.txtEndDate.Date = new System.DateTime(((long)(0)));
            this.txtEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate.InsertInDatesTable = true;
            this.txtEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDate.Location = new System.Drawing.Point(12, 147);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate.Size = new System.Drawing.Size(76, 23);
            this.txtEndDate.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 83;
            this.label2.Text = "تا تاریخ:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(12, 186);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 24);
            this.btnSearch.TabIndex = 82;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(3, 243);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(568, 40);
            this.txtDesc.TabIndex = 30;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(508, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "توضیحات";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.chkConclusive);
            this.groupBox11.Controls.Add(this.chkNoCon);
            this.groupBox11.Location = new System.Drawing.Point(78, 171);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(156, 47);
            this.groupBox11.TabIndex = 28;
            this.groupBox11.TabStop = false;
            // 
            // chkConclusive
            // 
            this.chkConclusive.AutoSize = true;
            this.chkConclusive.Location = new System.Drawing.Point(90, 17);
            this.chkConclusive.Name = "chkConclusive";
            this.chkConclusive.Size = new System.Drawing.Size(60, 20);
            this.chkConclusive.TabIndex = 87;
            this.chkConclusive.Text = "قطعی";
            this.chkConclusive.UseVisualStyleBackColor = true;
            // 
            // chkNoCon
            // 
            this.chkNoCon.AutoSize = true;
            this.chkNoCon.Location = new System.Drawing.Point(6, 17);
            this.chkNoCon.Name = "chkNoCon";
            this.chkNoCon.Size = new System.Drawing.Size(78, 20);
            this.chkNoCon.TabIndex = 88;
            this.chkNoCon.Text = "غیرقطعی";
            this.chkNoCon.UseVisualStyleBackColor = true;
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
            this.txtDate.Location = new System.Drawing.Point(158, 147);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(76, 23);
            this.txtDate.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(234, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 16);
            this.label11.TabIndex = 26;
            this.label11.Text = "تاریخ رای از:";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.chkAgaints);
            this.groupBox9.Controls.Add(this.chkBenefit);
            this.groupBox9.Location = new System.Drawing.Point(356, 171);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(213, 47);
            this.groupBox9.TabIndex = 25;
            this.groupBox9.TabStop = false;
            // 
            // chkAgaints
            // 
            this.chkAgaints.AutoSize = true;
            this.chkAgaints.Location = new System.Drawing.Point(2, 18);
            this.chkAgaints.Name = "chkAgaints";
            this.chkAgaints.Size = new System.Drawing.Size(92, 20);
            this.chkAgaints.TabIndex = 84;
            this.chkAgaints.Text = "علیه شرکت";
            this.chkAgaints.UseVisualStyleBackColor = true;
            // 
            // chkBenefit
            // 
            this.chkBenefit.AutoSize = true;
            this.chkBenefit.Location = new System.Drawing.Point(104, 18);
            this.chkBenefit.Name = "chkBenefit";
            this.chkBenefit.Size = new System.Drawing.Size(101, 20);
            this.chkBenefit.TabIndex = 83;
            this.chkBenefit.Text = "به نفع شرکت";
            this.chkBenefit.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkGharar);
            this.groupBox5.Controls.Add(this.chkRay);
            this.groupBox5.Location = new System.Drawing.Point(237, 171);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(116, 47);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            // 
            // chkGharar
            // 
            this.chkGharar.AutoSize = true;
            this.chkGharar.Location = new System.Drawing.Point(6, 17);
            this.chkGharar.Name = "chkGharar";
            this.chkGharar.Size = new System.Drawing.Size(45, 20);
            this.chkGharar.TabIndex = 86;
            this.chkGharar.Text = "قرار";
            this.chkGharar.UseVisualStyleBackColor = true;
            // 
            // chkRay
            // 
            this.chkRay.AutoSize = true;
            this.chkRay.Location = new System.Drawing.Point(62, 17);
            this.chkRay.Name = "chkRay";
            this.chkRay.Size = new System.Drawing.Size(46, 20);
            this.chkRay.TabIndex = 85;
            this.chkRay.Text = "رای";
            this.chkRay.UseVisualStyleBackColor = true;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(309, 147);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(164, 23);
            this.txtNum.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(474, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "شماره دادنامه:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chklistType);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(568, 122);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "نوع رای:";
            // 
            // chklistType
            // 
            this.chklistType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklistType.FormattingEnabled = true;
            this.chklistType.Location = new System.Drawing.Point(3, 19);
            this.chklistType.Name = "chklistType";
            this.chklistType.Size = new System.Drawing.Size(562, 94);
            this.chklistType.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 464);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 42);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(486, 14);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 24);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "انصراف";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(405, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.jdgvSearch);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 286);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(574, 178);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // jdgvSearch
            // 
            this.jdgvSearch.ActionMenu = jPopupMenu1;
            this.jdgvSearch.AllowUserToAddRows = false;
            this.jdgvSearch.AllowUserToDeleteRows = false;
            this.jdgvSearch.AllowUserToOrderColumns = true;
            this.jdgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvSearch.EnableContexMenu = true;
            this.jdgvSearch.KeyName = null;
            this.jdgvSearch.Location = new System.Drawing.Point(3, 19);
            this.jdgvSearch.Name = "jdgvSearch";
            this.jdgvSearch.ReadHeadersFromDB = false;
            this.jdgvSearch.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvSearch.ShowRowNumber = true;
            this.jdgvSearch.Size = new System.Drawing.Size(568, 156);
            this.jdgvSearch.TabIndex = 0;
            this.jdgvSearch.TableName = null;
            this.jdgvSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jdgvSearch_CellDoubleClick);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(13, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 18;
            this.btnNew.Text = "حکم جدید";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // JDecisionSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 506);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JDecisionSearchForm";
            this.Text = "جستجوی رای دادگاه";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox chklistType;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox11;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JDataGrid jdgvSearch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkNoCon;
        private System.Windows.Forms.CheckBox chkConclusive;
        private System.Windows.Forms.CheckBox chkAgaints;
        private System.Windows.Forms.CheckBox chkBenefit;
        private System.Windows.Forms.CheckBox chkGharar;
        private System.Windows.Forms.CheckBox chkRay;
        private ClassLibrary.DateEdit txtEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNew;
    }
}