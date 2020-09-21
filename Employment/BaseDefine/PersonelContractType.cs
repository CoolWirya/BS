using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JPersonelContractType : JSubBaseDefine
    {
        public JPersonelContractType()
            : base(JTableNameEmployment.PersonelContractType)
        {
        }
    }

    public class JPersonelContractTypes : JSubBaseDefines
    {
        public JPersonelContractTypes()
            : base(JTableNameEmployment.PersonelContractType)
        {

        }
    }
}
