using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.Nozzle
{
    public class JNozzle
    {
        public int Code { get; set; }
        public int PumpCode { get; set; }
        public int Number { get; set; }
        /// <summary>
        /// مخزن
        /// </summary>
        public int FuelTankCode { get; set; }

        public Pump.JPump GetPump()
        {
            Pump.JPump jPump = new Pump.JPump();
            jPump.GetData(PumpCode);
            return jPump;
        }

        public int Insert()
        {
            JNozzleTable GH = new JNozzleTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool Update()
        {
            JNozzleTable GH = new JNozzleTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JNozzleTable GH = new JNozzleTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JNozzleTable GH = new JNozzleTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JNozzleTable GH = new JNozzleTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JNozzleses
    {
        public static DataTable GetDataTableByPumpCode(int pumpCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"SELECT on1.Code, CAST(on1.Number AS NVARCHAR(10)) + ' (پمپ ' + CAST(op.Number AS NVARCHAR(10)) + ' ' + ogs.Name + ')' Title FROM OilNozzle on1
                            INNER JOIN OilPump op ON op.Code = on1.PumpCode
                            INNER JOIN OilGasStation ogs ON ogs.Code = op.GasStationCode Where on1.PumpCode=" + pumpCode.ToString());
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
            JNozzleTable GH = new JNozzleTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return @"SELECT on1.Code, on1.Number NozzleNumber, op.Number PumpNumber, oft.Number FuelTankNumber
                      FROM OilNozzle on1
                    INNER JOIN OilPump op ON op.Code = on1.PumpCode
                    INNER JOIN OilFuelTank oft ON oft.Code = on1.FuelTankCode 
                    INNER JOIN OilGasStation ogs ON ogs.code = op.GasStationCode WHERE " + ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.GasStation.JGasStationes.GetGasStations", "ogs.Code");
        }

        public static DataTable GetNuzzelByStationCode(int GasStationCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {

                db.setQuery(@"SELECT on1.Code, on1.Number Title
                      FROM OilNozzle on1
                    INNER JOIN OilPump op ON op.Code = on1.PumpCode
                    WHERE Op.GasStationCode =" + GasStationCode.ToString());
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetTitles()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"SELECT on1.Code, CAST(on1.Number AS NVARCHAR(10)) + ' (پمپ ' + CAST(op.Number AS NVARCHAR(10)) + ' ' + ogs.Name + ')' Title FROM OilNozzle on1
                            INNER JOIN OilPump op ON op.Code = on1.PumpCode
                            INNER JOIN OilGasStation ogs ON ogs.Code = op.GasStationCode WHERE " + ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.GasStation.JGasStationes.GetGasStations", "ogs.Code"));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }



        public static bool CanViewAllNozzles()
        {
            return ClassLibrary.JPermission.CheckPermission("OilProductsDistributionCompany.Nozzle.JNozzleses.CanViewAllNozzles", false);
        }
    }

    public class JNozzleTable : ClassLibrary.JTable
    {
        public int PumpCode;
        public int Number;
        /// <summary>
        /// مخزن
        /// </summary>
        public int FuelTankCode;

        public JNozzleTable()
            : base("OilNozzle")
        {
        }
    }

}
