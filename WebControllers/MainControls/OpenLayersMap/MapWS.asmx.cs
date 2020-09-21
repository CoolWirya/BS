using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebClassLibrary;

namespace WebControllers.MainControls.OpenLayersMap
{
    /// <summary>
    /// Summary description for MapWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class MapWS : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public object[] MapRequest(string actionString, string[] param)
        {
            //if ((JMainFrame)Context.Session["JMainFrame"] == null || ((JMainFrame)Context.Session["JMainFrame"]).CurrentPersonCode == 0)
            //    return null;
            actionString = ClassLibrary.JEnryption.DecryptStr(actionString, WebClassLibrary.SessionManager.Current.SessionID);
            ClassLibrary.JAction action = new ClassLibrary.JAction("", actionString, new object[] { param }, null);
            return (object[])action.run();
        }
    }
}
