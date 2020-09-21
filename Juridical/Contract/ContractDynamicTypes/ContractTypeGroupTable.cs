using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JContractTypeGroupTable: JTable
    {
        public int DynamicCode;
        public int FinanceGroup;
        public JContractTypeGroupTable()
            : base("legContractTypeGroup")
        {
        }
    }

}
