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
    public partial class JGSPropertiesReportControl : System.Web.UI.UserControl
    {
        ///گزارش مشخصات جایگاه ها 
        //// نام ناحیه
        ////شناسه جایگاه GS
        ////نام جایگاه
        ////آدرس جایگاه
        ////مدل سرور
        ////نوع مودم
        ////تعداد مخزن
        ////وضعیت نازل ها
        ////نوع ارتباط جایگاه
        ////نوع سوخت
        ////پایداری تسویه حساب

        protected global::WebControllers.MainControls.JCustomListSelectorControl JCustomListSelectorControlDamage;
        protected global::WebControllers.MainControls.JCustomListSelectorControl JLstCtrUsers;
        protected global::WebControllers.MainControls.JSearchPersonControl personOwner;
        protected global::WebControllers.MainControls.JSearchPersonControl personOperator;
        int Code;

        #region Public
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int.TryParse(Request["Code"], out Code);
                btnGenerateReport_Click(null, null);

            }
            else
            {
                //((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                //((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                //  int AreaCode     = 0, int Supplier        = 0, int OilZoneCode  = 0//, int DayType = -1
                //, int UsersCode    = 0, int PlaceOfSupply   = 0, int TypeOfSupply = 0, int OwnerCode          = 0
                //, int OperatorCode = 0, int FuelTankCode    = 0, int NozzelCode   = 0, int TypeOfFuelTankCode = 0, int TypeOfProductCode = 0 , ,int Lat = 0,int Lon = 0,int Alt =0)
                LoadOilZone();
                LoadSupplier();
                LoadOilArea();
                LoadUsers();
                LoadPlaceOfSupply();
                LoadTypeOfSupply();
                LoadTypeOfFuelTankCode();
                LoadTypeOfProductCode();
            }
        }




        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion Public

        #region Methods

        /// <summary>
        /// لیست کاربران
        /// </summary>
        private void LoadUsers()
        {
            // Users List Search
            JLstCtrUsers.Code = 0;
            JLstCtrUsers.SQL = @"SELECT Pcode as Code , Name AS Title  FROM users as Usr left join clsAllPerson CLS on CLS.code=Usr.Pcode";
        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        private void LoadTypeOfSupply()
        {
            cmbTypeOfSupply.DataSource = OilProductsDistributionCompany.Define.JTypeOfSupplies.GetDataTable(OilProductsDistributionCompany.JDefine.TypeOfSupply);
            cmbTypeOfSupply.DataTextField = "Name";
            cmbTypeOfSupply.DataValueField = "Code";
            cmbTypeOfSupply.DataBind();

        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        private void LoadPlaceOfSupply()
        {
            cmbPlaceOfSupply.DataSource = OilProductsDistributionCompany.Define.JPlaceOfSupplies.GetDataTable(OilProductsDistributionCompany.JDefine.PlaceOfSupply);
            cmbPlaceOfSupply.DataTextField = "Name";
            cmbPlaceOfSupply.DataValueField = "Code";
            cmbPlaceOfSupply.DataBind();
        }
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
        private void LoadTypeOfProductCode()
        {
            cmbTypeOfProduct.DataSource = OilProductsDistributionCompany.Define.JTypeOfProducts.GetDataTable(OilProductsDistributionCompany.JDefine.TypeOfProduct);
            cmbTypeOfProduct.DataTextField = "Name";
            cmbTypeOfProduct.DataValueField = "Code";
            cmbTypeOfProduct.DataBind();
        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        private void LoadTypeOfFuelTankCode()
        {
            cmbTypeOfFuelTank.DataSource = OilProductsDistributionCompany.Define.JTypeOfFuelTanks.GetDataTable(OilProductsDistributionCompany.JDefine.TypeOfFuelTank);
            cmbTypeOfFuelTank.DataTextField = "Name";
            cmbTypeOfFuelTank.DataValueField = "Code";
            cmbTypeOfFuelTank.DataBind();
        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        public void GetReport(int AreaCode = 0, int Supplier = 0, int OilZoneCode = 0//, int DayType = -1
                            , int UsersCode = 0, int PlaceOfSupply = 0, int TypeOfSupply = 0, int OwnerCode = 0
                            , int OperatorCode = 0, int FuelTankCode = 0, int NozzelCode = 0, int TypeOfFuelTankCode = 0, int TypeOfProductCode = 0
                            , string Lat = "0", string Lon = "0", string Alt = "0")
        {
            if (string.IsNullOrEmpty(Lat))
                Lat = "0";
            if (string.IsNullOrEmpty(Lon))
                Lon = "0";
            if (string.IsNullOrEmpty(Alt))
                Alt = "0";

            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("GSPropertiesReport");
            jGridView.SQL = OilProductsDistributionCompany.GasStation.JGasStationes.GSPropertiesReport(AreaCode, Supplier, OilZoneCode, //, int DayType = -1
                           UsersCode, PlaceOfSupply, TypeOfSupply, OwnerCode, OperatorCode, FuelTankCode, NozzelCode, TypeOfFuelTankCode, TypeOfProductCode
                           , Convert.ToInt32(Lat), Convert.ToInt32(Lon), Convert.ToInt32(Alt));
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 100;
            jGridView.HiddenColumns = "Code,FTCount,ONCount";
            jGridView.Title = "JGSPropertiesReportControl";
            jGridView.Buttons = "excel";
            //jGridView.SumFields = new Dictionary<string, double>();
            //jGridView.SumFields.Add("TransactionCount", 0);
            //jGridView.SumFields.Add("InCome", 0);
            ((WebControllers.MainControls.Grid.JGridViewControl)grdManagerPortalReports).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)grdManagerPortalReports).LoadGrid(true);
        }

        #endregion Methods

        #region Event
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {

                GetReport(Convert.ToInt32(cmbArea.SelectedValue), Convert.ToInt32(cmbSupplier.SelectedValue),
                    Convert.ToInt32(cmbOilZone.SelectedValue), JLstCtrUsers.Code
                    , int.Parse(cmbPlaceOfSupply.SelectedValue), int.Parse(cmbTypeOfSupply.SelectedValue), personOwner.PersonCode, personOperator.PersonCode
                    , Convert.ToInt32(cmbTypeOfFuelTank.SelectedValue), 0, int.Parse(cmbTypeOfFuelTank.SelectedValue), Convert.ToInt32(cmbTypeOfProduct.SelectedValue),
                    txtLat.Text, txtLon.Text, txtAlt.Text);
            }
            catch
            {
            }
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