using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JTarahanAccountUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        bool ReloadPage = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Code = 0;
            int.TryParse(Request["Code"], out Code);
            if (IsPostBack)
            {
            }
            else
            {
                LoadMonth();
                LoadYears();
                LoadFleets();
                LoadFinDocuments();
                LoadPayment();
                _SetForm();
                if (Code > 0)
                {
                    GetReport();
                    GetTarahanShare();
                }
            }
        }

        public void GetTarahanShare()
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"
                declare @karkard bigint = 0,  @payment bigint = 0

	            SELECT @karkard = 10 * SUM(CAST(ISNULL(dd.BesPrice, 0) AS BIGINT))
                FROM FinDocumentPayment fdp
	            INNER JOIN FinDocumentDetails dd ON dd.DocCode = fdp.DocCode
	            WHERE fdp.ContractorDocCode = " + Code + @" AND dd.MoeinCode = 3
				
	            SELECT @payment = 10 * SUM(CAST(ISNULL(pd.TotalPrice, 0) AS BIGINT))
                FROM FinDocumentPayment fdp
		        INNER JOIN AUTPaymentDetail pd on pd.PaymentCode=fdp.PaymentCode
	            WHERE fdp.ContractorDocCode = " + Code + @"

				SELECT @karkard Karkard, @payment Payment");
            if (dt != null && dt.Rows.Count > 0)
            {
                lblTotalKarkard.Text = dt.Rows[0]["Karkard"].ToString();
                lblTotalPayment.Text = dt.Rows[0]["Payment"].ToString();
            }
        }

        public void GetReport()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JTarahanAccountUpdateControl";
            jGridView.SQL = @"SELECT fdp.Code
                ,fdp.DocCode KarkardCode
                ,CAST(fd.Description AS NVARCHAR(MAX)) KarkardDesc
                ,10 * SUM(ISNULL(CAST(fdd.BesPrice AS BIGINT), 0)) Karkard
                ,fdp.PaymentCode 
                ,p.PayDesc
                ,p.payment
                FROM FinDocumentPayment fdp
                INNER JOIN FinDocument fd ON fd.Code = fdp.DocCode
                LEFT JOIN  FinDocumentDetails fdd ON fdd.DocCode = fdp.DocCode AND fdd.MoeinCode = 3
				inner join
				(
				select fdp.Code
                ,fdp.DocCode KarkardCode
                ,fdp.PaymentCode 
                ,p.Description PayDesc
                ,10 * SUM(ISNULL(CAST(pd.TotalPrice AS BIGINT), 0)) payment
                FROM FinDocumentPayment fdp
                INNER JOIN AUTPayment p on p.Code = fdp.PaymentCode
                LEFT JOIN  AUTPaymentDetail pd ON pd.PaymentCode = fdp.PaymentCode
                WHERE ContractorDocCode = {0}
                GROUP BY fdp.Code, fdp.DocCode,
				fdp.PaymentCode, 
				p.Description
				) p on fdp.Code = p.Code
                WHERE ContractorDocCode = {0}
                GROUP BY fdp.Code, fdp.DocCode, 
				CAST(fd.Description AS NVARCHAR(MAX)), 
				fdp.PaymentCode, 
				p.payment, p.PayDesc";
            jGridView.Parameters = new object[] { Code };
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 10;
            jGridView.Title = "JTarahanAccountUpdateControl";
            jGridView.PageOrderByField = "Code DESC";
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.Bind();


            JGridView1.ClassName = "WebBusManagement_FormsReports_JTarahanAccountUpdateControl_2";
            JGridView1.SQL = @"select 
TafziliCode1 Code,
(select Value from finComparativeCode where ObjectCode=TafziliCode1) ComparativeCode,
(select name from clsAllPerson where Code=TafziliCode1) Name,
TafziliCode2-30000000 Bus,
min(F.DocCode) FromCode,
max(F.DocCode) ToCode,
cast(sum(isnull(BesPrice,0)-isnull(0,0)) as bigint)*10 Karkard 
from FinDocumentDetails F
inner join FinDocumentPayment fdp on F.DocCode=fdp.DocCode
where fdp.ContractorDocCode={0}
and MoeinCode=3
and tafziliCode1  not in (select code from clsallperson where name like N'%دولتی%')
and TafziliCode1 is not null
and TafziliCode1 <>0
group by TafziliCode1,TafziliCode2
";
            JGridView1.Parameters = new object[] { Code };
            JGridView1.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            JGridView1.PageSize = 10;
            JGridView1.Title = "JTarahanAccountUpdateControl_2";
            JGridView1.PageOrderByField = "Code DESC";
            JGridView1.Buttons = "excel,print,record_print,refresh";
            JGridView1.Bind();


            JGridView2.ClassName = "WebBusManagement_FormsReports_JTarahanAccountUpdateControl_3";
            JGridView2.SQL = @"select 
