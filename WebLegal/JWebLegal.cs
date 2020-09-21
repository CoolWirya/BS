using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebLegal
{
	public class JWebLegal
	{
		public const string _ConstClassName = "WebLegal.JWebLegal";

		public List<JNode> GetNodes()
		{
			string _WebBaseDefineConstClassName = "WebLegal.JWebLegal";

			List<JNode> nodes = new List<JNode>();
			//nodes.Add(new JNode(null, "اطلاعات پایه", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode>() {
			//	new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JNewLand", null, new List<object>() { }) }, "New Land", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null),
			//	new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JAddUsage", null, new List<object>() { }) }, "Add Usage", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null),
			//	new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JEstateType", null, new List<object>() { }) }, "EstateType", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null),
			//	new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JDocumentType", null, new List<object>() { }) }, "DocumentType", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null)
			//}));
			nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JSubjectContract", null, new List<object>() { }) }, "SubjectContract", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null));
			return nodes;
		}

		//#region Usage
		//public string _JAddUsage()
		//{
		//	WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
		//	jGridView.SQL = "select * from estUsageGround";
		//	jGridView.Title = "AddUsage";
		//	jGridView.ClassName = "AddUsage";
		//	jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
		//	jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JAddUsageNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
		//	jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JAddUsageUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
		//	jGridView.Actions = new List<JActionsInfo>();
		//	jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._JAddUsageUpdate", null, null));
		//	return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
		//}

		//public string _JAddUsageNew()
		//{
		//	return WebClassLibrary.JWebManager.LoadClientControl("AddUsage"
		//		, "~/WebEstate/Land/Ground/Usage/JAddUsageControl.ascx"
		//		, ClassLibrary.JLanguages._Text("AddUsage")
		//		, null
		//		, WindowTarget.NewWindow
		//		, true, false, true, 600, 400);
		//}

		//public string _JAddUsageUpdate(string code)
		//{
		//	return WebClassLibrary.JWebManager.LoadClientControl("AddUsage"
		//		, "~/WebEstate/Land/Ground/Usage/JAddUsageControl.ascx"
		//		, ClassLibrary.JLanguages._Text("AddUsage")
		//		, new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
		//		, WindowTarget.NewWindow
		//		, true, false, true, 600, 400);
		//}
		//#endregion

		//#region Land
		//public string _JNewLand()
		//{
		//	WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
		//	jGridView.SQL = "select * from estLand";
		//	jGridView.Title = "NewLand";
		//	jGridView.ClassName = "NewLand";
		//	jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
		//	jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JNewLandNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
		//	jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JNewLandUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
		//	jGridView.Actions = new List<JActionsInfo>();
		//	jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._JNewLandUpdate", null, null));
		//	return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
		//}

		//public string _JNewLandNew()
		//{
		//	return WebClassLibrary.JWebManager.LoadClientControl("NewLand"
		//		, "~/WebEstate/Land/Land/JNewLandsControl.ascx"
		//		, ClassLibrary.JLanguages._Text("NewLand")
		//		, null
		//		, WindowTarget.NewWindow
		//		, true, false, true, 600, 400);
		//}

		//public string _JNewLandUpdate(string code)
		//{
		//	return WebClassLibrary.JWebManager.LoadClientControl("NewLand"
		//		, "~/WebEstate/Land/Land/JNewLandsControl.ascx"
		//		, ClassLibrary.JLanguages._Text("NewLand")
		//		, new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
		//		, WindowTarget.NewWindow
		//		, true, false, true, 600, 400);
		//}
		//#endregion

		#region SubjectContract
		public string _JSubjectContract()
		{
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
			jGridView.SQL = "select * from estGround";
			jGridView.Title = "SubjectContract";
			jGridView.ClassName = "SubjectContract";
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JSubjectContractNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JSubjectContractUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
			jGridView.Actions = new List<JActionsInfo>();
			jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "_JSubjectContractUpdate", null, null));
			return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
		}

		public string _JSubjectContractNew()
		{
			return WebClassLibrary.JWebManager.LoadClientControl("SubjectContract"
				, "~/WebLegal/Contract/Forms/SubjectContract/SubjectControl.ascx"
				, ClassLibrary.JLanguages._Text("SubjectContract")
				, null
				, WindowTarget.NewWindow
				, true, true, true, 600, 400);
		}

		public string _JSubjectContractUpdate(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("SubjectContract"
				, "~/WebLegal/Contract/Forms/SubjectContract/SubjectControl.ascx"
				, ClassLibrary.JLanguages._Text("SubjectContract")
				, new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
				, WindowTarget.NewWindow
				, true, true, true, 600, 400);
		}
		#endregion
	}
}