using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JBusPayOffUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBus();
            }
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = dt;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            hidBusCode.Value = cmbBus.SelectedValue;
            GetReport(Int32.Parse(cmbBus.SelectedValue));
        }

        void GetReport(int BusCode)
        {
            int SelectP = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(
                    (
                                @"with cte as(
                                select fcc.value TafsiliCode, cap.Name OwnerName , abo.startDate, fba.AccountNo,
                                (select isnull(sum(TCount), 0) from AUTShiftDriver sd where sd.BusNumber = bus.BusNumber) Transactions, 
                                (select isnull(sum(Price), 0) from AUTDailyPerformanceRportOnBus adpr where adpr.BusCode = abo.BusCode) KarKardBus,

                                cast((select isnull(sum(BesPrice), 0) - isnull(sum(BedPrice), 0) KarKard from FinDocumentDetails 
                                    where TafziliCode1 = fcc.ObjectCode and MoeinCode=3 and DocCode between 120000000 and 130000000) as decimal)  KarkardMalek,
                                cast((select isnull(sum(BedPrice), 0) - isnull(sum(BesPrice), 0) Pardakhti from FinDocumentDetails 
                                    where TafziliCode1 = fcc.ObjectCode and MoeinCode=3 and DocCode between 400000000 and 499999999) as decimal) PardakhtiMalek

                                from AUTBusOwner abo
                                left join clsAllPerson cap on cap.Code = abo.CodePerson 
                                left join AUTBus bus on bus.Code = abo.BusCode  
                                left join finComparativeCode fcc on fcc.ObjectCode = cap.Code 
                                left join finBankAccount fba on fba.PCode = cap.Code 
                                where fcc.ClassName = N'ClassLibrary.Person.AllPerson' and abo.BusCode = " + BusCode + @"
                                #CodePerson#
                                )
                                select TafsiliCode, OwnerName, left(startDate, 11) startDate, Transactions, KarKardBus, AccountNo, (Transactions - KarKardBus) mande,
                                KarkardMalek, PardakhtiMalek, (KarkardMalek - PardakhtiMalek) MandeMalek,
                                case when Transactions > KarKardBus then N'بدهکار'
                                when Transactions = KarKardBus then N'تصفیه'
                                when Transactions < KarKardBus then N'بستانکار' end status
                                from cte"
                    ).Replace("#CodePerson#", SelectP == 0 ? "" : " and abo.CodePerson = " + SelectP.ToString())
            );
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    txtOwner.Text = Dt.Rows[0]["OwnerName"].ToString();
                    txtStartDate.Text = ClassLibrary.JDateTime.FarsiDate(Convert.ToDateTime( Dt.Rows[0]["startDate"].ToString()));
                    txtTafsili.Text = Dt.Rows[0]["TafsiliCode"].ToString();
                    txtAccountNo.Text = Dt.Rows[0]["AccountNo"].ToString();
                    txtTransactions.Text = Dt.Rows[0]["Transactions"].ToString();
                    txtPardakhti.Text = Dt.Rows[0]["KarKardBus"].ToString();
                    txtMande.Text = Dt.Rows[0]["mande"].ToString();
                    txtStatus.Text = Dt.Rows[0]["status"].ToString();
                    txtKarkardMalek.Text = Dt.Rows[0]["KarkardMalek"].ToString();
                    txtPardakhtiMalek.Text = Dt.Rows[0]["PardakhtiMalek"].ToString();
                    txtMandeMalek.Text = Dt.Rows[0]["MandeMalek"].ToString();
                    btnPayOff.Enabled = true;
                }
                else
                {
                    txtOwner.Text = "";
                    txtStartDate.Text = "";
                    txtTafsili.Text = "";
                    txtAccountNo.Text = "";
                    txtTransactions.Text = "";
                    txtPardakhti.Text = "";
                    txtMande.Text = "";
                    txtStatus.Text = "";
                    txtKarkardMalek.Text = "";
                    txtPardakhtiMalek.Text = "";
                    txtMandeMalek.Text = "";
                    WebClassLibrary.JWebManager.RunClientScript("alert('اطلاعاتی موجود نمی باشد');", "ConfirmDialog");
                }
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('اطلاعاتی موجود نمی باشد');", "ConfirmDialog");
            }
        }

        protected void btnPayOff_Click(object sender, EventArgs e)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"update AUTBusOwner set EndDate = getdate() where BusCode = " + hidBusCode.Value);
                if (DB.Query_Execute() >= 0)
                    WebClassLibrary.JWebManager.RunClientScript("alert('تصفیه با موفقیت انجام شد');", "ConfirmDialog");
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات!');", "ConfirmDialog");
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}