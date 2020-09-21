using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    /// <summary>
    /// انواع سرویس در مجتمع انبارها
    /// </summary>
    public class JServiceType : JSubBaseDefine
    {
        public JServiceType() :
            base(JBaseDefine.SCServices)
        {
        }
    }

    public class JServiceTypes : JSubBaseDefines
    {
        public JServiceTypes() :
            base(JBaseDefine.SCServices)
        {
        }
    }
}