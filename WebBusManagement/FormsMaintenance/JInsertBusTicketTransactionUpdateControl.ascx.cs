using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JInsertBusTicketTransactionUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtReportDate).SetDate(DateTime.Now);
                LoadBus();
                _SetForm();
            }
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = dt;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.JBusTransactionPrint TransactionPrint = new BusManagment.JBusTransactionPrint();
                TransactionPrint.GetData(Code);
                cmbBus.SelectedValue = TransactionPrint.BusCode.ToString();
                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode = TransactionPrint.PersonCode;
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(TransactionPrint.FromDate);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(TransactionPrint.ToDate);
                ((WebControllers.MainControls.Date.JDateControl)txtReportDate).SetDate(TransactionPrint.ReportDate);
                txtTransactionCount.Text = TransactionPrint.TransactionCount.ToString();
                txtIncome.Text = TransactionPrint.Income.ToString();
            }
        }

        public bool Save()
        {
            BusManagment.JBusTransactionPrint TransactionPrint = new BusManagment.JBusTransactionPrint();
            TransactionPrint.Code = Code;
            TransactionPrint.BusCode = Convert.ToInt32(cmbBus.SelectedValue);
            TransactionPrint.PersonCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode;
            TransactionPrint.FromDate = ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate();
            TransactionPrint.ToDate = ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate();
            TransactionPrint.ReportDate = ((WebControllers.MainControls.Date.JDateControl)txtReportDate).GetDate();
            TransactionPrint.TransactionCount = Convert.ToInt32(txtTransactionCount.Text);
            TransactionPrint.Income = Convert.ToInt32(txtIncome.Text);
            if (Code > 0)
                return TransactionPrint.Update();
            else
                return TransactionPrint.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}