namespace Legal
{
    partial class JDocumentsForm
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
            this.btnReg = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTypeDoc = new System.Windows.Forms.ComboBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdDocuments = new ClassLibrary.JDataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label54 = new System.Windows.Forms.Label();
            this.txtDateRecieve = new ClassLibrary.DateEdit(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAcc3 = new ClassLibrary.TextEdit(this.components);
            this.txtAcc2 = new ClassLibrary.TextEdit(this.components);
            this.txtAcc1 = new ClassLibrary.TextEdit(this.components);
            this.txtSerial = new ClassLibrary.TextEdit(this.components);
            this.cmbForm = new ClassLibrary.JComboBox(this.components);
            this.cmbConcern = new ClassLibrary.JComboBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocuments)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReg);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbTypeDoc);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 48);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            // 
            // btnReg
            // 
            this.btnReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReg.Location = new System.Drawing.Point(509, 16);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(41, 25);
            this.btnReg.TabIndex = 63;
            this.btnReg.Text = "+";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(779, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "نوع سند:";
            // 
            // cmbTypeDoc
            // 
            this.cmbTypeDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTypeDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeDoc.FormattingEnabled = true;
            this.cmbTypeDoc.Location = new System.Drawing.Point(556, 17);
            this.cmbTypeDoc.Name = "cmbTypeDoc";
            this.cmbTypeDoc.Size = new System.Drawing.Size(217, 24);
            this.cmbTypeDoc.TabIndex = 2;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(428, 16);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 25);
            this.btnDel.TabIndex = 62;
            this.btnDel.Text = "حذف ";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNext);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnBack);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 397);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(849, 54);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(761, 17);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 18;
            this.btnNext.Text = "بعدی";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(680, 17);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "قبلی";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdDocuments);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(849, 349);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            // 
            // grdDocuments
            // 
            this.grdDocuments.ActionMenu = jPopupMenu1;
            this.grdDocuments.AllowUserToAddRows = false;
            this.grdDocuments.AllowUserToDeleteRows = false;
            this.grdDocuments.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grdDocuments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDocuments.EnableContexMenu = true;
            this.grdDocuments.KeyName = null;
            this.grdDocuments.Location = new System.Drawing.Point(3, 130);
            this.grdDocuments.Name = "grdDocuments";
            this.grdDocuments.ReadHeadersFromDB = false;
            this.grdDocuments.ReadOnly = true;
            this.grdDocuments.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDocuments.ShowRowNumber = true;
            this.grdDocuments.Size = new System.Drawing.Size(843, 216);
            this.grdDocuments.TabIndex = 14;
            this.grdDocuments.TableName = null;
            this.grdDocuments.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDocuments_CellContentDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label54);
            this.panel1.Controls.Add(this.txtDateRecieve);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtAcc3);
            this.panel1.Controls.Add(this.txtAcc2);
            this.panel1.Controls.Add(this.txtAcc1);
            this.panel1.Controls.Add(this.txtSerial);
            this.panel1.Controls.Add(this.cmbForm);
            this.panel1.Controls.Add(this.cmbConcern);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 111);
            this.panel1.TabIndex = 15;
            // 
            // label54
            // 
            this.label54.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(335, 16);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(95, 16);
            this.label54.TabIndex = 104;
            this.label54.Text = "تاريخ سررسيد :";
            // 
            // txtDateRecieve
            // 
            this.txtDateRecieve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateRecieve.ChangeColorIfNotEmpty = true;
            this.txtDateRecieve.ChangeColorOnEnter = true;
            this.txtDateRecieve.Date = new System.DateTime(((long)(0)));
            this.txtDateRecieve.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateRecieve.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateRecieve.InsertInDatesTable = true;
            this.txtDateRecieve.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateRecieve.Location = new System.Drawing.Point(229, 14);
            this.txtDateRecieve.Mask = "0000/00/00";
            this.txtDateRecieve.Name = "txtDateRecieve";
            this.txtDateRecieve.NotEmpty = false;
            this.txtDateRecieve.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateRecieve.Size = new System.Drawing.Size(100, 23);
            this.txtDateRecieve.TabIndex = 103;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(498, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 16);
            this.label14.TabIndex = 100;
            this.label14.Text = "دسته 3:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(638, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 16);
            this.label13.TabIndex = 101;
            this.label13.Text = "دسته 2:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(773, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 16);
            this.label12.TabIndex = 102;
            this.label12.Text = "دسته 1:";
            // 
            // txtAcc3
            // 
            this.txtAcc3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcc3.ChangeColorIfNotEmpty = false;
            this.txtAcc3.ChangeColorOnEnter = true;
            this.txtAcc3.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAcc3.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAcc3.Location = new System.Drawing.Point(437, 71);
            this.txtAcc3.Name = "txtAcc3";
            this.txtAcc3.Negative = true;
            this.txtAcc3.NotEmpty = false;
            this.txtAcc3.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAcc3.ReadOnly = true;
            this.txtAcc3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcc3.SelectOnEnter = true;
            this.txtAcc3.Size = new System.Drawing.Size(55, 23);
            this.txtAcc3.TabIndex = 97;
            this.txtAcc3.TextMode = ClassLibrary.TextModes.Text;
            this.txtAcc3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtAcc3_MouseDoubleClick);
            // 
            // txtAcc2
            // 
            this.txtAcc2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcc2.ChangeColorIfNotEmpty = false;
            this.txtAcc2.ChangeColorOnEnter = true;
            this.txtAcc2.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAcc2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAcc2.Location = new System.Drawing.Point(580, 72);
            this.txtAcc2.Name = "txtAcc2";
            this.txtAcc2.Negative = true;
            this.txtAcc2.NotEmpty = false;
            this.txtAcc2.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAcc2.ReadOnly = true;
            this.txtAcc2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcc2.SelectOnEnter = true;
            this.txtAcc2.Size = new System.Drawing.Size(55, 23);
            this.txtAcc2.TabIndex = 98;
            this.txtAcc2.TextMode = ClassLibrary.TextModes.Text;
            this.txtAcc2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtAcc3_MouseDoubleClick);
            // 
            // txtAcc1
            // 
            this.txtAcc1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcc1.ChangeColorIfNotEmpty = false;
            this.txtAcc1.ChangeColorOnEnter = true;
            this.txtAcc1.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAcc1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAcc1.Location = new System.Drawing.Point(715, 73);
            this.txtAcc1.Name = "txtAcc1";
            this.txtAcc1.Negative = true;
            this.txtAcc1.NotEmpty = false;
            this.txtAcc1.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAcc1.ReadOnly = true;
            this.txtAcc1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcc1.SelectOnEnter = true;
            this.txtAcc1.Size = new System.Drawing.Size(55, 23);
            this.txtAcc1.TabIndex = 99;
            this.txtAcc1.TextMode = ClassLibrary.TextModes.Text;
            this.txtAcc1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtAcc3_MouseDoubleClick);
            // 
            // txtSerial
            // 
            this.txtSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerial.ChangeColorIfNotEmpty = false;
            this.txtSerial.ChangeColorOnEnter = true;
            this.txtSerial.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSerial.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSerial.Location = new System.Drawing.Point(649, 13);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Negative = true;
            this.txtSerial.NotEmpty = false;
            this.txtSerial.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSerial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSerial.SelectOnEnter = true;
            this.txtSerial.Size = new System.Drawing.Size(130, 23);
            this.txtSerial.TabIndex = 91;
            this.txtSerial.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbForm
            // 
            this.cmbForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbForm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbForm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbForm.BaseCode = 0;
            this.cmbForm.ChangeColorIfNotEmpty = true;
            this.cmbForm.ChangeColorOnEnter = true;
            this.cmbForm.FormattingEnabled = true;
            this.cmbForm.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbForm.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbForm.Location = new System.Drawing.Point(436, 13);
            this.cmbForm.Name = "cmbForm";
            this.cmbForm.NotEmpty = false;
            this.cmbForm.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbForm.SelectOnEnter = true;
            this.cmbForm.Size = new System.Drawing.Size(170, 24);
            this.cmbForm.TabIndex = 90;
            this.cmbForm.SelectedIndexChanged += new System.EventHandler(this.cmbForm_SelectedIndexChanged);
            // 
            // cmbConcern
            // 
            this.cmbConcern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConcern.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbConcern.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbConcern.BaseCode = 0;
            this.cmbConcern.ChangeColorIfNotEmpty = true;
            this.cmbConcern.ChangeColorOnEnter = true;
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbConcern.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbConcern.Location = new System.Drawing.Point(229, 43);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.NotEmpty = false;
            this.cmbConcern.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbConcern.SelectOnEnter = true;
            this.cmbConcern.Size = new System.Drawing.Size(550, 24);
            this.cmbConcern.TabIndex = 92;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(785, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 16);
            this.label11.TabIndex = 93;
            this.label11.Text = "سریال:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(612, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 16);
            this.label7.TabIndex = 94;
            this.label7.Text = "فرم:";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(792, 46);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 16);
            this.label20.TabIndex = 95;
            this.label20.Text = "بابت:";
            // 
            // JDocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 451);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JDocumentsForm";
            this.Text = "اسناد مالی رد و بدا شده";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JDocumentsForm_FormClosed);
            this.Load += new System.EventHandler(this.JDocumentsForm_Load);
            this.VisibleChanged += new System.EventHandler(this.JDocumentsForm_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDocuments)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTypeDoc;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.JDataGrid grdDocuments;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private ClassLibrary.TextEdit txtAcc3;
        private ClassLibrary.TextEdit txtAcc2;
        private ClassLibrary.TextEdit txtAcc1;
        private ClassLibrary.TextEdit txtSerial;
        private ClassLibrary.JComboBox cmbForm;
        private ClassLibrary.JComboBox cmbConcern;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label54;
        private ClassLibrary.DateEdit txtDateRecieve;
    }
}