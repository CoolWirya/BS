namespace Legal
{
    partial class JExpertiseForm
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
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.txtJudicial = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.jdgvFey = new ClassLibrary.JDataGrid();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtNumber = new ClassLibrary.TextEdit(this.components);
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSearchPetition = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtExpertiseComment = new ClassLibrary.TextEdit(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBranchNew = new System.Windows.Forms.TextBox();
            this.txtJudicialNew = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvFeyn = new ClassLibrary.JDataGrid();
            this.dgvFey = new System.Windows.Forms.TabControl();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvFey)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeyn)).BeginInit();
            this.dgvFey.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBranch);
            this.groupBox1.Controls.Add(this.txtJudicial);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(3, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 124);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "محل حضور:";
            // 
            // txtBranch
            // 
            this.txtBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBranch.Location = new System.Drawing.Point(74, 61);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(257, 20);
            this.txtBranch.TabIndex = 21;
            // 
            // txtJudicial
            // 
            this.txtJudicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJudicial.Location = new System.Drawing.Point(74, 31);
            this.txtJudicial.Name = "txtJudicial";
            this.txtJudicial.Size = new System.Drawing.Size(257, 20);
            this.txtJudicial.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(333, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "مجتمع قضائی:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(332, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "شعبه:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.jdgvFey);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(441, 177);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "مشخصات اخطار شونده:";
            // 
            // jdgvFey
            // 
            this.jdgvFey.ActionMenu = jPopupMenu1;
            this.jdgvFey.AllowUserToAddRows = false;
            this.jdgvFey.AllowUserToDeleteRows = false;
            this.jdgvFey.AllowUserToOrderColumns = true;
            this.jdgvFey.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvFey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvFey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvFey.EnableContexMenu = true;
            this.jdgvFey.KeyName = null;
            this.jdgvFey.Location = new System.Drawing.Point(3, 16);
            this.jdgvFey.Name = "jdgvFey";
            this.jdgvFey.ReadHeadersFromDB = false;
            this.jdgvFey.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvFey.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvFey.ShowRowNumber = true;
            this.jdgvFey.Size = new System.Drawing.Size(435, 158);
            this.jdgvFey.TabIndex = 1;
            this.jdgvFey.TableName = null;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtNumber);
            this.groupBox6.Controls.Add(this.txtSubject);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.btnSearchPetition);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(511, 80);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            // 
            // txtNumber
            // 
            this.txtNumber.ChangeColorIfNotEmpty = false;
            this.txtNumber.ChangeColorOnEnter = true;
            this.txtNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumber.Location = new System.Drawing.Point(229, 19);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Negative = true;
            this.txtNumber.NotEmpty = false;
            this.txtNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumber.ReadOnly = true;
            this.txtNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumber.SelectOnEnter = true;
            this.txtNumber.Size = new System.Drawing.Size(136, 23);
            this.txtNumber.TabIndex = 22;
            this.txtNumber.TextMode = ClassLibrary.TextModes.Text;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Enabled = false;
            this.txtSubject.Location = new System.Drawing.Point(174, 48);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(268, 23);
            this.txtSubject.TabIndex = 21;
            this.txtSubject.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(371, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 16);
            this.label13.TabIndex = 8;
            this.label13.Text = "کددادخواست/شکوائیه:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(451, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 16);
            this.label16.TabIndex = 11;
            this.label16.Text = " موضوع:";
            // 
            // btnSearchPetition
            // 
            this.btnSearchPetition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchPetition.Location = new System.Drawing.Point(174, 19);
            this.btnSearchPetition.Name = "btnSearchPetition";
            this.btnSearchPetition.Size = new System.Drawing.Size(37, 23);
            this.btnSearchPetition.TabIndex = 10;
            this.btnSearchPetition.Text = "...";
            this.btnSearchPetition.UseVisualStyleBackColor = true;
            this.btnSearchPetition.Click += new System.EventHandler(this.btnSearchPetition_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtExpertiseComment);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(494, 356);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "نتایج دادگاه";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtExpertiseComment
            // 
            this.txtExpertiseComment.ChangeColorIfNotEmpty = false;
            this.txtExpertiseComment.ChangeColorOnEnter = true;
            this.txtExpertiseComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtExpertiseComment.InBackColor = System.Drawing.SystemColors.Info;
            this.txtExpertiseComment.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtExpertiseComment.Location = new System.Drawing.Point(3, 32);
            this.txtExpertiseComment.Multiline = true;
            this.txtExpertiseComment.Name = "txtExpertiseComment";
            this.txtExpertiseComment.Negative = true;
            this.txtExpertiseComment.NotEmpty = false;
            this.txtExpertiseComment.NotEmptyColor = System.Drawing.Color.Red;
            this.txtExpertiseComment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtExpertiseComment.SelectOnEnter = true;
            this.txtExpertiseComment.Size = new System.Drawing.Size(488, 321);
            this.txtExpertiseComment.TabIndex = 7;
            this.txtExpertiseComment.TextMode = ClassLibrary.TextModes.Text;
            this.txtExpertiseComment.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(390, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "نظر کارشناسی:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(494, 356);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "مشخصات";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBranchNew);
            this.groupBox2.Controls.Add(this.txtJudicialNew);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(3, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 124);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "محل حضور:";
            // 
            // txtBranchNew
            // 
            this.txtBranchNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBranchNew.Location = new System.Drawing.Point(85, 75);
            this.txtBranchNew.Name = "txtBranchNew";
            this.txtBranchNew.Size = new System.Drawing.Size(257, 23);
            this.txtBranchNew.TabIndex = 21;
            this.txtBranchNew.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // txtJudicialNew
            // 
            this.txtJudicialNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJudicialNew.Location = new System.Drawing.Point(85, 31);
            this.txtJudicialNew.Name = "txtJudicialNew";
            this.txtJudicialNew.Size = new System.Drawing.Size(257, 23);
            this.txtJudicialNew.TabIndex = 20;
            this.txtJudicialNew.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "مجتمع قضائی:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "شعبه:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvFeyn);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(488, 177);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "مشخصات احضار شونده:";
            // 
            // dgvFeyn
            // 
            this.dgvFeyn.ActionMenu = jPopupMenu2;
            this.dgvFeyn.AllowUserToAddRows = false;
            this.dgvFeyn.AllowUserToDeleteRows = false;
            this.dgvFeyn.AllowUserToOrderColumns = true;
            this.dgvFeyn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFeyn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeyn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFeyn.EnableContexMenu = true;
            this.dgvFeyn.KeyName = null;
            this.dgvFeyn.Location = new System.Drawing.Point(3, 19);
            this.dgvFeyn.Name = "dgvFeyn";
            this.dgvFeyn.ReadHeadersFromDB = false;
            this.dgvFeyn.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgvFeyn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFeyn.ShowRowNumber = true;
            this.dgvFeyn.Size = new System.Drawing.Size(482, 155);
            this.dgvFeyn.TabIndex = 1;
            this.dgvFeyn.TableName = null;
            // 
            // dgvFey
            // 
            this.dgvFey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFey.Controls.Add(this.tabPage4);
            this.dgvFey.Controls.Add(this.tabPage2);
            this.dgvFey.Location = new System.Drawing.Point(9, 86);
            this.dgvFey.Name = "dgvFey";
            this.dgvFey.RightToLeftLayout = true;
            this.dgvFey.SelectedIndex = 0;
            this.dgvFey.Size = new System.Drawing.Size(502, 385);
            this.dgvFey.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(101, 499);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(323, 499);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // JExpertiseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 538);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.dgvFey);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JExpertiseForm";
            this.Text = "JExpertiseForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvFey)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeyn)).EndInit();
            this.dgvFey.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.TextBox txtJudicial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private ClassLibrary.JDataGrid jdgvFey;
        private System.Windows.Forms.GroupBox groupBox6;
        private ClassLibrary.TextEdit txtNumber;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSearchPetition;
        private System.Windows.Forms.TabPage tabPage2;
        private ClassLibrary.TextEdit txtExpertiseComment;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBranchNew;
        private System.Windows.Forms.TextBox txtJudicialNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.JDataGrid dgvFeyn;
        private System.Windows.Forms.TabControl dgvFey;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;

    }
}