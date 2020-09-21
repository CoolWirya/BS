namespace MapProject.WindowsForms.Forms
{
    partial class BaseForm
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
            this.mainForm1 = new MapProject.WindowsForms.MainForm();
            this.SuspendLayout();
            // 
            // mainForm1
            // 
            this.mainForm1.BackColor = System.Drawing.Color.AliceBlue;
            this.mainForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainForm1.Location = new System.Drawing.Point(0, 0);
            this.mainForm1.MinimumSize = new System.Drawing.Size(552, 103);
            this.mainForm1.Name = "mainForm1";
            this.mainForm1.Size = new System.Drawing.Size(707, 474);
            this.mainForm1.TabIndex = 0;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 474);
            this.Controls.Add(this.mainForm1);
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.ResumeLayout(false);

        }

        #endregion

        private MainForm mainForm1;
    }
}