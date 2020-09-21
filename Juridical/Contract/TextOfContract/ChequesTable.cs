using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
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
        /// <summary>
        /// شماره چک
        /// </summary>
        public int Cheque_No;
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

        #endregion


        public JChequesTable()
            : base(JTableNamesLegal.Cheques, "")
        {
        }
    }
}
