using System;
using System.Collections.Generic;
using ProjectManagement;
using System.Data;

namespace WebProjectManagement.Forms
{
    public partial class TemplateItemList : System.Web.UI.UserControl
    {
        int templateCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out templateCode);

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
            ProjectManagement.Template.JTemplate t = new ProjectManagement.Template.JTemplate(templateCode);
            Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode();
            node.Text = t.Name + "(وزن الگو: " + t.TotalWeight + " - وزن آیتم های اصلی: " + t.TotalFilledWeight + ")";
            node.Value = t.Code.ToString() + ",-1";
            node.ExpandMode = Telerik.Web.UI.TreeNodeExpandMode.WebService;
            if (t.TotalFilledWeight == t.TotalWeight)
                node.ImageUrl = "~/WebProjectManagement/Images/double-left-arrow_green.png";
            else
                node.ImageUrl = "~/WebProjectManagement/Images/double-left-arrow_red.png";
            trvOrg.Nodes.Add(node);


        }


        protected void tbrActions_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            if ((trvOrg.SelectedNode==null || trvOrg.SelectedNode.Parent == trvOrg) && e.Item.Value!= "AddMainNode") return;
            switch (e.Item.Value)
            {
                case "AddMainNode":
                    ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadControl("MainItem"
                                    , JWebProjectManagement.FORMS_PLACE + "TemplateItemUpdate.ascx"
                                    , "ایجاد آیتم اصلی"
                                    , new List<Tuple<string, string>>() {
                                        new Tuple<string, string>("ItemCode", "-1"),
                                        new Tuple<string, string>("ParentCode", "-1"),
                                        new Tuple<string, string>("TemplateCode", templateCode.ToString())
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
                                    , JWebProjectManagement.FORMS_PLACE + "TemplateItemUpdate.ascx"
                                    , "ایجاد آیتم"
                                    , new List<Tuple<string, string>>() {
                                        new Tuple<string, string>("ItemCode", "-1" ),
                                        new Tuple<string, string>("ParentCode", trvOrg.SelectedValue.Split(',')[1]),
                                        new Tuple<string, string>("TemplateCode", templateCode.ToString())
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
                                    , JWebProjectManagement.FORMS_PLACE + "TemplateItemUpdate.ascx"
                                    , "ویرایش آیتم"
                                    , new List<Tuple<string, string>>() {
                                        new Tuple<string, string>("ItemCode",trvOrg.SelectedValue.Split(',')[1] ),
                                        new Tuple<string, string>("ParentCode", trvOrg.SelectedNode.ParentNode.Value.Split(',')[1]),
                                        new Tuple<string, string>("TemplateCode", templateCode.ToString())
                                    }
                                    , WebClassLibrary.WindowTarget.NewWindow
                                    , "OnClienClosedTheWindow"
                                    , true, false, true, 630, 350);
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
                if (ProjectManagement.TemplateItem.JTemplateItems.DeleteItemAndLevelUpSubItems(trvOrg.SelectedValue.Split(',')[1].ToInt32()))
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('آیتم حذف شد. وزیر مجموعه ها یک رده به بالا منتقل شدند.');", "ConfirmDialog");
                    trvOrg.SelectedNode.Remove();
                    WebClassLibrary.JWebManager.RunClientScript("OnClienClosedTheWindow(null,null);", "ConfirmDialog");
                }
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('عملیات ناموفق');", "ConfirmDialog");
            });
            askUser.no = new AskUser.Clicked(() => {  pnlPromptDeleteAndMove.Controls.Clear(); });
            return askUser;
        }
        private AskUser InitPromptBoxDeleteFully()
        {

            AskUser askUser = (AskUser)LoadControl(JWebProjectManagement.FORMS_PLACE + "AskUser.ascx");
            askUser.Message = "آیا مطمئن هستید که آِیتم به همراه زیر مجموعه ها حذف شود؟";
            askUser.ok = new AskUser.Clicked(() =>
            {
                if (!trvOrg.SelectedValue.Contains(",")) return;
                if (ProjectManagement.TemplateItem.JTemplateItems.DeleteItemIncludeSubItems(trvOrg.SelectedValue.Split(',')[1].ToInt32()))
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('آیتم به همراه زیر مجموعه ها حذف شد.');", "ConfirmDialog");
                    trvOrg.SelectedNode.Remove();
                    WebClassLibrary.JWebManager.RunClientScript("OnClienClosedTheWindow(null,null);", "ConfirmDialog");
                }
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('عملیات ناموفق');", "ConfirmDialog");
            });
            askUser.no = new AskUser.Clicked(() => { pnlPromptDeleteFully.Controls.Clear(); });
            return askUser;
        }
    }
}