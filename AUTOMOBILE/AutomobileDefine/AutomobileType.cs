using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AUTOMOBILE.AutomobileDefine
{
    public class JAutomobileType: ClassLibrary.JSubBaseDefine
    {
        public JAutomobileType()
            : base(ClassLibrary.JBaseDefine.AutomobileType)
        {
        }
    }

    public class JAutomobileTypes : ClassLibrary.JSubBaseDefines
    {
        public JAutomobileTypes()
            : base(ClassLibrary.JBaseDefine.AutomobileType)
        {
        }
    }
}
