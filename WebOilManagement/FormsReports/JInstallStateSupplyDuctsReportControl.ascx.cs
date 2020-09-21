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
    public partial class JInstallStateSupplyDuctsReportControl : System.Web.UI.UserControl
    {

        protected global::WebControllers.MainControls.JCustomListSelectorControl JLstCtrGood;

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                btnGenerateReport_Click(null, null);
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)AsDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)ToDate).SetDate(DateTime.Now);
                this.LoadOilZone();
                this.LoadOilArea();
                this.LoadSupplier();
            }
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            this.GetReport(Convert.ToInt32(cmbArea.SelectedValue)
                , Convert.ToInt32(cmbOilZone.SelectedValue)
                , Convert.ToInt32(cmbSupplier.SelectedValue)
                , ((WebControllers.MainControls.Date.JDateControl)AsDate).GetDate()
                , ((WebControllers.MainControls.Date.JDateControl)ToDate).GetDate());
        }

        protected void cmbOilZone_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            this.LoadOilArea(Convert.ToInt32(cmbOilZone.SelectedValue));
        }

        protected void cmbArea_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            this.LoadSupplier(Convert.ToInt32(cmbArea.SelectedValue));
        }

        #endregion Events

        #region Methods

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

        private void LoadSupplier(int OilAreaCode = 0)
        {
            string where = string.Empty;
            if (OilAreaCode > 0)
                where = " Where OSD.ZoneCode = " + OilAreaCode;
            else
                where = " WHERE " + ClassLibrary.JPermission.getObjectSql("OilProductsDistributionCompany.Zone.JOliZonees.GetWebQuery", "OSD.ZoneCode");
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT OS.Code, CAP.Name FROM OilSupplier OS
                          Left join OilSupplierDetails OSD  ON(OS.Code = OSD.SupplierCode )
                          Left Join clsAllPerson CAP  ON(CAP.Code=OS.PCode) " + where);

            var p = (from v in Dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();

            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbSupplier.DataSource = p;
            cmbSupplier.DataTextField = "Name";
            cmbSupplier.DataValueField = "Code";
            cmbSupplier.DataBind();
        }

        private void GetReport(int AreaCode = 0, int OilZoneCode = 0, int Supplier = 0
                                , DateTime? AsDate = null, DateTime? ToDate = null)
        {

            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("InstallStateSupplyDuctsReport");

            jGridView.SQL = OilProductsDistributionCompany.GasStation.JGasStationes.GSInstallStateSupplyDuctsReport(AreaCode, OilZoneCode
                                                                                    , Supplier, AsDate, ToDate);

            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 100;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JInstallStateSupplyDuctsReportControl";
            jGridView.Buttons = "excel";

            ((WebControllers.MainControls.Grid.JGridViewControl)grdManagerPortalReports).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)grdManagerPortalReports).LoadGrid(true);

        }

        #endregion Methods


    }
}