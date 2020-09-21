using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebControllers.WebService
{
    /// <summary>
    /// Summary description for Action
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Action : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public object[] RunAction(string actionString, string[] param)
        {
            actionString = WebClassLibrary.JDataManager.DecryptString(actionString);
            ClassLibrary.JAction action = new ClassLibrary.JAction("", actionString, new object[] { param }, null);
            return (object[])action.run();
        }

    }
}
