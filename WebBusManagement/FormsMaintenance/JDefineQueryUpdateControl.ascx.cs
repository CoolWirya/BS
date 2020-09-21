using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JDefineQueryUpdateControl : System.Web.UI.UserControl
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
                BusManagment.Query.JQuery Query = new BusManagment.Query.JQuery();
                Query.GetData(Code);
                txtName.Text = Query.Name;
                txtQuery.Text = Query.QueryText;
            }
        }

        public bool Save()
        {
            BusManagment.Query.JQuery Query = new BusManagment.Query.JQuery();
            Query.Code = Code;
            Query.Name = txtName.Text;
            Query.QueryText = txtQuery.Text;
            if (Code > 0)
                return Query.Update();
            else
            {
                if (Query.FindDuplicate() > 0) return false;
                else
                    return Query.Insert() > 0 ? true : false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا! کوئری دیگری با همین نام موجود است');", "ConfirmDialog");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BusManagment.Query.JQuery Query = new BusManagment.Query.JQuery();
            Query.Code = Code;
            if (Query.Delete())
                WebClassLibrary.JWebManager.RunClientScript("alert('کوئری با موفقیت حذف شد');", "ConfirmDialog");
        }
    }
}