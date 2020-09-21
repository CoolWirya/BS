namespace Parking
{
    partial class DefShift
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbMarketDefShift = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.txtName = new ClassLibrary.TextEdit(this.components);
            this.txthourin = new ClassLibrary.TextEdit(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.TxtMinin = new ClassLibrary.TextEdit(this.components);
            this.TxtHourOut = new ClassLibrary.TextEdit(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.TxtMinout = new ClassLibrary.TextEdit(this.components);
            this.chkClose = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ساعت شروع :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "ساعت پايان :";
            // 
            // CmbMarketDefShift
            // 
            this.CmbMarketDefShift.FormattingEnabled = true;
            this.CmbMarketDefShift.Location = new System.Drawing.Point(66, 125);
            this.CmbMarketDefShift.Name = "CmbMarketDefShift";
            this.CmbMarketDefShift.Size = new System.Drawing.Size(212, 24);
            this.CmbMarketDefShift.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "مجتمع :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "عنوان :";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(12, 208);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(116, 38);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "ثبت";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtName
            // 
            this.txtName.ChangeColorIfNotEmpty = false;
            this.txtName.ChangeColorOnEnter = true;
            this.txtName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(66, 9);
            this.txtName.Name = "txtName";
            this.txtName.Negative = true;
            this.txtName.NotEmpty = false;
            this.txtName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectOnEnter = true;
            this.txtName.Size = new System.Drawing.Size(212, 23);
            this.txtName.TabIndex = 7;
            this.txtName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txthourin
            // 
            this.txthourin.ChangeColorIfNotEmpty = false;
            this.txthourin.ChangeColorOnEnter = true;
            this.txthourin.InBackColor = System.Drawing.SystemColors.Info;
            this.txthourin.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txthourin.Location = new System.Drawing.Point(168, 47);
            this.txthourin.MaxLength = 2;
            this.txthourin.Name = "txthourin";
            this.txthourin.Negative = true;
            this.txthourin.NotEmpty = false;
            this.txthourin.NotEmptyColor = System.Drawing.Color.Red;
            this.txthourin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txthourin.SelectOnEnter = true;
            this.txthourin.Size = new System.Drawing.Size(44, 23);
            this.txthourin.TabIndex = 15;
            this.txthourin.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(149, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = ":";
            // 
            // TxtMinin
            // 
            this.TxtMinin.ChangeColorIfNotEmpty = false;
            this.TxtMinin.ChangeColorOnEnter = true;
            this.TxtMinin.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtMinin.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtMinin.Location = new System.Drawing.Point(102, 47);
            this.TxtMinin.MaxLength = 2;
            this.TxtMinin.Name = "TxtMinin";
            this.TxtMinin.Negative = true;
            this.TxtMinin.NotEmpty = false;
            this.TxtMinin.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtMinin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtMinin.SelectOnEnter = true;
            this.TxtMinin.Size = new System.Drawing.Size(44, 23);
            this.TxtMinin.TabIndex = 17;
            this.TxtMinin.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // TxtHourOut
            // 
            this.TxtHourOut.ChangeColorIfNotEmpty = false;
            this.TxtHourOut.ChangeColorOnEnter = true;
            this.TxtHourOut.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtHourOut.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtHourOut.Location = new System.Drawing.Point(168, 87);
            this.TxtHourOut.MaxLength = 2;
            this.TxtHourOut.Name = "TxtHourOut";
            this.TxtHourOut.Negative = true;
            this.TxtHourOut.NotEmpty = false;
            this.TxtHourOut.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtHourOut.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtHourOut.SelectOnEnter = true;
            this.TxtHourOut.Size = new System.Drawing.Size(44, 23);
            this.TxtHourOut.TabIndex = 18;
            this.TxtHourOut.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = ":";
            // 
            // TxtMinout
            // 
            this.TxtMinout.ChangeColorIfNotEmpty = false;
            this.TxtMinout.ChangeColorOnEnter = true;
            this.TxtMinout.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtMinout.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtMinout.Location = new System.Drawing.Point(102, 87);
            this.TxtMinout.MaxLength = 2;
            this.TxtMinout.Name = "TxtMinout";
            this.TxtMinout.Negative = true;
            this.TxtMinout.NotEmpty = false;
            this.TxtMinout.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtMinout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtMinout.SelectOnEnter = true;
            this.TxtMinout.Size = new System.Drawing.Size(44, 23);
            this.TxtMinout.TabIndex = 20;
            this.TxtMinout.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // chkClose
            // 
            this.chkClose.AutoSize = true;
            this.chkClose.Location = new System.Drawing.Point(13, 170);
            this.chkClose.Name = "chkClose";
            this.chkClose.Size = new System.Drawing.Size(222, 20);
            this.chkClose.TabIndex = 21;
            this.chkClose.Text = "اين شيفت مي تواند حساب را ببندد";
            this.chkClose.UseVisualStyleBackColor = true;
            // 
            // DefShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 256);
            this.Controls.Add(this.chkClose);
            this.Controls.Add(this.TxtMinout);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtHourOut);
            this.Controls.Add(this.TxtMinin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txthourin);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbMarketDefShift);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DefShift";
            this.Text = "DefShift";
            this.Load += new System.EventHandler(this.DefShift_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbMarketDefShift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.TextEdit txtName;
        private System.Windows.Forms.Button BtnSave;
        private ClassLibrary.TextEdit txthourin;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.TextEdit TxtMinin;
        private ClassLibrary.TextEdit TxtHourOut;
        private System.Windows.Forms.Label label7;
        private ClassLibrary.TextEdit TxtMinout;
        private System.Windows.Forms.CheckBox chkClose;
    }
}