using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JTariffHokmeKarBaseDefineUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
                LoadZones();
                LoadSeri();
                LoadShift();
                LoadLines();
            }
            ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
            ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            _SetForm();
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


        public void _SetForm()
        {
            BusManagment.WorkOrder.JTarrfiHokmeKarBaseDefine TarrfiHokmeKarBaseDefine = new BusManagment.WorkOrder.JTarrfiHokmeKarBaseDefine();

            if (Code > 0)
            {
                TarrfiHokmeKarBaseDefine.GetData(Code);
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(TarrfiHokmeKarBaseDefine.StartDate);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(TarrfiHokmeKarBaseDefine.EndDate);
                cmbZone.SelectedValue = TarrfiHokmeKarBaseDefine.ZoneCode.ToString();
                cmbLine.SelectedValue = TarrfiHokmeKarBaseDefine.LineCode.ToString();
                cmbSeri.SelectedValue = TarrfiHokmeKarBaseDefine.Seri.ToString();
                cmbShift.SelectedValue = TarrfiHokmeKarBaseDefine.ShiftCode.ToString();
                txtDatePeriod.Text = TarrfiHokmeKarBaseDefine.DatePeriod.ToString();
            }
        }

        public bool Save()
        {
            BusManagment.WorkOrder.JTarrfiHokmeKarBaseDefine TarrfiHokmeKarBaseDefine = new BusManagment.WorkOrder.JTarrfiHokmeKarBaseDefine();
            TarrfiHokmeKarBaseDefine.Code = Code;
            TarrfiHokmeKarBaseDefine.StartDate = ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate();
            TarrfiHokmeKarBaseDefine.EndDate = ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate();
            TarrfiHokmeKarBaseDefine.ZoneCode = Convert.ToInt32(cmbZone.SelectedValue);
            TarrfiHokmeKarBaseDefine.LineCode = Convert.ToInt32(cmbLine.SelectedValue);
            TarrfiHokmeKarBaseDefine.Seri = Convert.ToInt32(cmbSeri.SelectedValue);
            TarrfiHokmeKarBaseDefine.ShiftCode = Convert.ToInt32(cmbShift.SelectedValue);
            TarrfiHokmeKarBaseDefine.DatePeriod = Convert.ToInt32(txtDatePeriod.Text);

            if (Code > 0)
                return TarrfiHokmeKarBaseDefine.Update(true);
            else
                return TarrfiHokmeKarBaseDefine.Insert(true) > 0 ? true : false;
        }

        public bool Save(DateTime StartDate, DateTime EndDate)
        {
            BusManagment.WorkOrder.JTarrfiHokmeKarBaseDefine TarrfiHokmeKarBaseDefine = new BusManagment.WorkOrder.JTarrfiHokmeKarBaseDefine();
            TarrfiHokmeKarBaseDefine.Code = Code;
            TarrfiHokmeKarBaseDefine.StartDate = StartDate;
            TarrfiHokmeKarBaseDefine.EndDate = EndDate;
            TarrfiHokmeKarBaseDefine.ZoneCode = Convert.ToInt32(cmbZone.SelectedValue);
            TarrfiHokmeKarBaseDefine.LineCode = Convert.ToInt32(cmbLine.SelectedValue);
            TarrfiHokmeKarBaseDefine.Seri = Convert.ToInt32(cmbSeri.SelectedValue);
            TarrfiHokmeKarBaseDefine.ShiftCode = Convert.ToInt32(cmbShift.SelectedValue);
            TarrfiHokmeKarBaseDefine.DatePeriod = Convert.ToInt32(GetAllDateBetweenToDatesCount(StartDate, EndDate));

            if (Code > 0)
                return TarrfiHokmeKarBaseDefine.Update(true);
            else
                return TarrfiHokmeKarBaseDefine.Insert(true) > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDatePeriod.Text != null & txtDatePeriod.Text != "")
            {
                int DatePI = 0;
                if (int.TryParse(txtDatePeriod.Text, out DatePI))
                {
                    if (DatePI == 0)
                    {
                        if (Save())
                        {
                            WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت ثبت شد');", "OKDialog");
                            WebClassLibrary.JWebManager.CloseAndRefresh();
                        }
                        else
                        {
                            WebClassLibrary.JWebManager.RunClientScript("alert('خطا در ثبت اطلاعات');", "OKDialog");
                        }
                    }
                    else
                    {
                        var dates = GetAllDateBetweenToDates(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                        int NextIndex = 0;
                        int FlagInsert = 0;
                        for (int i = 0; i < dates.Count; i = i + DatePI)
                        {
                            if (FlagInsert == 1)
                            {
                                FlagInsert = 0;
                                continue;
                            }
                            NextIndex = i + (DatePI - 1);
                            if (NextIndex > dates.Count - 1)
                                NextIndex = dates.Count - 1;
                            Save(dates[i], dates[NextIndex]);
                            FlagInsert = 1;
                        }
                        WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت ثبت شد');", "OKDialog");
                        WebClassLibrary.JWebManager.CloseAndRefresh();
                    }
                }
            }
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

        public int GetAllDateBetweenToDatesCount(DateTime start, DateTime end)
        {
            var dates = new List<DateTime>();

            for (var dt = start; dt <= end; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }
            return dates.Count;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BusManagment.WorkOrder.JTarrfiHokmeKarBaseDefine TarrfiHokmeKarBaseDefine = new BusManagment.WorkOrder.JTarrfiHokmeKarBaseDefine();
            TarrfiHokmeKarBaseDefine.Code = Code;
            if (TarrfiHokmeKarBaseDefine.Delete(true))
                WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت حذف شد');", "OKDialog");
        }
    }
}