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
    public partial class JNewGSReportControl : System.Web.UI.UserControl
    {

        ////گزارش جایگاه های جدید الاحداث
        ////نام منطقه
        ////نام ناحیه
        ////شناسه جایگاه
        ////نام جایگاه
        ////نوع ارتباط جایگاه
        ////مدل سرور
        ////زمان ثبت اینیشیال
        ////کد رهگیری اینیشیال
        ////تعداد نازل
        ////تعداد مخزن



        protected global::WebControllers.MainControls.JCustomListSelectorControl JCustomListSelectorControlDamage;
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
                LoadOilZone();
                LoadSupplier();
                LoadOilArea();
                LoadOilTableDamages();
                LoadUsers();
                LoadDontFixDefects();

            }

        }

        public void LoadDontFixDefects()
        {
            DataTable Dt = new DataTable();
            Dt = WebClassLibrary.JDataManager.EnumToDataTable(typeof(OilProductsDistributionCompany.Failure.JDontFixDefects));
            cmbDontFixDefects.DataSource = Dt;
            cmbDontFixDefects.DataTextField = "Key";
            cmbDontFixDefects.DataValueField = "Value";
            cmbDontFixDefects.DataBind();
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
        /// <summary>
        /// نوع خرابی
        /// </summary>
        private void LoadOilTableDamages()
        {
            // Damage Custom List Search
            JCustomListSelectorControlDamage.Code = 0;
            JCustomListSelectorControlDamage.SQL = @"SELECT FailureNumber AS Code,NAME AS Title,case FailureTypeCode WHEN 1 THEN N'الکتريکي' 
                                                                                                                WHEN 2 THEN N'مکانيکي' ELSE N'کارت هوشمند' END AS FailureTypeCode,
                                                                                                                ExpertiseRequired,case Urgency WHEN 1 THEN N'بالا' 
                                                                                                              WHEN 2 THEN N'متوسط' ELSE N'پايين' END AS Urgency FROM OilTableDamages";
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
        public void GetReport(int AreaCode = 0, int Supplier = 0, int OilZoneCode = 0//, int DayType = -1
                            , DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("ManagerPortalReports");
            string PreQuery = string.Empty;
            jGridView.SQL = OilProductsDistributionCompany.Zone.JOliZonees.PerformanceZoneReport(AreaCode, Supplier, OilZoneCode, StartEventDate
                                                                                                 , EndEventDate,ref PreQuery);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 100;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JManagerPortalReportsControl";
            jGridView.Buttons = "excel";
            //jGridView.SumFields = new Dictionary<string, double>();
            //jGridView.SumFields.Add("TransactionCount", 0);
            //jGridView.SumFields.Add("InCome", 0);
            ((WebControllers.MainControls.Grid.JGridViewControl)grdManagerPortalReports).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)grdManagerPortalReports).LoadGrid(true);
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
        protected void rbFixDefects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbFixDefects.SelectedValue == "0" || rbFixDefects.SelectedValue == "1")
            {
                cmbDontFixDefects.Enabled = true;
            }
            else
            {
                cmbDontFixDefects.SelectedIndex = -1;
                cmbDontFixDefects.Enabled = false;
            }
        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion Event
    }
}