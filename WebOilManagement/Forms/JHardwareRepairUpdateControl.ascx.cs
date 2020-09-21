using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebOilManagement.Forms
{
    public partial class JHardwareRepairUpdateControl : System.Web.UI.UserControl
    {

        #region Init
        /// -------------------------------------------------------------------------------------------------------
        int Code;
        /// -------------------------------------------------------------------------------------------------------
        int ReferCode;
        /// -------------------------------------------------------------------------------------------------------
        int MalfunctionCode;
        /// -------------------------------------------------------------------------------------------------------
        protected global::WebControllers.ArchiveDocument.JArchiveControl JArchiveControl;
        /// -------------------------------------------------------------------------------------------------------
        protected global::WebControllers.MainControls.Grid.JGridViewControl grdHardwareRepair;
        /// -------------------------------------------------------------------------------------------------------
        public const string ConstClassName = "WebOilManagement.JHardwareRepair";
        #endregion Init

        #region Public
        /// -------------------------------------------------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            int.TryParse(Request["ReferCode"], out ReferCode);
            DataTable dt = new DataTable();



            // Get Code using ReferCode

            if (ReferCode > 0)
            {
                Automation.JARefer jaRefer = new Automation.JARefer(ReferCode);
                MalfunctionCode = (new Automation.JAObject(jaRefer.object_code)).ObjectCode;
                OilProductsDistributionCompany.Failure.JHardwareRepair jHardwareRepair = new OilProductsDistributionCompany.Failure.JHardwareRepair();
                GrdHardwareRepairBind();
                //jHardwareRepair.GetDataByMalfunction(MalfunctionCode);
                Code = jHardwareRepair.Code;

                OilProductsDistributionCompany.Failure.JMalfunction Malfunction = new OilProductsDistributionCompany.Failure.JMalfunction();
                OilProductsDistributionCompany.GasStation.JGasStation GasStation = new OilProductsDistributionCompany.GasStation.JGasStation();
                OilProductsDistributionCompany.JSupplier Supplier = new OilProductsDistributionCompany.JSupplier();

                Malfunction.GetData(MalfunctionCode);
                GasStation.GetData(Malfunction.GasStationCode);
                Supplier.GetData(Malfunction.SupplierCode);

                ViewState["OilMalfunction"] = MalfunctionCode;
                ViewState["OilGasStation"] = GasStation.WarCode;
                ViewState["OilSupplier"] = Supplier.WarCode;
            }
            // _SetForm();


            if (!IsPostBack)
            {

            }

            if (grdHardwareRepair.SelectedRow != null && grdHardwareRepair.SelectedRow.Count > 0 && grdHardwareRepair.SelectedRow["CODE"] != null)
                int.TryParse(grdHardwareRepair.SelectedRow["CODE"].ToString(), out Code);
            _SetForm();
            //GrdHardwareRepairBind();
            JArchiveControl.ClassName = ConstClassName;
            JArchiveControl.ObjectCode = ReferCode;
            JArchiveControl.LoadArchive();

            // PTCode Custom List Search
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlPTCode).ValidationGroup = "HardwareRepair";
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlPTCode).IsRequired = true;
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlPTCode).Code = 0;
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlPTCode).SQL = @"SELECT Code,PTNumber AS Title FROM OilPT";

            // FormSealCode Custom List Search
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlFormSealCode).ValidationGroup = "HardwareRepair";
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlFormSealCode).Code = 0;
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlFormSealCode).SQL = @"SELECT OFS.Code,OGS.Name,OFS.FormSealSerial AS Title,OFS.Serial FROM OilFormSeal OFS
                                                                                                                     LEFT JOIN OilGasStation OGS ON OFS.GasStationCode = OGS.Code ";

            // Damage Custom List Search
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRealTableDamageCode).ValidationGroup = "HardwareRepair";
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRealTableDamageCode).IsRequired = true;
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRealTableDamageCode).Code = 0;
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRealTableDamageCode).SQL = @"SELECT FailureNumber AS Code,NAME AS Title,case FailureTypeCode WHEN 1 THEN N'الکتريکي' 
                                                                                                                WHEN 2 THEN N'مکانيکي' ELSE N'کارت هوشمند' END AS FailureTypeCode,
                                                                                                                ExpertiseRequired,case Urgency WHEN 1 THEN N'بالا' 
                                                                                                              WHEN 2 THEN N'متوسط' ELSE N'پايين' END AS Urgency FROM OilTableDamages";

            /// WarGoodsReplace Search
            ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).ValidationGroup = "HardwareRepair";
            ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).Code = 0;
            ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).SQL = @"
                                                                     		SELECT
	                                                                        (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
                                                                                LEFT JOIN WarGoods G1               ON(G1.Code              = d1.GoodsCode) 
                                                                                LEFT JOIN WarReceiptOfGoods r1      ON (r1.Code             = d1.ReceiptOfGoodsCode)
		                                                                        LEFT JOIN WarWarehouse WWH          ON(r1.WarehouseCode     = WWH.Code)
		                                                                        LEFT JOIN OilGasStation GS          ON(GS.OwnerCode         = WWH.OwnerCode)
                                                        
		                                                                        LEFT JOIN OilMalfunction OM         ON(OM.GasStationCode = GS.Code)
	                                                                        WHERE d1.GoodsCode = M1.Code AND OM.Code =" + MalfunctionCode + @"      )   -
		                                                                        (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
                                                                                    LEFT JOIN WarGoods G2           ON(G2.Code              = d2.GoodsCode)
			                                                                        LEFT JOIN WarBillOfGoods W      ON(W.Code=d2.BillOfGoodsCode)
			                                                                        LEFT JOIN WarWarehouse WWH      ON(w.WarehouseCode      = WWH.Code)
			                                                                        LEFT JOIN OilGasStation GS      ON(GS.OwnerCode         = WWH.OwnerCode)
		                                                                            LEFT JOIN OilMalfunction OM     ON(OM.GasStationCode    = GS.Code)
		                                                                        WHERE d2.GoodsCode  =  M1.Code  AND OM.Code =" + MalfunctionCode + @" ) As Count 
                                                                                 ,M1.Code,M1.Serial,M1.Description,WTOG.Name  AS Title
	                                                                            FROM WarGoods M1 
		                                                                            LEFT JOIN WarTypesOfGoods WTOG ON(WTOG.Code = M1.TypeOfGoodsCode)
                                                                                Where
                                                                                      (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
                                                                                LEFT JOIN WarGoods G1               ON (G1.Code             =d1.GoodsCode) 
                                                                                LEFT JOIN WarReceiptOfGoods r1      ON (r1.Code             =d1.ReceiptOfGoodsCode)
		                                                                        LEFT JOIN WarWarehouse WWH          ON(r1.WarehouseCode     = WWH.Code)
		                                                                        LEFT JOIN OilGasStation GS          ON(GS.OwnerCode         = WWH.OwnerCode)
		                                                                        LEFT JOIN OilMalfunction OM         ON(OM.GasStationCode    = GS.Code)
	                                                                        WHERE d1.GoodsCode = M1.Code AND OM.Code = " + MalfunctionCode + @"  )  -
		                                                                        (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
                                                                                    LEFT JOIN WarGoods G2           ON (G2.Code             =d2.GoodsCode)
			                                                                        LEFT JOIN WarBillOfGoods W      ON (W.Code              =d2.BillOfGoodsCode)
			                                                                        LEFT JOIN WarWarehouse WWH      ON (w.WarehouseCode     = WWH.Code)
			                                                                        LEFT JOIN OilGasStation GS      ON (GS.OwnerCode        = WWH.OwnerCode)
		                                                                            LEFT JOIN OilMalfunction OM     ON (OM.GasStationCode   = GS.Code)
		                                                                        WHERE d2.GoodsCode  =  M1.Code  AND OM.Code =" + MalfunctionCode + @" ) > 0";
            /// WarGoodsCrash Search

            ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodReplaceCode).Code = 0;
            ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodReplaceCode).ValidationGroup = "HardwareRepair";
            //            ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).SQL = @"
            //                                                                     		SELECT
            //	                                                                        (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
            //                                                                                LEFT JOIN WarGoods G1               ON(G1.Code              = d1.GoodsCode) 
            //                                                                                LEFT JOIN WarReceiptOfGoods r1      ON (r1.Code             = d1.ReceiptOfGoodsCode)
            //		                                                                        LEFT JOIN WarWarehouse WWH          ON(r1.WarehouseCode     = WWH.Code)
            //		                                                                        LEFT JOIN OilGasStation GS          ON(GS.OwnerCode         = WWH.OwnerCode)
            //		                                                                        LEFT JOIN OilMalfunction OM         ON(OM.GasStationCode = GS.Code)
            //	                                                                        WHERE d1.GoodsCode = M1.Code AND OM.Code =" + MalfunctionCode + @"      )   -
            //		                                                                        (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
            //                                                                                    LEFT JOIN WarGoods G2           ON(G2.Code              = d2.GoodsCode)
            //			                                                                        LEFT JOIN WarBillOfGoods W      ON(W.Code=d2.BillOfGoodsCode)
            //			                                                                        LEFT JOIN WarWarehouse WWH      ON(w.WarehouseCode      = WWH.Code)
            //			                                                                        LEFT JOIN OilGasStation GS      ON(GS.OwnerCode         = WWH.OwnerCode)
            //		                                                                            LEFT JOIN OilMalfunction OM     ON(OM.GasStationCode    = GS.Code)
            //		                                                                        WHERE d2.GoodsCode  =  M1.Code  AND OM.Code =" + MalfunctionCode + @" ) As Count 
            //                                                                                ,M1.Code,M1.Name AS Title
            //	                                                                        FROM WarGoods M1 Where
            //                                                                                      (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
            //                                                                                LEFT JOIN WarGoods G1               ON (G1.Code             =d1.GoodsCode) 
            //                                                                                LEFT JOIN WarReceiptOfGoods r1      ON (r1.Code             =d1.ReceiptOfGoodsCode)
            //		                                                                        LEFT JOIN WarWarehouse WWH          ON(r1.WarehouseCode     = WWH.Code)
            //		                                                                        LEFT JOIN OilGasStation GS          ON(GS.OwnerCode         = WWH.OwnerCode)
            //		                                                                        LEFT JOIN OilMalfunction OM         ON(OM.GasStationCode    = GS.Code)
            //	                                                                        WHERE d1.GoodsCode = M1.Code AND OM.Code = " + MalfunctionCode + @"  )  -
            //		                                                                        (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
            //                                                                                    LEFT JOIN WarGoods G2           ON (G2.Code             =d2.GoodsCode)
            //			                                                                        LEFT JOIN WarBillOfGoods W      ON (W.Code              =d2.BillOfGoodsCode)
            //			                                                                        LEFT JOIN WarWarehouse WWH      ON (w.WarehouseCode     = WWH.Code)
            //			                                                                        LEFT JOIN OilGasStation GS      ON (GS.OwnerCode        = WWH.OwnerCode)
            //		                                                                            LEFT JOIN OilMalfunction OM     ON (OM.GasStationCode   = GS.Code)
            //		                                                                        WHERE d2.GoodsCode  =  M1.Code  AND OM.Code =" + MalfunctionCode + @" ) > 0";
            ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodReplaceCode).SQL = @"
                                                                  SELECT
	                                                                (SELECT ISNULL(Sum(d1.Number),0)	FROM WarReceiptOfGoodsDetails d1  
                                                                            LEFT JOIN WarGoods               G1	     ON (G1.Code=d1.GoodsCode) 
                                                                            LEFT JOIN WarReceiptOfGoods      r1	     ON(r1.Code				= d1.ReceiptOfGoodsCode)
		                                                                    LEFT JOIN WarWarehouse          WWH	     ON(r1.WarehouseCode		= WWH.Code)
		                                                                    LEFT JOIN OilMalfunction	     OM		 ON(OM.Code				= " + MalfunctionCode + @")
					                                                        LEFT JOIN OilSupplier		     OS  	 ON(OS.WarCode			= WWH.Code)
	                                                                    WHERE d1.GoodsCode = M1.Code AND  WWH.OwnerCode = OS.PCode  )-
		                                                                    (SELECT ISNULL(Sum(d2.Number),0)	FROM WarBillOfGoodsDetails d2
                                                                                LEFT JOIN WarGoods           G2		    ON (G2.Code=d2.GoodsCode)
			                                                                    LEFT JOIN WarBillOfGoods      W 		ON (W.Code=d2.BillOfGoodsCode)
			                                                                    LEFT JOIN WarWarehouse      WWH			ON(w.WarehouseCode = WWH.Code)
			                                                                    LEFT JOIN OilMalfunction     OM			ON(OM.Code				= " + MalfunctionCode + @")
			                                                                    LEFT JOIN OilSupplier		 OS         ON(OS.WarCode			= WWH.Code)
		                                                                    WHERE d2.GoodsCode  =  M1.Code AND  WWH.OwnerCode = OS.PCode) As Count 
                                                                            ,M1.Code,M1.Serial,M1.Description,WTOG.Name  AS Title
	                                                                            FROM WarGoods M1 
		                                                                            LEFT JOIN WarTypesOfGoods WTOG ON(WTOG.Code = M1.TypeOfGoodsCode)
                                                                                Where
                                                                                (SELECT ISNULL(Sum(d1.Number),0)	FROM WarReceiptOfGoodsDetails d1  
			                                                                    LEFT JOIN WarGoods           G1		ON (G1.Code=d1.GoodsCode) 
			                                                                    LEFT JOIN WarReceiptOfGoods  r1		ON (r1.Code=d1.ReceiptOfGoodsCode)
			                                                                    LEFT JOIN WarWarehouse      WWH		ON(r1.WarehouseCode = WWH.Code)
			                                                                    LEFT JOIN OilMalfunction     OM		ON(OM.Code				= " + MalfunctionCode + @")
                                                                                LEFT JOIN OilSupplier		 OS	    ON(OS.WarCode			= WWH.Code)
	                                                                    WHERE d1.GoodsCode = M1.Code AND  WWH.OwnerCode = OS.PCode )-
		                                                                    (SELECT ISNULL(Sum(d2.Number),0)	FROM WarBillOfGoodsDetails d2
                                                                                LEFT JOIN WarGoods            G2	    ON (G2.Code=d2.GoodsCode)
			                                                                    LEFT JOIN WarBillOfGoods       W		ON (W.Code=d2.BillOfGoodsCode)
			                                                                    LEFT JOIN WarWarehouse       WWH        ON(w.WarehouseCode = WWH.Code)
			                                                                    LEFT JOIN OilMalfunction      OM	   	ON(OM.Code				= " + MalfunctionCode + @")
			                                                                    LEFT JOIN OilSupplier		  OS		ON(OS.WarCode			= WWH.Code)
		                                                                    WHERE d2.GoodsCode  =  M1.Code AND  WWH.OwnerCode = OS.PCode) > 0";

            switch (rbIsServiced.SelectedValue)
            {
                case "0"://هیچکدام
                    tdWarGoodReplaceCode.Disabled = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).IsRequired = false;
                    break;
                case "1"://سرویس
                    tdWarGoodReplaceCode.Disabled = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlFormSealCode).IsRequired = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).IsRequired = true;
                    break;
                case "2"://تعویض
                    tdWarGoodReplaceCode.Disabled = false;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).IsRequired = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodReplaceCode).IsRequired = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlFormSealCode).IsRequired = true;
                    //                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodReplaceCode).SQL = @"
                    //                    SELECT  WarGoods.Serial AS Code ,WTOG.Name AS Title  
                    //                            FROM WarGoods 
                    //                            LEFT JOIN WarTypesOfGoods WTOG ON (WarGoods.TypeOfGoodsCode=WTOG.Code)
                    //                            LEFT JOIN WarWarehouse WWH ON(WWH.Code=WarGoods.WarehouseCode)
                    //                            LEFT JOIN OilGasStation OGS ON(OGS.OwnerCode=WWH.OwnerCode)
                    //                            LEFT JOIN OilArea OA ON(OGS.Area=OA.Code)
                    //                            LEFT JOIN OilSupplierDetails ON( OilSupplierDetails.ZoneCode = OA.OilZoneCode)";
                    break;
                case "3"://عدم وجود قطعه
                    tdWarGoodReplaceCode.Disabled = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).IsRequired = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodReplaceCode).IsRequired = false;
                    break;
            }
        }

        private void GrdHardwareRepairBind()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("OilHardwareRepair");
            jGridView.SQL = @"SELECT
                                    OHR.Code AS CODE
	                                ,OHR.DischargeInformation AS [تخلیه اطلاعات]
	                                ,OHR.FormSealCode
	                                ,OFS.DatesOfOperation
	                                ,OFS.FormSealSerial
	                                ,OFS.Serial
	                                ,OHR.IsOfficeDamage AS [خرابی جایگاه]
	                             -- ,OHR.PTCode
	                                ,ONO.Number
	                                ,OP.PTNumber
	                             -- ,OHR.WarGoodCrashCode
	                                ,WTOG.Name AS TypeGoodName
	                                ,CASE OHR.Serviced 
		                                WHEN 0 THEN N'هیچکدام'
		                                WHEN 1 THEN N'سرویس'
		                                WHEN 2 THEN N'تعویض'
		                                WHEN 3 THEN N'عدم وجود قطعه'
		                                END AS DescServiced
                                FROM [OilHardwareRepair]   AS    OHR
	                                 LEFT JOIN OilTableDamages   OTD  ON(OHR.RealDamageCode   =  OTD.Code)
	                                 LEFT JOIN OilFormSeal	     OFS  ON(OHR.FormSealCode     =  OFS.Code)
	                                 LEFT JOIN OilPT		     OP   ON(OHR.PTCode	          =   OP.Code)
	                                 LEFT JOIN WarGoods          WG   ON(OHR.WarGoodCrashCode =   WG.Code)
	                                 LEFT JOIN WarTypesOfGoods   WTOG ON(WG.TypeOfGoodsCode   = WTOG.Code)
                                     LEFT JOIN OilNozzle         ONO  ON(OP.NozzleCode        =  ONO.Code)
	                                 Where [MalfunctionCode] = " + MalfunctionCode.ToString();
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 100;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JHardwareRepair";
            jGridView.Buttons = "excel";
            //jGridView.SumFields = new Dictionary<string, double>();
            //jGridView.SumFields.Add("TransactionCount", 0);
            //jGridView.SumFields.Add("InCome", 0);
            ((WebControllers.MainControls.Grid.JGridViewControl)grdHardwareRepair).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)grdHardwareRepair).LoadGrid(true);
        }
        /// -------------------------------------------------------------------------------------------------------
        #endregion Public

        #region Methods
        /// -------------------------------------------------------------------------------------------------------
        public void _SetForm()
        {
            switch (rbIsServiced.SelectedValue)
            {
                case "0"://هیچکدام
                    tdWarGoodReplaceCode.Disabled = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).IsRequired = false;
                    break;
                case "1"://سرویس
                    tdWarGoodReplaceCode.Disabled = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlFormSealCode).IsRequired = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).IsRequired = true;
                    break;
                case "2"://تعویض
                    tdWarGoodReplaceCode.Disabled = false;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).IsRequired = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodReplaceCode).IsRequired = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlFormSealCode).IsRequired = true;
                    //                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodReplaceCode).SQL = @"
                    //                    SELECT  WarGoods.Serial AS Code ,WTOG.Name AS Title  
                    //                            FROM WarGoods 
                    //                            LEFT JOIN WarTypesOfGoods WTOG ON (WarGoods.TypeOfGoodsCode=WTOG.Code)
                    //                            LEFT JOIN WarWarehouse WWH ON(WWH.Code=WarGoods.WarehouseCode)
                    //                            LEFT JOIN OilGasStation OGS ON(OGS.OwnerCode=WWH.OwnerCode)
                    //                            LEFT JOIN OilArea OA ON(OGS.Area=OA.Code)
                    //                            LEFT JOIN OilSupplierDetails ON( OilSupplierDetails.ZoneCode = OA.OilZoneCode)";
                    break;
                case "3"://عدم وجود قطعه
                    tdWarGoodReplaceCode.Disabled = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).IsRequired = true;

                    break;
            }
            if (Code > 0)
            {
                OilProductsDistributionCompany.Failure.JHardwareRepair HardwareRepair = new OilProductsDistributionCompany.Failure.JHardwareRepair();
                HardwareRepair.GetData(Code);

                //// TableDamage Custom List Search
                //((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRealTableDamageCode).Code = HardwareRepair.RealDamageCode;
                //((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRealTableDamageCode).SQL = @"SELECT Code,NAME AS Title FROM OilTableDamages";

                //// TableDamage Custom List Search
                //((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRealTableDamageCode).Code = 0;
                //((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRealTableDamageCode).SQL = @"SELECT Code,NAME AS Title FROM OilTableDamages";

                DataTable OilTableDamages_dt = WebClassLibrary.JWebDataBase.GetDataTable("select FailureNumber from OilTableDamages where code = " + HardwareRepair.RealDamageCode);
                if (OilTableDamages_dt.Rows.Count > 0)

                    ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRealTableDamageCode).Code = int.Parse(OilTableDamages_dt.Rows[0]["FailureNumber"].ToString());
                else
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRealTableDamageCode).Code = 0;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRealTableDamageCode).SQL =
                                                                                @"SELECT FailureNumber AS Code,NAME AS Title,case FailureTypeCode WHEN 1 THEN N'الکتريکي' 
                                                                                          WHEN 2 THEN N'مکانيکي' ELSE N'کارت هوشمند' END AS FailureTypeCode,
                                                                                          ExpertiseRequired,case Urgency WHEN 1 THEN N'بالا' 
                                                                                          WHEN 2 THEN N'متوسط' ELSE N'پايين' END AS Urgency FROM OilTableDamages";

                // PTCode Custom List Search
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlPTCode).Code = HardwareRepair.PTCode;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlPTCode).SQL = @"SELECT Code,PTNumber AS Title FROM OilPT";

                // FormSealCode Custom List Search
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlFormSealCode).Code = HardwareRepair.FormSealCode;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlFormSealCode).SQL = @"
                                                                           SELECT OFS.Code,OGS.Name,OFS.FormSealCode AS Title,OFS.Serial 
                                                                              FROM OilFormSeal OFS
                                                                                  LEFT JOIN OilGasStation OGS ON OFS.GasStationCode = OGS.Code ";


                rbIsServiced.SelectedValue = Convert.ToInt32(HardwareRepair.Serviced).ToString();
                chbIsOfficeDamage.Checked = HardwareRepair.IsOfficeDamage;
                chbHard.Checked = HardwareRepair.IsHardDisk;
                chbModem.Checked = HardwareRepair.IsModem;
                chbIsFormated.Checked = HardwareRepair.IsFormated;

                //txtNumbersOfMechanicallyBeforeRemoveTheSeal.Text = HardwareRepair.NumbersOfMechanicallyBeforeRemoveTheSeal.ToString();
                //txtNumbersOfMechanicallyAfterRemoveTheSeal.Text = HardwareRepair.NumbersOfMechanicallyAfterRemoveTheSeal.ToString();
                rbDischargeInformation.Items.FindByValue(Convert.ToInt32(HardwareRepair.DischargeInformation).ToString());

                GrdHardwareRepairBind();
            }


        }
        /// -------------------------------------------------------------------------------------------------------
        public bool Save()
        {

            OilProductsDistributionCompany.Failure.JHardwareRepair HardwareRepair = new OilProductsDistributionCompany.Failure.JHardwareRepair();
            HardwareRepair.Code = Code;
            HardwareRepair.MalfunctionCode = MalfunctionCode;
            HardwareRepair.RealDamageCode = ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRealTableDamageCode).Code;

            DataTable OilTableDamages_dt = WebClassLibrary.JWebDataBase.GetDataTable("SELECT code  FROM OilTableDamages WHERE FailureNumber = " + ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRealTableDamageCode).Code);
            if (OilTableDamages_dt != null && OilTableDamages_dt.Rows.Count > 0)
                HardwareRepair.RealDamageCode = int.Parse(OilTableDamages_dt.Rows[0]["code"].ToString());
            else
                HardwareRepair.RealDamageCode = 0;

            HardwareRepair.PTCode = ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlPTCode).Code;
            HardwareRepair.FormSealCode = ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlFormSealCode).Code;
            HardwareRepair.WarGoodReplaceCode = ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodReplaceCode).Code;
            HardwareRepair.WarGoodCrashCode = ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).Code;
            //HardwareRepair.NumbersOfMechanicallyBeforeRemoveTheSeal = Convert.ToInt32(txtNumbersOfMechanicallyBeforeRemoveTheSeal.Text);
            //HardwareRepair.NumbersOfMechanicallyAfterRemoveTheSeal = Convert.T.oInt32(txtNumbersOfMechanicallyAfterRemoveTheSeal.Text);
            HardwareRepair.DischargeInformation = Convert.ToBoolean(Convert.ToInt32(rbDischargeInformation.SelectedValue));
            HardwareRepair.Serviced = Convert.ToByte(rbIsServiced.SelectedValue);
            HardwareRepair.IsOfficeDamage = chbIsOfficeDamage.Checked;
            HardwareRepair.IsHardDisk = chbHard.Checked;
            HardwareRepair.IsModem = chbModem.Checked;
            HardwareRepair.IsFormated = chbIsFormated.Checked;
            if (Code > 0)
                return HardwareRepair.update();
            else
            {
                Code = HardwareRepair.Insert();
                return Code > 0 ? true : false;
            }

        }
        /// -------------------------------------------------------------------------------------------------------
        public void RedirectToMalfunction()
        {
            WebClassLibrary.JWebManager.LoadControl("Malfunction"
                  , "~/WebOilManagement/Forms/JMalfunctionUpdateControl.ascx"
                  , "اعلام خرابی"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("ReferCode", ReferCode.ToString()) }
                  , WebClassLibrary.WindowTarget.CurrentWindow
                  , true, false, true, 650, 450);
        }
        /// -------------------------------------------------------------------------------------------------------
        #endregion Methods

        #region Events
        /// -------------------------------------------------------------------------------------------------------
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                GrdHardwareRepairBind();
            // RedirectToMalfunction();
            else
                WebClassLibrary.JWebManager.ShowMessage("عملیات با خطا مواجه شد. پس از بررسی اطلاعات وارد شده مجددا سعی نمایید.");
        }
        /// -------------------------------------------------------------------------------------------------------
        protected void btnClose_Click(object sender, EventArgs e)
        {
            RedirectToMalfunction();
        }
        /// -------------------------------------------------------------------------------------------------------
        protected void btnJOilSealFormUpdateControl_Click(object sender, ImageClickEventArgs e)
        {
            OilProductsDistributionCompany.Failure.JMalfunction Malfunction = new OilProductsDistributionCompany.Failure.JMalfunction();
            Malfunction.GetData(MalfunctionCode);
            WebClassLibrary.JWebManager.LoadControl("Malfunction"
                 , "~/WebOilManagement/Forms/JOilSealFormUpdateControl.ascx"
                 , "ثبت فرم پلمپ"
                 , new List<Tuple<string, string>>() { new Tuple<string, string>("GSID", Malfunction.GasStationCode.ToString()) }
                 , WebClassLibrary.WindowTarget.NewWindow
                 , true, false, true, 650, 450);
        }
        /// -------------------------------------------------------------------------------------------------------
        protected void rbIsServiced_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).Code == 0 && int.Parse(rbIsServiced.SelectedValue) > 0)
            {
                rbIsServiced.Items.FindByValue("0").Selected = true;
                WebClassLibrary.JWebManager.ShowMessage("لطفا ابتدا قطعه معیوب را انتخاب کنید.");
            }

            switch (rbIsServiced.SelectedValue)
            {
                case "0"://هیچکدام
                    tdWarGoodReplaceCode.Disabled = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).IsRequired = false;
                    break;
                case "1"://سرویس
                    tdWarGoodReplaceCode.Disabled = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlFormSealCode).IsRequired = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).IsRequired = true;
                    break;
                case "2"://تعویض
                    tdWarGoodReplaceCode.Disabled = false;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).IsRequired = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodReplaceCode).IsRequired = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlFormSealCode).IsRequired = true;
                    //                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodReplaceCode).SQL = @"
                    //                    SELECT  WarGoods.Serial AS Code ,WTOG.Name AS Title  
                    //                            FROM WarGoods 
                    //                            LEFT JOIN WarTypesOfGoods WTOG ON (WarGoods.TypeOfGoodsCode=WTOG.Code)
                    //                            LEFT JOIN WarWarehouse WWH ON(WWH.Code=WarGoods.WarehouseCode)
                    //                            LEFT JOIN OilGasStation OGS ON(OGS.OwnerCode=WWH.OwnerCode)
                    //                            LEFT JOIN OilArea OA ON(OGS.Area=OA.Code)
                    //                            LEFT JOIN OilSupplierDetails ON( OilSupplierDetails.ZoneCode = OA.OilZoneCode)";
                    break;
                case "3"://عدم وجود قطعه
                    tdWarGoodReplaceCode.Disabled = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodCrashCode).IsRequired = true;
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCSWarGoodReplaceCode).IsRequired = false;
                    break;
            }
        }
        /// -------------------------------------------------------------------------------------------------------
        protected void btnJCSWarGoodCrash_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewState["OilGasStation"] != null && !string.IsNullOrEmpty(ViewState["OilGasStation"].ToString()))
                WebClassLibrary.JWebManager.LoadControl("Goods"
                  , "~/WebWarehouseManagement/Forms/JGoodsUpdateControl.ascx"
                  , "درج کالا"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("WhCode", ViewState["OilGasStation"].ToString()) }
                  , WebClassLibrary.WindowTarget.NewWindow
                  , true, false, true, 650, 450);
            else
                WebClassLibrary.JWebManager.ShowMessage("ابتدا باید برای جایگاه انبار تعریف کنید.");
        }
        /// -------------------------------------------------------------------------------------------------------
        protected void btnJCSWarGoodReplace_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewState["OilSupplier"] != null && !string.IsNullOrEmpty(ViewState["OilSupplier"].ToString()))
                WebClassLibrary.JWebManager.LoadControl("Goods"
                  , "~/WebWarehouseManagement/Forms/JGoodsUpdateControl.ascx"
                  , "درج کالا"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("WhCode", ViewState["OilSupplier"].ToString()) }
                  , WebClassLibrary.WindowTarget.NewWindow
                  , true, false, true, 650, 450);
            else
                WebClassLibrary.JWebManager.ShowMessage("ابتدا باید برای پیمانکار انبار تعریف کنید.");
        }
        /// -------------------------------------------------------------------------------------------------------
        #endregion Events

    }
}