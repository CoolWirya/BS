using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace Communication
{
    
    /// <summary>
    /// نود کلاس ثبت نامه وارده
    /// </summary>
    public class JCLetterRegisterInternal : JCLetterRegister
    {
        // سازنده های کلاس
        #region Constructors
        public JCLetterRegisterInternal()
            : base(0)
        {
        }
        /// <summary>
        /// سازنده
        /// </summary>
        public JCLetterRegisterInternal(int pCode)
            : base(pCode)
        {
        }
        #endregion Constructors

        // Insert-Delete-Update
        #region Insert-Delete-Update
        /// <summary>
        /// درج نامه صادره جدید
        /// </summary>
        /// <param name="pDTCopyes">رونوشت ها</param>
        /// <param name="pDTAttachments">ضمائم</param>
        /// <returns>bool</returns>
        public int Insert(DataTable pDTCopyes, ArchivedDocuments.JArchiveList pDTAttachments, OfficeWord.WinWordControl pLetter, DataTable pDTRelatedLetter)
        {
            if (JPermission.CheckPermission("Communication.JCLetterRegisterInternal.Insert"))
            {
                letter_type = ClassLibrary.Domains.JCommunication.JLetterType.Internal;
                letter_status = ClassLibrary.Domains.JCommunication.JLetterStatus.Minute;
                //----------- اطلاعات کاربر دریافت کننده -----------------------------------------------------------------------
                //Employment.JEOrganizationChart EOC = new Employment.JEOrganizationChart(receiver_post_code);
                //receiver_full_title = EOC.full_title;
                //receiver_code = EOC.user_code;
                //----------- اطلاعات کاربر ارسال کننده -----------------------------------------------------------------------
                //sender_full_title = EOC.full_title;
                //sender_code = EOC.user_code;
                //------------------------------------------------------------------------------------------------------------
                JDataBase DB = new JDataBase();
                try
                {
                    DB.beginTransaction("Save Import Letter");

                    bool RegInSecretariat = false;
                    bool RegSignatureLetter = false;
                    if (letter_status != ClassLibrary.Domains.JCommunication.JLetterStatus.Accept && SignatureLetter())
                    {
                        RegSignatureLetter = true;
                    }
                    else
                    {

                        if (letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept && RegisterInSecretariat(DB))
                        {
                            RegInSecretariat = true;
                        }
                        else
                        {
                        }
                    }

                    if (RegInSecretariat)
                    {
                        pLetter.Reaplce(this.GetLetterTable());
                    }

                    int _Code = InsertLetter(pDTCopyes, pDTAttachments, null, pLetter, pDTRelatedLetter, DB);
                    
                    if (RegSignatureLetter && letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept && RegSecretariats(DB))
                    {
                    }
                    else
                    {
                    }

                    if (RegInSecretariat)
                        if (!RegRefer(Code, DB))
                        {
                            DB.Rollback("LetterRegister");
                            return 0;
                        }

                    if (_Code > 0)
                        if (DB.Commit())
                            try
                            {
                                Nodes.DataTable.Merge(JCLetterRegisterInternals.GetDataTable(Code));
                            }
                            catch
                            {
                            }
                        else
                        {
                            DB.Rollback("Save Import Letter");
                            return 0;
                        }
                    else
                    {
                        DB.Rollback("Save Import Letter");
                        return 0;
                    }
                        return _Code;
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                    DB.Rollback("Save Export Letter");
                    return 0;
                }
                finally
                {
                    DB.DisConnect();
                }
            }
            else
                return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLetterCode"></param>
        /// <param name="pDTCopyes"></param>
        /// <param name="pDTAttachments"></param>
        /// <param name="pDTRelatedLetter"></param>
        /// <returns></returns>
        public bool Update(int pLetterCode, DataTable pDTCopyes, ArchivedDocuments.JArchiveList pDTAttachments, OfficeWord.WinWordControl pLetter, DataTable pDTRelatedLetter, JCWorkLetterType pRegister)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.beginTransaction("LetterRegister");
                if (JPermission.CheckPermission("Communication.JCLetterRegisterInternal.Update"))
                {
                    Code = pLetterCode;
                    //----------- اطلاعات کاربر دریافت کننده -----------------------------------------------------------------------
                    //Employment.JEOrganizationChart EOC = new Employment.JEOrganizationChart(receiver_post_code);
                    //receiver_full_title = EOC.full_title;
                    //receiver_code = EOC.user_code;
                    //------------------------------------------------------------------------------------------------------------
                    bool RegInSevretariat = false;

                    bool RegSignatureLetter = false;
                    if (SignatureLetter())
                    {
                        RegSignatureLetter = true;
                    }
                    else
                    {
                    }

                    if (letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept && RegisterInSecretariat(DB))
                    {
                        RegInSevretariat = true;
                    }
                    else
                    {
                    }
                    if (RegInSevretariat)
                    {
                        pLetter.Reaplce(this.GetLetterTable());
                    }
                    if (!UpdateLetter(pDTCopyes, pDTAttachments, null, pLetter, pDTRelatedLetter, DB))
                    {
                        DB.Rollback("LetterRegister");
                        return false;
                    }
                    
                    if (RegSignatureLetter && letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept && RegSecretariats(DB))
                    {
                    }
                    else
                    {
                    }
                    
                    if (RegInSevretariat)
                        if (!RegRefer(Code, DB))
                        {
                            DB.Rollback("LetterRegister");
                            return  false;
                        }
                    if (DB.Commit())
                    {
                        //Nodes.Refreshdata(Nodes.CurrentNode, JCLetterRegisterInternals.GetDataTable(Code).Rows[0]);
                        //Nodes.DataTable.Merge(JCLetterRegisterInternals.GetDataTable(Code));
                        return true;
                    }
                    return false;
                }
                else
                {
                    DB.Rollback("LetterRegister");
                    return false;

                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                DB.Rollback("Save Export Letter");
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        #endregion Insert-Delete-Update


        #region Node

        /// <summary>
        /// فرم ثبت نامه داخلی
        /// </summary>
        public bool ShowDialog(int pLetter_Code)
        {
            JfrmLetterRegister jLRImport = new JfrmLetterRegister(ClassLibrary.Domains.JCommunication.JLetterType.Internal, JFormState.Insert, pLetter_Code, Current_Refer_Code);
            if (pLetter_Code == 0)
                jLRImport.State = JFormState.Insert;
            else
                jLRImport.State = JFormState.Update;
            jLRImport.ShowDialog();
            return true;
        }

        /// <summary>
        /// فرم ثبت نامه داخلی با عطف یا پاسخ
        /// </summary>
        //public bool ShowDialog()
        //{
        //    JfrmLetterRegister jLRImport = new JfrmLetterRegister(ClassLibrary.Domains.JCommunication.JLetterType.Internal, JFormState.Insert, pLetter_Code, Current_Refer_Code);
        //    if (pLetter_Code == 0)
        //        jLRImport.State = JFormState.Insert;
        //    else
        //        jLRImport.State = JFormState.Update;
        //    jLRImport.ShowDialog();
        //    return true;
        //}

        /// <summary>
        /// جستجوی نامه داخلی
        /// </summary>
        public void SearchDialog()
        {
            JfrmSearchLetters jLRImport = new JfrmSearchLetters(ClassLibrary.Domains.JCommunication.JLetterType.Internal,0);            
            jLRImport.ShowDialog();
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow["Code"], "Communication.JCLetterRegisterInternal");
            node.Icone = JImageIndex.testimonial.GetHashCode();
            node.Name = pRow["Sender_Full_Title"].ToString();

            //Nodes.hidColumns = @"Sender_Name,Sender_Post_Name,Sender_Title_Job,Receiver_Name,Receiver_Post_Name,Receiver_Title_Job
//,letter_type,sender_post_code,sender_code,sender_external_code,receiver_post_code,receiver_code,register_post_code,register_user_code,send_type,receiver_type,subject_code,sender_external_code,receiver_external_code";

            ArchivedDocuments.JSubjectTree S = new ArchivedDocuments.JSubjectTree();
            string Subject="";
            //if (pRow["Subject_Code"].ToString() != "")
                //Subject = S.GetSubjectList((int)pRow["Subject_Code"]).Rows[0]["Name"].ToString();
            node.Hint = JLanguages._Text("Sender_Full_Title:") + " " + pRow["Receiver_Full_Title"] + "\n" +
            JLanguages._Text("Subject:") + " " + Subject  + "\n" +
                JLanguages._Text("summary:") + " " + pRow["summary"];
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Communication.JCLetterRegisterInternal.ShowDialog", new object[] { node.Code }, null);
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Communication.JCLetterRegister.Delete", new object[] { node.Code } ,null);
            node.DeleteClickAction = deleteAction;
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Communication.JCLetterRegisterInternal.ShowDialog", new object[] { 0 }, null);
            /// اکشن تایید مینوت
            //JAction ConfirmMinuteAction = new JAction("Confirm Minute...", "Communication.JCLetterRegisterInternal.ShowDialog", new object[] { node.Code }, null);
            /// اکشن کپی از مینوت
            JAction CopyMinuteAction = new JAction("Copy Minute...", "Communication.JCLetterRegister.Copy", new object[] { node.Code}, null);
            /// اکشن آرشیو
            JAction ArchiveAction = new JAction("Archive...", "Communication.JCLetterRegister.ArshiveLetter", new object[] { node.Code}, null);
            /// اکشن ارجاع
            JAction ReferAction = new JAction("Refer...", "Communication.JCLetterRegister.Refer", new object[] { node.Code }, null);
            /// ثبت دبیرخانه
            JAction ConSec = new JAction("ConSec...", "Communication.JCLetterRegister.ConSec", new object[] { node.Code }, null);

            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);
            //node.Popup.Insert(ConfirmMinuteAction);
            node.Popup.Insert(CopyMinuteAction);
            node.Popup.Insert(ArchiveAction);
            node.Popup.Insert(ReferAction);
            node.Popup.Insert(ConSec);

            return node;
        }

        #endregion Node

    }
    /// <summary>
    ///  کلاس ثبت نامه وارده
    /// </summary>
    public class JCLetterRegisterInternals : JCLetterRegisters
    {
        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JCLetterRegisterInternals()
        {
        }
        #endregion Constructors

        /// <summary>
        /// تشکیل نودهای کلاس ثبت نامه داخلی
        /// </summary>
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetInternalLetters", "Communication.JCLetterRegisterInternal.GetNode");
            Nodes.DataTable = GetDataTable();
            //Nodes.hidColumns = "Letter_Type,subject_code,Sender_Name,Sender_Post_Name,Sender_Title_Job,Receiver_Name,Receiver_Post_Name,Receiver_Title_Job";

            JAction newAction = new JAction("New...", "Communication.JCLetterRegisterInternal.ShowDialog", new object[] { 0 }, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            JAction SearchAction = new JAction("Search...", "Communication.JCLetterRegisterInternal.SearchDialog", null, null);
            Nodes.GlobalMenuActions.Insert(SearchAction);
            JToolbarNode TNS = new JToolbarNode();
            TNS.Icon = JImageIndex.Search;
            TNS.Hint = "Search...";
            TNS.Click = SearchAction;
            Nodes.AddToolbar(TNS);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        /// <summary>
        /// لیست اطلاعات براساس نوع داخلی
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="pStatusForm"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode)
        {
            
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = @"select 
Code,
letter_type,
case letter_type
when " + ClassLibrary.Domains.JCommunication.JLetterType.Internal.GetHashCode().ToString() + @" then 'داخلی'
when " + ClassLibrary.Domains.JCommunication.JLetterType.Import.GetHashCode().ToString() + @" then 'وارده'
when " + ClassLibrary.Domains.JCommunication.JLetterType.Export.GetHashCode().ToString() + @" then 'صادره'
end letter_type_Label,
case letter_status
when 1 Then 'پیشنویس'
when 2 Then 'نامه'
when 3 Then 'همگی حالات'
when 4 Then 'بایگانی'
when 5 Then 'امضا شده'
end 'letter_status',
subject_code,
sender_full_title,
receiver_full_title,

(select Name + ' '+Fam from clsPerson where Code=sender_code) As 'Sender_Name',
(select Title from organizationchart Where code=sender_post_code ) as 'Sender_Post_Name',
(select name from subdefine Where code = (select metier_code from organizationchart Where code=sender_post_code)) as 'Sender_Title_Job',

(select Name + ' '+Fam from clsPerson where Code=Receiver_code) As 'Receiver_Name',
(select title from organizationchart Where code=Receiver_Post_code ) as 'Receiver_Post_Name',
(select name from subdefine Where code = (select metier_code from organizationchart Where code=Receiver_Post_code)) as 'Receiver_Title_Job',

(select Name from ArchivedSubject Where Code=Subject_Code) 'SubjectLetter',
pre_subject,
(Select Fa_Date from StaticDates where En_Date = register_date_time) 'register_date_timeFA',register_date_time,
register_no,
letter_no,
sender_post_code,
sender_code,
sender_external_code,
receiver_post_code,
receiver_code,
receiver_external_code,
register_post_code,
register_user_code,
register_user_full_title,
case secret_level
when 1 Then 'عادی'
when 2 Then 'محرمانه'
when 3 Then 'سری'
end 'secret_level',
case urgency
when 1 Then 'عادی'
when 2 Then 'سریع'
when 3 Then 'خیلی سریع'
end 'urgency',
send_type,
(select Name from subdefine where bcode=send_type) 'send_type_Name',
receiver_type,
(select Name from subdefine where bcode=receiver_type) 'receiver_type_Name',
(Select  Name From secretariat Where Code= secretariat_code)'secretariatName',
appendix,
summary , '' CopiesText
from " + JTableNamesLetters.Letters + " Where  letter_type=" +
                    ClassLibrary.Domains.JCommunication.JLetterType.Internal + " And register_user_code=" + JMainFrame.CurrentUserCode +
                    " And register_post_code=" + JMainFrame.CurrentPostCode;
                if (pCode != 0)
                    WHERE = WHERE + " And Code = " + pCode;
                DB.setQuery(WHERE);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public static DataTable GetDataTablePattern(int pCode)
        {
            DataTable table = new DataTable();
            table = GetDataTable(pCode);
            table.Columns.Remove("Code");
            table.Columns.Remove("letter_type");
            table.Columns.Remove("letter_status");
            table.Columns.Remove("subject_code");
            table.Columns.Remove("register_no");
    
            table.Columns.Remove("sender_post_code");
            table.Columns.Remove("sender_code");
            table.Columns.Remove("sender_external_code");
            table.Columns.Remove("receiver_external_code");
            table.Columns.Remove("receiver_post_code");
            table.Columns.Remove("receiver_code");
            table.Columns.Remove("register_post_code");
            table.Columns.Remove("register_user_code");
            table.Columns.Remove("receiver_type");
            table.Columns.Remove("send_type");
            table.Columns.Remove("register_date_time");
    
            return table;
        }
        #region View

        /// <summary>
        /// تشکیل زیردرخت کلاس ثبت نامه وارده
        /// </summary>
        public JNode[] TreeView()
        {

            //JNode[] N = new JNode[1];
            //N[0] = JAStaticNode._LetterRegisterInternalsNode();
            //N[1] = JAStaticNode._SecretariatsNode();
            //N[2] = JAStaticNode._StorageLetterNosNode();
            ////N[4] = GetNode(ReferTypeCode);
            ////N[5] = GetNode(PursueTypeCode);

            return null;
        }
        #endregion View
    }
}