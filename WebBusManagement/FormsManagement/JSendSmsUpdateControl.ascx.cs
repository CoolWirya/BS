using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JSendSmsUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            bool SMSRes = ClassLibrary.SMS.ClsMainSmsClass.SendSms(Db, txtMessageText.Text, txtReciverMobile.Text, "BusManagement", 0);
            if (SMSRes)
                WebClassLibrary.JWebManager.RunClientScript("alert('ارسال پیام کوتاه با موفقیت انجام شد');", "SendSMSDialog");
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('عملیات ارسال پیام کوتاه با مشکل مواجه شده است');", "SendSMSDialog");
        }
    }
}