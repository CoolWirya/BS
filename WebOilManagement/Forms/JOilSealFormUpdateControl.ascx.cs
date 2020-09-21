using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebOilManagement.Forms
{
    public partial class JOilSealFormUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        int GSID;
        protected global::WebControllers.MainControls.JCustomListSelectorControl personTechnicalTeamResponsible;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            int.TryParse(Request["GSID"], out GSID);

            _SetForm();

            if (GSID != 0 && cmbGasStation.FindItemByValue(GSID.ToString()) != null)
            {
                cmbGasStation.FindItemByValue(GSID.ToString()).Selected = true;
                cmbGasStation.Enabled = false;

                OilProductsDistributionCompany.GasStation.JGasStation GS = new OilProductsDistributionCompany.GasStation.JGasStation();
                GS.GetData(GSID);

                OilProductsDistributionCompany.JSupplier Sup = new OilProductsDistributionCompany.JSupplier();
                Sup.Code = Sup.FindByGSCode(GS.Code);

                personTechnicalTeamResponsible.Code = 0;
                //                personTechnicalTeamResponsible.SQL
                //                    = @"SELECT CAP2.Name FROM clsAllPerson  CAP
                //		                LEFT JOIN OilSupplier		OS		ON(OS.PCode		  = CAP.Code)
                //		                LEFT JOIN USERS				USR		ON(USR.pcode	  = CAP.Code)
                //		                LEFT JOIN organizationchart OC		ON(OC.user_code   = USR.code)
                //		                LEFT JOIN organizationchart OC2		ON(OC2.parentcode = OC.Code)
                //		                LEFT JOIN USERS				USR2	ON(USR2.Code	  = OC2.user_code)
                //		                LEFT JOIN clsAllPerson		CAP2	ON(USR2.pcode	  = CAP2.Code)
                //                    WHERE CAP2.Name Is Not Null AND OS.Code =" + Sup.Code;

                personTechnicalTeamResponsible.SQL
                    = @"SELECT CAP2.code, CAP2.Name+' _ '+CAP.Name AS Title FROM clsAllPerson  CAP
		                LEFT JOIN OilSupplier		OS		ON(OS.PCode		  = CAP.Code)
		                LEFT JOIN USERS				USR		ON(USR.pcode	  = CAP.Code)
		                LEFT JOIN organizationchart OC		ON(OC.user_code   = USR.code)
		                LEFT JOIN organizationchart OC2		ON(OC2.parentcode = OC.Code)
		                LEFT JOIN USERS				USR2	ON(USR2.Code	  = OC2.user_code)
		                LEFT JOIN clsAllPerson		CAP2	ON(USR2.pcode	  = CAP2.Code)
                    WHERE CAP2.Name Is Not Null  AND OS.Code =" + Sup.Code;

                if (GS.OwnerCode != 0)
                    ((WebControllers.MainControls.JSearchPersonControl)personGasStationManager).PersonCode = GS.OwnerCode;
            }
            else
            {
                personTechnicalTeamResponsible.Code = 0;
                personTechnicalTeamResponsible.SQL
                    = @"SELECT CAP2.code, CAP2.Name+' _ '+CAP.Name AS Title FROM clsAllPerson  CAP
		                LEFT JOIN OilSupplier		OS		ON(OS.PCode		  = CAP.Code)
		                LEFT JOIN USERS				USR		ON(USR.pcode	  = CAP.Code)
		                LEFT JOIN organizationchart OC		ON(OC.user_code   = USR.code)
		                LEFT JOIN organizationchart OC2		ON(OC2.parentcode = OC.Code)
		                LEFT JOIN USERS				USR2	ON(USR2.Code	  = OC2.user_code)
		                LEFT JOIN clsAllPerson		CAP2	ON(USR2.pcode	  = CAP2.Code)
                    WHERE CAP2.Name Is Not Null  AND OS.Code Is Not Null";
            }

        }

        private void LoadcmbSeal()
        {
            cmbSeal.DataSource = OilProductsDistributionCompany.Seal.JSeales.GetDataTableNotInSealForm(Code);
            cmbSeal.DataTextField = "Serial";
            cmbSeal.DataValueField = "Code";
            cmbSeal.DataBind();
        }

        public void _SetForm()
        {
            cmbGasStation.DataSource = OilProductsDistributionCompany.GasStation.JGasStationes.GetTitles();
            cmbGasStation.DataTextField = "Title";
            cmbGasStation.DataValueField = "Code";
            cmbGasStation.DataBind();

            cmbSealStatus.DataSource = WebClassLibrary.JWebDataBase.TranslateColumns(WebClassLibrary.JDataManager.EnumToDataTable(typeof(OilProductsDistributionCompany.Seal.JStatusSeal)), "Key");
            cmbSealStatus.DataTextField = "Key";
            cmbSealStatus.DataValueField = "Value";
            cmbSealStatus.DataBind();



            if (Code > 0)
            {
                cmbPlaceSealed.DataSource = WebClassLibrary.JWebDataBase.TranslateColumns(WebClassLibrary.JDataManager.EnumToDataTable(typeof(OilProductsDistributionCompany.Seal.JPlaceSealed)), "Key");
                cmbPlaceSealed.DataTextField = "Key";
                cmbPlaceSealed.DataValueField = "Value";
                cmbPlaceSealed.DataBind();

                cmbNozzle.DataSource = OilProductsDistributionCompany.Nozzle.JNozzleses.GetTitles();
                cmbNozzle.DataTextField = "Title";
                cmbNozzle.DataValueField = "Code";
                cmbNozzle.DataBind();

                OilProductsDistributionCompany.Seal.JFormSeal jFormSeal = new OilProductsDistributionCompany.Seal.JFormSeal();
                jFormSeal.GetData(Code);
                ((WebControllers.MainControls.Date.JDateControl)dteAction).SetDate(jFormSeal.DatesOfOperation);
                txtFormSealCode.Text = jFormSeal.FormSealSerial;
                cmbGasStation.SelectedValue = jFormSeal.GasStationCode.ToString();
                ((WebControllers.MainControls.JSearchPersonControl)personGasStationManager).PersonCode = jFormSeal.GasStationManagerCode;
                personTechnicalTeamResponsible.Code = jFormSeal.ResponsibleForTheTechnicalTeamCode;
                txtInSerial.Text = jFormSeal.Serial;
                txtUnSerial.Text=jFormSeal.UnSerial;
                LoadSealGrid();
            }
            else
                rpvSealDetails.Visible = false;
        }

        public bool Save()
        {
            OilProductsDistributionCompany.Seal.JFormSeal jFormSeal = new OilProductsDistributionCompany.Seal.JFormSeal();
            jFormSeal.Code = Code;
            jFormSeal.DatesOfOperation = ((WebControllers.MainControls.Date.JDateControl)dteAction).GetDate();
            jFormSeal.FormSealSerial = txtFormSealCode.Text;
            jFormSeal.GasStationCode = Convert.ToInt32(cmbGasStation.SelectedValue);
            jFormSeal.GasStationManagerCode = ((WebControllers.MainControls.JSearchPersonControl)personGasStationManager).PersonCode;
            jFormSeal.ResponsibleForTheTechnicalTeamCode = personTechnicalTeamResponsible.Code;
            jFormSeal.Serial = txtInSerial.Text;
            jFormSeal.UnSerial = txtUnSerial.Text;

            if (Code > 0)
                return jFormSeal.Update();
            else
                return jFormSeal.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                if (GSID == 0)
                    WebClassLibrary.JWebManager.CloseAndRefresh();
                else
                    WebClassLibrary.JWebManager.CloseWindow();
            }
        }

        private void LoadSealGrid()
        {
            grdSeal.DataSource = OilProductsDistributionCompany.Seal.JFormSealDetailses.GetDataTableByFormSealCode(Code);
            grdSeal.DataBind();
        }

        protected void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (cmbSeal.SelectedItem == null) return;
            OilProductsDistributionCompany.Seal.JFormSealDetails jFormSealDetails = new OilProductsDistributionCompany.Seal.JFormSealDetails();
            jFormSealDetails.GetData(Code);
            jFormSealDetails.FormSealCode = Code;
            jFormSealDetails.NozzleCode = Convert.ToInt32(cmbNozzle.SelectedValue);
            jFormSealDetails.PlaceSealed = (OilProductsDistributionCompany.Seal.JPlaceSealed)Convert.ToInt32(cmbPlaceSealed.SelectedValue);
            jFormSealDetails.SealCode = Convert.ToInt32(cmbSeal.SelectedValue);
            jFormSealDetails.Status = (OilProductsDistributionCompany.Seal.JStatusSeal)Convert.ToInt32(cmbSealStatus.SelectedValue);
            if (jFormSealDetails.Insert() > 0)
            {
                LoadcmbSeal();
            }

            LoadSealGrid();
        }

        protected void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            int x = 0;
            int.TryParse(Request["radGridClickedRowIndex"], out x);
            if (x >= ((DataTable)grdSeal.DataSource).Rows.Count) return;
            int code = Convert.ToInt32(((DataTable)grdSeal.DataSource).Rows[x]["Code"]);
            OilProductsDistributionCompany.Seal.JFormSealDetails jFormSealDetails = new OilProductsDistributionCompany.Seal.JFormSealDetails();
            jFormSealDetails.Code = code;
            jFormSealDetails.Delete();

            LoadcmbSeal();
            LoadSealGrid();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OilProductsDistributionCompany.Seal.JSeal jSeal = new OilProductsDistributionCompany.Seal.JSeal();
            jSeal.Code = Code;
            jSeal.Delete();
        }

        protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            switch (e.Tab.PageViewID)
            {
                case "rpvSealForm":

                    break;

                case "rpvSealDetails":
                    LoadcmbSeal();
                    break;

            }
        }
    }
}