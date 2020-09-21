using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.Zone
{
    /// <summary>
    /// حوزه نفتی
    /// </summary>
    public class JOilDistrict
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Insert()
        {
            JOilDistrictTable GH = new JOilDistrictTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool update()
        {
            JOilDistrictTable GH = new JOilDistrictTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JOilDistrictTable GH = new JOilDistrictTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JOilDistrictTable GH = new JOilDistrictTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JOilDistrictTable GH = new JOilDistrictTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JOilDistrictes
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JOilDistrictTable GH = new JOilDistrictTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return "SELECT Code, Name FROM OilDistrict od";
        }
    }

    public class JOilDistrictTable : ClassLibrary.JTable
    {
        public string Name;

        public JOilDistrictTable()
            : base("OilDistrict")
        {
        }
    }
}


