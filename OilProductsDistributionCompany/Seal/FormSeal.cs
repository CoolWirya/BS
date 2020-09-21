using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.Seal
{
    public enum JPlaceSealed
    {
        DoorPump = 1,
        DoorBanner = 2,
        ExternalTerminal = 3,
    }


    public class JFormSeal
    {
        public int Code { get; set; }
        public int GasStationCode { get; set; }
        public string FormSealSerial { get; set; }
       
        /// <summary>
        /// سریال  پلمپ نصب شده
        /// </summary>
        public string Serial { get; set; }
        
        /// <summary>
        /// سریال پلمپ فک شده
        /// </summary>
        public string UnSerial { get; set; }

        public DateTime DatesOfOperation { get; set; }
        /// <summary>
        /// مسئول تیم فنی پیمانکار
        /// </summary>
        public int ResponsibleForTheTechnicalTeamCode { get; set; }
        /// <summary>
        /// مسئول جایگاه
        /// </summary>
        public int GasStationManagerCode { get; set; }

        public int Insert()
        {
            JFormSealTable GH = new JFormSealTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool Update()
        {
            JFormSealTable GH = new JFormSealTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JFormSealTable GH = new JFormSealTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JFormSealTable GH = new JFormSealTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JFormSealTable GH = new JFormSealTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JFormSealses
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JFormSealTable GH = new JFormSealTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return @"SELECT ofs.Code,ofs.Serial,ofs.UnSerial, ogs.Name + ' (' + CAST( ogs.Number AS NVARCHAR(10)) + ')' GasStation, ofs.FormSealSerial, ofs.DatesOfOperation, cap.Name ResponsibleForTheTechnicalTeamCode, cap2.Name GasStationManagerCode
                          FROM OilFormSeal ofs
                        LEFT JOIN clsAllPerson cap ON cap.Code = ofs.ResponsibleForTheTechnicalTeamCode
                        LEFT JOIN clsAllPerson cap2 ON cap2.Code = ofs.GasStationManagerCode
                        LEFT JOIN OilGasStation ogs ON ogs.Code = ofs.GasStationCode";
        }
    }

    public class JFormSealTable : ClassLibrary.JTable
    {
        public int GasStationCode;
        public string FormSealSerial;
        public string Serial;
        public string UnSerial;
        public DateTime DatesOfOperation;
        /// <summary>
        /// مسئول تیم فنی پیمانکار
        /// </summary>
        public int ResponsibleForTheTechnicalTeamCode;
        /// <summary>
        /// مسئول جایگاه
        /// </summary>
        public int GasStationManagerCode;

        public JFormSealTable()
            : base("OilFormSeal")
        {
        }
    }


    public class JFormSealDetails
    {
        public int Code { get; set; }
        public int FormSealCode { get; set; }
        public int NozzleCode { get; set; }

        public int SealCode { get; set; }
        public JPlaceSealed PlaceSealed { get; set; }
        public JStatusSeal Status { get; set; }

        public int Insert()
        {
            JFormSealDetailsTable GH = new JFormSealDetailsTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool update()
        {
            JFormSealDetailsTable GH = new JFormSealDetailsTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JFormSealDetailsTable GH = new JFormSealDetailsTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JFormSealDetailsTable GH = new JFormSealDetailsTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JFormSealDetailsTable GH = new JFormSealDetailsTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JFormSealDetailses
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JFormSealDetailsTable GH = new JFormSealDetailsTable();
            return GH.GetDataTable(pCode);
        }

        public static DataTable GetDataTableByFormSealCode(int pFormSealCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Select * From OilFormSealDetails Where FormSealCode=" + pFormSealCode);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

    }

    public class JFormSealDetailsTable : ClassLibrary.JTable
    {
        public int FormSealCode;
        public int NozzleCode;

        public int SealCode;
        public JPlaceSealed PlaceSealed;
        public JStatusSeal Status;

        public JFormSealDetailsTable()
            : base("OilFormSealDetails")
        {
        }
    }

}
