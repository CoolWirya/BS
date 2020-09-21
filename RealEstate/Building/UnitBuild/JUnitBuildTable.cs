using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    class JUnitBuildTable : JTable
    {
        public JUnitBuildTable()
            : base(JTableNamesEstate.UnitBuild)
        {
        }
        /// <summary>
        /// کد پدر
        /// </summary>
        public int ParentCode;
        /// <summary>
        /// کد نوع واحد
        /// </summary>
        public int TypeCode;
        /// <summary>
        /// کد ساختمانی که واحد در آن مستقر شده است
        /// </summary>
        public int MarketCode;

        /// <summary>
        /// پلاک واحد
        /// </summary>
        public string Plaque;

        /// <summary>
        /// طبقه ای که واحد در آن مستقر است
        /// </summary>
        public int FloorCode;

        /// <summary>
        /// شماره واحد 
        /// </summary>
        public string Number;

        /// <summary>
        /// مساحت واحد مربوطه
        /// </summary>
        public double Area;
        /// <summary>
        /// قیمت اولیه
        /// </summary>
        public double Price;

        /// <summary>
        /// کاربری
        /// </summary>
        public int UsageCode;
        /// <summary>
        /// شغل
        /// </summary>
        public int UnitJob;

        /// <summary>
        /// پلاک ثبتی
        /// </summary>
        public string PlaqueRegistration;
        /// <summary>
        /// اجاره اولیه
        /// </summary>
        public decimal InitialRental;
        /// <summary>
        /// مساحت اولیه
        /// </summary>
        public double InitialArea;
        /// <summary>
        /// تاریخ تحویل
        /// </summary>
        public DateTime DeliveryDate;
        /// <summary>
        /// کد زمین
        /// </summary>
        public int GroundCode;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string UDesc;
        /// <summary>
        /// بالکن
        /// </summary>
        public decimal Balcon;
        /// <summary>
        /// فازی ای که واحد در آن مستقر است
        /// </summary>
        public int Faz;
        /// <summary>
        /// کد تفضیلی س÷اد
        /// </summary>
        public int Tafsili1;
        /// <summary>
        /// کد تفضیلی بازارها
        /// </summary>
        public int Tafsili2;
        /// <summary>
        /// کد وضعیت
        /// </summary>
        public UnitBuildStatus Status;
    }

    enum JUnitBuildTableEnum
    {
        TypeCode,
        MarketCode,
        Plaque,
        FloorCode,
        Number,
        Area,
        UsageCode,
        PlaqueRegistration,
        Market,
        InitialRental,
        InitialArea,
        DeliveryDate,
        GroundCode,
        Balcon,
        Faz
    }
}
