namespace Bascol
{
    partial class JTruckForm
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
            ClassLibrary.JPopupMenu jPopupMenu3 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtEnddate = new ClassLibrary.DateEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new ClassLibrary.TextEdit(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.jDataGrid1 = new ClassLibrary.JDataGrid();
            this.txtShortcut = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtShortcut);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnInsert);
            this.groupBox1.Controls.Add(this.txtEnddate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(24, 49);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(109, 28);
            this.btnEdit.TabIndex = 75;
            this.btnEdit.Text = "تایید";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(138, 49);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(102, 28);
            this.btnInsert.TabIndex = 74;
            this.btnInsert.Text = "درج";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtEnddate
            // 
            this.txtEnddate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnddate.ChangeColorIfNotEmpty = true;
            this.txtEnddate.ChangeColorOnEnter = true;
            this.txtEnddate.Date = new System.DateTime(((long)(0)));
            this.txtEnddate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEnddate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEnddate.InsertInDatesTable = true;
            this.txtEnddate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEnddate.Location = new System.Drawing.Point(292, 49);
            this.txtEnddate.Mask = "0000/00/00";
            this.txtEnddate.Name = "txtEnddate";
            this.txtEnddate.NotEmpty = false;
            this.txtEnddate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEnddate.Size = new System.Drawing.Size(100, 23);
            this.txtEnddate.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(399, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 72;
            this.label1.Text = "تاریخ پایان:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.ChangeColorIfNotEmpty = false;
            this.txtName.ChangeColorOnEnter = true;
            this.txtName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(469, 19);
            this.txtName.Name = "txtName";
            this.txtName.Negative = true;
            this.txtName.NotEmpty = false;
            this.txtName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectOnEnter = true;
            this.txtName.Size = new System.Drawing.Size(135, 23);
            this.txtName.TabIndex = 1;
            this.txtName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(610, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 16);
            this.label5.TabIndex = 70;
            this.label5.Text = "نام :";
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(504, 49);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(610, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 68;
            this.label2.Text = "تاریخ شروع:";
            // 
            // jDataGrid1
            // 
            this.jDataGrid1.ActionMenu = jPopupMenu3;
            this.jDataGrid1.AllowUserToAddRows = false;
            this.jDataGrid1.AllowUserToDeleteRows = false;
            this.jDataGrid1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.jDataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jDataGrid1.EnableContexMenu = true;
            this.jDataGrid1.KeyName = null;
            this.jDataGrid1.Location = new System.Drawing.Point(0, 85);
            this.jDataGrid1.Name = "jDataGrid1";
            this.jDataGrid1.ReadHeadersFromDB = false;
            this.jDataGrid1.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGrid1.ShowRowNumber = true;
            this.jDataGrid1.Size = new System.Drawing.Size(692, 464);
            this.jDataGrid1.TabIndex = 1;
            this.jDataGrid1.TableName = null;
            // 
            // txtShortcut
            // 
            this.txtShortcut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortcut.ChangeColorIfNotEmpty = false;
            this.txtShortcut.ChangeColorOnEnter = true;
            this.txtShortcut.InBackColor = System.Drawing.SystemColors.Info;
            this.txtShortcut.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShortcut.Location = new System.Drawing.Point(114, 19);
            this.txtShortcut.Name = "txtShortcut";
            this.txtShortcut.Negative = true;
            this.txtShortcut.NotEmpty = false;
            this.txtShortcut.NotEmptyColor = System.Drawing.Color.Red;
            this.txtShortcut.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShortcut.SelectOnEnter = true;
            this.txtShortcut.Size = new System.Drawing.Size(99, 23);
            this.txtShortcut.TabIndex = 5;
            this.txtShortcut.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 77;
            this.label3.Text = "Shortcut:";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(292, 19);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(99, 23);
            this.txtPrice.TabIndex = 2;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 79;
            this.label4.Text = "قیمت:";
            // 
            // JTruckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 549);
            this.Controls.Add(this.jDataGrid1);
            this.Controls.Add(this.groupBox1);
            this.Name = "JTruckForm";
            this.Text = "TruckForm";
            this.Load += new System.EventHandler(this.JTruckForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.DateEdit txtEnddate;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtName;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnInsert;
        private ClassLibrary.JDataGrid jDataGrid1;
        private ClassLibrary.TextEdit txtShortcut;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.TextEdit txtPrice;
        private System.Windows.Forms.Label label4;
    }
}