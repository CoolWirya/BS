using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassLibrary;
using WebClassLibrary;

namespace WebBusManagement.FormsReports
{
    public partial class JBusServiceWithoutTransactionReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {


               //   btnSave_Click(null, null);
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
                

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
        public void GetReport(int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null , int MaxTransaction = 0)
        {
            string WhereStr = " ";
            string WhereStr2 = " ";
            string WhereStr3 = " ";
            string WhereStr4 = " ";
            if (BusNumebr > 0)
                WhereStr += " and a.BusNumber = " + BusNumebr;
            if (MaxTransaction > 0)
            {
                WhereStr3 += " TicketCount < " + MaxTransaction;
            }
            WhereStr2 += " t.eventdate between '" + StartEventDate.Value.ToShortDateString() + " 00:00:00' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + " 23:59:59'";
            WhereStr += "  a.Date between '" + StartEventDate.Value.ToShortDateString() + " ' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "")+"'" ;
            WhereStr4 +="a.firststationdate >'"  +StartEventDate.Value.ToShortDateString() + " 06:00:00' and a.firststationdate <'" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + " 20:00:00'";
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JBusServiceWithoutTransactionReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JBusServiceWithoutTransactionReportControl_" + BusNumebr.ToString() + "_"
                + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_"
                + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + MaxTransaction.ToString();
            jGridView.SQL = @"             

                                          select  busnumber,eventdate, passengercardserial,remainprice  into #T from AUTTicketTransaction t 
                                          where  " + WhereStr2 + @"  group by busnumber, eventdate, passengercardserial,remainprice 
                                          select 
                                           a.Code,a.Busnumber,a.linenumber,a.Numofservice,a.IsOk 
                                          ,(select count(*) c from #T t where t.busnumber=a.BusNumber and  t.eventdate between a.firststationdate and a.laststationdate) TicketCount
                                          ,dbo.DateEnToFa(a.Date)Date,a.FirstStationCode
            						      ,LEFT(CAST(CONVERT(time,a.FirstStationDate) AS CHAR(16)),8)FirstStationDate,
                                          a.LastStationCode, LEFT(CAST(CONVERT(time,a.LastStationDate) AS CHAR(16)),8)LastStationDate
            							  into #TT
                                          from AutBusServices a														  
                                          where 1=1 and  " + WhereStr + @"  and deleted=0 and isok in(2,5,11)
                                          <#PreviusSQL#>
                                          select Code,BusNumber,LineNumber,NumOfService, case when IsOk=5 then N'ردیابی تخمینی' when IsOk=2 then N' ردیابی کامل' when IsOk=11 then N'سرویس بازرس' end as servicedescription
                                          ,TicketCount,Date,FirstStationCode,FirstStationDate,LastStationCode,LastStationDate from #TT where " + WhereStr3 + @" and   firststationdate between '06:00:00' and '20:00:00' 
                                          ";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusServiceWithoutTransactionReportControl";
            jGridView.PageOrderByField = "Date asc";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.PageOrderByField = " BusNumber ";
            jGridView.Bind();
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JBusServiceWithoutTransactionReportControl._ShowViewMapNew", null, null));
        }
        public string _ShowViewMapNew(string code)
        {
           
                return WebClassLibrary.JWebManager.LoadClientControl("ViewMap"
                    , "~/WebBusManagement/FormsManagement/JViewMap.ascx"
                    , "نقشه مشاهده مسیر"
                    , new List<Tuple<string, string>>() { new Tuple<string, string>("code", code) }
                    , WindowTarget.NewWindow
                    , true, false, true, 770, 450);
           
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //InitialReport = false;
            try
            {
                if (cmbBus.SelectedValue == "0")
                {
                    GetReport(0, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), int.Parse(txtMaxTransaction.Text)
                    );
                }
                else
                {
                    GetReport(Convert.ToInt32(cmbBus.SelectedItem.Text), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), int.Parse(txtMaxTransaction.Text)
                    );
                }

            }
            catch { }
        }
        
    }
}

