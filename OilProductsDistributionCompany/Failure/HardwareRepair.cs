using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.Failure
{
    public class JHardwareRepair
    {
        public int Code { get; set; }
        /// <summary>
        /// کد اعلام خرابی
        /// </summary>
        public int MalfunctionCode { get; set; }
        /// <summary>
        /// کد واقعی اعلام خرابی
        /// </summary>
        public int RealDamageCode { get; set; }
        /// <summary>
        /// شماره PT
        /// </summary>
        public int PTCode { get; set; }
        /// <summary>
        /// سرویس شده
        /// </summary> 
        public byte Serviced { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FormSealCode { get; set; }
        ///// <summary>
        ///// شمارنده توتالایزر قبل از فک
        ///// </summary>
        //public int NumbersOfMechanicallyBeforeRemoveTheSeal { get; set; }
        ///// <summary>
        ///// شمارنده توتالایزر بعد از فک
        ///// </summary>
        //public int NumbersOfMechanicallyAfterRemoveTheSeal { get; set; }
        /// <summary>
        /// قطعه معیوب
        /// </summary>
        public int WarGoodCrashCode { get; set; }

        /// <summary>
        /// قطعه تعویضی
        /// </summary>
        public int WarGoodReplaceCode { get; set; }

        /// <summary>
        /// خرابی مربوط به دفتر جایگاه 
        /// </summary>
        public bool IsOfficeDamage { get; set; }

        /// <summary>
        /// تخلیه اطلاعات انجام شده است
        /// </summary>
        public bool DischargeInformation { get; set; }

        /// <summary>
        /// خرابی هارد دیسک
        /// </summary>
        public bool IsHardDisk { get; set; }

        /// <summary>
        /// خرابی مودم
        /// </summary>
        public bool IsModem { get; set; }

        /// <summary>
        /// پیکربندی انجام شد
        /// </summary>
        public bool IsFormated { get; set; }

        public int Insert()
        {
            #region Initilization
            ClassLibrary.JDataBase JDB = new ClassLibrary.JDataBase();
            JHardwareRepairTable GH = new JHardwareRepairTable();
            JSoftwareRepairTable SOR = new JSoftwareRepairTable();
            WarehouseManagement.Goods.JBillOfGoodsTable BOG = new WarehouseManagement.Goods.JBillOfGoodsTable();
            WarehouseManagement.Goods.JBillOfGoodsDetailsTable BOG_Detail = new WarehouseManagement.Goods.JBillOfGoodsDetailsTable();
            WarehouseManagement.Goods.JReceiptOfGoodsTable ROG = new WarehouseManagement.Goods.JReceiptOfGoodsTable();
            WarehouseManagement.Goods.JReceiptOfGoodsDetailsTable ROG_Detail = new WarehouseManagement.Goods.JReceiptOfGoodsDetailsTable();
            WarehouseManagement.Goods.JWarGoodRequestTable Good_Req = new WarehouseManagement.Goods.JWarGoodRequestTable();
            WarehouseManagement.Goods.JWarGoodRequestDetailsTable Good_ReqDetail = new WarehouseManagement.Goods.JWarGoodRequestDetailsTable();
            #endregion Initilization

            try
            {
                GH.SetValueProperty(this);
                JMalfunction MFunc = new JMalfunction();
                MFunc.GetData(GH.MalfunctionCode);

                GasStation.JGasStation GS = new GasStation.JGasStation();
                GS.GetData(MFunc.GasStationCode);

                WarehouseManagement.Goods.JGoods JG = new WarehouseManagement.Goods.JGoods();
                JG.GetData(GH.WarGoodCrashCode);
                DataTable Dt = JDB.Query_DataTable();
                int SupplierPersonCode = FindSupplier(GS, ref JDB);
                int Gs_WarehouseCode = FindGasStationWarehouseCode(GS, ref JDB);
                int Supplier_WarehouseCode = FindSupplierWarehouseCode(GS, SupplierPersonCode, ref JDB);


                if (JDB.beginTransaction("HardwareRepair_Wearhouse"))
                {
                    Code = GH.Insert(JDB);
                    DataTable Bill_Bad_dt = WarehouseManagement.Goods.JBillOfGoodSes.GetData("'WebOilManagement.JWebFailure.Bad'", GH.MalfunctionCode);
                    DataTable Rec_Hale_dt = WarehouseManagement.Goods.JReceiptOfGoodSes.GetData("'WebOilManagement.JWebFailure.Hale'", GH.MalfunctionCode);
                    DataTable Bill_Hale_dt = WarehouseManagement.Goods.JBillOfGoodSes.GetData("'WebOilManagement.JWebFailure.Hale'", GH.MalfunctionCode);
                    DataTable Rec_Bad_dt = WarehouseManagement.Goods.JReceiptOfGoodSes.GetData("'WebOilManagement.JWebFailure.Bad'", GH.MalfunctionCode);
                    int BillGoodCode;
                    int ReceiptOfGoodsCode;

                    #region Bad Goods Drag From Gas Station Warehose & Drop To Supplier Warehose
                    if (Bill_Bad_dt.Rows.Count == 0)
                    {
                        #region JBillOfGoodsInsert
                        BOG.BillDate = DateTime.Now;
                        BOG.DeliveryPersonCode = GS.OwnerCode;
                        BOG.TransfereePersonCode = SupplierPersonCode;
                        BOG.WarehouseCode = Gs_WarehouseCode;
                        BOG.RegisterDate = DateTime.Now;
                        BOG.class_Name = "WebOilManagement.JWebFailure.Bad";
                        BOG.object_code = GH.MalfunctionCode;
                        BillGoodCode = BOG.Insert(JDB);
                        #endregion JBillOfGoodsInsert
                    }
                    else
                        BillGoodCode = (int)Bill_Bad_dt.Rows[0]["Code"];

                    #region JBillOfGoodsDetailInsert

                    BOG_Detail.BillOfGoodsCode = BillGoodCode;
                    BOG_Detail.GoodsCode = GH.WarGoodCrashCode;
                    BOG_Detail.Number = 1;
                    BOG_Detail.RegisterDate = DateTime.Now;
                    BOG_Detail.Insert(JDB);

                    #endregion JBillOfGoodsDetailInsert

                    #region Goods Update Status To Bad

                    JG.StatusOfGoods = WarehouseManagement.Goods.JStatusOfGoods.Bad;
                    JG.Update();

                    #endregion Goods Update Status To Bad

                    ///با نظر مهندس زرین هدر رسید سند هم ثبت نمی گردد

                    //if (Rec_Bad_dt.Rows.Count == 0)
                    //{
                    //    #region JReceiptOfGoodsInsert

                    //    ROG.DeliveryPersonCode = SupplierPersonCode;
                    //    ROG.ReceiptDate = DateTime.Now;
                    //    ROG.RegisterDate = DateTime.Now;
                    //    ROG.TransfereePersonCode = GS.OwnerCode;
                    //    ROG.WarehouseCode = Supplier_WarehouseCode;
                    //    ROG.class_Name = "WebOilManagement.JWebFailure.Bad";
                    //    ROG.object_code = GH.MalfunctionCode;
                    //    ReceiptOfGoodsCode = ROG.Insert(JDB);

                    //    #endregion JReceiptOfGoodsInsert
                    //}
                    //else
                    //    ReceiptOfGoodsCode = (int)Rec_Bad_dt.Rows[0]["Code"];

                    #region JReceiptOfGoodsDetailInsert
                    ///باتوجه به اینکه احتمال این وجود دارد که
                    ///کارمند تکنسین پیمانکار
                    ///کالای معیوب را به انبار پیمانکار تحویل ندهد
                    ///کالاهای رسید انبار باید به صورت دستی وارد شود
                    ///تحلیل با مهندس زرین
                    //ROG_Detail.ReceiptOfGoodsCode = ReceiptOfGoodsCode;
                    //ROG_Detail.GoodsCode = GH.WarGoodCrashCode;
                    //ROG_Detail.Number = 1;
                    //ROG_Detail.RegisterDate = DateTime.Now;
                    //ROG_Detail.Insert(JDB);

                    #endregion JReceiptOfGoodsDetailInsert

                    #endregion Bad Goods Drag From Gas Station Warehose & Drop To Supplier Warehose

                    #region Hale Goods Drag From Supplier Warehose & Drop To Gas Station Warehose
                    if (Bill_Hale_dt.Rows.Count == 0)
                    {
                        #region JBillOfGoodsInsert

                        BOG.BillDate = DateTime.Now;
                        BOG.DeliveryPersonCode = SupplierPersonCode;
                        BOG.TransfereePersonCode = GS.OwnerCode;
                        BOG.WarehouseCode = Supplier_WarehouseCode;
                        BOG.RegisterDate = DateTime.Now;
                        BOG.class_Name = "WebOilManagement.JWebFailure.Hale";
                        BOG.object_code = GH.MalfunctionCode;
                        BillGoodCode = BOG.Insert(JDB);

                        #endregion JBillOfGoodsInsert
                    }
                    else
                        BillGoodCode = (int)Bill_Hale_dt.Rows[0]["Code"];

                    #region JBillOfGoodsDetailInsert

                    BOG_Detail.BillOfGoodsCode = BillGoodCode;
                    BOG_Detail.GoodsCode = GH.WarGoodReplaceCode;
                    BOG_Detail.Number = 1;
                    BOG_Detail.RegisterDate = DateTime.Now;
                    BOG_Detail.Insert(JDB);

                    #endregion JBillOfGoodsDetailInsert

                    if (Rec_Hale_dt.Rows.Count == 0)
                    {
                        #region JReceiptOfGoodsInsert

                        ROG.DeliveryPersonCode = GS.OwnerCode;
                        ROG.ReceiptDate = DateTime.Now;
                        ROG.RegisterDate = DateTime.Now;
                        ROG.TransfereePersonCode = SupplierPersonCode;
                        ROG.WarehouseCode = Gs_WarehouseCode;
                        ROG.class_Name = "WebOilManagement.JWebFailure.Hale";
                        ROG.object_code = GH.MalfunctionCode;
                        ReceiptOfGoodsCode = ROG.Insert(JDB);

                        #endregion JReceiptOfGoodsInsert
                    }
                    else
                        ReceiptOfGoodsCode = (int)Rec_Hale_dt.Rows[0]["Code"];

                    #region JReceiptOfGoodsDetailInsert

                    ROG_Detail.ReceiptOfGoodsCode = ReceiptOfGoodsCode;
                    ROG_Detail.GoodsCode = GH.WarGoodReplaceCode;
                    ROG_Detail.Number = 1;
                    ROG_Detail.RegisterDate = DateTime.Now;
                    ROG_Detail.Insert(JDB);

                    #endregion JReceiptOfGoodsDetailInsert

                    #endregion Hale Goods Drag From Supplier Warehose & Drop To Gas Station Warehose

                    if (GH.Serviced == 3)
                    {
                        #region Needs Goods
                        Good_Req.Code = WarehouseManagement.Goods.JWarGoodRequest.FindByClassNameObjectCode("WebOilManagement.JWebFailure", GH.MalfunctionCode);
                        int TypeOfGoodsCode = (int)WarehouseManagement.Goods.JGoodSes.GetData(GH.WarGoodCrashCode).Rows[0]["TypeOfGoodsCode"];
                        if (Good_Req.ObjectCode == 0)
                        {

                            Good_Req.ClassName = "WebOilManagement.JWebFailure";
                            Good_Req.ObjectCode = GH.MalfunctionCode;
                            Good_Req.RequestDate = DateTime.Now;
                            Good_Req.UserCode = MFunc.RegistrarCode;
                            Good_Req.Code = Good_Req.Insert(JDB);
                        }
                        if (Good_Req.Code > 0)
                        {
                            Good_ReqDetail.GRCode = Good_Req.Code;
                            Good_ReqDetail.Count = 1;
                            Good_ReqDetail.GoodTypeCode = TypeOfGoodsCode;
                            Good_ReqDetail.Code = Good_ReqDetail.Insert(JDB);
                        }

                        #endregion Needs Goods
                    }

                    if (GH.IsHardDisk || GH.IsModem)
                    {
                        #region JSoftwareRepairInsert

                        SOR.GSSoftwareANDDashboard = false;
                        SOR.GSSoftwareANDDashboardComment = string.Empty;
                        SOR.InitialAgain = JInitialAgain.None;
                        SOR.InitialAgainComment = string.Empty;

                        SOR.InitialReasons = JInitialReasons.BurningDrive;
                        if (GH.IsModem)
                            SOR.InitialReasonsComment = "تعویض  مودم";
                        else
                            SOR.InitialReasonsComment = "تعویض هارد دیسک ";

                        SOR.LastTimeConnectingPooler = DateTime.Now;
                        SOR.MalfunctionCode = GH.MalfunctionCode;
                        SOR.PtVersion = string.Empty;
                        SOR.TablePrices = 0;
                        SOR.TableQuotas = 0;
                        SOR.Insert(JDB);

                        #endregion JSoftwareRepairInsert
                    }

                    if (JDB.Commit())
                        return Code;

                }
            }
            catch
            {
                JDB.Rollback("WebOilManagement.JWebFailure.Hale");
            }
            finally
            {
                JDB.Dispose();
            }
            return 0;
        }

        private int FindSupplierWarehouseCode(GasStation.JGasStation GS, int SupplierPersonCode, ref ClassLibrary.JDataBase JDB)
        {
            #region Find Supplier WarehouseCode (Receipt's WarehouseCode)

            JDB.setQuery(@"SELECT Code FROM WarWarehouse WHERE OwnerCode=" + SupplierPersonCode);
            DataTable Dt = JDB.Query_DataTable();
            int Supplier_WarehouseCode = 0;
            if (Dt.Rows[0]["Code"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["Code"].ToString()))
            {
                Supplier_WarehouseCode = int.Parse(Dt.Rows[0]["Code"].ToString());
            }

            #endregion Find Supplier WarehouseCode (Receipt's WarehouseCode)

            return Supplier_WarehouseCode;
        }

        private int FindGasStationWarehouseCode(GasStation.JGasStation GS, ref ClassLibrary.JDataBase JDB)
        {
            #region Find GasStation WarehouseCode (Bill's WarehouseCode)
            DataTable Dt = new DataTable();
            JDB.setQuery(@"SELECT Code FROM WarWarehouse WHERE OwnerCode=" + GS.OwnerCode);
            Dt = JDB.Query_DataTable();
            int Gs_WarehouseCode = 0;
            if (Dt.Rows[0]["Code"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["Code"].ToString()))
            {
                Gs_WarehouseCode = int.Parse(Dt.Rows[0]["Code"].ToString());
            }

            #endregion Find GasStation WarehouseCode (Bill's WarehouseCode)

            return Gs_WarehouseCode;
        }

        private int FindSupplier(GasStation.JGasStation GS, ref ClassLibrary.JDataBase JDB)
        {
            #region Find Supplier (Bill's TransfereePersonCode)
            JDB.setQuery(@"SELECT OSD.Code,SupplierCode,OA.OilZoneCode,OA.Code AS AreaCode,OS.PCode PersonCode,PCode FROM OilSupplierDetails OSD
			                            LEFT JOIN OilSupplier OS ON(OSD.SupplierCode= OS.Code)
			                            LEFT JOIN OilArea OA ON(OA.OilZoneCode = OSD.ZoneCode)  WHERE OA.Code = " + GS.OilAreaCode);
            DataTable Dt;
            Dt = JDB.Query_DataTable();
            int SupplierPersonCode = 0;
            if (Dt.Rows[0]["PersonCode"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["PersonCode"].ToString()))
            {
                SupplierPersonCode = int.Parse(Dt.Rows[0]["PersonCode"].ToString());

            }
            #endregion Find Supplier (Bill's TransfereePersonCode)

            return SupplierPersonCode;
        }

        public bool update()
        {
            JHardwareRepairTable GH = new JHardwareRepairTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JHardwareRepairTable GH = new JHardwareRepairTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JHardwareRepairTable GH = new JHardwareRepairTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JHardwareRepairTable GH = new JHardwareRepairTable();
            return GH.GetData(this, pCode);
        }

        public bool GetDataByMalfunction(int pMalfunctionCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"Select top 1 * From [OilHardwareRepair] Where [MalfunctionCode] = " + pMalfunctionCode.ToString());
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, db.DataReader);
                    db.DataReader.Close();
                    return true;
                }


                return false;
            }
            finally
            {
                db.Dispose();
            }
        }


        public static string HardDiskReplacement(int AreaCode = 0, int OilZoneCode = 0, DateTime? FailureDate = null, DateTime? FixBugDate = null)
        {


            string Query = string.Empty;
            StringBuilder where = new StringBuilder();
            DateTime FailureDTime = new DateTime(FailureDate.Value.Year, FailureDate.Value.Month, FailureDate.Value.Day, 0, 0, 0);
            DateTime FixBugDTime = new DateTime(FixBugDate.Value.Year, FixBugDate.Value.Month, FixBugDate.Value.Day, 23, 59, 59);

            #region Initial Where Query

            ///___________________________________________-

            if (AreaCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");

                where.Append(" A.Code = " + AreaCode.ToString());
            }

            ///___________________________________________-
            if (OilZoneCode > 0)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" z.Code = " + OilZoneCode.ToString());
            }
            ///___________________________________________-


            if (FailureDate.HasValue && FixBugDate.HasValue)
            {
                if (where.Length == 0)
                    where.Append(" where ");
                else
                    where.Append(" AND ");
                where.Append(" mf.RealMalfunctionDate between  ");
                where.Append("'" + FailureDTime.ToString() + "'");
                where.Append(" AND ");
                where.Append("'" + FixBugDTime.ToString() + "'");
            }

            #endregion Initial Where Query


            #region Query

            Query = @"SELECT gs.Code, z.Name AS 'نام منطقه',a.Name as 'نام ناحيه',gs.Number AS 'شناسه جايگاه',gs.Name AS 'نام جايگاه',
                    (select wg.Serial from WarGoods wg where wg.Code=hr.WarGoodCrashCode) as 'شماره سريال هارد معيوب',
                    (select wg.Serial from WarGoods wg where wg.Code=hr.WarGoodReplaceCode) as  'شماره سريال هارد تعويضي',
                    mf.RealMalfunctionDate AS 'زمان وقوع خرابي',ar.GasStationManagerConfirmation AS 'زمان رفع خرابي',
                    td.Name AS 'دليل تعويض هارد'  
                     FROM OilArea a INNER JOIN OilZone z ON a.OilZoneCode=z.Code 
                    INNER JOIN OilGasStation gs ON a.Code=gs.OilAreaCode 
                    INNER JOIN OilMalfunction mf ON gs.Code=mf.GasStationCode 
                    INNER JOIN OilTableDamages td ON mf.DamageCode=td.Code 
                    INNER JOIN OilHardwareRepair hr ON mf.Code=hr.MalfunctionCode 
                    INNER JOIN OilAfterReviewing ar ON mf.Code=ar.MalfunctionCode AND hr.IsHardDisk=1 ";

            Query += where.ToString();
            #endregion Query

            return Query;
        }
    }

    public class JHardwareRepairs
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JHardwareRepairTable GH = new JHardwareRepairTable();
            return GH.GetDataTable(pCode);
        }

        public static DataTable FillByMalCode(int pMalfunctionCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"Select * From [OilHardwareRepair] Where [MalfunctionCode] = " + pMalfunctionCode.ToString());
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static string GetWebQuery()
        {
            JHardwareRepairTable GH = new JHardwareRepairTable();
            return GH.CreateQuery("");
        }
    }

    public class JHardwareRepairTable : ClassLibrary.JTable
    {
        /// <summary>
        /// کد اعلام خرابی
        /// </summary>
        public int MalfunctionCode;
        /// <summary>
        /// کد واقعی اعلام خرابی
        /// </summary>
        public int RealDamageCode;
        /// <summary>
        /// شماره PT
        /// </summary>
        public int PTCode;
        /// <summary>
        /// سرویس 
        /// </summary>
        public Byte Serviced;
        /// <summary>
        /// 
        /// </summary>
        public int FormSealCode;

        /// <summary>
        /// قطعه معیوب
        /// </summary>
        public int WarGoodCrashCode;

        /// <summary>
        /// قطعه تعویضی
        /// </summary>
        public int WarGoodReplaceCode;

        /// <summary>
        /// خرابی مربوط به دفتر جایگاه 
        /// </summary>
        public bool IsOfficeDamage;

        /// <summary>
        /// خرابی هارد دیسک
        /// </summary>
        public bool IsHardDisk;

        /// <summary>
        /// خرابی مودم
        /// </summary>
        public bool IsModem;

        ///// <summary>
        ///// شمارنده توتالایزر قبل از فک
        ///// </summary>
        //public int NumbersOfMechanicallyBeforeRemoveTheSeal;
        ///// <summary>
        ///// شمارنده توتالایزر بعد از فک
        ///// </summary>
        //public int NumbersOfMechanicallyAfterRemoveTheSeal;
        /// <summary>
        /// تخلیه اطلاعات انجام شده است
        /// </summary>
        public bool DischargeInformation;

        /// <summary>
        /// پیکربندی بندی
        /// </summary>
        public bool IsFormated;

        public JHardwareRepairTable()
            : base("OilHardwareRepair")
        {
        }
    }

}
