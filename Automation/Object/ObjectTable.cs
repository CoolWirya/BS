using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    public class JObjectTable: JTable
    {
        #region Properties
        /// <summary>
        /// آدرس تابعی که هنگام انتخاب شی باید اجرا شود
        /// </summary>
        public string action ;
        /// <summary>
        /// 
        /// </summary>
        public string BeforRefer;
        /// <summary>
        /// بعد از ارجا
        /// </summary>
        public string AfterRefer;
        /// <summary>
        /// کد شی در سیستم خودش
        /// </summary>
        public int ObjectCode ;
        /// <summary>
        /// کد پست فرستنده
        /// </summary>
        public int sender_post_code ;
        /// <summary>
        /// کد کاربر فرستنده
        /// </summary>
        public int sender_user_code ;
        /// <summary>
        /// عنوان کامل فرستنده
        /// </summary>
        public string sender_full_title ;
        /// <summary>
        /// تاریخ و زمان ایجاد
        /// </summary>
        public DateTime create_date_time ;
        /// <summary>
        /// عنوان شی
        /// </summary>
        public string title ;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string description;
        /// <summary>
        /// 
        /// </summary>
        public string ClassName;
        /// <summary>
        /// 
        /// </summary>
        public int DynamicClassCode;
        /// <summary>
        /// گرفتن داده از داخل شی
        /// </summary>
        public string ActionGetData;
        /// <summary>
        /// کد وضعیت
        /// </summary>
        public int StatusObject;

        #endregion

        public JObjectTable()
            : base("Objects")
        {

        }
    }
}
