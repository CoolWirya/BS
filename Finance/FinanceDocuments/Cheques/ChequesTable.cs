using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{
    public class JChequesTable : JTable
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
        public int branch_Number;
        /// <summary>
        /// شماره چک
        /// </summary>
        public string Cheque_No;
        /// <summary>
        /// تاریخ تحویل
        /// </summary>
        public DateTime Create_Date;
        /// <summary>
        /// تاریخ صدور
        /// </summary>
        public DateTime Issue_Date;
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
        /// پشت نویسی
        /// </summary>
        public string Back_Note;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// تاریخ برگشت
        /// </summary>
        public DateTime Return_Date;
        /// <summary>
        /// تاریخ پاس
        /// </summary>
        public DateTime Pass_Date;
        /// <summary>
        /// بابت
        /// </summary>
        public int Concern;
        /// <summary>
        /// شماره حساب
        /// </summary>
        public string AccountNo;

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


        public JChequesTable()
            : base(JTableNamesFinance.Cheques, "")
        {
        }
    }
}
