using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment
{
    public partial class JEOrganizationChartForm : ClassLibrary.JBaseForm
    {
        /*private JTree tree = new JTree(JTreeTypes.OrganizationUnit, "Employment.JChart");
        public JTreeNode SelectedItem
        {
            get;
            set;
        }*/
        public JEOrganizationChartForm()
        {
            InitializeComponent();
            //tree.ArrangeTree(treeView1);
        }

        private void Set_DataGrid()
        {
            dgrChart.DataSource = (new JECharts()).GetSecretariat();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            JTextInputDialogForm jeTextInputDialogForm = new JTextInputDialogForm("نام چارت", "چارت سازمانی سال ");
            if (jeTextInputDialogForm.ShowDialog() == DialogResult.OK)
            {
                JEChart jeChart = new JEChart();
                jeChart.is_active = false;
                jeChart.Title = jeTextInputDialogForm.Text;
                if (jeChart.Insert())
                    JMessages.Information("با موفقیت درج شد.", "چارت");
                else
                    JMessages.Error("درج با خطا مواجه شد.", "چارت");
            }
            Set_DataGrid();
            /*JESubBaseDefines organs = new JESubBaseDefines(JEBaseDefine.OrganizationUnitCode);
            organs.ShowList();
            JSubBaseDefine organ = organs.SelectedItem;
            JTreeNode newNode = new JTreeNode(tree);
            TreeNode node = new TreeNode();
            if (organ == null)
                return;
            newNode.Name = organ.Name;
            newNode.ObjectCode = organ.Code;
            newNode.State = true;
            node.ImageIndex = newNode.ImageIndex;
            node.Text = newNode.ToString();

            int ParentCode = 0;
            int insertRes;

            if (treeView1.SelectedNode != null)
                ParentCode = ((JTreeNode)treeView1.SelectedNode.Tag).Code;
            insertRes = newNode.Insert(ParentCode);
            if (insertRes > 0)
            {
                if (treeView1.SelectedNode == null)
                    treeView1.Nodes.Add(node);
                else
                    treeView1.SelectedNode.Nodes.Add(node);
                //treeView1.SelectedNode.Nodes.Add(node);
                treeView1.SelectedNode = node;
                newNode.Code = insertRes;
                node.Tag = newNode;
            }

            else if (insertRes == -1)
            {
                JMessages.Message("TheObjectIsAlreadyExistsInTheTree", "Error", JMessageType.Error);
            }
            treeView1.Focus();*/
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            JEChart jeChart = new JEChart(Convert.ToInt32(dgrChart.SelectedRows[0].Cells[0].Value));
            jeChart.Delete(jeChart.Code);
            Set_DataGrid();
            /*if (treeView1.SelectedNode == null)
                return;
            JTreeNode node = (JTreeNode)treeView1.SelectedNode.Tag;
            if (node.Delete(node.Code, false))
                treeView1.SelectedNode.Remove();*/
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            JEChart jeChart = new JEChart(Convert.ToInt32(dgrChart.SelectedRows[0].Cells[0].Value));
            JTextInputDialogForm jeTextInputDialogForm = new JTextInputDialogForm("نام چارت", jeChart.Title);
            if (jeTextInputDialogForm.ShowDialog() == DialogResult.OK)
            {
                jeChart.Title = jeTextInputDialogForm.Text;
                if (jeChart.Update())
                    JMessages.Information("با موفقیت بروز رسانی شد.", "چارت");
                else
                    JMessages.Error("بروزرسانی با خطا مواجه شده است.", "چارت");
            }
            Set_DataGrid();
            /*if (treeView1.SelectedNode != null)
            {
                SelectedItem = (JTreeNode)treeView1.SelectedNode.Tag;
                DialogResult = DialogResult.OK;
            }*/
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JEOrganizationChartForm_Load(object sender, EventArgs e)
        {
            Set_DataGrid();
        }

        private void dgrChart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgrChart.Rows.Count > 0)
            {
                if (MessageBox.Show("آیا از انتخاب این چارت به عنوان چارت فعال مطمئن هستید؟", "چارت فعال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int code = Convert.ToInt32(dgrChart.SelectedRows[0].Cells[0].Value);
                    (new JEChart()).MakeActiveChart(code);
                    Set_DataGrid();
                }
            }
        }
    }
}
