using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilProductsDistributionCompany.Define
{
    /// <summary>
    /// نوع فراورده نفت - سوپر - نفت گاز
    /// </summary>
    public class JTypeOfProduct : ClassLibrary.JSubBaseDefine
    {
        public JTypeOfProduct()
            : base(JDefine.TypeOfProduct)
        {
        }
    }
    public class JTypeOfProducts : ClassLibrary.JSubBaseDefines
    {
        public JTypeOfProducts()
            : base(JDefine.TypeOfProduct)
        {
        }
    }
}
