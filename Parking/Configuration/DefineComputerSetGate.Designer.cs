namespace Parking
{
    partial class DefineComputerSetGate
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
            this.cmbComplex = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGate = new ClassLibrary.JComboBox(this.components);
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(255, 111);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 32);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "ثبت";
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
            this.cmbComplex.Location = new System.Drawing.Point(166, 21);
            this.cmbComplex.Name = "cmbComplex";
            this.cmbComplex.NotEmpty = false;
            this.cmbComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbComplex.SelectOnEnter = true;
            this.cmbComplex.Size = new System.Drawing.Size(177, 24);
            this.cmbComplex.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "مجتمع در حال کار :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "گیت :";
            // 
            // cmbGate
            // 
            this.cmbGate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGate.BaseCode = 0;
            this.cmbGate.ChangeColorIfNotEmpty = true;
            this.cmbGate.ChangeColorOnEnter = true;
            this.cmbGate.FormattingEnabled = true;
            this.cmbGate.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGate.Location = new System.Drawing.Point(166, 70);
            this.cmbGate.Name = "cmbGate";
            this.cmbGate.NotEmpty = false;
            this.cmbGate.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGate.SelectOnEnter = true;
            this.cmbGate.Size = new System.Drawing.Size(177, 24);
            this.cmbGate.TabIndex = 10;
            // 
            // DefineComputerSetGate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 165);
            this.Controls.Add(this.cmbGate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbComplex);
            this.Controls.Add(this.btnAdd);
            this.Name = "DefineComputerSetGate";
            this.Text = "DefineComputerSetGate";
            this.Load += new System.EventHandler(this.DefineComputerSetGate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private ClassLibrary.JComboBox cmbComplex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.JComboBox cmbGate;
    }
}