using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Automation;

namespace Communication
{
    public enum JCWorkLetterType
    {
        Save =1,// فقط ویرایش  یا ذخیره اطلاعت
        UpdateAndSecretariat=2,// ویرایش و ارسال به دبیرخانه
        UpdateAndRegister=3,// ویرایش و ثبت نامه توسط دبیرخانه
    }
    /// <summary>
    ///نود پدر ثبت نامه
    /// </summary>er
    public class JCLetterRegister : JCLetter
    {
        // ویژگیها و فیلد ها
        #region Peroperties

        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نوع نامه - واره ، صادره یا درون سازمانی
        /// </summary>
        public int letter_type { get; set; }
        /// <summary>
        /// وضعیت نامه
        /// </summary>
        public int letter_status { get; set; }
        /// <summary>
        /// کد موضوع نامه
        /// </summary>
        public int subject_code { get; set; }
        /// <summary>
        /// پیش نویس موضوع
        /// </summary>
        public string pre_subject { get; set; }
        /// <summary>
        /// تاریخ و زمان ثبت
        /// </summary>
        public DateTime register_date_time { get; set; }
        /// <summary>
        /// شماره ثبت
        /// </summary>
        public int register_no { get; set; }
        /// <summary>
        /// شماره نامه
        /// </summary>
        public string letter_no { get; set; }
        /// <summary>
        /// شماره نامه وارده
        /// </summary>
        public string incoming_no { get; set; }
        /// <summary>
        /// تاریخ نامه وارده
        /// </summary>
        public DateTime incoming_date { get; set; }
        /// <summary>
        /// امضا کننده نامه وارده
        /// </summary>
        public string incoming_signature_person { get; set; }
        /// <summary>
        /// کد پست فرستنده
        /// </summary>
        public int sender_post_code { get; set; }
        /// <summary>
        /// کد کاربر فرستنده
        /// </summary>
        public int sender_code { get; set; }
        /// <summary>
        /// عنوان کامل فرستنده
        /// </summary>
        public string sender_full_title { get; set; }
        /// <summary>
        /// کد سازمان فرستنده نامه
        /// </summary>
        public int sender_external_code { get; set; }
        /// <summary>
        /// کد پست گیرنده
        /// </summary>
        public int receiver_post_code { get; set; }
        /// <summary>
        /// کد کاربر گیرنده
        /// </summary>
        public int receiver_code { get; set; }
        /// <summary>
        /// عنوان کامل گیرنده
        /// </summary>
        public string receiver_full_title { get; set; }
        /// <summary>
        /// کد سازمان گیرنده نامه
        /// </summary>
        public int receiver_external_code { get; set; }
        /// <summary>
        /// کد پست کاربر ثبت کننده
        /// </summary>
        public int register_post_code { get; set; }
        /// <summary>
        /// کد کاربر ثبت کننده
        /// </summary>
        public int register_user_code { get; set; }
        /// <summary>
        /// نام کامل ثبت کننده نامه
        /// </summary>
        public string register_user_full_title { get; set; }
        /// <summary>
        /// سطح محرمانگی
        /// </summary>
        public int secret_level { get; set; }
        /// <summary>
        /// فوریت
        /// </summary>
        public int urgency { get; set; }
        /// <summary>
        /// نحوه ارسال
        /// </summary>
        public int send_type { get; set; }
        /// <summary>
        /// نحوه دریافت
        /// </summary>
        public int receiver_type { get; set; }
        /// <summary>
        /// کد دبیرخانه
        /// </summary>
        public int secretariat_code { get; set; }
        /// <summary>
        /// پیوست
        /// </summary>
        public string appendix { get; set; }
        /// <summary>
        /// خلاصه نامه
        /// </summary>
        public string summary { get; set; }
        /// <summary>
        ///  پاسخ
        /// </summary>
        public DateTime Respite_date_time { get; set; }
        /// <summary>
        /// متن رونوشتها
        /// </summary>
        public string CopiesText { get; set; }

        #endregion Peroperties
        /// <summary>
        /// فیلد رونوشت
        /// </summary>
        private bool _Copy = false;

        ///نام فعال ارسال شده است
        public bool LetterSend = false;

        // Insert , Update , Delete
        #region Bease Action
        /// <summary>
        /// درج نامه جدید
        /// </summary>
        /// <param name="pDTCopyes"></param>
        /// <returns></returns>
        protected int InsertLetter(DataTable pDTCopyes, ArchivedDocuments.JArchiveList pDTAttachments,
            ArchivedDocuments.JArchiveList pLetter, DataTable pDTRelatedLetter, JDataBase DB)
        {
            return InsertLetter(pDTCopyes, pDTAttachments, pLetter, null, pDTRelatedLetter,DB);
        }

        protected int InsertLetter(DataTable pDTCopyes, ArchivedDocuments.JArchiveList pDTAttachments,
            ArchivedDocuments.JArchiveList pLetter, DataTable pDTRelatedLetter)
        {
            return InsertLetter(pDTCopyes, pDTAttachments, pLetter, null, pDTRelatedLetter);
        }

        protected int InsertLetter(DataTable pDTCopyes, ArchivedDocuments.JArchiveList pDTAttachments,
            ArchivedDocuments.JArchiveList pLetter, OfficeWord.WinWordControl pWinWordControl, DataTable pDTRelatedLetter)
        {
            JDataBase DB = new JDataBase();
            DB.beginTransaction("LetterRegister");
            try
            {
                int RetCode =  InsertLetter(pDTCopyes, pDTAttachments, pLetter, pWinWordControl, pDTRelatedLetter, DB);
                if (RetCode < 1)
                {
                    DB.Rollback("LetterRegister");
                    return RetCode;
                }
                DB.Commit();
                return RetCode;

            }
            finally
            {
                DB.DisConnect();                
            }
        }

