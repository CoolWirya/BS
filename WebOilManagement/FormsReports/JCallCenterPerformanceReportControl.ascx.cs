using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassLibrary;

namespace WebOilManagement.FormsReports
{
    public partial class JCallCenterPerformanceReportControl : System.Web.UI.UserControl
    {
    ////گزارش عملکرد Call Center
    ////تعداد کاربران مرکز تماس
    ////تعداد کل تیکت های ثبت شده توسط مرکز تماس
    ////تعداد تیکت های ثبت شده توسط هر کاربر
    ////تعداد تیکت های ارجاع داده شده توسط هر کاربر

        protected global::WebControllers.MainControls.JCustomListSelectorControl JLstCtrUsers;
        #region Public
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                btnGenerateReport_Click(null, null);
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadUsers();

            }
        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion Public

        #region Methods
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// لیست کاربران
        /// </summary>
        private void LoadUsers()
        {
            // Users List Search
            JLstCtrUsers.Code = 0;
            JLstCtrUsers.SQL = @"SELECT  Usr.Code , Name AS Title  FROM users as Usr left join clsAllPerson CLS on CLS.code=Usr.Pcode";
        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        public void GetReport(int UserCode = 0
                            , DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("CallCenterPerformance");
            jGridView.SQL = OilProductsDistributionCompany.Failure.JMalfunctiones.PerformanceCallCenterReport(UserCode, StartEventDate
                                                                                                 , EndEventDate);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 100;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JCallCenterPerformanceReportControl";
            jGridView.Buttons = "excel";
            //jGridView.SumFields = new Dictionary<string, double>();
            //jGridView.SumFields.Add("TransactionCount", 0);
            //jGridView.SumFields.Add("InCome", 0);
            ((WebControllers.MainControls.Grid.JGridViewControl)grdCallCenterPerformance).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)grdCallCenterPerformance).LoadGrid(true);
        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion Methods

        #region Event
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                GetReport(Convert.ToInt32(JLstCtrUsers.Code), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
            catch { }
        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion Event
    }
}