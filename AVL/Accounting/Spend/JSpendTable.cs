using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Accounting.Spend
{
    public  class JSpendTable : ClassLibrary.JTable
    {
        public JSpendTable()
            : base("AVLSpend")
        {

        }

        public DateTime RegisterDate;
        public decimal price;
        public string Description;
        public int DeviceCode;
        public int userCode;
    }
}
