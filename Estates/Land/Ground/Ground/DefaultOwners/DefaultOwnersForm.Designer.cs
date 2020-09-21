namespace Estates
{
    partial class JDefaultOwnersForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnok = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DelPrimaryOwners = new System.Windows.Forms.Button();
            this.AddPrimaryOwners = new System.Windows.Forms.Button();
            this.grdDefaultOwners = new ClassLibrary.JDataGrid();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDefaultOwners)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnok);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 401);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 50);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(353, 11);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 33);
            this.btnok.TabIndex = 0;
            this.btnok.Text = "تایید";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 33);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DelPrimaryOwners);
            this.panel2.Controls.Add(this.AddPrimaryOwners);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 363);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(446, 38);
            this.panel2.TabIndex = 1;
            // 
            // DelPrimaryOwners
            // 
            this.DelPrimaryOwners.Location = new System.Drawing.Point(272, 9);
            this.DelPrimaryOwners.Name = "DelPrimaryOwners";
            this.DelPrimaryOwners.Size = new System.Drawing.Size(75, 23);
            this.DelPrimaryOwners.TabIndex = 1;
            this.DelPrimaryOwners.Text = "حذف";
            this.DelPrimaryOwners.UseVisualStyleBackColor = true;
            this.DelPrimaryOwners.Click += new System.EventHandler(this.DelPrimaryOwners_Click);
            // 
            // AddPrimaryOwners
            // 
            this.AddPrimaryOwners.Location = new System.Drawing.Point(353, 9);
            this.AddPrimaryOwners.Name = "AddPrimaryOwners";
            this.AddPrimaryOwners.Size = new System.Drawing.Size(75, 23);
            this.AddPrimaryOwners.TabIndex = 0;
            this.AddPrimaryOwners.Text = "اضافه";
            this.AddPrimaryOwners.UseVisualStyleBackColor = true;
            this.AddPrimaryOwners.Click += new System.EventHandler(this.AddPrimaryOwners_Click);
            // 
            // grdDefaultOwners
            // 
            this.grdDefaultOwners.ActionMenu = jPopupMenu1;
            this.grdDefaultOwners.AllowUserToAddRows = false;
            this.grdDefaultOwners.AllowUserToDeleteRows = false;
            this.grdDefaultOwners.AllowUserToOrderColumns = true;
            this.grdDefaultOwners.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdDefaultOwners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDefaultOwners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDefaultOwners.EnableContexMenu = true;
            this.grdDefaultOwners.KeyName = null;
            this.grdDefaultOwners.Location = new System.Drawing.Point(0, 0);
            this.grdDefaultOwners.Name = "grdDefaultOwners";
            this.grdDefaultOwners.ReadHeadersFromDB = false;
            this.grdDefaultOwners.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdDefaultOwners.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDefaultOwners.ShowRowNumber = true;
            this.grdDefaultOwners.Size = new System.Drawing.Size(446, 363);
            this.grdDefaultOwners.TabIndex = 0;
            this.grdDefaultOwners.TableName = null;
            // 
            // JDefaultOwnersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 451);
            this.Controls.Add(this.grdDefaultOwners);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JDefaultOwnersForm";
            this.Text = "DefaultOwners";
            this.Load += new System.EventHandler(this.JDefaultOwnersForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDefaultOwners)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private ClassLibrary.JDataGrid grdDefaultOwners;
        private System.Windows.Forms.Button DelPrimaryOwners;
        private System.Windows.Forms.Button AddPrimaryOwners;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnok;

    }
}