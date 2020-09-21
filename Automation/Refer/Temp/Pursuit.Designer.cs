namespace Automation
{
    partial class JPursuit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nedPersuit = new ClassLibrary.NumEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.chkPersuit = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nedPersuit);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.chkPersuit);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(246, 38);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "pursuit";
            // 
            // nedPersuit
            // 
            this.nedPersuit.ChangeColorIfNotEmpty = true;
            this.nedPersuit.ChangeColorOnEnter = true;
            this.nedPersuit.Enabled = false;
            this.nedPersuit.InBackColor = System.Drawing.SystemColors.Info;
            this.nedPersuit.InForeColor = System.Drawing.SystemColors.WindowText;
            this.nedPersuit.Location = new System.Drawing.Point(6, 12);
            this.nedPersuit.Name = "nedPersuit";
            this.nedPersuit.Negative = true;
            this.nedPersuit.NotEmpty = false;
            this.nedPersuit.NotEmptyColor = System.Drawing.Color.Red;
            this.nedPersuit.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.nedPersuit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nedPersuit.SelectOnEnter = true;
            this.nedPersuit.Size = new System.Drawing.Size(100, 20);
            this.nedPersuit.TabIndex = 1;
            this.nedPersuit.TextMode = ClassLibrary.TextModes.Text;
            this.nedPersuit.TextChanged += new System.EventHandler(this.nedPersuit_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(112, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Step:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // chkPersuit
            // 
            this.chkPersuit.AutoSize = true;
            this.chkPersuit.Location = new System.Drawing.Point(166, 15);
            this.chkPersuit.Name = "chkPersuit";
            this.chkPersuit.Size = new System.Drawing.Size(58, 17);
            this.chkPersuit.TabIndex = 0;
            this.chkPersuit.Text = "Pursuit";
            this.chkPersuit.UseVisualStyleBackColor = true;
            this.chkPersuit.CheckedChanged += new System.EventHandler(this.chkPersuit_CheckedChanged);
            // 
            // JPursuit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "JPursuit";
            this.Size = new System.Drawing.Size(255, 47);
            this.Load += new System.EventHandler(this.Pursuit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.NumEdit nedPersuit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkPersuit;
    }
}
