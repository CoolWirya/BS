using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class MainPage : System.Web.UI.UserControl
    {
        protected int deviceCode = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            AVL.RegisterDevice.JRegisterDevice device = new AVL.RegisterDevice.JRegisterDevice();
            device.GetData(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
            deviceCode = device.Code;
            
         

            Page.Title = "صفحه اصلی";
           // Accounting.Cash.JCash cash=new Accounting.Cash.JCash(0,WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
            //squarList.Text = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonName + "[اعتبار پنل شما " + ClassLibrary.JMoney.DecimalToMoney(Math.Round(cash.paid,0))+" ریال]";
        }
    }
}