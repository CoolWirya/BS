using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebControllers.MainControls
{
    public class JPersonList : WebClassLibrary.JSessionClass
    {
        private const string SESSION_VARS = "CompanyCode,RealPersonDetailsElementID,PersonNameElementID,RealPersonNameElementID,PersonCodeElementID,personLastNameElementID,"
            + "persoBrthDateElementID,personIDNoElementID,personFatherNameElementID,personNationalNoElementID,Title,LegalPersonDetailsElementID,"
            + "LegalPersonNameElementID,RegNoElementID,SubjectElementID,TypeElementID,RegPlaceElementID,EcoNoElementID,OtherPersonDetailsElementID,TitleElementID,"
            + "PhoneElementID,AddressElementID,DescElementID,MobileElementID";
        public JPersonList()
            : base(SESSION_VARS)
        {
        }
        public JPersonList(string sessionUniqueID)
            : base(SESSION_VARS, sessionUniqueID)
        {
        }
        public int CompanyCode;
        public string RealPersonDetailsElementID;
        public string PersonNameElementID;
        public string RealPersonNameElementID;
        public string PersonCodeElementID;
        public string personLastNameElementID;
        public string persoBrthDateElementID;
        public string personIDNoElementID;
        public string personFatherNameElementID;
        public string personNationalNoElementID;
        public string Title;
        public string LegalPersonDetailsElementID;
        public string LegalPersonNameElementID;
        public string RegNoElementID;
        public string SubjectElementID;
        public string TypeElementID;
        public string RegPlaceElementID;
        public string EcoNoElementID;
        public string OtherPersonDetailsElementID;
        public string TitleElementID;
        public string PhoneElementID;
        public string AddressElementID;
        public string DescElementID;
        public string MobileElementID;

        public JPersonListControl Generate()
        {
            SessionSave();
            JPersonListControl jPersonListControl = (JPersonListControl)WebClassLibrary.JWebManager.CurrentPage.LoadControl("~/WebControllers/MainControls/Persons/JPersonListControl.ascx");
            jPersonListControl.ID = "personList_" + SessionUniqueID;
            jPersonListControl.PersonList = this;
            return jPersonListControl;
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

    public class JPersonLists
    {
        public string GetPersonWindow(string personCodeID, string personNameID)
        {
            JPersonList jPersonList = new JPersonList("PersonSearch");
            jPersonList.PersonCodeElementID = personCodeID;
            jPersonList.PersonNameElementID = personNameID;
            jPersonList.Title = ClassLibrary.JLanguages._Farsi("PersonSearch");
            jPersonList.SessionSave();

            return WebClassLibrary.JWebManager.LoadClientControl("PersonSearch", "~/WebControllers/MainControls/Persons/JPersonListControl.ascx", "PersonSearch", null, WebClassLibrary.WindowTarget.NewWindow, true, false, false, 400, 300);
        }
        public string GetPersonWindowForShare(string CompanyCode, string personCodeID, string RealPersonDetailsID, string RealPersonNameID, string personLastNameID,
            string personBrthDateID, string personIDNoID, string personFatherNameID, string personNationalNoID, string LegalPersonDetailsID, string LegalPersonNameID,
            string RegNoID, string SubjectID, string TypeID, string RegPlaceID, string EcoNoID, string OtherPersonDetailsID, string TitleID, string PhoneID,
            string AddressID, string DescID, string MobileID)
        {
            JPersonList jPersonList = new JPersonList("PersonSearch");
            jPersonList.CompanyCode = Convert.ToInt32(CompanyCode);
            jPersonList.PersonCodeElementID = personCodeID;
            jPersonList.RealPersonDetailsElementID = RealPersonDetailsID;
            jPersonList.RealPersonNameElementID = RealPersonNameID;
            jPersonList.personLastNameElementID = personLastNameID;
            jPersonList.persoBrthDateElementID = personBrthDateID;
            jPersonList.personIDNoElementID = personIDNoID;
            jPersonList.personFatherNameElementID = personFatherNameID;
            jPersonList.personNationalNoElementID = personNationalNoID;
            jPersonList.LegalPersonDetailsElementID = LegalPersonDetailsID;
            jPersonList.LegalPersonNameElementID = LegalPersonNameID;
            jPersonList.RegNoElementID = RegNoID;
            jPersonList.SubjectElementID = SubjectID;
            jPersonList.TypeElementID = TypeID;
            jPersonList.RegPlaceElementID = RegPlaceID;
            jPersonList.EcoNoElementID = EcoNoID;
            jPersonList.OtherPersonDetailsElementID = OtherPersonDetailsID;
            jPersonList.TitleElementID = TitleID;
            jPersonList.PhoneElementID = PhoneID;
            jPersonList.AddressElementID =AddressID;
            jPersonList.DescElementID = DescID;
            jPersonList.MobileElementID = MobileID;
            jPersonList.SessionSave();

            return WebClassLibrary.JWebManager.LoadClientControl("PersonSearch", "~/WebControllers/MainControls/Persons/JPersonListControl.ascx", "PersonSearch", null, WebClassLibrary.WindowTarget.NewWindow, true, false, false, 400, 300);
        }
    }
}