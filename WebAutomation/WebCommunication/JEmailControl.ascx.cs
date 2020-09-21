using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using ClassLibrary.EMail;

namespace WebAutomation.WebCommunication
{
	public partial class JEmailControl : System.Web.UI.UserControl
	{
		protected global::WebAutomation.Refer.JReferViewControl JReferViewControl;
		protected global::WebControllers.ArchiveDocument.JArchiveControl JArchiveControl;
		public const string _ConstClassName = "ClassLibrary.EMail.JEMailSend";
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
		int referCode;
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
		int parentCode;
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
		private void _SetForm()
		{
			SendersDropDownList.DataTextField = "Name";
			SendersDropDownList.DataValueField = "Code";
			SendersDropDownList.DataSource = JEMails.GetDataTable(JMainFrame.CurrentUserCode);
			SendersDropDownList.DataBind();
			if (ParentCode > 0)
			{
				JEMailReceived jEMailReceived = new JEMailReceived(ParentCode);
				//EmailReceivers.Items.Add(jEMailReceived.MessageFrom);

				//EmailReceivers.Items.Add(new Telerik.Web.UI.RadListBoxItem(jEMailReceived.MessageFrom));
				SubjectTextBox.Text = "پاسخ: " + jEMailReceived.Subject;
				EmailTextEditor.Text = "\r\n\r\n-- " + "از: " + jEMailReceived.MessageFrom + "\r\n-- "
					+ "به: " + jEMailReceived.MessageTo + "\r\n-- " + "موضوع: " + jEMailReceived.Subject
					+ "\r\n-- " + "تاریخ: " + JDateTime.FarsiDate(jEMailReceived.DateSent) + " " + jEMailReceived.DateSent.Hour.ToString("00") + ":" + jEMailReceived.DateSent.Minute.ToString("00") + ":" + jEMailReceived.DateSent.Second.ToString("00")
					+ "\r\n-- " + jEMailReceived.Text.Replace("\r\n", "\r\n-- ");
			}

			if (Code > 0)
			{
				JEMailSend jEMailSend = new JEMailSend(Code);
				EmailTextEditor.Text = jEMailSend.Text;
				SubjectTextBox.Text = jEMailSend.Subject;
				SendersDropDownList.SelectedIndex = SendersDropDownList.Items.IndexOf(new ListItem(jEMailSend.MessageFrom));
				//EmailReceivers.Items.AddRange((from x in jEMailSend.MessageTo.Split(';').ToList() select new ListItem(x)).ToArray());

				//string[] rcvsArr = jEMailSend.MessageTo.Split(';');
				//for (int i = 0; i < rcvsArr.Length; i++)
				//	EmailReceivers.Items.Add(new Telerik.Web.UI.RadListBoxItem(rcvsArr[i]));
				JArchiveControl.DataBaseClassName = "Email";
				JArchiveControl.DataBaseObjectCode = 0;
				JArchiveControl.ClassName = _ConstClassName;
				JArchiveControl.ObjectCode = Code;
				JArchiveControl.LoadArchive();

				if (ReferCode > 0)
				{
					JReferViewControl.LoadRefers(ReferCode);

					Automation.JARefer jaRefer = new Automation.JARefer(ReferCode);
					if (jaRefer.receiver_post_code != JMainFrame.CurrentPostCode
						|| jaRefer.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
					{
						_ChangeFormView("NoChangeNoRefer");
					}

				}

				_SetStatus(jEMailSend);
			}
		}

		private void _ChangeFormView(string State)
		{
			if (State.ToLower() == "nochange")
			{
				OkButton.Enabled = false;
				ListButton.Enabled = false;
				OtherButton.Enabled = false;
				DeleteButton.Enabled = false;
				EmailTextEditor.Enabled = false;
			}
			else if (State.ToLower() == "nochangenorefer")
			{
				OkButton.Enabled = false;
				EmailTextEditor.Enabled = false;
				ReferButton.Enabled = false;
			}

		}

		private void _SetStatus(JEMailSend jEMailSend)
		{
			if (jEMailSend.Status == Convert.ToInt32(ClassLibrary.Domains.JClassLibrary.JEMailStatus.Sent))
			{
				StatusLabel.Text = "ایمیل در تاریخ " + JDateTime.FarsiDate(jEMailSend.DateSent) + " " + jEMailSend.DateSent.Hour.ToString("00") + ":" + jEMailSend.DateSent.Minute.ToString("00") + ":" + jEMailSend.DateSent.Second.ToString("00")
					+ " توسط " + jEMailSend.Sender_Full_Title + " ارسال شده است.";
				_ChangeFormView("NoChange");
			}
			else if (jEMailSend.Status == Convert.ToInt32(ClassLibrary.Domains.JClassLibrary.JEMailStatus.Draft))
			{
				StatusLabel.Text = "پیش نویس";
			}
			else if (jEMailSend.Status == Convert.ToInt32(ClassLibrary.Domains.JClassLibrary.JEMailStatus.ReadyForSend))
			{
				StatusLabel.Text = "در حال ارسال...";
				_ChangeFormView("NoChange");
			}
			else if (jEMailSend.Status == Convert.ToInt32(ClassLibrary.Domains.JClassLibrary.JEMailStatus.SendError))
			{
				StatusLabel.Text = "ارسال ایمیل با خطا مواجه شد.";
				_ChangeFormView("NoChange");
			}
			else
			{
				StatusLabel.Text = "نامشخص";
			}
		}
		private void BindDummyRow()
		{
			DataTable dummy = new DataTable();
			dummy.Columns.Add("Email");
			dummy.Rows.Add();
			EmailReceivers.DataSource = dummy;
			EmailReceivers.DataBind();
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
				return;
			BindDummyRow();
			_SetForm();
			if (!int.TryParse(Request["Code"], out code))
				return;
			EmailCodeHiddenField.Value = Request["Code"];
			Code = code;

			if (!int.TryParse(Request["ParentCode"], out parentCode))
				return;
			ParentCodeHiddenField.Value = Request["ParentCode"];
			ParentCode = parentCode;

			if (!int.TryParse(Request["ReferCode"], out referCode))
				return;
			ReferCode = referCode;
		}
		private void Refer()
		{
			JEMailSend jEMailSend = new JEMailSend(Code);

			if (jEMailSend.EmailCode == 0)
			{
				JMessages.Error("لطفا یک ایمیل به عنوان فرستنده انتخاب کنید.", "ارجاع");
				return;
			}

			DataTable _DT = JEMailSends.GetCustomeDataTable("Code=" + Code);

			WebControllers.Automation.JAutomationRefer.ShowRefer(
			   _ConstClassName, 0, Code
						  , _DT
						  , ReferCode, "ایمیل ارسالی");
		}
		protected void ReferButton_Click(object sender, EventArgs e)
		{
			Refer();
		}

		protected void OkButton_Click(object sender, EventArgs e)
		{
			JArchiveControl.DataBaseClassName = "Email";
			JArchiveControl.DataBaseObjectCode = 0;
			JArchiveControl.ClassName = _ConstClassName;
			JArchiveControl.ObjectCode = int.Parse(EmailCodeHiddenField.Value);
			JArchiveControl.SaveToArchive();
		}
	}
}