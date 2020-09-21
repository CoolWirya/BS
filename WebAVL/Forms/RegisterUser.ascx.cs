using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class RegisterUser : System.Web.UI.UserControl
    {
        int vercode = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {

            }
            else
                hdfasp.Value = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(hdfasp.Value))
            {
                txtVerificationCode.Visible = true;
                lblVerificationCode.Visible = true;
                btnVerificationCode.Visible = true;
                vercode = new Random().Next(99999);
                hdfasp.Value = ClassLibrary.JEnryption.EncryptStr(vercode.ToString());
            }
            else
            {

            }
            ClassLibrary.JPerson person = new ClassLibrary.JPerson();
            person.Name = txtName.Text;
            person.Fam = txtLastname.Text;
            person.ShMeli = "";
            person.FatherName = "";
            person.ShSh = "";
            person.PDesc = "";
            
            Globals.JUser user = new Globals.JUser();
            user.Active=true;
            user.PCode = person.insertAVL(false,false);
            user.username = txtUsername.Text;
            user.password = txtPassword.Text;
            //user.code = user.insert();

            ClassLibrary.JPersonAddress pa = new ClassLibrary.JPersonAddress();
            pa.Email = txtEmail.Text;
            pa.Mobile = txtMobile.Text;
            pa.PCode = user.PCode;
            pa.Address = "";
            pa.AddressType = ClassLibrary.JAddressTypes.Work;
            pa.PostalCode = "";
            pa.Tel = "";
            pa.WebSite = "";
            pa.Fax = "";
            pa.ClassName = "AVL";
            if (user.PCode != 0)
                if (user.insertAVL(false) != 0)
                {
                    if (pa.Insert() != 0)
                    {
                        //SMS will be sent.
                        ClassLibrary.JSMSSend jss = new ClassLibrary.JSMSSend();
                        jss.Mobile = pa.Mobile;
                        jss.Text = "کد زیر را وارد کنید تا تایید شوید.  " + vercode.ToString();
                        jss.SendDate = jss.RegDate = DateTime.Now;
                        jss.Project = "AVL";
                        jss.Description = "Verification code";
                        jss.ClassName = "AVL";
                        jss.Code = jss.Insert();
                    }
                }
            string[] s = ClassLibrary.JSystem.Except.GetAll();
        }

        protected void btnVerificationCode_Click(object sender, EventArgs e)
        {
            if (hdfasp.Value == ClassLibrary.JEnryption.EncryptStr(txtVerificationCode.Text))
            {
                ClassLibrary.EMail.JEMailSend email = new ClassLibrary.EMail.JEMailSend();
                email.MessageTo = txtEmail.Text;
                email.Subject = "تایید کاربر";
                email.Text = "پنل کاربری شما در سیستم تایید شد. با تشکر از حسن انتخاب شما.";
                email.DateSent = DateTime.Now;
                email.Code = email.Insert();
                Response.Redirect("~/Default.aspx");
            }
        }

    }
}