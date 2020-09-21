using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{
    public class JCountPollingChoice :JSystem
    {
        public int Code { get; set; }
        /// <summary>
        /// کد برگه شمارش شده
        /// </summary>
        public int PollingCountCode { get; set; }
        /// <summary>
        /// کد گزینه انتخابی
        /// </summary>
        public int ChoiceCode { get; set; }

        public JCountPollingChoice(int pCode)
        {
            if (pCode > 0)
                JTable.SetToClassProperty(this, this.GetData(pCode).Rows[0]);
        }
        private DataTable GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @" Select  * FROM ShareAssemblyPollingCountChoice WHERE Code =" + pCode;
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

        public bool DeleteAll(int pPollingCountCode, JDataBase pDB)
        {
            //JDataBase DB = new JDataBase();
            try
            {
                pDB.setQuery(@" Delete FROM ShareAssemblyPollingCountChoice WHERE PollingCountCode =" + pPollingCountCode);
                return pDB.Query_Execute() >= 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                //DB.Dispose();
            }
            return false;
        }
        /// <summary>
        /// درج
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase pDB)
        {
            JCountPollingChoiceTable table = new JCountPollingChoiceTable();
            try
            {
                table.SetValueProperty(this);
                Code = table.Insert(pDB);
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

        public bool Delete(JDataBase pDB)
        {
            try
            {
                JCountPollingChoiceTable JPT = new JCountPollingChoiceTable();
                JPT.SetValueProperty(this);
                return (JPT.Delete(pDB));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
    public class JCountPollingChoices : JSystem
    {
        public static DataTable GetData(int pPollingCountCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @" Select  * FROM ShareAssemblyPollingCountChoice WHERE PollingCountCode =" + pPollingCountCode;
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
