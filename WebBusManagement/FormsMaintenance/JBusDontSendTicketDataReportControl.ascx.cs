using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusDontSendTicketDataReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBus();
                LoadFleets();
            }
            else
            {
                int SimCharge;
                if (txtNumOfDay.Text != "")
                {
                    if (int.TryParse(txtNumOfDay.Text, out SimCharge) == true)
                    {
                        if (SimCharge > 0)
                        {
                            GetReport(0, Convert.ToInt32(txtNumOfDay.Text), Convert.ToInt32(cmbFleets.SelectedValue));
                        }
                    }
                }
            }
        }

        public void LoadFleets()
        {
            DataTable dt = BusManagment.Fleet.JFleets.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbFleets.DataSource = p;
            cmbFleets.DataTextField = "Name";
            cmbFleets.DataValueField = "Code";
            cmbFleets.DataBind();
            if (cmbFleets.Items.Count > 1)
            {
                cmbFleets.SelectedIndex = 1;
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

        public void GetReport(int Mode = 0, int SimCardCharge = 0, int FleetCode = 0)
        {

            string BusQuery = "";
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            DB.setQuery(@"select ISNULL(IsAdmin,0)IsAdmin from users where Code = " + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
            DataTable DtBusCheck = DB.Query_DataTable();
            if (DtBusCheck.Rows[0]["IsAdmin"].ToString() != "True")
            {
                BusQuery = "  and len(ab.BusNumber)=4 and ab.BusNumber < 6999  ";
            }


            string FleetWhere = "";
            if (FleetCode > 0)
                FleetWhere = " and ab.FleetCode = " + FleetCode;
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusDontSendTicketDataReportControl");
            jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusDontSendTicketDataReportControl_" + Mode.ToString() + "_" + SimCardCharge + "_" + FleetCode;
            jGridView.SQL = @"select ab.Code,af.Name FleetName,ab.LastLineNumber LineNumber,ab.BUSNumber,
                                ab.TicketLastDate,ab.LastSimCardCharge,sf.name as FailureName from AUTBus ab 
                                left join AUTFleet af on af.Code = ab.FleetCode
                                left join AUTBusFailure abf on abf.BusCode = ab.Code and cast(abf.Date as date) = cast(ab.TicketLastDate as date)
								left join subdefine sf on sf.Code = abf.BusFailureCode
                                where cast(ab.TicketLastDate as date) <= cast(dateadd(day,-" + SimCardCharge + @",getdate()) as date)
                                and (len(ab.LastLineNumber)=3 or len(ab.LastLineNumber)=4) and ab.LastLineNumber < 200 " + FleetWhere + BusQuery;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.PageOrderByField = "TicketLastDate desc";
            jGridView.Title = "JBusDontSendTicketDataReportControl";
            jGridView.Buttons = "excel";
            jGridView.Bind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int SimCharge;
            if (txtNumOfDay.Text != "")
            {
                if (int.TryParse(txtNumOfDay.Text, out SimCharge) == true)
                {
                    if (SimCharge > 0)
                    {
                        GetReport(0, Convert.ToInt32(txtNumOfDay.Text), Convert.ToInt32(cmbFleets.SelectedValue));
                    }
                    else
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('لطفا عدد بزرگتر از صفر وارد کنید');", "UpdateSettings");
                    }
                }
                else
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('لطفا عدد وارد کنید');", "UpdateSettings");
                }
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا تعداد روز را وارد کنید');", "UpdateSettings");
            }
        }

    }
}