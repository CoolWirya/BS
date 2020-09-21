using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JTarrifHokmeKarUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadZones();
                LoadSeri();
                LoadShift();
                LoadLines();
            }
            ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
            ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
        }

        public void LoadShift()
        {
            DataTable DtShift = new DataTable();
            DtShift = BusManagment.WorkOrder.JShifts.GetDataTable(0);
            cmbShift.DataSource = DtShift;
            cmbShift.DataTextField = "Title";
            cmbShift.DataValueField = "Code";
            cmbShift.DataBind();
        }

        public void LoadSeri()
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select Seri Code,Seri Name from AutTarrifHokmeKar
                                                                       group by Seri");
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbSeri.DataSource = p;
            cmbSeri.DataTextField = "Name";
            cmbSeri.DataValueField = "Code";
            cmbSeri.DataBind();
        }

        public void LoadLines()
        {
            DataTable dt = BusManagment.Line.JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, lineName = "همه" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        public void LoadZones()
        {
            DataTable dt = BusManagment.Zone.JZones.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbZone.DataSource = p;
            cmbZone.DataTextField = "Name";
            cmbZone.DataValueField = "Code";
            cmbZone.DataBind();
        }

        public bool Save(DateTime date)
        {
            string WhereStr = "", HasdupStr = "";
            if (cmbZone.SelectedValue != "0")
            {
                WhereStr += " and a.ZoneCode = " + cmbZone.SelectedValue.ToString();
                HasdupStr = " and ZoneCode = " + cmbZone.SelectedValue.ToString();
            }
            if (cmbSeri.SelectedValue != "0")
            {
                WhereStr += " and a.Seri = " + cmbSeri.SelectedValue.ToString();
                HasdupStr = " and DriverCode in (select DriverPCode from AutTarrifHokmeKar where Seri = " + cmbSeri.SelectedValue.ToString() + ") ";
            }
            if (cmbLine.SelectedValue != "0")
            {
                WhereStr += " and a.LineCode = " + cmbLine.SelectedValue.ToString();
                HasdupStr = " and BusCode in (select code from AUTBus where LastLineNumber = ( select linenumber from autline where code = " + cmbLine.SelectedValue.ToString() + @"))";
            }
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            DataTable HasDuplicateDate = WebClassLibrary.JWebDataBase.GetDataTable(@"select ISNULL(count(*),0)C from AUTTariff where ShiftCode = " + cmbShift.SelectedValue.ToString() + " and cast([Date] as date)=cast('" + date.ToShortDateString() + @"' as date) " + HasdupStr);
            if (Convert.ToInt32(HasDuplicateDate.Rows[0][0].ToString()) == 0)
            {

                


                Db.setQuery(@"insert into [AUTTariff]
                            select Row_number() over (order by a.LineCode)+(select isnull(max(code),0) from [AUTTariff])Code,a.LineCode,0,(select Code from autbus where busnumber = a.BusNumber),
                            DriverPCode,[NahveyeHamkariCode],[VaziayeHamkariCode],'" + date.ToShortDateString() + @" 00:00:00',
                            (select startTime from autshift where code = " + cmbShift.SelectedValue.ToString() + @"),
                            (select endTime from autshift  where code = " + cmbShift.SelectedValue.ToString() + @")," + cmbShift.SelectedValue.ToString() + @",[FaliyatCode]
                            ,[OnvaneShoghliCode],null,[ZoneCode],0,isnull((select top 1 TransactionCount from AUTDailyLineTransactionCount where LineCode = a.LineCode order by code desc),0), a.NumOfService
                            from AutTarrifHokmeKar a where a.LineCode > 0 and a.BusNumber Is Not null and a.BusNumber in (select BusNumber from autbus) and a.Status = 1 " + WhereStr);
                if (Db.Query_Execute() >= 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public List<DateTime> GetAllDateBetweenToDates(DateTime start, DateTime end)
        {
            var dates = new List<DateTime>();

            for (var dt = start; dt <= end; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }
            return dates;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int Flag = 0;
            var dates = GetAllDateBetweenToDates(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            for (int i = 0; i < dates.Count; i++)
            {
                if (Save(dates[i]))
                { }
                else { Flag = 1; break; }
            }
            if (Flag == 0)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت ثبت شد');", "OKDialog");
                WebClassLibrary.JWebManager.CloseAndRefresh();
            }
            else { WebClassLibrary.JWebManager.RunClientScript("alert('این تعرفه قبلا ثبت شده و تکراری است');", "OKDialog"); }
        }

    }
}