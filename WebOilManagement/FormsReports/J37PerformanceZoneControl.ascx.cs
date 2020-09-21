using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassLibrary;
using WebClassLibrary;

namespace WebOilManagement.FormsReports
{
    public partial class J37PerformanceZoneControl : System.Web.UI.UserControl
    {

        ///گزارش عملکرد مناطق 37 گانه
        ///منطقه oilzone
        ///ناحیه[OilArea]
        ///تعداد جایگاه های تحت پوشش 
        ///مدیر منطقه *
        ///پیمانکار تحت پوشش
        ///تعداد تیکت های ثبتی هر منطقه
        ///SLA مناطق *
        ///تعداد RPM های دستی نصب شده در طول ماه در هر منطقه *
        // protected global::WebControllers.MainControls.Grid.JGridViewControl grd37PerformanceZone;

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
                LoadOilZone();
                LoadSupplier();
                LoadOilArea();

            }
        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion Public

        #region Methods
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        private void LoadSupplier(int OilZoneCode = 0)
        {
            string where = string.Empty;
            if (OilZoneCode > 0)
                where = " Where OSD.ZoneCode = " + OilZoneCode;
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
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
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
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
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
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        public void GetReport(int AreaCode = 0, int Supplier = 0, int OilZoneCode = 0//, int DayType = -1
                            , DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("37PerformanceZone");
            string PreQuery = string.Empty;
            jGridView.SQL = OilProductsDistributionCompany.Zone.JOliZonees.PerformanceZoneReport(AreaCode, Supplier, OilZoneCode, StartEventDate, EndEventDate, ref PreQuery);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 100;
            jGridView.Title = "J37PerformanceZoneControl";
            jGridView.Buttons = "excel";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //jGridView.DetailDataSource = OilProductsDistributionCompany.Zone.JOliZonees.PerformanceZoneCodeList(AreaCode, Supplier, OilZoneCode, StartEventDate, EndEventDate);
            //jGridView.DetailKeyFields = new Dictionary<string, string>();
            //jGridView.DetailKeyFields.Add("MasterCode", " AND ");
            //jGridView.DetailKeyFields.Add("ZoneCode", " AND ");
            //jGridView.DetailKeyFields.Add("AreaCode", " AND ");
            //jGridView.HiddenColumns = "AreaCode,Code";
            //jGridView.IsDetailQueryIn = true;
            //jGridView.PreQuery = PreQuery;
            ((WebControllers.MainControls.Grid.JGridViewControl)grd37PerformanceZone).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)grd37PerformanceZone).LoadGrid(true);
          //jGridView.

        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion Methods

        #region Event
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                GetReport(Convert.ToInt32(cmbArea.SelectedValue), Convert.ToInt32(cmbSupplier.SelectedValue),
                    Convert.ToInt32(cmbOilZone.SelectedValue), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
            catch { }
        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        protected void cmbOilZone_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LoadOilArea(int.Parse(cmbOilZone.SelectedValue));
            LoadSupplier(int.Parse(cmbOilZone.SelectedValue));

        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion Event
    }
}