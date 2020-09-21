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
    public partial class JBusPerformanceYearlyReportControl : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {

            }
            else
            {
               // btnSave_Click(null, null);
                LoadYears();
                LoadBus();
            }

        }
        public void LoadYears()
        {
            string Year = ClassLibrary.JDateTime.FarsiYear(DateTime.Now);
            for (int i = Convert.ToInt32(Year); i > 1390; i--)
            {
                Telerik.Web.UI.RadComboBoxItem RBI = new Telerik.Web.UI.RadComboBoxItem();
                RBI.Value = i.ToString();
                RBI.Text = i.ToString();
                cmbFromYear.Items.Add(RBI);

            }
            Year = ClassLibrary.JDateTime.FarsiYear(DateTime.Now);
            for (int i = Convert.ToInt32(Year); i > 1390; i--)
            {
                Telerik.Web.UI.RadComboBoxItem RBI = new Telerik.Web.UI.RadComboBoxItem();
                RBI.Value = i.ToString();
                RBI.Text = i.ToString();
                cmbToYear.Items.Add(RBI);
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


        public void GetReport(int BusNumber = 0, int fromYear = 0, int toYear = 0)
        {
            if (fromYear > toYear)
            {
                JWebManager.ShowMessage("تاریخ شروع نمیتواند از تاریخ پایان بزرگتر باشد", MessageType.Error);
                return;

            }
            System.Globalization.PersianCalendar PersianFormYear = new System.Globalization.PersianCalendar();
            System.Globalization.PersianCalendar PersianToYear = new System.Globalization.PersianCalendar();

            string fromDateTimeString = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
            string toDateTimeString = DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59";

            if (fromYear > 0)
                fromDateTimeString = new DateTime(fromYear, 1, 1, PersianFormYear).ToString("yyyy-MM-dd") + " 00:00:00";
            if (toYear > 0)
                toDateTimeString = new DateTime(toYear, 12, 29, PersianToYear).ToString("yyyy-MM-dd") + " 23:59:59";
            
            string WhereStr = "";
            string WhereStr2 = "";
            string WhereStr3 = "";
         
            WhereStr += " date between '" + fromDateTimeString + "' and '" + toDateTimeString + "'";

            if (BusNumber > 0)
            {
                WhereStr += "and BusNumber =" + BusNumber;

            }

            WhereStr2 += " abs.date between '" + fromDateTimeString + "' and '" + toDateTimeString + "'";

            if (BusNumber > 0)
            {
                WhereStr2 += "and abs.BusNumber =" + BusNumber;

            }

            WhereStr3 += " ,'" + fromDateTimeString + "','" + toDateTimeString + "'";

            (RadGridReport as WebControllers.MainControls.Grid.JGridView).ClassName = "WebBusManagement_FormsReports_JBusPerformanceYearlyReportControl_" + BusNumber.ToString() + "_" + (fromDateTimeString) + "_" + (toDateTimeString);
            (RadGridReport as WebControllers.MainControls.Grid.JGridView).SQL = @" select a.BusNumber, ISNULL(COUNT(a.count),0) NumOfDayService ,a.Year
                                    ,(select((datediff(DAY  " + WhereStr3 + @")+1)-ISNULL(COUNT(a.count),0)))NumOfDayInActive
                               from(
                                  select busnumber, date, count(date) count,Year 
								  from
                                   (
                                        select BusNumber,Date,LEFT(dbo.dateentofa(date),4) Year
                                        from Autshiftdriver shift
                                        where " + WhereStr + @"
										and busnumber in 
										(
										select distinct abs.busnumber from autbusservices abs
										inner join autbus bus on bus.busnumber=abs.busnumber 
										 where " +WhereStr2+ @" and isnull(abs.deleted, 0) = 0 and bus.isvalid=1
										)

                                   )t
                                         group by BusNumber, date, Year
                                 )a
                               group by a.BusNumber, a.Year";
            (RadGridReport as WebControllers.MainControls.Grid.JGridView).SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            (RadGridReport as WebControllers.MainControls.Grid.JGridView).HiddenColumns = "Code";
            (RadGridReport as WebControllers.MainControls.Grid.JGridView).Title = "BusPerformanceYearlyReportControl";
            (RadGridReport as WebControllers.MainControls.Grid.JGridView).PageOrderByField = "Date asc";
            (RadGridReport as WebControllers.MainControls.Grid.JGridView).Buttons = "excel,print,record_print";
            (RadGridReport as WebControllers.MainControls.Grid.JGridView).PageOrderByField = " BusNumber ";
            (RadGridReport as WebControllers.MainControls.Grid.JGridView).Actions = new List<JActionsInfo>();
            (RadGridReport as WebControllers.MainControls.Grid.JGridView).Bind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                if (cmbBus.SelectedValue == "0")
                {
                    GetReport(0, Convert.ToInt32(cmbFromYear.SelectedValue), Convert.ToInt32(cmbToYear.SelectedValue));
                }
                else
                {
                    GetReport(Convert.ToInt32(cmbBus.SelectedItem.Text), Convert.ToInt32(cmbFromYear.SelectedValue), Convert.ToInt32(cmbToYear.SelectedValue));
                }

            }
            catch { }

        }
    }
}







