using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace WebControllers.MainControls.Grid
{
	[Serializable()]
	public struct JContextMenuItem
	{
		public WebClassLibrary.JActionsInfo Action { get; set; }
		public string Text { get; set; }
		//public override string Value
		//{
		//	get
		//	{
		//		return Action.ActionToString();
		//	}
		//	set
		//	{
		//		base.Value = value;
		//	}
		//}
	}
	public partial class JGridViewControl : System.Web.UI.UserControl
	{
		#region Properties & Fields
		////______________________________________________________________________________________________________
		private static bool isSortingChanged = false;

		private static string sortField = "Code";

		private JGridView gridView;
		public JGridView GridView
		{
			get
			{
				if (ViewState["GridView"] != null)
					gridView = (JGridView)ViewState["GridView"];
				return (gridView == null) ? new JGridView() : (JGridView)gridView;
			}
			set
			{
				ViewState["GridView"] = value;
				sortField = value.PageOrderByField;
				isSortingChanged = false;
			}
		}

		private Dictionary<string, double> sumFields;

		private Dictionary<string, double> sumFieldsPage;

		private Dictionary<string, object> selectedRow;

		public int Alternative;// :-)

		Dictionary<string, string> FilterItem;

		public Dictionary<string, double> SumFields
		{
			get
			{
				if (ViewState["sumFields"] != null)
					sumFields = (Dictionary<string, double>)ViewState["sumFields"];
				return (sumFields == null) ? new Dictionary<string, double>() : (Dictionary<string, double>)sumFields;

			}

			set
			{
				ViewState["sumFields"] = value;
			}
		}

		private Dictionary<string, double> SumFieldsPage
		{
			get
			{
				if (ViewState["sumFieldsPage"] != null)
					sumFieldsPage = (Dictionary<string, double>)ViewState["sumFieldsPage"];
				return (sumFieldsPage == null) ? new Dictionary<string, double>() : (Dictionary<string, double>)sumFieldsPage;

			}

			set
			{
				ViewState["sumFieldsPage"] = value;
			}
		}

		public Dictionary<string, object> SelectedRow
		{
			get
			{
				if (ViewState["selectedRow"] != null)
					selectedRow = (Dictionary<string, object>)ViewState["selectedRow"];
				return (selectedRow == null) ? new Dictionary<string, object>() : (Dictionary<string, object>)selectedRow;

			}

			set
			{
				ViewState["selectedRow"] = value;
			}
		}
		List<RowStyle> rowStyles;

		public List<RowStyle> RowStyles
		{
			get
			{
				if (ViewState["rowStyles"] != null)
					rowStyles = (List<RowStyle>)ViewState["rowStyles"];
				return rowStyles == null ? new List<RowStyle>() : rowStyles;
			}
			set
			{
				ViewState["rowStyles"] = value;
			}
		}

		//private List<JContextMenuItem> contextMenuItems;
		private List<GridContextMenuItem> contextMenuItems;


		//public List<JContextMenuItem> ContextMenuItems
		public List<GridContextMenuItem> ContextMenuItems
		{
			get
			{
				if (ViewState["contextMenuItems"] != null)
					//contextMenuItems = (List<JContextMenuItem>)ViewState["contextMenuItems"];
					contextMenuItems = (List<GridContextMenuItem>)ViewState["contextMenuItems"];
				return contextMenuItems == null ? null : contextMenuItems;
			}
			set
			{
				ViewState["contextMenuItems"] = value;
			}
		}

		private Dictionary<string, string> detailKeyFields;

		public Dictionary<string, string> DetailKeyFields
		{
			get
			{
				if (ViewState["detailKeyFields"] != null)
					detailKeyFields = (Dictionary<string, string>)ViewState["detailKeyFields"];
				return (detailKeyFields == null) ? new Dictionary<string, string>() : (Dictionary<string, string>)detailKeyFields;

			}

			set
			{
				ViewState["detailKeyFields"] = value;
			}
		}


		////______________________________________________________________________________________________________
		#endregion Properties & Fields

		#region Global
		////______________________________________________________________________________________________________
		protected void Page_Load(object sender, EventArgs e)
		{
			if (GridView == null) return;

			LoadFilters();
			if (!IsPostBack)
			{
				SumFields = GridView.SumFields;
				RowStyles = GridView.RowStyles;
				DetailKeyFields = GridView.DetailKeyFields;
				//ContextMenuItems = GridView.ContextMenuItems;
				ContextMenuItems = GridView.ContextMenu;
				ViewState["NoFilterClick"] = true;
				if (GridView != null && GridView.PageSize != null && !string.IsNullOrEmpty(GridView.PageSize.ToString()))
				{
					ViewState["pageSize"] = GridView.PageSize;
					GridView1.PageSize = GridView.PageSize > 0 ? GridView.PageSize : 10;

					if (GridView.DetailDataSource == string.Empty)
					{
						GridView1.MasterTableView.DetailTables[0].Enabled = false;
						GridView1.MasterTableView.DetailTables.RemoveAt(0);
					}
					else
					{
						GridView1.MasterTableView.DetailTables[0].Enabled = true;
						GridView1.DetailTableDataBind += GridView1_DetailTableDataBind;
					}
				}
				else
					ViewState["pageSize"] = 10;
				GridView.FilterQuery = string.Empty;
				GridView.SessionSave();
				Alternative = 0;
			}
			//if (IsChildControlStateCleared)
			LoadGrid();

			if (GridView1.MasterTableView.DetailTables.Count > 0)
				if (GridView.DetailDataSource == string.Empty)
				{
					GridView1.MasterTableView.DetailTables[0].Enabled = false;
					GridView1.MasterTableView.DetailTables.RemoveAt(0);
				}
				else
				{
					GridView1.MasterTableView.DetailTables[0].Enabled = true;
					GridView1.DetailTableDataBind += GridView1_DetailTableDataBind;
				}
			//if (ContextMenuItems == null)
			//	ContextMenuItems = GridView.ContextMenuItems;
			//if (ContextMenuItems != null)
			//	foreach (JContextMenuItem cmi in ContextMenuItems)
			//	{
			//		RadMenuItem rmi = RadContextMenu1.Items[0].Clone();//new RadMenuItem();
			//		rmi.Text = cmi.Text;
			//		rmi.Value = cmi.Action.ActionToString();
			//		RadContextMenu1.Items.Add(rmi);
			//	}
			if (ContextMenuItems == null)
				ContextMenuItems = GridView.ContextMenu;
			if (ContextMenuItems != null)
				foreach (GridContextMenuItem cmi in ContextMenuItems)
				{
					RadMenuItem rmi = RadContextMenu1.Items[0].Clone();//new RadMenuItem();
					rmi.Text = cmi.Text;
					rmi.Value = cmi.Action.ActionToString();
					RadContextMenu1.Items.Add(rmi);
				}
			if (RadContextMenu1.Items.Count > 0)
				RadContextMenu1.Items.RemoveAt(0);
		}
		////______________________________________________________________________________________________________
		#endregion Global

		#region Methods
		////______________________________________________________________________________________________________
		public void LoadGrid(bool isForced = false)
		{
			#region initilization
			SumFields = GridView.SumFields;
			RowStyles = GridView.RowStyles;
			//ContextMenuItems = GridView.ContextMenuItems;
			ContextMenuItems = GridView.ContextMenu;
			if (ViewState["NoFilterClick"] == null)
				ViewState["NoFilterClick"] = true;
			//if (GridView.PageSize != null && !string.IsNullOrEmpty(GridView.PageSize.ToString()))
			//    ViewState["pageSize"] = GridView.PageSize;
			//else
			if (ViewState["pageSize"] == null || !(ViewState["pageSize"] is int))
				ViewState["pageSize"] = 10;
			#endregion initilization
			// Configuring AjaxManager
			Telerik.Web.UI.RadAjaxManager manager = Telerik.Web.UI.RadAjaxManager.GetCurrent(Page);
			manager.ClientEvents.OnRequestStart = "onRequestStart";
			manager.ClientEvents.OnResponseEnd = "onResponseEnd";
			manager.AjaxRequest += new Telerik.Web.UI.RadAjaxControl.AjaxRequestDelegate(manager_AjaxRequest);

			// Configuring Timer
			//if (GridView.RefreshTimerEnabled || !GridView.RefreshTimerEnabled)
			//{
			//    WebClassLibrary.JWebManager.RunClientScript("setInterval('RefreshGrid();', " + GridView.RefreshTimerInterval.ToString() + ");", "RefreshTimer", false);
			//}
			if (!IsPostBack || isForced == true)
			{
				// Creating upper toolbar
				RadToolBar1.Items.Clear();
				if (GridView.Toolbar != null && GridView.Toolbar.Buttons != null)
				{
					foreach (WebControllers.MainControls.ToolBar.JToolBarItem item in GridView.Toolbar.Buttons)
					{
						Telerik.Web.UI.RadToolBarButton radToolBarButton = new Telerik.Web.UI.RadToolBarButton();
						radToolBarButton.Text = item.Text;
						radToolBarButton.ImageUrl = item.ImageUrl;
						radToolBarButton.Value = item.Action.ActionToString();
						RadToolBar1.Items.Add(radToolBarButton);
					}
				}
				else
					RadToolBar1.Visible = false;

				// Creating Grid toolbar
				RadToolBar2.Items.Clear();
				if (GridView.Buttons != null)
				{
					string[] btn = GridView.Buttons.Split(',');
					if (btn != null && btn.Length > 0)
						foreach (string item in btn)
						{
							switch (item.ToLower())
							{
								case "refresh":
									Telerik.Web.UI.RadToolBarButton radToolBarButtonRefresh = new Telerik.Web.UI.RadToolBarButton();
									radToolBarButtonRefresh.Text = "";
									radToolBarButtonRefresh.ImageUrl = "~/" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Refresh;
									radToolBarButtonRefresh.Value = "refresh";
									RadToolBar2.Items.Add(radToolBarButtonRefresh);
									break;
								case "print":
									Telerik.Web.UI.RadToolBarButton radToolBarButtonPrint = new Telerik.Web.UI.RadToolBarButton();
									radToolBarButtonPrint.Text = "";
									radToolBarButtonPrint.ImageUrl = "~/" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Print;
									radToolBarButtonPrint.Value = "print";
									RadToolBar2.Items.Add(radToolBarButtonPrint);
									break;

								case "record_print":
									Telerik.Web.UI.RadToolBarButton radToolBarBtnRecordPrint = new Telerik.Web.UI.RadToolBarButton();
									radToolBarBtnRecordPrint.Text = "";
									radToolBarBtnRecordPrint.ImageUrl = "~/" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_RecordPrint;
									radToolBarBtnRecordPrint.Value = "record_print";
									radToolBarBtnRecordPrint.ToolTip = "چاپ ردیف انتخاب شده";
									RadToolBar2.Items.Add(radToolBarBtnRecordPrint);
									break;

								case "pdf":
									Telerik.Web.UI.RadToolBarButton radToolBarButtonPDF = new Telerik.Web.UI.RadToolBarButton();
									radToolBarButtonPDF.Text = "";
									radToolBarButtonPDF.ImageUrl = "~/" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_PDF;
									radToolBarButtonPDF.Value = "pdf";
									RadToolBar2.Items.Add(radToolBarButtonPDF);
									break;
								case "excel":
									Telerik.Web.UI.RadToolBarButton radToolBarButtonExcel = new Telerik.Web.UI.RadToolBarButton();
									radToolBarButtonExcel.Text = "";
									radToolBarButtonExcel.ImageUrl = "~/" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Excel;
									radToolBarButtonExcel.Value = "excel";
									RadToolBar2.Items.Add(radToolBarButtonExcel);
									break;
								case "word":
									Telerik.Web.UI.RadToolBarButton radToolBarButtonWord = new Telerik.Web.UI.RadToolBarButton();
									radToolBarButtonWord.Text = "";
									radToolBarButtonWord.ImageUrl = "~/" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Word;
									radToolBarButtonWord.Value = "word";
									RadToolBar2.Items.Add(radToolBarButtonWord);
									break;
								case "csv":
									Telerik.Web.UI.RadToolBarButton radToolBarButtonCSV = new Telerik.Web.UI.RadToolBarButton();
									radToolBarButtonCSV.Text = "";
									radToolBarButtonCSV.ImageUrl = "~/" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_CSV;
									radToolBarButtonCSV.Value = "csv";
									RadToolBar2.Items.Add(radToolBarButtonCSV);
									break;
								case "formmanagers":
									//if (GridView.ClassName == null) break;
									Telerik.Web.UI.RadToolBarButton radToolBarButtonFormManagers = new Telerik.Web.UI.RadToolBarButton();
									radToolBarButtonFormManagers.Text = "";
									radToolBarButtonFormManagers.ImageUrl = "~/" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_FormManagers;
									//WebClassLibrary.JActionsInfo action = new WebClassLibrary.JActionsInfo();
									//action.Method = "WebControllers.FormManager.JFormManager.ShowClientFormList";
									//action.ParameterValue = new List<object>();
									//action.ParameterValue.Add(GridView.ClassName);
									radToolBarButtonFormManagers.Value = "formmanagers";// action.ActionToString();
									RadToolBar2.Items.Add(radToolBarButtonFormManagers);
									break;
								case "forms":
									Telerik.Web.UI.RadToolBarButton radToolBarButtonForms = new Telerik.Web.UI.RadToolBarButton();
									radToolBarButtonForms.Text = "";
									radToolBarButtonForms.ImageUrl = "~/" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Forms;
									radToolBarButtonForms.Value = "forms";
									RadToolBar2.Items.Add(radToolBarButtonForms);
									break;
							}
						}
				}
				// Help Button
				Telerik.Web.UI.RadToolBarButton radToolBarButtonHelp = new Telerik.Web.UI.RadToolBarButton();
				radToolBarButtonHelp.Text = "";
				radToolBarButtonHelp.ImageUrl = "~/" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Help;
				radToolBarButtonHelp.Value = "help";
				RadToolBar2.Items.Add(radToolBarButtonHelp);

				if (GridView.Actions != null && GridView.Actions.Where(m => m.Event == WebClassLibrary.JDomains.JActionEvents.GridItemRightClick).Count() > 0)
				{
					Telerik.Web.UI.GridDataItem param = null;
					WebClassLibrary.JActionsInfo action = GridView.Actions.Where(m => m.Event == WebClassLibrary.JDomains.JActionEvents.GridItemRightClick).First();
					action.ParameterValue = new List<object>();
					action.ParameterValue.Add(param);
					List<Menu.JMenuItem> menuItems = (List<Menu.JMenuItem>)action.runAction();
					RadContextMenu1.Items.Clear();
					if (menuItems != null)
						foreach (Menu.JMenuItem item in menuItems)
						{
							Telerik.Web.UI.RadMenuItem radMenuItem = new Telerik.Web.UI.RadMenuItem();
							radMenuItem.Text = item.Text;
							radMenuItem.ImageUrl = item.ImageUrl;
							radMenuItem.Value = item.Action.ActionToString();
							RadContextMenu1.Items.Add(radMenuItem);
						}
				}
			}
			///Must Be remove After The Pages Is correct
			///باید پس از اصلاح صفحات کامن شود
			if (isForced)
				GetData();
		}
		////______________________________________________________________________________________________________
		void manager_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
		{
			if (Request.Form["EventType"] == "GridRowDblClick")
			{
				if (GridView.Actions != null && GridView.Actions.Where(m => m.Event == WebClassLibrary.JDomains.JActionEvents.GridItemDblClick).Count() > 0)
				{
					WebClassLibrary.JActionsInfo action = GridView.Actions.Where(m => m.Event == WebClassLibrary.JDomains.JActionEvents.GridItemDblClick).First();
					if (GridView1.SelectedItems.Count > 0)
					{
						try
						{
							string index = Request.Form["radGridClickedRowIndex"].ToString();
							Telerik.Web.UI.GridDataItem param = GridView1.MasterTableView.Items[index];
							action.ParameterValue = new List<object>();
							action.ParameterValue.Add(param);
						}
						catch { }
						action.runAction();
					}
				}
			}
			else if (Request.Form["EventType"] == "RefreshGrid")
			{
				GetData(true);
				//GetData();
			}
		}
		////______________________________________________________________________________________________________
		private void GetData(bool rebind = true)
		{
			//lblFooter.Text = "<table style='background-color: #EEEEF2'  cellspacing='0' cellpading='0'  border='0' style='padding: 0px; margin: 0px; border-width: 1px;  width:450px; '  >"
			//                  + "       <tr> <td  dir='rtl' colspan='3' > تاریخ و ساعت تهیه گزارش : " + ClassLibrary.JDateTime.FarsiDate(DateTime.Now.Date) +" | "+ DateTime.Now.ToShortTimeString() + "</td></tr>"
			//                   + "      <tr> <td  dir='rtl' colspan='3' ></td></tr>"
			//                  + "       <tr> <td  dir='rtl' style='width:150px;text-align:center;'>نام فیلد اطلاعاتی</td>"
			//                  + "       <td  dir='rtl'      style='width:150px;text-align:center;'>جمع صفحه جاری </td>"
			//                  + "       <td  dir='rtl'      style='width:150px;text-align:center;'>جمع-کل </td></tr></table>";
			if (GridView == null) return;

			string sql = "";
			string where = string.Empty;
			if (GridView.SQLType == Convert.ToInt32(WebControllers.MainControls.Grid.SQLTypeEnum.Query))
				sql = GridView.SQL;
			else if (GridView.SQLType == Convert.ToInt32(WebControllers.MainControls.Grid.SQLTypeEnum.QueryFromAction))
				sql = (new ClassLibrary.JAction("", GridView.SQL, new Object[] { }, null)).run().ToString();

			if (ViewState["currentPage"] == null)
				ViewState["currentPage"] = 1;
			where = GetWhere();
			string OrderBy = string.Empty;
			if (!string.IsNullOrEmpty(GridView.PageOrderByField))
				OrderBy = " ORDER BY " + GridView.PageOrderByField;
			SumFieldsPage = new Dictionary<string, double>();
			if (SumFields.Count != 0)
			{
				foreach (string Key in SumFields.Keys)
				{
					SumFieldsPage.Add(Key, 0);
				}
			}
			if (!string.IsNullOrEmpty(where))
			{
				GridView1.VirtualItemCount = WebClassLibrary.JWebDataBase.GetPageCount(sql, where);
				ViewState["VirtualItemCount"] = GridView1.VirtualItemCount;
			}
			else if (ViewState["VirtualItemCount"] == null)
				GridView1.VirtualItemCount = WebClassLibrary.JWebDataBase.GetPageCount(sql);
			else
				GridView1.VirtualItemCount = (int)ViewState["VirtualItemCount"];

			DataTable Grid_dt = new DataTable();
			if ((bool)ViewState["NoFilterClick"] || (int)ViewState["currentPage"] <= (GridView1.VirtualItemCount / (int)ViewState["pageSize"]))
				Grid_dt = WebClassLibrary.JWebDataBase.GetPage(sql, (int)ViewState["currentPage"], (int)ViewState["pageSize"], isSortingChanged ? sortField : GridView.PageOrderByField, where, GridView.PreQuery);
			else
				Grid_dt = WebClassLibrary.JWebDataBase.GetPage(sql, 1, (int)ViewState["pageSize"], isSortingChanged ? sortField : GridView.PageOrderByField, where, GridView.PreQuery);
			Session["CurrentQuery"] = GridView.PreQuery + " Select TOP 100 percent * From(Select TOP 100 percent DataBaseTableRowNum = ROW_NUMBER() OVER (Order by " + GridView.PageOrderByField + "), tbl.* from (" + sql + ") tbl" + (where == "" ? "" : " where " + where) + " ) tbl2";
			GridView1.DataSource = Grid_dt;

			SumFieldsPage = InitDictionary(SumFieldsPage, SumFields);
			SumFields = InitDictionary(SumFields, SumFieldsPage);
			if (Grid_dt != null)
				foreach (DataRow dr in Grid_dt.Rows)
				{
					foreach (string Key in SumFields.Keys)
					{
						if (dr[Key] != null && dr[Key] is int)
						{
							SumFieldsPage[Key] += (int)dr[Key];
						}
					}
					if (GridView1.VirtualItemCount <= (int)ViewState["pageSize"])
					{

						foreach (string Key in SumFieldsPage.Keys)
						{
							if (dr[Key] != null && dr[Key] is int)
							{
								SumFields[Key] += (int)dr[Key];
							}
						}
					}
				}
			if (GridView1.VirtualItemCount > (int)ViewState["pageSize"])
				SumFields = WebClassLibrary.JWebDataBase.GetSumOfFields(SumFields, sql, true, where);

			if (rebind)
				GridView1.Rebind();
			//LoadFilters();
			ViewState["Grid_dt"] = Grid_dt;
		}

		private Dictionary<string, double> InitDictionary(Dictionary<string, double> Fields, Dictionary<string, double> StructuerFields)
		{

			foreach (string Key in StructuerFields.Keys)
			{
				Fields[Key] = 0;
			}
			return Fields;
		}
		////______________________________________________________________________________________________________
		private string GetWhere()
		{
			//if (GridView1.DataSource == null) return "";
			string where = " 1=1 ";
			if (GridView1.MasterTableView != null && GridView1.MasterTableView.Columns.Count > 0)
				foreach (Telerik.Web.UI.GridColumn column in GridView1.MasterTableView.Columns)
				{
					if (column.CurrentFilterValue.Length > 0)
					{
						where += " AND " + column.UniqueName + " LIKE '%" + column.CurrentFilterValue + "%'";
					}
				}

			if (GridView.FilterQuery != null && GridView.FilterQuery != "") where += " AND " + GridView.FilterQuery;
			return where;
		}
		////______________________________________________________________________________________________________
		private void SetPages(int totalPageCount, int pageCount, int pageNum)
		{
			if (totalPageCount == 0)
			{
				return;
			}
			int pages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(totalPageCount) / Convert.ToDouble(pageCount)));
			//if (RadComboBox_Page.Items.Count == pages) return;
			//RadComboBox_Page.Items.Clear();
			//string pageLink = "<a href=\"#\" onclick=\"GetPage({PAGE_NUM})\">{PAGE_NUM}</a>&nbsp;&nbsp;&nbsp;";
			//string pagesLink = "";
			int startIndex = (pageNum - 10) > 0 ? pageNum - 10 : 1;
			int endIndex = (pageNum + 10) <= pages ? pageNum + 10 : pages;
			//for (int i = 1; i <= pages; i++)
			//{
			//    //pagesLink += pageLink.Replace("{PAGE_NUM}", i.ToString());
			//    RadComboBox_Page.Items.Add(new Telerik.Web.UI.RadComboBoxItem(i.ToString(), i.ToString()));
			//}
			//if (startIndex > 1) RadComboBox_Page.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("...", "Previous"));
			//if (endIndex < totalPageCount) RadComboBox_Page.Items.Add(new Telerik.Web.UI.RadComboBoxItem("...", "Next"));
		}
		////______________________________________________________________________________________________________
		private void LoadFilters()
		{

			string sql = "";
			if (GridView.SQLType == Convert.ToInt32(WebControllers.MainControls.Grid.SQLTypeEnum.Query))
				sql = GridView.SQL;
			else if (GridView.SQLType == Convert.ToInt32(WebControllers.MainControls.Grid.SQLTypeEnum.QueryFromAction))
				sql = (new ClassLibrary.JAction("", GridView.SQL, new Object[] { }, null)).run().ToString();

			DataTable dt = WebClassLibrary.JWebDataBase.GetDataTableStructure(sql);
			if (dt == null) return;
			tblFilter.Rows.Clear();
			foreach (DataColumn col in dt.Columns)
			{
				HtmlTableRow tblRow = new HtmlTableRow();
				HtmlTableCell tblCell = new HtmlTableCell();
				// Cell 1: Name
				tblCell.InnerText = ClassLibrary.JLanguages._Text(col.ColumnName);
				tblCell.Width = "150px";
				tblRow.Cells.Add(tblCell);
				// Cell 2: TextBox
				tblCell = new HtmlTableCell();
				tblCell.Width = "150px";
				Telerik.Web.UI.RadTextBox radTextBox = new Telerik.Web.UI.RadTextBox();
				radTextBox.Width = new Unit(100, UnitType.Percentage);
				radTextBox.ID = "txtFilter_" + col.ColumnName;
				radTextBox.AutoPostBack = true;
				//radTextBox.EnableViewState = true;
				radTextBox.ViewStateMode = ViewStateMode.Enabled;
				radTextBox.TextChanged += Filter_TextChanged;
				tblCell.Controls.Add(radTextBox);
				tblRow.Cells.Add(tblCell);
				//Cell 3: ComboBox FilterType
				tblCell = new HtmlTableCell();
				tblCell.Width = "150px";
				Telerik.Web.UI.RadComboBox radComboBox = new Telerik.Web.UI.RadComboBox();
				radComboBox.Width = new Unit(100, UnitType.Percentage);
				radComboBox.ViewStateMode = ViewStateMode.Enabled;
				//radComboBox.EnableViewState = true;
				radComboBox.AutoPostBack = true;
				radComboBox.SelectedIndexChanged += radComboBox_SelectedIndexChanged;
				radComboBox.Items.Add(new Telerik.Web.UI.RadComboBoxItem(ClassLibrary.JLanguages._Text("Contains"), "Contains"));
				radComboBox.Items.Add(new Telerik.Web.UI.RadComboBoxItem(ClassLibrary.JLanguages._Text("Equals"), "Equals"));
				radComboBox.Items.Add(new Telerik.Web.UI.RadComboBoxItem(ClassLibrary.JLanguages._Text("Bigger"), "Bigger"));
				radComboBox.Items.Add(new Telerik.Web.UI.RadComboBoxItem(ClassLibrary.JLanguages._Text("Smaller"), "Smaller"));
				tblCell.Controls.Add(radComboBox);
				tblRow.Cells.Add(tblCell);
				tblFilter.Rows.Add(tblRow);
			}
			if (ViewState["NoFilterClick"] != null && !(bool)ViewState["NoFilterClick"])
			{
				FilterItem = (Dictionary<string, string>)ViewState["FilterItem"];
				foreach (HtmlTableRow row in tblFilter.Rows)
				{
					string colName = ((Telerik.Web.UI.RadTextBox)row.Cells[1].Controls[0]).ID.Replace("txtFilter_", string.Empty);
					if (FilterItem.ContainsKey(colName))
						if (FilterItem[colName] != null)
						{

							((Telerik.Web.UI.RadTextBox)row.Cells[1].Controls[0]).Text = FilterItem[colName].ToString().ToString().Split('_')[1];
							((Telerik.Web.UI.RadComboBox)row.Cells[2].Controls[0]).FindItemByValue(FilterItem[colName].ToString().Split('_')[0]).Selected = true;
						}
				}
			}
		}

		int GetGridColumnId(string name)
		{
			foreach (GridColumn col in GridView1.MasterTableView.AutoGeneratedColumns)
				if (col.UniqueName.ToLower() == name.ToLower())
					return col.OrderIndex;
			return -1;
		}
		////______________________________________________________________________________________________________
		#endregion Methods

		#region ContextMenu Events
		////______________________________________________________________________________________________________

		protected void RadContextMenu1_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
		{
			if (GridView == null) return;
			//WebControllers.MainControls.Menu.JMenuItem menuItem = WebControllers.MainControls.Menu.JMenuItem.Parse(e.Item);
			int i = RadContextMenu1.Items.IndexOf(e.Item);
			WebControllers.MainControls.Menu.JMenuItem menuItem = WebControllers.MainControls.Menu.JMenuItem.Parse(new RadMenuItem() { Text = ContextMenuItems[i].Text, Value = ContextMenuItems[i].Action.ActionToString() });
			if (menuItem.Action.ParameterValue == null) menuItem.Action.ParameterValue = new List<object>();
			string index = Request.Form["radGridClickedRowIndex"].ToString();
			Telerik.Web.UI.GridDataItem param = GridView1.MasterTableView.Items[index];
			//menuItem.Action.ParameterValue = null;// new List<object>();
			//menuItem.Action.ParameterValue.Add(menuItem);
			for (int j = 0; j < menuItem.Action.ParameterValue.Count; j++)
				menuItem.Action.ParameterValue[j] = param.GetDataKeyValue(menuItem.Action.ParameterValue[j].ToString());
			//menuItem.Action.ParameterValue.Add(param);//.GetDataKeyValue("Code"));
			menuItem.Action.runAction();
		}
		////______________________________________________________________________________________________________
		#endregion  ContextMenu Events

		#region GridView Events
		////______________________________________________________________________________________________________
		protected void GridView1_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
				return;
			GetData();
		}
		////______________________________________________________________________________________________________
		protected void GridView1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
		{

			GetData(false);

			//if (GridView != null)
			//{
			//    string sql = "";
			//    if (GridView.SQLType == Convert.ToInt32(WebControllers.MainControls.Grid.SQLTypeEnum.Query))
			//        sql = GridView.SQL;
			//    else if (GridView.SQLType == Convert.ToInt32(WebControllers.MainControls.Grid.SQLTypeEnum.QueryFromAction))
			//        sql = (new ClassLibrary.JAction("", GridView.SQL, new Object[] { }, null)).run().ToString();

			//    GridView1.DataSource = WebClassLibrary.JWebDataBase.GetPage(sql, GridView1.CurrentPageIndex, GridView.PageSize, GridView.PageOrderByField, GetWhere());
			//}
		}
		////_______________________________________________________________________________________________________
		protected void GridView1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
		{
			ViewState["currentPage"] = e.NewPageIndex + 1;
			GridView1.SelectedIndexes.Clear();
			GetData(true);
			//lblFooter.Text = string.Empty;


		}
		////______________________________________________________________________________________________________
		protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (GridView == null) return;
			if (GridView.Actions != null && GridView.Actions.Where(m => m.Event == WebClassLibrary.JDomains.JActionEvents.GridItemRightClick).Count() > 0)
			{
				WebClassLibrary.JActionsInfo action = GridView.Actions.Where(m => m.Event == WebClassLibrary.JDomains.JActionEvents.GridItemRightClick).First();
				if (GridView1.SelectedItems.Count > 0)
				{
					string index = Request.Form["radGridClickedRowIndex"].ToString();
					if (index != "")
					{
						Telerik.Web.UI.GridDataItem param = GridView1.MasterTableView.Items[index];
						action.ParameterValue = new List<object>();
						action.ParameterValue.Add(param);
						List<Menu.JMenuItem> menuItems = (List<Menu.JMenuItem>)action.runAction();
						RadContextMenu1.Items.Clear();
						if (menuItems != null)
							foreach (Menu.JMenuItem item in menuItems)
							{
								Telerik.Web.UI.RadMenuItem radMenuItem = new Telerik.Web.UI.RadMenuItem();
								radMenuItem.Text = item.Text;
								radMenuItem.ImageUrl = item.ImageUrl;
								radMenuItem.Value = item.Action.ActionToString();
								RadContextMenu1.Items.Add(radMenuItem);
							}
					}
				}
			}
			//foreach (TableCellCollection Cel in GridView1.SelectedItems[0].)
			//{
			//    Cel.
			//}
			try
			{
				if (GridView1 != null && GridView1.SelectedValues != null)
				{
					DataTable dt = (DataTable)GridView1.DataSource;
					string TempRowFilter = dt.DefaultView.RowFilter;
					dt.DefaultView.RowFilter = " Code =" + GridView1.SelectedValues["Code"].ToString();
					SelectedRow = new Dictionary<string, object>();
					if (dt.DefaultView.Count != 0)
						foreach (DataColumn col in (GridView1.DataSource as DataTable).Columns)
						{
							SelectedRow.Add(col.ColumnName, dt.DefaultView[0][col.ColumnName]);
						}
					dt.DefaultView.RowFilter = TempRowFilter;
				}
			}
			catch
			{

			}
			//MasterTableView.DataKeyNames
		}
		////______________________________________________________________________________________________________
		protected void GridView1_PreRender(object sender, EventArgs e)
		{
			if (GridView == null) return;
			if (GridView1.DataSource == null) return;
			foreach (DataColumn col in (GridView1.DataSource as DataTable).Columns)
				GridView1.MasterTableView.GetColumn(col.ColumnName).HeaderText = ClassLibrary.JLanguages._Text(col.ColumnName);
			GridView1.MasterTableView.Rebind();
			if (GridView.HiddenColumns != null && GridView.HiddenColumns != "")
				foreach (string column in GridView.HiddenColumns.Split(','))
				{
					try
					{
						int index = GridView1.MasterTableView.GetColumn(column).OrderIndex;
						GridView1.MasterTableView.RenderColumns[index].Display = false;
					}
					catch { }
				}

		}
		////______________________________________________________________________________________________________
		protected void GridView1_ColumnCreated(object sender, Telerik.Web.UI.GridColumnCreatedEventArgs e)
		{
			e.Column.FilterControlWidth = Unit.Pixel(80);

			if (GridView != null && GridView.HiddenColumns != null && GridView.HiddenColumns.Contains(e.Column.UniqueName))
			{
				e.Column.Visible = false;
			}
			if (SumFields.ContainsKey(e.Column.UniqueName))
			{

				(e.Column as Telerik.Web.UI.GridBoundColumn).Aggregate = Telerik.Web.UI.GridAggregateFunction.Custom;
				// (e.Column as Telerik.Web.UI.GridBoundColumn).DataFormatString = "\n{0:F0}\n";
				//(e.Column as Telerik.Web.UI.GridBoundColumn).DataType = typeof(System.Double);
				//(e.Column as Telerik.Web.UI.GridBoundColumn).DataFormatString = "{0:G17}";



			}
			if ((e.Column as Telerik.Web.UI.GridBoundColumn) != null)
				(e.Column as Telerik.Web.UI.GridBoundColumn).HeaderText = ClassLibrary.JLanguages._Text(e.Column.UniqueName);


		}
		////______________________________________________________________________________________________________
		protected void GridView1_CustomAggregate(object sender, Telerik.Web.UI.GridCustomAggregateEventArgs e)
		{
			if (SumFields.ContainsKey(e.Column.UniqueName))
			{
				(e.Column as Telerik.Web.UI.GridBoundColumn).FooterAggregateFormatString = "<table  cellspacing='0' cellpading='0'  border='0' style='padding: 0px; margin: 0px; border-width: 0px;  width:150px; '  ><tr><td  dir='rtl'>جمع:</td></tr><tr><td style='text-align:right; '>" + SumFieldsPage[e.Column.UniqueName] + "</td></tr>";
				(e.Column as Telerik.Web.UI.GridBoundColumn).FooterAggregateFormatString += "       <tr><td style='width:150px; dir='rtl'>جمع-کل:</td></tr><tr><td style='text-align:right; '>" + SumFields[e.Column.UniqueName] + "</td></tr>";
				(e.Column as Telerik.Web.UI.GridBoundColumn).FooterAggregateFormatString += "       <tr><td  dir='rtl'>تاریخ:</td></tr><tr><td style='text-align:right; '> " + ClassLibrary.JDateTime.FarsiDate(DateTime.Now.Date) + "</td></tr>";
				(e.Column as Telerik.Web.UI.GridBoundColumn).FooterAggregateFormatString += "       <tr><td  dir='rtl'>ساعت:</td></tr><tr><td style='text-align:right; '>" + DateTime.Now.ToShortTimeString() + "</td></tr></table>";

				//Alternative++;
				//if (Alternative % 2 == 0)
				//    lblFooter.Text += "<table style='background-color: #EEEEF2'  cellspacing='0' cellpading='0'  border='0' style='padding: 0px; margin: 0px; border-width: 1px;  width:450px; '  >"
				//                 + "       <tr> <td style='width:150px;text-align:center;'  dir='rtl'>" + ClassLibrary.JLanguages._Text(e.Column.UniqueName) + "</td>"
				//                 + "       <td      style='width:150px;text-align:center;'  dir='rtl'>" + SumFieldsPage[e.Column.UniqueName] + "</td>"
				//                 + "       <td      style='width:150px;text-align:center;'  dir='rtl'>" + SumFields[e.Column.UniqueName] + "</td></tr></table>";
				//else
				//    lblFooter.Text += "<table style='background-color:white'  cellspacing='0' cellpading='0'  border='0' style='padding: 0px; margin: 0px; border-width: 1px;  width:450px; '  >"
				//                 + "       <tr> <td style='width:150px;text-align:center;'  dir='rtl'>" + ClassLibrary.JLanguages._Text(e.Column.UniqueName) + "</td>"
				//                 + "       <td      style='width:150px;text-align:center;' dir='rtl'>" + SumFieldsPage[e.Column.UniqueName] + "</td>"
				//                 + "       <td      style='width:150px;text-align:center;' dir='rtl'>" + SumFields[e.Column.UniqueName] + "</td></tr></table>";

				//+ "       <td  dir='rtl'>تاریخ:</td></tr><tr><td style='text-align:right; '> " + ClassLibrary.JDateTime.FarsiDate(DateTime.Now.Date) + "</td>"
				//+ "       <td  dir='rtl'>ساعت:</td></tr><tr><td style='text-align:right; '>" + DateTime.Now.ToShortTimeString() + "</td></tr></table>";
			}
		}
		////______________________________________________________________________________________________________
		protected void RadComboBox_Page_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
		{
			GetData(true);
		}
		////______________________________________________________________________________________________________
		protected void GridView1_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
		{
			GridView.PageSize = e.NewPageSize;
			GridView1.CurrentPageIndex = 0;
			ViewState["currentPage"] = 1;
			ViewState["pageSize"] = e.NewPageSize;
			GetData(true);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			foreach (GridDataItem row in GridView1.Items)
			{
				GridDataItem item = row;
				for (int i = 0; i < RowStyles.Count; i++)
				{
					int index = GetGridColumnId(RowStyles[i].columnName);
					if (index == -1)
						continue;
					TableCell cell = item.Cells[index];
					if (cell == null)
						continue;
					int cellValue = -1;
					int.TryParse(cell.Text, out cellValue);
					if (cellValue == -1)
						continue;
					var list = (from x in RowStyles where x.fromTime <= cellValue && x.toTime > cellValue select x.color);
					if (list.Count() < 1)
						continue;
					string color = list.First();
					item.BackColor = System.Drawing.Color.FromArgb(int.Parse(color.Substring(2), System.Globalization.NumberStyles.HexNumber));
				}
			}
		}
		////______________________________________________________________________________________________________
		#endregion GridView Events

		#region ToolBar Events
		////______________________________________________________________________________________________________
		protected void RadToolBar1_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
		{
			if (GridView == null) return;
			var q = GridView.Toolbar.Buttons.Where(m => m.Name == e.Item.Value);
			if (q.Count() > 0)
			{
				ToolBar.JToolBarItem jToolBarItem = q.First();
				try
				{
					string index = Request["radGridClickedRowIndex"].ToString();
					Telerik.Web.UI.GridDataItem param = GridView1.MasterTableView.Items[index];
					if (jToolBarItem.Action.ParameterValue == null) jToolBarItem.Action.ParameterValue = new List<object>();
					jToolBarItem.Action.ParameterValue.Clear();
					jToolBarItem.Action.ParameterValue.Add(param);
				}
				catch
				{
				}

				jToolBarItem.Action.runAction();
			}
		}
		////______________________________________________________________________________________________________
		protected void RadToolBar2_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
		{
			if (GridView == null) return;

			string Query = GridView.SQL;
			List<string> REP_SQL;

			if (e.Item.Value != "refresh")
			{
				ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
				try
				{
					db.setQuery(GridView.SQL);
					radGridForPrint.DataSource = db.Query_DataTable();
					radGridForPrint.DataBind();
				}
				finally
				{
					db.Dispose();
				}
			}
			if (radGridForPrint.DataSource != null)
			{
				foreach (DataColumn col in (radGridForPrint.DataSource as DataTable).Columns)
					radGridForPrint.MasterTableView.GetColumn(col.ColumnName).HeaderText = ClassLibrary.JLanguages._Text(col.ColumnName);
				radGridForPrint.ExportSettings.OpenInNewWindow = true;
				radGridForPrint.ExportSettings.IgnorePaging = false;
				radGridForPrint.ExportSettings.HideStructureColumns = false;
			}
			switch (e.Item.Value)
			{
				case "refresh":
					GetData();
					break;
				case "print":
					//  WebReport.JReportManager.SelectReport(false, "rptGrid", GridView.ClassName, 0, WebClassLibrary.WindowTarget.NewWindow, new List<WebReport.JReportDataSource>() { new WebReport.JReportDataSource(GridView.Title, GridView1.DataSource as DataTable) });
					//radGridForPrint.ExportSettings.ExportOnlyData = false;
					//radGridForPrint.MasterTableView.ExportToPdf();

					REP_SQL = new List<string>();
					REP_SQL.Add(Query);
					Session["REP_SQL"] = REP_SQL;
					WebClassLibrary.JWebManager.LoadControl(GridView.ClassName
					, "~/WebReport/Viewer/JReportSelectorControl.ascx"
					, "چاپ"
					, new List<Tuple<string, string>>(){ new Tuple<string, string>("ObjectCode", "0")
                                               ,  new Tuple<string, string>("rSUID", "Report_Dt")
                                               , new Tuple<string, string>("ClassName",GridView.ClassName) 
                                               , new Tuple<string,string>("SQL1",Query) }
					, WebClassLibrary.WindowTarget.NewWindow
					, true, true, true, 750, 500);
					break;

				case "record_print":
					string where = string.Empty;
					REP_SQL = new List<string>();

					if (GridView1.SelectedIndexes.Count > 0)
					{
						//for (int i = 0; i < GridView1.SelectedIndexes.Count; i++)
						//{
						//    if (i > 0 && GridView1.SelectedIndexes[0] != string.Empty)
						//        where += " OR ";
						where += " t.Code = " + GridView1.SelectedValues["Code"].ToString();
						//}
						Query = "Select * From (" + Query + ")t Where " + where;
					}
					REP_SQL.Add(Query);
					Session["REP_SQL"] = REP_SQL;
					WebClassLibrary.JWebManager.LoadControl(GridView.ClassName
					, "~/WebReport/Viewer/JReportSelectorControl.ascx"
					, "چاپ"
					, new List<Tuple<string, string>>(){ new Tuple<string, string>("ObjectCode", "0")
                                               ,  new Tuple<string, string>("rSUID", "Report_Dt")
                                               , new Tuple<string, string>("ClassName",GridView.ClassName) 
                                               , new Tuple<string,string>("SQL1",Query) }
					, WebClassLibrary.WindowTarget.NewWindow
					, true, true, true, 750, 500);
					break;

				case "pdf":
					radGridForPrint.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Html;
					radGridForPrint.ExportSettings.ExportOnlyData = false;
					radGridForPrint.MasterTableView.ExportToPdf();
					break;
				case "excel":
					radGridForPrint.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.ExcelML;
					radGridForPrint.ExportSettings.FileName = GridView.Title + DateTime.Now;
					radGridForPrint.ExportSettings.ExportOnlyData = true;
					radGridForPrint.ExportSettings.IgnorePaging = true;
					radGridForPrint.MasterTableView.ExportToExcel();
					break;
				case "word":
					radGridForPrint.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
					radGridForPrint.ExportSettings.ExportOnlyData = true;
					radGridForPrint.ExportSettings.IgnorePaging = true;
					radGridForPrint.MasterTableView.ExportToWord();
					break;
				case "csv":
					radGridForPrint.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.ExcelML;
					radGridForPrint.ExportSettings.ExportOnlyData = true;
					radGridForPrint.ExportSettings.IgnorePaging = true;
					radGridForPrint.MasterTableView.ExportToCSV();
					break;
				case "formmanagers":
					string index = Request["radGridClickedRowIndex"].ToString();
					if (index == "" || Convert.ToInt32(index) < 0) return;
					Telerik.Web.UI.GridDataItem gridItem = GridView1.MasterTableView.Items[index];
					WebClassLibrary.JSUIDManager jSUIDManager = new WebClassLibrary.JSUIDManager("FormManagers", true);
					jSUIDManager.SetObject("ObjectCode", Convert.ToInt32(gridItem["Code"].Text));
					jSUIDManager.SetObject("ClassName", GridView.ClassName);// "ClassLibrary.FormManagers");
					WebClassLibrary.JWebManager.LoadControl("FormManagers"
							, "~/WebControllers/FormManager/JFormListControl.ascx"
							, "فرم ساز"
							, null
							, WebClassLibrary.WindowTarget.NewWindow
							, true, false, true, 600, 350);
					break;
				case "forms":
					WebClassLibrary.JSUIDManager jSUIDForm = new WebClassLibrary.JSUIDManager("Forms", true);
					//jSUIDManager.SetObject("ClassName", "WebControllers.FormManager.JWebForms");
					jSUIDForm.SetObject("ClassName", GridView.ClassName);// "ClassLibrary.FormManagers");
					WebClassLibrary.JWebManager.LoadControl("Forms"
							, "~/WebControllers/FormManager/JWebForms.ascx"
							, "فرم ها"
							, null
							, WebClassLibrary.WindowTarget.NewWindow
							, true, true, true, 600, 350);
					break;
				//case "help":
				//    Help.JHelps.ShowHelp(GridView.ClassName, 0);
				//    break;
			}
		}
		////______________________________________________________________________________________________________
		#endregion ToolBar Events

		#region Filter (Search) Events
		////______________________________________________________________________________________________________
		protected void Filter_TextChanged(object sender, EventArgs e)
		{
			ViewState["NoFilterClick"] = true;
		}
		////______________________________________________________________________________________________________
		private void radComboBox_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
		{
			ViewState["NoFilterClick"] = true;
			((Telerik.Web.UI.RadComboBox)sender).FindItemByValue(e.Value).Selected = true;
			((Telerik.Web.UI.RadComboBox)sender).SelectedIndex = ((Telerik.Web.UI.RadComboBox)sender).FindItemByValue(e.Value).Index;
			((Telerik.Web.UI.RadComboBox)sender).DataBind();
		}
		////______________________________________________________________________________________________________
		protected void btnFilter_Click(object sender, EventArgs e)
		{
			if (GridView == null)
				return;
			GridView.FilterQuery = "";
			ViewState["VirtualItemCount"] = null;
			FilterItem = new Dictionary<string, string>();
			foreach (HtmlTableRow row in tblFilter.Rows)
			{
				//CommentBy Sheikh Nezami   
				// string colName = ((HiddenField)row.Cells[3].Controls[0]).Value;
				string colName = ((Telerik.Web.UI.RadTextBox)row.Cells[1].Controls[0]).ID.Replace("txtFilter_", string.Empty);
				string searchText = ((Telerik.Web.UI.RadTextBox)row.Cells[1].Controls[0]).Text.Replace("'", "''").Trim();
				if (searchText.Length == 0) continue;
				if (GridView.FilterQuery != string.Empty)
					GridView.FilterQuery += " AND ";

				//)ViewState["FilterItem"];

				switch (((Telerik.Web.UI.RadComboBox)row.Cells[2].Controls[0]).SelectedValue)
				{
					case "Contains":
						GridView.FilterQuery += "  [" + colName + "] LIKE N'%" + searchText + "%'";
						break;
					case "Equals":
						GridView.FilterQuery += "  [" + colName + "] = N'" + searchText + "'";
						break;
					case "Bigger":
						GridView.FilterQuery += "  [" + colName + "] > '" + searchText + "'";
						break;
					case "Smaller":
						GridView.FilterQuery += "  [" + colName + "] < '" + searchText + "'";
						break;
				}
				FilterItem.Add(colName
							  , ((Telerik.Web.UI.RadComboBox)row.Cells[2].Controls[0]).SelectedValue + "_" + searchText);


			}
			ViewState["NoFilterClick"] = false;
			ViewState["FilterItem"] = FilterItem;
			GridView.SessionSave();

			GetData(true);
		}
		////______________________________________________________________________________________________________
		protected void btnNoFilter_Click(object sender, EventArgs e)
		{
			ViewState["VirtualItemCount"] = null;
			FilterItem = (Dictionary<string, string>)ViewState["FilterItem"];
			if (FilterItem == null)
				FilterItem = new Dictionary<string, string>();
			FilterItem.Clear();
			ViewState["NoFilterClick"] = true;
			ViewState["FilterItem"] = FilterItem;
			GridView.FilterQuery = string.Empty;
			GridView.SessionSave();
			GetData(true);
		}

		////______________________________________________________________________________________________________

		#endregion Filter (Search) Events


		protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
		{
			if (e.Argument == "DoubleClick")
			{
				//Do Something
			}
		}

		protected void GridView1_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
		{
			GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
			string MasterCode = dataItem.GetDataKeyValue("Code").ToString();
			DataTable Grid_dt;
			string Where = string.Empty;


			Grid_dt = (DataTable)ViewState["Grid_dt"];
			Grid_dt.DefaultView.RowFilter = " Code  =" + MasterCode;

			if (ViewState["Grid_dt"] != null)
			{
				foreach (string Key in GridView.DetailKeyFields.Keys)
				{
					if (!GridView.IsDetailQueryIn)
					{
						if (Grid_dt.DefaultView[0][Key].ToString() != string.Empty)
						{
							if (Where != string.Empty && GridView.DetailKeyFields[Key] != string.Empty)
								Where += GridView.DetailKeyFields[Key];
							else
								Where += " Where ";

							Where += "t." + Key + " = " + Grid_dt.DefaultView[0][Key].ToString();
						}

					}
					else
					{
						if (Grid_dt.DefaultView[0][Key].ToString() != string.Empty)
						{
							if (Where != string.Empty && GridView.DetailKeyFields[Key] != string.Empty)
								Where += GridView.DetailKeyFields[Key];
							else
								Where += " Where ";

							Where += "t." + Key + " IN (" + Grid_dt.DefaultView[0][Key].ToString() + ")";
						}
					}
				}


				e.DetailTableView.DataSource = WebClassLibrary.JWebDataBase.GetDataTable(" Select * From  (" + GridView.DetailDataSource + ")t " + Where);
			}
		}

		protected void GridView1_SortCommand(object sender, GridSortCommandEventArgs e)
		{
			isSortingChanged = e.SortExpression.ToLower() != "databasetablerownum";
			GridView1.SelectedIndexes.Clear();
			//GridView.PageOrderByField = e.SortExpression + (e.NewSortOrder.ToString().ToLower() == "descending" ? " desc" : "");
			sortField = " [" + e.SortExpression + "] " + (e.NewSortOrder.ToString().ToLower() == "descending" ? " desc" : "");
			GetData(true);
		}

	}

}
