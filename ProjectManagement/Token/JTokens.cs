using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Token
{
    public class JTokens : ClassLibrary.JSystem
    {
        public const string CLASSNAME = "ProjectManagement.Token.JTokens";

        public static bool DeleteAll(int userCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = string.Format(@"DELETE FROM pmTokens where userCode="+userCode.ToString());
                DB.setQuery(query);
                return DB.Query_Execute()>0;
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
