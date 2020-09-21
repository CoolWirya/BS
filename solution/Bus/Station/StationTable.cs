using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Station
{
    class StationTable:ClassLibrary.JTable
    {
        #region Properties
        public string Name;
        public int ZoneCode;
        public int StationTypeCode;
        public decimal Lat;
        public decimal Lng;
        public bool isTerminal;
        public string Address;
        public string StationCode;
        #endregion

        public StationTable()
            : base("AUTStation")
        {
        }
    }
}