        protected int InsertLetter(DataTable pDTCopyes, ArchivedDocuments.JArchiveList pDTAttachments, ArchivedDocuments.JArchiveList pLetter, 
            OfficeWord.WinWordControl pWinWordControl, DataTable pDTRelatedLetter, JDataBase db)
        {
            if (Code > 0)
            {
                Except.NewException("is Insert!");
                return -1;
            }
            //----------- اطلاعات کاربر ثبت کننده -----------------------------------------------------------------------
            register_user_code = JMainFrame.CurrentUserCode;
            register_post_code = JMainFrame.CurrentPostCode;
            register_user_full_title = (new Employment.JEOrganizationChart(JMainFrame.CurrentPostCode)).full_title;
            //------------------------------------------------------------------------------------------------------------           
            //JDataBase db = JGlobal.MainFrame.GetDBO();
            //db.beginTransaction("LetterRegister");
            int NewLetterCode = -1;
            try
            {

                JCLetterRegisterTable JST = new JCLetterRegisterTable();
                JST.SetValueProperty(this);
                // -----------------  ثبت اطلاعات نامه  -------------------
                NewLetterCode = JST.Insert(db);
                if (NewLetterCode != 0)
                {
                    // -----------------  ثبت رونوشت ها -------------------
                    if (pDTCopyes != null)
                    {
                        JCLetterCopys JLC = new JCLetterCopys();
                        if (!JLC.Insert(NewLetterCode, pDTCopyes, db))
                        {
                            //db.Rollback(db.TransactionName);
                            return -1;
                        }
                    }
                    //----------------- ثبت ضمائم --------------------

                    if (pDTAttachments != null)
                    {
                        pDTAttachments.ClassName = "Communication.JCLetterAttachment";
                        pDTAttachments.ObjectCode = NewLetterCode;
                        pDTAttachments.SubjectCode = ArchivedDocuments.JConstantArchiveSubjects.LetterAttachment.GetHashCode();
                        pDTAttachments.PlaceCode = ArchivedDocuments.JConstantArchivePalces.LetterAttachment.GetHashCode();
                    }

                    if (pLetter != null)
                    {
                        pLetter.ClassName = "Communication.JCLetter";
                        pLetter.ObjectCode = NewLetterCode;
                        pLetter.SubjectCode = ArchivedDocuments.JConstantArchiveSubjects.Letter.GetHashCode();
                        pLetter.PlaceCode = ArchivedDocuments.JConstantArchivePalces.Letter.GetHashCode();
                    }

                    if (pWinWordControl != null)
                    {
                        if (!pWinWordControl.SaveInOfficeWord(db, "Communication.JCLetter", NewLetterCode, true))
                        {
                            return -1;
                        }
                    }

                    if(pDTAttachments!= null)
                        if (!pDTAttachments.ArchiveList())
                        {
                            //db.Rollback(db.TransactionName);
                            return -1;
                        }
                    //----------------- ثبت متن نامه --------------------
                    if(pLetter!=null)
                        if (!pLetter.ArchiveList())
                        {
                            //db.Rollback(db.TransactionName);
                            return -1;
                        }
                    //----------------- ثبت عطف --------------------
                    JCRelatedLetter JRL = new JCRelatedLetter();
                    if (!JRL.InsertAll(NewLetterCode, pDTRelatedLetter, db))
                    {
                        //db.Rollback(db.TransactionName);
                        return -1;
                    }
                }
                else
                {
                    //db.Rollback(db.TransactionName);
                    return -1;
                }


                //db.Commit();
                Code = NewLetterCode;
                
                if (Nodes != null)
                {
                    //Nodes.DataTable.Merge(JCLetterRegisters.GetDataTable(Code, letter_type));
                    //DataRow DR = JST.GetRow(Nodes.DataTable);
                    //Nodes.DataTable.Rows.Add(DR);
                }
            }
            catch (Exception ex)
            {
                //db.Rollback(db.TransactionName);
                JSystem.Except.AddException(ex);
                return -1;
            }
            finally
            {
                //db.Dispose();
            }
            pDTCopyes.AcceptChanges();
            return NewLetterCode;
        }

