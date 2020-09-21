using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassLibrary;
using WebClassLibrary.Authentication;

namespace WebERP
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebClassLibrary.JWebManager.Configure();
            if (Page.IsPostBack)
            {
            }
            else
            {
                hdfasp.Value = "";
            }
        }

        private void SendSms(string code, string mobileNumber)
        {

            ClassLibrary.JSMSSend jss = new ClassLibrary.JSMSSend();
            jss.Mobile = mobileNumber;
            jss.Text = "کد زیر را وارد کنید تا تایید شوید.  " + code;
            jss.SendDate = jss.RegDate = DateTime.Now;
            jss.Project = "AVL";
            jss.Description = "Verification code";
            jss.ClassName = "AVL";
            jss.Code = jss.Insert();
        }

        int vercode = 0;
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!RadCaptcha1.IsValid) return;
            if (WebClassLibrary.Authentication.Authentication.Authenticate(txtUserlogin.Text, txtPassLogin.Text))
            {
                if (!WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin)
                    if (true)//new AVL.UserVerify.JUserVarify() { userID = ClassLibrary.JEnryption.EncryptStr(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode.ToString()) }.Varified())
                        Response.Redirect("~/Default.aspx?f=mp");
                    else
                    {
                        lblVarifyError.Visible = true;
                        pnlVarify.Visible = true;
                        lblVerificationCode.Visible = true;
                        txtVerificationCode.Visible = true;
                        btnVerificationCode.Visible = true;
                        Button1.Visible = true;
                        string code = new Random().Next(0, 99999).ToString();
                        string phone = new ClassLibrary.JPersonAddress(WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode).Mobile;
                        SendSms(code, phone);
                        hdfasp.Value = ClassLibrary.JEnryption.EncryptStr(code);
                        hdmasp.Value = ClassLibrary.JEnryption.EncryptStr(phone);
                        txtChangeNumber.Text = phone;
                        hduasp.Value = ClassLibrary.JEnryption.EncryptStr(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode.ToString());
                        WebClassLibrary.SessionManager.Current.Dispose();
                    }
                else
                    Response.Redirect("~/Default.aspx?f=mp");
            }
            else
            {
                lblError.Visible = true;
                lnkForgetPass.Visible = true;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            pnlForgetPass.Visible =
            lblVarifyError.Visible =
            lblError.Visible = false;
            RadCaptcha1.ErrorMessage = "";

            if (string.IsNullOrEmpty(hdfasp.Value))
            {
                txtVerificationCode.Visible = true;
                lblVerificationCode.Visible = true;
                btnVerificationCode.Visible = true;
                vercode = new Random().Next(99999);
                hdfasp.Value = ClassLibrary.JEnryption.EncryptStr(vercode.ToString());
            }



            ClassLibrary.JPerson person = new ClassLibrary.JPerson();
            person.Name = txtName.Text;
            person.Fam = txtLastname.Text;
            person.ShMeli = "";
            person.FatherName = "";
            person.ShSh = "";
            person.PDesc = "";

            Globals.JUser user = new Globals.JUser();
            user.Active = true;
            user.PCode = person.insertAVL(false, false);
            user.username = txtUsername.Text;
            user.password = txtPassword.Text;
            //user.code = person.insert();

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
            {
                if ((user.code = user.insertAVL(false)) != 0)
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

                        if (jss.Code > 0)
                        {
                            Employment.JEOrganizationChart oc = new Employment.JEOrganizationChart();
                            oc.user_code = user.code;
                            oc.parentcode = 0;
                            if (oc.InsertNode())//false))
                            {
                                ClassLibrary.JPermissionGroupUsers gu = new ClassLibrary.JPermissionGroupUsers();
                                gu.User_Post_Code = oc.code;
                                gu.GroupCode = 1;// کد گروه
                                gu.Insert(false);
                                //if (gu.InsertAVL(false) > 0)
                                //{
                                global::AVL.ObjectList.JObjectList ol = new global::AVL.ObjectList.JObjectList();
                                ol.ClassName = "ClassLibrary.JPerson";
                                ol.DynamicObjectCode = 0;
                                ol.Label = person.Name + " " + person.Fam;
                                ol.Type = "شخص";
                                ol.ObjectCode = person.Code;
                                ol.personCode = user.code;
                                ol.RegisterDateTime = DateTime.Now;
                                global::AVL.ObjectList.JObjectListTable olt = new global::AVL.ObjectList.JObjectListTable();
                                olt.SetValueProperty(ol);
                                ol.Code = olt.Insert();
                                if (ol.Code > 0)
                                {

                                    Accounting.Cash.JCash jCash = new Accounting.Cash.JCash();
                                    jCash.paid=(50000);
                                    jCash.userCode=(user.code);
                                    jCash.Insert(true);
                                    lblError.Visible = false;
                                    pnlVarify.Visible = true;
                                    RadCaptcha1.ErrorMessage = "";
                                    hdmasp.Value = ClassLibrary.JEnryption.EncryptStr(txtMobile.Text);
                                    hduasp.Value = ClassLibrary.JEnryption.EncryptStr(user.code.ToString());
                                }
                                else
                                {
                                    gu.delete(false);
                                    oc.DeleteNode();
                                    jss.Delete();
                                    pa.Delete(pa.Code);
                                    user.DeleteAVL(user.code, false);
                                    person.DeleteAVL(person.Code, null, true, false);
                                }
                                //}
                                //else
                                //{
                                ////    oc.DeleteNode();
                                ////    jss.Delete();
                                ////    pa.Delete(pa.Code);
                                ////    user.DeleteAVL(user.code, false);
                                ////    person.DeleteAVL(person.Code, null, true, false);
                                //}
                            }
                            else
                            {
                                jss.Delete();
                                pa.Delete(pa.Code);
                                user.DeleteAVL(user.code, false);
                                person.DeleteAVL(person.Code, null, true, false);
                            }
                        }
                        else
                        {
                            pa.Delete(pa.Code);
                            user.DeleteAVL(user.code, false);
                            person.DeleteAVL(person.Code, null, true, false);
                        }
                    }
                    else
                    {
                        user.DeleteAVL(user.code, false);
                        person.DeleteAVL(person.Code, null, true, false);
                    }
                }
                else
                {
                    //Exception er = WebClassLibrary.SessionManager.Current.MainFrame.Except.GetByIndex(WebClassLibrary.SessionManager.Current.MainFrame.Except.Count - 1);
                    //if (er.Message == "UserNameRepeated")
                    //{
                    //}
                    //else if (er.Message == "PersonRepeated")
                    //{
                    //     lblDuplicatedPerson.Visible = true;
                    //}
                    person.DeleteAVL(person.Code, null, true, false);
                }
            }
            else
            {
                //    Exception er = WebClassLibrary.SessionManager.Current.MainFrame.Except.GetByIndex(WebClassLibrary.SessionManager.Current.MainFrame.Except.Count - 1);
                //    if (er.Message == "UserNameRepeated")
                //    {
                //        lblDuplicatedUsername.Visible = true;
                //    }
                //    else if (er.Message == "PersonExists")
                //    {
                //}

            }
        }

        protected void btnVerificationCode_Click(object sender, EventArgs e)
        {
            if (hdfasp.Value == ClassLibrary.JEnryption.EncryptStr(txtVerificationCode.Text))
            {

                ClassLibrary.JPersonAddress jPersonAddress = new ClassLibrary.JPersonAddress();
                jPersonAddress.getData(ClassLibrary.JEnryption.DecryptStr(this.hdmasp.Value));
                this.hdmasp.Value = ClassLibrary.JEnryption.EncryptStr(this.txtChangeNumber.Text);
                jPersonAddress.Mobile = this.txtChangeNumber.Text;
                jPersonAddress.Update();

                ClassLibrary.EMail.JEMailSend email = new ClassLibrary.EMail.JEMailSend();
                email.EmailCode = 1;
                email.MessageTo = txtEmail.Text;
                email.Subject = "تایید کاربر";
                email.Text = string.Format(@" شماره همراه شما تایید شد. برای تایید شدن ایمیل بر روی لینک کلیک کنید. 
            tsavl.ir/EmailVarification.aspx?q={0}&n={1}&s={2}",
                 hduasp.Value,
                  hdmasp.Value,
                 ClassLibrary.JEnryption.EncryptStr(txtEmail.Text));
                email.DateSent = DateTime.Now;
                email.Code = email.Insert();

                btnRegister.Enabled = false;

                AVL.UserVerify.JUserVarify userarify = new AVL.UserVerify.JUserVarify();
                userarify.email = ClassLibrary.JEnryption.EncryptStr(txtEmail.Text);
                userarify.phonenumber = hdmasp.Value;
                userarify.userID = hduasp.Value;
                userarify.phoneVarified = true;
                userarify.emailVarified = false;
                userarify.Insert();

                userarify.VarifyPhonenumber();

                WebClassLibrary.JWebManager.RunClientScript("alert('اکانت کاربری شما تایید شد.');", "ConfirmDialog");


                Globals.JUser user = new Globals.JUser(int.Parse(ClassLibrary.JEnryption.DecryptStr(userarify.userID)));
                if (WebClassLibrary.Authentication.Authentication.Authenticate(user.username, ClassLibrary.JEnryption.DecryptStr(user.password)))
                {
                    Response.Redirect("~/Default.aspx?f=t");
                }
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('کداشتباه است.');", "ConfirmDialog");
            }
        }
        protected void RadCaptcha1_CaptchaValidate(object sender, Telerik.Web.UI.CaptchaValidateEventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.SendSms(ClassLibrary.JEnryption.DecryptStr(this.hdfasp.Value), this.txtChangeNumber.Text);
        }

        protected void lnkForgetPass_Click(object sender, EventArgs e)
        {
            pnlForgetPass.Visible = true;
        }

        /// <summary>
        /// Forget password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            ClassLibrary.JPersonAddress pa = new ClassLibrary.JPersonAddress();
            pa.getData(txtForgetpassMobile.Text,false);
            if (pa.Code < 1)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('این شماره تماس ثبت نشده است یا اشتباه است');", "ConfirmDialog");
                return;
            }
            ClassLibrary.JSMSSend jss = new ClassLibrary.JSMSSend();
            jss.Mobile = pa.Mobile;
            Globals.JUser user = new Globals.JUser(pa.PCode, true);
            jss.Text = "   نام کاربری: " + user.username + "   کلمه عبور: " + ClassLibrary.JEnryption.DecryptStr(user.password);
            jss.SendDate = jss.RegDate = DateTime.Now;
            jss.Project = "AVL";
            jss.Description = "Forget password and username";
            jss.ClassName = "AVL";
            jss.Code = jss.Insert();
            WebClassLibrary.JWebManager.RunClientScript("alert('اطلاعات کاربری برای شما ارسال گردید.');", "ConfirmDialog");
            pnlForgetPass.Visible = false;
        }
        protected void vldEmailDuplicate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                ClassLibrary.JPersonAddress jPersonAddress = new ClassLibrary.JPersonAddress();
                jPersonAddress.getData(args.Value, true);
                if (jPersonAddress.Code > 0)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            catch (Exception)
            {
                args.IsValid = false;
            }
        }
        protected void vldMobileDuplicate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                ClassLibrary.JPersonAddress jPersonAddress = new ClassLibrary.JPersonAddress();
               jPersonAddress.getData(args.Value);
                if (jPersonAddress.Code > 0)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            catch (Exception)
            {
                args.IsValid = false;
            }
        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
              Globals.JUser jUser = new Globals.JUser();
                jUser.GetData(args.Value);
                if (jUser.code > 0)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            catch
            {
                args.IsValid = false;
            }
        }
    }
}