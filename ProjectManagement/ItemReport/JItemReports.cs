using System;

namespace ProjectManagement.ItemReport
{
   public class JItemReports : ClassLibrary.JSystem
    {
        public const String CLASSNAME = "ProjectManagement.ItemReport.JItemReports";
        public static System.Data.DataTable GetDataTable(int pCode)
        {
            throw new NotImplementedException();
            if (!ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = "";
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
