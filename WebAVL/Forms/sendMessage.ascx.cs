using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class sendMessage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin && !ClassLibrary.JPermission.CheckPermission("WebAVL.JWebAVL._isMarketer"))
                    h3.Visible = searchDevice.Visible = false;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            AVL.RegisterDevice.JRegisterDevice senderDevice = new AVL.RegisterDevice.JRegisterDevice();
            if (searchDevice.Visible)
                senderDevice.GetData(((WebAVL.Controls.Search.JSearchDevice)searchDevice).IMEI);
            else
                senderDevice.GetData((WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode));
            Chat.JChat C;
            System.Data.DataTable dt = null;
            //if (dsDevices.Device.Code== 0)
            //    dt = AVL.JoinDevice.JJoinDevices.GetAllData(senderDevice.Code);
            //else
            dt = AVL.JoinDevice.JJoinDevices.GetData(0, senderDevice.Code);
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                C = new Chat.JChat();
                C.message = txtMessage.Text;
                C.sender = senderDevice.IMEI.ToString();
                C.senderName = senderDevice.Name;
                C.receiver = new AVL.RegisterDevice.JRegisterDevice(int.Parse(dr["childDeviceCode"].ToString()), false).IMEI.ToString();
                C.registerDate = DateTime.Now;
                C.GroupID = senderDevice.Code;
                C.messageType = 1;
                C.Insert();
            }
        }
    }
}