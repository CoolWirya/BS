using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JDefineSubjectType :JSubBaseDefine
    {
        public JDefineSubjectType()
            : base(JBaseDefine.IssueBriefs)
        {
        }
    }

    public class JDefineSubjectTypes : JSubBaseDefines
    {
        public JDefineSubjectTypes()
            : base(JBaseDefine.IssueBriefs)
        {
        }
    }
}
