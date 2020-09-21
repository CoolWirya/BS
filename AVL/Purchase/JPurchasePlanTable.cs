using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Purchase
{
    public class JPurchasePlanTable:ClassLibrary.JTable
    {
        public string planName { get; set; }
        public double price { get; set; }
        public JPurchasePlanTable()
            : base("AVLPurchasePlan")
        {

        }
    }
}
