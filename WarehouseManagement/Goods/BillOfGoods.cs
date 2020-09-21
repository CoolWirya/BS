using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WarehouseManagement.Goods
{
    /// <summary>
    /// وضعیت های سند حواله خروج
    /// </summary>
    public enum JStatusBillOfGoods
    {
        Draft = 1,
        Send = 2,
    }

    /// <summary>
    /// رسید کالا
    /// </summary>
    public class JBillOfGoods
    {
        public int Code { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public int DeliveryPersonCode { get; set; }
        public int TransfereePersonCode { get; set; }
        public int WarehouseCode { get; set; }
        public string class_Name { get; set; }
        public int object_code { get; set; }
        //public int WarGoodsCode { get; set; }
        public int AimWearCode { get; set; }

        /// <summary>
        /// وضعیت 
        /// 1.پیش نویس
        /// 2.ارسال شده ....
        /// </summary>
        public short Status { get; set; }

        public int Insert()
        {
            JBillOfGoodsTable GH = new JBillOfGoodsTable();
            GH.SetValueProperty(this);
            int result = GH.Insert();
            if (result > 0)
            {
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("WarehouseManagement.Goods", 1, result, 0, 0, "حواله خروج", "", new ClassLibrary.JDataBase());
            }
            return result;
        }

        public bool Update()
        {
            JBillOfGoodsTable GH = new JBillOfGoodsTable();
            GH.SetValueProperty(this);
            bool result = GH.Update();
            if (result)
            {
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("WarehouseManagement.Goods", 1, this.Code, 0, 0, "حواله خروج", "بروزرسانی", new ClassLibrary.JDataBase());
            }
            return result;
        }

        public bool Delete()
        {
            JBillOfGoodsTable GH = new JBillOfGoodsTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JBillOfGoodsTable GH = new JBillOfGoodsTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JBillOfGoodsTable GH = new JBillOfGoodsTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JBillOfGoodSes
    {
        public static DataTable GetData()
        {
            return GetData(0);
        }

        public static DataTable GetData(int pCode)
        {
            JBillOfGoodsTable GH = new JBillOfGoodsTable();
            return GH.GetDataTable(pCode);
        }

        public static DataTable GetData(string class_Name, int object_code)
        {
            ClassLibrary.JDataBase JDB = new ClassLibrary.JDataBase();

            if (object_code >= 0)
                JDB.setQuery(@"SELECT * FROM WarBillOfGoods WHERE class_Name=" + class_Name + " AND  object_code=" + object_code);
            else
                JDB.setQuery(@"SELECT * FROM WarBillOfGoods WHERE class_Name Not Like N'%" + class_Name.Replace("'", string.Empty) + "%' OR  object_code <> WarBillOfGoods.Code ");

            DataTable Dt = JDB.Query_DataTable();
            int Code = 0;
            if (Dt != null && Dt.Rows.Count > 0 && Dt.Rows[0]["Code"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["Code"].ToString()) && object_code != -1)
            {
                Code = int.Parse(Dt.Rows[0]["Code"].ToString());
                JBillOfGoodsTable GH = new JBillOfGoodsTable();
                return GH.GetDataTable(Code);
            }
            else
                return Dt;

        }

        public static string GetWebQuery()
        {
            // JBillOfGoodsTable BG = new JBillOfGoodsTable();
            string Query =
             @"SELECT WBOG.Code,WBOG.BillDate,WBOG.RegisterDate,Case Status When 2 Then 'تایید شده' else 'پیش نویس' end AS [وضعیت],WWH.Name AS WarehouseName,WWH2.Name AS AimWarehouseName
		                ,CAP.Name  AS DeliveryPersonName
		                ,CAP2.Name AS TransfereePersonName 
		     FROM WarBillOfGoods WBOG
			        LEFT JOIN clsAllPerson CAP   ON(CAP.Code   =     WBOG.DeliveryPersonCode)
			        LEFT JOIN clsAllPerson CAP2  ON(CAP2.Code  =   WBOG.TransfereePersonCode)
                    LEFT JOIN WarWarehouse WWH   ON(WWH.Code   =          WBOG.WarehouseCode)
                    LEFT JOIN WarWarehouse WWH2  ON(WWH2.Code  =            WBOG.AimWearCode)
                    Where " + ClassLibrary.JPermission.getObjectSql("WarehouseManagement.Warehouse.JWarehousees", "WWH.Code");
            //return BG.CreateQuery("");
            return Query;
        }


        //public static DataTable GetBillsOfAimWarehouse(string AimWearCode)
        //{
        //    ClassLibrary.JDataBase JDB = new ClassLibrary.JDataBase();
        //    JDB.setQuery(@"SELECT Code FROM WarBillOfGoods WHERE class_Name=" + class_Name + " AND  object_code=" + object_code);
        //    DataTable Dt = JDB.Query_DataTable();
        //    int Code = 0;
        //    if (Dt != null && Dt.Rows.Count > 0 && Dt.Rows[0]["Code"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["Code"].ToString()))
        //    {
        //        Code = int.Parse(Dt.Rows[0]["Code"].ToString());
        //        JBillOfGoodsTable GH = new JBillOfGoodsTable();
        //        return GH.GetDataTable(Code);
        //    }
        //    else
        //        return new DataTable();
        //}
    }

    public class JBillOfGoodsTable : ClassLibrary.JTable
    {
        public DateTime BillDate;
        public DateTime RegisterDate;
        public int DeliveryPersonCode;
        public int TransfereePersonCode;
        public int WarehouseCode;
        public string class_Name;
        public int object_code;
        // public int WarGoodsCode;
        public int AimWearCode;
        /// <summary>
        /// وضعیت 
        /// 1.پیش نویس
        /// 2.ارسال شده ....
        /// </summary>
        public short Status;
        public JBillOfGoodsTable()
            : base("WarBillOfGoods")
        {
        }
    }


    public class JBillOfGoodsDetails
    {
        public int Code { get; set; }
        public int BillOfGoodsCode { get; set; }
        public int GoodsCode { get; set; }
        /// <summary>
        /// فقط برای کالاهایی که سریال ندارند
        /// </summary>
        public int Number { get; set; }
        ///// <summary>
        ///// سریال کالا
        ///// </summary>
        //public int WarGoodsCode{get;set;}
        public DateTime RegisterDate { get; set; }

        public int Insert()
        {
            JBillOfGoodsDetailsTable GH = new JBillOfGoodsDetailsTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool update()
        {
            JBillOfGoodsDetailsTable GH = new JBillOfGoodsDetailsTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JBillOfGoodsDetailsTable GH = new JBillOfGoodsDetailsTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JBillOfGoodsDetailsTable GH = new JBillOfGoodsDetailsTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JBillOfGoodsDetailsTable GH = new JBillOfGoodsDetailsTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JBillOfGoodsDetailSes
    {
        public static DataTable GetData()
        {
            return GetData(0);
        }

        public static DataTable GetData(int pCode)
        {
            JBillOfGoodsDetailsTable GH = new JBillOfGoodsDetailsTable();
            return GH.GetDataTable(pCode);
        }

        public static DataTable GetDataTableByBillOfGoodsCode(int BillOfGoodsCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"Select wrgd.Code as BillOfGoodsCode, wg.Description, wrgd.Number,wg.Code As GoodsCode,
                            (Select Fa_Date from StaticDates where En_Date = Cast(wrgd.RegisterDate as date))+ '<br/>' +CONVERT(varchar,convert(time(0),wrgd.RegisterDate)) AS 'RegisterDate'
                            ,wg.Serial,wtog.Name From WarBillOfGoodsDetails wrgd
                            LEFT JOIN WarGoods wg ON (wg.Code = wrgd.GoodsCode)
                            LEFT JOIN WarTypesOfGoods wtog ON (wtog.Code = wg.TypeOfGoodsCode) Where wrgd.BillOfGoodsCode = " + BillOfGoodsCode);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
    }

    public class JBillOfGoodsDetailsTable : ClassLibrary.JTable
    {
        public int BillOfGoodsCode;
        public int GoodsCode;
        /// <summary>
        /// فقط برای کالاهایی که سریال ندارند
        /// </summary>
        public int Number;
        public DateTime RegisterDate;


        public JBillOfGoodsDetailsTable()
            : base("WarBillOfGoodsDetails")
        {
        }
    }
}
