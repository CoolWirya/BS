using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Communication
{
    class JCLetterRegisterTable : JTable
    {
        #region Peroperties
        /// <summary>
        /// نوع نامه - واره ، صادره یا درون سازمانی
        /// </summary>
        public int letter_type ;
        /// <summary>
        /// وضعیت نامه
        /// </summary>
        public int letter_status;
        /// <summary>
        /// کد موضوع نامه
        /// </summary>
        public int subject_code;
        /// <summary>
        /// پیش نویس نامه
        /// </summary>
        public string pre_subject;                      
        /// <summary>
        /// تاریخ و زمان ثبت
        /// </summary>
        public DateTime register_date_time;
        /// <summary>
        /// شماره ثبت
        /// </summary>
        public int register_no;
        /// <summary>
        /// شماره نامه
        /// </summary>
        public string letter_no;
        /// <summary>
        /// شماره نامه وارده
        /// </summary>
        public string incoming_no;
        /// <summary>
        /// تاریخ نامه وارده
        /// </summary>
        public DateTime incoming_date;
        /// <summary>
        /// امضا کننده نامه وارده
        /// </summary>
        public string incoming_signature_person;
        /// <summary>
        /// کد پست فرستنده
        /// </summary>
        public int sender_post_code;
        /// <summary>
        /// کد کاربر فرستنده
        /// </summary>
        public int sender_code;
        /// <summary>
        /// نام کامل ارسال کننده
        /// </summary>
        public string sender_full_title;
        /// <summary>
        /// کد سازمان فرستنده نامه
        /// </summary>
        public int sender_external_code;
        /// <summary>
        /// کد پست گیرنده
        /// </summary>
        public int receiver_post_code;
        /// <summary>
        /// کد کاربر گیرنده
        /// </summary>
        public int receiver_code;
        /// <summary>
        /// نام کامل دریافت کننده
        /// </summary>
        public string receiver_full_title;
        /// <summary>
        /// کد سازمان گیرنده نامه
        /// </summary>
        public int receiver_external_code;
        /// <summary>
        /// کد پست کاربر ثبت کننده
        /// </summary>
        public int register_post_code;
        /// <summary>
        /// کد کاربر ثبت کننده
        /// </summary>
        public int register_user_code;
        /// <summary>
        /// نام کامل کاربر ثبت کننده
        /// </summary>
        public string register_user_full_title;
        /// <summary>
        /// سطح محرمانگی
        /// </summary>
        public int secret_level;
        /// <summary>
        /// فوریت
        /// </summary>
        public int urgency;
        /// <summary>
        /// نحوه ارسال
        /// </summary>
        public int send_type;
        /// <summary>
        /// نحوه دریافت
        /// </summary>
        public int receiver_type;
        /// <summary>
        /// کد دبیرخانه
        /// </summary>
        public int secretariat_code;
        /// <summary>
        /// پیوست
        /// </summary>
        public string appendix;
        /// <summary>
        /// خلاصه نامه
        /// </summary>
        public string summary;
        /// <summary>
        ///  پاسخ
        /// </summary>
        public DateTime Respite_date_time;

        #endregion Peroperties
        
        public JCLetterRegisterTable()
            : base("Letters", "subject_code,register_no,sender_post_code,sender_code,sender_external_code,receiver_post_code,receiver_code,receiver_full_title,receiver_external_code,register_post_code,register_user_code,secret_level,urgency,send_type,receiver_type,secretariat_code")
        {
        }      
    }
}
