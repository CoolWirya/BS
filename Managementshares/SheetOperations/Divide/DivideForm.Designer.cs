namespace ManagementShares
{
    partial class JDivideForm
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
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grddividedSheets = new ClassLibrary.JDataGrid();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDivideCount = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.grdSheets = new ClassLibrary.JDataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grddividedSheets)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSheets)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 326);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(795, 52);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(612, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "خروج";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(693, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "ثبت تقسیم";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grddividedSheets
            // 
            this.grddividedSheets.ActionMenu = jPopupMenu1;
            this.grddividedSheets.AllowUserToAddRows = false;
            this.grddividedSheets.AllowUserToDeleteRows = false;
            this.grddividedSheets.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grddividedSheets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grddividedSheets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grddividedSheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grddividedSheets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grddividedSheets.EnableContexMenu = true;
            this.grddividedSheets.KeyName = null;
            this.grddividedSheets.Location = new System.Drawing.Point(3, 19);
            this.grddividedSheets.Name = "grddividedSheets";
            this.grddividedSheets.ReadHeadersFromDB = false;
            this.grddividedSheets.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grddividedSheets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grddividedSheets.ShowRowNumber = true;
            this.grddividedSheets.Size = new System.Drawing.Size(789, 116);
            this.grddividedSheets.TabIndex = 3;
            this.grddividedSheets.TableName = null;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.grddividedSheets);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 188);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(795, 138);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "برگه های ایجاد شده";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDivideCount);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(789, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtDivideCount
            // 
            this.txtDivideCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDivideCount.ChangeColorIfNotEmpty = false;
            this.txtDivideCount.ChangeColorOnEnter = true;
            this.txtDivideCount.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDivideCount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDivideCount.Location = new System.Drawing.Point(573, 16);
            this.txtDivideCount.Name = "txtDivideCount";
            this.txtDivideCount.Negative = true;
            this.txtDivideCount.NotEmpty = false;
            this.txtDivideCount.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDivideCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDivideCount.SelectOnEnter = true;
            this.txtDivideCount.Size = new System.Drawing.Size(100, 23);
            this.txtDivideCount.TabIndex = 1;
            this.txtDivideCount.TextMode = ClassLibrary.TextModes.Integer;
            this.txtDivideCount.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(690, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "تعداد تقسیمات:";
            // 
            // grdSheets
            // 
            this.grdSheets.ActionMenu = jPopupMenu2;
            this.grdSheets.AllowUserToAddRows = false;
            this.grdSheets.AllowUserToDeleteRows = false;
            this.grdSheets.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grdSheets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdSheets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdSheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSheets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSheets.EnableContexMenu = true;
            this.grdSheets.KeyName = null;
            this.grdSheets.Location = new System.Drawing.Point(3, 19);
            this.grdSheets.Name = "grdSheets";
            this.grdSheets.ReadHeadersFromDB = false;
            this.grdSheets.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdSheets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSheets.ShowRowNumber = true;
            this.grdSheets.Size = new System.Drawing.Size(789, 118);
            this.grdSheets.TabIndex = 3;
            this.grdSheets.TableName = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdSheets);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 188);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "برگه انتخاب شده";
            // 
            // JDivideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 378);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JDivideForm";
            this.Text = "تقسیم برگه سهم";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grddividedSheets)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSheets)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
        private ClassLibrary.JDataGrid grddividedSheets;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.TextEdit txtDivideCount;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JDataGrid grdSheets;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}