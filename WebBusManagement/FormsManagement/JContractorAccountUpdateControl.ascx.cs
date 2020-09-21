using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JContractorAccountUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
                LoadMonth();
                LoadYears();
                LoadFleets();
                _SetForm();
            }
            else {
                //GetReportAmareKol(cmbYears.SelectedValue.ToString(), cmbMount.SelectedValue.ToString());
                //GetReportAmareKarKard(cmbYears.SelectedValue.ToString(), cmbMount.SelectedValue.ToString());
                //GetReportAmarePardakhti(cmbYears.SelectedValue.ToString(), cmbMount.SelectedValue.ToString());
            }
        }

        private void _SetForm()
        {
            if (Code > 0)
            {
                cmbFleets.Enabled = false;
                btnSave.Enabled = false;
                btnCheck.Enabled = false;
                cmbYears.Enabled = false;
                cmbMount.Enabled = false;
                
                DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from FinDocument where Code = " + Code,false);
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        DateTime StartDate = DateTime.Now, EndDate = DateTime.Now;
                        StartDate = Convert.ToDateTime(Dt.Rows[0]["DateSave"].ToString());
                        if (Convert.ToInt32(cmbMount.SelectedValue.ToString()) <= 6)
                            EndDate = ClassLibrary.JDateTime.GregorianDate(ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(0, 4) + "/" + ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(5, 2) + "/" + "31", "23:59:59");
                        else if (Convert.ToInt32(cmbMount.SelectedValue.ToString()) > 6 & Convert.ToInt32(cmbMount.SelectedValue.ToString()) < 12)
                            EndDate = ClassLibrary.JDateTime.GregorianDate(ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(0, 4) + "/" + ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(5, 2) + "/" + "30", "23:59:59");
                        else if (Convert.ToInt32(cmbMount.SelectedValue.ToString()) == 12)
                            EndDate = ClassLibrary.JDateTime.GregorianDate(ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(0, 4) + "/" + ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(5, 2) + "/" + "29", "23:59:59");

                        cmbYears.SelectedValue = ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(0, 4);
                        cmbMount.SelectedValue = ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(5, 2);

                        DataTable DTKarKard = WebClassLibrary.JWebDataBase.GetDataTable(@"select cast(((sum(BesPrice) * 10.0 * 6.0)/100.0) as bigint) KarKard 
                                                                                            from FinDocumentDetails a
                                                                                            left join FinDocument b on a.DocCode = b.Code
                                                                                            where b.DateSave between '" + StartDate.ToShortDateString() + @" 00:00:00' 
                                                                                            and '" + EndDate.ToShortDateString() + @" 23:59:59'
                                                                                            and MoeinCode = 3
                                                                                            and BesPrice > 0 
                                                                                            and DocCode between 100000000 and 199999999");

                        DataTable DtDaryafti = WebClassLibrary.JWebDataBase.GetDataTable(@"select (ISNULL(sum(BesPrice),0)-ISNULL(sum(BedPrice),0)) * 10 Daryafti 
                                                                               from FinDocumentDetails 
                                                                               where DateSave between '" + StartDate.ToShortDateString() + @" 00:00:00' and '" + EndDate.ToShortDateString() + @" 23:59:59'
                                                                               and MoeinCode = 6 and DocCode between 800000000 and 899999999");
                        double Karkard = 0.0, Daryafti = 0.0;
                        if (DTKarKard != null && DTKarKard.Rows.Count > 0)
                        { 
                            Karkard = Convert.ToDouble(DTKarKard.Rows[0]["KarKard"].ToString());
                        }
                        if (DtDaryafti != null && DtDaryafti.Rows.Count > 0)
                        {
                            Daryafti = Convert.ToDouble(DtDaryafti.Rows[0]["Daryafti"].ToString());
                        }
                        txtKarkard.Text = Karkard.ToString();
                        txtDaryafti.Text = Daryafti.ToString();
                        txtMandeh.Text = (Karkard - Daryafti).ToString();

                        GetReportAmareKol(ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(0, 4), ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(5, 2));
                        GetReportAmareKarKard(ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(0, 4), ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(5, 2));
                        GetReportAmarePardakhti(ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(0, 4), ClassLibrary.JDateTime.FarsiDate(StartDate).Substring(5, 2));
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime StartDate = DateTime.Now, EndDate = DateTime.Now;
            StartDate = ClassLibrary.JDateTime.GregorianDate(cmbYears.SelectedValue.ToString() + "/" + cmbMount.SelectedValue.ToString() + "/" + "1", "00:00:00");
            if (Convert.ToInt32(cmbMount.SelectedValue.ToString()) <= 6)
                EndDate = ClassLibrary.JDateTime.GregorianDate(cmbYears.SelectedValue.ToString() + "/" + cmbMount.SelectedValue.ToString() + "/" + "31", "23:59:59");
            else if (Convert.ToInt32(cmbMount.SelectedValue.ToString()) > 6 & Convert.ToInt32(cmbMount.SelectedValue.ToString()) < 12)
                EndDate = ClassLibrary.JDateTime.GregorianDate(cmbYears.SelectedValue.ToString() + "/" + cmbMount.SelectedValue.ToString() + "/" + "30", "23:59:59");
            else if (Convert.ToInt32(cmbMount.SelectedValue.ToString()) == 12)
                EndDate = ClassLibrary.JDateTime.GregorianDate(cmbYears.SelectedValue.ToString() + "/" + cmbMount.SelectedValue.ToString() + "/" + "29", "23:59:59");

            if (Convert.ToDouble(txtMandeh.Text) != 0)
            {
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                DB.setQuery(@"INSERT INTO [dbo].[FinDocument]
                                ([Code]
                                ,[DateSave]
                                ,[DateModifie]
                                ,[UserCode]
                                ,[PostCode]
                                ,[Description]
                                ,[Date]
                                ,[IsOk])
                            VALUES
                                ((Select ISNULL(((select Max(a.Code)+1 from (select Code from FinDocument where code between 800000000 and 899999999)a)),800000000))
                                ,'" + StartDate.ToShortDateString() + @" 00:00:00'
                                ,getdate()
                                ," + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode + @"
                                ," + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode + @"
                                ,N'سند صورت وضعیت " + cmbFleets.SelectedItem.Text + @" برای سال " + cmbYears.SelectedItem.Text + @" ماه " + cmbMount.SelectedItem.Text + @"'
                                ,cast(getdate() as date)
                                ,1)");
                if (DB.Query_Execute() >= 0)
                {
                    DataTable DtMaxFinDocumentCode = WebClassLibrary.JWebDataBase.GetDataTable(@"select Max(a.Code)Code from (select Code from FinDocument where code between 800000000 and 899999999)a");
                    if (Convert.ToDouble(txtMandeh.Text) > 0)
                        DB.setQuery(@"INSERT INTO [dbo].[FinDocumentDetails]
                                        ([Code]
                                        ,[DocCode]
                                        ,[DateSave]
                                        ,[DateModifie]
                                        ,[GroupCode]
                                        ,[KolCode]
                                        ,[MoeinCode]
                                        ,[TafziliCode1]
                                        ,[TafziliCode2]
                                        ,[TafziliCode3]
                                        ,[TafziliCode4]
                                        ,[TafziliCOde5]
                                        ,[BedPrice]
                                        ,[BesPrice]
                                        ,[Description]
                                        ,[ClassName]
                                        ,[ObjectCode])
                                    VALUES
                                        ((select Max(Code)+1 From FinDocumentDetails)
                                        ," + DtMaxFinDocumentCode.Rows[0]["Code"].ToString() + @"
                                        ,'" + StartDate.ToShortDateString() + @" 00:00:00'
                                        ,getdate()
                                        ,1
                                        ,1
                                        ,6
                                        ," + cmbFleets.SelectedItem.Value + @"
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ," + Convert.ToDouble(txtMandeh.Text) / 10 + @"
                                        ,N'سند صورت وضعیت " + cmbFleets.SelectedItem.Text + @" برای سال " + cmbYears.SelectedItem.Text + @" ماه " + cmbMount.SelectedItem.Text + @"'
                                        ,'AUTDailyPerformanceRportOnBus'
                                        ,0)");
                    else
                        DB.setQuery(@"INSERT INTO [dbo].[FinDocumentDetails]
                                        ([Code]
                                        ,[DocCode]
                                        ,[DateSave]
                                        ,[DateModifie]
                                        ,[GroupCode]
                                        ,[KolCode]
                                        ,[MoeinCode]
                                        ,[TafziliCode1]
                                        ,[TafziliCode2]
                                        ,[TafziliCode3]
                                        ,[TafziliCode4]
                                        ,[TafziliCOde5]
                                        ,[BedPrice]
                                        ,[BesPrice]
                                        ,[Description]
                                        ,[ClassName]
                                        ,[ObjectCode])
                                    VALUES
                                        ((select Max(Code)+1 From FinDocumentDetails)
                                        ," + DtMaxFinDocumentCode.Rows[0]["Code"].ToString() + @"
                                        ,'" + StartDate.ToShortDateString() + @" 00:00:00'
                                        ,getdate()
                                        ,1
                                        ,1
                                        ,6
                                        ," + cmbFleets.SelectedItem.Value + @"
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ," + ((Convert.ToDouble(txtMandeh.Text) * (-1)) / 10).ToString() + @"
                                        ,0
                                        ,N'سند صورت وضعیت " + cmbFleets.SelectedItem.Text + @" برای سال " + cmbYears.SelectedItem.Text + @" ماه " + cmbMount.SelectedItem.Text + @"'
                                        ,'AUTDailyPerformanceRportOnBus'
                                        ,0)");
                    if (DB.Query_Execute() >= 0)
                    {
                        txtMandeh.Text = "0";
                        txtDaryafti.Text = "0";
                        txtKarkard.Text = "0";
                        WebClassLibrary.JWebManager.RunClientScript("alert('ثبت سند با موفقیت انجام شد');", "ConfirmDialog");
                    }
                    else
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('خطا در ثبت سند');", "ConfirmDialog");
                    }
                }
                else
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('خطا در ثبت سند');", "ConfirmDialog");
                }
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('مانده ای جهت ثبت سند وجود ندارد');", "ConfirmDialog");
            }
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            DateTime StartDate = DateTime.Now, EndDate = DateTime.Now;
            StartDate = ClassLibrary.JDateTime.GregorianDate(cmbYears.SelectedValue.ToString() + "/" + cmbMount.SelectedValue.ToString() + "/" + "1", "00:00:00");
            if (Convert.ToInt32(cmbMount.SelectedValue.ToString()) <= 6)
                EndDate = ClassLibrary.JDateTime.GregorianDate(cmbYears.SelectedValue.ToString() + "/" + cmbMount.SelectedValue.ToString() + "/" + "31", "23:59:59");
            else if (Convert.ToInt32(cmbMount.SelectedValue.ToString()) > 6 & Convert.ToInt32(cmbMount.SelectedValue.ToString()) < 12)
                EndDate = ClassLibrary.JDateTime.GregorianDate(cmbYears.SelectedValue.ToString() + "/" + cmbMount.SelectedValue.ToString() + "/" + "30", "23:59:59");
            else if (Convert.ToInt32(cmbMount.SelectedValue.ToString()) == 12)
                EndDate = ClassLibrary.JDateTime.GregorianDate(cmbYears.SelectedValue.ToString() + "/" + cmbMount.SelectedValue.ToString() + "/" + "29", "23:59:59");

            DataTable DTKarKard = WebClassLibrary.JWebDataBase.GetDataTable(@"select cast(((sum(BesPrice) * 10.0 * 6.0)/100.0) as bigint) KarKard 
                                                                                            from FinDocumentDetails a
                                                                                            left join FinDocument b on a.DocCode = b.Code
                                                                                            where b.DateSave between '" + StartDate.ToShortDateString() + @" 00:00:00' 
                                                                                            and '" + EndDate.ToShortDateString() + @" 23:59:59'
                                                                                            and MoeinCode = 3
                                                                                            and BesPrice > 0 
                                                                                            and DocCode between 100000000 and 199999999");

            //            DataTable DTKarKard = WebClassLibrary.JWebDataBase.GetDataTable(@"select cast((sum(a.TicketPrice * a.TCount) * 6.0 / 100.0) as float) * 10.0 KarKard from (
            //                                                                                select TicketPrice,sum(TCount)TCount from AUTShiftDriver where Startdate between '" + StartDate.ToShortDateString() + @" 00:00:00'
            //                                                                                and '" + EndDate.ToShortDateString() + @" 23:59:59'
            //                                                                                and Error = 0 and CardType = 0 and len(BusNumber) = 4
            //																				and TicketPrice in (select Price from AUTPrice) and TCount > 0
            //                                                                                group by TicketPrice
            //                                                                                )a");

            DataTable DtDaryafti = WebClassLibrary.JWebDataBase.GetDataTable(@"select (ISNULL(sum(BesPrice),0)-ISNULL(sum(BedPrice),0)) * 10 Daryafti 
                                                                               from FinDocumentDetails 
                                                                               where DateSave between '" + StartDate.ToShortDateString() + @" 00:00:00' and '" + EndDate.ToShortDateString() + @" 23:59:59'
                                                                               and MoeinCode = 6 and DocCode between 800000000 and 899999999");
            double Karkard, Daryafti;
            Karkard = Convert.ToDouble(DTKarKard.Rows[0]["KarKard"].ToString());
            Daryafti = Convert.ToDouble(DtDaryafti.Rows[0]["Daryafti"].ToString());
            txtKarkard.Text = Karkard.ToString();
            txtDaryafti.Text = Daryafti.ToString();
            txtMandeh.Text = (Karkard - Daryafti).ToString();

            GetReportAmareKol(cmbYears.SelectedValue.ToString(), cmbMount.SelectedValue.ToString());
            GetReportAmareKarKard(cmbYears.SelectedValue.ToString(), cmbMount.SelectedValue.ToString());
            GetReportAmarePardakhti(cmbYears.SelectedValue.ToString(), cmbMount.SelectedValue.ToString());
        }


        public void GetReportAmareKol(string Year, string Mount)
        {
            DateTime StartDate = DateTime.Now, EndDate = DateTime.Now;
            StartDate = ClassLibrary.JDateTime.GregorianDate(Year + "/" + Mount + "/" + "1", "00:00:00");
            if (Convert.ToInt32(Mount) <= 6)
                EndDate = ClassLibrary.JDateTime.GregorianDate(Year + "/" + Mount + "/" + "31", "23:59:59");
            else if (Convert.ToInt32(Mount) > 6 & Convert.ToInt32(Mount) < 12)
                EndDate = ClassLibrary.JDateTime.GregorianDate(Year + "/" + Mount + "/" + "30", "23:59:59");
            else if (Convert.ToInt32(Mount) == 12)
                EndDate = ClassLibrary.JDateTime.GregorianDate(Year + "/" + Mount + "/" + "29", "23:59:59");

            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReportAmareKol;//new WebControllers.MainControls.Grid.JGridView("WebBusManagement_JContractorAccountUpdateControl");
            jGridView.ClassName = "WebBusManagement_JContractorAccountUpdateControl_GetReport_RadGridReportAmareKol";
            jGridView.SQL = @"select 1 Code,cast(((sum(BesPrice) * 10.0)) as bigint) KarKardKol,cast(((sum(BesPrice) * 10.0 * 6.0)/100.0) as bigint) DarsadeTarahan 
                                                                                            from FinDocumentDetails a
                                                                                            left join FinDocument b on a.DocCode = b.Code
                                                                                            where b.DateSave between '" + StartDate.ToShortDateString() + @" 00:00:00' 
                                                                                            and '" + EndDate.ToShortDateString() + @" 23:59:59'
                                                                                            and MoeinCode = 3
                                                                                            and BesPrice > 0 
                                                                                            and DocCode between 100000000 and 199999999";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 5;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "JContractorAccountUpdateControl";
            jGridView.Buttons = "excel,print,record_print";
            //((WebControllers.MainControls.Grid.JGridViewControl)RadGridReportAmareKol).GridView = jGridView;
            //((WebControllers.MainControls.Grid.JGridViewControl)RadGridReportAmareKol).LoadGrid(true);
            jGridView.Bind();
        }

        public void GetReportAmareKarKard(string Year, string Mount)
        {
            DateTime StartDate = DateTime.Now, EndDate = DateTime.Now;
            StartDate = ClassLibrary.JDateTime.GregorianDate(Year + "/" + Mount + "/" + "1", "00:00:00");
            if (Convert.ToInt32(Mount) <= 6)
                EndDate = ClassLibrary.JDateTime.GregorianDate(Year + "/" + Mount + "/" + "31", "23:59:59");
            else if (Convert.ToInt32(Mount) > 6 & Convert.ToInt32(Mount) < 12)
                EndDate = ClassLibrary.JDateTime.GregorianDate(Year + "/" + Mount + "/" + "30", "23:59:59");
            else if (Convert.ToInt32(Mount) == 12)
                EndDate = ClassLibrary.JDateTime.GregorianDate(Year + "/" + Mount + "/" + "29", "23:59:59");

           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReportAmareKarKard;//new WebControllers.MainControls.Grid.JGridView("WebBusManagement_JContractorAccountUpdateControl");
            jGridView.ClassName = "WebBusManagement_JContractorAccountUpdateControl_GetReport_RadGridReportAmareKarKard";
            jGridView.SQL = @"select top 100 percent a.Code,dbo.dateentofa(a.DateSave)Date,a.[Description]
                                ,(select sum(BesPrice) from FinDocumentDetails where MoeinCode=3 and DocCode = a.Code)BesPrice 
                                from findocument a
                                inner join users u on a.UserCode = u.Code
                                inner join clsAllPerson cap on cap.code = u.pcode
                                where  a.code between 120000000 and 129999999
                                and a.DateSave between '{0}' and '{1}'
                                and ((select sum(BedPrice) from FinDocumentDetails where DocCode = a.Code) > 0 or (select sum(BesPrice) from FinDocumentDetails where DocCode = a.Code) > 0)";
            jGridView.Parameters = new object[] { StartDate.ToShortDateString() + " 00:00:00", EndDate.ToShortDateString() + " 23:59:59" };
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "JContractorAccountUpdateControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.PageOrderByField = " Date asc ";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("BesPrice", 0);
            //((WebControllers.MainControls.Grid.JGridViewControl)RadGridReportAmareKarKard).GridView = jGridView;
            //((WebControllers.MainControls.Grid.JGridViewControl)RadGridReportAmareKarKard).LoadGrid(true);
            jGridView.Bind();
        }

        public void GetReportAmarePardakhti(string Year, string Mount)
        {
            DateTime StartDate = DateTime.Now, EndDate = DateTime.Now;
            StartDate = ClassLibrary.JDateTime.GregorianDate(Year + "/" + Mount + "/" + "1", "00:00:00");
            if (Convert.ToInt32(Mount) <= 6)
                EndDate = ClassLibrary.JDateTime.GregorianDate(Year + "/" + Mount + "/" + "31", "23:59:59");
            else if (Convert.ToInt32(Mount) > 6 & Convert.ToInt32(Mount) < 12)
                EndDate = ClassLibrary.JDateTime.GregorianDate(Year + "/" + Mount + "/" + "30", "23:59:59");
            else if (Convert.ToInt32(Mount) == 12)
                EndDate = ClassLibrary.JDateTime.GregorianDate(Year + "/" + Mount + "/" + "29", "23:59:59");

            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReportAmarePardakhti;//new WebControllers.MainControls.Grid.JGridView("WebBusManagement_JContractorAccountUpdateControl");
            jGridView.ClassName = "WebBusManagement_JContractorAccountUpdateControl_GetReport_RadGridReportAmarePardakhti";
            jGridView.SQL = @"select top 100 percent a.Code,dbo.dateentofa(a.DateSave)Date,a.[Description]
                                ,(select sum(BesPrice) from FinDocumentDetails where MoeinCode=3 and DocCode = a.Code)BesPrice 
                                from findocument a
                                inner join users u on a.UserCode = u.Code
                                inner join clsAllPerson cap on cap.code = u.pcode
                                where  a.code between 700000000 and 700000999
                                and a.DateSave between '" + StartDate.ToShortDateString() + @" 00:00:00' and '" + EndDate.ToShortDateString() + @" 23:59:59' ";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "JContractorAccountUpdateControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.PageOrderByField = " Date asc ";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("BesPrice", 0);
            //((WebControllers.MainControls.Grid.JGridViewControl)RadGridReportAmarePardakhti).GridView = jGridView;
            //((WebControllers.MainControls.Grid.JGridViewControl)RadGridReportAmarePardakhti).LoadGrid(true);
            jGridView.Bind();
        }


    }
}