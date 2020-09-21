namespace Legal
{
    partial class JTextContractForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.objTextWordControl = new OfficeWord.TextControl();
            this.objWinWordControl = new OfficeWord.WinWordControl();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.objTextWordControl);
            this.groupBox2.Controls.Add(this.objWinWordControl);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(798, 601);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // objTextWordControl
            // 
            this.objTextWordControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objTextWordControl.Location = new System.Drawing.Point(3, 19);
            this.objTextWordControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.objTextWordControl.Name = "objTextWordControl";
            this.objTextWordControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.objTextWordControl.Size = new System.Drawing.Size(792, 579);
            this.objTextWordControl.TabIndex = 1;
            // 
            // objWinWordControl
            // 
            this.objWinWordControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objWinWordControl.Location = new System.Drawing.Point(3, 19);
            this.objWinWordControl.Name = "objWinWordControl";
            this.objWinWordControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.objWinWordControl.Size = new System.Drawing.Size(792, 579);
            this.objWinWordControl.TabIndex = 0;
            // 
            // JTextContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 601);
            this.Controls.Add(this.groupBox2);
            this.Name = "JTextContractForm";
            this.Text = "TextContract";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.JTextContractForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private OfficeWord.WinWordControl objWinWordControl;
        private OfficeWord.TextControl objTextWordControl;
    }
}