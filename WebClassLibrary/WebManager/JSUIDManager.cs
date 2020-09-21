using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebClassLibrary
{
    public class JSUIDManager
    {
        public string SUID;
        public JSUIDManager(string SUID, bool removeExpiredSUIDs = true)
        {
            this.SUID = SUID;
            if (removeExpiredSUIDs) JSUIDManager.RemoveExpiredSUIDs();
            SessionManager.Current.Objects.Set("Timeout_" + SUID, DateTime.Now);
        }

        public void SetObject(string ID, object Value)
        {
            SessionManager.Current.Objects.Set(JSUIDManager.GetSUIDName(SUID, ID), Value);
        }

        public object GetObject(string ID)
        {
            return SessionManager.Current.Objects.Get(JSUIDManager.GetSUIDName(SUID, ID));
        }

        public void RemoveObject(string ID)
        {
            SessionManager.Current.Objects.Remove(JSUIDManager.GetSUIDName(SUID, ID));
        }

        // Static Methods and Properties

        public static int SUID_Timeout
        {
            get
            {
                return Convert.ToInt32(SessionManager.Current.Objects.Get("SUID_Timeout"));
            }
            set
            {
                SessionManager.Current.Objects.Set("SUID_Timeout", value);
            }
        }

        public static string GetSUIDName(string SUID, string ID)
        {
            return SUID + "_" + ID;
        }

        public static void SetObject(string SUID, string ID, object Value)
        {
            (new JSUIDManager(SUID)).SetObject(ID, Value);
        }

        public static object GetObject(string SUID, string ID)
        {
            return (new JSUIDManager(SUID)).GetObject(ID);
        }

        public static void RemoveObjects(string SUID, string ID)
        {
            (new JSUIDManager(SUID)).RemoveObject(ID);
        }

        public static void RemoveSUID(string SUID)
        {
            for (int i = SessionManager.Current.Session.Keys.Count; i >= 0; i--)
            {
                if (SessionManager.Current.Session.Keys[i].StartsWith(SUID))
                {
                    SessionManager.Current.Session.Remove(SessionManager.Current.Session.Keys[i]);
                }
            }
        }

        public static void RemoveExpiredSUIDs()
        {
            if (SUID_Timeout <= 0) return;
            for (int i = SessionManager.Current.Session.Keys.Count; i >= 0; i--)
            {
                if (SessionManager.Current.Session.Keys[i].StartsWith("Timeout_") && (DateTime.Now - Convert.ToDateTime(SessionManager.Current.Session[SessionManager.Current.Session.Keys[i]])).Seconds > SUID_Timeout)
                {
                    SessionManager.Current.Session.Remove(SessionManager.Current.Session.Keys[i].Split('_')[1]);
                }
            }
        }
    }
}
