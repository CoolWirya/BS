using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroidWebManagement.Forms
{
    public partial class JSellChangeStatusUpdateControl : System.Web.UI.UserControl
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
                ManagementShares.TransferRequest.JRequestSell SellRequest = new ManagementShares.TransferRequest.JRequestSell();
                SellRequest.GetData(Code);
                ClassLibrary.JPerson Perosn = new ClassLibrary.JPerson();
                Perosn.getData(SellRequest.PCode);
                txtPersonName.Text = Perosn.Name + " " + Perosn.Fam;
                txtRequestDate.Text = SellRequest.RequestDate.ToShortDateString();
                txtRequestType.Text = "درخواست فروش";
                txtSharesCount.Text = SellRequest.ShareCount.ToString();
                cmbStatus.SelectedValue = SellRequest.Status.ToString();
            }
        }

        public bool Save()
        {
            ManagementShares.TransferRequest.JRequestSell SellRequest = new ManagementShares.TransferRequest.JRequestSell();
            SellRequest.GetData(Code);
            SellRequest.Status = Convert.ToInt32(cmbStatus.SelectedValue);
            ClassLibrary.JDataBase JDB = new ClassLibrary.JDataBase();
            bool Res = SellRequest.Update(JDB);
            JDB.Dispose();
            return Res;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}