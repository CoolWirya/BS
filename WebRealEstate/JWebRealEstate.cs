using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebRealEstate
{
	public class JWebRealEstate
	{
		public const string _ConstClassName = "WebRealEstate.JWebRealEstate";
		// Main Method
		public List<JNode> GetNodes()
		{
			//string _WebBaseDefineConstClassName = "WebBaseDefine.JWebBaseDefine";

			List<JNode> nodes = new List<JNode>();
			nodes.Add(new JNode(null, "تعاریف پایه", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode>
            {
                
					new JNode(new List<JActionsInfo> () { new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName+"._MarketUsage",null,new List<object>() {})},"MarketUsage",_ConstClassName,JDomains.Images.MenuImages.Item,null),
					new JNode(new List<JActionsInfo> () { new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName+"._UnitJobs",null,new List<object>() {})},"UnitJobs",_ConstClassName,JDomains.Images.MenuImages.Item,null),
					new JNode(new List<JActionsInfo> () { new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName+"._UnitBuildType",null,new List<object>() {})},"UnitBuildType",_ConstClassName,JDomains.Images.MenuImages.Item,null),
					new JNode(new List<JActionsInfo> () { new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName+"._JointTypes",null,new List<object>() {})},"JointTypes",_ConstClassName,JDomains.Images.MenuImages.Item,null),
					new JNode(new List<JActionsInfo> () { new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName+"._JointStatus",null,new List<object>() {})},"JointStatus",_ConstClassName,JDomains.Images.MenuImages.Item,null),
					new JNode(new List<JActionsInfo> () { new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName+"._JDoorBuilding",null,new List<object>() {})},"DoorBuilding",_ConstClassName,JDomains.Images.MenuImages.Item,null),
        }));

			nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JMarkets", null, new List<object>() { }) }, "Markets", _ConstClassName, JDomains.Images.MenuImages.Item, null));
			nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JUnitBuild", null, new List<object>() { }) }, "UnitBuild", _ConstClassName, JDomains.Images.MenuImages.Item, null));
			nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JDefaultOwners ", null, new List<object>() { }) }, "DefaultOwners", _ConstClassName, JDomains.Images.MenuImages.Item, null));

			return nodes;
		}

		#region Defines

		public string _MarketUsage()
		{
			return WebClassLibrary.JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(ClassLibrary.JBaseDefine.MarketUsage, "MarketUsage").GenerateWindow(false, false, false), true);
		}

		public string _UnitJobs()
		{
			return WebClassLibrary.JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(ClassLibrary.JBaseDefine.UnitJobs, "UnitJobs").GenerateWindow(false, false, false), true);
		}

		public string _UnitBuildType()
		{
			return WebClassLibrary.JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(ClassLibrary.JBaseDefine.UnitTypes, "UnitBuildType").GenerateWindow(false, false, false), true);
		}

		public string _JointStatus()
		{
			return WebClassLibrary.JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(RealEstate.JRealStatesBaseDefines.EnviromentStatus, "JointStatus").GenerateWindow(false, false, false), true);
		}

		public string _JDoorBuilding()
		{
			return WebClassLibrary.JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(RealEstate.JRealStatesBaseDefines.DoorBuilding, "JDoorBuilding").GenerateWindow(false, false, false), true);
		}

		#endregion

		#region Market
		public string _JMarkets()
		{
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
			jGridView.SQL = "SELECT Code,name,bcode From [subdefine] WHERE [bcode] =" + ClassLibrary.JBaseDefine.MarketUsage;
			jGridView.Title = "MarketUsage";
			jGridView.ClassName = "MarketUsage";
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JMarketsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JMarketsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
			jGridView.Actions = new List<JActionsInfo>();
			jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._JMarketsUpdate", null, null));
			return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
		}

		public string _MarketsNew()
		{
			return WebClassLibrary.JWebManager.LoadClientControl("Markets"
				, "~/WebEstate/Land/Ground/Usage/JAddUsageControl.ascx"
				, ClassLibrary.JLanguages._Text("Add Markets")
				, null
				, WindowTarget.NewWindow
				, true, false, true, 600, 400);
		}

		public string _MarketsUpdate(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("Markets"
				, "~/WebEstate/Land/Ground/Usage/JAddUsageControl.ascx"
				, ClassLibrary.JLanguages._Text("Edit Market")
				, new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
				, WindowTarget.NewWindow
				, true, false, true, 600, 400);
		}
		#endregion

		#region JointTypes
		public string _JointTypes()
		{
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
			jGridView.SQL = "SELECT * FROM ReJointTable WHERE " + ClassLibrary.JPermission.getObjectSql("RealEstate.JJoints.GetDataTable", "ReJointTable.Code");
			jGridView.Title = "JointTypes";
			jGridView.ClassName = "JointTypes";
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JointTypesNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JointTypesUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
			jGridView.Actions = new List<JActionsInfo>();
			jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._JointTypesUpdate", null, null));
			return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
		}
		public string _JointTypesNew()
		{
			return WebClassLibrary.JWebManager.LoadClientControl("JointTypes"
				, "~/WebRealEstate/Building/Joint/JointFormControl.ascx"
				, ClassLibrary.JLanguages._Text("AddJointType")
				, null
				, WindowTarget.NewWindow
				, true, false, true, 600, 400);
		}

		public string _JointTypesUpdate(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("JointTypes"
				, "~/WebRealEstate/Building/Joint/JointFormControl.ascx"
				, ClassLibrary.JLanguages._Text("EditJointType")
				, new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
				, WindowTarget.NewWindow
				, true, false, true, 600, 400);
		}
		#endregion

		#region Default Owners
		//public string _JDefaultOwners()
		//{
		//	WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
		//	jGridView.SQL = "SELECT * FROM ReJointTable WHERE " + ClassLibrary.JPermission.getObjectSql("RealEstate.JJoints.GetDataTable", "ReJointTable.Code");
		//	jGridView.Title = "JointTypes";
		//	jGridView.ClassName = "JointTypes";
		//	jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
		//	jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JointTypesNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
		//	jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JointTypesUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
		//	jGridView.Actions = new List<JActionsInfo>();
		//	jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._JointTypesUpdate", null, null));
		//	return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
		//}
		public string _JDefaultOwners()//New()
		{
			return WebClassLibrary.JWebManager.LoadClientControl("DefaultOwners"
				, "~/WebRealEstate/Building/UnitBuild/DefaultOwners/DefaultOwnersControl.ascx"
				, ClassLibrary.JLanguages._Text("DefaultOwners")
				, null
				, WindowTarget.NewWindow
				, true, false, true, 600, 400);
		}

		//public string _JDefaultOwnersUpdate(string code)
		//{
		//	return WebClassLibrary.JWebManager.LoadClientControl("JointTypes"
		//		, "~/WebRealEstate/Building/Joint/JointFormControl.ascx"
		//		, ClassLibrary.JLanguages._Text("EditJointType")
		//		, new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
		//		, WindowTarget.NewWindow
		//		, true, false, true, 600, 400);
		//}
		#endregion
	}
}