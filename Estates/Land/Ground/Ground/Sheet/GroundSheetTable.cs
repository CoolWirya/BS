using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates.Land.Ground.Ground.Sheet
{
    public class JGroundSheetTable: ClassLibrary.JTable
    {
        public int GCode;
        public int PCode;
        public int ContractCode;
        public int PersonContractCode;
        public float Area;
        public DateTime CreateDate;
        public int Creator;
        public int NumPrint;
        public int State;
        public int DeActive;
        public int Parent;

        public JGroundSheetTable()
            : base("estSheet")
        {
            
        }
    }
}
