using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Goods
{
    /// <summary>
    /// نوع کالا
    /// </summary>
    public class JTypesOfGoods
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int GoodsHierarchyCode { get; set; }
        public int ParentCode { get; set; }
        public bool HasSerial { get; set; }

        public int Insert()
        {
            JTypesOfGoodsTable GH = new JTypesOfGoodsTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool Update()
        {
            JTypesOfGoodsTable GH = new JTypesOfGoodsTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JTypesOfGoodsTable GH = new JTypesOfGoodsTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JTypesOfGoodsTable GH = new JTypesOfGoodsTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JTypesOfGoodsTable GH = new JTypesOfGoodsTable();
            return GH.GetData(this, pCode);
        }
    }

    public class JTypesOfGoodSes
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JTypesOfGoodsTable TG = new JTypesOfGoodsTable();
            return TG.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            JTypesOfGoodsTable TG = new JTypesOfGoodsTable();
            return "SELECT  WTOG.Code"
                + "        ,WTOG.Name"
                + "        ,GoodsHierarchyCode"
                + "        ,WGH.Name AS GoodsHierarchyName"
                + "  FROM WarTypesOfGoods  WTOG"
                + "  Left Join WarGoodsHierarchy WGH ON(WTOG.GoodsHierarchyCode = WGH.Code)";
        }

        public static DataTable GetTypeOfGoodsInStock(int WarWarehouseCode = 0)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"
                            	SELECT	 WGM.Code AS Code ,WGM.Name 
			                            FROM WarTypesOfGoods  WGM ");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        
    }

    public class JTypesOfGoodsTable : ClassLibrary.JTable
    {
        public string Name;
        public int GoodsHierarchyCode;
        public int ParentCode;
        public bool HasSerial;

        public JTypesOfGoodsTable()
            : base("WarTypesOfGoods")
        {
        }
    }
}
