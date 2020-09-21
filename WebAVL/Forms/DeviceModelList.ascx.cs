using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class DeviceModelList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "مدل دستگاه ارسال کننده اطلاعات";
            grdDeviceModel.DataSource = WebClassLibrary.JWebDataBase.GetDataTable("Select Code,Year, Company,Model from AVLDeviceModel Where Company like N'%" + txtCompany.Text.Replace("'", "''") + "%' AND Model like N'%" + txtModel.Text.Replace("'", "''") + "%'  AND (SELECT CAST(Year AS NVARCHAR(MAX))) like '%" + txtYear.Text.Replace("'", "''") + "%'"
                , true);
            grdDeviceModel.Rebind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            grdDeviceModel.DataSource = WebClassLibrary.JWebDataBase.GetDataTable("Select Code,Year, Company,Model from AVLDeviceModel Where Company like N'%" + txtCompany.Text.Replace("'", "''") + "%' AND Model like N'%" + txtModel.Text.Replace("'", "''") + "%'  AND (SELECT CAST(Year AS NVARCHAR(MAX))) like '%" + txtYear.Text.Replace("'", "''")+"%'"
                , true);
            grdDeviceModel.Rebind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
           AVL.Device.DeviceModelSeason devicemodel = new  AVL.Device.DeviceModelSeason(WebClassLibrary.JWebManager.GetSUID());
        
            string index = Request.Form["radGridClickedRowIndex"].ToString();
            if (index == "") return;

            int DeviceModelCode = Convert.ToInt32(grdDeviceModel.Items[Convert.ToInt32(index)]["Code"].Text);
            string DeviceModeilCompany = grdDeviceModel.Items[Convert.ToInt32(index)]["Company"].Text;
            int DeviceModelYear = Convert.ToInt32(grdDeviceModel.Items[Convert.ToInt32(index)]["Year"].Text);
            string DeviceModelModel = grdDeviceModel.Items[Convert.ToInt32(index)]["Model"].Text;

            if (devicemodel.DeviceModelCompany != null && devicemodel.DeviceModelModel != null && devicemodel.DeviceModelYear !=null)
                WebClassLibrary.JWebManager.RunClientScript(new List<string>()
                {
                    "{Parent}.document.getElementById('" + devicemodel.DeviceModelCompany + "').value = '" + DeviceModeilCompany + "';",
                    "{Parent}.document.getElementById('" + devicemodel.DeviceModelModel + "').value = '" + DeviceModelModel + "';",
                    "{Parent}.document.getElementById('" + devicemodel.DeviceModelYear + "').value = '" + DeviceModelYear + "';",
                    "{Parent}.document.getElementById('" + devicemodel.DeviceModelCode + "').value = '" + DeviceModelCode + "';",
                    "{CloseWindow};"
                }, "SendDeviceModelInfo", true);
        }
    }
}