namespace Legal
{
    partial class JNotaryLetterSearchForm
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
            this.EndDate = new ClassLibrary.DateEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.jcmbNotary = new ClassLibrary.JComboBox(this.components);
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNotary = new ClassLibrary.NumEdit();
            this.DateLetter = new ClassLibrary.DateEdit(this.components);
            this.txtLetterNo = new ClassLibrary.NumEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearchNotary = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.jdgvNotaryLetter = new ClassLibrary.JDataGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvNotaryLetter)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EndDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.jcmbNotary);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.txtSubject);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNotary);
            this.groupBox1.Controls.Add(this.DateLetter);
            this.groupBox1.Controls.Add(this.txtLetterNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSearchNotary);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // EndDate
            // 
            this.EndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EndDate.ChangeColorIfNotEmpty = true;
            this.EndDate.ChangeColorOnEnter = true;
            this.EndDate.Date = new System.DateTime(((long)(0)));
            this.EndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.EndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.EndDate.InsertInDatesTable = true;
            this.EndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.EndDate.Location = new System.Drawing.Point(349, 113);
            this.EndDate.Mask = "0000/00/00";
            this.EndDate.Name = "EndDate";
            this.EndDate.NotEmpty = false;
            this.EndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.EndDate.Size = new System.Drawing.Size(117, 23);
            this.EndDate.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "تا تاریخ:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(163, 112);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // jcmbNotary
            // 
            this.jcmbNotary.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.jcmbNotary.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.jcmbNotary.BaseCode = 0;
            this.jcmbNotary.ChangeColorIfNotEmpty = true;
            this.jcmbNotary.ChangeColorOnEnter = true;
            this.jcmbNotary.FormattingEnabled = true;
            this.jcmbNotary.InBackColor = System.Drawing.SystemColors.Info;
            this.jcmbNotary.InForeColor = System.Drawing.SystemColors.WindowText;
            this.jcmbNotary.Location = new System.Drawing.Point(348, 22);
            this.jcmbNotary.Name = "jcmbNotary";
            this.jcmbNotary.NotEmpty = false;
            this.jcmbNotary.NotEmptyColor = System.Drawing.Color.Red;
            this.jcmbNotary.SelectOnEnter = true;
            this.jcmbNotary.Size = new System.Drawing.Size(84, 24);
            this.jcmbNotary.TabIndex = 2;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(8, 51);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(230, 55);
            this.txtDesc.TabIndex = 6;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(8, 19);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(230, 23);
            this.txtSubject.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "توضیحات :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "موضوع نامه:";
            // 
            // txtNotary
            // 
            this.txtNotary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotary.ChangeColorIfNotEmpty = false;
            this.txtNotary.ChangeColorOnEnter = true;
            this.txtNotary.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNotary.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNotary.Location = new System.Drawing.Point(432, 22);
            this.txtNotary.Name = "txtNotary";
            this.txtNotary.Negative = true;
            this.txtNotary.NotEmpty = false;
            this.txtNotary.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNotary.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtNotary.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNotary.SelectOnEnter = true;
            this.txtNotary.Size = new System.Drawing.Size(34, 23);
            this.txtNotary.TabIndex = 1;
            this.txtNotary.TextMode = ClassLibrary.TextModes.Text;
            // 
            // DateLetter
            // 
            this.DateLetter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateLetter.ChangeColorIfNotEmpty = true;
            this.DateLetter.ChangeColorOnEnter = true;
            this.DateLetter.Date = new System.DateTime(((long)(0)));
            this.DateLetter.InBackColor = System.Drawing.SystemColors.Info;
            this.DateLetter.InForeColor = System.Drawing.SystemColors.WindowText;
            this.DateLetter.InsertInDatesTable = true;
            this.DateLetter.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.DateLetter.Location = new System.Drawing.Point(349, 82);
            this.DateLetter.Mask = "0000/00/00";
            this.DateLetter.Name = "DateLetter";
            this.DateLetter.NotEmpty = false;
            this.DateLetter.NotEmptyColor = System.Drawing.Color.Red;
            this.DateLetter.Size = new System.Drawing.Size(117, 23);
            this.DateLetter.TabIndex = 4;
            // 
            // txtLetterNo
            // 
            this.txtLetterNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLetterNo.ChangeColorIfNotEmpty = false;
            this.txtLetterNo.ChangeColorOnEnter = true;
            this.txtLetterNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLetterNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLetterNo.Location = new System.Drawing.Point(348, 51);
            this.txtLetterNo.Name = "txtLetterNo";
            this.txtLetterNo.Negative = true;
            this.txtLetterNo.NotEmpty = false;
            this.txtLetterNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLetterNo.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtLetterNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLetterNo.SelectOnEnter = true;
            this.txtLetterNo.Size = new System.Drawing.Size(118, 23);
            this.txtLetterNo.TabIndex = 3;
            this.txtLetterNo.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(466, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "تاریخ نامه از:";
            // 
            // btnSearchNotary
            // 
            this.btnSearchNotary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchNotary.Location = new System.Drawing.Point(316, 22);
            this.btnSearchNotary.Name = "btnSearchNotary";
            this.btnSearchNotary.Size = new System.Drawing.Size(29, 24);
            this.btnSearchNotary.TabIndex = 18;
            this.btnSearchNotary.Text = "...";
            this.btnSearchNotary.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(466, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 16);
            this.label17.TabIndex = 17;
            this.label17.Text = "شماره نامه:";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(466, 26);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(102, 16);
            this.label21.TabIndex = 16;
            this.label21.Text = "شماره دفتر خانه:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnConfirm);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 404);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 47);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Location = new System.Drawing.Point(493, 16);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 25);
            this.BtnConfirm.TabIndex = 26;
            this.BtnConfirm.Text = "Confirm";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.jdgvNotaryLetter);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(574, 264);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // jdgvNotaryLetter
            // 
            this.jdgvNotaryLetter.ActionMenu = jPopupMenu1;
            this.jdgvNotaryLetter.AllowUserToAddRows = false;
            this.jdgvNotaryLetter.AllowUserToDeleteRows = false;
            this.jdgvNotaryLetter.AllowUserToOrderColumns = true;
            this.jdgvNotaryLetter.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvNotaryLetter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvNotaryLetter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvNotaryLetter.EnableContexMenu = true;
            this.jdgvNotaryLetter.KeyName = null;
            this.jdgvNotaryLetter.Location = new System.Drawing.Point(3, 19);
            this.jdgvNotaryLetter.Name = "jdgvNotaryLetter";
            this.jdgvNotaryLetter.ReadHeadersFromDB = false;
            this.jdgvNotaryLetter.ReadOnly = true;
            this.jdgvNotaryLetter.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvNotaryLetter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvNotaryLetter.ShowRowNumber = true;
            this.jdgvNotaryLetter.Size = new System.Drawing.Size(568, 242);
            this.jdgvNotaryLetter.TabIndex = 0;
            this.jdgvNotaryLetter.TableName = null;
            this.jdgvNotaryLetter.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.jdgvNotaryLetter_CellMouseDoubleClick);
            // 
            // JNotaryLetterSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 451);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JNotaryLetterSearchForm";
            this.Text = "frmNotaryLetterSearch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvNotaryLetter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JComboBox jcmbNotary;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.NumEdit txtNotary;
        private ClassLibrary.DateEdit DateLetter;
        private ClassLibrary.NumEdit txtLetterNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchNotary;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.JDataGrid jdgvNotaryLetter;
        private System.Windows.Forms.Button btnSearch;
        private ClassLibrary.DateEdit EndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnConfirm;
    }
}