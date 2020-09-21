using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;


namespace WebBusManagement
{
    public class JBusBaseNet
    {

        public const string _ConstClassName = "WebBusManagement.JBusBaseNet";
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DefineGroupNetType", null, new List<object>() { }) }, "DefineGroupNetType", _ConstClassName + "._DefineGroupNetType", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DefinNetDefine", null, new List<object>() { }) }, "DefinNetDefine", _ConstClassName + "._DefinNetDefine", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BaseNetDefine", null, new List<object>() { }) }, "BaseNetDefine", _ConstClassName + "._BaseNetDefine", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Report", null, new List<object>() { }) }, "Report", _ConstClassName + "._Report", JDomains.Images.MenuImages.Item, null));
            return nodes;
        }

        public string _DefineGroupNetType()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(ClassLibrary.JBaseDefine.GroupNetType, "GroupNetType").GenerateWindow(false, false, false), true);
        }

        #region BaseNetDefine
        public string _BaseNetDefine()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_BaseNetDefine";
            jGridView.SQL = @"select Code,(select BusNumber from AUTBus where code=BusCode) BusNumber,DateEvent,(select DefineName from AUTNetDefine where code=DefineCode) Define,StartTime,EndTime,(select Name from AUTBusEventPlace where code= PlaceCode) Place from AUTNetEvent";
            jGridView.PageOrderByField = " Code desc";
            jGridView.Title = "BaseNetDefine";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BaseNetDefineNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BaseNetDefineUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._BaseNetDefineUpdate", null, null));

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _BaseNetDefineNew()
        {
            return _BaseNetDefineNew(null);
        }

        public string _BaseNetDefineNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InsertBusBaseNetNew"
                 , "~/WebBusManagement/FormsBaseNet/JBaseNetDefineUpdateControl.ascx"
                , "ثبت نت اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , true, false, true, 0, 0, true);
        }

        public string _BaseNetDefineUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InsertBusBaseNetNew"
                 , "~/WebBusManagement/FormsBaseNet/JBaseNetDefineUpdateControl.ascx"
                , "ثبت نت اتوبوس ها"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 0, 0, true);
        }
        #endregion

        #region _DefinNetDefine
        public string _DefinNetDefine()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_DefinNetDefine";
            jGridView.SQL = @"select Code,DefineName,case when DefineType=1 then N'کیلومتر' else N'زمان(روز)' end Type,DefineValue,(Select Name from subdefine where code=GroupCode) Groups from AUTNetDefine";
            jGridView.PageOrderByField = " Code desc";
            jGridView.Title = "DefinNetDefine";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DefinNetDefineNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DefinNetDefineUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._DefinNetDefineUpdate", null, null));

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _DefinNetDefineNew()
        {
            return _DefinNetDefineNew(null);
        }

        public string _DefinNetDefineNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InsertBusBaseNetNew"
                 , "~/WebBusManagement/FormsBaseNet/JDefineNetDefineUpdateControl.ascx"
                , "ثبت تعاریف نت اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , true, false, true, 0, 0, true);
        }

        public string _DefinNetDefineUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InsertBusBaseNetNew"
                 , "~/WebBusManagement/FormsBaseNet/JDefineNetDefineUpdateControl.ascx"
                , "ثبت تعاریف نت اتوبوس ها"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 0, 0, true);
        }
        #endregion

        public string _Report()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ReportNet"
                 , "~/WebBusManagement/FormsBaseNet/JBusNetStateReportControl.ascx"
                , "گزارش نت اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , true, false, true, 0, 0, true);
        }

    }
}