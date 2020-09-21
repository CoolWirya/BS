using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Communication
{
    class JCLetterAttachment : JCommunication
    {
        #region Peroperties & Feilds
        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد نامه
        /// </summary>
        public int letter_code { get; set; }
        /// <summary>
        /// نام فایل
        /// </summary>
        public string file_name { get; set; }
        /// <summary>
        /// عنوان فایل
        /// </summary>
        public string file_title { get; set; }
        /// <summary>
        /// نوع ضمیمه
        /// </summary>
        public int file_type { get; set; }
        /// <summary>
        /// کد پست ایجاد کننده
        /// </summary>
        public int creator_user_post { get; set; }
        /// <summary>
        /// کد کاربر ایجاد کننده
        /// </summary>
        public int creator_user_code { get; set; }
        /// <summary>
        /// نام کامل ایجاد کننده
        /// </summary>
        public string creator_user_full_title { get; set; }
        /// <summary>
        /// تاریخ و زمان ایجاد
        /// </summary>
        public DateTime create_date_time { get; set; }
        /// <summary>
        /// کد نسخه قبلی
        /// </summary>
        public int previous_version_code { get; set; }
        /// <summary>
        /// کد فایل ضمیمه
        /// </summary>
        public int letter_file_code { get; set; }
        /// <summary>
        /// کد فایل ضمیمه در آرشیو
        /// </summary>
        public int archive_file_code { get; set; }
        /// <summary>
        /// وضعیت حذف
        /// </summary>
        public bool is_deleted { get; set; }
        /// <summary>
        /// کد پست حذف کننده
        /// </summary>
        public int deleted_user_post { get; set; }
        /// <summary>
        /// کد کاربر حذف کننده
        /// </summary>
        public int deleted_user_code { get; set; }
        /// <summary>
        /// نام کامل حذف کننده
        /// </summary>
        public string deleted_user_full_title { get; set; }
        /// <summary>
        /// وضعیت فایل اصلی بودن
        /// </summary>
        public bool is_main_file { get; set; }
        /// <summary>
        /// تاریخ و زمان حذف
        /// </summary>
        public DateTime deleted_create_date_time { get; set; }
        /// <summary>
        /// فایل
        /// </summary>
        public Letter_Attachment_File File;
        /// <summary>
        /// ساختار فایل
        /// </summary>
        public struct Letter_Attachment_File
        {
            public int Code;
            public byte[] file_content;
            public string file_xml;
            public string file_text;
        }
        /// <summary>
        /// نوع سایر فایل های غیر از ورد و اسکن شده ها
        /// </summary>
        public int other_file_type { get; set; }

        #endregion  Peroperties & Feilds

        #region Insert,Update,Delete
        
        /// <summary>
        /// ثبت ضمیمه جدید
        /// </summary>
        public int Insert(JDataBase db)
        {
            letter_file_code = InsertFile(db);


            if (letter_file_code == -1)
                return -1;

            JCLetterAttachmetTable JLA = new JCLetterAttachmetTable();
            JLA.SetValueProperty(this);
                            // -----------------  ثبت اطلاعات نامه  -------------------
            int NewLetterFileCode = JLA.Insert(db);
            if (NewLetterFileCode < 1)
            {
                db.Rollback(db.TransactionName);
                return -1;
            }
            return Convert.ToInt32(NewLetterFileCode);

        }

        /// <summary>
        /// ثبت فایل جدید
        /// </summary>
        public int InsertFile(JDataBase db)
        {
            string Sql = "";
            
            db.Params.Clear();
            db.AddParams("@Content", File.file_content);
            db.AddParams("@Text", File.file_text);
            Sql = @"DECLARE @Code INT
                SET @Code = ISNULL((SELECT MAX(Code) FROM letterattachmentfiles),0)+1
                INSERT INTO letterattachmentfiles VALUES(@Code,@Content,@Text)SELECT @Code";
            object File_Code;
            try
            {
                db.setQuery(Sql);
                File_Code = db.Query_ExecutSacler();
            }
            

            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Rollback(db.TransactionName);
                return -1;
            }

            if (File_Code == null)
            {
                db.Rollback(db.TransactionName);
                return -1;
            }

            return Convert.ToInt32(File_Code);
        }
        /// <summary>
        /// حذف فایل ها
        /// </summary>
        /// <param name="pLetterCode"></param>
        /// <returns></returns>
        public int Delete(int[] pFileCode, JDataBase db)
        {
            try
            {
                string strCode = "";
                for (int i = 0; i < pFileCode.Length; i++)
                    strCode = strCode + pFileCode[i].ToString() + ",";
                strCode = strCode + "0";
                db.setQuery(@"Delete from letterattachmentfiles where Code in (" + strCode + ")");
                //            db.setQuery(@"Delete from letterattachmentfiles where Code in (select letter_file_code from letterattachments LA inner join letterattachmentfiles LAF on LA.letter_file_code=LAF.Code
                //Where LA.letter_code= " + pLetterCode.ToString() + ")");
                return db.Query_Execute();
            }
            catch (Exception ex)
            {
                Except.AddException(ex); 
                db.Rollback(db.TransactionName);
               return -1;

            }            
        }

        /// <summary>
        /// حذف رونوشت
        /// </summary>
        /// <returns></returns>
        public bool DelManual(int pLetterCode, JDataBase db)
        {
            JCLetterAttachmetTable JST = new JCLetterAttachmetTable();
            return JST.DeleteManual(" Letter_Code= " + pLetterCode, db);
        }

        #endregion Insert,Update,Delete

        #region MyFunction
        /// <summary>
        /// ایجاد الگوی جدول ضمائم
        /// </summary>
        public DataTable GetDataTablePatern()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Code", typeof(int));
            dt.Columns.Add("file_name");
            dt.Columns.Add("file_title");
            dt.Columns.Add("file_type");
            dt.Columns.Add("creator_user_full_title");
            dt.Columns.Add("create_date_time");
            dt.Columns.Add("is_main_file");
            dt.Columns.Add("file_content",typeof(byte[]));
            dt.Columns.Add("file_text");
            dt.Columns.Add("other_file_type");
            dt.Columns.Add("previous_version_code");
            dt.Columns.Add("is_new",typeof(bool));
            return dt;
        }

        /// <summary>
        /// جستجوی  
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        public Boolean FindByLetterCode(int pCode, JDataBase pDB)
        {
            try
            {
                pDB.setQuery("SELECT * FROM letterattachments WHERE Letter_Code=" + JDataBase.Quote(pCode.ToString()));
                pDB.Query_DataReader();
                return pDB.DataReader.HasRows;
            }
            finally
            {
                // pDB.Dispose();
            }
        }

        /// <summary>
        /// جستجوی ضمیمه خاص بر اساس کد آن
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                try
                {
                    DB.setQuery("SELECT * FROM " + JTableNamesLetters.Letterattachments + " WHERE " + LetterAttachmets.Code + "=" + pCode.ToString());
                    DB.Query_DataReader();
                    if (DB.DataReader.Read())
                        JTable.SetToClassProperty(this, DB.DataReader);
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                }
            }
            finally
            {
                DB.Dispose();
            }
            return true;
        }

        /// <summary>
        /// بروزرسانی کلاس
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="pName"></param>
        /// <param name="pDefaultValue"></param>
        /// <param name="pSQL"></param>
        /// <returns></returns>
        public Boolean Update(JDataBase pDB)
        {
            JCLetterAttachmetTable PDC = new JCLetterAttachmetTable();
            try
            {
                PDC.SetValueProperty(this);
                return PDC.Update(pDB);
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
            }
            return false;
        }
        /// <summary>
        /// ویرایش ضمائم موقع ارسال به آرشیو
        /// </summary>
        /// <param name="pLetterCode"></param>
        /// <param name="pDT"></param>
        /// <param name="pDB"></param>
        /// <returns></returns>
        public int[] Update(int[] pArchiveCode, DataTable pDT, JDataBase pDB)
        {
            int[] CodeFile=new int[0];
            ///int[] CodeFile = new int[]{0};
            try
            {
                for (int i = 0; i < pDT.Rows.Count; i++)
                {
                    GetData(Convert.ToInt32(pDT.Rows[i]["Code"].ToString()));
                    archive_file_code = pArchiveCode[i];
                    Array.Resize(ref CodeFile, i + 1);
                    CodeFile[i] =  letter_file_code;

                    letter_file_code = 0;
                    if (!Update(pDB))
                    {
                        pDB.Rollback(pDB.TransactionName);
                        return CodeFile;
                    }                    
                }
                return CodeFile;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return CodeFile;
            }
            finally
            {
            }
            return CodeFile;
        }

        #endregion MyFunction

    }
    class JCLetterAttachments : JCommunication
    {
        public bool Insert(int pLetterCode,int pRegister_no, DataTable pDT, JDataBase pDB)
        {
            if (pDT == null)
                return false;

            //--------------------  بدست آوردن اطلاعات کاربر جاری ---------------------------------------------------------
            string CurrentUser_full_title = (new Employment.JEOrganizationChart(JMainFrame.CurrentPostCode)).full_title;


            for (int i = 0; i < pDT.Rows.Count; i++)
            {
                
                JCLetterAttachment JLA = new JCLetterAttachment();
                //-------------------- کد نامه -------------------------------------------------------------------------------
                JLA.letter_code = pLetterCode;
                //-------------------- نام فایل ------------------------------------------------------------------------------
                JLA.file_name = pDT.Rows[i]["file_name"].ToString();
                //-------------------- عنوان فایل ----------------------------------------------------------------------------
                JLA.file_title = pDT.Rows[i]["file_title"].ToString();
                //-------------------- نوع فایل ------------------------------------------------------------------------------
                JLA.file_type = Convert.ToInt32(pDT.Rows[i]["file_type"]);
                //-------------------- تاریخ و زمان ایجاد --------------------------------------------------------------------
                JLA.create_date_time = (new JDataBase().GetCurrentDateTime());
                //-------------------- وضعیت فایل اصلی بودن ------------------------------------------------------------------
                JLA.is_main_file = Convert.ToBoolean(pDT.Rows[i]["is_main_file"]);
                //------------------------------------------------------------------------------------------------------------
                JLA.File.file_content = ((byte[])pDT.Rows[i]["file_content"]);
                JLA.File.file_text = pDT.Rows[i]["file_text"].ToString();
                //----------- اطلاعات کاربر ایجاد کننده -----------------------------------------------------------------------
                JLA.creator_user_code = JMainFrame.CurrentUserCode;
                JLA.creator_user_post = JMainFrame.CurrentPostCode;
                JLA.creator_user_full_title = CurrentUser_full_title;
                if (pDT.Rows[i]["other_file_type"] != null && ClassLibrary.JGeneral.is_Number(pDT.Rows[i]["other_file_type"]))
                {
                   JLA.other_file_type =  Convert.ToInt32(pDT.Rows[i]["other_file_type"]);
                }
                //------------------------------------------------------------------------------------------------------------

                //===================== ثبت تاریخچه ========================
                if (pDT.Rows[i]["previous_version_code"] != null)
                {
                    JLA.previous_version_code = Convert.ToInt32(pDT.Rows[i]["previous_version_code"]);
                }
                //====================================================================


                if (Convert.ToBoolean(pDT.Rows[i]["is_new"]) && JLA.Insert(pDB) == -1)
                {
                    pDB.Rollback(pDB.TransactionName);
                    return false;
                }

            }

            //--------------- ویرایش ضمائمی که حذف شده اند -------------------------
            DataTable dtOldAttachments = new DataTable();
            dtOldAttachments = GetAttachments(pLetterCode, pDB);
            for (int i = 0; i < dtOldAttachments.Rows.Count; i++)
            {
                bool Is_Deleted = false;
                for (int j = 0; j < pDT.Rows.Count; j++)
                {
                    if (dtOldAttachments.Rows[i]["Code"] == pDT.Rows[j]["Code"] && Convert.ToBoolean(pDT.Rows[j]["is_new"]) != true)
                    {
                        Is_Deleted = false;
                        break;
                    }
                }
                if (Is_Deleted)
                {
                    JCLetterCopy JLC = new JCLetterCopy();
                    JLC.GetData(Convert.ToInt32(dtOldAttachments.Rows[i]["Code"]), pDB);

                    JLC.is_deleted = true;
                    JLC.deleted_user_code = JMainFrame.CurrentUserCode;
                    JLC.deleted_user_post = JMainFrame.CurrentPostCode;
                    JLC.deleted_user_full_title = CurrentUser_full_title;
                    JLC.Update(pDB);
                }
            }
            //----------------------------------------------------

            return true;
        }

        /// <summary>
        /// ضمائم یک نامه خاص را در قالب یک جدول داده بر میگرداند
        /// </summary>
        /// <param name="pLetterCode">کد نامه</param>
        /// <param name="pDB">JDataBase</param>
        /// <returns>DataTable</returns>
        public DataTable GetAttachments(int pLetterCode, JDataBase pDB)
        {
            bool pDBidNull = (pDB == null);
            try
            {
                if (pDB == null)
                    pDB = JGlobal.MainFrame.GetDBO();
                pDB.setQuery("SELECT count(Code) FROM letterattachments WHERE (Letter_file_code is null) and Letter_Code=" + JDataBase.Quote(pLetterCode.ToString()));
                int Archive = Convert.ToInt32(pDB.Query_ExecutSacler());

                string Sql = "";
                if (Archive == 0)
                    Sql = @"SELECT  letterattachments.Code, letterattachments.letter_code, letterattachments.file_name, letterattachments.file_title, letterattachments.file_type, 
                   letterattachments.creator_user_post, letterattachments.creator_user_code, letterattachments.creator_user_full_title, 
                   letterattachments.create_date_time, letterattachments.previous_version_code, letterattachments.letter_file_code, letterattachments.archive_file_code, 
                   letterattachments.is_deleted, letterattachments.deleted_user_post, letterattachments.deleted_user_code, letterattachments.deleted_user_full_title, 
                   letterattachments.deleted_create_date_time, letterattachments.is_main_file, letterattachments.other_file_type, letterattachmentfiles.Code AS Let_Att_File_Code, letterattachmentfiles.file_content, 
                   letterattachmentfiles.file_text                          
                   FROM  letterattachments 
                   INNER JOIN letterattachmentfiles ON letterattachments.letter_file_code = letterattachmentfiles.Code 
                   where letter_code = " + pLetterCode + "order by letterattachments.Code";
                else
                {
                    //-----------------Join Archive-------------
                    string SqlArchive = ArchivedDocuments.JArchiveDocument.SearchText("Communication.JCLetter", "", pLetterCode);
                    Sql = @"SELECT  letterattachments.Code, letterattachments.letter_code, letterattachments.file_name, letterattachments.file_title, letterattachments.file_type, 
                   letterattachments.creator_user_post, letterattachments.creator_user_code, letterattachments.creator_user_full_title, 
                   letterattachments.create_date_time, letterattachments.previous_version_code, letterattachments.letter_file_code, letterattachments.archive_file_code, 
                   letterattachments.is_deleted, letterattachments.deleted_user_post, letterattachments.deleted_user_code, letterattachments.deleted_user_full_title, 
                   letterattachments.deleted_create_date_time, letterattachments.is_main_file, letterattachments.other_file_type, letterattachmentfiles.Code AS Let_Att_File_Code, letterattachmentfiles.file_content, 
                   letterattachmentfiles.file_text                          
                   FROM  letterattachments 
                   INNER JOIN letterattachmentfiles ON letterattachments.letter_file_code = letterattachmentfiles.Code 
                   where letter_code = " + pLetterCode + "order by letterattachments.Code";
                }
                pDB.setQuery(Sql);
                return pDB.Query_DataTable();
            }
            finally
            {
                if (pDBidNull)
                    pDB.Dispose();
            }
        }
        /// <summary>
        /// ضمائم یک نامه خاص را در قالب یک جدول داده بر میگرداند
        /// </summary>
        /// <param name="pLetterCode">کد نامه</param>
        /// <returns>DataTable</returns>
        public DataTable GetAttachments(int pLetterCode)
        {
            return GetAttachments(pLetterCode, null);
        }
    }
}
