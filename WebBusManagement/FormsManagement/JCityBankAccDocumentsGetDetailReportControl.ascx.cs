using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JCityBankAccDocumentsGetDetailReportControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            GetReport(Code);
        }
        public void GetReport(int DocumnetCode)
        {
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("JCityBankAccDocumentsGetDetailReportControl");
            jGridView.SQL = @"select top 100 percent [Code]
                              ,[EventDate]
                              ,[RecievedDate]
                              ,[DriverCardSerial]
                              ,[DriverPersonCode]
                              ,[DriverPersonName]
                              ,[LineNumber]
                              ,[ZoneName]
                              ,[FleetName]
                              ,[BusNumber]
                              ,[PassengerCardSerial]
                              ,[CardType]
                              ,[TicketPrice] * 10 TicketPrice
                              ,[RemainPrice]
                              ,[ReaderId]
                              ,[Bin] CBin
                              ,[TerminalID]
                              ,[WaletID]
                              ,[CType]
                              ,[LTD]
                              ,[ServerMac]
                              ,[MacOut]
                              ,[LTB]
                              ,[Counter]
                              ,[ServerID]
                              ,[BankType]
	                          from AUTTicketTransactionCityBank where FileGenerate = " + DocumnetCode.ToString();
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JCityBankAccDocumentsGetDetailReportControl";
            jGridView.PageOrderByField = "Code";
            jGridView.Buttons = "excel";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("TicketPrice", 0);
            
            
        }
    }
}