TafziliCode1 Code,
(select Value from finComparativeCode where ObjectCode=TafziliCode1) ComparativeCode,
(select name from clsAllPerson where Code=TafziliCode1) Name,
DBO.DateEnToFa(DateSave) FDate,
TafziliCode2-30000000 Bus,
min(F.DocCode) FromCode,
max(F.DocCode) ToCode,
cast(sum(isnull(BesPrice,0)-isnull(0,0)) as bigint)*10 Karkard
from FinDocumentDetails F
inner join FinDocumentPayment fdp on F.DocCode=fdp.DocCode
where fdp.ContractorDocCode={0}
and MoeinCode=3
and tafziliCode1  not in (select code from clsallperson where name like N'%دولتی%')
and tafziliCode1 is not null 
and tafziliCode1 <>0
and F.DocCode not in (120160533,120160534)
group by TafziliCode1,TafziliCode2,DateSave";
            JGridView2.Parameters = new object[] { Code };
            JGridView2.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            JGridView2.PageSize = 10;
            JGridView2.Title = "JTarahanAccountUpdateControl_3";
            JGridView2.PageOrderByField = "Code DESC";
            JGridView2.Buttons = "excel,print,record_print,refresh";
            JGridView2.Bind();

//            JGridView3.ClassName = "WebBusManagement_FormsReports_JTarahanAccountUpdateControl_4";
//            JGridView3.SQL = @"select 
//TafziliCode1 Code,
//(select Value from finComparativeCode where ObjectCode=TafziliCode1) ComparativeCode,
//(select name from clsAllPerson where Code=TafziliCode1) Name,
//DBO.DateEnToFa(DateSave) Date,
//TafziliCode2-30000000 Bus,
//min(F.DocCode) FromCode,
//max(F.DocCode) ToCode,
//cast(sum(isnull(BesPrice,0)-isnull(0,0)) as bigint)*10 Karkard
//from FinDocumentDetails F
//inner join FinDocumentPayment fdp on F.DocCode=fdp.DocCode
//where fdp.ContractorDocCode={0}
//and MoeinCode=3
//and tafziliCode1  not in (select code from clsallperson where name like N'%دولتی%')
//and tafziliCode1 is not null 
//and tafziliCode1 <>0
//and F.DocCode not in (120160533,120160534)
//group by TafziliCode1,TafziliCode2,DateSave";
//            JGridView3.Parameters = new object[] { Code };
//            JGridView3.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
//            JGridView3.PageSize = 10;
//            JGridView3.Title = "JTarahanAccountUpdateControl_4";
//            JGridView3.PageOrderByField = "Code DESC";
//            JGridView3.Buttons = "excel,print,record_print,refresh";
//            JGridView3.Bind();


            JGridView4.ClassName = "WebBusManagement_FormsReports_JTarahanAccountUpdateControl_5";
            JGridView4.SQL = @"select a.*,Pardakht from
