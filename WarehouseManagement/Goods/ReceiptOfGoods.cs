using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WarehouseManagement.Goods
{
    /// <summary>
    /// رسید کالا
    /// </summary>
    public class JReceiptOfGoods
    {
        public int Code { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public int DeliveryPersonCode { get; set; }
        public int TransfereePersonCode { get; set; }
        public int WarehouseCode { get; set; }
        public string class_Name { get; set; }
        public int object_code { get; set; }

        public int Insert()
        {
            JReceiptOfGoodsTable GH = new JReceiptOfGoodsTable();
            GH.SetValueProperty(this);
            int result = GH.Insert();
            if (result > 0)
            {
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("WarehouseManagement.Goods", 2, result, 0, 0, "برگه ورود", "", new ClassLibrary.JDataBase());
            }
            return result;
        }

        public bool Update()
        {
            JReceiptOfGoodsTable GH = new JReceiptOfGoodsTable();
            GH.SetValueProperty(this);
            bool result = GH.Update();
            if (result)
            {
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("WarehouseManagement.Goods", 2, this.Code, 0, 0, "حواله خروج", "بروزرسانی", new ClassLibrary.JDataBase());
            }
            return result;
        }

        public bool Delete()
        {
            JReceiptOfGoodsTable GH = new JReceiptOfGoodsTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JReceiptOfGoodsTable GH = new JReceiptOfGoodsTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JReceiptOfGoodsTable GH = new JReceiptOfGoodsTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JReceiptOfGoodSes
    {
        public static DataTable GetDataTable(int pCode = 0)
        {
            JReceiptOfGoodsTable GH = new JReceiptOfGoodsTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            string Query =
            @"SELECT WROG.Code,WROG.ReceiptDate,WROG.RegisterDate
		            ,CAP.Name  AS DeliveryPersonName
		            ,CAP2.Name AS TransfereePersonName 
                   ,WWH.Name AS WarehouseName
		     FROM WarReceiptOfGoods WROG
			        LEFT JOIN clsAllPerson CAP  ON(CAP.Code  =     WROG.DeliveryPersonCode)
			        LEFT JOIN clsAllPerson CAP2 ON(CAP2.Code =   WROG.TransfereePersonCode)
                    LEFT JOIN WarWarehouse WWH   ON(WWH.Code   =          WROG.WarehouseCode)
                    Where " + ClassLibrary.JPermission.getObjectSql("WarehouseManagement.Warehouse.JWarehousees", "WWH.Code");
            return Query;
        }

        public static DataTable GetData(string class_Name, int object_code)
        {
            ClassLibrary.JDataBase JDB = new ClassLibrary.JDataBase();

            if (object_code >= 0)
                JDB.setQuery(@"SELECT * FROM WarReceiptOfGoods WHERE class_Name=" + class_Name + " AND  object_code=" + object_code);
            else
                JDB.setQuery(@"SELECT * FROM WarReceiptOfGoods WHERE class_Name Not Like N'%" + class_Name.Replace("'", string.Empty) + "%' OR  object_code <> WarReceiptOfGoods.Code ");

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

    }

    public class JReceiptOfGoodsTable : ClassLibrary.JTable
    {
        public DateTime ReceiptDate;
        public DateTime RegisterDate;
        public int DeliveryPersonCode;
        public int TransfereePersonCode;
        public int WarehouseCode;
        public string class_Name;
        public int object_code;

        public JReceiptOfGoodsTable()
            : base("WarReceiptOfGoods")
        {
        }
    }


    public class JReceiptOfGoodsDetails
    {
        public int Code { get; set; }
        public int ReceiptOfGoodsCode { get; set; }
        public int GoodsCode { get; set; }
        /// <summary>
        /// فقط برای کالاهایی که سریال ندارند
        /// </summary>
        public int Number { get; set; }

        public DateTime RegisterDate { get; set; }

        public int Insert()
        {
            JReceiptOfGoodsDetailsTable GH = new JReceiptOfGoodsDetailsTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool update()
        {
            JReceiptOfGoodsDetailsTable GH = new JReceiptOfGoodsDetailsTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JReceiptOfGoodsDetailsTable GH = new JReceiptOfGoodsDetailsTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JReceiptOfGoodsDetailsTable GH = new JReceiptOfGoodsDetailsTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JReceiptOfGoodsDetailsTable GH = new JReceiptOfGoodsDetailsTable();
            return GH.GetData(this, pCode);
        }

        public static DataTable GetData(string class_Name, int object_code)
        {
            ClassLibrary.JDataBase JDB = new ClassLibrary.JDataBase();
            JDB.setQuery(@"SELECT Code FROM WarReceiptOfGoods WHERE class_Name=" + class_Name + " AND  object_code=" + object_code);
            DataTable Dt = JDB.Query_DataTable();
            int Code = 0;
            if (Dt.Rows[0]["Code"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["Code"].ToString()))
            {
                Code = int.Parse(Dt.Rows[0]["Code"].ToString());
                JBillOfGoodsTable GH = new JBillOfGoodsTable();
                return GH.GetDataTable(Code);
            }
            else
                return new DataTable();

        }

        public bool GetDataByReceiptOfGoodsCode(int pReceiptOfGoodsCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("SELECT TOP 1 * FROM WarReceiptOfGoodsDetails WHERE ReceiptOfGoodsCode = " + pReceiptOfGoodsCode);
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
            return false;
        }
    }

    public class JReceiptOfGoodsDetailSes
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JReceiptOfGoodsDetailsTable GH = new JReceiptOfGoodsDetailsTable();
            return GH.GetDataTable(pCode);
        }

        public static DataTable GetDataTableByReceiptOfGoodsCode(int ReceiptOfGoodsCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"Select wrgd.Code, wg.Description, wrgd.Number
                            ,(Select Fa_Date from StaticDates where En_Date = Cast(wrgd.RegisterDate as date))+ '<br/>' +CONVERT(varchar,convert(time(0),wrgd.RegisterDate)) AS 'RegisterDate' 
                            ,wg.serial From WarReceiptOfGoodsDetails wrgd
                            LEFT JOIN WarGoods wg ON (wg.Code = wrgd.GoodsCode)
                            LEFT JOIN WarTypesOfGoods wtog ON (wtog.Code = wg.TypeOfGoodsCode) Where wrgd.ReceiptOfGoodsCode = " + ReceiptOfGoodsCode );
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
    }

    public class JReceiptOfGoodsDetailsTable : ClassLibrary.JTable
    {
        public int ReceiptOfGoodsCode;
        public int GoodsCode;
        /// <summary>
        /// فقط برای کالاهایی که سریال ندارند
        /// </summary>
        public int Number;
        public DateTime RegisterDate;

        public JReceiptOfGoodsDetailsTable()
            : base("WarReceiptOfGoodsDetails")
        {
        }
    }
}
