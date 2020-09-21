using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using Telerik.Web.UI;
using WebControllers.MainControls.Date;

namespace WebBaseDefine.Forms
{
	public partial class JSuccessorUpdateControl : System.Web.UI.UserControl
	{
		public int userPostCode
		{
			get
			{
				if (String.IsNullOrWhiteSpace(UserPostCodeHiddenField.Value))
					return 0;
				return int.Parse(UserPostCodeHiddenField.Value);
			}
			set
			{
				UserPostCodeHiddenField.Value = value.ToString();
			}
		}

		private void fillPermissions()
		{
			PermissionsCheckBoxList.Items.Clear();
			JPermissionsUser PerUser = new JPermissionsUser(JMainFrame.CurrentPostCode);//
			PerUser.GetData();
			for (int i = 0; i < PerUser.Items.Count(); i++)
				PermissionsCheckBoxList.Items.Add(new ListItem(PerUser.Items[i].ToString(), PerUser.Items[i].Code.ToString()));
			PermissionsCheckBoxList.DataBind();
		}

		private void fillGrid()
		{
			SuccessorsGridView.DataSource = JSuccessor.GetDataTableSuccessor();
			SuccessorsGridView.DataBind();
			SuccessorsGridView.Columns[3].Visible = false;
			SuccessorsGridView.Columns[4].Visible = false;
			SuccessorsGridView.Columns[5].Visible = false;
			SuccessorsGridView.Columns[6].Visible = false;
		}

		private void fillReferComboBox()
		{
			ReferInternalComboBox.DataTextField = "Full_title";
			ReferInternalComboBox.DataValueField = "Code";
			ReferInternalComboBox.DataSource = Employment.JEOrganizationChart.GetAllData();
			ReferInternalComboBox.DataBind();
		}

		private void removeExtraQueryStrings()
		{
			isreadonly.SetValue(Request.QueryString, false, null);
			Request.QueryString.Remove("evt");
			Request.QueryString.Remove("evt_idx");
			//Request.QueryString.Remove("Code2");
			isreadonly.SetValue(Request.QueryString, true, null);
		}
		PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
		protected void Page_Load(object sender, EventArgs e)
		{
			(FromDateJDateControl as JDateControl).SetDate(DateTime.Now);
			(ToDateJDateControl as JDateControl).SetDate(DateTime.Now);
			fillReferComboBox();
			fillPermissions();
			fillGrid();
			if (Request.QueryString != null && Request.QueryString["evt"] == "SuccessorsGridView_SelectedIndexChanged")
				SuccessorsGridView_SelectedIndexChanged1(int.Parse(Request.QueryString["evt_idx"]));
			removeExtraQueryStrings();
		}

		private void SuccessorsGridView_SelectedIndexChanged1(int index)
		{
			if (index >= SuccessorsGridView.Rows.Count)
				return;
			GridViewRow dataItem = SuccessorsGridView.Rows[index];
			userPostCode = Convert.ToInt32(dataItem.Cells[4].Text);
			//(FromDateJDateControl as JDateControl).SetFarsiDate(dataItem.Cells[1].Text);
			//(ToDateJDateControl as JDateControl).SetFarsiDate(dataItem.Cells[2].Text);
			StatusCheckBox.Checked = dataItem.Cells[6].Text.Trim().ToLower() == "true";
			JSuccessor tmpSuccessor = new JSuccessor(Convert.ToInt32(dataItem.Cells[3].Text));
			isreadonly.SetValue(Request.QueryString, false, null);
			Request.QueryString.Add("Code2", tmpSuccessor.Code.ToString());
			isreadonly.SetValue(Request.QueryString, true, null);
			JPermissionsSuccessor PerUser = new JPermissionsSuccessor(userPostCode);
			DataTable dt = PerUser.GetDataTable();
			foreach (DataRow dr in dt.Rows)
				for (int i = 0; i < PermissionsCheckBoxList.Items.Count; i++)
				{
					DateTime start_dt = Convert.ToDateTime(dr["Start_Date"]);
					DateTime end_dt = Convert.ToDateTime(dr["End_Date"]);
					JPermissionUser user = new JPermissionUser(int.Parse(PermissionsCheckBoxList.Items[i].Value));
					if (dr["ObjectCode"].ToString() == user.ObjectCode.ToString()
						&& (dr["DecisionCode"].ToString() == user.DecisionCode.ToString())
						&& start_dt == tmpSuccessor.Start_date_time && end_dt == tmpSuccessor.End_date_time)
						PermissionsCheckBoxList.Items[i].Selected = true;
				}
			//dataItem.BackColor = System.Drawing.Color.Black;
			//dataItem.ForeColor = System.Drawing.Color.White;
		}

		protected void SuccessorsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType != DataControlRowType.DataRow)
				return;
			e.Row.Attributes.Add("idx", e.Row.RowIndex.ToString());
			//if (Request.QueryString["evt_idx"] == null || e.Row.RowIndex.ToString() != Request.QueryString["evt_idx"])
			//	return;
		}
	}
}