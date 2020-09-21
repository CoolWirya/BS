using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JVacationDailyTable : JTable
    {
        public JVacationDailyTable()
            : base("EmpVacationDaily")
        {
        }

        #region Property
        /// <summary>
        /// کد پست درخواست کننده 
        /// </summary>
        public int User_Post_Code;
        /// <summary>
        /// کد درخواست کننده 
        /// </summary>
        public int User_Code;
        /// <summary>
        /// عنوان درخواست کننده 
        /// </summary>
        public string User_Full_Title;
        /// <summary>
        /// کد  شخص درخواست کننده 
        /// </summary>
        public int pCode;
        /// <summary>
        /// کد پست ثبت کننده 
        /// </summary>
        public int Register_Post_Code;
        /// <summary>
        /// عنوان ثبت کننده 
        /// </summary>
        public string Register_Full_Title;
        /// <summary>
        /// کد ثبت کننده 
        /// </summary>
        public int Register_User_Code;
        /// <summary>
        /// کد پست تایید کننده 
        /// </summary>
        public int Confirm_Post_Code;
        /// <summary>
        /// عنوان تایید کننده 
        /// </summary>
        public string Confirm_Full_Title;
        /// <summary>
        /// کد  شخص تایید کننده 
        /// </summary>
        public int Confirm_User_Code;
        /// <summary>
        /// کد پست تایید کارگزینی کننده 
        /// </summary>
        public int ConfirmVacation_Post_Code;
        /// <summary>
        /// عنوان تایید کارگزینی کننده 
        /// </summary>
        public string ConfirmVacation_Full_Title;
        /// <summary>
        /// کد   تایید کارگزینی کننده 
        /// </summary>
        public int ConfirmVacation_User_Code;
        /// <summary>
        /// وضعیت 
        /// </summary>
        public int Status;
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// تاریخ پایان 
        /// </summary>
        public DateTime EndDate;
        /// <summary>
        /// نوع مرخصی 
        /// </summary>
        public int Type;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;

        #endregion
    }
}
