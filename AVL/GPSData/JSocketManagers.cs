using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.GPSData
{
    public class JSocketManagers
    {
        public static System.Data.DataTable GetDataTable(int pCode = 0,bool CheckProceced=false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.GPSData.JSocketManagers.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM [ClsSocketClientDataManager]"
                + " WHERE 1=1 ";// + ClassLibrary.JPermission.getObjectSql("AVL.GPSData.JSocketManagers.GetDataTable", "JSocketManager.Code");
                if (CheckProceced)
                    query += " AND [IsProceced]='false'";
                if (pCode > 0)
                    query += " AND Code=" + pCode;

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
