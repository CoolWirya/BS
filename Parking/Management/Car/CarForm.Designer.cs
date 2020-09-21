namespace Parking
{
    partial class JCarForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BtnDel = new System.Windows.Forms.Button();
            this.Grdkhodro = new ClassLibrary.JDataGrid();
            this.BtnNew = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grdkhodro)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(839, 331);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BtnNew);
            this.tabPage3.Controls.Add(this.BtnDel);
            this.tabPage3.Controls.Add(this.Grdkhodro);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(831, 302);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ساير خودروها";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BtnDel
            // 
            this.BtnDel.Location = new System.Drawing.Point(550, 259);
            this.BtnDel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(135, 34);
            this.BtnDel.TabIndex = 55;
            this.BtnDel.Text = "حذف";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // Grdkhodro
            // 
            this.Grdkhodro.ActionMenu = jPopupMenu1;
            this.Grdkhodro.AllowUserToAddRows = false;
            this.Grdkhodro.AllowUserToDeleteRows = false;
            this.Grdkhodro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Grdkhodro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grdkhodro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grdkhodro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grdkhodro.Dock = System.Windows.Forms.DockStyle.Top;
            this.Grdkhodro.EnableContexMenu = true;
            this.Grdkhodro.KeyName = null;
            this.Grdkhodro.Location = new System.Drawing.Point(3, 3);
            this.Grdkhodro.Name = "Grdkhodro";
            this.Grdkhodro.ReadHeadersFromDB = false;
            this.Grdkhodro.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.Grdkhodro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grdkhodro.ShowRowNumber = true;
            this.Grdkhodro.Size = new System.Drawing.Size(825, 251);
            this.Grdkhodro.TabIndex = 0;
            this.Grdkhodro.TableName = null;
            this.Grdkhodro.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Grdkhodro_CellMouseDoubleClick);
            // 
            // BtnNew
            // 
            this.BtnNew.Location = new System.Drawing.Point(691, 259);
            this.BtnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(135, 34);
            this.BtnNew.TabIndex = 55;
            this.BtnNew.Text = "جديد";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // JCarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 331);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JCarForm";
            this.Text = "تعريف خودرو";
            this.Load += new System.EventHandler(this.JCarForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grdkhodro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private ClassLibrary.JDataGrid Grdkhodro;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.Button BtnNew;
    }
}