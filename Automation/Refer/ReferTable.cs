using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    class JReferTable : JTable
    {

        #region Properties
        /// <summary>
        ///کد جدول Object
        /// </summary>
        public int object_code ;
        /// <summary>
        ///کد پدر
        /// </summary>
        public int parent_code;
        /// <summary>
        ///کد وطیفه
        /// </summary>
        public int task_code;
        /// <summary>
        /// نوع ارجاع
        /// </summary>
        public int refertype;
        /// <summary>
        /// 
        /// </summary>
        public int sender_External_code;
        /// <summary>
        /// کد پست فرستنده
        /// </summary>      
        public int sender_post_code ;
        /// <summary>
        /// کد کاربر فرستنده
        /// </summary>
        public int sender_code ;
        /// <summary>
        /// عنوان کامل فرستنده
        /// </summary>
        public string sender_full_title ;
        /// <summary>
        /// تاریخ و زمان ارجاع
        /// </summary>
        public DateTime send_date_time = ClassLibrary.JDateTime.Now();
        /// <summary>
        /// 
        /// </summary>
        public int receiver_External_code;
        /// <summary>
        /// کد پست گیرنده
        /// </summary>      
        public int receiver_post_code ;
        /// <summary>
        ///کد کاربر گیرنده
        /// </summary>
        public int receiver_code ;
        /// <summary>
        /// عنوان کامل گیرنده
        /// </summary>
        public string receiver_full_title ;
        /// <summary>
        /// وضعیت ارجاع
        /// </summary>
        public int status ;
        /// <summary>
        /// سطح محرمانگی
        /// </summary>
        public int secret_level ;
        /// <summary>
        /// تاریخ و زمان پاسخ
        /// </summary>
        public DateTime response_date_time;
        /// <summary>
        /// تاریخ و زمان مشاهده
        /// </summary>
        public DateTime view_date_time;
        /// <summary>
        /// فعال / غیر فعال
        /// </summary>
        public bool is_active ;
        /// <summary>
        /// دوره پاسخ
        /// </summary>
        public DateTime respite_date_time ;
        /// <summary>
        /// فوریت
        /// </summary>
        public int urgency ;
        /// <summary>
        /// پیام عادی
        /// </summary>
        public string message ;
        /// <summary>
        /// پیام محرمانه
        /// </summary>
        public string message_secret ;
        /// <summary>
        /// پاسخ عادی
        /// </summary>
        public string response ;
        /// <summary>
        /// پاسخ عادی
        /// </summary>
        public string response_secret ;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string description;
        /// <summary>
        /// کد کاربر ثبت کننده
        /// </summary>
        public int register_user_code;
        /// <summary>
        /// تاریخ و زمان ثبت
        /// </summary>
        public DateTime register_Date_Time;
        /// <summary>
        /// ضمائم
        /// </summary>
        public string attachments;
        /// <summary>
        /// 
        /// </summary>
        public int ReferLevel;
        /// <summary>
        /// 
        /// </summary>
        public string DescriptionObject;
        /// <summary>
        /// 
        /// </summary>
        public int ReferGroup;
        /// <summary>
        /// 
        /// </summary>
        public int WorkFlowCode;
        #endregion

        public JReferTable()
            : base("Refer", "parent_code,task_code,receiver_post_code,response_date_time,view_date_time")
        {
        }
    }
}
