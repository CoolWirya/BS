namespace Estates
{
    partial class JSearchGroundForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtGroundCode = new System.Windows.Forms.TextBox();
            this.cmbUsage = new ClassLibrary.JComboBox(this.components);
            this.txtArea = new ClassLibrary.TextEdit(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.txtPartNum = new ClassLibrary.TextEdit(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBlockNum = new ClassLibrary.TextEdit(this.components);
            this.txtSection = new ClassLibrary.TextEdit(this.components);
            this.txtSubAve = new ClassLibrary.TextEdit(this.components);
            this.cmbLand = new ClassLibrary.JComboBox(this.components);
            this.txtMainAve = new ClassLibrary.TextEdit(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvGround = new ClassLibrary.JDataGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGround)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtGroundCode);
            this.groupBox4.Controls.Add(this.cmbUsage);
            this.groupBox4.Controls.Add(this.txtArea);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtPartNum);
            this.groupBox4.Controls.Add(this.btnSearch);
            this.groupBox4.Controls.Add(this.txtBlockNum);
            this.groupBox4.Controls.Add(this.txtSection);
            this.groupBox4.Controls.Add(this.txtSubAve);
            this.groupBox4.Controls.Add(this.cmbLand);
            this.groupBox4.Controls.Add(this.txtMainAve);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(3, 19);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(590, 228);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "موقعیت";
            // 
            // txtGroundCode
            // 
            this.txtGroundCode.Location = new System.Drawing.Point(296, 23);
            this.txtGroundCode.Name = "txtGroundCode";
            this.txtGroundCode.Size = new System.Drawing.Size(140, 23);
            this.txtGroundCode.TabIndex = 5;
            // 
            // cmbUsage
            // 
            this.cmbUsage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUsage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUsage.ChangeColorIfNotEmpty = true;
            this.cmbUsage.ChangeColorOnEnter = true;
            this.cmbUsage.FormattingEnabled = true;
            this.cmbUsage.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbUsage.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbUsage.Location = new System.Drawing.Point(66, 161);
            this.cmbUsage.Name = "cmbUsage";
            this.cmbUsage.NotEmpty = false;
            this.cmbUsage.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbUsage.SelectOnEnter = true;
            this.cmbUsage.Size = new System.Drawing.Size(141, 24);
            this.cmbUsage.TabIndex = 5;
            // 
            // txtArea
            // 
            this.txtArea.ChangeColorIfNotEmpty = true;
            this.txtArea.ChangeColorOnEnter = true;
            this.txtArea.InBackColor = System.Drawing.SystemColors.Info;
            this.txtArea.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtArea.Location = new System.Drawing.Point(67, 198);
            this.txtArea.Name = "txtArea";
            this.txtArea.Negative = true;
            this.txtArea.NotEmpty = false;
            this.txtArea.NotEmptyColor = System.Drawing.Color.Red;
            this.txtArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtArea.SelectOnEnter = true;
            this.txtArea.Size = new System.Drawing.Size(140, 23);
            this.txtArea.TabIndex = 6;
            this.txtArea.TextMode = ClassLibrary.TextModes.Real;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(462, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "کد زمین:";
            // 
            // txtPartNum
            // 
            this.txtPartNum.ChangeColorIfNotEmpty = true;
            this.txtPartNum.ChangeColorOnEnter = true;
            this.txtPartNum.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPartNum.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPartNum.Location = new System.Drawing.Point(296, 198);
            this.txtPartNum.Name = "txtPartNum";
            this.txtPartNum.Negative = true;
            this.txtPartNum.NotEmpty = false;
            this.txtPartNum.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPartNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPartNum.SelectOnEnter = true;
            this.txtPartNum.Size = new System.Drawing.Size(140, 23);
            this.txtPartNum.TabIndex = 4;
            this.txtPartNum.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(67, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(139, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBlockNum
            // 
            this.txtBlockNum.ChangeColorIfNotEmpty = true;
            this.txtBlockNum.ChangeColorOnEnter = true;
            this.txtBlockNum.InBackColor = System.Drawing.SystemColors.Info;
            this.txtBlockNum.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBlockNum.Location = new System.Drawing.Point(296, 162);
            this.txtBlockNum.Name = "txtBlockNum";
            this.txtBlockNum.Negative = true;
            this.txtBlockNum.NotEmpty = false;
            this.txtBlockNum.NotEmptyColor = System.Drawing.Color.Red;
            this.txtBlockNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBlockNum.SelectOnEnter = true;
            this.txtBlockNum.Size = new System.Drawing.Size(140, 23);
            this.txtBlockNum.TabIndex = 3;
            this.txtBlockNum.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtSection
            // 
            this.txtSection.ChangeColorIfNotEmpty = true;
            this.txtSection.ChangeColorOnEnter = true;
            this.txtSection.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSection.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSection.Location = new System.Drawing.Point(66, 53);
            this.txtSection.Name = "txtSection";
            this.txtSection.Negative = true;
            this.txtSection.NotEmpty = false;
            this.txtSection.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSection.ReadOnly = true;
            this.txtSection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSection.SelectOnEnter = true;
            this.txtSection.Size = new System.Drawing.Size(140, 23);
            this.txtSection.TabIndex = 7;
            this.txtSection.TabStop = false;
            this.txtSection.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtSubAve
            // 
            this.txtSubAve.ChangeColorIfNotEmpty = true;
            this.txtSubAve.ChangeColorOnEnter = true;
            this.txtSubAve.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSubAve.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubAve.Location = new System.Drawing.Point(65, 126);
            this.txtSubAve.Name = "txtSubAve";
            this.txtSubAve.Negative = true;
            this.txtSubAve.NotEmpty = false;
            this.txtSubAve.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSubAve.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubAve.SelectOnEnter = true;
            this.txtSubAve.Size = new System.Drawing.Size(371, 23);
            this.txtSubAve.TabIndex = 2;
            this.txtSubAve.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbLand
            // 
            this.cmbLand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbLand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLand.ChangeColorIfNotEmpty = true;
            this.cmbLand.ChangeColorOnEnter = true;
            this.cmbLand.FormattingEnabled = true;
            this.cmbLand.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbLand.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLand.Location = new System.Drawing.Point(296, 52);
            this.cmbLand.Name = "cmbLand";
            this.cmbLand.NotEmpty = false;
            this.cmbLand.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbLand.SelectOnEnter = true;
            this.cmbLand.Size = new System.Drawing.Size(140, 24);
            this.cmbLand.TabIndex = 0;
            // 
            // txtMainAve
            // 
            this.txtMainAve.ChangeColorIfNotEmpty = true;
            this.txtMainAve.ChangeColorOnEnter = true;
            this.txtMainAve.InBackColor = System.Drawing.SystemColors.Info;
            this.txtMainAve.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMainAve.Location = new System.Drawing.Point(65, 90);
            this.txtMainAve.Name = "txtMainAve";
            this.txtMainAve.Negative = true;
            this.txtMainAve.NotEmpty = false;
            this.txtMainAve.NotEmptyColor = System.Drawing.Color.Red;
            this.txtMainAve.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMainAve.SelectOnEnter = true;
            this.txtMainAve.Size = new System.Drawing.Size(371, 23);
            this.txtMainAve.TabIndex = 1;
            this.txtMainAve.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(213, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "مساحت:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "اراضی:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(443, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "شماره قطعه:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(226, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "کاربری:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "پلاک فرعی:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(450, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "پلاک اصلی:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(443, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "شماره بلوک:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "بخش:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConfirm);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 506);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(596, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(484, 22);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvGround);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 250);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(596, 256);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // dgvGround
            // 
            this.dgvGround.AllowUserToAddRows = false;
            this.dgvGround.AllowUserToDeleteRows = false;
            this.dgvGround.AllowUserToOrderColumns = true;
            this.dgvGround.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGround.EnableContexMenu = true;
            this.dgvGround.KeyName = null;
            this.dgvGround.Location = new System.Drawing.Point(3, 19);
            this.dgvGround.Name = "dgvGround";
            this.dgvGround.ReadHeadersFromDB = false;
            this.dgvGround.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgvGround.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGround.ShowRowNumber = true;
            this.dgvGround.Size = new System.Drawing.Size(590, 234);
            this.dgvGround.TabIndex = 1;
            this.dgvGround.TableName = null;
            this.dgvGround.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.jDataGrid1_MouseDoubleClick);
            // 
            // JSearchGroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JSearchGroundForm";
            this.Text = "frmSearchGround";
           // this.Load += new System.EventHandler(this.JSearchGroundForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGround)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtGroundCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnConfirm;
        private ClassLibrary.JDataGrid dgvGround;
        private System.Windows.Forms.GroupBox groupBox4;
        private ClassLibrary.JComboBox cmbUsage;
        private ClassLibrary.TextEdit txtArea;
        private ClassLibrary.TextEdit txtPartNum;
        private ClassLibrary.TextEdit txtBlockNum;
        private ClassLibrary.TextEdit txtSection;
        private ClassLibrary.TextEdit txtSubAve;
        private ClassLibrary.JComboBox cmbLand;
        private ClassLibrary.TextEdit txtMainAve;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
    }
}