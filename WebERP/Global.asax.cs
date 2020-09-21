using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebERP
{
    public class Global : System.Web.HttpApplication
    {

        private static List<string> _sessionInfo;
        private static readonly object padlock = new object();

        public static List<string> Sessions
        {
            //sss
            get
            {
                lock (padlock)
                {
                    if (_sessionInfo == null)
                    {
                        _sessionInfo = new List<string>();
                    }
                    return _sessionInfo;
                }
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            //Application.Lock();
            //Application.UnLock();
            //// Session State Configuration
            //System.Data.SqlClient.SqlConnectionStringBuilder connection;
            //if (HttpContext.Current.IsDebuggingEnabled)
            //{
            //    connection = (new ClassLibrary.JConnection()).GetConnection("sessionState_debug", 0);
            //}
            //else
            //{
            //    connection = (new ClassLibrary.JConnection()).GetConnection("SessionState", 0);
            //}
            //string configPath = "~/";
            //System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath);
            ////string conString = "data source=" + connection.DataSource + "; user id=" + connection.UserID + ";password=" + connection.Password + ";";
            ////string conString = "data source=" + connection.DataSource + "; Integrated Security=;";
            //string conString = "data source=" + connection.DataSource + "; user id=erp;password=erp!@#;";
            //System.Web.Configuration.SessionStateSection sessionSection;
            //sessionSection = ((System.Web.Configuration.SessionStateSection)config.GetSection("system.web/sessionState"));
            //if (connection.DataSource != null && connection.DataSource != "")
            //{
            //    if (sessionSection.SqlConnectionString != conString)
            //    {
            //        sessionSection.Mode = System.Web.SessionState.SessionStateMode.SQLServer;
            //        sessionSection.SqlConnectionString = conString;
            //        sessionSection.AllowCustomSqlDatabase = false;
            //        sessionSection.RegenerateExpiredSessionId = false;
            //        sessionSection.Cookieless = System.Web.HttpCookieMode.UseCookies;
            //        config.Save();
            //    }
            //}
            //else if (sessionSection.Mode != SessionStateMode.InProc)
            //{
            //    sessionSection.Mode = SessionStateMode.InProc;
            //    config.Save();
            //}
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Application.Lock();
            //Sessions.Add(HttpContext.Current.Session.SessionID);
            //Application.UnLock();
        }

        private void DropCreatedViews(Dictionary<string, string> views)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                foreach (string item in views.Keys)
                {
                    DB.setQuery("DROP VIEW v" + views[item] + "Temp");
                    DB.Query_Execute();
                }
            }
            catch
            {
            }
            finally
            {
                DB.Dispose();
            }
        }

        protected void Session_End(object sender, EventArgs e)
		{
			//Application.Lock();
			//Sessions.Remove(HttpContext.Current.Session.SessionID);
			//Application.UnLock();
            DropCreatedViews(Session["ViewsList"] as Dictionary<string, string>);
			DropSessionDataBase();
		}


        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

		private void DropSessionDataBase()
		{
			foreach (string key in Session.Keys)
			{
				if(Session[key] is ClassLibrary.JDataBase)
					try
					{
						(Session[key] as ClassLibrary.JDataBase).Dispose();
					}
					catch
					{
					}
			}
		}
    }
}