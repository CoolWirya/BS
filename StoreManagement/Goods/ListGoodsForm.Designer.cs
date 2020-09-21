namespace StoreManagement
{
    partial class JListGoodsForm
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
            this.SuspendLayout();
            // 
            // jJanusGrid1
            // 
            this.jJanusGrid1.ActionMenu = null;
            this.jJanusGrid1.DataSource = null;
            this.jJanusGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jJanusGrid1.Location = new System.Drawing.Point(0, 0);
            this.jJanusGrid1.MultiSelect = false;
            this.jJanusGrid1.Name = "jJanusGrid1";
            this.jJanusGrid1.Size = new System.Drawing.Size(583, 451);
            this.jJanusGrid1.TabIndex = 0;
            this.jJanusGrid1.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.jJanusGrid1_OnRowDBClick);
            // 
            // JListGoodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 451);
            this.Controls.Add(this.jJanusGrid1);
            this.Name = "JListGoodsForm";
            this.Text = "ListGoodsForm";
            this.Load += new System.EventHandler(this.JListGoodsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JJanusGrid jJanusGrid1;
    }
}