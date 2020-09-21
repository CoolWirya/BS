namespace Estates
{
    partial class JUsageGroundForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JUsageGroundForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.txtName = new ClassLibrary.TextEdit(this.components);
            this.txtDensity = new ClassLibrary.TextEdit(this.components);
            this.numPercent = new ClassLibrary.TextEdit(this.components);
            this.txtComment = new ClassLibrary.TextEdit(this.components);
            this.txtParking = new ClassLibrary.TextEdit(this.components);
            this.txtAccess = new ClassLibrary.TextEdit(this.components);
            this.labCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "aktion.png");
            this.imageList.Images.SetKeyName(1, "alert.png");
            this.imageList.Images.SetKeyName(2, "All software is current.png");
            this.imageList.Images.SetKeyName(3, "amor.png");
            this.imageList.Images.SetKeyName(4, "antivirus.png");
            this.imageList.Images.SetKeyName(5, "applixware.png");
            this.imageList.Images.SetKeyName(6, "ark.png");
            this.imageList.Images.SetKeyName(7, "arts.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "کد کاربری:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "عنوان کاربری:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "سطح اشغال:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "درصد";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "تراکم به درصد:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "پارکینگ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(222, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "دسترسی: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "توضیحات:";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(15, 317);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 6;
            this.Save.Text = "ذخیره";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(353, 317);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 7;
            this.Close.Text = "خروج";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // txtName
            // 
            this.txtName.ChangeColorIfNotEmpty = true;
            this.txtName.ChangeColorOnEnter = true;
            this.txtName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(105, 42);
            this.txtName.Name = "txtName";
            this.txtName.Negative = true;
            this.txtName.NotEmpty = true;
            this.txtName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectOnEnter = true;
            this.txtName.Size = new System.Drawing.Size(323, 23);
            this.txtName.TabIndex = 0;
            this.txtName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtDensity
            // 
            this.txtDensity.ChangeColorIfNotEmpty = true;
            this.txtDensity.ChangeColorOnEnter = true;
            this.txtDensity.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDensity.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDensity.Location = new System.Drawing.Point(105, 100);
            this.txtDensity.Name = "txtDensity";
            this.txtDensity.Negative = true;
            this.txtDensity.NotEmpty = false;
            this.txtDensity.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDensity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDensity.SelectOnEnter = true;
            this.txtDensity.Size = new System.Drawing.Size(100, 23);
            this.txtDensity.TabIndex = 2;
            this.txtDensity.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // numPercent
            // 
            this.numPercent.ChangeColorIfNotEmpty = true;
            this.numPercent.ChangeColorOnEnter = true;
            this.numPercent.InBackColor = System.Drawing.SystemColors.Info;
            this.numPercent.InForeColor = System.Drawing.SystemColors.WindowText;
            this.numPercent.Location = new System.Drawing.Point(105, 134);
            this.numPercent.Name = "numPercent";
            this.numPercent.Negative = true;
            this.numPercent.NotEmpty = false;
            this.numPercent.NotEmptyColor = System.Drawing.Color.Red;
            this.numPercent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numPercent.SelectOnEnter = true;
            this.numPercent.Size = new System.Drawing.Size(100, 23);
            this.numPercent.TabIndex = 4;
            this.numPercent.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtComment
            // 
            this.txtComment.ChangeColorIfNotEmpty = true;
            this.txtComment.ChangeColorOnEnter = true;
            this.txtComment.InBackColor = System.Drawing.SystemColors.Info;
            this.txtComment.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtComment.Location = new System.Drawing.Point(15, 192);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Negative = true;
            this.txtComment.NotEmpty = false;
            this.txtComment.NotEmptyColor = System.Drawing.Color.Red;
            this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtComment.SelectOnEnter = true;
            this.txtComment.Size = new System.Drawing.Size(413, 119);
            this.txtComment.TabIndex = 5;
            this.txtComment.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtParking
            // 
            this.txtParking.ChangeColorIfNotEmpty = true;
            this.txtParking.ChangeColorOnEnter = true;
            this.txtParking.InBackColor = System.Drawing.SystemColors.Info;
            this.txtParking.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtParking.Location = new System.Drawing.Point(105, 71);
            this.txtParking.Name = "txtParking";
            this.txtParking.Negative = true;
            this.txtParking.NotEmpty = false;
            this.txtParking.NotEmptyColor = System.Drawing.Color.Red;
            this.txtParking.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtParking.SelectOnEnter = true;
            this.txtParking.Size = new System.Drawing.Size(323, 23);
            this.txtParking.TabIndex = 1;
            this.txtParking.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtAccess
            // 
            this.txtAccess.ChangeColorIfNotEmpty = true;
            this.txtAccess.ChangeColorOnEnter = true;
            this.txtAccess.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAccess.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAccess.Location = new System.Drawing.Point(288, 103);
            this.txtAccess.Name = "txtAccess";
            this.txtAccess.Negative = true;
            this.txtAccess.NotEmpty = false;
            this.txtAccess.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAccess.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAccess.SelectOnEnter = true;
            this.txtAccess.Size = new System.Drawing.Size(140, 23);
            this.txtAccess.TabIndex = 3;
            this.txtAccess.TextMode = ClassLibrary.TextModes.Text;
            // 
            // labCode
            // 
            this.labCode.AutoSize = true;
            this.labCode.Location = new System.Drawing.Point(154, 15);
            this.labCode.Name = "labCode";
            this.labCode.Size = new System.Drawing.Size(0, 16);
            this.labCode.TabIndex = 28;
            // 
            // JUsageGroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 352);
            this.Controls.Add(this.labCode);
            this.Controls.Add(this.txtAccess);
            this.Controls.Add(this.txtParking);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.numPercent);
            this.Controls.Add(this.txtDensity);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JUsageGroundForm";
            this.Text = "کاربری (زمین)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Close;
        private ClassLibrary.TextEdit txtName;
        private ClassLibrary.TextEdit txtDensity;
        private ClassLibrary.TextEdit numPercent;
        private ClassLibrary.TextEdit txtComment;
        private ClassLibrary.TextEdit txtParking;
        private ClassLibrary.TextEdit txtAccess;
        private System.Windows.Forms.Label labCode;
    }
}