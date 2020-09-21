using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBaseDefine.Forms
{
    public partial class JLegalPersonUpdateControl : System.Web.UI.UserControl
    {
        int Code;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);

            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtRegisterDate).SetDate(DateTime.Now);
            }

            _SetForm();

            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ClassName = "ClassLibrary.JLegalPerson";
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ObjectCode = 1;
            if (Code > 0) ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ValueObjectCode = Code;
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).KeyColumnWidth = "150px";
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ValueColumnWidth = "400px";
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).LoadPropertyOnPageLoad();

            ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ClassName = (new ClassLibrary.JOrganization()).GetType().FullName;
            if (Code > 0) ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ObjectCode = Code;
            ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).LoadArchive();
        }

        private void _SetForm()
        {
            // Birth Place
            cmbHomeCity.DataValueField = "Code";
            cmbHomeCity.DataTextField = "name";
            cmbHomeCity.DataSource = ClassLibrary.JCities.GetDataTable(ClassLibrary.JBaseDefine.CityCode);
            cmbHomeCity.DataBind();
            // Type
            cmbType.DataValueField = "Code";
            cmbType.DataTextField = "name";
            cmbType.DataSource = ClassLibrary.JCompanyTypes.GetDataTable(ClassLibrary.JBaseDefine.CompanyTypes);
            cmbType.DataBind();
            cmbType.SelectedItem.Text = "سهامی خاص";
            // Register Place
            cmbRegisterPlace.DataValueField = "Code";
            cmbRegisterPlace.DataTextField = "name";
            cmbRegisterPlace.DataSource = ClassLibrary.JCities.GetDataTable(ClassLibrary.JBaseDefine.CityCode);
            cmbRegisterPlace.DataBind();
            cmbRegisterPlace.SelectedItem.Text = "تبریز";

            if (Code > 0)
            {
                ClassLibrary.JOrganization organization = new ClassLibrary.JOrganization(Code);
                txtCode.Text = organization.Code.ToString();
                cmbRegisterPlace.SelectedValue = organization.RegisterPlace.ToString();
                txtInstituteName.Text = organization.Name;
                txtSubject.Text = organization.Subject;
                txtRegisterNumber.Text = organization.RegisterNo;
                cmbType.SelectedValue = organization.CompanyType.ToString();
                txtCommercialCode.Text = organization.CommercialCode;
                ((WebControllers.MainControls.Date.JDateControl)txtRegisterDate).SetDate(organization.RegisterDate);
                txtDescription.Text = organization.Description;
                txtTafsiliCode.Text = organization._TafsiliCode.ToString();
                txtShareHolderCode.Text = organization._SharePCode.ToString();
                txtNationalCode.Text = organization.ShenaseMeli;
                switch (organization.Status)
                {
                    case ClassLibrary.JCompanyStatuses.Active: { rbnCompanyStateActive.Checked = true; break; }
                    case ClassLibrary.JCompanyStatuses.Broke: { rbnCompanyStateBankrupt.Checked = true; break; }
                    case ClassLibrary.JCompanyStatuses.Deactive: { rbnCompanyStateInactive.Checked = true; break; }
                    case ClassLibrary.JCompanyStatuses.Dissolved: { rbnCompanyStateDissolved.Checked = true; break; }
                }

                // Tab #1
                txtHomeAddress.Text = organization.Address.Address;
                cmbHomeCity.SelectedValue = organization.Address.City.ToString();
                txtHomePostalCode.Text = organization.Address.PostalCode;
                txtHomeTel.Text = organization.Address.Tel;
                txtHomeWebsite.Text = organization.Address.WebSite;
                txtHomeFax.Text = organization.Address.Fax;
                txtHomeEmail.Text = organization.Address.Email;

                // Tab #2
                dgrOwnersSignatures.DataSource = organization.SignatureMen;
                dgrOwnersSignatures.DataBound += (sender, args) =>
                {
                    dgrOwnersSignatures.MasterTableView.GetColumn(ClassLibrary.JSignatureMenFields.Code.ToString()).Visible = false;
                    dgrOwnersSignatures.MasterTableView.GetColumn(ClassLibrary.JSignatureMenFields.PCode.ToString()).Visible = false;
                };

                // Tab #3

                // Tab #4
                dgrAssets.DataSource = null;
                Finance.JAsset asset = new Finance.JAsset();
                dgrAssets.DataSource = asset.GetAssetPerson(organization.Code);
                dgrAssets.DataBound += (sender, args) =>
                    {
                        dgrAssets.MasterTableView.GetColumn("AClassName").Visible = false;
                        dgrAssets.MasterTableView.GetColumn("TClassName").Visible = false;
                        dgrAssets.MasterTableView.GetColumn("PersonCode").Visible = false;
                        dgrAssets.MasterTableView.GetColumn("TransferObjectCode").Visible = false;
                        dgrAssets.MasterTableView.GetColumn("FinanceObjectCode").Visible = false;
                    };
                // Tab #5
                dgrContract.DataSource = Legal.JSubjectContracts.PersonContractHistory(organization.Code);
                dgrContract.DataBound += (sender, args) =>
                    {
                        dgrContract.MasterTableView.GetColumn("ContractCode").Visible = false;
                        dgrContract.MasterTableView.GetColumn("ClassName").Visible = false;
                        dgrContract.MasterTableView.GetColumn("ObjectCode").Visible = false;
                    };

            }
        }

        private bool Save()
        {
            ClassLibrary.JOrganization organization = new ClassLibrary.JOrganization(Code);

            organization.RegisterPlace = Convert.ToInt32(cmbRegisterPlace.SelectedValue);
            organization.Name = txtInstituteName.Text;
            organization.Subject = txtSubject.Text;
            organization.RegisterNo = txtRegisterNumber.Text;
            try
            {
                organization.CompanyType = Convert.ToInt32(cmbType.SelectedValue);
            }
            catch
            {
            }
            organization.CommercialCode = txtCommercialCode.Text;
            organization.RegisterDate = ((WebControllers.MainControls.Date.JDateControl)txtRegisterDate).GetDate();
            organization.Description = txtDescription.Text;
            try
            {
                organization._TafsiliCode = Convert.ToInt32(txtTafsiliCode.Text);
                organization._SharePCode = Convert.ToInt32(txtShareHolderCode.Text);
            }
            catch
            {
            }
            organization.ShenaseMeli = txtNationalCode.Text;

            // Tab #1
            organization.Address.Address = txtHomeAddress.Text;
            try
            {
                organization.Address.City = Convert.ToInt32(cmbHomeCity.SelectedValue);
            }
            catch
            {
            }
            organization.Address.PostalCode = txtHomePostalCode.Text;
            organization.Address.Tel = txtHomeTel.Text;
            organization.Address.WebSite = txtHomeWebsite.Text;
            organization.Address.Fax = txtHomeFax.Text;
            organization.Address.Email = txtHomeEmail.Text;

            if (Code > 0)
                return organization.Update();
            else
                return organization.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRegisterNumber.Text != "" || txtRegisterNumber.Text != null)
            {
                if (txtInstituteName.Text != "" || txtInstituteName.Text != null)
                {
                    if (Save())
                        WebClassLibrary.JWebManager.CloseAndRefresh();
                    else
                        WebClassLibrary.JWebManager.ShowMessage("عملیات با خطا مواجه شد. پس از بررسی اطلاعات وارد شده مجددا سعی نمایید.");
                }
                else
                {
                    WebClassLibrary.JWebManager.ShowMessage("لطفا نام موسسه را وارد کنید");
                }
            }
            else
            {
                WebClassLibrary.JWebManager.ShowMessage("لطفا شماره ثبت را وارد کنید");
            }
        }

        protected void btnAddSignature_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditSignature_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeleteSignature_Click(object sender, EventArgs e)
        {

        }
    }
}