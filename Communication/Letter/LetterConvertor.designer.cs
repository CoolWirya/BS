namespace Communication.Letter
{
    partial class LetterConvertor
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
            this.btnConvert = new System.Windows.Forms.Button();
            this.PBLoading = new System.Windows.Forms.ProgressBar();
            this.lblPercent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            //this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
           // this.htmlEditor1 = new ClassLibrary.HtmlEditor();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(29, 121);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(232, 23);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "RTF to HTML";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // PBLoading
            // 
            this.PBLoading.Location = new System.Drawing.Point(12, 222);
            this.PBLoading.Name = "PBLoading";
            this.PBLoading.Size = new System.Drawing.Size(260, 23);
            this.PBLoading.TabIndex = 1;
            this.PBLoading.UseWaitCursor = true;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(12, 203);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(13, 13);
            this.lblPercent.TabIndex = 2;
            this.lblPercent.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "%";
            // 
            // htmlEditor1
            // 
            //this.htmlEditor1.Location = new System.Drawing.Point(301, 1);
            //this.htmlEditor1.Name = "htmlEditor1";
            //this.htmlEditor1.Size = new System.Drawing.Size(794, 465);
            //this.htmlEditor1.TabIndex = 4;
            // 
            // LetterConvertor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 468);
           // this.Controls.Add(this.htmlEditor1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.PBLoading);
            this.Controls.Add(this.btnConvert);
            this.Name = "LetterConvertor";
            this.Text = "LetterConvertor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ProgressBar PBLoading;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label label1;
        //private Telerik.WinControls.RadThemeManager radThemeManager1;
       // private ClassLibrary.HtmlEditor htmlEditor1;
    }
}