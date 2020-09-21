namespace Parking
{
    partial class JCreateParkingCardForm
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
            this.numEdit1 = new ClassLibrary.NumEdit();
            this.numEdit2 = new ClassLibrary.NumEdit();
            this.jComboBox1 = new ClassLibrary.JComboBox(this.components);
            this.jComboBox2 = new ClassLibrary.JComboBox(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "از شماره :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "تا شماره :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "عضو گروه :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "وضعیت کارت:";
            // 
            // numEdit1
            // 
            this.numEdit1.ChangeColorIfNotEmpty = false;
            this.numEdit1.ChangeColorOnEnter = true;
            this.numEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.numEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.numEdit1.Location = new System.Drawing.Point(79, 19);
            this.numEdit1.Name = "numEdit1";
            this.numEdit1.Negative = true;
            this.numEdit1.NotEmpty = false;
            this.numEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.numEdit1.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.numEdit1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numEdit1.SelectOnEnter = true;
            this.numEdit1.Size = new System.Drawing.Size(189, 23);
            this.numEdit1.TabIndex = 4;
            this.numEdit1.TextMode = ClassLibrary.TextModes.Text;
            // 
            // numEdit2
            // 
            this.numEdit2.ChangeColorIfNotEmpty = false;
            this.numEdit2.ChangeColorOnEnter = true;
            this.numEdit2.InBackColor = System.Drawing.SystemColors.Info;
            this.numEdit2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.numEdit2.Location = new System.Drawing.Point(352, 19);
            this.numEdit2.Name = "numEdit2";
            this.numEdit2.Negative = true;
            this.numEdit2.NotEmpty = false;
            this.numEdit2.NotEmptyColor = System.Drawing.Color.Red;
            this.numEdit2.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.numEdit2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numEdit2.SelectOnEnter = true;
            this.numEdit2.Size = new System.Drawing.Size(189, 23);
            this.numEdit2.TabIndex = 5;
            this.numEdit2.TextMode = ClassLibrary.TextModes.Text;
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
            this.jComboBox1.Location = new System.Drawing.Point(79, 75);
            this.jComboBox1.Name = "jComboBox1";
            this.jComboBox1.NotEmpty = false;
            this.jComboBox1.NotEmptyColor = System.Drawing.Color.Red;
            this.jComboBox1.SelectOnEnter = true;
            this.jComboBox1.Size = new System.Drawing.Size(189, 24);
            this.jComboBox1.TabIndex = 6;
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
            this.jComboBox2.Location = new System.Drawing.Point(352, 75);
            this.jComboBox2.Name = "jComboBox2";
            this.jComboBox2.NotEmpty = false;
            this.jComboBox2.NotEmptyColor = System.Drawing.Color.Red;
            this.jComboBox2.SelectOnEnter = true;
            this.jComboBox2.Size = new System.Drawing.Size(189, 24);
            this.jComboBox2.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(452, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "ذخیره";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // JCreateParkingCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 172);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.jComboBox2);
            this.Controls.Add(this.jComboBox1);
            this.Controls.Add(this.numEdit2);
            this.Controls.Add(this.numEdit1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JCreateParkingCardForm";
            this.Text = "ایجاد کارت پارکینگ به صورت گروهی ";
            this.Load += new System.EventHandler(this.JCreateParkingCardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.NumEdit numEdit1;
        private ClassLibrary.NumEdit numEdit2;
        private ClassLibrary.JComboBox jComboBox1;
        private ClassLibrary.JComboBox jComboBox2;
        private System.Windows.Forms.Button button1;
    }
}