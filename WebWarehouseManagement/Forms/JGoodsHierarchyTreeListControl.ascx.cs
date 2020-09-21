using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebWarehouseManagement.Forms
{
    public partial class JGoodsHierarchyTreeListControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadRootNodes();
        }

        private void LoadRootNodes()
        {
            if (IsPostBack) return;
            DataTable dt = WarehouseManagement.Goods.JGoodsHierarchies.GetHierarchy(0);
            foreach (DataRow row in dt.Rows)
            {
                Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode();
                node.Text = row["Name"].ToString();
                node.Value = row["Code"].ToString();
                node.ExpandMode = Telerik.Web.UI.TreeNodeExpandMode.WebService;
                trvHirearchy.Nodes.Add(node);
            }

        }

        protected void tbrActions_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "EditNode":
                    WebClassLibrary.JWebManager.LoadControl("GoodHierarchy"
                                    , "~/WebWarehouseManagement/Forms/JGoodsHierarchyUpdateControl.ascx"
                                    , "ویرایش دسته بندی"
                                    , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", trvHirearchy.SelectedValue) }
                                    , WebClassLibrary.WindowTarget.NewWindow
                                    , true, false, true, 630, 200);
                    break;
                case "AddSubNode":
                    WebClassLibrary.JWebManager.LoadControl("GoodHierarchy"
                                    , "~/WebWarehouseManagement/Forms/JGoodsHierarchyUpdateControl.ascx"
                                    , "اقزودن دسته بندی (زیرمجموعه)"
                                    , new List<Tuple<string, string>>() { new Tuple<string, string>("ParentCode", trvHirearchy.SelectedValue) }
                                    , WebClassLibrary.WindowTarget.NewWindow
                                    , true, false, true, 630, 200);
                    break;
                case "AddMainNode":
                    WebClassLibrary.JWebManager.LoadControl("User"
                                    , "~/WebWarehouseManagement/Forms/JGoodsHierarchyUpdateControl.ascx"
                                    , "افزودن دسته بندی اصلی"
                                    , new List<Tuple<string, string>>() { new Tuple<string, string>("ParentCode", "-1") }
                                    , WebClassLibrary.WindowTarget.NewWindow
                                    , true, false, true, 630, 200);
                    break;
                case "DeleteNodeAndMove":
                    if (trvHirearchy.SelectedNode != null)
                    {
                        WarehouseManagement.Goods.JGoodsHierarchies.MoveChildren(Convert.ToInt32(trvHirearchy.SelectedNode.Value), new WarehouseManagement.Goods.JGoodsHierarchy(Convert.ToInt32(trvHirearchy.SelectedNode.Value)).ParentCode);
                        WarehouseManagement.Goods.JGoodsHierarchies.DeleteNode(Convert.ToInt32(trvHirearchy.SelectedNode.Value));
                        trvHirearchy.SelectedNode.Remove();
                    }
                    break;
                case "DeleteNodeFully":
                    if (trvHirearchy.SelectedNode != null)
                    {
                        WarehouseManagement.Goods.JGoodsHierarchies.DeleteNode(Convert.ToInt32(trvHirearchy.SelectedNode.Value));
                        trvHirearchy.SelectedNode.Remove();
                    }
                    break;
            }
        }

        protected void trvHirearchy_NodeDrop(object sender, Telerik.Web.UI.RadTreeNodeDragDropEventArgs e)
        {
            if (e.DestDragNode == null || e.SourceDragNode == null) return;
            int sourcePostCode = 0, targetPostCode = 0;
            int.TryParse(e.SourceDragNode.Value, out sourcePostCode);
            int.TryParse(e.DestDragNode.Value, out targetPostCode);

            WarehouseManagement.Goods.JGoodsHierarchy goodsHierarchy = new WarehouseManagement.Goods.JGoodsHierarchy();
            goodsHierarchy.GetData(sourcePostCode);
            goodsHierarchy.ParentCode = targetPostCode;
            if (goodsHierarchy.Update())
            {
                Telerik.Web.UI.RadTreeNode radTreeNode = new Telerik.Web.UI.RadTreeNode();
                radTreeNode.Text = e.SourceDragNode.Text;
                radTreeNode.Value = e.SourceDragNode.Value;
                radTreeNode.ExpandMode = Telerik.Web.UI.TreeNodeExpandMode.WebService;
                e.SourceDragNode.Remove();
                if (e.DestDragNode.Expanded == true)
                    e.DestDragNode.Nodes.Add(radTreeNode);
            }
        }
    }
}