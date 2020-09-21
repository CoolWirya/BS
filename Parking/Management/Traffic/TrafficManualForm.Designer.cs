namespace Parking
{
    partial class JTrafficManualForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTimeIn = new System.Windows.Forms.MaskedTextBox();
            this.txtDateIn = new ClassLibrary.DateEdit(this.components);
            this.cmbGroupCard = new ClassLibrary.JComboBox(this.components);
            this.cmbComplex = new ClassLibrary.JComboBox(this.components);
            this.txtCard = new ClassLibrary.NumEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTimeIn);
            this.groupBox1.Controls.Add(this.txtDateIn);
            this.groupBox1.Controls.Add(this.cmbGroupCard);
            this.groupBox1.Controls.Add(this.cmbComplex);
            this.groupBox1.Controls.Add(this.txtCard);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ورودی";
            // 
            // txtTimeIn
            // 
            this.txtTimeIn.Location = new System.Drawing.Point(36, 63);
            this.txtTimeIn.Mask = "00:00";
            this.txtTimeIn.Name = "txtTimeIn";
            this.txtTimeIn.Size = new System.Drawing.Size(123, 23);
            this.txtTimeIn.TabIndex = 0;
            this.txtTimeIn.ValidatingType = typeof(System.DateTime);
            // 
            // txtDateIn
            // 
            this.txtDateIn.ChangeColorIfNotEmpty = true;
            this.txtDateIn.ChangeColorOnEnter = true;
            this.txtDateIn.Date = new System.DateTime(((long)(0)));
            this.txtDateIn.Enabled = false;
            this.txtDateIn.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateIn.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateIn.InsertInDatesTable = true;
            this.txtDateIn.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateIn.Location = new System.Drawing.Point(36, 29);
            this.txtDateIn.Mask = "0000/00/00";
            this.txtDateIn.Name = "txtDateIn";
            this.txtDateIn.NotEmpty = false;
            this.txtDateIn.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateIn.Size = new System.Drawing.Size(123, 23);
            this.txtDateIn.TabIndex = 9;
            // 
            // cmbGroupCard
            // 
            this.cmbGroupCard.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGroupCard.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroupCard.BaseCode = 0;
            this.cmbGroupCard.ChangeColorIfNotEmpty = true;
            this.cmbGroupCard.ChangeColorOnEnter = true;
            this.cmbGroupCard.Enabled = false;
            this.cmbGroupCard.FormattingEnabled = true;
            this.cmbGroupCard.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGroupCard.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGroupCard.Location = new System.Drawing.Point(275, 60);
            this.cmbGroupCard.Name = "cmbGroupCard";
            this.cmbGroupCard.NotEmpty = false;
            this.cmbGroupCard.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGroupCard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbGroupCard.SelectOnEnter = true;
            this.cmbGroupCard.Size = new System.Drawing.Size(173, 24);
            this.cmbGroupCard.TabIndex = 8;
            // 
            // cmbComplex
            // 
            this.cmbComplex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbComplex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbComplex.BaseCode = 0;
            this.cmbComplex.ChangeColorIfNotEmpty = true;
            this.cmbComplex.ChangeColorOnEnter = true;
            this.cmbComplex.Enabled = false;
            this.cmbComplex.FormattingEnabled = true;
            this.cmbComplex.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbComplex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbComplex.Location = new System.Drawing.Point(275, 91);
            this.cmbComplex.Name = "cmbComplex";
            this.cmbComplex.NotEmpty = false;
            this.cmbComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbComplex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbComplex.SelectOnEnter = true;
            this.cmbComplex.Size = new System.Drawing.Size(173, 24);
            this.cmbComplex.TabIndex = 7;
            // 
            // txtCard
            // 
            this.txtCard.ChangeColorIfNotEmpty = false;
            this.txtCard.ChangeColorOnEnter = true;
            this.txtCard.Enabled = false;
            this.txtCard.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCard.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCard.Location = new System.Drawing.Point(275, 29);
            this.txtCard.Name = "txtCard";
            this.txtCard.Negative = true;
            this.txtCard.NotEmpty = false;
            this.txtCard.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCard.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtCard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCard.SelectOnEnter = true;
            this.txtCard.Size = new System.Drawing.Size(173, 23);
            this.txtCard.TabIndex = 6;
            this.txtCard.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(165, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "ساعت ورود :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "تاریخ ورود :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "کد مجتمع/بازار:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "گروه کارت :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(454, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "شماره کارت :";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(450, 145);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 34);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "ذخیره";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // JTrafficManualForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 182);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Name = "JTrafficManualForm";
            this.Text = "TrafficManualForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.NumEdit txtCard;
        private System.Windows.Forms.Button btnAdd;
        private ClassLibrary.DateEdit txtDateIn;
        private ClassLibrary.JComboBox cmbGroupCard;
        private ClassLibrary.JComboBox cmbComplex;
        private System.Windows.Forms.MaskedTextBox txtTimeIn;
    }
}