using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JSCReceiptGoodsTable : JTable
    {
        public JSCReceiptGoodsTable()
            : base("SCReceiptGoods")
        {
        }
        #region Properties
        /// <summary>
        /// کد رسید
        /// </summary>
        public int ReceiptCode;
        /// <summary>
        /// کد کالا
        /// </summary>
        public int GoodCode;
        /// <summary>
        /// مقدار
        /// </summary>
        public decimal Amount;
        /// <summary>
        /// شرح
        /// </summary>
        public string Description;
        /// <summary>
        /// هزینه
        /// </summary>
        public decimal Cost;
        /// <summary>
        /// نوع انبارداری
        /// </summary>
        public int StoreType;
        #endregion Properties
    }
}
