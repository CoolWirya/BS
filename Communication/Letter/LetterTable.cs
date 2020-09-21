using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Communication
{
    public class JCLetterTable : JTable
    {
        #region Peroperties
        /// <summary>
        /// نامه قبلی
        /// </summary>
        public int ParentCode;
        /// <summary>
        /// نوع نامه - واره ، صادره یا درون سازمانی
        /// </summary>
        public int letter_type;
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
        public string subject;
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
        public DateTime respite_date_time;

        public DateTime minute_register_date;
        /// <summary>
        /// متن نامه
        /// </summary>
        public string LetterText;
        /// <summary>
        /// متن ساده نامه
        /// </summary>
        public string NormalLetterText;
        /// <summary>
        /// وضعیت امضا
        /// </summary>
        public bool isSigned;
        /// <summary>
        /// تاریخ امضا
        /// </summary>
        public DateTime SignDate;
        /// <summary>
        /// کد تصویر در بایگانی تصاویر
        /// </summary>
        public int ImageCode;
        /// <summary>
        /// نوع ارسال و تحویل
        /// </summary>
        public int DeliveryType;
        /// <summary>
        /// تاریخ ارسال
        /// </summary>
        public DateTime DeliveryDate;
        /// <summary>
        /// شخص تحویل گیرنده
        /// </summary>
        public string DeliveryPerson;
		/// <summary>
		/// 
		/// </summary>
		public string html;
        /// <summary>
        /// 
        /// </summary>
        public int EditorType;
        #endregion Peroperties

        public JCLetterTable()
            : base("Letters")
        {
        }

    }
}
