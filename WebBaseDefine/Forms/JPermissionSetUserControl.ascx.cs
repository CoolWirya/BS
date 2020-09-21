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
	public partial class JPermissionSetUserControl : System.Web.UI.UserControl
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
            if (UserPostCode == 0)
                WebClassLibrary.JWebManager.RunClientScript("alert('این کاربر در چارت سازمانی تعریف نشده است'); CloseDialog(null);", "ConfirmDialog");
		}

		void setForm()
		{
			GroupDropDownList.DataSource = JApplication.JApplicationType.GetData();
			GroupDropDownList.DataValueField = "value";
			GroupDropDownList.DataTextField = "FarsiName";
			GroupDropDownList.DataBind();
			GroupDropDownList.SelectedValue = JApplication.JApplicationType.Automation.ToString();
			GroupDropDownList_SelectedIndexChanged(null, null);

			//JPermissionsDefineClass Per = new JPermissionsDefineClass();
			//Per.GetData();
			//DefineClassListBox.Items.AddRange((from x in Per.Items select new ListItem(x.ToString(), x.Code.ToString())).ToArray());

			JUser User = new JUser(Code);
			UserPostCode = User.default_post_code;
			UsernameLabel.Text = User.username;

			Employment.JEOrganizationChart chart = new Employment.JEOrganizationChart();
			PostDropDownList.DataTextField = "Job";
			PostDropDownList.DataValueField = "Code";
			PostDropDownList.DataSource = chart.GetUserPostsByUser_code(Code);
			PostDropDownList.DataBind();
			if (PostDropDownList.Items.Count <= 0)
				return;
			PostDropDownList.SelectedIndex = 0;
			PostDropDownList_SelectedIndexChanged1(null, null);
		}

		private void GetDecision()
		{
			if (DefineClassListBox.SelectedItem != null)
			{
				DecissionsListBox.Items.Clear();
				DataTable DT = JPermissionDecisions.GetDataTable(int.Parse(DefineClassListBox.SelectedValue));
				if (DT.Rows.Count > 0)
					foreach (DataRow DR in DT.Rows)
					{
						JPermissionDecision PD = new JPermissionDecision();
						JTable.SetToClassProperty(PD, DR);
						DecissionsListBox.Items.Add(new ListItem(PD.ToString(), PD.Code.ToString()));
					}
			}
		}

		protected void GroupDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			DefineClassListBox.Items.Clear();
			JPermissionsDefineClass Per = new JPermissionsDefineClass();
			Per.GetData(int.Parse(GroupDropDownList.SelectedValue), 0);
			DefineClassListBox.Items.AddRange((from x in Per.Items select new ListItem(x.ToString(), x.Code.ToString())).ToArray());
		}

		protected void DefineClassListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				DecissionsListBox.Items.Clear();
				ObjectListBox.Items.Clear();
				ObjectCode = 0;
				JPermissionDefineClass PerDefine = new JPermissionDefineClass(int.Parse(DefineClassListBox.SelectedItem.Value));
                // Replace some keyword with actual value.
                PerDefine.SQL = PerDefine.SQL.Replace("@UserCode", WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode.ToString());
                if (PerDefine != null)
				{
					if (PerDefine.SQL.Length < 1)
						GetDecision();
					else
                    {
                        IDictionary<string, object> Objs = PerDefine.GetObjectList();
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
			if (DefineClassListBox.SelectedItem != null && DecissionsListBox.SelectedItem != null)
			{
				JPermissionDefineClass PDC = new JPermissionDefineClass(int.Parse(DefineClassListBox.SelectedItem.Value));
				foreach (int index in DecissionsListBox.GetSelectedIndices())
				{
					JPermissionDecision PD = new JPermissionDecision(int.Parse(DecissionsListBox.Items[index].Value));

					KeyValuePair<string, object>[] Objs;
					if (ObjectListBox.GetSelectedIndices().Length > 0)
						Objs = new KeyValuePair<string, object>[ObjectListBox.GetSelectedIndices().Length];
					else
						Objs = new KeyValuePair<string, object>[1] { new KeyValuePair<string, object>("", 0) };
					if (ObjectListBox.Enabled)
					{
						int count = 0;
						foreach (int k in ObjectListBox.GetSelectedIndices())
							Objs[count++] = new KeyValuePair<string, object>(ObjectListBox.Items[k].Text, ObjectListBox.Items[k].Value);
					}
					JPermissionUser PU = new JPermissionUser();
					PU.User_Post_Code = UserPostCode;
					foreach (KeyValuePair<string, object> Obj in Objs)
					{
						if (Obj.Key != "")
							PU.ObjectCode = Convert.ToInt32(Obj.Value);
						PU.DecisionCode = PD.Code;
						PU.HasPermission = true;
						if (PU.Check())
						{
							int pCode = PU.Insert();
							if (pCode > 0)
							{
								PermissionUserListBox.Items.Add(new ListItem(PU.ToString(), PU.Code.ToString()));
							}
						}
					}
				}
			}
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < PermissionUserListBox.GetSelectedIndices().Length; i++)
			{
				JPermissionUser PU = new JPermissionUser(int.Parse(PermissionUserListBox.Items[PermissionUserListBox.GetSelectedIndices()[i]].Value));
				if (PU != null)
					if (PU.delete())
					{
						PermissionUserListBox.Items.RemoveAt(PermissionUserListBox.GetSelectedIndices()[i]);
						i--;
					}
			}
		}

		protected void PostDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
		{
			int jobCode = 0;
			if (int.TryParse(PostDropDownList.SelectedValue, out jobCode))
			{
                UserPostCode = jobCode;
				JPermissionsUser PerUser = new JPermissionsUser(jobCode);
				PerUser.GetData();
				PermissionUserListBox.Items.Clear();
				PermissionUserListBox.Items.AddRange((from x in PerUser.Items select new ListItem(x.ToString(), x.Code.ToString())).ToArray());
			}
		}

		protected void ObjectListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
           
            if (ObjectListBox.GetSelectedIndices().Length == 1)
				if (ObjectListBox.SelectedItem != null)
				{
					ObjectCode = Int32.Parse(ObjectListBox.SelectedValue);
					GetDecision();
				}
              
        }
	}
}