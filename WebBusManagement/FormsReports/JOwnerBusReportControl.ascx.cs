using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JOwnerBusReportControl : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            GetReport();

        }


        public void GetReport()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JOwnerBusReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JOwnerBusReportControl";
            jGridView.SQL = @"select 1 Code, bus.BUSNumber, person.Name, account.AccountNo, comparative.value TafsiliCode from AUTBusOwner ownr
	                            join AUTBus bus on ownr.BusCode = bus.Code
	                            join finBankAccount account on account.PCode = ownr.CodePerson
	                            join clsAllPerson person on person.Code = ownr.CodePerson
	                            join finComparativeCode comparative on comparative.ObjectCode = ownr.CodePerson";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "JOwnerBusReportControl";
            jGridView.PageOrderByField = " Name";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.Bind();
            
        }
    }
}