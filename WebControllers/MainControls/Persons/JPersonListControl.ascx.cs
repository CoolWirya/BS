using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls
{
	public partial class JPersonListControl : System.Web.UI.UserControl
	{
		public bool ShowSelectionButton
		{
			get
			{
				return btnSelect.Visible;
			}
			set
			{
				btnSelect.Visible = value;
			}
		}
		public JPersonList PersonList;
		protected void Page_Load(object sender, EventArgs e)
		{
			Telerik.Web.UI.RadAjaxManager manager = Telerik.Web.UI.RadAjaxManager.GetCurrent(Page);
			//manager.ClientEvents.OnRequestStart = "onRequestStart";
			//manager.ClientEvents.OnResponseEnd = "onResponseEnd";
			manager.AjaxRequest += manager_AjaxRequest;
		}

		void manager_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
		{
			//PersonList = new JPersonList(WebClassLibrary.JWebManager.GetSUID());
			//if (Request.Form["EventType"] == "GridRowDblClick")
			//{
			//    string index = Request.Form["radGridClickedRowIndex"].ToString();
			//    int personCode = Convert.ToInt32(grdPersons.Items[Convert.ToInt32(index)]["Code"].Text);
			//    string personName = grdPersons.Items[Convert.ToInt32(index)]["Name"].Text;
			//    WebClassLibrary.JWebManager.RunClientScript(new List<string>()
			//    {
			//        //"{Parent}.getElementById('" + PersonList.PersonCodeElementID + "').value = '" + personCode + "';",
			//        //"{Parent}.getElementById('" + PersonList.PersonNameElementID + "').value = '" + personName + "';",
			//        "{CloseWindow};"
			//    }, "SendPersonInfo", true);
			//}
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
            grdPersons.DataSource = WebClassLibrary.JWebDataBase.GetDataTable("Select Code, Name from clsAllPerson Where Name like N'%" + txtSearch.Text.Replace("'", "''") + "%' order by Name", true);
            grdPersons.Rebind();
		}

		protected void btnSelect_Click(object sender, EventArgs e)
		{
			PersonList = new JPersonList(WebClassLibrary.JWebManager.GetSUID());
			string index = Request.Form["radGridClickedRowIndex"].ToString();
			if (index == "") return;
			int personCode = Convert.ToInt32(grdPersons.Items[Convert.ToInt32(index)]["Code"].Text);
			string personName = grdPersons.Items[Convert.ToInt32(index)]["Name"].Text;
			if (PersonList.PersonCodeElementID != null && PersonList.PersonNameElementID != null)
				WebClassLibrary.JWebManager.RunClientScript(new List<string>()
                {
                    "{Parent}.document.getElementById('" + PersonList.PersonCodeElementID + "').value = '" + personCode + "';",
                    "{Parent}.document.getElementById('" + PersonList.PersonNameElementID + "').value = '" + personName + "';",
                    "{CloseWindow};"
                }, "SendPersonInfo", true);
			//WebClassLibrary.JWebManager.RunClientScript(new List<string>()
			//	{
			//		//"{Parent}.document.getElementById('" + ControlToSet + "').value = '" + personCode + "';",
			//		"parent.$(\"#"+ControlToSet+"\".val('"+personCode+"');",
			//		"{CloseWindow};"
			//	}, "SendPersonInfo", true);
		}
	}
}