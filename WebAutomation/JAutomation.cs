using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebAutomation
{
	public class JAutomation
	{
		public const string _ConstClassName = "WebAutomation.JAutomation";
		// Main Method
		public List<JNode> GetNodes()
		{
			List<JNode> nodes = new List<JNode>();
			//nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebAutomation.JAutomation._Users", null, new List<object>() { }) }, "Users", _ConstClassName + "._Users", JDomains.Images.MenuImages.Item, null)); 
			nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebAutomation.JAutomation.GetInbox", null, new List<object>() { string.Empty, string.Empty }) }, "Inbox", _ConstClassName + ".GetInbox", JDomains.Images.ControlImages.Inbox, null));

			nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebAutomation.JAutomation.GetOutbox", null, new List<object>() { string.Empty, string.Empty }) }, "Outbox", _ConstClassName + ".GetOutbox", JDomains.Images.ControlImages.Outbox, null));
			nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, JCommunication._ConstClassName + ".WebCommunication", null, new List<object>() { }) }, "WebCommunication", JCommunication._ConstClassName + ".WebCommunication", JDomains.Images.ControlImages.MailRead, null));
			nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, JCommunication._ConstClassName + ".LetterSearch", null, new List<object>() { }) }, "LetterSearch", JCommunication._ConstClassName + ".LetterSearch", JDomains.Images.MenuImages.Item, null));
			nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, JCommunication._ConstClassName + "._SMS", null, new List<object>() { }) }, "SMS", JCommunication._ConstClassName + "._SMS", JDomains.Images.MenuImages.Item, null));
			nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, JCommunication._ConstClassName + "._Email", null, new List<object>() { }) }, "Email", JCommunication._ConstClassName + "._Email", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, JCommunication._ConstClassName + "._Secretariat", null, new List<object>() { }) }, "Secretariat", JCommunication._ConstClassName + "._Secretariat", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebAutomation.JAutomation.WorkFlow", null, new List<object>() { }) }, "WorkFlow", _ConstClassName + ".WorkFlow", JDomains.Images.MenuImages.Item, null));

			System.Data.DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select   
                                                                                        ClassName,max(title) as title ,DynamicClassCode
                                                                                        from Objects group by ClassName,DynamicClassCode order by ClassName");
            foreach (System.Data.DataRow Dr in dt.Rows)
            {
                nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click"
                                                                , JDomains.JActionEvents.MouseClick,  "WebAutomation.JAutomation.GetInbox"
                                                                , null, new List<object>() {Dr["ClassName"].ToString(),Dr["DynamicClassCode"].ToString() }) }
                                                                , Dr["Title"].ToString(), _ConstClassName + ".GetInbox", JDomains.Images.ControlImages.Inbox, null));
            }

            return nodes;
        }


        public string WorkFlow() 
        { 

            return WebClassLibrary.JWebManager.LoadClientControl("WorkFlow"
                , "~/WebAutomation/WebCommunication/JWorkFlow.ascx"
                , "WorkFlow"
                , null
                , WindowTarget.NewWindow
                   , false, true, true, 0, 0, true);
        }

		public string GetInbox(string ClassName = "", string DynamicClassCode = "")
		{
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_GetInbox");

			string Query = string.Empty;
			Query += WebAutomation.JARefer.GetInbox();

			var q = (new ClassLibrary.JAction("", ClassName + ".GetInbox", new object[] { }, null)).run();
			var GridStyle = (new ClassLibrary.JAction("", ClassName + ".GetSyles", new object[] { }, null)).run();
			if (q != null)
			{
				Query = WebAutomation.JARefer.GetSpecialInbox(q.ToString(), Query, ClassName);
			}
			else
			{
				Query = WebAutomation.JARefer.GetSpecialInbox(Query, ClassName);
			}

			if (GridStyle != null)
			{
				jGridView.RowStyles = new List<WebControllers.MainControls.Grid.RowStyle>();
				jGridView.RowStyles = (List<WebControllers.MainControls.Grid.RowStyle>)GridStyle;
			}
			jGridView.SQL = Query;//"WebAutomation.JARefer.GetInbox";
            jGridView.ClassName = "WebAutomation.JAutomation.GetInbox";
            //jGridView.SQLType = Convert.ToInt32(WebControllers.MainControls.Grid.SQLTypeEnum.Query);
			jGridView.Title = "Inbox";
			jGridView.PageOrderByField = "Send_Date_Time desc";
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebAutomation.JAutomation.ShowItem", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			jGridView.Actions = new List<JActionsInfo>();
			jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JAutomation.GetInboxMenu", null, null));
			jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebAutomation.JAutomation.ShowItem", null, null));

			return JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, true, false), true);
		}



		public string GetOutbox(string ClassName = "", string DynamicClassCode = "")
		{
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_GetOutbox");

			var q = (new ClassLibrary.JAction("", ClassName + ".GetOutbox", new object[] { }, null)).run();
			var GridStyle = (new ClassLibrary.JAction("", ClassName + ".GetSyles", new object[] { }, null)).run();

			#region Query
			string Query = string.Empty;
			Query += WebAutomation.JARefer.GetOutbox();
			if (q != null)
				Query = WebAutomation.JARefer.GetSpecialOutbox(q.ToString(), Query, ClassName);
			else
				Query = WebAutomation.JARefer.GetSpecialOutbox(string.Empty, Query, ClassName);
			//            if (q != null)
			//            {
			//                Query = "select  Code,[Title],View_date_Time,Send_Date_time,[از],[به],[فوریت],t.*  from  (" + Query + ") s";
			//                Query += " Left join ( ";
			//                Query += q.ToString();
			//                Query += @" )t 
			//					 on (s.objectcode = t.Master_Code)";
			//                Query += " where s.ClassName = '" + ClassName + "' ";
			//            }
			//            else
			//            {
			//                Query = "select  Code,[Title],View_date_Time,Send_Date_time,[از],[به],[فوریت]  from  (" + Query + ") s";
			//                if (ClassName != string.Empty)
			//                    Query += " where s.ClassName = '" + ClassName + "' ";
			//            }
			#endregion

			//if (GridStyle != null)
			//{
			//	jGridView.RowStyles = new List<WebControllers.MainControls.Grid.RowStyle>();
			//	jGridView.RowStyles = (List<WebControllers.MainControls.Grid.RowStyle>)GridStyle;
			//}
			jGridView.SQL = Query;
			jGridView.SQLType = Convert.ToInt32(WebControllers.MainControls.Grid.SQLTypeEnum.Query);
			jGridView.Title = "Outbox";
			jGridView.PageOrderByField = "Send_Date_Time desc";
			jGridView.ClassName = _ConstClassName;
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			jGridView.Toolbar.AddButton("نمایش", "نمایش", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebAutomation.JAutomation.ShowOutboxItem", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
			jGridView.Actions = new List<JActionsInfo>();
			jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JAutomation.GetOutboxMenu", null, null));
			jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebAutomation.JAutomation.ShowOutboxItem", null, null));

			return JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, true, false), true);
		}

		public string _Users()
		{
			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
			jGridView.SQL = Globals.JUsers.GetWebQuery();
			jGridView.Title = "Users";
			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
			jGridView.Actions = new List<JActionsInfo>();
			jGridView.ClassName = "JAutomation.TSIP_Forms";

			return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
		}

        public string ShowItem(string Code)
        {
            int ReferCode = Convert.ToInt32(Code);
            Automation.JARefer jaRefer = new Automation.JARefer(ReferCode);
            Automation.JAObject jaObject = new Automation.JAObject(jaRefer.object_code);
            string Result = string.Empty;

            if (jaObject.ClassName == "ClassLibrary.FormManagers")
            {
                Result = WebControllers.FormManager.JFormManager.ShowClientForm(jaObject.Code, jaObject.ObjectCode, ReferCode);
            }
            else
            {
                //var q = (new ClassLibrary.JAction("", jaObject.ClassName + ".ShowRefer", new object[] { ReferCode }, null)).run();
                var q = (new ClassLibrary.JAction("", JCommunication._ConstClassName + ".ShowRefer", new object[] { ReferCode }, null)).run();

                if (q != null)
                    Result = q.ToString();
                else
                    Result = "";
            }

            Automation.JARefer jAuto = new Automation.JARefer(ReferCode);
            jAuto.view_date_time = ClassLibrary.JDateTime.Now();
            //jAuto.status = ClassLibrary.Domains.JAutomation.JReferStatus.Sent;
            jAuto.Update();
            return Result;
        }

		public string ShowOutboxItem(string Code)
		{
			int ReferCode = Convert.ToInt32(Code);
			Automation.JARefer jaRefer = new Automation.JARefer(ReferCode);
			Automation.JAObject jaObject = new Automation.JAObject(jaRefer.object_code);
			string Result = string.Empty;

			if (jaObject.ClassName == "ClassLibrary.FormManagers")
			{
				Result = WebControllers.FormManager.JFormManager.ShowClientForm(jaObject.Code, jaObject.ObjectCode, ReferCode);
			}

			else
			{

				var q = (new ClassLibrary.JAction("", jaObject.ClassName + ".ShowRefer", new object[] { ReferCode }, null)).run();

				if (q != null)
					Result = q.ToString();
				else
					Result = "";
			}

			return Result;
		}

	}
}