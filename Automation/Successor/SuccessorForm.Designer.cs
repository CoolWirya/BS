namespace Automation
{
    partial class JSuccessorForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtStartDate = new ClassLibrary.DateEdit(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cdbReferInternal = new ClassLibrary.JCodingBox();
            this.cmbTitles = new ClassLibrary.JComboBox(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.jdgvSuccessor = new ClassLibrary.JJanusGrid();
            this.groupBox1.SuspendLayout();
            this.cdbReferInternal.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cdbReferInternal);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(223, 54);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "اضافه ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.Location = new System.Drawing.Point(142, 54);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "حذف";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 56;
            this.label2.Text = "تا تاریخ:";
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
            this.txtEndDate.Location = new System.Drawing.Point(339, 54);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate.Size = new System.Drawing.Size(100, 23);
            this.txtEndDate.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(611, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 16);
            this.label9.TabIndex = 54;
            this.label9.Text = "از تاریخ:";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDate.ChangeColorIfNotEmpty = true;
            this.txtStartDate.ChangeColorOnEnter = true;
            this.txtStartDate.Date = new System.DateTime(((long)(0)));
            this.txtStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDate.InsertInDatesTable = true;
            this.txtStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartDate.Location = new System.Drawing.Point(503, 54);
            this.txtStartDate.Mask = "0000/00/00";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.NotEmpty = false;
            this.txtStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartDate.Size = new System.Drawing.Size(100, 23);
            this.txtStartDate.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(74, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 52;
            this.button1.TabStop = false;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(607, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 51;
            this.label1.Text = "جانشین:";
            // 
            // cdbReferInternal
            // 
            this.cdbReferInternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cdbReferInternal.Controls.Add(this.cmbTitles);
            this.cdbReferInternal.dataTable = null;
            this.cdbReferInternal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cdbReferInternal.Location = new System.Drawing.Point(109, 19);
            this.cdbReferInternal.Name = "cdbReferInternal";
            this.cdbReferInternal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cdbReferInternal.SelectedIndex = -1;
            this.cdbReferInternal.SelectedValue = null;
            this.cdbReferInternal.Size = new System.Drawing.Size(494, 29);
            this.cdbReferInternal.TabIndex = 1;
            // 
            // cmbTitles
            // 
            this.cmbTitles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTitles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTitles.BaseCode = 0;
            this.cmbTitles.ChangeColorIfNotEmpty = true;
            this.cmbTitles.ChangeColorOnEnter = true;
            this.cmbTitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTitles.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbTitles.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTitles.Location = new System.Drawing.Point(0, 0);
            this.cmbTitles.Name = "cmbTitles";
            this.cmbTitles.NotEmpty = false;
            this.cmbTitles.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbTitles.SelectOnEnter = true;
            this.cmbTitles.Size = new System.Drawing.Size(494, 24);
            this.cmbTitles.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.jdgvSuccessor);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(677, 380);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "لیست جانشین ها";
            // 
            // jdgvSuccessor
            // 
            this.jdgvSuccessor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvSuccessor.Location = new System.Drawing.Point(3, 19);
            this.jdgvSuccessor.MultiSelect = false;
            this.jdgvSuccessor.Name = "jdgvSuccessor";
            this.jdgvSuccessor.Size = new System.Drawing.Size(671, 358);
            this.jdgvSuccessor.TabIndex = 10;
            // 
            // JSuccessorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 479);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JSuccessorForm";
            this.Text = "SuccessorForm";
            this.Load += new System.EventHandler(this.JSuccessorForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cdbReferInternal.ResumeLayout(false);
            this.cdbReferInternal.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.JJanusGrid jdgvSuccessor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JCodingBox cdbReferInternal;
        private ClassLibrary.JComboBox cmbTitles;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.DateEdit txtEndDate;
        private System.Windows.Forms.Label label9;
        private ClassLibrary.DateEdit txtStartDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
    }
}