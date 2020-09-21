using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JAssemblyPresenceTable :JTable
    {
        public int ACode;
        public int AgentPCode;
        public DateTime PresenceTime;
        public JAssemblyPresenceTable()
            : base("ShareAssemblyPresence")
        {
        }
    }
}
