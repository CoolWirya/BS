using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebClassLibrary
{
    public class JWebManager
    {
        #region Constant Variables
        public const int SUID_Timeout = 30;
        #endregion

        public static void Configure()
        {
            // localhost : fzebdrba2XccL3dUqSnjYg==
            //if (ClassLibrary.JEnryption.EncryptStr(System.Web.HttpContext.Current.Request.Url.Host.Split(':').First(), "") != "fzebdrba2XccL3dUqSnjYg==")
            //    Redirect("Error.aspx?err=9999");
        }

        public static System.Web.UI.Page CurrentPage
        {
            get
            {
                return (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            }
        }

        public static void Redirect(string URL)
        {
            try
            {
                CurrentPage.Response.Redirect(URL);
            }
            catch
            { }
        }

        public static void AddWindow(Telerik.Web.UI.RadWindow radWindow, bool isRestricted = false, string ContentControlID = "ContentZone")
        {
            try
            {
                if (isRestricted)
                    radWindow.RestrictionZoneID = ContentControlID;
                //radWindow.InitialBehaviors = Telerik.Web.UI.WindowBehaviors.Maximize;
                CurrentPage.PreRender += (sender, args) => CurrentPage.FindControl(ContentControlID).Controls.Add(radWindow);
            }
            catch
            {

            }
        }

        public static string GenerateClientWindow(Telerik.Web.UI.RadWindow radWindow, bool isRestricted = false)
        {
            string splitter = ":|:";
            // 0 , 1
            string result = radWindow.NavigateUrl + splitter + ClassLibrary.JLanguages._Text(radWindow.Title) + splitter;
            // 2
            if (isRestricted)
                result += "isRestricted=true";
            else
                result += "isRestricted=false";
            result += splitter;

            // 3
            if (radWindow.Modal)
                result += "isModal=true";
            else
                result += "isModal=false";
            result += splitter;
            //radWindow.InitialBehaviors = Telerik.Web.UI.WindowBehaviors.Maximize;
            // 4 , 5
            if (radWindow.Width.Value == 0)
                result += "" + splitter + "";
            else
                result += radWindow.Width + splitter + radWindow.Height;

            return result;

        }

        public static void AddToContentZone(System.Web.UI.Control control)
        {
            CurrentPage.PreRender += (sender, args) => CurrentPage.FindControl("ContentZone").Controls.Add(control);
        }

        public static void LoadControl(string SUID, string ControlPath, string Name, List<Tuple<string, string>> QueryParameters, WindowTarget Target, bool isModal = true, bool isMaximized = true, bool Closeable = true, int Width = 0, int Height = 0, bool isRestricted = false, string ContentControlID = "")
        {
            // Set Control Type and Control Path in Session using SUID
            JWebManager.SetControlType(JDomains.JControls.JUserControl, SUID, ControlPath);
            if (Target == WindowTarget.NewWindow)
            {
                // Create new window using SUID
                WebControllers.MainControls.JWindow window = new WebControllers.MainControls.JWindow(SUID, Name, isModal);
                window.NavigateURL = JWebManager.GenerateControlURL(SUID);
                if (Width > 0) window.Width = Width;
                if (Height > 0) window.Height = Height;
                window.QueryParameters = QueryParameters;
                window.isModal = isModal;
                window.isMaximized = isMaximized;
                window.WindowOptions |= Telerik.Web.UI.WindowBehaviors.Maximize;
                if (ContentControlID == "")
                    WebClassLibrary.JWebManager.AddWindow(window.Generate(), isRestricted);
                else
                    WebClassLibrary.JWebManager.AddWindow(window.Generate(), isRestricted, ContentControlID);

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

        public static string LoadClientControl(string SUID, string ControlPath, string Name, List<Tuple<string, string>> QueryParameters, WindowTarget Target, bool isModal = true, bool isMaximized = true, bool Closeable = true, int Width = 0, int Height = 0, bool isRestricted = false)
        {
            // Set Control Type and Control Path in Session using SUID
            JWebManager.SetControlType(JDomains.JControls.JUserControl, SUID, ControlPath);
            if (Target == WindowTarget.NewWindow)
            {
                // Create new window using SUID
                WebControllers.MainControls.JWindow window = new WebControllers.MainControls.JWindow(SUID, Name, isModal);
                window.NavigateURL = JWebManager.GenerateControlURL(SUID);
                if (Width > 0) window.Width = Width;
                if (Height > 0) window.Height = Height;
                window.QueryParameters = QueryParameters;
                window.isModal = isModal;
                window.isMaximized = isMaximized;
                window.WindowOptions |= Telerik.Web.UI.WindowBehaviors.Maximize;
                return WebClassLibrary.JWebManager.GenerateClientWindow(window.Generate(), isRestricted);
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

        public static object GetQueryString(string key)
        {
            return System.Web.HttpContext.Current.Request.QueryString[key] ?? "";
        }

        public static string GetSUID()
        {
            return GetQueryString("SUID") == null ? "" : GetQueryString("SUID").ToString();
        }

        public static JDomains.JControls GetControlType(string SUID = "")
        {
            try
            {
                if (SUID == "") SUID = GetSUID();
                return (SUID == null || SUID == "") ? JDomains.JControls.None : (JDomains.JControls)SessionManager.Current.Objects.Get("ControlType_" + SUID);
            }
            catch
            {
                return JDomains.JControls.None;
            }
        }

        public static string GetControlPath(string SUID = "")
        {
            if (SUID == "") SUID = GetSUID();
            return GetSUID() == "" ? "" : SessionManager.Current.Objects.Get("ControlPath_" + SUID).ToString();
        }

        public static void SetControlType(JDomains.JControls ControlType, string SUID = "", string ControlPath = "", bool needAuthenticate = true)
        {
            if (SUID == "") SUID = GetSUID();
            SessionManager.Current.Objects.Set("Authentication_" + SUID, needAuthenticate);
            SessionManager.Current.Objects.Set("ControlType_" + SUID, ControlType);
            SessionManager.Current.Objects.Set("ControlPath_" + SUID, ControlPath);
            SessionManager.Current.Objects.Set("Timeout_" + SUID, DateTime.Now);
        }

        public static string GenerateControlURL(string SUID)
        {
            return "~/Controls.aspx?SUID=" + SUID;
        }

        public static string Skin
        {
            get
            {
                return "Metro";
            }
            set
            {
            }
        }

        public static Telerik.Web.UI.RadAjaxManager AjaxManager
        {
            get
            {
                return (Telerik.Web.UI.RadAjaxManager)CurrentPage.FindControl("AjaxManagerProxy1");
                //return Telerik.Web.UI.RadAjaxManager.GetCurrent(CurrentPage);
            }
        }

        public static void AddToAjaxManager(string ajaxControlID, string destControlID, string eventName = "")
        {
            Telerik.Web.UI.AjaxSetting ajaxSetting = new Telerik.Web.UI.AjaxSetting();
            ajaxSetting.AjaxControlID = ajaxControlID;
            if (eventName.Length > 0)
                ajaxSetting.EventName = eventName;
            Telerik.Web.UI.AjaxUpdatedControl updatedControl = new Telerik.Web.UI.AjaxUpdatedControl(destControlID, "AxajLoadingPanel");
            ajaxSetting.UpdatedControls.Add(updatedControl);
            CurrentPage.PreRender += (sender, args) => AjaxManager.AjaxSettings.Add(ajaxSetting);
        }

        public static void AddToAjaxManager(System.Web.UI.Control ajaxControl, System.Web.UI.Control destControl)
        {
            var ralp = CurrentPage.FindControl("AxajLoadingPanel");
            if (ralp == null)
                return;
            CurrentPage.PreRender += (sender, args) => AjaxManager.AjaxSettings.AddAjaxSetting(ajaxControl, destControl, (Telerik.Web.UI.RadAjaxLoadingPanel)ralp);
                //Telerik.Web.UI.RadAjaxManager.GetCurrent(CurrentPage).AjaxSettings.AddAjaxSetting(ajaxControl, destControl, (Telerik.Web.UI.RadAjaxLoadingPanel)ralp);
        }

        public static void CloseWindow()
        {
            CurrentPage.ClientScript.RegisterStartupScript(CurrentPage.GetType(), "Close Dialog", "CloseDialog(null);", true);
        }

        public static void RefreshGrid()
        {
            CurrentPage.ClientScript.RegisterStartupScript(CurrentPage.GetType(), "Refresh Grid", "GetRadWindow().BrowserWindow.RefreshGrid();", true);
        }

        public static void CloseAndRefresh()
        {
			CurrentPage.ClientScript.RegisterStartupScript(CurrentPage.GetType(), "Close And Refresh Grid", "GetRadWindow().BrowserWindow.RefreshGrid();CloseDialog(null);", false);
			//CurrentPage.ClientScript.RegisterStartupScript(CurrentPage.GetType(), "Close And Refresh Grid", "GetRadWindowManager().GetWindows()[0].BrowserWindow.RefreshGrid();CloseDialog(null);", false);
        }

        public static void ReferSuccess()
        {
            CurrentPage.ClientScript.RegisterStartupScript(CurrentPage.GetType(), "Refered Successfully", "GetRadWindow().BrowserWindow.RefreshGrid();CloseDialog(null);", true);
        }

        public static void RedirectClient(string location)
        {
            CurrentPage.ClientScript.RegisterStartupScript(CurrentPage.GetType(), "Change Location", "window.top.location = '" + location + "';", true);
        }

        public static void ShowMessage(string text, MessageType messageType = MessageType.Normal, string width = "300px", string height = "150px")
        {
            //WebControllers.MainControls.ErrorManager.JErrorMassage error = new WebControllers.MainControls.ErrorManager.JErrorMassage();
            //error.ShowMessage(string.Empty, text, string.Empty, messageType);
            //WebClassLibrary.JWebManager.LoadControl("Malfunction"
            //    , "~/WebControllers/MainControls/ErrorManager/JErrorMassage.ascx"
            //    , "هــشدار"
            //    , new List<Tuple<string, string>>() { new Tuple<string, string>
            //        ("message", text) }
            //    , WebClassLibrary.WindowTarget.NewWindow
            //    , true, false, true, 300, 150);
            ////ImageUrl = Request["url"];
            ////MessageText = Request["message"];
            ////MessageDescription = Request["messageDesc"];
            ////ErrorType = WebClassLibrary.MessageType.Error;

			//RunClientScript("Show_Message('" + text + "', '" + messageType.ToString() + "', '" + width + "', '" + height + "');", "Show_Message", false);
			try
			{
				string S = String.Join("<p>", ClassLibrary.JMainFrame.Except.GetAll()).Replace("'", "\'");
				RunClientScript("alert('" + text + "');", "Show_Message", false);
			}
			catch { }
		}

        public static void RunClientScript(string script, string name, bool replaceParams = false)
        {
            RunClientScript(new List<string>() { script }, name, replaceParams);
        }
        public static void RunClientScript(List<string> script, string name, bool replaceParams = false)
        {
            string final_script = "";
            foreach (string item in script)
            {
                final_script += (replaceParams == true ? ReplaceClientScriptParameters(item) : item);
            }
            CurrentPage.PreRender += (sender, args) => CurrentPage.ClientScript.RegisterStartupScript(CurrentPage.GetType(), name, final_script, true);
        }

        public static string ReplaceClientScriptParameters(string script)
        {
            script = script.Replace("{PARENT}", "GetRadWindow().BrowserWindow").Replace("{Parent}", "GetRadWindow().BrowserWindow");
            script = script.Replace("{WINDOW}", "GetRadWindow()").Replace("{Window}", "GetRadWindow()");
            script = script.Replace("{CLOSEWINDOW}", "CloseDialog(null)").Replace("{CloseWindow}", "CloseDialog(null)");
            return script;
        }

        public static string ResolveQueryStringValue(string queryStringValue, string replaceString)
        {
            return queryStringValue.Replace("+", replaceString).Replace("/", replaceString).Replace("&", replaceString);
        }

    }

    public enum WindowTarget
    {
        CurrentWindow,
        NewWindow
    }

    public enum MessageType
    {
        Normal,
        Information,
        Warning,
        Error
    }

}
