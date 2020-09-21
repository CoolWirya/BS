using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JAdvocacyTable : JTable
    {

        #region Property
        /// <summary>
        /// کد موکل
        /// </summary>
        public int PersonCode;
        /// <summary>
        /// تاریخ شروع وکالت
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// تاریخ پایان وکالت
        /// </summary>
        public DateTime EndDate;
        /// <summary>
        /// کد نامه محضر
        /// </summary>
        public int NotaryCode;
        /// <summary>
        /// توضیحات اختیارات
        /// </summary>
        public string Description;
        /// <summary>
        /// نوع انحلال
        /// </summary>
        public int Breakup_Type;
        /// <summary>
        /// تاریخ انحلال
        /// </summary>
        public DateTime BreakupDate;
        /// <summary>
        /// کد نامه انحلال از محضر
        /// </summary>
        public int Breakup_Notary;
        /// <summary>
        /// کد نامه انحلال از دادگاه
        /// </summary>
        public int Breakup_tribunal;
        /// <summary>
        /// توضیح انحلال
        /// </summary>
        public string BreakupDesc;
        /// <summary>
        /// وضعیت وکالت
        /// </summary>
        public Boolean State;
        /// <summary>
        /// نوع وکالت
        /// </summary>
        public int Type;
        /// <summary>
        /// تایید شده توسط واحد حقوقی
        /// </summary>
        public Boolean Confirm;
        /// <summary>
        /// کد اموال
        /// </summary>
        //public int FinanceCode;
        /// <summary>
        /// کد حکم انحلال وکالت از دادگاه
        /// </summary>
        public int DesionCode;
        /// <summary>
        /// شماره دفتر
        /// </summary>
        public int NotaryOffice;
        /// <summary>
        /// شماره وکالت نامه
        /// </summary>
        public string LetterNo;
        /// <summary>
        /// تاریخ وکالت نامه 
        /// </summary>
        public DateTime LetterDate;
        /// <summary>
        /// موضوع وکالت نامه
        /// </summary>
        public string LetterSubject;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string LetterDesc;
        /// <summary>
        /// وکالت تمام دارایی ها
        /// </summary>
        public bool AllAssets;

        #endregion

        public JAdvocacyTable()
            : base(JTableNamesLegal.AdvocacyTable, "")
        {
        }
    }
}
