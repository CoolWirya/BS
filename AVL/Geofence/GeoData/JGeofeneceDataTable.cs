using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Geofence.GeoData
{
   public class JGeofeneceDataTable: ClassLibrary.JTable
    {

       public DateTime LastDate;
        public int ObjectCode;
        public int GeoCode;
        public bool entered;
        public bool IsGeofence;
        public JGeofeneceDataTable()
            : base("AVLGeofenceData")
        {

        }
    }
}
