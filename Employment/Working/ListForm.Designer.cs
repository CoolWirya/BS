namespace Employment
{
    partial class JListForm
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
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFeild = new ClassLibrary.JComboBox(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.jdgvList = new ClassLibrary.JDataGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbFeild);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(886, 60);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cmbFeild
            // 
            this.cmbFeild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFeild.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbFeild.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFeild.BaseCode = 0;
            this.cmbFeild.ChangeColorIfNotEmpty = true;
            this.cmbFeild.ChangeColorOnEnter = true;
            this.cmbFeild.FormattingEnabled = true;
            this.cmbFeild.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbFeild.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFeild.Location = new System.Drawing.Point(700, 22);
            this.cmbFeild.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbFeild.Name = "cmbFeild";
            this.cmbFeild.NotEmpty = false;
            this.cmbFeild.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbFeild.SelectOnEnter = true;
            this.cmbFeild.Size = new System.Drawing.Size(157, 24);
            this.cmbFeild.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(538, 22);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 26);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(619, 22);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 26);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "تایید";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // jdgvList
            // 
            this.jdgvList.ActionMenu = jPopupMenu1;
            this.jdgvList.AllowUserToAddRows = false;
            this.jdgvList.AllowUserToDeleteRows = false;
            this.jdgvList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jdgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jdgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvList.EnableContexMenu = true;
            this.jdgvList.KeyName = null;
            this.jdgvList.Location = new System.Drawing.Point(0, 0);
            this.jdgvList.Name = "jdgvList";
            this.jdgvList.ReadHeadersFromDB = false;
            this.jdgvList.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvList.ShowRowNumber = true;
            this.jdgvList.Size = new System.Drawing.Size(886, 170);
            this.jdgvList.TabIndex = 2;
            this.jdgvList.TableName = null;
            // 
            // JListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 230);
            this.Controls.Add(this.jdgvList);
            this.Controls.Add(this.groupBox1);
            this.Name = "JListForm";
            this.Text = "ListForm";
            this.Load += new System.EventHandler(this.JListForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConfirm;
        private ClassLibrary.JDataGrid jdgvList;
        private ClassLibrary.JComboBox cmbFeild;
    }
}