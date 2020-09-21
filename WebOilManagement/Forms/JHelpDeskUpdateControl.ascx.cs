using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebOilManagement.Forms
{
    public partial class JHelpDeskUpdateControl : System.Web.UI.UserControl
    {
        #region Init
        int Code;
        int ReferCode;
        int MalfunctionCode;
        #endregion Init

        #region Public
        ///---------------------------------------------------------------------------------
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
                _SetForm();
            }

        }
        ///---------------------------------------------------------------------------------
        #endregion Public

        #region Methods
        ///---------------------------------------------------------------------------------
        public void _SetForm()
        {
            if (Code > 0)
            {
                OilProductsDistributionCompany.Failure.JSoftwareRepair SoftwareRepair = new OilProductsDistributionCompany.Failure.JSoftwareRepair();
                SoftwareRepair.GetData(Code);
            }
        }
        ///---------------------------------------------------------------------------------
        public bool Save()
        {
            if (Code <= 0)
            {
                WebClassLibrary.JWebManager.ShowMessage("خرابی نرم افزار ثبت نشده است.");
                return true;
            }
            OilProductsDistributionCompany.Failure.JSoftwareRepair SoftwareRepair = new OilProductsDistributionCompany.Failure.JSoftwareRepair();
            SoftwareRepair.Code = Code;
            SoftwareRepair.MalfunctionCode = MalfunctionCode;
            SoftwareRepair.LastTimeConnectingPooler = DateTime.Now;
            //SoftwareRepair.NewRPMCode = ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlRPMCode).Code;
            //SoftwareRepair.InitialReasons = (OilProductsDistributionCompany.Failure.JInitialReasons)Convert.ToInt32(cmbInitialReasons.SelectedValue);
            //SoftwareRepair.InitialReasonsComment = txtInitialReasonsComment.Text;
            //SoftwareRepair.InitialAgain = (OilProductsDistributionCompany.Failure.JInitialAgain)Convert.ToInt32(cmbInitialAgain.SelectedValue);
            //SoftwareRepair.InitialAgainComment = txtInitialAgainComment.Text;
            //SoftwareRepair.TableQuotas = Convert.ToInt32(txtTableQuotas.Text);
            //SoftwareRepair.TablePrices = Convert.ToInt32(txtTablePrices.Text);
            //SoftwareRepair.PtVersion = txtPtVersion.Text;
            //SoftwareRepair.GSSoftwareANDDashboard = Convert.ToBoolean(Convert.ToInt32(rbGSSoftwareANDDashboard.SelectedValue));
            //SoftwareRepair.GSSoftwareANDDashboardComment = txtGSSoftwareANDDashboardComment.Text;
            //SoftwareRepair.RelationshipStatusDataCenter = Convert.ToBoolean(Convert.ToInt32(rbGSSoftwareANDDashboard.SelectedValue));
            //DateTime txtLastTime = ((WebControllers.MainControls.Date.JDateControl)txtLastTimeConnectingPooler).GetDate();
            //DateTime FinalDateTime = new DateTime(txtLastTime.Year, txtLastTime.Month, txtLastTime.Day, Convert.ToInt32(txtTimeHour.Text), Convert.ToInt32(txtTimeMinute.Text), 0);
            //SoftwareRepair.LastTimeConnectingPooler = FinalDateTime;

            SoftwareRepair.OperationDescription = txtOperationDescription.Text;
            SoftwareRepair.OperationDone = chbOperationDone.Checked;
            if (Code > 0)
                return SoftwareRepair.update();
            else
                return false;
        }
        ///---------------------------------------------------------------------------------
        public void RedirectToMalfunction()
        {
            WebClassLibrary.JWebManager.LoadControl("Malfunction"
                  , "~/WebOilManagement/Forms/JMalfunctionUpdateControl.ascx"
                  , "اعلام خرابی"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("ReferCode", ReferCode.ToString()) }
                  , WebClassLibrary.WindowTarget.CurrentWindow
                  , true, false, true, 650, 450);
        }
        ///---------------------------------------------------------------------------------
        #endregion Methods

        #region Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                RedirectToMalfunction();
            else
                WebClassLibrary.JWebManager.ShowMessage("عملیات با خطا مواجه شد. پس از بررسی اطلاعات وارد شده مجددا سعی نمایید.");
        }
        ///---------------------------------------------------------------------------------
        protected void btnClose_Click(object sender, EventArgs e)
        {
            RedirectToMalfunction();
        }
        ///---------------------------------------------------------------------------------
        #endregion Events

    }
}