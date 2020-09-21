using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate.Building.Joint
{
    class JJointClassTable : JTable
    {
        public string Type="";
        public int MarketCode = 0;
        public JJointClassTable()
            : base("ReJointTable")
        {
        }
    }
}
