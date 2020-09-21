using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JTaghsitMandehHesabUpdateControl : System.Web.UI.UserControl
    {
        public Int64 TransactionRemainMax;
        public Int64 DocumentRemainMax;
        int TafziliCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDayCount.Text = "1";
            }
            int.TryParse(Request["Code"], out TafziliCode);
            GetMandeh();
            ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now.AddDays(1));
        }
        void GetMandeh()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            db.setQuery(@"select 
                isnull((
                    select 
                    10 * sum(isnull(cast(BesPrice as bigint),0)) 
				    - 10 * sum(isnull(cast(BedPrice as bigint),0))
                    from FinDocumentDetails 
                    where 
                    DocCode = 120160533
				    and MoeinCode = 3
                    and TafziliCode1 =" + TafziliCode + @"
                ), 0) TransactionRemain,
                isnull((select 
                10 * sum(isnull(cast(BedPrice as bigint),0)) 
				- 10 * sum(isnull(cast(BesPrice as bigint),0))
                from FinDocumentDetails 
                where 
                DocCode = 120160534
				and MoeinCode = 3
                and TafziliCode1 =" + TafziliCode + @"
                ), 0) DocumentRemain");
            try
            {
                TransactionRemainMax = Int64.Parse(db.Query_DataTable().Rows[0]["TransactionRemain"].ToString());
                DocumentRemainMax = Int64.Parse(db.Query_DataTable().Rows[0]["DocumentRemain"].ToString());
                lblTransactionRemain.Text = string.Format("{0:n0}", Math.Abs(TransactionRemainMax));
                txtTransactionRemain.MaxValue = Math.Abs(TransactionRemainMax);
                lblDocumentRemain.Text = string.Format("{0:n0}", Math.Abs(DocumentRemainMax));
                txtDocumentRemain.MaxValue = Math.Abs(DocumentRemainMax);

                if (TransactionRemainMax < 0)
                    lblTransactionRemainType.Text = "(اضافه پرداخت)";
                else
                    lblTransactionRemainType.Text = "(کسر پرداخت)";

                if (DocumentRemainMax < 0)
                    lblDocumentRemainType.Text = "(اضافه پرداخت)";
                else
                    lblDocumentRemainType.Text = "(کسر پرداخت)";

            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int DayCount = 0;
            Int64 TransactionRemain = 0, DocumentRemain = 0;
            if (TransactionRemainMax == 0 && DocumentRemainMax == 0)
                return;

            if (!Int64.TryParse(txtDocumentRemain.Text, out DocumentRemain) || !Int64.TryParse(txtTransactionRemain.Text, out TransactionRemain)
                || (TransactionRemain == 0 && DocumentRemain == 0) || TransactionRemain < 0 || TransactionRemain > Math.Abs(TransactionRemainMax)
                || DocumentRemain < 0 || DocumentRemain > Math.Abs(DocumentRemainMax))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "success", "alert('مبلغ مانده معتبر نیست.');", true);
                return;
            }

            if (TransactionRemainMax < 0)
                TransactionRemain = -TransactionRemain;

            if (DocumentRemainMax < 0)
                DocumentRemain = -DocumentRemain;

            lblTotalRemain.Text = string.Format("{0:n0}", (TransactionRemain + DocumentRemain));

            DateTime Tomorrow = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 0, 0, 0);
            if (((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate() < Tomorrow || DateTime.Now.Hour >= 23)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('تاریخ شروع معتبر نیست.');", true);
                return;
            }
            if (((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate() > DateTime.MinValue
                && int.TryParse(txtDayCount.Text, out DayCount) && DayCount > 0)
            {
                ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
                Db.setQuery(@"SELECT * FROM [dbo].[AUTInstallments] 
                WHERE  CAST(DATEADD(DAY, -3, GETDATE()) AS DATE) <= DATEADD(DAY, DayPeriod * (Count - 1), StartDate) AND OwnerCode = " + TafziliCode);
                DataTable dt = Db.Query_DataTable();
                if (dt != null && dt.Rows.Count > 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "success", "alert('تقسیط قبلی هنوز به پایان نرسیده است.');", true);
                    Db.Dispose();
                    return;
                }
                if (Save(Db, TransactionRemain/10, DocumentRemain/10))
                    Page.ClientScript.RegisterStartupScript(GetType(), "success", "alert('عملیات با موفقیت انجام شد.');", true);
                else
                    Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('دوباره تلاش کنید.');", true);
            }
            else
                Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('لطفا تاریخ شروع و تعداد روز را وارد کنید.');", true);

        }
        bool Save(ClassLibrary.JDataBase Db, Int64 TransactionRemain, Int64 DocumentRemain)
        {
            Db.setQuery(@"

                INSERT INTO [dbo].[AUTInstallments]
                           ([Code]
                           ,[OwnerCode]
                           ,[StartDate]
                           ,[GhestPrice]
                           ,[TotalBedPrice]
                           ,[TotalBesPrice]
                           ,[Count]
                           ,[DayPeriod])
                     VALUES
                           (isnull((select max(code) + 1 from AUTInstallments), 1)
                           ,@OwnerCode
                           ,@StartDate
                           ,cast(@DocumentRemain/@Count as int)
                           ,(case when @DocumentRemain < 0 then ABS(@DocumentRemain) else 0 end)
                           ,(case when @DocumentRemain > 0 then @DocumentRemain else 0 end)
                           ,@Count
		                   ,1
                            )");
            Db.AddParams("OwnerCode", TafziliCode);
            Db.AddParams("StartDate", ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate().ToString("yyyy-MM-dd"));
            Db.AddParams("DocumentRemain", DocumentRemain);
            Db.AddParams("Count", txtDayCount.Text);
            Db.beginTransaction("Taghsit");
            try
            {
                if (Db.Query_Execute() >= 0)
                {
                    Db.Params.Clear();
                    if (Db.Params.Count > 0)
                    {
                        Db.Params.Remove("OwnerCode");
                        Db.Params.Remove("StartDate");
                        Db.Params.Remove("Count");
                    }
                    Db.setQuery("exec [dbo].[SP_GhestbandieMandehHesab] @tafzili_code,@start_date,@total_price,@ghest_count");
                    Db.AddParams("tafzili_code", TafziliCode);
                    Db.AddParams("start_date", ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate().ToString("yyyy-MM-dd"));
                    Db.AddParams("total_price", TransactionRemain);
                    Db.AddParams("ghest_count", txtDayCount.Text);
                    DataTable dt = Db.Query_DataTable();
                    if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "1")
                    {
                        Db.Commit();
                        return true;
                    }
                    else
                    {
                        Db.Rollback("Taghsit");
                        return false;
                    }
                }
                else
                {
                    Db.Rollback("Taghsit");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                Db.Rollback("Taghsit");
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }
    }
}