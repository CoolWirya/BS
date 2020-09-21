namespace Automation
{
    partial class JCentral
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JCentral));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LbPost = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbObjectType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnrefer = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.juC_ReferHistory1 = new Automation.JUC_ReferHistory();
            this.dgCentral = new ClassLibrary.UC_Grid();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.uiPanel0 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel0Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.jDataTreeView1 = new ClassLibrary.JDataTreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIDefineKartabl = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIEditKartabl = new System.Windows.Forms.ToolStripMenuItem();
            this.TsbDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).BeginInit();
            this.uiPanel0.SuspendLayout();
            this.uiPanel0Container.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "aktion.png");
            this.imageList.Images.SetKeyName(1, "alert.png");
            this.imageList.Images.SetKeyName(2, "All software is current.png");
            this.imageList.Images.SetKeyName(3, "amor.png");
            this.imageList.Images.SetKeyName(4, "antivirus.png");
            this.imageList.Images.SetKeyName(5, "applixware.png");
            this.imageList.Images.SetKeyName(6, "ark.png");
            this.imageList.Images.SetKeyName(7, "arts.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.LbPost);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbObjectType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 92);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(496, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(222, 23);
            this.textBox1.TabIndex = 5;
            // 
            // LbPost
            // 
            this.LbPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LbPost.FormattingEnabled = true;
            this.LbPost.ItemHeight = 16;
            this.LbPost.Location = new System.Drawing.Point(12, 5);
            this.LbPost.Name = "LbPost";
            this.LbPost.Size = new System.Drawing.Size(314, 84);
            this.LbPost.TabIndex = 4;
            this.LbPost.SelectedIndexChanged += new System.EventHandler(this.LbPost_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "پست سازمانی :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(721, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "نام فرآیند :";
            // 
            // cmbObjectType
            // 
            this.cmbObjectType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbObjectType.FormattingEnabled = true;
            this.cmbObjectType.Location = new System.Drawing.Point(496, 55);
            this.cmbObjectType.Name = "cmbObjectType";
            this.cmbObjectType.Size = new System.Drawing.Size(220, 24);
            this.cmbObjectType.TabIndex = 1;
            this.cmbObjectType.SelectedIndexChanged += new System.EventHandler(this.cmbObjectType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(724, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام کاربر :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnTransfer);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnrefer);
            this.panel2.Controls.Add(this.btnView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 572);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(788, 43);
            this.panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Automation.Properties.Resources.file_del25;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(414, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Image = global::Automation.Properties.Resources.Back1;
            this.btnTransfer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransfer.Location = new System.Drawing.Point(507, 5);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(87, 32);
            this.btnTransfer.TabIndex = 3;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::Automation.Properties.Resources.round_exit___gel27;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(321, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 32);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnrefer
            // 
            this.btnrefer.Image = global::Automation.Properties.Resources.back28;
            this.btnrefer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefer.Location = new System.Drawing.Point(600, 5);
            this.btnrefer.Name = "btnrefer";
            this.btnrefer.Size = new System.Drawing.Size(87, 32);
            this.btnrefer.TabIndex = 1;
            this.btnrefer.Text = "Refer";
            this.btnrefer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefer.UseVisualStyleBackColor = true;
            this.btnrefer.Click += new System.EventHandler(this.btnrefer_Click);
            // 
            // btnView
            // 
            this.btnView.Image = global::Automation.Properties.Resources.view_save11;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(693, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(87, 32);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.juC_ReferHistory1);
            this.panel3.Controls.Add(this.dgCentral);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(260, 95);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 474);
            this.panel3.TabIndex = 2;
            // 
            // juC_ReferHistory1
            // 
            this.juC_ReferHistory1.Location = new System.Drawing.Point(0, 155);
            this.juC_ReferHistory1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.juC_ReferHistory1.Name = "juC_ReferHistory1";
            this.juC_ReferHistory1.Size = new System.Drawing.Size(237, 319);
            this.juC_ReferHistory1.TabIndex = 1;
            // 
            // dgCentral
            // 
            this.dgCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCentral.Location = new System.Drawing.Point(0, 0);
            this.dgCentral.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgCentral.MultiSelect = false;
            this.dgCentral.Name = "dgCentral";
            this.dgCentral.Size = new System.Drawing.Size(525, 474);
            this.dgCentral.TabIndex = 0;
            this.dgCentral.GridRowDoubleClick += new System.EventHandler(this.dgCentral_GridRowDoubleClick);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanel0.Id = new System.Guid("d120590b-cec7-491e-aa7b-f8d6126ca194");
            this.uiPanelManager1.Panels.Add(this.uiPanel0);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("d120590b-cec7-491e-aa7b-f8d6126ca194"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(257, 474), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("d120590b-cec7-491e-aa7b-f8d6126ca194"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // uiPanel0
            // 
            this.uiPanel0.AllowPanelDrag = Janus.Windows.UI.InheritableBoolean.True;
            this.uiPanel0.AllowPanelDrop = Janus.Windows.UI.InheritableBoolean.True;
            this.uiPanel0.AllowResize = Janus.Windows.UI.InheritableBoolean.True;
            this.uiPanel0.ImeMode = System.Windows.Forms.ImeMode.On;
            this.uiPanel0.InfoTextFormatStyle.BackColor = System.Drawing.Color.White;
            this.uiPanel0.InfoTextFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.uiPanel0.InfoTextFormatStyle.ForeColor = System.Drawing.Color.White;
            this.uiPanel0.InnerContainer = this.uiPanel0Container;
            this.uiPanel0.Location = new System.Drawing.Point(3, 95);
            this.uiPanel0.Name = "uiPanel0";
            this.uiPanel0.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.uiPanel0.Size = new System.Drawing.Size(257, 474);
            this.uiPanel0.TabIndex = 4;
            this.uiPanel0.Text = "                      کارتابل ها";
            // 
            // uiPanel0Container
            // 
            this.uiPanel0Container.Controls.Add(this.jDataTreeView1);
            this.uiPanel0Container.Location = new System.Drawing.Point(1, 23);
            this.uiPanel0Container.Name = "uiPanel0Container";
            this.uiPanel0Container.Size = new System.Drawing.Size(251, 450);
            this.uiPanel0Container.TabIndex = 0;
            // 
            // jDataTreeView1
            // 
            this.jDataTreeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.jDataTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jDataTreeView1.Location = new System.Drawing.Point(0, 0);
            this.jDataTreeView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jDataTreeView1.Name = "jDataTreeView1";
            this.jDataTreeView1.Size = new System.Drawing.Size(251, 450);
            this.jDataTreeView1.TabIndex = 0;
            this.jDataTreeView1.Click += new System.EventHandler(this.jDataTreeView1_Click);
            this.jDataTreeView1.SelectedItemChange += new System.Windows.Forms.TreeViewEventHandler(this.jDataTreeView1_SelectedItemChange);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIDefineKartabl,
            this.TSMIEditKartabl,
            this.TsbDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 70);
            // 
            // TSMIDefineKartabl
            // 
            this.TSMIDefineKartabl.Name = "TSMIDefineKartabl";
            this.TSMIDefineKartabl.Size = new System.Drawing.Size(143, 22);
            this.TSMIDefineKartabl.Text = "تعریف کارتابل";
            this.TSMIDefineKartabl.Click += new System.EventHandler(this.TSMIDefineKartabl_Click);
            // 
            // TSMIEditKartabl
            // 
            this.TSMIEditKartabl.Name = "TSMIEditKartabl";
            this.TSMIEditKartabl.Size = new System.Drawing.Size(143, 22);
            this.TSMIEditKartabl.Text = "ویرایش کارتابل";
            this.TSMIEditKartabl.Click += new System.EventHandler(this.TSMIEditKartabl_Click);
            // 
            // TsbDelete
            // 
            this.TsbDelete.Name = "TsbDelete";
            this.TsbDelete.Size = new System.Drawing.Size(143, 22);
            this.TsbDelete.Text = "حذف کارتابل";
            this.TsbDelete.Click += new System.EventHandler(this.TsbDelete_Click);
            // 
            // JCentral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 615);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.uiPanel0);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JCentral";
            this.Text = "frmCentral";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCentral_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).EndInit();
            this.uiPanel0.ResumeLayout(false);
            this.uiPanel0Container.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbObjectType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox LbPost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnrefer;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.TextBox textBox1;
        public ClassLibrary.UC_Grid dgCentral;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel uiPanel0;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel0Container;
        private System.Windows.Forms.Button btnCancel;
        private ClassLibrary.JDataTreeView jDataTreeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMIDefineKartabl;
        private System.Windows.Forms.ToolStripMenuItem TSMIEditKartabl;
        private System.Windows.Forms.ToolStripMenuItem TsbDelete;
        private JUC_ReferHistory juC_ReferHistory1;
    }
}