using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebControllers.MainControls
{
    public class JCustomListSelector:WebClassLibrary.JSessionClass
    {
        private const string SESSION_VARS = "TitleElementID,CodeElementID,Title,SQL,SearchFields";
        public JCustomListSelector()
            : base(SESSION_VARS)
        {
        }
        public JCustomListSelector(string sessionUniqueID)
            : base(SESSION_VARS, sessionUniqueID)
        {
        }

        public string SQL;
        public string TitleElementID;
        public string CodeElementID;
        public string Title;
        public string SearchFields;

        public JCustomListViewControl Generate()
        {
            SessionSave();
            JCustomListViewControl jCustomListViewControl = (JCustomListViewControl)WebClassLibrary.JWebManager.CurrentPage.LoadControl("~/WebControllers/MainControls/CustomListSelector/JCustomListViewControl.ascx");
            jCustomListViewControl.ID = "customList" + SessionUniqueID;
            jCustomListViewControl.CustomListSelector = this;
            return jCustomListViewControl;
        }

        public Telerik.Web.UI.RadWindow GenerateWindow(bool isMaximized = true)
        {
            SessionSave();
            Telerik.Web.UI.RadWindow radWindow = (new JWindow(SessionUniqueID, Title)).Generate();
            radWindow.NavigateUrl = "Controls.aspx?SUID=" + SessionUniqueID;
            radWindow.Title = ClassLibrary.JLanguages._Text(Title);
            WebClassLibrary.JWebManager.SetControlType(WebClassLibrary.JDomains.JControls.JUserControl, SessionUniqueID);
            if (isMaximized) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Maximize;
            radWindow.Controls.Add(Generate());
            return radWindow;
        }
}
}