using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Employment
{
    public class JCompanyEmployee : JEmployment
    {



		public static int CurrentCompany()
		{
			DataTable T = GetDataTable();
			if (T.Rows.Count > 0)
				return int.Parse(T.Rows[0]["Code"].ToString());
			return 0;
		}
        public static DataTable GetDataTable()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"select CompanyCode Code,(Select Name From ClsAllperson Where Code=CompanyCode) Name from EmpCompanyEmployee Where " + JPermission.getObjectSql("Employment.JCompanyEmployee.GetDataTable", "CompanyCode"));
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
