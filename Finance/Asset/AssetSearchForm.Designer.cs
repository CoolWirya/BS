namespace Finance
{
    partial class JAssetSearchForm
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
			this.cmbAssetType = new System.Windows.Forms.ComboBox();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.btnAdvanceSearch = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnSearch = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.jdgvAsset = new ClassLibrary.JJanusGrid();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbAssetType
			// 
			this.cmbAssetType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbAssetType.FormattingEnabled = true;
			this.cmbAssetType.Location = new System.Drawing.Point(448, 28);
			this.cmbAssetType.Name = "cmbAssetType";
			this.cmbAssetType.Size = new System.Drawing.Size(198, 24);
			this.cmbAssetType.TabIndex = 0;
			this.cmbAssetType.SelectedIndexChanged += new System.EventHandler(this.cmbAssetType_SelectedIndexChanged);
			// 
			// txtComment
			// 
			this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtComment.Location = new System.Drawing.Point(178, 28);
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(251, 23);
			this.txtComment.TabIndex = 1;
			// 
			// btnAdvanceSearch
			// 
			this.btnAdvanceSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdvanceSearch.Location = new System.Drawing.Point(448, 58);
			this.btnAdvanceSearch.Name = "btnAdvanceSearch";
			this.btnAdvanceSearch.Size = new System.Drawing.Size(198, 23);
			this.btnAdvanceSearch.TabIndex = 2;
			this.btnAdvanceSearch.Text = "جستجو پیشرفته...";
			this.btnAdvanceSearch.UseVisualStyleBackColor = true;
			this.btnAdvanceSearch.Click += new System.EventHandler(this.btnAdvanceSearch_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(580, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "نوع دارائی:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(326, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "جستجو در عنوان:";
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.Location = new System.Drawing.Point(94, 26);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 25);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "جستجو";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnSearch);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cmbAssetType);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtComment);
			this.groupBox1.Controls.Add(this.btnAdvanceSearch);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(662, 87);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnOK);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox2.Location = new System.Drawing.Point(0, 406);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(662, 45);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(570, 14);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// jdgvAsset
			// 
			this.jdgvAsset.ActionClassName = "";
			this.jdgvAsset.ActionMenu = null;
			this.jdgvAsset.DataSource = null;
			this.jdgvAsset.Dock = System.Windows.Forms.DockStyle.Fill;
			this.jdgvAsset.Edited = false;
			this.jdgvAsset.Location = new System.Drawing.Point(0, 87);
			this.jdgvAsset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.jdgvAsset.MultiSelect = true;
			this.jdgvAsset.Name = "jdgvAsset";
			this.jdgvAsset.ShowNavigator = true;
			this.jdgvAsset.ShowToolbar = true;
			this.jdgvAsset.Size = new System.Drawing.Size(662, 319);
			this.jdgvAsset.TabIndex = 9;
			// 
			// JAssetSearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(662, 451);
			this.Controls.Add(this.jdgvAsset);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "JAssetSearchForm";
			this.Text = "AssetSearch";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAssetType;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnAdvanceSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOK;
        private ClassLibrary.JJanusGrid jdgvAsset;
    }
}