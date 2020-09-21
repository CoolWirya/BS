using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebControllers.Automation
{
    public class JAutomationRefer : WebClassLibrary.JSUIDManager
    {
        public const string ReferSUID = "Automation_Refer";

        public string ClassName
        {
            get
            {
                return GetObject("ClassName").ToString();
            }
            set
            {
                SetObject("ClassName", value);
            }
        }
        public int ObjectCode
        {
            get
            {
                return Convert.ToInt32(GetObject("ObjectCode"));
            }
            set
            {
                SetObject("ObjectCode", value);
            }
        }
        public int DynamicClassCode
        {
            get
            {
                return Convert.ToInt32(GetObject("DynamicClassCode"));
            }
            set
            {
                SetObject("DynamicClassCode", value);
            }
        }
        public DataTable PublicDataRow
        {
            get
            {
                return (DataTable)GetObject("PublicDataRow");
            }
            set
            {
                SetObject("PublicDataRow", value);
            }
        }
        public int ParentReferCode
        {
            get
            {
                return Convert.ToInt32(GetObject("ParentReferCode"));
            }
            set
            {
                SetObject("ParentReferCode", value);
            }
        }
        public string Title
        {
            get
            {
                return GetObject("Title").ToString();
            }
            set
            {
                SetObject("Title", value);
            }
        }

        public JAutomationRefer()
            : base(ReferSUID)
        {
        }

        public static void ShowRefer(string className, int dynamicClassCode, int objectCode, DataTable publicDataRow, int parentReferCode, string title)
        {
            JAutomationRefer jAutomationRefer = new JAutomationRefer();
            jAutomationRefer.ClassName = className;
            jAutomationRefer.DynamicClassCode = dynamicClassCode;
            jAutomationRefer.ObjectCode = objectCode;
            jAutomationRefer.PublicDataRow = publicDataRow;
            jAutomationRefer.ParentReferCode = parentReferCode;
            jAutomationRefer.Title = title;

            WebClassLibrary.JWebManager.LoadControl("Refer"
                , "~/WebAutomation/Refer/JReferControl.ascx"
                , "ارجاع"
                , null
                , WebClassLibrary.WindowTarget.NewWindow
                , true, false, true, 600, 350);
        }

        public static void ShowClientRefer(string className, int dynamicClassCode, int objectCode, DataTable publicDataRow, int parentReferCode, string title)
        {
            JAutomationRefer jAutomationRefer = new JAutomationRefer();
            jAutomationRefer.ClassName = className;
            jAutomationRefer.DynamicClassCode = dynamicClassCode;
            jAutomationRefer.ObjectCode = objectCode;
            jAutomationRefer.PublicDataRow = publicDataRow;
            jAutomationRefer.ParentReferCode = parentReferCode;
            jAutomationRefer.Title = title;

            WebClassLibrary.JWebManager.LoadClientControl("Refer"
                , "~/WebAutomation/Refer/JReferControl.ascx"
                , "ارجاع"
                , null
                , WebClassLibrary.WindowTarget.NewWindow
                , true, false, true, 600, 350);
        }

        public static void Dispose()
        {
            WebClassLibrary.JSUIDManager.RemoveSUID(ReferSUID);            
        }
    }
}