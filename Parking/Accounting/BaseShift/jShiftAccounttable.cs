using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class jShiftAccounttable : JTable
    {

        public DateTime Date;
        public DateTime Time ;
        public int Shift ;
        public int UserManager; 
        public float Amount ;
        public jShiftAccounttable()
            : base(JTableNamesParking.DefShift)
        {

        }
    }
}
