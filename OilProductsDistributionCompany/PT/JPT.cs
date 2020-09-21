using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OilProductsDistributionCompany.PT
{
    public class JPT
    {
        public int Code { get; set; }
        public int NozzleCode { get; set; }
        public int PTNumber { get; set; }

        public Nozzle.JNozzle GetNozzle()
        {
            Nozzle.JNozzle jNozzle = new Nozzle.JNozzle();
            jNozzle.GetData(NozzleCode);
            return jNozzle;
        }

        public int Insert()
        {
            JPTTable GH = new JPTTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool Update()
        {
            JPTTable GH = new JPTTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JPTTable GH = new JPTTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JPTTable GH = new JPTTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JPTTable GH = new JPTTable();
            return GH.GetData(this, pCode);
        }
    }
    public class JPTs
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JPTTable GH = new JPTTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return @"SELECT op.Code, on1.Number NozzleNumber, op.PTNumber FROM OilPT op
                        INNER JOIN OilNozzle on1 ON on1.Code = op.NozzleCode";
        }

    }
    public class JPTTable : ClassLibrary.JTable
    {
        public int NozzleCode;
        public int PTNumber;

        public JPTTable()
            : base("OilPT")
        {
        }
    }

    public class JPTGoods
    {
        public int Code { get; set; }
        public int PTCode { get; set; }
        public int GoodCode { get; set; }
        public int Status { get; set; }

        public int Insert()
        {
            JPTGoodsTable GH = new JPTGoodsTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool update()
        {
            JPTGoodsTable GH = new JPTGoodsTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JPTGoodsTable GH = new JPTGoodsTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JPTGoodsTable GH = new JPTGoodsTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JPTGoodsTable GH = new JPTGoodsTable();
            return GH.GetData(this, pCode);
        }
    }
    public class JPTGoodss
    {
        public static DataTable GetPTsGoods(int PTCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Select * From OilPTGoods where PTCode = " + PTCode);
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
            JPTGoodsTable GH = new JPTGoodsTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            JPTGoodsTable GH = new JPTGoodsTable();
            return GH.CreateQuery("");
        }

    }
    public class JPTGoodsTable : ClassLibrary.JTable
    {
        public int PTCode;
        public int GoodCode;
        public int Status;

        public JPTGoodsTable()
            : base("OilPTGoods")
        {
        }
    }
}
