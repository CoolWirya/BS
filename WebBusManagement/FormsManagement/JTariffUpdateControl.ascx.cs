using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebClassLibrary;
using ClassLibrary.DataBase;
using ClassLibrary;


namespace WebBusManagement.FormsManagement
{
    public partial class JTariffUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        bool SeeTicketTransactionRow;
        bool SeeTicketTransactionColumn;
        bool AllowDeleteTariff = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
                LoadLine();
                LoadBus();
                LoadShift();
                LoadZones();
                LoadNahvayeHamkari();
                LoadtxtDriverWorkStatus();
                LoadtxtOnvaneShoghli();
                LoadtxtFaaliyat();
                LoadReportCode();

                ((WebControllers.MainControls.Date.JDateControl)txtStartDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl1).Code = 0;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl1).SQL = "select cap.Code,cast(isnull(EmpEmployee.PersonNumber,0) as nvarchar)+' - '+cap.Name Title from clsAllPerson cap left join EmpEmployee on cap.Code = EmpEmployee.pCode";
                _SetForm();
            }
        }
        public void LoadReportCode()
        {
            DataTable DttxtReportCode = new DataTable();
            DttxtReportCode = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name from subdefine where bcode = 9101057");
            txtReportCode.DataSource = DttxtReportCode;
            txtReportCode.DataTextField = "Name";
            txtReportCode.DataValueField = "Code";
            txtReportCode.DataBind();
        }


        public void LoadtxtFaaliyat()
        {
            DataTable DttxtFaaliyat = new DataTable();
            DttxtFaaliyat = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name from subdefine where bcode = 9101054");
            txtFaaliyat.DataSource = DttxtFaaliyat;
            txtFaaliyat.DataTextField = "Name";
            txtFaaliyat.DataValueField = "Code";
            txtFaaliyat.DataBind();
        }
        public void LoadtxtOnvaneShoghli()
        {
            DataTable DttxtOnvaneShoghli = new DataTable();
            DttxtOnvaneShoghli = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name from subdefine where bcode = 9101055");
            txtOnvaneShoghli.DataSource = DttxtOnvaneShoghli;
            txtOnvaneShoghli.DataTextField = "Name";
            txtOnvaneShoghli.DataValueField = "Code";
            txtOnvaneShoghli.DataBind();
        }
        public void LoadtxtDriverWorkStatus()
        {
            DataTable DttxtDriverWorkStatus = new DataTable();
            DttxtDriverWorkStatus = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name from subdefine where bcode = 9101053");
            txtDriverWorkStatus.DataSource = DttxtDriverWorkStatus;
            txtDriverWorkStatus.DataTextField = "Name";
            txtDriverWorkStatus.DataValueField = "Code";
            txtDriverWorkStatus.DataBind();
        }

        public void LoadNahvayeHamkari()
        {
            DataTable DttxtDriverWorkType = new DataTable();
            DttxtDriverWorkType = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name from subdefine where bcode = 9101056");
            txtDriverWorkType.DataSource = DttxtDriverWorkType;
            txtDriverWorkType.DataTextField = "Name";
            txtDriverWorkType.DataValueField = "Code";
            txtDriverWorkType.DataBind();
        }

        public void LoadZones()
        {
            DataTable dt = BusManagment.Zone.JZones.GetDataTable(0);
            cmbZone.DataSource = dt;
            cmbZone.DataTextField = "Name";
            cmbZone.DataValueField = "Code";
            cmbZone.DataBind();
        }

        public void LoadLine()
        {
            DataTable DtLine = new DataTable();
            DtLine = BusManagment.Line.JLines.GetWebDataTable(0);
            cmbLine.DataSource = DtLine;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        public void LoadBus()
        {
            DataTable DtBus = new DataTable();
            DtBus = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = DtBus;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void LoadShift()
        {
            DataTable DtShift = new DataTable();
            DtShift = BusManagment.WorkOrder.JShifts.GetDataTable(0);
            cmbShift.DataSource = DtShift;
            cmbShift.DataTextField = "Title";
            cmbShift.DataValueField = "Code";
            cmbShift.DataBind();
        }
        /////////


       




       /// <summary>
       /// /
       /// </summary>
       /// <param name="TarrifCode"></param>

        public void GetNumOfNimService(string TarrifCode)
        {
            System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"Select 
	                    AUTTariff.Code,AUTTariff.Code TarrifCode, clsAllPerson.Name DriverName, AUTLine.LineNumber,
	                    srvs.NumOfNimService
		                    , AUTBus .BUSNumber , AUTShift .Title Shift
		                    ,AUTTariff.DriverCode
                        , AUTTariff.Date
	                    ,AUTTariff.StartTime
	                    ,AUTTariff.EndTime
	                    ,srvs.StartWork
	                    ,srvs.EndWork
                        from AUTTariff 
	                        left join clsAllPerson on  AUTTariff.DriverCode = clsAllPerson.Code 
	                        left join AUTLine  on  AUTLine.Code  = AUTTariff.LineCode 
	                        left join AUTBus   on  AUTBus.Code  = AUTTariff.BusCode 
	                        left join AUTShift    on  AUTShift.Code  = AUTTariff.ShiftCode
	                        left join AUTZone    on  AUTZone.Code  = AUTLine.ZoneCode 
	                        left JOIN (
		                        SELECT 
			                        CAST(MIN(bs.FirstStationDate) AS TIME)StartWork
			                        ,CAST(MAX(bs.FirstStationDate) AS TIME)EndWork
			                        ,COUNT(*) NumOfNimService
			                        ,bs.BusNumber
			                        ,bs.Date
		                        FROM AutBusServices bs INNER JOIN AUTTariff t ON t.date = bs.Date AND CAST(bs.FirstStationDate AS TIME) BETWEEN t.StartTime AND t.EndTime
		                        INNER JOIN AUTBus b ON b.Code = t.BusCode AND b.BUSNumber = bs.BusNumber
		                        GROUP BY bs.BusNumber,bs.Date,t.StartTime, t.EndTime
	                        ) srvs ON srvs.BusNumber = AUTBus.BUSNumber AND srvs.Date = CAST(AUTTariff.Date AS DATE)
		                    AND StartWork BETWEEN AUTTariff.StartTime AND AUTTariff.EndTime
							where AUTTariff.Code = " + TarrifCode);

            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl1).Code = Convert.ToInt32(Dt.Rows[0]["DriverCode"].ToString());
                    ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl1).SQL = "select cap.Code,cast(isnull(EmpEmployee.PersonNumber,0) as nvarchar)+' - '+cap.Name Title from clsAllPerson cap left join EmpEmployee on cap.Code = EmpEmployee.pCode";
                }
            }
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                int ServiceCount = 0;
                int ExtraServices = 0;
                btnDelete.Visible = true;
                BusManagment.WorkOrder.JTariff Tariff = new BusManagment.WorkOrder.JTariff();
                Tariff.GetData(Code);
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl1).Code = Tariff.DriverCode;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl1).SQL = "select cap.Code,cast(isnull(EmpEmployee.PersonNumber,0) as nvarchar)+' - '+cap.Name Title from clsAllPerson cap left join EmpEmployee on cap.Code = EmpEmployee.pCode";
                txtTarrifCode.Text = Code.ToString();
                cmbLine.SelectedValue = Tariff.LineCode.ToString();
                cmbBus.SelectedValue = Tariff.BusCode.ToString();
                ((WebControllers.MainControls.Date.JDateControl)txtStartDate).SetDate(Tariff.Date);
                cmbShift.SelectedValue = Tariff.ShiftCode.ToString();
                txtNumOfService.Text = Tariff.NumOfService.ToString();
                txtDriverWorkStatus.SelectedValue = Tariff.DriverWorkStatus.ToString();
                txtDriverWorkType.SelectedValue = Tariff.DriverWorkType.ToString();
                txtFaaliyat.SelectedValue = Tariff.FaliyatCode.ToString();
                txtOnvaneShoghli.SelectedValue = Tariff.OnvaneShoghliCode.ToString();
                txtReportCode.SelectedValue = Tariff.GozareshCode.ToString();
                cmbZone.SelectedValue = Tariff.ZoneCode.ToString();
                txtTransactionCount.Text = Tariff.DailyLineTransactionCount.ToString();

                SeeTicketTransactionRow = 
                    ClassLibrary.JPermission.CheckPermission("WebBusManagement.FormsManagement.JTariffUpdateControl.SeeTicketTransactionRow");
                SeeTicketTransactionColumn = 
                    ClassLibrary.JPermission.CheckPermission("WebBusManagement.FormsManagement.JTariffUpdateControl.SeeTicketTransactionColumn");

                //////////////////////////////                  Loading EzamBeGrid             ////////////////////////////// 

                DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"exec [dbo].[SP_GetTarifData] @tarif_code = " + Code 
                    + ", @SeeTicketTransactionRow = " + (SeeTicketTransactionRow ? 1 : 0) 
                    + ", @SeeTicketTransactionColumn = " + (SeeTicketTransactionColumn ? 1 : 0)
                    + ", @SeeEvent = " 
                    + (ClassLibrary.JPermission.CheckPermission("WebBusManagement.FormsManagement.JTariffUpdateControl.SeeEvent") ? 1 : 0));

                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        int NumOfService;
                        if (Tariff.NumOfService > 0)
                            ServiceCount = Convert.ToInt32(Tariff.NumOfService);
                        else
                        {
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {
                                try
                                {
                                    NumOfService = Convert.ToInt32(Dt.Rows[i]["تعداد سرویس"]);
                                    ServiceCount += NumOfService;
                                }
                                catch
                                {
                                    ServiceCount++;
                                }
                            }
                        }

                        try
                        {
                            DataTable dtTime = new DataTable();
                            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
                            DateTime MinStartTime;
                            DateTime MaxEndTime;
                            string Query =
                                @"SELECT MIN(bs.FirstStationDate)  MinStartDate, MAX(bs.LastStationDate) MaxEndDate
                                FROM AutBusServices bs
	                                INNER JOIN AUTBus b ON b.BUSNumber = bs.BusNumber
	                                INNER JOIN AUTLine l ON l.LineNumber = b.LastLineNumber
	                                INNER JOIN AUTTariff t on t.BusCode = b.Code AND bs.Date = CAST(t.Date AS DATE) AND CAST(bs.FirstStationDate AS TIME) BETWEEN t.StartTime AND t.EndTime
                                WHERE t.Code = " + Code + @" AND bs.FirstStationDate BETWEEN t.Date + t.StartTime AND t.Date + t.EndTime AND isnull(bs.Deleted, 0) = 0";
                            Db.setQuery(Query);
                            try
                            {
                                dtTime = Db.Query_DataTable();
                            }
                            catch (Exception ex)
                            {
                                ClassLibrary.JError.Except.AddException(ex);
                            }
                            finally
                            {
                                Db.Dispose();
                            }
                            if (dtTime != null && dtTime.Rows.Count > 0)
                            {
                                MinStartTime = DateTime.Parse(dtTime.Rows[0]["MinStartDate"].ToString());
                                MaxEndTime = DateTime.Parse(dtTime.Rows[0]["MaxEndDate"].ToString());
                                txtStartTimeHour.Text = MinStartTime.Hour.ToString("00");
                                txtStartTimeMinute.Text = MinStartTime.Minute.ToString("00");
                                txtFinishTimeHour.Text = MaxEndTime.Hour.ToString("00");
                                txtFinishTimeMinute.Text = MaxEndTime.Minute.ToString("00");
                            }
                        }
                        catch { }

                    }
                }
                RadGridReport.DataSource = Dt;
                RadGridReport.DataBind();


                BusManagment.Line.JLine line = new BusManagment.Line.JLine(Tariff.LineCode);
                if (Tariff.MinNumOfService != 0)
                {
                    txtMinNumOfService.Text = Tariff.MinNumOfService.ToString();
                    ExtraServices = ServiceCount - (int)Tariff.MinNumOfService;
                }
                else
                {
                    txtMinNumOfService.Text = line.NumOfServicePerDay.ToString();
                    ExtraServices = ServiceCount - line.NumOfServicePerDay;
                }

                if (ExtraServices > 0)
                    txtExtraServices.Text = ExtraServices.ToString();
                else
                    txtServiceDeficiency.Text = Math.Abs(ExtraServices).ToString();
                PanelGrid.Visible = true;
                PanelTable.Visible = false;
            }
            else
            {
                btnDelete.Visible = true;
                PanelGrid.Visible = false;
                PanelTable.Visible = true;
            }
        }

        public bool Save()
        {
            int MinNumOfService = 0;
            BusManagment.WorkOrder.JTariff Tariff = new BusManagment.WorkOrder.JTariff();
            Tariff.Code = Code;
            Tariff.DriverCode = ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl1).Code;
            Tariff.LineCode = Convert.ToInt32(cmbLine.SelectedValue);
            Tariff.BusCode = Convert.ToInt32(cmbBus.SelectedValue);
            Tariff.Date = ((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetDate();
            Tariff.ShiftCode = Convert.ToInt32(cmbShift.SelectedValue);
            if (txtNumOfService.Text.Length > 0)
                Tariff.NumOfService = Convert.ToInt32(txtNumOfService.Text);
            Tariff.DriverWorkType = Convert.ToInt32(txtDriverWorkType.SelectedValue);
            Tariff.DriverWorkStatus = Convert.ToInt32(txtDriverWorkStatus.SelectedValue);
            BusManagment.WorkOrder.JShift shift = new BusManagment.WorkOrder.JShift(Tariff.ShiftCode);
            Tariff.StartTime = shift.StartTime.ToString("hh':'mm':'ss");
            Tariff.EndTime = shift.EndTime.ToString("hh':'mm':'ss");
            Tariff.FaliyatCode = Convert.ToInt32(txtFaaliyat.SelectedValue);
            Tariff.OnvaneShoghliCode = Convert.ToInt32(txtOnvaneShoghli.SelectedValue);
            Tariff.GozareshCode = Convert.ToInt32(txtReportCode.SelectedValue);
            Tariff.ZoneCode = Convert.ToInt32(cmbZone.SelectedValue);
            if (txtTransactionCount.Text.Length > 0)
                Tariff.DailyLineTransactionCount = Convert.ToInt32(txtTransactionCount.Text);
            Int32.TryParse(txtMinNumOfService.Text, out MinNumOfService);
            Tariff.MinNumOfService = MinNumOfService;
            if (Code > 0)
            {
                if (Tariff.Update(true))
                {
                    ClassLibrary.JDataBase Db2 = new ClassLibrary.JDataBase();
                    try
                    {
                        Db2.setQuery(@"
                        update AutBusServices set DriverPersonCode=t.DriverCode
	                    FROM AutBusServices bs
	                    INNER JOIN AUTBus b ON b.BUSNumber = bs.BusNumber
	                    INNER JOIN AUTLine l ON l.LineNumber = b.LastLineNumber
	                    INNER JOIN AUTTariff t on t.BusCode = b.Code AND bs.Date = CAST(t.Date AS DATE) AND CAST(bs.FirstStationDate AS TIME) BETWEEN t.StartTime AND t.EndTime
	                    LEFT JOIN clsAllPerson cap ON cap.Code = t.DriverCode
                        WHERE t.Code = " + Code + @" AND bs.FirstStationDate BETWEEN t.Date + t.StartTime AND t.Date + t.EndTime
                    ");
                        Db2.Query_Execute();
                    }
                    finally
                    {
                        Db2.Dispose();
                    }
                    return true;
                }
                return false;
            }
            else
                return Tariff.Insert(true) > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetFarsiDate().ToString().Length == 10)
                {
                    if (((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetFarsiDate().ToString().Length == 10)
                    {
                        if (Save())
                        {
                            WebClassLibrary.JWebManager.RunClientScript("alert('تعرفه مورد نظر با موفقیت ثبت شد');", "ConfirmDialog");
                            WebClassLibrary.JWebManager.CloseAndRefresh();
                        }
                        else
                        {
                            WebClassLibrary.JWebManager.RunClientScript("alert('تعرفه تکراری است و قبلا ثبت شده است');", "ConfirmDialog");
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('لطفا تاریخ پایان را انتخاب کنید');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('لطفا تاریخ شروع را انتخاب کنید');", true);
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('ثبت اطلاعات با خطا مواجه شد');", true);
            }
        }


        protected void BtnReport_Click(object sender, EventArgs e) 
        {
            try
            {

                //string code2;
                //_BusServiceShowMap();

                _BusServiceShowMap(txtTarrifCode.ToString());

            }
            catch
            {

            }
        }

        protected void BtnSearchTarrif_Click(object sender, EventArgs e)
        {
            int TarrifCode = 0;
            int.TryParse(txtTarrifCode.Text, out TarrifCode);
            if (TarrifCode > 0)
            {
                try
                {
                    GetNumOfNimService(TarrifCode.ToString());
                }
                catch { }
                BusManagment.WorkOrder.JTariff Tariff = new BusManagment.WorkOrder.JTariff();
                Tariff.GetData(TarrifCode);
                cmbLine.SelectedValue = Tariff.LineCode.ToString();
                cmbBus.SelectedValue = Tariff.BusCode.ToString();
                ((WebControllers.MainControls.Date.JDateControl)txtStartDate).SetDate(Tariff.Date);
                cmbShift.SelectedValue = Tariff.ShiftCode.ToString();
                txtDriverWorkStatus.SelectedValue = Tariff.DriverWorkStatus.ToString();
                txtDriverWorkType.SelectedValue = Tariff.DriverWorkType.ToString();
                try
                {
                    txtStartTimeHour.Text = Tariff.StartTime.Split(':')[0].ToString();
                    txtStartTimeMinute.Text = Tariff.StartTime.Split(':')[1].ToString();
                    txtFinishTimeHour.Text = Tariff.EndTime.Split(':')[0].ToString();
                    txtFinishTimeMinute.Text = Tariff.EndTime.Split(':')[1].ToString();
                }
                catch { }
                txtFaaliyat.SelectedValue = Tariff.FaliyatCode.ToString();
                txtOnvaneShoghli.SelectedValue = Tariff.OnvaneShoghliCode.ToString();
                txtReportCode.SelectedValue = Tariff.GozareshCode.ToString();
                cmbZone.SelectedValue = Tariff.ZoneCode.ToString();
            }
        }

        protected void btnInsertEzamBe_Click(object sender, EventArgs e)
        {
            int TarrifCode = 0;
            int.TryParse(txtTarrifCode.Text, out TarrifCode);
            if (Code > 0)
                _EzamBeUpdate(Code.ToString());
            else if (TarrifCode > 0)
                _EzamBeUpdate(TarrifCode.ToString());
        }

        public string _EzamBeUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("EzamBe"
                  , "~/WebBusManagement/FormsManagement/JEzamBeUpdateControl.ascx"
                  , "اعزام به"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 1150, 500);
        }
        protected void RadGridReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditCode.Value = RadGridReport.SelectedRow.Cells[1].Text.ToString();
            Control control = RadGridReport.SelectedRow.FindControl("IsServiceLabel");
            if (control == null || (control as Label).Text == "")
                return;
            IsService.Value = (control as Label).Text;
            BtnDeleteService.Visible = true;
            BtnIsOk.Visible = true;
        }

        protected void BtnDeleteService_Click(object sender, EventArgs e)
        {
            if (IsService.Value == "" || IsService.Value == "False") return;// not a service
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            try
            {
                Db.setQuery(@"update AutBusServices set Deleted = 1, IsOK = 3 where Code = " + EditCode.Value);

                if (Db.Query_Execute() >= 0)
                {
                    EditCode.Value = "0";
                    IsService.Value = "";
                    BtnDeleteService.Visible = false;
                    BtnIsOk.Visible = false;
                }
            }
            catch (Exception ex) { ClassLibrary.JError.Except.AddException(ex); }
            finally
            {
                Db.Dispose();
            }
        }

        protected void BtnIsOk_Click(object sender, EventArgs e)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            try
            {

                if (IsService.Value == "True")
                {
                    DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select IsOk from AutBusServices where Code = " + EditCode.Value);
                    if (Dt == null || Dt.Rows.Count <= 0)
                        return;
                    if (Dt.Rows[0]["IsOk"].ToString() != "4")
                    {
                        Db.setQuery(@"update AutBusServices set IsOk = 4 where Code = " + EditCode.Value);
                    }
                    else
                    {
                        Db.setQuery(@"update AutBusServices set IsOk = 3 where Code = " + EditCode.Value);
                    }
                }
                else
                {
                    DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select Status from AUTBusEventRegister where Code = " + EditCode.Value);
                    if (Dt == null || Dt.Rows.Count <= 0)
                        return;
                    Db.setQuery(@"update AUTBusEventRegister set Status = " + (Dt.Rows[0]["Status"].ToString() == "1" ? "0" : "1") + " where Code = " + EditCode.Value);
                }

                if (Db.Query_Execute() >= 0)
                {
                    EditCode.Value = "0";
                    IsService.Value = "";
                    BtnDeleteService.Visible = false;
                    BtnIsOk.Visible = false;
                }
            }
            catch (Exception ex) { ClassLibrary.JError.Except.AddException(ex); }
            finally
            {
                Db.Dispose();
                _SetForm();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Code > 0)
            {
                ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
                db.beginTransaction("DeleteTarif");
                try 
                { 
                    if (!AllowDeleteTariff)
                    {
                        // این قسمت برای این است که اگر اعزام به یا واقعه وجود داشت ولی تعرفه تکراری بود، امکان حذف داده شود
                        db.setQuery(@"select * from AUTTariff a inner join AUTTariff b 
                            on a.BusCode = b.BusCode and a.Date = b.Date and a.ShiftCode = b.ShiftCode
                            where a.Code <> b.Code and a.Code = " + Code);

                        DataTable dt = db.Query_DataTable();
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            WebClassLibrary.JWebManager.RunClientScript("alert('بدلیل وجود اعزام به یا واقعه، عملیات حذف مجاز نیست');", "ConfirmDialog");
                            db.Rollback("DeleteTarif");
                            return;
                        }
                        db.setQuery(@"
                            delete AUTBusEventRegisterTarrifCode where TarrifCode = " + Code + @"
                            delete dbo.AutTarrifEzamBe where TarrifCode = " + Code);
                        if (db.Query_Execute() < 0)
                        {
                            WebClassLibrary.JWebManager.RunClientScript("alert('ثبت اطلاعات با خطا مواجه شد');", "ConfirmDialog");
                            db.Rollback("DeleteTarif");
                            return;
                        }
                    }
                    BusManagment.WorkOrder.JTariff Tariff = new BusManagment.WorkOrder.JTariff();
                    Tariff.Code = Code;
                    if (Tariff.Delete(true, db))
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('تعرفه مورد نظر با موفقیت حذف شد');", "ConfirmDialog");
                        WebClassLibrary.JWebManager.CloseAndRefresh();
                        db.Commit();
                    }
                    else
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('ثبت اطلاعات با خطا مواجه شد');", "ConfirmDialog");
                        db.Rollback("DeleteTarif");
                    }
                }
                catch (Exception ex)
                {
                    JException.Exceptions.Add(ex);
                    db.Rollback("DeleteTarif");
                }
            }
        }

        protected void OkAllServicesButton_Click(object sender, EventArgs e)
        {
            Save();
            DataTable dtTime = new DataTable();
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            DateTime MinStartDate = new DateTime();
            DateTime MaxEndDate = new DateTime();
            int NumOfService;
            string Query =
                @"SELECT MIN(bs.FirstStationDate)  MinStartDate, MAX(bs.LastStationDate) MaxEndDate, SUM(bs.NumOfService) NumOfService
                                FROM AutBusServices bs
	                                INNER JOIN AUTBus b ON b.BUSNumber = bs.BusNumber
	                                INNER JOIN AUTLine l ON l.LineNumber = b.LastLineNumber
	                                INNER JOIN AUTTariff t on t.BusCode = b.Code AND bs.Date = CAST(t.Date AS DATE) AND CAST(bs.FirstStationDate AS TIME) BETWEEN t.StartTime AND t.EndTime
                                WHERE t.Code = " + Code + @" AND bs.FirstStationDate BETWEEN t.Date + t.StartTime AND t.Date + t.EndTime AND isnull(bs.Deleted, 0) = 0";
            Db.setQuery(Query);
            try
            {
                dtTime = Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                ClassLibrary.JError.Except.AddException(ex);
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت اطلاعات با خطا مواجه شد');", "ConfirmDialog");
                return;
            }
            finally
            {
                Db.Dispose();
            }
            if (dtTime != null && dtTime.Rows.Count > 0)
            {
                MinStartDate = DateTime.Parse(dtTime.Rows[0]["MinStartDate"].ToString());
                MaxEndDate = DateTime.Parse(dtTime.Rows[0]["MaxEndDate"].ToString());
                NumOfService = int.Parse(dtTime.Rows[0]["NumOfService"].ToString());
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('هیچ سرویسی برای تایید موجود نیست');", "ConfirmDialog");
                return;
            }
            ClassLibrary.JDataBase Db2 = new ClassLibrary.JDataBase();
            Db2.setQuery(@"
                update AUTTariff set 
                StartTime = '" + MinStartDate.TimeOfDay + "' ,EndTime = '" + MaxEndDate.TimeOfDay + "',NumOfService="+NumOfService+", Status=1 where code = " + Code + @"

                update AutBusServices set IsOk = 4
	            FROM AutBusServices bs
	            INNER JOIN AUTBus b ON b.BUSNumber = bs.BusNumber
	            INNER JOIN AUTLine l ON l.LineNumber = b.LastLineNumber
	            INNER JOIN AUTTariff t on t.BusCode = b.Code AND bs.Date = CAST(t.Date AS DATE) AND CAST(bs.FirstStationDate AS TIME) BETWEEN t.StartTime AND t.EndTime
	            LEFT JOIN clsAllPerson cap ON cap.Code = t.DriverCode
                WHERE t.Code = " + Code + @" AND bs.FirstStationDate BETWEEN t.Date + t.StartTime AND t.Date + t.EndTime
            ");
            Db2.beginTransaction("UpdateTariff");
            try
            {
                if (Db2.Query_Execute() <= 0)
                {
                    Db2.Rollback("UpdateTariff");
                    WebClassLibrary.JWebManager.RunClientScript("alert('ثبت اطلاعات با خطا مواجه شد');", "ConfirmDialog");
                    return;
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JError.Except.AddException(ex);
                Db2.Rollback("UpdateTariff");
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت اطلاعات با خطا مواجه شد');", "ConfirmDialog");
                return;
            }
            finally
            {
                Db2.Commit();
                Db2.Dispose();
                _SetForm();
            }
        }

        protected void RadGridReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            e.Row.Cells[0].Enabled = e.Row.Cells[2].Text.Trim() != "0";
            if (e.Row.Cells[8].Text.Contains("&gt;"))
                e.Row.Cells[8].Text = e.Row.Cells[8].Text.Substring(e.Row.Cells[8].Text.IndexOf("&gt;") + 4);
            if (e.Row.Cells[9].Text.Contains("&gt;"))
                e.Row.Cells[9].Text = e.Row.Cells[9].Text.Substring(e.Row.Cells[9].Text.IndexOf("&gt;") + 4);

            int IsOK = -1;
            Int32.TryParse(e.Row.Cells[18].Text,out IsOK);

            bool DriverOK = e.Row.Cells[19].Text != "0";
            //bool.TryParse(e.Row.Cells[18].Text, out DriverOK);

            bool FistStationOK = e.Row.Cells[20].Text != "0";
            //bool.TryParse(e.Row.Cells[19].Text, out FistStationOK);

            bool LastStationOK = e.Row.Cells[21].Text != "0"; ;
            //bool.TryParse(e.Row.Cells[20].Text, out LastStationOK);

            string Type = e.Row.Cells[22].Text;
            if (Type == "Transaction")
            {
                e.Row.ForeColor = System.Drawing.Color.Green;
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#e5ffe5");
            }
            else if (IsOK != 1)
            {
                if (IsOK == 0)// disapproved by user
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#E8CDE5");
                }
                else
                {
                    if (!DriverOK)// wrong driver
                    {
                        e.Row.Cells[17].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[17].BackColor = System.Drawing.ColorTranslator.FromHtml("#E8CDE5");
                    }
                    if (!FistStationOK)// wrong first station
                    {
                        e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[9].BackColor = System.Drawing.ColorTranslator.FromHtml("#E8CDE5");
                        e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[10].BackColor = System.Drawing.ColorTranslator.FromHtml("#E8CDE5");
                    }
                    if (!LastStationOK)// wrong last station
                    {
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#E8CDE5");
                        e.Row.Cells[13].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[13].BackColor = System.Drawing.ColorTranslator.FromHtml("#E8CDE5");
                    }
                }
            }

            TableCell cell = new TableCell();
            string strIsService = "";
            if (e.Row.Cells[22].Text == "Auto" || e.Row.Cells[22].Text == "Manual")
                strIsService = "True";
            else if (e.Row.Cells[22].Text == "Event")
                strIsService = "False";
            cell.Controls.Add(new Label() { ID = "IsServiceLabel", Text = strIsService, Visible = false });
            cell.Visible = false;
            e.Row.Cells.Add(cell);

            LinkButton btnShow = (LinkButton)e.Row.Cells[1].FindControl("lbnShow");
            switch (Type)
            {
                case "Auto":
                    e.Row.Cells[22].Text = "اتوماتیک";
                    break;
                case "Manual":
                    e.Row.Cells[22].Text = "دستی";
                    break;
                case "Event":
                    e.Row.Cells[22].Text = "واقعه";
                    btnShow.Visible = false;
                    AllowDeleteTariff = false;
                    break;
                case "EzamBe":
                    e.Row.Cells[22].Text = "اعزام به";
                    btnShow.Visible = false;
                    AllowDeleteTariff = false;
                    break;
                case "Transaction":
                    e.Row.Cells[22].Text = "تراکنش";
                    btnShow.Visible = false;
                    break;
            }

        }

        protected void RadGridReport_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (!SeeTicketTransactionColumn)
            {
                e.Row.Cells[8].Visible = false; // hiding TicketTransaction column
            }
            e.Row.Cells[18].Visible = false; // hiding IsOK column
            e.Row.Cells[19].Visible = false; // hiding DriverOK column
            e.Row.Cells[20].Visible = false; // hiding FistStationOK column
            e.Row.Cells[21].Visible = false; // hiding LastStationOK column
        }
       

        /// <summary>
        /// //
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string _BusServiceShowMap(string code)  
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusServiceShowMap"
                  , "~/WebBusManagement/FormsReports/JBusServiceShowMapUpdateControl.ascx"
                  , "نمایش مسیر سرویس روی نقشه"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WebClassLibrary.WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }

        protected void RadGridReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Show")
            {
                int ServiceCode = Convert.ToInt32(e.CommandArgument);
                string actInfo = WebClassLibrary.JWebManager.LoadClientControl("BusServiceShowMap"
                      , "~/WebBusManagement/FormsReports/JBusServiceShowMapUpdateControl.ascx"
                      , "نمایش مسیر سرویس روی نقشه"
                      , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", ServiceCode.ToString()) }
                      , WebClassLibrary.WindowTarget.NewWindow
                      , true, false, true, 700, 400);
                string[] Info = System.Text.RegularExpressions.Regex.Split(actInfo, @"\:\|\:");
                string ClientScript = @"
                    var oBrowserWnd = GetRadWindow().BrowserWindow; 
                    GetRadWindow().BrowserWindow; 
                    GetRadWindow().restore(); 
                    setTimeout(function () {
                        var oWindow = oBrowserWnd.radopen(""" + Info[0] + @""", """ + Info[1] + @""");
                        oWindow.set_visibleStatusbar(false);
                        oWindow.set_destroyOnClose(true);
                        oWindow.set_animation(Telerik.Web.UI.WindowAnimation.Fade);
                        oWindow.setActive(true);
                        oWindow.set_width(700);
                        oWindow.set_height(400);
                        oWindow.center();
                    }, 0);";
                WebClassLibrary.JWebManager.RunClientScript(ClientScript, "BusServiceShowMap");
            }
        }

        protected void btnPrintClick(object sender, EventArgs e)
        {
            string _Classname = "WebBusManagement.FormsManagement.JTariffUpdateControl";
            int TarrifCode = 0;
            int.TryParse(txtTarrifCode.Text, out TarrifCode);

            string SQL = @"Select 
	                    AUTTariff.Code,AUTTariff.Code TarrifCode, clsAllPerson.Name DriverName, AUTLine.LineNumber,
	                    srvs.NumOfNimService
		                    , AUTBus .BUSNumber , AUTShift .Title Shift
		                    ,AUTTariff.DriverCode
                        , AUTTariff.Date
	                    ,AUTTariff.StartTime
	                    ,AUTTariff.EndTime
	                    ,srvs.StartWork
	                    ,srvs.EndWork
                        from AUTTariff 
	                        left join clsAllPerson on  AUTTariff.DriverCode = clsAllPerson.Code 
	                        left join AUTLine  on  AUTLine.Code  = AUTTariff.LineCode 
	                        left join AUTBus   on  AUTBus.Code  = AUTTariff.BusCode 
	                        left join AUTShift    on  AUTShift.Code  = AUTTariff.ShiftCode
	                        left join AUTZone    on  AUTZone.Code  = AUTLine.ZoneCode 
	                        left JOIN (
		                        SELECT 
			                        CAST(MIN(bs.FirstStationDate) AS TIME)StartWork
			                        ,CAST(MAX(bs.FirstStationDate) AS TIME)EndWork
			                        ,COUNT(*) NumOfNimService
			                        ,bs.BusNumber
			                        ,bs.Date
		                        FROM AutBusServices bs INNER JOIN AUTTariff t ON t.date = bs.Date AND CAST(bs.FirstStationDate AS TIME) BETWEEN t.StartTime AND t.EndTime
		                        INNER JOIN AUTBus b ON b.Code = t.BusCode AND b.BUSNumber = bs.BusNumber
		                        GROUP BY bs.BusNumber,bs.Date,t.StartTime, t.EndTime
	                        ) srvs ON srvs.BusNumber = AUTBus.BUSNumber AND srvs.Date = CAST(AUTTariff.Date AS DATE)
		                    AND StartWork BETWEEN AUTTariff.StartTime AND AUTTariff.EndTime
							where AUTTariff.Code = " + TarrifCode;
            JQuery jQuery = new JQuery(_Classname, SQL, 0, null, null);

            string SQLTarif = @"exec [dbo].[SP_GetTarifData] @tarif_code = " + TarrifCode
                + ", @SeeTicketTransactionRow = " + (SeeTicketTransactionRow ? 1 : 0)
                + ", @SeeTicketTransactionColumn = " + (SeeTicketTransactionColumn ? 1 : 0)
                + ", @SeeEvent = "
                + (ClassLibrary.JPermission.CheckPermission("WebBusManagement.FormsManagement.JTariffUpdateControl.SeeEvent") ? 1 : 0);

            JQuery jQuery1 = new JQuery(_Classname, SQLTarif, 1, null, null);

            string actInfo = WebClassLibrary.JWebManager.LoadClientControl(_Classname
                    , "~/WebReport/Viewer/JReportSelectorControl.ascx"
                    , "چاپ"
                    , new List<Tuple<string, string>>(){ new Tuple<string, string>("ObjectCode", 0.ToString())
                                               ,  new Tuple<string, string>("rSUID", "Report_Dt")
                                               , new Tuple<string, string>("ClassName",_Classname) 
                                               , new Tuple<string,string>("QueryCode",jQuery.Code.ToString()+","+jQuery1.Code.ToString()) }
                    , WebClassLibrary.WindowTarget.NewWindow
                    , true, true, true, 750, 500);

            string[] Info = System.Text.RegularExpressions.Regex.Split(actInfo, @"\:\|\:");
            string ClientScript = @"
                    var oBrowserWnd = GetRadWindow().BrowserWindow; 
                    GetRadWindow().BrowserWindow; 
                    GetRadWindow().restore(); 
                    setTimeout(function () {
                        var oWindow = oBrowserWnd.radopen(""" + Info[0] + @""", """ + Info[1] + @""");
                        oWindow.set_visibleStatusbar(false);
                        oWindow.set_destroyOnClose(true);
                        oWindow.set_animation(Telerik.Web.UI.WindowAnimation.Fade);
                        oWindow.setActive(true);
                        oWindow.set_width(700);
                        oWindow.set_height(400);
                        oWindow.center();
                    }, 0);";
            WebClassLibrary.JWebManager.RunClientScript(ClientScript, "TariffUpdateControlPrint");
        }

        protected void btnReCalculate_Click(object sender, EventArgs e)
        {
//            string SQL = @"
//                Select top 50
//                AUTTariff.Code
//                from AUTTariff 
//	                left join clsAllPerson on  AUTTariff.DriverCode = clsAllPerson.Code 
//	                left join AUTLine  on  AUTLine.Code  = AUTTariff.LineCode 
//	                left join AUTBus   on  AUTBus.Code  = AUTTariff.BusCode 
//	                left join AUTShift    on  AUTShift.Code  = AUTTariff.ShiftCode
//	                left join AUTZone    on  AUTZone.Code  = AUTLine.ZoneCode 
//	                left join EmpEmployee e on e.pCode = AUTTariff.DriverCode
//	                left JOIN 
//	                (
//		                select code, min(StartWork) StartWork, max(EndWork) EndWork
//		                ,sum(NumOfServices) NumOfServices
//		                ,sum(NumOfFaultyServices) NumOfFaultyServices
//		                ,sum(WrongDriver) WrongDriver
//		                ,BusNumber,Date
//		                from
//		                (
//			                SELECT t.Code,
//				                CAST(MIN(bs.FirstStationDate) AS TIME)StartWork
//				                ,CAST(MAX(bs.LastStationDate) AS TIME)EndWork
//				                ,sum(bs.NumOfService) NumOfServices 
//				                ,case when isnull(bs.IsOk, 1) = 0 and isnull(bs.EzamBeCode, 0) = 0 then sum(bs.NumOfService) else 0 end NumOfFaultyServices 
//								,case when isnull(bs.DriverPersonCode, 0) != t.DriverCode then sum(bs.NumOfService) else 0 end WrongDriver
//				                ,bs.BusNumber
//				                ,bs.Date
//				                ,bs.DriverPersonCode
//			                FROM AutBusServices bs 
//			                INNER JOIN AUTTariff t ON t.date = bs.Date AND CAST(bs.FirstStationDate AS TIME) BETWEEN t.StartTime AND t.EndTime
//			                INNER JOIN AUTBus b ON b.Code = t.BusCode AND b.BUSNumber = bs.BusNumber
//                            where isnull(bs.Deleted, 0) = 0
//								and ((isnull(bs.EzamBeCode, 0) > 0 or not exists(select * from AutTarrifEzamBe where TarrifCode = t.Code and bs.FirstStationDate < FinishTime and bs.LastStationDate > StartTime)))
//			                GROUP BY t.Code,bs.BusNumber,bs.Date,bs.DriverPersonCode,t.DriverCode, bs.IsOk, bs.EzamBeCode
//		                )tbl
//                        WHERE Date between '2016-05-21 00:00:00' and '2016-06-20 23:59:59'
//		                GROUP BY Code,BusNumber,Date
//	                ) srvs ON srvs.Code = AUTTariff.Code
//                    where 1 = 1 order by isnull(srvs.NumOfFaultyServices, 0) desc";
//            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(SQL,false);

//            for (int i = 0; i < 50; i++)
//            {
//                Code = Convert.ToInt32(dt.Rows[i][0]);
            if (ClassLibrary.JMainFrame.CurrentPostCode != 1 && ClassLibrary.JMainFrame.IsAdmin)
                return;
            if (Code == 0)
                return;
            JDataBase db2 = new JDataBase();
            db2.setQuery(@"
declare @startDate datetime 
, @endDate datetime 
, @BusNumber int

select @BusNumber = b.BUSNumber, @startDate = a.Date + Cast(Cast(c.StartTime as time(0)) as varchar)
, @endDate = a.Date + Cast(Cast(c.EndTime as time(0)) as varchar)
from AUTTariff a
inner join AUTBus b on a.BusCode = b.Code
inner join AUTShift c on a.ShiftCode = c.Code
where a.Code = @tariff_code

delete from AutBusPassingStations where BusNumber = @BusNumber and EventDate between @startDate and DATEADD(hour, 1, @endDate)
delete from AutBusServices where Date = cast(FirstStationDate as date) and BusNumber = @BusNumber and FirstStationDate between @startDate and @endDate
 and isok in (0,2,5)

	declare @P_Lat FLOAT
	,@P_Long FLOAT
	,@P_Angle INT
	,@P_BusCode INT
	,@P_BusSerial INT
	,@P_EventDate DATETIME
	,@Speed INT
	,@DirPath FLOAT

	declare Date_Cursor_Temp_ProcessTicket1 CURSOR FOR 
	select a.Latitude, a.Longitude, a.BusCode, b.BUSNumber, a.EventDate, a.Course, a.Speed, ISNULL( c.Dir,0)
from AUTAvlTransaction a 
inner join AUTBus b on a.BusCode = b.Code
left join [AUTBusAvlDirection] c on c.BusNumber = b.BUSNumber and c.EventDate = a.EventDate
where b.BUSNumber = @BusNumber and a.EventDate between DATEADD(MINUTE, -8, @startDate) and DATEADD(hour, 1, @endDate) 
order by a.BusCode,a.EventDate

	OPEN Date_Cursor_Temp_ProcessTicket1
	FETCH NEXT FROM Date_Cursor_Temp_ProcessTicket1 INTO 
	@P_Lat 
	,@P_Long 
	,@P_BusCode 
	,@P_BusSerial 
	,@P_EventDate 
	,@P_Angle 
	,@Speed 
	,@DirPath
	WHILE @@FETCH_STATUS = 0
	BEGIN
			
	  EXEC FindStationPassing
	  @P_Lat 
	,@P_Long 
	,@P_Angle 
	,@P_BusCode 
	,@P_BusSerial 
	,@P_EventDate 
	,null
	,@Speed 
	,@DirPath 

	FETCH NEXT FROM Date_Cursor_Temp_ProcessTicket1 INTO
	@P_Lat 
	,@P_Long 
	,@P_BusCode 
	,@P_BusSerial 
	,@P_EventDate 
	,@P_Angle 
	,@Speed 
	,@DirPath

	END
	CLOSE Date_Cursor_Temp_ProcessTicket1;
	DEALLOCATE Date_Cursor_Temp_ProcessTicket1;
declare @date date = cast(@startDate as date)
exec SP_UpdateServices_Modified @date");
	
            db2.AddParams("tariff_code", Code.ToString());
            db2.Query_Execute(true);
            WebClassLibrary.JWebManager.RunClientScript("alert('بررسی مجدد طی حدود 20 دقیقه تکمیل می گردد.');", "ConfirmDialog");
            //}
        }
    }
}