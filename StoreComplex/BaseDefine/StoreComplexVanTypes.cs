using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JVanType : JSubBaseDefine
    {
        public JVanType()
            : base(JBaseDefine.SCVanTypes)
        {
        }
    }

    public class JVanTypes : JSubBaseDefines
    {
        public JVanTypes()
            : base(JBaseDefine.SCVanTypes)
        {
        }
    }
}
