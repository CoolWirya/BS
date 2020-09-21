using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using WebClassLibrary;
using Telerik.Web.UI;

namespace WebControllers.FormManager
{
	[Serializable()]
	public partial class JFormListControl : System.Web.UI.UserControl
	{
        string SUID = "FormManagers";
		public string ClassName
		{
			get
			{
				if (ViewState["ClassName"] == null)
					return "";
				return ViewState["ClassName"].ToString();
			}
			set
			{
				ViewState["ClassName"] = value;
			}
		}
		public int ObjectCode
		{
			get
			{
				if (ViewState["ObjectCode"] == null)
					return 0;
				return (int)ViewState["ObjectCode"];
			}
			set
			{
				ViewState["ObjectCode"] = value;
			}
		}
		public int FormCode
		{
			get
			{
				if (ViewState["FormCode"] == null)
					return 0;
				return (int)ViewState["FormCode"];
			}
			set
			{
				ViewState["FormCode"] = value;
			}
		}
		private Telerik.Web.UI.RadPanelBar panelForms = new Telerik.Web.UI.RadPanelBar();
		private Telerik.Web.UI.RadPanelBar panelFormObjects = new Telerik.Web.UI.RadPanelBar();
		void GridDoubleClick(int index)
		{
			string SUID = "FormManagers";
			WebClassLibrary.JSUIDManager jSUIDManager = new WebClassLibrary.JSUIDManager(SUID);
			//jSUIDManager.SetObject("FormObjectCode", Convert.ToInt32(e.Item.Value));
			bool isMultiple = (new ClassLibrary.JForms(FormCode)).isMultiple;
			jSUIDManager.SetObject("ValueObjectCode", gridView.Items[index]["ObjectCode"].Text);
			jSUIDManager.SetObject("TableCode", isMultiple ? "0" : gridView.Items[index]["Code"].Text);
			jSUIDManager.SetObject("ReferCode", 0);
			//jSUIDManager.SetObject("ObjectCode", isMultiple ? gridView.Items[index]["ListObjectCode"].Text : ObjectCode.ToString());
			jSUIDManager.SetObject("FormCode", FormCode);
			jSUIDManager.SetObject("IsMultiple", isMultiple);
			jSUIDManager.SetObject("ClassName", ClassName);
			WebClassLibrary.JWebManager.LoadControl(SUID
					, "~/WebControllers/FormManager/JFormObjectControl.ascx"
					, "فرم"
					, null
					, WebClassLibrary.WindowTarget.CurrentWindow
					, true, false, true, 600, 350);
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request["__EVENTTARGET"] != null && Request["__EVENTTARGET"].ToLower() == "gridviewdblclicked")
			{
				int index = int.Parse(Request["__EVENTARGUMENT"]);
				GridDoubleClick(index);
				return;
			}
          string  ClassName1 = Request.QueryString["ClassName"]; 
			// Get Variables
			WebClassLibrary.JSUIDManager formSUID = new WebClassLibrary.JSUIDManager("FormManagers");
			//ClassName = formSUID.GetObject("ClassName").ToString();
			ClassName = Request["ClassName"];
			if (!IsPostBack)
				//ObjectCode = Convert.ToInt32(formSUID.GetObject("ObjectCode"));
				ObjectCode = Convert.ToInt32(Request["ObjectCode"]);
			panelForms.Width = new Unit(100, UnitType.Percentage);
			panelFormObjects.Width = new Unit(100, UnitType.Percentage); DataTable dt = ClassLibrary.JForms.GetListForm(ClassName);
			if (dt != null)
				foreach (DataRow row in dt.Rows)
				{
					Telerik.Web.UI.RadPanelItem radPanelItem = new Telerik.Web.UI.RadPanelItem();
					radPanelItem.Value = WebClassLibrary.JDataManager.EncryptString(row["Code"].ToString());
					radPanelItem.Text = row["FormName"].ToString();
                    Objlabel.InnerText = row["FormName"].ToString();
					panelForms.Items.Add(radPanelItem);
				}
			else
				WebClassLibrary.JWebManager.ShowMessage("برای این قسمت فرمی طراحی نشده است.");

			panelForms.ItemClick += radPanelBar_ItemClick;
			divForms.Controls.Add(panelForms);
			if (IsPostBack)
				return;
			if (formSUID.GetObject("FormCode") != null)
				FormCode = Convert.ToInt32(formSUID.GetObject("FormCode"));

			//if (panelForms.SelectedItem != null)
			//{
			//    FormCode = Convert.ToInt32(WebClassLibrary.JDataManager.DecryptString(panelForms.SelectedItem.Value));
			//    LoadFormObjects();
			//}
			//else 
			if (FormCode != 0)
            { }
				//LoadFormObjects();
			//WebClassLibrary.JWebManager.AddToAjaxManager(panelForms, panelFormObjects);
		}

		void radPanelBar_ItemClick(object sender, Telerik.Web.UI.RadPanelBarEventArgs e)
		{
			FormCode = Convert.ToInt32(WebClassLibrary.JDataManager.DecryptString(e.Item.Value));
			LoadFormObjects();
		}

