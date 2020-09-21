using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace WebBusManagement
{
    public class JBusAccounting
    {
        public const string _ConstClassName = "WebBusManagement.JBusAccounting";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BaseDefine", null, new List<object>() { }) }, "BaseDefine", _ConstClassName + "._BaseDefine", "Images/MainMenu/Apps-basket-icon.png", null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Documents", null, new List<object>() { }) }, "Documents", _ConstClassName + "._Documents", JDomains.Images.MenuImages.BusManagmentDefine, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AccountingDocument", null, new List<object>() { }) }, "AccountingDocument", _ConstClassName + "._AccountingDocument", "Images/MainMenu/billing.png", null));
            
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Payments", null, new List<object>() { }) }, "Payments", _ConstClassName + "._Payments", "Images/MainMenu/Apps-kmymoney-icon.png", null));

            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Installments", null, new List<object>() { }) }, "Installments", _ConstClassName + "._Installments", "Images/MainMenu/taghsit.png", null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentDocumnetMandeh", null, new List<object>() { }) }, "PaymentDocumnetMandeh", _ConstClassName + "._PaymentDocumnetMandeh", JDomains.Images.MenuImages.BusManagmentDefine, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusPayOff", null, new List<object>() { }) }, "BusPayOff", _ConstClassName + "._BusPayOff", "Images/MainMenu/bus-icon.png", null));

            // nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentAndPayment", null, new List<object>() { }) }, "DocumentAndPayment", _ConstClassName + "._DocumentAndPayment", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentDetaileReport", null, new List<object>() { }) }, "PaymentDetaileReport", _ConstClassName + "._PaymentDetaileReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._UnpaidBlackListReportControl", null, new List<object>() { }) }, "UnpaidBlackListReportControl", _ConstClassName + "._UnpaidBlackListReportControl", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._NotPayingBusBlackList", null, new List<object>() { }) }, "NotPayingBusBlackList", _ConstClassName + "._NotPayingBusBlackList", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PeriodPaymentReport", null, new List<object>() { }) }, "PeriodPaymentReport", _ConstClassName + "._PeriodPaymentReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinePeriodPaymentReport", null, new List<object>() { }) }, "LinePeriodPaymentReport", _ConstClassName + "._LinePeriodPaymentReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OwnerPaymentReport", null, new List<object>() { }) }, "OwnerPaymentReport", _ConstClassName + "._OwnerPaymentReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriverPaymentReport", null, new List<object>() { }) }, "DriverPaymentReport", _ConstClassName + "._DriverPaymentReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            // nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentedDocumentReport", null, new List<object>() { }) }, "PaymentedDocumentReport", _ConstClassName + "._PaymentedDocumentReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + ".AccountsReview", null, new List<object>() { }) }, "مرور حساب ها", _ConstClassName + ".AccountsReview", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OnAccountForm", null, new List<object>() { }) }, "OnAccountForm", _ConstClassName + "._OnAccountForm", JDomains.Images.MenuImages.BusManagmentReport, null));

            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AccountReviewReport", null, new List<object>() { }) }, "AccountReviewReport", _ConstClassName + "._AccountReviewReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TotalReport", null, new List<object>() { }) }, "TotalReport", _ConstClassName + "._AccountReviewReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ContractorAccReport", null, new List<object>() { }) }, "ContractorAccountReport", _ConstClassName + "._ContractorAccReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OwnerChangeReport", null, new List<object>() { }) }, "OwnerChangeReport", _ConstClassName + "._OwnerChangeReport", JDomains.Images.MenuImages.BusManagmentReport, null));


            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._CityBankAccountingDocument", null, new List<object>() { }) }, "CityBankAccountingDocument", _ConstClassName + "._CityBankAccountingDocument", JDomains.Images.MenuImages.BusManagmentReport, null));


            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TasfieMandehHesabReport", null, new List<object>() { }) }, "TasfieMandehHesabReport", _ConstClassName + "._TasfieMandehHesabReport", JDomains.Images.MenuImages.BusManagmentReport, null));



            return nodes;
        }

        public string _OwnerChangeReport()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_OwnerChangeReport";
            jGridView.SQL = @"
                select Change.Code, Change.BusNumber, FromOwner.Name FromOwner, ToOwner.Name ToOwner, Change.FromDate, Change.ToDate, usr.Name UserInstaller
                from AUTBusOwnerChange Change
                inner join clsAllPerson FromOwner on FromOwner.Code = Change.FromOwnerCode
                inner join clsAllPerson ToOwner on ToOwner.Code = Change.ToOwnerCode
                inner join clsAllPerson usr on usr.Code = Change.UserPostCode";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "OwnerChangeReport";
            jGridView.PageOrderByField = " Code";
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OwnerChangeNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _OwnerChangeNew(string code)
        {
            return _OwnerChangeNew();
        }

        public string _OwnerChangeNew()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OwnerChangeUpdate"
                , "~/WebBusManagement/FormsManagement/JOwnerChangeUpdateControl.ascx"
                , "تغییر مالک اتوبوس"
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }
        
        public string _TotalReport()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_AccountReviewReport";
            #region SQL
            string PermitionSql = ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBusOwners.GetBusOwners", "a.TafziliCode1");
            jGridView.SQL = @"
