namespace Legal
{
    partial class JExecutiveSearchForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumber = new ClassLibrary.TextEdit(this.components);
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.txtNumClase2 = new ClassLibrary.TextEdit(this.components);
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearchPetition = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumClase = new ClassLibrary.TextEdit(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.jdgvSearch = new ClassLibrary.JDataGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNumber);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.txtNumClase2);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSearchPetition);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNumClase);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(22, 71);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 24);
            this.btnSearch.TabIndex = 83;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtEndDate
            // 
            this.txtEndDate.BackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate.ChangeColorIfNotEmpty = true;
            this.txtEndDate.ChangeColorOnEnter = true;
            this.txtEndDate.Date = new System.DateTime(((long)(0)));
            this.txtEndDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDate.Location = new System.Drawing.Point(7, 13);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate.Size = new System.Drawing.Size(79, 23);
            this.txtEndDate.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "تاریخ اجراء:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "مشخصات محکوم به:";
            // 
            // txtNumber
            // 
            this.txtNumber.ChangeColorIfNotEmpty = false;
            this.txtNumber.ChangeColorOnEnter = true;
            this.txtNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumber.Location = new System.Drawing.Point(344, 14);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Negative = true;
            this.txtNumber.NotEmpty = false;
            this.txtNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumber.SelectOnEnter = true;
            this.txtNumber.Size = new System.Drawing.Size(74, 23);
            this.txtNumber.TabIndex = 33;
            this.txtNumber.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(14, 101);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(405, 41);
            this.txtDesc.TabIndex = 32;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtNumClase2
            // 
            this.txtNumClase2.ChangeColorIfNotEmpty = false;
            this.txtNumClase2.ChangeColorOnEnter = true;
            this.txtNumClase2.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumClase2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumClase2.Location = new System.Drawing.Point(88, 72);
            this.txtNumClase2.Name = "txtNumClase2";
            this.txtNumClase2.Negative = true;
            this.txtNumClase2.NotEmpty = false;
            this.txtNumClase2.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumClase2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumClase2.SelectOnEnter = true;
            this.txtNumClase2.Size = new System.Drawing.Size(331, 23);
            this.txtNumClase2.TabIndex = 31;
            this.txtNumClase2.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.SystemColors.Info;
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(156, 14);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(78, 23);
            this.txtDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "شماره کلاسه اجرا احکام:";
            // 
            // btnSearchPetition
            // 
            this.btnSearchPetition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchPetition.Location = new System.Drawing.Point(310, 14);
            this.btnSearchPetition.Name = "btnSearchPetition";
            this.btnSearchPetition.Size = new System.Drawing.Size(28, 23);
            this.btnSearchPetition.TabIndex = 24;
            this.btnSearchPetition.Text = "...";
            this.btnSearchPetition.UseVisualStyleBackColor = true;
            this.btnSearchPetition.Click += new System.EventHandler(this.btnSearchPetition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "تاریخ اجراء:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "شماره کلاسه اجرائی:";
            // 
            // txtNumClase
            // 
            this.txtNumClase.ChangeColorIfNotEmpty = false;
            this.txtNumClase.ChangeColorOnEnter = true;
            this.txtNumClase.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumClase.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumClase.Location = new System.Drawing.Point(88, 43);
            this.txtNumClase.Name = "txtNumClase";
            this.txtNumClase.Negative = true;
            this.txtNumClase.NotEmpty = false;
            this.txtNumClase.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumClase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumClase.SelectOnEnter = true;
            this.txtNumClase.Size = new System.Drawing.Size(331, 23);
            this.txtNumClase.TabIndex = 29;
            this.txtNumClase.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(422, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "کد رای دادگاه:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 460);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 46);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(487, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 24);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "انصراف";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(410, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.jdgvSearch);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(574, 306);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // jdgvSearch
            // 
            this.jdgvSearch.AllowUserToAddRows = false;
            this.jdgvSearch.AllowUserToDeleteRows = false;
            this.jdgvSearch.AllowUserToOrderColumns = true;
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
            this.jdgvSearch.Size = new System.Drawing.Size(568, 284);
            this.jdgvSearch.TabIndex = 0;
            this.jdgvSearch.TableName = null;
            this.jdgvSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jdgvSearch_CellDoubleClick);
            // 
            // JExecutiveSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 506);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JExecutiveSearchForm";
            this.Text = "ExecutiveSearch";
            this.Load += new System.EventHandler(this.JExecutiveSearchForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSave;
        private ClassLibrary.TextEdit txtNumClase2;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearchPetition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtNumClase;
        private System.Windows.Forms.Label label12;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.TextEdit txtNumber;
        private ClassLibrary.DateEdit txtEndDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private ClassLibrary.JDataGrid jdgvSearch;
        private System.Windows.Forms.Button btnClear;
    }
}