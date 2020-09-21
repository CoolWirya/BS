using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassLibrary;

namespace WebBusManagement.FormsReports
{
    public partial class JTariffServiceConflictReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
                btnSave_Click(null, null);
            }
        }
        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null, int Bus = 0)
        {
            string WhereStr = "", TarifWhereStr = "";

            if (Bus > 0)
                WhereStr += " and bus.Code =  " + Bus;
            WhereStr += " and service.Date between '" + StartEventDate.Value.ToShortDateString() + "' and '" + EndEventDate.Value.ToShortDateString() + "'";
            TarifWhereStr += " and tariff.Date between '" + StartEventDate.Value.ToShortDateString() + "' and '" + EndEventDate.Value.ToShortDateString() + "'";
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JTariffServiceConflictReportControl_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "_" + Bus;
            jGridView.SQL = @"select tariff.BusCode, tariff.Date, s.StartTime, s.EndTime into #tmpTarif 
                            from AUTTariff tariff inner join AUTShift s on s.Code = tariff.ShiftCode
                            where 1=1" + TarifWhereStr + @"
                            <#PreviusSQL#>
                            select min(service.Code) Code, service.DriverPersonCode, person.Name DriverName, service.BusNumber, bus.LastLineNumber LineNumber,service.Date, count(service.Code) NumOfService
                            from AutBusServices service
                            left join AUTBus bus on bus.BUSNumber = service.BusNumber
							left join clsAllPerson person on person.Code = service.DriverPersonCode
                                where service.BusNumber is not null
                            and not exists(select*from #tmpTarif tariff where service.Date = tariff.Date and tariff.BusCode = bus.Code 
                                and cast(service.FirstStationDate as time) between tariff.StartTime and tariff.EndTime) 
                                and ISNULL(SERVICE.deleted,0) != 1" + WhereStr + @"
							group by service.DriverPersonCode, person.Name, service.BusNumber, bus.LastLineNumber, service.Date ";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "TariffServiceConflictReport";
            jGridView.PageOrderByField = " Date desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("InsertTariff", "InsertTariff", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffServiceConflictReportControl._TariffInsert", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit)); 
            jGridView.Buttons = "excel,print,record_print";
            jGridView.Bind();
        }

        public string _TariffInsert(string code)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            string[] ParamaName = new string[1]{"@SeviceCode"};
            DataTable dt = new DataTable();
            try
            {
                dt = Db.ExecuteProcedure_Query("[dbo].[SP_InsertAUTTariffByService]", ParamaName, code.ToString());
            }
            catch(Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                Db.Dispose();
            }
            int TariffCode = 0;
            if(dt != null && dt.Rows.Count > 0)
                TariffCode = Convert.ToInt32(dt.Rows[0][0]);
            if (TariffCode > 0)
                return WebClassLibrary.JWebManager.LoadClientControl("Tariff"
                      , "~/WebBusManagement/FormsManagement/JTariffUpdateControl.ascx"
                      , "تعرفه"
                      , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", TariffCode.ToString()) }
                      , WindowTarget.NewWindow
                      , true, true, true);
            else return null;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReport(
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), 
                Convert.ToInt32(cmbBus.SelectedValue));
        }
    }
}