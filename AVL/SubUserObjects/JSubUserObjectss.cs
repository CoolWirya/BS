using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.SubUserObjects
{
    public class JSubUserObjectss:ClassLibrary.JSystem
    {
       static public System.Data.DataTable GetDataTable(int patentUserCode,int CurrentUserCode)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.SubUserObjects.JSubUserObjectss.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM [AVLSubUserObjects]";
                    query += " where parentUserCode=" + patentUserCode;
                    query += " AND userCode="+CurrentUserCode;
                
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
