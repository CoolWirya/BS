using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{

    public class JSheetLog : JManagementshares
    {
        public int Code { get; set; }
        public int SCode { get; set; }
        public int PCode { get; set; }
        public int NewPCode { get; set; }
        public int Operation { get; set; }
        public int OperationCode { get; set; }
        public int NewSCode { get; set; }

        public JSheetLog()
        {
        }
        public JSheetLog(int pSheetCode, JShareOperations operation, int pOperationCode, JDataBase DB)
        {
            try
            {
                DB.setQuery(string.Format("SELECT * FROM ShareSheetLog WHERE SCode = {0} AND Operation = {1} AND OperationCode = {2} ", pSheetCode, operation.GetHashCode(), pOperationCode));
                DataTable logs = DB.Query_DataTable();
                if (logs.Rows.Count == 1)
                {
                    //int logCode = Convert.ToInt32(logs.Rows[0]["Code"]);
                    JTable.SetToClassProperty(this, logs.Rows[0]);                    
                }
            }
            catch
            {
            }
        }
        public int Insert(JDataBase pDB)
        {
            JSheetLogTable logTable = new JSheetLogTable();
            try
            {
                logTable.SetValueProperty(this);
                Code = logTable.Insert(pDB);
                return Code;
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
            JSheetLogTable logTable = new JSheetLogTable();
            try
            {
                logTable.SetValueProperty(this);
                return logTable.Delete(pDB);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                //       Db.Dispose();
            }
        }
    }
}
