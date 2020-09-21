namespace ShareProfit
{
    partial class JShowDetailsForm2
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
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdPayment = new ClassLibrary.JDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // grdPayment
            // 
            this.grdPayment.ActionMenu = jPopupMenu1;
            this.grdPayment.AllowUserToAddRows = false;
            this.grdPayment.AllowUserToDeleteRows = false;
            this.grdPayment.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grdPayment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPayment.EnableContexMenu = true;
            this.grdPayment.KeyName = null;
            this.grdPayment.Location = new System.Drawing.Point(0, 0);
            this.grdPayment.Name = "grdPayment";
            this.grdPayment.ReadHeadersFromDB = false;
            this.grdPayment.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPayment.ShowRowNumber = true;
            this.grdPayment.Size = new System.Drawing.Size(583, 451);
            this.grdPayment.TabIndex = 0;
            this.grdPayment.TableName = null;
            // 
            // JShowDetailsForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 451);
            this.Controls.Add(this.grdPayment);
            this.Name = "JShowDetailsForm2";
            this.Text = "جزئیات پرداخت";
            ((System.ComponentModel.ISupportInitialize)(this.grdPayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JDataGrid grdPayment;

    }
}