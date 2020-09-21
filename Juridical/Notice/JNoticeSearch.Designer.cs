namespace Legal
{
    partial class JNoticeSearchFrom
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtResult = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtReason = new ClassLibrary.TextEdit(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.jdgvNotice = new ClassLibrary.JDataGrid();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvNotice)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtResult);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 108);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtResult
            // 
            this.txtResult.ChangeColorIfNotEmpty = false;
            this.txtResult.ChangeColorOnEnter = true;
            this.txtResult.InBackColor = System.Drawing.SystemColors.Info;
            this.txtResult.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtResult.Location = new System.Drawing.Point(23, 74);
            this.txtResult.Name = "txtResult";
            this.txtResult.Negative = true;
            this.txtResult.NotEmpty = false;
            this.txtResult.NotEmptyColor = System.Drawing.Color.Red;
            this.txtResult.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtResult.SelectOnEnter = true;
            this.txtResult.Size = new System.Drawing.Size(476, 23);
            this.txtResult.TabIndex = 89;
            this.txtResult.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 88;
            this.label2.Text = "نتیجه حضور:";
            // 
            // txtReason
            // 
            this.txtReason.ChangeColorIfNotEmpty = false;
            this.txtReason.ChangeColorOnEnter = true;
            this.txtReason.InBackColor = System.Drawing.SystemColors.Info;
            this.txtReason.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReason.Location = new System.Drawing.Point(23, 45);
            this.txtReason.Name = "txtReason";
            this.txtReason.Negative = true;
            this.txtReason.NotEmpty = false;
            this.txtReason.NotEmptyColor = System.Drawing.Color.Red;
            this.txtReason.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReason.SelectOnEnter = true;
            this.txtReason.Size = new System.Drawing.Size(476, 23);
            this.txtReason.TabIndex = 87;
            this.txtReason.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(499, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 86;
            this.label10.Text = "علت حضور:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(154, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 24);
            this.btnSearch.TabIndex = 85;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtEndDate
            // 
            this.txtEndDate.ChangeColorIfNotEmpty = true;
            this.txtEndDate.ChangeColorOnEnter = true;
            this.txtEndDate.Date = new System.DateTime(((long)(0)));
            this.txtEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate.Location = new System.Drawing.Point(246, 17);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate.Size = new System.Drawing.Size(100, 23);
            this.txtEndDate.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 83;
            this.label1.Text = "تاریخ:";
            // 
            // txtDate
            // 
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.Location = new System.Drawing.Point(398, 17);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(498, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 81;
            this.label4.Text = "تاریخ:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 406);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 45);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(386, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.jdgvNotice);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 108);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(574, 298);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // jdgvNotice
            // 
            this.jdgvNotice.AllowUserToAddRows = false;
            this.jdgvNotice.AllowUserToDeleteRows = false;
            this.jdgvNotice.AllowUserToOrderColumns = true;
            this.jdgvNotice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvNotice.EnableContexMenu = true;
            this.jdgvNotice.KeyName = null;
            this.jdgvNotice.Location = new System.Drawing.Point(3, 19);
            this.jdgvNotice.Name = "jdgvNotice";
            this.jdgvNotice.ReadHeadersFromDB = false;
            this.jdgvNotice.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvNotice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvNotice.ShowRowNumber = true;
            this.jdgvNotice.Size = new System.Drawing.Size(568, 276);
            this.jdgvNotice.TabIndex = 1;
            this.jdgvNotice.TableName = null;
            this.jdgvNotice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jdgvNotice_CellDoubleClick);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(467, 15);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 24);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "انصراف";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // JNoticeSearchFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 451);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JNoticeSearchFrom";
            this.Text = "JNoticeSearch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvNotice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.DateEdit txtEndDate;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private ClassLibrary.TextEdit txtReason;
        private System.Windows.Forms.Label label10;
        private ClassLibrary.TextEdit txtResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private ClassLibrary.JDataGrid jdgvNotice;
        private System.Windows.Forms.Button btnClear;
    }
}