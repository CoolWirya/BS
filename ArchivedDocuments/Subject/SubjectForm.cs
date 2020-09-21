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
    public partial class JSubjectForm : JBaseForm
    {
        public JSubjectForm()
        {
            InitializeComponent();
            jCustomTreeView1.TableName = "ArchivedSubject";
            jCustomTreeView1.NameCode = "Code";
            jCustomTreeView1.NameParent = "ParentCode";
            jCustomTreeView1.NameTitle = "Name";
            jCustomTreeView1.Pattern = "Name,AccessCode";
            jCustomTreeView1.Refresh();
            jCustomTreeView1.TreeView.RightToLeftLayout = this.RightToLeftLayout;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            JSubjectEditForm editForm = new JSubjectEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                jCustomTreeView1.FieldsValue["Name"] = editForm.txtTitle.Text;
                jCustomTreeView1.FieldsValue["State"] = editForm.cmbState.SelectedIndex;
                jCustomTreeView1.FieldsValue["AccessCode"] =Convert.ToInt32(editForm.txtAccessCode.Text);
                jCustomTreeView1.DefaultCode = 0;
                jCustomTreeView1.AutoIncrement = true;
                if (jCustomTreeView1.TreeView.SelectedNode == null)
                    jCustomTreeView1.FieldsValue["ParentCode"] = 0;
                else
                    jCustomTreeView1.FieldsValue["ParentCode"] = ((JCustomTreeNode)jCustomTreeView1.TreeView.SelectedNode.Tag).Code;
                TreeNode treeNode = jCustomTreeView1.Insert();
                if (treeNode != null)
                {
                    jCustomTreeView1.TreeView.SelectedNode = treeNode;
                    jCustomTreeView1.Focus();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (jCustomTreeView1.TreeView.SelectedNode == null)
                return;

            JSubjectEditForm editForm = new JSubjectEditForm();
            editForm.txtTitle.Text = jCustomTreeView1.FieldsValue["Name"].ToString();
            if (jCustomTreeView1.FieldsValue["AccessCode"] != DBNull.Value)
                editForm.txtAccessCode.Text = jCustomTreeView1.FieldsValue["AccessCode"].ToString();
            if (jCustomTreeView1.FieldsValue["State"] != DBNull.Value)
                editForm.cmbState.SelectedIndex = Convert.ToInt32(jCustomTreeView1.FieldsValue["State"]);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                jCustomTreeView1.FieldsValue["Name"] = editForm.txtTitle.Text;
                jCustomTreeView1.FieldsValue["State"] = editForm.cmbState.SelectedIndex;
                if (editForm.txtAccessCode.Text != "")
                    jCustomTreeView1.FieldsValue["AccessCode"] = editForm.txtAccessCode.IntValue;
                TreeNode treeNode = jCustomTreeView1.Update();
                if (treeNode != null)
                {
                    jCustomTreeView1.TreeView.SelectedNode.Text = treeNode.Tag.ToString();
                }
                jCustomTreeView1.Focus();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (jCustomTreeView1.TreeView.SelectedNode == null)
                return;

            jCustomTreeView1.Delete(true);
        }
        /// <summary>
        /// 
        /// </summary>
        public object SelectedItem{ get;set;}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (jCustomTreeView1.TreeView.SelectedNode != null)
            {
                SelectedItem = jCustomTreeView1.TreeView.SelectedNode.Tag;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                JMessages.Message(" لطفا یک موضوع را انتخاب کنید در غیر این صورت دکمه خروج را بزنید","", JMessageType.Information);
        }

        private void JSubjectForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
    }
}
