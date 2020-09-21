using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.OEMProducts
{

    /// <summary>
    /// محل نصب کالاها
    /// </summary>
    public class JOEMProducts
    {
        public int Code { get; set; }
        /// <summary>
        /// کد کالای 
        /// </summary>
        public int GoodsCode { get; set; }
        /// <summary>
        /// کد جایگاه
        /// </summary>
        public int GasStationCode { get; set; }
        /// <summary>
        /// کد تلمبه
        /// </summary>
        public int PumpCode { get; set; }
        /// <summary>
        /// کد نازل
        /// </summary>
        public int NozzelCode { get; set; }
        /// <summary>
        /// شماره
        /// </summary>
        public int Number { get; set; }
        
        public int Insert()
        {
            JOEMProductsTable GH = new JOEMProductsTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool update()
        {
            JOEMProductsTable GH = new JOEMProductsTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JOEMProductsTable GH = new JOEMProductsTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JOEMProductsTable GH = new JOEMProductsTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JOEMProductsTable GH = new JOEMProductsTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JOEMProductsses
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JOEMProductsTable GH = new JOEMProductsTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return @"SELECT oo.Code, wtog.Name GoodName, ogs.Name + ' ('+CAST(ogs.Number AS NVARCHAR(10))+')' GasStation, op.Number PumpNumber, on1.Number NozzleNumber
                      FROM OilOEMProducts oo
                    INNER JOIN WarGoods wg ON wg.Code = oo.GoodsCode
                    INNER JOIN WarTypesOfGoods wtog ON wtog.Code = wg.TypeOfGoodsCode
                    INNER JOIN OilGasStation ogs ON ogs.Code = oo.GasStationCode
                    INNER JOIN OilPump op ON op.Code = oo.PumpCode
                    INNER JOIN OilNozzle on1 ON on1.Code = oo.NozzelCode"; 
        }
    }

    public class JOEMProductsTable : ClassLibrary.JTable
    {
        /// <summary>
        /// کد کالای 
        /// </summary>
        public int GoodsCode;
        /// <summary>
        /// کد جایگاه
        /// </summary>
        public int GasStationCode;
        /// <summary>
        /// کد تلمبه
        /// </summary>
        public int PumpCode;
        /// <summary>
        /// کد نازل
        /// </summary>
        public int NozzelCode;
        /// <summary>
        /// شماره
        /// </summary>
        public int Number;

        public JOEMProductsTable()
            : base("OilOEMProducts")
        {
        }
    }
}
