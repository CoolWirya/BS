using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JFishTable : JTable
    {
         #region Properties
        /// <summary>
        /// کد بانک
        /// </summary>
        public int Bank_Code;
        /// <summary>
        /// کد شعبه
        /// </summary>
        public int branch_Code;
        /// <summary>
        /// شماره چک
        /// </summary>
        public int Serial_No;
        /// <summary>
        /// تاریخ تحویل
        /// </summary>
        public DateTime PaymentDate;
        /// <summary>
        /// تاریخ صدور
        /// </summary>
        public DateTime Create_Date;
        /// <summary>
        /// مبلغ
        /// </summary>
        public Decimal Price;
        /// <summary>
        /// کد دریافت کننده
        /// </summary>
        public int ReceiverCode;
        /// <summary>
        /// کد صادر کننده
        /// </summary>
        public int ExporterCode;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// بابت
        /// </summary>
        public int Concern;

        #endregion

        public JFishTable()
            : base(JTableNamesContracts.Fish, "")
        {
        }
    }
}
