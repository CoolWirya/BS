using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusInstallAndUinstallDeviceUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(DateTime.Now);
                // Custom List Search
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code = 0;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).SQL = "SELECT Code,CASE [TYPE] WHEN 1 THEN N'کنسول' ELSE N'کارتخوان' END AS DeviceType,CASE [TYPE] WHEN 1 THEN IMEI ELSE ID END AS Title FROM [dbo].[AUTDevice]";
                LoadBus();
                LoadBusFailureType();
                _SetForm();
            }
        }

        public void LoadBusFailureType()
        {
            DataTable DtBusFailureType = new DataTable();
            DtBusFailureType = (new BusManagment.JBusFailureTypes()).GetList();
            cmbBusFailureType.DataSource = DtBusFailureType;
            cmbBusFailureType.DataTextField = "Name";
            cmbBusFailureType.DataValueField = "Code";
            cmbBusFailureType.DataBind();
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = dt;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.JBusInstallAndUnistallDevise BusInstallDevice = new BusManagment.JBusInstallAndUnistallDevise();
                BusInstallDevice.GetData(Code);
                ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(BusInstallDevice.EventDate);
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code = BusInstallDevice.DeviceCode;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).SQL = "SELECT Code,CASE [TYPE] WHEN 1 THEN N'کنسول' ELSE N'کارتخوان' END AS DeviceType,CASE [TYPE] WHEN 1 THEN IMEI ELSE ID END AS Title FROM [dbo].[AUTDevice]";

                cmbBus.SelectedValue = BusInstallDevice.BusCode.ToString();
                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode = BusInstallDevice.Installer;
                cmbType.SelectedValue = Convert.ToInt32(BusInstallDevice.Type).ToString();
                txtDiscription.Text = BusInstallDevice.Description;

                cmbBusFailureType.SelectedValue = BusInstallDevice.BusFailureCode.ToString();
            }
        }

        public bool Save()
        {
            BusManagment.JBusInstallAndUnistallDevise BusInstallDevice = new BusManagment.JBusInstallAndUnistallDevise();
            BusInstallDevice.Code = Code;
            BusInstallDevice.EventDate = ((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate();
            BusInstallDevice.DeviceCode = ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code;
            BusInstallDevice.BusCode = Convert.ToInt32(cmbBus.SelectedValue);
            BusInstallDevice.Installer = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode;
            BusInstallDevice.Type = Convert.ToBoolean(Convert.ToInt32(cmbType.SelectedValue));
            BusInstallDevice.BusFailureCode = Convert.ToInt32(cmbBusFailureType.SelectedValue);
            BusInstallDevice.Description = txtDiscription.Text;
            if (Code > 0)
                return BusInstallDevice.Update();
            else
                return BusInstallDevice.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            { 
                WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت ثبت شد');", "OKDialog");
                txtDiscription.Text = "";
            }
                //WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}