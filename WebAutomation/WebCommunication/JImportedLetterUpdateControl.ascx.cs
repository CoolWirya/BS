using ArchivedDocuments;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebControllers.ArchiveDocument;

namespace WebAutomation.WebCommunication
{
	public partial class JImportedLetterUpdateControl : System.Web.UI.UserControl
	{
		#region Init
		protected global::WebControllers.ArchiveDocument.JArchiveControl JArchiveControl;
		protected global::WebAutomation.Refer.JReferViewControl JReferViewControl;
		//  int int.Parse(hfCode.Value);
		//  int int.Parse(hfReferCode.Value);
		#endregion Init

		#region Events
		///-------------------------------------------------------------------------------------------------------------------------
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				if (!string.IsNullOrEmpty(Request["Code"]))
					hfCode.Value = Request["Code"];
				else
					hfCode.Value = "0";

				if (!string.IsNullOrEmpty(Request["ReferCode"]))
					hfReferCode.Value = Request["ReferCode"];
				else
					hfReferCode.Value = "0";

				if (!string.IsNullOrEmpty(Request["CurrentPage"]))
					hfCurrentPage.Value = Request["CurrentPage"];
				else
					hfCurrentPage.Value = "0";

				_SetForm();

				if (!string.IsNullOrEmpty(Request["Code"]))
				{
					JArchiveControl.ClassName = Communication.JCImportedLetter._ConstClassName;
					JArchiveControl.ObjectCode = int.Parse(Request["Code"]);
					JArchiveControl.LoadArchive();
				}
				if (int.Parse(Request["Code"]) > 0 && int.Parse(Request["ReferCode"]) == 0)
				{
					///به صلاح دید مهندس زرین
					///به علت استفاده از همین کد در نرم افزار ویندوز
					///با اینکه منطق اشتباه است و این متد اولین ارجاع را می آورد
					///Findrefer حذف نشد
					hfReferCode.Value = (new Automation.JARefer()).FindRefer(Communication.JCImportedLetter._ConstClassName, int.Parse(hfCode.Value), 0).ToString();

				}
				if (int.Parse(Request["ReferCode"]) > 0 && int.Parse(Request["Code"]) == 0)
				{
					Automation.JARefer Jref = new Automation.JARefer(int.Parse(hfReferCode.Value));
					hfCode.Value = (new Automation.JAObject(Jref.object_code).ObjectCode).ToString();
				}
				if (Request["CurrentPage"] != "GetOutbox")
					btnReturn.Enabled = false;
				else
					btnReturn.Enabled = true;

