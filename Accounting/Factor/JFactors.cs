using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Factor
{
    public class JFactors : ClassLibrary.JSystem
    {
        public static int GetNumberOpenFactor()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select Count(*) c from AccFactor where payState=0 AND  userCode=" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
                if (DB.Query_DataTable().Rows.Count == 0)
                    return 0;
                else
                    return (int)DB.Query_DataTable().Rows[0]["c"];
            }
            catch
            {

            }
            finally
            {
                DB.Dispose();
            }
            return 0;
        }
    }
}
