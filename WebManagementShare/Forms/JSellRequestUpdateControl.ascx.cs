using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebManagementShare.Forms
{
    public partial class JSellRequestUpdateControl : System.Web.UI.UserControl
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
                txtSharesCount.Text = SellRequest.ShareCount.ToString();
            }
        }

        public bool Save()
        {
            ManagementShares.TransferRequest.JRequestSell SellRequest = new ManagementShares.TransferRequest.JRequestSell();
            SellRequest.Code = Code;
            SellRequest.GetData(Code);
            SellRequest.PCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            SellRequest.RequestDate = DateTime.Now;
            SellRequest.ShareCount = Convert.ToInt32(txtSharesCount.Text);
            SellRequest.Status = 0;
            ClassLibrary.JDataBase JDB = new ClassLibrary.JDataBase();
            if (Code > 0)
                return SellRequest.Update(JDB);
            else
                return SellRequest.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}