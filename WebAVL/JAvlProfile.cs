using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAVL
{
    public class JAvlProfile
    {
        public const string _ConstClassName = "WebAVL.JAvlProfile";

        public List<WebClassLibrary.JNode> GetNodes()
        {
            List<WebClassLibrary.JNode> Nodes = new List<WebClassLibrary.JNode>();
           // Nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("config", WebClassLibrary.JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Configuration.JConfiguration._Information", null, null) }, "اطلاعات کاربر", "WebControllers.MainControls.Configuration.JConfiguration._Information", WebClassLibrary.JDomains.Images.MenuImages.Item, null));
            Nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("config", WebClassLibrary.JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Configuration.JConfiguration._ChangePassword", null, null) }, "تغییر کلمه عبور", "WebControllers.MainControls.Configuration.JConfiguration._ChangePassword", WebClassLibrary.JDomains.Images.AvlManagementImages.modify_key_icon, null));
           // Nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("config", WebClassLibrary.JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Configuration.JConfiguration._Settings", null, null) }, "تنظیمات", "WebControllers.MainControls.Configuration.JConfiguration._Settings", WebClassLibrary.JDomains.Images.MenuImages.Item, null));
            return Nodes;
        }
    }
}