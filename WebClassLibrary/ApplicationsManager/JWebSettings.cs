using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebClassLibrary.ApplicationsManager
{
    public class JWebSettings
    {
        public const string _ConstClassName = "WebClassLibrary.ApplicationsManager.JWebSettings";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("LogOut", JDomains.JActionEvents.MouseClick, "WebClassLibrary.ApplicationsManager.JWebSettings.LogOut", null, new List<object> { }) }, "Logout", _ConstClassName, JDomains.Images.MenuImages.LogOut, null));
			nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("MainConfig", JDomains.JActionEvents.MouseClick, "WebClassLibrary.ApplicationsManager.JWebSettings.MainConfig", null, new List<object> { }) }, "MainConfig", _ConstClassName, JDomains.Images.MenuImages.Setting, null));
            return nodes;
        }

        public void LogOut()
        {
            SessionManager.Current.Dispose();
            JWebManager.CurrentPage.Response.Redirect("~/"+ClassLibrary.JConfig.LoginPage);
        }

		public string MainConfig()
		{
			return WebClassLibrary.JWebManager.LoadClientControl("MainConfig"
				, "~/WebControllers/MainControls/Configuration/JConfigControl.ascx"
				, "تنظیمات"
				, null
				, WebClassLibrary.WindowTarget.NewWindow
				, true, false, true, 500, 400, false);
		}
    }
}
