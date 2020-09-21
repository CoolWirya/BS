namespace ManagementShares
{
    partial class JBreakSheetsForm
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
            ClassLibrary.JPopupMenu jPopupMenu3 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            ClassLibrary.JPopupMenu jPopupMenu4 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdCompanies = new ClassLibrary.JDataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdIncreaseHistory = new ClassLibrary.JDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanies)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIncreaseHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCompanies
            // 
            this.grdCompanies.ActionMenu = jPopupMenu3;
            this.grdCompanies.AllowUserToAddRows = false;
            this.grdCompanies.AllowUserToDeleteRows = false;
            this.grdCompanies.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grdCompanies.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdCompanies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCompanies.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdCompanies.EnableContexMenu = true;
            this.grdCompanies.KeyName = null;
            this.grdCompanies.Location = new System.Drawing.Point(0, 0);
            this.grdCompanies.Name = "grdCompanies";
            this.grdCompanies.ReadHeadersFromDB = false;
            this.grdCompanies.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdCompanies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCompanies.ShowRowNumber = true;
            this.grdCompanies.Size = new System.Drawing.Size(645, 100);
            this.grdCompanies.TabIndex = 2;
            this.grdCompanies.TableName = null;
            this.grdCompanies.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCompanies_CellEnter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 51);
            this.panel1.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(484, 7);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(132, 32);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "شکستن برگه سهم";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdIncreaseHistory);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 290);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "شکستن برگه سهم";
            // 
            // grdIncreaseHistory
            // 
            this.grdIncreaseHistory.ActionMenu = jPopupMenu4;
            this.grdIncreaseHistory.AllowUserToAddRows = false;
            this.grdIncreaseHistory.AllowUserToDeleteRows = false;
            this.grdIncreaseHistory.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grdIncreaseHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdIncreaseHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdIncreaseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIncreaseHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIncreaseHistory.EnableContexMenu = true;
            this.grdIncreaseHistory.KeyName = null;
            this.grdIncreaseHistory.Location = new System.Drawing.Point(3, 19);
            this.grdIncreaseHistory.Name = "grdIncreaseHistory";
            this.grdIncreaseHistory.ReadHeadersFromDB = false;
            this.grdIncreaseHistory.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdIncreaseHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdIncreaseHistory.ShowRowNumber = true;
            this.grdIncreaseHistory.Size = new System.Drawing.Size(639, 268);
            this.grdIncreaseHistory.TabIndex = 4;
            this.grdIncreaseHistory.TableName = null;
            // 
            // JBreakSheetsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 441);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdCompanies);
            this.Name = "JBreakSheetsForm";
            this.Text = "شکستن برگه سهم";
            this.Shown += new System.EventHandler(this.JBreakSheetsForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanies)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdIncreaseHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JDataGrid grdCompanies;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JDataGrid grdIncreaseHistory;

    }
}