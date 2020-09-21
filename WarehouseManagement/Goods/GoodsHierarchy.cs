using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WarehouseManagement.Goods
{

    /// <summary>
    /// ساختار درختی کالاها
    /// </summary>
    public class JGoodsHierarchy
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int ParentCode { get; set; }

        public JGoodsHierarchy() { }
        public JGoodsHierarchy(int pCode)
        {
            GetData(pCode);
        }

        public int Insert()
        {
            JGoodsHierarchyTable GH = new JGoodsHierarchyTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool Update()
        {
            JGoodsHierarchyTable GH = new JGoodsHierarchyTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JGoodsHierarchyTable GH = new JGoodsHierarchyTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JGoodsHierarchyTable GH = new JGoodsHierarchyTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JGoodsHierarchyTable GH = new JGoodsHierarchyTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JGoodsHierarchies
    {
        public static DataTable GetData()
        {
            return GetData(0);
        }

        public static DataTable GetData(int pCode)
        {
            JGoodsHierarchyTable GH = new JGoodsHierarchyTable();
            return GH.GetDataTable(pCode);
        }

        public static DataTable GetHierarchy(int parentCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Select * From WarGoodsHierarchy Where ParentCode=" + parentCode.ToString() + " OR ParentCode is null");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetList()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Select * From WarGoodsHierarchy");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static void MoveChildren(int srcCode, int desCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Update WarGoodsHierarchy Set ParentCode=" + desCode + " Where ParentCode=" + srcCode);
                db.Query_Execute();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static bool DeleteNode(int code)
        {
            if (code == 0)
            {
                return false;
            }
            string childs = "";
            DataTable dt = new DataTable();
            dt = GetHierarchy(code);
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                childs += dt.Rows[i]["code"] + ",";
            }
            string strDelete = "DELETE FROM WarGoodsHierarchy where Code in (" + childs + code.ToString() + ")";
            int retCode = 0;
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(strDelete);
                retCode = int.Parse(db.Query_Execute().ToString());
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                db.Dispose();
            }
            if (retCode != 0 && retCode != -1)
            {
                return true;
            }
            return false;
        }


        public static string GetWebQuery()
        {
            JGoodsHierarchyTable GH = new JGoodsHierarchyTable();
            return GH.CreateQuery("");
        }

    }

    public class JGoodsHierarchyTable : ClassLibrary.JTable
    {
        public string Name;
        public int ParentCode;

        public JGoodsHierarchyTable()
            : base("WarGoodsHierarchy")
        {
        }
    }

}
