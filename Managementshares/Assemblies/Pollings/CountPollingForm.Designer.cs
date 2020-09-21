namespace ManagementShares
{
    partial class JCountPollingForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveVote = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbCandidas = new ClassLibrary.JComboBox(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSahamdari = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtRightCount = new ClassLibrary.TextEdit(this.components);
            this.txtVoteNo = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.grdSelected = new ClassLibrary.JDataGrid();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 591);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(12, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveVote
            // 
            this.btnSaveVote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveVote.Location = new System.Drawing.Point(293, 4);
            this.btnSaveVote.Name = "btnSaveVote";
            this.btnSaveVote.Size = new System.Drawing.Size(305, 29);
            this.btnSaveVote.TabIndex = 1;
            this.btnSaveVote.Text = "ثبت برگه رأی - F2";
            this.btnSaveVote.UseVisualStyleBackColor = true;
            this.btnSaveVote.Click += new System.EventHandler(this.btnSaveVote_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbCandidas);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 47);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "لیست کاندیدا";
            // 
            // cmbCandidas
            // 
            this.cmbCandidas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCandidas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCandidas.BaseCode = 0;
            this.cmbCandidas.ChangeColorIfNotEmpty = true;
            this.cmbCandidas.ChangeColorOnEnter = true;
            this.cmbCandidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCandidas.FormattingEnabled = true;
            this.cmbCandidas.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCandidas.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCandidas.Location = new System.Drawing.Point(68, 19);
            this.cmbCandidas.Name = "cmbCandidas";
            this.cmbCandidas.NotEmpty = false;
            this.cmbCandidas.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCandidas.SelectOnEnter = true;
            this.cmbCandidas.Size = new System.Drawing.Size(553, 24);
            this.cmbCandidas.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdd.Location = new System.Drawing.Point(3, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "افزودن";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.txtSahamdari);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtRightCount);
            this.panel1.Controls.Add(this.txtVoteNo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 69);
            this.panel1.TabIndex = 0;
            // 
            // txtSahamdari
            // 
            this.txtSahamdari.ChangeColorIfNotEmpty = false;
            this.txtSahamdari.ChangeColorOnEnter = true;
            this.txtSahamdari.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSahamdari.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSahamdari.Location = new System.Drawing.Point(381, 38);
            this.txtSahamdari.Name = "txtSahamdari";
            this.txtSahamdari.Negative = true;
            this.txtSahamdari.NotEmpty = false;
            this.txtSahamdari.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSahamdari.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSahamdari.SelectOnEnter = true;
            this.txtSahamdari.Size = new System.Drawing.Size(100, 23);
            this.txtSahamdari.TabIndex = 1;
            this.txtSahamdari.TextMode = ClassLibrary.TextModes.Integer;
            this.txtSahamdari.Leave += new System.EventHandler(this.txtSahamdari_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "شماره سریال:";
            // 
            // txtRightCount
            // 
            this.txtRightCount.ChangeColorIfNotEmpty = false;
            this.txtRightCount.ChangeColorOnEnter = true;
            this.txtRightCount.InBackColor = System.Drawing.SystemColors.Info;
            this.txtRightCount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRightCount.Location = new System.Drawing.Point(172, 22);
            this.txtRightCount.Name = "txtRightCount";
            this.txtRightCount.Negative = true;
            this.txtRightCount.NotEmpty = false;
            this.txtRightCount.NotEmptyColor = System.Drawing.Color.Red;
            this.txtRightCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRightCount.SelectOnEnter = true;
            this.txtRightCount.Size = new System.Drawing.Size(100, 23);
            this.txtRightCount.TabIndex = 2;
            this.txtRightCount.TextMode = ClassLibrary.TextModes.Integer;
            this.txtRightCount.TextChanged += new System.EventHandler(this.txtRightCount_TextChanged);
            // 
            // txtVoteNo
            // 
            this.txtVoteNo.ChangeColorIfNotEmpty = false;
            this.txtVoteNo.ChangeColorOnEnter = true;
            this.txtVoteNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtVoteNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVoteNo.Location = new System.Drawing.Point(381, 9);
            this.txtVoteNo.Name = "txtVoteNo";
            this.txtVoteNo.Negative = true;
            this.txtVoteNo.NotEmpty = false;
            this.txtVoteNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtVoteNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtVoteNo.SelectOnEnter = true;
            this.txtVoteNo.Size = new System.Drawing.Size(100, 23);
            this.txtVoteNo.TabIndex = 0;
            this.txtVoteNo.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "تعداد رأی:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(498, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "شماره برگه:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSaveVote);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 555);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(624, 36);
            this.panel2.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.grdSelected);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 439);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "متخبین:";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.Location = new System.Drawing.Point(12, 410);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "حذف";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // grdSelected
            // 
            this.grdSelected.ActionMenu = jPopupMenu1;
            this.grdSelected.AllowUserToAddRows = false;
            this.grdSelected.AllowUserToDeleteRows = false;
            this.grdSelected.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grdSelected.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSelected.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSelected.EnableContexMenu = true;
            this.grdSelected.KeyName = null;
            this.grdSelected.Location = new System.Drawing.Point(3, 19);
            this.grdSelected.Name = "grdSelected";
            this.grdSelected.ReadHeadersFromDB = false;
            this.grdSelected.ReadOnly = true;
            this.grdSelected.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdSelected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSelected.ShowRowNumber = true;
            this.grdSelected.Size = new System.Drawing.Size(618, 417);
            this.grdSelected.TabIndex = 3;
            this.grdSelected.TableName = null;
            // 
            // JCountPollingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 613);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "JCountPollingForm";
            this.Text = "شمارش برگه رأی";
            this.Shown += new System.EventHandler(this.JCountPollingForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JCountPollingForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.JCountPollingForm_KeyUp);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSelected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private ClassLibrary.TextEdit txtRightCount;
        private ClassLibrary.TextEdit txtVoteNo;
        private System.Windows.Forms.Button btnSaveVote;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDel;
        private ClassLibrary.JDataGrid grdSelected;
        private ClassLibrary.JComboBox cmbCandidas;
        private ClassLibrary.TextEdit txtSahamdari;
        private System.Windows.Forms.Label label3;
    }
}