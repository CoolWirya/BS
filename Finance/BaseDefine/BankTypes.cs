using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{
    public class JBankType : JSubBaseDefine
    {
       public JBankType()
           : base(JBaseDefine.BankTypes)
       {
       }
    }

        public class JBankTypes : JSubBaseDefines
        {
            public JBankTypes()
                : base(JBaseDefine.BankTypes)
            {
            }
        }

    }

