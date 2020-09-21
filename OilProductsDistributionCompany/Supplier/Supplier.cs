using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany
{
    /// <summary>
    /// پیمانکار
    /// </summary>
    public class JSupplier
    {
        public int Code { get; set; }
        /// <summary>
        /// کد شخص حقوقی
        /// </summary>
        public int PCode { get; set; }
        public DateTime StartContract { get; set; }
        public DateTime EndContract { get; set; }
        public int WarCode { get; set; }
        public int Insert()
        {
            ClassLibrary.JDataBase JDB = new ClassLibrary.JDataBase();
            JSupplierTable GH = new JSupplierTable();
            ClassLibrary.JPerson JP = new ClassLibrary.JPerson();
            WarehouseManagement.Warehouse.JWarehouseTable WHT = new WarehouseManagement.Warehouse.JWarehouseTable();
            WarehouseManagement.Warehouse.JWarehouse WH = new WarehouseManagement.Warehouse.JWarehouse();

            if (JDB.beginTransaction("Supplier_Wearhouse"))
            {
                GH.SetValueProperty(this);
                JP.getData(GH.PCode);
                GH.Code = GH.Insert(JDB);
                WH.Name = " انبار " + JP.Name + " " + JP.Fam + " (پیمانکار) ";
                WH.OwnerCode = GH.PCode;
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
            JSupplierTable GH = new JSupplierTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JSupplierTable GH = new JSupplierTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JSupplierTable GH = new JSupplierTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JSupplierTable GH = new JSupplierTable();
            return GH.GetData(this, pCode);
        }

        public bool updateOwner(int _Code, int _OwnerCode)
        {
            JSupplierTable GH = new JSupplierTable();
            ClassLibrary.JPerson JP = new ClassLibrary.JPerson();
            WarehouseManagement.Warehouse.JWarehouseTable WHT = new WarehouseManagement.Warehouse.JWarehouseTable();
            WarehouseManagement.Warehouse.JWarehouse WH = new WarehouseManagement.Warehouse.JWarehouse();

            GetData(_Code);

            GH.SetValueProperty(this);
            JP.getData(GH.PCode);
            WH.Name = " انبار " + JP.Name + " " + JP.Fam + " (پیمانکار) ";
            WH.OwnerCode = GH.PCode;
            WHT.SetValueProperty(WH);
            GH.WarCode = WHT.Insert();
            return GH.Update();

        }


        public int FindByGSCode(int GSCode = 0)
        {
            ClassLibrary.JDataBase JDB = new ClassLibrary.JDataBase();
            string Query =
            @"SELECT OS.Code FROM OilSupplier OS
                    LEFT JOIN OilSupplierDetails OSD ON(OSD.SupplierCode=OS.Code)
                    LEFT JOIN OilZone OZ ON(OZ.Code=OSD.ZoneCode)
                    LEFT JOIN OilArea OA ON(OA.OilZoneCode = OZ.Code)
                    LEFT JOIN OilGasStation OGS ON(OGS.OilAreaCode = OA.Code)
                    Where OGS.Code=" + GSCode.ToString();
            JDB.setQuery(Query);

            DataTable dtSupplier = JDB.Query_DataTable();
            if (dtSupplier != null && dtSupplier.Rows.Count != 0)
                return (int)dtSupplier.Rows[0]["Code"];

            return 0;
        }

       
    }

    public class JSupplierses
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JSupplierTable GH = new JSupplierTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return @"SELECT os.Code, cap.Name, os.StartContract, os.EndContract FROM OilSupplier os
                        INNER JOIN clsAllPerson cap ON cap.Code = os.PCode";
        }

    }

    public class JSupplierTable : ClassLibrary.JTable
    {
        /// <summary>
        /// کد شخص حقوقی
        /// </summary>
        public int PCode;
        public DateTime StartContract;
        public DateTime EndContract;
        public int WarCode;
        public JSupplierTable()
            : base("OilSupplier")
        {
        }
    }

    public class JSupplierDetails
    {
        public int Code { get; set; }
        public int SupplierCode { get; set; }
        public int ZoneCode { get; set; }

        public int Insert()
        {
            JSupplierDetailsTable GH = new JSupplierDetailsTable();
            GH.SetValueProperty(this);
            return GH.Insert();

        }

        public bool update()
        {
            JSupplierDetailsTable GH = new JSupplierDetailsTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JSupplierDetailsTable GH = new JSupplierDetailsTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JSupplierDetailsTable GH = new JSupplierDetailsTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JSupplierDetailsTable GH = new JSupplierDetailsTable();
            return GH.GetData(this, pCode);
        }


        //public void FindBySupplierCode(int SupplierCode)
        //{

        //    ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
        //    try
        //    {
        //        db.setQuery(@"SELECT Code FROM OilSupplierDetails  WHERE " + ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.GasStation.JGasStationes.GetGasStations", "ogs.Code"));
        //        return db.Query_DataTable();
        //    }
        //    finally
        //    {
        //        db.Dispose();
        //    }




        //    JSupplierDetailsTable GH = new JSupplierDetailsTable();


        //    throw new NotImplementedException();
        //}
    }

    public class JSupplierDetailses
    {
        public static DataTable GetData()
        {
            return GetData(0);
        }

        public static DataTable GetData(int pCode)
        {
            JSupplierDetailsTable GH = new JSupplierDetailsTable();
            return GH.GetDataTable(pCode);
        }

    }

    public class JSupplierDetailsTable : ClassLibrary.JTable
    {
        public int SupplierCode;
        public int ZoneCode;

        public JSupplierDetailsTable()
            : base("OilSupplierDetails")
        {
        }
    }

    /// <summary>
    /// کارکنان پیمانکار
    /// </summary>
    public class JSupplierContractorEmployees
    {
        public int Code { get; set; }
        public int PCode { get; set; }
        public DateTime StatrtContract { get; set; }
        public DateTime EndContract { get; set; }
        public int ContractCode { get; set; }
        /// <summary>
        /// شماره بیمه
        /// </summary>
        public string InsuranceNumber { get; set; }
        public string Resume { get; set; }
    }
}
