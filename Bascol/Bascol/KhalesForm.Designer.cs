namespace Bascol
{
    partial class JKhalesForm
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
            this.jJanusGrid1 = new ClassLibrary.JJanusGrid();
            this.btnPrint2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // jJanusGrid1
            // 
            this.jJanusGrid1.ActionMenu = null;
            this.jJanusGrid1.DataSource = null;
            this.jJanusGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jJanusGrid1.Edited = false;
            this.jJanusGrid1.Location = new System.Drawing.Point(0, 0);
            this.jJanusGrid1.MultiSelect = false;
            this.jJanusGrid1.Name = "jJanusGrid1";
            this.jJanusGrid1.ShowNavigator = true;
            this.jJanusGrid1.ShowToolbar = true;
            this.jJanusGrid1.Size = new System.Drawing.Size(583, 451);
            this.jJanusGrid1.TabIndex = 4;
            // 
            // btnPrint2
            // 
            this.btnPrint2.Location = new System.Drawing.Point(348, 4);
            this.btnPrint2.Name = "btnPrint2";
            this.btnPrint2.Size = new System.Drawing.Size(138, 31);
            this.btnPrint2.TabIndex = 5;
            this.btnPrint2.Text = "چاپ قبض المثنی";
            this.btnPrint2.UseVisualStyleBackColor = true;
            this.btnPrint2.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // JKhalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 451);
            this.Controls.Add(this.btnPrint2);
            this.Controls.Add(this.jJanusGrid1);
            this.Name = "JKhalesForm";
            this.Text = "KhalesForm";
            this.Load += new System.EventHandler(this.JKhalesForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JJanusGrid jJanusGrid1;
        private System.Windows.Forms.Button btnPrint2;

    }
}