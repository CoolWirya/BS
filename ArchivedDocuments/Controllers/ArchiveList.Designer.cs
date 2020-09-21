namespace ArchivedDocuments
{
    partial class JArchiveList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JArchiveList));
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnAddImage = new System.Windows.Forms.ToolStripButton();
            this.btnAddFile = new System.Windows.Forms.ToolStripButton();
            this.btnArchive = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnGetWebCam = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControlList = new System.Windows.Forms.TabControl();
            this.tabPageImageList = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grdArchive = new ClassLibrary.JDataGrid();
            this.TabPabgeImagesView = new System.Windows.Forms.TabPage();
            this.panelBigImage = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ThumbLinepanel = new System.Windows.Forms.Panel();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.tsMain.SuspendLayout();
            this.tabControlList.SuspendLayout();
            this.tabPageImageList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArchive)).BeginInit();
            this.TabPabgeImagesView.SuspendLayout();
            this.panelBigImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddImage,
            this.btnAddFile,
            this.btnArchive,
            this.btnDelete,
            this.btnGetWebCam});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tsMain.Size = new System.Drawing.Size(626, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            this.tsMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsMain_ItemClicked);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Image = ((System.Drawing.Image)(resources.GetObject("btnAddImage.Image")));
            this.btnAddImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(98, 22);
            this.btnAddImage.Text = "افزودن تصویر...";
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFile.Image")));
            this.btnAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(88, 22);
            this.btnAddFile.Text = "افزودن فایل...";
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.Image = ((System.Drawing.Image)(resources.GetObject("btnArchive.Image")));
            this.btnArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(126, 22);
            this.btnArchive.Text = "AddFromArchive...";
            this.btnArchive.Visible = false;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(57, 22);
            this.btnDelete.Text = "حذف...";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnGetWebCam
            // 
            this.btnGetWebCam.Image = ((System.Drawing.Image)(resources.GetObject("btnGetWebCam.Image")));
            this.btnGetWebCam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGetWebCam.Name = "btnGetWebCam";
            this.btnGetWebCam.Size = new System.Drawing.Size(58, 22);
            this.btnGetWebCam.Text = "دوربین";
            this.btnGetWebCam.Click += new System.EventHandler(this.btnGetWebCam_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "AllFiles|*.*";
            this.openFileDialog1.Multiselect = true;
            // 
            // tabControlList
            // 
            this.tabControlList.Controls.Add(this.tabPageImageList);
            this.tabControlList.Controls.Add(this.TabPabgeImagesView);
            this.tabControlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlList.Location = new System.Drawing.Point(0, 45);
            this.tabControlList.Name = "tabControlList";
            this.tabControlList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControlList.RightToLeftLayout = true;
            this.tabControlList.SelectedIndex = 0;
            this.tabControlList.Size = new System.Drawing.Size(626, 321);
            this.tabControlList.TabIndex = 5;
            // 
            // tabPageImageList
            // 
            this.tabPageImageList.Controls.Add(this.pictureBox2);
            this.tabPageImageList.Controls.Add(this.splitter1);
            this.tabPageImageList.Controls.Add(this.grdArchive);
            this.tabPageImageList.Location = new System.Drawing.Point(4, 22);
            this.tabPageImageList.Name = "tabPageImageList";
            this.tabPageImageList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImageList.Size = new System.Drawing.Size(618, 295);
            this.tabPageImageList.TabIndex = 0;
            this.tabPageImageList.Text = "لیست";
            this.tabPageImageList.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(318, 289);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(321, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 289);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // grdArchive
            // 
            this.grdArchive.ActionMenu = jPopupMenu1;
            this.grdArchive.AllowUserToAddRows = false;
            this.grdArchive.AllowUserToDeleteRows = false;
            this.grdArchive.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grdArchive.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdArchive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdArchive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdArchive.Dock = System.Windows.Forms.DockStyle.Right;
            this.grdArchive.EnableContexMenu = true;
            this.grdArchive.KeyName = "ArchiveList";
            this.grdArchive.Location = new System.Drawing.Point(331, 3);
            this.grdArchive.MultiSelect = false;
            this.grdArchive.Name = "grdArchive";
            this.grdArchive.ReadHeadersFromDB = false;
            this.grdArchive.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdArchive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdArchive.ShowRowNumber = true;
            this.grdArchive.Size = new System.Drawing.Size(284, 289);
            this.grdArchive.TabIndex = 4;
            this.grdArchive.TableName = null;
            this.grdArchive.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdArchive_RowEnter);
            this.grdArchive.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdArchive_CellDoubleClick);
            this.grdArchive.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdArchive_CellEndEdit);
            this.grdArchive.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grdArchive_CellPainting);
            this.grdArchive.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdArchive_CellClick);
            this.grdArchive.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdArchive_CellEnter);
            // 
            // TabPabgeImagesView
            // 
            this.TabPabgeImagesView.Controls.Add(this.panelBigImage);
            this.TabPabgeImagesView.Controls.Add(this.ThumbLinepanel);
            this.TabPabgeImagesView.Location = new System.Drawing.Point(4, 22);
            this.TabPabgeImagesView.Name = "TabPabgeImagesView";
            this.TabPabgeImagesView.Padding = new System.Windows.Forms.Padding(3);
            this.TabPabgeImagesView.Size = new System.Drawing.Size(618, 295);
            this.TabPabgeImagesView.TabIndex = 1;
            this.TabPabgeImagesView.Text = "پیش نمایش";
            this.TabPabgeImagesView.UseVisualStyleBackColor = true;
            this.TabPabgeImagesView.Enter += new System.EventHandler(this.ImagesView_Enter);
            // 
            // panelBigImage
            // 
            this.panelBigImage.AutoScroll = true;
            this.panelBigImage.Controls.Add(this.pictureBox1);
            this.panelBigImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBigImage.Location = new System.Drawing.Point(3, 3);
            this.panelBigImage.Name = "panelBigImage";
            this.panelBigImage.Size = new System.Drawing.Size(439, 289);
            this.panelBigImage.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(365, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ThumbLinepanel
            // 
            this.ThumbLinepanel.AutoScroll = true;
            this.ThumbLinepanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ThumbLinepanel.Location = new System.Drawing.Point(442, 3);
            this.ThumbLinepanel.Name = "ThumbLinepanel";
            this.ThumbLinepanel.Size = new System.Drawing.Size(173, 289);
            this.ThumbLinepanel.TabIndex = 0;
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(0, 25);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(626, 20);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            this.txtDesc.Leave += new System.EventHandler(this.txtDesc_Leave);
            // 
            // JArchiveList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlList);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.tsMain);
            this.Name = "JArchiveList";
            this.Size = new System.Drawing.Size(626, 366);
            this.Load += new System.EventHandler(this.ImageList_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.JArchiveList_KeyUp);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JArchiveList_KeyPress);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.JArchiveList_ControlRemoved);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.tabControlList.ResumeLayout(false);
            this.tabPageImageList.ResumeLayout(false);
            this.tabPageImageList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArchive)).EndInit();
            this.TabPabgeImagesView.ResumeLayout(false);
            this.panelBigImage.ResumeLayout(false);
            this.panelBigImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnAddFile;
        private System.Windows.Forms.ToolStripButton btnArchive;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnAddImage;
        private ClassLibrary.TextEdit txtDesc;
        private ClassLibrary.JDataGrid grdArchive;
        private System.Windows.Forms.Panel panelBigImage;
        private System.Windows.Forms.Panel ThumbLinepanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TabControl tabControlList;
        public System.Windows.Forms.TabPage tabPageImageList;
        public System.Windows.Forms.TabPage TabPabgeImagesView;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripButton btnGetWebCam;
    }
}
