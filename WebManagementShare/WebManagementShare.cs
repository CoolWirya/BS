using ManagementShares;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebManagementShare
{
	public class JWebManagementShare
	{
		public const string _ConstClassName = "WebManagementShare.JWebManagementShare";

		public List<JNode> GetNodes()
		{
			List<JNode> nodes = new List<JNode>();

			nodes.Add(new JNode(new List<JActionsInfo>() { 
                new JActionsInfo("ShareHolderInfoClick",
                    JDomains.JActionEvents.MouseClick, _ConstClassName + ".ShowInfo",
                    null, new List<object>() { }) }, "اطلاعات سهامدار", _ConstClassName + ".ShowInfo",
					JDomains.Images.MenuImages.BusManagmentBusStation, null));

			nodes.Add(new JNode(new List<JActionsInfo>() { 
                new JActionsInfo("ShareSheetClick",
                    JDomains.JActionEvents.MouseClick, _ConstClassName + ".ShowShareSheet",
                    null, new List<object>() { }) }, "اطلاعات دارائی", _ConstClassName + ".ShowShareSheet",
		JDomains.Images.MenuImages.BusManagmentBusStation, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { 
                new JActionsInfo("ShowFinanceHistoryClick",
                    JDomains.JActionEvents.MouseClick, _ConstClassName + ".ShowFinanceHistory",
                    null, new List<object>() { }) }, "اطلاعات سوابق مالی", _ConstClassName + ".ShowFinanceHistory",
        JDomains.Images.MenuImages.BusManagmentBusStation, null));
            
            
       //     nodes.Add(new JNode(new List<JActionsInfo>() { 
       //         new JActionsInfo("SharePayment",
       //             JDomains.JActionEvents.MouseClick, _ConstClassName + ".SharePayment",
       //             null, new List<object>() { }) }, "اطلاعات سود", _ConstClassName + ".SharePayment",
       // JDomains.Images.MenuImages.BusManagmentBusStation, null));

       //     nodes.Add(new JNode(new List<JActionsInfo>() { 
       //         new JActionsInfo("SharePaymentType",
       //             JDomains.JActionEvents.MouseClick, _ConstClassName + ".SharePaymentType",
       //             null, new List<object>() { }) }, "نحوه پرداخت سود", _ConstClassName + ".SharePaymentType",
       //JDomains.Images.MenuImages.BusManagmentBusStation, null));

       //     nodes.Add(new JNode(new List<JActionsInfo>() { 
       //         new JActionsInfo("ShareFinanceInfo",
       //             JDomains.JActionEvents.MouseClick, _ConstClassName + ".ShareFinanceInfo",
       //             null, new List<object>() { }) }, "اطلاعات مالی", _ConstClassName + ".ShareFinanceInfo",
       // JDomains.Images.MenuImages.BusManagmentBusStation, null));

			nodes.Add(new JNode(new List<JActionsInfo>() { 
                new JActionsInfo("ShareLastPrice",
                    JDomains.JActionEvents.MouseClick, _ConstClassName + ".ShareLastPrice",
                    null, new List<object>() { }) }, "آخرین تغییرات قیمت سهام", _ConstClassName + ".ShareLastPrice",
		JDomains.Images.MenuImages.BusManagmentBusStation, null));

			nodes.Add(new JNode(new List<JActionsInfo>() { 
                new JActionsInfo("ShareBenefits",
                    JDomains.JActionEvents.MouseClick, _ConstClassName + ".ShareBenefits",
                    null, new List<object>() { }) }, "سودهای مصوب", _ConstClassName + ".ShareBenefits",
		JDomains.Images.MenuImages.BusManagmentBusStation, null));

			nodes.Add(new JNode(new List<JActionsInfo>() { 
                new JActionsInfo("News",
                    JDomains.JActionEvents.MouseClick, _ConstClassName + ".News",
                    null, new List<object>() { }) }, "اخبار", _ConstClassName + ".News",
		JDomains.Images.MenuImages.BusManagmentBusStation, null));

			nodes.Add(new JNode(new List<JActionsInfo>() { 
                new JActionsInfo("SellRequest",
                    JDomains.JActionEvents.MouseClick, _ConstClassName + ".SellRequest",
                    null, new List<object>() { }) }, "درخواست فروش", _ConstClassName + ".SellRequest",
		JDomains.Images.MenuImages.BusManagmentBusStation, null));

			nodes.Add(new JNode(new List<JActionsInfo>() { 
                new JActionsInfo("BuyRequest",
                    JDomains.JActionEvents.MouseClick, _ConstClassName + ".BuyRequest",
                    null, new List<object>() { }) }, "درخواست خرید", _ConstClassName + ".BuyRequest",
		JDomains.Images.MenuImages.BusManagmentBusStation, null));


            //nodes.Add(new JNode(new List<JActionsInfo>()
            //{ new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SendBox", 
            //    null, new List<object>() { }) }, "پیام های ارسالی", _ConstClassName + "._SendBox", JDomains.Images.MenuImages.Item, null));

            //nodes.Add(new JNode(new List<JActionsInfo>()
            //{ new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InBox",
            //    null, new List<object>() { }) }, "پیام های دریافتی", _ConstClassName + "._InBox", JDomains.Images.MenuImages.Item, null));

			nodes.Add(new JNode(new List<JActionsInfo>()
            { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InBoxEnteghad", 
                null, new List<object>() { }) }, "انتقادات و پیشنهادات", _ConstClassName + "._InBoxEnteghad", JDomains.Images.MenuImages.Item, null));

			return nodes;
		}

		public string ShowInfo()
		{
			//string SUID = "ShareHolderInfo";
			//JWebManager.SetControlType(JDomains.JControls.JUserControl, SUID, "~/WebManagementShare/Forms/JShareHolderInfoControl.ascx");
			//WebControllers.MainControls.JWindow window = new WebControllers.MainControls.JWindow(SUID, "اطلاعات سهامدار", true);
			//window.NavigateURL = JWebManager.GenerateControlURL(SUID);
			//window.isModal = false;
			//return WebClassLibrary.JWebManager.LoadClientControl(window.Generate(true, false, false));

			return WebClassLibrary.JWebManager.LoadClientControl("ShareHolderInfo"
				 , "~/WebManagementShare/Forms/JShareHolderInfoControl.ascx"
				 , "اطلاعات سهامدار"
				 , null
				 , WindowTarget.NewWindow
				 , false, true, true, 0, 0, true);
		}

		public string ShowShareSheet()
		{
			return WebClassLibrary.JWebManager.LoadClientControl("ShareSheet"
				 , "~/WebManagementShare/Forms/JShareSheetControl.ascx"
				 , "اطلاعات دارائی"
				 , null
				 , WindowTarget.NewWindow
				 , false, true, true, 0, 0, true);
		}

        public string ShowFinanceHistory()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ShareSheet"
                 , "~/WebManagementShare/Forms/JFinanceHistory.ascx"
                 , "اطلاعات سوابق مالی"
                 , null
                 , WindowTarget.NewWindow
                 , false, true, true, 0, 0, true);
        }


		public string SharePayment()
		{
			//string SUID = "SharePayment";
			//JWebManager.SetControlType(JDomains.JControls.JUserControl, SUID, "~/WebManagementShare/Forms/JSharePaymentControl.ascx");
			//WebControllers.MainControls.JWindow window = new WebControllers.MainControls.JWindow(SUID, "اطلاعات سود", true);
			//window.NavigateURL = JWebManager.GenerateControlURL(SUID);
			//window.isModal = false;
			//return WebClassLibrary.JWebManager.GenerateClientWindow(window.Generate());

			return WebClassLibrary.JWebManager.LoadClientControl("SharePayment"
				, "~/WebManagementShare/Forms/JSharePaymentControl.ascx"
				, "اطلاعات سود"
				, null
				, WindowTarget.NewWindow
				, false, true, true, 0, 0, true);
		}

		public string SharePaymentType()
		{
			return WebClassLibrary.JWebManager.LoadClientControl("SharePaymentType"
				, "~/WebManagementShare/Forms/JSharePaymentTypeControl.ascx"
				, "نحوه پرداخت سود"
				, null
				, WindowTarget.NewWindow
				, false, true, true, 0, 0, true);
		}

		//ShareLastPrice
		public string ShareLastPrice()
		{
			return WebClassLibrary.JWebManager.LoadClientControl("ShareLastPrice"
				, "~/WebManagementShare/Forms/JShareLastPriceControl.ascx"
				, "آخرین تغییرات قیمت سهام"
				, null
				, WindowTarget.NewWindow
				, false, true, true, 0, 0, true);
		}

		//ShareBenefits
		public string ShareBenefits()
		{
			return WebClassLibrary.JWebManager.LoadClientControl("ShareBenefits"
				, "~/WebManagementShare/Forms/JShareBenefitsControl.ascx"
				, "سودهای مصوب"
				, null
				, WindowTarget.NewWindow
				, false, true, true, 0, 0, true);
		}

		//ShareFinanceInfo
		public string ShareFinanceInfo()
		{
			return WebClassLibrary.JWebManager.LoadClientControl("ShareFinanceInfo"
				, "~/WebManagementShare/Forms/JShareFinanceInfoControl.ascx"
				, "اطلاعات مالی"
				, null
				, WindowTarget.NewWindow
				, false, true, true, 0, 0, true);
		}

		public string News()
		{
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
			jGridView.SQL = @"SELECT  [Code],[Title]
                      ,dbo.DateEnToFa([Date]) 'Date'
                       FROM [EntNews]";
			jGridView.Title = "News";
			jGridView.PageOrderByField = "Date Desc";
            jGridView.Buttons = "Refresh";
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			//jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinesNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			//jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinesUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
			jGridView.Toolbar.AddButton("ShowNews", "ShowNews", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShowNews", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
			jGridView.Actions = new List<JActionsInfo>();
			//jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
			jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ShowNews", null, null));
			return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
			//JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
		}

		public string _ShowNews(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("ShowNews"
				  , "~/WebManagementShare/Forms/JShowNewsControl.ascx"
				  , "نمایش خبر"
				  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
				  , WindowTarget.NewWindow
				  , true, false, true, 700, 450);
		}

		//SellAndBuyRequest
		public string SellRequest()
		{
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
			jGridView.SQL = @"Select top 100 percent Code ,'درخواست فروش' as 'Type'
                , RequestDate
                , ShareCount
	            ,Case Status 
		            When 0 then 'در انتظار پاسخ' 
		            When 1 then 'پذیرفته شده' 
		            When 2 then 'رد شده' 
		            When -1 then 'کنسل شده'  end AS RequestStatus
	            from ShareRequestSell where PCode = " + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode.ToString();
			jGridView.Title = "SellRequest";
            jGridView.Buttons = "Refresh";
            jGridView.PageOrderByField = "RequestDate DESC";
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + ".SellRequestNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + ".SellRequesUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
			//jGridView.Toolbar.AddButton("ShowNews", "ShowNews", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShowNews", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
			jGridView.Actions = new List<JActionsInfo>();
			//jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
			jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + ".SellRequesUpdate", null, null));
			return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
			//JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
		}

		public string SellRequestNew()
		{
			return SellRequestNew(null);
		}
		public string SellRequestNew(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("SellReques"
				  , "~/WebManagementShare/Forms/JSellRequestUpdateControl.ascx"
				  , "ثبت درخواست فروش"
				  , null
				  , WindowTarget.NewWindow
				  , true, false, true, 600, 350);
		}
		public string SellRequesUpdate(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("SellReques"
				   , "~/WebManagementShare/Forms/JSellRequestUpdateControl.ascx"
				   , "ویرایش درخواست فروش"
				   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
				   , WindowTarget.NewWindow
				   , true, false, true, 600, 350);
		}

		//BuyRequest
		public string BuyRequest()
		{
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
			jGridView.SQL = @"Select top 100 percent Code, 'درخواست خرید' AS 'Type'
                , RequestDate
                , ShareCount
	            ,Case Status 
		            When 0 then 'در انتظار پاسخ' 
		            When 1 then 'پذیرفته شده' 
		            When 2 then 'رد شده' 
		            When -1 then 'کنسل شده'  end AS RequestStatus
	            from ShareRequestBuy where PCode = " + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode.ToString();
			jGridView.Title = "BuyRequest";
            jGridView.Buttons = "Refresh";
            jGridView.PageOrderByField = "RequestDate DESC";
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + ".BuyRequestNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + ".BuyRequestUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
			//jGridView.Toolbar.AddButton("ShowNews", "ShowNews", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShowNews", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
			jGridView.Actions = new List<JActionsInfo>();
			//jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
			jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + ".BuyRequestUpdate", null, null));
			return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
			//JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
		}


		public string BuyRequestNew()
		{
			return BuyRequestNew(null);
		}
		public string BuyRequestNew(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("SellReques"
				  , "~/WebManagementShare/Forms/JBuyRequestUpdateControl.ascx"
				  , "ثبت درخواست خرید"
				  , null
				  , WindowTarget.NewWindow
				  , true, false, true, 600, 350);
		}
		public string BuyRequestUpdate(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("SellReques"
				   , "~/WebManagementShare/Forms/JBuyRequestUpdateControl.ascx"
				   , "ویرایش درخواست خرید"
				   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
				   , WindowTarget.NewWindow
				   , true, false, true, 600, 350);
		}


		public string _SendBox()
		{
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_SendBox");
			jGridView.SQL = @"Select  ShareMessage.Code, SenderCode, ReceiverCode, Type ,
                                clsAllPerson .Name SenderName ,cap.Name ReceiverName, sDate,Title, Body
                                from ShareMessage
                                INNER JOIN clsAllPerson ON ShareMessage .SenderCode = clsAllPerson .Code
                                INNER JOIN clsAllPerson cap ON ReceiverCode = cap.Code
                                where SenderCode = " + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
			jGridView.Title = "SendBox";
            jGridView.Buttons = "Refresh";
            jGridView.PageOrderByField = "sDate Desc";
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SendBoxNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
		}

		public string _SendBoxNew()
		{
			return _SendBoxNew(null);
		}
		public string _SendBoxNew(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("SendBoxNew"
				   , "~/WebManagementShare/Forms/JSendMessageUpdateControl.ascx"
				   , "ارسال پیام"
				   , null
				   , WindowTarget.NewWindow
				   , true, false, true, 600, 350);
		}

		//_InBox
		public string _InBox()
		{
			ManagementShares.JShareCompany Company = new ManagementShares.JShareCompany(1);
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_InBox");
			jGridView.SQL = @"Select  ShareMessage.Code, SenderCode, ReceiverCode ,
                                clsAllPerson .Name SenderName ,cap.Name ReceiverName, sDate,Title, Body
                                from ShareMessage
                                INNER JOIN clsAllPerson ON ShareMessage .SenderCode = clsAllPerson .Code
                                INNER JOIN clsAllPerson cap ON ReceiverCode = cap.Code
                                where Type = 2 and ReceiverCode in(" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode + @")";
			jGridView.Title = "InBox";
            jGridView.Buttons = "Refresh";
            jGridView.PageOrderByField = "sDate Desc";
			jGridView.PageSize = 5;
			return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
		}

		//_InBoxEnteghad
		public string _InBoxEnteghad()
		{
			ManagementShares.JShareCompany Company = new ManagementShares.JShareCompany(1);
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_InBoxEnteghad");
            jGridView.SQL = @"Select  ShareMessage.Code, SenderCode, ReceiverCode ,
                                (select top 1 sharePCode from SharePCodeSheet where personcode=SenderCode) SharePCode
								,(select name from clsAllPerson where code=SenderCode) SenderName 
								,(select name from clsAllPerson where code=ReceiverCode) ReceiverName,
								 sDate,Title, Body
                                from ShareMessage
                                where Type = 3 and SenderCode in(" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode + @")";
			jGridView.Title = "_InBoxEnteghad";
            jGridView.Buttons = "Refresh";
            jGridView.PageOrderByField = "sDate Desc";
			jGridView.PageSize = 5;
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SendBoxEnteghadNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
		}

		public string _SendBoxEnteghadNew()
		{
			return _SendBoxEnteghadNew(null);
		}
		public string _SendBoxEnteghadNew(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("SendBoxEnteghadNew"
				   , "~/WebManagementShare/Forms/JSendMessageEnteghadUpdateControl.ascx"
				   , "ارسال انتقاد و پیشنهاد"
				   , null
				   , WindowTarget.NewWindow
				   , true, false, true, 600, 350);
		}


	}

    public class JWebManagementShareNew
    {
        public const string _ConstClassName = "WebManagementShare.JWebManagementShareNew";
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            JNode[] Nodes = new JNode[0];
            DataTable companies = new DataTable();
            companies = JShareCompanies.GetDataTable();
            foreach (DataRow row in companies.Rows)
            {
                JShareCompany sc = new JShareCompany(Convert.ToInt32(row["Code"]));
                List<JNode> SubNodes = _CompanyOperationNodes(sc.Code);

                nodes.Add(new JNode(null, (new ClassLibrary.JOrganization(sc.PCode)).Name, _ConstClassName, JDomains.Images.MenuImages.Folder, SubNodes)); 
            }


            return nodes;
        }

        List<JNode> _CompanyOperationNodes(int pCompanyCode)
        {
            List<JNode> gNodes = new List<JNode>();
            gNodes.Add(_PersonNode(pCompanyCode));
            gNodes.Add(_DeactiveSheets(pCompanyCode));
            gNodes.Add(IncreaseShare(pCompanyCode));
            gNodes.Add(JoinSheets(pCompanyCode));
            gNodes.Add(BreakSheets(pCompanyCode));
            //gNodes.Add(Assemblies(pCompanyCode));
            gNodes.Add(DocumentShareOld(pCompanyCode));
            gNodes.Add(_AgentNode(pCompanyCode));
            gNodes.Add(_TransferNode(pCompanyCode));
            gNodes.Add(ReportNode(pCompanyCode));


            //gNodes[10] = _TransferWebNode(pCompanyCode);

            //gNodes[11] = _TransferDataToWebNode(pCompanyCode);


            return gNodes;
        }


        JNode DocumentShareOld(int CompanyCode)
        {
            JNode node = new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentShareOld", null, new List<object>() { CompanyCode }) }, "DocumentShareOld", _ConstClassName + "._DocumentShareOld", JDomains.Images.MenuImages.Item, null);
            //JNode node = new JNode(0, "DocumentShareOld");
            //node.Name = "DocumentShareOld";
            //JAction Ac = new JAction("DocumentShareOld", "ManagementShares.JDocumentShareOlds.ListView", new object[] { CompanyCode }, null);
            //node.MouseClickAction = Ac;
            //node.MouseDBClickAction = Ac;
            //node.Icone = JImageIndex.Bazar.GetHashCode();
            return node;
        }

        public string _DocumentShareOld(int CompanyCode) 
        {
            return "";
        }

        JNode _DeactiveSheets(int CompanyCode)
        {
            JNode node = new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeActiveListView", null, new List<object>() { CompanyCode }) }, "DeactiveSheets", _ConstClassName + "._DeactiveSheets", JDomains.Images.MenuImages.Item, null);
            //JNode node = new JNode(0, "DeActiveSheets");
            //node.Name = "DeActiveSheets";
            //node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JShareSheets.DeActiveListView", new object[] { CompanyCode }, null);
            return node;
        }

        public string _DeActiveListView(int CompanyCode)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_DeactiveSheets";
            jGridView.SQL = ManagementShares.JShareSheets.GetDeactiveSheetsWebQuery(CompanyCode);
            jGridView.Title = "DeactiveSheets";
            jGridView.PageOrderByField = " Name asc ";
            jGridView.PageSize = 50;
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        //JNode Assemblies(int CompanyCode)
        //{
        //    JNode node = new JNode(null, Assemblies, _ConstClassName + ".JAssemblies.ListView", JDomains.Images.MenuImages.Folder, SubNodes);
        //    JNode node = new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentShareOld", null, new List<object>() { CompanyCode }) }, "DocumentShareOld", _ConstClassName + "._DocumentShareOld", JDomains.Images.MenuImages.Item, null);
        //    JNode node = new JNode(0, "Assemblies");
        //    node.Name = "Assemblies";
        //    node.MouseClickAction = new JAction("Assemblies", "ManagementShares.JAssemblies.ListView", null, new object[] { CompanyCode });
        //    ManagementShares.JAssemblies _Assemblies = new JAssemblies(CompanyCode);
        //    node.Childs = _Assemblies.TreeView();
        //    return node;
        //}


        JNode BreakSheets(int CompanyCode)
        {
            JNode node = new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BreakSheets", null, new List<object>() { CompanyCode }) }, "BreakSheets", _ConstClassName + "._BreakSheets", JDomains.Images.MenuImages.Item, null);
            //JNode node = new JNode(0, "ManagementShares.JShareCompany");
            //node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JShareCompany.ShowBreakSheetsForm", new object[] { pCompanyCode }, null);
            //node.Name = "BreakSheets";
            return node;
        }


        JNode IncreaseShare(int CompanyCode)
        {
            JNode node = new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._IncreaseShare", null, new List<object>() { CompanyCode }) }, "IncreaseShare", _ConstClassName + "._IncreaseShare", JDomains.Images.MenuImages.Item, null);
            //JNode node = new JNode(0, "ManagementShares.JShareCompany");
            //node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JShareCompany.ShowIncreaseShareForm", new object[] { pCompanyCode }, null);
            //node.Name = "IncreaseShare";
            return node;
        }
        JNode JoinSheets(int CompanyCode)
        {
            JNode node = new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JoinSheets", null, new List<object>() { CompanyCode }) }, "JoinSheets", _ConstClassName + "._JoinSheets", JDomains.Images.MenuImages.Item, null);
            //JNode node = new JNode(0, "ManagementShares.JShareCompany");
            //node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JShareCompany.ShowJoinSheetsForm", new object[] { pCompanyCode }, null);
            //node.Name = "JoinSheets";
            return node;
        }

        JNode _AgentNode(int CompanyCode)
        {
            JNode node = new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AgentListView", null, new List<object>() { CompanyCode }) }, "Agents", _ConstClassName + "._AgentNode", JDomains.Images.MenuImages.Item, null);
            return node;
        }
        public string _AgentListView(int CompanyCode)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_AgentNode";
            jGridView.SQL = ManagementShares.JShareAgents.GetQuery(JAgentStatus.All, 0, CompanyCode);
            jGridView.Title = "Agents";
            jGridView.PageOrderByField = " AgentName asc ";
            jGridView.PageSize = 50;
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AgentNew", null, new List<object>() { CompanyCode }), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AgentUpdate", null, new List<object>() { CompanyCode }), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("ChangeState", "ChangeState", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ChangeState", null, new List<object>() { CompanyCode }), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Button));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._AgentUpdate", null, new List<object>() { CompanyCode }));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public void _ChangeState(int CompanyCode, string code) 
        { 
            //(new ManagementShares.JShareAgent(Convert.ToInt32(code), CompanyCode)).
        }
        public string _AgentNew(int CompanyCode)
        {
            return _AgentNew(CompanyCode, null);
        }
        public string _AgentNew(int CompanyCode, string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Agents"
                , "~/WebManagementShare/Forms/JAgentUpdateControl.ascx"
                , "وکلا"
                , new List<Tuple<string, string>>(){ 
                    new Tuple<string, string>("CompanyCode", CompanyCode.ToString())}
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }
        public string _AgentUpdate(int CompanyCode, string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Agents"
                , "~/WebManagementShare/Forms/JAgentUpdateControl.ascx"
                , "وکلا"
                , new List<Tuple<string, string>>(){ new Tuple<string, string>("Code", code)
                    , new Tuple<string, string>("CompanyCode", CompanyCode.ToString())}
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }
        JNode _PersonNode(int CompanyCode)
        {
            JNode node = new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PersonListView", null, new List<object>() { CompanyCode }) }, "ShareHolders", _ConstClassName + "._SharePeople", JDomains.Images.MenuImages.Item, null);
            return node;
        }

        public string _PersonListView(int CompanyCode)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_SharePeople";
            jGridView.SQL = ManagementShares.JShareSheets.GetPersonWebQuery(CompanyCode);
            jGridView.Title = "ShareHolders";
            jGridView.PageOrderByField = " Name asc ";
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "companyCode";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SharePeopleNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SharePeopleUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("SharePCode", "SharePCode", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SharePCode", null, new List<object>() { CompanyCode }), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("Transfer", "Transfer", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Transfer", null, new List<object>() { CompanyCode }), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._SharePeopleUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _SharePeopleNew() 
        {
            return _SharePeopleNew(null);
        }

        public string _SharePeopleNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("RealPersons"
                , "~/WebBaseDefine/Forms/JRealPersonUpdateControl.ascx"
                , "شخص حقیقی"
                , null
                , WindowTarget.NewWindow
                , true, true, true, 600, 350);
        }

        public string _SharePeopleUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("RealPersons"
                , "~/WebBaseDefine/Forms/JRealPersonUpdateControl.ascx"
                , "شخص حقیقی"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }

        public string _SharePCode(int CompanyCode, string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SharePaymentType"
                , "~/WebManagementShare/Forms/JSharePCodeUpdateCotrol.ascx"
                , "تغییر کد سهامداری"
                , new List<Tuple<string, string>>(){ new Tuple<string, string>("Code", code)
                    , new Tuple<string, string>("CompanyCode", CompanyCode.ToString())
                    , new Tuple<string, string>("SharePCode", "0")}
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }

        public string _Transfer(int CompanyCode, string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SharePaymentType"
                , "~/WebManagementShare/Forms/JTransferUpdateControl.ascx"
                , "انتقال سهام"
                , new List<Tuple<string, string>>(){ new Tuple<string, string>("Code", code)
                    , new Tuple<string, string>("CompanyCode", CompanyCode.ToString())}
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }
        JNode ReportNode(int CompanyCode)
        {
            JNode node = new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ReportNode", null, new List<object>() { CompanyCode }) }, "ReportNode", _ConstClassName + "._ReportNode", JDomains.Images.MenuImages.Item, null);
            //JNode node = new JNode(0, "ManagementShares.JShareReport");
            //node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JShareReport.ShowReportForm", new object[] { pCompanyCode }, null);
            //node.Name = "Reports";
            return node;
        }

        JNode _TransferNode(int CompanyCode)
        {
            JNode node = new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TransferListView", null, new List<object>() { CompanyCode }) }, "JShareTransfer", _ConstClassName + "._TransferNode", JDomains.Images.MenuImages.Item, null);
            //JNode node = new JNode(0, "ManagementShares.JShareTransfer");
            //node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JTransferSheets.ListView", new object[] { pCompanyCode }, null);
            //node.Name = "JShareTransfer";
            return node;
        }

        public string _TransferListView(int CompanyCode)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_TransferListView";
            jGridView.SQL = ManagementShares.JTransferSheets.GetQuery(CompanyCode);
            jGridView.Title = "JShareTransfer";
            jGridView.PageOrderByField = " Seller asc ";
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "SPCode,FPCode";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("View", "View", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ViewInfo", null, new List<object>() { CompanyCode }), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("ReturnTransfer", "ReturnTransfer", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ReturnTransfer", null, new List<object>() { CompanyCode }), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Delete));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ViewInfo", null, new List<object>() { CompanyCode }));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public void _ReturnTransfer(int CompanyCode, string code)
        {
            JTransferSheet transfer = new JTransferSheet(Convert.ToInt32(code));
            (new ManagementShares.JShareSheet(transfer.SCode)).ReturnTransfer(transfer, true);
        }
        public string _ViewInfo(int CompanyCode, string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SharePaymentType"
                , "~/WebManagementShare/Forms/JTransferUpdateControl.ascx"
                , "انتقال سهام"
                , new List<Tuple<string, string>>(){ new Tuple<string, string>("transferCode", code)
                    , new Tuple<string, string>("CompanyCode", CompanyCode.ToString())}
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }

        JNode TransferWebNode()
        {
            JNode node = new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TransferWebNode", null, new List<object>() {  }) }, "TransferWebNode", _ConstClassName + "._TransferWebNode", JDomains.Images.MenuImages.Item, null);
            //JNode Node = new JNode(0, "JManagementshares");
            //Node.MouseClickAction = new JAction("test", "ManagementShares.FormWebUserChange.ShowDialog");
            //Node.MouseDBClickAction = new JAction("test", "ManagementShares.FormWebUserChange.ShowDialog");
            //Node.Name = "ChangeDataFromWeb";
            return node;
        }

        JNode _TransferDataToWebNode()
        {
            JNode node = new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TransferDataToWebNode", null, new List<object>() {  }) }, "TransferDataToWebNode", _ConstClassName + "._TransferDataToWebNode", JDomains.Images.MenuImages.Item, null);
            //JNode Node = new JNode(0, "JManagementshares");
            //Node.MouseClickAction = new JAction("test", "ManagementShares.JExportDataToWeb.ShowDialog");
            //Node.MouseDBClickAction = new JAction("test", "ManagementShares.JExportDataToWeb.ShowDialog");
            //Node.Name = "TransferDataToWeb";
            return node;
        }

    }
}