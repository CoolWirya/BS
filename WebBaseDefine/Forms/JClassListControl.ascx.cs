using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Domains;
using WebClassLibrary;
using WebControllers.MainControls.Grid;

namespace WebBaseDefine.Forms
{
	public partial class JClassListControl : System.Web.UI.UserControl
	{
        //JGridViewControl gv;

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			//gv = JGridViewControl1 as JGridViewControl;
			//WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(WebBaseDefine.JWebBaseDefine._ConstClassName.Replace(".", "_"));
			//jGridView.ClassName = WebBaseDefine.JWebBaseDefine._ConstClassName.Replace(".", "_") + "_Decision";
			//jGridView.ContextMenuItems = new List<JContextMenuItem>();
			//jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "New", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._DecisionNew", null, null) });
			//jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "Edit", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._DecisionUpdate", null, null) });
			//jGridView.SQL = "select code,classname,sql from PermissionDecision" + (ProjectsDropDownList.SelectedValue != null ? " where parentcode = " + ProjectsDropDownList.SelectedValue : "");
			//jGridView.Title = "Decisions";
			//jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			//jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._DecisionNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			//jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._DecisionUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
			//jGridView.Actions = new List<JActionsInfo>();
			//jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._DecisionUpdate", null, null));

			//DataGridView1.ID = "grid_" + WebBaseDefine.JWebBaseDefine._ConstClassName.Replace(".", "_") + "_classGrid";
			//DataGridView1.PageIndex = 1;
			//DataGridView1.PageSize = 10;
			//DataGridView1.ContextMenu = new List<JComponents.GridContextMenuItem>();
			//DataGridView1.ContextMenu.Add(new JComponents.GridContextMenuItem() { Text = "New", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._ClassNew", null, null) });
			//DataGridView1.ContextMenu.Add(new JComponents.GridContextMenuItem() { Text = "Edit", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._ClassUpdate", null, null) });
			//DataGridView1.Columns = "code,classname,sql";
			//DataGridView1.SQL = "select code,classname,sql from PermissionDefineClass where parentcode = " + SelectedProject;
			//DataGridView1.SUID = WebBaseDefine.JWebBaseDefine._ConstClassName.Replace(".", "_") + "_classGrid";
			//DataGridView1.Bind();
		}
		public string SelectedProject
		{
			get
			{
				if (ViewState["SelectedProject"] == null)
					return "2";// automation
				return ViewState["SelectedProject"].ToString();
			}
			set
			{
				ViewState["SelectedProject"] = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			//IsGroup = bool.Parse(Request["IsGroup"]);
			if (IsPostBack)
				return;
			ProjectsDropDownList.DataSource = JApplication.JApplicationType.GetData();
			ProjectsDropDownList.DataValueField = "value";
			ProjectsDropDownList.DataTextField = "FarsiName";
			ProjectsDropDownList.DataBind();
			ProjectsDropDownList.SelectedValue = JApplication.JApplicationType.Automation.ToString();
			setGrid();
		}

		void setGrid()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = WebBaseDefine.JWebBaseDefine._ConstClassName.Replace(".", "_") + "_Class";
            jGridView.SQL = "select code,classname,sql from PermissionDefineClass where parentcode = " + SelectedProject;
            jGridView.Title = "Classes";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._ClassNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._ClassUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("Decisions", "Decisions", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._Decision", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, WebBaseDefine.JWebBaseDefine._ConstClassName + "._ClassUpdate", null, null));
            jGridView.Bind();
		}

		protected void ProjectsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedProject = ProjectsDropDownList.SelectedValue;
			setGrid();
		}
	}
}