using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroidWebManagement.Forms
{
    public partial class JBuyRequestChangeStatusUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                ManagementShares.TransferRequest.JRequestBuy BuyRequest = new ManagementShares.TransferRequest.JRequestBuy();
                BuyRequest.GetData(Code);
                ClassLibrary.JPerson Perosn = new ClassLibrary.JPerson();
                Perosn.getData(BuyRequest.PCode);
                txtPersonName.Text = Perosn.Name + " " + Perosn.Fam;
                txtRequestDate.Text = BuyRequest.RequestDate.ToShortDateString();
                txtRequestType.Text = "درخواست خرید";
                txtSharesCount.Text = BuyRequest.ShareCount.ToString();
                cmbStatus.SelectedValue = BuyRequest.Status.ToString();
            }
        }

        public bool Save()
        {
            ManagementShares.TransferRequest.JRequestBuy BuyRequest = new ManagementShares.TransferRequest.JRequestBuy();
            BuyRequest.GetData(Code);
            BuyRequest.Status = Convert.ToInt32(cmbStatus.SelectedValue);
            ClassLibrary.JDataBase JDB = new ClassLibrary.JDataBase();
            bool Res = BuyRequest.Update(JDB);
            JDB.Dispose();
            return Res;
        }

        protected void btnSave1_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}