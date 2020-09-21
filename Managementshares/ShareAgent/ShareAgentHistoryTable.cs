using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JShareAgentHistoryTable :JTable
    {
        public JShareAgentHistoryTable()
            : base("ShareAgentHistory", "ACode")
        {
        }
        public int SCode;
        public int ACode ;
        public DateTime ChangeDate ;
    }
}
