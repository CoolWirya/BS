namespace AUTOMOBILE.AutomobileDefine
{
    partial class JAutomobileForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbMakerCompany = new ClassLibrary.JComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlak3 = new System.Windows.Forms.TextBox();
            this.txtPlak1 = new System.Windows.Forms.TextBox();
            this.txtPlak2 = new System.Windows.Forms.TextBox();
            this.cmbPlak = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbType = new ClassLibrary.JComboBox(this.components);
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(496, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(419, 7);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 303);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 33);
            this.panel1.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(583, 303);
            this.tabControl1.TabIndex = 330;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbMakerCompany);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtPlak3);
            this.tabPage1.Controls.Add(this.txtPlak1);
            this.tabPage1.Controls.Add(this.txtPlak2);
            this.tabPage1.Controls.Add(this.cmbPlak);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.cmbType);
            this.tabPage1.Controls.Add(this.chkActive);
            this.tabPage1.Controls.Add(this.txtCapacity);
            this.tabPage1.Controls.Add(this.txtModel);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(575, 274);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Car";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbMakerCompany
            // 
            this.cmbMakerCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMakerCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbMakerCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMakerCompany.BaseCode = 0;
            this.cmbMakerCompany.ChangeColorIfNotEmpty = true;
            this.cmbMakerCompany.ChangeColorOnEnter = true;
            this.cmbMakerCompany.FormattingEnabled = true;
            this.cmbMakerCompany.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbMakerCompany.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbMakerCompany.Location = new System.Drawing.Point(262, 114);
            this.cmbMakerCompany.Name = "cmbMakerCompany";
            this.cmbMakerCompany.NotEmpty = false;
            this.cmbMakerCompany.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbMakerCompany.SelectOnEnter = true;
            this.cmbMakerCompany.Size = new System.Drawing.Size(182, 24);
            this.cmbMakerCompany.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(455, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 331;
            this.label5.Text = "maker Company:";
            // 
            // txtPlak3
            // 
            this.txtPlak3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlak3.Location = new System.Drawing.Point(386, 14);
            this.txtPlak3.MaxLength = 2;
            this.txtPlak3.Name = "txtPlak3";
            this.txtPlak3.Size = new System.Drawing.Size(58, 23);
            this.txtPlak3.TabIndex = 0;
            this.txtPlak3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPlak1
            // 
            this.txtPlak1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlak1.Location = new System.Drawing.Point(148, 13);
            this.txtPlak1.MaxLength = 2;
            this.txtPlak1.Name = "txtPlak1";
            this.txtPlak1.Size = new System.Drawing.Size(58, 23);
            this.txtPlak1.TabIndex = 3;
            this.txtPlak1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPlak2
            // 
            this.txtPlak2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlak2.Location = new System.Drawing.Point(283, 14);
            this.txtPlak2.MaxLength = 3;
            this.txtPlak2.Name = "txtPlak2";
            this.txtPlak2.Size = new System.Drawing.Size(78, 23);
            this.txtPlak2.TabIndex = 1;
            this.txtPlak2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbPlak
            // 
            this.cmbPlak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPlak.DisplayMember = "21";
            this.cmbPlak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlak.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPlak.FormattingEnabled = true;
            this.cmbPlak.Items.AddRange(new object[] {
            "الف",
            "ب",
            "پ",
            "ت",
            "ث",
            "ج",
            "چ",
            "ح",
            "خ",
            "د",
            "ذ",
            "ر",
            "ز",
            "ژ",
            "س",
            "ش",
            "ص",
            "ض",
            "ط",
            "ظ",
            "ع",
            "غ",
            "ف",
            "ق",
            "ک",
            "گ",
            "ل",
            "م",
            "ن",
            "و",
            "ه",
            "ی"});
            this.cmbPlak.Location = new System.Drawing.Point(212, 13);
            this.cmbPlak.Name = "cmbPlak";
            this.cmbPlak.Size = new System.Drawing.Size(65, 24);
            this.cmbPlak.TabIndex = 2;
            this.cmbPlak.ValueMember = "21";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(367, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 16);
            this.label10.TabIndex = 342;
            this.label10.Text = "-";
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbType.BaseCode = 0;
            this.cmbType.ChangeColorIfNotEmpty = true;
            this.cmbType.ChangeColorOnEnter = true;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbType.Location = new System.Drawing.Point(262, 50);
            this.cmbType.Name = "cmbType";
            this.cmbType.NotEmpty = false;
            this.cmbType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbType.SelectOnEnter = true;
            this.cmbType.Size = new System.Drawing.Size(182, 24);
            this.cmbType.TabIndex = 4;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // chkActive
            // 
            this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(378, 173);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(66, 20);
            this.chkActive.TabIndex = 8;
            this.chkActive.Text = "Active:";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtCapacity
            // 
            this.txtCapacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCapacity.Location = new System.Drawing.Point(344, 144);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(100, 23);
            this.txtCapacity.TabIndex = 7;
            // 
            // txtModel
            // 
            this.txtModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModel.Location = new System.Drawing.Point(262, 84);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(182, 23);
            this.txtModel.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 330;
            this.label4.Text = "Capacity:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(509, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 331;
            this.label3.Text = "Model:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(515, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 332;
            this.label2.Text = "Type:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(505, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 333;
            this.label1.Text = "Plaque:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(575, 274);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Image";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // JAutomobileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 336);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "JAutomobileForm";
            this.Text = "AutomobileForm";
            this.Load += new System.EventHandler(this.JAutomobileForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtPlak3;
        private System.Windows.Forms.TextBox txtPlak1;
        private System.Windows.Forms.TextBox txtPlak2;
        private System.Windows.Forms.ComboBox cmbPlak;
        private System.Windows.Forms.Label label10;
        private ClassLibrary.JComboBox cmbType;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.JComboBox cmbMakerCompany;
    }
}