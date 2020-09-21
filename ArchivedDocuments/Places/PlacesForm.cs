using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ArchivedDocuments
{
    public partial class JPlacesForm : JBaseForm
    {
        public JPlacesForm()
        {
            InitializeComponent();
            jCustomTreeView1.TableName = "ArchivePlaces";
            jCustomTreeView1.NameCode = "Code";
            jCustomTreeView1.NameParent = "ParentCode";
            jCustomTreeView1.NameTitle = "Name";
            jCustomTreeView1.Pattern = "Name,Code";
            jCustomTreeView1.Refresh();
            jCustomTreeView1.TreeView.RightToLeftLayout = this.RightToLeftLayout;
        }
        /// <summary>
        /// 
        /// </summary>
        public object SelectedItem { get; set; }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            JPlacesEditForm editForm = new JPlacesEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                jCustomTreeView1.FieldsValue["Name"] = editForm.txtTitle.Text;
                jCustomTreeView1.FieldsValue["State"] = editForm.cmbState.SelectedIndex;
                jCustomTreeView1.DefaultCode = 0;
                jCustomTreeView1.AutoIncrement = true;
                if (jCustomTreeView1.TreeView.SelectedNode == null)
                    jCustomTreeView1.FieldsValue["ParentCode"] = 0;
                else
                    jCustomTreeView1.FieldsValue["ParentCode"] = ((JCustomTreeNode)jCustomTreeView1.TreeView.SelectedNode.Tag).Code;
                TreeNode treeNode = jCustomTreeView1.Insert();
                if (treeNode!=null)
                {
                    jCustomTreeView1.TreeView.SelectedNode = treeNode;
                    jCustomTreeView1.Focus();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (jCustomTreeView1.TreeView.SelectedNode == null)
                return;
            
            jCustomTreeView1.Delete(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (jCustomTreeView1.TreeView.SelectedNode == null)
                return;
            
            JPlacesEditForm editForm = new JPlacesEditForm();
            editForm.txtTitle.Text = jCustomTreeView1.FieldsValue["Name"].ToString();
            editForm.cmbState.SelectedIndex = Convert.ToInt32(jCustomTreeView1.FieldsValue["State"]);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                jCustomTreeView1.FieldsValue["Name"] = editForm.txtTitle.Text;
                jCustomTreeView1.FieldsValue["State"] = editForm.cmbState.SelectedIndex;
                TreeNode treeNode = jCustomTreeView1.Update();
                if (treeNode != null)
                {
                    jCustomTreeView1.TreeView.SelectedNode.Text = treeNode.Tag.ToString();
                }
                jCustomTreeView1.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (jCustomTreeView1.TreeView.SelectedNode != null)
            {
                SelectedItem = jCustomTreeView1.TreeView.SelectedNode.Tag;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}

