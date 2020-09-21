using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JEzamBeReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {


                //btnSave_Click(null, null);
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
                LoadZones();
                LoadLines();
                //GetReport();
                btnSave_Click(null, null);
            }
        }

        public void LoadLines()
        {
            DataTable dt = BusManagment.Line.JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, lineName = "همه" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        public void LoadZones()
        {
            DataTable dt = BusManagment.Zone.JZones.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbZone.DataSource = p;
            cmbZone.DataTextField = "Name";
            cmbZone.DataValueField = "Code";
            cmbZone.DataBind();
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

        public void GetReport(int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int DriverCode = 0, int LineCode = 0, int ZoneCode = 0)//
        {
            string WhereStr = "";
            if (BusNumebr > 0)
                WhereStr += " and Bus.BUSNumber = " + BusNumebr;
            if (DriverCode > 0)
                WhereStr += " and AutTarrifEzamBe.DriverPCode = " + DriverCode;
            if (LineCode > 0)
                WhereStr += " and AUTLine.Code = " + LineCode;
            if (ZoneCode > 0)
                WhereStr += " and AUTZone.Code = " + ZoneCode;
            //if (StartEventDate.HasValue && EndEventDate.HasValue)
            WhereStr += " and Cast(AutTarrifEzamBe.StartTime as Date) between '{0}' and '{1}'";
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;//new WebControllers.MainControls.Grid.JGridView("WebBusManagement_FormsReports_JTariffReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JEzamBeReportControl_" + BusNumebr.ToString() + "_" + DriverCode.ToString() + "_" + LineCode.ToString() + "_" + ZoneCode.ToString();
            jGridView.SQL = @"Select 
                AutTarrifEzamBe.Code, AUTTariff.Code TarrifCode, clsAllPerson.Name DriverName,e.PersonNumber,Bus.BUSNumber
				,case when isnull(EzamBe, 0) > 0 then (select Name from subdefine where bcode = 9101058 AND code = EzamBe) else N'هیچکدام' end EzamBe
				,AutTarrifEzamBe.NumOfSevice NumOfService
                ,(select Name from subdefine where bcode = 9101053 and Code=DriverWorkStatus) DriverWorkStatus
                ,(select Name from subdefine where Code=FaliyatCode) Faliyat, AUTLine.LineNumber
                ,dbo.DateEnToFa(Cast(AutTarrifEzamBe.StartTime as Date)) Date, AUTShift.Title Shift
                ,Cast(AutTarrifEzamBe.StartTime as time(0)) StartTime
                ,Cast(AutTarrifEzamBe.FinishTime as time(0)) EndTime
                ,BusBeja.BUSNumber BusBeja
				from AutTarrifEzamBe
                left join AUTTariff on AutTarrifEzamBe.TarrifCode = AUTTariff.Code
	            left join clsAllPerson on  AutTarrifEzamBe.DriverPCode = clsAllPerson.Code 
	            left join AUTLine  on  AUTLine.Code  = AutTarrifEzamBe.LineCode 
	            left join AUTBus Bus   on  Bus.Code  = AUTTariff.BusCode 
	            left join AUTBus BusBeja   on  BusBeja.Code  = AutTarrifEzamBe.BusCodeBeJa 
	            left join AUTShift    on  AUTShift.Code  = AUTTariff.ShiftCode
	            left join AUTZone    on  AUTZone.Code  = AUTLine.ZoneCode 
	            left join EmpEmployee e on e.pCode = AutTarrifEzamBe.DriverPCode
                    where 1 = 1 " + WhereStr;
            jGridView.Parameters = new object[] { StartEventDate.Value.ToShortDateString() + " 00:00:00", EndEventDate.Value.ToShortDateString() + " 23:59:59" };
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 10;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "JEzamBeReport";
            jGridView.PageOrderByField = " Date Desc, StartTime Desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Buttons = "excel,print,record_print,refresh";

            //
            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBus.SelectedValue == "0")
                {
                    GetReport(0, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                        ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, Convert.ToInt32(cmbLine.SelectedValue)
                        , Convert.ToInt32(cmbZone.SelectedValue));
                }
                else
                {
                    GetReport(Convert.ToInt32(cmbBus.SelectedItem.Text), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                            ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                            ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, Convert.ToInt32(cmbLine.SelectedValue)
                        , Convert.ToInt32(cmbZone.SelectedValue));
                }
            }
            catch { }
        }
    }
}