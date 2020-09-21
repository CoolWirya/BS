namespace ManagementShares
{
    partial class JShareCompanyForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PriceText = new System.Windows.Forms.TextBox();
            this.jucPerson1 = new ClassLibrary.JUCPerson();
            this.label2 = new System.Windows.Forms.Label();
            this.TaxTransfer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 301);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 43);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(93, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "تائید";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TaxTransfer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PriceText);
            this.groupBox1.Controls.Add(this.jucPerson1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(583, 301);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(475, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "ارزش اسمی";
            // 
            // PriceText
            // 
            this.PriceText.Location = new System.Drawing.Point(272, 205);
            this.PriceText.Name = "PriceText";
            this.PriceText.Size = new System.Drawing.Size(188, 23);
            this.PriceText.TabIndex = 1;
            this.PriceText.Text = "0";
            // 
            // jucPerson1
            // 
            this.jucPerson1.CompanyCode = 1;
            this.jucPerson1.Dock = System.Windows.Forms.DockStyle.Top;
            this.jucPerson1.FilterPerson = null;
            this.jucPerson1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.jucPerson1.LableGroup = null;
            this.jucPerson1.Location = new System.Drawing.Point(3, 20);
            this.jucPerson1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jucPerson1.Name = "jucPerson1";
            this.jucPerson1.PersonType = ClassLibrary.JPersonTypes.LegalPerson;
            this.jucPerson1.ReadOnly = false;
            this.jucPerson1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.jucPerson1.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.jucPerson1.SelectedCode = 0;
            this.jucPerson1.ShareSelectedCode = ((long)(0));
            this.jucPerson1.Size = new System.Drawing.Size(577, 199);
            this.jucPerson1.TabIndex = 0;
            this.jucPerson1.TafsiliCode = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "مالیات انتقال";
            // 
            // TaxTransfer
            // 
            this.TaxTransfer.Location = new System.Drawing.Point(331, 234);
            this.TaxTransfer.Name = "TaxTransfer";
            this.TaxTransfer.Size = new System.Drawing.Size(129, 23);
            this.TaxTransfer.TabIndex = 3;
            this.TaxTransfer.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "درصد";
            // 
            // JShareCompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 344);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JShareCompanyForm";
            this.Text = "مشخصات شرکت";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JUCPerson jucPerson1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PriceText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TaxTransfer;
    }
}