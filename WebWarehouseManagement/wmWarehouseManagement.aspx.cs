using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web.Services;

namespace WebWarehouseManagement
{
    public partial class wmWarehouseManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod()]
        public static Telerik.Web.UI.RadTreeNodeData[] LoadGoodsHierarchyNodes(RadTreeNodeData node, object context)
        {
            List<RadTreeNodeData> result = new List<RadTreeNodeData>();
            int parentCode = 0;
            int.TryParse(node.Value, out parentCode);
            if (parentCode == 0) return result.ToArray();
            DataTable dt = WarehouseManagement.Goods.JGoodsHierarchies.GetHierarchy(parentCode);
            if (dt == null) return result.ToArray();
            foreach (DataRow row in dt.Rows)
            {
                Telerik.Web.UI.RadTreeNodeData _node = new Telerik.Web.UI.RadTreeNodeData();
                _node.Text = row["Name"].ToString();
                _node.Value = row["Code"].ToString();
                _node.ExpandMode = Telerik.Web.UI.TreeNodeExpandMode.WebService;
                result.Add(_node);
            }

            return result.ToArray();
        }
    }
}