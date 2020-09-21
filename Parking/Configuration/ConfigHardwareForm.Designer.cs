namespace Parking
{
    partial class JConfigHardwareForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.jComboBox1 = new ClassLibrary.JComboBox(this.components);
            this.numEdit1 = new ClassLibrary.NumEdit();
            this.jComboBox2 = new ClassLibrary.JComboBox(this.components);
            this.textEdit1 = new ClassLibrary.TextEdit(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.jComboBox3 = new ClassLibrary.JComboBox(this.components);
            this.jComboBox4 = new ClassLibrary.JComboBox(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbTypeDevice = new ClassLibrary.JComboBox(this.components);
            this.cmbModelDevice = new ClassLibrary.JComboBox(this.components);
            this.cmbCommunicationProtocol = new ClassLibrary.JComboBox(this.components);
            this.txtNoProtocol = new ClassLibrary.NumEdit();
            this.cmbTypeDvr = new ClassLibrary.JComboBox(this.components);
            this.txtAddressSavePic = new ClassLibrary.TextEdit(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbComplex = new ClassLibrary.JComboBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "پروتکل ارتباطی :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "شماره پورت :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "نوع DVR :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "مسیر ذخیره سازی عکس ها :";
            // 
            // jComboBox1
            // 
            this.jComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.jComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.jComboBox1.BaseCode = 0;
            this.jComboBox1.ChangeColorIfNotEmpty = true;
            this.jComboBox1.ChangeColorOnEnter = true;
            this.jComboBox1.FormattingEnabled = true;
            this.jComboBox1.InBackColor = System.Drawing.SystemColors.Info;
            this.jComboBox1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.jComboBox1.Location = new System.Drawing.Point(148, 100);
            this.jComboBox1.Name = "jComboBox1";
            this.jComboBox1.NotEmpty = false;
            this.jComboBox1.NotEmptyColor = System.Drawing.Color.Red;
            this.jComboBox1.SelectOnEnter = true;
            this.jComboBox1.Size = new System.Drawing.Size(164, 21);
            this.jComboBox1.TabIndex = 4;
            // 
            // numEdit1
            // 
            this.numEdit1.ChangeColorIfNotEmpty = false;
            this.numEdit1.ChangeColorOnEnter = true;
            this.numEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.numEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.numEdit1.Location = new System.Drawing.Point(148, 141);
            this.numEdit1.Name = "numEdit1";
            this.numEdit1.Negative = true;
            this.numEdit1.NotEmpty = false;
            this.numEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.numEdit1.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.numEdit1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numEdit1.SelectOnEnter = true;
            this.numEdit1.Size = new System.Drawing.Size(164, 20);
            this.numEdit1.TabIndex = 5;
            this.numEdit1.TextMode = ClassLibrary.TextModes.Text;
            // 
            // jComboBox2
            // 
            this.jComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.jComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.jComboBox2.BaseCode = 0;
            this.jComboBox2.ChangeColorIfNotEmpty = true;
            this.jComboBox2.ChangeColorOnEnter = true;
            this.jComboBox2.FormattingEnabled = true;
            this.jComboBox2.InBackColor = System.Drawing.SystemColors.Info;
            this.jComboBox2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.jComboBox2.Location = new System.Drawing.Point(148, 182);
            this.jComboBox2.Name = "jComboBox2";
            this.jComboBox2.NotEmpty = false;
            this.jComboBox2.NotEmptyColor = System.Drawing.Color.Red;
            this.jComboBox2.SelectOnEnter = true;
            this.jComboBox2.Size = new System.Drawing.Size(164, 21);
            this.jComboBox2.TabIndex = 6;
            // 
            // textEdit1
            // 
            this.textEdit1.ChangeColorIfNotEmpty = false;
            this.textEdit1.ChangeColorOnEnter = true;
            this.textEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.textEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.textEdit1.Location = new System.Drawing.Point(28, 253);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Negative = true;
            this.textEdit1.NotEmpty = false;
            this.textEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.textEdit1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textEdit1.SelectOnEnter = true;
            this.textEdit1.Size = new System.Drawing.Size(284, 20);
            this.textEdit1.TabIndex = 7;
            this.textEdit1.Text = "c:\\";
            this.textEdit1.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "نوع دستگاه:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "مدل :";
            // 
            // jComboBox3
            // 
            this.jComboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.jComboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.jComboBox3.BaseCode = 0;
            this.jComboBox3.ChangeColorIfNotEmpty = true;
            this.jComboBox3.ChangeColorOnEnter = true;
            this.jComboBox3.FormattingEnabled = true;
            this.jComboBox3.InBackColor = System.Drawing.SystemColors.Info;
            this.jComboBox3.InForeColor = System.Drawing.SystemColors.WindowText;
            this.jComboBox3.Location = new System.Drawing.Point(148, 18);
            this.jComboBox3.Name = "jComboBox3";
            this.jComboBox3.NotEmpty = false;
            this.jComboBox3.NotEmptyColor = System.Drawing.Color.Red;
            this.jComboBox3.SelectOnEnter = true;
            this.jComboBox3.Size = new System.Drawing.Size(164, 21);
            this.jComboBox3.TabIndex = 10;
            // 
            // jComboBox4
            // 
            this.jComboBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.jComboBox4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.jComboBox4.BaseCode = 0;
            this.jComboBox4.ChangeColorIfNotEmpty = true;
            this.jComboBox4.ChangeColorOnEnter = true;
            this.jComboBox4.FormattingEnabled = true;
            this.jComboBox4.InBackColor = System.Drawing.SystemColors.Info;
            this.jComboBox4.InForeColor = System.Drawing.SystemColors.WindowText;
            this.jComboBox4.Location = new System.Drawing.Point(148, 59);
            this.jComboBox4.Name = "jComboBox4";
            this.jComboBox4.NotEmpty = false;
            this.jComboBox4.NotEmptyColor = System.Drawing.Color.Red;
            this.jComboBox4.SelectOnEnter = true;
            this.jComboBox4.Size = new System.Drawing.Size(164, 21);
            this.jComboBox4.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 37);
            this.button1.TabIndex = 12;
            this.button1.Text = "ذخیره";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "نوع دستگاه :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "مدل :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "پروتکل ارتباطی :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "شماره پورت :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 242);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 16);
            this.label11.TabIndex = 4;
            this.label11.Text = "نوع DVR :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 286);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(156, 16);
            this.label12.TabIndex = 5;
            this.label12.Text = "مسیر ذخیره سازی عکس :";
            // 
            // cmbTypeDevice
            // 
            this.cmbTypeDevice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTypeDevice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTypeDevice.BaseCode = 0;
            this.cmbTypeDevice.ChangeColorIfNotEmpty = true;
            this.cmbTypeDevice.ChangeColorOnEnter = true;
            this.cmbTypeDevice.FormattingEnabled = true;
            this.cmbTypeDevice.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbTypeDevice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTypeDevice.Location = new System.Drawing.Point(141, 63);
            this.cmbTypeDevice.Name = "cmbTypeDevice";
            this.cmbTypeDevice.NotEmpty = false;
            this.cmbTypeDevice.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbTypeDevice.SelectOnEnter = true;
            this.cmbTypeDevice.Size = new System.Drawing.Size(172, 24);
            this.cmbTypeDevice.TabIndex = 1;
            // 
            // cmbModelDevice
            // 
            this.cmbModelDevice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbModelDevice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbModelDevice.BaseCode = 0;
            this.cmbModelDevice.ChangeColorIfNotEmpty = true;
            this.cmbModelDevice.ChangeColorOnEnter = true;
            this.cmbModelDevice.FormattingEnabled = true;
            this.cmbModelDevice.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbModelDevice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbModelDevice.Location = new System.Drawing.Point(141, 107);
            this.cmbModelDevice.Name = "cmbModelDevice";
            this.cmbModelDevice.NotEmpty = false;
            this.cmbModelDevice.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbModelDevice.SelectOnEnter = true;
            this.cmbModelDevice.Size = new System.Drawing.Size(172, 24);
            this.cmbModelDevice.TabIndex = 2;
            // 
            // cmbCommunicationProtocol
            // 
            this.cmbCommunicationProtocol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCommunicationProtocol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCommunicationProtocol.BaseCode = 0;
            this.cmbCommunicationProtocol.ChangeColorIfNotEmpty = true;
            this.cmbCommunicationProtocol.ChangeColorOnEnter = true;
            this.cmbCommunicationProtocol.FormattingEnabled = true;
            this.cmbCommunicationProtocol.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCommunicationProtocol.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCommunicationProtocol.Location = new System.Drawing.Point(141, 151);
            this.cmbCommunicationProtocol.Name = "cmbCommunicationProtocol";
            this.cmbCommunicationProtocol.NotEmpty = false;
            this.cmbCommunicationProtocol.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCommunicationProtocol.SelectOnEnter = true;
            this.cmbCommunicationProtocol.Size = new System.Drawing.Size(172, 24);
            this.cmbCommunicationProtocol.TabIndex = 3;
            // 
            // txtNoProtocol
            // 
            this.txtNoProtocol.ChangeColorIfNotEmpty = false;
            this.txtNoProtocol.ChangeColorOnEnter = true;
            this.txtNoProtocol.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNoProtocol.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNoProtocol.Location = new System.Drawing.Point(141, 195);
            this.txtNoProtocol.Name = "txtNoProtocol";
            this.txtNoProtocol.Negative = true;
            this.txtNoProtocol.NotEmpty = false;
            this.txtNoProtocol.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNoProtocol.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtNoProtocol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNoProtocol.SelectOnEnter = true;
            this.txtNoProtocol.Size = new System.Drawing.Size(172, 23);
            this.txtNoProtocol.TabIndex = 4;
            this.txtNoProtocol.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbTypeDvr
            // 
            this.cmbTypeDvr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTypeDvr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTypeDvr.BaseCode = 0;
            this.cmbTypeDvr.ChangeColorIfNotEmpty = true;
            this.cmbTypeDvr.ChangeColorOnEnter = true;
            this.cmbTypeDvr.FormattingEnabled = true;
            this.cmbTypeDvr.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbTypeDvr.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTypeDvr.Location = new System.Drawing.Point(141, 239);
            this.cmbTypeDvr.Name = "cmbTypeDvr";
            this.cmbTypeDvr.NotEmpty = false;
            this.cmbTypeDvr.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbTypeDvr.SelectOnEnter = true;
            this.cmbTypeDvr.Size = new System.Drawing.Size(172, 24);
            this.cmbTypeDvr.TabIndex = 5;
            // 
            // txtAddressSavePic
            // 
            this.txtAddressSavePic.ChangeColorIfNotEmpty = false;
            this.txtAddressSavePic.ChangeColorOnEnter = true;
            this.txtAddressSavePic.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAddressSavePic.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAddressSavePic.Location = new System.Drawing.Point(27, 324);
            this.txtAddressSavePic.Name = "txtAddressSavePic";
            this.txtAddressSavePic.Negative = true;
            this.txtAddressSavePic.NotEmpty = false;
            this.txtAddressSavePic.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAddressSavePic.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAddressSavePic.SelectOnEnter = true;
            this.txtAddressSavePic.Size = new System.Drawing.Size(286, 23);
            this.txtAddressSavePic.TabIndex = 6;
            this.txtAddressSavePic.Text = "c:\\";
            this.txtAddressSavePic.TextMode = ClassLibrary.TextModes.Text;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(27, 373);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 31);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "ذخیره";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbComplex
            // 
            this.cmbComplex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbComplex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbComplex.BaseCode = 0;
            this.cmbComplex.ChangeColorIfNotEmpty = true;
            this.cmbComplex.ChangeColorOnEnter = true;
            this.cmbComplex.FormattingEnabled = true;
            this.cmbComplex.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbComplex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbComplex.Location = new System.Drawing.Point(141, 21);
            this.cmbComplex.Name = "cmbComplex";
            this.cmbComplex.NotEmpty = false;
            this.cmbComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbComplex.SelectOnEnter = true;
            this.cmbComplex.Size = new System.Drawing.Size(172, 24);
            this.cmbComplex.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 16);
            this.label13.TabIndex = 13;
            this.label13.Text = "مجتمع / بازار :";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(227, 373);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 31);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 373);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 31);
            this.button2.TabIndex = 16;
            this.button2.Text = "تنظیم گیت";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // JConfigHardwareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(349, 424);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cmbComplex);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtAddressSavePic);
            this.Controls.Add(this.cmbTypeDvr);
            this.Controls.Add(this.txtNoProtocol);
            this.Controls.Add(this.cmbCommunicationProtocol);
            this.Controls.Add(this.cmbModelDevice);
            this.Controls.Add(this.cmbTypeDevice);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Name = "JConfigHardwareForm";
            this.Text = "تنظیمات سخت افزار";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.JComboBox jComboBox1;
        private ClassLibrary.NumEdit numEdit1;
        private ClassLibrary.JComboBox jComboBox2;
        private ClassLibrary.TextEdit textEdit1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.JComboBox jComboBox3;
        private ClassLibrary.JComboBox jComboBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private ClassLibrary.JComboBox cmbTypeDevice;
        private ClassLibrary.JComboBox cmbModelDevice;
        private ClassLibrary.JComboBox cmbCommunicationProtocol;
        private ClassLibrary.NumEdit txtNoProtocol;
        private ClassLibrary.JComboBox cmbTypeDvr;
        private ClassLibrary.TextEdit txtAddressSavePic;
        private System.Windows.Forms.Button btnAdd;
        private ClassLibrary.JComboBox cmbComplex;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button button2;
    }
}