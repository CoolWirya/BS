using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebControllers.MainControls.Grid
{
	public class JGridView : WebClassLibrary.JSessionClass
	{


		private const string SESSION_VARS = "SQL,SQLType,PageOrderByField,PageSize,Actions,Toolbar,Buttons,ClassName,CssClass"
												+ ",HiddenColumns,FilterQuery,SumFields,RowStyles,DetailDataSource,DetailKeyFields,IsDetailQueryIn,PreQuery,ContextMenuItems";

		public JGridView()
			: base(SESSION_VARS)
		{
			// SumFields = new Dictionary<string, double>();
		}

		public JGridView(string sessionUniqueID)
			: base(SESSION_VARS, sessionUniqueID)
		{
			//  SumFields = new Dictionary<string, double>();
		}

		public void ClearVariables()
		{
			Toolbar = null;
			Actions = null;
			SQL = "";
			SQLType = 0;
			PageOrderByField = "";
			PageSize = 10;
			Title = "";
			CssClass = "";
			ClassName = "";
			Buttons = "";
			HiddenColumns = "";
			RefreshTimerEnabled = false;
			RefreshTimerInterval = 10000;
		}
		public ToolBar.JToolBar Toolbar;
		public List<WebClassLibrary.JActionsInfo> Actions;
		public string SQL;
		public int SQLType;
		public string PageOrderByField = "Code";
		public int PageSize = 10;
		public string Title;
		public string CssClass;
		public string ClassName;
		/// <summary>
		/// Buttons = Refresh,Print,PDF,Excel,Word,CSV,FormManagers,Forms
		/// </summary>
		public string Buttons;
		public string HiddenColumns;
		public bool RefreshTimerEnabled;
		public int RefreshTimerInterval;
		public string FilterQuery;

		private List<JContextMenuItem> contextMenuItems;
		public List<JContextMenuItem> ContextMenuItems
		{
			get
			{
				if (contextMenuItems == null)
					return new List<JContextMenuItem>();
				return contextMenuItems;
			}
			set
			{
				contextMenuItems = value;
			}
		}

		private Dictionary<string, double> sumFields;


		public Dictionary<string, double> SumFields
		{
			get
			{

				return (sumFields == null) ? new Dictionary<string, double>() : (Dictionary<string, double>)sumFields;

			}
			set
			{
				sumFields = value;
			}
		}
		private string detailDataSource;
		public string DetailDataSource
		{
			get
			{
				return (detailDataSource == null) ? "" : detailDataSource;
			}
			set
			{
				detailDataSource = value;
			}
		}

		private Dictionary<string, string> detailKeyFields;

		public Dictionary<string, string> DetailKeyFields
		{
			get
			{

				return (detailKeyFields == null) ? new Dictionary<string, string>() : (Dictionary<string, string>)detailKeyFields;

			}
			set
			{
				detailKeyFields = value;
			}
		}



		private bool isDetailQueryIn;
		public bool IsDetailQueryIn
		{
			get
			{
				return isDetailQueryIn;
			}
			set
			{
				isDetailQueryIn = value;
			}
		}

		string preQuery;
		public string PreQuery
		{
			get
			{
				return (preQuery == null) ? "" : preQuery;
			}
			set
			{
				preQuery = value;
			}
		}

		private List<RowStyle> rowStyles;

		public List<RowStyle> RowStyles
		{
			get
			{
				if (rowStyles == null)
					rowStyles = new List<RowStyle>();
				return rowStyles;
			}
			set
			{
				rowStyles = value;
			}
		}

		public JGridViewControl Generate()
		{
			SessionSave();
            JGridViewControl jGridViewControl = (JGridViewControl)WebClassLibrary.JWebManager.CurrentPage.LoadControl("~/WebControllers/MainControls/Grid/JGridViewControl.ascx");
			jGridViewControl.ID = "grid_" + SessionUniqueID;
			jGridViewControl.GridView = this;
			sumFields = SumFields;
			jGridViewControl.SumFields = SumFields;
			rowStyles = RowStyles;
			jGridViewControl.RowStyles = RowStyles;
			contextMenuItems = ContextMenuItems;
			jGridViewControl.ContextMenuItems = ContextMenuItems;
			detailKeyFields = DetailKeyFields;
			jGridViewControl.DetailKeyFields = detailKeyFields;

			return jGridViewControl;
		}

		public Telerik.Web.UI.RadWindow GenerateWindow(bool isMaximized = true, bool isClosable = false, bool isModal = false)
		{
			if (PageSize == 0) PageSize = 10;
			if (Buttons == null || Buttons == "") Buttons = "Refresh,Print,record_print,PDF,Excel,Word,CSV,Forms,FormManagers,Close";
			if (PageOrderByField == "") PageOrderByField = "Code";
			sumFields = SumFields;
			rowStyles = RowStyles;
			contextMenuItems = ContextMenuItems;
			detailKeyFields = DetailKeyFields;
			SessionSave();
			Telerik.Web.UI.RadWindow radWindow = (new JWindow(SessionUniqueID, Title)).Generate();
			radWindow.NavigateUrl = "Controls.aspx?SUID=" + SessionUniqueID;
			radWindow.Title = ClassLibrary.JLanguages._Text(Title);
			WebClassLibrary.JWebManager.SetControlType(WebClassLibrary.JDomains.JControls.JGridView, SessionUniqueID);
			if (isMaximized) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Maximize;
			if (isClosable) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Close;
			radWindow.Modal = isModal;
			radWindow.Controls.Add(Generate());
			return radWindow;
		}

		//public DataGridView Generate2()
		//{
		//	SessionSave();
		//	DataGridView dgv = new DataGridView();
		//	dgv.ID = "grid_" + SessionUniqueID;
		//	dgv.PageIndex = 1;
		//	dgv.PageSize = 10;
		//	dgv.Columns = "Code,Name";
		//	dgv.Table = "clsallperson";
		//	dgv.Bind();
		//	return dgv;
		//}

		//public Telerik.Web.UI.RadWindow GenerateWindow2(bool isMaximized = true, bool isClosable = false, bool isModal = false)
		//{
		//	if (PageSize == 0) PageSize = 10;
		//	if (Buttons == null || Buttons == "") Buttons = "Refresh,Print,record_print,PDF,Excel,Word,CSV,Forms,FormManagers,Close";
		//	if (PageOrderByField == "") PageOrderByField = "Code";
		//	sumFields = SumFields;
		//	rowStyles = RowStyles;
		//	contextMenuItems = ContextMenuItems;
		//	detailKeyFields = DetailKeyFields;
		//	SessionSave();
		//	Telerik.Web.UI.RadWindow radWindow = (new JWindow(SessionUniqueID, Title)).Generate();
		//	radWindow.NavigateUrl = "Controls.aspx?SUID=" + SessionUniqueID;
		//	radWindow.Title = ClassLibrary.JLanguages._Text(Title);
		//	WebClassLibrary.JWebManager.SetControlType(WebClassLibrary.JDomains.JControls.DataGridView, SessionUniqueID);
		//	if (isMaximized) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Maximize;
		//	if (isClosable) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Close;
		//	radWindow.Modal = isModal;
		//	radWindow.Controls.Add(Generate2());
		//	return radWindow;
		//}
	}

	public enum SQLTypeEnum
	{
		Query = 0,
		QueryFromAction = 1
	}
}