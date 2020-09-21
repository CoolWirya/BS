using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Spend
{
    public class JSpend : ClassLibrary.JSystem
    {
        public int Code { get; set; }
        public DateTime RegisterDate { get; set; }
        public decimal price { get; set; }
        public string Description { get; set; }
        public int DeviceCode { get; set; }
        public int userCode { get; set; }
    }
}
