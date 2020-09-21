namespace Legal
{
    partial class JPetitionSearchForm
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
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.cmbJudicalComplex = new ClassLibrary.JComboBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReasons = new ClassLibrary.TextEdit(this.components);
            this.txtRequest = new ClassLibrary.TextEdit(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtDateEnd = new ClassLibrary.DateEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNumber = new ClassLibrary.TextEdit(this.components);
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.rbFey = new System.Windows.Forms.RadioButton();
            this.rbPetition = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.jdgvPetition = new ClassLibrary.JDataGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvPetition)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbBranch);
            this.groupBox1.Controls.Add(this.cmbJudicalComplex);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtReasons);
            this.groupBox1.Controls.Add(this.txtRequest);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtDateEnd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbSubject);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtNumber);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbBranch
            // 
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(194, 72);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(269, 24);
            this.cmbBranch.TabIndex = 89;
            // 
            // cmbJudicalComplex
            // 
            this.cmbJudicalComplex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbJudicalComplex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbJudicalComplex.BaseCode = 0;
            this.cmbJudicalComplex.ChangeColorIfNotEmpty = true;
            this.cmbJudicalComplex.ChangeColorOnEnter = true;
            this.cmbJudicalComplex.FormattingEnabled = true;
            this.cmbJudicalComplex.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbJudicalComplex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbJudicalComplex.Location = new System.Drawing.Point(194, 42);
            this.cmbJudicalComplex.Name = "cmbJudicalComplex";
            this.cmbJudicalComplex.NotEmpty = false;
            this.cmbJudicalComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbJudicalComplex.SelectOnEnter = true;
            this.cmbJudicalComplex.Size = new System.Drawing.Size(269, 24);
            this.cmbJudicalComplex.TabIndex = 87;
            this.cmbJudicalComplex.SelectedIndexChanged += new System.EventHandler(this.cmbJudicalComplex_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(469, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 16);
            this.label7.TabIndex = 88;
            this.label7.Text = "مجتمع قضائی:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(469, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 86;
            this.label8.Text = "شعبه:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(465, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 85;
            this.label6.Text = "دلائل :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(465, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 84;
            this.label2.Text = "تعیین خواسته :";
            // 
            // txtReasons
            // 
            this.txtReasons.ChangeColorIfNotEmpty = false;
            this.txtReasons.ChangeColorOnEnter = true;
            this.txtReasons.InBackColor = System.Drawing.SystemColors.Info;
            this.txtReasons.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReasons.Location = new System.Drawing.Point(194, 160);
            this.txtReasons.Name = "txtReasons";
            this.txtReasons.Negative = true;
            this.txtReasons.NotEmpty = false;
            this.txtReasons.NotEmptyColor = System.Drawing.Color.Red;
            this.txtReasons.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReasons.SelectOnEnter = true;
            this.txtReasons.Size = new System.Drawing.Size(269, 23);
            this.txtReasons.TabIndex = 83;
            this.txtReasons.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtRequest
            // 
            this.txtRequest.ChangeColorIfNotEmpty = false;
            this.txtRequest.ChangeColorOnEnter = true;
            this.txtRequest.InBackColor = System.Drawing.SystemColors.Info;
            this.txtRequest.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRequest.Location = new System.Drawing.Point(194, 131);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Negative = true;
            this.txtRequest.NotEmpty = false;
            this.txtRequest.NotEmptyColor = System.Drawing.Color.Red;
            this.txtRequest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRequest.SelectOnEnter = true;
            this.txtRequest.Size = new System.Drawing.Size(268, 23);
            this.txtRequest.TabIndex = 82;
            this.txtRequest.TextMode = ClassLibrary.TextModes.Text;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(16, 151);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 24);
            this.btnSearch.TabIndex = 81;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.ChangeColorIfNotEmpty = true;
            this.txtDateEnd.ChangeColorOnEnter = true;
            this.txtDateEnd.Date = new System.DateTime(((long)(0)));
            this.txtDateEnd.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateEnd.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateEnd.InsertInDatesTable = true;
            this.txtDateEnd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateEnd.Location = new System.Drawing.Point(6, 13);
            this.txtDateEnd.Mask = "0000/00/00";
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.NotEmpty = false;
            this.txtDateEnd.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateEnd.Size = new System.Drawing.Size(100, 23);
            this.txtDateEnd.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 79;
            this.label1.Text = "تاریخ:";
            // 
            // cmbSubject
            // 
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(194, 101);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(269, 24);
            this.cmbSubject.TabIndex = 78;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(465, 103);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 16);
            this.label16.TabIndex = 77;
            this.label16.Text = " موضوع:";
            // 
            // txtNumber
            // 
            this.txtNumber.ChangeColorIfNotEmpty = false;
            this.txtNumber.ChangeColorOnEnter = true;
            this.txtNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumber.Location = new System.Drawing.Point(342, 15);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Negative = true;
            this.txtNumber.NotEmpty = false;
            this.txtNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumber.SelectOnEnter = true;
            this.txtNumber.Size = new System.Drawing.Size(117, 23);
            this.txtNumber.TabIndex = 75;
            this.txtNumber.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtDate
            // 
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(158, 13);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 74;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbBoth);
            this.groupBox6.Controls.Add(this.rbFey);
            this.groupBox6.Controls.Add(this.rbPetition);
            this.groupBox6.Location = new System.Drawing.Point(7, 44);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(175, 86);
            this.groupBox6.TabIndex = 73;
            this.groupBox6.TabStop = false;
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.Checked = true;
            this.rbBoth.Location = new System.Drawing.Point(114, 10);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(55, 20);
            this.rbBoth.TabIndex = 0;
            this.rbBoth.TabStop = true;
            this.rbBoth.Text = "هر دو";
            this.rbBoth.UseVisualStyleBackColor = true;
            // 
            // rbFey
            // 
            this.rbFey.AutoSize = true;
            this.rbFey.Location = new System.Drawing.Point(98, 36);
            this.rbFey.Name = "rbFey";
            this.rbFey.Size = new System.Drawing.Size(71, 20);
            this.rbFey.TabIndex = 1;
            this.rbFey.Text = "شکوائیه";
            this.rbFey.UseVisualStyleBackColor = true;
            // 
            // rbPetition
            // 
            this.rbPetition.AutoSize = true;
            this.rbPetition.Location = new System.Drawing.Point(85, 62);
            this.rbPetition.Name = "rbPetition";
            this.rbPetition.Size = new System.Drawing.Size(84, 20);
            this.rbPetition.TabIndex = 2;
            this.rbPetition.Text = "دادخواست";
            this.rbPetition.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 71;
            this.label4.Text = "تاریخ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(465, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 70;
            this.label3.Text = "کلاسه پرونده :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 414);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 47);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(400, 14);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 24);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "انصراف";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(481, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.jdgvPetition);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(574, 227);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // jdgvPetition
            // 
            this.jdgvPetition.ActionMenu = jPopupMenu1;
            this.jdgvPetition.AllowUserToAddRows = false;
            this.jdgvPetition.AllowUserToDeleteRows = false;
            this.jdgvPetition.AllowUserToOrderColumns = true;
            this.jdgvPetition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvPetition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvPetition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvPetition.EnableContexMenu = true;
            this.jdgvPetition.KeyName = null;
            this.jdgvPetition.Location = new System.Drawing.Point(3, 19);
            this.jdgvPetition.Name = "jdgvPetition";
            this.jdgvPetition.ReadHeadersFromDB = false;
            this.jdgvPetition.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvPetition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvPetition.ShowRowNumber = true;
            this.jdgvPetition.Size = new System.Drawing.Size(568, 205);
            this.jdgvPetition.TabIndex = 0;
            this.jdgvPetition.TableName = null;
            this.jdgvPetition.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.jdgvPetition_CellMouseDoubleClick);
            // 
            // JPetitionSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 461);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JPetitionSearchForm";
            this.Text = "PetitionSearch";
            this.Load += new System.EventHandler(this.JPetitionSearchForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvPetition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.JDataGrid jdgvPetition;
        private ClassLibrary.TextEdit txtNumber;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbFey;
        private System.Windows.Forms.RadioButton rbPetition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSave;
        private ClassLibrary.DateEdit txtDateEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private ClassLibrary.TextEdit txtRequest;
        private ClassLibrary.TextEdit txtReasons;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBranch;
        private ClassLibrary.JComboBox cmbJudicalComplex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rbBoth;
    }
}