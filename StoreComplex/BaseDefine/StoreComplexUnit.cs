using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    /// <summary>
    /// واحدها در قرارداد مجتمع انبارها
    /// </summary>
    public class JSCUnit : JSubBaseDefine
    {
        public JSCUnit()
            : base(JBaseDefine.SCUnits)
        {
        }
    }

    public class JSCUnits : JSubBaseDefines
    {
        public JSCUnits()
            : base(JBaseDefine.SCUnits)
        {
        }
    }
}
