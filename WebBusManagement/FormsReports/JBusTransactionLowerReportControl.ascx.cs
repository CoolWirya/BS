using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusManagment;
using BusManagment.Line;
using BusManagment.Zone;

namespace WebBusManagement.FormsReports
{
    public partial class JBusTransactionLowerReportControl : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                
                  
                    btnSave_Click(null, null);
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadZones();
                LoadLines();
                LoadBus();
                LoadFleets();
                LoadMonth();
                LoadYears();
            }
        }


        public void LoadMonth()
        {
            string M = ClassLibrary.JDateTime.FarsiMonth(DateTime.Now).ToString();
            
            if (Convert.ToInt32(ClassLibrary.JDateTime.FarsiMonth(DateTime.Now)) < 10)
                M = "0" + ClassLibrary.JDateTime.FarsiMonth(DateTime.Now).ToString();

            cmbMount.SelectedValue = M;
        }

        public void LoadYears()
        {
            int CYear = Convert.ToInt32(ClassLibrary.JDateTime.FarsiYear(DateTime.Now));
            for (int i = CYear; i >= 1392; i--)
            {
                Telerik.Web.UI.RadComboBoxItem RCBI = new Telerik.Web.UI.RadComboBoxItem();
                RCBI.Value = i.ToString();
                RCBI.Text = i.ToString();
                cmbYears.Items.Add(RCBI);
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


        public void GetReport(int ZoneCode = 0, int LineNumber = 0, int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int OwnerCode = 0, int FleetCode = 0, int DayOrMont = 0, int NumOfTransaction = 0)
        {
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JBusTransactionLowerReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JBusTransactionLowerReportControl_"+ZoneCode.ToString()+ "_" +LineNumber.ToString()+ "_" +BusNumebr.ToString()+ "_" +(StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "")+ "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "")+ "_" +OwnerCode.ToString()+ "_" +FleetCode.ToString()+ "_" +DayOrMont.ToString()+ "_" +NumOfTransaction.ToString();

            string WhereStr = "";
            if (ZoneCode > 0)
                WhereStr += " and az.Code = " + ZoneCode;
            if (LineNumber > 0)
                WhereStr += " and al.Code = " + LineNumber;
            if (BusNumebr > 0)
                WhereStr += " and ab.Code = " + BusNumebr;
            if (OwnerCode > 0)
                WhereStr += " and cap.Code = " + OwnerCode;
            if (FleetCode > 0)
                WhereStr += " and af.Code = " + FleetCode;

            if (DayOrMont == 0)
                jGridView.SQL = @"select F.Code,F.Date,F.BusNumber,F.OwnerName,F.FleetName,F.ZoneName,F.LineNumber,F.TicketPrice,F.TCount TransactionCount from (
	                               select max(asd.[Code])Code,asd.[Date],asd.[BusNumber],cap.Name OwnerName
                                  ,af.Name FleetName,az.Name ZoneName,asd.[LineNumber],asd.[TicketPrice]
	                              ,sum(asd.[TCount])TCount
	                               from autshiftdriver asd 
	                               left join AutLine al on al.LineNumber = asd.[LineNumber]
	                               left join AUTZone az on az.Code = al.ZoneCode
	                               left join AUTFleet af on af.Code = al.Fleet
	                               left join AUTBus ab on ab.busNumber = asd.[BusNumber]
	                               left join (select * from AUTBusOwner where IsActive = 1) abo on BusCode = ab.Code
	                               left join clsAllPerson cap on cap.code = abo.CodePerson
	                               where asd.error = 0 and asd.CardType = 0 and ab.Active = 1 and ab.IsValid = 1 " + WhereStr + @"
	                               group by asd.[BusNumber],cap.Name,asd.[Date],af.Name,az.Name,asd.[LineNumber],asd.[TicketPrice]
	                               )F
	                               where F.Date between '" + StartEventDate.Value.ToShortDateString() + @"' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + @"'
	                               and TCount < " + NumOfTransaction;
            else
                jGridView.SQL = @"select F.Code,F.YearM,f.MONTHM,F.BusNumber,F.OwnerName,F.FleetName,F.ZoneName,F.LineNumber,F.TicketPrice,F.TCount from (
	                               select max(asd.[Code])Code,
	                               SUBSTRING(dbo.DateEnToFa([Date]),1,4)YearM,SUBSTRING(dbo.DateEnToFa([Date]),6,2)MONTHM,
	                               asd.[BusNumber],cap.Name OwnerName
                                  ,af.Name FleetName,az.Name ZoneName,asd.[LineNumber],asd.[TicketPrice]
	                              ,sum(asd.[TCount])TCount
	                               from autshiftdriver asd 
	                               left join AutLine al on al.LineNumber = asd.[LineNumber]
	                               left join AUTZone az on az.Code = al.ZoneCode
	                               left join AUTFleet af on af.Code = al.Fleet
	                               left join AUTBus ab on ab.busNumber = asd.[BusNumber]
	                               left join (select * from AUTBusOwner where IsActive = 1) abo on BusCode = ab.Code
	                               left join clsAllPerson cap on cap.code = abo.CodePerson
	                               where asd.error = 0 and asd.CardType = 0 and ab.Active = 1 and ab.IsValid = 1 " + WhereStr + @"
	                               group by asd.[BusNumber],cap.Name,SUBSTRING(dbo.DateEnToFa([Date]),1,4),SUBSTRING(dbo.DateEnToFa([Date]),6,2)
	                               ,af.Name,az.Name,asd.[LineNumber],asd.[TicketPrice]
	                               )F
	                               where F.YearM = '" + cmbYears.SelectedValue + @"' and f.MONTHM = '" + cmbMount.SelectedValue + @"'
	                               and TCount < " + NumOfTransaction;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusTransactionLowerReportControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.PageOrderByField = " BusNumber ";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("TransactionCount", 0);

            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                GetReport(Convert.ToInt32(cmbZone.SelectedValue), Convert.ToInt32(cmbLine.SelectedValue), Convert.ToInt32(cmbBus.SelectedValue)
                    , ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                    ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, Convert.ToInt32(cmbFleets.SelectedValue)
                    , Convert.ToInt32(cmbDayOrMont.SelectedValue), Convert.ToInt32(txtTransactionCount.Text));
            }
            catch { }
        }

        protected void cmbZone_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbZone.SelectedValue) > 0)
            {
                DataTable dtLines = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],convert(nvarchar,[LineNumber])+' -> '+[LineName] as [lineName],LineNumber FROM AUTLine Where ZoneCode = " + cmbZone.SelectedValue + " Order By LineNumber ASC");
                var p = (from v in dtLines.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, lineName = "همه" });
                cmbLine.DataSource = p;
                cmbLine.DataTextField = "lineName";
                cmbLine.DataValueField = "Code";
                cmbLine.DataBind();

                DataTable dtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus Where Active = 1 
                                                                              and LastLineNumber in (SELECT LineNumber FROM AUTLine 
                                                                              Where ZoneCode = " + cmbZone.SelectedValue + ") Order By BusNumber ASC");
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
                LoadLines();
                LoadBus();
            }
        }

        protected void cmbLine_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbLine.SelectedValue) > 0)
            {
                DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
                    (Select ZoneCode From AutLine Where Code = " + cmbLine.SelectedValue + ")");
                var p = (from v in dtZones.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, Name = "همه" });
                cmbZone.DataSource = p;
                cmbZone.DataTextField = "Name";
                cmbZone.DataValueField = "Code";
                cmbZone.DataBind();

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
                LoadZones();
                LoadBus();
            }
        }

        protected void cmbBus_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbBus.SelectedValue) > 0)
            {
                DataTable dtLines = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],convert(nvarchar,[LineNumber])+' -> '+[LineName] as [lineName],LineNumber FROM AUTLine Where LineNumber = (Select LastLineNumber From AutBus Where Code = " + cmbBus.SelectedValue + ") Order By LineNumber ASC");
                var p = (from v in dtLines.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, lineName = "همه" });
                cmbLine.DataSource = p;
                cmbLine.DataTextField = "lineName";
                cmbLine.DataValueField = "Code";
                cmbLine.DataBind();

                DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
                    (Select top 1 ZoneCode From AutLine Where LineNumber = (Select LastLineNumber From AutBus Where Code = " + cmbBus.SelectedValue + "))");
                var p2 = (from v in dtZones.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, Name = "همه" });
                cmbZone.DataSource = p2;
                cmbZone.DataTextField = "Name";
                cmbZone.DataValueField = "Code";
                cmbZone.DataBind();
            }
            else
            {
                LoadZones();
                LoadLines();
            }
        }
    }
}