using Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;
using WebControllers.MainControls;
using JComponents;
using ClassLibrary.DataBase;

namespace WebAutomation
{
	public class JCommunication
	{
		////-----------------------------------------------------------------------------------------------------
		public const string _ConstClassName = "WebAutomation.JCommunication";
		////-----------------------------------------------------------------------------------------------------
		public string WebCommunication()
		{
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));

			string query = JCLetter.GetWebQuery("register_post_code = " + ClassLibrary.JMainFrame.CurrentPostCode.ToString());

			jGridView.SQL = query;
			jGridView.PageOrderByField = "Code Desc";
			jGridView.Title = "Letters";
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();

			jGridView.Toolbar.AddButton("NewJLetter", "نامه داخلی جدید", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + ".NewJLetter"
		  , null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));

			jGridView.Toolbar.AddButton("NewJImportedLetter", "نامه وارده جدید", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + ".NewJImportedLetter"
		   , null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));

			jGridView.Toolbar.AddButton("NewJExportedLetter", "نامه صادره جدید", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + ".NewJExportedLetter"
				, null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));

			jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + ".WebCommunicationUpdate"
				, null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));

			jGridView.ClassName = JAutomation._ConstClassName;
			jGridView.Actions = new List<JActionsInfo>();
			jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + ".WebCommunicationUpdate", null, null));

			//jGridView.SumFields = new Dictionary<string, double>();
			//jGridView.SumFields.Add("Code", 0);
			//jGridView.SumFields.Add("ParentCode", 0);

			return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

		}

		public string WebCommunicationUpdate(string code)
		{
			return WebCommunicationUpdate(code, "0");
		}
		////-----------------------------------------------------------------------------------------------------
		public string WebCommunicationUpdate(string code, string RefCode = "0", string currentPage = "")
		{
			Communication.JCLetter jcLetter;//= new Communication.JCLetter();
			jcLetter = new Communication.JCLetter(int.Parse(code));
			string result = string.Empty;
			//jcLetter.GetData();
			//3 then N'داخلی' when 2 then N'وارده' when 1 then N'صادره'
			switch (jcLetter.letter_type)
			{
				case 1:
					int ReferCode = int.Parse(RefCode);
					if (ReferCode > 0)
					{
						result =
									WebClassLibrary.JWebManager.LoadClientControl("Letters"
										 , "~/WebAutomation/WebCommunication/JLetteViewControl.ascx"
										 , "نامه وارده"
										 , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code)
                                                                                      , new Tuple<string, string>("Type", jcLetter.letter_type.ToString())
                                                                                      ,  new Tuple<string, string>("ReferCode", RefCode)
                                                                                      , new Tuple<string, string>("CurrentPage", currentPage) }
										 , WindowTarget.NewWindow
										 , true, true, true, 750, 500);

						// ReferCode = Convert.ToInt32(code);
						Automation.JARefer jAuto = new Automation.JARefer(ReferCode);
						jAuto.view_date_time = ClassLibrary.JDateTime.Now();
						jAuto.Update();
					}
					else
					{
						result = WebClassLibrary.JWebManager.LoadClientControl("Letters"
											  , "~/WebAutomation/WebCommunication/JImportedLetterUpdateControl.ascx"
											  , "ویرایش نامه وارده"
											  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code)
                                                                                    , new Tuple<string, string>("Type", jcLetter.letter_type.ToString()) 
                                                                                     ,  new Tuple<string, string>("ReferCode", RefCode)
                                                                                      , new Tuple<string, string>("CurrentPage", currentPage) }

												 , WindowTarget.NewWindow
												 , true, true, true, 750, 500);
					}
					break;
				case 2:
					if (jcLetter.isSigned)
					{
						ReferCode = int.Parse(RefCode);
						result =
									WebClassLibrary.JWebManager.LoadClientControl("Letters"
										 , "~/WebAutomation/WebCommunication/JLetteViewControl.ascx"
										 , "نامه صادره"
										  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code)
                                                                                      , new Tuple<string, string>("Type", jcLetter.letter_type.ToString())
                                                                                      ,  new Tuple<string, string>("ReferCode", RefCode)
                                                                                      , new Tuple<string, string>("CurrentPage", currentPage) }
										 , WindowTarget.NewWindow
										 , true, true, true, 750, 500);

						//  ReferCode = Convert.ToInt32(code);
						Automation.JARefer jAuto = new Automation.JARefer(ReferCode);
						jAuto.view_date_time = ClassLibrary.JDateTime.Now();
						jAuto.Update();
					}
					else
					{
						result = WebClassLibrary.JWebManager.LoadClientControl("Letters"
							  , "~/WebAutomation/WebCommunication/JExportedLetterUpdateControl.ascx"
							  , "ویرایش نامه صادره"
							  , new List<Tuple<string, string>>(){ new Tuple<string, string>("Code", code)
                                                                                      , new Tuple<string, string>("Type", jcLetter.letter_type.ToString())
                                                                                      ,  new Tuple<string, string>("ReferCode", RefCode)
                                                                                      , new Tuple<string, string>("CurrentPage", currentPage) }
								 , WindowTarget.NewWindow
								 , true, true, true, 750, 500);
					}
					break;
				case 3:

					if (jcLetter.isSigned)
					{
						ReferCode = int.Parse(RefCode);
						result =
									WebClassLibrary.JWebManager.LoadClientControl("Letters"
										 , "~/WebAutomation/WebCommunication/JLetteViewControl.ascx"
										 , "نامه داخلی"
										  , new List<Tuple<string, string>>(){ new Tuple<string, string>("Code", code)
                                                                                      , new Tuple<string, string>("Type", jcLetter.letter_type.ToString())
                                                                                      ,  new Tuple<string, string>("ReferCode", RefCode)
                                                                                      , new Tuple<string, string>("CurrentPage", currentPage) }
										 , WindowTarget.NewWindow
										 , true, true, true, 750, 500);

						// ReferCode = Convert.ToInt32(code);
						Automation.JARefer jAuto = new Automation.JARefer(ReferCode);
						jAuto.view_date_time = ClassLibrary.JDateTime.Now();
						jAuto.Update();
					}
					else
					{
						result = WebClassLibrary.JWebManager.LoadClientControl("Letters"
							, "~/WebAutomation/WebCommunication/JLetterUpdateControl.ascx"
							, "ویرایش نامه داخلی"
							 , new List<Tuple<string, string>>(){ new Tuple<string, string>("Code", code)
                                                                                      , new Tuple<string, string>("Type", jcLetter.letter_type.ToString())
                                                                                      ,  new Tuple<string, string>("ReferCode", RefCode)
                                                                                      , new Tuple<string, string>("CurrentPage", currentPage) }
							   , WindowTarget.NewWindow
							   , true, true, true, 750, 500);

					}
					break;
			}
			return result;
		}
		////-----------------------------------------------------------------------------------------------------


		#region Exported Letter

		public string NewJExportedLetter()
		{
			return NewJExportedLetter(null);
		}
		////-----------------------------------------------------------------------------------------------------
		public string NewJExportedLetter(string code)
		{
			return
			WebClassLibrary.JWebManager.LoadClientControl("Letters"
				 , "~/WebAutomation/WebCommunication/JExportedLetterUpdateControl.ascx"
				 , "نامه صادره جدید"
				 , new List<Tuple<string, string>>(){ new Tuple<string, string>("Code", "0")
                                                                                      ,  new Tuple<string, string>("ReferCode", "0")
                                                                                      , new Tuple<string, string>("CurrentPage", "")
				 ,new Tuple<string, string>("ObjectCode", "0"), new Tuple<string, string>("ClassName", "Communication.JCExportedLetter")}
				 , WindowTarget.NewWindow
				 , true, true, true, 750, 500);


		}

		#endregion Exported Letter

		#region Imported Letter
		////-----------------------------------------------------------------------------------------------------
		public string NewJImportedLetter()
		{
			return NewJImportedLetter(null);
		}
		////-----------------------------------------------------------------------------------------------------
		public string NewJImportedLetter(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("Letters"
				  , "~/WebAutomation/WebCommunication/JImportedLetterUpdateControl.ascx"
				  , "نامه وارده جدید"
				 , new List<Tuple<string, string>>(){ new Tuple<string, string>("Code", "0")
                                                                                      ,  new Tuple<string, string>("ReferCode", "0")
                                                                                      , new Tuple<string, string>("CurrentPage", "") }
				  , WindowTarget.NewWindow
				  , true, false, true, 750, 500);
		}
		////-----------------------------------------------------------------------------------------------------
		#endregion Imported Letter

		#region  Letter
		////-----------------------------------------------------------------------------------------------------
		public string NewJLetter()
		{
			return NewJLetter(null);
		}
		////-----------------------------------------------------------------------------------------------------
		public string NewJLetter(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("Letters"
				  , "~/WebAutomation/WebCommunication/JLetterUpdateControl.ascx"
				  , "نامه داخلی جدید"
                 , new List<Tuple<string, string>>(){ new Tuple<string, string>("Code", "0")
                                                                                      , new Tuple<string, string>("Type", "3")
                                                                                      ,  new Tuple<string, string>("ReferCode", "0")
                                                                                      , new Tuple<string, string>("CurrentPage", "") }
				  , WindowTarget.NewWindow
				  , true, true, true, 750, 500);
		}
		////-----------------------------------------------------------------------------------------------------
		public string ShowRefer(int ReferCode)
		{
			string currentPage = HttpContext.Current.Request.UrlReferrer.AbsoluteUri.Split('_')[HttpContext.Current.Request.UrlReferrer.AbsoluteUri.Split('_').Length - 1];

			Automation.JARefer Jref = new Automation.JARefer(ReferCode);
			return WebCommunicationUpdate((new Automation.JAObject(Jref.object_code).ObjectCode).ToString(), ReferCode.ToString(), currentPage);
			//return WebCommunicationUpdate(Jref.object_code.ToString(), ReferCode.ToString(), currentPage);
		}
		////-----------------------------------------------------------------------------------------------------
		#endregion  Letter

		#region Letter Search
		public string LetterSearch()
		{
			return WebClassLibrary.JWebManager.LoadClientControl("LetterSearch", "~/WebAutomation/WebCommunication/JLetterSearchControl.ascx", "جستجوی نامه", null, WindowTarget.NewWindow, true, true, true, 0, 0, true);
		}
		#endregion

		#region SMS
		public string _SMS()
		{
			//WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_SMS");
			//jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_SMS";
			//string query = @"SELECT Code,(select Fa_Date from StaticDates where En_Date = CAST(Send_Date_Time as date)) as Send_Date_Time, SMS_Text, Register_Full_Title, Send_Full_Title,(select Fa_Date from StaticDates where En_Date = CAST(Register_Date_Time as date)) as Register_Date_Time , CASE Status When 0 THEN N'ارسال نشده' WHEN 1 THEN N'ارسال شده' END as Status from SMSes where Register_User_Post_Code = " + ClassLibrary.JMainFrame.CurrentPostCode + " OR Send_User_Post_Code = " + ClassLibrary.JMainFrame.CurrentPostCode;
			////query = "Select tbl.* From (" + query + ") tbl Order By tbl.Register_Date_Time desc";
			////query += " order by 6 desc";
			//jGridView.PageOrderByField = " register_date_time desc ";
			//jGridView.SQL = query;
			////ClassLibrary.JOrganizations.GetWebQuery();
			//jGridView.Title = "SMS";
			//jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			//jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SMSNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			//jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SMSUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
			//jGridView.Actions = new List<JActionsInfo>();
			////jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
			//jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._SMSUpdate", null, null));
			////JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
			//return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow2(true, false, false), true);
			////return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

			////return WebClassLibrary.JWebManager.GenerateClientWindow(GenerateWindow2(true, false, false), true);

			DataGridView dgv = new DataGridView();
			dgv.ID = "grid_" + _ConstClassName.Replace(".", "_") + "_SMS";
			dgv.PageIndex = 1;
			dgv.PageSize = 10;
			//dgv.Columns = "Code,Name";
			//dgv.Table = "clsallperson";
			//dgv.Columns = "Code,Send_Date_Time,SMS_Text,Register_Full_Title,Send_Full_Title,Register_Date_Time,Status";
			//dgv.SQL = "SELECT Code,(select Fa_Date from StaticDates where En_Date = CAST(Send_Date_Time as date)) as Send_Date_Time, SMS_Text, Register_Full_Title, Send_Full_Title,(select Fa_Date from StaticDates where En_Date = CAST(Register_Date_Time as date)) as Register_Date_Time , CASE Status When 0 THEN N'ارسال نشده' WHEN 1 THEN N'ارسال شده' END as Status from SMSes where Register_User_Post_Code = " + ClassLibrary.JMainFrame.CurrentPostCode + " OR Send_User_Post_Code = " + ClassLibrary.JMainFrame.CurrentPostCode;
			dgv.ClassName = _ConstClassName + ".SMS.test";
			dgv.ObjectCode = 0;
			dgv.Parameters = new object[] { 1000650 };
			//dgv.GridButtons = new List<GridButton>()
			//{
			//	new GridButton(){Text="New",ID="sms" ,Control="~/WebAutomation/WebCommunication/JNoStorageControl.ascx",IconUrl=JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add)}
			//};
			dgv.ToolBar = new WebControllers.MainControls.ToolBar.JToolBar();
			dgv.ToolBar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SMSNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			dgv.SUID = _ConstClassName.Replace(".", "_") + "_SMS";
			List<GridContextMenuItem> contextMenus = new List<GridContextMenuItem>();
			contextMenus.Add(new GridContextMenuItem() { Text = "New", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SMSNew", null, null) });
			contextMenus.Add(new GridContextMenuItem() { Text = "Edit", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SMSUpdate", null, null) });
			dgv.ContextMenu = contextMenus;
			dgv.DoubleClick = new GridEventArgs() { Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SMSUpdate", null, null) };
			dgv.Bind();
			return WebClassLibrary.JWebManager.GenerateClientWindow(dgv.GenerateWindow(true, false, false), true);
		}

		//public JComponents.DataGridView Generate2()
		//{
		//	JComponents.DataGridView dgv = new JComponents.DataGridView();
		//	dgv.PageIndex = 1;
		//	dgv.PageSize = 10;
		//	dgv.Columns = "Code,Name";
		//	dgv.Table = "clsallperson";
		//	dgv.Bind();
		//	return dgv;
		//}
		//public Telerik.Web.UI.RadWindow GenerateWindow2(bool isMaximized = true, bool isClosable = false, bool isModal = false)
		//{
		//	//Telerik.Web.UI.RadWindow radWindow = (new JWindow(_ConstClassName.Replace(".", "_") + "_SMS", "SMS")).Generate();
		//	//radWindow.NavigateUrl = "Controls.aspx?SUID=" + _ConstClassName.Replace(".", "_") + "_SMS";
		//	//radWindow.Title = ClassLibrary.JLanguages._Text("SMS");
		//	////WebClassLibrary.JWebManager.SetControlType(WebClassLibrary.JDomains.JControls.JGridView, _ConstClassName.Replace(".", "_") + "_SMS");
		//	//if (isMaximized) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Maximize;
		//	//if (isClosable) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Close;
		//	//radWindow.Modal = isModal;
		//	//radWindow.Controls.Add(Generate2());
		//	//return radWindow;
		//	Telerik.Web.UI.RadWindow rw = new Telerik.Web.UI.RadWindow();
		//	rw.NavigateUrl = "Controls.aspx";
		//	rw.Title = "SMS";
		//	rw.Controls.Add(Generate2());
		//	return rw;
		//}

		// Other Person New/Edit
		public string _SMSNew()
		{
			return _SMSNew(null);
		}
		public string _SMSNew(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("SMS"
				, "~/WebAutomation/WebCommunication/JSMSControl.ascx"
				, "اس ام اس"
				, null
				, WindowTarget.NewWindow
				, true, true, true, 600, 350);
		}

		public string _SMSUpdate(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("SMS"
				, "~/WebAutomation/WebCommunication/JSMSControl.ascx"
				, "اس ام اس"
				, new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
				, WindowTarget.NewWindow
				, true, true, true, 630, 350);
		}
		#endregion

		#region Email
		public string _Email()
		{
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_Email");
			jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_SMS";

			jGridView.SQL = @"SELECT * FROM EMailSend where Register_Post_Code=" + ClassLibrary.JMainFrame.CurrentPostCode;
			//ClassLibrary.JOrganizations.GetWebQuery();
			jGridView.Title = "Email";
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._EmailNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._EmailUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
			jGridView.Actions = new List<JActionsInfo>();
			//jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
			jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._EmailUpdate", null, null));
			//JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
			return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
		}
		// Other Person New/Edit
		public string _EmailNew()
		{
			return _EmailNew(null);
		}
		public string _EmailNew(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("Email"
				, "~/WebAutomation/WebCommunication/JEmailControl.ascx"
				, "پست الکترونیک"
				, null
				, WindowTarget.NewWindow
				, true, true, true, 600, 350);
		}

		public string _EmailUpdate(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("Email"
				, "~/WebAutomation/WebCommunication/JEmailControl.ascx"
				, "پست الکترونیک"
				, new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
				, WindowTarget.NewWindow
				, true, true, true, 630, 350);
		}
		#endregion

		#region Secretariat
		public string _Secretariat()
		{
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_Secretariat");
			jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Secretariat";

			jGridView.SQL = @"SELECT * FROM Secretariat";
			//ClassLibrary.JOrganizations.GetWebQuery();
			jGridView.Title = "Secretariat";
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SecretariatNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SecretariatUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
			jGridView.Actions = new List<JActionsInfo>();
			//jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
			jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._SecretariatUpdate", null, null));
			//JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
			return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
		}

		public string _SecretariatNew()
		{
			return _SecretariatNew(null);
		}

		public string _SecretariatNew(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("Secretariat"
				, "~/WebAutomation/WebCommunication/JSecretariatControl.ascx"
				//, "~/WebAutomation/WebCommunication/JNoStorageControl.ascx"
				, "دبیرخانه"
				, null
				, WindowTarget.NewWindow
				, true, true, true, 600, 350);
		}

		public string _SecretariatUpdate(string code)
		{
			return WebClassLibrary.JWebManager.LoadClientControl("Email"
				, "~/WebAutomation/WebCommunication/JSecretariatControl.ascx"
				, "دبیرخانه"
				, new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
				, WindowTarget.NewWindow
				, true, true, true, 630, 350);
		}
		#endregion
		//        public string GetDataTable()
		//        {
		//            return GetDataTable();
		//        }

		//        public string GetDataTable(string where)
		//        {

		//            string query = @"SELECT [Code],Letter_No
		//      ,CASE letter_type WHEN 3 THEN N'داخلی' WHEN 2 THEN N'صادره' WHEN 1 THEN N'وارده' ELSE N'unknown' END 'نوع نامه'
		//      ,[subject]
		//      ,CASE WHEN [ParentCode] > 0 THEN CAST([ParentCode] as nvarchar) ELSE N'-' END 'پاسخ/پیرو نامه'
		//      ,[sender_full_title]
		//      ,[receiver_full_title]
		//      ,(select Fa_Date from StaticDates where En_Date = CAST([register_date_time] as date)) as [register_date_time]
		//      ,[incoming_no]
		//      ,(select Fa_Date from StaticDates where En_Date = CAST([incoming_date] as date)) as [incoming_date]
		//      ,(select Fa_Date from StaticDates where En_Date = CAST([SignDate] as date)) as [SignDate]
		//      ,[letter_type]
		//  FROM [Letters] Where letter_type = " + ClassLibrary.Domains.JCommunication.JLetterType.Internal.ToString() + " " + (where == null ? "" : (" AND " + where));
		//            query += @" union all SELECT [Code],Letter_No
		//      ,CASE letter_type WHEN 3 THEN N'داخلی' WHEN 2 THEN N'صادره' WHEN 1 THEN N'وارده' ELSE N'unknown' END 'نوع نامه'
		//      ,[subject]
		//      ,CASE WHEN [ParentCode] > 0 THEN CAST([ParentCode] as nvarchar) ELSE N'-' END 'پاسخ/پیرو نامه'
		//      ,[sender_full_title]
		//      ,[receiver_full_title]
		//      ,(select Fa_Date from StaticDates where En_Date = CAST([register_date_time] as date)) as [register_date_time]
		//      ,[incoming_no]
		//      ,(select Fa_Date from StaticDates where En_Date = CAST([incoming_date] as date)) as [incoming_date]
		//      ,(select Fa_Date from StaticDates where En_Date = CAST([SignDate] as date)) as [SignDate]
		//      ,[letter_type]
		//  FROM [Letters] Where letter_type = " + ClassLibrary.Domains.JCommunication.JLetterType.Export.ToString() + " " + (where == null ? "" : (" AND " + where));
		//            query += @" union all SELECT [Code],Letter_No
		//      ,CASE letter_type WHEN 3 THEN N'داخلی' WHEN 2 THEN N'صادره' WHEN 1 THEN N'وارده' ELSE N'unknown' END 'نوع نامه'
		//      ,[subject]
		//      ,CASE WHEN [ParentCode] > 0 THEN CAST([ParentCode] as nvarchar) ELSE N'-' END 'پاسخ/پیرو نامه'
		//      ,[sender_full_title]
		//      ,[receiver_full_title]
		//      ,(select Fa_Date from StaticDates where En_Date = CAST([register_date_time] as date)) as [register_date_time]
		//      ,[incoming_no]
		//      ,(select Fa_Date from StaticDates where En_Date = CAST([incoming_date] as date)) as [incoming_date]
		//      ,(select Fa_Date from StaticDates where En_Date = CAST([SignDate] as date)) as [SignDate]
		//      ,[letter_type]
		//  FROM [Letters] Where letter_type = " + ClassLibrary.Domains.JCommunication.JLetterType.Import.ToString() + " " + (where == null ? "" : (" AND " + where)); ;
		//            query = "Select tbl.* From (" + query + ") tbl  "; //tbl Order By tbl.register_date_time desc
		//            return query;
		//        }

	}
}