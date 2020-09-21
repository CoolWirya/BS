namespace Globals
{
    partial class JPermissionLoadDLLForm
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
            this.treeFunctions = new System.Windows.Forms.TreeView();
            this.treeClass = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtFunctionName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeFunctions
            // 
            this.treeFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeFunctions.HideSelection = false;
            this.treeFunctions.Location = new System.Drawing.Point(352, 7);
            this.treeFunctions.Name = "treeFunctions";
            this.treeFunctions.RightToLeftLayout = true;
            this.treeFunctions.Size = new System.Drawing.Size(271, 461);
            this.treeFunctions.TabIndex = 1;
            this.treeFunctions.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFunctions_NodeMouseClick);
            // 
            // treeClass
            // 
            this.treeClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeClass.HideSelection = false;
            this.treeClass.Location = new System.Drawing.Point(12, 7);
            this.treeClass.Name = "treeClass";
            this.treeClass.RightToLeftLayout = true;
            this.treeClass.Size = new System.Drawing.Size(295, 290);
            this.treeClass.TabIndex = 3;
            this.treeClass.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeClass_NodeMouseDoubleClick);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 365);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(293, 78);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(12, 300);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 34);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtFunctionName
            // 
            this.txtFunctionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFunctionName.BackColor = System.Drawing.SystemColors.Window;
            this.txtFunctionName.Location = new System.Drawing.Point(12, 336);
            this.txtFunctionName.Name = "txtFunctionName";
            this.txtFunctionName.ReadOnly = true;
            this.txtFunctionName.Size = new System.Drawing.Size(293, 23);
            this.txtFunctionName.TabIndex = 6;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(12, 449);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 26);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "-";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // JPermissionLoadDLLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 480);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtFunctionName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.treeClass);
            this.Controls.Add(this.treeFunctions);
            this.Name = "JPermissionLoadDLLForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "LoadDLLForm";
            this.Load += new System.EventHandler(this.JPermissionLoadDLLForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeFunctions;
        private System.Windows.Forms.TreeView treeClass;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtFunctionName;
        private System.Windows.Forms.Button btnDelete;
    }
}