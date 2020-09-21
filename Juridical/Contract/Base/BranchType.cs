using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JBranchType : JSubBaseDefine
    {
        public JBranchType()
           : base(JBaseDefine.BranchTypes)
       {
       }
    }
    public class JBranchTypes : JSubBaseDefines
    {
        public JBranchTypes()
            : base(JBaseDefine.BranchTypes)
        {
        }
    }
}
