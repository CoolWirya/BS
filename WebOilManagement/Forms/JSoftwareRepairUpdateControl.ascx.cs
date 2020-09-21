using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebOilManagement.Forms
{
    public partial class JSoftwareRepairUpdateControl : System.Web.UI.UserControl
    {
        
        int Code;
        int ReferCode;
        int MalfunctionCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            int.TryParse(Request["ReferCode"], out ReferCode);

            // Get Code using ReferCode
            if (ReferCode > 0)
            {
                Automation.JARefer jaRefer = new Automation.JARefer(ReferCode);
                MalfunctionCode = (new Automation.JAObject(jaRefer.object_code)).ObjectCode;
                OilProductsDistributionCompany.Failure.JSoftwareRepair jSoftwareRepair = new OilProductsDistributionCompany.Failure.JSoftwareRepair();
                jSoftwareRepair.GetDataByMalfunction(MalfunctionCode);
                Code = jSoftwareRepair.Code;
            }
            else
            {
            }

            if (!IsPostBack)
            {
                LoadInitialReasons();
                LoadInitialAgains();
                ((WebControllers.MainControls.Date.JDateControl)txtLastTimeConnectingPooler).SetDate(DateTime.Now);
                txtTimeHour.Text = "07";
                txtTimeMinute.Text = "00";
                _SetForm();
            }

            // TableDamage Custom List Search
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRPMCode).Code = 0;
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRPMCode).SQL = @"SELECT Code,[Version] AS Title,DateRegister,Comment FROM OilRPM";
        }

        public void LoadInitialReasons()
        {
            DataTable Dt = new DataTable();
            Dt = WebClassLibrary.JDataManager.EnumToDataTable(typeof(OilProductsDistributionCompany.Failure.JInitialReasons));
            cmbInitialReasons.DataSource = Dt;
            cmbInitialReasons.DataTextField = "Key";
            cmbInitialReasons.DataValueField = "Value";
            cmbInitialReasons.DataBind();
        }

        public void LoadInitialAgains()
        {
            DataTable Dt = new DataTable();
            Dt = WebClassLibrary.JDataManager.EnumToDataTable(typeof(OilProductsDistributionCompany.Failure.JInitialAgain));
           // Dt.
            cmbInitialAgain.DataSource = Dt;
            cmbInitialAgain.DataTextField = "Key";
            cmbInitialAgain.DataValueField = "Value";
            cmbInitialAgain.DataBind();
        }

        //public void LoadDontFixDefects()
        //{
        //    DataTable Dt = new DataTable();
        //    Dt = WebClassLibrary.JDataManager.EnumToDataTable(typeof(OilProductsDistributionCompany.Failure.JDontFixDefects));
        //    cmbInitialAgain.DataSource = Dt;
        //    cmbInitialAgain.DataTextField = "Key";
        //    cmbInitialAgain.DataValueField = "Value";
        //    cmbInitialAgain.DataBind();
        //}

        public void _SetForm()
        {
            if (Code > 0)
            {
                OilProductsDistributionCompany.Failure.JSoftwareRepair SoftwareRepair = new OilProductsDistributionCompany.Failure.JSoftwareRepair();
                SoftwareRepair.GetData(Code);

                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRPMCode).Code = SoftwareRepair.NewRPMCode;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRPMCode).SQL = @"SELECT Code,[Version] AS Title,DateRegister,Comment FROM OilRPM";

                cmbInitialReasons.SelectedValue = SoftwareRepair.InitialReasons.GetHashCode().ToString();
                txtInitialReasonsComment.Text = SoftwareRepair.InitialReasonsComment;
                cmbInitialAgain.SelectedValue = SoftwareRepair.InitialAgain.GetHashCode().ToString();
                txtInitialAgainComment.Text = SoftwareRepair.InitialAgainComment;
                txtTableQuotas.Text = SoftwareRepair.TableQuotas.ToString();
                txtTablePrices.Text = SoftwareRepair.TablePrices.ToString();
                txtPtVersion.Text = SoftwareRepair.PtVersion.ToString();
                rbGSSoftwareANDDashboard.SelectedValue = Convert.ToInt32(SoftwareRepair.GSSoftwareANDDashboard).ToString();
                txtGSSoftwareANDDashboardComment.Text = SoftwareRepair.GSSoftwareANDDashboardComment;
                rbRelationshipStatusDataCenter.SelectedValue = Convert.ToInt32(SoftwareRepair.RelationshipStatusDataCenter).ToString();
                ((WebControllers.MainControls.Date.JDateControl)txtLastTimeConnectingPooler).SetDate(SoftwareRepair.LastTimeConnectingPooler);
                txtTimeHour.Text = SoftwareRepair.LastTimeConnectingPooler.Hour.ToString();
                txtTimeMinute.Text = SoftwareRepair.LastTimeConnectingPooler.Minute.ToString();
            }
        }


        public bool Save()
        {
            OilProductsDistributionCompany.Failure.JSoftwareRepair SoftwareRepair = new OilProductsDistributionCompany.Failure.JSoftwareRepair();
            SoftwareRepair.Code = Code;
            SoftwareRepair.MalfunctionCode = MalfunctionCode;
            SoftwareRepair.NewRPMCode = ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRPMCode).Code;
            SoftwareRepair.InitialReasons = (OilProductsDistributionCompany.Failure.JInitialReasons)Convert.ToInt32(cmbInitialReasons.SelectedValue);
            SoftwareRepair.InitialReasonsComment = txtInitialReasonsComment.Text;
            SoftwareRepair.InitialAgain = (OilProductsDistributionCompany.Failure.JInitialAgain)Convert.ToInt32(cmbInitialAgain.SelectedValue);
            SoftwareRepair.InitialAgainComment = txtInitialAgainComment.Text;
            SoftwareRepair.TableQuotas = Convert.ToInt32(txtTableQuotas.Text);
            SoftwareRepair.TablePrices = Convert.ToInt32(txtTablePrices.Text);
            SoftwareRepair.PtVersion = txtPtVersion.Text;
            SoftwareRepair.GSSoftwareANDDashboard = Convert.ToBoolean(Convert.ToInt32(rbGSSoftwareANDDashboard.SelectedValue));
            SoftwareRepair.GSSoftwareANDDashboardComment = txtGSSoftwareANDDashboardComment.Text;
            SoftwareRepair.RelationshipStatusDataCenter = Convert.ToBoolean(Convert.ToInt32(rbGSSoftwareANDDashboard.SelectedValue));

            DateTime txtLastTime = ((WebControllers.MainControls.Date.JDateControl)txtLastTimeConnectingPooler).GetDate();
            DateTime FinalDateTime = new DateTime(txtLastTime.Year, txtLastTime.Month, txtLastTime.Day, Convert.ToInt32(txtTimeHour.Text), Convert.ToInt32(txtTimeMinute.Text), 0);

            SoftwareRepair.LastTimeConnectingPooler = FinalDateTime;
            if (Code > 0)
                return SoftwareRepair.update();
            else
                return SoftwareRepair.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                RedirectToMalfunction();
            else
                WebClassLibrary.JWebManager.ShowMessage("عملیات با خطا مواجه شد. پس از بررسی اطلاعات وارد شده مجددا سعی نمایید.");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            RedirectToMalfunction();
        }

        public void RedirectToMalfunction()
        {
            WebClassLibrary.JWebManager.LoadControl("Malfunction"
                  , "~/WebOilManagement/Forms/JMalfunctionUpdateControl.ascx"
                  , "اعلام خرابی"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("ReferCode", ReferCode.ToString()) }
                  , WebClassLibrary.WindowTarget.CurrentWindow
                  , true, false, true, 650, 450);
        }
    }
}