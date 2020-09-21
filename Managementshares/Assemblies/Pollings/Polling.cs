using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{
    public class JPolling : JSystem
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد مجمع
        /// </summary>
        public int ACode { get; set; }
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// تعداد اعضای اصلی
        /// </summary>
        public int MainMembers { get; set; }
        /// <summary>
        /// تعداد اعضای علی البدل
        /// </summary>
        public int AlternateMembers { get; set; }
        #endregion Properties
        public JPolling()
        {
        }
        public JPolling(int pCode)
        {
            this.getData(pCode);
        }
        public Boolean getData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM ShareAssemblyPolling WHERE [Code] = " + pCode.ToString());
                if (db.Query_DataReader() && db.DataReader.Read())
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

        public int Insert()
        {
            JPollingTable pollingTable = new JPollingTable();
            try
            {
                    pollingTable.SetValueProperty(this);
                    Code = pollingTable.Insert();
                    if (Code > 0)
                    {
                        return Code;
                    }
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                //       Db.Dispose();
            }
        }

        public bool Update(JDataBase pDB)
        {
            JPollingTable JUBT = new JPollingTable();
                JUBT.SetValueProperty(this);
                if (JUBT.Update(pDB))
                {
                    return true;
                }
                else return false;
        }

        public Boolean Delete()
        {
            try
            {
                if ( JMessages.Question("آیا میخواهید رای گیری مورد نظر حذف شود؟", this.Title) == System.Windows.Forms.DialogResult.Yes)
                {
                    ///
                    JPollingTable JPT = new JPollingTable();
                    JPT.SetValueProperty(this);
                    if (JPT.Delete())
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
    public class JPollings : JSystem
    {
        int AssemblyCode;
        public JPollings(int pAssemblyCode)
        {
            AssemblyCode = pAssemblyCode;
        }
        public DataTable GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = " SELECT Code, Title, MainMembers FROM ShareAssemblyPolling WHERE ACode =" + AssemblyCode.ToString();
                if (pCode > 0)
                    query += " AND Code = " + pCode;
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return null;
        }
    }
}
