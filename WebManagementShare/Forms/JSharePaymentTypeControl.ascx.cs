using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebManagementShare.Forms
{
    public partial class JSharePaymentTypeControl : System.Web.UI.UserControl
    {
        public string ShareHolderStr = "";
        public string ShareHolderStrStatus = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetForm();
                CheckStatus();
            }
            GetPersonList();
        }

        public void GetPersonList()
        {
            ClassLibrary.JPerson person = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPerson;
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusReports_JBusReports");
            jGridView.SQL = @"Select a.Code,Cap.Name from [dbo].[Propperty_ClassName_ClassLibrary.FormManagers_2] a 
                                left join clsallperson cap on cap.code = a.[ObjectCode]
                                where a.[تایید] like N'%افزایش تعداد سهام%'";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 4;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JSharePaymentTypeControl";
            //jGridView.Buttons = "excel";
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).LoadGrid(true);
        }

        public void CheckStatus()
        {
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from [dbo].[Propperty_ClassName_ClassLibrary.FormManagers_2] where [ObjectCode] = "
                + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode);
            if (Dt != null & Dt.Rows.Count > 0)
            {
                editemode.Value = "1";
                btnSave.Visible = false;
                RbSaham.Visible = false;
                RbPool.Visible = false;
                ShareHolderStrStatus = "انتخاب شما : " + Dt.Rows[0]["تایید"].ToString();
                btnClose.Text = "خروج";
            }
            else
            {
                editemode.Value = "0";
            }
        }

        public void SetForm()
        {
            ClassLibrary.JPerson person = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPerson;
            Finance.JBankAccount BanckAcc = new Finance.JBankAccount();
            BanckAcc.GetData(person.Code);
            int ShareCount = ManagementShares.JShareSheets.GetSumPersonSheet(person.Code);
            ShareHolderStr = "مشخصات سهامدار <div style='clear:both;height:5px'></div> نام و نام خانوادگی : " + person.Name + " " + person.Fam + "<div style='clear:both;height:3px'></div>" +
                "نام پدر : " + person.FatherName + "<div style='clear:both;height:3px'></div> کد ملی : " + person.ShMeli + "<div style='clear:both;height:3px'></div> شماره حساب : " + BanckAcc.AccountNo +
                "<div style='clear:both;height:3px'></div> بانک : " + BanckAcc.Branch + "<div style='clear:both;height:5px'></div>";
        }

        public bool Save()
        {
            string ChoiceText = "";
            if (RbPool.Checked)
                ChoiceText = "اینجانب ضمن تایید مشخصات فوق درخواست می نمایم سود تعلق گرفته سهام به حساب بانکی خودم واریز گردد";
            else
                ChoiceText = "اینجانب ضمن تایید مشخصات فوق متقاضی افزایش تعداد سهام از محل سود تعلق گرفته می باشم";
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            db.setQuery(@"INSERT INTO [dbo].[Propperty_ClassName_ClassLibrary.FormManagers_2]
                           ([Code]
                           ,[ObjectCode]
                           ,[متن__نمایش]
                           ,[تایید])
                     VALUES
                           ((select ISNULL(Max(code),0)+1 from [dbo].[Propperty_ClassName_ClassLibrary.FormManagers_2])
                           ," + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode + @"
                           ,Null
                           ,N'" + ChoiceText + @"')");
            return db.Query_Execute() >= 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                CheckStatus();
            }
        }
    }
}