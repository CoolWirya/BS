using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusFailureDeviceIMEIReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
            else
            {
                btnSave_Click(null, null);
            }
        }

        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            string WhereStrAnd = "";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue == true && StartEventDate.Value.Date > NullDatetime)
            {
                WhereStrAnd += @" and convert(date,ad.StartDate) between '" + StartEventDate.Value.Date.ToShortDateString() + "' and '" + EndEventDate.Value.Date.ToShortDateString() + "'";
            }
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusMaintenance_JBusFailureDeviceIMEIReport");
            jGridView.SQL = @"SELECT top 100 percent TblBusDevice.Code,TblBusDevice.BUSNumber,TblBusDevice.StartDate,TblBusDevice.EndDate,
                                TblBusDevice.IMEIResiterInPortal,ath.[Date] as RecivedDate,ath.IMEI IMEIReciveFromConsole,TblBusDevice.InstallerName FROM
                                (SELECT ad.Code,ad.BusCode,ab.BUSNumber,ad.StartDate,ad.EndDate,a.IMEI AS IMEIResiterInPortal,ap.Name AS InstallerName FROM AUTBusDevise ad
                                LEFT JOIN AUTDevice a ON ad.DeviceCode=a.Code
                                LEFT JOIN AUTBus ab ON ad.BusCode=ab.Code
                                LEFT JOIN clsAllPerson ap ON ad.Installer=ap.Code
                                WHERE 1=1 " + WhereStrAnd + @")TblBusDevice
                                LEFT JOIN AUTTicketTransaction att ON TblBusDevice.BusCode = att.BusCode
                                LEFT JOIN AUTHeaderTransaction ath ON att.HeaderTransactionCode = ath.Code
                                WHERE TblBusDevice.IMEIResiterInPortal <> ath.IMEI AND ath.[Date] BETWEEN TblBusDevice.StartDate AND TblBusDevice.EndDate 
                                GROUP BY TblBusDevice.Code,TblBusDevice.BUSNumber,TblBusDevice.StartDate,TblBusDevice.EndDate,
                                TblBusDevice.IMEIResiterInPortal,ath.[Date],ath.IMEI,TblBusDevice.InstallerName";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusFailureDeviceIMEIReportControl";
            jGridView.Buttons = "excel";
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).LoadGrid(true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }
    }
}