namespace Globals
{
    partial class JUsersListForm
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
            this.UsersListlistBox = new System.Windows.Forms.ListBox();
            this.SearchUsertextBox = new System.Windows.Forms.TextBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.labelConstSearch = new System.Windows.Forms.Label();
            this.labelConstPersonsList = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UsersListlistBox
            // 
            this.UsersListlistBox.FormattingEnabled = true;
            this.UsersListlistBox.ItemHeight = 19;
            this.UsersListlistBox.Location = new System.Drawing.Point(12, 114);
            this.UsersListlistBox.Name = "UsersListlistBox";
            this.UsersListlistBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.UsersListlistBox.Size = new System.Drawing.Size(503, 251);
            this.UsersListlistBox.TabIndex = 0;
            // 
            // SearchUsertextBox
            // 
            this.SearchUsertextBox.Location = new System.Drawing.Point(12, 47);
            this.SearchUsertextBox.Name = "SearchUsertextBox";
            this.SearchUsertextBox.Size = new System.Drawing.Size(503, 27);
            this.SearchUsertextBox.TabIndex = 1;
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(189, 371);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(152, 45);
            this.OKbutton.TabIndex = 2;
            this.OKbutton.Text = "تایید";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // labelConstSearch
            // 
            this.labelConstSearch.AutoSize = true;
            this.labelConstSearch.Location = new System.Drawing.Point(12, 25);
            this.labelConstSearch.Name = "labelConstSearch";
            this.labelConstSearch.Size = new System.Drawing.Size(121, 19);
            this.labelConstSearch.TabIndex = 3;
            this.labelConstSearch.Text = "جستجوی کاربر :";
            // 
            // labelConstPersonsList
            // 
            this.labelConstPersonsList.AutoSize = true;
            this.labelConstPersonsList.Location = new System.Drawing.Point(12, 92);
            this.labelConstPersonsList.Name = "labelConstPersonsList";
            this.labelConstPersonsList.Size = new System.Drawing.Size(168, 19);
            this.labelConstPersonsList.TabIndex = 4;
            this.labelConstPersonsList.Text = "لیست کابران سیستم :";
            // 
            // JUsersListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 425);
            this.Controls.Add(this.labelConstPersonsList);
            this.Controls.Add(this.labelConstSearch);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.SearchUsertextBox);
            this.Controls.Add(this.UsersListlistBox);
            this.Name = "JUsersListForm";
            this.Text = "لیست کاربران";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UsersListlistBox;
        private System.Windows.Forms.TextBox SearchUsertextBox;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Label labelConstSearch;
        private System.Windows.Forms.Label labelConstPersonsList;
    }
}