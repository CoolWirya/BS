using Globals.Property;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;
using WebClassLibrary;
using WebControllers.MainControls;

namespace WebControllers.FormManager
{
    public class JFormProperty //: WebClassLibrary.JSessionClass
    {
        string _className;
        string _title;
        public JProperty Property { get; set; }
        public event EventHandler OnClose;
        public JFormProperty(string className, string title)
        //: base("", className)
        {
            _className = className;
            _title = title;
        }
        private JFormPropertyControl Generate()
        {
            //SessionSave();
            JFormPropertyControl jPropertyFormControl = (JFormPropertyControl)WebClassLibrary.JWebManager.CurrentPage.LoadControl("~/WebControllers/FormManager/JFormPropertyControl.ascx");
            jPropertyFormControl.ID = "JFPC_" + _className;
            return jPropertyFormControl;
        }

        void jPropertyFormControl_OnClose(object sender, EventArgs e)
        {
            Property = (sender as JFormPropertyControl).Property;
            if (OnClose != null)
                OnClose(this, e);
        }
        public RadWindow GenerateWindow(bool isMaximized = true, bool isClosable = false, bool isModal = false)
        {
            //SessionSave();
            RadWindow radWindow = (new JWindow(_className, _title)).Generate();
            radWindow.NavigateUrl = "Controls.aspx?SUID=" + _className;
            radWindow.Title = ClassLibrary.JLanguages._Text(_title);
            WebClassLibrary.JWebManager.SetControlType(WebClassLibrary.JDomains.JControls.JUserControl, _className);
            if (isMaximized) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Maximize;
            if (isClosable) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Close;
            radWindow.Modal = isModal;
            radWindow.Controls.Add(Generate());
            return radWindow;
        }
    }
}