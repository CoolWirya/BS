using System;
using System.Data;
using pm = ProjectManagement.Item;
using System.Collections.Generic;
using System.Web.Services;
using ProjectManagement;
using Telerik.Web.UI;

namespace WebProjectManagement.Forms
{
    public partial class ProjectItemList : System.Web.UI.UserControl
    {
        int projectCode;
        public const String SessionNameForShowProjectItems = "projectCodeToShowItems";
        protected void Page_Load(object sender, EventArgs e)
        {
            projectCode = -1;
            int.TryParse(Request["Code"], out projectCode);
            WebClassLibrary.SessionManager.Current.Session.Add(SessionNameForShowProjectItems, projectCode);

            LoadRootNodes();

            pnlPromptDeleteAndMove.Visible = false;
            pnlPromptDeleteFully.Visible = false;
            pnlPromptDeleteAndMove.Controls.Add(InitPromptBoxDeleteAndMove());
            pnlPromptDeleteFully.Controls.Add(InitPromptBoxDeleteFully());
        }


        private void LoadRootNodes()
        {
            if (IsPostBack) return;
            trvOrg.Nodes.Clear();
            ProjectManagement.MixedObjects.ItemAndProjectDetails project = new ProjectManagement.MixedObjects.ItemAndProjectDetails(-1, projectCode);

            Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode();
            node.Text = project.Project.Name + "( <span class='treeviewPart1'>وزن پروژه: " + project.Project.TotalWeight + " </span> - <span class='treeviewPart2'> وزن آیتم های اصلی: " + project.TotalSubItemPercentage + "</span>)";
            node.Value = project.Project.Code.ToString() + ",-1";
            node.ExpandMode = Telerik.Web.UI.TreeNodeExpandMode.WebService;
            if (project.Item != null && project.Item.Code > 0 && project.TotalSubItemPercentage == project.Item.WeightPercentage)
                node.ImageUrl = "~/WebProjectManagement/Images/double-left-arrow_green.png";
            else
                node.ImageUrl = "~/WebProjectManagement/Images/double-left-arrow_red.png";
            trvOrg.Nodes.Add(node);
            //DataTable dt = pm.JItems.GetDataTableRootNodes(projectCode);
            //if (dt == null) return;
            //foreach (DataRow row in dt.Rows)
            //{
            //    Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode();
            //    node.Text = row[1].ToString();
            //    node.Value = row["Code"].ToString();
            //    node.ExpandMode = Telerik.Web.UI.TreeNodeExpandMode.WebService;
            //    trvOrg.Nodes.Add(node);
            //}
        }

