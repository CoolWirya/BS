namespace Bascol
{
    partial class JConfigBascolForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbBascol = new ClassLibrary.JComboBox(this.components);
            this.cmbBascolType = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(170, 104);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "ثبت";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(35, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 16);
            this.label13.TabIndex = 328;
            this.label13.Text = "باسکول شماره :";
            // 
            // cmbBascol
            // 
            this.cmbBascol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbBascol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBascol.BaseCode = 0;
            this.cmbBascol.ChangeColorIfNotEmpty = true;
            this.cmbBascol.ChangeColorOnEnter = true;
            this.cmbBascol.FormattingEnabled = true;
            this.cmbBascol.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbBascol.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBascol.Location = new System.Drawing.Point(140, 24);
            this.cmbBascol.Name = "cmbBascol";
            this.cmbBascol.NotEmpty = false;
            this.cmbBascol.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbBascol.SelectOnEnter = true;
            this.cmbBascol.Size = new System.Drawing.Size(121, 24);
            this.cmbBascol.TabIndex = 329;
            // 
            // cmbBascolType
            // 
            this.cmbBascolType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbBascolType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBascolType.BaseCode = 0;
            this.cmbBascolType.ChangeColorIfNotEmpty = true;
            this.cmbBascolType.ChangeColorOnEnter = true;
            this.cmbBascolType.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbBascolType.FormattingEnabled = true;
            this.cmbBascolType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbBascolType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBascolType.Items.AddRange(new object[] {
            "جدید",
            "قدیم"});
            this.cmbBascolType.Location = new System.Drawing.Point(140, 58);
            this.cmbBascolType.Name = "cmbBascolType";
            this.cmbBascolType.NotEmpty = true;
            this.cmbBascolType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbBascolType.SelectOnEnter = true;
            this.cmbBascolType.Size = new System.Drawing.Size(121, 24);
            this.cmbBascolType.TabIndex = 331;
            this.cmbBascolType.Text = "جدید";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 330;
            this.label1.Text = "باسکول نوع :";
            // 
            // JConfigBascolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 182);
            this.Controls.Add(this.cmbBascolType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBascol);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnSave);
            this.Name = "JConfigBascolForm";
            this.Text = "ConfigBascolForm";
            this.Load += new System.EventHandler(this.JConfigBascolForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label13;
        private ClassLibrary.JComboBox cmbBascol;
        private ClassLibrary.JComboBox cmbBascolType;
        private System.Windows.Forms.Label label1;
    }
}