namespace ManagementShares
{
    partial class JSheetHistoryForm
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
            this.grdHistory = new ClassLibrary.JJanusGrid();
            this.SuspendLayout();
            // 
            // grdHistory
            // 
            this.grdHistory.ActionMenu = null;
            this.grdHistory.DataSource = null;
            this.grdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHistory.Edited = false;
            this.grdHistory.Location = new System.Drawing.Point(0, 0);
            this.grdHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdHistory.MultiSelect = true;
            this.grdHistory.Name = "grdHistory";
            this.grdHistory.ShowNavigator = true;
            this.grdHistory.ShowToolbar = true;
            this.grdHistory.Size = new System.Drawing.Size(809, 385);
            this.grdHistory.TabIndex = 0;
            // 
            // JSheetHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 385);
            this.Controls.Add(this.grdHistory);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JSheetHistoryForm";
            this.Text = "سابقه برگه سهم";
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JJanusGrid grdHistory;
    }
}