namespace ShareProfit.Payment
{
    partial class JPaymentForm
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
            ClassLibrary.JPopupMenu jPopupMenu4 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jDataGridPayment = new ClassLibrary.JDataGrid();
            this.dateEdit2 = new ClassLibrary.DateEdit(this.components);
            this.txtSheetNo = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGridPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(583, 451);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.jDataGridPayment);
            this.tabPage1.Controls.Add(this.dateEdit2);
            this.tabPage1.Controls.Add(this.txtSheetNo);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(575, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // jDataGridPayment
            // 
            this.jDataGridPayment.ActionMenu = jPopupMenu4;
            this.jDataGridPayment.AllowUserToAddRows = false;
            this.jDataGridPayment.AllowUserToDeleteRows = false;
            this.jDataGridPayment.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jDataGridPayment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.jDataGridPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jDataGridPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jDataGridPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGridPayment.EnableContexMenu = true;
            this.jDataGridPayment.KeyName = null;
            this.jDataGridPayment.Location = new System.Drawing.Point(77, 131);
            this.jDataGridPayment.Name = "jDataGridPayment";
            this.jDataGridPayment.ReadHeadersFromDB = false;
            this.jDataGridPayment.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDataGridPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGridPayment.ShowRowNumber = true;
            this.jDataGridPayment.Size = new System.Drawing.Size(433, 188);
            this.jDataGridPayment.TabIndex = 2;
            this.jDataGridPayment.TableName = null;
            // 
            // dateEdit2
            // 
            this.dateEdit2.ChangeColorIfNotEmpty = true;
            this.dateEdit2.ChangeColorOnEnter = true;
            this.dateEdit2.Date = new System.DateTime(((long)(0)));
            this.dateEdit2.InBackColor = System.Drawing.SystemColors.Info;
            this.dateEdit2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.dateEdit2.InsertInDatesTable = true;
            this.dateEdit2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dateEdit2.Location = new System.Drawing.Point(331, 40);
            this.dateEdit2.Mask = "0000/00/00";
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.NotEmpty = false;
            this.dateEdit2.NotEmptyColor = System.Drawing.Color.Red;
            this.dateEdit2.Size = new System.Drawing.Size(100, 23);
            this.dateEdit2.TabIndex = 1;
            // 
            // txtSheetNo
            // 
            this.txtSheetNo.Location = new System.Drawing.Point(446, 40);
            this.txtSheetNo.Name = "txtSheetNo";
            this.txtSheetNo.Size = new System.Drawing.Size(100, 23);
            this.txtSheetNo.TabIndex = 0;
            this.txtSheetNo.Leave += new System.EventHandler(this.txtSheetNo_Leave);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(575, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(492, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // JPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 451);
            this.Controls.Add(this.tabControl1);
            this.Name = "JPaymentForm";
            this.Text = "PayForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGridPayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ClassLibrary.DateEdit dateEdit2;
        private System.Windows.Forms.TextBox txtSheetNo;
        private ClassLibrary.JDataGrid jDataGridPayment;
        private System.Windows.Forms.Button button1;
    }
}