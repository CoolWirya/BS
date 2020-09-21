using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.GasStation
{
    /// <summary>
    /// جایگاه عرضه سوخت
    /// </summary>
    public class JGasStation
    {
        public int Code { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// مکان محل عرضه
        /// </summary>
        public int PlaceOfSupply { get; set; }
        /// <summary>
        /// نوع محل عرضه
        /// </summary>
        public int TypeOfSupply { get; set; }
        public int Number { get; set; }
        public int OilRegionCode { get; set; }
        public int OilAreaCode { get; set; }
        /// <summary>
        /// مساحت
        /// </summary>
        public int Area { get; set; }
        /// <summary>
        /// مالک
        /// </summary>
        public int OwnerCode { get; set; }
        /// <summary>
        /// اپراتور جایگاه
        /// </summary>
        public int OperatorCode { get; set; }
        /// <summary>
        /// آدرس
        /// </summary>
        public string AddressCode { get; set; }
        /// <summary>
        /// طول
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// عرض
        /// </summary>
        public double Lon { get; set; }
        /// <summary>
        /// ارتفاع
        /// </summary>
        public double Alt { get; set; }
        /// <summary>
        /// کد انبار
        /// </summary>
        public int WarCode { get; set; }


        public int Insert()
        {
            ClassLibrary.JDataBase JDB = new ClassLibrary.JDataBase();
            JGasStationTable GH = new JGasStationTable();
            WarehouseManagement.Warehouse.JWarehouseTable WHT = new WarehouseManagement.Warehouse.JWarehouseTable();
            WarehouseManagement.Warehouse.JWarehouse WH = new WarehouseManagement.Warehouse.JWarehouse();

            if (JDB.beginTransaction("GasStation_Wearhouse"))
            {
                GH.SetValueProperty(this);

                GH.Code = GH.Insert(JDB);
                WH.Name = " انبار " + GH.Name;
                WH.OwnerCode = GH.OwnerCode;
                WHT.SetValueProperty(WH);
                GH.WarCode = WHT.Insert(JDB);
                GH.Update(JDB);
                if (JDB.Commit())
                    return GH.Code;
            }
            return 0;
        }

        public bool update()
        {
            JGasStationTable GH = new JGasStationTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool updateOwner(int _Code, int _OwnerCode)
        {
            JGasStation GS = new JGasStation();
            JGasStationTable GH = new JGasStationTable();
            GS.Code = _Code;
            GS.GetData(_Code);
            GS.OwnerCode = _OwnerCode;

            WarehouseManagement.Warehouse.JWarehouse War = new WarehouseManagement.Warehouse.JWarehouse();
            WarehouseManagement.Warehouse.JWarehouseTable WHT = new WarehouseManagement.Warehouse.JWarehouseTable();

            War.Name = " انبار " + GS.Name;
            War.OwnerCode = GS.OwnerCode;
            War.StockClerk = GS.OwnerCode;
            WHT.SetValueProperty(War);
            GS.WarCode = War.Insert();
            GH.SetValueProperty(GS);
            return GH.Update();
        }

        public bool Delete()
        {
            JGasStationTable GH = new JGasStationTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JGasStationTable GH = new JGasStationTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JGasStationTable GH = new JGasStationTable();
            return GH.GetData(this, pCode);
        }
        /// <summary>
        /// پرکردن مشخصات جایگاه با استفاده از 
        /// GSID
        /// </summary>
        /// <param name="GSID">مشخصه جایگاه</param>
        /// <returns></returns>
        public bool GetDataByGSID(int GSID)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                int pCode = 0;
                db.setQuery(
                    @"Select * from OilGasStation OGS where OGS.Number = " + GSID);
                DataTable dt = db.Query_DataTable();
                pCode = (int)dt.Rows[0]["Code"];
                JGasStationTable GH = new JGasStationTable();
                return GH.GetData(this, pCode);
            }
            finally
            {
                db.Dispose();
            }
        }

    }

    public class JGasStationes
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JGasStationTable GH = new JGasStationTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return @"SELECT ogs.Code, ogs.Name, ogs.Number GSID, oa.Name AreaName, oz.Name ZoneName, od.Name DistrictName
                          FROM OilGasStation ogs
                        INNER JOIN OilArea oa ON oa.Code = ogs.OilAreaCode
                        INNER JOIN OilZone oz ON oz.Code = oa.OilZoneCode
                        INNER JOIN OilDistrict od ON od.Code = oz.OilDistrictCode WHERE " + ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.GasStation.JGasStationes.GetGasStations", "ogs.Code");
        }

        public static DataTable GetTitles()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"SELECT Code, ogs.Name Title,ogs.Number FROM OilGasStation ogs WHERE " + ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.GasStation.JGasStationes.GetGasStations", "ogs.Code"));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static bool GetGasStations()
        {
            return ClassLibrary.JPermission.CheckPermission("OilProductsDistributionCompany.GasStationJGasStationes.GetGasStations", false);
        }

        public static string GSPropertiesReport(int AreaCode, int Supplier, int OilZoneCode
                          , int UsersCode, int PlaceOfSupply, int TypeOfSupply, int OwnerCode, int OperatorCode, int FuelTankCode, int NozzelCode, int TypeOfFuelTankCode, int TypeOfProductCode
                          , int Lat, int Lon, int Alt)
        //, DateTime? StartEventDate, DateTime? EndEventDate)
        {
            StringBuilder Fields = new StringBuilder();
            StringBuilder GroupBy = new StringBuilder();
            StringBuilder Where = new StringBuilder();
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);

            #region Where Generate
            ///___________________________________________-
            if (AreaCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" OA.Code = " + AreaCode);
            }
            ///___________________________________________-
            if (Supplier > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" OS.Code = " + Supplier);
            }
            ///___________________________________________-
            if (OilZoneCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" OZ.Code = " + OilZoneCode);
            }
            ///___________________________________________-
            //if (UsersCode > 0)
            //{
            //    if (Where.Length == 0)
            //        Where.Append(" WHERE ");
            //    else
            //        Where.Append(" AND ");
            //    Where.Append(" Usr.PCode = " + UsersCode);
            //}
            ///___________________________________________-
            if (PlaceOfSupply > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" SD1.Code = " + PlaceOfSupply);
            }
            ///___________________________________________-
            if (TypeOfSupply > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" SD2.Code = " + TypeOfSupply);
            }
            ///___________________________________________-
            if (OwnerCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" CAP2.Code = " + OwnerCode);
            }
            ///___________________________________________-
            if (OperatorCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" CAP3.Code = " + OperatorCode);
            }
            ///___________________________________________-
            if (FuelTankCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" OFT.Code = " + FuelTankCode);
            }
            ///___________________________________________-
            if (NozzelCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" OIN.Code = " + NozzelCode);
            }
            ///___________________________________________-
            if (TypeOfFuelTankCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" SD3.Code = " + TypeOfFuelTankCode);
            }
            ///___________________________________________-
            if (TypeOfProductCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" SD4.Code = " + TypeOfProductCode);
            }
            ///___________________________________________-
            if (Lat > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" OGS.Code = " + Lat);
            }
            ///___________________________________________-
            if (Lon > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" OGS.Code = " + Lon);
            }
            ///___________________________________________-
            if (Alt > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" OGS.Code = " + Alt);
            }

            ///___________________________________________-
            //if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime))
            //{
            //    DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
            //    DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
            //    if (Where.Length == 0)
            //        Where.Append(" WHERE ");
            //    else
            //        Where.Append(" AND ");
            //    Where.Append(" InsertDate between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'");
            //}
            ///___________________________________________-
            #endregion Where Generate

            return @"  
                        SELECT DISTINCT OGS.Code,OGS.Name,OGS.Number,OGS.Lat,OGS.Lon,OGS.Alt " + Fields.ToString() + @"
			                 ,(SELECT COUNT(*)			FROM OilFuelTank      OFT WHERE     OFT.GasStationCode=OGS.Code)                                                              AS FTCount
			                 ,(SELECT COUNT(*)			FROM OilNozzle        OIN LEFT JOIN OilFuelTank OFT ON(OFT.Code = OIN.FuelTankCode AND OFT.GasStationCode = OGS.Code))        AS ONCount
			                 ,(SELECT TOP 1 Address		FROM clsPersonAddress CPA WHERE     OGS.Code = CPA.ObjectCode AND CPA.ClassName Like N'%WebOilManagement.JWebOilManagement%') AS Address
			                 ,CAP.Name  AS SupplierName
			                 ,OZ.Name   AS ZoneName
			                 ,SD1.name  AS PlaceOfSupply
			                 ,SD2.name  AS TypeOfSupply
			                 ,CAP2.Name AS OwnerName
			                 ,CAP3.Name AS OperatorName
	                     From OilGasStation OGS
		                    LEFT JOIN clsPersonAddress	 CPA		ON(OGS.Code       = CPA.ObjectCode AND CPA.ClassName Like N'%WebOilManagement.JWebOilManagement%')
		                    LEFT JOIN OilFuelTank		 OFT		ON(OGS.Code       = OFT.GasStationCode)
		                    LEFT JOIN OilNozzle			 OIN		ON(OFT.Code       = OIN.FuelTankCode)
		                    LEFT JOIN OilPT				 OP			ON(OP.NozzleCode  = OIN.Code)
		                    LEFT JOIN OilArea			 OA			ON(OGS.OilAreaCode= OA.Code)
		                    LEFT JOIN OilZone			 OZ			ON(OA.OilZoneCode = OZ.Code)
                            LEFT JOIN OilSupplierDetails OSD		ON(OSD.ZoneCode   = OZ.Code)
                            LEFT JOIN OilSupplier	     OS			ON(OS.Code		  = OSD.SupplierCode)
                            LEFT JOIN clsAllPerson       CAP		ON(CAP.Code		  = OS.PCode)
	                        LEFT JOIN clsAllPerson       CAP2		ON(CAP2.Code 	  = OGS.OwnerCode)
		                    LEFT JOIN clsAllPerson       CAP3		ON(CAP3.Code 	  = OGS.OperatorCode)
	                    --	LEFT JOIN Define             DEF		ON(DEF.Code		  = 9010004)
		                    LEFT JOIN subdefine          SD1        ON(SD1.Code		  = OGS.PlaceOfSupply)
		                    LEFT JOIN subdefine          SD2        ON(SD2.Code		  = OGS.TypeOfSupply)
		                    LEFT JOIN subdefine          SD3        ON(SD3.Code		  = OFT.TypeOfFuelTankCode)
		                    LEFT JOIN subdefine          SD4        ON(SD4.Code		  = OFT.TypeOfProductCode)
                          " + Where.ToString();
        }

        /// <summary>
        /// گزارش خرابی ها و تعمیرات انجام شده
        /// </summary>
        /// <param name="AreaCode"></param>
        /// <param name="OilZoneCode"></param>
        /// <param name="StationName"></param>
        /// <param name="StationID"></param>
        /// <param name="Code"></param>
        /// <param name="UseType"></param>
        /// <param name="FailurDate"></param>
        /// <param name="FixingBrokenDate"></param>
        /// <returns></returns>
        public static string GSFunctionReport(int AreaCode = 0, int OilZoneCode = 0, int StationID = 0, int UseType = 0
                    , DateTime? AsDate = null, DateTime? ToDate = null)
        {
            string Query = string.Empty;
            StringBuilder where = new StringBuilder();
            DateTime StartDTime = new DateTime(AsDate.Value.Year, AsDate.Value.Month, AsDate.Value.Day, 0, 0, 0);
            DateTime EndDTime = new DateTime(ToDate.Value.Year, ToDate.Value.Month, ToDate.Value.Day, 23, 59, 59);

            #region Initial Where Query

            ///___________________________________________-

            if (AreaCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");

                where.Append(" a.Code = " + AreaCode.ToString());
            }

            ///___________________________________________-
            if (OilZoneCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" z.Code = " + OilZoneCode.ToString());
            }
            ///___________________________________________-

            if (StationID > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append("gs.Code=" + StationID.ToString());
            }

            if (AsDate.HasValue && ToDate.HasValue)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" mf.InsertDate between  ");
                where.Append("'" + StartDTime.ToString() + "'");
                where.Append(" AND ");
                where.Append("'" + EndDTime.ToString() + "'");
            }

            if (UseType > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" hr.Serviced =" + UseType.ToString());
            }
            #endregion Initial Where Query


            #region Query
            //EliminateDowntimeDue      UseType
            Query = @"select distinct gs.Code, z.Name as 'منطقه',a.Name as 'ناحیه',gs.Number as 'شناسه جایگاه',gs.Name as 'نام جایگاه', 
                    mf.DamageCode as 'کد خرابی',mf.Code as 'کد رهگیری',mf.RealMalfunctionDate as 'زمان وقوع خرابی',
                    ar.GasStationManagerConfirmation as 'زمان رفع خرابی',
                     (select DATEDIFF (MINUTE,mf.RealMalfunctionDate,ar.GasStationManagerConfirmation)) as 'مدت رفع خرابی', 
                    (SELECT name FROM subdefine  WHERE bcode=mf.TypeOfMalfunction ) as 'نحوه اعلام خرابی',
                     ( select 
                     CASE 
                     WHEN ar.FixDefects=0 THEN (select 
                      CASE 
                       WHEN ar.DontFixDefects=0 THEN N'عدم انتخاب'
                          WHEN ar.DontFixDefects=1 THEN N'نیاز به قطعه' 
                          WHEN ar.DontFixDefects=2 THEN N'نیاز به بررسی بیشتر' 
	                      WHEN ar.DontFixDefects=3 THEN N'عدم ارتباط با مرکز'  
	                      WHEN ar.DontFixDefects=4 THEN N'عدم حضور مسئول جایگاه' 
	                      WHEN ar.DontFixDefects=5 THEN N'ایراد مکانیکی' 
	                      WHEN ar.DontFixDefects=6 THEN N'ایراد نرم افزاری'
	                      ELSE N'سایر موارد'
                       END ) END ) as 'DontFixDefects',
                       (select 
                       CASE
                       WHEN hr.Serviced=0 THEN N'هیچ کدام'
                       WHEN hr.Serviced=1 THEN N'سرویس'
                       WHEN hr.Serviced=2 THEN N'تعویض' 
                       WHEN hr.Serviced=3 THEN N'عدم وجود قطعه' 
                       END) as 'Serviced',
                       (select wg.Description from WarGoods wg where wg.Code=hr.WarGoodCrashCode) as 'قطعه معيوب',
                    hr.RealDamageCode AS 'کد واقعي خرابي',
                    (select wg.Serial from WarGoods wg where wg.Code=hr.WarGoodCrashCode) as 'شماره سريال قطعه معيوب',
                    (select wg.Serial from WarGoods wg where wg.Code=hr.WarGoodReplaceCode) as  'شماره سريال قطعه تعويضي' 
                    from  OilZone z inner join OilArea a  on  a.OilZoneCode=z.Code 
                    inner join OilGasStation gs   ON gs.OilAreaCode=a.Code 
                    INNER JOIN OilMalfunction mf ON mf.GasStationCode=gs.Code  
                    inner join OilTableDamages td ON mf.DamageCode=td.Code
                    inner join OilAfterReviewing ar on  ar.MalfunctionCode=mf.Code 
                    left JOIN  OilHardwareRepair hr ON hr.MalfunctionCode=mf.Code 
                    LEFT JOIN OilSoftwareRepair sr ON  sr.MalfunctionCode=mf.Code ";

            Query += where.ToString();
            #endregion Query

            return Query;
        }

        /// <summary>
        /// گزارش رویت وضعیت نصب تجهیزات در مجاری عرضه
        /// </summary>
        /// <param name="AreaCode"></param>
        /// <param name="OilZoneCode"></param>
        /// <param name="Supplier"></param>
        /// <param name="TypeOfGoodcode"></param>
        /// <param name="AsDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public static string GSInstallStateSupplyDuctsReport(int AreaCode = 0, int OilZoneCode = 0, int Supplier = 0
                                , DateTime? AsDate = null, DateTime? ToDate = null)
        {
            string Query = string.Empty;
            StringBuilder where = new StringBuilder();
            DateTime StartDTime = new DateTime(AsDate.Value.Year, AsDate.Value.Month, AsDate.Value.Day, 0, 0, 0);
            DateTime EndDTime = new DateTime(ToDate.Value.Year, ToDate.Value.Month, ToDate.Value.Day, 23, 59, 59);

            #region Initial Where Query

            ///___________________________________________-

            if (AreaCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");

                where.Append(" OA.Code = " + AreaCode.ToString());
            }
            ///___________________________________________-
            if (Supplier > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" OS.Code = " + Supplier.ToString());
            }
            ///___________________________________________-
            if (OilZoneCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" oz.Code = " + OilZoneCode.ToString());
            }
            ///___________________________________________-

            if (AsDate.HasValue && ToDate.HasValue)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" omf.InsertDate between  ");
                where.Append("'" + StartDTime.ToString() + "'");
                where.Append(" AND ");
                where.Append("'" + EndDTime.ToString() + "'");
            }
            where.Append(" AND oar.FixDefects = 1 ");
            #endregion Initial Where Query


            #region Query

            Query = @"select distinct
                    oz.code, 
	                oz.Name zone,
	                p.Name,
                    omf.InsertDate, 
	                (select name from subdefine sd where sd.bcode = 9010004 and code=ogs.PlaceOfSupply) placeofsupply,
	                (select name from subdefine sd where sd.bcode = 9010001 and code=ogs.TypeOfSupply) typeofsuply,
	                ogs.Name gasstation,
	                ogs.Number gsid,
	                (select wtg.Name + ' - ' + wg.Description from WarGoods wg inner join WarTypesOfGoods wtg on wtg.Code = wg.TypeOfGoodsCode and wg.Code = ohr.WarGoodCrashCode) part,
	                (select serial from WarGoods where Code = ohr.WarGoodCrashCode) crashedSerial,
	                (select serial from WarGoods where Code = ohr.WarGoodReplaceCode) replacedSerial,
	                oar.GasStationManagerConfirmation,
	                omf.Code peygiri
                from 
	                oilzone oz
	                inner join OilArea oa on oa.OilZoneCode = oz.Code
	                inner join OilGasStation ogs on ogs.OilAreaCode = oa.Code
	                inner join OilSupplierDetails osd on osd.ZoneCode = oz.Code
	                inner join OilSupplier os on os.Code = osd.SupplierCode
	                inner join clsAllPerson p on p.Code = os.PCode
	                inner join OilMalfunction omf on omf.GasStationCode = ogs.Code 		--and omf.SupplierCode = os.Code
	                inner join OilHardwareRepair ohr on ohr.MalfunctionCode = omf.Code
	                inner join OilAfterReviewing oar on oar.MalfunctionCode = omf.Code ";

            Query += where;

            #endregion Query

            return Query;
        }


    }

    public class JGasStationTable : ClassLibrary.JTable
    {
        public string Name;
        /// <summary>
        /// مکان محل عرضه
        /// </summary>
        public int PlaceOfSupply;
        /// <summary>
        /// نوع محل عرضه
        /// </summary>
        public int TypeOfSupply;
        public int Number;
        public int OilRegionCode;
        public int OilAreaCode;
        /// <summary>
        /// مساحت
        /// </summary>
        public int Area;
        /// <summary>
        /// مالک
        /// </summary>
        public int OwnerCode;
        /// <summary>
        /// اپراتور جایگاه
        /// </summary>
        public int OperatorCode;
        /// <summary>
        /// آدرس
        /// </summary>
        public string AddressCode;
        /// <summary>
        /// عرض
        /// </summary>
        public double Lat;
        /// <summary>
        /// طول
        /// </summary>
        public double Lon;
        /// <summary>
        /// ارتفاع
        /// </summary>
        public double Alt;
        /// <summary>
        /// کد انبار
        /// </summary>
        public int WarCode;

        public JGasStationTable()
            : base("OilGasStation")
        {
        }
    }
}
