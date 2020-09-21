using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.GPSData.TSIPAndroid
{
    //مربوط به جدول 
    //AVLTSIPAndroidSocket
    public class JTSIPAndroids:ClassLibrary.JSystem
    {
        public static System.Data.DataTable GetDataTable()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM [AVLTSIPAndroidSocket]"
                + " WHERE  [IsProceced]='false'";

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
