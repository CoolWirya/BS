using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JDecisionTable : JTable
    {

       #region Property

        /// <summary>
        /// کددادخواست
        /// </summary>
        public int PetitionCode;
        /// <summary>
        /// تاریخ رای
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// شماره دادنامه
        /// </summary>
        public string number;
        /// <summary>
        /// بر علیه شرکت
        /// </summary>
        public JAgainstCompanyType AgainstCompany;
        /// <summary>
        /// نوع آرا / قرار
        /// </summary>
        public bool Type;
        /// <summary>
        /// قطعی
        /// </summary>
        public bool Conclusive;
        /// <summary>
        /// توضیحات رای
        /// </summary>
        public string DecisionDesc;
        /// <summary>
        /// غیبت خوانده در دادگاه
        /// </summary>
        public bool AbsencePerson;

       #endregion

        public JDecisionTable()
            : base(JTableNamesLegal.Decision, "")
        {
        }
    }
}
