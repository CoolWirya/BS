using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebControllers.MainControls;

namespace WebAVL.Controls.Search
{
    public class JDeviceList: WebClassLibrary.JSessionClass
    {
        private const string SESSION_VARS = "DeviceCode,DeviceImei,DeviceName,Title,MultipleSelection";
        public JDeviceList(): base(SESSION_VARS)
        {
        }
        public JDeviceList(string sessionUniqueID): base(SESSION_VARS, sessionUniqueID)
        {
        }
        public string DeviceCode;
        public string DeviceImei;
        public string DeviceName;
        public string Title;
        public string MultipleSelection;

        public JDeviceListControl Generate()
        {
            SessionSave();
            JDeviceListControl deviceLlistControl = (JDeviceListControl)WebClassLibrary.JWebManager.CurrentPage.LoadControl("~/WebAVL/Controls/Search/JSearchDevice.ascx");
            deviceLlistControl.ID = "deviceSearch" + SessionUniqueID;
            deviceLlistControl.DeviceList = this;
            return deviceLlistControl;
        }

        public Telerik.Web.UI.RadWindow GenerateWindow(bool isMaximized = true)
        {
            SessionSave();
            Telerik.Web.UI.RadWindow radWindow = (new JWindow(SessionUniqueID, Title)).Generate();
            radWindow.NavigateUrl = "Controls.aspx?SUID=" + SessionUniqueID;
            radWindow.Title = ClassLibrary.JLanguages._Text(Title);
            WebClassLibrary.JWebManager.SetControlType(WebClassLibrary.JDomains.JControls.JUserControl, SessionUniqueID);
            if (isMaximized) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Maximize;
            //radWindow.Controls.Add(Generate());
            return radWindow;
        }
    }
    public class JDeviceLists
    {
        public string GetPersonWindow(string deviceImei, string deviceName,string deviceCode,string multipleSelection)
        {
            JDeviceList devicelist = new JDeviceList("JDeviceList");
            devicelist.DeviceImei = deviceImei;
            devicelist.DeviceName = deviceName;
            devicelist.DeviceCode = deviceCode;
            devicelist.MultipleSelection = multipleSelection;
            devicelist.Title = ClassLibrary.JLanguages._Farsi("JDeviceList");
            devicelist.SessionSave();

            return WebClassLibrary.JWebManager.LoadClientControl("JDeviceList", "~/WebAVL/Controls/Search/JDeviceListControl.ascx", "DeviceSearch", null, WebClassLibrary.WindowTarget.NewWindow, true, false, false, 400, 300);
        }
    }
}
