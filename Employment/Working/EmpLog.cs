using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Employment
{
    public class JEmpLog : JSystem
    {
        #region constructor
        public JEmpLog()
        {
        }
        public JEmpLog(int pCode)
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
        public int FormCode { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public int FormObjectCode { set; get; }

        #endregion

        public bool Find()
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from EmpLog where FormCode=" + FormCode + " And FormObjectCode=" + FormObjectCode;
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

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from EmpLog where Code=" + pCode + "";
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
            JEmpLogTable JPOT = new JEmpLogTable();
            try
            {                
                JPOT.SetValueProperty(this);
                if (Find())
                    return 1;
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
                JEmpLogTable JPOT = new JEmpLogTable();
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
                JEmpLogTable JPOT = new JEmpLogTable();
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
            JEmpLogTable JPOT = new JEmpLogTable();
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

        #endregion
    }

    public class JEmpLogTable : JTable
    {
        public JEmpLogTable()
            : base("EmpLog")
        {
        }
        /// <summary>
        ///  
        /// </summary>
        public int FormCode;
        /// <summary>
        ///  
        /// </summary>
        public int FormObjectCode;      
    }
}
