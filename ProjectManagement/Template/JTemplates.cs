using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Template
{
    public class JTemplates  : ClassLibrary.JSystem
    {
        public const String CLASSNAME = "ProjectManagement.Template.JTemplates";
        public static System.Data.DataTable GetDataTable(bool checkPermission=true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".GetDataTable");
            if (!hasPermission)
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * from pmTemplate";
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
