using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using ClassLibrary.Domains;
using ClassLibrary.Permission;

namespace WebBaseDefine.Forms
{
	public partial class JLoadDLLControl : System.Web.UI.UserControl
	{
		void SetForm()
		{
			GroupDropDownList.DataSource = JApplication.JApplicationType.GetData();
			GroupDropDownList.DataValueField = "value";
			GroupDropDownList.DataTextField = "FarsiName";
			GroupDropDownList.DataBind();
			GroupDropDownList.SelectedValue = JApplication.JApplicationType.Automation.ToString();
			PermissionListBox.DataSource = JPermissionDefineControls.GetData();
			PermissionListBox.DataTextField = "PermissionName";
			PermissionListBox.DataValueField = "PermissionName";
			PermissionListBox.DataBind();
			MakeDecisionTree();
		}

		private string GetParents(TreeNode pNode)
		{
			if (pNode.Parent == null)
				return pNode.Text;
			else
				return GetParents(pNode.Parent) + "." + pNode.Text;
		}

		private void LoadSavedDecision()
		{
			ListBox1.Items.Clear();
			int[] decisions = JPermissionControl.GetDecisions(FunctionNameTextBox.Text);
			foreach (int dec in decisions)
			{
				JPermissionDecision decision = new JPermissionDecision();
				decision.GetData(dec);

				foreach (TreeNode tn in ClassTreeView.Nodes)
				{
					if (decision.ClassName.ToString() == (new JPermissionDefineClass(int.Parse(tn.Value)).ClassName))
					{
						for (int i = 0; i < tn.ChildNodes.Count; i++)
						{
							if (decision.Name == tn.ChildNodes[i].Text)
								tn.ChildNodes[i].Select();
						}
					}
				}

				ListItem item = new ListItem(decision.ClassName + "." + decision.Name);
				item.Value = decision.Code.ToString();
				ListBox1.Items.Add(item);
			}
		}

		void MakeDecisionTree()
		{
			ClassTreeView.Nodes.Clear();
			JPermissionsDefineClass classList = new JPermissionsDefineClass();
			classList.GetData(Convert.ToInt32(GroupDropDownList.SelectedValue), 0);
			int i = 0;
			foreach (JPermissionDefineClass ds in classList.Items)
			{
				/// افزودن کلاس به درخت
				TreeNode classNode = new TreeNode(ds.ClassName);
				classNode.Value = ds.Code.ToString();
				if (ds.SQL.Trim() != "")
					classNode.ToolTip = ds.SQL;
				ClassTreeView.Nodes.Add(classNode);
				JPermissionDecisions decisions = new JPermissionDecisions();
				decisions.GetData(ds.Code);
				foreach (JPermissionDecision decision in decisions.Items)
				{
					TreeNode decisionNode = new TreeNode(decision.Name);
					decisionNode.Value = decision.Code.ToString();
					/// افزودن هر کدام از تصمیمات به نود کلاس
					ClassTreeView.Nodes[i].ChildNodes.Add(decisionNode);
				}
				i++;
			}
			ClassTreeView.CollapseAll();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
				return;
			SetForm();
		}

		protected void GroupDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			MakeDecisionTree();
		}

		protected void PermissionListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			FunctionNameTextBox.Text = PermissionListBox.SelectedItem.Text;
			LoadSavedDecision();
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			int selectedNodeValue = 0;
			int.TryParse(SelectedClassHiddenField.Value, out selectedNodeValue);
			if ((ClassTreeView.SelectedNode == null && selectedNodeValue <= 0) || PermissionListBox.SelectedValue == null)
				return;
			JPermissionDecision pd = new JPermissionDecision(selectedNodeValue);
			if (pd == null)
				return;
			if (FunctionNameTextBox.Text == "")
				return;
			JPermissionControl control = new JPermissionControl();
			control.Class_Name = FunctionNameTextBox.Text;
			control.Class_Code = pd.PermissionDefineCode;
			control.Decision_Code = pd.Code;
			if (control.Insert() > 0)
			{
				ListItem item = new ListItem(pd.ClassName + "." + pd.Name);
				item.Value = pd.Code.ToString();
				ListBox1.Items.Add(item);
			}
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			JPermissionControl control = new JPermissionControl();
			int decisionCode = 0;
			int.TryParse(ListBox1.SelectedItem.Value, out decisionCode);
			if (decisionCode <= 0)
				return;
			if (control.Delete(FunctionNameTextBox.Text, decisionCode))
				ListBox1.Items.Remove(ListBox1.SelectedItem);
		}

		protected void ClassTreeView_SelectedNodeChanged(object sender, EventArgs e)
		{
			//try
			//{
			//	if (ClassTreeView.SelectedNode == null || PermissionListBox.SelectedValue == null)
			//		return;
			//	JPermissionDecision pd = new JPermissionDecision(int.Parse(ClassTreeView.SelectedNode.Value));
			//	if (pd == null)
			//		return;
			//	JPermissionControl control = new JPermissionControl();
			//	control.Class_Name = FunctionNameTextBox.Text;
			//	control.Class_Code = pd.PermissionDefineCode;
			//	control.Decision_Code = pd.Code;
			//	foreach (DataRow dr in control.FindClassName().Rows)
			//	{
			//		TreeView t = new TreeView();
			//		string[] str = dr["Class_Name"].ToString().Split('.');
			//		for (int i = 0; i < str.Length; i++)
			//			PermissionListBox.SelectedValue = str[i];
			//	}
			//}
			//catch (Exception ex)
			//{
			//}
			SelectedClassHiddenField.Value = ClassTreeView.SelectedNode.Value;
		}
	}
}