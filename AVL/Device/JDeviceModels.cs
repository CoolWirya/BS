using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Device
{
    public class JDeviceModels:ClassLibrary.JSystem
    {
        public static System.Data.DataTable GetDataTable(int pCode = 0)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Device.JDeviceModels.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM DeviceModel";
               // + " WHERE " + ClassLibrary.JPermission.getObjectSql("AVL.Device.JDeviceModels.GetDataTable", "AVLDeviceModel.Code");
                if (pCode > 0)
                    query += " WHERE Code=" + pCode.ToString();

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
