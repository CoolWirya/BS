using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Globals
{
    class JUserTable:JTable
    {
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string username ;
        /// <summary>
        /// کلمه عبور
        /// </summary>
        public string password ;
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode;
        /// <summary>
        /// درحال کار
        /// </summary>
        //public Boolean login ;
        /// <summary>
        /// آخرین زمان ورود
        /// </summary>
        public DateTime lastlogin ;
        /// <summary>
        /// آخرین تاریخ عوض کردن پسورد
        /// </summary>
        public DateTime LastPassChangeDate;
        /// <summary>
        /// فعال
        /// </summary>
        public Boolean Active ;
        /// <summary>
        /// تعداد ورودهای ناموفق
        /// </summary>
        public int LoginFaildCount ;
        /// <summary>
        /// غیر فعال به صورت موقت
        /// </summary>
        public Boolean TempDeactive ;
        /// <summary>
        /// کد پست پیش فرض
        /// </summary>
        public int default_post_code;
        /// <summary>
        /// کد منحصر بفرد
        /// </summary>
        public string Guide;
        /// <summary>
        /// نام دامینی
        /// </summary>
        public string domainName;
        /// <summary>
        /// 
        /// </summary>
        public string Serial;
        /// <summary>
        /// 
        /// </summary>
        public Boolean isLogin;

        public Boolean IsAdmin;

        public Int32 UniqCode;

        public string marketerCode;

        public bool LoginedFromAndroid;
        public JUserTable()
            : base("users")
        {
            Set_ComplexInsert(false);
        }
    }
    enum JUserTableEnum
    {
        Code,
        /// <summary>
        /// نام کاربری
        /// </summary>
        username ,
        /// <summary>
        /// کلمه عبور
        /// </summary>
        password,
        /// <summary>
        /// کد شخص
        /// </summary>
        PCode,
        /// <summary>
        /// درحال کار
        /// </summary>
        //public Boolean login ;
        /// <summary>
        /// آخرین زمان ورود
        /// </summary>
        lastlogin ,
        /// <summary>
        /// فعال
        /// </summary>
        Active ,
        /// <summary>
        /// تعداد ورودهای ناموفق
        /// </summary>
        LoginFaildCount ,
        /// <summary>
        /// غیر فعال به صورت موقت
        /// </summary>
        TempDeactive ,
        /// <summary>
        /// کد پست پیش فرض
        /// </summary>
        default_post_code,
        /// <summary>
        /// کد منحصر بفرد
        /// </summary>
        Guide,
        /// <summary>
        /// نام دومینی
        /// </summary>
        domainName,
		/// <summary>
		/// ورود به سیستم از طریق اندروید
		/// </summary>
		LoginedFromAndroid
    }
}
