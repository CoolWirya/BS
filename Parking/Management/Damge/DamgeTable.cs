using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JDamgeTable : JTable
    {
      public JDamgeTable()
            : base(JTableNamesParking.Damge)
        {

        }


      public int Code;
      public int Type;
      public string Hint;
      public DateTime DateStop;
      public string Time;
      public int Gate;
      public int Code_Traffic;
      public int Market;
      public int Oprator;
    }
}
