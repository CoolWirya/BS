using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebOilManagement.FormsReports
{
    public partial class JMalFunctionVsRepairReportsRepairControl : System.Web.UI.UserControl
    {

        /// <summary>
        /// فرم گزارش گیری از خرابی ها و تعمیرات انجام شده
        /// </summary>

        protected global::WebControllers.MainControls.JCustomListSelectorControl jclDefectiveItem;

        #region "Events"
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
                btnGenerateReport_Click(null, null);
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)dcFailurDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)dcFixingBrokenDate).SetDate(DateTime.Now);
                this.LoadOilZone();
                this.LoadOilArea();
                this.LoadStationName();
            }
           
        }
        
        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            
           this.GetReport(Convert.ToInt32(cmbArea.SelectedValue)
                    ,Convert.ToInt32(cmbOilZone.SelectedValue)
                    ,Convert.ToInt32(cmbStationName.SelectedValue)
                    , ((WebControllers.MainControls.Date.JDateControl)dcFailurDate).GetDate()
                    ,((WebControllers.MainControls.Date.JDateControl)dcFixingBrokenDate).GetDate()
                    ,Convert.ToInt32(rbtnUseType.SelectedValue));
        }

        protected void cmbOilZone_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            this.LoadOilArea(Convert.ToInt32(cmbOilZone.SelectedValue));
        }

        protected void cmbArea_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            this.LoadStationName(Convert.ToInt32(cmbArea.SelectedValue));
        }
#endregion

        #region "Methods"
        public void LoadOilZone()
        {
            DataTable Dt = new DataTable();
            Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT Code, Name FROM OilZone Where  " + ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.Zone.JOliZonees.GetWebQuery", "Code"));
            var p = (from v in Dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbOilZone.DataSource = p;
            cmbOilZone.DataTextField = "Name";
            cmbOilZone.DataValueField = "Code";
            cmbOilZone.DataBind();
        }

        //----------------------------------------------------------------------------------------------
        private void LoadOilArea(int OilZoneCode = 0)
        {
            string where = string.Empty;
            if (OilZoneCode > 0)
                where = " Where oa.OilZoneCode = " + OilZoneCode;
            else
                where = " WHERE " + ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.Zone.JOliZonees.GetWebQuery", "oa.OilZoneCode");
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT oa.Code, oa.Name FROM OilArea oa" + where);
            var p = (from v in Dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbArea.DataSource = p;
            cmbArea.DataTextField = "Name";
            cmbArea.DataValueField = "Code";
            cmbArea.DataBind();
        }
        //----------------------------------------------------------------------------------------------------------------------------

        private void LoadStationName(int OilAreaCode = 0)
        {
            string where = string.Empty;
            if (OilAreaCode > 0)
                where = " Where og.OilAreaCode = " + OilAreaCode;

            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code, Name from OilGasStation og " + where);

            var p = (from v in Dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();

            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbStationName.DataSource = p;
            cmbStationName.DataTextField = "Name";
            cmbStationName.DataValueField = "Code";
            cmbStationName.DataBind();
        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------

        //private void LoadEliminateDownTimeDue()
        //{
            
        //    DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT Code, DontFixDefectsComment FROM OilAfterReviewing ");

        //    var p = (from v in Dt.AsEnumerable()
        //             select new { Code = Convert.ToInt32(v["Code"]), Name = v["DontFixDefectsComment"].ToString() }).ToList();

        //    p.Insert(0, new { Code = 0, Name = "همه" });
        //    cmbEliminateDownTimeDue.DataSource = p;
        //    cmbEliminateDownTimeDue.DataTextField = "Name";
        //    cmbEliminateDownTimeDue.DataValueField = "Code";
        //    cmbEliminateDownTimeDue.DataBind();
        //}
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        public void GetReport(int AreaCode = 0, int OilZoneCode = 0, int StationID = 0,DateTime? FailurDate = null
            , DateTime? FixingBrokenDate=null,  int UseType = 0)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("ManagerPortalReports");
            
            jGridView.SQL = OilProductsDistributionCompany.Failure.JMalfunctiones.PerformanceVsRepairReportsRepair(AreaCode, OilZoneCode, StationID
                                                    ,  FailurDate, FixingBrokenDate, UseType);

            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 100;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JManagerPortalReportsControl";
            jGridView.Buttons = "excel";

            ((WebControllers.MainControls.Grid.JGridViewControl)grdManagerPortalReports).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)grdManagerPortalReports).LoadGrid(true);
        }
        
#endregion

        protected void rbtnUseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["UseType"] = rbtnUseType.SelectedValue;
        }

    }
}