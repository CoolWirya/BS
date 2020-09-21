using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JShareAgentHistory :JSystem
    {
        public int Code { get; set; }
        public int SCode { get; set; }
        public int ACode { get; set; }
        public DateTime ChangeDate{ get; set; }
    }
}
