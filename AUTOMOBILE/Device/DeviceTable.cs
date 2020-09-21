using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTOMOBILE.Device
{
    class DeviceTable:ClassLibrary.JTable
    {
        public int Type;
        public string ID;
        public string Tel;
        public string MacAddress;
        public string IMEI;
        public string Barcode;
        public string Model;

        public DeviceTable()
            : base("AUTDevice")
        {
        }
    }
}
