using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstate
{
    public class JRETableNames
    {
        /// <summary>
        /// جدول افزایش اجاره سرقفلی
        /// </summary>
        public static string MarketGoodwill = "estMarketGoodwill";
        /// <summary>
        /// جدول مالکین پیشفرض
        /// </summary>
        public static string DefaultOwners = "estDefaultOwners";
        /// <summary>
        /// جدول ملزومات واحد تجاری
        /// </summary>
        public static string InformationUnitBuild = "estUnitBuildTels";
        /// <summary>
        /// اطلاعات شارژ غرفه ها
        /// </summary>
        public static string ChargeBuild = "ReChargeBuild";
        /// <summary>
        /// قبضهای چاپ شده
        /// </summary>
        public static string PrintedCharge = "RePrintedCharge";
        /// <summary>
        ///محيط هاي مشاء
        /// </summary>
        public static string EnviromentTable = "ReEnviromentTable";
        /// <summary>
        ///مالك اوليه محيط هاي مشا
        /// </summary>
        public static string EnviromentOwner = "ReEnviromentOwner";
        /// <summary>
        ///تجمیع اعیان جدید
        /// </summary>
        public static string RestAggregateUnitBuild = "REstAggregateUnitBuild";
        /// <summary>
        ///تجمیع اعیان قدیم
        /// </summary>
        public static string RestAggregateUnitBuilds = "REstAggregateUnitBuilds";
        /// <summary>
        ///تفکیک اعیان جدید
        /// </summary>
        public static string RestBreakDownUnitBuild = "REstBreakDownUnitBuild";
        /// <summary>
        ///تفکیک اعیان قدیم
        /// </summary>
        public static string RestBreakDownUnitBuilds = "REstBreakDownUnitBuilds";
        /// <summary>
        ///انتقال اعیان 
        /// </summary>
        public static string RestTransferUnitBuild = "REstTransferUnitBuild";
        /// <summary>
        ///اشخاص انتقال اعیان 
        /// </summary>
        public static string RestTransferPersons = "REstTransferPersons";
        /// <summary>
        ///كارت الكترونيك 
        /// </summary>
        public static string ElectronicCard = "ReElectronicCard";
    }
}
