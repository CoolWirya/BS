using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Coordinate
{
    public class JCoordinateTable : ClassLibrary.JTable
    {
        public int DeviceCode;
        public int ObjectCode;
        public float lng;
        public float lat;
        public DateTime RegisterDateTime;
        public DateTime DeviceSendDateTime;        
        public float Altitude;
        public float Speed;
        public int Angle;
        public string Battery;
        public JCoordinateTable()
            : base("AVLCoordinate")
        {

        }
    }
}
