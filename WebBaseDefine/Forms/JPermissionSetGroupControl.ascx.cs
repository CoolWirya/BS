using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using ClassLibrary.Domains;
using Globals;

namespace WebBaseDefine.Forms
{
	public partial class JPermissionSetGroupControl : System.Web.UI.UserControl
	{
		int code;
		int Code
		{
			get
			{
				if (ViewState["Code"] == null)
					return -1;
				return (int)ViewState["Code"];
			}
			set
			{
				ViewState["Code"] = value;
			}
		}

		int ParentCode
		{
			get
			{
				if (ViewState["ParentCode"] == null)
					return -1;
				return (int)ViewState["ParentCode"];
			}
			set
			{
				ViewState["ParentCode"] = value;
			}
		}

		int UserPostCode
		{
			get
			{
				if (ViewState["UserPostCode"] == null)
					return -1;
				return (int)ViewState["UserPostCode"];
			}
			set
			{
				ViewState["UserPostCode"] = value;
			}
		}

		int ObjectCode
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

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
				return;
			if (!int.TryParse(Request["Code"], out code))
				return;
			Code = code;
			setForm();
		}

		void setForm()
		{
			//JPermissionDecisionGroups Per = new JPermissionDecisionGroups();
			//Per.GetData(Code);
			////DefineGroupListBox.Items.AddRange((from x in Per.Items select new ListItem(x.ToString(), x.Code.ToString())).ToArray());
			//DecissionsListBox.Items.AddRange((from x in Per.Items select new ListItem(x.ToString(), x.Code.ToString())).ToArray());


			GroupDropDownList.DataSource = JApplication.JApplicationType.GetData();
			GroupDropDownList.DataValueField = "value";
			GroupDropDownList.DataTextField = "FarsiName";
			GroupDropDownList.DataBind();
			GroupDropDownList.SelectedIndex = 0;// JApplication.JApplicationType.Automation.ToString();
			DecissionsListBox.Items.Clear();
			ObjectListBox.Items.Clear();
			ObjectCode = 0;
			JPermissionDefineGroup group = new JPermissionDefineGroup(Code);
			GroupLabel.Text = group.GroupName;
			JPermissionsGroup pg = new JPermissionsGroup(Code);
			pg.GetData();
			PermissionGroupListBox.Items.AddRange((from x in pg.Items select new ListItem(x.ToString(), x.Code.ToString())).ToArray());
			//JPermissionDefineGroupClass pgdc = new JPermissionDefineGroupClass();
			//if (group != null)
			//{
			//ParentCode = group.ParentCode;

			//if (group.SQL.Length < 1)
			//	GetDecision();
			//else
			//{
			//	IDictionary<string, object> Objs = group.GetObjectList();
			//	foreach (KeyValuePair<string, object> Obj in Objs)
			//		ObjectListBox.Items.Add(new ListItem(Obj.Value.ToString(), Obj.Key));
			//}

			//}
		}

		private void GetDecision()
		{
			if (DefineGroupListBox.SelectedItem != null)
			{
				DecissionsListBox.Items.Clear();
				DataTable DT = JPermissionDecisions.GetDataTable(int.Parse(DefineGroupListBox.SelectedItem.Value));
				if (DT.Rows.Count > 0)
					foreach (DataRow DR in DT.Rows)
					{
						JPermissionDecision PD = new JPermissionDecision();
						JTable.SetToClassProperty(PD, DR);
						DecissionsListBox.Items.Add(new ListItem(PD.ToString(), PD.Code.ToString()));
					}
			}
		}

