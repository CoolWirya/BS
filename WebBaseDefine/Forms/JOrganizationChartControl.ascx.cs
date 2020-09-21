using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBaseDefine.Forms
{
    public partial class JOrganizationChartControl : System.Web.UI.UserControl
    {
        int PostCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(WebClassLibrary.JWebManager.GetQueryString("PostCode").ToString(), out PostCode);

            LoadRootNodes();

            //if (PostCode > 0)
            //    tbrActions.FindItemByValue("AddMainNode").Enabled = false;
        }

        private void LoadRootNodes()
        {
            if (IsPostBack) return;
            trvOrg.Nodes.Clear();
            DataTable dt = Employment.JEOrganizationChart.GetUserPostsTree(PostCode);
            if (dt == null) return;
            foreach (DataRow row in dt.Rows)
            {
                Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode();
                node.Text = row["Title"].ToString();
                node.Value = row["Code"].ToString();
                node.ExpandMode = Telerik.Web.UI.TreeNodeExpandMode.WebService;
                trvOrg.Nodes.Add(node);
            }
        }

        protected void tbrActions_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "EditNode":
                    WebClassLibrary.JWebManager.LoadControl("User"
                                    , "~/WebBaseDefine/Forms/JOrganizationChartUpdateControl.ascx"
                                    , "ویرایش پست سازمانی"
                                    , new List<Tuple<string, string>>() { new Tuple<string, string>("UserPostCode", trvOrg.SelectedValue) }
                                    , WebClassLibrary.WindowTarget.NewWindow
                                    , true, false, true, 630, 350);
                    break;
                case "AddSubNode":
                    WebClassLibrary.JWebManager.LoadControl("User"
                                    , "~/WebBaseDefine/Forms/JOrganizationChartUpdateControl.ascx"
                                    , "اقزودن پست سازمانی (زیرمجموعه)"
                                    , new List<Tuple<string, string>>() { new Tuple<string, string>("ParentPostCode", trvOrg.SelectedValue) }
                                    , WebClassLibrary.WindowTarget.NewWindow
                                    , true, false, true, 630, 350);
                    break;
                case "AddMainNode":
                    WebClassLibrary.JWebManager.LoadControl("User"
                                    , "~/WebBaseDefine/Forms/JOrganizationChartUpdateControl.ascx"
                                    , "افزودن پست سازمانی اصلی"
                                    , new List<Tuple<string, string>>() { new Tuple<string, string>("ParentPostCode", PostCode == 0 ? "-1" : PostCode.ToString()) }
                                    , WebClassLibrary.WindowTarget.NewWindow
                                    , true, false, true, 630, 350);
                    break;
                case "DeleteNodeAndMove":
                    if (trvOrg.SelectedNode != null)
                    {
                        Employment.JEOrganizationCharts.MoveChildren(Convert.ToInt32(trvOrg.SelectedNode.Value), new Employment.JEOrganizationChart(Convert.ToInt32(trvOrg.SelectedNode.Value)).parentcode);
                        (new Employment.JEOrganizationChart(Convert.ToInt32(trvOrg.SelectedNode.Value))).DeleteNode();
                        trvOrg.SelectedNode.Remove();
                    }
                    break;
                case "DeleteNodeFully":
                    if (trvOrg.SelectedNode != null)
                    {
                        (new Employment.JEOrganizationChart(Convert.ToInt32(trvOrg.SelectedNode.Value))).DeleteNode();
                        trvOrg.SelectedNode.Remove();
                    }
                    break;
            }
        }

        protected void trvOrg_NodeDrop(object sender, Telerik.Web.UI.RadTreeNodeDragDropEventArgs e)
        {
            if (e.DestDragNode == null || e.SourceDragNode == null) return;
            int sourcePostCode = 0, targetPostCode = 0;
            int.TryParse(e.SourceDragNode.Value, out sourcePostCode);
            int.TryParse(e.DestDragNode.Value, out targetPostCode);

            Employment.JEOrganizationChart orgChart = new Employment.JEOrganizationChart(sourcePostCode);
            orgChart.parentcode = targetPostCode;
            if (orgChart.UpdateNode())
            {
                Telerik.Web.UI.RadTreeNode radTreeNode = new Telerik.Web.UI.RadTreeNode();
                radTreeNode.Text = e.SourceDragNode.Text;
                radTreeNode.Value = e.SourceDragNode.Value;
                radTreeNode.ExpandMode = Telerik.Web.UI.TreeNodeExpandMode.WebService;
                e.SourceDragNode.Remove();
                e.DestDragNode.Nodes.Add(radTreeNode);
            }
        }
    }
}