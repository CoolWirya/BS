using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebManagementShare.Forms
{
    public partial class JSharePCodeUpdateCotrol : System.Web.UI.UserControl
    {
        int CompanyCode = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            int SelectCode = 0;
            int.TryParse(Request["CompanyCode"], out CompanyCode);
            int.TryParse(Request["Code"], out SelectCode);
            txtOldSharepCode.Text = "0";
            ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = SelectCode;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Change())
                WebClassLibrary.JWebManager.RunClientScript("alert('تغییرات با موفقیت ذخیره شد');", "ConfirmDialog");
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در ذخیره اطلاعات');", "ConfirmDialog");
        }

        bool Change()
        {
            try
            {
                ManagementShares.ShareCompany.JSharepCode S = new ManagementShares.ShareCompany.JSharepCode();
                if (S.find(CompanyCode, ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode))
                {
                    return S.Update(CompanyCode, ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, Int64.Parse(txtOldSharepCode.Text), Int64.Parse(txtNewSharepCode.Text));
                }
                else
                {
                    return S.Insert(CompanyCode, ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, Int64.Parse(txtNewSharepCode.Text)) > 0;
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);

            }
            return false;

        }
    }
}