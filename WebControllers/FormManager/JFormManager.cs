using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebControllers.FormManager
{
    public class JFormManager
    {
        public static void ShowForm(int formCode, int ObjectCode, int ValueObjectCode, int ReferCode,string ClassName)
        {
        
            string SUID = "FormManagers";
            WebClassLibrary.JSUIDManager jSUIDManager = new WebClassLibrary.JSUIDManager(SUID);
            jSUIDManager.SetObject("ValueObjectCode", ValueObjectCode);
            jSUIDManager.SetObject("ReferCode", ReferCode);
            jSUIDManager.SetObject("ObjectCode", ObjectCode);
            jSUIDManager.SetObject("FormCode", formCode);
            jSUIDManager.SetObject("TableCode", 0);
            jSUIDManager.SetObject("ClassName", ClassName);
            WebClassLibrary.JWebManager.LoadControl(SUID
                    , "~/WebControllers/FormManager/JFormObjectControl.ascx"
                    , "فرم"
                    ,null
                    , WebClassLibrary.WindowTarget.CurrentWindow
                    , true, false, true, 700, 400);
        }

        public static string ShowClientForm(int ObjectCode, int FormObjectCode, int ReferCode)
        {
            string SUID = "FormManagers";
            WebClassLibrary.JSUIDManager jSUIDManager = new WebClassLibrary.JSUIDManager(SUID);
            jSUIDManager.SetObject("FormObjectCode", FormObjectCode);
            jSUIDManager.SetObject("ReferCode", ReferCode);
            jSUIDManager.SetObject("ObjectCode", ObjectCode);
            return WebClassLibrary.JWebManager.LoadClientControl(SUID
                    , "~/WebControllers/FormManager/JFormObjectControl.ascx"
                    , "فرم"
                    , null
                    , WebClassLibrary.WindowTarget.NewWindow
                    , true, false, true, 600, 350);
        }

        public static string ShowClientFormList(object ClassName, object ObjectCode)
        {
            WebClassLibrary.JSUIDManager jSUIDManager = new WebClassLibrary.JSUIDManager("FormManagers", true);
            jSUIDManager.SetObject("ObjectCode", Convert.ToInt32(ObjectCode));
            jSUIDManager.SetObject("ClassName", ClassName.ToString());
            return WebClassLibrary.JWebManager.LoadClientControl("FormManagers"
                    , "~/WebControllers/FormManager/JFormListControl.ascx"
                    , "فرم ساز"
                    , null
                    , WebClassLibrary.WindowTarget.NewWindow
                    , true, false, true, 600, 350);
        }
    }
}