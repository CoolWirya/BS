namespace RealEstate
{
    partial class GoodwillDates
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateEdit1 = new ClassLibrary.DateEdit(this.components);
            this.dateEdit2 = new ClassLibrary.DateEdit(this.components);
            this.textEdit1 = new ClassLibrary.TextEdit(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 42);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textEdit1);
            this.groupBox1.Controls.Add(this.dateEdit2);
            this.groupBox1.Controls.Add(this.dateEdit1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 107);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "میزان افزایش (درصد)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "تا تاریخ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = " از تاریخ:";
            // 
            // dateEdit1
            // 
            this.dateEdit1.ChangeColorIfNotEmpty = true;
            this.dateEdit1.ChangeColorOnEnter = true;
            this.dateEdit1.Date = new System.DateTime(((long)(0)));
            this.dateEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.dateEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.dateEdit1.Location = new System.Drawing.Point(254, 24);
            this.dateEdit1.Mask = "0000/00/00";
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.NotEmpty = false;
            this.dateEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.dateEdit1.Size = new System.Drawing.Size(100, 23);
            this.dateEdit1.TabIndex = 3;
            // 
            // dateEdit2
            // 
            this.dateEdit2.ChangeColorIfNotEmpty = true;
            this.dateEdit2.ChangeColorOnEnter = true;
            this.dateEdit2.Date = new System.DateTime(((long)(0)));
            this.dateEdit2.InBackColor = System.Drawing.SystemColors.Info;
            this.dateEdit2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.dateEdit2.Location = new System.Drawing.Point(71, 24);
            this.dateEdit2.Mask = "0000/00/00";
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.NotEmpty = false;
            this.dateEdit2.NotEmptyColor = System.Drawing.Color.Red;
            this.dateEdit2.Size = new System.Drawing.Size(100, 23);
            this.dateEdit2.TabIndex = 4;
            // 
            // textEdit1
            // 
            this.textEdit1.ChangeColorIfNotEmpty = false;
            this.textEdit1.ChangeColorOnEnter = true;
            this.textEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.textEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.textEdit1.Location = new System.Drawing.Point(254, 65);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Negative = true;
            this.textEdit1.NotEmpty = false;
            this.textEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.textEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit1.SelectOnEnter = true;
            this.textEdit1.Size = new System.Drawing.Size(44, 23);
            this.textEdit1.TabIndex = 5;
            this.textEdit1.TextMode = ClassLibrary.TextModes.Text;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(337, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // GoodwillDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 166);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "GoodwillDates";
            this.Text = "تاریخ های افزایش اجاره سرقفلی";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit textEdit1;
        private ClassLibrary.DateEdit dateEdit2;
        private ClassLibrary.DateEdit dateEdit1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}