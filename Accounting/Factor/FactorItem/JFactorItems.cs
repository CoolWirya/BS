using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Factor.FactorItem
{
    public class JFactorItems : ClassLibrary.JSystem
    {

        public static System.Data.DataTable GetDataTable(int FactorCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();

            try
            {
                string query = string.Format(@"SELECT ROW_NUMBER() over(partition by FactorCode order by code) Row, Code,describe,count,cast(unitPrice as bigint)unitPrice,cast(TotalUnitPrice as bigint)TotalUnitPrice,product,FactorCode,parameter FROM AccFactorItem WHERE FactorCode= {0}", FactorCode);


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
