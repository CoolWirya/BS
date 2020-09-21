using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Device
{
    public class JDeviceModelTable:ClassLibrary.JTable
    {
        public int RegDeviceCode;
        public int Year;
        public string Company;
        public string Model;
        public float UnitPrice;
        public int Speed;
        public JDeviceModelTable()
            : base("AVLDeviceModel")
        {

        }
    }
}
