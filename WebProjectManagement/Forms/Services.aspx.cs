using System;
using System.Collections.Generic;
using System.Data;
using ProjectManagement;
using Telerik.Web.UI;

namespace WebProjectManagement.Forms
{
    public partial class Services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static Telerik.Web.UI.RadTreeNodeData[] LoadTemplateNodes(RadTreeNodeData node, object context)
        {
            List<RadTreeNodeData> result = new List<RadTreeNodeData>();
            int templateCode = 0, parentCode = 0;
            int.TryParse(node.Value.ToString().Split(',')[0], out templateCode);
            int.TryParse(node.Value.ToString().Split(',')[1], out parentCode);
            if (templateCode == 0 || parentCode == 0) return result.ToArray();
            DataTable dt = ProjectManagement.TemplateItem.JTemplateItems.GetDataTable(templateCode, parentCode, false);
            if (dt == null) return result.ToArray();
            foreach (DataRow row in dt.Rows)
            {
                RadTreeNodeData _node = new RadTreeNodeData();
                ProjectManagement.TemplateItem.JTemplateItem i = new ProjectManagement.TemplateItem.JTemplateItem(row["Code"].ToString().ToInt32());

                _node.Text = row[1].ToString() + "(<span class='treeviewPart1'>وزن آیتم:" + i.WeightPercentage.ToString("000.00").ToDecimal() +
                    " </span>)-<span class='treeviewPart2'> وزن زیر مجموعه: " + i.TotalWeight.ToString("000.00").ToDecimal() + "</span>)";

                _node.Value = row["TemplateCode"].ToString() + "," + row["Code"].ToString();
                _node.ExpandMode = TreeNodeExpandMode.WebService;
                if (i.WeightPercentage==i.TotalWeight)
                    _node.ImageUrl = "/WebProjectManagement/Images/double-left-arrow_green.png";
                else if(i.TotalWeight>0)
                    _node.ImageUrl = "/WebProjectManagement/Images/double-left-arrow_red.png";
                else
                    _node.ImageUrl = "/WebProjectManagement/Images/left_arrow_blue.png";
                result.Add(_node);
            }

            return result.ToArray();
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static Telerik.Web.UI.RadTreeNodeData[] LoadNodes(RadTreeNodeData node, object context)
        {
            List<RadTreeNodeData> result = new List<RadTreeNodeData>();
            int projectCode = 0,parentCode=0;
            int.TryParse(node.Value.ToString().Split(',')[0], out projectCode);
            int.TryParse(node.Value.ToString().Split(',')[1], out parentCode);
            if (projectCode == 0 || parentCode==0) return result.ToArray();
            DataTable dt = ProjectManagement.Item.JItems.GetDataTable(projectCode,parentCode,false);
            if (dt == null) return result.ToArray();
            foreach (DataRow row in dt.Rows)
            {
                RadTreeNodeData _node = new RadTreeNodeData();
                ProjectManagement.MixedObjects.ItemAndProjectDetails i = new ProjectManagement.MixedObjects.ItemAndProjectDetails();
              i.GetData(  row["Code"].ToString().ToInt32(), row["ProjectCode"].ToString().ToInt32(), false);
              //  if(i.TotalSubItemPercentage==0)
                    _node.Text = row[1].ToString() + "(<span class='treeviewPart1'>وزن آیتم: " + i.Item.WeightPercentage.ToString("000.00").ToDecimal() +
                    "</span> - <span class='treeviewPart2'> وزن زیرمجموعه: " + i.TotalSubItemPercentage.ToString("000.00").ToDecimal() +
                    "</span> - <span class='treeviewPart3'> وزن پیشرفت آیتم: " + i.Item.ReportedPercentage().ToString("000.00").ToDecimal() + "%</span>)";
          //      else
           //    _node.Text = row[1].ToString() + "(" + i.Item.WeightPercentage + "/" + i.TotalSubItemPercentage + ")";
                _node.Value = row["ProjectCode"].ToString()+","+row["Code"].ToString();
                _node.ExpandMode = TreeNodeExpandMode.WebService;
                if (i.Item != null && i.Item.Code > 0 && i.TotalSubItemPercentage == i.Item.WeightPercentage && i.TotalSubItemPercentage!=0)// زیرمجموعه کامل دارد
                    _node.ImageUrl = "/WebProjectManagement/Images/double-left-arrow_green.png";
                else if (i.Item != null && i.Item.Code > 0 && i.TotalSubItemPercentage < i.Item.WeightPercentage && i.TotalSubItemPercentage>0)//زیر مجموعه کامل نیست
                    _node.ImageUrl = "/WebProjectManagement/Images/double-left-arrow_red.png";
                else if (i.TotalReportedPercentage >= 100)//==i.Item.WeightPercentage)    // 100 درصد پیشرفت گزارش شده است
                    _node.ImageUrl = "/WebProjectManagement/Images/checked.png";
                else// نه زیر مجموعه دارد و گزارش پیشرفت 100 درصدی دارد
                {
                    _node.ImageUrl = "/WebProjectManagement/Images/left_arrow_blue.png";
                    _node.Attributes.Add("tag", "0");
                }
                result.Add(_node);
            }

            return result.ToArray();
        }
    }
}