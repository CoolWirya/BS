using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.FuelTank
{
    public class JFuelTank
    {
        public int Code { get; set; }
        /// <summary>
        /// شماره مخزن
        /// </summary>
        public int Number { get; set; }
        public int GasStationCode { get; set; }
        /// <summary>
        /// نوع مخزن
        /// </summary>
        public int TypeOfFuelTankCode { get; set; }
        /// <summary>
        /// سازنده
        /// </summary>
        public int Manufacturer { get; set; }
        /// <summary>
        /// سال ساخت
        /// </summary>
        public int YearBuilt { get; set; }
        /// <summary>
        /// نوع فراورده
        /// </summary>
        public int TypeOfProductCode { get; set; }
        /// <summary>
        /// تعداد پمپ
        /// </summary>
        public int NumberOfPumps { get; set; }



        public int Insert()
        {
            JFuelTankTable GH = new JFuelTankTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool Update()
        {
            JFuelTankTable GH = new JFuelTankTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JFuelTankTable GH = new JFuelTankTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JFuelTankTable GH = new JFuelTankTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JFuelTankTable GH = new JFuelTankTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JFuelTankes
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JFuelTankTable GH = new JFuelTankTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return @"SELECT oft.Code, oft.Number FuelTankNumber, ogs.Name GasStationName, sTypeOfFuelTank.name TypeOfFuelTank, sManufacturer.name Manufacturer, sTypeOfProduct.name TypeOfProduct 
                      FROM OilFuelTank oft
                    LEFT JOIN OilGasStation ogs ON ogs.Code = oft.GasStationCode
                    LEFT JOIN subdefine sTypeOfFuelTank ON sTypeOfFuelTank.Code = oft.TypeOfFuelTankCode
                    LEFT JOIN subdefine sManufacturer ON sManufacturer.Code = oft.Manufacturer
                    LEFT JOIN subdefine sTypeOfProduct ON sTypeOfProduct.Code = oft.TypeOfProductCode WHERE " + ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.GasStation.JGasStationes.GetGasStations", "ogs.Code");
        }

        public static DataTable GetTitles()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"SELECT oft.Code, CAST(oft.Number AS NVARCHAR(10)) + ' (' + ogs.Name +')' Title FROM OilFuelTank oft
                                INNER JOIN OilGasStation ogs ON ogs.Code = oft.GasStationCode WHERE " + ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.GasStation.JGasStationes.GetGasStations", "ogs.Code"));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }


    }

    public class JFuelTankTable : ClassLibrary.JTable
    {
        /// <summary>
        /// شماره مخزن
        /// </summary>
        public int Number;
        public int GasStationCode;
        /// <summary>
        /// نوع مخزن
        /// </summary>
        public int TypeOfFuelTankCode;
        /// <summary>
        /// سازنده
        /// </summary>
        public int Manufacturer;
        /// <summary>
        /// سال ساخت
        /// </summary>
        public int YearBuilt;
        /// <summary>
        /// نوع فراورده
        /// </summary>
        public int TypeOfProductCode;
        /// <summary>
        /// تعداد پمپ
        /// </summary>
        public int NumberOfPumps;

        public JFuelTankTable()
            : base("OilFuelTank")
        {
        }
    }
}
