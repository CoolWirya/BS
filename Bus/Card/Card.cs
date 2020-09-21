using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.Card
{


    public class JCards : JSystem
    {

        public static DataTable GetDataTable(int pCode = 0)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = "select * from AUTCardType "
                     + " Where " + JPermission.getObjectSql("BusManagment.Card.JCards.GetDataTable", "AUTCardType.Code");
                if (pCode > 0)
                    query += " AND  Code = " + pCode;
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }



    }

}
