using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ClassLibrary;
using Globals.Property;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using WebControllers.FormManager;
using WebClassLibrary;
namespace WebERP.Services
{
    /// <summary>
    /// Summary description for UserControllerActionService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class UserControllerActionService : System.Web.Services.WebService
    {
        public class FormUserControllerData
        {
            public string Name;
            public int pCode;
            public string ClassName;
            public bool State;
        }


        [WebMethod(EnableSession = true)]

        public bool InsertDataToFormController(int pCode, string UserControllerName, string pClassName, int FormCode)
        {
            WebControllers.FormManager.JFormEventManager eventmgr = new WebControllers.FormManager.JFormEventManager();
            WebClassLibrary.JSUIDManager formSUID = new WebClassLibrary.JSUIDManager("FormManagers");
            pCode = Convert.ToInt32(formSUID.GetObject("pCode"));
            FormCode = Convert.ToInt32(formSUID.GetObject("FormCode"));

            //Create new guid
            eventmgr.GetNewCode(pClassName, pCode);
            Guid nguid = Guid.NewGuid();
            //Guid oguid = Guid.NewGuid();
            //Save Data

            //
            eventmgr.ConnectUserControls(pClassName, UserControllerName, pCode, nguid);


            eventmgr.save(nguid, pCode);
            return true;

        }

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}
    }
}
