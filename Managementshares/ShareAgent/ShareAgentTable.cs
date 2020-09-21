using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JShareAgentTable :JTable
    {
        public JShareAgentTable()
            : base("ShareAgent")
        {
        }
        public int PCode ;
        public DateTime StartDate ;
        public DateTime EndDate ;
        public DateTime DeActiveDate;
        public int Status;
        public bool IsFormal;
        public int CompanyCode;
    }
}
