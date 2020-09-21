namespace AUTOMOBILE.Controls
{
    partial class JPlaqueControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPlak = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPlak1 = new ClassLibrary.TextEdit(this.components);
            this.txtPlak2 = new ClassLibrary.TextEdit(this.components);
            this.txtPlak3 = new ClassLibrary.TextEdit(this.components);
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(183, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 349;
            this.label6.Text = "ایران";
            // 
            // cmbPlak
            // 
            this.cmbPlak.DisplayMember = "21";
            this.cmbPlak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlak.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPlak.FormattingEnabled = true;
            this.cmbPlak.Items.AddRange(new object[] {
            "الف",
            "ب",
            "پ",
            "ت",
            "ث",
            "ج",
            "چ",
            "ح",
            "خ",
            "د",
            "ذ",
            "ر",
            "ز",
            "ژ",
            "س",
            "ش",
            "ص",
            "ض",
            "ط",
            "ظ",
            "ع",
            "غ",
            "ف",
            "ق",
            "ک",
            "گ",
            "ل",
            "م",
            "ن",
            "و",
            "ه",
            "ی"});
            this.cmbPlak.Location = new System.Drawing.Point(46, 3);
            this.cmbPlak.Name = "cmbPlak";
            this.cmbPlak.Size = new System.Drawing.Size(46, 21);
            this.cmbPlak.TabIndex = 345;
            this.cmbPlak.ValueMember = "21";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(136, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 348;
            this.label10.Text = "-";
            // 
            // txtPlak1
            // 
            this.txtPlak1.ChangeColorIfNotEmpty = false;
            this.txtPlak1.ChangeColorOnEnter = true;
            this.txtPlak1.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPlak1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPlak1.Location = new System.Drawing.Point(12, 3);
            this.txtPlak1.MaxLength = 2;
            this.txtPlak1.Name = "txtPlak1";
            this.txtPlak1.Negative = true;
            this.txtPlak1.NotEmpty = false;
            this.txtPlak1.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPlak1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlak1.SelectOnEnter = true;
            this.txtPlak1.Size = new System.Drawing.Size(30, 20);
            this.txtPlak1.TabIndex = 350;
            this.txtPlak1.TextMode = ClassLibrary.TextModes.Integer;
            this.txtPlak1.TextChanged += new System.EventHandler(this.txtPlak1_TextChanged);
            this.txtPlak1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlak1_KeyPress_1);
            // 
            // txtPlak2
            // 
            this.txtPlak2.ChangeColorIfNotEmpty = false;
            this.txtPlak2.ChangeColorOnEnter = true;
            this.txtPlak2.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPlak2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPlak2.Location = new System.Drawing.Point(98, 4);
            this.txtPlak2.MaxLength = 3;
            this.txtPlak2.Name = "txtPlak2";
            this.txtPlak2.Negative = true;
            this.txtPlak2.NotEmpty = false;
            this.txtPlak2.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPlak2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlak2.SelectOnEnter = true;
            this.txtPlak2.Size = new System.Drawing.Size(40, 20);
            this.txtPlak2.TabIndex = 351;
            this.txtPlak2.TextMode = ClassLibrary.TextModes.Integer;
            this.txtPlak2.TextChanged += new System.EventHandler(this.txtPlak2_TextChanged);
            this.txtPlak2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlak2_KeyPress);
            // 
            // txtPlak3
            // 
            this.txtPlak3.ChangeColorIfNotEmpty = false;
            this.txtPlak3.ChangeColorOnEnter = true;
            this.txtPlak3.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPlak3.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPlak3.Location = new System.Drawing.Point(144, 4);
            this.txtPlak3.MaxLength = 2;
            this.txtPlak3.Name = "txtPlak3";
            this.txtPlak3.Negative = true;
            this.txtPlak3.NotEmpty = false;
            this.txtPlak3.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPlak3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlak3.SelectOnEnter = true;
            this.txtPlak3.Size = new System.Drawing.Size(33, 20);
            this.txtPlak3.TabIndex = 352;
            this.txtPlak3.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // PlaqueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPlak3);
            this.Controls.Add(this.txtPlak2);
            this.Controls.Add(this.txtPlak1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbPlak);
            this.Controls.Add(this.label10);
            this.Name = "PlaqueControl";
            this.Size = new System.Drawing.Size(209, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbPlak;
        private System.Windows.Forms.Label label10;
        private ClassLibrary.TextEdit txtPlak1;
        private ClassLibrary.TextEdit txtPlak2;
        private ClassLibrary.TextEdit txtPlak3;
    }
}
