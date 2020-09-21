namespace Estates
{
    partial class JAggregateSheetForm
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
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.jdgvAggregateSheet = new ClassLibrary.JDataGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvAggregateSheet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(12, 20);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(432, 23);
            this.txtDesc.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(447, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "توضیحات :";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(110, 49);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(96, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "تایید";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(398, 49);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // jdgvAggregateSheet
            // 
            this.jdgvAggregateSheet.ActionMenu = jPopupMenu2;
            this.jdgvAggregateSheet.AllowUserToAddRows = false;
            this.jdgvAggregateSheet.AllowUserToDeleteRows = false;
            this.jdgvAggregateSheet.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jdgvAggregateSheet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.jdgvAggregateSheet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvAggregateSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvAggregateSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvAggregateSheet.EnableContexMenu = true;
            this.jdgvAggregateSheet.KeyName = null;
            this.jdgvAggregateSheet.Location = new System.Drawing.Point(0, 76);
            this.jdgvAggregateSheet.Name = "jdgvAggregateSheet";
            this.jdgvAggregateSheet.ReadHeadersFromDB = false;
            this.jdgvAggregateSheet.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvAggregateSheet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvAggregateSheet.ShowRowNumber = true;
            this.jdgvAggregateSheet.Size = new System.Drawing.Size(517, 226);
            this.jdgvAggregateSheet.TabIndex = 1;
            this.jdgvAggregateSheet.TableName = null;
            // 
            // JAggregateSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 302);
            this.Controls.Add(this.jdgvAggregateSheet);
            this.Controls.Add(this.groupBox1);
            this.Name = "JAggregateSheetForm";
            this.Text = "AggregateForm";
            this.Load += new System.EventHandler(this.JAggregateSheetForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvAggregateSheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelete;
        private ClassLibrary.JDataGrid jdgvAggregateSheet;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label1;
    }
}