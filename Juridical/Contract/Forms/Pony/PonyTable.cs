using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JPonyTable : JTable
    {

        #region Properties       
        
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractSubjectCode;
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Create_Date;
        /// <summary>
        /// اجاره ماهیانه
        /// </summary>
        public bool PriceMonth;
        /// <summary>
        /// مبلغ قرض الحسنه
        /// </summary>
        public bool Price;
        /// <summary>
        /// مبلغ شارژ ماهانه
        /// </summary>
        public bool Sharj;
        /// <summary>
        /// حق التحریر
        /// </summary>
        public bool RightStationery;
        /// <summary>
        /// تبلیغات
        /// </summary>
        public bool Advertisement;
        /// <summary>
        /// شهرداری
        /// </summary>
        public bool mayor;
        /// <summary>
        /// دارایی
        /// </summary>
        public bool TaxOffice;
        /// <summary>
        /// بیمه
        /// </summary>
        public bool InsuranceOffice;
        /// <summary>
        /// برق
        /// </summary>
        public bool Power;
        /// <summary>
        /// تلفن
        /// </summary>
        public bool Telephone;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// امضا موجر
        /// </summary>
        public bool RenterSignature;
        /// <summary>
        /// امضا مساجر
        /// </summary>
        public bool LodgerSignature;
        /// <summary>
        /// امضا اداری
        /// </summary>
        public bool OfficeSignature;
        /// <summary>
        /// امضا مدیر
        /// </summary>
        public bool ManagerSignature;

        #endregion

        public JPonyTable()
            : base(JTableNamesContracts.Pony, "")
        {
        }

    }
}
