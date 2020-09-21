using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebOilManagement.Forms
{
    public partial class JOilSupplierZonesUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        int SupplierPersonCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
                LoadOilZone();
                LoadSupplier();
                _SetForm();
            }
        }

        public void LoadSupplier()
        {
            DataTable DtSuppliers = new DataTable();
            DtSuppliers = OilProductsDistributionCompany.JSupplierses.GetDataTable(Code);
            SupplierPersonCode = Convert.ToInt32(DtSuppliers.Rows[0]["PCode"].ToString());
            txtSupplierNamer.Text = (new ClassLibrary.JAllPerson(SupplierPersonCode)).Name;
        }

        public void LoadOilZone()
        {
            DataTable DtOilZone = new DataTable();
            DtOilZone = OilProductsDistributionCompany.Zone.JOliZonees.GetDataTable();
            cmbOilZone.DataSource = DtOilZone;
            cmbOilZone.DataTextField = "Name";
            cmbOilZone.DataValueField = "Code";
            cmbOilZone.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                LoadSupplierZones();
            }
        }

        public int Save()
        {
            DataTable DtHasDuplicate = new DataTable();
            DtHasDuplicate = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from OilSupplierDetails where SupplierCode="
                                                                        + Code
                                                                        + @" and ZoneCode = " + cmbOilZone.SelectedValue);

            if (DtHasDuplicate.Rows.Count == 0)
            {
                OilProductsDistributionCompany.JSupplierDetails OilSupplierZone = new OilProductsDistributionCompany.JSupplierDetails();
                //OilSupplierZone.Code = Code;
                OilSupplierZone.SupplierCode = Code;
                OilSupplierZone.ZoneCode = Convert.ToInt32(cmbOilZone.SelectedValue);
                //if (Code > 0)
                //return OilSupplierArea.update();
                //else
                return OilSupplierZone.Insert() > 0 ? 1 : 0;
            }
            else
            {
                return -1;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save() == 1)
            {
                //WebClassLibrary.JWebManager.CloseAndRefresh();
                LoadSupplierZones();
            }
            else if (Save() == -1)
            {
                WebClassLibrary.JWebManager.ShowMessage("این منطقه قبلا برای این پیمانکار ثبت شده است");
            }
            else
            {
                WebClassLibrary.JWebManager.ShowMessage("عملیات با خطا مواجه شد. پس از بررسی اطلاعات وارد شده مجددا سعی نمایید.");
            }
        }

        public void LoadSupplierZones()
        {
            DataTable DtSuppliers = new DataTable();
            DtSuppliers = OilProductsDistributionCompany.JSupplierses.GetDataTable(Code);
            GrvOilSupplierArea.DataSource = WebClassLibrary.JWebDataBase.GetDataTable(@"select os.Code as N'کد',oz.Name as N'منطقه' from OilSupplierDetails os
                                                                                            LEFT JOIN OilZone oz ON os.ZoneCode = oz.Code
                                                                                            where SupplierCode =" + Code);
            //OilProductsDistributionCompany.JSupplierDetailses.GetData(Convert.ToInt32(DtSuppliers.Rows[0]["PCode"].ToString()));
            GrvOilSupplierArea.DataBind();
        }

        protected void GrvOilSupplierArea_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string CuCode = "";
            CuCode = e.Item.Cells[3].Text.ToString();
            OilProductsDistributionCompany.JSupplierDetails OilSupplierZone = new OilProductsDistributionCompany.JSupplierDetails();
            OilSupplierZone.Code = Convert.ToInt32(CuCode);
            OilSupplierZone.Delete();
            LoadSupplierZones();
        }
    }
}