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
    public class JCLetterRegisterImport : JCLetterRegister
    {

        // سازنده های کلاس
        #region Constructors
                /// <summary>
        /// سازنده
        /// </summary>
        public JCLetterRegisterImport()
            : base(0)
        {
        }

        public JCLetterRegisterImport(int pCode)
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
        public int Insert(DataTable pDTCopyes, ArchivedDocuments.JArchiveList pDTAttachments,ArchivedDocuments.JArchiveList pLetter, DataTable pDTRelatedLetter)
        {
            if (JPermission.CheckPermission("Communication.JCLetterRegisterImport.Insert"))
            {
                letter_type = ClassLibrary.Domains.JCommunication.JLetterType.Import;
                letter_status = ClassLibrary.Domains.JCommunication.JLetterStatus.Minute;
                //----------- اطلاعات کاربر دریافت کننده -----------------------------------------------------------------------
                //Employment.JEOrganizationChart EOC = new Employment.JEOrganizationChart(receiver_post_code);
                //receiver_full_title = EOC.full_title;
                //receiver_code = EOC.user_code;


                ClassLibrary.JAllPerson Pers = new JAllPerson(sender_external_code);
                sender_full_title = Pers.Name;
                sender_external_code = Pers.Code;

                //------------------------------------------------------------------------------------------------------------
                JDataBase DB = new JDataBase();
                try
                {
                    DB.beginTransaction("Save Import Letter");

                    bool RegInSevretariat = false;
                    if (RegisterInSecretariat(DB))
                    {
                        RegInSevretariat = true;
                    }
                    else
                    {
                    }

                    {
                        int _Code = InsertLetter(pDTCopyes, pDTAttachments, pLetter, pDTRelatedLetter, DB);

                        if (RegInSevretariat)
                            if (!RegRefer(Code, DB))
                            {
                                DB.Rollback("LetterRegister");
                                return 0;
                            }
                        if (_Code > 0)
                            if (DB.Commit())
                                Nodes.DataTable.Merge(JCLetterRegisterExports.GetDataTable(Code));
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

        public bool Update(int pLetterCode, DataTable pDTCopyes, ArchivedDocuments.JArchiveList pDTAttachments, ArchivedDocuments.JArchiveList pLetter, DataTable pDTRelatedLetter)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.beginTransaction("LetterRegister");
                if (JPermission.CheckPermission("Communication.JCLetterRegisterImport.Update"))
                {
                    Code = pLetterCode;
                    //----------- اطلاعات کاربر دریافت کننده -----------------------------------------------------------------------
                    //Employment.JEOrganizationChart EOC = new Employment.JEOrganizationChart(receiver_post_code);
                    //receiver_full_title = EOC.full_title;
                    //receiver_code = EOC.user_code;
                    //------------------------------------------------------------------------------------------------------------
                    bool RegInSevretariat = false;
                    if (RegisterInSecretariat(DB))
                    {
                        RegInSevretariat = true;
                    }
                    else
                    {
                    }

                    if (!UpdateLetter(pDTCopyes, pDTAttachments, pLetter, pDTRelatedLetter, DB))
                    {
                        DB.Rollback("LetterRegister");
                        return false;
                    }
                    if(RegInSevretariat)
                        if (!RegRefer(Code, DB))
                        {
                            DB.Rollback("LetterRegister");
                            return false;
                        }
                    DB.Commit();
                    return true;
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

        //public bool SendToAutomation(JCWorkLetterType pAction, JDataBase db)
        //{
        //    //-----------------------امضا کردن نامه و ارسال پیشنویس به دبیرخانه--------------
        //    if (pAction == JCWorkLetterType.UpdateAndSecretariat)
        //    {
        //        // در امضا نامه داخلی و صادر باید ارسال کننده به دبیرخانه و فرستنده نامه یکنفر باشند
        //        if ((letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal ||
        //            letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export) &&
        //            JMainFrame.CurrentPostCode != sender_post_code)
        //        {
        //            db.Rollback(db.TransactionName);
        //            Except.NewException("Sender must be equal with sender letter");
        //            JMessages.Message("Sender must be equal with sender letter", "", JMessageType.Information);
        //            return false;
        //        }
        //    //    //-------------------- پیشنویس قبلاً امضا شده باشد
        //        if (letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept)
        //        {
        //            db.Rollback(db.TransactionName);
        //            Except.NewException("Letter is Accept!");
        //            return false;
        //        }
        //        letter_status = ClassLibrary.Domains.JCommunication.JLetterStatus.Accept;
        //        Employment.JEOrganizationChart tmpChart = new Employment.JEOrganizationChart();
        //        // باید ارسال کننده به یک دبیرخانه وصل باشد
        //        if (!tmpChart.GetData(JMainFrame.CurrentPostCode) && tmpChart.secretariat_code < 1)
        //        {
        //            db.Rollback(db.TransactionName);
        //            Except.NewException("Sender is NOT in a Secretarait!");
        //            return false;
        //        }
        //        secretariat_code = tmpChart.secretariat_code;
        //    }
        //    //-----------------------دادن شماره به نامه توسط دبیرخانه --------------
        //    else if ((pAction == JCWorkLetterType.UpdateAndRegister) && (CheckSecretariat(true)))
        //    {
        //        //-------------------- پیشنویس قبلاً امضا نشده باشد
        //        if (letter_status != ClassLibrary.Domains.JCommunication.JLetterStatus.Accept && letter_type != ClassLibrary.Domains.JCommunication.JLetterType.Import)
        //        {
        //            db.Rollback(db.TransactionName);
        //            Except.NewException("Letter Not Accept!");
        //            return false;
        //        }
        //        if (secretariat_code < 1)
        //        {
        //            db.Rollback(db.TransactionName);
        //            Except.NewException("secretariat_code is ZERO!");
        //            return false;
        //        }
        //        JCSecretariat tmpJCSecretariats = new JCSecretariat();
        //        int NewNumber = tmpJCSecretariats.GetRegister_NO(secretariat_code, db);
        //        if (NewNumber < 1)
        //        {
        //            Except.NewException("secretariat_code is ZERO!");
        //            return false;
        //        }
        //        register_no = NewNumber;
        //        letter_no = tmpJCSecretariats.Prifix + NewNumber.ToString() + tmpJCSecretariats.Suffix;
        //        // از پیشنویس به نامه تبدیل شده است
        //        letter_status = ClassLibrary.Domains.JCommunication.JLetterStatus.Letter;
        //    }

        //    //-------------------ارجاع نامه دبیرخانه-------------------
        //    if (pAction == JCWorkLetterType.UpdateAndSecretariat)
        //    {
        //        if (!RegSecretariats(db))
        //        {
        //            db.Rollback(db.TransactionName);
        //            return false;
        //        }
        //    }
        //    //-------------------ارجاع نامه به دریافت کنندگان-------------------
        //    else
        //        if (pAction == JCWorkLetterType.UpdateAndRegister)
        //        {
        //            if (!RegRefer(Code, db))
        //            {
        //                db.Rollback(db.TransactionName);
        //                return false;
        //            }
        //        }

        //}

        #endregion Insert-Delete-Update


        /// <summary>
        /// فرم ثبت نامه وارده
        /// </summary>
        public bool ShowDialog(int pLetter_Code)
        {
            JfrmLetterRegister jLRImport = new JfrmLetterRegister(ClassLibrary.Domains.JCommunication.JLetterType.Import, JFormState.Insert, pLetter_Code,Current_Refer_Code);
            if (pLetter_Code == 0)
            {
                if (!JPermission.CheckPermission("Communication.JCLetterRegisterImport.Insert"))
                    return false;
                jLRImport.State = JFormState.Insert;
            }
            else
            {
                if (!JPermission.CheckPermission("Communication.JCLetterRegisterImport.Update"))
                    return false;
                jLRImport.State = JFormState.Update;
            }
            jLRImport.ShowDialog();
            return true;
        }

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
            JNode node = new JNode((int)pRow["Code"], "Communication.JCLetterRegisterImport");
            node.Icone = JImageIndex.testimonial.GetHashCode();
            node.Name = pRow["Sender_Full_Title"].ToString();
            Nodes.hidColumns = @"Sender_Name,Sender_External_Name,Receiver_Name,Receiver_Post_Name,Receiver_Title_Job
,letter_type,sender_post_code,sender_code,sender_external_code,receiver_post_code,receiver_code,register_post_code,register_user_code,send_type,receiver_type,subject_code,sender_external_code,receiver_external_code";
            ArchivedDocuments.JSubjectTree S = new ArchivedDocuments.JSubjectTree();
            string Subject = "";
            //if (pRow["Subject_Code"].ToString() != "")
                //Subject = S.GetSubjectList((int)pRow["Subject_Code"]).Rows[0]["Name"].ToString();
            node.Hint = JLanguages._Text("Sender_Full_Title:") + " " + pRow["Receiver_Full_Title"] + "\n" +
                JLanguages._Text("Subject:") + " " + Subject + "\n" +
                JLanguages._Text("summary:") + " " + pRow["summary"];
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Communication.JCLetterRegisterImport.ShowDialog", new object[] { node.Code } ,null );
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Communication.JCLetterRegister.Delete", new object[] { node.Code }, null);
            node.DeleteClickAction = deleteAction;
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Communication.JCLetterRegisterImport.ShowDialog", null, null);
            /// اکشن آرشیو
            JAction ArchiveAction = new JAction("Archive...", "Communication.JCLetterRegister.ArshiveLetter", new object[] { node.Code }, null);
            /// اکشن ارجاع
            JAction ReferAction = new JAction("Refer...", "Communication.JCLetterRegister.Refer", new object[] { node.Code, 0 }, null);

            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);
            node.Popup.Insert(ReferAction);
            node.Popup.Insert(ArchiveAction);

            return node;
        }

    }

    /// <summary>
    ///  کلاس ثبت نامه وارده
    /// </summary>
    public class JCLetterRegisterImports :JSystem
    {
        // سازنده های کلاس
        #region Constructors
                /// <summary>
        /// سازنده
        /// </summary>
        public JCLetterRegisterImports()
        {
        }
        #endregion Constructors

        #region View
        /// <summary>
        /// تشکیل نودهای کلاس ثبت نامه وارده
        /// </summary>
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetImportLetters", "Communication.JCLetterRegisterImport.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Communication.JCLetterRegisterImport.ShowDialog", new object[] { 0 }, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            JAction SearchAction = new JAction("Search...", "Communication.JCLetterRegisterImport.SearchDialog", null, null);
            Nodes.GlobalMenuActions.Insert(SearchAction);
            JToolbarNode TNS = new JToolbarNode();
            TNS.Icon = JImageIndex.Search;
            TNS.Hint = "Search...";
            TNS.Click = SearchAction;
            Nodes.AddToolbar(TNS);
            //ListView(OrderName, "");
            //Nodes.Insert(JAStaticNode._LetterRegisterImportsNode());
            //Nodes.Insert(JAStaticNode._LetterRegisterExportsNode());
            //Nodes.Insert(JAStaticNode._LetterRegisterInternalsNode());            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        /// <summary>
        /// لیست اطلاعات براساس نوع نامه
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
(select Name  from organization where Code=sender_external_code) As 'Sender_External_Name',

(select Name + ' '+Fam from clsPerson where Code=Receiver_code) As 'Receiver_Name',
(select title from organizationchart Where code=Receiver_Post_code ) as 'Receiver_Post_Name',
(select name from subdefine Where code = (select metier_code from organizationchart Where code=Receiver_Post_code)) as 'Receiver_Title_Job',

(select Name from ArchivedSubject Where Code=Subject_Code) 'موضوع نامه',
pre_subject,
(Select Fa_Date from StaticDates where En_Date = register_date_time) 'register_date_time',
register_no,
letter_no,
incoming_no,
(Select Fa_Date from StaticDates where En_Date = incoming_date) 'incoming_date',
incoming_signature_person,
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
(Select  Name From secretariat Where Code= secretariat_code) 'secretariatName',
appendix,
summary 
                from " + JTableNamesLetters.Letters + " Where  letter_type=" +
                    ClassLibrary.Domains.JCommunication.JLetterType.Import + " And register_user_code=" + JMainFrame.CurrentUserCode +
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
        /// <summary>
        /// تشکیل زیردرخت کلاس ثبت نامه وارده
        /// </summary>
        public JNode[] TreeView()
        {

            //JNode[] N = new JNode[1];
            //N[0] = JAStaticNode._LetterRegisterImportsNode();
            //N[1] = JAStaticNode._SecretariatsNode();
            //N[2] = JAStaticNode._StorageLetterNosNode();
            ////N[4] = GetNode(ReferTypeCode);
            ////N[5] = GetNode(PursueTypeCode);

            return null;
        }
        #endregion View


    }
}
