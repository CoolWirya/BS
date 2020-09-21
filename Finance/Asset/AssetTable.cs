using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance
{

    public class JAssetTable: ClassLibrary.JTable
    {
        ///// <summary>
        /////کد دارائی قبلی 
        ///// </summary>
        //public int ParentCode;        
        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName;
        /// <summary>
        /// کد شی
        /// </summary>
        public int ObjectCode;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Comment;
        /// <summary>
        /// کد پست ایجاد کننده
        /// </summary>
        public int CreatorPostCode;
        /// <summary>
        /// کد کاربر ایجاد کننده
        /// </summary>
        public int CreatorUserCode;
        /// <summary>
        /// حداکثر تعداد
        /// </summary>
        public decimal MaxCount;
        /// <summary>
        /// روش تقسیم
        /// </summary>
        public int DivideType;
        /// <summary>
        /// وضعیت
        /// </summary>
        public int Status;

        /// <summary>
        /// ارزش
        /// </summary>
        public decimal Value;
        /// <summary>
        /// فعال / غیرفعال
        /// </summary>
        //public bool Active;
        /// <summary>
        /// کد گروه جدول Asset
        /// </summary>
        public int GroupCode;
        /// <summary>
        /// حالت دارایی (قابل انتقال و ...)
        /// </summary>
        public int State;
        public JAssetTable()
            : base(JTableNamesFinance.Asset)
        {
        }
    }

    public enum finAsset
    {
        Code,
        /// <summary>
        ///کد دارائی قبلی 
        /// </summary>
        ParentCode,
        /// <summary>
        /// نام کلاس
        /// </summary>
        ClassName,
        /// <summary>
        /// کد شی
        /// </summary>
        ObjectCode,
        /// <summary>
        /// توضیحات
        /// </summary>
        Comment,
        /// <summary>
        /// کد پست ایجاد کننده
        /// </summary>
        CreatorPostCode,
        /// <summary>
        /// کد کاربر ایجاد کننده
        /// </summary>
        CreatorUserCode,
        /// <summary>
        /// ارزش
        /// </summary>
        Value,
        /// <summary>
        /// فعال / غیرفعال
        /// </summary>
        Status,
        /// <summary>
        /// نحوه تقسیم
        /// </summary>
        DivideType,
        GroupCode,
    }

    

}
