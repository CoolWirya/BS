using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.UserObjects
{
    public class JUserObjects : ClassLibrary.JSystem
    {
        public static System.Data.DataTable GetDataTable(int pCode = 0)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.UserObjects.JUserObjects.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM AVLUserObjects"
                + " WHERE 1=1 ";// +ClassLibrary.JPermission.getObjectSql("AVL.UserObjects.JUserObjects.GetDataTable", "AVLUserObject.Code");
                if (pCode != 0)
                    query += " AND personCode= " + pCode.ToString() +" AND isActive='true' ";

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
