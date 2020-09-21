using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Employment;

namespace Communication
{
    public class JCLetterCopy : JCommunication
    {
        #region Peroperties
        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد نامه
        /// </summary>
        public int letter_code { get; set; }
        /// <summary>
        /// نوع رونوشت  - داخلی ، خارجی ، شرکت اقماری
        /// </summary>
        public int copy_type { get; set; }
        /// <summary>
        /// کد پست گیرنده رونوشت
        /// </summary>
        public int receiver_post_code { get; set; }
        /// <summary>
        /// کد کاربری گیرنده رونوشت
        /// </summary>
        public int receiver_user_code { get; set; }
        /// <summary>
        /// نام کامل گیرنده رونوشت
        /// </summary>
        public string receiver_full_title { get; set; }
        /// <summary>
        /// علت رونوشت
        /// </summary>
        public string copy_reason { get; set; }
        /// <summary>
        /// کد پست اضافه کننده رونوشت
        /// </summary>
        public int register_post_code { get; set; }
        /// <summary>
        /// کد کاربری اضافه کننده رونوشت
        /// </summary>
        public int register_user_code { get; set; }
        /// <summary>
        /// نام کامل اضافه کننده رونوشت
        /// </summary>
        public string register_full_title { get; set; }
        /// <summary>
        /// کد سازمان دریافت کننده رونوشت
        /// </summary>
        public int receiver_external_code { get; set; }
        /// <summary>
        /// کد شرکت اقماری
        /// </summary>
//        public int receiver_subsidiaries_code { get; set; }
        /// <summary>
        /// کد نحوه ارسال
        /// </summary>
        public int send_type { get; set; }
        /// <summary>
        /// وضعیت حذف
        /// </summary>
        public bool is_deleted { get; set; }
        /// <summary>
        /// کد پست حذف کننده
        /// </summary>
        public int deleted_user_post { get; set; }
        /// <summary>
        /// کد کاربر حرف کننده
        /// </summary>
        public int deleted_user_code { get; set; }
        /// <summary>
        /// نام کامل حذف کننده
        /// </summary>
        public string deleted_user_full_title { get; set; }
        /// <summary>
        /// تاریخ مهلت پاسخ
        /// </summary>
        public DateTime respite_date_time { get; set; }
        
        #endregion Peroperties

        /// <summary>
        /// سازنده
        /// </summary>
        public JCLetterCopy()
        {
        }

