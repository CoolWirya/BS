namespace RealEstate
{
    partial class JointLegal
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
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.jComboBox1 = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.jDataGrid1 = new ClassLibrary.JDataGrid();
            this.jComboBox3 = new ClassLibrary.JComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numEdit1 = new ClassLibrary.NumEdit();
            this.jComboBox2 = new ClassLibrary.JComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jComboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(619, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "كاربري :";
            // 
            // jComboBox1
            // 
            this.jComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.jComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.jComboBox1.BaseCode = 0;
            this.jComboBox1.ChangeColorIfNotEmpty = true;
            this.jComboBox1.ChangeColorOnEnter = true;
            this.jComboBox1.FormattingEnabled = true;
            this.jComboBox1.InBackColor = System.Drawing.SystemColors.Info;
            this.jComboBox1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.jComboBox1.Location = new System.Drawing.Point(227, 34);
            this.jComboBox1.Name = "jComboBox1";
            this.jComboBox1.NotEmpty = false;
            this.jComboBox1.NotEmptyColor = System.Drawing.Color.Red;
            this.jComboBox1.SelectOnEnter = true;
            this.jComboBox1.Size = new System.Drawing.Size(171, 24);
            this.jComboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(404, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "نوع كاربري(تبليغاتي،تجاري ، هردو)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.jComboBox3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numEdit1);
            this.groupBox2.Controls.Add(this.jComboBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 83);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(619, 468);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "وضعيت مالي";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.jDataGrid1);
            this.groupBox3.Location = new System.Drawing.Point(6, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(613, 316);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تعهدات تهاتر";
            // 
            // jDataGrid1
            // 
            this.jDataGrid1.ActionMenu = jPopupMenu2;
            this.jDataGrid1.AllowUserToAddRows = false;
            this.jDataGrid1.AllowUserToDeleteRows = false;
            this.jDataGrid1.AllowUserToOrderColumns = true;
            this.jDataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jDataGrid1.EnableContexMenu = true;
            this.jDataGrid1.KeyName = null;
            this.jDataGrid1.Location = new System.Drawing.Point(3, 19);
            this.jDataGrid1.Name = "jDataGrid1";
            this.jDataGrid1.ReadHeadersFromDB = false;
            this.jDataGrid1.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGrid1.ShowRowNumber = true;
            this.jDataGrid1.Size = new System.Drawing.Size(607, 294);
            this.jDataGrid1.TabIndex = 0;
            this.jDataGrid1.TableName = null;
            // 
            // jComboBox3
            // 
            this.jComboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.jComboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.jComboBox3.BaseCode = 0;
            this.jComboBox3.ChangeColorIfNotEmpty = true;
            this.jComboBox3.ChangeColorOnEnter = true;
            this.jComboBox3.FormattingEnabled = true;
            this.jComboBox3.InBackColor = System.Drawing.SystemColors.Info;
            this.jComboBox3.InForeColor = System.Drawing.SystemColors.WindowText;
            this.jComboBox3.Location = new System.Drawing.Point(12, 105);
            this.jComboBox3.Name = "jComboBox3";
            this.jComboBox3.NotEmpty = false;
            this.jComboBox3.NotEmptyColor = System.Drawing.Color.Red;
            this.jComboBox3.SelectOnEnter = true;
            this.jComboBox3.Size = new System.Drawing.Size(171, 24);
            this.jComboBox3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "نحوه تسویه (درصد فروش -خدمات)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "مبلغ اجاره واقعي :";
            // 
            // numEdit1
            // 
            this.numEdit1.ChangeColorIfNotEmpty = false;
            this.numEdit1.ChangeColorOnEnter = true;
            this.numEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.numEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.numEdit1.Location = new System.Drawing.Point(388, 106);
            this.numEdit1.Name = "numEdit1";
            this.numEdit1.Negative = true;
            this.numEdit1.NotEmpty = false;
            this.numEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.numEdit1.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.numEdit1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numEdit1.SelectOnEnter = true;
            this.numEdit1.Size = new System.Drawing.Size(104, 23);
            this.numEdit1.TabIndex = 2;
            this.numEdit1.TextMode = ClassLibrary.TextModes.Text;
            // 
            // jComboBox2
            // 
            this.jComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.jComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.jComboBox2.BaseCode = 0;
            this.jComboBox2.ChangeColorIfNotEmpty = true;
            this.jComboBox2.ChangeColorOnEnter = true;
            this.jComboBox2.FormattingEnabled = true;
            this.jComboBox2.InBackColor = System.Drawing.SystemColors.Info;
            this.jComboBox2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.jComboBox2.Location = new System.Drawing.Point(227, 42);
            this.jComboBox2.Name = "jComboBox2";
            this.jComboBox2.NotEmpty = false;
            this.jComboBox2.NotEmptyColor = System.Drawing.Color.Red;
            this.jComboBox2.SelectOnEnter = true;
            this.jComboBox2.Size = new System.Drawing.Size(133, 24);
            this.jComboBox2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "نحوه پرداخت اجاره(اجاره كامل ، تهاتر،هردو)";
            // 
            // JointLegal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 553);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JointLegal";
            this.Text = "نحوه تسويه مشاعات";
            this.Load += new System.EventHandler(this.JointLegal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JComboBox jComboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.JComboBox jComboBox2;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.JComboBox jComboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.NumEdit numEdit1;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.JDataGrid jDataGrid1;
    }
}