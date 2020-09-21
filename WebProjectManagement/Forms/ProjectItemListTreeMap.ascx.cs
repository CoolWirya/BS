using System;
using ProjectManagement;
using System.Collections.Generic;

namespace WebProjectManagement.Forms
{
    public partial class ProjectItemListTreeMap : System.Web.UI.UserControl
    {
        int projectCode;
        public const String SessionNameForShowProjectItems = "projectCodeToShowItems";
        protected void Page_Load(object sender, EventArgs e)
        {
            projectCode = -1;
            int.TryParse(Request["Code"], out projectCode);
            WebClassLibrary.SessionManager.Current.Session.Add(SessionNameForShowProjectItems, projectCode);
            
            if (!IsPostBack)
            {

                TreeMap1.DataFieldID = "Code";
                TreeMap1.DataFieldParentID = "ParentItemCode";
                TreeMap1.DataTextField = "WeightPercentage";
                TreeMap1.DataValueField = "WeightPercentage";

                TreeMap1.DataSource = ProjectManagement.Item.JItems.GetDataTableForTreeMap(projectCode);
                TreeMap1.DataBind();

            }
            else
            {

                if (!string.IsNullOrEmpty(Request.Form["HiddenField"]))
                {
                    string[] vals = Request.Form["HiddenField"].Split('-');
                    loadForm(vals[0], vals[1].ToInt32());
                    return;
                }
            }
        }


        private void B_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void tbrActions_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            loadForm(e.Item.Value, -1);
        }
        protected void loadForm(string value, int selectedItemCode)
        {
            ProjectManagement.Item.JItem item = new ProjectManagement.Item.JItem(selectedItemCode);
            switch (value)
            {
                case "AddMainNode":
                    WebClassLibrary.JWebManager.LoadControl("MainItem"
                                    , JWebProjectManagement.FORMS_PLACE + "ItemUpdate.ascx"
                                    , "ایجاد آیتم اصلی"
                                    , new List<Tuple<string, string>>() {
                                        new Tuple<string, string>("ItemCode", "-1"),
                                        new Tuple<string, string>("ParentCode", "-1"),
                                        new Tuple<string, string>("ProjectCode", projectCode.ToString())
                                    }
                                    , WebClassLibrary.WindowTarget.NewWindow
                                    , true, false, true, 630, 350);
                    break;
                case "AddSubNode":
                    WebClassLibrary.JWebManager.LoadControl("SubItem"
                                    , JWebProjectManagement.FORMS_PLACE + "ItemUpdate.ascx"
                                    , "ایجاد آیتم"
                                    , new List<Tuple<string, string>>() {
                                        new Tuple<string, string>("ItemCode", "-1"),
                                        new Tuple<string, string>("ParentCode",  item.Code.ToString()),
                                        new Tuple<string, string>("ProjectCode", projectCode.ToString())
                                    }
                                    , WebClassLibrary.WindowTarget.NewWindow
                                    , true, false, true, 630, 350);
                    break;
                case "EditNode":
                    WebClassLibrary.JWebManager.LoadControl("EditItem"
                                    , JWebProjectManagement.FORMS_PLACE + "ItemUpdate.ascx"
                                    , "ویرایش آیتم"
                                    , new List<Tuple<string, string>>() {
                                                new Tuple<string, string>("ItemCode",item.Code.ToString() ),
                                                new Tuple<string, string>("ParentCode", item.ParentItemCode.ToString()),
                                                new Tuple<string, string>("ProjectCode", projectCode.ToString())
                                    }
                                    , WebClassLibrary.WindowTarget.NewWindow
                                    , true, false, true, 630, 350);
                    break;
                case "DeleteNodeAndMove":
                    if(!ProjectManagement.Item.JItems.Move(item.Code, item.ParentItemCode))
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('آیتم نباید گزارشی برایش ثبت شده باشد و همینطور آیتم مادر جدید باید فضا برای درصد های جدید را داشته باشد.');", "ConfirmDialog");
                        return;
                    }
                    if (!ProjectManagement.Item.JItems.DeleteNodeIncludeSubNodes(item.Code))
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('نمی توان آیتم هایی که برایشان گزارش ثبت شده را حذف نمود.');", "ConfirmDialog");
                    }
                    break;
                case "DeleteNodeFully":
                    if(!ProjectManagement.Item.JItems.DeleteNodeIncludeSubNodes(item.Code))
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('نمی توان آیتم هایی که برایشان گزارش ثبت شده را حذف نمود.');", "ConfirmDialog");
                    }
                    break;
                case "btnEnterData":
                    WebClassLibrary.JWebManager.LoadControl("EnterReport"
                                  , JWebProjectManagement.FORMS_PLACE + "ItemReportUpdate.ascx"
                                           , "وارد کردن اطلاعات"
                                  , new List<Tuple<string, string>>() {
                              new Tuple<string, string>("Code","-1" ),
                               new Tuple<string, string>("ItemCode", item.Code.ToString())
                                  }
                                  , WebClassLibrary.WindowTarget.NewWindow
                                  , true, true, true, 600, 350, true);
                    break;
            }
        }



    }


}