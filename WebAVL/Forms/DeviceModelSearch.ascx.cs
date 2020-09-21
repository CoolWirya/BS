using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class DeviceModelSearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            btnSearch.OnClientClicked = "CallShowMenu";
        }

        public string Code
        {
            get { return txtCode.Text; }
            set
            {
                AVL.Device.JDeviceModel dmodel = new AVL.Device.JDeviceModel();
                dmodel.GetData(value);

                txtCode.Text = dmodel.Code.ToString();
                txtCompany.Text = dmodel.Company;
                txtModel.Text = dmodel.Model;
                txtYear.Text = dmodel.Year.ToString();
            }
        }

    }
}