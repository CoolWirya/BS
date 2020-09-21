using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace WebBusManagement.FormsManagement
{
    public partial class JTariffUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            LoadLine();
            LoadBus();
            LoadShift();
            _SetForm();
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

        public void LoadShift()
        {
            DataTable DtShift = new DataTable();
            DtShift = BusManagment.WorkOrder.JShifts.GetDataTable(0);
            cmbShift.DataSource = DtShift;
            cmbShift.DataTextField = "Title";
            cmbShift.DataValueField = "Code";
            cmbShift.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.WorkOrder.JTariff Tariff = new BusManagment.WorkOrder.JTariff();
                Tariff.GetData(Code);
                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = Tariff.DriverCode;
                cmbLine.SelectedValue = Tariff.LineCode.ToString();
                cmbBus.SelectedValue = Tariff.BusCode.ToString();
                ((WebControllers.MainControls.Date.JDateControl)txtStartDate).SetDate(Tariff.StartDate);
                ((WebControllers.MainControls.Date.JDateControl)txtFinishDate).SetDate(Tariff.EndDate);
                cmbShift.SelectedValue = Tariff.ShiftCode.ToString();
            }
        }

        public bool Save()
        {
            BusManagment.WorkOrder.JTariff Tariff = new BusManagment.WorkOrder.JTariff();
            Tariff.Code = Code;
            Tariff.DriverCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;
            Tariff.LineCode = Convert.ToInt32(cmbLine.SelectedValue);
            Tariff.BusCode = Convert.ToInt32(cmbBus.SelectedValue);
            Tariff.StartDate = ((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetDate();
            Tariff.EndDate = ((WebControllers.MainControls.Date.JDateControl)txtFinishDate).GetDate();
            Tariff.ShiftCode = Convert.ToInt32(cmbShift.SelectedValue);
            if (Code > 0)
                return Tariff.Update(true);
            else
                return Tariff.Insert(true) > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetFarsiDate().ToString().Length == 10)
            {
                if (((WebControllers.MainControls.Date.JDateControl)txtFinishDate).GetFarsiDate().ToString().Length == 10)
                {
                    Save();
                    WebClassLibrary.JWebManager.CloseAndRefresh();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('لطفا تاریخ پایان را انتخاب کنید');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('لطفا تاریخ شروع را انتخاب کنید');", true);
            }
        }

    }
}