using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace WebClassLibrary
{
    public class SessionManager
    {
        public class Current
        {
            public class Objects
            {
                public static void Set(string ID, object Value)
                {
                    if (ID == null || ID.Trim() == "") throw new Exception("WebClassLibrary.SessionManager: Variable Name/ID not set.");
                    HttpContext.Current.Session[ID] = Value;
                }
                public static object Get(string ID)
                {
                    try
                    {
                        if (ID == null || ID.Trim() == "") throw new Exception("WebClassLibrary.SessionManager: Variable Name/ID not set.");
                        return HttpContext.Current.Session[ID];
                    }
                    catch
                    {
                        return null;
                    }
                }
                public static void Remove(string ID)
                {
                    HttpContext.Current.Session.Remove(ID);
                }
            }

            public static System.Web.SessionState.HttpSessionState Session
            {
                get
                {
                    return HttpContext.Current.Session;
                }
            }

            private static List<String> getOnlineUsers()
            {
                List<String> activeSessions = new List<String>();
                object obj = typeof(HttpRuntime).GetProperty("CacheInternal", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null, null);
                object[] obj2 = (object[])obj.GetType().GetField("_caches", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(obj);
                for (int i = 0; i < obj2.Length; i++)
                {
                    Hashtable c2 = (Hashtable)obj2[i].GetType().GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(obj2[i]);
                    foreach (DictionaryEntry entry in c2)
                    {
                        object o1 = entry.Value.GetType().GetProperty("Value", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(entry.Value, null);
                        if (o1.GetType().ToString() == "System.Web.SessionState.InProcSessionState")
                        {
                            SessionStateItemCollection sess = (SessionStateItemCollection)o1.GetType().GetField("_sessionItems", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(o1);
                            if (sess != null)
                            {
                                if (sess["loggedInUserId"] != null)
                                {
                                    activeSessions.Add(sess["loggedInUserId"].ToString());
                                }
                            }
                        }
                    }
                }
                return activeSessions;
            }

            public static JMainFrame MainFrame
            {
                get
                {
                    try
                    {

                        if (HttpContext.Current.Session == null) return null;
                        if (HttpContext.Current.Session["JMainFrame"] == null)
                            return null;
                        JMainFrame jMainFrame = (JMainFrame)HttpContext.Current.Session["JMainFrame"];
                        if (jMainFrame != null)
                            return jMainFrame;
                        else
                        {
                            //jMainFrame = (JMainFrame)WebERP.Global.Sessions[0]["JMainFrame"];
                            //if (jMainFrame != null)
                            //	return jMainFrame;
                            jMainFrame = new JMainFrame();
                        }
                        return jMainFrame;
                    }
                    catch
                    {
                        return null;
                    }
                }
                set
                {
                    HttpContext.Current.Session["JMainFrame"] = value;
                }
            }

            public static string SessionID
            {
                get
                {
                    return HttpContext.Current.Session.SessionID;
                }
            }

            public static void Dispose()
            {
                HttpContext.Current.Session.Abandon();
            }

            private static void ReinitializeSessions(SessionItemCollection sic)
            {
                foreach (SessionItem si in sic)
                    HttpContext.Current.Session[si.Key] = si.Value;
            }

            public static bool RebuildSessions()
            {
                WebClassLibrary.SessionItemCollection sic = WebClassLibrary.JSessionParser.ParseSession(Session.SessionID);
                if (sic == null || sic.Count <= 0)
                    return false;
                ReinitializeSessions(sic);
                return true;
            }

        }

        public static int SessionTimeOut
        {
            get
            {
                return HttpContext.Current.Session.Timeout;
            }
            set
            {
                HttpContext.Current.Session.Timeout = value;
            }
        }

    }

    public class JSessionClass
    {
        public JSessionClass()
            : this("")
        {
        }
        public JSessionClass(string fiedsToSave)
            : this(fiedsToSave, "")
        {
            sessionmanager_jsession_fields = fiedsToSave;
        }
        public JSessionClass(string fiedsToSave, string sessionUniqueID)
        {
            sessionmanager_jsession_fields = fiedsToSave;
            SessionUniqueID = sessionUniqueID;
            SessionRetrieve();
        }

        public void SetSessionVars(string fields)
        {
            sessionmanager_jsession_fields = fields;
        }

        private string sessionmanager_jsession_fields;

        public string SessionUniqueID;
        public void SessionSave()
        {
            if (sessionmanager_jsession_fields == null) return;
            if (sessionmanager_jsession_fields == "")
            {
                SessionManager.Current.Objects.Set(SessionUniqueID, this);
                return;
            }
            if (SessionUniqueID == null || SessionUniqueID.Trim() == "") throw new Exception("WebClassLibrary.JSessionClass: SessionUniqueID not set.");
            foreach (string field in sessionmanager_jsession_fields.Split(','))
            {
                System.Reflection.PropertyInfo[] propInfo = this.GetType().GetProperties();
                System.Reflection.FieldInfo[] fieldInfo = this.GetType().GetFields();
                if (propInfo.Where(m => m.Name == field).Count() > 0)
                {
                    object pValue = new object();
                    object propValue = propInfo.Where(m => m.Name == field).First().GetValue(this, null);
                    SessionManager.Current.Objects.Set(SessionUniqueID + "_" + field, propValue);
                }
                else if (fieldInfo.Where(m => m.Name == field).Count() > 0)
                {
                    object pValue = new object();
                    object propValue = fieldInfo.Where(m => m.Name == field).First().GetValue(this);
                    SessionManager.Current.Objects.Set(SessionUniqueID + "_" + field, propValue);
                }
            }
        }
        public void SessionRetrieve()
        {
            if (sessionmanager_jsession_fields == null) return;
            if (sessionmanager_jsession_fields == "")
            {

                //this = (JSessionClass)SessionManager.Current.Objects.Get(SessionUniqueID);
                return;
            }
            System.Reflection.PropertyInfo[] propInfo = this.GetType().GetProperties();
            System.Reflection.FieldInfo[] fieldInfo = this.GetType().GetFields();
            try
            {
                if (SessionUniqueID == null || SessionUniqueID.Trim() == "")
                    throw new Exception("WebClassLibrary.JSessionClass: SessionUniqueID not set.");

                foreach (string field in sessionmanager_jsession_fields.Split(','))
                {
                    if (propInfo.Where(m => m.Name == field).Count() > 0)
                    {
                        System.Reflection.PropertyInfo pInfo = propInfo.Where(m => m.Name == field).First();
                        pInfo.SetValue(this, SessionManager.Current.Objects.Get(SessionUniqueID + "_" + field), null);
                    }
                    else if (fieldInfo.Where(m => m.Name == field).Count() > 0)
                    {
                        System.Reflection.FieldInfo fInfo = fieldInfo.Where(m => m.Name == field).First();
                        fInfo.SetValue(this, SessionManager.Current.Objects.Get(SessionUniqueID + "_" + field));
                    }
                }
            }
            catch { }
        }
        public void SessionRemove()
        {
            if (sessionmanager_jsession_fields == null) return;
            if (SessionUniqueID == null || SessionUniqueID.Trim() == "") throw new Exception("WebClassLibrary.JSessionClass: SessionUniqueID not set.");
            if (sessionmanager_jsession_fields == "")
            {
                SessionManager.Current.Objects.Remove(SessionUniqueID);
                return;
            }
            foreach (string field in sessionmanager_jsession_fields.Split(','))
            {
                SessionManager.Current.Objects.Remove(SessionUniqueID + "_" + field);
            }
        }
    }
}
