using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BusManagment.Bus 
{
    public class JBusTable : ClassLibrary.JTable
    {
       
        public int CarCode;
        public double BUSNumber;
        public bool Active;
        public int FleetCode;
        public JBusTable()
            : base("AUTBus")
        {
        }
    }
}
