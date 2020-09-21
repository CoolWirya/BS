using BusManagment.Fleet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JFleetUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            LoadFleet();
            _SetForm();
        }

        public void LoadFleet()
        {
            DataTable DtFleet = new DataTable();
            DtFleet = (new BusManagment.Fleet.JFleetTypes()).GetList();
            cmbFleetType.DataSource = DtFleet;
            cmbFleetType.DataTextField = "Name";
            cmbFleetType.DataValueField = "Code";
            cmbFleetType.DataBind();
        }

        public void _SetForm()
        {
            JFleetTypes types = new JFleetTypes();
            //types.

            if (Code > 0)
            {
                BusManagment.Fleet.JFleet fleet = new BusManagment.Fleet.JFleet();
                fleet.GetData(Code);
                txtName.Text = fleet.Name;
                cmbFleetType.SelectedValue = fleet.FleetType.ToString();
                ((WebControllers.MainControls.Date.JDateControl)JDateControl_A).SetDate(fleet.StartDate);
                ((WebControllers.MainControls.Date.JDateControl)JDateControl_B).SetDate(fleet.EndDate);
            }
        }

        public bool Save()
        {
            BusManagment.Fleet.JFleet fleet = new BusManagment.Fleet.JFleet();
            fleet.Code = Code;
            fleet.Name = txtName.Text;
            fleet.FleetType = Convert.ToInt32(cmbFleetType.SelectedValue);
            fleet.StartDate = ((WebControllers.MainControls.Date.JDateControl)JDateControl_A).GetDate();
            fleet.EndDate = ((WebControllers.MainControls.Date.JDateControl)JDateControl_B).GetDate();
            if (Code > 0)
                return fleet.Update(true);
            else
                return fleet.Insert(true) > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}