(
	select 
	TafziliCode1 Code,
	(select Value from finComparativeCode where ObjectCode=TafziliCode1) ComparativeCode,
	(select name from clsAllPerson where Code=TafziliCode1) Name,
	cast(sum(isnull(BesPrice,0)-isnull(0,0)) as bigint)*10 Karkard
	from FinDocumentDetails F
	inner join FinDocumentPayment fdp on F.DocCode=fdp.DocCode
	where fdp.ContractorDocCode={0}
	and  MoeinCode=3
	and tafziliCode1  not in (select code from clsallperson where name like N'%دولتی%')
			and tafziliCode1 is not null 
			and tafziliCode1 <>0
	group by TafziliCode1
) a 
FULL join
(
	select OwnerPCode , cast(sum(TotalPrice)as bigint) *10 Pardakht 
	from AUTPaymentDetail F
	inner join FinDocumentPayment fdp on F.PaymentCode=fdp.PaymentCode
	where fdp.ContractorDocCode={1}
	group by OwnerPCode
)
b
on a.Code=b.OwnerPCode
";
            JGridView4.Parameters = new object[] { Code,Code };
            JGridView4.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            JGridView4.PageSize = 10;
            JGridView4.Title = "JTarahanAccountUpdateControl_5";
            JGridView4.PageOrderByField = "Code DESC";
            JGridView4.Buttons = "excel,print,record_print,refresh";
            JGridView4.Bind();
        }

        private void _SetForm()
        {
            if (Code > 0)
            {
                cmbFleets.Enabled = false;
                cmbYears.Enabled = false;
                cmbMount.Enabled = false;

                DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from FinDocument where Code = " + Code, false);
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        DateTime StartDate = DateTime.Now;
                        StartDate = Convert.ToDateTime(Dt.Rows[0]["DateSave"].ToString());
                        cmbYears.SelectedValue = ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(0, 4);
                        cmbMount.SelectedValue = Convert.ToInt32(ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(5, 2)).ToString();
                    }
                }
                Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from FinDocumentPayment where contractorDocCode=" + Code+ " order by code", false);
                if(Dt != null)
                {
                    int i = 1;
                    foreach(DataRow DR in Dt.Rows)
                    {
                        (this.GetType().GetField("DocCode" + i, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this) as System.Web.UI.HtmlControls.HtmlInputText).Value = DR["DocCode"].ToString();
                        (this.GetType().GetField("Pay" + i, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this) as System.Web.UI.HtmlControls.HtmlInputText).Value = DR["PaymentCode"].ToString();
                        i++;
                        if (i > 31)
                            break;

                    }
                }

            }
        }

        public void LoadFleets()
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code, Name from finTafzili where ClassName = N'JFleets' order by Code desc");
            cmbFleets.DataSource = dt;
            cmbFleets.DataTextField = "Name";
            cmbFleets.DataValueField = "Code";
            cmbFleets.DataBind();
            if (cmbFleets.Items.Count > 1)
            {
                cmbFleets.SelectedIndex = 1;
            }
        }

        public void LoadMonth()
        {
            cmbMount.SelectedValue = ClassLibrary.JDateTime.FarsiMonth(DateTime.Now);
        }

        public void LoadYears()
        {
            int CYear = Convert.ToInt32(ClassLibrary.JDateTime.FarsiYear(DateTime.Now));
            for (int i = CYear; i >= 1392; i--)
            {
                Telerik.Web.UI.RadComboBoxItem RCBI = new Telerik.Web.UI.RadComboBoxItem();
                RCBI.Value = i.ToString();
                RCBI.Text = i.ToString();
                cmbYears.Items.Add(RCBI);
            }
        }

        public void LoadFinDocuments()
        {
            //string Query = "";
            //if (Code > 0)
            //{
            //    Query = @"SELECT Code FROM FinDocument 
            //    WHERE Code NOT IN (SELECT DocCode FROM FinDocumentPayment) AND Code BETWEEN 100000000 and 199999999 
            //    AND Code BETWEEN isnull((SELECT min(DocCode) - 150 FROM FinDocumentPayment where ContractorDocCode = " + Code + @") ,100000000) 
            //        and isnull((SELECT max(DocCode) + 150 FROM FinDocumentPayment where ContractorDocCode = " + Code + @") ,199999999)
            //    ORDER BY Code DESC";
            //}
            //else 
            //{
            //    Query = @"SELECT Code FROM FinDocument 
            //    WHERE Code NOT IN (SELECT DocCode FROM FinDocumentPayment) AND Code BETWEEN 100000000 and 199999999 ORDER BY Code DESC";
            //}
            //DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(Query, false);
            //var p = (from v in dt.AsEnumerable()
            //         select new { Code = Convert.ToInt32(v["Code"]), Text = v["Code"].ToString() }).ToList();
            //p.Insert(0, new { Code = 0, Text = "-" });
            //cmbKarkard.DataSource = p;
            //cmbKarkard.DataTextField = "Text";
            //cmbKarkard.DataValueField = "Code";
            //cmbKarkard.DataBind();
        }

        public void LoadPayment()
        {
            //string Query = "";
            //if (Code > 0)
            //{
            //    Query = @"SELECT Code FROM AUTPayment 
            //    WHERE Code NOT IN (SELECT PaymentCode FROM FinDocumentPayment)
            //    AND Code BETWEEN isnull((SELECT min(PaymentCode) - 50 FROM FinDocumentPayment where ContractorDocCode = " + Code + @") ,0) 
            //        and isnull((SELECT max(PaymentCode) + 50 FROM FinDocumentPayment where ContractorDocCode = " + Code + @") ,100000000)
            //    ORDER BY Code DESC";
            //}
            //else
            //{
            //    Query = @"SELECT Code FROM AUTPayment
            //    WHERE Code NOT IN (SELECT PaymentCode FROM FinDocumentPayment) ORDER BY Code DESC";
            //}
            //DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(Query, false);
            //var p = (from v in dt.AsEnumerable()
            //         select new { Code = Convert.ToInt32(v["Code"]), Text = v["Code"].ToString() }).ToList();
            //p.Insert(0, new { Code = 0, Text = "-" });
            //cmbPayment.DataSource = p;
            //cmbPayment.DataTextField = "Text";
            //cmbPayment.DataValueField = "Code";
            //cmbPayment.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(Code>0)
            {
                WebClassLibrary.JWebDataBase.ExecuteQuery(@"delete from FinDocumentPayment where contractorDocCode=" + Code);
            }
            for (int i = 1; i <= 31; i++)
            {
                int KarkardDocCode = 0, PaymentCode = 0;
                try {
                    string DocCode = (this.GetType().GetField("DocCode" + i, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this) as System.Web.UI.HtmlControls.HtmlInputText).Value;
                    string Pay = (this.GetType().GetField("Pay" + i, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this) as System.Web.UI.HtmlControls.HtmlInputText).Value;
                    int.TryParse(DocCode, out KarkardDocCode);
                    int.TryParse(Pay, out PaymentCode);

                    if (KarkardDocCode > 0 && PaymentCode > 0)
                        Save(KarkardDocCode, PaymentCode);
                }
                catch( Exception ex)
                {

                }
            }
            if (ReloadPage)
            {
                WebClassLibrary.JWebManager.LoadControl("ContractorAccount"
                , "~/WebBusManagement/FormsManagement/JTarahanAccountUpdateControl.ascx"
                  , "صورت وضعیت طراحان کنترل شرق"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", Code.ToString()) }
                    , WebClassLibrary.WindowTarget.CurrentWindow
                  , true, false, true, 600, 450);
            }
            else
            {
                GetReport();
                GetTarahanShare();
            }
        }
    
        bool Save(int KarkardDocCode, int PaymentCode)
        {
            int CurrentCode = 0;
            DateTime StartDate = DateTime.Now, EndDate = DateTime.Now;
            StartDate = ClassLibrary.JDateTime.GregorianDate(cmbYears.SelectedValue.ToString() + "/" + cmbMount.SelectedValue.ToString() + "/" + "1", "00:00:00");
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            Db.beginTransaction("FinDocumentPaymentInsert");
            try
            {
                if (Code == 0)
                {
                    DataTable dt = new DataTable();
                    Db.setQuery(@"
                            DECLARE @t table(Code INT)
                            INSERT INTO [dbo].[FinDocument]
                                ([Code]
                                ,[DateSave]
                                ,[DateModifie]
                                ,[UserCode]
                                ,[PostCode]
                                ,[Description]
                                ,[Date]
                                ,[IsOk])
                            OUTPUT Inserted.Code into @t
                            VALUES
                                ((Select ISNULL(((select Max(a.Code)+1 from (select Code from FinDocument where code between 800000000 and 899999999)a)),800000000))
                                ,'" + StartDate.ToString("yyyy-MM-dd") + @" 00:00:00'
                                ,getdate()
                                ," + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode + @"
                                ," + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode + @"
                                ,N'سند صورت وضعیت " + cmbFleets.SelectedItem.Text + @" برای سال " + cmbYears.SelectedItem.Text + @" ماه " + cmbMount.SelectedItem.Text + @"'
                                ,cast(getdate() as date)
                                ,1)
                            SELECT ISNULL((SELECT TOP 1 Code FROM @t), 0)");
                    dt = Db.Query_DataTable();
                    if (dt != null && dt.Rows.Count > 0)
                        CurrentCode = Convert.ToInt32(dt.Rows[0][0]);
                    if (CurrentCode == 0)
                    {
                        Db.Rollback("FinDocumentPaymentInsert");
                        return false;
                    }
                }
                else 
                    CurrentCode = Code;

                Db.setQuery(@"
                    INSERT INTO [dbo].[FinDocumentPayment]
                               ([Code]
                               ,[DocCode]
                               ,[PaymentCode]
                               ,[ContractorDocCode])
                         VALUES
                               (ISNULL((SELECT MAX(Code) + 1 FROM [dbo].[FinDocumentPayment]),1)
                               ,@KarkardDocCode
                               ,@PaymentCode
                               ,@CurrentCode)");

                Db.AddParams("KarkardDocCode", KarkardDocCode);
                Db.AddParams("PaymentCode", PaymentCode);
                Db.AddParams("CurrentCode", CurrentCode);
                if (Db.Query_Execute() >= 0)
                {
                    Db.Commit();
                    //cmbKarkard.Items.Remove(cmbKarkard.SelectedIndex);
                    //cmbPayment.Items.Remove(cmbPayment.SelectedIndex);
                    if (Code == 0)
                    {
                        Code = CurrentCode;
                        ReloadPage = true;
                    }
                    return true;
                }
                else
                {
                    Db.Rollback("FinDocumentPaymentInsert");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                Db.Rollback("FinDocumentPaymentInsert");
                return false;
            }
            finally 
            { 
                Db.Dispose();
            }
        }
    }
}