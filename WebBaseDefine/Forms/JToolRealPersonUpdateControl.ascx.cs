using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBaseDefine.Forms
{
    public partial class JToolRealPersonUpdateControl : System.Web.UI.UserControl
    {
        #region Init
        /// ---------------------------------------------------------------------------
        int Code;
        /// ---------------------------------------------------------------------------
        #endregion Init

        #region Public
        /// ---------------------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            // int.TryParse(Request["Code"], out Code);

            _SetForm();

        }
        /// ---------------------------------------------------------------------------
        #endregion Public

        #region Methods
        /// ---------------------------------------------------------------------------
        public void _SetForm()
        {
            if (Code > 0)
            {
                ClassLibrary.JPerson jPerson = new ClassLibrary.JPerson(Code);

                txtName.Text = jPerson.Name;
                txtFam.Text = jPerson.Fam;
            }
        }
        /// ---------------------------------------------------------------------------
        public bool Save()
        {
            int tmp = 0;
            ClassLibrary.JPerson jPerson = new ClassLibrary.JPerson(Code);
            jPerson.Name = txtName.Text;
            jPerson.Fam = txtFam.Text;
            jPerson.FatherName = "_";
            jPerson.ShSh = "_";
            jPerson.PDesc = "_";
            jPerson._SharePCode = 0;

            jPerson.ShMeli = "_";
            jPerson.BthDate = DateTime.Now;
            jPerson._TafsiliCode = 0;
            // Birth Place0
            jPerson.BirthplaceCode = 0;
            // Issue Place (Sader)0
            jPerson.Sader = 0;
            // Gender (Male, Female)
            jPerson.Gender = (cmbGender.SelectedValue == "1" ? true : false);
            cmbGender.SelectedValue = (jPerson.Gender == true ? "1" : "0");

            // // // Home
            if (jPerson.HomeAddress == null) jPerson.HomeAddress = new JPersonAddress();
            jPerson.HomeAddress.Address = "_";
            jPerson.HomeAddress.City = 0;
            jPerson.HomeAddress.PostalCode = "_";
            jPerson.HomeAddress.Tel = "_";
            jPerson.HomeAddress.Fax = "_";
            jPerson.HomeAddress.Mobile = "_";
            jPerson.HomeAddress.Email = "_";

            // // // Work
            if (jPerson.WorkAddress == null) jPerson.WorkAddress = new JPersonAddress();
            jPerson.WorkAddress.Address = "_";
            jPerson.WorkAddress.City = 0;
            jPerson.WorkAddress.PostalCode = "_";
            jPerson.WorkAddress.Tel = "_";
            jPerson.WorkAddress.Fax = "_";
            jPerson.WorkAddress.WebSite = "_";
            jPerson.WorkAddress.Email = "_";



            if (Code > 0)
            {
                jPerson.Code = Code;
                if (jPerson.Update())
                    return true;
            }
            else
            {
                ViewState["Code"] = jPerson.insert();
                return (int)ViewState["Code"] > 0 ? true : false;
            }

            return false;
        }
        /// ---------------------------------------------------------------------------
        #endregion Methods

        #region Events
        /// ---------------------------------------------------------------------------
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Code = (int)ViewState["Code"];
                if (!string.IsNullOrEmpty(Request["Action"]) && !string.IsNullOrEmpty(Request["Parameters"]))
                {
                    var q = (new ClassLibrary.JAction("", Request["Action"], new object[] { int.Parse(Request["Parameters"]), Code }, null)).run();

                    if (!string.IsNullOrEmpty(Request["R_SUID"]) &&
                        !string.IsNullOrEmpty(Request["R_URL"]) &&
                        !string.IsNullOrEmpty(Request["R_Name"]) &&
                        !string.IsNullOrEmpty(Request["R_ReferCode"]))

                        // انتقال به صفحه مورد نظر بعد از ثبت
                        WebClassLibrary.JWebManager.LoadControl(
                                   Request["R_SUID"],
                                   Request["R_URL"],
                                   Request["R_Name"],
                                   new List<Tuple<string, string>> { new Tuple<string, string>("ReferCode", Request["R_ReferCode"]) },
                                   WebClassLibrary.WindowTarget.CurrentWindow,
                                   false, true, false, 0, 0, false);
                }
                else
                {
                    var q = (new ClassLibrary.JAction("", Request["Action"], new object[] { Code }, null)).run();
                }
            }
            else
                WebClassLibrary.JWebManager.ShowMessage("امکان ذخیره اطلاعات وجود ندارد. لطفا پس از بررسی مجددا سعی نمایید.");
        }
        /// ---------------------------------------------------------------------------
        #endregion Events
    }
}
