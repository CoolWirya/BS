using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JVacationType : JSubBaseDefine
    {
        public JVacationType()
            : base(JTableNameEmployment.VacationType)
        {
        }
    }

    public class JVacationTypes : JSubBaseDefines
    {
        public JVacationTypes()
            : base(JTableNameEmployment.VacationType)
        {
        }
    }
}
