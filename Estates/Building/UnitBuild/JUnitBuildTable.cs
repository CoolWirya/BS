using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    class JUnitBuildTable:JTable
    {
        public JUnitBuildTable()
            : base(JTableNamesEstate.UnitBuild)
        {
        }
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
        public int PlaqueRegistration;
        /// <summary>
        /// کددارایی
        /// </summary>
        public int AssetCode;
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
    }
}
