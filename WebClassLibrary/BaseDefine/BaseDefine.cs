using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebClassLibrary
{
    public class JBaseDefine
    {
        public const string _ConstClassName = "WebClassLibrary.JBaseDefine";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            JNode Person = new JNode(null, "اشخاص", _ConstClassName, JDomains.Images.MenuImages.Folder, null);
            Person._Childs = new List<JNode>() { new JNode(new List<JActionsInfo>(){new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebClassLibrary.JBaseDefine.ShowList", null, new List<object>(){"RealPerson"})}, "شخص حقیقی", _ConstClassName, JDomains.Images.MenuImages.Item, null),
                                            new JNode(new List<JActionsInfo>(){new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebClassLibrary.JBaseDefine.ShowList", null, new List<object>(){"LegalPerson"})}, "شخص حقوقی", _ConstClassName,JDomains.Images.MenuImages.Item, null),
                                            new JNode(new List<JActionsInfo>(){new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebClassLibrary.JBaseDefine.ShowList", null, new List<object>(){"OtherPerson"})}, "سایر اشخاص", _ConstClassName,JDomains.Images.MenuImages.Item, null)};
            nodes.Add(Person);
            return nodes;
        }

        public string ShowList(string type)
        {
            if (type == "RealPerson")
            {
                WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
                jGridView.SQL = "select top 100 percent Code, Name, Fam, FatherName, ShSh, ShMeli, CASE WHEN Gender=1 THEN N'مرد' ELSE N'زن' END Gender from clsPerson";
                jGridView.Title = "کاربران";
                jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
                jGridView.Toolbar.AddButton("New", "جدید", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebClassLibrary.JBaseDefine.New", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
                jGridView.Actions = new List<JActionsInfo>();
                jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebClassLibrary.JBaseDefine.GetMenu", null, null));

                return JWebManager.GenerateClientWindow(jGridView.GenerateWindow());
            }

            return "";
        }

        public List<WebControllers.MainControls.Menu.JMenuItem> GetMenu(Telerik.Web.UI.GridDataItem param = null)
        {
            List<WebControllers.MainControls.Menu.JMenuItem> menuItems = new List<WebControllers.MainControls.Menu.JMenuItem>();
            WebControllers.MainControls.Menu.JMenuItem menuItem = new WebControllers.MainControls.Menu.JMenuItem();
            menuItem.Text = "جدید";
            menuItem.ImageUrl = WebClassLibrary.JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Menu_Add);
            menuItem.Action = new JActionsInfo("Add", JDomains.JActionEvents.MouseClick, "WebClassLibrary.JBaseDefine.MenuItemClick", null, new List<object>() { });
            menuItems.Add(menuItem);
            menuItem = new WebControllers.MainControls.Menu.JMenuItem();
            menuItem.Text = "ویرایش";
            menuItem.ImageUrl = WebClassLibrary.JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Menu_Edit);
            menuItem.Action = new JActionsInfo("Edit", JDomains.JActionEvents.MouseClick, "WebClassLibrary.JBaseDefine.MenuItemClick", null, new List<object>() { });
            menuItems.Add(menuItem);
            menuItem = new WebControllers.MainControls.Menu.JMenuItem();
            menuItem.Text = "حذف";
            menuItem.ImageUrl = WebClassLibrary.JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Menu_Delete);
            menuItem.Action = new JActionsInfo("Delete", JDomains.JActionEvents.MouseClick, "WebClassLibrary.JBaseDefine.MenuItemClick", null, new List<object>() { });
            menuItems.Add(menuItem);

            return menuItems;
        }

        public void MenuItemClick(WebControllers.MainControls.Menu.JMenuItem menuItem, Telerik.Web.UI.GridDataItem item)
        {
            if (menuItem.Text == "جدید")
            {
                New();
            }
            else if (menuItem.Text == "ویرایش")
            {
            }
            else if (menuItem.Text == "حذف")
            {
            }
        }

        public void New()
        {
            string SUID = "AddRealPerson";
            JWebManager.SetControlType(JDomains.JControls.JUserControl, SUID, "~/WebControllers/BaseDefine/JNewRealPerson.ascx");
            WebControllers.MainControls.JWindow window = new WebControllers.MainControls.JWindow(SUID, "شخص جدید", true);
            window.Width = 700;
            window.Height = 500;
            window.NavigateURL = JWebManager.GenerateControlURL(SUID);
            WebClassLibrary.JWebManager.AddToContentZone(window.Generate());

        }
    }
}
