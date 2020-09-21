namespace AUTOMOBILE.AutomobileDefine
{
    partial class JAutomobileSearch
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
            this.jJanusGridResault = new ClassLibrary.JJanusGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPlak3 = new System.Windows.Forms.TextBox();
            this.txtPlak1 = new System.Windows.Forms.TextBox();
            this.txtPlak2 = new System.Windows.Forms.TextBox();
            this.cmbPlak = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // jJanusGridResault
            // 
            this.jJanusGridResault.ActionClassName = "";
            this.jJanusGridResault.ActionMenu = null;
            this.jJanusGridResault.DataSource = null;
            this.jJanusGridResault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jJanusGridResault.Edited = false;
            this.jJanusGridResault.Location = new System.Drawing.Point(0, 109);
            this.jJanusGridResault.MultiSelect = true;
            this.jJanusGridResault.Name = "jJanusGridResault";
            this.jJanusGridResault.ShowNavigator = true;
            this.jJanusGridResault.ShowToolbar = true;
            this.jJanusGridResault.Size = new System.Drawing.Size(510, 253);
            this.jJanusGridResault.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtPlak3);
            this.panel1.Controls.Add(this.txtPlak1);
            this.panel1.Controls.Add(this.txtPlak2);
            this.panel1.Controls.Add(this.cmbPlak);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 109);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(210, 80);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 366;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPlak3
            // 
            this.txtPlak3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlak3.Location = new System.Drawing.Point(354, 12);
            this.txtPlak3.MaxLength = 2;
            this.txtPlak3.Name = "txtPlak3";
            this.txtPlak3.Size = new System.Drawing.Size(58, 23);
            this.txtPlak3.TabIndex = 364;
            this.txtPlak3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPlak1
            // 
            this.txtPlak1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlak1.Location = new System.Drawing.Point(110, 12);
            this.txtPlak1.MaxLength = 2;
            this.txtPlak1.Name = "txtPlak1";
            this.txtPlak1.Size = new System.Drawing.Size(58, 23);
            this.txtPlak1.TabIndex = 361;
            this.txtPlak1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPlak2
            // 
            this.txtPlak2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlak2.Location = new System.Drawing.Point(251, 12);
            this.txtPlak2.MaxLength = 3;
            this.txtPlak2.Name = "txtPlak2";
            this.txtPlak2.Size = new System.Drawing.Size(78, 23);
            this.txtPlak2.TabIndex = 363;
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
            this.cmbPlak.Location = new System.Drawing.Point(180, 11);
            this.cmbPlak.Name = "cmbPlak";
            this.cmbPlak.Size = new System.Drawing.Size(65, 24);
            this.cmbPlak.TabIndex = 362;
            this.cmbPlak.ValueMember = "21";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(335, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 16);
            this.label10.TabIndex = 365;
            this.label10.Text = "-";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(432, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 360;
            this.label6.Text = "Plaque:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 362);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(510, 31);
            this.panel2.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(423, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // JAutomobileSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 393);
            this.Controls.Add(this.jJanusGridResault);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "JAutomobileSearch";
            this.Text = "AutomobileSearch";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JJanusGrid jJanusGridResault;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtPlak3;
        private System.Windows.Forms.TextBox txtPlak1;
        private System.Windows.Forms.TextBox txtPlak2;
        private System.Windows.Forms.ComboBox cmbPlak;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
    }
}