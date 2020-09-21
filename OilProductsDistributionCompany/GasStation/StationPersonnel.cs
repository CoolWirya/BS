using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.GasStation
{
    public enum JStationPersonnelStatus
    {
        Active = 1,
        DeActive = 2,
    }
    public class JStationPersonnel
    {
        public int Code { get; set; }
        public int PCode { get; set; }
        public int GasStationCode { get; set; }
        public JStationPersonnelStatus Status { get; set; }
        public int PostCode { get; set; }

        public int Insert()
        {
            JStationPersonnelTable GH = new JStationPersonnelTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool update()
        {
            JStationPersonnelTable GH = new JStationPersonnelTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JStationPersonnelTable GH = new JStationPersonnelTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JStationPersonnelTable GH = new JStationPersonnelTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JStationPersonnelTable GH = new JStationPersonnelTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JStationPersonneles
    {
        public static DataTable GetData()
        {
            return GetData(0);
        }

        public static DataTable GetData(int pCode)
        {
            JStationPersonnelTable GH = new JStationPersonnelTable();
            return GH.GetDataTable(pCode);
        }

    }

    public class JStationPersonnelTable : ClassLibrary.JTable
    {
        public int PCode;
        public int GasStationCode;
        public JStationPersonnelStatus Status;
        public int PostCode;

        public JStationPersonnelTable()
            : base("OilStationPersonnel")
        {
        }
    }
}
