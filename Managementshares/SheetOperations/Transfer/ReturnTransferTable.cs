using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
 
namespace ManagementShares
{
    public class ReturnTransferTable : JTable
    {
        public int TransferCode;
        public DateTime RDateS;

        public ReturnTransferTable()
            : base("ShareReturnTransfer")
        {
        }
    }
}
