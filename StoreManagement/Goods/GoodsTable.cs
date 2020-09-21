using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreManagement
{
    public class JGoodsTable : JTable
    {
        public JGoodsTable()
            : base("StoreGoods")
        {
        }

        /// <summary>
        /// نام کالا  
        /// </summary>
        public string Name;
        /// <summary>
        /// نام لاتین 
        /// </summary>
        public string Latin_Name;
        /// <summary>
        /// کد گروه 
        /// </summary>
        public int GroupCode;
        /// <summary>
        /// نوع کالا 
        /// </summary>
        public int GoodsType;
        /// <summary>
        /// نقطه سفارش 
        /// </summary>
        public int OrderQuantity;
        /// <summary>
        /// حداقل 
        /// </summary>
        public int MinQuantity;
        /// <summary>
        /// حداکثر 
        /// </summary>
        public int MaxQuantity;
        /// <summary>
        /// وضعیت
        /// </summary>
        public int Status;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// تاریخ ایجاد
        /// </summary>
        public DateTime Create_Date_Time;
        /// <summary>
        /// قیمت
        /// </summary>
        public decimal Price;
        /// <summary>
        /// ایران کد
        /// </summary>
        public int IranCode;
        /// <summary>
        /// واحد اندازه گیری
        /// </summary>
        public int Measure;
    }
}
