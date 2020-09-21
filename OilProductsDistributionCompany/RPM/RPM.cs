using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.RPM
{
    public class JRPM
    {
        public int Code { get; set; }
        public string Version { get; set; }
        public DateTime DateRegister { get; set; }
        public int FileCode { get; set; } // Archive Code
        public string Comment { get; set; }
        public int TableQuotas { get; set; }
        public int TablePrices { get; set; }
        public string PtVersion { get; set; }



        public int Insert()
        {
            JRPMTable GH = new JRPMTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool Update()
        {
            JRPMTable GH = new JRPMTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JRPMTable GH = new JRPMTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JRPMTable GH = new JRPMTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JRPMTable GH = new JRPMTable();
            return GH.GetData(this, pCode);
        }

        public static string HandyLoadReport(int AreaCode = 0, int OilZoneCode = 0, int StationID = 0, DateTime? RPMDate = null)
        {

            string Query = string.Empty;
            StringBuilder where = new StringBuilder();
            DateTime RPMTime = new DateTime(RPMDate.Value.Year, RPMDate.Value.Month, RPMDate.Value.Day,0,0,0);
            
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
                where.Append(" gs.Code = " + StationID.ToString());
            }

            ///___________________________________________-

            if (RPMDate.HasValue)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" rp.DateRegister = " + "'" + RPMTime.ToString() + "'");
            }

            #endregion Initial Where Query


            #region Query

            Query = @"SELECT distinct gs.Code, z.Name AS 'منطقه', a.Name as 'ناحيه',gs.Number AS 'شناسه جايگاه',gs.Name AS 'نام جايگاه', 
                    rp.Version AS 'نسخه RPM', rpg.Version AS 'ورژن RPM',rpg.DateIns AS 'تاريخ نصب RPM' 
                    FROM OilZone z INNER JOIN OilArea a ON  a.OilZoneCode=z.Code 
                    INNER JOIN  OilGasStation gs on gs.OilAreaCode=a.Code 
                    INNER JOIN OilMalfunction om ON om.GasStationCode=gs.Code 
                    INNER JOIN OilTableDamages s ON s.Code=om.DamageCode 
                    INNER JOIN OilRPMGS rpg ON rpg.GasStationCode=om.GasStationCode 
                    INNER JOIN OilRPM rp ON  rp.Code =rpg.Code_RPM AND s.Code=-1 ";

            Query += where.ToString();

            #endregion Query
            return Query;
        }
    }

    public class JRPMes
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JRPMTable GH = new JRPMTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return @"SELECT or1.Code, or1.DateRegister, or1.Version,or1.Comment, or1.TableQuotas, or1.TablePrices
                        FROM OilRPM or1 ";
        }

    }

    public class JRPMTable : ClassLibrary.JTable
    {
        public string Version;
        public DateTime DateRegister;
        public int FileCode;
        public string Comment;
        public int TableQuotas;
        public int TablePrices;
        public string PtVersion;

        public JRPMTable()
            : base("OilRPM")
        {
        }
    }


}


