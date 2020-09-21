using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WarehouseManagement.Goods
{

    public enum JStatusOfGoods
    {
        /// <summary>
        /// سالم
        /// </summary>
        Healthy = 1,
        /// <summary>
        /// خراب
        /// </summary>
        Bad = 2,
        /// <summary>
        /// اسقاط
        /// </summary>
        Plant = 3,
    }

    public class JGoods
    {
        public int Code { get; set; }
        /// <summary>
        /// نوع کالا
        /// </summary>
        public int TypeOfGoodsCode { get; set; }
        public string Serial { get; set; }
        public string Model { get; set; }

        /// <summary>
        /// سازنده
        ///با نظر شخص مهندس زرین تغییر در سازنده ایجاد شد
        ///و از جدول اشخاص اورده شد
        /// </summary>
        //public int ManufacturerCode { get; set; }
        public int PersonCode { get; set; }
        public int YearBuilt { get; set; }
        // public int WarehouseCode { get; set; }
        public JStatusOfGoods StatusOfGoods { get; set; }

        public string Description { get; set; }

        public string GoodName
        {
            get
            {
                JTypesOfGoods typesOfGoods = new JTypesOfGoods();
                typesOfGoods.GetData(this.TypeOfGoodsCode);
                return typesOfGoods.Name;
            }
        }

        public int Insert()
        {
            JGoodsTable GH = new JGoodsTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public int Insert(int WarehouseCode)
        {
            ClassLibrary.JDataBase JDB = new ClassLibrary.JDataBase();
            try
            {
                JGoodsTable GH = new JGoodsTable();
                GH.SetValueProperty(this);
                JReceiptOfGoodsTable ROG = new JReceiptOfGoodsTable();
                JReceiptOfGoodsDetailsTable ROG_Detail = new JReceiptOfGoodsDetailsTable();
                Warehouse.JWarehouse Wr = new Warehouse.JWarehouse();

                DataTable Rec_dt = Goods.JReceiptOfGoodSes.GetData("WarehouseManagement.Goods", Code);

                Wr.GetData(WarehouseCode);
                if (JDB.beginTransaction("Receipt_Goods"))
                {
                    GH.SetValueProperty(this);
                    GH.Code = GH.Insert(JDB);
                    int ReceiptOfGoodsCode = 0;
                    if (!ROG.GetData("WebOilManagement.JWebFailure.Hale", Code))
                    {
                        #region JReceiptOfGoodsInsert

                        ROG.DeliveryPersonCode = Wr.OwnerCode;
                        ROG.ReceiptDate = DateTime.Now;
                        ROG.RegisterDate = DateTime.Now;
                        ROG.TransfereePersonCode = Wr.OwnerCode;
                        ROG.WarehouseCode = WarehouseCode;
                        ROG.class_Name = "WarehouseManagement.Goods";
                        ROG.object_code = GH.Code;
                        ReceiptOfGoodsCode = ROG.Insert(JDB);

                        #endregion JReceiptOfGoodsInsert
                    }
                    else
                        ReceiptOfGoodsCode = (int)Rec_dt.Rows[0]["Code"];

                    #region JReceiptOfGoodsDetailInsert

                    ROG_Detail.ReceiptOfGoodsCode = ReceiptOfGoodsCode;
                    ROG_Detail.GoodsCode = GH.Code;
                    ROG_Detail.Number = 1;
                    ROG_Detail.RegisterDate = DateTime.Now;
                    ROG_Detail.Insert(JDB);

                    #endregion JReceiptOfGoodsDetailInsert

                    if (JDB.Commit())
                        return GH.Code;
                }
                return 0;
            }
            finally
            {
                JDB.Dispose();
            }
        }


        public bool Update()
        {
            JGoodsTable GH = new JGoodsTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JGoodsTable GH = new JGoodsTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JGoodsTable GH = new JGoodsTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JGoodsTable GH = new JGoodsTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JGoodSes
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"			Select wgoods.*,WTOG.HasSerial AS HasSerial,WTOG.Description AS Description From warGoods wgoods
													LEFT JOIN WarTypesOfGoods WTOG ON(WTOG.Code = wgoods.TypeOfGoodsCode)");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
            //JGoodsTable GH = new JGoodsTable();
            //return GH.GetDataTable(pCode);
        }
        public static int GetGoodStock(int GoodCode, int WarehouseCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"SELECT	
								  (SELECT ISNULL(Sum(wrogd.Number),0) FROM WarReceiptOfGoodsDetails wrogd  LEFT JOIN WarGoods WG1 ON (WG1.Code=wrogd.GoodsCode) 
                                      LEFT JOIN WarReceiptOfGoods WROG ON (WROG.Code=wrogd.ReceiptOfGoodsCode)
                                   WHERE wrogd.GoodsCode = " + GoodCode + @" AND WROG.WarehouseCode =  " + WarehouseCode + @") - 
								  (SELECT ISNULL(Sum(wrgd.Number),0) FROM WarBillOfGoodsDetails wrgd  LEFT JOIN WarGoods WG2 ON (WG2.Code=wrgd.GoodsCode)
                                      LEFT JOIN WarBillOfGoods WBOG ON (WBOG.Code=wrgd.BillOfGoodsCode)
                                   WHERE wrgd.GoodsCode  = " + GoodCode + @" AND WBOG.WarehouseCode =  " + WarehouseCode + @")");
                DataTable dt = db.Query_DataTable();
                if (dt != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            finally
            {
                db.Dispose();
            }

        }

        public static int GetGoodStock(int GoodCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"SELECT (SELECT ISNULL(Sum(wrogd.Number),0) FROM WarReceiptOfGoodsDetails wrogd
                                WHERE wrogd.GoodsCode = " + GoodCode + @") - (SELECT ISNULL(Sum(wrgd.Number),0) FROM WarBillOfGoodsDetails wrgd
                                WHERE wrgd.GoodsCode  = " + GoodCode + ")");
                DataTable dt = db.Query_DataTable();
                if (dt != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            finally
            {
                db.Dispose();
            }

        }

        public static string GetWebQuery()
        {
            JGoodsTable GH = new JGoodsTable();
            return "SELECT WG.Code"
                      + " ,WG.TypeOfGoodsCode"
                      + " ,WTOG.Name AS TypeOfGoodsName"
                      + " ,WG.Serial"
                      + " ,WG.Model"
                      + " ,WG.PersonCode AS ManufacturerCode"
                      + " ,CP.name AS ManufacturerName"
                      + " ,WG.YearBuilt"
                     // + " ,WG.StatusOfGoods"
                      + " ,WG.Description"
                     // + " ,WG.GoodsHierarchyCode"
                + "  FROM WarGoods WG"
                + "  LEFT JOIN WarTypesOfGoods WTOG ON(WG.TypeOfGoodsCode = WTOG.Code)"
                + "  LEFT JOIN clsAllPerson CP ON(CP.code = WG.PersonCode)";
        }

        public static int FindBySerial(int GoodCode, int WarehouseCode, int Serial)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"SELECT	
								  (SELECT ISNULL(Sum(wrogd.Number),0) FROM WarReceiptOfGoodsDetails wrogd  LEFT JOIN WarGoods WG1 ON (WG1.Code=wrogd.GoodsCode) 
                                      LEFT JOIN WarReceiptOfGoods WROG ON (WROG.Code=wrogd.ReceiptOfGoodsCode)
                                   WHERE wrogd.GoodsCode = " + GoodCode + @" AND WROG.WarehouseCode =  " + WarehouseCode + @") - 
								  (SELECT ISNULL(Sum(wrgd.Number),0) FROM WarBillOfGoodsDetails wrgd  LEFT JOIN WarGoods WG2 ON (WG2.Code=wrgd.GoodsCode)
                                      LEFT JOIN WarBillOfGoods WBOG ON (WBOG.Code=wrgd.BillOfGoodsCode)
                                   WHERE wrgd.GoodsCode  = " + GoodCode + @" AND WBOG.WarehouseCode =  " + WarehouseCode + @")
                                   ,  Code From WarGoods where WarGoods.Serial=" + Serial);

                //                @"SELECT	
                //                    (SELECT ISNULL(Sum(wrogd.Number),0) FROM WarReceiptOfGoodsDetails wrogd  LEFT JOIN WarGoods WG1 ON (WG1.Code=wrogd.GoodsCode) 
                //                            LEFT JOIN WarReceiptOfGoods WROG ON (WROG.Code=wrogd.ReceiptOfGoodsCode)
                //                    WHERE wrogd.GoodsCode = 1 AND WROG.WarehouseCode =  1  )-
                //                    (SELECT ISNULL(Sum(wrgd.Number),0) FROM WarBillOfGoodsDetails wrgd  LEFT JOIN WarGoods WG2 ON (WG2.Code=wrgd.GoodsCode)
                //                            LEFT JOIN WarBillOfGoods WBOG ON (WBOG.Code=wrgd.BillOfGoodsCode)
                //                    WHERE wrgd.GoodsCode  = 1 AND WBOG.WarehouseCode = 1 ) ,  Code From WarGoods where WarGoods.Serial=11111";
                DataTable dt = db.Query_DataTable();
                if (dt != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static int FindBySerial(int Serial)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"SELECT * From WarGoods  where WarGoods.Serial=" + Serial);

               
                DataTable dt = db.Query_DataTable();
                if (dt != null && dt.Rows.Count > 0)
                    return  Convert.ToInt32(dt.Rows[0]["Code"].ToString());
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetData(int pCode)
        {
            JGoodsTable GH = new JGoodsTable();
            return GH.GetDataTable(pCode);
        }
    }

    public class JGoodsTable : ClassLibrary.JTable
    {
        public int TypeOfGoodsCode;
        public string Serial;
        public string Model;
        /// <summary>
        /// سازنده
        /// </summary>
        public int PersonCode;
        public int YearBuilt;
        //public int WarehouseCode;
        public JStatusOfGoods StatusOfGoods;
        public string Description;
        public JGoodsTable()
            : base("WarGoods")
        {
        }
    }
}

