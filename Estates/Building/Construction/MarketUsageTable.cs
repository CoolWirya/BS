using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    class jMarketUsageTable : JTable
    {
        public int MarketCode;
        public int UsageCode;
        public string Infrastructure;
        
        public jMarketUsageTable()
            : base(JTableNamesEstate.MarketUsage,"" )
        {
        }
    }
}
