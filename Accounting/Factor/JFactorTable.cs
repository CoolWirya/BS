using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Factor
{
    public class JFactorTable: ClassLibrary.JTable
    {
        public int Number;
        public DateTime RegisterDate;
        public bool payState;
        public int userCode;
        public decimal Tax;
        public decimal Total;
        public decimal Discount;
        public JFactorTable() : base("AccFactor") { }
    }
}
