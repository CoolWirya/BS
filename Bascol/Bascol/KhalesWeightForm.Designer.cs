namespace Bascol
{
    partial class JKhalesWeightForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBascolCode = new ClassLibrary.JComboBox(this.components);
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.txtWeight = new ClassLibrary.TextEdit(this.components);
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 22);
            this.label4.TabIndex = 37;
            this.label4.Text = "شماره باسکول:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(83, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 22);
            this.label3.TabIndex = 36;
            this.label3.Text = "تاریخ توزین:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 22);
            this.label2.TabIndex = 35;
            this.label2.Text = "وزن خالی بار / پر بار:";
            // 
            // cmbBascolCode
            // 
            this.cmbBascolCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbBascolCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBascolCode.BaseCode = 0;
            this.cmbBascolCode.ChangeColorIfNotEmpty = true;
            this.cmbBascolCode.ChangeColorOnEnter = true;
            this.cmbBascolCode.Font = new System.Drawing.Font("Tahoma", 16F);
            this.cmbBascolCode.FormattingEnabled = true;
            this.cmbBascolCode.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbBascolCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBascolCode.Location = new System.Drawing.Point(185, 21);
            this.cmbBascolCode.Name = "cmbBascolCode";
            this.cmbBascolCode.NotEmpty = false;
            this.cmbBascolCode.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbBascolCode.SelectOnEnter = true;
            this.cmbBascolCode.Size = new System.Drawing.Size(140, 33);
            this.cmbBascolCode.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(122, 167);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(96, 30);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "تایید";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(240, 167);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(102, 30);
            this.btnCancle.TabIndex = 5;
            this.btnCancle.Text = "انصراف";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // txtWeight
            // 
            this.txtWeight.ChangeColorIfNotEmpty = false;
            this.txtWeight.ChangeColorOnEnter = true;
            this.txtWeight.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txtWeight.InBackColor = System.Drawing.SystemColors.Info;
            this.txtWeight.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWeight.Location = new System.Drawing.Point(185, 63);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Negative = true;
            this.txtWeight.NotEmpty = false;
            this.txtWeight.NotEmptyColor = System.Drawing.Color.Red;
            this.txtWeight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWeight.SelectOnEnter = true;
            this.txtWeight.Size = new System.Drawing.Size(140, 33);
            this.txtWeight.TabIndex = 2;
            this.txtWeight.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtDate
            // 
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(185, 109);
            this.txtDate.Mask = "1300/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(140, 33);
            this.txtDate.TabIndex = 3;
            // 
            // JKhalesWeightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 230);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cmbBascolCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "JKhalesWeightForm";
            this.Text = "KhalesWeightForm";
            this.Load += new System.EventHandler(this.JKhalesWeightForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JKhalesWeightForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.JComboBox cmbBascolCode;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancle;
        private ClassLibrary.TextEdit txtWeight;
        private ClassLibrary.DateEdit txtDate;
    }
}