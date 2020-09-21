using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    class jMarketLocationTable : JTable
    {
        public int MarketCode;
        public int GroundCode;
        public decimal occupancy;

        public jMarketLocationTable()
            : base(JTableNamesEstate.MarketLocation,"" )
        {
        }
    }

    public enum estMarketLocation
    {
        Code,
        MarketCode,
        GroundCode,
        occupancy,
    }
}
