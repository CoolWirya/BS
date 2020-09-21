using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JRenewTable : JTable
    {
        #region Prperties
        public int ReceiptGoodCode;
        public DateTime Date;
        public decimal Cost;
        public decimal Amount;
        public string Description;
        public bool Closed;

        #endregion

        public JRenewTable()
            : base("SCRenew")
        {
        }
    }
}
