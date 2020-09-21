using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreManagement
{
    public class JMaliBill: JSystem
    {
        #region constructor
        public JMaliBill()
        {

        }
        public JMaliBill(int pCode)
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
        /// کد فاکتور  
        /// </summary>
        public int BillCode { get; set; }
        /// <summary>
        ///   کد فاکتور
        /// </summary>
        public int DocMaliCode { get; set; }
        #endregion

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from StorePrepayment where Code=" + pCode + "";
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

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
                    JDataBase tempDb = new JDataBase();
                    JMaliBillTable JLT = new JMaliBillTable();
                    try
                    {
                        tempDb.beginTransaction("EmployeeInfo");
                        JLT.SetValueProperty(this);
                        Code = JLT.Insert(tempDb);
                        if (Code > 0)
                            if (tempDb.Commit())
                            {
                                return Code;
                            }
                            else
                                return 0;

                        tempDb.Rollback("EmployeeInfo");
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                        tempDb.Rollback("EmployeeInfo");
                        return 0;
                    }
                    finally
                    {
                        tempDb.Dispose();
                        JLT.Dispose();
                    }
        }
        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete(int pCode)
        {
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                JMaliBillTable PDT = new JMaliBillTable();
                try
                {
                    Code = pCode;
                    PDT.SetValueProperty(this);
                    if (PDT.Delete())
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    return false;
                }
                finally
                {
                    DB.Dispose();
                    PDT.Dispose();
                }
            }

        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JDataBase Db = new JDataBase();
            return Update(Db);
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase Db)
        {
                JMaliBillTable PDT = new JMaliBillTable();
                try
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update(Db))
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    return false;
                }
                finally
                {
                    Db.Dispose();
                    PDT.Dispose();
                }
        }
    }

    public class JMaliBillTable : JTable
    {
        public JMaliBillTable()
            : base("StoreMaliBill")
        {
        }
        /// <summary>
        /// کد فاکتور  
        /// </summary>
        public int BillCode;
        /// <summary>
        ///   کد فاکتور
        /// </summary>
        public int DocMaliCode ;
    }
}
