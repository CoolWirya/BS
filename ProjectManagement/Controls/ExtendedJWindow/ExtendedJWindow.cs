using System;
using System.Collections.Generic;
using WebClassLibrary;

namespace ProjectManagement.Controls.ExtendedJWindow
{
    public class ExtendedJWindow : WebControllers.MainControls.JWindow
    {
        public ExtendedJWindow(string uniqueId, string title, bool ismodal = false) : base(uniqueId, title, ismodal)
        {
        }

        public Telerik.Web.UI.RadWindow Generate(string onClientCloseFunction)
        {
            return Generate(onClientCloseFunction, "");
        }
        public Telerik.Web.UI.RadWindow Generate(string onClientCloseFunction,string onClientShowFunction)
        {
            Telerik.Web.UI.RadWindow window = this.Generate();
            window.OnClientClose = onClientCloseFunction;
            window.OnClientShow =onClientShowFunction; // @"function onRadWindowShow(sender, arg){console.log('a');sender.maximize(true);}";
            if (isMaximized)
            {
                window.Width = System.Web.UI.WebControls.Unit.Parse("0px");
            }
            return window;
        }

        public new Telerik.Web.UI.RadWindow Generate()
        {
            Telerik.Web.UI.RadWindow radWindow = new Telerik.Web.UI.RadWindow();
            radWindow.ID = "window_" + UniqueID;
            radWindow.Title = Title;
            radWindow.Modal = isModal;
          //  radWindow.AutoSize = true;
            radWindow.AutoSizeBehaviors = Telerik.Web.UI.WindowAutoSizeBehaviors.Height | Telerik.Web.UI.WindowAutoSizeBehaviors.Width;
         //   radWindow.Width = Width;
        //    radWindow.MinWidth = Width;
            radWindow.Height = Height;
            radWindow.MinHeight = Height;
            radWindow.Visible = true;
            radWindow.DestroyOnClose = true;
            radWindow.VisibleOnPageLoad = true;
            radWindow.VisibleStatusbar = false;
            radWindow.AutoSize = false;
            radWindow.Behaviors = WindowOptions;
            if (isMaximized) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Maximize;
            radWindow.Style.Add("z-index", "2001");
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
        public static void LoadControl(string SUID, string ControlPath, string Name, List<Tuple<string, string>> QueryParameters, WindowTarget Target, string onClientCloseFunction, bool isModal = true, bool isMaximized = true, bool Closeable = true, int Width = 0, int Height = 0, bool isRestricted = false, string ContentControlID = "")
        {
            // Set Control Type and Control Path in Session using SUID
            JWebManager.SetControlType(JDomains.JControls.JUserControl, SUID, ControlPath);
            if (Target == WindowTarget.NewWindow)
            {
                // Create new window using SUID
                ExtendedJWindow window = new ExtendedJWindow(SUID, Name, isModal);
                window.NavigateURL = JWebManager.GenerateControlURL(SUID);
                if (Width > 0) window.Width = Width;
                if (Height > 0) window.Height = Height;
                window.QueryParameters = QueryParameters;
                window.isModal = isModal;
                window.isMaximized = isMaximized;
                window.WindowOptions |= Telerik.Web.UI.WindowBehaviors.Maximize;
                if (ContentControlID == "")
                    WebClassLibrary.JWebManager.AddWindow(window.Generate(onClientCloseFunction), isRestricted);
                else
                    WebClassLibrary.JWebManager.AddWindow(window.Generate(onClientCloseFunction), isRestricted, ContentControlID);

            }
            else if (Target == WindowTarget.CurrentWindow)
            {
                string QueryString = "";
                if (QueryParameters != null)
                {
                    foreach (var item in QueryParameters)
                        QueryString += "&" + item.Item1 + "=" + item.Item2;
                    QueryString = QueryString.Substring(1);
                }
                System.Web.HttpContext.Current.Response.Redirect(JWebManager.GenerateControlURL(SUID) + (QueryString != "" ? "&" + QueryString : ""));
            }
        }
        public static string LoadClientControl(string SUID, string ControlPath, string Name, List<Tuple<string, string>> QueryParameters, WebClassLibrary.WindowTarget Target,
          string onClientCloseFunction,  bool isModal = true, bool isMaximized = true, bool Closeable = true, int Width = 0, int Height = 0, bool isRestricted = false)
        {
            // Set Control Type and Control Path in Session using SUID
            JWebManager.SetControlType(JDomains.JControls.JUserControl, SUID, ControlPath);
            if (Target == WindowTarget.NewWindow)
            {
                // Create new window using SUID
                ExtendedJWindow window = new ExtendedJWindow(SUID, Name, isModal);
                window.NavigateURL = JWebManager.GenerateControlURL(SUID);
                if (Width > 0) window.Width = Width;
                if (Height > 0) window.Height = Height;
                window.QueryParameters = QueryParameters;
                window.isModal = isModal;
                window.isMaximized = isMaximized;
                window.WindowOptions |= Telerik.Web.UI.WindowBehaviors.Maximize;
                return WebClassLibrary.JWebManager.GenerateClientWindow(window.Generate(onClientCloseFunction), isRestricted);
            }
            else if (Target == WindowTarget.CurrentWindow)
            {
                //string QueryString = "";
                //if (QueryParameters != null)
                //{
                //    foreach (var item in QueryParameters)
                //        QueryString += "&" + item.Item1 + "=" + item.Item2;
                //    QueryString = QueryString.Substring(1);
                //}
                //System.Web.HttpContext.Current.Response.Redirect(JWebManager.GenerateControlURL(SUID) + (QueryString != "" ? "?" + QueryString : ""));
            }
            return "";
        }

        public static string LoadClientControl(string SUID, string ControlPath, string Name, List<Tuple<string, string>> QueryParameters, WebClassLibrary.WindowTarget Target,
          string onClientCloseFunction, string onClientShowFunction, bool isModal = true, bool isMaximized = true, bool Closeable = true, int Width = 0, int Height = 0, bool isRestricted = false)
        {
            // Set Control Type and Control Path in Session using SUID
            JWebManager.SetControlType(JDomains.JControls.JUserControl, SUID, ControlPath);
            if (Target == WindowTarget.NewWindow)
            {
                // Create new window using SUID
                ExtendedJWindow window = new ExtendedJWindow(SUID, Name, isModal);
                window.NavigateURL = JWebManager.GenerateControlURL(SUID);
                if (Width > 0) window.Width = Width;
                if (Height > 0) window.Height = Height;
                window.QueryParameters = QueryParameters;
                window.isModal = isModal;
                window.isMaximized = isMaximized;
                window.WindowOptions |= Telerik.Web.UI.WindowBehaviors.Maximize;
                return WebClassLibrary.JWebManager.GenerateClientWindow(window.Generate(onClientCloseFunction, onClientShowFunction), isRestricted);
            }
            else if (Target == WindowTarget.CurrentWindow)
            {
                //string QueryString = "";
                //if (QueryParameters != null)
                //{
                //    foreach (var item in QueryParameters)
                //        QueryString += "&" + item.Item1 + "=" + item.Item2;
                //    QueryString = QueryString.Substring(1);
                //}
                //System.Web.HttpContext.Current.Response.Redirect(JWebManager.GenerateControlURL(SUID) + (QueryString != "" ? "?" + QueryString : ""));
            }
            return "";
        }
    }
}
