using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.Zone
{
    /// <summary>
    /// مناطق نفتی
    /// </summary>
    public class JOilZone
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int OilDistrictCode { get; set; }

        public int Insert()
        {
            JOliZoneTable GH = new JOliZoneTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool update()
        {
            JOliZoneTable GH = new JOliZoneTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JOliZoneTable GH = new JOliZoneTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JOliZoneTable GH = new JOliZoneTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JOliZoneTable GH = new JOliZoneTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JOliZonees
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JOliZoneTable GH = new JOliZoneTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return @"SELECT oz.Code, oz.Name, od.Name DistrictName FROM OilZone oz
                    INNER JOIN OilDistrict od ON od.Code = oz.OilDistrictCode";
        }

        public static string PerformanceZoneReport(int AreaCode, int SupplierCode, int OilZoneCode, DateTime? StartEventDate, DateTime? EndEventDate, ref string PreQuery)
        {
            #region Initilization
            ///___________________________________________-
            string Query = string.Empty;
            string OilMalFunction = string.Empty;
            string where = string.Empty;
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            ///___________________________________________-
            #endregion Initilization

            #region Build  SubQuerys
            ///___________________________________________-
            OilMalFunction = " select count(*) from OilMalFunction where OilMalFunction.GasStationCode in(select code from OilGasStation where OilAreaCode=OA.Code) ";
            if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime))
            {
                DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, 0, 0, 0);
                DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day, 23, 59, 59);
                OilMalFunction += "  And InsertDate between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'";
            }
            ///___________________________________________-
            #endregion Build  SubQuerys

            #region Where Generate
            ///___________________________________________-

            if (AreaCode > 0)
            {
                if (where == string.Empty)
                    where = " where ";
                else
                    where += " AND ";
                where += " OA.Code = " + AreaCode;
            }
            ///___________________________________________-
            if (SupplierCode > 0)
            {
                if (where == string.Empty)
                    where = " where ";
                else
                    where += " AND ";
                where += " OS.Code = " + SupplierCode;
            }
            ///___________________________________________-
            if (OilZoneCode > 0)
            {
                if (where == string.Empty)
                    where = " where ";
                else
                    where += " AND ";
                where += " OilZone.Code = " + OilZoneCode;
            }
            ///___________________________________________-

            if (where == string.Empty)
                where = " where ";
            else
                where += " AND ";
            where += ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.Zone.JOliZonees.GetWebQuery", "OA.OilZoneCode");

            #endregion

//            #region Build MainQuery
//            PreQuery = @"DECLARE @MalCode VARCHAR(8000)
//                        SELECT @MalCode = COALESCE(@MalCode + ', ', '') + Cast(OM.Code AS VARCHAR) 
//                                                    FROM OilMalfunction OM
//                                                        LEFT JOIN OilGasStation   ogs                   ON (ogs.Code     = om.GasStationCode)
//                                                        LEFT JOIN OilArea         OA                    ON (OA.Code      = OGS.OilAreaCode) 
//                                                        LEFT JOIN OilZone		  OZ                    ON (OZ.Code     = OA.OilZoneCode)
//                                                        LEFT JOIN OilNozzle       on1                   ON (on1.Code     = om.NozzleCode)
//                                                        LEFT JOIN OilTableDamages otd                   ON (otd.Code     = om.DamageCode)
//                                                        LEFT JOIN users                                 ON (users.code   = om.RegistrarCode)
//            									        LEFT JOIN clsPerson                             ON (users.pcode  = clsPerson.Code)
//                                                        LEFT JOIN OilSupplier     OS                    ON (OS.Code		 = om.SupplierCode)
//            									        LEFT JOIN clsAllPerson    CAP			        ON (CAP.Code	 = OS.PCode)
//                                                        LEFT JOIN subdefine       sTypeOfMalfunction    ON (sTypeOfMalfunction.Code = om.TypeOfMalfunction) " + where;

