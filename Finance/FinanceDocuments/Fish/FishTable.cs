using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{
    class JFishTable : JTable
    {
         #region Properties
        /// <summary>
        /// شماره حساب
        /// </summary>
        public string Accountnumber;
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
        public string Serial_No;
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

        public int ConcernForm;
        public int City;
        public int State;
        public int Acc1;
        public int Acc2;
        public int Acc3;
        public string ConcernSerial;
        public int Form;
        public int Serial;
        public int FormId;
        public int ItemNo;
        public int CompanyId;
        public int FormDtlId;
        public int Status;
        public int PersonGroup;

        #endregion

        public JFishTable()
            : base(JTableNamesFinance.Fish, "")
        {
        }
    }
}