		void LoadFormObjects()//int FormCode)
		{
			hidSelectedForm.Value = FormCode.ToString();
			//Telerik.Web.UI.RadPanelBar panelFormObjects = new Telerik.Web.UI.RadPanelBar();
			//DataTable dt = (new ClassLibrary.JFormObjects()).GetDataTable(FormCode);
			DataTable dt = (new ClassLibrary.JFormObjects()).GetObjectTable(FormCode, ObjectCode, ClassName);
            //panelFormObjects.Items.Clear();
            //foreach (DataRow row in dt.Rows)
            //{
            //    Telerik.Web.UI.RadPanelItem radPanelItem = new Telerik.Web.UI.RadPanelItem();
            //   // radPanelItem.Text = row["ObjectCode"].ToString();// +" - " + ClassLibrary.JDateTime.FarsiDate(Convert.ToDateTime(row["Date"]));
            //  radPanelItem.Value = row["Code"].ToString();
            //    panelFormObjects.Items.Add(radPanelItem);
            //}
            //panelFormObjects.ItemClick += radPanelBarObjects_ItemClick;
            //divFormObjects.Controls.Add(panelFormObjects);
            gridView.DataSource = null;
			if (dt != null && dt.Rows.Count > 0)
				gridView.DataSource = dt;
			gridView.DataBind();

            //DataTable sqlDt = (new JForms(FormCode)).GetSQL(ObjectCode);
            //if (sqlDt == null) return;
            //DataTable sqlResultDt = new DataTable();
            //sqlResultDt.Columns.Add("نام");
            //sqlResultDt.Columns.Add("مقدار");
            //for (int i = 0; i < sqlDt.Columns.Count; i++)
            //{
            //    DataRow dr = sqlResultDt.NewRow();
            //    dr[0] = JLanguages._Text(sqlDt.Columns[i].ToString());
            //    if (sqlDt.Rows.Count > 0)
            //        dr[1] = sqlDt.Rows[0][i];
            //    sqlResultDt.Rows.Add(dr);
            //}
            //SqlGrid.DataSource = sqlResultDt;
            //SqlGrid.DataBind();
		}

		void radPanelBarObjects_ItemClick(object sender, Telerik.Web.UI.RadPanelBarEventArgs e)
		{
			string SUID = "FormManagers";
			WebClassLibrary.JSUIDManager jSUIDManager = new WebClassLibrary.JSUIDManager(SUID);
			//jSUIDManager.SetObject("FormObjectCode", Convert.ToInt32(e.Item.Value));
			jSUIDManager.SetObject("ValueObjectCode", Convert.ToInt32(e.Item.Value));
			jSUIDManager.SetObject("ReferCode", 0);
			jSUIDManager.SetObject("ObjectCode", ObjectCode);
			jSUIDManager.SetObject("ClassName", ClassName);
			jSUIDManager.SetObject("FormCode", Convert.ToInt32(WebClassLibrary.JDataManager.DecryptString(panelForms.SelectedItem.Value)));
			WebClassLibrary.JWebManager.LoadControl(SUID
					, "~/WebControllers/FormManager/JFormObjectControl.ascx"
					, "فرم"
					, null
					, WebClassLibrary.WindowTarget.NewWindow
					, true, false, true, 600, 350);
		}

		protected void panelForms_Load(object sender, EventArgs e)
		{
		}

		protected void btnAddFormObject_Click(object sender, EventArgs e)
		{
            ClassName=Request["ClassName"];
			int valueObjectCode = 0;
            //if (panelFormObjects.SelectedItem != null)
            //    valueObjectCode = Convert.ToInt32(WebClassLibrary.JDataManager.DecryptString(panelFormObjects.SelectedItem.Value));
			//JFormManager.ShowForm(ObjectCode, Convert.ToInt32(WebClassLibrary.JDataManager.DecryptString(panelForms.SelectedItem.Value)), 0);
			//JFormManager.ShowForm(Convert.ToInt32(WebClassLibrary.JDataManager.DecryptString(panelForms.SelectedItem.Value)), ObjectCode, valueObjectCode, 0);
            JFormManager.ShowForm(FormCode, ObjectCode, valueObjectCode, 0, ClassName);
		}

        protected void btnEditFormObject_Click(object sender, EventArgs e)
        {
            ClassName = Request["ClassName"];
            int valueObjectCode = 0;
            if (gridView.SelectedIndexes.Count > 0)
                valueObjectCode = Convert.ToInt32(gridView.SelectedItems[0].Cells[3].Text);
            else
                return;
                //valueObjectCode = Convert.ToInt32(WebClassLibrary.JDataManager.DecryptString(gridView.DataSource));
            JFormManager.ShowForm(FormCode, ObjectCode, valueObjectCode, 0, ClassName);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedItems == null || gridView.SelectedItems.Count < 1)
            {
                JWebManager.ShowMessage("رکوردی برای ویرایش انتخاب نشده است");
                return;
            }
            string formCode = (gridView.SelectedItems[0] as GridDataItem)["Code"].Text;
            string formName = (gridView.SelectedItems[0] as GridDataItem)["FormName"].Text;
            string sqlQuery = (gridView.SelectedItems[0] as GridDataItem)["Sql"].Text;
            WebClassLibrary.JSUIDManager jSUIDManager = new WebClassLibrary.JSUIDManager("Forms");
            jSUIDManager.SetObject("JWebFormsTemporaryURL", Request.Url.AbsoluteUri);
            jSUIDManager.SetObject("ClassName", ClassName);
            jSUIDManager.SetObject("ObjectCode", formCode);
            jSUIDManager.SetObject("FormName", formName);
            jSUIDManager.SetObject("SqlQuery", sqlQuery);
            WebClassLibrary.JWebManager.LoadControl(SUID
                    , "~/WebControllers/FormManager/JFormDefineControl.ascx"
                    , "ویرایش فرم"
                    , null
                    , WebClassLibrary.WindowTarget.CurrentWindow
                    , true, true, true, 600, 400);
        }
    }
}