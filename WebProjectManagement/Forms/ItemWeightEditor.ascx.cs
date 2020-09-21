using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ProjectManagement;
using System.Web.UI.WebControls;
using ProjectManagement.Controls.ExcelLike;

namespace WebProjectManagement.Forms
{
    public partial class ItemWeightEditor : System.Web.UI.UserControl
    {
        int code, type;
        System.Data.DataTable dt;
        private Dictionary<int, int> MainItemsOrders = new Dictionary<int, int>();
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["code"], out code);
            int.TryParse(Request["Type"], out type);
            string projectOrTemplateName;
            System.Data.DataTable dt = new System.Data.DataTable();
            int latestParentCode = 1;
            List<object> rowArray;
            List<List<object>> rowArrays = new List<List<object>>();
            string redFieldNames = "";

            if (type == 1)//project
            {
                ProjectManagement.Item.JItem latestParentTemp;
                ProjectManagement.Project.JProject project = new ProjectManagement.Project.JProject(code);
                projectOrTemplateName = project.Name;
             //   dt.Columns.Add("projectName");
                foreach (System.Data.DataRow dr in ProjectManagement.Item.JItems.GetDataTableWithFillField(code).Rows)//.GetLatestChildren(code).Rows)
                {
                    latestParentCode = 1;
                    rowArray = new List<object>();
                    latestParentTemp = GetParent(int.Parse(dr["ParentItemCode"].ToString()));
                    while (latestParentTemp != null && latestParentTemp.Code > 0)
                    {
                        if (!dt.Columns.Contains("Name" + latestParentCode))
                            dt.Columns.Add("Name" + latestParentCode);

                        rowArray.Add(ExcelLikeTable.CreateCellValue("Name", latestParentTemp.Code.ToString(), latestParentTemp.Name));
                        latestParentTemp = GetParent(latestParentTemp.ParentItemCode);
                        latestParentCode++;
                    }
                    rowArray.Reverse();

                    if (!bool.Parse(dr["isFilled"].ToString())) redFieldNames += dr["Code"].ToString() + ",";

                    rowArray.Add(ExcelLikeTable.CreateCellValue("Name", dr["Code"].ToString(), dr["Name"].ToString()));
                    rowArray.Add(ExcelLikeTable.CreateCellValue("WeightPercentage", dr["Code"].ToString(), dr["WeightPercentage"].ToString().ToFloat(2).ToString()));
                    // rowArray.Add(ExcelLikeTable.CreateCellValue("ItemDescription", dr["Code"].ToString(), dr["ItemDescription"].ToString()));
                 
                    rowArrays.Add(rowArray);

                    if (!MainItemsOrders.ContainsKey(dr["Code"].ToString().ToInt32()))
                        MainItemsOrders.Add(dr["Code"].ToString().ToInt32(), dr["Ordered"].ToString().ToInt32()==0? dr["Code"].ToString().ToInt32() : dr["Ordered"].ToString().ToInt32());
                }
                dt.Columns.Add("Name0");
                dt.Columns.Add("WeightPercentage");
                //  dt.Columns.Add("ItemDescription");
            }
            else//template
            {
                ProjectManagement.TemplateItem.JTemplateItem latestParentTemp;
                ProjectManagement.Template.JTemplate template = new ProjectManagement.Template.JTemplate(code);
                projectOrTemplateName = template.Name;
            //    dt.Columns.Add("templateName");
                foreach (System.Data.DataRow dr in ProjectManagement.TemplateItem.JTemplateItems.GetDataTableWithFillField(code).Rows)//GetLatestChildren(code).Rows)
                {
                    latestParentCode = 1;
                    rowArray = new List<object>();

                    latestParentTemp = GetTemplateItemParent(int.Parse(dr["ParentItemCode"].ToString()));
                    while (latestParentTemp != null && latestParentTemp.Code > 0)
                    {
                        if (!dt.Columns.Contains("Name" + latestParentCode))
                        {
                            dt.Columns.Add("Name" + latestParentCode);
                        }
                        rowArray.Add(ExcelLikeTable.CreateCellValue("Name", latestParentTemp.Code.ToString(), latestParentTemp.Name));
                        latestParentTemp = GetTemplateItemParent(latestParentTemp.ParentItemCode);
                        latestParentCode++;
                    }
                    rowArray.Reverse();

                    if (!bool.Parse(dr["isFilled"].ToString())) redFieldNames += dr["Code"].ToString()+",";

                    rowArray.Add(ExcelLikeTable.CreateCellValue("Name", dr["Code"].ToString(), dr["Name"].ToString()));
                    rowArray.Add(ExcelLikeTable.CreateCellValue("WeightPercentage", dr["Code"].ToString(), dr["WeightPercentage"].ToString().ToFloat(2).ToString()));
                                    rowArrays.Add(rowArray);


                    if (!MainItemsOrders.ContainsKey(dr["Code"].ToString().ToInt32()))
                        MainItemsOrders.Add(dr["Code"].ToString().ToInt32(), dr["Ordered"].ToString().ToInt32() == 0 ? dr["Code"].ToString().ToInt32() : dr["Ordered"].ToString().ToInt32());
                }
                dt.Columns.Add("Name0");
                dt.Columns.Add("WeightPercentage");
            }