        /// <summary>
        /// ایجاد الگوی رونوشت نامه
        /// </summary>
        public DataTable GetDataTablePatern()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Code",typeof(int));
            dt.Columns.Add("Letter_code");
            dt.Columns.Add("copy_type");
            dt.Columns.Add("receiver_post_code");
            dt.Columns.Add("receiver_user_code");
            dt.Columns.Add("receiver_full_title");
            dt.Columns.Add("copy_reason");
            dt.Columns.Add("send_type");
            dt.Columns.Add("send_type_title");
            dt.Columns.Add("copy_type_title");
            dt.Columns.Add("register_post_code");
            dt.Columns.Add("register_user_code");
            dt.Columns.Add("register_full_title");
            dt.Columns.Add("receiver_external_code");
            dt.Columns.Add("receiver_subsidiaries_code");
            dt.Columns.Add("respite_date_time");
            dt.Columns.Add("is_deleted");
            dt.Columns.Add("deleted_user_post");
            dt.Columns.Add("deleted_user_code");
            dt.Columns.Add("deleted_user_full_title");
            dt.Columns.Add("is_new");
            dt.Columns.Add("RecieverText");
            return dt;            
        }
        /// <summary>
        /// درج رونوشت جدید
        /// </summary>
        /// <param name="db">JDataBase</param>
        /// <returns>int</returns>
        public int Insert(JDataBase db)
        {
            JCLetterCopyTable JST = new JCLetterCopyTable();
            JST.SetValueProperty(this);
            int mCode = JST.Insert(db);
            if (mCode != 0)
            {
                return mCode;
            }
            return -1;
        }
        /// <summary>
        /// ویرایش رونوشت
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase db)
        {
            if (Find(Code,db))
            {
                JCLetterCopyTable JST = new JCLetterCopyTable();
                JST.SetValueProperty(this);
                return JST.Update(db);
            }
            return false;
        }
        /// <summary>
        /// حذف رونوشت
        /// </summary>
        /// <returns></returns>
        public bool DelManual(int pLetterCode,JDataBase db)
        {            
                JCLetterCopyTable JST = new JCLetterCopyTable();
                return JST.DeleteManual(" Letter_Code= " + pLetterCode, db);
        }

        /// <summary>
        /// جستجوی  
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        public Boolean Find(int pCode,JDataBase pDB)
        {
            try
            {
                pDB.setQuery("SELECT * FROM lettercopy WHERE [Code]=" + JDataBase.Quote(pCode.ToString()));
                pDB.Query_DataReader();
                return pDB.DataReader.HasRows;
            }
            finally
            {
               // pDB.Dispose();
            }
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
                pDB.setQuery("SELECT * FROM lettercopy WHERE Letter_Code=" + JDataBase.Quote(pCode.ToString()));
                pDB.Query_DataReader();
                return pDB.DataReader.HasRows;
            }
            finally
            {
                // pDB.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean GetData(int pCode)
        {
            JDataBase db = new JDataBase();
            return GetData(pCode, db);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="pDB"></param>
        /// <returns></returns>
        public Boolean GetData(int pCode,JDataBase pDB)
        {
            try
            {
                pDB.setQuery("SELECT * FROM lettercopy WHERE [Code]=" + JDataBase.Quote(pCode.ToString()));
                pDB.Query_DataReader();
                if (pDB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, pDB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
              //pDB.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public DataTable GetDatatable(int pLetterCode)
        {
            JDataBase pDB = new JDataBase();
            try
            {
                pDB.setQuery("SELECT * FROM lettercopy WHERE Letter_Code=" + JDataBase.Quote(pLetterCode.ToString()));
                return pDB.Query_DataTable();                
            }
            finally
            {
                pDB.Dispose();
            }
        }
    }

    public class JCLetterCopys : JCommunication
    {
        /// <summary>
        /// ثبت رونوشت های یه نامه
        /// </summary>
        /// <param name="pLetterCode">کد نامه</param>
        /// <param name="pDT">جدول اطلاعات رونوشت ها</param>
        /// <param name="pDB">jDatabase</param>
        /// <returns>bool</returns>
        public bool Insert(int pLetterCode, DataTable pDT, JDataBase pDB)
        {
            if (pDT == null)
                return false;

            for (int i = 0; i < pDT.Rows.Count; i++)
                if (pDT.Rows[i].RowState == DataRowState.Added)
                {
                    JCLetterCopy JLC = new JCLetterCopy();
                    //--------------------- کد نامه ---------------------------------------------------------------------------
                    JLC.letter_code = pLetterCode;
                    //--------------------- نوع رونوشت ------------------------------------------------------------------------
                    JLC.copy_type = Convert.ToInt32(pDT.Rows[i]["copy_type"]);
                    //--------------------- کد پست دریافت کننده ---------------------------------------------------------------
                    if (pDT.Rows[i]["receiver_post_code"] != DBNull.Value)
                        JLC.receiver_post_code = Convert.ToInt32(pDT.Rows[i]["receiver_post_code"]);
                    //--------------------- کد کاربر دریافت کننده -------------------------------------------------------------
                    if (pDT.Rows[i]["receiver_user_code"] != DBNull.Value)
                        JLC.receiver_user_code = Convert.ToInt32(pDT.Rows[i]["receiver_user_code"]);
                    //--------------------- نام کامل دریافت کننده رونوشت ------------------------------------------------------
                    JLC.receiver_full_title = pDT.Rows[i]["receiver_full_title"].ToString();
                    //--------------------- علت رونوشت ------------------------------------------------------------------------
                    JLC.copy_reason = pDT.Rows[i]["copy_reason"].ToString();
                    //--------------------- کد سازمان دریافت کننده ------------------------------------------------------------
                    if (pDT.Rows[i]["receiver_external_code"] != DBNull.Value)
                        JLC.receiver_external_code = Convert.ToInt32(pDT.Rows[i]["receiver_external_code"]);
                    //--------------------- کد شرکت اقماری دریافت کننده -------------------------------------------------------
                    //if (pDT.Rows[i]["receiver_subsidiaries_code"] != DBNull.Value)
                    //    JLC.receiver_subsidiaries_code = Convert.ToInt32(pDT.Rows[i]["receiver_subsidiaries_code"]);
                    //-------------------- نحوه ارسال --------------------------------------------------------------------------
                    JLC.send_type = Convert.ToInt32(pDT.Rows[i]["send_type"]);
                    //----------- اطلاعات کاربر ثبت کننده ----------------------------------------------------------------------
                    JLC.register_user_code = JMainFrame.CurrentPersonCode;
                    JLC.register_post_code = JMainFrame.CurrentPostCode;
                    JLC.register_full_title = JMainFrame.CurrentPostTitle;
                    //(new Employment.JEOrganizationChart(CurrentUser.current_post_code)).full_title;
                    //--------------------------------------------------------------------------------------------------------- 
                    int code = JLC.Insert(pDB);
                    if (code < 1)
                    {
                        pDB.Rollback(pDB.TransactionName);
                        return false;
                    }

                }
            return true;
        }


        /// <summary>
        /// ثبت رونوشت های یه نامه
        /// </summary>
        /// <param name="pLetterCode">کد نامه</param>
        /// <param name="pDT">جدول اطلاعات رونوشت ها</param>
        /// <param name="pDB">jDatabase</param>
        /// <returns>bool</returns>
        public bool Update(int pLetterCode, DataTable pDT, JDataBase pDB)
        {

            if (pDT == null)
                return false;
            //--------------------  بدست آوردن اطلاعات کاربر جاری ------------------------------------------------------
            string CurrentUser_full_title = (new Employment.JEOrganizationChart(JMainFrame.CurrentPostCode)).full_title;

            for (int i = 0; i < pDT.Rows.Count; i++)
            {
                if (pDT.Rows[i].RowState == DataRowState.Unchanged || pDT.Rows[i].RowState == DataRowState.Deleted || !Convert.ToBoolean(pDT.Rows[i]["is_new"]))
                    continue;
                
                JCLetterCopy JLC = new JCLetterCopy();
                //if (pDT.Rows[i]["Code"].ToString().Length > 0)
                    //JLC.GetData((int)pDT.Rows[i]["Code"], pDB);
                //--------------------- کد نامه ---------------------------------------------------------------------------
                JLC.letter_code = pLetterCode;
                //--------------------- نوع رونوشت ------------------------------------------------------------------------
                JLC.copy_type = Convert.ToInt32(pDT.Rows[i]["copy_type"]);
                //--------------------- کد پست دریافت کننده ---------------------------------------------------------------
                if (pDT.Rows[i]["receiver_post_code"] != DBNull.Value)
                    JLC.receiver_post_code = Convert.ToInt32(pDT.Rows[i]["receiver_post_code"]);
                //--------------------- کد کاربر دریافت کننده -------------------------------------------------------------
                if (pDT.Rows[i]["receiver_user_code"] != DBNull.Value)
                    JLC.receiver_user_code = Convert.ToInt32(pDT.Rows[i]["receiver_user_code"]);
                //--------------------- نام کامل دریافت کننده رونوشت ------------------------------------------------------
                JLC.receiver_full_title = pDT.Rows[i]["receiver_full_title"].ToString();
                //--------------------- علت رونوشت ------------------------------------------------------------------------
                JLC.copy_reason = pDT.Rows[i]["copy_reason"].ToString();
                //--------------------- کد سازمان دریافت کننده ------------------------------------------------------------
                if (pDT.Rows[i]["receiver_external_code"] != DBNull.Value)
                    JLC.receiver_external_code = Convert.ToInt32(pDT.Rows[i]["receiver_external_code"]);
                //--------------------- کد شرکت اقماری دریافت کننده -------------------------------------------------------
                //if (pDT.Rows[i]["receiver_subsidiaries_code"] != DBNull.Value)
                //    JLC.receiver_subsidiaries_code = Convert.ToInt32(pDT.Rows[i]["receiver_subsidiaries_code"]);
                //-------------------- نحوه ارسال --------------------------------------------------------------------------
                JLC.send_type = Convert.ToInt32(pDT.Rows[i]["send_type"]);
                //-------------------- مهلت پاسخ --------------------------------------------------------------------------
                if (pDT.Rows[i]["respite_date_time"].ToString() != "")
                    JLC.respite_date_time = JDateTime.GregorianDate(pDT.Rows[i]["respite_date_time"].ToString());
                //----------- اطلاعات کاربر ثبت کننده ----------------------------------------------------------------------
                JLC.register_user_code = JMainFrame.CurrentUserCode;
                JLC.register_post_code = JMainFrame.CurrentPostCode;
                JLC.register_full_title = CurrentUser_full_title;
                //--------------------------------------------------------------------------------------------------------- 
                int code = 0;
                if (Convert.ToBoolean(pDT.Rows[i]["is_new"]))
                {
                    code = JLC.Insert(pDB);
                    if (code < 1)
                    {
                        pDB.Rollback(pDB.TransactionName);
                        return false;
                    }
                }
            }

            //--------------- ویرایش رونوشت هایی که حذف شده اند -------------------------
            for (int i = 0; i < pDT.Rows.Count; i++)
            {
                if (pDT.Rows[i].RowState == DataRowState.Deleted)
                {
                    pDT.Rows[i].RejectChanges();
                    JCLetterCopy JLC = new JCLetterCopy();

                    JLC.GetData(Convert.ToInt32(pDT.Rows[i]["Code"]), pDB);

                    JLC.is_deleted = true;
                    JLC.deleted_user_code = JMainFrame.CurrentUserCode;
                    JLC.deleted_user_post = JMainFrame.CurrentPostCode;
                    JLC.deleted_user_full_title = CurrentUser_full_title;
                    try
                    {
                        JLC.Update(pDB);
                        pDT.Rows[i].Delete();
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
            pDT.AcceptChanges();
            //----------------------------------------------------
            return true;
        }

        /// <summary>
        /// اطلاعات رونوشت های یک نامه خاص را در قالب جدول داده برمی گرداند
        /// </summary>
        /// <param name="pLetterCode">کد نامه</param>
        /// <param name="pDB">JDataBase</param>
        /// <returns>DataTable</returns>
        public DataTable GetCopys(int pLetterCode,JDataBase pDB)
        {
            bool pDBisNull = (pDB == null);
            try
            {
                string Sql = @"select   lettercopy.Code, letter_code, copy_type, receiver_post_code, receiver_user_code, receiver_full_title, 
                            copy_reason, register_post_code, register_user_code, register_full_title, receiver_external_code, 
                            receiver_subsidiaries_code, send_type ,ISNULL(vChart.Post +' محترم '+vChart.title+' '+copy_reason, '') RecieverText,  
                            CASE copy_type 
                            WHEN " + ClassLibrary.Domains.JAutomation.JReferType.Internal.ToString() + " THEN '" + JLanguages._Text("Internal") + "'" +
                                " WHEN " + ClassLibrary.Domains.JAutomation.JReferType.External.ToString() + " THEN '" + JLanguages._Text("External") + "'" +
                                " WHEN " + ClassLibrary.Domains.JAutomation.JReferType.Subsidiaries.ToString() + " THEN '" + JLanguages._Text("Subsidiaries") + "'" +
                                " END AS 'copy_type_title' ," +
                                " CASE send_type " +
                                " WHEN " + ClassLibrary.Domains.JCommunication.JSendType.Automation.ToString() + " THEN '" + JLanguages._Text("Automation") + "'" +
                                " WHEN " + ClassLibrary.Domains.JCommunication.JSendType.ECE.ToString() + " THEN '" + JLanguages._Text("ECE") + "'" +
                                " WHEN " + ClassLibrary.Domains.JCommunication.JSendType.Email.ToString() + " THEN '" + JLanguages._Text("Email") + "'" +
                                " WHEN " + ClassLibrary.Domains.JCommunication.JSendType.Fax.ToString() + " THEN '" + JLanguages._Text("Fax") + "'" +
                                " WHEN " + ClassLibrary.Domains.JCommunication.JSendType.Messenger.ToString() + " THEN '" + JLanguages._Text("Messenger") + "'" +
                                " WHEN " + ClassLibrary.Domains.JCommunication.JSendType.Server.ToString() + " THEN '" + JLanguages._Text("Server") + "'" +
                                " WHEN " + ClassLibrary.Domains.JCommunication.JSendType.SMS.ToString() + " THEN '" + JLanguages._Text("SMS") + "'" +
                                " END AS 'send_type_title',(select Fa_Date from StaticDates where En_Date=respite_date_time) as 'respite_date_time' " +
                                @"from lettercopy left join VOrganizationChart vChart on vChart .Code = lettercopy.receiver_post_code
                            where ISNULL(is_deleted,0) = 0 AND letter_code = " + pLetterCode;
                if (pDB == null)
                {
                    pDB = JGlobal.MainFrame.GetDBO();
                }
                pDB.setQuery(Sql);
                return pDB.Query_DataTable();
            }
            finally
            {
                if (pDBisNull)
                    pDB.Dispose();
            }
        }
        /// <summary>
        /// اطلاعات رونوشت های یک نامه خاص را در قالب جدول داده برمی گرداند
        /// </summary>
        /// <param name="pLetterCode">کد نامه</param>
        /// <returns>DataTable</returns>
        public DataTable GetCopys(int pLetterCode)
        {
            return GetCopys(pLetterCode,null);
        }
    }
}
