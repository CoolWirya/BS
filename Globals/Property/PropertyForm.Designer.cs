namespace Globals.Property
{
    partial class JPropertyForm
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
			this.txbTitle = new System.Windows.Forms.TextBox();
			this.txbDataType = new System.Windows.Forms.ComboBox();
			this.txbListType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.lbListValue = new System.Windows.Forms.Label();
			this.txbOrder = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.clbPostEditList = new System.Windows.Forms.CheckedListBox();
			this.clbPostViewList = new System.Windows.Forms.CheckedListBox();
			this.chkAllEdit = new System.Windows.Forms.CheckBox();
			this.chkAllView = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txbListValue = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txbTitle
			// 
			this.txbTitle.Location = new System.Drawing.Point(12, 34);
			this.txbTitle.Name = "txbTitle";
			this.txbTitle.Size = new System.Drawing.Size(275, 23);
			this.txbTitle.TabIndex = 0;
			// 
			// txbDataType
			// 
			this.txbDataType.FormattingEnabled = true;
			this.txbDataType.Location = new System.Drawing.Point(199, 79);
			this.txbDataType.Name = "txbDataType";
			this.txbDataType.Size = new System.Drawing.Size(88, 24);
			this.txbDataType.TabIndex = 1;
			this.txbDataType.SelectedIndexChanged += new System.EventHandler(this.txbDataType_SelectedIndexChanged);
			// 
			// txbListType
			// 
			this.txbListType.FormattingEnabled = true;
			this.txbListType.Location = new System.Drawing.Point(76, 79);
			this.txbListType.Name = "txbListType";
			this.txbListType.Size = new System.Drawing.Size(117, 24);
			this.txbListType.TabIndex = 2;
			this.txbListType.SelectedIndexChanged += new System.EventHandler(this.txbListType_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(254, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Title";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(225, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "DataType";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(141, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "ListType";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(32, 60);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Order";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSave.Location = new System.Drawing.Point(12, 375);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(78, 23);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.button2_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(495, 375);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lbListValue
			// 
			this.lbListValue.AutoSize = true;
			this.lbListValue.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbListValue.Location = new System.Drawing.Point(0, 0);
			this.lbListValue.Name = "lbListValue";
			this.lbListValue.Size = new System.Drawing.Size(59, 16);
			this.lbListValue.TabIndex = 3;
			this.lbListValue.Text = "ListValue";
			this.lbListValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txbOrder
			// 
			this.txbOrder.Location = new System.Drawing.Point(12, 80);
			this.txbOrder.Name = "txbOrder";
			this.txbOrder.Size = new System.Drawing.Size(58, 23);
			this.txbOrder.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.clbPostEditList);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.clbPostViewList);
			this.groupBox1.Controls.Add(this.chkAllEdit);
			this.groupBox1.Controls.Add(this.txbTitle);
			this.groupBox1.Controls.Add(this.chkAllView);
			this.groupBox1.Controls.Add(this.txbOrder);
			this.groupBox1.Controls.Add(this.txbDataType);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txbListType);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
			this.groupBox1.Location = new System.Drawing.Point(286, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(296, 369);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// clbPostEditList
			// 
			this.clbPostEditList.Enabled = false;
			this.clbPostEditList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.clbPostEditList.FormattingEnabled = true;
			this.clbPostEditList.Location = new System.Drawing.Point(12, 140);
			this.clbPostEditList.Name = "clbPostEditList";
			this.clbPostEditList.Size = new System.Drawing.Size(133, 212);
			this.clbPostEditList.TabIndex = 7;
			// 
			// clbPostViewList
			// 
			this.clbPostViewList.Enabled = false;
			this.clbPostViewList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.clbPostViewList.FormattingEnabled = true;
			this.clbPostViewList.Location = new System.Drawing.Point(151, 140);
			this.clbPostViewList.Name = "clbPostViewList";
			this.clbPostViewList.Size = new System.Drawing.Size(133, 212);
			this.clbPostViewList.TabIndex = 7;
			// 
			// chkAllEdit
			// 
			this.chkAllEdit.AutoSize = true;
			this.chkAllEdit.Checked = true;
			this.chkAllEdit.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAllEdit.Location = new System.Drawing.Point(25, 114);
			this.chkAllEdit.Name = "chkAllEdit";
			this.chkAllEdit.Size = new System.Drawing.Size(120, 20);
			this.chkAllEdit.TabIndex = 6;
			this.chkAllEdit.Text = "ویرایش برای همه";
			this.chkAllEdit.UseVisualStyleBackColor = true;
			this.chkAllEdit.CheckedChanged += new System.EventHandler(this.chkAllEdit_CheckedChanged);
			// 
			// chkAllView
			// 
			this.chkAllView.AutoSize = true;
			this.chkAllView.Checked = true;
			this.chkAllView.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAllView.Location = new System.Drawing.Point(151, 114);
			this.chkAllView.Name = "chkAllView";
			this.chkAllView.Size = new System.Drawing.Size(133, 20);
			this.chkAllView.TabIndex = 6;
			this.chkAllView.Text = "مشاهده برای  همه";
			this.chkAllView.UseVisualStyleBackColor = true;
			this.chkAllView.CheckedChanged += new System.EventHandler(this.chkAllView_CheckedChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txbListValue);
			this.panel1.Controls.Add(this.lbListValue);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(582, 369);
			this.panel1.TabIndex = 6;
			// 
			// txbListValue
			// 
			this.txbListValue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txbListValue.Location = new System.Drawing.Point(0, 16);
			this.txbListValue.Multiline = true;
			this.txbListValue.Name = "txbListValue";
			this.txbListValue.Size = new System.Drawing.Size(286, 353);
			this.txbListValue.TabIndex = 0;
			// 
			// JPropertyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(582, 404);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnSave);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "JPropertyForm";
			this.Text = "PropertyForm";
			this.Load += new System.EventHandler(this.PropertyForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txbTitle;
        private System.Windows.Forms.ComboBox txbDataType;
        private System.Windows.Forms.ComboBox txbListType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbListValue;
        private System.Windows.Forms.TextBox txbOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbListValue;
        private System.Windows.Forms.CheckedListBox clbPostEditList;
        private System.Windows.Forms.CheckedListBox clbPostViewList;
        private System.Windows.Forms.CheckBox chkAllEdit;
        private System.Windows.Forms.CheckBox chkAllView;
    }
}