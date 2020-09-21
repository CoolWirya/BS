using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class JObjectListItemList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin)
                grdDeviceModel.DataSource = WebClassLibrary.JWebDataBase.GetDataTable("Select Code,Label from AVLObjectList Where Label like N'%" + txtLabel.Text.Replace("'", "''") + "%'", true);
            else
                grdDeviceModel.DataSource = WebClassLibrary.JWebDataBase.GetDataTable("Select Code,Label from AVLObjectList Where Label like N'%" + txtLabel.Text.Replace("'", "''") + "%' AND personCode=" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, true);
            grdDeviceModel.Rebind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            grdDeviceModel.DataSource = WebClassLibrary.JWebDataBase.GetDataTable("Select Code,Label from AVLObjectList Where Label like N'%" + txtLabel.Text.Replace("'", "''") + "%' AND personCode=" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, true);
            grdDeviceModel.Rebind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            AVL.RegisterDevice.JDeviceObjectSeason devicemodel = new AVL.RegisterDevice.JDeviceObjectSeason(WebClassLibrary.JWebManager.GetSUID());

            string index = Request.Form["radGridClickedRowIndex"].ToString();
            if (index == "") return;

            int code = Convert.ToInt32(grdDeviceModel.Items[Convert.ToInt32(index)]["Code"].Text);
            string label = grdDeviceModel.Items[Convert.ToInt32(index)]["Label"].Text;

            if (devicemodel.ObjectListCode != null && devicemodel.ObjectListLabel != null )
                WebClassLibrary.JWebManager.RunClientScript(new List<string>()
                {
                    "{Parent}.document.getElementById('" + devicemodel.ObjectListCode + "').value = '" + code + "';",
                    "{Parent}.document.getElementById('" + devicemodel.ObjectListLabel + "').value = '" + label + "';",
                    "{CloseWindow};"
                }, "SendDeviceModelInfo", true);
        }
    }
}