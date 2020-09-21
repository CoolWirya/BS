namespace Globals.Property
{
    partial class JDataPropertyMainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jDataGrid1 = new ClassLibrary.JDataGrid();
            this.jComboBox1 = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.jDataGrid2 = new ClassLibrary.JDataGrid();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(574, 451);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.jDataGrid2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.jComboBox1);
            this.tabPage1.Controls.Add(this.jDataGrid1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(566, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ثبت فرم";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // jDataGrid1
            // 
            this.jDataGrid1.ActionMenu = jPopupMenu2;
            this.jDataGrid1.AllowUserToAddRows = false;
            this.jDataGrid1.AllowUserToDeleteRows = false;
            this.jDataGrid1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.jDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jDataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGrid1.EnableContexMenu = true;
            this.jDataGrid1.KeyName = null;
            this.jDataGrid1.Location = new System.Drawing.Point(6, 6);
            this.jDataGrid1.Name = "jDataGrid1";
            this.jDataGrid1.ReadHeadersFromDB = false;
            this.jDataGrid1.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGrid1.ShowRowNumber = true;
            this.jDataGrid1.Size = new System.Drawing.Size(554, 60);
            this.jDataGrid1.TabIndex = 0;
            this.jDataGrid1.TableName = null;
            // 
            // jComboBox1
            // 
            this.jComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.jComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.jComboBox1.BaseCode = 0;
            this.jComboBox1.ChangeColorIfNotEmpty = true;
            this.jComboBox1.ChangeColorOnEnter = true;
            this.jComboBox1.FormattingEnabled = true;
            this.jComboBox1.InBackColor = System.Drawing.SystemColors.Info;
            this.jComboBox1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.jComboBox1.Location = new System.Drawing.Point(6, 99);
            this.jComboBox1.Name = "jComboBox1";
            this.jComboBox1.NotEmpty = false;
            this.jComboBox1.NotEmptyColor = System.Drawing.Color.Red;
            this.jComboBox1.SelectOnEnter = true;
            this.jComboBox1.Size = new System.Drawing.Size(550, 24);
            this.jComboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(515, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "فرم ها";
            // 
            // jDataGrid2
            // 
            this.jDataGrid2.ActionMenu = jPopupMenu1;
            this.jDataGrid2.AllowUserToAddRows = false;
            this.jDataGrid2.AllowUserToDeleteRows = false;
            this.jDataGrid2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jDataGrid2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jDataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jDataGrid2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jDataGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGrid2.EnableContexMenu = true;
            this.jDataGrid2.KeyName = null;
            this.jDataGrid2.Location = new System.Drawing.Point(8, 129);
            this.jDataGrid2.Name = "jDataGrid2";
            this.jDataGrid2.ReadHeadersFromDB = false;
            this.jDataGrid2.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDataGrid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGrid2.ShowRowNumber = true;
            this.jDataGrid2.Size = new System.Drawing.Size(547, 161);
            this.jDataGrid2.TabIndex = 3;
            this.jDataGrid2.TableName = null;
            // 
            // DataPropertyMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 451);
            this.Controls.Add(this.tabControl1);
            this.Name = "DataPropertyMainForm";
            this.Text = "ثبت فرم";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ClassLibrary.JDataGrid jDataGrid1;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JComboBox jComboBox1;
        private ClassLibrary.JDataGrid jDataGrid2;

    }
}