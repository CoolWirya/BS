using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.Seal
{

    public enum JStatusSeal
    {
        /// <summary>
        /// نصب شده
        /// </summary>
        Mounted = 1,
        /// <summary>
        /// فک شده
        /// </summary>
        Jaw = 2,
        /// <summary>
        /// معیوب
        /// </summary>
        Defective = 3,
    }

    public class JSeal
    {
        public int Code { get; set; }
        public string Serial { get; set; }
        public JStatusSeal Status { get; set; }
        public int Insert()
        {
            JSealTable GH = new JSealTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool Update()
        {
            JSealTable GH = new JSealTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JSealTable GH = new JSealTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JSealTable GH = new JSealTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JSealTable GH = new JSealTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JSeales
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JSealTable GH = new JSealTable();
            return GH.GetDataTable(pCode);
        }

        public static DataTable GetDataTableNotInSealForm(int SealFormCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Select * From OilSeal ss Where ss.Code not in (Select fs.SealCode From OilFormSealDetails fs Where fs.FormSealCode = " + SealFormCode + ")");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static string GetWebQuery()
        {
            return "SELECT os.Code, os.Serial, CASE os.[Status] WHEN 1 THEN 'نصب شده' WHEN 2 THEN 'فک شده' WHEN 3 THEN 'معيوب' ELSE 'نامشخص' END [Status] FROM OilSeal os";
        }

    }

    public class JSealTable : ClassLibrary.JTable
    {
        public string Serial;
        public JStatusSeal Status;

        public JSealTable()
            : base("OilSeal")
        {
        }
    }
}
