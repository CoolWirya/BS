using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Employment
{
    public class JFormula : JSystem
    {

        #region constructor
        public JFormula()
        {
        }
        public JFormula(int pCode)
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
        public int TitleCode { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public string FeildName { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public string Sql { set; get; }       
        /// <summary>
        ///  
        /// </summary>
        public int CompanyCode { set; get; }
        
        #endregion


        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from empFormula where Code=" + pCode + "";
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
            JFormulaTable JPOT = new JFormulaTable();
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
                JFormulaTable JPOT = new JFormulaTable();
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

        public bool Delete(int pTitleCode, JDataBase PDb)
        {
            try
            {
                JFormulaTable JPOT = new JFormulaTable();
                if (JPOT.DeleteManual(" TitleCode= " + pTitleCode, PDb))
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
            JFormulaTable JPOT = new JFormulaTable();
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

        public bool Save(int pCompanyCode, int pTitleCode, DataTable pGoodsList)
        {
            JDataBase pDb = JGlobal.MainFrame.GetDBO();
            try
            {
                return Save(pCompanyCode, pTitleCode, pGoodsList, pDb);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                pDb.Dispose();
            }
        }

        public bool Save(int pCompanyCode, int pTitleCode, DataTable pGoodsList, JDataBase pDb)
        {
            try
            {
                foreach (DataRow Row in pGoodsList.Rows)
                {
                    /// در صورتی که سطر اضافه شده باشد
                    if ((Row.RowState == DataRowState.Added))
                    {
                        TitleCode = Convert.ToInt32(Row["TitleCode"]);
                        CompanyCode = pCompanyCode;
                        FeildName = JLanguages._Farsi(Row["FeildName"].ToString());
                        Sql = Row["Sql"].ToString();
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
                        TitleCode = Convert.ToInt32(Row["TitleCode"]);
                        CompanyCode = pCompanyCode;
                        FeildName = JLanguages._Farsi(Row["FeildName"].ToString());
                        Sql = Row["Sql"].ToString();
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

        public void FormulaForm(int pCompanyCode)
        {
            //if (!(JPermission.CheckPermission("Employment.JFormula.FormulaForm")))
            //    return;

            JFormulaForm p = new JFormulaForm(pCompanyCode);
            p.ShowDialog();
        }

        public static DataTable ExecFormula(int pTitleCode, int pContractCode, int pCompanyCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = " Where ";
                if (pTitleCode != 0)
                    Where = Where + "  TitleCode=" + pTitleCode;
                if (pCompanyCode != 0)
                    Where = Where + "  CompanyCode=" + pCompanyCode;
                Db.setQuery(@" select *,(select [sql] from EmpPersonnelContract where ContractCode= " + pContractCode + ") from empformula " + Where);
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

        public static DataTable GetDataTable(int pTitleCode, int pCompanyCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = " Where 1=1 ";
                if (pTitleCode != 0)
                    Where = Where + " And TitleCode=" + pTitleCode;
                if (pCompanyCode != 0)
                    Where = Where + " And CompanyCode=" + pCompanyCode;
                Db.setQuery(@" select Code,TitleCode,(Select Text From dic Where Name=FeildName)FeildName,Sql from EmpFormula " + Where);
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

    public class JFormulaTable : JTable
    {
        public JFormulaTable()
            : base("EmpFormula")
        {
        }
        /// <summary>
        ///  
        /// </summary>
        public int TitleCode;
        /// <summary>
        ///  
        /// </summary>
        public string FeildName;
        /// <summary>
        ///  
        /// </summary>
        public string Sql;
        /// <summary>
        ///  
        /// </summary>
        public int CompanyCode;
    }
}