        protected void tbrActions_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            if ((trvOrg.SelectedNode == null || trvOrg.SelectedNode.Parent == trvOrg) && e.Item.Value!="AddMainNode") return;
            switch (e.Item.Value)
            {
                case "AddMainNode":
                 ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadControl("MainItem"
                                    , JWebProjectManagement.FORMS_PLACE + "ItemUpdate.ascx"
                                    , "ایجاد آیتم اصلی"
                                    , new List<Tuple<string, string>>() {
                                        new Tuple<string, string>("ItemCode", "-1"),
                                        new Tuple<string, string>("ParentCode", "-1"),
                                        new Tuple<string, string>("ProjectCode", projectCode.ToString())
                                    }
                                    , WebClassLibrary.WindowTarget.NewWindow
                                    , "OnClienClosedTheWindow"
                                    , true, false, true, 630, 350);
                    break;
                case "AddSubNode":
                    if (trvOrg.SelectedNode == null)
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('برای اضافه کردن زیر مجموعه باید آیتم را انتخاب کنید.');", "ConfirmDialog");
                        return;
                    }
                    ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadControl("SubItem"
                                    , JWebProjectManagement.FORMS_PLACE + "ItemUpdate.ascx"
                                    , "ایجاد آیتم"
                                    , new List<Tuple<string, string>>() {
                                        new Tuple<string, string>("ItemCode", "-1" ),
                                        new Tuple<string, string>("ParentCode", trvOrg.SelectedValue.Split(',')[1]),
                                        new Tuple<string, string>("ProjectCode", projectCode.ToString())
                                    }
                                    , WebClassLibrary.WindowTarget.NewWindow
                                    , "OnClienClosedTheWindow"
                                    , true, false, true, 630, 350);
                    break;
                case "EditNode":
                    if (trvOrg.SelectedNode == null)
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('برای ویرایش آیتم را انتخاب کنید.');", "ConfirmDialog");
                        return;
                    }
                    ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadControl("EditItem"
                                    , JWebProjectManagement.FORMS_PLACE + "ItemUpdate.ascx"
                                    , "ویرایش آیتم"
                                    , new List<Tuple<string, string>>() {
                                        new Tuple<string, string>("ItemCode",trvOrg.SelectedValue.Split(',')[1] ),
                                        new Tuple<string, string>("ParentCode", trvOrg.SelectedNode.ParentNode!=null?trvOrg.SelectedNode.ParentNode.Value.Split(',')[1]:"-1"),
                                        new Tuple<string, string>("ProjectCode", projectCode.ToString())
                                    }
                                    , WebClassLibrary.WindowTarget.NewWindow
                                    , "OnClienClosedTheWindow"
                                    , true, true, true, 630, 350, true);
                    break;
                case "DeleteNodeAndMove":
                    if (trvOrg.SelectedNode != null && trvOrg.SelectedNode.ParentNode != null)
                    {
                        pnlPromptDeleteAndMove.Visible = true;
                    }
                    break;
                case "DeleteNodeFully":
                    if (trvOrg.SelectedNode != null)
                    {
                        pnlPromptDeleteFully.Visible = true;
                    }
                    break;
            }
        }


        private AskUser InitPromptBoxDeleteAndMove()
        {

            AskUser askUser = (AskUser)LoadControl(JWebProjectManagement.FORMS_PLACE + "AskUser.ascx");
            askUser.Message = "آیا مطمئن هستید که آِیتم حذف شود؟";
            askUser.ok = new AskUser.Clicked(() =>
            {
                if (!trvOrg.SelectedValue.Contains(",")) return;
                if (pm.JItems.Move(trvOrg.SelectedValue.Split(',')[1].ToInt32(), trvOrg.SelectedNode.Level==1?-1: trvOrg.SelectedNode.ParentNode.Value.Split(',')[1].ToInt32()))
                {
                    if (pm.JItems.DeleteNodeIncludeSubNodes(trvOrg.SelectedValue.Split(',')[1].ToInt32()))
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('آیتم حذف شد. وزیر مجموعه ها یک رده به بالا منتقل شدند.');", "ConfirmDialog");
                        trvOrg.SelectedNode.Remove();
                        WebClassLibrary.JWebManager.RunClientScript("OnClienClosedTheWindow(null,null);", "ConfirmDialog");
                    }
                    else
                        WebClassLibrary.JWebManager.RunClientScript("alert('آیتم حذف نشد.');", "ConfirmDialog");


                }
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('عملیات ناموفق');", "ConfirmDialog"); 
            });
            askUser.no = new AskUser.Clicked(() => { pnlPromptDeleteAndMove.Controls.Clear(); });
            return askUser;
        }
        private AskUser InitPromptBoxDeleteFully()
        {

            AskUser askUser = (AskUser)LoadControl(JWebProjectManagement.FORMS_PLACE + "AskUser.ascx");
            askUser.Message = "آیا مطمئن هستید که آِیتم به همراه زیر مجموعه ها حذف شود؟";
            askUser.ok = new AskUser.Clicked(() =>
            {
                if (!trvOrg.SelectedValue.Contains(",")) return;
                if (pm.JItems.DeleteNodeIncludeSubNodes(trvOrg.SelectedValue.Split(',')[1].ToInt32()))
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('آیتم به همراه زیر مجموعه ها حذف شد.');", "ConfirmDialog");
                    trvOrg.SelectedNode.Remove();
                    WebClassLibrary.JWebManager.RunClientScript("OnClienClosedTheWindow(null,null);", "ConfirmDialog");
                }
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('عملیات ناموفق. آیتم هایی که برای آن ها گزارش ثبت شده است، حذف نمی شوند.');", "ConfirmDialog"); 
            });
            askUser.no = new AskUser.Clicked(() => { pnlPromptDeleteFully.Controls.Clear(); });
            return askUser;
        }





    }
}