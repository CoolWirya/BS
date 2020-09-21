namespace Legal
{
    partial class JReportForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpContract = new System.Windows.Forms.TabPage();
            this.tpCheque = new System.Windows.Forms.TabPage();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.jdgvContract = new ClassLibrary.JDataGrid();
            this.jdgvCheque = new ClassLibrary.JDataGrid();
            this.tpFish = new System.Windows.Forms.TabPage();
            this.tpProm = new System.Windows.Forms.TabPage();
            this.tpAsset = new System.Windows.Forms.TabPage();
            this.jdgvFish = new ClassLibrary.JDataGrid();
            this.jdgvProm = new ClassLibrary.JDataGrid();
            this.jdgvAsset = new ClassLibrary.JDataGrid();
            this.jReport1 = new ClassLibrary.JReport();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpContract.SuspendLayout();
            this.tpCheque.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvContract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvCheque)).BeginInit();
            this.tpFish.SuspendLayout();
            this.tpProm.SuspendLayout();
            this.tpAsset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvFish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvProm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvAsset)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jReport1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(829, 432);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpContract);
            this.tabControl1.Controls.Add(this.tpCheque);
            this.tabControl1.Controls.Add(this.tpFish);
            this.tabControl1.Controls.Add(this.tpProm);
            this.tabControl1.Controls.Add(this.tpAsset);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(823, 225);
            this.tabControl1.TabIndex = 1;
            // 
            // tpContract
            // 
            this.tpContract.Controls.Add(this.jdgvContract);
            this.tpContract.Location = new System.Drawing.Point(4, 25);
            this.tpContract.Name = "tpContract";
            this.tpContract.Padding = new System.Windows.Forms.Padding(3);
            this.tpContract.Size = new System.Drawing.Size(815, 196);
            this.tpContract.TabIndex = 0;
            this.tpContract.Text = "قراردادها";
            this.tpContract.UseVisualStyleBackColor = true;
            // 
            // tpCheque
            // 
            this.tpCheque.Controls.Add(this.jdgvCheque);
            this.tpCheque.Location = new System.Drawing.Point(4, 25);
            this.tpCheque.Name = "tpCheque";
            this.tpCheque.Padding = new System.Windows.Forms.Padding(3);
            this.tpCheque.Size = new System.Drawing.Size(815, 196);
            this.tpCheque.TabIndex = 1;
            this.tpCheque.Text = "چک قرارداد";
            this.tpCheque.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(470, 16);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 679);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(829, 44);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 432);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(829, 247);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // jdgvContract
            // 
            this.jdgvContract.AllowUserToAddRows = false;
            this.jdgvContract.AllowUserToDeleteRows = false;
            this.jdgvContract.AllowUserToOrderColumns = true;
            this.jdgvContract.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvContract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvContract.EnableContexMenu = true;
            this.jdgvContract.KeyName = null;
            this.jdgvContract.Location = new System.Drawing.Point(3, 3);
            this.jdgvContract.Name = "jdgvContract";
            this.jdgvContract.ReadHeadersFromDB = false;
            this.jdgvContract.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvContract.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvContract.ShowRowNumber = true;
            this.jdgvContract.Size = new System.Drawing.Size(809, 190);
            this.jdgvContract.TabIndex = 1;
            this.jdgvContract.TableName = null;
            // 
            // jdgvCheque
            // 
            this.jdgvCheque.AllowUserToAddRows = false;
            this.jdgvCheque.AllowUserToDeleteRows = false;
            this.jdgvCheque.AllowUserToOrderColumns = true;
            this.jdgvCheque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvCheque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvCheque.EnableContexMenu = true;
            this.jdgvCheque.KeyName = null;
            this.jdgvCheque.Location = new System.Drawing.Point(3, 3);
            this.jdgvCheque.Name = "jdgvCheque";
            this.jdgvCheque.ReadHeadersFromDB = false;
            this.jdgvCheque.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvCheque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvCheque.ShowRowNumber = true;
            this.jdgvCheque.Size = new System.Drawing.Size(809, 190);
            this.jdgvCheque.TabIndex = 1;
            this.jdgvCheque.TableName = null;
            // 
            // tpFish
            // 
            this.tpFish.Controls.Add(this.jdgvFish);
            this.tpFish.Location = new System.Drawing.Point(4, 25);
            this.tpFish.Name = "tpFish";
            this.tpFish.Size = new System.Drawing.Size(815, 196);
            this.tpFish.TabIndex = 2;
            this.tpFish.Text = "فیش قرارداد";
            this.tpFish.UseVisualStyleBackColor = true;
            // 
            // tpProm
            // 
            this.tpProm.Controls.Add(this.jdgvProm);
            this.tpProm.Location = new System.Drawing.Point(4, 25);
            this.tpProm.Name = "tpProm";
            this.tpProm.Size = new System.Drawing.Size(815, 196);
            this.tpProm.TabIndex = 3;
            this.tpProm.Text = "سفته قرارداد";
            this.tpProm.UseVisualStyleBackColor = true;
            // 
            // tpAsset
            // 
            this.tpAsset.Controls.Add(this.jdgvAsset);
            this.tpAsset.Location = new System.Drawing.Point(4, 25);
            this.tpAsset.Name = "tpAsset";
            this.tpAsset.Size = new System.Drawing.Size(815, 196);
            this.tpAsset.TabIndex = 4;
            this.tpAsset.Text = "اموال";
            this.tpAsset.UseVisualStyleBackColor = true;
            // 
            // jdgvFish
            // 
            this.jdgvFish.AllowUserToAddRows = false;
            this.jdgvFish.AllowUserToDeleteRows = false;
            this.jdgvFish.AllowUserToOrderColumns = true;
            this.jdgvFish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvFish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvFish.EnableContexMenu = true;
            this.jdgvFish.KeyName = null;
            this.jdgvFish.Location = new System.Drawing.Point(0, 0);
            this.jdgvFish.Name = "jdgvFish";
            this.jdgvFish.ReadHeadersFromDB = false;
            this.jdgvFish.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvFish.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvFish.ShowRowNumber = true;
            this.jdgvFish.Size = new System.Drawing.Size(815, 196);
            this.jdgvFish.TabIndex = 2;
            this.jdgvFish.TableName = null;
            // 
            // jdgvProm
            // 
            this.jdgvProm.AllowUserToAddRows = false;
            this.jdgvProm.AllowUserToDeleteRows = false;
            this.jdgvProm.AllowUserToOrderColumns = true;
            this.jdgvProm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvProm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvProm.EnableContexMenu = true;
            this.jdgvProm.KeyName = null;
            this.jdgvProm.Location = new System.Drawing.Point(0, 0);
            this.jdgvProm.Name = "jdgvProm";
            this.jdgvProm.ReadHeadersFromDB = false;
            this.jdgvProm.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvProm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvProm.ShowRowNumber = true;
            this.jdgvProm.Size = new System.Drawing.Size(815, 196);
            this.jdgvProm.TabIndex = 2;
            this.jdgvProm.TableName = null;
            // 
            // jdgvAsset
            // 
            this.jdgvAsset.AllowUserToAddRows = false;
            this.jdgvAsset.AllowUserToDeleteRows = false;
            this.jdgvAsset.AllowUserToOrderColumns = true;
            this.jdgvAsset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvAsset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvAsset.EnableContexMenu = true;
            this.jdgvAsset.KeyName = null;
            this.jdgvAsset.Location = new System.Drawing.Point(0, 0);
            this.jdgvAsset.Name = "jdgvAsset";
            this.jdgvAsset.ReadHeadersFromDB = false;
            this.jdgvAsset.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvAsset.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvAsset.ShowRowNumber = true;
            this.jdgvAsset.Size = new System.Drawing.Size(815, 196);
            this.jdgvAsset.TabIndex = 2;
            this.jdgvAsset.TableName = null;
            // 
            // jReport1
            // 
            this.jReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jReport1.Fields = null;
            this.jReport1.Location = new System.Drawing.Point(3, 19);
            this.jReport1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jReport1.Name = "jReport1";
            this.jReport1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.jReport1.ShowAsset = false;
            this.jReport1.ShowBuild = true;
            this.jReport1.ShowContract = true;
            this.jReport1.ShowContractCheque = true;
            this.jReport1.ShowContractFish = true;
            this.jReport1.ShowContractPro = true;
            this.jReport1.ShowGround = false;
            this.jReport1.ShowLand = false;
            this.jReport1.ShowOwner = false;
            this.jReport1.Size = new System.Drawing.Size(823, 410);
            this.jReport1.TabIndex = 0;
            // 
            // JReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 723);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JReportForm";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpContract.ResumeLayout(false);
            this.tpCheque.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvContract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvCheque)).EndInit();
            this.tpFish.ResumeLayout(false);
            this.tpProm.ResumeLayout(false);
            this.tpAsset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvFish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvProm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvAsset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpContract;
        private System.Windows.Forms.TabPage tpCheque;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.JDataGrid jdgvContract;
        private ClassLibrary.JDataGrid jdgvCheque;
        private System.Windows.Forms.TabPage tpFish;
        private ClassLibrary.JDataGrid jdgvFish;
        private System.Windows.Forms.TabPage tpProm;
        private ClassLibrary.JDataGrid jdgvProm;
        private System.Windows.Forms.TabPage tpAsset;
        private ClassLibrary.JDataGrid jdgvAsset;
        private ClassLibrary.JReport jReport1;
    }
}