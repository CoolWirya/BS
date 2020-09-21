using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    /// <summary>
    /// محل انجام قرارداد
    /// </summary>
    public class JContractLocation : JSubBaseDefine
    {
        public JContractLocation()
            : base(JBaseDefineLegal.ContractLocations)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JContractLocations : JSubBaseDefines
    {
        public JContractLocations()
            : base(JBaseDefineLegal.ContractLocations)
        {

        }

    }
}
