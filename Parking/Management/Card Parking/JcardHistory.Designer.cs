namespace Parking
{
    partial class JcardHistory
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdContractsGoodwill = new ClassLibrary.JJanusGrid();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdContractsGoodwill);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(979, 705);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات";
            // 
            // grdContractsGoodwill
            // 
            this.grdContractsGoodwill.ActionMenu = null;
            this.grdContractsGoodwill.DataSource = null;
            this.grdContractsGoodwill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContractsGoodwill.Location = new System.Drawing.Point(3, 19);
            this.grdContractsGoodwill.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdContractsGoodwill.MultiSelect = false;
            this.grdContractsGoodwill.Name = "grdContractsGoodwill";
            this.grdContractsGoodwill.ShowNavigator = true;
            this.grdContractsGoodwill.ShowToolbar = true;
            this.grdContractsGoodwill.Size = new System.Drawing.Size(973, 683);
            this.grdContractsGoodwill.TabIndex = 1;
            // 
            // JcardHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 705);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JcardHistory";
            this.Text = "سوابق ورود و خروج";
            this.Load += new System.EventHandler(this.JcardHistory_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JJanusGrid grdContractsGoodwill;
    }
}