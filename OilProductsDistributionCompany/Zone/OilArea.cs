using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.Zone
{
    /// <summary>
    /// نواحی نفتی
    /// </summary>
    public class OilArea
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int OilZoneCode { get; set; }

        public int Insert()
        {
            JOilAreaTable GH = new JOilAreaTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool update()
        {
            JOilAreaTable GH = new JOilAreaTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JOilAreaTable GH = new JOilAreaTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JOilAreaTable GH = new JOilAreaTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JOilAreaTable GH = new JOilAreaTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JOilAreaes
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JOilAreaTable GH = new JOilAreaTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return @"SELECT oa.Code, oa.Name, oz.Name ZoneName FROM OilArea oa
                    INNER JOIN OilZone oz ON oz.Code = oa.OilZoneCode";
        }
    }

    public class JOilAreaTable : ClassLibrary.JTable
    {
        public string Name;
        public int OilZoneCode;

        public JOilAreaTable()
            : base("OilArea")
        {
        }
    }
}


