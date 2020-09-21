using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using WebClassLibrary;

namespace WebBaseDefine.Forms
{
	public partial class JDecisionListControl : System.Web.UI.UserControl
	{
        //JGridViewControl gv;

		protected void Page_Load(object sender, EventArgs e)
		{
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = WebBaseDefine.JWebBaseDefine._ConstClassName.Replace(".", "_") + "_Decision";
			//gv.GridView.ContextMenuItems = new List<JContextMenuItem>();
			//gv.GridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "New", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._DecisionNew", null, new List<object>() { Request["Code"] }) });
			//gv.GridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "Edit", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._DecisionUpdate", null, new List<object>() { Request["Code"] }) });
            RadGridReport.SQL = "select * from PermissionDecision where PermissionDefineCode = " + Request["Code"];
            RadGridReport.Title = "Decisions";
            RadGridReport.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            RadGridReport.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._DecisionNew", null, new List<object>() { Request["Code"] }), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            RadGridReport.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._DecisionUpdate", null, new List<object>() { Request["Code"] }), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            RadGridReport.Actions = new List<JActionsInfo>();
            RadGridReport.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._DecisionUpdate", null, new List<object>() { Request["Code"] }));
            RadGridReport.Bind();
		}
	}
}