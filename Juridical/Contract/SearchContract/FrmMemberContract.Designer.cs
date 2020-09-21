namespace Security
{
    partial class FrmMemberContract
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
            this.TxtPerson = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtGhNumber = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbSamat = new ClassLibrary.JComboBox(this.components);
            this.ChkBlock = new System.Windows.Forms.CheckBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.btnPerson = new System.Windows.Forms.Button();
            this.BtnGharardad = new System.Windows.Forms.Button();
            this.TxtExpireDate = new ClassLibrary.DateEdit(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtCode = new ClassLibrary.TextEdit(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtPerson
            // 
            this.TxtPerson.ChangeColorIfNotEmpty = false;
            this.TxtPerson.ChangeColorOnEnter = true;
            this.TxtPerson.Enabled = false;
            this.TxtPerson.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtPerson.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtPerson.Location = new System.Drawing.Point(109, 13);
            this.TxtPerson.Name = "TxtPerson";
            this.TxtPerson.Negative = true;
            this.TxtPerson.NotEmpty = false;
            this.TxtPerson.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtPerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtPerson.SelectOnEnter = true;
            this.TxtPerson.Size = new System.Drawing.Size(258, 23);
            this.TxtPerson.TabIndex = 0;
            this.TxtPerson.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "شخص مورد نظر :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "شماره قرارداد:";
            // 
            // TxtGhNumber
            // 
            this.TxtGhNumber.ChangeColorIfNotEmpty = false;
            this.TxtGhNumber.ChangeColorOnEnter = true;
            this.TxtGhNumber.Enabled = false;
            this.TxtGhNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtGhNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtGhNumber.Location = new System.Drawing.Point(111, 54);
            this.TxtGhNumber.Multiline = true;
            this.TxtGhNumber.Name = "TxtGhNumber";
            this.TxtGhNumber.Negative = true;
            this.TxtGhNumber.NotEmpty = false;
            this.TxtGhNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtGhNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtGhNumber.SelectOnEnter = true;
            this.TxtGhNumber.Size = new System.Drawing.Size(256, 50);
            this.TxtGhNumber.TabIndex = 2;
            this.TxtGhNumber.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "تاريخ پايان همكاري :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "سمت :";
            // 
            // CmbSamat
            // 
            this.CmbSamat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbSamat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbSamat.BaseCode = 0;
            this.CmbSamat.ChangeColorIfNotEmpty = true;
            this.CmbSamat.ChangeColorOnEnter = true;
            this.CmbSamat.FormattingEnabled = true;
            this.CmbSamat.InBackColor = System.Drawing.SystemColors.Info;
            this.CmbSamat.InForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbSamat.Location = new System.Drawing.Point(62, 158);
            this.CmbSamat.Name = "CmbSamat";
            this.CmbSamat.NotEmpty = false;
            this.CmbSamat.NotEmptyColor = System.Drawing.Color.Red;
            this.CmbSamat.SelectOnEnter = true;
            this.CmbSamat.Size = new System.Drawing.Size(188, 24);
            this.CmbSamat.TabIndex = 7;
            // 
            // ChkBlock
            // 
            this.ChkBlock.AutoSize = true;
            this.ChkBlock.Location = new System.Drawing.Point(9, 195);
            this.ChkBlock.Name = "ChkBlock";
            this.ChkBlock.Size = new System.Drawing.Size(135, 20);
            this.ChkBlock.TabIndex = 8;
            this.ChkBlock.Text = "مورد تاييد مي باشد";
            this.ChkBlock.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(7, 223);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(97, 38);
            this.BtnSave.TabIndex = 9;
            this.BtnSave.Text = "ذخيره";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnPerson
            // 
            this.btnPerson.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPerson.Location = new System.Drawing.Point(373, 11);
            this.btnPerson.Name = "btnPerson";
            this.btnPerson.Size = new System.Drawing.Size(29, 30);
            this.btnPerson.TabIndex = 10;
            this.btnPerson.Text = "...";
            this.btnPerson.UseVisualStyleBackColor = true;
            this.btnPerson.Click += new System.EventHandler(this.btnPerson_Click);
            // 
            // BtnGharardad
            // 
            this.BtnGharardad.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.BtnGharardad.Location = new System.Drawing.Point(373, 54);
            this.BtnGharardad.Name = "BtnGharardad";
            this.BtnGharardad.Size = new System.Drawing.Size(29, 30);
            this.BtnGharardad.TabIndex = 11;
            this.BtnGharardad.Text = "...";
            this.BtnGharardad.UseVisualStyleBackColor = true;
            this.BtnGharardad.Click += new System.EventHandler(this.BtnGharardad_Click);
            // 
            // TxtExpireDate
            // 
            this.TxtExpireDate.ChangeColorIfNotEmpty = true;
            this.TxtExpireDate.ChangeColorOnEnter = true;
            this.TxtExpireDate.Date = new System.DateTime(((long)(0)));
            this.TxtExpireDate.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtExpireDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtExpireDate.InsertInDatesTable = true;
            this.TxtExpireDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.TxtExpireDate.Location = new System.Drawing.Point(132, 110);
            this.TxtExpireDate.Mask = "0000/00/00";
            this.TxtExpireDate.Name = "TxtExpireDate";
            this.TxtExpireDate.NotEmpty = false;
            this.TxtExpireDate.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtExpireDate.Size = new System.Drawing.Size(118, 23);
            this.TxtExpireDate.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "كد:";
            this.label5.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.ChangeColorIfNotEmpty = false;
            this.txtCode.ChangeColorOnEnter = true;
            this.txtCode.Enabled = false;
            this.txtCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCode.Location = new System.Drawing.Point(316, 158);
            this.txtCode.Name = "txtCode";
            this.txtCode.Negative = true;
            this.txtCode.NotEmpty = false;
            this.txtCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCode.SelectOnEnter = true;
            this.txtCode.Size = new System.Drawing.Size(76, 23);
            this.txtCode.TabIndex = 13;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCode.TextMode = ClassLibrary.TextModes.Integer;
            this.txtCode.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 38);
            this.button1.TabIndex = 15;
            this.button1.Text = "اعمال";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMemberContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 266);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.TxtExpireDate);
            this.Controls.Add(this.BtnGharardad);
            this.Controls.Add(this.btnPerson);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.ChkBlock);
            this.Controls.Add(this.CmbSamat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtGhNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtPerson);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMemberContract";
            this.Text = "اشخاص مرتبط با قرارداد";
            this.Load += new System.EventHandler(this.FrmMemberContract_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClassLibrary.TextEdit TxtPerson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit TxtGhNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.JComboBox CmbSamat;
        private System.Windows.Forms.CheckBox ChkBlock;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button btnPerson;
        private System.Windows.Forms.Button BtnGharardad;
        private ClassLibrary.DateEdit TxtExpireDate;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.TextEdit txtCode;
        private System.Windows.Forms.Button button1;
    }
}