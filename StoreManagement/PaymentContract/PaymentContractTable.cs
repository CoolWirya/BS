using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreManagement
{
    class JPaymentContractTable: JTable
    {
        public JPaymentContractTable()
            : base("StorePaymentContract")
        {
        }

        #region Property        
        /// <summary>
        /// کد قرارداد 
        /// </summary>
        public int ContractCode;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// تاریخ پرداخت
        /// </summary>
        public DateTime PayDate;
        /// <summary>
        /// قیمت
        /// </summary>
        public decimal Pay;
        /// <summary>
        ///  مالیات 
        /// </summary>
        public decimal Tax ;
        /// <summary>
        ///  عوارض
        /// </summary>
        public decimal Duty ;
        /// <summary>
        ///  مالیت مکسوره
        /// </summary>
        public decimal TaxMaksore;
        #endregion
    }
}
