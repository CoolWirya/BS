using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WarehouseManagement.Warehouse
{
    public class JWarehouse
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int OwnerCode { get; set; }
        /// <summary>
        /// مسئول انبار
        /// </summary>
        public int StockClerk { get; set; }

        public int Insert()
        {
            JWarehouseTable GH = new JWarehouseTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public int Insert(string _Name, int _OwnerCode, int _StockClerk)
        {
            JWarehouseTable GH = new JWarehouseTable();
            GH.Name = _Name;
            GH.OwnerCode = _OwnerCode;
            GH.StockClerk = _StockClerk;

            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool Update()
        {
            JWarehouseTable GH = new JWarehouseTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JWarehouseTable GH = new JWarehouseTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JWarehouseTable GH = new JWarehouseTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JWarehouseTable GH = new JWarehouseTable();
            return GH.GetData(this, pCode);
        }

    }

    public class JWarehousees
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTableVsPermision()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {

                db.setQuery(@"SELECT * FROM WarWarehouse
                                WHERE " + ClassLibrary.JPermission.getObjectSql("WarehouseManagement.Warehouse.JWarehousees", "Code"));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }


        public static string GetQueryVsPermision()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {

                return @"SELECT * FROM WarWarehouse
                                WHERE " + ClassLibrary.JPermission.getObjectSql("WarehouseManagement.Warehouse.JWarehousees", "Code");

            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetDataTable(int pCode)
        {
            JWarehouseTable GH = new JWarehouseTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            JWarehouseTable GH = new JWarehouseTable();
            return "   SELECT WW.[Code]"
                        + "  ,WW.[Name]"
                        + "  ,WW.[OwnerCode],CP.Name AS OwnerName"
                        + "  ,WW.[StockClerk] ,CP2.Name AS ClerkName"
                    + "  FROM WarWarehouse WW"
                    + "  LEFT JOIN clsAllPerson CP on(Cp.Code = WW.OwnerCode)"
                    + "  LEFT JOIN clsAllPerson CP2 on(CP2.Code = WW.StockClerk)";
        }

        /// <summary>
        /// گزارش گیری از تجهیزات در گردش بین انبارها
        /// </summary>
        /// <param name="AreaCode"></param>
        /// <param name="OilZoneCode"></param>
        /// <param name="Supplier"></param>
        /// <param name="TypeOfGoodcode"></param>
        /// <param name="AsDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public static string PerforemanceStoresFlowReport(int Supplier = 0, DateTime? AsDate = null, DateTime? ToDate = null)
        {

            string query = string.Empty;

            StringBuilder where = new StringBuilder();
            DateTime StartDTime = new DateTime(AsDate.Value.Year, AsDate.Value.Month, AsDate.Value.Day, 0, 0, 0);
            DateTime EndDTime = new DateTime(ToDate.Value.Year, ToDate.Value.Month, ToDate.Value.Day, 23, 59, 59);

            #region Initial Where Query

            if (Supplier > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" and ");

                where.Append(" os.code = " + Supplier.ToString());
            }

            /////___________________________________________-

            if (AsDate != null && ToDate != null)
            {
                where.Append("WHERE ");
                where.Append("r.date between ");
                where.Append("'" + StartDTime.ToString() + "'");
                where.Append(" AND ");
                where.Append("'" + EndDTime.ToString() + "'");
            }

            #endregion Initial Where Query

            #region Query


            query = @"select r.Code, r.date, r.bill_code, r.receipt_code,r.from_stock,r.to_stock, r.good, r.Number, r.letter_ltatus,r.receipt_status 
                    from  (SELECT DISTINCT
                        wwh.Code,
	                    wbg.BillDate date,
	                    wbg.Code bill_code,
	                    wrg.Code receipt_code,
	                    (select name from WarWarehouse where wwh.Code=wbg.WarehouseCode) from_stock,
	                    (select name from WarWarehouse where wwh.Code=wrg.WarehouseCode) to_stock,
	                    (wtg.Name + ' - ' + wg.Description) good,wbgd.Number,
	                    CASE wbg.Status WHEN 2 THEN 'تائید شده' ELSE 'پیش نویس' END letter_ltatus,
	                    'رسید شده' receipt_status
                    FROM
	                    WarWarehouse wwh
	                    INNER JOIN WarBillOfGoods wbg ON wwh.Code = wbg.WarehouseCode
	                    INNER JOIN WarBillOfGoodsDetails wbgd ON wbg.Code = wbgd.BillOfGoodsCode
	                    INNER JOIN WarGoods wg ON wg.Code = wbgd.Code
	                    INNER JOIN WarTypesOfGoods wtg ON wtg.Code = wg.TypeOfGoodsCode
	                    INNER JOIN WarReceiptOfGoods wrg ON wrg.WarehouseCode = wbg.AimWearCode AND wrg.class_Name = wbg.class_Name AND wbg.Code = wrg.object_code
                    WHERE
	                    wbg.class_Name = 'WebWarehouseManagement.JWebWarehouseManagement'
                    UNION ALL
                    SELECT DISTINCT
                        wwh.Code,
	                    wbg.BillDate date,
	                    wbg.Code bill_code,
	                    wrg.Code receipt_code,
	                    (select name from WarWarehouse where wwh.Code=wbg.WarehouseCode) from_stock,
	                    (select name from WarWarehouse where wwh.Code=wrg.WarehouseCode) to_stock,
	                    (wtg.Name + ' - ' + wg.Description) good,wbgd.Number,
	                    CASE wbg.Status WHEN 2 THEN 'تائید شده' ELSE 'پیش نویس' END letter_ltatus,
	                    'معلق' receipt_status
                    FROM
	                    WarWarehouse wwh
	                    INNER JOIN WarBillOfGoods wbg ON wwh.Code = wbg.WarehouseCode
	                    INNER JOIN WarBillOfGoodsDetails wbgd ON wbg.Code = wbgd.BillOfGoodsCode
	                    INNER JOIN WarGoods wg ON wg.Code = wbgd.Code
	                    INNER JOIN WarTypesOfGoods wtg ON wtg.Code = wg.TypeOfGoodsCode
	                    INNER JOIN WarReceiptOfGoods wrg ON wrg.WarehouseCode = wbg.AimWearCode
                    WHERE
	                    wbg.class_Name = 'WebWarehouseManagement.JWebWarehouseManagement' AND wbg.Code != wrg.object_code
                    ) r inner join OilSupplier os on r.Code=os.Code ";

            query += where.ToString();

            #endregion Query

            return query;
        }

        /// <summary>
        /// رویت رویدادهای یک قطعه در طول یک بازه زمانی
        /// </summary>
        /// <param name="WareHouseCode"></param>
        /// <param name="TypeOfGoodcode"></param>
        /// <param name="AsDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public static string PeriodicPartReaderEventReport(int WareHouseCode = 0, int TypeOfGoodcode = 0, DateTime? AsDate = null, DateTime? ToDate = null)
        {
            return "";
        }

        /// <summary>
        /// گزارش گیري مقایسه ای بین مصارف تجهیزات و گردش انبار
        /// </summary>
        /// <param name="WareHouseCode"></param>
        /// <param name="TypeOfGoodcode"></param>
        /// <param name="AsDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public static string UsedMaterielVsStoreFlowReport(int AreaCode = 0, int OilZoneCode = 0, DateTime? AsDate = null, DateTime? ToDate = null)
        {

            string Query = string.Empty;
            StringBuilder where = new StringBuilder();
            DateTime StartDTime = new DateTime(AsDate.Value.Year, AsDate.Value.Month, AsDate.Value.Day, 0, 0, 0);
            DateTime EndDTime = new DateTime(ToDate.Value.Year, ToDate.Value.Month, ToDate.Value.Day, 23, 59, 59);

            #region Initial Where Query

            ///___________________________________________-
            if (where.Length == 0)
                where.Append(" WHERE oar.FixDefects = 1 ");
            else
                where.Append(" AND ");


            if (AreaCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");

                where.Append(" OA.Code = " + AreaCode.ToString());
            }

            ///___________________________________________-
            if (OilZoneCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" oz.Code = " + OilZoneCode.ToString());
            }
            ///___________________________________________-

            #endregion Initial Where Query


            #region Query

            #region Old Query
            //            Query = @";WITH TemporaryTable AS 
            //                    (
            //                    SELECT * FROM(
            //	                    SELECT DISTINCT
            //	                    (select code from WarWarehouse where code=wbg.WarehouseCode) WarHouse,
            //	                    (select name from WarWarehouse where Code=wbg.WarehouseCode) from_stock,
            //	                    (select name from WarWarehouse where Code=wrg.WarehouseCode) to_stock,
            //	                    wtg.Name + ' - ' + wg.Description good
            //                    FROM
            //	                    WarWarehouse wwh
            //	                    INNER JOIN WarBillOfGoods wbg ON wwh.Code = wbg.WarehouseCode
            //	                    INNER JOIN WarBillOfGoodsDetails wbgd ON wbg.Code = wbgd.BillOfGoodsCode
            //	                    INNER JOIN WarGoods wg ON wg.Code = wbgd.Code
            //	                    INNER JOIN WarTypesOfGoods wtg ON wtg.Code = wg.TypeOfGoodsCode
            //	                    INNER JOIN WarReceiptOfGoods wrg ON wrg.WarehouseCode = wbg.AimWearCode AND wrg.class_Name = wbg.class_Name AND wbg.Code = wrg.object_code
            //                    WHERE
            //	                    wbg.class_Name = 'WebWarehouseManagement.JWebWarehouseManagement'
            //                    UNION ALL
            //                    SELECT DISTINCT
            //	                    (select code from WarWarehouse where code=wbg.WarehouseCode) WarHouse,
            //	                    (select name from WarWarehouse where Code=wbg.WarehouseCode) from_stock,
            //	                    (select name from WarWarehouse where Code=wrg.WarehouseCode) to_stock,
            //	                    wtg.Name + ' - ' + wg.Description good
            //                    FROM
            //	                    WarWarehouse wwh
            //	                    INNER JOIN WarBillOfGoods wbg ON wwh.Code = wbg.WarehouseCode
            //	                    INNER JOIN WarBillOfGoodsDetails wbgd ON wbg.Code = wbgd.BillOfGoodsCode
            //	                    INNER JOIN WarGoods wg ON wg.Code = wbgd.Code
            //	                    INNER JOIN WarTypesOfGoods wtg ON wtg.Code = wg.TypeOfGoodsCode
            //	                    INNER JOIN WarReceiptOfGoods wrg ON wrg.WarehouseCode = wbg.AimWearCode
            //                    WHERE
            //	                    wbg.class_Name = 'WebWarehouseManagement.JWebWarehouseManagement' AND wbg.Code != wrg.object_code) TBS
            //	                    INNER JOIN
            //	                    (SELECT 
            //	                    ogs.WarCode WarHouseCode
            //	                    ,omf.InsertDate
            //                    FROM 
            //	                    oilzone oz
            //	                    INNER JOIN OilArea oa on oa.OilZoneCode = oz.Code
            //	                    INNER JOIN OilGasStation ogs on ogs.OilAreaCode = oa.Code
            //	                    INNER JOIN OilSupplierDetails osd on osd.ZoneCode = oz.Code
            //	                    INNER JOIN OilSupplier os on os.Code = osd.SupplierCode 
            //	                    INNER JOIN clsAllPerson p on p.Code = os.PCode
            //	                    INNER JOIN OilMalfunction omf on omf.GasStationCode = ogs.Code 		
            //	                    INNER JOIN OilHardwareRepair ohr on ohr.MalfunctionCode = omf.Code
            //	                    INNER JOIN OilAfterReviewing oar on oar.MalfunctionCode = omf.Code 
            //                    ";
            #endregion Old Query

            Query = @"SELECT ROW_NUMBER() over(order by good)as code, from_stock, to_stock, good , count(good)AS CountOfGood FROM (SELECT * FROM(
	                SELECT DISTINCT
	                (select code from WarWarehouse where code=wbg.WarehouseCode) WarHouse,
	                (select name from WarWarehouse where Code=wbg.WarehouseCode) from_stock,
	                (select name from WarWarehouse where Code=wrg.WarehouseCode) to_stock,
	                wtg.Name + ' - ' + wg.Description good
                FROM
	                WarWarehouse wwh
	                INNER JOIN WarBillOfGoods wbg ON wwh.Code = wbg.WarehouseCode
	                INNER JOIN WarBillOfGoodsDetails wbgd ON wbg.Code = wbgd.BillOfGoodsCode
	                INNER JOIN WarGoods wg ON wg.Code = wbgd.Code
	                INNER JOIN WarTypesOfGoods wtg ON wtg.Code = wg.TypeOfGoodsCode
	                INNER JOIN WarReceiptOfGoods wrg ON wrg.WarehouseCode = wbg.AimWearCode AND wrg.class_Name = wbg.class_Name AND wbg.Code = wrg.object_code
                WHERE
	                wbg.class_Name = 'WebWarehouseManagement.JWebWarehouseManagement'
                UNION ALL
                SELECT DISTINCT
	                (select code from WarWarehouse where code=wbg.WarehouseCode) WarHouse,
	                (select name from WarWarehouse where Code=wbg.WarehouseCode) from_stock,
	                (select name from WarWarehouse where Code=wrg.WarehouseCode) to_stock,
	                wtg.Name + ' - ' + wg.Description good
                FROM
	                WarWarehouse wwh
	                INNER JOIN WarBillOfGoods wbg ON wwh.Code = wbg.WarehouseCode
	                INNER JOIN WarBillOfGoodsDetails wbgd ON wbg.Code = wbgd.BillOfGoodsCode
	                INNER JOIN WarGoods wg ON wg.Code = wbgd.Code
	                INNER JOIN WarTypesOfGoods wtg ON wtg.Code = wg.TypeOfGoodsCode
	                INNER JOIN WarReceiptOfGoods wrg ON wrg.WarehouseCode = wbg.AimWearCode
                WHERE
	                wbg.class_Name = 'WebWarehouseManagement.JWebWarehouseManagement' AND wbg.Code != wrg.object_code) TBS
	                INNER JOIN
	                (SELECT 
	                ogs.WarCode WarHouseCode
	                ,omf.InsertDate
                FROM 
	                oilzone oz
	                INNER JOIN OilArea oa on oa.OilZoneCode = oz.Code
	                INNER JOIN OilGasStation ogs on ogs.OilAreaCode = oa.Code
	                INNER JOIN OilSupplierDetails osd on osd.ZoneCode = oz.Code
	                INNER JOIN OilSupplier os on os.Code = osd.SupplierCode 
	                INNER JOIN clsAllPerson p on p.Code = os.PCode
	                INNER JOIN OilMalfunction omf on omf.GasStationCode = ogs.Code 		
	                INNER JOIN OilHardwareRepair ohr on ohr.MalfunctionCode = omf.Code
	                INNER JOIN OilAfterReviewing oar on oar.MalfunctionCode = omf.Code ";

            Query += where.ToString();
            Query += @") TB
	                    ON tbs.WarHouse = tb.WarHouseCode) TTB ";

            /// مقایسه میان 2 تاریخ مشخص
            if (AsDate.HasValue && ToDate.HasValue)
            {
                where.Clear();
                where.Append(" where ");
                where.Append(" InsertDate between  ");
                where.Append("'" + StartDTime.ToString() + "'");
                where.Append(" AND ");
                where.Append("'" + EndDTime.ToString() + "'");
            }

            Query += where.ToString();
            Query += " GROUP BY good, from_stock, to_stock";

            #endregion Query

            return Query;
        }

        public static string GetCountGoodsInWarehouses(int WarehouseCode, int GoodsCode, int PersonCode, int TypeOfGoodsCode)
        {
            string Query = string.Empty;
            StringBuilder where = new StringBuilder();

            #region Initial Where Query

            //M1.TypeOfGoodsCode = @TypeOfGoodsCode
            //AND
            //M1.PersonCode=@PersonCode
            //AND
            //WH.Code=@WarehouseCode
            //AND
            //M1.Code = @GoodsCode


            if (WarehouseCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");

                where.Append(" WH.Code = " + WarehouseCode.ToString());
            }

            ///___________________________________________-
            if (GoodsCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" M1.Code = " + GoodsCode.ToString());
            }
            ///___________________________________________-
            if (PersonCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" M1.PersonCode = " + PersonCode.ToString());
            }
            ///___________________________________________-
            if (TypeOfGoodsCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" M1.TypeOfGoodsCode = " + TypeOfGoodsCode.ToString());
            }
            ///___________________________________________-




            #endregion Initial Where Query


            Query = @"
            SELECT
                M1.Code ,
	            (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
                    LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
                    LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
		            WHERE d1.GoodsCode = M1.Code 
			            AND 
			            r1.WarehouseCode = WH.Code--@WarehouseCode			
			            )

	            -
	            (SELECT ISNULL(Sum(d2.Number),0) 
		            FROM WarBillOfGoodsDetails d2
		            LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
		            LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)			
		            WHERE d2.GoodsCode  =  M1.Code  
			            AND 
				            W.WarehouseCode = WH.Code--@WarehouseCode				
				            ) as CountOfGoods-- N'تعداد کالا در انبار'
							 ,WTOG.Name as GoodsType -- N'نوع کالا'
							 ,M1.[Description] as GoodsDescription --N'شرح کالا'
							 , isnull(WH.Name,N'در هیچ انباری موجود نیست.') as WarehouseName -- N'انبار'
							 ,CLSALLPERSON.Name as GoodManufactuer-- N'سازنده کالا'
	
	            FROM WarGoods M1  	
	            LEFT JOIN WarTypesOfGoods WTOG ON(WTOG.Code = M1.TypeOfGoodsCode)    

	            ------------------------------------------------------------
	            LEFT JOIN CLSALLPERSON ON(CLSALLPERSON.Code=M1.PersonCode)
	            LEFT JOIN WarReceiptOfGoodsDetails WROGD ON(WROGD.GoodsCode=M1.Code)
	            LEFT JOIN WarReceiptOfGoods WROG ON(WROG.Code=WROGD.ReceiptOfGoodsCode)
	            LEFT JOIN WarWarehouse WH ON(WH.Code=WROG.WarehouseCode)";
            Query += where.ToString();

            return Query;
        }


        public static string GetGoodsWithPerson(int WarGoods, int TypesOfGoodsCode)
        {
            string Query = string.Empty;
            StringBuilder where = new StringBuilder();

            #region Initial Where Query


            if (WarGoods > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" M1.Code = " + WarGoods.ToString());
            }
           
            ///___________________________________________-
            if (TypesOfGoodsCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" M1.TypeOfGoodsCode = " + TypesOfGoodsCode.ToString());
            }
            ///___________________________________________-




            #endregion Initial Where Query


            Query = @"Select 
	                    M1.Code as Code,
	                    WTOG.Name as GoodsType -- N'نوع کالا'
	                    ,M1.[Description] as GoodsDescription --N'شرح کالا'
	                    ,CLSALLPERSON.Name as GoodManufactuer-- N'سازنده کالا'
                    FROM WarGoods M1  	
	                    LEFT JOIN WarTypesOfGoods WTOG ON(WTOG.Code = M1.TypeOfGoodsCode)
	                    ------------------------------------------------------------
	                    LEFT JOIN CLSALLPERSON ON(CLSALLPERSON.Code=M1.PersonCode)";
            Query += where.ToString();

            return Query;
        }

      
        public static string GetPersonWithGoods(int PersonCode)
        {
            string Query = string.Empty;
            StringBuilder where = new StringBuilder();

            #region Initial Where Query

          
            ///___________________________________________-
            if (PersonCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" M1.PersonCode = " + PersonCode.ToString());
            }
            ///___________________________________________-
          


            #endregion Initial Where Query


            Query = @"Select 
	                        M1.Code as Code,
	                        WTOG.Name as GoodsType -- N'نوع کالا'
	                        ,M1.[Description] as GoodsDescription --N'شرح کالا'
	                        ,CLSALLPERSON.Name as GoodManufactuer-- N'سازنده کالا'
                        FROM WarGoods M1  	
	                        LEFT JOIN WarTypesOfGoods WTOG ON(WTOG.Code = M1.TypeOfGoodsCode)
	                        ------------------------------------------------------------
	                        LEFT JOIN CLSALLPERSON ON(CLSALLPERSON.Code=M1.PersonCode)";
            Query += where.ToString();

            return Query;
        }
    }

    public class JWarehouseTable : ClassLibrary.JTable
    {
        public string Name;
        public int OwnerCode;
        public int StockClerk;
        public JWarehouseTable()
            : base("WarWarehouse")
        {
        }
    }
}


