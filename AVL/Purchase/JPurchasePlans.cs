using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Purchase
{
    public class JPurchasePlans:ClassLibrary.JSystem
    {
        public static System.Data.DataTable GetDataTable(int pCode = 0)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Purchase.JPurchasePlans.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM AVLPurchasePlan";
               // + " WHERE " + ClassLibrary.JPermission.getObjectSql("AVL.Purchase.JPurchasePlans.GetDataTable", "AVLPurchasePlan.Code");


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
