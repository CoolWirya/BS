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
    public partial class JManagerPortalReportsControl : System.Web.UI.UserControl
    {

        ///گزارش های مدیریتی از پورتال
        ///کل تیکت های ثبت شده 
        ///تعداد تیکت های ثبت شده به ازا مناطق نفتی
        ///تعداد تیکت های ثیت شده به ازا نوع خرابی
        ///تعداد تیکت های ثبتی به ازا پیمانکاران
        ///تعدادتیکت ها با وضعیت های مختلف
        ///تعداد تیکت ها ی ثبتی توسط هر یک ازکاربران مرکز تماس
        ///وضعیت SLA پیمانکاران 

        protected global::WebControllers.MainControls.JCustomListSelectorControl JCustomListSelectorControlDamage;
        protected global::WebControllers.MainControls.JCustomListSelectorControl JLstCtrUsers;
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
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadOilZone();
                LoadSupplier();
                LoadOilArea();
                LoadOilTableDamages();
                LoadUsers();
                LoadDontFixDefects();

                switch (Request["Code"])
                {
                    case "1":
                        divTitle.InnerText = "کل تیکت های ثبت شده";
                        break;
                    case "2":
                        divTitle.InnerText = "تعداد تیکت های ثبت شده به ازا مناطق نفتی";
                        break;
                    case "3":
                        divTitle.InnerText = "تعداد تیکت های ثیت شده به ازا نوع خرابی";
                        break;
                    case "4":
                        divTitle.InnerText = "تعداد تیکت های ثبتی به ازا پیمانکاران";
                        break;
                    case "5":
                        divTitle.InnerText = "تعدادتیکت ها با وضعیت های مختلف";
                        break;
                    case "6":
                        divTitle.InnerText = "تعداد تیکت ها ی ثبتی توسط هر یک ازکاربران مرکز تماس";
                        break;
                }
               
            //     AllTicket = 1,///کل تیکت های ثبت شده 
            //ZoneTicket = 2,///تعداد تیکت های ثبت شده به ازا مناطق نفتی
            //TypeTicket = 3,///تعداد تیکت های ثیت شده به ازا نوع خرابی
            //SupplierTicket = 4,///تعداد تیکت های ثبتی به ازا پیمانکاران
            //StatusTicket = 5,///تعدادتیکت ها با وضعیت های مختلف
            //UsersTicket = 6,///تعداد تیکت ها ی ثبتی توسط هر یک ازکاربران مرکز تماس
                

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
                          , int UsersCode = 0, int DamageCode = 0, int DontFixDefectsCode = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("ManagerPortalReports");
            jGridView.SQL = OilProductsDistributionCompany.Failure.JMalfunctiones.PerformanceZoneReport(AreaCode, Supplier, OilZoneCode //, int DayType = -1
                          , UsersCode, DamageCode, DontFixDefectsCode, StartEventDate, EndEventDate, (OilProductsDistributionCompany.Failure.JMalfunctiones.PerformanceMalfunctionReport)Code);
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
        #endregion Methods

        #region Event
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                GetReport(Convert.ToInt32(cmbArea.SelectedValue), Convert.ToInt32(cmbSupplier.SelectedValue),
                    Convert.ToInt32(cmbOilZone.SelectedValue), JLstCtrUsers.Code
                    , JCustomListSelectorControlDamage.Code, Convert.ToInt32(cmbDontFixDefects.SelectedValue),
                    ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
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