using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace OilProductsDistributionCompany.Define
{
    /// <summary>
    /// مکان محل عرضه
    /// </summary>
    public class JTypeOfSupply : JSubBaseDefine
    {
        public JTypeOfSupply()
            : base(JDefine.TypeOfSupply)
        {
        }

    }

    public class JTypeOfSupplies : JSubBaseDefines
    {
        public JTypeOfSupplies()
            : base(JDefine.TypeOfSupply)
        {
        }

    }
}
