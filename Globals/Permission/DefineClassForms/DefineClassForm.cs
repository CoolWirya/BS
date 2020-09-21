using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Globals
{
    public partial class JPermisionClassForm : Globals.JBaseForm
    {
        public JPermisionClassForm()
        {
            InitializeComponent();
            _MakeTree();
        }

        private void _MakeTree()
        {
            treeClass.Nodes.Clear();
            JPermissionsDefineClass classList = new JPermissionsDefineClass();
            classList.GetData();
            int i=0;
            foreach (JPermissionDefineClass ds in classList.Items)
            {
                /// افزودن کلاس به درخت
                TreeNode classNode = new TreeNode(ds.ClassName);
                classNode.Tag = ds;
                if (ds.SQL.Trim() != "")
                {
                    classNode.BackColor = Color.Yellow;
                    treeClass.ShowNodeToolTips = true;
                    classNode.ToolTipText = ds.SQL;
                }
                treeClass.Nodes.Add(classNode);
                JPermissionDecisions decisions= new JPermissionDecisions();
                decisions.GetData(ds.Code);
                foreach (JPermissionDecision decision in decisions.Items)
                {
                    TreeNode decisionNode = new TreeNode(decision.Name);
                    decisionNode.Tag = decision;
                    /// افزودن هر کدام از تصمیمات به نود کلاس
                    treeClass.Nodes[i].Nodes.Add(decisionNode);
                }
                i++;
            }
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            JPermissionDefineClass defineClass = new JPermissionDefineClass();
            JPermissionNewClassForm form = new JPermissionNewClassForm(defineClass);
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (defineClass.Insert() > 0)
                {
                    _MakeTree();
                }
            }
        }

        private void btnAddDecision_Click(object sender, EventArgs e)
        {
            if (treeClass.SelectedNode == null)
            {
                ClassLibrary.JMessages.Error("PleaseSelectAnItem", "Error");
                return;
            }
            JPermissionDecision decision = new JPermissionDecision();
            JPermissionDecisionForm decFrom = new JPermissionDecisionForm(decision);
            if (decFrom.DialogResult == DialogResult.OK)
            {
                if (decision.Insert() > 0)
                {
                    _MakeTree();
                }
            }            
        }

        private void btnDelClass_Click(object sender, EventArgs e)
        {
            if (treeClass.SelectedNode == null)
                return;
            if (!(treeClass.SelectedNode.Tag is JPermissionDefineClass))
                return;
            if (((JPermissionDefineClass)treeClass.SelectedNode.Tag).Delete())
                treeClass.SelectedNode.Remove();
                //_MakeTree();
        }

        private void treeClass_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeClass.SelectedNode == null)
                return;
            if (treeClass.SelectedNode.Tag is JPermissionDefineClass)
            {
                JPermissionDefineClass defineClass = (JPermissionDefineClass)treeClass.SelectedNode.Tag;
                JPermissionNewClassForm classFrom = new JPermissionNewClassForm(defineClass);
                if (classFrom.ShowDialog() == DialogResult.OK)
                {
                    if (defineClass.Update())
                        _MakeTree();
                }
            }
            else if (treeClass.SelectedNode.Tag is JPermissionDecision)
            {
                JPermissionDecision decision = (JPermissionDecision)treeClass.SelectedNode.Tag;
                JPermissionDecisionForm decForm = new JPermissionDecisionForm(decision);
                if (decForm.ShowDialog() == DialogResult.OK)
                {
                    if (decision.Update())
                        _MakeTree();
                }
            }
        }

        private void btnDelDecision_Click(object sender, EventArgs e)
        {
            if(!(treeClass.SelectedNode.Tag is JPermissionDecision))
                return;
            if(((JPermissionDecision)treeClass.SelectedNode.Tag).delete())
                treeClass.SelectedNode.Remove();
        }

    }
}
