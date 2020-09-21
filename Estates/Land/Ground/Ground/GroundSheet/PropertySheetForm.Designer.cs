namespace Estates
{
    partial class JPropertySheetForm
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
            this.jDefinePropertyUserControl1 = new Globals.Property.JDefinePropertyUserControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // jDefinePropertyUserControl1
            // 
            this.jDefinePropertyUserControl1.ClassName = null;
            this.jDefinePropertyUserControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.jDefinePropertyUserControl1.Location = new System.Drawing.Point(0, 0);
            this.jDefinePropertyUserControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.jDefinePropertyUserControl1.Name = "jDefinePropertyUserControl1";
            this.jDefinePropertyUserControl1.ObjectCode = 0;
            this.jDefinePropertyUserControl1.Size = new System.Drawing.Size(583, 408);
            this.jDefinePropertyUserControl1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "ذخیره";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(148, 416);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "خروج";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // JPropertySheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 451);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.jDefinePropertyUserControl1);
            this.Name = "JPropertySheetForm";
            this.Text = "PropertySheetForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Globals.Property.JDefinePropertyUserControl jDefinePropertyUserControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

    }
}