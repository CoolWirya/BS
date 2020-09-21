using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.RegisterDevice.DeviceObjectHistory
{
    public class JDeviceObjectHistories : ClassLibrary.JSystem
    {

        public static System.Data.DataTable GetDataTable(int deviceCode)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.RegisterDeivce.DeviceObjectHistory.JDeviceObjectHistories.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM AVLDeviceObjectHistory"; 

                query += " where DeviceCode=" + deviceCode;
               
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
