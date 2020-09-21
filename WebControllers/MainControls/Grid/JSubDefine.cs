using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebControllers.MainControls.Grid
{
    public class JSubDefine
    {
        public const string _ConstClassName = "WebControllers.MainControls.Grid.JSubDefine";

		public static JGridView GetSubDefineGrid(int defineCode, string Title)
		{
			string uid = _ConstClassName.Replace(".", "_");
			WebClassLibrary.SessionManager.Current.Objects.Set("__subdefine_" + uid, defineCode);
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(uid);
            jGridView.ClassName = uid + "__" + defineCode;
			jGridView.SQL = "Select Code, Name, bcode From subdefine Where bcode=" + defineCode;
			jGridView.HiddenColumns = "bcode";
			jGridView.Title = Title;
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SubDefineNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SubDefineUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
			jGridView.Actions = new List<JActionsInfo>();
			//jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
			jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._SubDefineUpdate", null, null));
			return jGridView;
		}

        public string _SubDefineNew()
        {
            return _SubDefineNew(null);
        }
        public string _SubDefineNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SubDefineNew"
                , "~/WebControllers/MainControls/Grid/JSubDefineUpdateControl.ascx"
                , "جدید"
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 200);
        }
        public string _SubDefineUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SubDefineUpdate"
                , "~/WebControllers/MainControls/Grid/JSubDefineUpdateControl.ascx"
                , "ویرایش"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 200);
        }
    }
}