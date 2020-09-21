using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{
    public class JAssetShareTable : ClassLibrary.JTable
    {
        /// <summary>
        ///کد مالک قبلی 
        /// </summary>
        public int ParentCode;
        /// <summary>
        /// کد دارائی
        /// </summary>
        public int ACode;
        /// <summary>
        /// کد انتقال
        /// </summary>
        public int TCode;
        /// <summary>
        /// کد مالک
        /// </summary>
        public int PersonCode;
        /// <summary>
        ///درصد مالکیت
        /// </summary>
        public float Share;
        /// <summary>
        /// توضیحات
        /// </summary>
        //public string Comment;
        /// <summary>
        /// نوع مالکیت
        /// </summary>
        //public JOwnershipType OwnershipType;
        /// <summary>
        /// نام کلاس
        /// </summary>
        //public string ClassName;
        /// <summary>
        /// کد شی
        /// </summary>
        //public int ObjectCode;
        /// <summary>
        /// وضعیت
        /// </summary>
        public int Status;

        public JAssetShareTable()
            : base("finAssetShare")
        {
        }
    }

    public enum finAssetShare
    {
        Code,
        /// <summary>
        ///کد مالک قبلی 
        /// </summary>
        ParentCode,
        /// <summary>
        /// کد دارائی
        /// </summary>
        ACode,
        TCode,
        /// <summary>
        /// کد مالک
        /// </summary>
        PersonCode,
        /// <summary>
        ///درصد مالکیت
        /// </summary>
        Share,
        /// <summary>
        /// توضیحات
        /// </summary>
        Comment,
        /// <summary>
        /// وضعیت
        /// </summary>
        Status,
        /// <summary>
        /// نوع مالکیت
        /// </summary>
        OwnershipType,
        /// <summary>
        /// 
        /// </summary>
        ClassName,
        /// <summary>
        /// کد شیئی که دارایی جزء از آن ساخته میشود
        /// </summary>
        ObjectCode
    }
}
