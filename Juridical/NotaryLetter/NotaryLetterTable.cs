using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JNotaryLetterTable : JTable
    {

        #region Property

        /// <summary>
        /// کد محضر
        /// </summary>
        public int Notary_Code;
        /// <summary>
        /// شماره نامه
        /// </summary>
        public string LetterNumber;
        /// <summary>
        /// تاریخ نامه
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// موضوع
        /// </summary>
        public int Subject;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// ارسالی یا در یافتی
        /// </summary>
        public bool Sended;

        #endregion

        public JNotaryLetterTable()
            : base(JTableNamesLegal.LegNotaryLetterTable)
        {

        }
    }
}
