namespace RealEstate
{
    partial class JTransferForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit1 = new System.Windows.Forms.Button();
            this.btnDelConfirm = new System.Windows.Forms.Button();
            this.btnEditConfirm = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelRequest = new System.Windows.Forms.Button();
            this.btnEditRequest = new System.Windows.Forms.Button();
            this.btnRequest = new System.Windows.Forms.Button();
            this.jdgvTransfer = new ClassLibrary.JDataGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvTransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit1);
            this.groupBox1.Controls.Add(this.btnDelConfirm);
            this.groupBox1.Controls.Add(this.btnEditConfirm);
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 394);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 57);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // btnExit1
            // 
            this.btnExit1.Location = new System.Drawing.Point(97, 19);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(114, 26);
            this.btnExit1.TabIndex = 7;
            this.btnExit1.Text = "خروج";
            this.btnExit1.UseVisualStyleBackColor = true;
            this.btnExit1.Click += new System.EventHandler(this.btnExit1_Click);
            // 
            // btnDelConfirm
            // 
            this.btnDelConfirm.Location = new System.Drawing.Point(217, 19);
            this.btnDelConfirm.Name = "btnDelConfirm";
            this.btnDelConfirm.Size = new System.Drawing.Size(114, 26);
            this.btnDelConfirm.TabIndex = 6;
            this.btnDelConfirm.Text = "حذف ";
            this.btnDelConfirm.UseVisualStyleBackColor = true;
            this.btnDelConfirm.Click += new System.EventHandler(this.btnDelConfirm_Click);
            // 
            // btnEditConfirm
            // 
            this.btnEditConfirm.Location = new System.Drawing.Point(337, 19);
            this.btnEditConfirm.Name = "btnEditConfirm";
            this.btnEditConfirm.Size = new System.Drawing.Size(114, 26);
            this.btnEditConfirm.TabIndex = 5;
            this.btnEditConfirm.Text = "ویرایش ";
            this.btnEditConfirm.UseVisualStyleBackColor = true;
            this.btnEditConfirm.Click += new System.EventHandler(this.btnEditConfirm_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(457, 19);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(114, 26);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "تایید درخواست ";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHistory);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnDelRequest);
            this.groupBox2.Controls.Add(this.btnEditRequest);
            this.groupBox2.Controls.Add(this.btnRequest);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 336);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 58);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(14, 22);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(75, 26);
            this.btnHistory.TabIndex = 4;
            this.btnHistory.Text = "تاریخچه";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(97, 22);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(114, 26);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelRequest
            // 
            this.btnDelRequest.Location = new System.Drawing.Point(217, 22);
            this.btnDelRequest.Name = "btnDelRequest";
            this.btnDelRequest.Size = new System.Drawing.Size(114, 26);
            this.btnDelRequest.TabIndex = 2;
            this.btnDelRequest.Text = "حذف درخواست";
            this.btnDelRequest.UseVisualStyleBackColor = true;
            this.btnDelRequest.Click += new System.EventHandler(this.btnDelRequest_Click);
            // 
            // btnEditRequest
            // 
            this.btnEditRequest.Location = new System.Drawing.Point(337, 22);
            this.btnEditRequest.Name = "btnEditRequest";
            this.btnEditRequest.Size = new System.Drawing.Size(114, 26);
            this.btnEditRequest.TabIndex = 1;
            this.btnEditRequest.Text = "ویرایش درخواست";
            this.btnEditRequest.UseVisualStyleBackColor = true;
            this.btnEditRequest.Click += new System.EventHandler(this.btnEditRequest_Click);
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(457, 22);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(114, 26);
            this.btnRequest.TabIndex = 0;
            this.btnRequest.Text = "درخواست جدید";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // jdgvTransfer
            // 
            this.jdgvTransfer.ActionMenu = jPopupMenu1;
            this.jdgvTransfer.AllowUserToAddRows = false;
            this.jdgvTransfer.AllowUserToDeleteRows = false;
            this.jdgvTransfer.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jdgvTransfer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jdgvTransfer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvTransfer.EnableContexMenu = true;
            this.jdgvTransfer.KeyName = null;
            this.jdgvTransfer.Location = new System.Drawing.Point(0, 0);
            this.jdgvTransfer.Name = "jdgvTransfer";
            this.jdgvTransfer.ReadHeadersFromDB = false;
            this.jdgvTransfer.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvTransfer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvTransfer.ShowRowNumber = true;
            this.jdgvTransfer.Size = new System.Drawing.Size(583, 336);
            this.jdgvTransfer.TabIndex = 7;
            this.jdgvTransfer.TableName = null;
            this.jdgvTransfer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.jdgvTransfer_MouseDoubleClick);
            this.jdgvTransfer.SelectionChanged += new System.EventHandler(this.jdgvTransfer_SelectionChanged);
            // 
            // JTransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 451);
            this.Controls.Add(this.jdgvTransfer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JTransferForm";
            this.Text = "TransferForm";
            this.Load += new System.EventHandler(this.JTransferForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvTransfer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelRequest;
        private System.Windows.Forms.Button btnEditRequest;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnExit1;
        private System.Windows.Forms.Button btnDelConfirm;
        private System.Windows.Forms.Button btnEditConfirm;
        private System.Windows.Forms.Button btnConfirm;
        private ClassLibrary.JDataGrid jdgvTransfer;
        private System.Windows.Forms.Button btnHistory;
    }
}