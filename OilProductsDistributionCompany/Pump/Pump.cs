using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.Pump
{
    public class JPump
    {
        public int Code { get; set; }
        public int Number { get; set; }
        public int TypeOfPumpCode { get; set; }
        public int GasStationCode { get; set; }

        public GasStation.JGasStation GetGasStation()
        {
            GasStation.JGasStation jGasStation = new GasStation.JGasStation();
            jGasStation.GetData(GasStationCode);
            return jGasStation;
        }

        public int Insert()
        {
            JPumpTable GH = new JPumpTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool Update()
        {
            JPumpTable GH = new JPumpTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JPumpTable GH = new JPumpTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JPumpTable GH = new JPumpTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JPumpTable GH = new JPumpTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JPumpes
    {
        public static DataTable GetDataTableByGasStationCode(int gasStationCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"SELECT op.Code, CAST(op.Number AS NVARCHAR(10)) + ' (' + ogs.Name + ')' Title FROM OilPump op
                            INNER JOIN OilGasStation ogs ON ogs.Code = op.GasStationCode Where GasStationCode=" + gasStationCode.ToString());
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JPumpTable GH = new JPumpTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return @"SELECT op.Code, op.Number, s.name [TypeOfPump], ogs.Name + ' (' + CAST(ogs.Number AS NVARCHAR(10)) + ')' [GasStation]
                      FROM OilPump op
                    INNER JOIN subdefine s ON s.Code = op.TypeOfPumpCode
                    INNER JOIN OilGasStation ogs ON ogs.code = op.GasStationCode WHERE " + ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.GasStation.JGasStationes.GetGasStations", "ogs.Code");
        }

        public static DataTable GetTitles()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"SELECT op.Code, CAST(op.Number AS NVARCHAR(10)) + ' (' + ogs.Name + ')' Title FROM OilPump op
                                INNER JOIN OilGasStation ogs ON ogs.Code = op.GasStationCode WHERE " + ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.GasStation.JGasStationes.GetGasStations", "ogs.Code"));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static bool CanViewAllPumps()
        {
            return ClassLibrary.JPermission.CheckPermission("OilProductsDistributionCompany.Pump.JPumpes.CanViewAllPumps", false);
        }
    }

    public class JPumpTable : ClassLibrary.JTable
    {
        public int Number;
        public int TypeOfPumpCode;
        public int GasStationCode;

        public JPumpTable()
            : base("OilPump")
        {
        }
    }
}