//            ///___________________________________________-
//            Query += @" SELECT Distinct row_number() OVER(ORDER BY OilZone.Code) AS Code , OilZone.Code AS ZoneCode ,OilZone.Name ZoneName,OA.Name As AreaName,OA.Code as AreaCode,(select count(*) from OilGasStation where OilAreaCode=OA.code) as GSCount
//                        ,CAP.Name AS OilSupplier 
//                        ,(" + OilMalFunction + @" AND OilMalfunction.Status = 1 ) OpenTicketCount 
//                        ,(" + OilMalFunction + @" AND OilMalfunction.Status = 2 ) CloseTicketCount
//                        ,( SELECT @MalCode ) AS MasterCode 
//
//                    FROM OilZone 
//                        LEFT JOIN OilArea OA on(OilZone.Code=OA.OilZoneCode)
//                        LEFT JOIN OilSupplierDetails OSD ON(OSD.ZoneCode=OilZone.Code)
//                        LEFT JOIN OilSupplier OS on(OS.Code=OSD.SupplierCode)
//                        LEFT JOIN clsAllPerson CAP ON(CAP.Code=OS.PCode) ";
//            ///___________________________________________-
//            #endregion Build MainQuery

            Query += @"SELECT Distinct OilZone.Code,OilZone.Name ZoneName,OA.Name As AreaName,(select count(*) from OilGasStation where OilAreaCode=OA.code) as GSCount
                        ,CAP.Name AS OilSupplier 
                        ,(" + OilMalFunction + @" AND OilMalfunction.Status = 1 ) OpenTicketCount 
                        ,(" + OilMalFunction + @" AND OilMalfunction.Status = 2 ) CloseTicketCount
                    FROM OilZone 
                        LEFT JOIN OilArea OA on(OilZone.Code=OA.OilZoneCode)
                        LEFT JOIN OilSupplierDetails OSD ON(OSD.ZoneCode=OilZone.Code)
                        LEFT JOIN OilSupplier OS on(OS.Code=OSD.SupplierCode)
                        LEFT JOIN clsAllPerson CAP ON(CAP.Code=OS.PCode) ";

            Query += where;

            return Query;
        }

        public static string PerformanceZoneCodeList(int AreaCode, int SupplierCode, int OilZoneCode, DateTime? StartEventDate, DateTime? EndEventDate)
        {
            #region Initilization
            ///___________________________________________-
            string Query = string.Empty;
            string OilMalFunction = string.Empty;
            string where = string.Empty;
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            ///___________________________________________-
            #endregion Initilization

            #region Where Generate
            ///___________________________________________-

            if (AreaCode > 0)
            {
                if (where == string.Empty)
                    where = " where ";
                else
                    where += " AND ";
                where += " OA.Code = " + AreaCode;
            }
            ///___________________________________________-
            if (SupplierCode > 0)
            {
                if (where == string.Empty)
                    where = " where ";
                else
                    where += " AND ";
                where += " OS.Code = " + SupplierCode;
            }
            ///___________________________________________-
            if (OilZoneCode > 0)
            {
                if (where == string.Empty)
                    where = " where ";
                else
                    where += " AND ";
                where += " OZ.Code = " + OilZoneCode;
            }
            ///___________________________________________-

            if (where == string.Empty)
                where = " where ";
            else
                where += " AND ";
            where += ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.Zone.JOliZonees.GetWebQuery", "OA.OilZoneCode");


            if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime))
            {
                if (where == string.Empty)
                    where = " where ";
                else
                    where += " AND ";
                DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, 0, 0, 0);
                DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day, 23, 59, 59);
                where += " InsertDate between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'";
            }

            #endregion

            #region Build MainQuery
            ///___________________________________________-

            Query += @" SELECT OM.Code AS MasterCode,OM.HangerName,OM.DateTimeMalfunction,OM.Description,OM.InsertDate,CASE OM.Status When 1 Then 'باز' Else 'بسته' end as MalStatus,OA.Name As AreaName
                                    ,OZ.Name As ZoneName,otd.Name As DamageName,CAP.Name SupplierName,
                                        sTypeOfMalfunction.Name As TypeOfMalfunctionName,Oz.Code as ZoneCode,OA.Code as AreaCode
                                    FROM OilMalfunction OM
                                        LEFT JOIN OilGasStation   ogs             ON (ogs.Code     = om.GasStationCode)
                                        LEFT JOIN OilArea         OA              ON (OA.Code      = OGS.OilAreaCode) 
                                        LEFT JOIN OilZone		    OZ            ON (OZ.Code     = OA.OilZoneCode)
                                        LEFT JOIN OilNozzle       on1             ON (on1.Code     = om.NozzleCode)
                                        LEFT JOIN OilTableDamages otd             ON (otd.Code     = om.DamageCode)
                                        LEFT JOIN users                           ON (users.code   = om.RegistrarCode)
            							LEFT JOIN clsPerson                       ON (users.pcode  = clsPerson.Code)
                                        LEFT JOIN OilSupplier      OS             ON (OS.Code		 = om.SupplierCode)
            							LEFT JOIN clsAllPerson     CAP			  ON (CAP.Code	 = OS.PCode)
                                        LEFT JOIN subdefine sTypeOfMalfunction    ON (sTypeOfMalfunction.Code = om.TypeOfMalfunction) 
                       " + where;


            ///___________________________________________-
            #endregion Build MainQuery

            return Query;

        }
    }

    public class JOliZoneTable : ClassLibrary.JTable
    {
        public string Name;
        public int OilDistrictCode;

        public JOliZoneTable()
            : base("OilZone")
        {
        }
    }
}


