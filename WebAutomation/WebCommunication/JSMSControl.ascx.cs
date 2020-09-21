using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using ClassLibrary.SMS;

namespace WebAutomation.WebCommunication
{
	public partial class JSMSControl : System.Web.UI.UserControl
	{
		protected global::WebAutomation.Refer.JReferViewControl JReferViewControl;
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
				if (value > 0)
					ViewState["ReferCode"] = (new Automation.JARefer()).FindRefer(JCommunication._ConstClassName, Code, 0);
			}
		}
		int ReferCode
		{
			get
			{
				if (ViewState["ReferCode"] == null)
					return -1;
				return (int)ViewState["ReferCode"];
			}
			set
			{
				ViewState["ReferCode"] = value;
			}
		}
		private void fillGroupGrid()
		{
			DataTable DT = JSMSGroupDefines.GetDataTable(true);
			DT.Columns.Remove("UserCode");
			DT.Columns.Remove("SQL");
			GroupGridView.DataSource = DT;
			GroupGridView.DataBind();
		}

		private void CalculateSMSes(int len)
		{
			CharCountLabel.Text = len.ToString();
			if (len <= 70)
				SMSCountLabel.Text = "1";
			else
				SMSCountLabel.Text = Math.Ceiling(Convert.ToDouble(len) / 67).ToString();
			ReceiversSMSCountLabel.Text = (int.Parse(SMSCountLabel.Text) * ReceiversGridView.Rows.Count).ToString();
			PreSpaceLabel.Text = SpacesBefore(SMSTextTextBox.Text).ToString();
			PostSpaceLabel.Text = SpacesAfter(SMSTextTextBox.Text).ToString();
		}

		private int SpacesBefore(string text)
		{
			int i = 0;
			for (; i < text.Length; i++)
				if (text[i] != ' ') break;
			return i;
		}
		private int SpacesAfter(string text)
		{
			int i = text.Length - 1;
			for (; i >= 0; i--)
				if (text[i] != ' ') break;
			return text.Length - i - 1;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
				return;
			fillGroupGrid();
			BindDummyRow();
			if (!int.TryParse(Request["Code"], out code))
				return;
			SMSCodeHiddenField.Value = Request["Code"];
			Code = code;
			#region Set Form
			JSMSes jSMSes = new JSMSes(code);
			SMSTextTextBox.Text = jSMSes.SMS_Text;
			ReceiversGridView.DataSource = jSMSes.SMSDetailsForView;
			ReceiversGridView.DataBind();
			CalculateSMSes(jSMSes.SMS_Text.Length);
			#endregion
		}

		protected void rtabLetter_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
		{
			switch (e.Tab.PageViewID)
			{
				case "rpvRefer":
					if (ReferCode > 0 && Code == 0)
					{
						Automation.JARefer Jref = new Automation.JARefer(ReferCode);
						Code = new Automation.JAObject(Jref.object_code).ObjectCode;
					}
					if (ReferCode <= 0)
						ReferButton.Enabled = true;
					else
						ReferButton.Enabled = false;
					JReferViewControl.LoadRefers(new Automation.JARefer(ReferCode).object_code);
					break;
			}
		}

		private void BindDummyRow()
		{
			DataTable dummy = new DataTable();
			dummy.Columns.Add("Code");
			dummy.Columns.Add("PersonCode");
			dummy.Columns.Add("PersonName");
			dummy.Columns.Add("Mobile");
			dummy.Columns.Add("Status");
			dummy.Rows.Add();
			ReceiversGridView.DataSource = dummy;
			ReceiversGridView.DataBind();
		}

		private void Refer()
		{
			JSMSes jSMSes = new JSMSes(Code);

			DataTable _DT = jSMSes.GetDataTable(Code);

			string Mobiles = "";
			foreach (DataRow item in jSMSes.SMSDetailsForView.Rows)
				Mobiles += item["Mobile"].ToString().Trim() + ",";
			if (Mobiles.Length > 3)
				Mobiles = Mobiles.Substring(0, Mobiles.Length - 1);
			_DT.Columns.Add("TotalSMSParts");
			_DT.Columns.Add("TotalRecievers");
			_DT.Columns.Add("TotalSMS");
			_DT.Columns.Add("TotalSMS_Day");
			_DT.Columns.Add("TotalSMS_Month");
			_DT.Columns.Add("Mobiles");
			_DT.Columns.Add("CurrentPostCode");
			_DT.Columns.Add("isUnit");
			if (_DT.Rows.Count > 0)
			{
				_DT.Rows[0]["TotalSMSParts"] = SMSCountLabel.Text;
				_DT.Rows[0]["TotalRecievers"] = jSMSes.SMSDetailsForView.Rows.Count;
				_DT.Rows[0]["TotalSMS"] = ReceiversSMSCountLabel.Text;
				_DT.Rows[0]["Mobiles"] = Mobiles;
				_DT.Rows[0]["CurrentPostCode"] = JMainFrame.CurrentPostCode;
				_DT.Rows[0]["TotalSMS_Day"] = JSMSess.GetTotalSMS_Day(JDateTime.Now().Year, JDateTime.Now().Month, JDateTime.Now().Day, JMainFrame.CurrentPostCode) + ReceiversSMSCountLabel.Text;
				_DT.Rows[0]["TotalSMS_Month"] = JSMSess.GetTotalSMS_Month(JDateTime.Now().Year, JDateTime.Now().Month, JMainFrame.CurrentPostCode) + ReceiversSMSCountLabel.Text;
				_DT.Rows[0]["isUnit"] = (new Employment.JEOrganizationChart(JMainFrame.CurrentPostCode)).is_unit;
			}
			WebControllers.Automation.JAutomationRefer.ShowRefer(
			   JAutomation._ConstClassName, 0, Code
						  , _DT
						  , ReferCode, "پیام کوتاه ارسالی");
			//ReferCode=(new Automation.JARefer()).FindRefer(JCommunication._ConstClassName, Code, 0)
		}

		protected void ReferButton_Click(object sender, EventArgs e)
		{
			Refer();
			//ReferButton.Enabled = false;
		}
	}
}