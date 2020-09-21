using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    public class JEstateType :JSubBaseDefine
    {
        public JEstateType()
            : base(JBaseDefineEstates.EstateType)
        {
        }

    }

    public class JEstateTypes : JSubBaseDefines
    {
        public JEstateTypes()
            : base(JBaseDefineEstates.EstateType)
        {
        }
    }
}
