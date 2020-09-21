namespace Parking
{
    partial class SaveElectronicCharje
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GrdData = new ClassLibrary.JDataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAmount = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDate = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.GrdUse = new ClassLibrary.JDataGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtDiv = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtKolUse = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdUse)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GrdData);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 357);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "سوابق شارژ";
            // 
            // GrdData
            // 
            this.GrdData.ActionMenu = jPopupMenu1;
            this.GrdData.AllowUserToAddRows = false;
            this.GrdData.AllowUserToDeleteRows = false;
            this.GrdData.AllowUserToOrderColumns = true;
            this.GrdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GrdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.EnableContexMenu = true;
            this.GrdData.KeyName = null;
            this.GrdData.Location = new System.Drawing.Point(3, 19);
            this.GrdData.Name = "GrdData";
            this.GrdData.ReadHeadersFromDB = false;
            this.GrdData.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.GrdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdData.ShowRowNumber = true;
            this.GrdData.Size = new System.Drawing.Size(445, 335);
            this.GrdData.TabIndex = 0;
            this.GrdData.TableName = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(465, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "شارژ كارت";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "ثبت در كارت";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.ChangeColorIfNotEmpty = false;
            this.txtAmount.ChangeColorOnEnter = true;
            this.txtAmount.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAmount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAmount.Location = new System.Drawing.Point(297, 28);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Negative = true;
            this.txtAmount.NotEmpty = false;
            this.txtAmount.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmount.SelectOnEnter = true;
            this.txtAmount.Size = new System.Drawing.Size(80, 23);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.TextMode = ClassLibrary.TextModes.Real;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "مبلغ شارژ";
            // 
            // TxtDate
            // 
            this.TxtDate.ChangeColorIfNotEmpty = true;
            this.TxtDate.ChangeColorOnEnter = true;
            this.TxtDate.Date = new System.DateTime(((long)(0)));
            this.TxtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtDate.InsertInDatesTable = true;
            this.TxtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.TxtDate.Location = new System.Drawing.Point(106, 28);
            this.TxtDate.Mask = "0000/00/00";
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.NotEmpty = false;
            this.TxtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtDate.Size = new System.Drawing.Size(80, 23);
            this.TxtDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "تاريخ اتمام شارز";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtKolUse);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtDiv);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.GrdUse);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(451, 357);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "سوابق مصرف";
            // 
            // GrdUse
            // 
            this.GrdUse.ActionMenu = jPopupMenu2;
            this.GrdUse.AllowUserToAddRows = false;
            this.GrdUse.AllowUserToDeleteRows = false;
            this.GrdUse.AllowUserToOrderColumns = true;
            this.GrdUse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GrdUse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdUse.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrdUse.EnableContexMenu = true;
            this.GrdUse.KeyName = null;
            this.GrdUse.Location = new System.Drawing.Point(3, 19);
            this.GrdUse.Name = "GrdUse";
            this.GrdUse.ReadHeadersFromDB = false;
            this.GrdUse.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.GrdUse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdUse.ShowRowNumber = true;
            this.GrdUse.Size = new System.Drawing.Size(445, 284);
            this.GrdUse.TabIndex = 0;
            this.GrdUse.TableName = null;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 65);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 392);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(457, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "سوابق شارژ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(457, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "سوابق مصرف";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtDiv
            // 
            this.txtDiv.ChangeColorIfNotEmpty = false;
            this.txtDiv.ChangeColorOnEnter = true;
            this.txtDiv.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDiv.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDiv.Location = new System.Drawing.Point(265, 319);
            this.txtDiv.Name = "txtDiv";
            this.txtDiv.Negative = true;
            this.txtDiv.NotEmpty = false;
            this.txtDiv.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDiv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDiv.SelectOnEnter = true;
            this.txtDiv.Size = new System.Drawing.Size(103, 23);
            this.txtDiv.TabIndex = 7;
            this.txtDiv.TextMode = ClassLibrary.TextModes.Real;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "مانده اعتبار :";
            // 
            // txtKolUse
            // 
            this.txtKolUse.ChangeColorIfNotEmpty = false;
            this.txtKolUse.ChangeColorOnEnter = true;
            this.txtKolUse.InBackColor = System.Drawing.SystemColors.Info;
            this.txtKolUse.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtKolUse.Location = new System.Drawing.Point(6, 319);
            this.txtKolUse.Name = "txtKolUse";
            this.txtKolUse.Negative = true;
            this.txtKolUse.NotEmpty = false;
            this.txtKolUse.NotEmptyColor = System.Drawing.Color.Red;
            this.txtKolUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtKolUse.SelectOnEnter = true;
            this.txtKolUse.Size = new System.Drawing.Size(103, 23);
            this.txtKolUse.TabIndex = 9;
            this.txtKolUse.TextMode = ClassLibrary.TextModes.Real;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "مصرف تا اين لحظه :";
            // 
            // SaveElectronicCharje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 469);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SaveElectronicCharje";
            this.Text = "SaveElectronicCharje";
            this.Load += new System.EventHandler(this.SaveElectronicCharje_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdUse)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.JDataGrid GrdData;
        private ClassLibrary.DateEdit TxtDate;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.JDataGrid GrdUse;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ClassLibrary.TextEdit txtDiv;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtKolUse;
        private System.Windows.Forms.Label label4;
    }
}