namespace ShareProfit
{
    partial class JTransferDetails
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
            this.grdDetails = new ClassLibrary.JDataGrid();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDetails
            // 
            this.grdDetails.ActionMenu = jPopupMenu1;
            this.grdDetails.AllowUserToAddRows = false;
            this.grdDetails.AllowUserToDeleteRows = false;
            this.grdDetails.AllowUserToOrderColumns = true;
            this.grdDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDetails.EnableContexMenu = true;
            this.grdDetails.KeyName = "TransferDetails";
            this.grdDetails.Location = new System.Drawing.Point(0, 0);
            this.grdDetails.Name = "grdDetails";
            this.grdDetails.ReadHeadersFromDB = false;
            this.grdDetails.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDetails.ShowRowNumber = true;
            this.grdDetails.Size = new System.Drawing.Size(607, 296);
            this.grdDetails.TabIndex = 0;
            this.grdDetails.TableName = null;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(522, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // JTransferDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 343);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grdDetails);
            this.Name = "JTransferDetails";
            this.Text = "جزئیات انتقال";
            ((System.ComponentModel.ISupportInitialize)(this.grdDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JDataGrid grdDetails;
        private System.Windows.Forms.Button button1;
    }
}