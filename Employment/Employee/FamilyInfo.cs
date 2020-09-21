using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Employment
{
    public class JFamilyInfomation : JSystem
    {
        #region constructor
        public JFamilyInfomation()
        {
        }
        public JFamilyInfomation(int pCode)
        {
            //GetData(pCode);
        }
        #endregion

        #region property
        /// <summary>
        ///  
        /// </summary>
        public int Code { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public int EmployeeCode { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public int PCode { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public int NesbatType { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public DateTime expireDate { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public bool is_finished { set; get; }
        /// <summary>
        ///    
        /// </summary>
        public string Description { set; get; }

        #endregion

        public int insert()
        {
            JDataBase pDb = JGlobal.MainFrame.GetDBO();
            try
            {                
                return insert(pDb);
            }
            finally
            {
                pDb.Dispose();
            }
        }
        #region Method
        public int insert(JDataBase pDb)
        {
            JFamilyInfomationTable JPOT = new JFamilyInfomationTable();
            try
            {
                int Code;
                JPOT.SetValueProperty(this);
                Code = JPOT.Insert(pDb);
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
                JPOT.Dispose();
            }
        }

        public bool Delete(JDataBase PDb)
        {
            try
            {
                JFamilyInfomationTable JPOT = new JFamilyInfomationTable();
                JPOT.SetValueProperty(this);
                if (JPOT.Delete(PDb) || JPOT.GetDeleteCount() == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool Delete(int pEmployeeCode, JDataBase PDb)
        {
            try
            {
                JFamilyInfomationTable JPOT = new JFamilyInfomationTable();
                if (JPOT.DeleteManual(" EmployeeCode= " + pEmployeeCode, PDb))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool Update(JDataBase pDb)
        {
            JFamilyInfomationTable JPOT = new JFamilyInfomationTable();
            try
            {
                JPOT.SetValueProperty(this);
                return JPOT.Update(pDb);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JPOT.Dispose();
            }
        }

        public bool Save(int pEmployeeCode, DataTable pGoodsList, JDataBase pDb)
        {
            try
            {
                foreach (DataRow Row in pGoodsList.Rows)
                {
                    /// در صورتی که سطر اضافه شده باشد
                    if ((Row.RowState == DataRowState.Added))
                    {
                        EmployeeCode = pEmployeeCode;
                        PCode = Convert.ToInt32(Row["PCode"].ToString());
                        NesbatType = Convert.ToInt32(Row["NesbatType"]);
                        if (Row["expireDateTakafol"].ToString() != "")
                            expireDate = Convert.ToDateTime(JDateTime.GregorianDate(Row["expireDateTakafol"].ToString()));
                        if (Row["is_finished"].ToString() == "True")
                            is_finished = true;
                        else
                            is_finished = false;
                        Description = Row["Description"].ToString();
                        Code = insert(pDb);
                        if (Code <= 0)
                            return false;
                    }
                    /// در صورتی که سطر حذف شده باشد
                    else if ((Row.RowState == DataRowState.Deleted))
                    {
                        Row.RejectChanges();
                        if (Row["Code"] != DBNull.Value)
                        {
                            Code = (int)Row["Code"];
                            if (!(Delete(pDb)))
                                return false;
                            Row.Delete();
                        }
                        else
                            Row.Delete();
                    }
                    /// در صورتی که سطر ویرایش شده باشد
                    else if ((Row.RowState == DataRowState.Modified))
                    {
                        Code = (int)Row["Code"];
                        EmployeeCode = pEmployeeCode;
                        PCode = Convert.ToInt32(Row["PCode"].ToString());
                        NesbatType = Convert.ToInt32(Row["NesbatType"]);
                        if (Row["expireDateTakafol"].ToString() != "")
                            expireDate = Convert.ToDateTime(JDateTime.GregorianDate(Row["expireDateTakafol"].ToString()));
                        if (Row["is_finished"].ToString() == "True")
                            is_finished = true;
                        else
                            is_finished = false;
                        Description = Row["Description"].ToString();
                        if (!Update(pDb))
                            return false;
                    }
                }
                pGoodsList.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }
        #endregion

        public static int GetCountChild(int pPCode)
        {
            string Where = " ";
            if (pPCode != 0)
                Where = Where + " And PCode=" + pPCode;
            string Query = @" select Count(*) from EmpFamilyInformation Where is_finished=0 And NesbatType<>1 " + Where;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return Convert.ToInt32(db.Query_ExecutSacler());
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetDataTable(int pEmployeeCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = "";
                if (pEmployeeCode != 0)
                    Where = " Where EmployeeCode=" + pEmployeeCode;
                Db.setQuery(@" select 
Code,
EmployeeCode,
PCode,
(select Name From clsAllPerson where Code=PCode) Name,
case NesbatType 
When 1 then 'همسر' 
When 2 then 'پسر' 
When 3 then 'دختر' 
end Nesbat, 
(select (Select Fa_Date From StaticDates Where En_Date =cast(BthDate as Date)) From clsPerson where Code=PCode) BthDate,
NesbatType,
(Select Fa_Date From StaticDates Where En_Date =cast(expireDate as Date)) expireDateTakafol,
is_finished,
Description
from EmpFamilyInformation " + Where);
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

    public class JFamilyInfomationTable : JTable
    {
        public JFamilyInfomationTable()
            : base("EmpFamilyInformation")
        {
        }
        /// <summary>
        ///  
        /// </summary>
        public int EmployeeCode;
        /// <summary>
        ///  
        /// </summary>
        public int PCode;
        /// <summary>
        ///  
        /// </summary>
        public int NesbatType;
        /// <summary>
        ///  
        /// </summary>
        public DateTime expireDate;
        /// <summary>
        ///  
        /// </summary>
        public bool is_finished;
        /// <summary>
        ///    
        /// </summary>
        public string Description;
    }
}
