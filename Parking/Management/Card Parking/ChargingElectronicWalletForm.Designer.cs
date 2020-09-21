namespace Parking.Management.Card_Parking
{
    partial class ChargingElectronicWalletForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textEdit1 = new ClassLibrary.TextEdit(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtIDContract = new ClassLibrary.NumEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEndDateContract = new ClassLibrary.DateEdit(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbComplex = new ClassLibrary.JComboBox(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.txtIDCardParking = new ClassLibrary.NumEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodeCard = new ClassLibrary.NumEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIDBusinessUnit = new ClassLibrary.JComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textEdit1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtIDContract);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtEndDateContract);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 186);
            this.groupBox2.TabIndex = 79;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اطلاعات قرارداد";
            // 
            // textEdit1
            // 
            this.textEdit1.ChangeColorIfNotEmpty = false;
            this.textEdit1.ChangeColorOnEnter = true;
            this.textEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.textEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.textEdit1.Location = new System.Drawing.Point(36, 82);
            this.textEdit1.Multiline = true;
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Negative = true;
            this.textEdit1.NotEmpty = false;
            this.textEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.textEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit1.SelectOnEnter = true;
            this.textEdit1.Size = new System.Drawing.Size(478, 89);
            this.textEdit1.TabIndex = 75;
            this.textEdit1.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(498, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "موجودی کارت:";
            // 
            // txtIDContract
            // 
            this.txtIDContract.ChangeColorIfNotEmpty = false;
            this.txtIDContract.ChangeColorOnEnter = true;
            this.txtIDContract.InBackColor = System.Drawing.SystemColors.Info;
            this.txtIDContract.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIDContract.Location = new System.Drawing.Point(284, 30);
            this.txtIDContract.Name = "txtIDContract";
            this.txtIDContract.Negative = true;
            this.txtIDContract.NotEmpty = false;
            this.txtIDContract.NotEmptyColor = System.Drawing.Color.Red;
            this.txtIDContract.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtIDContract.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIDContract.SelectOnEnter = true;
            this.txtIDContract.Size = new System.Drawing.Size(179, 23);
            this.txtIDContract.TabIndex = 37;
            this.txtIDContract.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(150, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 38;
            this.label7.Text = "تاريخ شارژ :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(511, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 16);
            this.label10.TabIndex = 74;
            this.label10.Text = "توضیحات :";
            // 
            // txtEndDateContract
            // 
            this.txtEndDateContract.ChangeColorIfNotEmpty = true;
            this.txtEndDateContract.ChangeColorOnEnter = true;
            this.txtEndDateContract.Date = new System.DateTime(((long)(0)));
            this.txtEndDateContract.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDateContract.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDateContract.InsertInDatesTable = true;
            this.txtEndDateContract.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDateContract.Location = new System.Drawing.Point(36, 27);
            this.txtEndDateContract.Mask = "0000/00/00";
            this.txtEndDateContract.Name = "txtEndDateContract";
            this.txtEndDateContract.NotEmpty = false;
            this.txtEndDateContract.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDateContract.Size = new System.Drawing.Size(107, 23);
            this.txtEndDateContract.TabIndex = 39;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbComplex);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtIDCardParking);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCodeCard);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbIDBusinessUnit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 127);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات";
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
            this.cmbComplex.Location = new System.Drawing.Point(12, 25);
            this.cmbComplex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbComplex.Name = "cmbComplex";
            this.cmbComplex.NotEmpty = false;
            this.cmbComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbComplex.SelectOnEnter = true;
            this.cmbComplex.Size = new System.Drawing.Size(163, 24);
            this.cmbComplex.TabIndex = 83;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(185, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 16);
            this.label17.TabIndex = 82;
            this.label17.Text = "مجتمع/بازار :";
            // 
            // txtIDCardParking
            // 
            this.txtIDCardParking.ChangeColorIfNotEmpty = false;
            this.txtIDCardParking.ChangeColorOnEnter = true;
            this.txtIDCardParking.InBackColor = System.Drawing.SystemColors.Info;
            this.txtIDCardParking.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIDCardParking.Location = new System.Drawing.Point(12, 77);
            this.txtIDCardParking.Name = "txtIDCardParking";
            this.txtIDCardParking.Negative = true;
            this.txtIDCardParking.NotEmpty = false;
            this.txtIDCardParking.NotEmptyColor = System.Drawing.Color.Red;
            this.txtIDCardParking.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtIDCardParking.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIDCardParking.SelectOnEnter = true;
            this.txtIDCardParking.Size = new System.Drawing.Size(163, 23);
            this.txtIDCardParking.TabIndex = 81;
            this.txtIDCardParking.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 80;
            this.label2.Text = "شماره کارت پارکینگ :";
            // 
            // txtCodeCard
            // 
            this.txtCodeCard.ChangeColorIfNotEmpty = false;
            this.txtCodeCard.ChangeColorOnEnter = true;
            this.txtCodeCard.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCodeCard.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCodeCard.Location = new System.Drawing.Point(392, 25);
            this.txtCodeCard.Name = "txtCodeCard";
            this.txtCodeCard.Negative = true;
            this.txtCodeCard.NotEmpty = false;
            this.txtCodeCard.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCodeCard.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtCodeCard.ReadOnly = true;
            this.txtCodeCard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodeCard.SelectOnEnter = true;
            this.txtCodeCard.Size = new System.Drawing.Size(90, 23);
            this.txtCodeCard.TabIndex = 79;
            this.txtCodeCard.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(526, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 78;
            this.label1.Text = "كد كارت :";
            // 
            // cmbIDBusinessUnit
            // 
            this.cmbIDBusinessUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbIDBusinessUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIDBusinessUnit.BaseCode = 0;
            this.cmbIDBusinessUnit.ChangeColorIfNotEmpty = true;
            this.cmbIDBusinessUnit.ChangeColorOnEnter = true;
            this.cmbIDBusinessUnit.FormattingEnabled = true;
            this.cmbIDBusinessUnit.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbIDBusinessUnit.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbIDBusinessUnit.Location = new System.Drawing.Point(332, 76);
            this.cmbIDBusinessUnit.Name = "cmbIDBusinessUnit";
            this.cmbIDBusinessUnit.NotEmpty = false;
            this.cmbIDBusinessUnit.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbIDBusinessUnit.SelectOnEnter = true;
            this.cmbIDBusinessUnit.Size = new System.Drawing.Size(131, 24);
            this.cmbIDBusinessUnit.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(468, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 16);
            this.label5.TabIndex = 74;
            this.label5.Text = "شماره واحد تجاري :";
            // 
            // ChargingElectronicWalletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 381);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChargingElectronicWalletForm";
            this.Text = "ChargingElectronicWalletForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.TextEdit textEdit1;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.NumEdit txtIDContract;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private ClassLibrary.DateEdit txtEndDateContract;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JComboBox cmbComplex;
        private System.Windows.Forms.Label label17;
        private ClassLibrary.NumEdit txtIDCardParking;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.NumEdit txtCodeCard;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JComboBox cmbIDBusinessUnit;
        private System.Windows.Forms.Label label5;
    }
}