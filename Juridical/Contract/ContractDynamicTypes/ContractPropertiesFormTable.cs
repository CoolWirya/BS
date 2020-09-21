using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legal
{
    public class JContractPropertiesFormTable: ClassLibrary.JTable
    {
        public string FormName;
        public int ContractTypeCode;
        public string ProPertiesName;
        public bool Value;

        public JContractPropertiesFormTable()
            : base("legContractPropertiesForm")
        {
        }

    }
}
