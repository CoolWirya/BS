namespace RealEstate
{
    partial class PrintedGhabzForm
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
            this.txtCodeghabz = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuild = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmohlat = new ClassLibrary.DateEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Btnsave = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnApplay = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtdebt = new ClassLibrary.TextEdit(this.components);
            this.txtpriviuosdebt = new ClassLibrary.TextEdit(this.components);
            this.txtyaraneh = new ClassLibrary.TextEdit(this.components);
            this.txtmonth = new ClassLibrary.TextEdit(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.CmbComplex = new ClassLibrary.JComboBox(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "كد قبض :";
            // 
            // txtCodeghabz
            // 
            this.txtCodeghabz.Location = new System.Drawing.Point(78, 32);
            this.txtCodeghabz.Name = "txtCodeghabz";
            this.txtCodeghabz.Size = new System.Drawing.Size(82, 23);
            this.txtCodeghabz.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "شماره واحد :";
            // 
            // txtBuild
            // 
            this.txtBuild.Location = new System.Drawing.Point(330, 85);
            this.txtBuild.Name = "txtBuild";
            this.txtBuild.Size = new System.Drawing.Size(138, 23);
            this.txtBuild.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "مهلت پرداخت :";
            // 
            // txtmohlat
            // 
            this.txtmohlat.ChangeColorIfNotEmpty = true;
            this.txtmohlat.ChangeColorOnEnter = true;
            this.txtmohlat.Date = new System.DateTime(((long)(0)));
            this.txtmohlat.InBackColor = System.Drawing.SystemColors.Info;
            this.txtmohlat.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtmohlat.InsertInDatesTable = true;
            this.txtmohlat.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtmohlat.Location = new System.Drawing.Point(106, 138);
            this.txtmohlat.Mask = "0000/00/00";
            this.txtmohlat.Name = "txtmohlat";
            this.txtmohlat.NotEmpty = false;
            this.txtmohlat.NotEmptyColor = System.Drawing.Color.Red;
            this.txtmohlat.Size = new System.Drawing.Size(84, 23);
            this.txtmohlat.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "ماه :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "مبلغ قابل پرداخت:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "يارانه :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(243, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "بدهي قبلي :";
            // 
            // Btnsave
            // 
            this.Btnsave.Location = new System.Drawing.Point(12, 236);
            this.Btnsave.Name = "Btnsave";
            this.Btnsave.Size = new System.Drawing.Size(91, 38);
            this.Btnsave.TabIndex = 15;
            this.Btnsave.Text = "ثبت";
            this.Btnsave.UseVisualStyleBackColor = true;
            this.Btnsave.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(464, 61);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(22, 23);
            this.txtCode.TabIndex = 17;
            this.txtCode.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(432, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "كد:";
            this.label8.Visible = false;
            // 
            // btnApplay
            // 
            this.btnApplay.Location = new System.Drawing.Point(111, 236);
            this.btnApplay.Name = "btnApplay";
            this.btnApplay.Size = new System.Drawing.Size(91, 38);
            this.btnApplay.TabIndex = 18;
            this.btnApplay.Text = "اعمال";
            this.btnApplay.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(419, 236);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 38);
            this.button3.TabIndex = 19;
            this.button3.Text = "خروج";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtdebt
            // 
            this.txtdebt.ChangeColorIfNotEmpty = false;
            this.txtdebt.ChangeColorOnEnter = true;
            this.txtdebt.InBackColor = System.Drawing.SystemColors.Info;
            this.txtdebt.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtdebt.Location = new System.Drawing.Point(124, 190);
            this.txtdebt.Name = "txtdebt";
            this.txtdebt.Negative = true;
            this.txtdebt.NotEmpty = false;
            this.txtdebt.NotEmptyColor = System.Drawing.Color.Red;
            this.txtdebt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdebt.SelectOnEnter = true;
            this.txtdebt.Size = new System.Drawing.Size(66, 23);
            this.txtdebt.TabIndex = 22;
            this.txtdebt.TextMode = ClassLibrary.TextModes.Money;
            // 
            // txtpriviuosdebt
            // 
            this.txtpriviuosdebt.ChangeColorIfNotEmpty = false;
            this.txtpriviuosdebt.ChangeColorOnEnter = true;
            this.txtpriviuosdebt.InBackColor = System.Drawing.SystemColors.Info;
            this.txtpriviuosdebt.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtpriviuosdebt.Location = new System.Drawing.Point(330, 190);
            this.txtpriviuosdebt.Name = "txtpriviuosdebt";
            this.txtpriviuosdebt.Negative = true;
            this.txtpriviuosdebt.NotEmpty = false;
            this.txtpriviuosdebt.NotEmptyColor = System.Drawing.Color.Red;
            this.txtpriviuosdebt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtpriviuosdebt.SelectOnEnter = true;
            this.txtpriviuosdebt.Size = new System.Drawing.Size(138, 23);
            this.txtpriviuosdebt.TabIndex = 23;
            this.txtpriviuosdebt.TextMode = ClassLibrary.TextModes.Money;
            // 
            // txtyaraneh
            // 
            this.txtyaraneh.ChangeColorIfNotEmpty = false;
            this.txtyaraneh.ChangeColorOnEnter = true;
            this.txtyaraneh.InBackColor = System.Drawing.SystemColors.Info;
            this.txtyaraneh.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtyaraneh.Location = new System.Drawing.Point(330, 138);
            this.txtyaraneh.Name = "txtyaraneh";
            this.txtyaraneh.Negative = true;
            this.txtyaraneh.NotEmpty = false;
            this.txtyaraneh.NotEmptyColor = System.Drawing.Color.Red;
            this.txtyaraneh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtyaraneh.SelectOnEnter = true;
            this.txtyaraneh.Size = new System.Drawing.Size(138, 23);
            this.txtyaraneh.TabIndex = 24;
            this.txtyaraneh.TextMode = ClassLibrary.TextModes.Money;
            // 
            // txtmonth
            // 
            this.txtmonth.ChangeColorIfNotEmpty = false;
            this.txtmonth.ChangeColorOnEnter = true;
            this.txtmonth.InBackColor = System.Drawing.SystemColors.Info;
            this.txtmonth.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtmonth.Location = new System.Drawing.Point(78, 81);
            this.txtmonth.MaxLength = 2;
            this.txtmonth.Name = "txtmonth";
            this.txtmonth.Negative = true;
            this.txtmonth.NotEmpty = false;
            this.txtmonth.NotEmptyColor = System.Drawing.Color.Red;
            this.txtmonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtmonth.SelectOnEnter = true;
            this.txtmonth.Size = new System.Drawing.Size(40, 23);
            this.txtmonth.TabIndex = 25;
            this.txtmonth.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(243, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "مجتمع :";
            // 
            // CmbComplex
            // 
            this.CmbComplex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.CmbComplex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbComplex.BaseCode = 0;
            this.CmbComplex.ChangeColorIfNotEmpty = true;
            this.CmbComplex.ChangeColorOnEnter = true;
            this.CmbComplex.FormattingEnabled = true;
            this.CmbComplex.InBackColor = System.Drawing.SystemColors.Info;
            this.CmbComplex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbComplex.Location = new System.Drawing.Point(330, 31);
            this.CmbComplex.Name = "CmbComplex";
            this.CmbComplex.NotEmpty = false;
            this.CmbComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.CmbComplex.SelectOnEnter = true;
            this.CmbComplex.Size = new System.Drawing.Size(138, 24);
            this.CmbComplex.TabIndex = 21;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(471, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(39, 23);
            this.button4.TabIndex = 26;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // PrintedGhabzForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 276);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtmonth);
            this.Controls.Add(this.txtyaraneh);
            this.Controls.Add(this.txtpriviuosdebt);
            this.Controls.Add(this.txtdebt);
            this.Controls.Add(this.CmbComplex);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnApplay);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Btnsave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtmohlat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBuild);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodeghabz);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PrintedGhabzForm";
            this.Text = "PrintedGhabzForm";
            this.Load += new System.EventHandler(this.PrintedGhabzForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodeghabz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuild;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.DateEdit txtmohlat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Btnsave;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnApplay;
        private System.Windows.Forms.Button button3;
        private ClassLibrary.TextEdit txtdebt;
        private ClassLibrary.TextEdit txtpriviuosdebt;
        private ClassLibrary.TextEdit txtyaraneh;
        private ClassLibrary.TextEdit txtmonth;
        private System.Windows.Forms.Label label9;
        private ClassLibrary.JComboBox CmbComplex;
        private System.Windows.Forms.Button button4;


    }
}