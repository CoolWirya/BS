using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Geofence
{
    public class JGeofenceTable : ClassLibrary.JTable
    {
        public int code;
        public int LineCode;
        public int ObjectCode;
        public DateTime LastDate;
        public bool InArea;
        public JGeofenceTable()
            : base("AVLGeofenceData")
        {
        }
    }
}
