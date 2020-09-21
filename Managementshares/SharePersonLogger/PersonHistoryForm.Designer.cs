namespace ManagementShares
{
    partial class JPersonHistoryForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbPCode = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.grdHistory = new ClassLibrary.JJanusGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 475);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 34);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(904, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "اضافه";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(742, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 27);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "دوباره سازی";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(823, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 27);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbPCode);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(996, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lbPCode
            // 
            this.lbPCode.AutoSize = true;
            this.lbPCode.Location = new System.Drawing.Point(12, 30);
            this.lbPCode.Name = "lbPCode";
            this.lbPCode.Size = new System.Drawing.Size(42, 16);
            this.lbPCode.TabIndex = 1;
            this.lbPCode.Text = "label1";
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbName.Location = new System.Drawing.Point(530, 15);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(454, 31);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "نام سهامدار";
            // 
            // grdHistory
            // 
            this.grdHistory.ActionClassName = "";
            this.grdHistory.ActionMenu = null;
            this.grdHistory.DataSource = null;
            this.grdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHistory.Edited = false;
            this.grdHistory.Location = new System.Drawing.Point(0, 53);
            this.grdHistory.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.grdHistory.MultiSelect = false;
            this.grdHistory.Name = "grdHistory";
            this.grdHistory.ShowNavigator = true;
            this.grdHistory.ShowToolbar = true;
            this.grdHistory.Size = new System.Drawing.Size(996, 422);
            this.grdHistory.TabIndex = 5;
            this.grdHistory.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.grdHistory_OnRowDBClick);
            this.grdHistory.GridRowDoubleClick += new System.EventHandler(this.grdHistory_GridRowDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.btnUp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(996, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(53, 509);
            this.panel2.TabIndex = 6;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(5, 229);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(42, 23);
            this.btnDown.TabIndex = 7;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(5, 200);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(42, 23);
            this.btnUp.TabIndex = 7;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // JPersonHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 509);
            this.Controls.Add(this.grdHistory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JPersonHistoryForm";
            this.Text = "سابقه نقل و انتقالات شخص";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbPCode;
        private System.Windows.Forms.Panel panel1;
        private ClassLibrary.JJanusGrid grdHistory;
        private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button button1;
    }
}