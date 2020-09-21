using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JTransactionsDetailsReportControl : System.Web.UI.UserControl
    {
        int Code;
        string Type;
        public string Title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (Request["Type"] != null)
                Type = Request["Type"];
            switch (Type)
            {
                case "Karkard":
                    Title = "گزارش کارکرد";
                    trBus.Visible = true;
                    break;
                case "Pardakht":
                    Title = "گزارش پرداخت";
                    break;
                case "Total":
                    Title = "گزارش مرور حساب";
                    break;
            }
            if (IsPostBack)
            {
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
                GetReport();
            }
            //GetReportTotal(Code);
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

        public void GetReport(int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            string Where = "";
            if (BusNumebr > 0)
                Where += " and cast(right(str(TafziliCode2 ),4 ) as int) = " + BusNumebr;
            if (StartEventDate != null && EndEventDate != null)
            {
                Where += " and DateSave between '{0}' and '{1}'";
            }
            string SQL = "";
            string JustKarkard = @"select TafziliCode1 Code, DocCode , right(str(TafziliCode2 ),4 ) BusNumber
		        ,(select name from clsAllPerson where code=TafziliCode1) name
		        ,isnull(10 * cast(BesPrice as bigint),0) BesPrice
		        ,isnull(10 * cast(BedPrice as bigint),0) BedPrice
				, Description, dbo.DateEnToFa(DateSave) Date
		        from FinDocumentDetails 
		        where 
		        ((select code from FinDocument where code=DocCode and IsOk=1 and code<>120160534) is not null OR DocCode = 120160533) 
		        and MoeinCode=3 and DocCode between 100000000 and 200000000 
		        and TafziliCode1 = " + Code.ToString() + Where;
            string Karkard = @"select TafziliCode1 Code, DocCode 
		        ,(select name from clsAllPerson where code=TafziliCode1) name
		        ,isnull(10 * cast(BesPrice as bigint),0) BesPrice
		        ,isnull(10 * cast(BedPrice as bigint),0) BedPrice
				, Description COLLATE SQL_Latin1_General_CP1_CI_AS Description
                , dbo.DateEnToFa(DateSave) Date
		        from FinDocumentDetails 
		        where 
		        ((select code from FinDocument where code=DocCode and IsOk=1 and code<>120160534) is not null OR DocCode = 120160533) 
		        and MoeinCode=3 and DocCode between 100000000 and 200000000 
		        and TafziliCode1 = " + Code.ToString() + Where;
            string Pardakht = @"select TafziliCode1 Code, DocCode 
		        ,(select name from clsAllPerson where code=TafziliCode1) name
		        ,0 BesPrice
		        ,isnull(10 * cast(BedPrice as bigint),0) BedPrice
				, Description COLLATE SQL_Latin1_General_CP1_CI_AS Description
                , dbo.DateEnToFa(DateSave) Date
		        from FinDocumentDetails 
		        where 
		        MoeinCode=3 and DocCode between 400000000 and 500000000 
		        and TafziliCode1 = " + Code.ToString() + Where;
            switch (Type)
            {
                case "Karkard":
                    SQL = JustKarkard;
                    break;
                case "Pardakht":
                    SQL = Pardakht;
                    break;
                case "Total":
                    SQL = Karkard + " union all " + Pardakht;
                    break;
            }
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            if (StartEventDate != null && EndEventDate != null)
                jGridView.Parameters = new object[] { StartEventDate.Value.ToShortDateString() + " 00:00:00", EndEventDate.Value.ToShortDateString() + " 23:59:59" };
            jGridView.ClassName = "WebBusManagement_FormsManagement_JTransactionsDetailsReportControl_" + Code;
            jGridView.SQL = SQL;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "TransactionsDetails";
            jGridView.PageOrderByField = "Date desc";
            jGridView.Buttons = "excel";
            //jGridView.SumFields = new Dictionary<string, double>();
            //jGridView.SumFields.Add("CardCount", 0);
            //jGridView.SumFields.Add("Price", 0);
            jGridView.Bind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBus.SelectedValue == "0")
                {
                    GetReport(0, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                }
                else
                {
                    GetReport(Convert.ToInt32(cmbBus.SelectedItem.Text), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                            ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                }
            }
            catch { }
        }
    }
}