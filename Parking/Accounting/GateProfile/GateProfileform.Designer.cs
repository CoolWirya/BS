namespace Parking
{
    partial class JGateProfileForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCode = new ClassLibrary.TextEdit(this.components);
            this.txtAmount = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TxtHint = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbldate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "كد :";
            // 
            // TxtCode
            // 
            this.TxtCode.ChangeColorIfNotEmpty = false;
            this.TxtCode.ChangeColorOnEnter = true;
            this.TxtCode.Enabled = false;
            this.TxtCode.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtCode.Location = new System.Drawing.Point(48, 26);
            this.TxtCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtCode.Name = "TxtCode";
            this.TxtCode.Negative = true;
            this.TxtCode.NotEmpty = false;
            this.TxtCode.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtCode.SelectOnEnter = true;
            this.TxtCode.Size = new System.Drawing.Size(58, 23);
            this.TxtCode.TabIndex = 1;
            this.TxtCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtAmount
            // 
            this.txtAmount.ChangeColorIfNotEmpty = false;
            this.txtAmount.ChangeColorOnEnter = true;
            this.txtAmount.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAmount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAmount.Location = new System.Drawing.Point(119, 82);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Negative = true;
            this.txtAmount.NotEmpty = false;
            this.txtAmount.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmount.SelectOnEnter = true;
            this.txtAmount.Size = new System.Drawing.Size(221, 23);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "مبلغ دخل فعلي :";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(346, 169);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(110, 37);
            this.BtnAdd.TabIndex = 4;
            this.BtnAdd.Text = "ثبت";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // TxtHint
            // 
            this.TxtHint.ChangeColorIfNotEmpty = false;
            this.TxtHint.ChangeColorOnEnter = true;
            this.TxtHint.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtHint.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtHint.Location = new System.Drawing.Point(84, 138);
            this.TxtHint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtHint.Multiline = true;
            this.TxtHint.Name = "TxtHint";
            this.TxtHint.Negative = true;
            this.TxtHint.NotEmpty = false;
            this.TxtHint.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtHint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtHint.SelectOnEnter = true;
            this.TxtHint.Size = new System.Drawing.Size(256, 68);
            this.TxtHint.TabIndex = 6;
            this.TxtHint.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "توضيحات: ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.txtUser,
            this.toolStripStatusLabel3,
            this.lbldate,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 212);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(460, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(121, 17);
            this.toolStripStatusLabel1.Text = "كاربر ثبت كننده اطلاعات :";
            // 
            // txtUser
            // 
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(11, 17);
            this.txtUser.Text = "-";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
            // 
            // lbldate
            // 
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(35, 17);
            this.lbldate.Text = "تاريخ :";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel4.Text = "-";
            // 
            // JGateProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 234);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TxtHint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtCode);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JGateProfileForm";
            this.Text = "بستن حساب";
            this.Load += new System.EventHandler(this.GateProfileform_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit TxtCode;
        private ClassLibrary.TextEdit txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnAdd;
        private ClassLibrary.TextEdit TxtHint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel txtUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lbldate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
    }
}