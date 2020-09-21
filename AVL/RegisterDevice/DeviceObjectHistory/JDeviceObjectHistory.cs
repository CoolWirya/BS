using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.RegisterDevice.DeviceObjectHistory
{
    public class JDeviceObjectHistory : ClassLibrary.JSystem
    {
        public int Code { get; set; }
        public int DeviceCode { get; set; }
        public int ObjectCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public JDeviceObjectHistory()
        {

        }

        public JDeviceObjectHistory(int DeviceCode)
        {
            GetData("SELECT TOP 1 * FROM AVLDeviceObjectHistory WHERE DeviceCode=" + DeviceCode);
        }


        public bool Update()
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.RegisterDevice.DeviceObjectHistory.JDeviceObjectHistory.Update"))
                return false;
            JDeviceObjectTable AT = new JDeviceObjectTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                return true;
            }
            else
                return false;
        }


        public int Insert()
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.RegisterDevice.DeviceObjectHistory.JDeviceObjectHistory.Insert"))
                return 0;
            JDeviceObjectTable AT = new JDeviceObjectTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();


            return Code;
        }


        public bool GetData(string query)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(query);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

    }
}
