namespace RealEstate
{
    partial class EnviromentSetPrimaryowenerForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtNamyandeh = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrimaryOwner = new ClassLibrary.TextEdit(this.components);
            this.BtnPrimaryOwner = new System.Windows.Forms.Button();
            this.BtnNamyandeh = new System.Windows.Forms.Button();
            this.cmbMarket = new ClassLibrary.JComboBox(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 108);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "نماينده قرارداد :";
            // 
            // txtNamyandeh
            // 
            this.txtNamyandeh.ChangeColorIfNotEmpty = false;
            this.txtNamyandeh.ChangeColorOnEnter = true;
            this.txtNamyandeh.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNamyandeh.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNamyandeh.Location = new System.Drawing.Point(100, 105);
            this.txtNamyandeh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNamyandeh.Name = "txtNamyandeh";
            this.txtNamyandeh.Negative = true;
            this.txtNamyandeh.NotEmpty = false;
            this.txtNamyandeh.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNamyandeh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNamyandeh.SelectOnEnter = true;
            this.txtNamyandeh.Size = new System.Drawing.Size(186, 23);
            this.txtNamyandeh.TabIndex = 11;
            this.txtNamyandeh.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "مالك :";
            // 
            // txtPrimaryOwner
            // 
            this.txtPrimaryOwner.ChangeColorIfNotEmpty = false;
            this.txtPrimaryOwner.ChangeColorOnEnter = true;
            this.txtPrimaryOwner.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrimaryOwner.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrimaryOwner.Location = new System.Drawing.Point(100, 56);
            this.txtPrimaryOwner.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrimaryOwner.Name = "txtPrimaryOwner";
            this.txtPrimaryOwner.Negative = true;
            this.txtPrimaryOwner.NotEmpty = false;
            this.txtPrimaryOwner.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrimaryOwner.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrimaryOwner.SelectOnEnter = true;
            this.txtPrimaryOwner.Size = new System.Drawing.Size(186, 23);
            this.txtPrimaryOwner.TabIndex = 9;
            this.txtPrimaryOwner.TextMode = ClassLibrary.TextModes.Text;
            // 
            // BtnPrimaryOwner
            // 
            this.BtnPrimaryOwner.Location = new System.Drawing.Point(292, 43);
            this.BtnPrimaryOwner.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnPrimaryOwner.Name = "BtnPrimaryOwner";
            this.BtnPrimaryOwner.Size = new System.Drawing.Size(134, 33);
            this.BtnPrimaryOwner.TabIndex = 8;
            this.BtnPrimaryOwner.Text = "انتخاب مالك مشاعات";
            this.BtnPrimaryOwner.UseVisualStyleBackColor = true;
            this.BtnPrimaryOwner.Click += new System.EventHandler(this.BtnPrimaryOwner_Click);
            // 
            // BtnNamyandeh
            // 
            this.BtnNamyandeh.Location = new System.Drawing.Point(292, 100);
            this.BtnNamyandeh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnNamyandeh.Name = "BtnNamyandeh";
            this.BtnNamyandeh.Size = new System.Drawing.Size(134, 33);
            this.BtnNamyandeh.TabIndex = 7;
            this.BtnNamyandeh.Text = "انتخاب نماينده قرارداد";
            this.BtnNamyandeh.UseVisualStyleBackColor = true;
            this.BtnNamyandeh.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbMarket
            // 
            this.cmbMarket.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbMarket.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMarket.BaseCode = 0;
            this.cmbMarket.ChangeColorIfNotEmpty = true;
            this.cmbMarket.ChangeColorOnEnter = true;
            this.cmbMarket.FormattingEnabled = true;
            this.cmbMarket.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbMarket.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbMarket.Location = new System.Drawing.Point(100, 12);
            this.cmbMarket.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMarket.Name = "cmbMarket";
            this.cmbMarket.NotEmpty = false;
            this.cmbMarket.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbMarket.SelectOnEnter = true;
            this.cmbMarket.Size = new System.Drawing.Size(186, 24);
            this.cmbMarket.TabIndex = 6;
            this.cmbMarket.SelectedIndexChanged += new System.EventHandler(this.cmbMarket_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 162);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(426, 44);
            this.button1.TabIndex = 4;
            this.button1.Text = "تاييد";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "مجتمع :";
            // 
            // EnviromentSetPrimaryowenerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 206);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNamyandeh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrimaryOwner);
            this.Controls.Add(this.BtnPrimaryOwner);
            this.Controls.Add(this.BtnNamyandeh);
            this.Controls.Add(this.cmbMarket);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EnviromentSetPrimaryowenerForm";
            this.Text = "تعيين نماينده قرارداد";
            this.Load += new System.EventHandler(this._ٍEnviromentSetPrimaryowenerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private ClassLibrary.JComboBox cmbMarket;
        private System.Windows.Forms.Button BtnNamyandeh;
        private System.Windows.Forms.Button BtnPrimaryOwner;
        private ClassLibrary.TextEdit txtPrimaryOwner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.TextEdit txtNamyandeh;
        private System.Windows.Forms.Label label1;
    }
}