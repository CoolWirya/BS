namespace Employment
{
    partial class JPostList
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
            this.jdgvPostList = new ClassLibrary.JDataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvPostList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // jdgvPostList
            // 
            this.jdgvPostList.AllowUserToAddRows = false;
            this.jdgvPostList.AllowUserToDeleteRows = false;
            this.jdgvPostList.AllowUserToOrderColumns = true;
            this.jdgvPostList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvPostList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvPostList.EnableContexMenu = true;
            this.jdgvPostList.KeyName = null;
            this.jdgvPostList.Location = new System.Drawing.Point(3, 19);
            this.jdgvPostList.Name = "jdgvPostList";
            this.jdgvPostList.ReadHeadersFromDB = false;
            this.jdgvPostList.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvPostList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvPostList.ShowRowNumber = true;
            this.jdgvPostList.Size = new System.Drawing.Size(318, 361);
            this.jdgvPostList.TabIndex = 0;
            this.jdgvPostList.TableName = null;
            this.jdgvPostList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jdgvPostList_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jdgvPostList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 383);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "لیست پست ها";
            // 
            // JPostList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 383);
            this.Controls.Add(this.groupBox1);
            this.Name = "JPostList";
            this.Text = "PostList";
            this.Load += new System.EventHandler(this.JPostList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvPostList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JDataGrid jdgvPostList;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}