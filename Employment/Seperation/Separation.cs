using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Employment
{

    public class JSeparation : JSystem
    {
        #region constructor
        public JSeparation()
        {
        }
        public JSeparation(int pCode)
        {
            GetData(pCode);
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
        public int id_employee { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public int id_DischargeType { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public DateTime Ddate { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public string description { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public DateTime Rdate { set; get; }

        #endregion
 
        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from EmpSeparation where Code=" + pCode + "";
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
            JSeparationTable JPOT = new JSeparationTable();
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
                JSeparationTable JPOT = new JSeparationTable();
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
                JSeparationTable JPOT = new JSeparationTable();
                if (JPOT.DeleteManual(" id_employee= " + pEmployeeCode, PDb))
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
            JSeparationTable JPOT = new JSeparationTable();
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
                        id_employee = pEmployeeCode;
                        id_DischargeType = Convert.ToInt32(Row["id_DischargeType"].ToString());
                        description = (Row["description"].ToString());
                        if (Row["Ddate"].ToString() != "")
                            Ddate = Convert.ToDateTime(JDateTime.GregorianDate(Row["Ddate"].ToString()));
                        if (Row["Rdate"].ToString() != "")
                            Rdate = Convert.ToDateTime(JDateTime.GregorianDate(Row["Rdate"].ToString()));
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
                        id_employee = pEmployeeCode;
                        id_DischargeType = Convert.ToInt32(Row["id_DischargeType"].ToString());
                        description = (Row["description"].ToString());
                        Ddate = Convert.ToDateTime(Row["Ddate"].ToString());
                        Rdate = Convert.ToDateTime(Row["Rdate"].ToString());
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

        public static DataTable GetDataTable(int pEmployeeCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = "";
                if (pEmployeeCode != 0)
                    Where = " Where id_employee=" + pEmployeeCode;
                Db.setQuery(@" select 
Code,
(Select Fa_Date from StaticDates where  En_Date = cast(Ddate as date)) 'Ddate',
description,
(Select Name From Subdefine where code=id_DischargeType) DischargeType,
(Select Fa_Date from StaticDates where  En_Date = cast(Rdate as date)) 'Rdate'

 from EmpSeparation " + Where);
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

    public class JSeparationTable : JTable
    {
        public JSeparationTable()
            : base("EmpSeparation")
        {
        }        
        /// <summary>
        ///  
        /// </summary>
        public int id_employee ;
        /// <summary>
        ///  
        /// </summary>
        public int id_DischargeType ;
        /// <summary>
        ///  
        /// </summary>
        public DateTime Ddate ;
        /// <summary>
        ///  
        /// </summary>
        public string description;
        /// <summary>
        ///  
        /// </summary>
        public DateTime Rdate ;
    }
}
