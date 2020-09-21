using BusManagment.Bus;
using BusManagment.UnpaidBlackList;
using ClassLibrary;
using System;
using System.Data;
using System.Web.UI;
using Telerik.Web.UI;
using WebClassLibrary;
namespace WebBusManagement.FormsManagement
{
    public partial class JUnpaidBlackListReportControl : System.Web.UI.UserControl
    {
        private int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(base.Request["Code"], out this.Code);
            if (base.IsPostBack)
            {
                return;
            }
            this.LoadForm();
        }
        public void LoadForm()
        {
            if (this.Code == 0)
            {
                DataTable busOwners = JBusOwners.GetBusOwners();
                this.cmbBusOwner.DataSource = busOwners;
                this.cmbBusOwner.DataTextField = "Name";
                this.cmbBusOwner.DataValueField = "Code";
                this.cmbBusOwner.DataBind();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                return;
            }
            JUnpaidBlackList jUnpaidBlackList = new JUnpaidBlackList(this.Code);
            int pCode = jUnpaidBlackList.pCode;
            DataTable allPersonsOnly = this.GetAllPersonsOnly(pCode);
            this.cmbBusOwner.DataSource = allPersonsOnly;
            this.cmbBusOwner.DataTextField = "Name";
            this.cmbBusOwner.DataValueField = "Code";
            this.cmbBusOwner.DataBind();
            ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(jUnpaidBlackList.FromDate);
            ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(jUnpaidBlackList.ToDate);
            payBlock.Checked = jUnpaidBlackList.PayAfterFinish;
        }
        private DataTable GetAllPersonsOnly(int pCode = 0)
        {
            JDataBase jDataBase = new JDataBase();
            try
            {
                if (pCode == 0)
                {
                    jDataBase.setQuery("select Code, Name from clsAllPerson");
                }
                else
                {
                    jDataBase.setQuery("select Code, Name from clsAllPerson where code =" + pCode);
                }
                DataTable result = jDataBase.Query_DataTable();
                jDataBase.Dispose();
                return result;
            }
            catch
            {
            }
            finally
            {
                jDataBase.Dispose();
            }
            return null;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate() <= DateTime.MinValue
                || ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate() <= DateTime.MinValue)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفاً تاریخ شروع و پایان را انتخاب کنید.');", "ConfirmDialog");
                return;
            }
            int pCode = int.Parse(this.cmbBusOwner.SelectedValue);
            if (Code > 0)
            {
                if (new JUnpaidBlackList
                {
                    Code = this.Code,
                    pCode = pCode,
                    FromDate = ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ToDate = ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                    InsertDate = DateTime.Now,
                    PayAfterFinish = payBlock.Checked
                }.Update(true))
                {
                    JWebManager.CloseAndRefresh();
                }
            }
            else
            {
                if (new JUnpaidBlackList
                {
                    Code = this.Code,
                    pCode = pCode,
                    FromDate = ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ToDate = ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                    InsertDate = DateTime.Now,
                    PayAfterFinish = payBlock.Checked
                }.Insert(true) > 0)
                {
                    JWebManager.CloseAndRefresh();
                } 
            }
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            JUnpaidBlackList jUnpaidBlackList = new JUnpaidBlackList(this.Code);
            if (jUnpaidBlackList.Delete(true))
            {
                JWebManager.CloseAndRefresh();
            }
        }
    }
}
