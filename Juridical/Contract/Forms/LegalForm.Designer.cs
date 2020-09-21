namespace Legal
{
    partial class LegalForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDetails = new System.Windows.Forms.Button();
            this.jdgvPetition = new ClassLibrary.JDataGrid();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvPetition)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDetails);
            this.groupBox4.Controls.Add(this.jdgvPetition);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(574, 345);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "دادخواستها ، شکوائیه ها";
            // 
            // btnDetails
            // 
            this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetails.Location = new System.Drawing.Point(487, 313);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 26);
            this.btnDetails.TabIndex = 2;
            this.btnDetails.Text = "جزئیات ...";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // jdgvPetition
            // 
            this.jdgvPetition.AllowUserToAddRows = false;
            this.jdgvPetition.AllowUserToDeleteRows = false;
            this.jdgvPetition.AllowUserToOrderColumns = true;
            this.jdgvPetition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvPetition.Dock = System.Windows.Forms.DockStyle.Top;
            this.jdgvPetition.EnableContexMenu = true;
            this.jdgvPetition.KeyName = null;
            this.jdgvPetition.Location = new System.Drawing.Point(3, 19);
            this.jdgvPetition.Name = "jdgvPetition";
            this.jdgvPetition.ReadHeadersFromDB = false;
            this.jdgvPetition.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvPetition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvPetition.ShowRowNumber = true;
            this.jdgvPetition.Size = new System.Drawing.Size(568, 288);
            this.jdgvPetition.TabIndex = 7;
            this.jdgvPetition.TableName = null;
            // 
            // LegalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 346);
            this.Controls.Add(this.groupBox4);
            this.Name = "LegalForm";
            this.Text = "اطلاعات حقوقی قرارداد";
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvPetition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDetails;
        private ClassLibrary.JDataGrid jdgvPetition;
    }
}