using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares.SahamMapping
{
    public class JSahamMapping
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int CodeSaham { get; set; }
        public int Static { get; set; }

        public bool GetData(string pName)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM SahamMapping WHERE Name='" + pName + "'");
                System.Data.DataTable _DT = DB.Query_DataTable();
                if (_DT.Rows.Count > 0)
                {
                    JTable.SetToClassProperty(this, _DT.Rows[0]);
                    return true;
                }

            }
            catch
            {
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
    }

    public class JSahamMappings
    {
        public System.Data.DataTable GetDataTable(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = " Where 1=1 ";
                if (pCode != 0)
                    Where = Where + " And Code=" + pCode;
                string query = @"Select * from SahamMapping " + Where;
                Db.setQuery(query);
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
