namespace Legal.Contract
{
    partial class ContractForm
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.ContractDatedateEdit = new ClassLibrary.DateEdit(this.components);
            this.txtContractNumber = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(489, 413);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 24;
            this.btnBack.Text = "قبلی";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(95, 413);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(14, 413);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 26;
            this.btnNext.Text = "بعدی";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // ContractDatedateEdit
            // 
            this.ContractDatedateEdit.ChangeColorIfNotEmpty = true;
            this.ContractDatedateEdit.ChangeColorOnEnter = true;
            this.ContractDatedateEdit.Date = new System.DateTime(((long)(0)));
            this.ContractDatedateEdit.InBackColor = System.Drawing.SystemColors.Info;
            this.ContractDatedateEdit.InForeColor = System.Drawing.SystemColors.WindowText;
            this.ContractDatedateEdit.Location = new System.Drawing.Point(158, 49);
            this.ContractDatedateEdit.Mask = "0000/00/00";
            this.ContractDatedateEdit.Name = "ContractDatedateEdit";
            this.ContractDatedateEdit.NotEmpty = false;
            this.ContractDatedateEdit.NotEmptyColor = System.Drawing.Color.Red;
            this.ContractDatedateEdit.Size = new System.Drawing.Size(121, 23);
            this.ContractDatedateEdit.TabIndex = 23;
            // 
            // txtContractNumber
            // 
            this.txtContractNumber.ChangeColorIfNotEmpty = true;
            this.txtContractNumber.ChangeColorOnEnter = true;
            this.txtContractNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtContractNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtContractNumber.Location = new System.Drawing.Point(29, 49);
            this.txtContractNumber.Name = "txtContractNumber";
            this.txtContractNumber.Negative = true;
            this.txtContractNumber.NotEmpty = false;
            this.txtContractNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtContractNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtContractNumber.SelectOnEnter = true;
            this.txtContractNumber.Size = new System.Drawing.Size(123, 23);
            this.txtContractNumber.TabIndex = 22;
            this.txtContractNumber.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "شماره قرارداد:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "تاریخ قرار داد:";
            // 
            // ContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 451);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.ContractDatedateEdit);
            this.Controls.Add(this.txtContractNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "ContractForm";
            this.Text = "Contract";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private ClassLibrary.DateEdit ContractDatedateEdit;
        private ClassLibrary.TextEdit txtContractNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}