using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ArchivedDocuments
{
    public class JRequestArchiveList : JSystem
    {
        #region constructor
        public JRequestArchiveList()
        {

        }
        public JRequestArchiveList(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Property
        /// <summary>
        /// کد 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// در درخواست 
        /// </summary>
        public int RequestCode { get; set; }
        /// <summary>
        /// کد آرشیو 
        /// </summary>
        public int ArchiveCode { get; set; }
        /// <summary>
        /// کد پست تایید کننده 
        /// </summary>
        public int Confirm_Post_Code { get; set; }
        /// <summary>
        /// عنوان تایید کننده 
        /// </summary>
        public string Confirm_Full_Title { get; set; }
        /// <summary>
        /// کد  تایید کننده 
        /// </summary>
        public int Confirm_User_Code { get; set; }
        /// <summary>
        /// وضعیت 
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        ///  تاریخ شروع
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        ///  تاریخ پایان
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        ///  توضیحات
        /// </summary>
        public string Description { get; set; }
        #endregion

        #region method

        public int Insert()
        {
            JDataBase tempDb = new JDataBase();
            return Insert(tempDb);
        }
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase tempDb)
        {            
            JRequestArchiveListTable JLT = new JRequestArchiveListTable();
            try
            {
                JLT.SetValueProperty(this);
                Code = JLT.Insert(tempDb);
                if (Code > 0)
                    return Code;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                tempDb.Dispose();
                JLT.Dispose();
            }
            return 0;
        }

        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JDataBase Db = new JDataBase();
            JRequestArchiveListTable PDT = new JRequestArchiveListTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Update(Db))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
                Db.Dispose();
            }
            return false;
        }

        /// <summary>
        /// حذف 
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            JDataBase Db = new JDataBase();
            JRequestArchiveListTable PDT = new JRequestArchiveListTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete(Db))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
                Db.Dispose();
            }
            return false;
        }
        #endregion

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from ArchiveRequestList where Code=" + pCode + "";
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public static DataTable GetDataTable(int pRequestCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from ArchiveRequestList where RequestCode=" + pRequestCode;
                Db.setQuery(Query);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

    }
}
