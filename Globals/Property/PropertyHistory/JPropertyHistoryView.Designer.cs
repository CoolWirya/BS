namespace Globals.Property.PropertyHistory
{
    partial class JPropertyHistoryView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.jDataGrid1 = new ClassLibrary.JDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // jDataGrid1
            // 
            this.jDataGrid1.ActionMenu = jPopupMenu1;
            this.jDataGrid1.AllowUserToAddRows = false;
            this.jDataGrid1.AllowUserToDeleteRows = false;
            this.jDataGrid1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jDataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jDataGrid1.EnableContexMenu = true;
            this.jDataGrid1.KeyName = null;
            this.jDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.jDataGrid1.Name = "jDataGrid1";
            this.jDataGrid1.ReadHeadersFromDB = false;
            this.jDataGrid1.ReadOnly = true;
            this.jDataGrid1.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGrid1.ShowRowNumber = true;
            this.jDataGrid1.Size = new System.Drawing.Size(394, 331);
            this.jDataGrid1.TabIndex = 0;
            this.jDataGrid1.TableName = null;
            this.jDataGrid1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.jDataGrid1_MouseDoubleClick);
            // 
            // JPropertyHistoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jDataGrid1);
            this.Name = "JPropertyHistoryView";
            this.Size = new System.Drawing.Size(394, 331);
            this.Load += new System.EventHandler(this.JPropertyHistoryView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JDataGrid jDataGrid1;
    }
}
