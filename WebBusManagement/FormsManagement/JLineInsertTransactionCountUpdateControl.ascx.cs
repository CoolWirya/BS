using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JLineInsertTransactionCountUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            BusManagment.Line.JLineDailyTransactionCount LineDailyTransactionCount = new BusManagment.Line.JLineDailyTransactionCount();
            LineDailyTransactionCount.GetData(Code.ToString());
            txtTransactionCount.Text = LineDailyTransactionCount.TransactionCount.ToString();
            BusManagment.Line.JLine Line = new BusManagment.Line.JLine();
            Line.GetData(Code);
            txtLine.Text = Line.LineNumber.ToString();
        }

        public bool Save()
        {
            BusManagment.Line.JLineDailyTransactionCount LineDailyTransactionCount = new BusManagment.Line.JLineDailyTransactionCount();
            LineDailyTransactionCount.Code = Code;
            LineDailyTransactionCount.TransactionCount = Convert.ToInt32(txtTransactionCount.Text);
            LineDailyTransactionCount.LineCode = Code;
            if (BusManagment.Line.JLineDailyTransactionCounts.HasLineCode(Code.ToString()))
                return LineDailyTransactionCount.Update(true);
            else
                return LineDailyTransactionCount.Insert(true) > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('ثبت با موفقیت انجام شد');", true);
                WebClassLibrary.JWebManager.CloseAndRefresh();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('خطا در ثبت اطلاعات');", true);
            }
        }
    }
}