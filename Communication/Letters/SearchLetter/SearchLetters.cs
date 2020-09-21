using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Communication
{
    public class JCSearchLetter : JCLetter
    {
        // ویژگیها و فیلد ها
        #region Peroperties

        /// <summary>
        /// کد
        /// </summary>
        public int Code{ get; set; }
        /// <summary>
        /// نوع نامه - واره ، صادره یا درون سازمانی
        /// </summary>
        public int letter_type{ get; set; }
        /// <summary>
        /// وضعیت نامه
        /// </summary>
        public int letter_status{ get; set; }
        /// <summary>
        /// کد موضوع نامه
        /// </summary>
        public int subject_code{ get; set; }
        /// <summary>
        /// پیش نویس موضوع
        /// </summary>
        public string pre_subject{ get; set; }
        /// <summary>
        /// تاریخ و زمان ثبت
        /// </summary>
        public DateTime register_date_time{ get; set; }
        /// <summary>
        /// شماره ثبت
        /// </summary>
        public int register_no{ get; set; }
        /// <summary>
        /// شماره نامه
        /// </summary>
        public string letter_no{ get; set; }
        /// <summary>
        /// شماره نامه وارده
        /// </summary>
        public string incoming_no{ get; set; }
        /// <summary>
        /// تاریخ نامه وارده
        /// </summary>
        public DateTime incoming_date{ get; set; }
        /// <summary>
        /// امضا کننده نامه وارده
        /// </summary>
        public string incoming_signature_person{ get; set; }
        /// <summary>
        /// کد پست فرستنده
        /// </summary>
        public int sender_post_code{ get; set; }
        /// <summary>
        /// کد کاربر فرستنده
        /// </summary>
        public int sender_code{ get; set; }
        /// <summary>
        /// عنوان کامل فرستنده
        /// </summary>
        public string sender_full_title{ get; set; }
        /// <summary>
        /// کد سازمان فرستنده نامه
        /// </summary>
        public int sender_external_code{ get; set; }
        /// <summary>
        /// کد پست گیرنده
        /// </summary>
        public int receiver_post_code{ get; set; }
        /// <summary>
        /// کد کاربر گیرنده
        /// </summary>
        public int receiver_code{ get; set; }
        /// <summary>
        /// عنوان کامل گیرنده
        /// </summary>
        public string receiver_full_title{ get; set; }
        /// <summary>
        /// کد سازمان گیرنده نامه
        /// </summary>
        public int receiver_external_code{ get; set; }
        /// <summary>
        /// کد پست کاربر ثبت کننده
        /// </summary>
        public int register_post_code{ get; set; }
        /// <summary>
        /// کد کاربر ثبت کننده
        /// </summary>
        public int register_user_code{ get; set; }
        /// <summary>
        /// نام کامل ثبت کننده نامه
        /// </summary>
        public string register_user_full_title{ get; set; }        
        /// <summary>
        /// سطح محرمانگی
        /// </summary>
        public int secret_level{ get; set; }
        /// <summary>
        /// فوریت
        /// </summary>
        public int urgency{ get; set; }
        /// <summary>
        /// نحوه ارسال
        /// </summary>
        public int send_type{ get; set; }
        /// <summary>
        /// نحوه دریافت
        /// </summary>
        public int receiver_type{ get; set; }
        /// <summary>
        /// کد دبیرخانه
        /// </summary>
        public int secretariat_code{ get; set; }
        /// <summary>
        /// پیوست
        /// </summary>
        public string appendix{ get; set; }
        /// <summary>
        /// خلاصه نامه
        /// </summary>
        public string summary{ get; set; }
        #endregion Peroperties
        
      
        // سازنده های کلاس
        #region Constructors
                /// <summary>
        /// سازنده
        /// </summary>
        public JCSearchLetter()
        {
        }
        #endregion Constructors

        #region Methods

        public DataTable SearchLetter(string User_Code, string pletter_no, string pincoming_no,string pregister_date_timeS,
           string pregister_date_timeE,string pKeyWords,string pRReceiver,string pSendType,string pRSecuritylevel,
           string pRUrgency, string pfaDatePickerStartDAteR, string pfaDatePickerEndDateR,
           string pSender, string pReceiver, string pSubject,string pSubjectMinute,
           string pAppindix,string pSummary,
           string pLetterImportLetterNo,string pSignatured,string pdteLetterImportDate,
           string pSecurityLevel, string pReceiveType, string pUrgencyLetter, int pState, int pSecretiatCode)                                          
        {
            //-----------------Search Archive-------------
            string SqlArchive = ArchivedDocuments.JArchiveDocument.SearchText("Communication.JCLetter", "");

            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string strsql = String.Empty;
                strsql = @"select distinct " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.Code + @", 
" + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.letter_status + @",
" + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.pre_subject + @",
(Select Fa_Date from StaticDates where En_Date = Letters.register_date_time) 'register_date_time',
" + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.register_no + @",
" + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.letter_no + @",
" + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.incoming_no + @",
(Select Fa_Date from StaticDates where En_Date = Letters.incoming_date) 'incoming_date',
" + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.incoming_signature_person + @",
" + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.sender_full_title + @",
" + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.receiver_full_title + @",
" + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.register_user_full_title + @",
" + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.appendix + @"
from " + JTableNamesLetters.Letters +
    " left join (" + SqlArchive + ") Archive on Letters.Code=Archive.ObjectCode " +
    " left join " + JTableNamesAutomation.Objects + " on " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.Code
    + "=" + JTableNamesAutomation.Objects + "." + Objects.externalcode + " left join " + JTableNamesAutomation.Refer + @" on " +
    JTableNamesAutomation.Refer + "." + Refer.object_code + "=" + JTableNamesAutomation.Objects + "." + Objects.Code +
    " where 1=1 " ;
    //((" + JTableNamesAutomation.Refer + "." +
    //Refer.sender_code + "=" + User_Code + " And " + JTableNamesAutomation.Refer + "." +
    //Refer.sender_post_code + "=" + JMainFrame.CurrentPostCode + ") or (" +
    //JTableNamesLetters.Letters + "." + ClassLibrary.Letters.register_user_code + "=" + JMainFrame.CurrentUserCode + " and " +
    //JTableNamesLetters.Letters + "." + ClassLibrary.Letters.register_post_code + "=" + JMainFrame.CurrentPostCode + "))";

                if (pletter_no != "")
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.letter_no + "='" + pletter_no + "'";
                if (pincoming_no != "")
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.incoming_no + "='" + pincoming_no + "'";
                if (pregister_date_timeS != "    /  /")
                {
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.register_date_time + " between '" + pregister_date_timeS + "' And '";
                    if (pregister_date_timeE != "    /  /")
                        strsql = strsql + pregister_date_timeS + "'";
                    else
                        strsql = strsql + "1400/01/01'";
                }
                if (pRReceiver != "")
                    strsql = strsql + " And " + JTableNamesAutomation.Refer + "." + Refer.receiver_code + "=" + pRReceiver;
                //if(pSendType != "")
                //    strsql = strsql + " And " + JTableNamesAutomation.Refer + "." + ClassLibrary.Letters.send_type + "=" + pSendType;
                //if(pRSecuritylevel != "")
                //    strsql = strsql + " And " + JTableNamesAutomation.Refer + "." + Refer.secret_level + "=" + pRSecuritylevel;
                //if(pRUrgency != "")
                //    strsql = strsql + " And " + JTableNamesAutomation.Refer + "." + Refer.urgency + "=" + pRUrgency;
                if (pfaDatePickerStartDAteR != "    /  /")
                {
                    strsql = strsql + " And " + JTableNamesAutomation.Refer + "." + Refer.send_date_time + " between '" + pfaDatePickerStartDAteR + "' And '";
                    if (pfaDatePickerEndDateR != "    /  /")
                        strsql = strsql + pfaDatePickerEndDateR + "'";
                    else
                        strsql = strsql + "1400/01/01'";
                }
                if ((pSender != "") && (pSender != "-1"))
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.sender_code + "=" + pSender;
                if ((pReceiver != "") && (pReceiver != "-1"))
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.receiver_code + "=" + pReceiver;
                if ((pSubject != "") && (pSubject != "-1"))
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.subject_code + " like '%" + pSubject + "%'";
                if (pSubjectMinute != "")
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.pre_subject + " like '%" + pSubjectMinute + "%'";
                if (pAppindix != "")
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.appendix + " like '%" + pAppindix + "%'";
                if (pSummary != "")
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.summary + " like '%" + pSummary + "%'";
                if (pLetterImportLetterNo != "")
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.incoming_no + "=" + pLetterImportLetterNo;
                if (pSignatured != "")
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.incoming_signature_person + " like '%" + pSignatured + "%'";
                if (pdteLetterImportDate != "    /  /")
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.incoming_date + "=" + pdteLetterImportDate;
                if (pSecurityLevel != "")
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.secret_level + "=" + pSecurityLevel;
                if ((pReceiveType != "") && ((pReceiveType != "-1")))
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.receiver_type + "=" + pReceiveType;
                if (pUrgencyLetter != "")
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.urgency + "=" + pUrgencyLetter;
                //if (pState == ClassLibrary.Domains.JCommunication.JLetterStatus.Minute)
                //    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.register_no + "= 0";
                //else if (pState == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
                //    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.register_no + "<> 0";
                if(pSecretiatCode != 0)
                    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.secretariat_code + "=" + pSecretiatCode;

                DB.setQuery(strsql);
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }


        public DataTable SearchLetter1(JCLetterRegister tmpLetterRegister, string Letter_Type)
        {
            //-----------------Search Archive-------------
            //string SqlArchive = ArchivedDocuments.JArchiveDocument.SearchText("Communication.JCLetter", tmpLetterRegister.summary);

            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {                
                    string strsql = String.Empty;
                    strsql = @"select distinct " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.Code + @","
                        + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.sender_full_title + @","
                        + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.receiver_full_title + @","
                        + @" Case Letter_Type 
                         when 3 Then 'نامه داخلی' 
                         when 2 Then 'نامه صادره' 
                         when 1 Then 'نامه وارده' 
                         end 'Type',
                         Case letter_status 
                         when 1 Then 'پیشنویس' 
                         when 2 Then 'نامه' 
                         when 4 Then 'بایگانی' 
                         when 5 Then 'امضا شده'
                         end 'letter_status',
                         (select Name from ArchivedSubject Where Code=Letters.Subject_Code) 'Subject',"
                        + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.pre_subject + @",
(Select Fa_Date from StaticDates where En_Date = Letters.register_date_time) 'register_date_time',"
                        + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.register_no + @","
                        + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.letter_no + @","
                        + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.incoming_no + @",
(Select Fa_Date from StaticDates where En_Date = Letters.incoming_date) 'incoming_date',"
                        + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.incoming_signature_person + @","
                        + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.register_user_full_title + @","
                        + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.appendix + @","
                        + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.letter_type + @"  from  "
                        + JTableNamesLetters.Letters +
                        // "  left join (" + SqlArchive + ") Archive on Letters.Code=Archive.ObjectCode " +
        " left join " + JTableNamesAutomation.Objects + " on " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.Code
        + "=" + JTableNamesAutomation.Objects + "." + Objects.externalcode + " left join " + JTableNamesAutomation.Refer + @" on " +
        JTableNamesAutomation.Refer + "." + Refer.object_code + "=" + JTableNamesAutomation.Objects + "." + Objects.Code +
        " where Letters.Code in (select ObjectCode from Word where DocumentText like '%" + tmpLetterRegister.summary + "%' and Classname = 'Communication.JCLetter')" +
                    " And (( " + JTableNamesAutomation.Refer + "." +
                    Refer.sender_post_code + "=" + JMainFrame.CurrentPostCode +
                    " or " + JTableNamesAutomation.Refer + "." +
                    Refer.receiver_post_code + "=" + JMainFrame.CurrentPostCode + ") or (" +
                    JTableNamesLetters.Letters + "." + ClassLibrary.Letters.register_post_code + "=" + JMainFrame.CurrentPostCode + " or " +
                    JTableNamesLetters.Letters + "." + ClassLibrary.Letters.receiver_post_code + "=" + JMainFrame.CurrentPostCode + " or " +
                    JTableNamesLetters.Letters + "." + ClassLibrary.Letters.sender_post_code + "=" + JMainFrame.CurrentPostCode + "))";

                    if (Letter_Type != "")
                        strsql = strsql + " And Letter_Type in " + Letter_Type;
                    if (tmpLetterRegister.letter_no != "")
                        strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.letter_no + "='" + tmpLetterRegister.letter_no + "'";
                    if ((tmpLetterRegister.sender_post_code != -1) && (tmpLetterRegister.sender_post_code != 0))
                        strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.sender_post_code + "=" + tmpLetterRegister.sender_post_code;
                    if ((tmpLetterRegister.receiver_post_code != -1) && (tmpLetterRegister.receiver_post_code != 0))
                        strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.receiver_post_code + "=" + tmpLetterRegister.receiver_post_code;
                    if (tmpLetterRegister.subject_code >0)
                        strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.subject_code + " like '%" + tmpLetterRegister.pre_subject + "%'";
                    if ((tmpLetterRegister.pre_subject != null)&&(tmpLetterRegister.pre_subject != ""))
                        strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.pre_subject + " like '%" + tmpLetterRegister.pre_subject + "%'";
                    //if (tmpLetterRegister.summary != "")
                    //    strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.summary + " like '%" + tmpLetterRegister.summary + "%'";
                    if (tmpLetterRegister.secret_level > 0)
                        strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.secret_level + "=" + tmpLetterRegister.secret_level;
                    if (tmpLetterRegister.receiver_type > 0)
                        strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.receiver_type + "=" + tmpLetterRegister.urgency;
                    if (tmpLetterRegister.urgency > 0)
                        strsql = strsql + " And " + JTableNamesLetters.Letters + "." + ClassLibrary.Letters.urgency + "=" + tmpLetterRegister.urgency;

                    if (!(JsecretariatUsers.CheckUser(JMainFrame.CurrentPostCode)))
                    {
                        DB.setQuery(strsql);
                        return DB.Query_DataTable();
                    }
                    else
                    {
                        int Sec = JCSecretariat.GetDataByUserPCode(JMainFrame.CurrentPostCode);
                        string WhereSec = "";
                        WhereSec = @" And Letters.Code in (select distinct Letters.Code from VOrganizationChart VO 
  inner join Refer R ON R.sender_post_code=VO.Code or R.receiver_post_code=VO.Code
  inner join Letters on 
  VO.Code=Letters.register_user_code or Letters.sender_post_code=VO.Code or Letters.receiver_post_code=VO.Code    
   where VO.secretariat_code = " + Sec + ")";
                        DB.setQuery(strsql + WhereSec);
                        return DB.Query_DataTable();
                    }
            }
            finally
            {
                DB.Dispose();
            }
        }
        #endregion

        public void ShowForm()
        {
            JfrmSearchLetter p = new JfrmSearchLetter();
            p.ShowDialog();
        }

        public void HelpForm()
        {
            JHelpForm p = new JHelpForm();
            p.ShowDialog();
        }
    }

    /// <summary>
    /// کلاس جستجوی نامه ها
    /// </summary>
    //public class JCSearchLetter : JCommunication
    //{
    //    // سازنده های کلاس
    //    #region Constructors
    //    /// <summary>
    //    /// سازنده
    //    /// </summary>
    //    public JCSearchLetter()
    //    {
    //    }
    //    #endregion Constructors

    //    // View Nodes
    //    #region View
    //    public JNode[] TreeView()
    //    {

    //        return null;
    //    }
    //    public void ListView()
    //    {

    //    }

    //    #endregion View
    //}
}
