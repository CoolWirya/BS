using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Device.DataProtocol
{
    public class JTSIPAndroidProtocol: JProtocolBase
    {
        //[1-150]     NOT SAVE IN AVLTSIPaNDROIDsOCKET
        //[1-1]       NOT SAVE IN AVLTSIPaNDROIDsOCKET
        //[8-IMEI]
        //[8-Longitude]
        //[8-Latitude]
        //[8-datetime]
        //[1-speed]
        //[1-curse]
        //[8-altitude]
        public DateTime datetime { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public float Altitude { get; set; }
        public int curse { get; set; }
        public float Speed { get; set; }
    }
}
