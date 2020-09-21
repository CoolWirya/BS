using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JCardBlackListUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32.TryParse(Request["Code"], out Code);

            if (!IsPostBack)
                LoadWord();
        }

        void LoadWord()
        {
            if (Code > 0)
            {
                BusManagment.CardBlackList.JCardBlackList Card = new BusManagment.CardBlackList.JCardBlackList(Code);
                ntbRfidNumber.Text = Card.RfidNumber.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Code == 0)
            {
                BusManagment.CardBlackList.JCardBlackList Card = new BusManagment.CardBlackList.JCardBlackList();
                try 
                {
                    Card.RfidNumber = Int64.Parse(ntbRfidNumber.Text);
                }
                catch
                {
                    return;
                }
                if (Card.FindDuplicate() > 0)
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('شماره آر اف آی دی تکراری است');", "ConfirmDialog");
                    return;
                }
                if (Card.Insert() > 0)
                    WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Delete())
                WebClassLibrary.JWebManager.RunClientScript("alert('حذف با موفقیت انجام شد');", "ConfirmDialog");
        }

        bool Delete()
        {
            if (Code > 0)
            {
                BusManagment.CardBlackList.JCardBlackList CardBlackList = new BusManagment.CardBlackList.JCardBlackList(Code);
                if (CardBlackList.Delete())
                    return true;
                else
                    return false;
            }
            else  //Code == 0
                return false;
        }
    }
}