using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JPollingCandidaTable:JTable
    {
        public JPollingCandidaTable()
            : base("ShareAssemblyPollingCandida")
        {
        }
        public int PCode;
        public int PollingCode;

    }
}
