using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Area
{
    public class JAreaTable:ClassLibrary.JTable
    {
        public int personCode;
        public string ObjectsCodes;
        public string Points;
        public bool IsGeofence;
        public string Name;
        public bool isCircle;
        public decimal radius;
        public int clientAreaCode;
        public int deviceCode;
        public JAreaTable():base("AVLArea")
        {

        }
    }
}
