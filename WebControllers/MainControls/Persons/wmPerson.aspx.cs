using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls.Persons
{
    public partial class wmPerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string GetPersonWindow(string personCodeID, string personNameID)
        {
            JPersonList jPersonList = new JPersonList("PersonSearch");
            jPersonList.PersonCodeElementID = personCodeID;
            jPersonList.PersonNameElementID = personNameID;
            jPersonList.Title = ClassLibrary.JLanguages._Farsi("PersonSearch");
            jPersonList.SessionSave();

            return WebClassLibrary.JWebManager.LoadClientControl("PersonSearch", "~/WebControllers/MainControls/Persons/JPersonListControl.ascx", "PersonSearch", null, WebClassLibrary.WindowTarget.NewWindow, true, false, false, 400, 300);
        }
    }
}