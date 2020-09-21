using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JComponents;
using WebClassLibrary;

namespace WebBaseDefine.Forms
{
	public partial class JGroupUsersControl : System.Web.UI.UserControl
	{
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			//AllUsersDGV.ID = "grid_" + JWebBaseDefine._ConstClassName.Replace(".", "_") + "_GroupUsers_AllUsers_" + Request["Code"];
			//AllUsersDGV.ClassName = JWebBaseDefine._ConstClassName.Replace(".", "_") + "_GroupUsers_AllUsers";
			//AllUsersDGV.PageIndex = 1;
			//AllUsersDGV.PageSize = 10;
			//AllUsersDGV.Columns = "Code,username,fam,name,lastlogin,Status";
			//AllUsersDGV.SQL = Globals.JUsers.GetWebQuery2() + " where u.code not in (select user_post_code from PermissionGroupUsers where groupcode = " + Request["Code"] + ")";
			//AllUsersDGV.SUID = JWebBaseDefine._ConstClassName.Replace(".", "_") + "_GroupUsers_AllUsers_" + Request["Code"];

			//GroupUsersDGV.ID = "grid_" + JWebBaseDefine._ConstClassName.Replace(".", "_") + "_GroupUsers_GroupUsers_" + Request["Code"];
			//GroupUsersDGV.ClassName = JWebBaseDefine._ConstClassName.Replace(".", "_") + "_GroupUsers_GroupUsers";
			//GroupUsersDGV.PageIndex = 1;
			//GroupUsersDGV.PageSize = 10;
			//GroupUsersDGV.Columns = "Code,username,fam,name,lastlogin,Status";
			//GroupUsersDGV.SQL = Globals.JUsers.GetWebQuery2() + " where u.code in (select user_post_code from PermissionGroupUsers where groupcode = " + Request["Code"] + ")";
			//GroupUsersDGV.SUID = JWebBaseDefine._ConstClassName.Replace(".", "_") + "_GroupUsers_GroupUsers_" + Request["Code"];

			//AllUsersDGV.Actions = new List<JActionsInfo>();
			//AllUsersDGV.Actions.Add(new JActionsInfo("Click", JDomains.JActionEvents.GridItemDblClick, "WebERP.Services.WebBaseDefineService._AddUserToGroup", null, new List<object>() { Request["Code"] }));
			////AllUsersDGV.DoubleClick = new GridEventArgs() { Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebERP.Services.JService._AddUserToGroup", null, new List<object>() { Request["Code"] }), AfterEvent = GridEvent.refreshGrid, AfterEventControls = AllUsersDGV.ClientID + "," + GroupUsersDGV.ClientID };
			//AllUsersDGV.Bind();

			//GroupUsersDGV.Actions = new List<JActionsInfo>();
			//GroupUsersDGV.Actions.Add(new JActionsInfo("Click", JDomains.JActionEvents.GridItemDblClick, "WebERP.Services.WebBaseDefineService._RemoveUserFromGroup", null, new List<object>() { Request["Code"] }));
			////GroupUsersDGV.DoubleClick = new GridEventArgs() { Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebERP.Services.JService._RemoveUserFromGroup", null, new List<object>() { Request["Code"] }), AfterEvent = GridEvent.refreshGrid, AfterEventControls = AllUsersDGV.ClientID + "," + GroupUsersDGV.ClientID };
			//GroupUsersDGV.Bind();
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}