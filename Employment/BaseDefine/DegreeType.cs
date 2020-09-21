using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JDegreeType : JSubBaseDefine
    {
        public JDegreeType()
            : base(JTableNameEmployment.DegreeType)
        {
        }
    }

    public class JDegreeTypes : JSubBaseDefines
    {
        public JDegreeTypes()
            : base(JTableNameEmployment.DegreeType)
        {

        }
    }
}
