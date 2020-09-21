using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JContractEmployeeType : JSubBaseDefine
    {
        public JContractEmployeeType()
            : base(JTableNameEmployment.PersonelContractType)
        {
        }
    }

    public class JContractEmployeeTypes : JSubBaseDefines
    {
        public JContractEmployeeTypes()
            : base(JTableNameEmployment.PersonelContractType)
        {

        }
    }
}
