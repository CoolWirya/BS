namespace Legal
{
    partial class JCommitmentsForm
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGuarantee = new ClassLibrary.TextEdit(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCondition = new ClassLibrary.TextEdit(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(93, 350);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "قبلی";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(487, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(12, 350);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "بعدی";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGuarantee);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 153);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تبصره تعهدات";
            // 
            // txtGuarantee
            // 
            this.txtGuarantee.ChangeColorIfNotEmpty = true;
            this.txtGuarantee.ChangeColorOnEnter = true;
            this.txtGuarantee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGuarantee.InBackColor = System.Drawing.SystemColors.Info;
            this.txtGuarantee.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGuarantee.Location = new System.Drawing.Point(3, 19);
            this.txtGuarantee.Multiline = true;
            this.txtGuarantee.Name = "txtGuarantee";
            this.txtGuarantee.Negative = true;
            this.txtGuarantee.NotEmpty = false;
            this.txtGuarantee.NotEmptyColor = System.Drawing.Color.Red;
            this.txtGuarantee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGuarantee.SelectOnEnter = true;
            this.txtGuarantee.Size = new System.Drawing.Size(568, 131);
            this.txtGuarantee.TabIndex = 1;
            this.txtGuarantee.TextMode = ClassLibrary.TextModes.Text;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCondition);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 191);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "تبصره شروط";
            // 
            // txtCondition
            // 
            this.txtCondition.ChangeColorIfNotEmpty = true;
            this.txtCondition.ChangeColorOnEnter = true;
            this.txtCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCondition.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCondition.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCondition.Location = new System.Drawing.Point(3, 19);
            this.txtCondition.Multiline = true;
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Negative = true;
            this.txtCondition.NotEmpty = false;
            this.txtCondition.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCondition.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCondition.SelectOnEnter = true;
            this.txtCondition.Size = new System.Drawing.Size(568, 169);
            this.txtCondition.TabIndex = 2;
            this.txtCondition.TextMode = ClassLibrary.TextModes.Text;
            // 
            // JCommitmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 380);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Name = "JCommitmentsForm";
            this.Text = "تعهدات و شروط قرارداد";
            this.Load += new System.EventHandler(this.JCommitmentsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.TextEdit txtGuarantee;
        private ClassLibrary.TextEdit txtCondition;
    }
}