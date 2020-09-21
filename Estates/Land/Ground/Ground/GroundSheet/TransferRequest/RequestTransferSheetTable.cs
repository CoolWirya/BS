using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates
{
    public class JRequestTransferSheetTable : ClassLibrary.JTable
    {
        public JRequestTransferSheetTable()
            : base("estrequesttransfersheet")
        {

        }
        public int SheetCode;
        public string RequestNumber;
        public DateTime RequestDate;
        public string Description;
        public int Price;
        public bool Manager;
        public bool ManagerSaham;
        public bool Responsible;
        public int SellerCode;
        public int BuyerCode;

    }
}
