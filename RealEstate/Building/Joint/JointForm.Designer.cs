namespace RealEstate
{
    partial class JJointForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new ClassLibrary.NumEdit();
            this.txtType = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbComplex = new ClassLibrary.JComboBox(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(8, 172);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(125, 42);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 60);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 27;
            this.label13.Text = "عنوان :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "شماره :";
            // 
            // txtCode
            // 
            this.txtCode.ChangeColorIfNotEmpty = false;
            this.txtCode.ChangeColorOnEnter = true;
            this.txtCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCode.Location = new System.Drawing.Point(89, 18);
            this.txtCode.Name = "txtCode";
            this.txtCode.Negative = true;
            this.txtCode.NotEmpty = false;
            this.txtCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCode.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtCode.ReadOnly = true;
            this.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCode.SelectOnEnter = true;
            this.txtCode.Size = new System.Drawing.Size(155, 23);
            this.txtCode.TabIndex = 29;
            this.txtCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtType
            // 
            this.txtType.ChangeColorIfNotEmpty = false;
            this.txtType.ChangeColorOnEnter = true;
            this.txtType.InBackColor = System.Drawing.SystemColors.Info;
            this.txtType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtType.Location = new System.Drawing.Point(97, 57);
            this.txtType.Name = "txtType";
            this.txtType.Negative = true;
            this.txtType.NotEmpty = false;
            this.txtType.NotEmptyColor = System.Drawing.Color.Red;
            this.txtType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtType.SelectOnEnter = true;
            this.txtType.Size = new System.Drawing.Size(147, 23);
            this.txtType.TabIndex = 1;
            this.txtType.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 99);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "مجتمع :";
            // 
            // cmbComplex
            // 
            this.cmbComplex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbComplex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbComplex.BaseCode = 0;
            this.cmbComplex.ChangeColorIfNotEmpty = true;
            this.cmbComplex.ChangeColorOnEnter = true;
            this.cmbComplex.FormattingEnabled = true;
            this.cmbComplex.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbComplex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbComplex.Location = new System.Drawing.Point(97, 96);
            this.cmbComplex.Name = "cmbComplex";
            this.cmbComplex.NotEmpty = false;
            this.cmbComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbComplex.SelectOnEnter = true;
            this.cmbComplex.Size = new System.Drawing.Size(147, 24);
            this.cmbComplex.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(195, 172);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "تعیین مالک پیش فرض";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // JJointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 221);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbComplex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JJointForm";
            this.Text = "تعريف فضا";
            this.Load += new System.EventHandler(this.JJointForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.NumEdit txtCode;
        private ClassLibrary.TextEdit txtType;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JComboBox cmbComplex;
        private System.Windows.Forms.Button button1;
    }
}