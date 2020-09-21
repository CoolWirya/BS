using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Device.DataProtocol
{
    /// <summary>
    /// FM1100, FM2100, FM2200, FM4100 , FM4200
    /// CodecID -1
    /// NumberOfData -1
    /// TimeStamp -8
    /// priority -1
    /// Longitude -4
    /// Latitude -4
    /// Altitude -2
    /// Angle -2
    /// Satellite -1
    /// Speed -2
    /// [IOElement]
    /// EventIOID -1
    /// 
    /// </summary>
    public class JTeltonikaProtocolV1 :JProtocolBase
    {

        public int CodecID { get; set; }
        public int NumberOfData { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte Priority { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public float Altitude { get; set; }
        public int Angle { get; set; }
        public int Satellite { get; set; }
        public float Speed { get; set; }


    }
}
