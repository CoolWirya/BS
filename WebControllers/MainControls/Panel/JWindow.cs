using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebControllers.MainControls
{
    public class JWindow
    {
        public string Title;
        public string UniqueID;
        public Telerik.Web.UI.WindowBehaviors WindowOptions = Telerik.Web.UI.WindowBehaviors.None;
        public bool isModal = false;
        public int Width = 300;
        public int Height = 200;
        public bool isMaximized = true;
        public string NavigateURL = "";
        public List<Tuple<string, string>> QueryParameters = null;

        public JWindow(string uniqueId, string title, bool ismodal = false)
        {
            Title = title;
            UniqueID = uniqueId;
            isModal = ismodal;
            if (ismodal == true)
            {
                WindowOptions = Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Move | Telerik.Web.UI.WindowBehaviors.Resize;
            }
        }

        public static Int64 z_index = 10000;
        public Telerik.Web.UI.RadWindow Generate()
        {
            if (z_index > 100000)
                z_index = 10000;
            z_index += 1;
            Telerik.Web.UI.RadWindow radWindow = new Telerik.Web.UI.RadWindow();
            radWindow.ID = "window_" + UniqueID;
            radWindow.Title = Title;
            radWindow.Modal = isModal;
            radWindow.AutoSize = true;
            radWindow.AutoSizeBehaviors = Telerik.Web.UI.WindowAutoSizeBehaviors.Height | Telerik.Web.UI.WindowAutoSizeBehaviors.Width;
            radWindow.Width = Width;
            radWindow.MinWidth = Width;
            radWindow.Height = Height;
            radWindow.MinHeight = Height;
            radWindow.Visible = true;
            radWindow.DestroyOnClose = true;
            radWindow.VisibleOnPageLoad = true;
            radWindow.VisibleStatusbar = false;
            radWindow.AutoSize = false;
            radWindow.Behaviors = WindowOptions;
            radWindow.ShowOnTopWhenMaximized = false;
            if (isMaximized) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Maximize;

            radWindow.Style.Remove("z-index");
            radWindow.Style.Add("z-index", z_index.ToString());

            radWindow.RenderMode = Telerik.Web.UI.RenderMode.Lightweight;

            // QueryParameters to QueryString
            string QueryString = "";
            if (QueryParameters != null)
            {
                foreach (var item in QueryParameters)
                    QueryString += "&" + item.Item1 + "=" + item.Item2;
                QueryString = QueryString.Substring(1);
            }

            if (QueryString != "")
            {
                if (NavigateURL.IndexOf("?") > 0) QueryString = "&" + QueryString;
                else QueryString = "?" + QueryString;
            }
            if (NavigateURL != "") radWindow.NavigateUrl = WebClassLibrary.JWebManager.CurrentPage.ResolveUrl(NavigateURL) + (QueryString != "" ? QueryString : "");
            return radWindow;
        }
    }
}