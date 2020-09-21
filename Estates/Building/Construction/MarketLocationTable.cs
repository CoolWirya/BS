using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    class jMarketLocationTable : JTable
    {
        public int MarketCode;
        public int GroundCode;
        public string occupancy;

        public jMarketLocationTable()
            : base(JTableNamesEstate.MarketLocation,"" )
        {
        }
    }
}
