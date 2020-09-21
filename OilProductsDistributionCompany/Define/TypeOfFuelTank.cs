using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilProductsDistributionCompany.Define
{
    /// <summary>
    /// نوع مخزن سوخت
    /// </summary>
    public class JTypeOfFuelTank : ClassLibrary.JSubBaseDefine
    {
        public JTypeOfFuelTank()
            : base(JDefine.TypeOfFuelTank)
        {
        }
    }
    public class JTypeOfFuelTanks : ClassLibrary.JSubBaseDefines
    {
        public JTypeOfFuelTanks()
            : base(JDefine.TypeOfFuelTank)
        {
        }
    }
}
