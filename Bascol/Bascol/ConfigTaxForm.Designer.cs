namespace Bascol
{
    partial class JConfigTaxForm
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
            this.label13 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTax = new ClassLibrary.TextEdit(this.components);
            this.txtDuty = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(87, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 16);
            this.label13.TabIndex = 330;
            this.label13.Text = "مالیات :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(145, 105);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 23);
            this.btnSave.TabIndex = 329;
            this.btnSave.Text = "ثبت";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTax
            // 
            this.txtTax.ChangeColorIfNotEmpty = false;
            this.txtTax.ChangeColorOnEnter = true;
            this.txtTax.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTax.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTax.Location = new System.Drawing.Point(145, 24);
            this.txtTax.Name = "txtTax";
            this.txtTax.Negative = true;
            this.txtTax.NotEmpty = false;
            this.txtTax.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTax.SelectOnEnter = true;
            this.txtTax.Size = new System.Drawing.Size(138, 23);
            this.txtTax.TabIndex = 331;
            this.txtTax.TextMode = ClassLibrary.TextModes.Real;
            // 
            // txtDuty
            // 
            this.txtDuty.ChangeColorIfNotEmpty = false;
            this.txtDuty.ChangeColorOnEnter = true;
            this.txtDuty.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDuty.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDuty.Location = new System.Drawing.Point(145, 53);
            this.txtDuty.Name = "txtDuty";
            this.txtDuty.Negative = true;
            this.txtDuty.NotEmpty = false;
            this.txtDuty.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDuty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDuty.SelectOnEnter = true;
            this.txtDuty.Size = new System.Drawing.Size(138, 23);
            this.txtDuty.TabIndex = 333;
            this.txtDuty.TextMode = ClassLibrary.TextModes.Real;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 332;
            this.label1.Text = "عوارض :";
            // 
            // ConfigTaxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 160);
            this.Controls.Add(this.txtDuty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnSave);
            this.Name = "ConfigTaxForm";
            this.Text = "ConfigTaxForm";
            this.Load += new System.EventHandler(this.ConfigTaxForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSave;
        private ClassLibrary.TextEdit txtTax;
        private ClassLibrary.TextEdit txtDuty;
        private System.Windows.Forms.Label label1;
    }
}