using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JSCTransferGoodsTable:JTable
    {
           public JSCTransferGoodsTable()
            : base("SCTransferGoods")
        {
        }
        #region Properties
        /// <summary>
        /// کد حواله
        /// </summary>
        public int TransferCode;
        /// <summary>
        /// کد کالا
        /// </summary>
        public int RecieptGoodCode;
        /// <summary>
        /// مقدار
        /// </summary>
        public decimal Amount;
        /// <summary>
        /// شرح
        /// </summary>
        public string Description;
       
        #endregion Properties
    }
}
