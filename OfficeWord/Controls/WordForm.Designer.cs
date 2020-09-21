namespace OfficeWord
{
    partial class JWordForm
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
            this.chkChangeList = new System.Windows.Forms.CheckedListBox();
            this.winWordControl1 = new OfficeWord.WinWordControl();
            this.SuspendLayout();
            // 
            // chkChangeList
            // 
            this.chkChangeList.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkChangeList.FormattingEnabled = true;
            this.chkChangeList.Location = new System.Drawing.Point(0, 0);
            this.chkChangeList.Name = "chkChangeList";
            this.chkChangeList.Size = new System.Drawing.Size(168, 436);
            this.chkChangeList.TabIndex = 1;
            this.chkChangeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chkChangeList_MouseDoubleClick);
            this.chkChangeList.SelectedIndexChanged += new System.EventHandler(this.chkChangeList_SelectedIndexChanged);
            this.chkChangeList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkChangeList_ItemCheck);
            // 
            // winWordControl1
            // 
            this.winWordControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.winWordControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winWordControl1.FileCode = 0;
            this.winWordControl1.Location = new System.Drawing.Point(168, 0);
            this.winWordControl1.Name = "winWordControl1";
            this.winWordControl1.ReadOnly = false;
            this.winWordControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.winWordControl1.Size = new System.Drawing.Size(415, 451);
            this.winWordControl1.TabIndex = 0;
            // 
            // JWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 451);
            this.Controls.Add(this.winWordControl1);
            this.Controls.Add(this.chkChangeList);
            this.Name = "JWordForm";
            this.Text = "WordContractForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JWordForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private OfficeWord.WinWordControl winWordControl1;
        private System.Windows.Forms.CheckedListBox chkChangeList;


    }
}