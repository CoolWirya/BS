namespace Automation
{
    partial class JUC_ReferHistory
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.jDataTreeView1 = new ClassLibrary.JDataTreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtbDesc = new System.Windows.Forms.RichTextBox();
            this.jArchiveList1 = new ArchivedDocuments.JArchiveList();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 402F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(631, 402);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.jDataTreeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(343, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 402);
            this.panel1.TabIndex = 2;
            // 
            // jDataTreeView1
            // 
            this.jDataTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jDataTreeView1.Location = new System.Drawing.Point(0, 0);
            this.jDataTreeView1.Name = "jDataTreeView1";
            this.jDataTreeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.jDataTreeView1.Size = new System.Drawing.Size(288, 402);
            this.jDataTreeView1.TabIndex = 0;
            this.jDataTreeView1.SelectedItemChange += new System.Windows.Forms.TreeViewEventHandler(this.jDataTreeView1_SelectedItemChange);
            this.jDataTreeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.jDataTreeView1_MouseClick);
            this.jDataTreeView1.SelectedNodWithMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.jDataTreeView1_SelectedNodWithMouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 402);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtbDesc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.jArchiveList1);
            this.splitContainer1.Size = new System.Drawing.Size(333, 402);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 4;
            // 
            // rtbDesc
            // 
            this.rtbDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDesc.Font = new System.Drawing.Font("B Mitra", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rtbDesc.ForeColor = System.Drawing.Color.Red;
            this.rtbDesc.Location = new System.Drawing.Point(0, 0);
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.ReadOnly = true;
            this.rtbDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rtbDesc.Size = new System.Drawing.Size(333, 202);
            this.rtbDesc.TabIndex = 3;
            this.rtbDesc.Text = "";
            // 
            // jArchiveList1
            // 
            this.jArchiveList1.AllowUserAddFile = false;
            this.jArchiveList1.AllowUserAddFromArchive = false;
            this.jArchiveList1.AllowUserAddImage = false;
            this.jArchiveList1.AllowUserDeleteFile = false;
            this.jArchiveList1.ClassName = "";
            this.jArchiveList1.ClassNames = null;
            this.jArchiveList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveList1.EnabledChange = false;
            this.jArchiveList1.Location = new System.Drawing.Point(0, 0);
            this.jArchiveList1.Name = "jArchiveList1";
            this.jArchiveList1.ObjectCode = 0;
            this.jArchiveList1.ObjectCodes = null;
            this.jArchiveList1.PlaceCode = 0;
            this.jArchiveList1.Size = new System.Drawing.Size(333, 196);
            this.jArchiveList1.SubjectCode = 0;
            this.jArchiveList1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(333, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 402);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // JUC_ReferHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "JUC_ReferHistory";
            this.Size = new System.Drawing.Size(631, 402);
            this.Load += new System.EventHandler(this.ReferHistory_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JDataTreeView jDataTreeView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ArchivedDocuments.JArchiveList jArchiveList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtbDesc;

    }
}
