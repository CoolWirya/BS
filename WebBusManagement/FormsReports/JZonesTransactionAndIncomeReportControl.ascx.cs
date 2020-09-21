using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using BusManagment.Zone;
using System.Data;
using WebClassLibrary;

namespace WebBusManagement.FormsReports
{
    public partial class JZonesTransactionAndIncomeReportControl : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {


            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadZones();
                LoadCardType();
                LoadFleets();
                btnSave_Click(null, null);
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

        public void LoadCardType()
        {
            DataTable DtCardType = new DataTable();
            DtCardType = BusManagment.Card.JCards.GetDataTable(0);
            var p = (from v in DtCardType.AsEnumerable()
                     select new { Type = Convert.ToInt32(v["Type"]), Type1 = v["Type"].ToString() }).ToList();
            p.Insert(0, new { Type = -1, Type1 = "همه" });
            cmbCardType.DataSource = p;
            cmbCardType.DataTextField = "Type1";
            cmbCardType.DataValueField = "Type";
            cmbCardType.DataBind();
            cmbCardType.SelectedValue = "0";
        }

        public void LoadZones()
        {
            DataTable dt = JZones.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbZone.DataSource = p;
            cmbZone.DataTextField = "Name";
            cmbZone.DataValueField = "Code";
            cmbZone.DataBind();
        }

        public void GetReport(int ZoneCode = 0, int DayType = -1, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int CardType = -1, int FleetCode = 0)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusReports_JBusReports");
            jGridView.ClassName = "WebBusReports_JBusReports_GetReport_Zone_" + ZoneCode.ToString() + "_" + DayType.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "_" + CardType.ToString() + "_" + FleetCode.ToString();
            jGridView.SQL = BusManagment.Zone.JZones.GetWebReportQuery(ZoneCode, DayType, StartEventDate, EndEventDate, CardType, FleetCode,chkJustZone.Checked);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JZonesTransactionAndIncomeReport";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("TransactionCount", 0);
            jGridView.SumFields.Add("InCome", 0);
            jGridView.Bind();
            //
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            GetReport(Convert.ToInt32(cmbZone.SelectedValue), Convert.ToInt32(cmbDayType.SelectedValue),
                    ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                    Convert.ToInt32(cmbCardType.SelectedValue), Convert.ToInt32(cmbFleets.SelectedValue));
        }

    }
}