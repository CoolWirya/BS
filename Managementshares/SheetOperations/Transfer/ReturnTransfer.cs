using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementShares
{
    public class JReturnTransfer : JManagementshares
    {
        public int Code { get; set; }
        public int TransferCode { get; set; }
        public DateTime RDate { get; set; }
    }
}