		protected void DefineGroupListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				DecissionsListBox.Items.Clear();
				ObjectListBox.Items.Clear();
				ObjectCode = 0;
				JPermissionDefineClass pdc = new JPermissionDefineClass(int.Parse(DefineGroupListBox.SelectedItem.Value));
				if (pdc != null)
				{
					if (pdc.SQL.Length < 1)
						GetDecision();
					else
					{
						IDictionary<string, object> Objs = pdc.GetObjectList();
						foreach (KeyValuePair<string, object> Obj in Objs)
							ObjectListBox.Items.Add(new ListItem(Obj.Value.ToString(), Obj.Key));
					}
				}
			}
			catch (Exception ex)
			{
				//Except.AddException(ex);
			}
		}

		protected void SelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < ObjectListBox.Items.Count; i++)
				ObjectListBox.Items[i].Selected = SelectAllCheckBox.Checked;
		}

		protected void NoneCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < ObjectListBox.Items.Count; i++)
				ObjectListBox.Items[i].Selected = false;
			if (NoneCheckBox.Checked)
			{
				ObjectCode = 0;
				GetDecision();
			}
			ObjectListBox.Enabled = NoneCheckBox.Checked;
		}

		protected void InsertButton_Click(object sender, EventArgs e)
		{
			if (DecissionsListBox.SelectedItem != null)
			{
				JPermissionDefineClass PDC = new JPermissionDefineClass(int.Parse(DefineGroupListBox.SelectedItem.Value));
				foreach (int index in DecissionsListBox.GetSelectedIndices())
				{
					JPermissionDecision PD = new JPermissionDecision(int.Parse(DecissionsListBox.Items[index].Value));

					KeyValuePair<string, object>[] Objs;
					if (ObjectListBox.GetSelectedIndices().Length > 0)
						Objs = new KeyValuePair<string, object>[ObjectListBox.GetSelectedIndices().Length];
					else
						Objs = new KeyValuePair<string, object>[1] { new KeyValuePair<string, object>("", "0") };
					if (ObjectListBox.Enabled)
					{
						int count = 0;
						foreach (int k in ObjectListBox.GetSelectedIndices())
							Objs[count++] = new KeyValuePair<string, object>(ObjectListBox.Items[k].Text, ObjectListBox.Items[k].Value);
					}
					JPermissionGroup PU = new JPermissionGroup();
					PU.GroupCode = Code;
					foreach (KeyValuePair<string, object> Obj in Objs)
					{
						if (Obj.Key != "")
							PU.ObjectCode = int.Parse(Obj.Value.ToString());
						PU.DecisionCode = PD.Code;
						PU.HasPermission = true;
						if (PU.Check())
						{
							int pCode = PU.Insert();
							if (pCode > 0)
								PermissionGroupListBox.Items.Add(new ListItem(PU.ToString(), PU.Code.ToString()));
						}
					}
				}
			}
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < PermissionGroupListBox.GetSelectedIndices().Length; i++)
			{
				JPermissionGroup PU = new JPermissionGroup(int.Parse(PermissionGroupListBox.Items[PermissionGroupListBox.GetSelectedIndices()[i]].Value));
				if (PU != null)
					if (PU.delete())
					{
						PermissionGroupListBox.Items.RemoveAt(PermissionGroupListBox.GetSelectedIndices()[i]);
						i--;
					}
			}
		}

		//protected void PostDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
		//{
		//	int jobCode = 0;
		//	if (int.TryParse(PostDropDownList.SelectedValue, out jobCode))
		//	{
		//		UserPostCode = code;
		//		JPermissionsGroup PerUser = new JPermissionsGroup(UserPostCode);
		//		PerUser.GetData();
		//		PermissionUserListBox.Items.AddRange((from x in PerUser.Items select new ListItem(x.ToString(), x.Code.ToString())).ToArray());
		//	}
		//}

		protected void ObjectListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ObjectListBox.GetSelectedIndices().Length == 1)
				if (ObjectListBox.SelectedItem != null)
				{
					ObjectCode = Int32.Parse(ObjectListBox.SelectedValue);
					GetDecision();
				}
		}

		protected void GroupDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			DefineGroupListBox.Items.Clear();
			JPermissionsDefineClass Per = new JPermissionsDefineClass();
			Per.GetData(int.Parse(GroupDropDownList.SelectedValue), 0);
			DefineGroupListBox.Items.AddRange((from x in Per.Items select new ListItem(x.ToString(), x.Code.ToString())).ToArray());
			//if (DefineGroupListBox.Items.Count > 0)
			//	DefineGroupListBox.SelectedIndex = 0;
		}
	}
}