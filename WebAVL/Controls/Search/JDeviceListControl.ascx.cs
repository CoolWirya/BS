using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Controls.Search
{
    public partial class JDeviceListControl : System.Web.UI.UserControl
    {
        public bool ShowSelectionButton
        {
            get
            {
                return btnSelect.Visible;
            }
            set
            {
                btnSelect.Visible = value;
            }
        }
        public JDeviceList DeviceList;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "جست و جوی دستگاه";

            bindData();

            DeviceList = new JDeviceList(WebClassLibrary.JWebManager.GetSUID());
            grdDevices.AllowMultiRowSelection = bool.Parse(DeviceList.MultipleSelection);
            lblmessage.Visible = grdDevices.AllowMultiRowSelection;
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindData();
        }

        private void bindData()
        {
            string adminOrMarketer = "";
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin || ClassLibrary.JPermission.CheckPermission("WebAVL.JWebAVL._isMarketer"))
                adminOrMarketer = " OR 1=1 ";
            grdDevices.DataSource = WebClassLibrary.JWebDataBase.GetDataTable(
              string.Format(@"Select Code, Name,IMEI from AVLDevice Where Name like N'%{0}%' AND Code in(SELECT jd.childDeviceCode FROM [AVLDB].[dbo].[AVLDevice] d right join
                            AVLJoinDevice jd on d.Code = jd.parentDeviceCode where d.personCode = {2} {1})  order by Name",
                txtSearch.Text.Replace("'", "''"), adminOrMarketer, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode.ToString()),
              true);
            grdDevices.Rebind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string index = Request.Form["radGridClickedRowIndex"].ToString();
            if (index == "") return;
            WebClassLibrary.SessionManager.Current.Session.Add("deviceSearchListSelectedItems", grdDevices.SelectedItems);
            
            int deviceCode = Convert.ToInt32(grdDevices.Items[Convert.ToInt32(index)]["Code"].Text);
            string deviceName = grdDevices.Items[Convert.ToInt32(index)]["Name"].Text;
            string deviceIMEI = grdDevices.Items[Convert.ToInt32(index)]["IMEI"].Text;
            if (DeviceList.DeviceCode != null && DeviceList.DeviceName != null)
                WebClassLibrary.JWebManager.RunClientScript(new List<string>()
                {
                    "{Parent}.document.getElementById('" + DeviceList.DeviceCode + "').value = '" + deviceCode + "';",
                    "{Parent}.document.getElementById('" + DeviceList.DeviceName + "').value = '" + deviceName + "';",
                    "{Parent}.document.getElementById('" + DeviceList.DeviceImei + "').value = '" + deviceIMEI + "';",
                //   "{Parent}.window.location.reload(true);",
                "{Parent}.window.location = {Parent}.window.location.href;",
                    "{CloseWindow};"
                }, "SendPersonInfo", true);
            //WebClassLibrary.JWebManager.RunClientScript(new List<string>()
            //	{
            //		//"{Parent}.document.getElementById('" + ControlToSet + "').value = '" + personCode + "';",
            //		"parent.$(\"#"+ControlToSet+"\".val('"+personCode+"');",
            //		"{CloseWindow};"
            //	}, "SendPersonInfo", true);
        }
    }
}