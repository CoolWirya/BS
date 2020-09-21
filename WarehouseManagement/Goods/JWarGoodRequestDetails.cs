using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WarehouseManagement.Goods
{

    /// <summary>
    /// تعداد و اقلام کالاهای درخواست شده از انبار
    /// </summary>
    public class JWarGoodRequestDetails
    {
        #region "Properties"
            public int Code { get; set; }
            public int GRCode { get; set; }
            public int GoodTypeCode { get; set; }
            public int Count { get; set; }

        #endregion

        #region "Methods"
            public int Insert()
            {
                JWarGoodRequestDetailsTable GH = new JWarGoodRequestDetailsTable();
                GH.SetValueProperty(this);
                int result = GH.Insert();

                return result;
            }

            public bool Update()
            {
                JWarGoodRequestDetailsTable GH = new JWarGoodRequestDetailsTable();
                GH.SetValueProperty(this);
                bool result = GH.Update();

                return result;
            }

            public bool Delete()
            {
                JWarGoodRequestDetailsTable GH = new JWarGoodRequestDetailsTable();
                GH.SetValueProperty(this);
                return GH.Delete();
            }

            public int Insert(ClassLibrary.JDataBase JDB)
            {
                JWarGoodRequestDetailsTable GH = new JWarGoodRequestDetailsTable();
                GH.SetValueProperty(this);
                int result = GH.Insert(JDB);

                return result;
            }

            public bool Update(ClassLibrary.JDataBase JDB)
            {
                JWarGoodRequestDetailsTable GH = new JWarGoodRequestDetailsTable();
                GH.SetValueProperty(this);
                bool result = GH.Update(JDB);

                return result;
            }

            public bool Delete(ClassLibrary.JDataBase JDB)
            {
                JWarGoodRequestDetailsTable GH = new JWarGoodRequestDetailsTable();
                GH.SetValueProperty(this);
                return GH.Delete(JDB);
            }


            public static bool Find(int pCode)
            {
                JWarGoodRequestDetailsTable GH = new JWarGoodRequestDetailsTable();
                return GH.Find(pCode);
            }

            public bool GetData(int pCode)
            {
                JWarGoodRequestDetailsTable GH = new JWarGoodRequestDetailsTable();
                return GH.GetData(this, pCode);
            }
        
        #endregion

        /// <summary>
        /// فیلتر کردن کالاهای درخواست 
        /// </summary>
        /// <param name="GRCode">کد درخواست</param>
        /// <returns></returns>
            public static DataTable GetDataTableByGRCode(int GRCode)
            {
                ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
                try
                {
                    db.setQuery(@"Select wrgd.Code, wtog.Name, wrgd.Count
                                ,wrgd.GoodTypeCode
                            From WarGoodRequestDetails wrgd
                                LEFT JOIN WarTypesOfGoods wtog ON (wtog.Code = wrgd.GoodTypeCode) Where wrgd.GRCode =  " + GRCode);
                    return db.Query_DataTable();
                }
                finally
                {
                    db.Dispose();
                }
            }
    }

    public class JWarGoodRequestDetailsTable: ClassLibrary.JTable
    {

        public int GRCode;

        public int GoodTypeCode;
        
        public int Count;
        
        public JWarGoodRequestDetailsTable()
            : base("WarGoodRequestDetails") { }
            
    }
}
