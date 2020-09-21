using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    public class JGroundTable : JTable 
    {
        public JGroundTable():base(JTableNamesEstate.GroundTable)
        {
            
        }
        #region field

       
        /// <summary>
        /// اراضی
        /// </summary>
        public int Land;
       
        /// <summary>
        /// پلاک اصلی
        /// </summary>

        public string MainAve;
         /// <summary>
        /// پلاک فرعی
        /// </summary>
        public string SubNo;
        
        /// <summary>
        /// بخش
        /// </summary>
        public string Section;
        /// <summary>
        /// شماره بلوک
        /// </summary>
        public string BlockNum;
        /// <summary>
        /// شماره قطعه
        /// </summary>
        public string PartNum;
        /// <summary>
        /// کاربری
        /// </summary>
        public int Usage;
        /// <summary>
        /// مساحت
        /// </summary>
        public double Area;       
        /// <summary>
        /// توضیحات مربوط به زمین
        /// </summary>
        public string Comment;
        /// <summary>
        /// تاریخ جاری را ثبت سیستم می کند
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// شخصی که اطلاعات را ثبت سیستم می کند
        /// </summary>
        public int Person;
        /// <summary>
        /// وضعیت زمین
        /// </summary>
        public int Status;
        /// <summary>
        /// ارزش زمین
        /// </summary>
        public decimal Cost;
        /// <summary>
        /// نوع ملک:ملکی یا آستانه
        /// </summary>
        public int EstateType;
        /// <summary>
        /// حق ریشه دارد یا نه
        /// </summary>
        public bool RightRoot;
        /// <summary>
        /// نوع سند زمین
        /// </summary>
        public int DocumentType;
        /// <summary>
        /// کد تصویر کروکی در آرشیو
        /// </summary>
        public int Korooki;
        /// <summary>
        /// تعداد تقصیمات زمین
        /// </summary>
        public int TotalShare;
        /// <summary>
        /// کد دارایی
        /// </summary>
        public int FinanceCode;
        /// <summary>
        /// شماره سند مالکیت
        /// </summary>
        public string DocumentNumber;
        #endregion

    }
    public enum JGroundTableEnum
    {
        Code,
        Land,
       
        /// <summary>
        /// پلاک اصلی
        /// </summary>

         MainAve,
         /// <summary>
        /// پلاک فرعی
        /// </summary>
        SubNo,
        
        /// <summary>
        /// بخش
        /// </summary>
        Section,
        /// <summary>
        /// شماره بلوک
        /// </summary>
        BlockNum,
        /// <summary>
        /// شماره قطعه
        /// </summary>
        PartNum,
        /// <summary>
        /// کاربری
        /// </summary>
        Usage,
        /// <summary>
        /// مساحت
        /// </summary>
        Area,       
        /// <summary>
        /// توضیحات مربوط به زمین
        /// </summary>
        Comment,
        /// <summary>
        /// تاریخ جاری را ثبت سیستم می کند
        /// </summary>
        Date,
        /// <summary>
        /// شخصی که اطلاعات را ثبت سیستم می کند
        /// </summary>
        Person

  
    }

  
}
