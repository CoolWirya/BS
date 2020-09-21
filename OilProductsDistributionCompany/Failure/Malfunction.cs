using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.Failure
{
    public enum JStatusMalfunction
    {
        Open = 1,
        Close = 2,
    }
    /// <summary>
    /// اعلام خرابی
    /// </summary>
    public class JMalfunction
    {
        /// <summary>
        /// کد رهگیری
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int GasStationCode { get; set; }
        /// <summary>
        /// کد نازل
        /// </summary>
        public int NozzleCode { get; set; }
        /// <summary>
        /// کد اعلام کننده خرابی از پرسنل جایگاه باید باشد یا پیمانکار
        /// </summary>
        public int HangerCode { get; set; }
        /// <summary>
        /// نام اعلام کننده خرابی از پرسنل جایگاه باید باشد یا پیمانکار
        /// </summary>
        public string HangerName { get; set; }
        /// <summary>
        /// تاریخ و ساعت اعلام
        /// </summary>
        public DateTime DateTimeMalfunction { get; set; }
        /// <summary>
        /// کد خرابی
        /// </summary>
        public int DamageCode { get; set; }
        public int RegistrarCode { get; set; }
        //public string RegistrarName { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        public JStatusMalfunction Status { get; set; }
        /// <summary>
        /// نوع اعلام خرابی
        /// </summary>
        public int TypeOfMalfunction { get; set; }
        /// <summary>
        /// زمان واقعی خرابی
        /// </summary>
        public DateTime RealMalfunctionDate { get; set; }

        /// <summary>
        /// توضیحات خرابی واقعی
        /// </summary>
        public string RealMalfunctionDescription { get; set; }

        /// <summary>
        ///خرابی دفتر
        /// </summary>
        public bool IsOfficeDamage { get; set; }

        /// <summary>
        /// تاریخ بستن پیش از رفع خرابی
        /// </summary>
        public DateTime NotSolvedDate { get; set; }

        ///// <summary>
        /////  ساعت بستن پیش از رفع خرابی
        ///// </summary>
        //public DateTime NotSolvedTime { get; set; }

        /// <summary>
        /// شرح بستن پیش از رفع خرابی
        /// </summary>
        public string NotSolvedDescription { get; set; }

        /// <summary>
        /// کد پیمانکار
        /// </summary>
        public int SupplierCode { get; set; }

        public int Insert()
        {
            JMalfunctionTable GH = new JMalfunctionTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool update()
        {
            JMalfunctionTable GH = new JMalfunctionTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JMalfunctionTable GH = new JMalfunctionTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JMalfunctionTable GH = new JMalfunctionTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JMalfunctionTable GH = new JMalfunctionTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JMalfunctiones
    {
        ///گزارش های مدیریتی از پورتال
        public enum PerformanceMalfunctionReport
        {

            AllTicket = 1,///کل تیکت های ثبت شده 
            ZoneTicket = 2,///تعداد تیکت های ثبت شده به ازا مناطق نفتی
            TypeTicket = 3,///تعداد تیکت های ثیت شده به ازا نوع خرابی
            SupplierTicket = 4,///تعداد تیکت های ثبتی به ازا پیمانکاران
            StatusTicket = 5,///تعدادتیکت ها با وضعیت های مختلف
            UsersTicket = 6,///تعداد تیکت ها ی ثبتی توسط هر یک ازکاربران مرکز تماس
            ///وضعیت SLA پیمانکاران 
        }

        public enum DamageReservedCode
        {

            Installing_RPM = -1,///کل تیکت های ثبت شده 
            //ZoneTicket = -2,///تعداد تیکت های ثبت شده به ازا مناطق نفتی
            //TypeTicket = -3,///تعداد تیکت های ثیت شده به ازا نوع خرابی
            //SupplierTicket = -4,///تعداد تیکت های ثبتی به ازا پیمانکاران
            //StatusTicket = -5,///تعدادتیکت ها با وضعیت های مختلف
            //UsersTicket = -6,///تعداد تیکت ها ی ثبتی توسط هر یک ازکاربران مرکز تماس
            ///وضعیت SLA پیمانکاران 
        }

        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JMalfunctionTable GH = new JMalfunctionTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return @"SELECT om.Code,case om.Status when 1 then N'باز' when 2 then N'بسته' when 3 then N'نیاز به قطعه' when 4 then N'عدم حضور مسئول جایگاه' when 5 then N'ایراد مکانیکی' when 6 then N'ایراد نرم افزاری' end as status
                                     ,ogs.Number GSID, ogs.name GasStation,  om.NozzleCode as NozzelNumber , om.HangerName, om.DateTimeMalfunction 
                                     ,sTypeOfMalfunction.name TypeOfMalfunction,otd.Name as DamageName,clsPerson.Name +' '+clsPerson.Fam as registerarFullName,InsertDate,CAP.Name AS SupplierName
                                    FROM OilMalfunction         om
                                      LEFT JOIN OilGasStation   ogs             ON (ogs.Code     = om.GasStationCode)
                                      LEFT JOIN OilArea         OA              ON (OA.Code      = OGS.OilAreaCode) 
                                      LEFT JOIN OilNozzle       on1             ON (on1.Code     = om.NozzleCode)
                                      LEFT JOIN OilTableDamages otd             ON (otd.Code     = om.DamageCode)
                                      LEFT JOIN users                           ON (users.code   = om.RegistrarCode)
									  LEFT JOIN clsPerson                       ON (users.pcode  = clsPerson.Code)
                                      LEFT JOIN OilSupplier      OS             ON (OS.Code		 = om.SupplierCode)
									  LEFT JOIN clsAllPerson     CAP			ON (CAP.Code	 = OS.PCode)
                                      LEFT JOIN subdefine sTypeOfMalfunction    ON sTypeOfMalfunction.Code = om.TypeOfMalfunction WHERE" + ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.Zone.JOliZonees.GetWebQuery", "OA.OilZoneCode"); ;
        }

        public static string GetWebQuery(int Code)
        {
            return @"SELECT om.Code,case om.Status when 1 then N'باز' when 2 then N'بسته' when 3 then N'نیاز به قطعه' when 4 then N'عدم حضور مسئول جایگاه' when 5 then N'ایراد مکانیکی' when 6 then N'ایراد نرم افزاری' end as status
                                     ,ogs.Number GSID, ogs.name GasStation,  om.NozzleCode as NozzelNumber , om.HangerName, om.DateTimeMalfunction 
                                     ,sTypeOfMalfunction.name TypeOfMalfunction,otd.Name as DamageName,clsPerson.Name +' '+clsPerson.Fam as registerarFullName,InsertDate,CAP.Name AS SupplierName
                                    FROM OilMalfunction         om
                                      LEFT JOIN OilGasStation   ogs             ON (ogs.Code     = om.GasStationCode)
                                      LEFT JOIN OilArea         OA              ON (OA.Code      = OGS.OilAreaCode) 
                                      LEFT JOIN OilNozzle       on1             ON (on1.Code     = om.NozzleCode)
                                      LEFT JOIN OilTableDamages otd             ON (otd.Code     = om.DamageCode)
                                      LEFT JOIN users                           ON (users.code   = om.RegistrarCode)
									  LEFT JOIN clsPerson                       ON (users.pcode  = clsPerson.Code)
                                      LEFT JOIN OilSupplier      OS             ON (OS.Code		 = om.SupplierCode)
									  LEFT JOIN clsAllPerson     CAP			ON (CAP.Code	 = OS.PCode)
                                      LEFT JOIN subdefine sTypeOfMalfunction    ON sTypeOfMalfunction.Code = om.TypeOfMalfunction WHERE" + ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.Zone.JOliZonees.GetWebQuery", "OA.OilZoneCode"); ;
        }

        public static string PerformanceZoneReport(int AreaCode, int Supplier, int OilZoneCode
                            , int UsersCode, int DamageCode, int DontFixDefectsCode, DateTime? StartEventDate, DateTime? EndEventDate, PerformanceMalfunctionReport PerReport)
        {
            StringBuilder Fields = new StringBuilder();
            StringBuilder GroupBy = new StringBuilder();
            StringBuilder Where = new StringBuilder();
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            switch (PerReport)
            {
                case PerformanceMalfunctionReport.AllTicket:
                    Fields.Append("");
                    GroupBy.Append("");
                    break;
                case PerformanceMalfunctionReport.StatusTicket:
                    break;
                case PerformanceMalfunctionReport.SupplierTicket:
                    Fields.Append(",CAPOS.Name AS JWebContractor");
                    GroupBy.Append(",CAPOS.Name");
                    break;
                case PerformanceMalfunctionReport.TypeTicket:
                    Fields.Append(",OTD.Name AS DamageName");
                    GroupBy.Append(",OTD.Name");
                    break;
                case PerformanceMalfunctionReport.UsersTicket:
                    Fields.Append(",CAP.Name AS Name");
                    GroupBy.Append(",CAP.Name");
                    break;
                case PerformanceMalfunctionReport.ZoneTicket:
                    Fields.Append(", OZ.Name AS ZONENAME");
                    GroupBy.Append(", OZ.Name");
                    break;
            }
            //if(AreaCode != 0 &&
            //     Supplier != 0 &&
            //     OilZoneCode != 0 &&
            //     UsersCode!= 0 && 
            //     DamageCode!= 0 &&
            //     DontFixDefectsCode != 0 && 
            //     StartEventDate!= string.Empty &&
            //     EndEventDate!= 0 &&
            //    )

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
            if (UsersCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" Usr.PCode = " + UsersCode);
            }
            ///___________________________________________-
            if (DamageCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" OTD.Code = " + DamageCode);
            }
            ///___________________________________________-
            if (DontFixDefectsCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" OAR.DontFixDefects = " + DontFixDefectsCode);
            }
            ///___________________________________________-
            if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime))
            {
                DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day,0,0,0);
                DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day,23,59,59);
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" InsertDate between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'");
            }
            if (Where.Length == 0)
                Where.Append(" WHERE ");
            else
                Where.Append(" AND ");
            Where.Append(ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.Zone.JOliZonees.GetWebQuery", "OA.OilZoneCode"));
          
            ///___________________________________________-
            #endregion Where Generate

            return @"  SELECT  row_number() OVER(ORDER BY OAR.DontFixDefects) AS Code ,count(*)  AS TicketCount
                        " + Fields.ToString() + @"
                        ,CASE OAR.DontFixDefects 
			                WHEN 1   THEN N'نیاز به قطعه'
			                WHEN 2   THEN N'نیاز به بررسی بیشتر'
			                WHEN 3   THEN N'عدم ارتباط با مرکز'
			                WHEN 4   THEN N'عدم حضور مسئول جایگاه'
			                WHEN 5   THEN N'ایراد مکانیکی'
			                WHEN 6   THEN N'ایراد نرم افزاری'
			                WHEN 7   THEN N'سایر موارد' END  AS DontFixDefectsName
	                   ,CASE OAR.FixDefects 
			                WHEN  0 THEN N'برطرف نشده' 
			                WHEN  1 THEN N'بسته' 
			                WHEN  2 THEN N'گزارش اشتباه' ELSE N'باز' END AS FixDefectsName  
                       FROM OilMalfunction OM
	                        LEFT JOIN OilGasStation OGS on(OGS.Code = OM.GasStationCode)
	                        LEFT JOIN OilArea OA on(OGS.OilAreaCode = OA.Code)
	                        LEFT JOIN OilZone OZ on(OA.OilZoneCode = OZ.Code)
	                        LEFT JOIN OilSupplierDetails OSD on(OSD.ZoneCode = OZ.Code)
	                        LEFT JOIN OilSupplier OS on(OS.Code = OSD.SupplierCode)
	                        LEFT JOIN clsAllPerson CAPOS ON(OS.PCode =CAPOS.Code) 
	                        LEFT JOIN OilTableDamages OTD ON(OTD.Code = OM.DamageCode)
	                        LEFT JOIN  users Usr ON(Usr.Code=OM.RegistrarCode)
	                        LEFT JOIN  clsAllPerson CAP ON(CAP.Code=Usr.pcode)
	                        LEFT JOIN  OilAfterReviewing OAR ON(OAR.MalfunctionCode = OM.Code)
                      " + Where.ToString() + @"
	            GROUP BY OAR.DontFixDefects,OAR.FixDefects" + GroupBy.ToString();
        }
        //        public static string PerformanceCountReport(int AreaCode, int Supplier, int OilZoneCode
        //                                                  , int UsersCode, int DamageCode, int DontFixDefectsCode, DateTime? StartEventDate, DateTime? EndEventDate
        //                                                  , PerformanceMalfunctionReport PerReport)
        //        {

        //            return @"--,(select count(*) from OilTableDamages WHERE  OilTableDamages.Code=OTD.Code) as DamageMalCount
        //	                       --  ,(select count(*) from OilSupplier WHERE OilSupplier.Code=OS.Code ) as SupplierMalCount
        //	                       --   ,(select  count(*) from OilMalFunction
        //                           --   LEFT JOIN OilGasStation  on(OilGasStation.Code = OilMalFunction.GasStationCode)
        //	                       --LEFT JOIN OilArea  on(OilGasStation.OilAreaCode = OilArea.Code)
        //	                       --LEFT JOIN OilZone  on(OilArea.OilZoneCode = OilZone.Code) WHERE OilZone.code = OZ.code)
        //	                       --,(select  count(*) from OilMalFunction
        //                           --   LEFT JOIN OilGasStation  on(OilGasStation.Code = OilMalFunction.GasStationCode)
        //	                       --LEFT JOIN OilArea  on(OilGasStation.OilAreaCode = OilArea.Code)
        //	                       --LEFT JOIN OilZone  on(OilArea.OilZoneCode = OilZone.Code) WHERE OilArea.code = OA.code)
        //		                    ----,(select count(*) from OilArea WHERE OilArea.Code =  OA.Code) as AreaMalCount
        //		                    -- ,(select count(*) from clsAllPerson  WHERE clsAllPerson.Code =  CAP.Code) as UserMalCount";
        //        }

        public static string PerformanceZoneCodeList(int AreaCode, int Supplier, int OilZoneCode
                           , int UsersCode, int DamageCode, int DontFixDefectsCode, DateTime? StartEventDate, DateTime? EndEventDate, PerformanceMalfunctionReport PerReport)
        {
            StringBuilder Fields = new StringBuilder();
            StringBuilder GroupBy = new StringBuilder();
            StringBuilder Where = new StringBuilder();
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            switch (PerReport)
            {
                case PerformanceMalfunctionReport.AllTicket:
                    Fields.Append("");
                    GroupBy.Append("");
                    break;
                case PerformanceMalfunctionReport.StatusTicket:
                    break;
                case PerformanceMalfunctionReport.SupplierTicket:
                    Fields.Append(",CAPOS.Name AS JWebContractor");
                    GroupBy.Append(",CAPOS.Name");
                    break;
                case PerformanceMalfunctionReport.TypeTicket:
                    Fields.Append(",OTD.Name AS DamageName");
                    GroupBy.Append(",OTD.Name");
                    break;
                case PerformanceMalfunctionReport.UsersTicket:
                    Fields.Append(",CAP.Name AS Name");
                    GroupBy.Append(",CAP.Name");
                    break;
                case PerformanceMalfunctionReport.ZoneTicket:
                    Fields.Append(", OZ.Name AS ZONENAME");
                    GroupBy.Append(", OZ.Name");
                    break;
            }


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
            if (UsersCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" Usr.PCode = " + UsersCode);
            }
            ///___________________________________________-
            if (DamageCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" OTD.Code = " + DamageCode);
            }
            ///___________________________________________-
            if (DontFixDefectsCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" OAR.DontFixDefects = " + DontFixDefectsCode);
            }
            ///___________________________________________-
            if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime))
            {
                DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, 0, 0, 0);
                DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day, 23, 59, 59);
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append(" InsertDate between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'");
            }
            if (Where.Length == 0)
                Where.Append(" WHERE ");
            else
                Where.Append(" AND ");
            Where.Append(ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.Zone.JOliZonees.GetWebQuery", "OA.OilZoneCode"));

            ///___________________________________________-
            #endregion Where Generate

            string Query = @"  DECLARE @MalCode VARCHAR(8000) 
                                SELECT @MalCode = COALESCE(@MalCode + ', ', '') + Cast(OilMalfunction.Code AS VARCHAR) 
                                FROM OilMalfunction OM
	                                    LEFT JOIN OilGasStation OGS on(OGS.Code = OM.GasStationCode)
	                                    LEFT JOIN OilArea OA on(OGS.OilAreaCode = OA.Code)
	                                    LEFT JOIN OilZone OZ on(OA.OilZoneCode = OZ.Code)
	                                    LEFT JOIN OilSupplierDetails OSD on(OSD.ZoneCode = OZ.Code)
	                                    LEFT JOIN OilSupplier OS on(OS.Code = OSD.SupplierCode)
	                                    LEFT JOIN clsAllPerson CAPOS ON(OS.PCode =CAPOS.Code) 
	                                    LEFT JOIN OilTableDamages OTD ON(OTD.Code = OM.DamageCode)
	                                    LEFT JOIN  users Usr ON(Usr.Code=OM.RegistrarCode)
	                                    LEFT JOIN  clsAllPerson CAP ON(CAP.Code=Usr.pcode)
	                                    LEFT JOIN  OilAfterReviewing OAR ON(OAR.MalfunctionCode = OM.Code)
                                  " + Where.ToString() + @"
	                        GROUP BY OAR.DontFixDefects,OAR.FixDefects" + GroupBy.ToString();

            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(Query);
                if (db.Query_DataReader() && db.DataReader.Read())
                    db.DataReader.Close();
                return db.DataSet.Tables[0].Rows[0].ToString();
            }
            finally
            {
                db.Dispose();
            }
        }
        
        #region Comments Code
        //        public static string PerformanceCountReport(int AreaCode, int Supplier, int OilZoneCode
        //                                                  , int UsersCode, int DamageCode, int DontFixDefectsCode, DateTime? StartEventDate, DateTime? EndEventDate
        //                                                  , PerformanceMalfunctionReport PerReport)
        //        {

        //            return @"--,(select count(*) from OilTableDamages WHERE  OilTableDamages.Code=OTD.Code) as DamageMalCount
        //	                       --  ,(select count(*) from OilSupplier WHERE OilSupplier.Code=OS.Code ) as SupplierMalCount
        //	                       --   ,(select  count(*) from OilMalFunction
        //                           --   LEFT JOIN OilGasStation  on(OilGasStation.Code = OilMalFunction.GasStationCode)
        //	                       --LEFT JOIN OilArea  on(OilGasStation.OilAreaCode = OilArea.Code)
        //	                       --LEFT JOIN OilZone  on(OilArea.OilZoneCode = OilZone.Code) WHERE OilZone.code = OZ.code)
        //	                       --,(select  count(*) from OilMalFunction
        //                           --   LEFT JOIN OilGasStation  on(OilGasStation.Code = OilMalFunction.GasStationCode)
        //	                       --LEFT JOIN OilArea  on(OilGasStation.OilAreaCode = OilArea.Code)
        //	                       --LEFT JOIN OilZone  on(OilArea.OilZoneCode = OilZone.Code) WHERE OilArea.code = OA.code)
        //		                    ----,(select count(*) from OilArea WHERE OilArea.Code =  OA.Code) as AreaMalCount
        //		                    -- ,(select count(*) from clsAllPerson  WHERE clsAllPerson.Code =  CAP.Code) as UserMalCount";
        //        }
        #endregion Comments Code

        public static string PerformanceCallCenterReport(int UserCode, DateTime? StartEventDate, DateTime? EndEventDate)
        {
            StringBuilder Where = new StringBuilder();
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            string ReferWhere = string.Empty;
            string OilMalfunctionWhere = string.Empty;
            #region Where Generate
            ///___________________________________________-
            if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime))
            {
                DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, 0, 0, 0);
                DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day, 23, 59, 59);

                ReferWhere = " AND ";
                ReferWhere += " Refer.register_date_time between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'";

                OilMalfunctionWhere = " AND ";
                OilMalfunctionWhere += " OilMalfunction.InsertDate between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'";
            }
            ///___________________________________________-
            if (UserCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append("  USR.code = " + UserCode);
            }
            #endregion Where Generate
            //if (Where.Length == 0)
            //    Where.Append(" WHERE ");
            //else
            //    Where.Append(" AND ");
            //Where.Append(ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.Zone.JOliZonees.GetWebQuery", "OA.OilZoneCode"));

            return @"SELECT DISTINCT USR.code as Code,CAP.Name,
                      (SELECT count(*) FROM OilMalfunction where OilMalfunction.RegistrarCode = USR.code " + OilMalfunctionWhere + @") AS TicketCount,
		              (SELECT count(*) FROM Refer 
                        LEFT JOIN Objects Objects ON(Objects.ClassName='WebOilManagement.JWebFailure' AND Refer.object_code = Objects.ObjectCode) 
                        WHERE  Refer.sender_code = USR.code 
                        " + ReferWhere + @" ) AS ReferCount
                            FROM users USR
                            LEFT JOIN clsAllPerson CAP ON(CAP.Code=USR.pcode)
                            LEFT JOIN OilMalfunction OM ON(OM.RegistrarCode = USR.code)" + Where;
        }

        /// <summary>
        /// گزارش مربوط به فرم گزارش خرابی ها و تعمیرات انجام شده 
        /// </summary>
        /// <param name="AreaCode"></param>
        /// <param name="OilZoneCode"></param>
        /// <param name="StationName"></param>
        /// <param name="StationID"></param>
        /// <param name="Code"></param>
        /// <param name="FailurDate"></param>
        /// <param name="FixingBrokenDate"></param>
        /// <param name="FixingBrokenTime"></param>
        /// <param name="EliminateDownTimeDue"></param>
        /// <param name="HowMalFunction"></param>
        /// <param name="DefectiveItem"></param>
        /// <param name="UseType"></param>
        /// <param name="ReplacedDefectiveItemSerial"></param>
        /// <param name="NormalItemReplacementSerial"></param>
        /// <param name="ActualCodeFailure"></param>
        /// <returns></returns>
        public static string PerformanceVsRepairReportsRepair(int AreaCode = 0, int OilZoneCode = 0, int StationID = 0, DateTime? FailurDate = null
            , DateTime? FixingBrokenDate = null, int UseType = 0)
        {
            string Query = string.Empty;
            StringBuilder where = new StringBuilder();
            DateTime FailureDTime = new DateTime(FailurDate.Value.Year, FailurDate.Value.Month, FailurDate.Value.Day,0,0,0);
            DateTime FixBugDTime = new DateTime(FixingBrokenDate.Value.Year, FixingBrokenDate.Value.Month, FixingBrokenDate.Value.Day,23,59,59);

            #region Initial Where Query

            ///___________________________________________-

            if (AreaCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                    
                where.Append(" A.Code = " + AreaCode.ToString());
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

            if(StationID > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append("gs.Code=" + StationID.ToString());
            }

            if (FailurDate.HasValue && FixingBrokenDate.HasValue)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" mf.InsertDate between  ");
                where.Append("'" + FailureDTime.ToString() + "'");
                where.Append(" AND ");
                where.Append("'" + FixBugDTime.ToString() + "'");
            }

            if(UseType > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" hr.Serviced =" + UseType.ToString());                
            }
            #endregion Initial Where Query


            #region Query

            Query = @"select distinct ROW_NUMBER() over(order by z.Name)as code, z.Name as 'منطقه',a.Name as 'ناحیه',gs.Number as 'شناسه جایگاه',gs.Name as 'نام جایگاه', 
                    mf.DamageCode as 'کد خرابی',mf.Code as 'کد رهگیری',mf.RealMalfunctionDate as 'زمان وقوع خرابی',
                    ar.GasStationManagerConfirmation as 'زمان رفع خرابی',
                     (select DATEDIFF (MINUTE,mf.RealMalfunctionDate,ar.GasStationManagerConfirmation)) as 'مدت رفع خرابی', 
                    (SELECT name FROM subdefine  WHERE bcode=mf.TypeOfMalfunction ) as 'نحوه اعلام خرابی',
                     ( select 
                     CASE 
                     WHEN ar.FixDefects=0 THEN (select 
                      CASE 
                       WHEN ar.DontFixDefects=0 THEN 'عدم انتخاب'
                          WHEN ar.DontFixDefects=1 THEN 'نیاز به قطعه' 
                          WHEN ar.DontFixDefects=2 THEN 'نیاز به بررسی بیشتر' 
	                      WHEN ar.DontFixDefects=3 THEN 'عدم ارتباط با مرکز'  
	                      WHEN ar.DontFixDefects=4 THEN 'عدم حضور مسئول جایگاه' 
	                      WHEN ar.DontFixDefects=5 THEN 'ایراد مکانیکی' 
	                      WHEN ar.DontFixDefects=6 THEN 'ایراد نرم افزاری'
	                      ELSE 'سایر موارد'
                       END ) END ) as 'دلیل عدم رفع خرابی',
                       (select 
                       CASE
                       WHEN hr.Serviced=0 THEN 'هیچ کدام'
                       WHEN hr.Serviced=1 THEN 'سرویس'
                       WHEN hr.Serviced=2 THEN 'تعویض' 
                       WHEN hr.Serviced=3 THEN 'عدم وجود قطعه' 
                       END) as 'نوع استفاده',
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
        /// 
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="StartEventDate"></param>
        /// <param name="EndEventDate"></param>
        /// <returns></returns>
        public static string PerformanceCallCenterCodeList(int UserCode, DateTime? StartEventDate, DateTime? EndEventDate)
        {
            StringBuilder Where = new StringBuilder();
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            string ReferWhere = string.Empty;
            string OilMalfunctionWhere = string.Empty;
            #region Where Generate
            ///___________________________________________-
            if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime))
            {
                DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, 0, 0, 0);
                DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day, 23, 59, 59);

                ReferWhere = " AND ";
                ReferWhere += " Refer.register_date_time between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'";

                OilMalfunctionWhere = " AND ";
                OilMalfunctionWhere += " OilMalfunction.InsertDate between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'";
            }
            ///___________________________________________-
            if (UserCode > 0)
            {
                if (Where.Length == 0)
                    Where.Append(" WHERE ");
                else
                    Where.Append(" AND ");
                Where.Append("  USR.code = " + UserCode);
            }
            #endregion Where Generate

            string Query = @"DECLARE @MalCode VARCHAR(8000) 
                    SELECT @MalCode = COALESCE(@MalCode + ', ', '') + Cast(OilMalfunction.Code AS VARCHAR) 
                    FROM OilMalfunction OM
	                            LEFT JOIN OilGasStation OGS on(OGS.Code = OM.GasStationCode)
	                            LEFT JOIN OilArea OA on(OGS.OilAreaCode = OA.Code)
	                            LEFT JOIN OilZone OZ on(OA.OilZoneCode = OZ.Code)
	                            LEFT JOIN OilSupplierDetails OSD on(OSD.ZoneCode = OZ.Code)
	                            LEFT JOIN OilSupplier OS on(OS.Code = OSD.SupplierCode)
	                            LEFT JOIN clsAllPerson CAPOS ON(OS.PCode =CAPOS.Code) 
	                            LEFT JOIN OilTableDamages OTD ON(OTD.Code = OM.DamageCode)
	                            LEFT JOIN  users Usr ON(Usr.Code=OM.RegistrarCode)
	                            LEFT JOIN  clsAllPerson CAP ON(CAP.Code=Usr.pcode)
	                            LEFT JOIN  OilAfterReviewing OAR ON(OAR.MalfunctionCode = OM.Code)
                            where " + Where
                             + " SELECT @MalCode AS MalCode ";

            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(Query);
                if (db.Query_DataReader() && db.DataReader.Read())
                    db.DataReader.Close();
                return db.DataSet.Tables[0].Rows[0].ToString();
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// فرم گزارش گیری از خرابی ها و تعمیرات انجام شده
        /// </summary>
        /// <param name="AreaCode"></param>
        /// <param name="OilZoneCode"></param>
        /// <param name="StationName"></param>
        /// <param name="StationID"></param>
        /// <param name="Code"></param>
        /// <param name="FailurDate"></param>
        /// <param name="FixingBrokenDate"></param>
        /// <param name="EliminateDownTimeDue"></param>
        /// <param name="DefectiveItem"></param>
        /// <param name="UseType"></param>
        /// <returns></returns>
        public static string PerformanceCompareIpcLogVsSupplier(int AreaCode = 0, int OilZoneCode = 0, string StationName = "0"
                    , int StationID = 0
                    , DateTime? FailurDate = null
                    , DateTime? FixingBrokenDate = null, int EliminateDownTimeDue = 0, int DefectiveItem = 0, int UseType = 0)
        {
            return "";
        }

        /// <summary>
        /// گزارش از Ticketهای باز شده
        /// </summary>
        /// <param name="AreaCode"></param>
        /// <param name="OilZoneCode"></param>
        /// <param name="StationName"></param>
        /// <param name="StationID"></param>
        /// <param name="AsDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public static string PerformanceLaggingTicket(int AreaCode = 0, int OilZoneCode = 0
                    , int StationID = 0
                    , DateTime? AsDate = null, DateTime? ToDate = null)
        {
            string Query = string.Empty;
            StringBuilder where = new StringBuilder();
            DateTime StartDTime = new DateTime(AsDate.Value.Year, AsDate.Value.Month, AsDate.Value.Day,0,0,0);
            DateTime EndDTime = new DateTime(ToDate.Value.Year, ToDate.Value.Month, ToDate.Value.Day,23,59,59);

            #region Initial Where Query

            ///___________________________________________-

            if (AreaCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                    
                where.Append(" A.Code = " + AreaCode.ToString());
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

            if(StationID > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" gs.Number = " + StationID.ToString());
            }

            ///___________________________________________-

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

            #endregion Initial Where Query


            #region Query

            Query = @" SELECT DISTINCT mf.Code, z.Name AS 'نام منطقه',gs.Number AS 'شناسه جايگاه',gs.Name AS 'نام جايگاه',
                     mf.Code AS 'کد رهگيري',td.Name AS 'عنوان خرابي',mf.NozzleCode AS 'شماره نازل',
                     mf.RealMalfunctionDate AS 'زمان ثبت خرابي',td.TimeRequiredToRepair AS 'مهلت رفع خرابي' 
                       FROM OilArea a INNER JOIN OilZone z ON a.OilZoneCode = z.Code 
                     INNER JOIN OilGasStation gs ON gs.OilAreaCode = a.Code 
                     INNER JOIN OilMalfunction mf ON mf.GasStationCode = gs.Code 
                     INNER JOIN OilTableDamages td ON td.Code = mf.DamageCode ";

                Query += where.ToString();
            #endregion Query

            return Query;
        }



    }

    public class JMalfunctionTable : ClassLibrary.JTable
    {
        /// <summary>
        /// کد جایگاه
        /// </summary>
        public int GasStationCode;
        /// <summary>
        /// کد نازل
        /// </summary>
        public int NozzleCode;
        /// <summary>
        /// کد اعلام کننده خرابی از پرسنل جایگاه باید باشد یا پیمانکار
        /// </summary>
        public int HangerCode;
        /// <summary>
        /// نام اعلام کننده خرابی از پرسنل جایگاه باید باشد یا پیمانکار
        /// </summary>
        public string HangerName;
        /// <summary>
        /// تاریخ و ساعت اعلام
        /// </summary>
        public DateTime DateTimeMalfunction;
        /// <summary>
        /// کد خرابی
        /// </summary>
        public int DamageCode;
        public int RegistrarCode;
        //public string RegistrarName;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        public JStatusMalfunction Status;
        /// <summary>
        /// نوع اعلام خرابی
        /// </summary>
        public int TypeOfMalfunction;

        /// <summary>
        /// زمان واقعی خرابی
        /// </summary>
        public DateTime RealMalfunctionDate;

        /// <summary>
        /// توضیحات خرابی واقعی
        /// </summary>
        public string RealMalfunctionDescription;

        /// <summary>
        /// خرابی دفتر
        /// </summary>
        public bool IsOfficeDamage;

        /// <summary>
        /// تاریخ بستن پیش از رفع خرابی
        /// </summary>
        public DateTime NotSolvedDate;

        /// <summary>
        ///  ساعت بستن پیش از رفع خرابی
        /// </summary>
        //public DateTime NotSolvedTime { get; set; }

        /// <summary>
        /// شرح بستن پیش از رفع خرابی
        /// </summary>
        public string NotSolvedDescription;

        /// <summary>
        /// کد پیمانکار
        /// </summary>
        public int SupplierCode;

        public JMalfunctionTable()
            : base("OilMalfunction")
        {
        }
    }

}
