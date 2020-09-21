using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAVL
{
    public class JWebAVL
    {
        public const string _ConstClassName = "WebAVL.JWebAVL";
        // Main Method
        public List<WebClassLibrary.JNode> GetNodes()
        {
            List<WebClassLibrary.JNode> nodes = new List<WebClassLibrary.JNode>();

            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._MainPage", null, new List<object>() { }) }, "MainPage", _ConstClassName + "._MainPage", WebClassLibrary.JDomains.Images.AvlManagementImages.Home_icon, null));

            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._OnlineMap", null, new List<object>() { }) }, "نقشه آنلاین", _ConstClassName + "._OnlineMap", WebClassLibrary.JDomains.Images.AvlManagementImages.Maps_icon, null));
            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._Direction", null, new List<object>() { }) }, "نقشه آفلاین", _ConstClassName + "._Direction", WebClassLibrary.JDomains.Images.AvlManagementImages.app_map_icon, null));
            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._StopReport", null, new List<object>() { }) }, "گزارش توقف", _ConstClassName + "._StopReport", WebClassLibrary.JDomains.Images.AvlManagementImages.gps_icon, null));
            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._MoveReport", null, new List<object>() { }) }, "گزارش حرکت", _ConstClassName + "._MoveReport", WebClassLibrary.JDomains.Images.AvlManagementImages.gps_icon, null));
            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._SpeedReport", null, new List<object>() { }) }, "گزارش سرعت", _ConstClassName + "._SpeedReport", WebClassLibrary.JDomains.Images.AvlManagementImages.gps_icon, null));
            //nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._locationReport", null, new List<object>() { }) }, "گزارش مکان ها", _ConstClassName + "._locationReport", WebClassLibrary.JDomains.Images.AvlManagementImages.gps_icon, null));
            //nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._Area", null, new List<object>() { }) }, "محدوده ها", _ConstClassName + "._Area", WebClassLibrary.JDomains.Images.MenuImages.Item, null));

            return nodes;
        }
        public string _OnlineMap()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OnlineMap"
                           , "~/WebAVL/Forms/GoogleMap.ascx"
                           , "نقشه آنلاین"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350,true);
        }

        public string _Direction()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Direction"
                           , "~/WebAVL/Forms/GoogleMapDirection.ascx"
                           , "نقشه مسیر حرکت"
                           , new List<Tuple<string, string>>() { new Tuple<string, string>("type", "Direction") }
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }
        public string _Area()
        {

            WebControllers.MainControls.Grid.JGridView jGridView =
                new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_Area");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_AreaNORMAL";
            string query = @"SELECT * FROM AVLArea WHERE personCode={0}";
            //+WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            jGridView.Parameters = new object[] { WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode };
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin)
            {
                query = @"SELECT * FROM AVLArea";
                jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Area";
            }
            jGridView.SQL = query;


            jGridView.Title = "Areas";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewArea", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._EditArea", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }
        public string _NewArea(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("NewArea"
                           , "~/WebAVL/Forms/AreaUpdate.ascx"
                           , "محدوده جدید"
                           , null//55555new List<Tuple<string, string>>() { new Tuple<string, string>("type", "Direction") }
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350,true);
        }
        public string _EditArea(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("EditArea"
                           , "~/WebAVL/Forms/AreaUpdate.ascx"
                           , "ویرایش محدوده"
                           , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350,true);
        }

        public string _MainPage()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("MainMPage"
                           , "~/WebAVL/Forms/MainPage.ascx"
                           , "صفحه اصلی"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }
        public string _locationReport()
        {
            WebControllers.MainControls.Grid.JGridView jGridView =
                new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_locationReport");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "LocationReport";
            string query = @"SELECT [Code]
      ,[Battery]
      ,[location]
	  ,	  [DeviceCode]
      ,[ObjectCode]
      ,[lng]
      ,[lat]
      ,[RegisterDateTime]
      ,[Altitude]
      ,[Speed]
      ,[Angle]
      ,[DeviceSendDateTime]
      ,[Charge]
      ,[GPSAnt]
      ,[GSMAnt]
      ,[Version]
      ,[lastAngle]
      ,[lastAltitude]
 FROM AVLCoordinate Where DeviceCode in (select Code from AVLDevice where code in (SELECT ad.Code  FROM AVLJoinDevice ajd inner join AVLDevice ad on (ad.Code =ajd.[parentDeviceCode] or ad.Code=ajd.childDeviceCode )where [childDeviceCode]={0} or [parentDeviceCode]={0})) ";
            AVL.RegisterDevice.JRegisterDevice rd = new AVL.RegisterDevice.JRegisterDevice();
            rd.GetData(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
            jGridView.Parameters = new object[] { rd.Code };
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin)
            {
                //              query = @"SELECT  *
                //FROM [AVLDB].[dbo].[/*/*AVLCoordinate*/*/]  order by Code desc";
                //              jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_LocationReportAdmin";
               query= @"SELECT [Code]
      ,[Battery]
      ,[location]
	  ,	  [DeviceCode]
      ,[ObjectCode]
      ,[lng]
      ,[lat]
      ,[RegisterDateTime]
      ,[Altitude]
      ,[Speed]
      ,[Angle]
      ,[DeviceSendDateTime]
      ,[Charge]
      ,[GPSAnt]
      ,[GSMAnt]
      ,[Version]
      ,[lastAngle]
      ,[lastAltitude]
 FROM AVLCoordinate Where DeviceCode in (Select Code from AVLDevice WHERE personCode={0} or 1=1 )";
                jGridView.ClassName = _ConstClassName.Replace(".", "_") + "LocationReportAdmin";
                jGridView.Parameters = new object[] { WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode };
            }
            jGridView.SQL = query;
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
          jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();


            jGridView.Title = "مکان ها";
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }
        public string _StopReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("StopReport"
                           , "~/WebAVL/Forms/StopReport.ascx"
                           , "گزارش توقف"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }
        public string _SpeedReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SpeedReport"
                           , "~/WebAVL/Forms/SpeedReport.ascx"
                           , "گزارش سرعت"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }
        public string _MoveReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("MoveReport"
                           , "~/WebAVL/Forms/MoveReport.ascx"
                           , "گزارش حرکت"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }


        public string _ShowMarkerOnMap(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("_ShowMarkerOnMap"
                           , "~/WebAVL/Forms/ShowMarker.ascx"
                           , "نمایش مکان"
                           , new List<Tuple<string, string>>() { new Tuple<string, string>("code",code) }
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);

        }
    }
}