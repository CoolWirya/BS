using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebBusManagement
{
    public class JPrivateBusManager
    {
        public const string _ConstClassName = "WebBusManagement.JPrivateBusManager";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SubsidyDefine", null, new List<object>() { }) }, "SubsidyDefine", _ConstClassName + "._SubsidyDefine", JDomains.Images.MenuImages.Setting, null));
            return nodes;
        }

        public string _SubsidyDefine()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PassengerCardReport"
                            , "~/WebBusManagement/FormsReports/JSubsidyDefine.ascx"
                            , "تنظیمات مربوط به یارانه"
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }
    
    }
}