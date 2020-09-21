using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ShareProfit
{
    public class JCourseTable :  JTable
    {
        public JCourseTable()
            : base(JTableNamesShareProfit.Cources)
        {
        }

        /// <summary>
        /// عنوان دوره
        /// </summary>
        public string Title ;
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public string StartDate ;
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public string EndDate ;
        /// <summary>
        /// سال مالی
        /// </summary>
        public int FinYear ;
        /// <summary>
        /// مبلغ سود هر سهم
        /// </summary>
        public decimal Cost ;
        /// <summary>
        /// تاریخ تصویب
        /// </summary>
        public string ApproveDate ;
        /// <summary>
        /// پرداخت نقدی
        /// </summary>
        public bool Pocket;
        /// <summary>
        /// نوع پرداخت
        /// </summary>
        public int PaymentType;
        /// <summary>
        /// مبلغ پایه
        /// </summary>
        public decimal BaseCost;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// خواندن اطلاعات سهام از نرم افزار سهام بصورت آنلاین
        /// </summary>
        public bool OnlinePayment;
        /// <summary>
        /// از شماره برگه
        /// </summary>
        public int FromSheet;
        /// <summary>
        /// تا شماره برگه
        /// </summary>
        public int ToSheet;
        /// <summary>
        /// تعداد سهم
        /// </summary>
        public int ShareCount;
        /// <summary>
        /// شرکت
        /// </summary>
        public int CompanyCode;
    }

    public enum JCourseEnum
    {
        Code,
        title,
        startdate,
        enddate,
        finyear,
        cost,
        ApproveDate,
        PaymentType
    }
}
