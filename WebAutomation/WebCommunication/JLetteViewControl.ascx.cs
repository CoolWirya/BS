using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAutomation.WebCommunication
{
    public partial class JLetterViewControl : System.Web.UI.UserControl
    {
        #region Init

        protected global::WebControllers.ArchiveDocument.JArchiveControl JArchiveControl;
        protected global::WebAutomation.Refer.JReferViewControl JReferViewControl;
        //int int.Parse(hfCode.Value);
        // int ReferCode;
        List<Communication.Letter.JCLetterCopy> arrJcLetterCopy;

        #endregion Init

        #region Events
        ///-------------------------------------------------------------------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rtabLetter.Tabs.FindTabByValue("Info").Selected = true;
                rpageLetter.FindPageViewByID("rpvLetterInfo").Selected = true;
                arrJcLetterCopy = new List<Communication.Letter.JCLetterCopy>();
                ViewState["arrJcLetterCopy"] = arrJcLetterCopy;


                if (!string.IsNullOrEmpty(Request["Code"]))
                    hfCode.Value = Request["Code"];
                else
                    hfCode.Value = "0";

                if (!string.IsNullOrEmpty(Request["ReferCode"]))
                    hfReferCode.Value = Request["ReferCode"];
                else
                    hfReferCode.Value = "0";

                if (!string.IsNullOrEmpty(Request["CurrentPage"]))
                    hfCurrentPage.Value = Request["CurrentPage"];
                else
                    hfCurrentPage.Value = "0";

                #region Set ClassName Title
                //3 then N'داخلی' when 2 then N'وارده' when 1 then N'صادره'
                switch (Request["Type"])
                {
                    case "1"://وارده
                        hfClassName.Value = Communication.JCImportedLetter._ConstClassName;
                        hfTitle.Value = "ارجاع نامه وارده";
                        //commented out by rajaei//pnlCopyReceiver.Visible = false;
                        //commented out by rajaei//pnlSignStatus.Visible = false;
                        pnlDelivery.Visible = false;
                        //pnlContent.Visible = false;
                        ((WebControllers.ArchiveDocument.JArchiveControl)JArchiveControl).CanUploadFile = false;
                        ((WebControllers.ArchiveDocument.JArchiveControl)JArchiveControl).CanDeleteFile = false;
                        break;
                    case "2"://صادره
                        hfClassName.Value = Communication.JCExportedLetter._ConstClassName;
                        hfTitle.Value = "ارجاع نامه صادره";
                        break;
                    case "3"://داخلی
                        hfClassName.Value = Communication.JCLetter._ConstClassName;
                        hfTitle.Value = "ارجاع نامه داخلی";
                        break;
                }
                #endregion  Set ClassName Title

                #region Set Archive Control Setting
                ///-----------------------------------------------------------------------------------------
                JArchiveControl.ClassName = hfClassName.Value;
                JArchiveControl.ObjectCode = int.Parse(hfCode.Value);
                JArchiveControl.LoadArchive();
                ///-----------------------------------------------------------------------------------------
                #endregion Set Archive Control Setting

                #region Set RefCode & Code
                ///-----------------------------------------------------------------------------------------
                if (int.Parse(hfCode.Value) > 0 && int.Parse(hfReferCode.Value) == 0)
                {
                    ///به صلاح دید مهندس زرین
                    ///به علت استفاده از همین کد در نرم افزار ویندوز
                    ///با اینکه منطق اشتباه است و این متد اولین ارجاع را می آورد
                    ///Findrefer حذف نشد
                    hfReferCode.Value = (new Automation.JARefer()).FindRefer(hfClassName.Value, int.Parse(hfCode.Value), 0).ToString();
                }
                if (int.Parse(hfReferCode.Value) > 0 && int.Parse(hfCode.Value) == 0)
                {
                    Automation.JARefer Jref = new Automation.JARefer(int.Parse(hfReferCode.Value));
                    hfCode.Value = (new Automation.JAObject(Jref.object_code).ObjectCode).ToString();
                    if (Jref.receiver_post_code != JMainFrame.CurrentPostCode
                               || Jref.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
                    {
                        btnReturn.Enabled = true;
                    }
                    else
                    {
                        btnReturn.Enabled = false;

                    }
                }

                if (hfCurrentPage.Value != "GetOutbox")
                    btnReturn.Enabled = false;
                else
                    btnReturn.Enabled = true;

                if (int.Parse(hfReferCode.Value) <= 0 || hfCurrentPage.Value == "GetInbox")
                    btnReference.Enabled = true;
                else
                    btnReference.Enabled = false;



                ///-----------------------------------------------------------------------------------------
                #endregion Set RefCode & Code


                if (!this.LetterCheck())
                    btnReference.Enabled = false;
                _SetForm();


            }






            // Communication.JCLetter.CheckPermission
        }
        ///-------------------------------------------------------------------------------------------------------------------------
        protected void btnReference_Click(object sender, EventArgs e)
        {
            Refer();
            btnReference.Enabled = false;
        }
        ///-------------------------------------------------------------------------------------------------------------------------
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (hfReferCode.Value != string.Empty)
            {
                Automation.JARefers.ReturnRefer(int.Parse(hfReferCode.Value));
                WebClassLibrary.JWebManager.CloseAndRefresh();
            }
        }
        ///-------------------------------------------------------------------------------------------------------------------------
        protected void btnParent_Click(object sender, EventArgs e)
        {

        }
        ///-------------------------------------------------------------------------------------------------------------------------
        protected void rtabLetter_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            switch (e.Tab.PageViewID)
            {
                case "rpvLetterInfo":
                    //if (Session["Sign"] != null && (bool)Session["Sign"])
                    //    txtContent.EditModes = Telerik.Web.UI.EditModes.Preview;

                    #region Button Status
                    if (int.Parse(hfReferCode.Value) > 0 && int.Parse(hfCode.Value) == 0)
                    {
                        Automation.JARefer Jref = new Automation.JARefer(int.Parse(hfReferCode.Value));
                        hfCode.Value = (new Automation.JAObject(Jref.object_code).ObjectCode).ToString();
                        if (Jref.receiver_post_code != JMainFrame.CurrentPostCode
                                   || Jref.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
                        {
                            btnReturn.Enabled = true;
                        }
                        else
                        {
                            btnReturn.Enabled = false;
                        }
                    }
                    if (hfCurrentPage.Value != "GetOutbox")
                        btnReturn.Enabled = false;
                    else
                        btnReturn.Enabled = true;

                    if (int.Parse(hfReferCode.Value) <= 0 || hfCurrentPage.Value == "GetInbox")
                        btnReference.Enabled = true;
                    else
                        btnReference.Enabled = false;

                    #endregion Button Status

                    break;
                case "rpvArchive":

                    JArchiveControl.ClassName = Communication.JCImportedLetter._ConstClassName;
                    JArchiveControl.ObjectCode = int.Parse(hfCode.Value);
                    JArchiveControl.LoadArchive();

                    #region Button Status
                    if (int.Parse(hfReferCode.Value) > 0 && int.Parse(hfCode.Value) == 0)
                    {
                        Automation.JARefer Jref = new Automation.JARefer(int.Parse(hfReferCode.Value));
                        hfCode.Value = (new Automation.JAObject(Jref.object_code).ObjectCode).ToString();
                        if (Jref.receiver_post_code != JMainFrame.CurrentPostCode
                                   || Jref.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
                        {
                            btnReturn.Enabled = true;
                        }
                        else
                        {
                            btnReturn.Enabled = false;
                        }
                    }
                    if (hfCurrentPage.Value != "GetOutbox")
                        btnReturn.Enabled = false;
                    else
                        btnReturn.Enabled = true;

                    if (int.Parse(hfReferCode.Value) <= 0 || hfCurrentPage.Value == "GetInbox")
                        btnReference.Enabled = true;
                    else
                        btnReference.Enabled = false;

                    #endregion Button Status

                    break;
                case "rpvRefer":

                    #region Button Status
                    if (int.Parse(hfReferCode.Value) > 0 && int.Parse(hfCode.Value) == 0)
                    {
                        Automation.JARefer Jref = new Automation.JARefer(int.Parse(hfReferCode.Value));
                        hfCode.Value = (new Automation.JAObject(Jref.object_code).ObjectCode).ToString();
                        if (Jref.receiver_post_code != JMainFrame.CurrentPostCode
                                   || Jref.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
                        {
                            btnReturn.Enabled = true;
                        }
                        else
                        {
                            btnReturn.Enabled = false;
                        }
                    }
                    if (hfCurrentPage.Value != "GetOutbox")
                        btnReturn.Enabled = false;
                    else
                        btnReturn.Enabled = true;

                    if (int.Parse(hfReferCode.Value) <= 0 || hfCurrentPage.Value == "GetInbox")
                        btnReference.Enabled = true;
                    else
                        btnReference.Enabled = false;

                    #endregion Button Status
                    JReferViewControl.LoadRefers(new Automation.JARefer(int.Parse(hfReferCode.Value)).object_code);
                    break;
                case "Delivery":

                    #region Button Status
                    if (int.Parse(hfReferCode.Value) > 0 && int.Parse(hfCode.Value) == 0)
                    {
                        Automation.JARefer Jref = new Automation.JARefer(int.Parse(hfReferCode.Value));
                        hfCode.Value = (new Automation.JAObject(Jref.object_code).ObjectCode).ToString();
                        if (Jref.receiver_post_code != JMainFrame.CurrentPostCode
                                   || Jref.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
                        {
                            btnReturn.Enabled = true;
                        }
                        else
                        {
                            btnReturn.Enabled = true;
                        }
                    }
                    if (hfCurrentPage.Value != "GetOutbox")
                        btnReturn.Enabled = false;
                    else
                        btnReturn.Enabled = true;

                    if (int.Parse(hfReferCode.Value) <= 0 || hfCurrentPage.Value == "GetInbox")
                        btnReference.Enabled = true;
                    else
                        btnReference.Enabled = false;

                    #endregion Button Status

                    break;

            }
        }
        ///-------------------------------------------------------------------------------------------------------------------------
        #endregion Events

        #region Grid Events
        ///-------------------------------------------------------------------------------------------------------------------------
        protected void grvCopies_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            arrJcLetterCopy = (List<Communication.Letter.JCLetterCopy>)ViewState["arrJcLetterCopy"];
            //commented out by rajaei//grvCopies.DataSource = arrJcLetterCopy;
        }
        ///-------------------------------------------------------------------------------------------------------------------------
        protected void grvCopies_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        ///-------------------------------------------------------------------------------------------------------------------------
        protected void grvCopies_Load(object sender, EventArgs e)
        {

        }
        ///-------------------------------------------------------------------------------------------------------------------------    
        #endregion Grid Events

        #region Methods
        ///-------------------------------------------------------------------------------------------------------------------------
        // چک می کند که آیا کاربر می تواند نامه جاری را ارجاع بدهد یا خیر.
        private Boolean LetterCheck()
        {
            if (Convert.ToInt32(hfCode.Value) < 0 && Convert.ToInt32(hfReferCode.Value) == 0)
                hfReferCode.Value = (new Automation.JARefer()).FindRefer(hfClassName.Value, int.Parse(hfCode.Value), 0).ToString();

            if (Convert.ToInt32(hfReferCode.Value) > 0)
            {
                Automation.JARefer jaRefer = new Automation.JARefer(Convert.ToInt32(hfReferCode.Value));

                if (jaRefer != null && jaRefer.receiver_post_code != JMainFrame.CurrentPostCode
                   || jaRefer.status == 2)// ClassLibrary.Domains.JAutomation.JReferStatus.Sent) 
                    return false;
                else
                    return true;
            }
            return true;
        }

        public void _SetForm()
        {
            DataTable Dt;
            DataTable dt_chart;
            Communication.JCLetter jcLetter;
            txtYear.Text = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now()).ToString();
            arrJcLetterCopy = (List<Communication.Letter.JCLetterCopy>)ViewState["arrJcLetterCopy"];
            if (int.Parse(hfCode.Value) > 0)
            {
                jcLetter = new Communication.JCLetter(int.Parse(hfCode.Value));

                #region Set Control Properties
                txtSubject.Text = jcLetter.subject;
                txtLetterNo.Text = jcLetter.letter_no;
                cmbSender.Text = jcLetter.sender_full_title.ToString();

                if (jcLetter.urgency != 0)
                {
                    Dt = ClassLibrary.Domains.JGlobal.JUrgency.GetData();
                    Dt.DefaultView.RowFilter = "value =" + jcLetter.urgency.ToString();
                    cmbUrgency.Text = Dt.DefaultView[0]["Farsiname"].ToString();
                }
                if (jcLetter.DeliveryType != 0)
                {
                    Dt = ClassLibrary.Domains.JCommunication.JSendType.GetData();
                    Dt.DefaultView.RowFilter = "value =" + jcLetter.DeliveryType.ToString();
                    cmbDeliveryType.Text = Dt.DefaultView[0]["Farsiname"].ToString();
                }
                System.Globalization.PersianCalendar prC = new System.Globalization.PersianCalendar();
                dteDelivery.Text = prC.ToDateTime(
                      jcLetter.DeliveryDate.Year
                    , jcLetter.DeliveryDate.Month
                    , jcLetter.DeliveryDate.Day
                    , jcLetter.DeliveryDate.Hour
                    , jcLetter.DeliveryDate.Minute
                    , jcLetter.DeliveryDate.Second
                    , jcLetter.DeliveryDate.Millisecond)
                    .ToShortDateString();
                LetterState.Value = jcLetter.letter_status.ToString();
                txtReciever.Text = jcLetter.receiver_full_title;
                txtContent.Text = jcLetter.html;

                #region Build Reference Tree

                if (hfReferCode.Value != "0")
                { 
                    List<Automation.JARefers.ReferInfo> referInfo = (new Automation.JARefers()).GetSpecificReferList(int.Parse(hfReferCode.Value));
                    if (referInfo != null)
                    {
                        string ReferenceTree = "<ul class='square_list_style'><li class='reference'>";
                        ReferenceTree += "<span>" + referInfo[0].SenderName + "</span>";
                        for (int i = 0; i < referInfo.Count; i++)
                        {
                            ReferenceTree += "<span class='refer_date'> (تاریخ ارجاع: " + referInfo[i].Date.ToString("hh:mm:ss yyyy/MM/dd") + ")</span>";
                            ReferenceTree += (referInfo[i].Description.Trim().Length > 0) ? "<br/>   <span class='refer_description'>: " + referInfo[i].Description + "</span>" : "";
                            ReferenceTree += "</li>";
                            ReferenceTree += "<li class='reference " + (referInfo[i].Code == int.Parse(hfReferCode.Value) ? "bold" : "") + "' style=\"margin-right:" + 10 * referInfo[i].Level + "px;color: black\">";
                            ReferenceTree += "<span>" + referInfo[0].RecieverName + "</span>";
                            ReferenceTree += (referInfo[i].isRead == true) ? "<span class = 'view_date'> (تاریخ مشاهده: " + referInfo[i].ReadDate.ToString("hh:mm:ss yyyy/MM/dd") + ")</span>" : "";
                        }
                        ReferenceTree += "</li></ul>";
                        dv_ReferenceTree.InnerHtml = ReferenceTree;
                    }
                }
                #endregion Build Reference Tree

                #region Build arrJcLetterCopy for FristTime
                DataTable _DT = jcLetter.LetterCopies;
                if (_DT != null && _DT.Rows.Count > 0)
                {
                    string CopiesContent = "<ul  class='no_list_style'>";
                    foreach (DataRow Drow in _DT.Rows)
                    {
                        try
                        {
                            CopiesContent += "<li class='copy'>" + Drow["receiver_full_title"].ToString() + ":" + Drow["copy_reason"].ToString() + "</li>";
                        }
                        catch (Exception ex)
                        {
                            JSystem.Except.AddException(ex);
                        }
                    }
                    dv_Copies.InnerHtml = CopiesContent + "</ul>"; 
                }
                #endregion Build arrJcLetterCopy for FristTime

                txtDeliveryPerson.Text = jcLetter.DeliveryPerson;
                if (jcLetter.isSigned)
                {
                    rpvLetterInfo.Enabled = false;
                    Session["Sign"] = true;
                    //commented out by rajaei//lblSignStatus.Text = "نامه در تاریخ " + JDateTime.FarsiDate(jcLetter.SignDate) + " " + jcLetter.SignDate.Hour.ToString("00") + ":" + jcLetter.SignDate.Minute.ToString("00") + ":" + jcLetter.SignDate.Second.ToString("00")
                    //commented out by rajaei//           + " امضا شده است";
                    ((WebControllers.ArchiveDocument.JArchiveControl)JArchiveControl).CanUploadFile = false;
                    ((WebControllers.ArchiveDocument.JArchiveControl)JArchiveControl).CanDeleteFile = false;
                }


                #region  Build arrJcLetterCopy for FristTime
                Communication.Letter.JCLetterCopy jcLetterCopy = new Communication.Letter.JCLetterCopy();
                DataTable dtJcLetterCopy = jcLetterCopy.GetLetterCopies(int.Parse(hfCode.Value));
                if (!IsPostBack)
                {
                    arrJcLetterCopy = new List<Communication.Letter.JCLetterCopy>();
                    foreach (DataRow dr in dtJcLetterCopy.Rows)
                    {
                        if (arrJcLetterCopy.Where(m => m.receiver_user_code == (int)dr["receiver_user_code"]).Count() == 0)
                        {
                            jcLetterCopy = new Communication.Letter.JCLetterCopy();
                            jcLetterCopy.copy_reason = (string)dr["copy_reason"];
                            jcLetterCopy.copy_type = (int)dr["copy_type"];
                            jcLetterCopy.letter_code = (int)dr["letter_code"];
                            jcLetterCopy.receiver_external_code = (int)dr["receiver_external_code"];
                            jcLetterCopy.receiver_full_title = (string)dr["receiver_full_title"];
                            jcLetterCopy.receiver_post_code = (int)dr["receiver_post_code"];
                            jcLetterCopy.receiver_subsidiaries_code = (int)dr["receiver_subsidiaries_code"];
                            jcLetterCopy.receiver_user_code = (int)dr["receiver_user_code"];
                            jcLetterCopy.register_full_title = (string)dr["register_full_title"];
                            jcLetterCopy.register_post_code = (int)dr["register_post_code"];
                            jcLetterCopy.register_user_code = (int)dr["register_user_code"];
                            jcLetterCopy.send_type = (int)dr["send_type"];
                            arrJcLetterCopy.Add(jcLetterCopy);
                        }
                    }
                }
                #endregion Build arrJcLetterCopy for FristTime
                #endregion Set Control Properties

                if (jcLetter.letter_type != 2)
                    rtabLetter.Tabs.FindTabByValue("Delivery").Enabled = false;
                else
                    rtabLetter.Tabs.FindTabByValue("Delivery").Enabled = true;
            }
            ViewState["arrJcLetterCopy"] = arrJcLetterCopy;
            //commented out by rajaei//grvCopies.DataSource = arrJcLetterCopy;
            //commented out by rajaei//grvCopies.DataBind();

            //if (hfReferCode.Value != string.Empty && int.Parse(hfReferCode.Value) > 0)
            //{

            //    refersText1.TotalRefers = true;
            //    refersText1.LoadRefer(_ReferCode);
            //    jRefersTextRTB1.LoadRefer(_ReferCode);

            //    Automation.JARefer jaRefer = new Automation.JARefer(_ReferCode);
            //    if (jaRefer.receiver_post_code != JMainFrame.CurrentPostCode
            //        || jaRefer.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
            //    {
            //        btnSave.Enabled = false;
            //        btnRefer.Enabled = false;
            //    }

            //}
        }
        ///-------------------------------------------------------------------------------------------------------------------------
        private string GetFullDate(DateTime date)
        {
            return date.Hour.ToString("00") + ":" + date.Minute.ToString("00") + "  " + JDateTime.FarsiDate(date).Substring(2);
        }
        ///-------------------------------------------------------------------------------------------------------------------------
        private void Refer()
        {
            Communication.JCLetter Letter = new Communication.JCLetter();

            DataTable _DT = Letter.GetData(int.Parse(hfCode.Value));
            if (_DT.Rows.Count == 1)
            {
                #region Set PostCodes For recivers List By Type Of Letter
                ///---------------------------------------------------------------------
                string _PostCode = "";
                switch (Request["Type"])
                {
                    case "1"://وارده
                        _PostCode = Letter.receiver_post_code.ToString();
                        break;
                    case "2"://صادره

                        break;
                    case "3"://داخلی
                        _PostCode = Letter.receiver_post_code.ToString();
                        break;
                }

                foreach (DataRow _row in Letter.LetterCopies.Rows)
                {
                    if (Convert.ToInt32(_row["receiver_post_code"]) > 0)
                    {
                        if (_PostCode != string.Empty)
                            _PostCode = _PostCode + ";" + _row["receiver_post_code"];
                        else
                            _PostCode = _row["receiver_post_code"].ToString();
                    }
                }
                //    if (_PostCode.Length > 1) _PostCode = _PostCode.Substring(1);
                _DT.Columns.Add("recivers");
                _DT.Rows[0]["recivers"] = _PostCode;
                ///---------------------------------------------------------------------
                #endregion Set PostCodes For recivers List

                WebControllers.Automation.JAutomationRefer.ShowRefer(
                   hfClassName.Value, 0, int.Parse(hfCode.Value)
                              , _DT
                              , int.Parse(hfReferCode.Value), hfTitle.Value);
                //hfReferCode.Value = (new Automation.JARefer()).FindRefer(hfClassName.Value, int.Parse(hfCode.Value), 0).ToString();
            }
        }

        ///-------------------------------------------------------------------------------------------------------------------------
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Communication.JCLetter Letter = new Communication.JCLetter();
            DataTable _DT = Letter.GetData(int.Parse(hfCode.Value));

            ///
            ///
            ///
            /// Query
            ///
            /// مد نظر اضافه شود و دکمه چاپ در بقیه نامه ها هم اضافه شود
            ///
            ///
            ///

            string Query = "Select * From Letters WHERE register_post_code = " + ClassLibrary.JMainFrame.CurrentPostCode.ToString() + " AND Code =" + int.Parse(hfCode.Value);
            //Session[""];
            List<string> REP_SQL = new List<string>();
            REP_SQL.Add(Query);
            Query = "Select * From Users ";
            REP_SQL.Add(Query);
            Session["REP_SQL"] = REP_SQL;
            WebClassLibrary.JWebManager.LoadControl("LettersReport"
            , "~/WebReport/Viewer/JReportSelectorControl.ascx"
            , "چاپ نامه"
            , new List<Tuple<string, string>>(){ new Tuple<string, string>("ObjectCode", "0")
                                               ,  new Tuple<string, string>("rSUID", "Report_Dt")
                                               , new Tuple<string, string>("ClassName",WebAutomation.JCommunication._ConstClassName) 
                                               , new Tuple<string,string>("SQL1",Query) }
            , WebClassLibrary.WindowTarget.NewWindow
            , true, true, true, 750, 500);

        }
        ///-------------------------------------------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------------------------------------------
        #endregion Methods

    }
}