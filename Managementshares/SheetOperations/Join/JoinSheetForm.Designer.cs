namespace ManagementShares
{
    partial class JoinSheetForm
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
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.grdSheets = new ClassLibrary.JDataGrid();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdSheets)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.button2);
			this.groupBox3.Controls.Add(this.btnSave);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox3.Location = new System.Drawing.Point(0, 301);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(640, 52);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(457, 14);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 32);
			this.button2.TabIndex = 3;
			this.button2.Text = "خروج";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(538, 14);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(90, 32);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "ثبت";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.grdSheets);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(640, 301);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "برگه های انتخاب شده";
			// 
			// grdSheets
			// 
			this.grdSheets.ActionMenu = jPopupMenu1;
			this.grdSheets.AllowUserToAddRows = false;
			this.grdSheets.AllowUserToDeleteRows = false;
			this.grdSheets.AllowUserToOrderColumns = true;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.grdSheets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.grdSheets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.grdSheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdSheets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdSheets.EnableContexMenu = true;
			this.grdSheets.KeyName = null;
			this.grdSheets.Location = new System.Drawing.Point(3, 19);
			this.grdSheets.Name = "grdSheets";
			this.grdSheets.ReadHeadersFromDB = false;
			this.grdSheets.ReadOnly = true;
			this.grdSheets.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
			this.grdSheets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdSheets.ShowRowNumber = true;
			this.grdSheets.Size = new System.Drawing.Size(634, 279);
			this.grdSheets.TabIndex = 2;
			this.grdSheets.TableName = null;
			// 
			// JoinSheetForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(640, 353);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox3);
			this.Name = "JoinSheetForm";
			this.Text = "الحاق برگه سهم";
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdSheets)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JDataGrid grdSheets;

    }
}