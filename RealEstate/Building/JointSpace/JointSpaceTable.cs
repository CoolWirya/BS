using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    public class JJointSpaceTable : JTable
    {
        public int CodeEnviroment = 0;
        public int Area = 0;
        public int CodeSpace = 0;
        public decimal moneyArea = 0;
        public decimal ChargeAmount = 0;
        public string Topics = "";
        public int JobTitle =0;
        public string Address = "";
        public int Register = 0;

        public JJointSpaceTable()
            : base("ReJointSpaceTable")
        {
        }
    }
}