select * into #TPardakht  from
(
	select TafziliCode1 
	,(select name from clsAllPerson where code=TafziliCode1) name, 10 * sum(BesPrice) Bes,10 * sum(BedPrice) Bed 
	,(select max(date) MDate from AUTDailyPerformanceRportOnBus where date < getdate() and OwnerCode=TafziliCode1) SDate
	from FinDocumentDetails 
	where  MoeinCode=3 and DocCode between 400000000 and 500000000 
	group by TafziliCode1 
) as a

	select * into #TKarkard from
	(
		select TafziliCode1 
		,(select name from clsAllPerson where code=TafziliCode1) name
		,(select 10 * sum(isnull(BesPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=1 and code not in (120160534)) is not null) and b.TafziliCode1=a.TafziliCode1 and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bes
		,(select 10 * sum(isnull(BedPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=1 and code not in (120160534)) is not null) and b.TafziliCode1=a.TafziliCode1 and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bed

		,(select 10 * sum(isnull(BesPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=1 and code not in (120160534)) is not null) and b.TafziliCode1=a.TafziliCode1 and MoeinCode=3 and DocCode between 100000000 and 200000000 and TafziliCode2 is not null ) BesRealDoc
		,(select 10 * sum(isnull(BedPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=1 and code not in (120160534)) is not null) and b.TafziliCode1=a.TafziliCode1 and MoeinCode=3 and DocCode between 100000000 and 200000000 and TafziliCode2 is not null ) BedRealDoc

		,(select 10 * sum(isnull(BesPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=0 and code not in (120160534)) is not null) and b.TafziliCode1=a.TafziliCode1 and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bes0
		,(select 10 * sum(isnull(BedPrice,0)) Mandeh from FinDocumentDetails b where ((select code from FinDocument where code=b.DocCode and IsOk=0 and code not in (120160534)) is not null) and b.TafziliCode1=a.TafziliCode1 and MoeinCode=3 and DocCode between 100000000 and 200000000 ) Bed0

		from FinDocumentDetails a
		where 
		MoeinCode=3 and DocCode between 100000000 and 200000000 
		group by TafziliCode1 
	) as a


select OwnerPCode, 10 * sum(TCount * cast(TicketPrice as bigint)) TransactionKarkard
into #TShift
from AUTShiftDriver
where CardType=0 and TicketPrice  in (select distinct Price from AUTPrice) and Error=0
	and BusNumber in (select BusNumber from AUTBus where IsValid = 1)
group by OwnerPCode
<#PreviusSQL#>

select TafziliCode1 Code
,(select Value from finComparativeCode where ObjectCode = OwnerPCode) OwnerPCode
,name, TransactionKarkard,BesDoc FinancialKarKard
,isnull(BesDoc0,0) NotVerifiedKarKard
,TransactionKarkard-(BesRealDoc + isnull(BesDoc0,0)) NoDocKarkard
,BedDoc Pardakht
,CASE WHEN BesDoc-BedDoc > 0 THEN BesDoc-BedDoc ELSE 0 END BESMandeh
,CASE WHEN BedDoc-BesDoc > 0 THEN BedDoc-BesDoc ELSE 0 END BEDMandeh
from
(
	select a.TafziliCode1,d.OwnerPCode, a.name, isnull(TransactionKarkard,0)TransactionKarkard,cast(a.Bes-a.bed as bigint) BesDoc,cast(a.BesRealDoc-a.BedRealDoc as bigint) BesRealDoc,cast(a.Bes0-a.bed0 as bigint) BesDoc0,cast(c.Bed-c.bes as bigint) BedDoc
	from #TKarkard as a
	full join
	#TPardakht as c on c.TafziliCode1=a.TafziliCode1
	full join
	#TShift d on a.TafziliCode1=d.OwnerPCode
) as a
where " + PermitionSql;
            #endregion
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "TotalReport";
            jGridView.PageOrderByField = " Code";
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.MoneyColumns = "TransactionKarkard,FinancialKarKard,NotVerifiedKarKard,NoDocKarkard,Pardakht,BesMandeh,BedMandeh";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("MoeinReport", "MoeinReport", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MoeinReport", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("DocMoeinReport", "DocMoeinReport", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocMoeinReport", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("AccountReviewReport", "AccountReviewReport", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MonthlyAccReviewReport", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("OverPayReport", "OverPayReport", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OverPayReport", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            if (ClassLibrary.JPermission.CheckPermission(_ConstClassName + ".AccountReviewReport.TaghsitMandehHesab"))
                jGridView.Toolbar.AddButton("TaghsitMandehHesab", "TaghsitMandehHesab", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TaghsitMandehHesab", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            if (ClassLibrary.JPermission.CheckPermission(_ConstClassName + ".AccountReviewReport.OwnersFinancialTransfer"))
                jGridView.Toolbar.AddButton("OwnersFinancialTransfer", "OwnersFinancialTransfer", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OwnersFinancialTransfer", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("GetEqualizationFile", "GetEqualizationFile", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GetEqualizationFile", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._MoeinReport", null, null));
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("TransactionKarkard", 0);
            jGridView.SumFields.Add("FinancialKarKard", 0);
            jGridView.SumFields.Add("NotVerifiedKarKard", 0);
            jGridView.SumFields.Add("NoDocKarkard", 0);
            jGridView.SumFields.Add("Pardakht", 0);
            jGridView.SumFields.Add("BesMandeh", 0);
            jGridView.SumFields.Add("BedMandeh", 0);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public string _MonthlyAccReviewReport(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("MonthlyAccReviewReport"
                  , "~/WebBusManagement/FormsReports/JMonthlyAccReviewReportControl.ascx"
                  , "گزارش مرور حساب ماهانه"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        public string _DocMoeinReport(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DocMoeinReport"
                  , "~/WebBusManagement/FormsReports/JDocumentMoeinReportControl.ascx"
                  , "گزارش معین سند"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        public string _MoeinReport(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("MoeinReport"
                  , "~/WebBusManagement/FormsReports/JMoeinReportControl.ascx"
                  , "گزارش معین اتوبوس"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        public string _OverPayReport(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OverPayReport"
                  , "~/WebBusManagement/FormsReports/JOverPayReportControl.ascx"
                  , "گزارش اضافه پرداخت"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 400);
        }
        public string _OwnersFinancialTransfer(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OwnersFinancialTransfer"
                  , "~/WebBusManagement/FormsManagement/JOwnersFinancialTransferUpdateControl.ascx"
                  , "انتقال مالی بین بهره برداران"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 500, 300);
        }

        public string _GetEqualizationFile(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GetEqualizationFile"
                  , "~/WebBusManagement/FormsReports/JBusGetEqualizationFile.ascx"
                  , "فایل تسویه"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 800, 650);
        }
        public string _OwnersFinancialTransfer()
        {
            return "";
        }
        public string _TaghsitMandehHesab(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TaghsitMandehHesab"
                  , "~/WebBusManagement/FormsManagement/JTaghsitMandehHesabUpdateControl.ascx"
                  , "تقسیط مانده حساب"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }

        //public string _AccountReviewDetailReport(string Type, string code)
        //{
        //    string Title = "";
        //    switch (Type)
        //    {
        //        case "Karkard":
        //            Title = "گزارش کارکرد";
        //            break;
        //        case "Pardakht":
        //            Title = "گزارش پرداخت";
        //            break;
        //        case "Total":
        //            Title = "گزارش مرور حساب";
        //            break;
        //    }
        //    return WebClassLibrary.JWebManager.LoadClientControl("AccountReviewReport"
        //          , "~/WebBusManagement/FormsReports/JTransactionsDetailsReportControl.ascx"
        //          , Title
        //          , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code), new Tuple<string, string>("Type", Type) }
        //          , WindowTarget.NewWindow
        //          , true, false, true, 700, 400);
        //}

        public string _TasfieMandehHesabReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TasfieMandehHesabReport"
                  , "~/WebBusManagement/FormsReports/JTasfieMandehHesabReportControl.ascx"
                  , "گزارش تسویه مانده حساب"
                  , null
                  , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_OnAccountForm
        public string _OnAccountForm()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OnAccountForm"
                , "~/WebBusManagement/FormsManagement/JOnAccountFormUpdateControl.ascx"
                , "فرم علی الحساب"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_AccountReviewReport
        public string _AccountReviewReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AccountReviewReport"
                , "~/WebBusManagement/FormsManagement/JAccountReviewReportControl.ascx"
                , "گزارش مرور حساب ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string AccountsReview()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AccountsReview"
                , "~/WebBusManagement/FormsManagement/JAccountingReview.ascx"
                , "مرور حساب ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }
        public string _BaseDefine()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BaseDefine"
                , "~/WebBusManagement/FormsManagement/JAccountingBaseDefineReportControl.ascx"
                , "تعاریف پایه حسابداری"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _DocumentAndPayment()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DocumentAndPayment"
                , "~/WebBusManagement/FormsReports/JDocumentAndPaymentReportControl.ascx"
                , "گزارش اسناد و پرداختی ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _PaymentDetaileReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PaymentDetaileReport"
                , "~/WebBusManagement/FormsReports/JPaymentDetaileReportControl.ascx"
                , "گزارش جزئیات پرداختی ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _NotPayingBusBlackList()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_NotPayingBusBlackList"; ;
            jGridView.SQL = BusManagment.NotPayingBus.JNotPayingBuses.GetWebQuery();
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "NotPayingBusBlackList";
            jGridView.PageOrderByField = " Code";
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._NotPayingBusBlackListNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._NotPayingBusBlackListUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._NotPayingBusBlackListUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public string _NotPayingBusBlackListNew()
        {
            return _NotPayingBusBlackListNew(null);
        }
        public string _NotPayingBusBlackListNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("NotPayingBlackListUpdateControl"
                  , "~/WebBusManagement/FormsManagement/JNotPayingBusBlackListUpdatecontrol.ascx"
                  , "لیست سیاه عدم پرداخت اتوبوس"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        public string _NotPayingBusBlackListUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("NotPayingBlackListUpdateControl"
                  , "~/WebBusManagement/FormsManagement/JNotPayingBusBlackListUpdatecontrol.ascx"
                  , "لیست سیاه عدم پرداخت اتوبوس"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        public string _UnpaidBlackListReportControl()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_UnpaidBlackList"; ;
            jGridView.SQL = @"IF OBJECT_ID('tempdb..#TTT') IS NOT NULL DROP Table #TTT
select UnpaidBlackList.*,FinDocumentDetails.Code FCode into #TTT from FinDocumentDetails 
                            inner join UnpaidBlackList ON FinDocumentDetails.DateSave between FromDate and ToDate and pCode=TafziliCode1
                            where 1=1
	                            and DocCode between 100000000 and 200000000
	                            and (select code from FinDocument where code=DocCode and IsOk=1) is not null
	                            and DocCode<>120160534	
								<#PreviusSQL#>
	                            select TOP 100 PERCENT *
	                            from
	                            (
		                            select TOP 100 PERCENT B.Code,B.pCode OwnerPCode,
                                    (select Name From clsAllPerson where Code = B.pCode)OwnerName,
		                            B.FromDate,B.ToDate
                                    ,ISNULL(CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT),0) BlockPrice
                                    ,ISNULL(CASE WHEN isnull(B.PayAfterFinish,0)=0 then CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT) else 0 end,0) RealBlockPrice
									,isnull(B.PayAfterFinish,0) PayAfterFinish
                                    from FinDocumentDetails
		                            inner join FinDocument on FinDocument.code = FinDocumentDetails.DocCode and MoeinCode = 3 and FinDocument.IsOk = 1
									inner join #TTT T on T.FCode = FinDocumentDetails.Code and T.Pcode=findocumentdetails.tafzilicode1
									right join UnpaidBlackList B ON B.Code = T.Code
                                    group by B.pCode,B.Code,B.FromDate,B.ToDate,B.PayAfterFinish
	                            ) as a";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "UnpaidBlackListReportControl";
            jGridView.PageOrderByField = " Code";
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.MoneyColumns = "BlockedPrice";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._UnpaidBlackListReportControlNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._UnpaidBlackListReportControlUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._UnpaidBlackListReportControlUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public string _UnpaidBlackListReportControlNew()
        {
            return _UnpaidBlackListReportControlNew(null);
        }
        public string _UnpaidBlackListReportControlNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("UnpaidBlackListReportControl"
                  , "~/WebBusManagement/FormsManagement/JUnpaidBlackListReportControl.ascx"
                  , "لیست سیاه عدم پرداخت"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        public string _UnpaidBlackListReportControlUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("UnpaidBlackListReportControl"
                  , "~/WebBusManagement/FormsManagement/JUnpaidBlackListReportControl.ascx"
                  , "لیست سیاه عدم پرداخت"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }

        public string _PeriodPaymentReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PeriodPaymentReport"
                            , "~/WebBusManagement/FormsReports/JPeriodPaymentReportControl.ascx"
                            , "گزارش پرداخت ها در دوره های زمانی"
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }

        public string _LinePeriodPaymentReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LinePeriodPaymentReport"
                            , "~/WebBusManagement/FormsReports/JLinePeriodPaymentReportControl.ascx"
                            , "گزارش پرداختی خطوط در دوره های زمانی"
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }

        public string _OwnerPaymentReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OwnerPaymentReport"
                            , "~/WebBusManagement/FormsReports/JOwnerPaymentReportControl.ascx"
                            , "گزارش مالی مالک"
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }

        //_DriverPaymentReport
        public string _DriverPaymentReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DriverPaymentReport"
                            , "~/WebBusManagement/FormsReports/JDriverPaymentReportControl.ascx"
                            , "گزارش مالی راننده"
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }

        //_PaymentedDocumentReport
        public string _PaymentedDocumentReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PaymentedDocumentReport"
                            , "~/WebBusManagement/FormsReports/JPaymentedDocumentReportControl.ascx"
                            , "گزارش اسناد پرداخت شده"
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }


        //_CityBankAccountingDocument
        public string _CityBankAccountingDocument()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
           jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_CityBankAccountingDocument";
            jGridView.SQL = @"select top 100 percent Code,Name,TransactionCount,TransactionSum * 10 TransactionSum,Date,InsertDate from [AutCityBankSettlementFile]";
            jGridView.Title = "CityBankAccountingDocument";
            //jGridView.HiddenColumns = "IsClosed";
            jGridView.PageOrderByField = "InsertDate desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //jGridView.Toolbar.AddButton("PaymentDocument", "PaymentDocument", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentAccDocument", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("DocumentsGetDetail", "DocumentsGetDetail", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._CityBankAccDocumentsGetDetail", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("GetFile", "GetFile", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._CityBankPaymentsGetFile", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._AccDocumentsGetDetail", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _CityBankPaymentsGetFile(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("CityBankPaymentsGetFile"
                 , "~/WebBusManagement/FormsManagement/JCityBankPaymentsGetFile.ascx"
                 , "دریافت فایل بانک"
                 , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                 , WindowTarget.NewWindow
                 , true, true, true, 200, 200);
        }

        public string _CityBankAccDocumentsGetDetail(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("CityBankAccDocumentsGetDetail"
                  , "~/WebBusManagement/FormsManagement/JCityBankAccDocumentsGetDetailReportControl.ascx"
                  , "مشاهده جزئیات سند"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }



        //_AccountingDocument
        public string _AccountingDocument()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_AccountingDocument";
            //            jGridView.SQL = @"select top 100 percent fd.[Code]
            //                                      ,fd.[DateSave]
            //                                      ,fd.[DateModifie]
            //                                      ,cap.Name
            //                                      ,cast(fd.[Description] as nvarchar(max))Description
            //                                      ,fd.[Date],
            //	                                  sum(fdd.bedprice)BedPrice
            //	                                  ,sum(fdd.Besprice)BesPrice,case Max(ISOk) when 0 then N'تایید نشده' else N'تایید شده' end as Status from findocument fd
            //                                inner join FinDocumentDetails fdd on fd.Code = fdd.DocCode
            //                                inner join users u on fd.UserCode = u.Code
            //                                inner join clsAllPerson cap on cap.code = u.pcode
            //                                where left(fd.Code,1) in (1,4)
            //                                group by fd.[Code],
            //                                fd.[DateSave]
            //                                      ,fd.[DateModifie]
            //                                      ,cap.Name
            //                                      ,cast(fd.[Description] as nvarchar(max))
            //                                      ,fd.[Date]";
            jGridView.SQL = @"select top 100 percent a.Code,a.DateSave,a.[DateModifie],a.Name,a.[Description],a.BedPrice,a.BesPrice,a.Status from (
                                select a.Code,a.DateSave,a.[DateModifie],cap.Name,a.[Description]
                                                                ,(select sum(BedPrice) from FinDocumentDetails where DocCode = a.Code)BedPrice
                                                                ,(select sum(BesPrice) from FinDocumentDetails where DocCode = a.Code)BesPrice
                                                                ,case a.ISOk when 0 then N'تایید نشده' else N'تایید شده' end as Status 
                                                                from findocument a
                                                                inner join users u on a.UserCode = u.Code
                                                                inner join clsAllPerson cap on cap.code = u.pcode
                                                                where a.Code < 700000000   
                                )a
                                where a.BedPrice > 0 or a.BesPrice > 0";
            jGridView.Title = "AccountingDocument";
            jGridView.PageOrderByField = "DateSave desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("DocumentsGetDetail", "DocumentsGetDetail", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AccDocumentsGetDetail", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("DocumentsApply", "DocumentsApply", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentsApply", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("DocumentsEdit", "DocumentsEdit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentsEdit", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("DocumentsTransfer", "DocumentsTransfer", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentsTransfer", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Outbox));
            jGridView.Toolbar.AddButton("DocumentsEditComment", "DocumentsEditComment", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentsEditComment", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Menu_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._AccDocumentsGetDetail", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        //_PaymentAccDocument
        public string _PaymentAccDocument(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PaymentDocument"
                  , "~/WebBusManagement/FormsManagement/JPaymentsUpdateControl.ascx"
                  , "پرداختها"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }

        //_AccDocumentsGetDetail
        public string _AccDocumentsGetDetail(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AccDocumentsGetDetail"
                  , "~/WebBusManagement/FormsManagement/JAccDocumentsGetDetailReportControl.ascx"
                  , "مشاهده جزئیات سند"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }

        public string _DocumentsApply(string code)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            string UpdateQuery = "";
            UpdateQuery = @"update findocument set ISOk = 1 where Code = " + code;
            Db.setQuery(UpdateQuery);
            if (Db.Query_Execute() >= 0)
                return WebClassLibrary.JWebManager.LoadClientControl("AccDocumentsGetDetail"
                  , "~/WebBusManagement/FormsManagement/JDeleteApplyControl.ascx"
                  , "تایید سند"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 500, 350);
            else
                return "";
        }

        public string _DocumentsEdit(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AccDocumentsGetDetail"
                  , "~/WebBusManagement/FormsManagement/JAccDocumentsEditUpdateControl.ascx"
                  , "ویرایش جزئیات سند"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }

        public string _DocumentsEditComment(string code)
        {
            if (ClassLibrary.JPermission.CheckPermission("WebBusManagement.JBusManagement._DocumentsEditComment"))
            {
                return WebClassLibrary.JWebManager.LoadClientControl("AccDocumentsGetDetail"
                      , "~/WebBusManagement/FormsManagement/JAccDocumentsEditCommentUpdateControl.ascx"
                      , "ویرایش شرح سند"
                      , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                      , WindowTarget.NewWindow
                      , true, true, true, 600, 350);
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('شما دسترسی مورد نیاز برای انجام این عملیات را ندارید');", "err");
                return "";
            }
        }

        public string _PaymentEditComment(string code)
        {
            if (ClassLibrary.JPermission.CheckPermission("WebBusManagement.JBusManagement._DocumentsEditComment"))
            {
                return WebClassLibrary.JWebManager.LoadClientControl("AccPaymentsGetDetail"
                      , "~/WebBusManagement/FormsManagement/JAccPaymentEditCommentUpdateControl.ascx"
                      , "ویرایش شرح سند"
                      , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                      , WindowTarget.NewWindow
                      , true, true, true, 600, 350);
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('شما دسترسی مورد نیاز برای انجام این عملیات را ندارید');", "err");
                return "";
            }
        }


        public string _DocumentsTransfer(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AccDocumentsTransfer"
                  , "~/WebBusManagement/FormsManagement/JAccDocumentsTransferUpdateControl.ascx"
                  , "انتقال سند"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 300);
        }


        public string _ContractorAccReport()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_ContractorAccountReport";
            jGridView.SQL = @"select Code,Description,SUM(Bes) KarKard,sum(Par) ParDakht from
                            (
                            select FD.ContractorDocCode Code,cast(F.Description as nVarchar(max)) Description
                            ,(select cast(sum(BesPrice) as bigint)*10 from FinDocumentDetails where DocCode=FD.DocCode and MoeinCode=3) Bes
                            ,(select cast(sum(BedPrice) as bigint)*10 from FinDocumentDetails where DocCode=FD.DocCode and MoeinCode=3) Bed
                            ,(select cast(sum(TotalPrice) as bigint)*10 from AutPaymentDetail where PaymentCode=FD.PaymentCode) Par
                            from FinDocumentPayment FD
                            left join FinDocument F ON FD.ContractorDocCode=F.Code
                            ) a
                            group by Code,Description
                            ";
            jGridView.Title = "ContractorAccountReport";
            jGridView.PageOrderByField = "Code desc";
            jGridView.MoneyColumns = "KarKard,ParDakht";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ContractorAccountNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ContractorUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ContractorUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _ContractorAccountNew()
        {
            return _ContractorAccountNew(null);
        }
        public string _ContractorAccountNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ContractorAccount"
                //, "~/WebBusManagement/FormsManagement/JContractorAccountUpdateControl.ascx"
                , "~/WebBusManagement/FormsManagement/JTarahanAccountUpdateControl.ascx"
                  , "صورت وضعیت طراحان کنترل شرق"
                  , null
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 450);
        }

        public string _ContractorUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ContractorAccount"
                //, "~/WebBusManagement/FormsManagement/JContractorAccountUpdateControl.ascx"
                , "~/WebBusManagement/FormsManagement/JTarahanAccountUpdateControl.ascx"
                  , "صورت وضعیت طراحان کنترل شرق"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 450);
        }

        //_Documents
        public string _Documents()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Documents";
            jGridView.SQL = BusManagment.Documents.JAUTDocuments.GetWebQuery();
            jGridView.Title = "Documents";
            jGridView.HiddenColumns = "IsClosed";
            jGridView.PageOrderByField = "IssueDate desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("DocumentsGetDetail", "DocumentsGetDetail", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentsGetDetail", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            //jGridView.Toolbar.AddButton("PaymentDocument", "PaymentDocument", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentDocument", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("GetDocumentZoneFile", "GetDocumentZoneFile", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GetDocumentZoneFile", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._DocumentsGetDetail", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _DocumentsNew()
        {
            return _DocumentsNew(null);
        }
        public string _DocumentsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Documents"
                  , "~/WebBusManagement/FormsManagement/JDocumentsUpdateControl.ascx"
                  , "اسناد"
                  , null
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }
        public string _DocumentsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Documents"
                  , "~/WebBusManagement/FormsManagement/JDocumentsUpdateControl.ascx"
                  , "اسناد"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }

        public string _DocumentsGetDetail(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DocumentsGetDetail"
                  , "~/WebBusManagement/FormsManagement/JDocumentsGetDetailReportControl.ascx"
                  , "مشاهده جزئیات سند"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }

        //_GetDocumentZoneFile
        public string _GetDocumentZoneFile(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GetDocumentZoneFile"
                  , "~/WebBusManagement/FormsManagement/JDocumentsGetDocumentZoneFile.ascx"
                  , "دریافت فایل سند"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 200, 200);
        }

        public string _PaymentDocument(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PaymentDocument"
                  , "~/WebBusManagement/FormsManagement/JPaymentsUpdateControl.ascx"
                  , "پرداختها"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }


        //_Payments
        public string _Payments()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Payments";
            jGridView.SQL = BusManagment.Documents.JAUTPayments.GetWebQuery();
            jGridView.Title = "Payments";
            jGridView.PageOrderByField = "PaymentDate desc,Code desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));

            //  jGridView.Toolbar.AddButton("PaymentMadeh", "PaymentMadeh", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentMadeh", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));

            jGridView.Toolbar.AddButton("GetFile", "GetFile", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentsGetFile", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("GetAccountingFile", "GetAccountingFile", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GetAccountingFile", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("GetAccountingFileexcel", "GetAccountingFileexcel", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GetAccountingFileexcel", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("PaymentGetDetail", "PaymentGetDetail", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentGetDetail", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("DocumentsEditComment", "DocumentsEditComment", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentEditComment", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Menu_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._PaymentGetDetail", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _PaymentsNew()
        {
            return _PaymentsNew(null);
        }
        public string _PaymentsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Payments"
                  , "~/WebBusManagement/FormsManagement/JPaymentsUpdateControl.ascx"
                  , "پرداختها"
                  , null
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }
        public string _PaymentsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Payments"
                , "~/WebBusManagement/FormsManagement/JPaymentsUpdateControl.ascx"
                , "پرداختها"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, true, true, 600, 350);
        }

        //_PaymentMadeh
        public string _PaymentMadeh()
        {
            return _PaymentMadeh(null);
        }
        public string _PaymentMadeh(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PaymentMadeh"
                  , "~/WebBusManagement/FormsManagement/JPaymentMadehUpdateControl.ascx"
                  , "ثبت سندهای مانده ها"
                  , null
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }

        public string _PaymentsGetFile(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PaymentsGetFile"
                 , "~/WebBusManagement/FormsManagement/JPaymentsGetFile.ascx"
                 , "دریافت فایل بانکی"
                 , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                 , WindowTarget.NewWindow
                 , true, true, true, 200, 200);
        }

        public string _GetAccountingFile(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GetAccountingFile"
                 , "~/WebBusManagement/FormsManagement/JPaymentsGetAccountingFile.ascx"
                 , "دریافت فایل حسابداری"
                 , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                 , WindowTarget.NewWindow
                 , true, true, true, 200, 200);
        }

        public string _GetAccountingFileexcel(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GetAccountingFileexcel"
                 , "~/WebBusManagement/FormsManagement/JPaymentsGetAccountingFileexcel.ascx"
                 , "دریافت فایل اکسل حسابداری"
                 , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                 , WindowTarget.NewWindow
                 , true, true, true, 200, 200);
        }
        //_GetZoneFile
        public string _GetZoneFile(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GetZoneFile"
                 , "~/WebBusManagement/FormsManagement/JPaymentsGetZoneFile.ascx"
                 , "دریافت فایل مناطق"
                 , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                 , WindowTarget.NewWindow
                 , true, true, true, 200, 200);
        }

        public string _PaymentGetDetail(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PaymentGetDetail"
                , "~/WebBusManagement/FormsManagement/JPaymentGetDetailReportControl.ascx"
                , "مشاهده جزئیات سند پرداختی"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, true, true, 600, 350);
        }
        public string _Installments()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Installments"
                            , "~/WebBusManagement/FormsManagement/JInstallmentUpdateControl.ascx"
                            , "تقسیط مانده حساب ها"
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }
        public string _BusPayOff()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusPayOff"
                            , "~/WebBusManagement/FormsManagement/JBusPayOffUpdateControl.ascx"
                            , "تصفیه حساب اتوبوس ها"
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }

    }
}