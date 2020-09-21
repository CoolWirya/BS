using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBaseDefine.Forms
{
    public partial class JBankAccountUpdateControl : System.Web.UI.UserControl
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
                Finance.JBankAccount BankAc = new Finance.JBankAccount();
                BankAc.GetDataWithCode(Code);
                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlOwner).PersonCode = BankAc.PCode;
                txtAccountNo.Text = BankAc.AccountNo;
            }
        }

        public bool Save()
        {
            Finance.JBankAccount BankAc = new Finance.JBankAccount();
            BankAc.Code = Code;
            BankAc.PCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlOwner).PersonCode;
            BankAc.AccountNo = txtAccountNo.Text;
            if (Code > 0)
                return BankAc.Update();
            else
                return BankAc.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}