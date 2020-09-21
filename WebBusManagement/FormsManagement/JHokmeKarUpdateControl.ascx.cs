using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JHokmeKarUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            LoadLine();
            LoadBus();
            LoadZones();
            LoadNahvayeHamkari();
            LoadtxtDriverWorkStatus();
            LoadtxtOnvaneShoghli();
            LoadtxtFaaliyat();
            
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtStartDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtFaliyatFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtFaliyatToDate).SetDate(DateTime.Now);

                ((WebControllers.MainControls.JCustomListSelectorControl)JSearchPersonControl).Code = 0;
                ((WebControllers.MainControls.JCustomListSelectorControl)JSearchPersonControl).SQL = "select cap.Code,cast(isnull(EmpEmployee.PersonNumber,0) as nvarchar)+' - '+cap.Name Title from clsAllPerson cap left join EmpEmployee on cap.Code = EmpEmployee.pCode";

            }

            _SetForm();
        }


        public void LoadtxtFaaliyat()
        {
            DataTable DttxtFaaliyat = new DataTable();
            DttxtFaaliyat = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name from subdefine where bcode = 9101054");
            txtFaaliyat.DataSource = DttxtFaaliyat;
            txtFaaliyat.DataTextField = "Name";
            txtFaaliyat.DataValueField = "Code";
            txtFaaliyat.DataBind();
        }
        public void LoadtxtOnvaneShoghli()
        {
            DataTable DttxtOnvaneShoghli = new DataTable();
            DttxtOnvaneShoghli = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name from subdefine where bcode = 9101055");
            txtOnvaneShoghli.DataSource = DttxtOnvaneShoghli;
            txtOnvaneShoghli.DataTextField = "Name";
            txtOnvaneShoghli.DataValueField = "Code";
            txtOnvaneShoghli.DataBind();
        }
        public void LoadtxtDriverWorkStatus()
        {
            DataTable DttxtDriverWorkStatus = new DataTable();
            DttxtDriverWorkStatus = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name from subdefine where bcode = 9101053");
            txtDriverWorkStatus.DataSource = DttxtDriverWorkStatus;
            txtDriverWorkStatus.DataTextField = "Name";
            txtDriverWorkStatus.DataValueField = "Code";
            txtDriverWorkStatus.DataBind();
        }

        public void LoadNahvayeHamkari()
        {
            DataTable DttxtDriverWorkType = new DataTable();
            DttxtDriverWorkType = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name from subdefine where bcode = 9101056");
            txtDriverWorkType.DataSource = DttxtDriverWorkType;
            txtDriverWorkType.DataTextField = "Name";
            txtDriverWorkType.DataValueField = "Code";
            txtDriverWorkType.DataBind();
        }

        public void LoadZones()
        {
            DataTable dt = BusManagment.Zone.JZones.GetDataTable(0);
            //var p = (from v in dt.AsEnumerable()
            //         select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            //p.Insert(0, new { Code = 0, Name = "همه" });
            cmbZone.DataSource = dt;
            cmbZone.DataTextField = "Name";
            cmbZone.DataValueField = "Code";
            cmbZone.DataBind();
        }

        public void LoadLine()
        {
            DataTable DtLine = new DataTable();
            DtLine = BusManagment.Line.JLines.GetWebDataTable(0);
            cmbLine.DataSource = DtLine;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        public void LoadBus()
        {
            DataTable DtBus = new DataTable();
            DtBus = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = DtBus;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.WorkOrder.JHokmeKar HokmeKar = new BusManagment.WorkOrder.JHokmeKar();
                HokmeKar.GetData(Code);
                ((WebControllers.MainControls.JCustomListSelectorControl)JSearchPersonControl).Code = HokmeKar.DriverPCode;
                ((WebControllers.MainControls.JCustomListSelectorControl)JSearchPersonControl).SQL = "select cap.Code,cast(isnull(EmpEmployee.PersonNumber,0) as nvarchar)+' - '+cap.Name Title from clsAllPerson cap left join EmpEmployee on cap.Code = EmpEmployee.pCode";
                //((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = HokmeKar.DriverPCode;
                cmbLine.SelectedValue = HokmeKar.LineCode.ToString();
                cmbBus.SelectedItem.Text = HokmeKar.BusNumber.ToString();
                txtNumOfService.Text = HokmeKar.NumOfService.ToString();
                int NumOfHolidayService = 0;
                Int32.TryParse(HokmeKar.NumOfHolidayService.ToString(), out NumOfHolidayService);
                txtNumOfHolidayService.Text = NumOfHolidayService.ToString();
                ((WebControllers.MainControls.Date.JDateControl)txtStartDate).SetDate(HokmeKar.Date);
                txtDriverWorkStatus.SelectedValue = HokmeKar.VaziayeHamkariCode.ToString();
                txtDriverWorkType.SelectedValue = HokmeKar.NahveyeHamkariCode.ToString();
                txtFaaliyat.SelectedValue = HokmeKar.FaliyatCode.ToString();
                txtOnvaneShoghli.SelectedValue = HokmeKar.OnvaneShoghliCode.ToString();
                cmbZone.SelectedValue = HokmeKar.ZoneCode.ToString();
                txtSeri.Text = HokmeKar.Seri.ToString();
                ((WebControllers.MainControls.Date.JDateControl)txtFaliyatFromDate).SetDate(HokmeKar.StartDate);
                ((WebControllers.MainControls.Date.JDateControl)txtFaliyatToDate).SetDate(HokmeKar.EndDate);
                cmbStatus.SelectedValue = HokmeKar.Status.ToString();
            }
        }

        public bool Save()
        {
            BusManagment.WorkOrder.JHokmeKar HokmeKar = new BusManagment.WorkOrder.JHokmeKar();
            HokmeKar.Code = Code;
            //HokmeKar.DriverPCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;
            HokmeKar.DriverPCode = ((WebControllers.MainControls.JCustomListSelectorControl)JSearchPersonControl).Code;
            HokmeKar.LineCode = Convert.ToInt32(cmbLine.SelectedValue);
            HokmeKar.BusNumber = Convert.ToInt32(cmbBus.SelectedItem.Text);
            HokmeKar.NumOfService = Convert.ToInt32(txtNumOfService.Text);
            int NumOfHolidayService = 0;
            Int32.TryParse(txtNumOfHolidayService.Text, out NumOfHolidayService);
            HokmeKar.NumOfHolidayService = NumOfHolidayService;
            HokmeKar.Date = ((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetDate();
            HokmeKar.NahveyeHamkariCode = Convert.ToInt32(txtDriverWorkType.SelectedValue);
            HokmeKar.VaziayeHamkariCode = Convert.ToInt32(txtDriverWorkStatus.SelectedValue);
            HokmeKar.FaliyatCode = Convert.ToInt32(txtFaaliyat.SelectedValue);
            HokmeKar.OnvaneShoghliCode = Convert.ToInt32(txtOnvaneShoghli.SelectedValue);
            HokmeKar.ZoneCode = Convert.ToInt32(cmbZone.SelectedValue);
            HokmeKar.Seri = Convert.ToInt32(txtSeri.Text);
            HokmeKar.StartDate = ((WebControllers.MainControls.Date.JDateControl)txtFaliyatFromDate).GetDate();
            HokmeKar.EndDate = ((WebControllers.MainControls.Date.JDateControl)txtFaliyatToDate).GetDate();
            HokmeKar.Status = Convert.ToInt32(cmbStatus.SelectedValue);
            if (Code > 0)
                return HokmeKar.Update(true);
            else
                return HokmeKar.Insert(true) > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetFarsiDate().ToString().Length == 10)
            {
                if (BusManagment.WorkOrder.JHokmeKar.FindDuplicate(Code, Convert.ToInt32(cmbBus.SelectedItem.Text), Convert.ToInt32(txtSeri.Text),
                    ((WebControllers.MainControls.Date.JDateControl)txtFaliyatFromDate).GetDate()))
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('حکم کار تکراری است');", true);
                    return;
                }
                Save();
                WebClassLibrary.JWebManager.RunClientScript("alert('حکم مورد نظر با موفقیت ثبت شد');", "ConfirmDialog");
                WebClassLibrary.JWebManager.CloseAndRefresh();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('لطفا تاریخ را انتخاب کنید');", true);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BusManagment.WorkOrder.JHokmeKar HokmeKar = new BusManagment.WorkOrder.JHokmeKar();
            HokmeKar.Code = Code;
            if(HokmeKar.Delete())
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('حذف حکم مورد نظر با موفقیت انجام شد');", "ConfirmDialog");
                WebClassLibrary.JWebManager.CloseAndRefresh();
            }
        }
    }
}