using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{
    public class JRealPriceTable : JTable
    {
        #region Properties
        /// <summary>
        /// تاریخ 
        /// </summary>
        public DateTime Create_Date;
        /// <summary>
        /// مبلغ
        /// </summary>
        public Decimal Price;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// بابت
        /// </summary>
        public int Concern;
        /// <summary>
        /// کد دریافت کننده
        /// </summary>
        public int ReceiverCode;
        /// <summary>
        /// کد صادر کننده
        /// </summary>
        public int ExporterCode;

        #endregion

        public JRealPriceTable()
            : base(JTableNamesFinance.RealPrice, "")
        {
        }
    }
}
