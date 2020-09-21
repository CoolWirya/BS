namespace Automation
{
    partial class JRefersGrid
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
            this.dgrRefers = new ClassLibrary.JDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dgrRefers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrRefers
            // 
            this.dgrRefers.ActionMenu = jPopupMenu1;
            this.dgrRefers.AllowUserToAddRows = false;
            this.dgrRefers.AllowUserToDeleteRows = false;
            this.dgrRefers.AllowUserToResizeColumns = false;
            this.dgrRefers.AllowUserToResizeRows = false;
            this.dgrRefers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrRefers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgrRefers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgrRefers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrRefers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrRefers.EnableContexMenu = true;
            this.dgrRefers.GridColor = System.Drawing.SystemColors.Window;
            this.dgrRefers.KeyName = null;
            this.dgrRefers.Location = new System.Drawing.Point(0, 0);
            this.dgrRefers.MultiSelect = false;
            this.dgrRefers.Name = "dgrRefers";
            this.dgrRefers.ReadHeadersFromDB = false;
            this.dgrRefers.ReadOnly = true;
            this.dgrRefers.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgrRefers.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("B Traffic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrRefers.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrRefers.RowTemplate.Height = 25;
            this.dgrRefers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrRefers.ShowRowNumber = false;
            this.dgrRefers.Size = new System.Drawing.Size(387, 265);
            this.dgrRefers.TabIndex = 0;
            this.dgrRefers.TableName = null;
            // 
            // JRefersGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgrRefers);
            this.Name = "JRefersGrid";
            this.Size = new System.Drawing.Size(387, 265);
            ((System.ComponentModel.ISupportInitialize)(this.dgrRefers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JDataGrid dgrRefers;
    }
}
