using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{
    class JPromissoryNoteTable : JTable
    {
        #region Properties

        /// <summary>
        /// شماره 
        /// </summary>
        public string Serial_No;
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

        public JPromissoryNoteTable()
            : base(JTableNamesFinance.PromissoryNote, "")
        {
        }
    }
}
