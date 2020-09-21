namespace Globals
{
    partial class JPermisionClassForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.treeClass = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemNewClass = new System.Windows.Forms.ToolStripMenuItem();
            this.editClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNewDecision = new System.Windows.Forms.ToolStripMenuItem();
            this.editDecisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddDecision = new System.Windows.Forms.Button();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.btnDelClass = new System.Windows.Forms.Button();
            this.btnDelDecision = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Classes:";
            // 
            // treeClass
            // 
            this.treeClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeClass.Location = new System.Drawing.Point(12, 50);
            this.treeClass.Name = "treeClass";
            this.treeClass.Size = new System.Drawing.Size(288, 350);
            this.treeClass.TabIndex = 3;
            this.treeClass.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeClass_NodeMouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemNewClass,
            this.editClassToolStripMenuItem,
            this.itemNewDecision,
            this.editDecisionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 92);
            // 
            // itemNewClass
            // 
            this.itemNewClass.Name = "itemNewClass";
            this.itemNewClass.Size = new System.Drawing.Size(146, 22);
            this.itemNewClass.Text = "NewClass...";
            // 
            // editClassToolStripMenuItem
            // 
            this.editClassToolStripMenuItem.Name = "editClassToolStripMenuItem";
            this.editClassToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.editClassToolStripMenuItem.Text = "EditClass...";
            // 
            // itemNewDecision
            // 
            this.itemNewDecision.Name = "itemNewDecision";
            this.itemNewDecision.Size = new System.Drawing.Size(146, 22);
            this.itemNewDecision.Text = "NewDecision...";
            // 
            // editDecisionToolStripMenuItem
            // 
            this.editDecisionToolStripMenuItem.Name = "editDecisionToolStripMenuItem";
            this.editDecisionToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.editDecisionToolStripMenuItem.Text = "EditDecision...";
            // 
            // btnAddDecision
            // 
            this.btnAddDecision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddDecision.Location = new System.Drawing.Point(208, 449);
            this.btnAddDecision.Name = "btnAddDecision";
            this.btnAddDecision.Size = new System.Drawing.Size(89, 33);
            this.btnAddDecision.TabIndex = 5;
            this.btnAddDecision.Text = "NewDecision";
            this.btnAddDecision.UseVisualStyleBackColor = true;
            this.btnAddDecision.Click += new System.EventHandler(this.btnAddDecision_Click);
            // 
            // btnAddClass
            // 
            this.btnAddClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddClass.Location = new System.Drawing.Point(208, 406);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(89, 37);
            this.btnAddClass.TabIndex = 6;
            this.btnAddClass.Text = "NewClass";
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // btnDelClass
            // 
            this.btnDelClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelClass.Location = new System.Drawing.Point(113, 406);
            this.btnDelClass.Name = "btnDelClass";
            this.btnDelClass.Size = new System.Drawing.Size(89, 37);
            this.btnDelClass.TabIndex = 7;
            this.btnDelClass.Text = "DeleteClass";
            this.btnDelClass.UseVisualStyleBackColor = true;
            this.btnDelClass.Click += new System.EventHandler(this.btnDelClass_Click);
            // 
            // btnDelDecision
            // 
            this.btnDelDecision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelDecision.Location = new System.Drawing.Point(113, 449);
            this.btnDelDecision.Name = "btnDelDecision";
            this.btnDelDecision.Size = new System.Drawing.Size(89, 33);
            this.btnDelDecision.TabIndex = 8;
            this.btnDelDecision.Text = "DeleteDecision";
            this.btnDelDecision.UseVisualStyleBackColor = true;
            this.btnDelDecision.Click += new System.EventHandler(this.btnDelDecision_Click);
            // 
            // JPermisionClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 484);
            this.Controls.Add(this.btnDelDecision);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelClass);
            this.Controls.Add(this.treeClass);
            this.Controls.Add(this.btnAddDecision);
            this.Controls.Add(this.btnAddClass);
            this.Name = "JPermisionClassForm";
            this.Text = "DefineClassesAndDecisions";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeClass;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem itemNewClass;
        private System.Windows.Forms.ToolStripMenuItem itemNewDecision;
        private System.Windows.Forms.Button btnAddDecision;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.Button btnDelClass;
        private System.Windows.Forms.ToolStripMenuItem editClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDecisionToolStripMenuItem;
        private System.Windows.Forms.Button btnDelDecision;

    }
}