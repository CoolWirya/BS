using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JComponents;
using RealEstate;
using WebClassLibrary;

namespace WebRealEstate.Building.UnitBuild.DefaultOwners
{
	public partial class DefaultOwnersControl : System.Web.UI.UserControl
	{
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			OwnersDGV.ID = "grid_" + WebRealEstate.JWebRealEstate._ConstClassName.Replace(".", "_") + "_DefaultOwners";
			OwnersDGV.PageIndex = 1;
			OwnersDGV.PageSize = 10;
			OwnersDGV.Columns = "Code,PCode,share,name";
			OwnersDGV.SQL = RealEstate.JDefaultOwner.Query + " Where " + ClassLibrary.JPermission.getObjectSql("RealEstate.JDefaultOwner.JDefaultOwner", JRETableNames.DefaultOwners + ".Code");
			OwnersDGV.SUID = WebRealEstate.JWebRealEstate._ConstClassName.Replace(".", "_") + "_DefaultOwners";
			OwnersDGV.Click = new GridEventArgs() { Field = "Code", Control = SelectedOwnerHiddenField.ClientID };
			OwnersDGV.Bind();
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}