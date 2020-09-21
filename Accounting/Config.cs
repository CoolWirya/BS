using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting
{
    public static class Config
    {
        public static decimal getTaxPercentage()
        {
            return 9;
        }
        public static decimal getDeviceRegisterPrice()
        {
            // get this value form AVL.Reseller.JResellerDomain
            return 20000;

        }
    }
}
