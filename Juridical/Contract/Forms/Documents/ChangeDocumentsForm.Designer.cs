namespace Legal.Contract.Forms.Documents
{
    partial class JChangeDocumentsForm
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
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.jDataGridNew = new ClassLibrary.JDataGrid();
            this.jDataGridOld = new ClassLibrary.JDataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEbtal = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTypeDoc = new System.Windows.Forms.ComboBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnCancelEbtal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGridNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGridOld)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // jDataGridNew
            // 
            this.jDataGridNew.ActionMenu = jPopupMenu1;
            this.jDataGridNew.AllowUserToAddRows = false;
            this.jDataGridNew.AllowUserToDeleteRows = false;
            this.jDataGridNew.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jDataGridNew.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jDataGridNew.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jDataGridNew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGridNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jDataGridNew.EnableContexMenu = true;
            this.jDataGridNew.KeyName = null;
            this.jDataGridNew.Location = new System.Drawing.Point(0, 344);
            this.jDataGridNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jDataGridNew.Name = "jDataGridNew";
            this.jDataGridNew.ReadHeadersFromDB = false;
            this.jDataGridNew.ReadOnly = true;
            this.jDataGridNew.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDataGridNew.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGridNew.ShowRowNumber = true;
            this.jDataGridNew.Size = new System.Drawing.Size(779, 133);
            this.jDataGridNew.TabIndex = 15;
            this.jDataGridNew.TableName = null;
            // 
            // jDataGridOld
            // 
            this.jDataGridOld.ActionMenu = jPopupMenu2;
            this.jDataGridOld.AllowUserToAddRows = false;
            this.jDataGridOld.AllowUserToDeleteRows = false;
            this.jDataGridOld.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jDataGridOld.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.jDataGridOld.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jDataGridOld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGridOld.Dock = System.Windows.Forms.DockStyle.Top;
            this.jDataGridOld.EnableContexMenu = true;
            this.jDataGridOld.KeyName = null;
            this.jDataGridOld.Location = new System.Drawing.Point(0, 0);
            this.jDataGridOld.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jDataGridOld.Name = "jDataGridOld";
            this.jDataGridOld.ReadHeadersFromDB = false;
            this.jDataGridOld.ReadOnly = true;
            this.jDataGridOld.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDataGridOld.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGridOld.ShowRowNumber = true;
            this.jDataGridOld.Size = new System.Drawing.Size(779, 246);
            this.jDataGridOld.TabIndex = 16;
            this.jDataGridOld.TableName = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelEbtal);
            this.panel1.Controls.Add(this.btnEbtal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 246);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 50);
            this.panel1.TabIndex = 17;
            // 
            // btnEbtal
            // 
            this.btnEbtal.Location = new System.Drawing.Point(678, 7);
            this.btnEbtal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEbtal.Name = "btnEbtal";
            this.btnEbtal.Size = new System.Drawing.Size(87, 28);
            this.btnEbtal.TabIndex = 0;
            this.btnEbtal.Text = "ابطال";
            this.btnEbtal.UseVisualStyleBackColor = true;
            this.btnEbtal.Click += new System.EventHandler(this.btnEbtal_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnApply);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 477);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(779, 50);
            this.panel2.TabIndex = 18;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(585, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(678, 8);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(87, 28);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "تایید";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReg);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbTypeDoc);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(779, 48);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            // 
            // btnReg
            // 
            this.btnReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReg.Location = new System.Drawing.Point(439, 16);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(41, 25);
            this.btnReg.TabIndex = 63;
            this.btnReg.Text = "+";
            this.btnReg.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(709, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "نوع سند:";
            // 
            // cmbTypeDoc
            // 
            this.cmbTypeDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTypeDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeDoc.FormattingEnabled = true;
            this.cmbTypeDoc.Location = new System.Drawing.Point(486, 17);
            this.cmbTypeDoc.Name = "cmbTypeDoc";
            this.cmbTypeDoc.Size = new System.Drawing.Size(217, 24);
            this.cmbTypeDoc.TabIndex = 2;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(358, 16);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 25);
            this.btnDel.TabIndex = 62;
            this.btnDel.Text = "حذف ";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnCancelEbtal
            // 
            this.btnCancelEbtal.Location = new System.Drawing.Point(585, 7);
            this.btnCancelEbtal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelEbtal.Name = "btnCancelEbtal";
            this.btnCancelEbtal.Size = new System.Drawing.Size(87, 28);
            this.btnCancelEbtal.TabIndex = 0;
            this.btnCancelEbtal.Text = "حذف از ابطال";
            this.btnCancelEbtal.UseVisualStyleBackColor = true;
            this.btnCancelEbtal.Click += new System.EventHandler(this.btnCancelEbtal_Click);
            // 
            // JChangeDocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 527);
            this.Controls.Add(this.jDataGridNew);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.jDataGridOld);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JChangeDocumentsForm";
            this.Text = "ChangeDocumentsForm";
            ((System.ComponentModel.ISupportInitialize)(this.jDataGridNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGridOld)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JDataGrid jDataGridNew;
        private ClassLibrary.JDataGrid jDataGridOld;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEbtal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTypeDoc;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnCancelEbtal;
    }
}