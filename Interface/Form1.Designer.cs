namespace ERP
{
    partial class Form1
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.txtCourseCode = new ClassLibrary.NumEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.RBMelliCode = new System.Windows.Forms.RadioButton();
			this.RBShSh = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(143, 38);
			this.button1.TabIndex = 0;
			this.button1.Text = "ایجاد از و الی سهام";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(12, 56);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(143, 38);
			this.button2.TabIndex = 1;
			this.button2.Text = "ایجاد از و الی سود سهام";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.Location = new System.Drawing.Point(12, 100);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(143, 47);
			this.button3.TabIndex = 2;
			this.button3.Text = "تعریف نام کاربری و کلمه عبور سهام داران";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// txtCourseCode
			// 
			this.txtCourseCode.ChangeColorIfNotEmpty = false;
			this.txtCourseCode.ChangeColorOnEnter = true;
			this.txtCourseCode.InBackColor = System.Drawing.SystemColors.Info;
			this.txtCourseCode.InForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCourseCode.Location = new System.Drawing.Point(251, 22);
			this.txtCourseCode.Name = "txtCourseCode";
			this.txtCourseCode.Negative = true;
			this.txtCourseCode.NotEmpty = false;
			this.txtCourseCode.NotEmptyColor = System.Drawing.Color.Red;
			this.txtCourseCode.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
			this.txtCourseCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtCourseCode.SelectOnEnter = true;
			this.txtCourseCode.Size = new System.Drawing.Size(100, 20);
			this.txtCourseCode.TabIndex = 3;
			this.txtCourseCode.TextMode = ClassLibrary.TextModes.Text;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(174, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "CourseCode :";
			// 
			// RBMelliCode
			// 
			this.RBMelliCode.AutoSize = true;
			this.RBMelliCode.Checked = true;
			this.RBMelliCode.Location = new System.Drawing.Point(161, 100);
			this.RBMelliCode.Name = "RBMelliCode";
			this.RBMelliCode.Size = new System.Drawing.Size(98, 17);
			this.RBMelliCode.TabIndex = 5;
			this.RBMelliCode.TabStop = true;
			this.RBMelliCode.Text = "بر اساس کد ملی";
			this.RBMelliCode.UseVisualStyleBackColor = true;
			// 
			// RBShSh
			// 
			this.RBShSh.AutoSize = true;
			this.RBShSh.Location = new System.Drawing.Point(160, 130);
			this.RBShSh.Name = "RBShSh";
			this.RBShSh.Size = new System.Drawing.Size(141, 17);
			this.RBShSh.TabIndex = 6;
			this.RBShSh.Text = "بر اساس شماره شناسنامه";
			this.RBShSh.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(453, 501);
			this.Controls.Add(this.RBShSh);
			this.Controls.Add(this.RBMelliCode);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtCourseCode);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
		private ClassLibrary.NumEdit txtCourseCode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton RBMelliCode;
		private System.Windows.Forms.RadioButton RBShSh;
    }
}

