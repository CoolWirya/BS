namespace Globals.Property.PropertyHistory
{
    partial class JPropertyHistoryViewForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.dgrChangeset = new ClassLibrary.JDataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgrChangeset)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.SystemColors.Info;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(575, 70);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "نام کاربر";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgrChangeset
            // 
            this.dgrChangeset.ActionMenu = jPopupMenu1;
            this.dgrChangeset.AllowUserToAddRows = false;
            this.dgrChangeset.AllowUserToDeleteRows = false;
            this.dgrChangeset.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgrChangeset.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrChangeset.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrChangeset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrChangeset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrChangeset.EnableContexMenu = true;
            this.dgrChangeset.KeyName = null;
            this.dgrChangeset.Location = new System.Drawing.Point(0, 70);
            this.dgrChangeset.Name = "dgrChangeset";
            this.dgrChangeset.ReadHeadersFromDB = false;
            this.dgrChangeset.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgrChangeset.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrChangeset.ShowRowNumber = true;
            this.dgrChangeset.Size = new System.Drawing.Size(575, 289);
            this.dgrChangeset.TabIndex = 1;
            this.dgrChangeset.TableName = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 359);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(575, 58);
            this.panel1.TabIndex = 52;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(8, 11);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 40);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "بازگشت";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDate.Location = new System.Drawing.Point(0, 70);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(575, 20);
            this.lblDate.TabIndex = 53;
            this.lblDate.Text = "تاریخ";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // JPropertyHistoryViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 417);
            this.Controls.Add(this.dgrChangeset);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblName);
            this.Name = "JPropertyHistoryViewForm";
            this.Text = "تغییرات";
            ((System.ComponentModel.ISupportInitialize)(this.dgrChangeset)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private ClassLibrary.JDataGrid dgrChangeset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblDate;
    }
}