        /// <summary>
        /// چک کردن مجوز کاربر برای ثبت دبیرخانه
        /// </summary>
        /// <returns></returns>
        public static bool CheckSecretariat(bool pMsg, DataTable pSecretariats)
        {
            return true;
            foreach (DataRow Row in pSecretariats.Rows)
            {
                if (!JPermission.CheckPermission("Communication.JCLetterRegister.CheckSecretariat", (int)Row["Code"], JMainFrame.CurrentPostCode, pMsg))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// ثبت یک نامه در دبیرخانه
        /// </summary>
        /// <returns></returns>
        public bool RegisterInSecretariat(JDataBase db)
        {
            DataTable secretariats = JCSecretariat.GetScretariatUserCodes(JMainFrame.CurrentPostCode, db);
            if (secretariats.Rows.Count > 0 && CheckSecretariat(false, secretariats))
                if (JMessages.Question("Do You Want Save In Secretariat", "Secretariat") == System.Windows.Forms.DialogResult.Yes)
                {

                    //-----------------------دادن شماره به نامه توسط دبیرخانه --------------

                    {
                        if (register_no == 0)
                        {
                            //انتخاب دبیرخانه
                            secretariat_code = (int)secretariats.Rows[0]["Code"];

                            JCSecretariat tmpJCSecretariats = new JCSecretariat();
                            int NewNumber = tmpJCSecretariats.GetRegister_NO(secretariat_code, db);
                            if (NewNumber < 1)
                            {
                                Except.NewException("secretariat_code is ZERO!");
                                JMessages.Message(" دبیرخانه ای وجود ندارد ","", JMessageType.Error);
                                return false;
                            }
                            register_no = NewNumber;
                            letter_no = tmpJCSecretariats.Prifix + NewNumber.ToString() + tmpJCSecretariats.Suffix;
                            // از پیشنویس به نامه تبدیل شده است
                            letter_status = ClassLibrary.Domains.JCommunication.JLetterStatus.Letter;
                            return true;
                        }
                    }
                }

            return false;
        }


        /// <summary>
        /// ویرایش نامه جدید
        /// </summary>
        /// <param name="pDTCopyes"></param>
        /// <returns></returns>
        public bool UpdateLetter(DataTable pDTCopyes, ArchivedDocuments.JArchiveList pDTAttachments, ArchivedDocuments.JArchiveList pLetter, DataTable pDTRelatedLetter, JDataBase db)
        {
            return UpdateLetter(pDTCopyes, pDTAttachments, pLetter, null, pDTRelatedLetter, db);
        }

        public bool UpdateLetter(DataTable pDTCopyes, ArchivedDocuments.JArchiveList pDTAttachments, ArchivedDocuments.JArchiveList pLetter, OfficeWord.WinWordControl WinWordControl, DataTable pDTRelatedLetter, JDataBase db)
        {
            // درصورتی که پیشنویس یا نامه به اتوماسیون ارسال شده باشد حق ویرایش ان از طریق بخش 
            //پیشنویس در مکاتبات اداری وجود ندارد
            if (Current_Refer_Code == 0)// از قسمت مکاتبات قصد ویرایش دارد
            {
                Automation.JAObject obj = new Automation.JAObject();
                //آیا نامه یا پیشنویس به اتوماسیون ارسال شده است؟
                if (obj.FindObjectByExternalcode(ClassLibrary.Domains.JAutomation.JObjectType.Letters, Code, db))
                {
                    Except.NewException("you can just update from kartable");
                    return false;
                }
            }
            else
            {
                Automation.JAObject obj = new Automation.JAObject();
                //آیا نامه یا پیشنویس به اتوماسیون ارسال شده است؟
                if (obj.FindObjectByExternalcode(ClassLibrary.Domains.JAutomation.JObjectType.Letters, Code, db))
                {
                    obj.title = pre_subject;
                    obj.Save(db);
                }
            }
            if (letter_status == 0)
            {
                return false;
            }
            //----------- اطلاعات کاربر ثبت کننده -----------------------------------------------------------------------
            //register_user_code = JMainFrame.CurrentUserCode;// CurrentUser.code;
            //register_post_code = JMainFrame.CurrentPostCode;// CurrentUser.current_post_code;
            //register_user_full_title = (new Employment.JEOrganizationChart(JMainFrame.CurrentPostCode)).full_title;
            //------------------------------------------------------------------------------------------------------------           

            try
            {

                register_date_time = (new JDataBase().GetCurrentDateTime());
                // -----------------  ثبت اطلاعات نامه  -------------------
                JCLetterRegisterTable JST = new JCLetterRegisterTable();
                JST.SetValueProperty(this);
                if (JST.Update(db))
                {
                    // -----------------  ثبت رونوشت ها -------------------
                    JCLetterCopys JLC = new JCLetterCopys();
                    if (!JLC.Update(Code, pDTCopyes, db))
                    {
                        return false;
                    }
                    //----------------- ثبت ضمائم --------------------
                    if(pDTAttachments!=null)
                        if (!pDTAttachments.ArchiveList())
                        {
                            return false;
                        }
                    //----------------- ثبت متن نامه --------------------
                    if (pLetter != null)
                        if (!pLetter.ArchiveList())
                        {
                            return false;
                        }

                    if (WinWordControl != null)
                    {
                        if (!WinWordControl.SaveInOfficeWord(db, "Communication.JCLetter", Code, true))
                        {
                            return false;
                        }
                    }
                    //----------------- ویرایش عطف --------------------
                    JCRelatedLetter JRL = new JCRelatedLetter();
                    if (!JRL.DelUp(Code, pDTRelatedLetter, db))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                if (Nodes != null)
                {
                    JNode Node = Nodes.getNode(this.GetType().FullName, Code);
                    if (Node != null)
                        JST.SetRow(Node.Row);
                }
                pDTCopyes.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
            }
            return true;
        }
       
        /// <summary>
        /// ویرایش دستی نامه 
        /// </summary>
        /// <param name="pDTCopyes"></param>
        /// <returns></returns>
        public bool UpdateManual(int pLetterCode, int pStatus,JDataBase db)
        {
            //JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("Update " + JTableNamesLetters.Letters + " Set " + ClassLibrary.Letters.letter_status + "=" + pStatus + " WHERE [Code]=" + JDataBase.Quote(pLetterCode.ToString()));
                if (db.Query_Execute() > 0)
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                //db.Dispose();
            }
        }

        #endregion Bease Action

        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JCLetterRegister()
        {
        }
        /// <summary>
        /// سازنده
        /// </summary>
        public JCLetterRegister(int pCode)
        {
            if (pCode > 0)
                GetData(pCode);
            _Copy = false;
        }
        #endregion Constructors

        // Node
        #region Node
        public JNode GetNode(DataRow DR)
        {
            try
            {
                JNode Node = new JNode((int)DR[ClassLibrary.Letters.Code.ToString()], this.GetType().FullName);
                if (DR[ClassLibrary.Letters.receiver_full_title.ToString()] != DBNull.Value)
                {
                    Node.Name = (string)DR[ClassLibrary.Letters.receiver_full_title.ToString()];
                    Node.Icone = (int)JImageIndex.mail;

                    JAction EditLetter = new JAction("Edit", "Communication.JCLetterRegister.ShowEditForm", new object[] { (byte)DR[ClassLibrary.Letters.letter_type.ToString()], (int)DR[ClassLibrary.Letters.Code.ToString()] }, new object[] { 0 });
                    JAction DeleteLetter = new JAction("Delete", "Communication.JCLetterRegister.Delete_Nodes", null, new object[] { 0 });
                    JAction CopyLetter = new JAction("CopyLetter", "Communication.JCLetterRegister.Copy_Nodes", null, new object[] { 0 });

                    Node.MouseDBClickAction = EditLetter;
                    Node.Popup.Insert(EditLetter);
                    Node.Popup.Insert(DeleteLetter);
                    Node.Popup.Insert(CopyLetter);
                    return Node;
                }
                return null;
            }
            catch(Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Copy_Nodes()
        {
            try
            {
                foreach (JNode Node in Nodes.CurrentNodes)
                {
                    int CopyCode = Copy(Node.Code);
                    if (CopyCode > 0)
                    {
                        GetData(CopyCode);

                        JCLetterRegisterTable LRT = new JCLetterRegisterTable();
                        LRT.SetValueProperty(this);
                        Nodes.DataTable.Rows.Add(LRT.GetRow(Nodes.DataTable));
                    }
                }
                return;
            }
            catch (Exception e)
            {
                Except.AddException(e);
                return;
            }
        }
        /// <summary>
        /// حذف مینوت
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool Delete_Nodes()
        {
            try
            {
                foreach (JNode Node in Nodes.CurrentNodes)
                {
                    if (Delete(Node.Code))
                    {
                        Nodes.Delete(Node.ClassName, Node.Code);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Except.AddException(e);
                return false;
            }
        }
        
        #endregion Node

        public void ShowEditForm(int pLetterStatus, int pCode)
        {
            if (pLetterStatus == ClassLibrary.Domains.JCommunication.JLetterType.Import)
            {
                JCLetterRegisterImport Imp = new JCLetterRegisterImport(0);
                Imp.Current_Refer_Code = Current_Refer_Code;
                Imp.ShowDialog(pCode);
            }
            else
                if (pLetterStatus == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                {
                    JCLetterRegisterExport Imp = new JCLetterRegisterExport(0);
                    Imp.Current_Refer_Code = Current_Refer_Code;
                    Imp.ShowDialog(pCode);
                }
                else
                    if (pLetterStatus == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                    {
                        JCLetterRegisterInternal Imp = new JCLetterRegisterInternal(0);
                        Imp.Current_Refer_Code = Current_Refer_Code;
                        Imp.ShowDialog(pCode);
                    }
        }

        public bool ShowDialog(int pLetter_Code)
        {
            JfrmLetterRegister jLRImport = new JfrmLetterRegister(ClassLibrary.Domains.JCommunication.JLetterType.Internal, JFormState.Insert, pLetter_Code,Current_Refer_Code );
            jLRImport.State = JFormState.Insert;
            jLRImport.ShowDialog();
            return true;
        }
        /// <summary>
        /// چک کردن مجوز حذف نامه 
        /// </summary>
        /// <returns></returns>
        public bool CheckDeleteExport()
        {
            if (JPermission.CheckPermission("Communication.JCLetterRegister.CheckDeleteExport", 0, JMainFrame.CurrentPostCode, true))
                return true;
            else
                return false;
        }
        /// <summary>
        /// چک کردن مجوز حذف نامه 
        /// </summary>
        /// <returns></returns>
        public bool CheckDeleteImport()
        {
            if (JPermission.CheckPermission("Communication.JCLetterRegister.CheckDeleteImport", 0, JMainFrame.CurrentPostCode, true))
                return true;
            else
                return false;
        }
        /// <summary>
        /// چک کردن مجوز حذف نامه 
        /// </summary>
        /// <returns></returns>
        public bool CheckDelete()
        {
            if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
            {
                if (JPermission.CheckPermission("Communication.JCLetterRegister.CheckDelete", 0, JMainFrame.CurrentPostCode, true))
                    return true;
            }
            else
                if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)                
                    return CheckDeleteImport();                
                else
                    if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                    {
                        //if (JPermission.CheckPermission("Communication.JCLetterRegister.CheckConfirm", 0, JMainFrame.CurrentPostCode, pMsg))
                        return CheckDeleteExport();
                    }
            return false;
        }

        /// <summary>
        /// حذف مینوت
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool Delete(int pCode)
        {
            GetData(pCode);
            if (CheckDelete())
            {
                if (JMessages.Question("Are You Sure?", "Delete") == System.Windows.Forms.DialogResult.Yes)
                {
                    JCLetterRegisterTable tmpJCLetterRegisterTable = new JCLetterRegisterTable();
                    JDataBase db = JGlobal.MainFrame.GetDBO();
                    db.beginTransaction("LetterDelete");

                    try
                    {
                        Automation.JAObject obj = new Automation.JAObject();
                        if (obj.FindObjectByExternalcode(ClassLibrary.Domains.JAutomation.JObjectType.Letters, pCode))
                        {
                            Except.NewException("you can not delete becuse it is in automation system");
                            JMessages.Message("این نامه ارجاع زده شده و امکان حذف آن وجود ندارد ", "خطا", JMessageType.Error);
                            db.Rollback(db.TransactionName);
                            return false;
                        }
                        JCLetterCopy tmpJCLetterCopy = new JCLetterCopy();
                        if (tmpJCLetterCopy.FindByLetterCode(pCode, db))
                            if (!tmpJCLetterCopy.DelManual(pCode, db))
                            {
                                db.Rollback(db.TransactionName);
                                JMessages.Message(" امکان حذف رونوشت وجود ندارد ", "خطا", JMessageType.Error);
                                return false;
                            }

                        ArchivedDocuments.JArchiveDocument ArchiveDocument = new ArchivedDocuments.JArchiveDocument();
                        ArchiveDocument.DeleteArchive("Communication.JCLetterAttachment", pCode, false);
                        ArchiveDocument.DeleteArchive("Communication.JCLetter", pCode, false);

                        //JCLetterAttachment tmpJCLetterAttachment = new JCLetterAttachment();
                        //if (tmpJCLetterAttachment.FindByLetterCode(pCode, db))
                        //    if (!tmpJCLetterAttachment.DelManual(pCode, db))
                        //    {
                        //        db.Rollback(db.TransactionName);
                        //        return false;
                        //    }
                        JCRelatedLetter tmpJCRelatedLetter = new JCRelatedLetter();
                        if (tmpJCRelatedLetter.FindByLetterCode(pCode, db))
                            if (!tmpJCRelatedLetter.DelManual(pCode, db))
                            {
                                db.Rollback(db.TransactionName);
                                JMessages.Message(" امکان حذف وجود ندارد ", "خطا", JMessageType.Error);
                                return false;
                            }
                        if (!tmpJCLetterRegisterTable.DeleteManual("(" + ClassLibrary.Letters.letter_no + "='' or (" + ClassLibrary.Letters.letter_no + " is null)) And " + ClassLibrary.Letters.register_post_code + "= " + JMainFrame.CurrentPostCode + " And " + ClassLibrary.Letters.Code + "=" + pCode, db))
                        {
                            db.Rollback(db.TransactionName);
                            JMessages.Message(" امکان حذف وجود ندارد ", "خطا", JMessageType.Error);
                            return false;
                        }
                        //if (db.DataReader.`())
                        //   db.DataReader.Close();
                        db.Commit();
                        Nodes.Delete(Nodes.CurrentNode);
                        Histroy.Save(this, tmpJCLetterRegisterTable, Code, "Delete");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        db.Rollback(db.TransactionName);
                        Except.AddException(ex);
                        JMessages.Message(" امکان حذف وجود ندارد ", "خطا", JMessageType.Error);
                        return false;
                    }
                    finally
                    {
                        tmpJCLetterRegisterTable.Dispose();
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }

    #region PopUpMenu
        /// <summary>
        /// ثبت دبیرخانه
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ConSec(int pLetterCode)
        {
            JCLetterRegister tmpJCLetterRegister = new JCLetterRegister(pLetterCode);
            if (tmpJCLetterRegister.SendAttachmentToArchive())
                JMessages.Message("Archive Successfuly ", "", JMessageType.Information);
            else
                JMessages.Message("Archive Not Successfuly ", "", JMessageType.Error);
            this.Dispose();
        }
        /// <summary>
        /// کپی از یک مینوت 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CopyMinute(int pLetterCode)
        {
            int code = 0;
            if (pLetterCode != 0)
            {
                code = Copy(pLetterCode);
                if (code > 0)
                    JMessages.Message("Minute Register Successfuly with Number :" + Code.ToString(), "", JMessageType.Information);
                else
                    JMessages.Message("Minute Register Not Successfuly ", "", JMessageType.Error);
            }
            else
                JMessages.Message("Please Selected Minute ", "", JMessageType.Information);
        }
            
        /// آرشیو نامه
        public void ArchiveMinute(int pLetterCode)
        {
            if (pLetterCode != 0)
            {
                JCLetterRegister tmpJCLetterRegister = new JCLetterRegister(pLetterCode);
                if (tmpJCLetterRegister.ArshiveLetter(pLetterCode))
                    JMessages.Message("Arshive Letter Successfuly", "", JMessageType.Information);
                else
                    JMessages.Message("Arshive Letter Not Successfuly", "", JMessageType.Information);
            }
            else
                JMessages.Message("Please Selected Minute", "", JMessageType.Information);
        }
        /// <summary>
        /// ارجائ در منو
        /// </summary>
        /// <param name="pLetterCode"></param>
        /// <param name="pCurrentReferCode"></param>
        public void Refer(int pLetterCode)//, int pCurrentReferCode
        {
            if (pLetterCode != 0)
            {
                //JCLetterRegister tmp = new JCLetterRegister(pLetterCode);
                //int id = tmp.FirstSend();
                //if (id > 0)
                {
                    JReferMain p = new JReferMain("Communication.JCLetterRegister",pLetterCode,
                    ClassLibrary.Domains.JAutomation.JObjectType.Letters,
                    "Letter", "letter", null, true);//pCurrentReferCode
                    if (p.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LetterSend = true;
                        JMessages.Message("Refer Successfully", "", JMessageType.Information);
                        this.Dispose();
                    }
                }
                //else
                    //JMessages.Message("Error", "", JMessageType.Error);
            }
            else
                JMessages.Message("Please Selected Minute", "", JMessageType.Information);
        }
    #endregion
        /// <summary>
        /// تنظیم مقادیر کلاس
        /// </summary>
        /// <param name="pCode">کد نامه</param>
        /// <returns>Boolean</returns>
        public Boolean GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesLetters.Letters + " WHERE " + ClassLibrary.Letters.Code + "=" + JDataBase.Quote(pCode.ToString()));
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// کپی گیری از مینوت یا نامه
        /// </summary>
        /// <param name="pCode">کد نامه</param>
        /// <returns>Int</returns>
        public int Copy(int pCode)
        {
            JCLetterRegisterImport LRI = new JCLetterRegisterImport(0);
            JCLetterCopy tmpJCLetterCopy = new JCLetterCopy();
            //JCLetterAttachments tmpJCLetterAttachment = new JCLetterAttachments();
            JCRelatedLetter tmpJCRelatedLetter = new JCRelatedLetter();
            try
            {
                JTable.SetToClassProperty(LRI, LRI.GetDataLetter(pCode).Rows[0]);                
                LRI.letter_status = ClassLibrary.Domains.JCommunication.JLetterStatus.Minute;
                LRI.secretariat_code = 0;
                LRI.register_no = 0;
                LRI.letter_no = "";
                LRI.register_post_code = JMainFrame.CurrentPostCode;
                LRI.register_user_code = JMainFrame.CurrentUserCode;
                LRI.register_user_full_title = JMainFrame.CurrentPostTitle;
                LRI.Code = 0;
                LRI.Code = LRI.InsertLetter(tmpJCLetterCopy.GetDatatable(pCode),null,null , tmpJCRelatedLetter.GetDate(pCode));
                if (LRI.Code > 0)
                    Nodes.DataTable.Merge(JCLetterRegisters.GetDataTable(LRI.Code, letter_type));
                return LRI.Code;
            }
            finally
            {
                LRI.Dispose();
                tmpJCLetterCopy.Dispose();
                tmpJCRelatedLetter.Dispose();
            }
        }
        /// <summary>
        /// نامه بصورت جدول
        /// </summary>
        /// <returns></returns>
        public DataTable GetLetterTable()
        {
            if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
            {
                DataTable table = JCLetterRegisterInternals.GetDataTable(-1); // JCLetterRegisters.GetDataTable(-1, 0);
                DataRow row = table.NewRow();
                Employment.JEOrganizationChart chart = new Employment.JEOrganizationChart();
                DataTable infoTable = chart.InfoLetterInternal(sender_code, sender_post_code, receiver_code, receiver_post_code);
                JTable.SetToDataRow(this, row);

                row["Sender_Name"] = infoTable.Rows[0]["Sender_Name"];
                row["Sender_Post_Name"] = infoTable.Rows[0]["Sender_Post_Name"];
                row["Sender_Title_Job"] = infoTable.Rows[0]["Sender_Title_Job"];
                row["Receiver_Name"] = infoTable.Rows[0]["Receiver_Name"];
                row["Receiver_Post_Name"] = infoTable.Rows[0]["Receiver_Post_Name"];
                row["Receiver_Title_Job"] = infoTable.Rows[0]["Receiver_Title_Job"];
                row["register_date_timeFA"] = JGeneral.ReverseDate(JDateTime.FarsiDate(this.register_date_time));
                row["CopiesText"] = this.CopiesText;

                table.Rows.Clear();
                table.Rows.Add(row);
                return table;
            }

            else if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export)
            {
                DataTable table = JCLetterRegisterExports.GetDataTable(-1);
                DataRow row = table.NewRow();
                //FillDataTableLetter(drLetter);
                Employment.JEOrganizationChart chart = new Employment.JEOrganizationChart();
                DataTable tmpdt = chart.InfoLetterExport(sender_code, sender_post_code, receiver_external_code, receiver_external_code);

                row["Sender_Name"] = tmpdt.Rows[0]["Sender_Name"];
                row["Sender_Post_Name"] = tmpdt.Rows[0]["Sender_Post_Name"];
                row["Sender_Title_Job"] = tmpdt.Rows[0]["Sender_Title_Job"];
                row["Receiver_Name"] = tmpdt.Rows[0]["Receiver_Name"];
                row["Receiver_External_Name"] = tmpdt.Rows[0]["Receiver_External_Name"];

                table.Rows.Clear();
                table.Rows.Add(row);
                return table;
            }
            else return null;
        }
        /// <summary>
        /// جستجوی اطلاعات نامه
        /// </summary>
        /// <param name="pCode">کد نامه</param>
        /// <returns>Boolean</returns>
        public DataTable GetDataLetter(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesLetters.Letters + " WHERE " + ClassLibrary.Letters.Code + "=" + JDataBase.Quote(pCode.ToString()));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        ///جستجوی اطلاعات نامه بر اساس شماره نامه 
        /// </summary>
        /// <param name="pLetter_no">کد نامه</param>
        /// <returns>Boolean</returns>
        public DataTable GetDataLetterbyLetter_no(int pLetter_no)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesLetters.Letters + " WHERE " + ClassLibrary.Letters.letter_no + "=" + JDataBase.Quote(pLetter_no.ToString()));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// لیست مینوت های کاربری خاص
        /// </summary>
        /// <param name="register_user_code"></param>
        /// <param name="register_post_code"></param>
        /// <returns></returns>
        public DataTable FindMinute(int register_user_code, int register_post_code, int pLetter_Type)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = "";
                if (pLetter_Type != 0)
                    Where = " And " + ClassLibrary.Letters.letter_type + "=" + pLetter_Type.ToString();
                db.setQuery(
@"select 
Code,
(Select Fa_Date from StaticDates where En_Date = Cast(minute_register_date as date))+'   '+CONVERT(varchar,convert(time(0),minute_register_date)) AS 'minute_register_date',
letter_type,
letter_status,
subject_code,
pre_subject,
(Select Fa_Date from StaticDates where En_Date = register_date_time) 'register_date_time',
register_no,
letter_no,
incoming_no,
(Select Fa_Date from StaticDates where En_Date = incoming_date) 'incoming_date',
incoming_signature_person,
sender_post_code,
sender_code,
sender_full_title,
sender_external_code,
receiver_post_code,
receiver_code,
receiver_full_title,
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
summary 

                FROM " + JTableNamesLetters.Letters + " WHERE  "
                        + ClassLibrary.Letters.letter_status + "=" + ClassLibrary.Domains.JCommunication.JLetterStatus.Minute 
                        //+ " And " + Letters.register_user_code + "=" + register_user_code.ToString() 
                        + " And " + ClassLibrary.Letters.register_post_code + "=" + register_post_code + Where +" ORDER BY Code DESC");
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// ثبت یک نامه شامل گرفتن شماره از دبیرخانه و ارسال له کارتابل دریافت کنندگان
        /// نامه باید حتما قبلا به سیستم اتومایبون ارسال شده باشد
        /// </summary>
        /// <param name="pLetterCode"></param>
        /// <param name="pRefer_Code"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool RegRefer(int pLetterCode, JDataBase db)
        {
            try
            {
                Automation.JARefer tmprefer = new Automation.JARefer();
                Automation.JAObject tmpJAObject = new Automation.JAObject();
                bool getData = tmpJAObject.FindObjectByExternalcode(ClassLibrary.Domains.JAutomation.JObjectType.Letters, pLetterCode, db);

                if (!getData)
                {
                    if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                    {
                        int OjectBCode =  tmprefer.SendToAutomation(Code,
                    ClassLibrary.Domains.JAutomation.JObjectType.Letters,
                    "Letter",  pre_subject , "Communication.JCLetterRegister", db,
                    this.sender_full_title,this.sender_post_code,this.sender_code,true);
                        tmpJAObject.GetData(OjectBCode, db);
                    }
                    else
                    {
                        return false;
                    }
                }
                 

                // اطلاعات نامه در سیستم اتوماسیون
                tmprefer.object_code = tmpJAObject.Code;
                tmprefer.parent_code = Current_Refer_Code;

                //ارسال کننده نامه
                if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                {
                    tmprefer.sender_full_title = sender_full_title;
                    tmprefer.sender_External_code = sender_external_code;
                }
                else
                {
                    //tmprefer.sender_post_code = sender_post_code;
                    //tmprefer.sender_code = sender_code;
                    //tmprefer.sender_full_title = sender_full_title;
                    tmprefer.sender_post_code = JMainFrame.CurrentPostCode;
                    tmprefer.sender_code = JMainFrame.CurrentUserCode;
                    tmprefer.sender_full_title = JMainFrame.CurrentPostTitle;
                }
                //tmprefer.Sender_External_Code
                tmprefer.send_date_time = (new JDataBase().GetCurrentDateTime());
                tmprefer.register_user_code = JMainFrame.CurrentUserCode;
                //دریافت کننده نامه
                if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                {
                    tmprefer.receiver_full_title = receiver_full_title;
                    tmprefer.receiver_External_code = receiver_external_code;
                }
                else
                {
                    tmprefer.receiver_post_code = receiver_post_code;
                    tmprefer.receiver_code = receiver_code;
                    tmprefer.receiver_full_title = receiver_full_title;
                }
                //tmprefer.Reciver_External_Code

                tmprefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
                tmprefer.secret_level = secret_level;
                tmprefer.is_active = true;

                tmprefer.urgency = urgency;

                if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                    tmprefer.refertype = ClassLibrary.Domains.JAutomation.JReferType.External;
                if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import ||
                    letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                    tmprefer.refertype = ClassLibrary.Domains.JAutomation.JReferType.Internal;

                if (RegisterRefer(tmprefer, db) < 1)
                {
                    return false;
                }

               
                ///ارجاع رنوشت های نامه
                JCLetterCopys tmpJCLetterCopys = new JCLetterCopys();
                JCLetterCopy LetterCopy = new JCLetterCopy();
                foreach (DataRow drCopy in tmpJCLetterCopys.GetCopys(pLetterCode, db).Rows)
                {
                    LetterCopy.GetData((int)drCopy["Code"],db);
                    if (LetterCopy.copy_type == ClassLibrary.Domains.JAutomation.JReferType.External)
                    {
                        tmprefer.receiver_full_title = LetterCopy.receiver_full_title;
                    }
                    else
                    {
                        tmprefer.receiver_post_code = LetterCopy.receiver_post_code;
                        tmprefer.receiver_code = LetterCopy.receiver_user_code;
                        tmprefer.receiver_full_title = LetterCopy.receiver_full_title;
                    }
                    tmprefer.refertype = LetterCopy.copy_type;
                    tmprefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
                    tmprefer.secret_level = secret_level;
                    tmprefer.ReferLevel--;
                    if (drCopy["respite_date_time"].ToString() != "")
                        tmprefer.respite_date_time = JDateTime.GregorianDate(drCopy["respite_date_time"].ToString());
                    _Copy = true;
                    if (RegisterRefer(tmprefer, db) < 1)
                        return false;
                }
                //ویرایش وضعیت ارجاع قبلی
                //if (Current_Refer_Code != 0)
                //{
                //    if (!tmprefer.UpdateRefer(Current_Refer_Code, ClassLibrary.Domains.JAutomation.JReferStatus.Sent, db))
                //    {
                //        db.Rollback(db.TransactionName);
                //        return false;
                //    }
                //}

                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
        }
        /// <summary>
        /// ارسال یک پیشنویس به دبیرخانه باید ابتدا نامه به ابجکت ارسال گرددو
        /// سپس یک ارجا به مسئول دبیرخانه بفرستد
        /// </summary>
        /// <param name="pLetterCode"></param>
        /// <param name="pRefer_Code"></param>
        /// <param name="pLetterType"></param>
        public bool RegSecretariats(JDataBase db)
        {
            try
            {
                //--------------------------------------------------------------------------------
                // ایا نامه قبلا به اتوماسیون ارسال شده است در غیر اینصورت ارسال گردد
                //int ObjectCode = GetAutomationObjectCode(Code, db);
                //if (ObjectCode < 1)
                //{
                //    ObjectCode = SendToAutomation(Code, db);
                //    if (ObjectCode < 1)
                //        return false;
                //}
                //---------------------------------------------------------------------------------
                Automation.JARefer tmprefer = new Automation.JARefer();
                int ObjectCode = tmprefer.SendToAutomation(Code,
                    ClassLibrary.Domains.JAutomation.JObjectType.Letters,
                    "Letter", pre_subject, "Communication.JCLetterRegister", db, 
                    this.sender_full_title, this.sender_post_code, this.sender_code, true);

                tmprefer.object_code = ObjectCode;
                tmprefer.refertype = ClassLibrary.Domains.JAutomation.JReferType.Internal;
                tmprefer.parent_code = Current_Refer_Code;
                //---------------------ارسال کننده----------------------------
                tmprefer.sender_post_code = JMainFrame.CurrentPostCode;
                tmprefer.sender_code = JMainFrame.CurrentUserCode;
                tmprefer.sender_full_title = JMainFrame.CurrentPostTitle;
                //----------------------------------------------------------
                tmprefer.send_date_time = (new JDataBase().GetCurrentDateTime());
                //----------------دریافت کننده مسئول دبیرخانه است

                Employment.JEOrganizationChart tmpChart = new Employment.JEOrganizationChart();
                // باید ارسال کننده به یک دبیرخانه وصل باشد
                //tmpChart.GetData(tempRefer.receiver_code) تغییر در تاریخ 17/12/89

                JCSecretariat tmpJCSecretariat = new JCSecretariat();

                if (!tmpChart.GetData(sender_post_code) && tmpChart.secretariat_code < 1)
                {
                    Except.NewException("Sender is NOT in a Secretarait!");
                    return false;
                }
                else
                {
                    secretariat_code = tmpChart.secretariat_code;
                    tmpJCSecretariat.GetData(secretariat_code);
                    tmprefer.receiver_post_code = tmpJCSecretariat.Manager_user_post_code;
                    Employment.JEOrganizationChart EOChart = new Employment.JEOrganizationChart(tmpJCSecretariat.Manager_user_post_code);
                    tmprefer.receiver_code = EOChart.user_code;
                    tmprefer.receiver_full_title = EOChart.full_title;
                    JMessages.Message(" " + "  ارسال به دبیرخانه" + "  " + tmpJCSecretariat.Name.ToString() + "-" +  tmprefer.receiver_full_title.ToString() + " " + "انجام گردید  ", "", JMessageType.Information);
                }
                
                //---------------------------------------------------------------------
                tmprefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
                tmprefer.is_active = true;
                tmprefer.parent_code = Current_Refer_Code;
                //---------------------------------------------------------------------
                if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                    tmprefer.refertype = ClassLibrary.Domains.JAutomation.JReferType.External;
                if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import ||
                    letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                    tmprefer.refertype = ClassLibrary.Domains.JAutomation.JReferType.Internal;
                //---------------------ثبت کننده----------------------------
                tmprefer.register_user_code = JMainFrame.CurrentUserCode;
                tmprefer.register_Date_Time = (new JDataBase().GetCurrentDateTime());
                tmprefer.respite_date_time = Respite_date_time.Date;
                if (RegisterRefer(tmprefer, db) < 1)
                {
                    //db.Rollback(db.TransactionName);
                    return false;
                }
                ////ویرایش وضعیت ارجاع قبلی
                //if (Current_Refer_Code != 0)
                //{
                //    if (!tmprefer.UpdateRefer(Current_Refer_Code, ClassLibrary.Domains.JAutomation.JReferStatus.Sent, db))
                //    {
                //        db.Rollback(db.TransactionName);
                //        return false;
                //    }
                //}
                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }

        /// <summary>
        /// چک کردن مجوز امضا نامه وارده 
        /// </summary>
        /// <returns></returns>
        public bool CheckConfirmInternal(bool pMsg)
        {
            if (JPermission.CheckPermission("Communication.JCLetterRegister.CheckConfirmInternal", 0, JMainFrame.CurrentPostCode, pMsg))
                return true;
            else
                return false;
        }
            /// <summary>
        ///  چک کردن مجوز امضا نامه صادره
        /// </summary>
        /// <returns></returns>
        public bool CheckConfirmExports(bool pMsg)
        {
            if (JPermission.CheckPermission("Communication.JCLetterRegister.CheckConfirmExports", 0, JMainFrame.CurrentPostCode, pMsg))
                return true;
            else
                return false;
        }
        /// <summary>
        /// چک کردن مجوز امضا نامه 
        /// </summary>
        /// <returns></returns>
        public bool CheckConfirm(bool pMsg)
        {
            if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                return CheckConfirmInternal(pMsg);
            if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)                
                return false;                
            if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                return CheckConfirmExports(pMsg);
             return false;
        }

        //امضا نامه
        public bool SignatureLetter()
        {
            if (CheckConfirm(false))
            {
                //-----------------------امضا کردن نامه -------------
                // در امضا نامه داخلی و صادر باید ارسال کننده به دبیرخانه و فرستنده نامه یکنفر باشند
                if ((letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal ||
                    letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export) &&
                    JMainFrame.CurrentPostCode != sender_post_code)
                {
                    //receiver_full_title = sender_full_title;
                    return false;
                }
                //    //-------------------- پیشنویس قبلاً امضا شده باشد
                if (letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept)
                {
                    return false;
                }
                if (JMessages.Question("Do you want signature Letter?", "Signature") == System.Windows.Forms.DialogResult.Yes)
                    letter_status = ClassLibrary.Domains.JCommunication.JLetterStatus.Accept;
                return true;
            }
            return false;
        }

        /// <summary>
        /// ارسال یک نامه یا پیشنویس از یکنفر به نفر دیگر
        /// ثبت در جدول ارجاعات با شرایط خاص
        /// </summary>
        /// <param name="tmpJRefer"></param>
        /// <returns></returns>
        public int RegisterRefer(Automation.JARefer pRefer, JDataBase pDB)
        {
            try
            {
                JARefer tempRefer = new JARefer();
                int RetCode = 0;
                int Flag = 0;
                if (secretariat_code < 1 && register_no < 1) // پیشنویس است
                {
                }
                else
                    // ارجا پیشنویس از کارکنان دبیرخانه به یک دیگر یا یک نفر دیگر . در هر صورت پیش نویس است
                    if (secretariat_code > 0 && register_no < 1)
                    {
                    }
                    //--------------- ارجا یک نامه از یک نفر به نفر بعدی
                    else
                        if (secretariat_code > 0 && register_no > 0)
                        {
                            //نامه داخلی  یا وارده هست
                            if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal ||
                                letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                            {
                                Employment.JEOrganizationChart SendPost = new Employment.JEOrganizationChart(pRefer.sender_post_code);
                                Employment.JEOrganizationChart RecivPost = new Employment.JEOrganizationChart(pRefer.receiver_post_code);
                                if (letter_type != ClassLibrary.Domains.JCommunication.JLetterType.Import && SendPost.secretariat_code == 0)
                                {
                                    JMessages.Error("Sender not Connect to a Secretariat", "Error");
                                    return -1;
                                }
                                if (letter_type != ClassLibrary.Domains.JCommunication.JLetterType.Export && RecivPost.secretariat_code == 0)
                                {
                                    JMessages.Error("Receiver not Connect to a Secretariat", "Error");
                                    return -1;
                                }

                                // دبیرخانه ها متفاوت هستند و ارسال به دبیخانه بجای کاربر
                                if (false && letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter && 
                                    letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal &&
                                    SendPost.secretariat_code != RecivPost.secretariat_code)
                                {
                                    Flag = 1;
                                    JCSecretariat secretariat = new JCSecretariat();
                                    secretariat.GetData(RecivPost.secretariat_code);
                                    Employment.JEOrganizationChart newReciver = new Employment.JEOrganizationChart(secretariat.Manager_user_post_code);

                                    //فرستنده برای ارسال بعدی ذخیره میگردد
                                    tempRefer.receiver_post_code = pRefer.receiver_post_code;
                                    tempRefer.receiver_code = pRefer.receiver_code;
                                    tempRefer.receiver_full_title = pRefer.receiver_full_title;
                                    tempRefer.object_code = pRefer.object_code;

                                    pRefer.receiver_post_code = secretariat.Manager_user_post_code;
                                    pRefer.receiver_code = newReciver.user_code;
                                    pRefer.receiver_full_title = newReciver.full_title;
                                    pRefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Sent;
                                }
                            }
                        }
               
                pRefer.parent_code = Current_Refer_Code;
                pRefer.DescriptionObject = JCLetter._setLetterDescriptionObject(letter_status, letter_no) + JLanguages._Text(ClassLibrary.Domains.JAutomation.JReferStatus.GetName(letter_status));

                /// تعیین گروه ارجا برای نمایش در چارت
                if (letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Minute)
                    pRefer.ReferGroup = 1;
                if (letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept)
                    pRefer.ReferGroup = 2;
                if (letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
                    pRefer.ReferGroup = 3;

                if (_Copy == false)
                    RetCode = pRefer.Insert(pDB);
                else
                {
                    _Copy = false;
                    RetCode = pRefer.Insert(pDB,false);
                }

                //اگر دبیرخانه ها متفاوت بود ارجاع از دبیرخانه بعدی به فرد
                if (Flag == 1)
                {
                    tempRefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
                    tempRefer.parent_code = RetCode;

                    tempRefer.is_active = pRefer.is_active;
                    tempRefer.send_date_time = pRefer.send_date_time;
                    tempRefer.register_user_code = pRefer.register_user_code;
                    tempRefer.secret_level = pRefer.secret_level;
                    tempRefer.urgency = pRefer.urgency;
                    tempRefer.register_Date_Time = pRefer.register_Date_Time;
                    //دبیرخانه فرستنده می شود
                    tempRefer.sender_post_code = pRefer.receiver_post_code;
                    tempRefer.sender_code = pRefer.receiver_code;
                    tempRefer.sender_full_title = pRefer.receiver_full_title;
                    //گیرنده همان گیرنده اولیه است
                    //tempRefer.receiver_post_code = tempRefer.sender_post_code;
                    //tempRefer.receiver_code = tempRefer.sender_code;
                    //tempRefer.receiver_full_title = tempRefer.sender_full_title;

                    tempRefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;

                    tempRefer.DescriptionObject = JCLetter._setLetterDescriptionObject(letter_status, letter_no) + JLanguages._Text(ClassLibrary.Domains.JAutomation.JReferStatus.GetName(letter_status)); ;
                    if (letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Minute)
                        tempRefer.ReferGroup = 1;
                    if (letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept)
                        tempRefer.ReferGroup = 2;
                    if (letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
                        tempRefer.ReferGroup = 3;

                    RetCode = tempRefer.Insert(pDB, false);

                    if (RetCode > 0)
                    {
                        Employment.JEOrganizationChart tmpChart = new Employment.JEOrganizationChart();
                        // باید ارسال کننده به یک دبیرخانه وصل باشد
                        //tmpChart.GetData(tempRefer.receiver_code) تغییر در تاریخ 17/12/89
                        
                        JCSecretariat tmpJCSecretariats = new JCSecretariat();
                        if (!tmpChart.GetData(tempRefer.receiver_post_code) && tmpChart.secretariat_code < 1)
                        {
                            pDB.Rollback(pDB.TransactionName);
                            Except.NewException("Sender is NOT in a Secretarait!");
                            return 0;
                        }
                        else
                        {
                            // HassanZadeh 
                            secretariat_code = tmpChart.secretariat_code;
                            tmpJCSecretariats.GetData(secretariat_code, pDB);
                            Employment.JEOrganizationChart EOChart = new Employment.JEOrganizationChart(tmpJCSecretariats.Manager_user_post_code);
                            JMessages.Information(" " + " ارسال به دبیرخانه" + "  " + tmpJCSecretariats.Name.ToString() + "-" + EOChart.full_title.ToString() + "  " + "انجام گردید  ", "");
                        }
                            

                        int pSecretariat_code = tmpChart.secretariat_code;
                        JCSecretariatLetter tmpJCSecretariatLetter = new JCSecretariatLetter();
                        
                        int NewNumber = tmpJCSecretariats.GetRegister_NO(pSecretariat_code, pDB);
                        if (NewNumber < 1)
                        {
                            Except.NewException("secretariat_code is ZERO!");
                            return 0;
                        }
                        tmpJCSecretariatLetter.register_no = NewNumber;
                        tmpJCSecretariatLetter.letter_no = tmpJCSecretariats.Prifix + NewNumber.ToString() + tmpJCSecretariats.Suffix;

                        tmpJCSecretariatLetter.Letter_Code=Code;
                        tmpJCSecretariatLetter.register_date_time = (new JDataBase().GetCurrentDateTime());
                        tmpJCSecretariatLetter.register_post_code = pRefer.sender_post_code;
                        tmpJCSecretariatLetter.secretariat_code = pSecretariat_code;
                        tmpJCSecretariatLetter.Insert(pDB);
                    }
                    else
                    {
                        pDB.Rollback(pDB.TransactionName);
                       return 0;
                    }
                }
                LetterSend = true;
                return RetCode;
            }
            catch
            {
                pDB.Rollback(pDB.TransactionName);
                return 0;
            }
        }



        /// <summary>
        /// آرشیو نامه
        /// </summary>
        /// <returns></returns>
        public bool ArshiveLetter(int pLetterCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            //if (!UpdateManual(pLetterCode, ClassLibrary.Domains.JCommunication.JLetterStatus.Archive, db))
            //{
            //    db.Rollback(db.TransactionName);
            //    return false;
            //}
            
            ///ارجاع بایگانی نامه
                JARefer tmprefer = new JARefer();
                JARefer tmpreferNew = new JARefer();
                JCLetterRegister tmpLetter = new JCLetterRegister(pLetterCode);                
                tmprefer.GetData(Current_Refer_Code);
                tmprefer.parent_code = Current_Refer_Code;
                tmprefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Finish;

                if (tmpLetter.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
                {
                    if (tmprefer.Update(db))
                    {
                        tmpreferNew = tmprefer;
                        tmpreferNew.sender_full_title = JMainFrame.CurrentPostTitle;
                        tmpreferNew.sender_post_code = JMainFrame.CurrentPostCode;
                        tmpreferNew.sender_code = JMainFrame.CurrentUserCode;
                        Employment.JEOrganizationChart RecivPost = new Employment.JEOrganizationChart(receiver_post_code);
                        JCSecretariat secretariat = new JCSecretariat();
                        secretariat.GetData(RecivPost.secretariat_code);
                        tmpreferNew.receiver_post_code = secretariat.Manager_user_post_code;
                        Employment.JEOrganizationChart newReciver = new Employment.JEOrganizationChart(secretariat.Manager_user_post_code);
                        tmpreferNew.receiver_code = newReciver.user_code;
                        tmpreferNew.receiver_full_title = newReciver.full_title;
                        tmpreferNew.DescriptionObject = JCLetter._setLetterDescriptionObject(letter_status,letter_no) + JLanguages._Text(ClassLibrary.Domains.JAutomation.JReferStatus.GetName(letter_status));
                        if (tmprefer.Insert(db) < 1)
                        {
                            db.Rollback(db.TransactionName);
                            return false;
                        }
                        else
                            return true;
                    }
                    else
                    {
                        db.Rollback(db.TransactionName);
                        return false;
                    }
                }
                else
                    JMessages.Information(" لطفا نامه انتخاب کنید", "");
                //if (!RegisterRefer(tmprefer, db))
                //{
                //    db.Rollback(db.TransactionName);
                //    return false;
                //}
                return true;                            
        }

        public bool SendAttachmentToArchive()
        {
            //DataTable pdtAttachment = new DataTable();
            //JCLetterAttachments tmpJCLetterAttachments = new JCLetterAttachments();
            //pdtAttachment=tmpJCLetterAttachments.GetAttachments(Code);
            //ArchivedDocuments.JArchiveForm tmp = new ArchivedDocuments.JArchiveForm("Communication.JCLetter", Code);
            ////frmArchiveFiles tmp = new frmArchiveFiles(_LetterCode);
            //foreach (DataRow dr in pdtAttachment.Rows)
            //{
            //    JFile attachment = new JFile();
            //    attachment.Content = (byte[])dr["file_content"];
            //    attachment.FileText = (string)dr["file_text"];
            //    attachment.FileName = dr["file_name"].ToString();
            //    tmp.Files.Add(attachment);
            //}
            //if (tmp.ShowDialog() > 0)
            //{
            //    //JDataBase db = JGlobal.MainFrame.GetDBO();
            //    //JCLetterAttachment tmpAttachment = new JCLetterAttachment();
            //    //int[] FileCode=tmpAttachment.Update(tmp.ArchivedCodes, pdtAttachment, db);
            //    //if (FileCode.Length > 0)
            //    //    if (tmpAttachment.Delete(FileCode, db) > 0)
            //    //        return true;
            //    //    else
            //    //        return false;
            //    //else
            //    //    return false;
            //}
            //tmp.Dispose();
            return true;
        }

        /// <summary>
        /// کلاس پدر ثبت نامه ها
        /// </summary>
    }

    public class JCLetterRegisters : JCommunication
    {
        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JCLetterRegisters()
        {
        }
        #endregion Constructors

        /// <summary>
        /// لیست اطلاعات براساس نوع نامه
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="pStatusForm"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode, int pStatusForm)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = "select * from " + JTableNamesLetters.Letters + " Where  letter_type=" + pStatusForm;// +
                    //JPermission.getObjectSql("Legal.JDecisions.GetDataTable");
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

        // View Nodes
        #region View
        public JNode[] TreeView()
        {

            return null;
        }
        public void ListView()
        { 

            Nodes.Insert(JAStaticNode._LetterRegisterImportsNode());
            Nodes.Insert(JAStaticNode._LetterRegisterExportsNode());
            Nodes.Insert(JAStaticNode._LetterRegisterInternalsNode());
            //foreach (JLetter Sec in Items)
            //{
            //    Nodes.Insert(Sec.GetNode());
            //}
        }

        #endregion View
    }
}
