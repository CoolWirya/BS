using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class addDeviceToGroup : System.Web.UI.UserControl
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
            string imei = "";
            AVL.RegisterDevice.JRegisterDevice senderDevice = new AVL.RegisterDevice.JRegisterDevice();
            senderDevice.GetData(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
            imei = (searchDevice.Visible) ? ((WebAVL.Controls.Search.JSearchDevice)searchDevice).IMEI : senderDevice.IMEI.ToString();
            if (string.IsNullOrEmpty(imei))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا یک دستگاه را انتخاب کنید.');", "ConfirmDialog");
                return;
            }
            txtMessage.Text= AVL.JoinDevice.JJoinDevice.GenerateJoinKey(imei);
           // WebClassLibrary.JWebManager.RunClientScript("sendmsg('شما به گروه '+senderDevice.Name+' دعوت شدید. در صورت تمایل کد را در قسمت چت وارد کنید. " + txtMessage.Text+","+senderDevice.IMEI+"', '0', '1');", "ConfirmDialog");
        }
    }
}