            lblProjectOrTemplateNname.Text= projectOrTemplateName;
            object[] b;
            foreach (List<object> o in Order(rowArrays))
            {
                b = new object[dt.Columns.Count];
              //  b[0] = projectOrTemplateName;
                o.ToArray().CopyTo(b, 0);
                dt.Rows.Add(b);
            }

            excellike.RedFieldNames = redFieldNames;
            excellike.ProjectOrTemplateCode = code;
            excellike.Type = type;
            excellike.ReadOnlyColumns += "templateName,projectName";
            //excellike.ColumnsToCalculateTotal += "WeightPercentage";
            excellike.Datatable = dt;
            if (!this.IsPostBack)
            {
            }
        }

        private List<List<object>> Order(List<List<object>> rawList)
        {
            IOrderedEnumerable<List<object>> data = null;
            data = rawList.OrderBy(x => MainItemsOrders[x[0].ToString().Split(new string[] { ExcelLikeTable.SEPARATOR }, StringSplitOptions.None)[1].ToInt32()]);
            data = data.ThenBy(x => x[0].ToString());
            data = data.ThenBy(x => x.Count > 1 && x[1].ToString().StartsWith("Name") ? x[1].ToString().Split(new string[] { ExcelLikeTable.SEPARATOR }, StringSplitOptions.None)[2] : null);
            data = data.ThenBy(x => x.Count > 1 && x[1].ToString().StartsWith("Name") ? x[1].ToString().Split(new string[] { ExcelLikeTable.SEPARATOR }, StringSplitOptions.None)[1] : null);

            data = data.ThenBy(x => x.Count > 2 && x[2].ToString().StartsWith("Name") ? x[2].ToString().Split(new string[] { ExcelLikeTable.SEPARATOR }, StringSplitOptions.None)[2] : null);
            data = data.ThenBy(x => x.Count > 3 && x[3].ToString().StartsWith("Name") ? x[3].ToString().Split(new string[] { ExcelLikeTable.SEPARATOR }, StringSplitOptions.None)[2] : null);
            data = data.ThenBy(x => x.Count > 4 && x[4].ToString().StartsWith("Name") ? x[4].ToString().Split(new string[] { ExcelLikeTable.SEPARATOR }, StringSplitOptions.None)[2] : null);
            data = data.ThenBy(x => x.Count > 5 && x[5].ToString().StartsWith("Name") ? x[5].ToString().Split(new string[] { ExcelLikeTable.SEPARATOR }, StringSplitOptions.None)[2] : null);
            data = data.ThenBy(x => x.Count > 6 && x[6].ToString().StartsWith("Name") ? x[6].ToString().Split(new string[] { ExcelLikeTable.SEPARATOR }, StringSplitOptions.None)[2] : null);
            data = data.ThenBy(x => x.Count > 7 && x[7].ToString().StartsWith("Name") ? x[7].ToString().Split(new string[] { ExcelLikeTable.SEPARATOR }, StringSplitOptions.None)[2] : null);
            data = data.ThenBy(x => x.Count > 8 && x[8].ToString().StartsWith("Name") ? x[8].ToString().Split(new string[] { ExcelLikeTable.SEPARATOR }, StringSplitOptions.None)[2] : null);
            data = data.ThenBy(x => x.Count > 9 && x[9].ToString().StartsWith("Name") ? x[9].ToString().Split(new string[] { ExcelLikeTable.SEPARATOR }, StringSplitOptions.None)[2] : null);

            return data.ToList();
        }



        private IOrderedEnumerable<List<object>> ThenBy(List<List<object>> rawList, int index)
        {
            return rawList.OrderBy(x => x.Count > index ? x[index].ToString() : "");
        }
        private ProjectManagement.Item.JItem GetParent(int Code)
        {
            if (code > 0)
                return new ProjectManagement.Item.JItem(Code);
            return null;
        }
        private ProjectManagement.TemplateItem.JTemplateItem GetTemplateItemParent(int Code)
        {
            if (code > 0)
                return new ProjectManagement.TemplateItem.JTemplateItem(Code);
            return null;
        }

        protected void tbrActions_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "AddMainNode":
                    ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadControl("MainItem"
                                    , JWebProjectManagement.FORMS_PLACE +(type==1? "ItemUpdate.ascx" : "TemplateItemUpdate.ascx")
                                    , "ایجاد آیتم اصلی"
                                    , new List<Tuple<string, string>>() {
                                        new Tuple<string, string>("ItemCode", "-1"),
                                        new Tuple<string, string>("ParentCode", "-1"),
                                        new Tuple<string, string>((type==1?"ProjectCode":"TemplateCode"), code.ToString())
                                    }
                                    , WebClassLibrary.WindowTarget.NewWindow
                             , "OnClienClosedTheWindow"
                                    , true, false, true, 630, 350);
                    break;
            }
        }

    }
}