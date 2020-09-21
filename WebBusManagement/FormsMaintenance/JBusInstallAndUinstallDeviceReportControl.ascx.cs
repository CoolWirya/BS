using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusInstallAndUinstallDeviceReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Int64 CuIMEI;
                if (txtIMEI.Text != "" && txtIMEI.Text.Length == 15)
                {
                    if (Int64.TryParse(txtIMEI.Text, out CuIMEI) == true)
                    {
                        GetReport(Convert.ToInt64(txtIMEI.Text));
                    }
                }
            }
            else
            {
                LoadBus();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
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

        public void GetReport(Int64 IMEI = 0, double BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            string WhereStr = " where 1=1 ";
            if (IMEI > 0)
                WhereStr += " and AD.IMEI = " + IMEI;
            if (BusNumebr > 0)
                WhereStr += " and AB.BUSNumber = " + BusNumebr;
            if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
            {
                DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
                DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
                WhereStr += @" and ABD.[EventDate] between '" + StartDTime.ToShortDateString() + "' and '" + EndDTime.ToShortDateString() + "'";
            }

            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusInstallAndUinstallDeviceReportControl");
            jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusInstallAndUinstallDeviceReportControl" + IMEI.ToString() + "_" + BusNumebr.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = @"select ABD.Code,AB.BUSNumber,AB.LastLineNumber
                            ,(Select Fa_Date from StaticDates Where En_Date =  ABD.EventDate) EventDate
                            ,CASE WHEN AD.Type=1 THEN N'کنسول' ELSE N'کارتخوان' END DeviceType
                            ,AD.Tel,AD.IMEI 
                            , person.Name InstallerName
                            ,CASE ABD.[TYPE] WHEN 0 THEN N'نصب' ELSE N'فک' END AS [Type]
                            ,sdf.name FailureName
                            ,Description
                            from AUTBus AB
                            inner join AUTBusInstallAndUnistallDevise ABD ON AB.Code = ABD.BusCode
                            inner join AUTDevice AD ON AD.Code = ABD.DeviceCode
                            inner join clsAllPerson person on person.Code = ABD.Installer
                            left join subdefine sdf on sdf.Code = ABD.BusFailureCode"
                            + WhereStr;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusInstallAndUinstallDeviceReportControl";
            jGridView.Buttons = "excel";
            jGridView.Bind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int64 CuIMEI;
            if (txtIMEI.Text != "" && txtIMEI.Text.Length == 15)
            {
                if (Int64.TryParse(txtIMEI.Text, out CuIMEI) == true)
                {
                    GetReport(Convert.ToInt64(txtIMEI.Text), Convert.ToDouble(cmbBus.SelectedItem.Text),
                    ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                }
            }
            else
            {
                if (cmbBus.SelectedItem.Value != "0")
                {
                    GetReport(0, Convert.ToDouble(cmbBus.SelectedItem.Text),
                        ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                }
                else
                {
                    GetReport(0, Convert.ToDouble(0),
                        ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                }
            }
        }
    }
}