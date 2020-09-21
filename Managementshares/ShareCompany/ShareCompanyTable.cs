using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JShareCompanyTable :JTable
    {
        public JShareCompanyTable()
            : base("ShareCompany")
        {
        }
        public int PCode;
        public decimal CurrentShareCost;
        public decimal CurrentShareCount;
        public int TaxTransfer;
    }
}
