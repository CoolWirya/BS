namespace Bascol
{
    partial class JChangePlokForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPlok = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cmbTruck = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gridPlok = new ClassLibrary.JJanusGrid();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPlok);
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Controls.Add(this.cmbTruck);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 65);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblPlok
            // 
            this.lblPlok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlok.AutoSize = true;
            this.lblPlok.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPlok.Location = new System.Drawing.Point(589, 25);
            this.lblPlok.Name = "lblPlok";
            this.lblPlok.Size = new System.Drawing.Size(17, 20);
            this.lblPlok.TabIndex = 338;
            this.lblPlok.Text = "-";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(41, 22);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 27);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "تایید";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cmbTruck
            // 
            this.cmbTruck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTruck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTruck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTruck.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbTruck.FormattingEnabled = true;
            this.cmbTruck.Items.AddRange(new object[] {
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
            this.cmbTruck.Location = new System.Drawing.Point(131, 22);
            this.cmbTruck.Name = "cmbTruck";
            this.cmbTruck.Size = new System.Drawing.Size(320, 28);
            this.cmbTruck.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(457, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 336;
            this.label4.Text = "ماشین :";
            // 
            // gridPlok
            // 
            this.gridPlok.ActionMenu = null;
            this.gridPlok.DataSource = null;
            this.gridPlok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPlok.Edited = false;
            this.gridPlok.Location = new System.Drawing.Point(0, 65);
            this.gridPlok.MultiSelect = false;
            this.gridPlok.Name = "gridPlok";
            this.gridPlok.ShowNavigator = true;
            this.gridPlok.ShowToolbar = true;
            this.gridPlok.Size = new System.Drawing.Size(671, 497);
            this.gridPlok.TabIndex = 4;
            this.gridPlok.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.gridPlok_OnRowDBClick);
            // 
            // JChangePlokForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 562);
            this.Controls.Add(this.gridPlok);
            this.Controls.Add(this.groupBox1);
            this.Name = "JChangePlokForm";
            this.Text = "ChangePlokForm";
            this.Load += new System.EventHandler(this.JChangePlokForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JJanusGrid gridPlok;
        private System.Windows.Forms.Label lblPlok;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ComboBox cmbTruck;
        private System.Windows.Forms.Label label4;

    }
}