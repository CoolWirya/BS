using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebOilManagement.Forms
{
    public partial class JMalfunctionUpdateControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// Product by Karamad ، Edit By Sheikh Nezami
        /// </summary>

        #region Init
        protected global::WebControllers.MainControls.JCustomListSelectorControl JCustomListSelectorControlGasStation;
        protected global::WebControllers.MainControls.JCustomListSelectorControl JCustomListSelectorControlNozzle;
        protected global::WebControllers.MainControls.JSearchPersonControl JSearchPersonControl;
        protected global::WebControllers.MainControls.JCustomListSelectorControl JCustomListSelectorControlDamage;
        protected global::WebAutomation.Refer.JReferViewControl jReferViewControl;
        protected global::WebControllers.MainControls.Date.JDateControl dteRealMalfunction;
        protected global::WebControllers.ArchiveDocument.JArchiveControl JArchiveControl;
        public const string ConstClassName = "WebOilManagement.JWebFailure";

        int Code;
        int ReferCode;
        bool OpenedFromInbox = false;

        #endregion Init

        #region Public
        /// ---------------------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            int.TryParse(Request["ReferCode"], out ReferCode);
            if (ReferCode > 0)
            {
                rpvMain.Enabled = false;
                OpenedFromInbox = true;
            }

            // Get Refer Code From DataBase if Object exists (if refer code is 0)
            if (ReferCode == 0 && Code > 0)
            {
                ReferCode = (new Automation.JARefer()).FindRefer(ConstClassName, Code, 0);
            }
            // Get Code using ReferCode
            if (ReferCode > 0)
            {
                Automation.JARefer jaRefer = new Automation.JARefer(ReferCode);
                Code = (new Automation.JAObject(jaRefer.object_code)).ObjectCode;
                jReferViewControl.LoadRefers(jaRefer.object_code);
                btnSave.Visible = false;
                btnDelete.Visible = false;
                //btnRefer.Visible = false;
                txtDiscription.ReadOnly = true;
                txtTimeHour.ReadOnly = true;
                txtTimeMinute.ReadOnly = true;
                cmbStatusMalfunction.Enabled = false;
                cmbTypeOfMulfunction.Enabled = false;
                //JCustomListSelectorControlGasStation.isReadOnly = true;
                JCustomListSelectorControlDamage.isReadOnly = true;
                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).isReadOnly = true;

            }
            else
            {
                btnHardware.Visible = false;
                btnSoftware.Visible = false;
                btnHelpDesk.Visible = false;
                btnAfterReviewing.Visible = false;
                dteRealMalfunction.isReadOnly = true;
                txtRealMalfunctionDescription.ReadOnly = true;
                txtRealMalfunctionHour.ReadOnly = true;
                txtRealMalfunctionMinute.ReadOnly = true;
            }

            if (!IsPostBack)
            {
                LoadTypeOfMulfunction();
                LoadStatusMalfunction();
                //LoadGasStation();
                txtTimeMinute.Text = DateTime.Now.Minute.ToString("00");
                txtTimeHour.Text = DateTime.Now.Hour.ToString("00");
                _SetForm();
            }
            JArchiveControl.ClassName = ConstClassName;
            JArchiveControl.ObjectCode = Code;
            JArchiveControl.LoadArchive();
            // Damage Custom List Search
            JCustomListSelectorControlDamage.Code = 0;
            JCustomListSelectorControlDamage.SQL = @"SELECT FailureNumber AS Code,NAME AS Title,case FailureTypeCode WHEN 1 THEN N'الکتريکي' 
                                                                                                                WHEN 2 THEN N'مکانيکي' ELSE N'کارت هوشمند' END AS FailureTypeCode,
                                                                                                                ExpertiseRequired,case Urgency WHEN 1 THEN N'بالا' 
                                                                                                              WHEN 2 THEN N'متوسط' ELSE N'پايين' END AS Urgency FROM OilTableDamages";
        }
        /// ---------------------------------------------------------------------------
        #endregion Public

        //private void LoadGasStation()
        //{
        //    ViewState["GasStationes"] = OilProductsDistributionCompany.GasStation.JGasStationes.GetTitles();
        //    cmbGasStation.DataSource = (DataTable)ViewState["GasStationes"];
        //    cmbGasStation.DataTextField = "Title";
        //    //     cmbGasStation.DataValueField = "Number";
        //    cmbGasStation.DataValueField = "Code";
        //    cmbGasStation.DataBind();

        //    ((DataTable)ViewState["GasStationes"]).DefaultView.RowFilter = " Code = " + cmbGasStation.SelectedValue;
        //    if (((DataTable)ViewState["GasStationes"]).DefaultView.Count != 0)
        //    {
        //        txtNozzle.Text = string.Empty;
        //        txtGasStation.Text = ((DataTable)ViewState["GasStationes"]).DefaultView[0]["Number"].ToString();
        //        LoadNuzzel();
        //        txtNozzle.Text = cmbNozzle.SelectedValue;
        //    }
        //    LoadNuzzel();
        //}

        //private void LoadNuzzel()
        //{
        //    if (cmbGasStation.SelectedValue != null && !string.IsNullOrEmpty(cmbGasStation.SelectedValue))
        //    {


        //        cmbNozzle.DataSource = OilProductsDistributionCompany.Nozzle.JNozzleses.GetNuzzelByStationCode(int.Parse(cmbGasStation.SelectedValue));
        //        cmbNozzle.DataTextField = "Title";
        //        cmbNozzle.DataValueField = "Code";
        //        cmbNozzle.DataBind();

        //        txtNozzle.Text = cmbNozzle.SelectedValue;
        //    }
        //}


        #region Methods
        /// ---------------------------------------------------------------------------
        public void LoadTypeOfMulfunction()
        {
            cmbTypeOfMulfunction.DataSource = OilProductsDistributionCompany.Define.JTypeOfMalfunctions.GetDataTable(OilProductsDistributionCompany.JDefine.TypeOfMalfunction);
            cmbTypeOfMulfunction.DataTextField = "Name";
            cmbTypeOfMulfunction.DataValueField = "Code";
            cmbTypeOfMulfunction.DataBind();
        }
        /// ---------------------------------------------------------------------------
        public void LoadStatusMalfunction()
        {
            DataTable Dt = new DataTable();
            Dt = WebClassLibrary.JDataManager.EnumToDataTable(typeof(OilProductsDistributionCompany.Failure.JStatusMalfunction));
            cmbStatusMalfunction.DataSource = Dt;
            cmbStatusMalfunction.DataTextField = "Key";
            cmbStatusMalfunction.DataValueField = "Value";
            cmbStatusMalfunction.DataBind();
        }
        /// ---------------------------------------------------------------------------
        public void _SetForm()
        {
            if (Code > 0)
            {
                //ViewState["Code"] = int.TryParse(Request["Code"], out Code);
                OilProductsDistributionCompany.Failure.JMalfunction MalFunction = new OilProductsDistributionCompany.Failure.JMalfunction();
                MalFunction.GetData(Code);

                if (MalFunction.NozzleCode != null && MalFunction.NozzleCode != 0)
                {
                    txtNozzleCode.Text = MalFunction.NozzleCode.ToString();
                    //txtNozzleTitle.Text = MalFunction..ToString();
                    DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("select number from oilnozzle where code = " + txtNozzleCode.Text);
                    if (dt != null && dt.Rows.Count > 0)
                        txtNozzleTitle.Text = dt.Rows[0][0].ToString();
                }
                if (MalFunction.GasStationCode != null && MalFunction.GasStationCode != 0)
                {
                    hdnGSCode.Value = MalFunction.GasStationCode.ToString();
                    DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("select name,number from oilgasstation where code = " + hdnGSCode.Value);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        txtGasStationCode.Text = dt.Rows[0]["number"].ToString();
                        txtGasStationTitle.Text = dt.Rows[0]["name"].ToString();
                    }
                    //DataTable Dv = ((DataTable)ViewState["GasStationes"]);
                    //Dv.DefaultView.RowFilter = " Code = " + txtGasStation.Text;

                    //if (Dv.DefaultView.Count != 0)
                    //txtGasStation.Text = Dv.DefaultView[0]["Number"].ToString();
                }

                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = MalFunction.HangerCode;
                txtTimeHour.Text = MalFunction.DateTimeMalfunction.Hour.ToString("00");
                txtTimeMinute.Text = MalFunction.DateTimeMalfunction.Minute.ToString("00");
                DataTable OilTableDamages_dt = WebClassLibrary.JWebDataBase.GetDataTable("select FailureNumber from OilTableDamages where code = " + MalFunction.DamageCode);
                if (OilTableDamages_dt.Rows.Count > 0)

                    JCustomListSelectorControlDamage.Code = int.Parse(OilTableDamages_dt.Rows[0]["FailureNumber"].ToString());
                else
                    JCustomListSelectorControlDamage.Code = 0;
                JCustomListSelectorControlDamage.SQL = @"SELECT FailureNumber AS Code,NAME AS Title,case FailureTypeCode WHEN 1 THEN N'الکتريکي' 
                                                                                                                WHEN 2 THEN N'مکانيکي' ELSE N'کارت هوشمند' END AS FailureTypeCode,
                                                                                                                ExpertiseRequired,case Urgency WHEN 1 THEN N'بالا' 
                                                                                                                WHEN 2 THEN N'متوسط' ELSE N'پايين' END AS Urgency FROM OilTableDamages";
                txtDiscription.Text = MalFunction.Description;
                cmbStatusMalfunction.SelectedValue = MalFunction.Status.GetHashCode().ToString();
                cmbTypeOfMulfunction.SelectedValue = MalFunction.TypeOfMalfunction.ToString();

                dteRealMalfunction.Date = MalFunction.RealMalfunctionDate;
                txtRealMalfunctionHour.Text = MalFunction.RealMalfunctionDate.Hour.ToString();
                txtRealMalfunctionMinute.Text = MalFunction.RealMalfunctionDate.Minute.ToString();
                txtRealMalfunctionDescription.Text = MalFunction.RealMalfunctionDescription;

                if (MalFunction.IsOfficeDamage)
                {
                    txtNozzleTitle.Text = string.Empty;
                    txtNozzleCode.Text = string.Empty;
                    hdnNozzleCode.Value = string.Empty;
                    txtNozzleCode.Enabled = false;
                    txtNozzleTitle.Enabled = false;
                    chbIsOfficeDamage2.Checked = true;
                }
                else
                {
                    txtNozzleCode.Enabled = true;
                    txtNozzleTitle.Enabled = true;
                    chbIsOfficeDamage2.Checked = false;
                }

                //if (MalFunction.ClosedNotSolved)
                //{
                //    lblNotSolvedDate.Text = MalFunction.NotSolvedDate.ToString();
                //    // lblNotSolvedTime.Text = MalFunction.NotSolvedTime.ToString();
                //    chbClosedNotSolved.Checked = MalFunction.ClosedNotSolved;
                //    txtNotSolvedDescription.Text = MalFunction.NotSolvedDescription;
                //}

            }
        }
        /// ---------------------------------------------------------------------------
        public bool Save()
        {
            #region Validation Controls
            //---------------------------------------------------------------------------------------------
            string errorMessage = string.Empty;

            if (!chbIsOfficeDamage2.Checked && txtNozzleCode.Text == string.Empty)
                errorMessage += "<br>نازل انتخاب نشده است";

            if (txtGasStationCode.Text == string.Empty)
            {
                errorMessage += "<br>جایگاه انتخاب نشده است";
            }
            //else
            //{
            //    OilProductsDistributionCompany.GasStation.JGasStation JGas = new OilProductsDistributionCompany.GasStation.JGasStation();
            //    JGas.GetData(int.Parse(hdnGSCode.Value));
            //    if(JGas.OwnerCode ==0)
            //        errorMessage += "<br> مالک جایگاه مورد نظر تعریف نشده ابتدا مالک جایگار را ثبت کنید ";
            //}

            if (JCustomListSelectorControlDamage.Code <= 0)
                errorMessage += "<br>نوع خرابی مشخص نشده است";
            //if (((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode <= 0)
            //    errorMessage += "<br> اعلام کننده خرابی مشخص نشده است";



            if (errorMessage != string.Empty)
            {
                errorMessage = "ابتدا مشکلات زیر را بررسی و برطرف نمایید" + errorMessage;
                // WebClassLibrary.JWebManager.ShowMessage(errorMessage);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Error", "<script>Show_Message('" + errorMessage + "', '" + WebClassLibrary.MessageType.Normal.ToString() + "', '300px', '150px');</script>", false);
                return false;
            }
            //---------------------------------------------------------------------------------------------
            #endregion Validation Controls

            if (!string.IsNullOrEmpty(hdnGSCode.Value) && int.Parse(hdnGSCode.Value) > 0 &&
                JCustomListSelectorControlDamage.Code > 0
                )
            {
                OilProductsDistributionCompany.Failure.JMalfunction MalFunction = new OilProductsDistributionCompany.Failure.JMalfunction();
                MalFunction.Code = Code;

                MalFunction.GasStationCode = int.Parse(hdnGSCode.Value);
                if (txtNozzleCode.Text != string.Empty)
                    MalFunction.NozzleCode = int.Parse(txtNozzleCode.Text);
                else
                    MalFunction.NozzleCode = 0;

                MalFunction.HangerCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;
                MalFunction.HangerName = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonName;
                MalFunction.DateTimeMalfunction = DateTime.Parse(DateTime.Now.ToShortDateString() + " " + txtTimeHour.Text + ":" + txtTimeMinute.Text);
                if (JCustomListSelectorControlDamage.Code != null)
                {
                    DataTable OilTableDamages_dt = WebClassLibrary.JWebDataBase.GetDataTable("select code  from OilTableDamages where FailureNumber = " + JCustomListSelectorControlDamage.Code);
                    if (OilTableDamages_dt != null && OilTableDamages_dt.Rows.Count > 0)
                        MalFunction.DamageCode = int.Parse(OilTableDamages_dt.Rows[0]["code"].ToString());
                    else
                        MalFunction.DamageCode = 0;
                }
                MalFunction.Description = txtDiscription.Text;
                MalFunction.Status = (OilProductsDistributionCompany.Failure.JStatusMalfunction)Convert.ToInt32(cmbStatusMalfunction.SelectedValue);
                MalFunction.TypeOfMalfunction = Convert.ToInt32(cmbTypeOfMulfunction.SelectedValue);

                DataTable dtSupplier = WebClassLibrary.JWebDataBase.GetDataTable(@"
                                                                                    SELECT  OS.* FROM OilGasStation  GS
				
				                                                                                    LEFT JOIN OilArea				OA	ON(OA.Code		= GS.OilAreaCode)
				                                                                                    LEFT JOIN OilZone				OZ	ON(OZ.Code		= OA.OilZoneCode)
				                                                                                    LEFT JOIN OilSupplierDetails	OSD ON(OSD.ZoneCode = OZ.Code)
				                                                                                    LEFT JOIN OilSupplier			OS  ON(OS.Code		= OSD.SupplierCode)
                                                                                             WHERE GS.Code = " + MalFunction.GasStationCode + " AND OS.CODE IS NOT NULL ");

                if (dtSupplier.Rows.Count > 0 && dtSupplier.Rows[0]["Code"] != null)
                    MalFunction.SupplierCode = (int)dtSupplier.Rows[0]["Code"];
                else
                    MalFunction.SupplierCode = 0;
                if (Code == 0)
                    MalFunction.RegistrarCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                if (dteRealMalfunction.Date.Year > 1)
                    MalFunction.RealMalfunctionDate = new DateTime(dteRealMalfunction.Date.Year, dteRealMalfunction.Date.Month, dteRealMalfunction.Date.Day, Convert.ToInt32(txtRealMalfunctionHour.Text), Convert.ToInt32(txtRealMalfunctionMinute.Text), 0);
                MalFunction.RealMalfunctionDescription = txtRealMalfunctionDescription.Text;
                MalFunction.IsOfficeDamage = chbIsOfficeDamage2.Checked;
                //if (chbClosedNotSolved.Checked)
                //{
                //    MalFunction.NotSolvedDate = DateTime.Now;
                //    MalFunction.NotSolvedDescription = txtNotSolvedDescription.Text;
                //    MalFunction.ClosedNotSolved = true;
                //    lblClosedNotSolved.Text = "تیکت بسته شد.";
                //}
                ViewState["Code"] = Code;
                if (Code > 0)
                    return MalFunction.update();
                else
                {
                    Code = MalFunction.Insert();
                    return Code > 0 ? true : false;
                }
            }
            else
            {
                return false;
            }
        }
        /// --------------------------------------------------------------------------------------------------------------------------------------------
        #endregion Methods

        
        #region Events
        /// --------------------------------------------------------------------------------------------------------------------------------------------
        public void GasStation_OnSelectedCodeChanged(object sender, WebControllers.MainControls.JCustomListSelectorControl.SearchEventArgs e)
        {
            JCustomListSelectorControlNozzle.SQL = @"SELECT on1.Code, on1.Number AS Title FROM OilNozzle on1
                                                     INNER JOIN OilPump op ON op.Code = on1.PumpCode
                                                     WHERE op.GasStationCode = " + e.SelectedCode;
        }
        /// --------------------------------------------------------------------------------------------------------------------------------------------
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                //WebClassLibrary.JWebManager.CloseAndRefresh();
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Close And Refresh Grid", "<script>GetRadWindow().BrowserWindow.RefreshGrid();CloseDialog(null);</script>", false);
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Error", "<script>alert('عملیات با خطا مواجه شد. پس از بررسی اطلاعات وارد شده مجددا سعی نمایید');</script>", false);
            //WebClassLibrary.JWebManager.ShowMessage("عملیات با خطا مواجه شد. پس از بررسی اطلاعات وارد شده مجددا سعی نمایید.");
        }
        /// --------------------------------------------------------------------------------------------------------------------------------------------
        protected void btnRefer_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                OilProductsDistributionCompany.Failure.JMalfunction mal = new OilProductsDistributionCompany.Failure.JMalfunction();
                mal.GetData(Code);
                //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Close And Refresh Grid", "<script>GetRadWindow().BrowserWindow.RefreshGrid();CloseDialog(null);</script>", false);
                //WebControllers.Automation.JAutomationRefer.ShowClientRefer(ConstClassName, 0, Code, OilProductsDistributionCompany.Failure.JMalfunctiones.GetDataTable(Code), ReferCode, "ارجاع خرابی");
                DataTable dt1 = OilProductsDistributionCompany.Failure.JMalfunctiones.GetDataTable(Code);
                DataTable dt2 = new DataTable();
                dt2.BeginInit();
                //OK=2 AND NeedGood=0 AND HD=0
                dt2.Columns.Add("WorkFlowCondition");
                dt2.Columns.Add("OK");
                dt2.Columns.Add("NeedGood");
                dt2.Columns.Add("HD");
                dt2.Columns.Add("GasStationCode");
                dt2.Columns.Add("WarGoodRequest_Code");
                dt2.Columns.Add("ClassName");
                dt2.Columns.Add("ObjectCode");
                DataRow dr;
                dr = dt2.NewRow();
                dr.BeginEdit();

                CheckStatusOfMalfunction(ref dr, mal.Code);
                dr["GasStationCode"] = mal.GasStationCode;

                //WarehouseManagement.Goods.JWarGoodRequest WGR = new WarehouseManagement.Goods.JWarGoodRequest();
                //OilProductsDistributionCompany.JSupplier Sup = new OilProductsDistributionCompany.JSupplier();
                //Sup.GetData(mal.SupplierCode);
                //WGR.ClassName = "WebOilManagement.JWebFailure";
                //WGR.ObjectCode=mal.Code;
                //WGR.RequestDate=DateTime.Now;
                //WGR.UserCode=WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                //WGR.WarCode = Sup.WarCode;
                int WarReqCode = WarehouseManagement.Goods.JWarGoodRequest.FindByClassNameObjectCode("WebOilManagement.JWebFailure", mal.Code);

                if (WarReqCode > 0)
                {
                    dr["ClassName"] = "WebWarehouseManagement.JWebWarehouseManagement";
                    dr["ObjectCode"] = WarReqCode;
                }

                dr.EndEdit();
                dt2.Rows.Add(dr);
                dt2.EndInit();

                DataTable final_dt = ClassLibrary.JTable.Join(dt1, dt2);
                WebControllers.Automation.JAutomationRefer.ShowRefer(ConstClassName, 0, Code, final_dt, ReferCode, "ارجاع خرابی");

            }
            else
                WebClassLibrary.JWebManager.ShowMessage("عملیات با خطا مواجه شد. پس از بررسی اطلاعات وارد شده مجددا سعی نمایید.");
        }

        private void CheckStatusOfMalfunction(ref DataRow dr, int MalCode)
        {
            dr["WorkFlowCondition"] = null;
            dr["HD"] = 0;
            dr["OK"] = 0;
            dr["NeedGood"] = 0;

            DataTable HardDatatable = OilProductsDistributionCompany.Failure.JHardwareRepairs.FillByMalCode(MalCode);

            OilProductsDistributionCompany.Failure.JSoftwareRepair Sr = new OilProductsDistributionCompany.Failure.JSoftwareRepair();
            Sr.GetDataByMalfunction(MalCode);

            OilProductsDistributionCompany.Failure.JAfterReviewing Ar = new OilProductsDistributionCompany.Failure.JAfterReviewing();
            Ar.GetDataByMalfunction(MalCode);

            if (Ar.Code != 0)
            {
                if (!Ar.FixDefects)
                {
                    switch (Ar.DontFixDefects)
                    {
                        case OilProductsDistributionCompany.Failure.JDontFixDefects.DealingWithCenter:
                            dr["OK"] = 2;
                            dr["HD"] = 0;
                            return;

                        case OilProductsDistributionCompany.Failure.JDontFixDefects.DeliveredSoftware:
                            dr["OK"] = 2;
                            dr["HD"] = 0;
                            return;

                        case OilProductsDistributionCompany.Failure.JDontFixDefects.MechanicalFault:
                            dr["OK"] = 2;
                            dr["HD"] = 0;
                            return;
                        case OilProductsDistributionCompany.Failure.JDontFixDefects.NeedToExamineMore:
                            dr["OK"] = 2;
                            dr["HD"] = 0;
                            return;
                        case OilProductsDistributionCompany.Failure.JDontFixDefects.NeedToTrack:
                            OilProductsDistributionCompany.Failure.JMalfunction Mal = new OilProductsDistributionCompany.Failure.JMalfunction();

                            dr["OK"] = 2;
                            dr["NeedGood"] = 1;
                            dr["HD"] = 0;
                            return;
                        case OilProductsDistributionCompany.Failure.JDontFixDefects.None:
                            dr["OK"] = 2;
                            dr["HD"] = 0;
                            return;
                        case OilProductsDistributionCompany.Failure.JDontFixDefects.Other:
                            dr["OK"] = 2;
                            dr["HD"] = 0;
                            return;
                        case OilProductsDistributionCompany.Failure.JDontFixDefects.TheAbsenceOfGasStation:
                            dr["OK"] = 2;
                            dr["HD"] = 0;
                            return;

                    }

                }
                else
                {
                    dr["OK"] = 1;
                    dr["HD"] = 0;
                    return;
                }

            }

            if (Sr.Code != 0)
            {
                dr["OK"] = 2;
                dr["HD"] = 1;
                return;
            }

            foreach (DataRow HDr in HardDatatable.Rows)
            {
                if (HDr["Serviced"].ToString() == "3"
                    && ((HDr["WarGoodReplaceCode"].ToString() == string.Empty)
                    || (HDr["WarGoodReplaceCode"].ToString() == "0")))
                {
                    dr["OK"] = 2;
                    dr["NeedGood"] = 1;
                    return;
                }
                else if (HDr["Serviced"].ToString() == "2")
                {
                    if (((HDr["WarGoodReplaceCode"].ToString() == string.Empty)
                    || (HDr["WarGoodReplaceCode"].ToString() == "0")))
                    {
                        dr["OK"] = 2;
                        dr["NeedGood"] = 1;
                        dr["HD"] = 1;
                        return;
                    }
                    else
                    {
                        dr["OK"] = 1;
                        dr["NeedGood"] = 0;
                        dr["HD"] = 0;
                        return;
                    }
                }

            }


        }
        /// --------------------------------------------------------------------------------------------------------------------------------------------
        protected void btnSoftware_Click(object sender, EventArgs e)
        {
            WebClassLibrary.JWebManager.LoadControl(
                "OilSoftwareRepair",
                "~/WebOilManagement/Forms/JSoftwareRepairUpdateControl.ascx",
                "تعمیرات نرم افزاری",
                new List<Tuple<string, string>> { new Tuple<string, string>("ReferCode", ReferCode.ToString()) },
                WebClassLibrary.WindowTarget.CurrentWindow,
                false, false, false, 0, 0, false);
        }
        /// --------------------------------------------------------------------------------------------------------------------------------------------

        protected void btnHardware_Click(object sender, EventArgs e)
        {

            OilProductsDistributionCompany.Failure.JMalfunction Malfunction = new OilProductsDistributionCompany.Failure.JMalfunction();
            OilProductsDistributionCompany.GasStation.JGasStation GasStation = new OilProductsDistributionCompany.GasStation.JGasStation();
            OilProductsDistributionCompany.JSupplier Supplier = new OilProductsDistributionCompany.JSupplier();



            Malfunction.GetData(Code);
            GasStation.GetData(Malfunction.GasStationCode);
            Supplier.GetData(Malfunction.SupplierCode);


            ViewState["OilMalfunction"] = Code;
            ViewState["OilGasStation"] = GasStation.WarCode;
            ViewState["OilSupplier"] = Supplier.WarCode;

            WarehouseManagement.Warehouse.JWarehouse War;
            WarehouseManagement.Warehouse.JWarehouseTable WHT = new WarehouseManagement.Warehouse.JWarehouseTable();

            #region  Gas Station OwnerCode

            if (GasStation.WarCode == 0)
            {
                WebClassLibrary.JWebManager.LoadControl(
               "RealPerson",
               "~/WebBaseDefine/Forms/JToolRealPersonUpdateControl.ascx",
               "درج مالک جــایگاه",
               new List<Tuple<string, string>> { new Tuple<string, string>("Action", "OilProductsDistributionCompany.GasStation.JGasStation.updateOwner")
                                                                            , new Tuple<string, string>("Parameters", GasStation.Code.ToString())
                                                                            , new Tuple<string, string>("R_URL", "~/WebOilManagement/Forms/JMalfunctionUpdateControl.ascx")
                                                                            , new Tuple<string, string>("R_ReferCode", ReferCode.ToString())
                                                                            , new Tuple<string, string>("R_SUID","OilHardwareRepair") 
                                                                            , new Tuple<string, string>("R_Name", "تعمیرات سخت افزاری") },
               WebClassLibrary.WindowTarget.CurrentWindow,
               false, true, false, 0, 0, false);


            }

            #endregion Gas Station OwnerCode

            #region Gas Station WearHouse Exist

            if (WarehouseManagement.Warehouse.JWarehousees.GetDataTable(GasStation.WarCode).Rows.Count == 0
                ||
                WarehouseManagement.Warehouse.JWarehousees.GetDataTable(GasStation.WarCode).Rows[0]["OwnerCode"].ToString() != GasStation.OwnerCode.ToString())
            {
                GasStation.updateOwner(GasStation.Code, GasStation.OwnerCode);
            }
            #endregion  Gas Station WearHouse Exist

            #region Supplier WearHouse Exist

            if (WarehouseManagement.Warehouse.JWarehousees.GetDataTable(Supplier.WarCode).Rows.Count == 0
                ||
                WarehouseManagement.Warehouse.JWarehousees.GetDataTable(Supplier.WarCode).Rows[0]["OwnerCode"].ToString() != Supplier.PCode.ToString())
            {
                Supplier.updateOwner(Supplier.Code, Supplier.PCode);
            }
            #endregion  Supplier WearHouse Exist



            WebClassLibrary.JWebManager.LoadControl(
             "OilHardwareRepair",
             "~/WebOilManagement/Forms/JHardwareRepairUpdateControl.ascx",
             "تعمیرات سخت افزاری",
             new List<Tuple<string, string>> { new Tuple<string, string>("ReferCode", ReferCode.ToString()) },
             WebClassLibrary.WindowTarget.CurrentWindow,
             false, true, false, 0, 0, false);

        }
        /// --------------------------------------------------------------------------------------------------------------------------------------------
        protected void btnAfterReviewing_Click(object sender, EventArgs e)
        {
            WebClassLibrary.JWebManager.LoadControl(
                "OilSoftwareRepair",
                "~/WebOilManagement/Forms/JAfterReviewingUpdateControl.ascx",
                "تعمیرات نرم افزاری",
                new List<Tuple<string, string>> { new Tuple<string, string>("ReferCode", ReferCode.ToString()) },
                WebClassLibrary.WindowTarget.CurrentWindow,
                false, false, false, 0, 0, false);

        }
        /// --------------------------------------------------------------------------------------------------------------------------------------------
        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
        /// --------------------------------------------------------------------------------------------------------------------------------------------
        //protected void cmbGasStation_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        //    DataTable Dv = ((DataTable)ViewState["GasStationes"]);
        //    Dv.DefaultView.RowFilter = " Code = " + cmbGasStation.SelectedValue;

        //    if (Dv.DefaultView.Count != 0)
        //    {
        //        txtNozzle.Text = string.Empty;
        //        txtGasStation.Text = Dv.DefaultView[0]["Number"].ToString();
        //        LoadNuzzel();
        //        txtNozzle.Text = cmbNozzle.SelectedValue;
        //    }
        //    else
        //    {
        //        txtNozzle.Text = string.Empty;
        //        txtGasStation.Text = string.Empty;
        //        LoadNuzzel();
        //        txtNozzle.Text = cmbNozzle.SelectedValue;
        //    }
        //}

        //protected void txtGasStation_TextChanged(object sender, EventArgs e)
        //{
        //    if (ViewState["GasStationes"] != null)
        //    {
        //        DataTable Dv = ((DataTable)ViewState["GasStationes"]);
        //        Dv.DefaultView.RowFilter = " Number = " + txtGasStation.Text;
        //        if (Dv.DefaultView.Count != 0)
        //            if (cmbGasStation.FindItemByValue(Dv.DefaultView[0]["Code"].ToString()) != null)
        //            {

        //                LoadNuzzel();
        //                txtNozzle.Text = cmbNozzle.SelectedValue;
        //                cmbGasStation.FindItemByValue(Dv.DefaultView[0]["Code"].ToString()).Selected = true;
        //            }
        //            else
        //            {
        //                txtNozzle.Text = string.Empty;
        //                txtGasStation.Text = string.Empty;
        //                cmbGasStation.SelectedIndex = -1;
        //            }
        //    }
        //}

        //protected void txtNozzle_TextChanged(object sender, EventArgs e)
        //{
        //    if (cmbNozzle.FindItemIndexByValue(txtNozzle.Text) != null)
        //    {
        //        cmbNozzle.SelectedIndex = cmbNozzle.FindItemIndexByValue(txtNozzle.Text);
        //    }
        //    //  foreach(string Value in cmbNozzle.Items.
        //    else
        //    {
        //        cmbNozzle.SelectedIndex = -1;
        //        txtNozzle.Text = string.Empty;
        //    }
        //}

        //protected void cmbNozzle_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        //    txtNozzle.Text = cmbNozzle.SelectedValue;
        //}

        protected void chbClosedNotSolved_CheckedChanged(object sender, EventArgs e)
        {
            //    if (Code > 0)
            //    {
            //        if (chbClosedNotSolved.Checked)
            //        {
            //            if (txtNotSolvedDescription.Text != string.Empty)
            //            {
            //                OilProductsDistributionCompany.Failure.JMalfunction MalFunction = new OilProductsDistributionCompany.Failure.JMalfunction();
            //                MalFunction.Code = Code;
            //                //MalFunction.GasStationCode = int.Parse(cmbGasStation.SelectedValue);
            //                //MalFunction.NozzleCode = int.Parse(cmbNozzle.SelectedValue);
            //                MalFunction.HangerCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;
            //                MalFunction.HangerName = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonName;
            //                MalFunction.DateTimeMalfunction = DateTime.Parse(DateTime.Now.ToShortDateString() + " " + txtTimeHour.Text + ":" + txtTimeMinute.Text);
            //                MalFunction.DamageCode = JCustomListSelectorControlDamage.Code;
            //                MalFunction.Description = txtDiscription.Text;
            //                MalFunction.Status = (OilProductsDistributionCompany.Failure.JStatusMalfunction)Convert.ToInt32(cmbStatusMalfunction.SelectedValue);
            //                MalFunction.TypeOfMalfunction = Convert.ToInt32(cmbTypeOfMulfunction.SelectedValue);
            //                MalFunction.RegistrarCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            //                if (dteRealMalfunction.Date.Year > 1)
            //                    MalFunction.RealMalfunctionDate = new DateTime(dteRealMalfunction.Date.Year, dteRealMalfunction.Date.Month, dteRealMalfunction.Date.Day, Convert.ToInt32(txtRealMalfunctionHour.Text), Convert.ToInt32(txtRealMalfunctionMinute.Text), 0);
            //                MalFunction.RealMalfunctionDescription = txtRealMalfunctionDescription.Text;
            //                MalFunction.NotSolvedDate = DateTime.Now;
            //                MalFunction.NotSolvedDescription = txtNotSolvedDescription.Text;
            //                MalFunction.ClosedNotSolved = true;
            //                lblClosedNotSolved.Text = "تیکت بسته شد.";
            //                MalFunction.update();
            //                lblNotSolvedDate.Text = DateTime.Now.ToString();
            //                //  lblNotSolvedTime.Text = DateTime.Now.Hour.ToString() + " : " + DateTime.Now.Minute.ToString() + " : " + DateTime.Now.Second.ToString();
            //            }
            //            else
            //            {
            //                chbClosedNotSolved.Checked = false;
            //                lblClosedNotSolved.Text = "برای بستن خطا شرح را وارد کنید.";
            //                lblNotSolvedDate.Text = string.Empty;
            //                //  lblNotSolvedTime.Text = string.Empty;
            //            }
            //        }
            //        else
            //        {
            //            OilProductsDistributionCompany.Failure.JMalfunction MalFunction = new OilProductsDistributionCompany.Failure.JMalfunction();
            //            MalFunction.NotSolvedDescription = string.Empty;
            //            MalFunction.ClosedNotSolved = false;
            //            MalFunction.update();
            //            lblClosedNotSolved.Text = "تیکت مجددا باز شد.";
            //            lblNotSolvedDate.Text = string.Empty;
            //            //  lblNotSolvedTime.Text = string.Empty;
            //        }
            //    }
            //    else
            //    {
            //        chbClosedNotSolved.Checked = false;
            //        txtNotSolvedDescription.Text = string.Empty;
            //        lblClosedNotSolved.Text = "تیکت خطا ، هنوز ثبت نشده و امکان بستن ندارد.";
            //        lblNotSolvedDate.Text = string.Empty;
            //        // lblNotSolvedTime.Text = string.Empty;
            //    }
        }
        /// --------------------------------------------------------------------------------------------------------------------------------------------
        protected void chbIsOfficeDamage2_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIsOfficeDamage2.Checked)
            {
                txtNozzleTitle.Text = string.Empty;
                txtNozzleCode.Text = string.Empty;
                hdnNozzleCode.Value = string.Empty;
                txtNozzleCode.Enabled = false;
                txtNozzleTitle.Enabled = false;
            }
            else
            {
                txtNozzleCode.Enabled = true;
                txtNozzleTitle.Enabled = true;
            }

        }

        /// --------------------------------------------------------------------------------------------------------------------------------------------
        protected void btnHelpDesk_Click(object sender, EventArgs e)
        {

            WebClassLibrary.JWebManager.LoadControl(
               "OilHelpDesk",
               "~/WebOilManagement/Forms/JHelpDeskUpdateControl.ascx",
               "Help Desk",
               new List<Tuple<string, string>> { new Tuple<string, string>("ReferCode", ReferCode.ToString()) },
               WebClassLibrary.WindowTarget.CurrentWindow,
               false, false, false, 0, 0, false);
        }
        /// --------------------------------------------------------------------------------------------------------------------------------------------
        #endregion Events

    }
}