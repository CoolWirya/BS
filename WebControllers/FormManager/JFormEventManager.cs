using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;
using WebControllers.FormManager;


namespace WebControllers.FormManager
{
    public class JFormEventManager
    {
        public Guid GetNewCode(String pClassName, int pObject)
        {
            Guid oguid = Guid.NewGuid();
            return oguid;
        }

        public bool ConnectUserControls(String pClassName, string pUserControlName, int pObject, Guid pGuid)
        {
            Object Out = WebClassLibrary.SessionManager.Current.Session[pGuid.ToString()];
            if (Out == null)
                Out = new List<KeyValuePair<String, int>>();
            List<KeyValuePair<String, int>> T = (List<KeyValuePair<String, int>>)Out;

            if (T.IndexOf(new KeyValuePair<string, int>(pClassName+"%"+pUserControlName, pObject)) < 0)
            {
                T.Add(new KeyValuePair<string, int>(pClassName + "%" + pUserControlName, pObject));
                WebClassLibrary.SessionManager.Current.Session[pGuid.ToString()] = Out;
                return true;
            }
            return false;
        }

        public void save(Guid pGuid, int pCode)
        {
            Object Out = WebClassLibrary.SessionManager.Current.Session[pGuid.ToString()];
            if (Out == null)
                Out = new List<KeyValuePair<String, int>>();
            List<KeyValuePair<String, int>> T = (List<KeyValuePair<String, int>>)Out;
            foreach(KeyValuePair<String, int> m in T)
            {
                ClassLibrary.JAction A = new ClassLibrary.JAction("Run", m.Key.Split('%')[0] + ".saveX", new object[] { m.Key.Split('%')[1], pCode ,m.Value, pGuid }, null);
                A.run();
            }
        }

    }
}