using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Factor.FactorItem
{
    public class JFactorItemTable : ClassLibrary.JTable
    {
        public int Row;
        public string describe;
        public int count;
        public decimal unitPrice;
        public decimal TotalUnitPrice;
        public int product;
        public int FactorCode;
        public string parameter;
        public JFactorItemTable() : base("AccFactorItem") { }
    }
}
