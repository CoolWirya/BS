using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebOilManagement.Forms
{
    public partial class JAfterReviewingUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        int ReferCode;
        int MalfunctionCode;

        protected global::WebControllers.MainControls.JCustomListSelectorControl RepresentativeSupplierCode;

        protected void Page_Load(object sender, EventArgs e)
        {

            int.TryParse(Request["Code"], out Code);
            int.TryParse(Request["ReferCode"], out ReferCode);

            // Get Code using ReferCode
            if (ReferCode > 0)
            {
                Automation.JARefer jaRefer = new Automation.JARefer(ReferCode);
                MalfunctionCode = (new Automation.JAObject(jaRefer.object_code)).ObjectCode;
                OilProductsDistributionCompany.Failure.JMalfunction Mal = new OilProductsDistributionCompany.Failure.JMalfunction();
                Mal.GetData(MalfunctionCode);
                OilProductsDistributionCompany.JSupplier Sup = new OilProductsDistributionCompany.JSupplier();
                Sup.GetData(Mal.SupplierCode);

                RepresentativeSupplierCode.Code = 0;
                RepresentativeSupplierCode.SQL
                   = @"SELECT CAP2.code, CAP2.Name+' _ '+CAP.Name AS Title FROM clsAllPerson  CAP
		                LEFT JOIN OilSupplier		OS		ON(OS.PCode		  = CAP.Code)
		                LEFT JOIN USERS				USR		ON(USR.pcode	  = CAP.Code)
		                LEFT JOIN organizationchart OC		ON(OC.user_code   = USR.code)
		                LEFT JOIN organizationchart OC2		ON(OC2.parentcode = OC.Code)
		                LEFT JOIN USERS				USR2	ON(USR2.Code	  = OC2.user_code)
		                LEFT JOIN clsAllPerson		CAP2	ON(USR2.pcode	  = CAP2.Code)
                    WHERE CAP2.Name Is Not Null  AND OS.Code =" + Sup.Code;

                OilProductsDistributionCompany.Failure.JAfterReviewing jAfterReviewing = new OilProductsDistributionCompany.Failure.JAfterReviewing();
                jAfterReviewing.GetDataByMalfunction(MalfunctionCode);
                Code = jAfterReviewing.Code;
            }
            else
            {
                RepresentativeSupplierCode.Code = 0;
                RepresentativeSupplierCode.SQL
                  = @"SELECT CAP2.code, CAP2.Name+' _ '+CAP.Name AS Title FROM clsAllPerson  CAP
		                LEFT JOIN OilSupplier		OS		ON(OS.PCode		  = CAP.Code)
		                LEFT JOIN USERS				USR		ON(USR.pcode	  = CAP.Code)
		                LEFT JOIN organizationchart OC		ON(OC.user_code   = USR.code)
		                LEFT JOIN organizationchart OC2		ON(OC2.parentcode = OC.Code)
		                LEFT JOIN USERS				USR2	ON(USR2.Code	  = OC2.user_code)
		                LEFT JOIN clsAllPerson		CAP2	ON(USR2.pcode	  = CAP2.Code)
                    WHERE CAP2.Name Is Not Null AND OS.Code Is Not Null";
            }

            if (!IsPostBack)
            {
                LoadDontFixDefects();
                ((WebControllers.MainControls.Date.JDateControl)txtInputDateTime).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtOutPutDateTime).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtGasStationManagerConfirmation).SetDate(DateTime.Now);
                txtTimeHour.Text = "07";
                txtTimeMinute.Text = "00";
                _SetForm();
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

        public void _SetForm()
        {
            if (Code > 0)
            {
                OilProductsDistributionCompany.Failure.JAfterReviewing AfterReviewing = new OilProductsDistributionCompany.Failure.JAfterReviewing();
                AfterReviewing.GetData(Code);

                rbFixDefects.SelectedValue = Convert.ToInt32(AfterReviewing.FixDefects).ToString();
                cmbDontFixDefects.SelectedValue = AfterReviewing.DontFixDefects.GetHashCode().ToString();
                txtDontFixDefectsComment.Text = AfterReviewing.DontFixDefectsComment;
                RepresentativeSupplierCode.Code = AfterReviewing.RepresentativeSupplierCode;
                ((WebControllers.MainControls.Date.JDateControl)txtInputDateTime).SetDate(AfterReviewing.InputDateTime);
                ((WebControllers.MainControls.Date.JDateControl)txtOutPutDateTime).SetDate(AfterReviewing.OutPutDateTime);
                // ((WebControllers.MainControls.JSearchPersonControl)GasStationManagerCode).PersonCode = AfterReviewing.GasStationManagerCode;
                ((WebControllers.MainControls.Date.JDateControl)txtGasStationManagerConfirmation).SetDate(AfterReviewing.GasStationManagerConfirmation);
                txtTimeHour.Text = AfterReviewing.GasStationManagerConfirmation.Hour.ToString();
                txtTimeMinute.Text = AfterReviewing.GasStationManagerConfirmation.Minute.ToString();
            }
        }

        public bool Save()
        {
            if (RepresentativeSupplierCode.Code > 0)
            {
                OilProductsDistributionCompany.Failure.JAfterReviewing AfterReviewing = new OilProductsDistributionCompany.Failure.JAfterReviewing();
                AfterReviewing.Code = Code;
                AfterReviewing.MalfunctionCode = MalfunctionCode;
                AfterReviewing.FixDefects = Convert.ToBoolean(Convert.ToInt32(rbFixDefects.SelectedValue));
                AfterReviewing.DontFixDefects = (OilProductsDistributionCompany.Failure.JDontFixDefects)Convert.ToInt32(cmbDontFixDefects.SelectedValue);
                AfterReviewing.DontFixDefectsComment = txtDontFixDefectsComment.Text;
                AfterReviewing.RepresentativeSupplierCode = RepresentativeSupplierCode.Code;
                AfterReviewing.InputDateTime = ((WebControllers.MainControls.Date.JDateControl)txtInputDateTime).GetDate();
                AfterReviewing.OutPutDateTime = ((WebControllers.MainControls.Date.JDateControl)txtOutPutDateTime).GetDate();
                // AfterReviewing.GasStationManagerCode = ((WebControllers.MainControls.JSearchPersonControl)GasStationManagerCode).PersonCode;

                DateTime ManagerConfrim = ((WebControllers.MainControls.Date.JDateControl)txtGasStationManagerConfirmation).GetDate();
                DateTime FinalManagerConfrim = new DateTime(ManagerConfrim.Year, ManagerConfrim.Month, ManagerConfrim.Day, Convert.ToInt32(txtTimeHour.Text), Convert.ToInt32(txtTimeMinute.Text), 0);

                AfterReviewing.GasStationManagerConfirmation = FinalManagerConfrim;


                if (MalfunctionCode > 0)
                {
                    OilProductsDistributionCompany.Failure.JMalfunction Malfunction = new OilProductsDistributionCompany.Failure.JMalfunction();
                    Malfunction.Code = MalfunctionCode;
                    Malfunction.GetData(MalfunctionCode);
                    Malfunction.Status = OilProductsDistributionCompany.Failure.JStatusMalfunction.Close;
                    Malfunction.update();
                }
                if (Code > 0)
                    return AfterReviewing.update();
                else
                    return AfterReviewing.Insert() > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                RedirectToMalfunction();
            else
                WebClassLibrary.JWebManager.ShowMessage("عملیات با خطا مواجه شد. پس از بررسی اطلاعات وارد شده مجددا سعی نمایید.");
        }

        protected void btnRefer_Click(object sender, EventArgs e)
        {
            if (Save())
                WebControllers.Automation.JAutomationRefer.ShowRefer(JMalfunctionUpdateControl.ConstClassName, 0, MalfunctionCode, OilProductsDistributionCompany.Failure.JMalfunctiones.GetDataTable(MalfunctionCode), ReferCode, "ارجاع خرابی بررسی شده");
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

        protected void rbFixDefects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbFixDefects.SelectedValue == "0" || rbFixDefects.SelectedValue == "1")
            {
                cmbDontFixDefects.Enabled = true;
                txtDontFixDefectsComment.Enabled = true;
            }
            else
            {
                txtDontFixDefectsComment.Text = string.Empty;
                cmbDontFixDefects.SelectedIndex = -1;
                cmbDontFixDefects.Enabled = false;
                txtDontFixDefectsComment.Enabled = false;
            }
        }
    }
}