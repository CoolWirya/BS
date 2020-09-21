using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JNotPayingBusBlackListUpdatecontrol : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (IsPostBack)
            {
            }
            //btnSave_Click(null, null);
            else
            {
                LoadForm();
            }
        }

        public void LoadForm()
        {

            if (Code == 0)
            {
                DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
                cmbBus.DataSource = dt;
                cmbBus.DataTextField = "BusNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
            else
            {
                BusManagment.NotPayingBus.JNotPayingBus NotPayingBus = new BusManagment.NotPayingBus.JNotPayingBus(Code);
                BusManagment.Bus.JBus Bus = new BusManagment.Bus.JBus();
                Bus.GetData(NotPayingBus.BusCode);
                cmbBus.Items.Add(new Telerik.Web.UI.RadComboBoxItem(Bus.BUSNumber.ToString(), Bus.Code.ToString()));
                cmbBus.DataBind();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(NotPayingBus.FromDate);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(NotPayingBus.ToDate);
            }
        }

        bool Save()
        {
            BusManagment.NotPayingBus.JNotPayingBus NotPayingBus = new BusManagment.NotPayingBus.JNotPayingBus();
            NotPayingBus.BusCode = Convert.ToInt32(cmbBus.SelectedValue);
            NotPayingBus.FromDate = ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate();
            NotPayingBus.ToDate = ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate();
            if (NotPayingBus.FindDuplicate() > 0) return false;
                return NotPayingBus.Insert()>0?true:false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate() <= DateTime.MinValue
                || ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate() <= DateTime.MinValue)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفاً تاریخ شروع و پایان را انتخاب کنید.');", "ConfirmDialog");
                return;
            }
            if(Code == 0)
            {
                if (Save())
                    WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('این اتوبوس قبلاً در لیست سیاه عدم پرداخت اتوبوس ثبت شده است');", "ConfirmDialog");
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BusManagment.NotPayingBus.JNotPayingBus NotPayingBus = new BusManagment.NotPayingBus.JNotPayingBus(Code);
            if (NotPayingBus.Delete())
                WebClassLibrary.JWebManager.RunClientScript("alert('حذف با موفقیت انجام شد');", "ConfirmDialog");
        }
    }
}