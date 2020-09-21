using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JAccountReviewReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            // btnSave_Click(null, null);
            //else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadTafsili1();
                //LoadTafsili2();
            }

            if (IsPostBack)
            {
                //try
                //{
                //    GetReport(Convert.ToInt32(cmbTafsili1.SelectedValue), 0,
                //       ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate());
                //}
                //catch { }
            }
            //comment
        }

        public void LoadTafsili1()
        {

            string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBusOwners.GetBusOwners", "ObjectCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select -1 Code, -1 TafsiliCode, N'همه' Name
                                                                        union
                                                                        select ObjectCode Code,Value TafsiliCode,b.Name from finComparativeCode a
                                                                        left join clsAllPerson b on a.ObjectCode = b.Code
                                                                        where ClassName = N'ClassLibrary.Person.AllPerson' " + PermitionSql);
            //var p = (from v in dt.AsEnumerable()
            //         select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            //p.Insert(0, new { Code = 0, Name = "همه" });
            cmbTafsili1.DataSource = dt;
            cmbTafsili1.DataTextField = "Name";
            cmbTafsili1.DataValueField = "Code";
            cmbTafsili1.DataBind();
        }
        //public void LoadTafsili2()
        //{
        //    DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name from finTafzili where Code > 1 and ClassName = N'JBus'");
        //    var p = (from v in dt.AsEnumerable()
        //             select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
        //    p.Insert(0, new { Code = 0, Name = "همه" });
        //    cmbTafsili2.DataSource = p;
        //    cmbTafsili2.DataTextField = "Name";
        //    cmbTafsili2.DataValueField = "Code";
        //    cmbTafsili2.DataBind();
        //}

        public void GetReport(int Tafsili1 = 0, int Tafsili2 = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null,
            int ReportType = 0, bool ShowHistory = true, int BedBes = 0)
        {
            String T1 = "1=1", T2, SD, ED, History = "", strBedBes = "";
            if (Tafsili1 > 0)
                T1 = "TafziliCode1 = " + Tafsili1;
            else if (Tafsili1 == -1)
            {
                string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBusOwners.GetBusOwners", "ObjectCode");
                if (PermitionSql.Length < 5)
                {
                    PermitionSql = "";
                }
                T1 = @"TafziliCode1 in (select ObjectCode from finComparativeCode a
                                                                        left join clsAllPerson b on a.ObjectCode = b.Code
                                                                        where ClassName = N'ClassLibrary.Person.AllPerson' " + PermitionSql + ")";
            }
            if (Tafsili2 > 0)
                T2 = Tafsili2.ToString();
            else
                T2 = "NULL";
            if (StartEventDate.HasValue)
                SD = ClassLibrary.JDataBase.Quote(StartEventDate.Value.ToString("yyyy-MM-dd"));
            else
                SD = "'2000-01-01'";
            if (EndEventDate.HasValue)
                ED = ClassLibrary.JDataBase.Quote(EndEventDate.Value.ToString("yyyy-MM-dd"));
            else
                ED = "'2000-01-01'";

            if(BedBes == 1)
                strBedBes = " and BedPrice = 0";
            else if (BedBes == 2)
                strBedBes = " and BesPrice = 0";

            if (ShowHistory)
                History = @"select 1 code, N'از ابتدا تا '+dbo.DateEnToFa(@StartDate) Date,(select Name from finTafzili where code=TafziliCode1) T1,TafziliCode1,TafziliCode2,
            		    (select Name from finMoein where code= MoeinCode) Moein,sum(cast(BedPrice as bigint)) Bed,sum(cast(BesPrice as bigint)) Bes,
            		    N'' Description,0 DocCode,cast(0 as bigint) total  from FinDocumentDetails
            		    where DocCode <> 120500723 and 
            		    ".Replace("@StartDate", SD) + T1 + @" and
            		    MoeinCode in (3) and 
            		    DateSave <@StartDate".Replace("@StartDate", SD) + strBedBes + @"
            		    group by TafziliCode1,MoeinCode,TafziliCode2
            		    union";


            //string WhereStr = "";
            //if (ReportType == 1)
            //    WhereStr = "where a.Bes > 0";
            //if (ReportType == 2)
            //    WhereStr = "where a.Bed > 0";

            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsManagement_JAccountReviewReportControl");
            jGridView.ClassName = "WebBusManagement_FormsManagement_JAccountReviewReportControl_" + Tafsili1 + "_" + Tafsili2 + "_"
                + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_"
                + (EndEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_"
                + ReportType + "_" + (ShowHistory ? 1 : 0) + "_" + BedBes;
            // jGridView.SQL = @" EXEC [dbo].[AccountingReview] @Date = N'" + StartEventDate.Value.ToShortDateString() + @"',@TafziliCode1 =  " + Tafsili1;
            if (ReportType == 0)
                jGridView.SQL = @"
                    select  top 100 percent a.code,a.Date,a.DocCode,a.T1,a.TafziliCode1,a.TafziliCode2,a.Moein,a.Bed BedPrice,a.Bes BesPrice,a.Des,sum(Remain) over (order by Code) Remain
                    from
                    (
                        select top 100 percent ROW_NUMBER() over(order by Code,Date) code,a.Date,a.T1,a.TafziliCode1,TafziliCode2 TafziliCode2,a.Moein,
	                    Sum(Bed) Bed,Sum(Bes) Bes,Description Des,a.DocCode,Sum(Bes)-Sum(Bed) Remain
                        from
                        (
                            " + History + @"
                            select 4 code, dbo.DateEnToFa(DateSave) Date,(select Name from finTafzili where code=TafziliCode1) T1,TafziliCode1,TafziliCode2,
                            (select Name from finMoein where code= MoeinCode) Moein,sum(cast(BedPrice as bigint)) Bed,sum(cast(BesPrice as bigint)) Bes,
                            cast(Description as nvarchar(1000)) Description,DocCode,cast(0 as bigint) total from FinDocumentDetails
                            where DocCode <> 120500723 and 
                            " + T1 + @" and
                            MoeinCode in (3) and 
                            DateSave between @StartDate and @EndDate".Replace("@StartDate", SD).Replace("@EndDate", ED) + strBedBes + @"
                            group by DateSave,TafziliCode1,MoeinCode,cast(Description as nvarchar(1000)),TafziliCode2,DocCode
                        ) as a
                        group by a.code,a.Date,a.T1,a.TafziliCode1,a.Moein,TafziliCode2,Description,a.DocCode
                        order by Code,Date
                    ) as a
                    group by a.code,a.Date,a.DocCode,a.T1,a.TafziliCode1,a.TafziliCode2,a.Moein,a.Bed ,a.Bes ,a.Des,Remain";
            else
                jGridView.SQL = @"
                    select 
                    ROW_NUMBER() over(order BY CAST(left(DateSaveServer,7)+'/01' AS date)) code,
                    left(DateSaveServer,7) date,
                    cast(sum(BedPrice) as bigint) BedPrice,
                    cast(sum(BesPrice) as bigint) BesPrice,
                    cast(sum(BesPrice) as bigint)  - cast(sum(BedPrice) as bigint) Remain, 
                    case when cast(sum(BesPrice) as bigint) > cast(sum(BedPrice) as bigint) then N'کسر پرداخت' else N'اضافه پرداخت' end 'وضعیت'
                     from
                    (
                    select dbo.DateEnToFa(DateModifie) DateSaveServer,dbo.DateEnToFa(DateSave) DSateEvent,BesPrice,BedPrice 
                    from FinDocumentDetails 
                    where DocCode <> 120500723 and  " + T1 + @" and MoeinCode=3 and DocCode<>120500720" + strBedBes + @"
                    ) as a
                    group by left(DateSaveServer,7)";
            //            jGridView.SQL = @"
            //select top 100 percent a.code,a.Date,a.T1,a.TafziliCode1,a.TafziliCode2,a.Moein,cast(a.Bed as bigint) BedPrice,cast(a.Bes as bigint) BesPrice,a.Des,cast(a.Remain + COALESCE(SUM(b.Remain),0) as bigint) Remain from
            //(
            //select top 100 percent ROW_NUMBER() over(order by Code,Date) code,a.Date,a.T1,a.TafziliCode1,TafziliCode2 TafziliCode2,a.Moein,Sum(Bed) Bed,Sum(Bes) Bes,Description Des,Sum(Bes)-Sum(Bed) Remain
            //		from
            //		(
            //		select top 100 percent *,cast(0 as bigint) total
            //		from
            //		(
            //		select 1 code, N'از ابتدا تا '+dbo.DateEnToFa(@StartDate) Date,(select Name from finTafzili where code=TafziliCode1) T1,TafziliCode1,TafziliCode2,
            //		(select Name from finMoein where code= MoeinCode) Moein,sum(BedPrice) Bed,sum(BesPrice) Bes,
            //		N'' Description  from FinDocumentDetails
            //		where 
            //		(TafziliCode1=@TafziliCode1 OR @TafziliCode1 is null) and
            //		MoeinCode in (3) and 
            //		DateSave <@StartDate
            //		group by TafziliCode1,MoeinCode,TafziliCode2
            //		union
            //		select 4, dbo.DateEnToFa(DateSave) Date,(select Name from finTafzili where code=TafziliCode1) T1,TafziliCode1,TafziliCode2,
            //		(select Name from finMoein where code= MoeinCode) Moein,sum(BedPrice) Bed,sum(BesPrice) Bes,
            //		cast(Description as nvarchar(1000)) Description from FinDocumentDetails
            //		where 
            //		(TafziliCode1=@TafziliCode1 OR @TafziliCode1 is null) and
            //		MoeinCode in (3) and 
            //		DateSave >=@StartDate
            //		group by DateSave,TafziliCode1,MoeinCode,cast(Description as nvarchar(1000)),TafziliCode2
            //		) as a
            //		order by Code,Date
            //) as a
            //group by a.code,a.Date,a.T1,a.TafziliCode1,a.Moein,TafziliCode2,Description
            //order by Code,Date
            //) as a
            //left outer join
            //(
            //select top 100 percent ROW_NUMBER() over(order by Code,Date) code,a.Date,a.T1,a.TafziliCode1,TafziliCode2 T2,a.Moein,Sum(Bed) Bed,Sum(Bes) Bes,Description Des,Sum(Bes)-Sum(Bed) Remain
            //		from
            //		(
            //		select top 100 percent *,cast(0 as bigint) total
            //		from
            //		(
            //		select 1 code, N'از ابتدا تا '+dbo.DateEnToFa(@StartDate) Date,(select Name from finTafzili where code=TafziliCode1) T1,TafziliCode1,TafziliCode2,
            //		(select Name from finMoein where code= MoeinCode) Moein,sum(BedPrice) Bed,sum(BesPrice) Bes,
            //		N'' Description  from FinDocumentDetails
            //		where 
            //		(TafziliCode1=@TafziliCode1 OR @TafziliCode1 is null) and
            //		MoeinCode in (3) and 
            //		DateSave <@StartDate
            //		group by TafziliCode1,MoeinCode,TafziliCode2
            //		union
            //		select 4, dbo.DateEnToFa(DateSave) Date,(select Name from finTafzili where code=TafziliCode1) T1,TafziliCode1,TafziliCode2,
            //		(select Name from finMoein where code= MoeinCode) Moein,sum(BedPrice) Bed,sum(BesPrice) Bes,
            //		cast(Description as nvarchar(1000)) Description from FinDocumentDetails
            //		where 
            //		(TafziliCode1=@TafziliCode1 OR @TafziliCode1 is null) and
            //		MoeinCode in (3) and 
            //		DateSave >=@StartDate
            //		group by DateSave,TafziliCode1,MoeinCode,cast(Description as nvarchar(1000)),TafziliCode2
            //		) as a
            //		order by Code,Date
            //) as a
            //group by a.code,a.Date,a.T1,a.TafziliCode1,a.Moein,TafziliCode2,Description
            //order by Code,Date
            //
            //)as b
            //on b.code<a.code
            //".Replace("@TafziliCode2", T2).Replace("@TafziliCode1", T1).Replace("@StartDate", SD) + WhereStr + @"
            //group by a.code,a.Date,a.T1,a.TafziliCode1,a.Moein,a.Bed,a.Bes,a.Des,a.Remain,TafziliCode2
            //		        ".Replace("@TafziliCode2", T2).Replace("@TafziliCode1", T1).Replace("@StartDate", SD);

            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "JAccountReviewReportControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("BedPrice", 0);
            jGridView.SumFields.Add("BesPrice", 0);
            jGridView.SumFields.Add("Remain", 0);

            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool ShowHistory = cmbShowHistory.SelectedValue == "1";
            try
            {
                GetReport(Convert.ToInt32(cmbTafsili1.SelectedValue), 0, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                   ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), Int32.Parse(cmbReportType.SelectedValue), ShowHistory, 
                   Int32.Parse(cmbBedBes.SelectedValue));
            }
            catch { }
        }
    }
}