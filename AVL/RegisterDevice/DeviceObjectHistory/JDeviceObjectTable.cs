using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.RegisterDevice.DeviceObjectHistory
{
    public class JDeviceObjectTable : ClassLibrary.JTable
    {

        public int DeviceCode;
        public int ObjectCode;
        public DateTime StartDate;
        public DateTime EndDate;
        public JDeviceObjectTable()
            : base("AVLDeviceObjectHistory")
        {

        }
    }
}
