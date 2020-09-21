using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.SpeedFault
{
    public class JSpeedFaultDataTable:ClassLibrary.JTable
    {
        public DateTime Datetime;
        public float LimitedSpeed;
        public float speed;
        public JSpeedFaultDataTable()
            : base("AVLSpeedFaultData")
        {
        }
    }
}
