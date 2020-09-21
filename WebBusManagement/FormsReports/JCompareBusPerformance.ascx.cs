using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassLibrary;
using BusManagment.Line;
using WebClassLibrary;

namespace WebBusManagement.FormsReports
{
    public partial class JCompareBusPerformance : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {


            }
            else
            {
           
                LoadLines();
                LoadBus();
                btnSave_Click(null, null);
                LoadToYears();
                LoadToMonth();
                LoadFromYears();
                LoadFromMonth();
            }
        }

        public void LoadLines()
        {
            DataTable dt = JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, lineName = "همه" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
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

        public void LoadFromMonth()
        {
            cmbfromMount.SelectedValue = ClassLibrary.JDateTime.FarsiMonth(DateTime.Now);
        }
        public void LoadToMonth()
        {
            cmbtoMount.SelectedValue = ClassLibrary.JDateTime.FarsiMonth(DateTime.Now);
        }

        public void LoadFromYears()
        {
            int CYear = Convert.ToInt32(ClassLibrary.JDateTime.FarsiYear(DateTime.Now));
            for (int i = CYear; i >= 1392; i--)
            {
                Telerik.Web.UI.RadComboBoxItem RCBI = new Telerik.Web.UI.RadComboBoxItem();
                RCBI.Value = i.ToString();
                RCBI.Text = i.ToString();
                cmbfromYears.Items.Add(RCBI);
            }
        }
        public void LoadToYears()
        {
            int CYear = Convert.ToInt32(ClassLibrary.JDateTime.FarsiYear(DateTime.Now));
            for (int i = CYear; i >= 1392; i--)
            {
                Telerik.Web.UI.RadComboBoxItem RCBI = new Telerik.Web.UI.RadComboBoxItem();
                RCBI.Value = i.ToString();
                RCBI.Text = i.ToString();
                cmbtoYears.Items.Add(RCBI);
            }
        }

        public void GetReport(int fromYear = 0, int fromMount = 0, int toYear = 0, int toMount = 0, int LineNumber = 0, int BusNumebr = 0 )
        {
            int NumOfDay = 0;
            if (toMount <= 6)
                NumOfDay = 31;
            else if (toMount > 6)
                NumOfDay = 30;
            if (fromMount <= 6)
                NumOfDay = 31;
            else if (fromMount > 6)
                NumOfDay = 30;

            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JCompareBusPerformanceReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JCompareBusPerformanceReportControl_"+ LineNumber.ToString() + "_" + BusNumebr.ToString() + "_" + toYear.ToString() + "_" +toMount.ToString() + fromYear.ToString() + "_" + fromMount.ToString();
           // jGridView.SQL = BusManagment.Bus.JBuses.GetCompareBusPerformanceReportQuery(LineNumber, BusNumebr,toYear, toMount ,fromYear,fromMount);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JCompareBusPerformanceReportControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.PageOrderByField = " BusNumber ";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("TransactionCount", 0);
            jGridView.SumFields.Add("InCome", 0);
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Bind();

        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                GetReport(Convert.ToInt32(cmbtoYears.SelectedValue), Convert.ToInt32(cmbtoMount.SelectedValue), Convert.ToInt32(cmbfromYears.SelectedValue), Convert.ToInt32(cmbfromMount.SelectedValue), Convert.ToInt32(cmbLine.SelectedValue),
                    Convert.ToInt32(cmbBus.SelectedValue)
                                );
            }
            catch { }
        }

       
        protected void cmbLine_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbLine.SelectedValue) > 0)
            {
                
                DataTable dtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus Where Active = 1 
                                                                              and LastLineNumber in (SELECT LineNumber FROM AUTLine 
                                                                              Where Code = " + cmbLine.SelectedValue + ") Order By BusNumber ASC");
                var p2 = (from v in dtBus.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, BUSNumber = "همه" });
                cmbBus.DataSource = p2;
                cmbBus.DataTextField = "BUSNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
            }
            else
            {
                LoadBus();
            }
        }

        protected void cmbBus_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbBus.SelectedValue) > 0)
            {
                DataTable dtLines = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],convert(nvarchar,[LineNumber])+' - - > '+[LineName] as [lineName],LineNumber FROM AUTLine Where LineNumber = (Select LastLineNumber From AutBus Where Code = " + cmbBus.SelectedValue + ") Order By LineNumber ASC");
                var p = (from v in dtLines.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, lineName = "همه" });
                cmbLine.DataSource = p;
                cmbLine.DataTextField = "lineName";
                cmbLine.DataValueField = "Code";
                cmbLine.DataBind();

             }
            else
            {
                LoadLines();
            }
        }

    }
}