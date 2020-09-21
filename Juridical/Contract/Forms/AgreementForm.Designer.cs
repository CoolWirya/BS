namespace Legal
{
    partial class AgreementForm
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
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.dataGridView13 = new System.Windows.Forms.DataGridView();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label26 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView13)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(15, 270);
            this.textBox12.Multiline = true;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(532, 219);
            this.textBox12.TabIndex = 23;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(9, 251);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(120, 16);
            this.label29.TabIndex = 22;
            this.label29.Text = "تغییرات صورت گرفته:";
            // 
            // dataGridView13
            // 
            this.dataGridView13.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView13.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column17,
            this.Column22,
            this.Column28});
            this.dataGridView13.Location = new System.Drawing.Point(12, 37);
            this.dataGridView13.Name = "dataGridView13";
            this.dataGridView13.Size = new System.Drawing.Size(535, 202);
            this.dataGridView13.TabIndex = 21;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "شماره";
            this.Column17.Name = "Column17";
            // 
            // Column22
            // 
            this.Column22.HeaderText = "نوع";
            this.Column22.Name = "Column22";
            // 
            // Column28
            // 
            this.Column28.HeaderText = "تاریخ";
            this.Column28.Name = "Column28";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(12, 18);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(90, 16);
            this.label26.TabIndex = 20;
            this.label26.Text = "لیست سوابق:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(487, 532);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 34;
            this.btnBack.Text = "قبلی";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 532);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(12, 532);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 32;
            this.btnNext.Text = "بعدی";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // AgreementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 567);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.dataGridView13);
            this.Controls.Add(this.label26);
            this.Name = "AgreementForm";
            this.Text = "تغییرات صورت گرفته در قرارداد";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView13)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DataGridView dataGridView13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column28;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
    }
}