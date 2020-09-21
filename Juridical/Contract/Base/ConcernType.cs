using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JConcernType : JSubBaseDefine
    {
        public JConcernType()
            : base(JBaseDefine.ConcernType)
        {
        }
    }
        public class JConcernTypes : JSubBaseDefines
        {
            public JConcernTypes()
                : base(JBaseDefine.ConcernType)
            {
            }
        }
}
