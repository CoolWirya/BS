using BusManagment.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JZoneUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtStartDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtFinishDate).SetDate(DateTime.Now);
            }
        }

        public void _SetForm()
        {
            //JZone types = new JFleetTypes();
            //types.
            if (Code > 0)
            {
                BusManagment.Zone.JZone zone = new BusManagment.Zone.JZone();
                zone.GetData(Code);
                txtName.Text = zone.Name;
                txtAddress.Text = zone.Address;
                txtTel.Text = zone.Tel;
                txtDescription.Text = zone.Description;
                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = zone.ChiefPersonCode;
                ((WebControllers.MainControls.Date.JDateControl)txtStartDate).SetDate(zone.StartDate);
                ((WebControllers.MainControls.Date.JDateControl)txtFinishDate).SetDate(zone.FinishDate);
            }
        }

        public bool Save()
        {
            BusManagment.Zone.JZone zone = new BusManagment.Zone.JZone();
            zone.Code = Code;
            zone.Name = txtName.Text;
            zone.Address = txtAddress.Text;
            zone.Tel = txtTel.Text;
            zone.Description = txtDescription.Text;
            zone.ChiefPersonCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;
            zone.StartDate = ((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetDate();
            zone.FinishDate = ((WebControllers.MainControls.Date.JDateControl)txtFinishDate).GetDate();
            if (Code > 0)
                return zone.Update(true);
            else
                return zone.Insert(true) > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BusManagment.Zone.JZone zone = new BusManagment.Zone.JZone();
            zone.Code = Code;
            if (zone.Delete(true))
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

    }
}