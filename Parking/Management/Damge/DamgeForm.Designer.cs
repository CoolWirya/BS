namespace Parking
{
    partial class DamgeForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txthint = new ClassLibrary.TextEdit(this.components);
            this.CmbTypeDamge = new ClassLibrary.JComboBox(this.components);
            this.CmbGate = new ClassLibrary.JComboBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 34);
            this.button1.TabIndex = 18;
            this.button1.Text = "ثبت";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "توضيحات :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "نوع ايراد :";
            // 
            // txthint
            // 
            this.txthint.ChangeColorIfNotEmpty = false;
            this.txthint.ChangeColorOnEnter = true;
            this.txthint.InBackColor = System.Drawing.SystemColors.Info;
            this.txthint.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txthint.Location = new System.Drawing.Point(90, 130);
            this.txthint.Multiline = true;
            this.txthint.Name = "txthint";
            this.txthint.Negative = true;
            this.txthint.NotEmpty = false;
            this.txthint.NotEmptyColor = System.Drawing.Color.Red;
            this.txthint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txthint.SelectOnEnter = true;
            this.txthint.Size = new System.Drawing.Size(490, 81);
            this.txthint.TabIndex = 13;
            this.txthint.TextMode = ClassLibrary.TextModes.Text;
            // 
            // CmbTypeDamge
            // 
            this.CmbTypeDamge.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.CmbTypeDamge.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbTypeDamge.BaseCode = 0;
            this.CmbTypeDamge.ChangeColorIfNotEmpty = true;
            this.CmbTypeDamge.ChangeColorOnEnter = true;
            this.CmbTypeDamge.FormattingEnabled = true;
            this.CmbTypeDamge.InBackColor = System.Drawing.SystemColors.Info;
            this.CmbTypeDamge.InForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbTypeDamge.Location = new System.Drawing.Point(90, 75);
            this.CmbTypeDamge.Name = "CmbTypeDamge";
            this.CmbTypeDamge.NotEmpty = false;
            this.CmbTypeDamge.NotEmptyColor = System.Drawing.Color.Red;
            this.CmbTypeDamge.SelectOnEnter = true;
            this.CmbTypeDamge.Size = new System.Drawing.Size(155, 24);
            this.CmbTypeDamge.TabIndex = 11;
            // 
            // CmbGate
            // 
            this.CmbGate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.CmbGate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbGate.BaseCode = 0;
            this.CmbGate.ChangeColorIfNotEmpty = true;
            this.CmbGate.ChangeColorOnEnter = true;
            this.CmbGate.FormattingEnabled = true;
            this.CmbGate.InBackColor = System.Drawing.SystemColors.Info;
            this.CmbGate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbGate.Location = new System.Drawing.Point(90, 17);
            this.CmbGate.Name = "CmbGate";
            this.CmbGate.NotEmpty = false;
            this.CmbGate.NotEmptyColor = System.Drawing.Color.Red;
            this.CmbGate.SelectOnEnter = true;
            this.CmbGate.Size = new System.Drawing.Size(155, 24);
            this.CmbGate.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "گيت :";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(443, 241);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(137, 34);
            this.btnExit.TabIndex = 26;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // DamgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 280);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.CmbGate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txthint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbTypeDamge);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DamgeForm";
            this.Text = "ايرادات";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClassLibrary.JComboBox CmbTypeDamge;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.TextEdit txthint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private ClassLibrary.JComboBox CmbGate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExit;
    }
}