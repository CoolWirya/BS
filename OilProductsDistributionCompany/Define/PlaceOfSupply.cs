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
    public class JPlaceOfSupply : JSubBaseDefine
    {
        public JPlaceOfSupply()
            : base(JDefine.PlaceOfSupply)
        {
        }

    }

    public class JPlaceOfSupplies : JSubBaseDefines
    {
        public JPlaceOfSupplies()
            : base(JDefine.PlaceOfSupply)
        {
        }

    }
}
