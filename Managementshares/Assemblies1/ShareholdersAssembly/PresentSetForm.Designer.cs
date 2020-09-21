namespace ManagementShares
{
    partial class JPresentSetForm
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
            this.txtCardCode = new System.Windows.Forms.TextBox();
            this.btnPresent = new System.Windows.Forms.Button();
            this.btnNonPresent = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lbPersonCount = new System.Windows.Forms.Label();
            this.lbShareCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCardCode
            // 
            this.txtCardCode.Location = new System.Drawing.Point(15, 47);
            this.txtCardCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCardCode.Name = "txtCardCode";
            this.txtCardCode.Size = new System.Drawing.Size(208, 27);
            this.txtCardCode.TabIndex = 0;
            this.txtCardCode.TextChanged += new System.EventHandler(this.txtCardCode_TextChanged);
            this.txtCardCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardCode_KeyPress);
            // 
            // btnPresent
            // 
            this.btnPresent.Location = new System.Drawing.Point(232, 47);
            this.btnPresent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPresent.Name = "btnPresent";
            this.btnPresent.Size = new System.Drawing.Size(96, 28);
            this.btnPresent.TabIndex = 1;
            this.btnPresent.Text = "حاضر";
            this.btnPresent.UseVisualStyleBackColor = true;
            this.btnPresent.Click += new System.EventHandler(this.btnPresent_Click);
            // 
            // btnNonPresent
            // 
            this.btnNonPresent.Location = new System.Drawing.Point(338, 47);
            this.btnNonPresent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNonPresent.Name = "btnNonPresent";
            this.btnNonPresent.Size = new System.Drawing.Size(96, 28);
            this.btnNonPresent.TabIndex = 1;
            this.btnNonPresent.Text = "عدم حضور";
            this.btnNonPresent.UseVisualStyleBackColor = true;
            this.btnNonPresent.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(641, 137);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "کد برگه رای";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "تعداد:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "مجموع:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(188, 141);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(107, 28);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "دوباره سازی";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lbPersonCount
            // 
            this.lbPersonCount.AutoSize = true;
            this.lbPersonCount.Location = new System.Drawing.Point(96, 112);
            this.lbPersonCount.Name = "lbPersonCount";
            this.lbPersonCount.Size = new System.Drawing.Size(0, 19);
            this.lbPersonCount.TabIndex = 3;
            // 
            // lbShareCount
            // 
            this.lbShareCount.AutoSize = true;
            this.lbShareCount.Location = new System.Drawing.Point(96, 146);
            this.lbShareCount.Name = "lbShareCount";
            this.lbShareCount.Size = new System.Drawing.Size(0, 19);
            this.lbShareCount.TabIndex = 3;
            // 
            // JPresentSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 211);
            this.Controls.Add(this.lbShareCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbPersonCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNonPresent);
            this.Controls.Add(this.btnPresent);
            this.Controls.Add(this.txtCardCode);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "JPresentSetForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PresentSetForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCardCode;
        private System.Windows.Forms.Button btnPresent;
        private System.Windows.Forms.Button btnNonPresent;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lbPersonCount;
        private System.Windows.Forms.Label lbShareCount;
    }
}