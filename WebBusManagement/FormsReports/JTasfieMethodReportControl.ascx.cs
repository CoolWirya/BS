using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JTasfieMethodReportControl : System.Web.UI.UserControl
    {
        int TafziliCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
            else
            {
                int.TryParse(Request["Code"], out TafziliCode);
                GetReport(TafziliCode);
            }
        }
        void GetReport(int TafziliCode)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JTasfieMethodReportControl";
            jGridView.SQL = @"
                select ROW_NUMBER() over (order by a.BusNumber, a.DateSave) Code, a.BusNumber,(select name from clsallPerson where code=(select top 1 TafziliCode1 from FinDocumentDetails where TafziliCode2-30000000 = a.BusNumber)) Name
                ,dbo.DateEnToFa(a.DateSave) DateF
                ,Bes 'پرداخت'
                ,Bed OverPay
                ,Price RealKarkard
                from
                (
	                select TafziliCode2-30000000 BusNumber,FDD.DateSave,cast(sum(BesPrice) as bigint) Bes, cast(SUM(BedPrice) as bigint) Bed,cast(sum(BesPrice) - SUM(BedPrice)as bigint) BesBed
	                from FinDocumentDetails FDD
	                inner join FinDocument FD ON FD.Code=FDD.DocCode
								                where 
								                MoeinCode in (3) and 
								                DocCode between 100000000 and 200000000 and
								                1=1
	                group by TafziliCode2,FDD.DateSave 
                ) a
                inner join
                (
                select BusNumber,Date,sum(TCount*TicketPrice) Price from AUTShiftDriver  group by BusNumber,Date
                )b
                on a.BusNumber = b.BusNumber and a.DateSave=b.Date
                where 1=1 
                and Bed>0
                and (select top 1 TafziliCode1 from FinDocumentDetails where TafziliCode2-30000000 = a.BusNumber) = " + TafziliCode;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "BusTasfieMethodReport";
            jGridView.PageOrderByField = " Code";
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.Bind();
        }
    }
}