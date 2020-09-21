using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment
{
    public partial class JEfrmOrganizatinChart : ClassLibrary.JBaseForm
    {
        /// <summary>
        /// انتخاب شده
        /// </summary>
        public DataRow SelectedItem
        {
            get
            {
                if (dtvOrganizatinChart.SelectedItem != null)
                    return (DataRow)(((System.Windows.Forms.TreeNode)dtvOrganizatinChart.SelectedItem).Tag);
                return null;
            }
        }
        /// <summary>
        /// انتخاب شده ها
        /// </summary>
        public DataRow[] SelectedItems
        {
            get
            {
                if (dtvOrganizatinChart.TreeView.Nodes.Count > 0)
                    return dtvOrganizatinChart.SelectedItems(dtvOrganizatinChart.TreeView.Nodes[0]);
                return null;

            }
        }
        /// <summary>
        /// مشخص کننده ی حالت نمایش فرم
        /// </summary>
        public bool ViewMode = false;
        /// <summary>
        /// مشخص کننده ی داشتن چک باکس
        /// </summary>
        public bool CheckBoxMode = false;
        /// <summary>
        /// چارت سازمانی
        /// </summary>
        private DataTable _dtCharts;
        /// <summary>
        /// 
        /// </summary>
        /// 
        public JEfrmOrganizatinChart()
        { }

        int _CompanyCode;

        public JEfrmOrganizatinChart(int pCompanyCode)
        {
            _CompanyCode = pCompanyCode;
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JfrmOrganizatinChart_Load(object sender, EventArgs e)
        {
            JECharts charts = new JECharts();
            _dtCharts = new DataTable();
            _dtCharts.Columns.Add("code");
            _dtCharts.Columns.Add("title");
            _dtCharts.Columns.Add("is_active");

            foreach (var item in charts.Items)
            {
                DataRow dr;
                dr = _dtCharts.NewRow();
                dr["code"] = item.Code;
                dr["title"] = item.Title;
                dr["is_active"] = item.is_active;
                _dtCharts.Rows.InsertAt(dr, _dtCharts.Rows.Count);
            }
            RefreshTree();
        }
        /// <summary>
        /// 
        /// </summary>

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtvOrganizatinChart.SelectedItem == null)
                return;
            JfrmOrganizationChartAddEdit frmOrg = new JfrmOrganizationChartAddEdit(_CompanyCode);
            frmOrg.ParentCode = Convert.ToInt32(((DataRow)(((System.Windows.Forms.TreeNode)(dtvOrganizatinChart.SelectedItem)).Tag))["code"]);
            frmOrg.State = JFormState.Insert;
            if (frmOrg.ShowDialog() == DialogResult.OK)
            {
                // TreeView
                RefreshTree();
                dtvOrganizatinChart.FindAndExpandNode(frmOrg.Code);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtvOrganizatinChart.SelectedItem == null)
                return;
            JfrmOrganizationChartAddEdit frmOrg = new JfrmOrganizationChartAddEdit(_CompanyCode);
            DataRow DR = ((DataRow)(((System.Windows.Forms.TreeNode)(dtvOrganizatinChart.SelectedItem)).Tag));
            //DataColumn dc = DR.Table.Columns[0];
            int code = (int)DR[0];
            JEOrganizationChart jeorg = new JEOrganizationChart((int)DR[0]);
            frmOrg.OrganizationChart = jeorg;
            frmOrg.State = JFormState.Update;
            if (frmOrg.ShowDialog() == DialogResult.OK)
            {
                // TreeView
                RefreshTree();
                dtvOrganizatinChart.FindAndExpandNode(Convert.ToInt32(DR["code"]));
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //JMessages.Information("برای حذف پست سازمانی با مدیر سیستم تماس بگیرید.", "حذف پست سازمانی");
            //return;

            if (dtvOrganizatinChart.SelectedItem == null)
                return;
            JEOrganizationChart orgChart = new JEOrganizationChart();
            orgChart.code = Convert.ToInt32(((DataRow)(((System.Windows.Forms.TreeNode)(dtvOrganizatinChart.SelectedItem)).Tag))["code"]);

            if (orgChart.DeleteNode())
            {
                // TreeView
                RefreshTree();
            }
        }

        private void RefreshTree()
        {
            DataTable dt = new DataTable();
            dt = (new JEOrganizationChart()).GetOrganizationCharts(0);
            if (dt != null)
            {
                dtvOrganizatinChart.dtTree = dt.Copy();
                dtvOrganizatinChart.Title = "full_title";
                dtvOrganizatinChart.Code = "code";
                dtvOrganizatinChart.ParentCode = "parentcode";
                dtvOrganizatinChart.CheckBox = CheckBoxMode;
                dtvOrganizatinChart.CMenu = Menu_TreeNodes;
                dtvOrganizatinChart.Refresh();
            }
            // ContextMenuStrip
            if (dt.Rows.Count == 0)
            {
                Menu_TreeNodes.Items[1].Enabled = false;
                Menu_TreeNodes.Items[2].Enabled = false;
            }
            else
            {
                Menu_TreeNodes.Items[1].Enabled = true;
                Menu_TreeNodes.Items[2].Enabled = true;
            }

        }

        private void dtvOrganizatinChart_SelectedNodWithMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (ViewMode)
            {
                //SelectedItem = (DataRow)(((System.Windows.Forms.TreeNode)dtvOrganizatinChart.SelectedItem).Tag);
                DialogResult = DialogResult.OK;
                //this.Close();
            }
        }

        private void Menu_TreeNodes_Opening(object sender, CancelEventArgs e)
        {

        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           (new Employment.Defined.OrganizationChart.JEfrmOrganizationChartMove( Convert.ToInt32(((DataRow)(((System.Windows.Forms.TreeNode)(dtvOrganizatinChart.SelectedItem)).Tag))["code"]))).ShowDialog();
           RefreshTree();
        }




    }
}
