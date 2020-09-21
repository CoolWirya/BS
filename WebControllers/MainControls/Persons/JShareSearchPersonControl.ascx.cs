using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls
{
    public partial class JShareSearchPersonControl : System.Web.UI.UserControl
    {
        int _CompanyCode = 1;
        public string Guid;
        public int CompanyCode
        {
            get
            {
                return _CompanyCode;
            }
            set
            {
                _CompanyCode = value;
            }
        }
        JPersonTypes _PersonType = new JPersonTypes();
        public JPersonTypes PersonType
        {
            set
            {
                _PersonType = value;
            }
        }
        public bool isReadOnly
        {
            set
            {
                if (value == true)
                {
                    //btnSearch.Visible = false;
                    //txtPersonCode.Enabled = false;
                }
                else
                {
                   // btnSearch.Visible = true;
                    //txtPersonCode.Enabled = true;
                }
            }
        }

        public string PersonName
        {
            get
            {
                return lblRealPersonName.Text + " " + lblLastName.Text;
            }
        }
        public int PersonCode;
        //{
        //    get
        //    {
        //        int d;
        //        int.TryParse(txtPersonCode.Text, out d);
        //        return d;
        //    }
        //    set
        //    {
        //        if (value != 0)
        //        {
        //            txtPersonCode.Text = value.ToString();
        //            if (_PersonType == JPersonTypes.RealPerson)
        //            {
        //                JPerson JDP = new JPerson();
        //                if (JDP.getData(value))
        //                {
        //                    pnlLegalPersonDetails.Style.Add("display", "none");
        //                    pnlRealPersonDetails.Style.Add("display", "block");
        //                    pnlOtherPersonDetails.Style.Add("display", "none");
        //                    lblRealPersonName.Text = JDP.Name;
        //                    lblLastName.Text = JDP.Fam;
        //                    lblIDNo.Text = JDP.ShSh;
        //                    lblFatherName.Text = JDP.FatherName;
        //                    lblBrthDate.Text = JDateTime.FarsiDate(JDP.BthDate);
        //                    lblNationalNo.Text = JDP.ShMeli;
        //                }
        //            }
        //            else if (_PersonType == JPersonTypes.OtherPerson)
        //            {
        //                JOtherPerson JDP = new JOtherPerson();
        //                if (JDP.GetData(value))
        //                {
        //                    JPersonAddress tmpAddress = new JPersonAddress(value, JAddressTypes.Home);
        //                    pnlLegalPersonDetails.Style.Add("display", "none");
        //                    pnlRealPersonDetails.Style.Add("display", "none");
        //                    pnlOtherPersonDetails.Style.Add("display", "block");
        //                    lblTitle.Text = JDP.Title;
        //                    lblPhone.Text = JDP.Phone;
        //                    lblAddress.Text = JDP.Address;
        //                    lblDesc.Text = JDP.Description;
        //                    lblMobile.Text = tmpAddress.Mobile;
        //                }
        //            }
        //            else
        //            {
        //                JOrganization JOrg = new JOrganization();
        //                if (JOrg.GetData(value))
        //                {
        //                    pnlLegalPersonDetails.Style.Add("display", "block");
        //                    pnlRealPersonDetails.Style.Add("display", "none");
        //                    pnlOtherPersonDetails.Style.Add("display", "none");
        //                    lblLegalPersonName.Text = JOrg.Name;
        //                    lblRegNo.Text = JOrg.RegisterNo;
        //                    lblSubject.Text = JOrg.Subject;
        //                    lblType.Text = (new JSubBaseDefine(ClassLibrary.JBaseDefine.CompanyTypes, JOrg.CompanyType)).Name;
        //                    lblRegPlace.Text = JOrg.RegisterPlaceText;
        //                    lblEcoNo.Text = JOrg.CommercialCode;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            txtPersonCode.Text = "";
        //            lblRealPersonName.Text = "";
        //            lblLastName.Text = "";
        //            lblIDNo.Text = "";
        //            lblFatherName.Text = "";
        //            lblBrthDate.Text = "";
        //            lblNationalNo.Text = "";
        //        }
        //    }
        //}
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            #region txtPersonCode_Settings
            //JJson.JsonResponse txtPersonCode_res = new JJson.JsonResponse();
            //txtPersonCode_res.Type = JJson.JsonResponseType.Item;
            //txtPersonCode_res.Params = new List<JJson.JsonResponseParam>();
            //txtPersonCode_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = txtPersonName.ClientID, Action = JJson.JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
            //txtPersonCode.OnSuccessControlsAction = new List<JJson.JsonResponse>() { txtPersonCode_res };
            //JJson.JsonRequest txtPersonCode_req = new JJson.JsonRequest();
            //txtPersonCode_req.URL = "WebControllers/MainControls/CustomListSelector/JCustomListSelectorService.asmx/Run";////GetTitleByCode";
            //txtPersonCode_req.Type = JJson.JsonRequestType.SQL;
            //txtPersonCode_req.data = "Select Name from clsAllPerson Where Code =@code";
            //txtPersonCode_req.Params = new List<JJson.JsonRequestParam>();
            //txtPersonCode_req.Params.Add(new JJson.JsonRequestParam() { Name = "@code", Type = JJson.JsonAction.Value, ControlID = txtPersonCode.ClientID });
            //txtPersonCode.Request = new List<JJson.JsonRequest>() { txtPersonCode_req };
            //JJson.JsonResponse txtPersonCode_error = new JJson.JsonResponse();
            //txtPersonCode_error.Params = new List<JJson.JsonResponseParam>();
            //txtPersonCode_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            //txtPersonCode.OnErrorControlsAction = new List<JJson.JsonResponse>() { txtPersonCode_error };
            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid = System.Guid.NewGuid().ToString("N");
            //Telerik.Web.UI.RadAjaxManager manager = Telerik.Web.UI.RadAjaxManager.GetCurrent(Page);
            //manager.ClientEvents.OnRequestStart = "onRequestStart";
            //manager.ClientEvents.OnResponseEnd = "onResponseEnd";
            //manager.AjaxRequest += manager_AjaxRequest;

            //btnSearch.OnClientClicked = "CallShowMenu_" + txtPersonCode.ClientID;
        }

       
        protected void btnUnSelect_Click(object sender, EventArgs e)
        {
            //PersonCode = 0;
            //txtPersonCode.Text = "";
            lblRealPersonName.Text = "";
            lblLastName.Text = "";
            lblIDNo.Text = "";
            lblFatherName.Text = "";
            lblBrthDate.Text = "";
            lblNationalNo.Text = "";
        }

        //protected void txtPersonCode_TextChanged(object sender, EventArgs e)
        //{
        //    if (!_ShowDetails)
        //    {
        //        System.Data.DataTable dt = new System.Data.DataTable();
        //        dt = WebClassLibrary.JWebDataBase.GetDataTable("Select Code, Name from clsAllPerson Where Code =" + txtPersonCode.Text, true);
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            txtPersonName.Text = dt.Rows[0]["Name"].ToString();
        //        }
        //        else
        //        {
        //            txtPersonCode.Text = string.Empty;
        //            txtPersonName.Text = string.Empty;
        //        }
        //    }
        //    else //Show Details
        //    {
        //        if (_PersonType == JPersonTypes.RealPerson)
        //        {
        //            JPerson JDP = new JPerson();
        //            if (JDP.getData(Int32.Parse(txtPersonCode.Text)))
        //            {
        //                lblName.Text = JDP.Name;
        //                lblLastName.Text = JDP.Fam;
        //                lblIDNo.Text = JDP.ShSh;
        //                lblFatherName.Text = JDP.FatherName;
        //                lblBrthDate.Text = JDateTime.FarsiDate(JDP.BthDate);
        //                lblNationalNo.Text = JDP.ShMeli;
        //            }
        //            else
        //            {
        //                txtPersonCode.Text = string.Empty;
        //                lblName.Text = string.Empty;
        //                lblLastName.Text = string.Empty;
        //                lblIDNo.Text = string.Empty;
        //                lblFatherName.Text = string.Empty;
        //                lblBrthDate.Text = string.Empty;
        //                lblNationalNo.Text = string.Empty;
        //            }
        //        }
        //    }
        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //grdPersons.DataSource = WebClassLibrary.JWebDataBase.GetDataTable("Select Code, Name from clsAllPerson Where Name like N'%" + txtSearch.Text.Replace("'", "''") + "%' order by Name", true);
            //grdPersons.Rebind();
        }
    }
}