				if (int.Parse(Request["ReferCode"]) <= 0 || Request["CurrentPage"] == "GetInbox")
					btnReference.Enabled = true;
				else
                    btnReference.Enabled = false;
                rtabImportedLetter.Tabs.FindTabByValue("Info").Selected = true;
                rpageImportedLetter.FindPageViewByID("rpvLetterInfo").Selected = true;
			}

		}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void btnSave_Click(object sender, EventArgs e)
		{
			if (Save())
				WebClassLibrary.JWebManager.RefreshGrid();
		}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void cmbReciever_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
		{

		}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void btnReference_Click(object sender, EventArgs e)
		{
			//WebControllers.Automation.JAutomationRefer.ShowRefer(Communication.JCLetter._ConstClassName, 0, int.Parse(hfCode.Value), (new Communication.JCLetter(int.Parse(hfCode.Value))).GetData(int.Parse(hfCode.Value)), int.Parse(hfReferCode.Value), "ارجاع نامه داخلی");
			if (Save())
				WebControllers.Automation.JAutomationRefer.ShowRefer(Communication.JCImportedLetter._ConstClassName, 0, int.Parse(hfCode.Value)
					, (new Communication.JCLetter(int.Parse(hfCode.Value))).GetData(int.Parse(hfCode.Value)), int.Parse(hfReferCode.Value), "ارجاع نامه وارده");

			// WebControllers.Automation.JAutomationRefer.ShowRefer(Communication.JExportedLetterForm._ConstClassName, 0, int.Parse(hfCode.Value), (new Communication.JCLetter(int.Parse(hfCode.Value))).GetData(int.Parse(hfCode.Value)), int.Parse(hfReferCode.Value), "ارجاع نامه خارجی");
		}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void btnReturn_Click(object sender, EventArgs e)
		{
			// hfReferCode.Value = (new Automation.JARefer()).FindRefer(hfClassName.Value, int.Parse(hfCode.Value), 0).ToString();

			if (hfReferCode.Value != string.Empty)
			{
				Automation.JARefers.ReturnRefer(int.Parse(hfReferCode.Value));
				WebClassLibrary.JWebManager.CloseAndRefresh();
			}
		}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void btnParent_Click(object sender, EventArgs e)
		{

		}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void rtabExportedLetter_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
		{
			if (int.Parse(hfCode.Value) <= 0)
            {
                rtabImportedLetter.Tabs.FindTabByValue("Info").Selected = true;
                rpageImportedLetter.FindPageViewByID("rpvLetterInfo").Selected = true;
				//WebClassLibrary.JWebManager.ShowMessage("ابتدا نامه را به ثبت رسانید");
				// Save();
			}
			else

				switch (e.Tab.PageViewID)
				{
					case "Info":
						if (hfCurrentPage.Value != "GetOutbox")
							btnReturn.Enabled = false;
						else
							btnReturn.Enabled = true;

						if (int.Parse(hfReferCode.Value) <= 0 || hfCurrentPage.Value == "GetInbox")
							btnReference.Enabled = true;
						else
							btnReference.Enabled = false;
						break;
					case "rpvArchive":
						JArchiveControl.ClassName = Communication.JCImportedLetter._ConstClassName;
						JArchiveControl.ObjectCode = int.Parse(hfCode.Value);
						JArchiveControl.LoadArchive();

						if (hfCurrentPage.Value != "GetOutbox")
							btnReturn.Enabled = false;
						else
							btnReturn.Enabled = true;

						if (int.Parse(hfReferCode.Value) <= 0 || hfCurrentPage.Value == "GetInbox")
							btnReference.Enabled = true;
						else
							btnReference.Enabled = false;
						break;
					case "rpvRefer":
						if (hfCurrentPage.Value != "GetOutbox")
							btnReturn.Enabled = false;
						else
							btnReturn.Enabled = true;

						if (int.Parse(hfReferCode.Value) <= 0 || hfCurrentPage.Value == "GetInbox")
							btnReference.Enabled = true;
						else
							btnReference.Enabled = false;
						JReferViewControl.LoadRefers(new Automation.JARefer(int.Parse(hfReferCode.Value)).object_code);
						break;
					case "Delivery":
						if (hfCurrentPage.Value != "GetOutbox")
							btnReturn.Enabled = false;
						else
							btnReturn.Enabled = true;

						if (int.Parse(hfReferCode.Value) <= 0 || hfCurrentPage.Value == "GetInbox")
							btnReference.Enabled = true;
						else
							btnReference.Enabled = false;
						break;

				}
		}
		///-------------------------------------------------------------------------------------------------------------------------      
		#endregion Events

		#region Method
		///-------------------------------------------------------------------------------------------------------------------------
		public void _SetForm()
		{

			txtYear.Text = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now()).ToString();

			//  ---------------------- Set ComboBox Sender --------------------------
			DataTable _dt = ClassLibrary.Domains.JCommunication.JSendType.GetData();
			_dt = (new Employment.JEOrganizationChart()).GetParents(ClassLibrary.JMainFrame.CurrentPostCode);
			(_dt as ClassLibrary.JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);
			cmbReciever.DataSource = _dt;
			cmbReciever.DataBind();
			ViewState["Reciever_dt"] = _dt;
			//  ---------------------- Set ComboBox Urgency --------------------------
			cmbUrgency.DataSource = ClassLibrary.Domains.JGlobal.JUrgency.GetData();
			cmbUrgency.SelectedValue = ClassLibrary.Domains.JGlobal.JUrgency.Normal.ToString();
			cmbUrgency.DataBind();

			if (int.Parse(hfCode.Value) > 0)
			{
				Communication.JCLetter jcLetter;
				jcLetter = new Communication.JCLetter(int.Parse(hfCode.Value));

				#region Set Control Properties

				txtSubject.Text = jcLetter.subject;
				txtLetterNo.Text = jcLetter.letter_no;
				txtIncoming_no.Text = jcLetter.incoming_no;
				if (cmbReciever.FindItemByValue(jcLetter.receiver_code.ToString()) != null)
					cmbReciever.FindItemByValue(jcLetter.receiver_code.ToString()).Selected = true;
				if (cmbUrgency.FindItemByValue(jcLetter.urgency.ToString()) != null)
					cmbUrgency.FindItemByValue(jcLetter.urgency.ToString()).Selected = true;
				txtSender.Text = jcLetter.sender_full_title;
				if (jcLetter.incoming_date != null)
					((WebControllers.MainControls.Date.JDateControl)incoming_date).SetDate(jcLetter.incoming_date);
				incoming_signature_person.Text = jcLetter.incoming_signature_person;
				LetterState.Value = jcLetter.letter_status.ToString();

				JArchiveDocument jArchiveDocument = new JArchiveDocument();
				jArchiveDocument.GetData(jcLetter.ImageCode);
				List<int> letterAttachments = jArchiveDocument.GetArchivesCodes(Communication.JCImportedLetter._ConstClassName, jcLetter.Code);
				if (letterAttachments == null || letterAttachments.Count == 0)
					return;

				JFile f = jArchiveDocument.RetrieveContent(letterAttachments[0]);
				string ImageString = Convert.ToBase64String(f.Stream.ToArray(), 0, (int)f.Stream.Length);
				LetterImage.ImageUrl = "data:image/jpg;base64," + ImageString;
				#endregion Set Control Properties
			}
		}
		///-------------------------------------------------------------------------------------------------------------------------
		public bool Save()
		{
			try
			{
				Communication.JCLetter jcLetter;
				if (int.Parse(hfCode.Value) == 0)
					jcLetter = new Communication.JCLetter();
				else
					jcLetter = new Communication.JCLetter(int.Parse(hfCode.Value));

				#region CheckValidate

				if (cmbReciever.SelectedValue == null)
				{
					WebClassLibrary.JWebManager.ShowMessage("گیرنده انتخاب نشده است");
					return false;
				}

				if (txtSender.Text.Trim().Length < 3)
				{
					WebClassLibrary.JWebManager.ShowMessage("فرستنده انتخاب نشده است");
					return false;
				}

				if (txtSubject.Text.Trim().Length == 0)
				{
					WebClassLibrary.JWebManager.ShowMessage("موضوع نامه انتخاب نشده است");
					return false;
				}

				#endregion CheckValidate

				jcLetter.letter_type = ClassLibrary.Domains.JCommunication.JLetterType.Import; // نامه وارده
				if (int.Parse(hfCode.Value) == 0)
				{
					if (LetterState.Value != string.Empty)
						jcLetter.letter_status = int.Parse(LetterState.Value);
					else
						jcLetter.letter_status = ClassLibrary.Domains.JCommunication.JLetterStatus.Accept;
					jcLetter.register_date_time = JDateTime.Now();
					jcLetter.register_post_code = JMainFrame.CurrentPostCode;
					jcLetter.register_user_code = JMainFrame.CurrentUserCode;
					jcLetter.register_user_full_title = JMainFrame.CurrentPostTitle;
				}
				jcLetter.subject = txtSubject.Text;
				jcLetter.letter_no = txtLetterNo.Text;
				jcLetter.receiver_post_code = Convert.ToInt32(cmbReciever.SelectedValue);
				jcLetter.receiver_code = (new Employment.JEOrganizationChart(jcLetter.receiver_post_code)).user_code;
				DataTable reciverDt = ((DataTable)(ViewState["Reciever_dt"]));
				reciverDt.DefaultView.RowFilter = "code =" + cmbReciever.SelectedValue;
				jcLetter.receiver_full_title = reciverDt.DefaultView[0]["full_name"].ToString();
				jcLetter.receiver_post_code = 0;
				jcLetter.receiver_code = 0;
				jcLetter.sender_full_title = txtSender.Text;
				jcLetter.urgency = Convert.ToInt32(cmbUrgency.SelectedValue);
				jcLetter.send_type = ClassLibrary.Domains.JCommunication.JSendType.Automation;
				jcLetter.minute_register_date = JDateTime.Now();
				jcLetter.incoming_signature_person = incoming_signature_person.Text;
				jcLetter.incoming_date = ((WebControllers.MainControls.Date.JDateControl)incoming_date).GetDate();

				///این کد دستی پر شد به خاطر خطا در اتوماسیون شرکت
				jcLetter.secretariat_code = 1000001;

				if (int.Parse(hfCode.Value) == 0)
				{
					if (Communication.NoStorage.VerifyStorage(JAutomation._ConstClassName, 0, Convert.ToInt32(txtYear.Text)) == false)
						Communication.NoStorage.CreateNewNoStorage(JAutomation._ConstClassName, 0, Convert.ToInt32(txtYear.Text));
					Communication.NoStorage noStorage = new Communication.NoStorage(JAutomation._ConstClassName, 0, Convert.ToInt32(txtYear.Text));
					txtLetterNo.Text = noStorage.GetNextNumber().ToString();
					jcLetter.letter_no = txtLetterNo.Text;
					hfCode.Value = jcLetter.Insert().ToString();
				}
				else
				{
					jcLetter.Update();
				}
				WebClassLibrary.JWebManager.ShowMessage("ذخیره با موفقیت انجام شد");
				// hfCode.Value = int.Parse(hfCode.Value).ToString();
				return true;
			}
			finally
			{
			}

		}
		///-------------------------------------------------------------------------------------------------------------------------
		private void Refer()
		{
			Communication.JCLetter Letter = new Communication.JCLetter();
			DataTable _DT = Letter.GetData(int.Parse(hfCode.Value));
			if (_DT.Rows.Count == 1)
			{

				#region Set PostCodes For recivers List By Type Of Letter
				///---------------------------------------------------------------------
				string _PostCode = Letter.receiver_post_code.ToString();


				foreach (DataRow _row in Letter.LetterCopies.Rows)
				{
					if (Convert.ToInt32(_row["receiver_post_code"]) > 0)
					{
						if (_PostCode != string.Empty)
							_PostCode = _PostCode + ";" + _row["receiver_post_code"];
						else
							_PostCode = _row["receiver_post_code"].ToString();
					}
				}
				_DT.Columns.Add("recivers");
				_DT.Rows[0]["recivers"] = _PostCode;
				///---------------------------------------------------------------------
				#endregion Set PostCodes For recivers List

				WebControllers.Automation.JAutomationRefer.ShowRefer(
				   Communication.JCImportedLetter._ConstClassName, 0, int.Parse(hfCode.Value)
							  , _DT
							  , int.Parse(hfReferCode.Value), "ارجاع نامــه های وارده");
				///به صلاح دید مهندس زرین
				///به علت استفاده از همین کد در نرم افزار ویندوز
				///با اینکه منطق اشتباه است و این متد اولین ارجاع را می آورد
				///Findrefer حذف نشد
				hfReferCode.Value = (new Automation.JARefer()).FindRefer(Communication.JCImportedLetter._ConstClassName, int.Parse(hfCode.Value), 0).ToString();
				btnReference.Enabled = false;

			}
		}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void btnPrint_Click(object sender, EventArgs e)
		{
			Communication.JCLetter Letter = new Communication.JCLetter();
			DataTable _DT = Letter.GetData(int.Parse(hfCode.Value));

			///
			///
			///
			/// Query
			///
			/// مد نظر اضافه شود و دکمه چاپ در بقیه نامه ها هم اضافه شود
			///
			///
			///

			string Query = "Select * From Letters WHERE register_post_code = " + ClassLibrary.JMainFrame.CurrentPostCode.ToString() + " AND Code =" + int.Parse(hfCode.Value);
			//Session[""];
			List<string> REP_SQL = new List<string>();
			REP_SQL.Add(Query);
			Query = "Select * From Users ";
			REP_SQL.Add(Query);
			Session["REP_SQL"] = REP_SQL;
			WebClassLibrary.JWebManager.LoadControl("LettersReport"
			, "~/WebReport/Viewer/JReportSelectorControl.ascx"
			, "چاپ نامه"
			, new List<Tuple<string, string>>(){ new Tuple<string, string>("ObjectCode", "0")
                                               ,  new Tuple<string, string>("rSUID", "Report_Dt")
                                               , new Tuple<string, string>("ClassName",WebAutomation.JCommunication._ConstClassName) 
                                               , new Tuple<string,string>("SQL1",Query) }
			, WebClassLibrary.WindowTarget.NewWindow
			, true, true, true, 750, 500);

		}
		///-------------------------------------------------------------------------------------------------------------------------


		#endregion Method
	}
}