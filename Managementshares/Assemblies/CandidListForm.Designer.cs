namespace ManagementShares
{
    partial class CandidListForm
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
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            ClassLibrary.JPopupMenu jPopupMenu3 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            ClassLibrary.JPopupMenu jPopupMenu4 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.dgv1 = new ClassLibrary.JDataGrid();
            this.cmb1 = new ClassLibrary.JComboBox(this.components);
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.dgv2 = new ClassLibrary.JDataGrid();
            this.cmb2 = new ClassLibrary.JComboBox(this.components);
            this.chkShowAraa = new System.Windows.Forms.CheckBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.gb3 = new System.Windows.Forms.GroupBox();
            this.dgv3 = new ClassLibrary.JDataGrid();
            this.cmb3 = new ClassLibrary.JComboBox(this.components);
            this.gb4 = new System.Windows.Forms.GroupBox();
            this.dgv4 = new ClassLibrary.JDataGrid();
            this.cmb4 = new ClassLibrary.JComboBox(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.gb2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.gb3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv3)).BeginInit();
            this.gb4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv4)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(924, 531);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gb1);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer2.Panel1.Tag = "12";
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gb2);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer2.Size = new System.Drawing.Size(431, 137);
            this.splitContainer2.SplitterDistance = 236;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.dgv1);
            this.gb1.Controls.Add(this.cmb1);
            this.gb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb1.Location = new System.Drawing.Point(0, 0);
            this.gb1.Margin = new System.Windows.Forms.Padding(0);
            this.gb1.Name = "gb1";
            this.gb1.Padding = new System.Windows.Forms.Padding(0);
            this.gb1.Size = new System.Drawing.Size(236, 137);
            this.gb1.TabIndex = 2;
            this.gb1.TabStop = false;
            // 
            // dgv1
            // 
            this.dgv1.ActionMenu = jPopupMenu1;
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.EnableContexMenu = true;
            this.dgv1.KeyName = null;
            this.dgv1.Location = new System.Drawing.Point(0, 81);
            this.dgv1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadHeadersFromDB = false;
            this.dgv1.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.ShowRowNumber = true;
            this.dgv1.Size = new System.Drawing.Size(236, 56);
            this.dgv1.TabIndex = 3;
            this.dgv1.TableName = null;
            // 
            // cmb1
            // 
            this.cmb1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb1.BaseCode = 0;
            this.cmb1.ChangeColorIfNotEmpty = true;
            this.cmb1.ChangeColorOnEnter = true;
            this.cmb1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmb1.FormattingEnabled = true;
            this.cmb1.InBackColor = System.Drawing.SystemColors.Info;
            this.cmb1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmb1.Location = new System.Drawing.Point(0, 37);
            this.cmb1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.cmb1.Name = "cmb1";
            this.cmb1.NotEmpty = false;
            this.cmb1.NotEmptyColor = System.Drawing.Color.Red;
            this.cmb1.SelectOnEnter = true;
            this.cmb1.Size = new System.Drawing.Size(236, 44);
            this.cmb1.TabIndex = 2;
            this.cmb1.SelectedIndexChanged += new System.EventHandler(this.cmb1_SelectedIndexChanged);
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.dgv2);
            this.gb2.Controls.Add(this.cmb2);
            this.gb2.Controls.Add(this.chkShowAraa);
            this.gb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb2.Location = new System.Drawing.Point(0, 0);
            this.gb2.Margin = new System.Windows.Forms.Padding(0);
            this.gb2.Name = "gb2";
            this.gb2.Padding = new System.Windows.Forms.Padding(0);
            this.gb2.Size = new System.Drawing.Size(194, 137);
            this.gb2.TabIndex = 1;
            this.gb2.TabStop = false;
            // 
            // dgv2
            // 
            this.dgv2.ActionMenu = jPopupMenu2;
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            this.dgv2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgv2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv2.EnableContexMenu = true;
            this.dgv2.KeyName = null;
            this.dgv2.Location = new System.Drawing.Point(0, 81);
            this.dgv2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.dgv2.Name = "dgv2";
            this.dgv2.ReadHeadersFromDB = false;
            this.dgv2.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv2.ShowRowNumber = true;
            this.dgv2.Size = new System.Drawing.Size(194, 56);
            this.dgv2.TabIndex = 4;
            this.dgv2.TableName = null;
            // 
            // cmb2
            // 
            this.cmb2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb2.BaseCode = 0;
            this.cmb2.ChangeColorIfNotEmpty = true;
            this.cmb2.ChangeColorOnEnter = true;
            this.cmb2.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmb2.FormattingEnabled = true;
            this.cmb2.InBackColor = System.Drawing.SystemColors.Info;
            this.cmb2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmb2.Location = new System.Drawing.Point(0, 37);
            this.cmb2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.cmb2.Name = "cmb2";
            this.cmb2.NotEmpty = false;
            this.cmb2.NotEmptyColor = System.Drawing.Color.Red;
            this.cmb2.SelectOnEnter = true;
            this.cmb2.Size = new System.Drawing.Size(194, 44);
            this.cmb2.TabIndex = 3;
            this.cmb2.SelectedIndexChanged += new System.EventHandler(this.cmb2_SelectedIndexChanged);
            // 
            // chkShowAraa
            // 
            this.chkShowAraa.AutoSize = true;
            this.chkShowAraa.Location = new System.Drawing.Point(0, 0);
            this.chkShowAraa.Margin = new System.Windows.Forms.Padding(0);
            this.chkShowAraa.Name = "chkShowAraa";
            this.chkShowAraa.Size = new System.Drawing.Size(15, 14);
            this.chkShowAraa.TabIndex = 1;
            this.chkShowAraa.UseVisualStyleBackColor = true;
            this.chkShowAraa.CheckedChanged += new System.EventHandler(this.chkShowAraa_CheckedChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.gb3);
            this.splitContainer3.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gb4);
            this.splitContainer3.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer3.Size = new System.Drawing.Size(924, 219);
            this.splitContainer3.SplitterDistance = 509;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 0;
            // 
            // gb3
            // 
            this.gb3.Controls.Add(this.dgv3);
            this.gb3.Controls.Add(this.cmb3);
            this.gb3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb3.Location = new System.Drawing.Point(0, 0);
            this.gb3.Margin = new System.Windows.Forms.Padding(0);
            this.gb3.Name = "gb3";
            this.gb3.Padding = new System.Windows.Forms.Padding(0);
            this.gb3.Size = new System.Drawing.Size(509, 219);
            this.gb3.TabIndex = 2;
            this.gb3.TabStop = false;
            // 
            // dgv3
            // 
            this.dgv3.ActionMenu = jPopupMenu3;
            this.dgv3.AllowUserToAddRows = false;
            this.dgv3.AllowUserToDeleteRows = false;
            this.dgv3.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgv3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv3.EnableContexMenu = true;
            this.dgv3.KeyName = null;
            this.dgv3.Location = new System.Drawing.Point(0, 81);
            this.dgv3.Margin = new System.Windows.Forms.Padding(1);
            this.dgv3.Name = "dgv3";
            this.dgv3.ReadHeadersFromDB = false;
            this.dgv3.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgv3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv3.ShowRowNumber = true;
            this.dgv3.Size = new System.Drawing.Size(509, 138);
            this.dgv3.TabIndex = 4;
            this.dgv3.TableName = null;
            // 
            // cmb3
            // 
            this.cmb3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb3.BaseCode = 0;
            this.cmb3.ChangeColorIfNotEmpty = true;
            this.cmb3.ChangeColorOnEnter = true;
            this.cmb3.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmb3.FormattingEnabled = true;
            this.cmb3.InBackColor = System.Drawing.SystemColors.Info;
            this.cmb3.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmb3.Location = new System.Drawing.Point(0, 37);
            this.cmb3.Margin = new System.Windows.Forms.Padding(1);
            this.cmb3.Name = "cmb3";
            this.cmb3.NotEmpty = false;
            this.cmb3.NotEmptyColor = System.Drawing.Color.Red;
            this.cmb3.SelectOnEnter = true;
            this.cmb3.Size = new System.Drawing.Size(509, 44);
            this.cmb3.TabIndex = 3;
            this.cmb3.SelectedIndexChanged += new System.EventHandler(this.cmb3_SelectedIndexChanged);
            // 
            // gb4
            // 
            this.gb4.Controls.Add(this.dgv4);
            this.gb4.Controls.Add(this.cmb4);
            this.gb4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb4.Location = new System.Drawing.Point(0, 0);
            this.gb4.Margin = new System.Windows.Forms.Padding(0);
            this.gb4.Name = "gb4";
            this.gb4.Padding = new System.Windows.Forms.Padding(0);
            this.gb4.Size = new System.Drawing.Size(414, 219);
            this.gb4.TabIndex = 2;
            this.gb4.TabStop = false;
            // 
            // dgv4
            // 
            this.dgv4.ActionMenu = jPopupMenu4;
            this.dgv4.AllowUserToAddRows = false;
            this.dgv4.AllowUserToDeleteRows = false;
            this.dgv4.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgv4.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv4.EnableContexMenu = true;
            this.dgv4.KeyName = null;
            this.dgv4.Location = new System.Drawing.Point(0, 81);
            this.dgv4.Margin = new System.Windows.Forms.Padding(1);
            this.dgv4.Name = "dgv4";
            this.dgv4.ReadHeadersFromDB = false;
            this.dgv4.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgv4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv4.ShowRowNumber = true;
            this.dgv4.Size = new System.Drawing.Size(414, 138);
            this.dgv4.TabIndex = 4;
            this.dgv4.TableName = null;
            // 
            // cmb4
            // 
            this.cmb4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb4.BaseCode = 0;
            this.cmb4.ChangeColorIfNotEmpty = true;
            this.cmb4.ChangeColorOnEnter = true;
            this.cmb4.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmb4.FormattingEnabled = true;
            this.cmb4.InBackColor = System.Drawing.SystemColors.Info;
            this.cmb4.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmb4.Location = new System.Drawing.Point(0, 37);
            this.cmb4.Margin = new System.Windows.Forms.Padding(1);
            this.cmb4.Name = "cmb4";
            this.cmb4.NotEmpty = false;
            this.cmb4.NotEmptyColor = System.Drawing.Color.Red;
            this.cmb4.SelectOnEnter = true;
            this.cmb4.Size = new System.Drawing.Size(414, 44);
            this.cmb4.TabIndex = 3;
            this.cmb4.SelectedIndexChanged += new System.EventHandler(this.cmb4_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CandidListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 531);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("B Koodak", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CandidListForm";
            this.Text = "CandidListForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CandidListForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gb1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.gb3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv3)).EndInit();
            this.gb4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.GroupBox gb3;
        private System.Windows.Forms.GroupBox gb4;
        private System.Windows.Forms.CheckBox chkShowAraa;
        private ClassLibrary.JDataGrid dgv1;
        private ClassLibrary.JComboBox cmb1;
        private ClassLibrary.JDataGrid dgv2;
        private ClassLibrary.JComboBox cmb2;
        private ClassLibrary.JDataGrid dgv3;
        private ClassLibrary.JComboBox cmb3;
        private ClassLibrary.JDataGrid dgv4;
        private ClassLibrary.JComboBox cmb4;
        private System.Windows.Forms.Timer timer1;
    }
}