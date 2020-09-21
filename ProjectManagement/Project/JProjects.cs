using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Project
{
   public  class JProjects : ClassLibrary.JSystem
    {
        public const string CLASSNAME = "ProjectManagement.Project.JProjects";
        public static System.Data.DataTable GetDataTable(bool checkPermission)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".GetDataTable");
            if(!hasPermission)
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = "SELECT * FROM pmProjects";
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
