using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JNoticeTable : JTable
    {

        #region Property
        /// <summary>
        /// کد دادخواست یا شکواییه
        /// </summary>
        public int PetitionCode;
        /// <summary>
        /// کد فرد ارجاع کننده
        /// </summary>
        public int ReferPersonCode;
        /// <summary>
        /// تاریخ حضور
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// ساعت حضور
        /// </summary>
        public string Time;
        /// <summary>
        /// علت حضور
        /// </summary>
        public string Reasons;
        /// <summary>
        /// نتیجه حضور
        /// </summary>
        public string Result;
        /// <summary>
        /// تاریخ ابلاغ
        /// </summary>
        public DateTime DateNotified;
        /// <summary>
        /// حداکثر مهلت به روز
        /// </summary>
        public int DateMax;
        /// <summary>
        /// پایان مهلت
        /// </summary>
        public DateTime DateEnd;
        /// <summary>
        /// فیلد مطلع-اخطاریه جهت اطلاع می باشد 
        /// </summary>
        public bool Informed;


        #endregion

        public JNoticeTable()
            : base(JTableNamesLegal.Notice)
        {

        }
    }
}
