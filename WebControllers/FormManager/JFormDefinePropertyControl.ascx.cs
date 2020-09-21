using Globals.Property;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace WebControllers.FormManager
{
	public partial class JFormDefinePropertyControl : System.Web.UI.UserControl
	{
		#region Propperties

		//public System.Data.DataTable _datatable;
		public DataTable _datatable
		{
			get
			{
				if (ViewState["_datatable"] != null)
					return (DataTable)ViewState["_datatable"];
				else
					return new DataTable();
			}
			set
			{
				ViewState["_datatable"] = value;
			}
		}
		private string ClassName
		{
			get
			{
				if (ViewState["_className"] != null)
					return ViewState["_className"].ToString();
				else
					return "";
			}
			set
			{
				ViewState["_className"] = value;
			}
		}
		private int ObjectCode
		{
			get
			{
				if (ViewState["_objectCode"] != null)
					return (int)ViewState["_objectCode"];
				else
					return 0;
			}
			set
			{
				ViewState["_objectCode"] = value;
			}
		}
		string JWebFormsTemporaryURL;
		#endregion

		//#region Events
		///// <summary>
		///// رویداد پس از افزودن ویژگی
		///// </summary>
		///// <param name="Sender"></param>
		///// <param name="e"></param>
		//public delegate void PropertyAdded(object Sender, EventArgs e);
		//public event PropertyAdded AfterPropertyAdded;

		///// <summary>
		///// رویداد پس از حذف ویژگی
		///// </summary>
		///// <param name="Sender"></param>
		///// <param name="e"></param>
		//public delegate void PropertyDeleted(object Sender, EventArgs e);
		//public event PropertyDeleted AfterPropertyDeleted;

		///// <summary>
		///// رویداد قبل از حذف ویژگی
		///// </summary>
		///// <param name="Sender"></param>
		///// <param name="e"></param>
		//public delegate void PropertyDelete(object Sender, EventArgs e);
		//public event PropertyDelete BeforPropertyDeleted;
		//#endregion

		#region function
		public void refreshDataTable()
		{
			//if (this.DesignMode)
			//    return;
			//if (_datatable != null)
			//    _datatable.Dispose();
			gridView.DataSource = _datatable;
			gridView.DataBind();
			//gridView.Columns["ClassName"].Visible = false;
			//gridView.Columns["Code"].Visible = false;
			//gridView.Columns["DefaultValue"].Visible = false;
			//gridView.Columns["ObjectCode"].Visible = false;
			//gridView.Columns["List"].HeaderText = "ValueList";
		}
		#endregion
		private void SetclbControl()
		{
			clbPostEditList.DataSource = Employment.JEOrganizationChart.GetUserPosts();
			clbPostEditList.DataTextField = "Title";
			clbPostEditList.DataValueField = "Code";
			clbPostEditList.DataBind();
			//SetList(clbPostEditList, Property.ListCanEdit);
			//if (Property.ListCanEdit != null && Property.ListCanEdit.Length > 0)
			//    chkAllEdit.Checked = false;

			clbPostViewList.DataSource = Employment.JEOrganizationChart.GetUserPosts();
			clbPostViewList.DataTextField = "Title";
			clbPostViewList.DataValueField = "Code";
			clbPostViewList.DataBind();
			//SetList(clbPostViewList, Property.ListCanView);
			//if (Property.ListCanView != null && Property.ListCanView.Length > 0)
			//    chkAllView.Checked = false;
		}
		public string GetList(CheckBoxList pCLB)
		{
			string List = "";
			for (int i = 0; i < pCLB.Items.Count; i++)
				if (pCLB.Items[i].Selected)
					List += (i > 0 ? "," : "") + pCLB.Items[i].Value;
			return List;
		}
		public void SetList(CheckBoxList pCLB, string pList)
		{
			if (pList == null || pList.Length == 0)
			{
			}
			else
			{
				string[] Values = pList.Split(new char[] { ',' });
				for (int i = 0; i < pCLB.Items.Count; i++)
					for (int j = 0; j < Values.Length; j++)
						pCLB.Items[i].Selected = pCLB.Items[i].Value == Values[j];
			}
		}
		void GridDoubleClick(int index)
		{
			txbTitle.Text = gridView.Items[index]["Name"].Text;
			txbListType.SelectedValue = gridView.Items[index]["ListType"].Text;
			txbDataType.SelectedValue = gridView.Items[index]["DataType"].Text;
			txbOrder.Text = gridView.Items[index]["Ordered"].Text;
			hdnPostViewList.Value = gridView.Items[index]["ListCanView"].Text;
			hdnPostEditList.Value = gridView.Items[index]["ListCanEdit"].Text;
			string[] vPosts = gridView.Items[index]["ListCanView"].Text.Split(',');
			string[] ePosts = gridView.Items[index]["ListCanEdit"].Text.Split(',');
			chkAllView.Checked = vPosts.Length == 0;
			chkAllEdit.Checked = ePosts.Length == 0;
			for (int i = 0; i < vPosts.Length; i++)
				for (int j = 0; j < clbPostViewList.Items.Count; j++)
					if (clbPostViewList.Items[j].Value == vPosts[i])
					{
						clbPostViewList.Items[j].Selected = true;
						break;
					}
			for (int i = 0; i < ePosts.Length; i++)
				for (int j = 0; j < clbPostEditList.Items.Count; j++)
					if (clbPostEditList.Items[j].Value == ePosts[i])
					{
						clbPostEditList.Items[j].Selected = true;
						break;
					}
			//if (!this.Page.ClientScript.IsStartupScriptRegistered("showDialogScript"))
			//this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "showDialogScript", "$(\"#jfpcDiv\").dialog(\"open\");", true);
			//ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>myFunction();</script>", false);
			//ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "tmp", "myFunction();", true);
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			//if (Request["__EVENTTARGET"] != null && Request["__EVENTTARGET"].ToLower() == "gridviewdblclicked")
			//{
			//    int index = int.Parse(Request["__EVENTARGUMENT"]);
			//    GridDoubleClick(index);
			//    return;
			//}
			WebClassLibrary.JSUIDManager formSUID = new WebClassLibrary.JSUIDManager("Forms");
			ClassName = formSUID.GetObject("ClassName").ToString();
			ObjectCode = (int)formSUID.GetObject("ObjectCode");
			JWebFormsTemporaryURL = formSUID.GetObject("JWebFormsTemporaryURL").ToString();
			if (IsPostBack)
				return;
			JProperties PropTB = new JProperties(ClassName, ObjectCode);
			_datatable = PropTB.GetDataTable();
			refreshDataTable();
			SetclbControl();
			//var tmp_dt = formSUID.GetObject("_dataTable");
			//if (tmp_dt != null)
			//    _datatable = tmp_dt as DataTable;

			txbDataType.DataSource = Enum.GetNames(typeof(Globals.Property.JSQLDataType));
			txbDataType.DataBind();
			txbListType.DataSource = Enum.GetNames(typeof(Globals.Property.JProppertyListType));
			txbListType.DataBind();
		}

		//protected void btnInsert_Click(object sender, EventArgs e)
		//{
		//    WebClassLibrary.JSUIDManager formSUID = new WebClassLibrary.JSUIDManager("Forms");
		//    formSUID.SetObject("JDefinePropertyFormTemporaryURL", Request.Url.AbsoluteUri);
		//    //formSUID.SetObject("ClassName", ClassName);
		//    //formSUID.SetObject("ObjectCode", ObjectCode);
		//    formSUID.SetObject("Code", 0);
		//    //formSUID.SetObject("_datatable", _datatable);

		//    //WebClassLibrary.JWebManager.LoadControl("Forms"
		//    //        , "~/WebControllers/FormManager/JFormPropertyControl.ascx"
		//    //        , "فیلد"
		//    //        , null
		//    //        , WebClassLibrary.WindowTarget.NewWindow
		//    //        , true, true, true, 600, 400);

		//    //WebClassLibrary.JWebManager.SetControlType(WebClassLibrary.JDomains.JControls.JUserControl, "Forms", "~/WebControllers/FormManager/JFormPropertyControl.ascx");
		//    //System.Web.HttpContext.Current.Response.Redirect(WebClassLibrary.JWebManager.GenerateControlURL("Forms"));


		//    //if (PF.ShowDialog() == DialogResult.OK)
		//    //{
		//    //    if (_datatable == null)
		//    //        return;
		//    //    DataRow DR = _datatable.NewRow();

		//    //    DR["Name"] = PF.Property.Name.Replace("__", " ");
		//    //    DR["Active"] = PF.Property.Active;
		//    //    DR["ClassName"] = PF.Property.ClassName;
		//    //    DR["Code"] = PF.Property.Code;
		//    //    DR["DataType"] = PF.Property.DataType;
		//    //    DR["DefaultValue"] = PF.Property.DefaultValue;
		//    //    DR["List"] = PF.Property.List;
		//    //    DR["ListType"] = PF.Property.ListType;
		//    //    DR["Ordered"] = PF.Property.Ordered;
		//    //    DR["ObjectCode"] = PF.Property.ObjectCode;
		//    //    DR["ListCanView"] = PF.Property.ListCanView;
		//    //    DR["ListCanEdit"] = PF.Property.ListCanEdit;

		//    //    _datatable.Rows.Add(DR);

		//    //    if (AfterPropertyAdded != null)
		//    //        AfterPropertyAdded(sender, e);
		//    //}
		//}

		protected void btnClose_Click(object sender, EventArgs e)
		{
			WebClassLibrary.JWebManager.CloseWindow();
		}

		protected void btnDelete_Click(object sender, EventArgs e)
		{
			if (_datatable == null)
				return;
			JProperty jp = new JProperty(ClassName, ObjectCode);
			string code = Regex.Replace(hdnCode.Value, @"&nbsp;", "").Trim();
			if (string.IsNullOrWhiteSpace(code))
				return;
			DataRow dr = _datatable.Select("Code =" + code)[0];
			jp.SetDataRow(dr);
			if (jp != null && jp.Delete())
			{
				_datatable.Rows.Remove(dr);
				refreshDataTable();
			}
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			if (_datatable == null)
				return;
			JProperty jp = new JProperty(ClassName, ObjectCode);
			string code = Regex.Replace(hdnCode.Value, @"&nbsp;", "").Trim();
			DataRow DR = null;
			if (!string.IsNullOrWhiteSpace(code))
			{
				DR = _datatable.Select("Code =" + code)[0];
				jp.SetDataRow(DR);
			}
			jp.Active = false;
			//jp.ClassName = ClassName;
			jp.DataType = txbDataType.SelectedValue;
			jp.DefaultValue = "";
			jp.List = txbListValue.Text;
			jp.ListCanEdit = hdnPostEditList.Value;
			jp.ListCanView = hdnPostViewList.Value;
			jp.ListType = txbListType.SelectedValue;
			jp.Name = txbTitle.Text;
			//jp.ObjectCode = ObjectCode;
			if (txbOrder.Text.Trim() != "")
				jp.Ordered = int.Parse(txbOrder.Text);
			//string code = Regex.Replace(hdnCode.Value, @"&nbsp;", "").Trim();
			//if (code != "")
			//	jp.Code = int.Parse(code);
			if (jp.Code > 0)
				jp.Update();
			else
			{
				jp.Insert();
				DR = _datatable.NewRow();
			}
			DR["Name"] = jp.Name.Replace("__", " ");
			DR["Active"] = jp.Active;
			DR["ClassName"] = jp.ClassName;
			DR["Code"] = jp.Code;
			DR["DataType"] = jp.DataType;
			DR["DefaultValue"] = jp.DefaultValue;
			DR["List"] = jp.List;
			DR["ListType"] = jp.ListType;
			DR["Ordered"] = jp.Ordered;
			DR["ObjectCode"] = jp.ObjectCode;
			DR["ListCanView"] = jp.ListCanView;
			DR["ListCanEdit"] = jp.ListCanEdit;
			_datatable.Rows.Add(DR);
           if(_datatable.Rows.Count>0)
			refreshDataTable();
		}
		//protected override void OnPreRender(EventArgs e)
		//{
		//    base.OnPreRender(e);
		//    #region txtCode_Settings
		//    JJson.JsonResponse txtCode_res = new JJson.JsonResponse();
		//    txtCode_res.Type = JJson.JsonResponseType.Dialog;
		//    txtCode_res.Params = new List<JJson.JsonResponseParam>();
		//    txtCode_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = "dialogDiv", Action = JJson.JsonAction.Html });
		//    txtCode.OnSuccessControlsAction = txtCode_res;
		//    JJson.JsonRequest txtCode_req = new JJson.JsonRequest();
		//    txtCode_req.URL = "WebControllers/JJsonServices/JJsonService.asmx/Run";////GetTitleByCode";
		//    txtCode_req.Type = JJson.JsonRequestType.LoadControl;
		//    //txtCode_req.data = "Select title From (@sql) weberp_tbl_customlistview_1 Where Code =@code";
		//    txtCode_req.Params = new List<JJson.JsonRequestParam>();
		//    txtCode_req.Params.Add(new JJson.JsonRequestParam() { Name = "uc", Type = JJson.JsonAction.Constant, Value = "FormManager/JFormListControl.ascx" });
		//    //txtCode_req.Params.Add(new JJson.JsonRequestParam() { Name = "@sql", Type = JJson.JsonAction.Value, ControlID = hfd.ClientID });
		//    txtCode.Request = txtCode_req;
		//    JJson.JsonResponse txtCode_error = new JJson.JsonResponse();
		//    txtCode_error.Params = new List<JJson.JsonResponseParam>();
		//    txtCode_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
		//    txtCode.OnErrorControlsAction = txtCode_error;
		//    #endregion
		//}
		protected void btnOk_Click(object sender, EventArgs e)
		{
			_datatable.AcceptChanges();
			WebClassLibrary.JWebManager.CloseWindow();
		}
	}
}