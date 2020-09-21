using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Employment
{
    public class JKaraneh : JSystem
    {
        #region constructor
        public JKaraneh()
        {
        }
        public JKaraneh(int pCode)
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
        public int id_karaneRange { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public decimal score { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public decimal price { set; get; }        

        #endregion


        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from empkaraneh where Code=" + pCode + "";
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
            JKaranehTable JPOT = new JKaranehTable();
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
                JKaranehTable JPOT = new JKaranehTable();
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
                JKaranehTable JPOT = new JKaranehTable();
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
            JKaranehTable JPOT = new JKaranehTable();
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
                        id_karaneRange = Convert.ToInt32(Row["id_karaneRange"].ToString());
                        score = Convert.ToInt32(Row["score"].ToString());
                        price = Convert.ToInt32(Row["price"].ToString());
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
                        id_karaneRange = Convert.ToInt32(Row["id_karaneRange"].ToString());
                        score = Convert.ToInt32(Row["score"].ToString());
                        price = Convert.ToInt32(Row["price"].ToString());
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

        public static DataTable ReportDataTable(string pWhere)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(@" select 
EmpKaraneh.id_employee,
EmpKaraneh.Score,
EmpKaraneh.Price PriceKaraneh,
( Select (select Name From clsAllPerson where Code=PCode) From EmpEmployee where Code=id_employee) Name,
(select PersonNumber From EmpEmployee where Code=id_employee) PersonNumber,
(select PersonCart From EmpEmployee where Code=id_employee) PersonCart,
(select (select name from subdefine where Code=Activity) From EmpEmployee where Code=id_employee) Activity,
(select Description From EmpKaranehRange where Code=id_KaraneRange) Description
from EmpKaraneh Where 1=1 " + pWhere);
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

        public void ReportForm(int pCompanyCode)
        {
            if (!(JPermission.CheckPermission("Employment.JEContract.ReportForm")))
                return;

            JReportDetailForm p = new JReportDetailForm(pCompanyCode);
            p.ShowDialog();
        }

        public static DataTable GetDataTable(int pEmployeeCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = "";
                if (pEmployeeCode != 0)
                    Where = " Where id_employee=" + pEmployeeCode;
                Db.setQuery(@" select EmpKaraneh.id_employee,id_KaraneRange,
EmpKaraneh.Score,
EmpKaraneh.Price PriceKaraneh,
(select Description From EmpKaranehRange where Code=id_KaraneRange) Description
 from EmpKaraneh " + Where);
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

    public class JKaranehTable : JTable 
    {
        public JKaranehTable()
            : base("EmpKaraneh")
        {
        }
        /// <summary>
        ///  
        /// </summary>
        public int id_employee ;
        /// <summary>
        ///  
        /// </summary>
        public int id_karaneRange ;
        /// <summary>
        ///  
        /// </summary>
        public decimal score ;
        /// <summary>
        ///  
        /// </summary>
        public decimal price;
    }
}
