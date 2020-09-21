using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    public class JChargeBuildTable : JTable
    {
        public decimal CurrentCharge = 0;
        public decimal PeriodCharge = 0;

        public decimal FirstPeriodCharges = 0;
        public int CodeMarket = 0;
        public int CodeUnitBuild = 0;
        public int Yaraneh = 0;
        public string Hint = "";

        public JChargeBuildTable()
            : base(JRETableNames.ChargeBuild)
        {

        }
    }
}
