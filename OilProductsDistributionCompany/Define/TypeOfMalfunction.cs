using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OilProductsDistributionCompany.Define
{
    public class JTypeOfMalfunction : ClassLibrary.JSubBaseDefine
    {
        public JTypeOfMalfunction()
            : base(JDefine.TypeOfMalfunction)
        {
        }
    }
    public class JTypeOfMalfunctions : ClassLibrary.JSubBaseDefines
    {
        public JTypeOfMalfunctions()
            : base(JDefine.TypeOfMalfunction)
        {
        }
    }
}
