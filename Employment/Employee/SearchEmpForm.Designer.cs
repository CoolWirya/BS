namespace Employment
{
    partial class SearchEmpForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbNoActive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.txtName = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.jdgvSeperation = new ClassLibrary.JDataGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvSeperation)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbNoActive);
            this.groupBox2.Controls.Add(this.rbActive);
            this.groupBox2.Location = new System.Drawing.Point(219, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(147, 45);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            // 
            // rbNoActive
            // 
            this.rbNoActive.AutoSize = true;
            this.rbNoActive.Location = new System.Drawing.Point(6, 17);
            this.rbNoActive.Name = "rbNoActive";
            this.rbNoActive.Size = new System.Drawing.Size(75, 20);
            this.rbNoActive.TabIndex = 4;
            this.rbNoActive.Text = "منفصلین";
            this.rbNoActive.UseVisualStyleBackColor = true;
            this.rbNoActive.CheckedChanged += new System.EventHandler(this.rbNoActive_CheckedChanged);
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Location = new System.Drawing.Point(87, 17);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(49, 20);
            this.rbActive.TabIndex = 3;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "فعال";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.CheckedChanged += new System.EventHandler(this.rbActive_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.ChangeColorIfNotEmpty = false;
            this.txtName.ChangeColorOnEnter = true;
            this.txtName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(376, 20);
            this.txtName.Name = "txtName";
            this.txtName.Negative = true;
            this.txtName.NotEmpty = false;
            this.txtName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectOnEnter = true;
            this.txtName.Size = new System.Drawing.Size(157, 23);
            this.txtName.TabIndex = 1;
            this.txtName.TextMode = ClassLibrary.TextModes.Text;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(539, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = "نام و نام خانوادگی :";
            // 
            // jdgvSeperation
            // 
            this.jdgvSeperation.ActionMenu = jPopupMenu1;
            this.jdgvSeperation.AllowUserToAddRows = false;
            this.jdgvSeperation.AllowUserToDeleteRows = false;
            this.jdgvSeperation.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jdgvSeperation.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jdgvSeperation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvSeperation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvSeperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvSeperation.EnableContexMenu = true;
            this.jdgvSeperation.KeyName = null;
            this.jdgvSeperation.Location = new System.Drawing.Point(0, 52);
            this.jdgvSeperation.Name = "jdgvSeperation";
            this.jdgvSeperation.ReadHeadersFromDB = false;
            this.jdgvSeperation.ReadOnly = true;
            this.jdgvSeperation.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvSeperation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvSeperation.ShowRowNumber = true;
            this.jdgvSeperation.Size = new System.Drawing.Size(668, 353);
            this.jdgvSeperation.TabIndex = 85;
            this.jdgvSeperation.TableName = null;
            this.jdgvSeperation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jDataGrid1_CellDoubleClick);
            this.jdgvSeperation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.jdgvSeperation_KeyDown);
            // 
            // SearchEmpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 405);
            this.Controls.Add(this.jdgvSeperation);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchEmpForm";
            this.Text = "SearchEmpForm";
            this.Load += new System.EventHandler(this.SearchEmpForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvSeperation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbNoActive;
        private System.Windows.Forms.RadioButton rbActive;
        private ClassLibrary.JDataGrid jdgvSeperation;
    }
}