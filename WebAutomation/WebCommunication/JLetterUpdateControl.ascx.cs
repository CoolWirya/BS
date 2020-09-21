using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAutomation.WebCommunication
{
	public partial class JLetterUpdateControl : System.Web.UI.UserControl
	{
		#region Init
		protected global::WebControllers.ArchiveDocument.JArchiveControl JArchiveControl;
		protected global::WebAutomation.Refer.JReferViewControl JReferViewControl;
		// int int.Parse(hfCode.Value);
		//  int int.Parse(hfReferCode.Value);
		List<Communication.Letter.JCLetterCopy> arrJcLetterCopy;
		#endregion Init

		#region Events
		///-------------------------------------------------------------------------------------------------------------------------
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				hfClassName.Value = Communication.JCLetter._ConstClassName;
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

				arrJcLetterCopy = new List<Communication.Letter.JCLetterCopy>();
				ViewState["arrJcLetterCopy"] = arrJcLetterCopy;
				Session["Sign"] = false;

				switch (Request["Type"])
				{
					case "1"://وارده
						hfClassName.Value = Communication.JCImportedLetter._ConstClassName;
						break;
					case "2"://صادره
						hfClassName.Value = Communication.JCExportedLetter._ConstClassName;
						break;
					case "3"://داخلی
						hfClassName.Value = Communication.JCLetter._ConstClassName;
						break;
				}

				_SetForm();

                JArchiveControl.ClassName = Communication.JCLetter._ConstClassName;
			JArchiveControl.ObjectCode = int.Parse(hfCode.Value);
			JArchiveControl.LoadArchive();
			if (int.Parse(hfCode.Value) > 0 && int.Parse(hfReferCode.Value) == 0)
			{
                    ///به صلاح دید مهندس زرین
                    ///به علت استفاده از همین کد در نرم افزار ویندوز
                    ///با اینکه منطق اشتباه است و این متد اولین ارجاع را می آورد
                    ///Findrefer حذف نشد
                    hfReferCode.Value = (new Automation.JARefer()).FindRefer(Communication.JCLetter._ConstClassName, int.Parse(hfCode.Value), 0).ToString();
			}
			if (int.Parse(hfReferCode.Value) > 0 && int.Parse(hfCode.Value) == 0)
			{
				Automation.JARefer Jref = new Automation.JARefer(int.Parse(hfReferCode.Value));
				hfCode.Value = (new Automation.JAObject(Jref.object_code).ObjectCode).ToString();
			}
                if (hfCurrentPage.Value != "GetOutbox")
                    btnReturn.Enabled = false;
                else
                    btnReturn.Enabled = true;

                if (int.Parse(hfReferCode.Value) <= 0 || hfCurrentPage.Value == "GetInbox")
                    btnReference.Enabled = true;
                else
                    btnReference.Enabled = false;
		}

        }
		///-------------------------------------------------------------------------------------------------------------------------
		protected void btnSign_Click(object sender, EventArgs e)
		{

			LetterState.Value = ClassLibrary.Domains.JCommunication.JLetterStatus.Minute.ToString();
			if (Save())
			{
				Communication.JCLetter jcLetter = new Communication.JCLetter(int.Parse(hfCode.Value));
				if (!jcLetter.isSigned)
				{
					jcLetter.letter_status = ClassLibrary.Domains.JCommunication.JLetterStatus.Accept;
					jcLetter.isSigned = true;
					jcLetter.SignDate = JDateTime.Now();
					jcLetter.LetterText = txtContent.Text;
					jcLetter.html = txtContent.Content;
					if (jcLetter.Update())
					{
						lblSignStatus.Text = "نامه در تاریخ " + JDateTime.FarsiDate(jcLetter.SignDate) + " " + jcLetter.SignDate.Hour.ToString("00") + ":" + jcLetter.SignDate.Minute.ToString("00") + ":" + jcLetter.SignDate.Second.ToString("00")
							+ " امضا شده است";
						btnSign.Visible = false;
						rpvLetterInfo.Enabled = false;
						txtContent.EditModes = Telerik.Web.UI.EditModes.Preview;
						Session["Sign"] = true;
						((WebControllers.ArchiveDocument.JArchiveControl)JArchiveControl).CanUploadFile = false;
						((WebControllers.ArchiveDocument.JArchiveControl)JArchiveControl).CanDeleteFile = false;
						Refer();
					}
					else
						Session["Sign"] = false;
				}
			}
		}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void btnReference_Click(object sender, EventArgs e)
        {
            hfReferCode.Value = (new Automation.JARefer()).FindRefer(hfClassName.Value, int.Parse(hfCode.Value), 0).ToString();
            if (hfReferCode.Value != "0") 
            { 
                WebClassLibrary.JWebManager.ShowMessage("امکان ارجاع مجدد وجود ندارد");
                return;
            }
            if (Save())
			Refer();
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
		protected void rtabLetter_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
		{
			if (int.Parse(hfCode.Value) <= 0)
			{
				rtabLetter.Tabs.FindTabByValue("rpvLetterInfo").Selected = true;
				rpageLetter.FindPageViewByID("rpvLetterInfo").Selected = true;
				//WebClassLibrary.JWebManager.ShowMessage("ابتدا نامه را به ثبت رسانید");
				// Save();
			}
			else

				switch (e.Tab.PageViewID)
				{
					case "rpvLetterInfo":
						if (Session["Sign"] != null && (bool)Session["Sign"])
							txtContent.EditModes = Telerik.Web.UI.EditModes.Preview;

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
                        hfReferCode.Value = (new Automation.JARefer()).FindRefer(hfClassName.Value, int.Parse(hfCode.Value), 0).ToString();
						JReferViewControl.LoadRefers(new Automation.JARefer(int.Parse(hfReferCode.Value)).object_code);
                        if (hfCurrentPage.Value != "GetOutbox")
                            btnReturn.Enabled = false;
                        else
                            btnReturn.Enabled = true;

                        if (int.Parse(hfReferCode.Value) <= 0 || hfCurrentPage.Value == "GetInbox")
                            btnReference.Enabled = true;
                        else
                            btnReference.Enabled = false;
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
			ViewState["SelectedTab"] = e.Tab.PageViewID;
		}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void btnSave_Click(object sender, EventArgs e)
		{
			//if (
			Save();
			//)
			//WebClassLibrary.JWebManager.CloseAndRefresh();
		}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void cmbSender_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
		{
			if (cmbSender.SelectedValue == null) return;

			cmbCopyReceiver.Text = "";
			cmbCopyReceiver.Items.Clear();
			cmbCopyReceiver.Text = "";

			cmbReciever.Text = "";
			cmbReciever.Items.Clear();
			cmbReciever.Text = "";

			cmbCopyReceiver.DataValueField = "code";
			cmbCopyReceiver.DataTextField = "Full_Title_Slim";
			cmbReciever.DataValueField = "code";
			cmbReciever.DataTextField = "Full_Title_Slim";

			////  ---------------------- Set ComboBox CopryReceiver --------------------------
			Employment.JEOrganizationChart jeOrgChart = new Employment.JEOrganizationChart();
			DataTable dtReceiver;
			dtReceiver = jeOrgChart.GetChart(Convert.ToInt32(cmbSender.SelectedValue), 1);
			(dtReceiver as ClassLibrary.JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);
			cmbCopyReceiver.DataSource = dtReceiver;
			cmbCopyReceiver.DataBind();
			cmbReciever.DataSource = dtReceiver;
			cmbReciever.DataBind();
			jeOrgChart = new Employment.JEOrganizationChart(int.Parse(cmbSender.SelectedValue.ToString()));
			if (jeOrgChart.is_unit)
				lblSignStatus.Text = "نامه هنوز امضا نشده است.";
			else
				lblSignStatus.Text = "فرستنده حق امضاء ندارد.";
			if (JMainFrame.CurrentPostCode == int.Parse(cmbSender.SelectedValue.ToString()))
			{
				btnSign.Visible = true;
			}
			else
				btnSign.Visible = false;
		}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void btnAddCopyReceiver_Click(object sender, EventArgs e)
		{
			arrJcLetterCopy = (List<Communication.Letter.JCLetterCopy>)ViewState["arrJcLetterCopy"];
			Communication.JCLetter jlet = new Communication.JCLetter();

			//DataTable Sender_dt = (new Employment.JEOrganizationChart()).GetParents(ClassLibrary.JMainFrame.CurrentPostCode);
			//(Sender_dt as ClassLibrary.JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);

			Employment.JEOrganizationChart jeOrgChart = new Employment.JEOrganizationChart();
			DataTable Reciver_dt = jeOrgChart.GetChart(Convert.ToInt32(cmbSender.SelectedValue), 1);
			(Reciver_dt as ClassLibrary.JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);

			Reciver_dt.DefaultView.RowFilter = "code =" + cmbCopyReceiver.SelectedValue;
			DataTable LetCopyDt = jlet.LetterCopies;
			DataRow dr = Reciver_dt.DefaultView[0].Row;
			DataRow copyReciver_dr = jlet.LetterCopies.NewRow();
			Communication.Letter.JCLetterCopy jcLetterCopy = new Communication.Letter.JCLetterCopy();

			#region AddCopyRec
			jcLetterCopy = new Communication.Letter.JCLetterCopy();
			jcLetterCopy.copy_reason = txtReason.Text;
			jcLetterCopy.copy_type = 0;
			jcLetterCopy.receiver_external_code = 0;
			jcLetterCopy.receiver_full_title = dr["full_title"].ToString();
			jcLetterCopy.receiver_post_code = Convert.ToInt32(dr["Code"].ToString());
			jcLetterCopy.receiver_subsidiaries_code = 0;
			jcLetterCopy.receiver_user_code = (new Employment.JEOrganizationChart(jcLetterCopy.receiver_post_code)).user_code;
			jcLetterCopy.register_full_title = JMainFrame.CurrentPostTitle;
			jcLetterCopy.register_post_code = JMainFrame.CurrentPostCode;
			jcLetterCopy.register_user_code = JMainFrame.CurrentUserCode;
			jcLetterCopy.respite_date_time = DateTime.MinValue;
			jcLetterCopy.send_type = ClassLibrary.Domains.JCommunication.JSendType.Automation;
			if (arrJcLetterCopy.Where(m => m.receiver_user_code == jcLetterCopy.receiver_user_code).Count() == 0)
				arrJcLetterCopy.Add(jcLetterCopy);
			#endregion AddCopyRec

			ViewState["arrJcLetterCopy"] = arrJcLetterCopy;
			grvCopies.DataSource = arrJcLetterCopy;
			grvCopies.DataBind();
		}
		///-------------------------------------------------------------------------------------------------------------------------
		#endregion Events

		#region Grid Events
		///-------------------------------------------------------------------------------------------------------------------------
		protected void grvCopies_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
		{
			arrJcLetterCopy = (List<Communication.Letter.JCLetterCopy>)ViewState["arrJcLetterCopy"];
			grvCopies.DataSource = arrJcLetterCopy;
		}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void grvCopies_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void grvCopies_Load(object sender, EventArgs e)
		{

		}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void grvCopies_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
		{
			arrJcLetterCopy = (List<Communication.Letter.JCLetterCopy>)ViewState["arrJcLetterCopy"];
			e.Item.Selected = true;
			arrJcLetterCopy.RemoveAt(e.Item.ItemIndex);
			ViewState["arrJcLetterCopy"] = arrJcLetterCopy;
			grvCopies.DataSource = arrJcLetterCopy;
			grvCopies.DataBind();
		}
		///-------------------------------------------------------------------------------------------------------------------------
		#endregion Grid Events

		#region Methods
		///-------------------------------------------------------------------------------------------------------------------------
		public void _SetForm()
		{
			txtYear.Text = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now()).ToString();
			DataTable _dt = ClassLibrary.Domains.JCommunication.JSendType.GetData();
			grvCopies.DataBind();
			arrJcLetterCopy = (List<Communication.Letter.JCLetterCopy>)ViewState["arrJcLetterCopy"];
			//  ---------------------- Set ComboBox Sender --------------------------
			_dt = (new Employment.JEOrganizationChart()).GetParents(ClassLibrary.JMainFrame.CurrentPostCode);
			(_dt as ClassLibrary.JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);
			cmbSender.DataSource = _dt;
			cmbSender.DataBind();
			//  ---------------------- Set ComboBox Urgency --------------------------
			cmbUrgency.DataSource = ClassLibrary.Domains.JGlobal.JUrgency.GetData();
			cmbUrgency.SelectedValue = ClassLibrary.Domains.JGlobal.JUrgency.Normal.ToString();
			cmbUrgency.DataBind();
			////  ---------------------- Set ComboBox CopryReceiver --------------------------
			Employment.JEOrganizationChart jeOrgChart = new Employment.JEOrganizationChart();
			DataTable dt;
			dt = jeOrgChart.GetChart(Convert.ToInt32(cmbSender.SelectedValue), 1);
			(dt as ClassLibrary.JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);
			cmbCopyReceiver.DataSource = dt.Copy();
			cmbCopyReceiver.DataBind();
			cmbReciever.DataSource = dt.Copy();
			cmbReciever.DataBind();

			if (int.Parse(hfCode.Value) > 0)
			{
				Communication.JCLetter jcLetter;
				jcLetter = new Communication.JCLetter(int.Parse(hfCode.Value));

				dt = ((DataTable)(cmbSender.DataSource));
				dt.DefaultView.RowFilter = "user_code =" + jcLetter.sender_code;
				int SenderCode = -1;
				if (dt.DefaultView.Count != 0)
				{
					SenderCode = (int)dt.DefaultView[0]["code"];
				}

				dt = ((DataTable)(cmbReciever.DataSource));
				dt.DefaultView.RowFilter = "user_code =" + +jcLetter.receiver_code;
				int ReciverCode = -1;
				if (dt.DefaultView.Count != 0)
				{
					ReciverCode = (int)dt.DefaultView[0]["code"];
				}

				#region Set Control Properties
				txtSubject.Text = jcLetter.subject;
				txtLetterNo.Text = jcLetter.letter_no;
				if (cmbSender.FindItemByValue(SenderCode.ToString()) != null)
					cmbSender.FindItemByValue(SenderCode.ToString()).Selected = true;
				if (cmbUrgency.FindItemByValue(jcLetter.urgency.ToString()) != null)
					cmbUrgency.FindItemByValue(jcLetter.urgency.ToString()).Selected = true;
				if (cmbReciever.FindItemByValue(ReciverCode.ToString()) != null)
					cmbReciever.FindItemByValue(ReciverCode.ToString()).Selected = true;
				LetterState.Value = jcLetter.letter_status.ToString();

                txtContent.Content = jcLetter.html;



				if (jcLetter.isSigned)
				{
					lblSignStatus.Text = "نامه در تاریخ " + JDateTime.FarsiDate(jcLetter.SignDate) + " " + jcLetter.SignDate.Hour.ToString("00") + ":" + jcLetter.SignDate.Minute.ToString("00") + ":" + jcLetter.SignDate.Second.ToString("00")
							   + " امضا شده است";
					btnSign.Visible = false;
					rpvLetterInfo.Enabled = false;
					txtContent.EditModes = Telerik.Web.UI.EditModes.Preview;
					Session["Sign"] = true;
					((WebControllers.ArchiveDocument.JArchiveControl)JArchiveControl).CanUploadFile = false;
					((WebControllers.ArchiveDocument.JArchiveControl)JArchiveControl).CanDeleteFile = false;
				}
				else
				{
					Session["Sign"] = false;
					rpvLetterInfo.Enabled = true;
					txtContent.EditModes = Telerik.Web.UI.EditModes.All;
				}

				#endregion Set Control Properties

				#region  Build arrJcLetterCopy for FristTime
				Communication.Letter.JCLetterCopy jcLetterCopy = new Communication.Letter.JCLetterCopy();
				DataTable dtJcLetterCopy = jcLetterCopy.GetLetterCopies(int.Parse(hfCode.Value));
				if (!IsPostBack)
				{
					arrJcLetterCopy = new List<Communication.Letter.JCLetterCopy>();

					foreach (DataRow dr in dtJcLetterCopy.Rows)
					{
						if (arrJcLetterCopy.Where(m => m.receiver_user_code == (int)dr["receiver_user_code"]).Count() == 0)
						{
							jcLetterCopy = new Communication.Letter.JCLetterCopy();
							jcLetterCopy.copy_reason = (string)dr["copy_reason"];
							jcLetterCopy.copy_type = (int)dr["copy_type"];
							jcLetterCopy.letter_code = (int)dr["letter_code"];
							jcLetterCopy.receiver_external_code = (int)dr["receiver_external_code"];
							jcLetterCopy.receiver_full_title = (string)dr["receiver_full_title"];
							jcLetterCopy.receiver_post_code = (int)dr["receiver_post_code"];
							jcLetterCopy.receiver_subsidiaries_code = (int)dr["receiver_subsidiaries_code"];
							jcLetterCopy.receiver_user_code = (int)dr["receiver_user_code"];
							jcLetterCopy.register_full_title = (string)dr["register_full_title"];
							jcLetterCopy.register_post_code = (int)dr["register_post_code"];
							jcLetterCopy.register_user_code = (int)dr["register_user_code"];
							jcLetterCopy.send_type = (int)dr["send_type"];
							arrJcLetterCopy.Add(jcLetterCopy);
						}
					}

				}
				#endregion Build arrJcLetterCopy for FristTime

                ///به صلاح دید مهندس زرین
                ///به علت استفاده از همین کد در نرم افزار ویندوز
                ///با اینکه منطق اشتباه است و این متد اولین ارجاع را می آورد
                ///Findrefer حذف نشد
				if (Convert.ToInt32(hfCode.Value) > 0 && Convert.ToInt32(hfReferCode.Value) == 0)
                    hfReferCode.Value = (new Automation.JARefer()).FindRefer(Communication.JCLetter._ConstClassName, int.Parse(hfCode.Value), 0).ToString();

				Automation.JARefer jaRefer = new Automation.JARefer(Convert.ToInt32(hfReferCode.Value));
				if (jaRefer.Code > 0)
				{
					if (jaRefer.receiver_post_code != JMainFrame.CurrentPostCode
						|| jaRefer.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
					{
						btnReference.Enabled = false;
					}
				}
			}

			ViewState["arrJcLetterCopy"] = arrJcLetterCopy;
			grvCopies.DataSource = arrJcLetterCopy;
			grvCopies.DataBind();
		}
		///-------------------------------------------------------------------------------------------------------------------------
		public bool Save()
		{
			try
			{
				arrJcLetterCopy = (List<Communication.Letter.JCLetterCopy>)ViewState["arrJcLetterCopy"];
				Communication.JCLetter jcLetter;

				DataTable Sender_dt = (new Employment.JEOrganizationChart()).GetParents(ClassLibrary.JMainFrame.CurrentPostCode);
				(Sender_dt as ClassLibrary.JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);

				Employment.JEOrganizationChart jeOrgChart = new Employment.JEOrganizationChart();
				DataTable Reciver_dt = jeOrgChart.GetChart(Convert.ToInt32(cmbSender.SelectedValue), 1);
				(Reciver_dt as ClassLibrary.JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);

				if (int.Parse(hfCode.Value) == 0)
					jcLetter = new Communication.JCLetter();
				else
					jcLetter = new Communication.JCLetter(int.Parse(hfCode.Value));

				#region CheckValidate

				if (jcLetter.isSigned)
				{
					WebClassLibrary.JWebManager.ShowMessage("نامه امضا شده است و قابل تغییر نیست");
					return false;
				}

				if (cmbSender.SelectedValue == null)
				{
					WebClassLibrary.JWebManager.ShowMessage("فرستنده انتخاب نشده است");
					return false;
				}

				if (cmbReciever.SelectedValue == null)
				{
					WebClassLibrary.JWebManager.ShowMessage("گیرنده انتخاب نشده است");
					return false;
				}

				if (txtSubject.Text.Trim().Length == 0)
				{
					WebClassLibrary.JWebManager.ShowMessage("موضوع نامه انتخاب نشده است");
					return false;
				}

				#endregion CheckValidate

				jcLetter.letter_type = ClassLibrary.Domains.JCommunication.JLetterType.Internal; // نامه داخلی
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
				if (ParentCode.Value != string.Empty)
					jcLetter.ParentCode = int.Parse(ParentCode.Value);


				jcLetter.subject = txtSubject.Text;
				jcLetter.letter_no = txtLetterNo.Text;
				jcLetter.sender_post_code = Convert.ToInt32(cmbSender.SelectedValue);
				jcLetter.sender_code = (new Employment.JEOrganizationChart(jcLetter.sender_post_code)).user_code;
				// DataTable senderDt = ((DataTable)(cmbSender.DataSource));
				Sender_dt.DefaultView.RowFilter = "code =" + cmbSender.SelectedValue;
				jcLetter.sender_full_title = Sender_dt.DefaultView[0]["full_name"].ToString();
				if (cmbReciever.SelectedValue != null && cmbReciever.SelectedValue.Length > 0)
				jcLetter.receiver_post_code = Convert.ToInt32(cmbReciever.SelectedValue);
				jcLetter.receiver_code = (new Employment.JEOrganizationChart(jcLetter.receiver_post_code)).user_code;
				if (cmbReciever.SelectedValue != null && cmbReciever.SelectedValue.Length > 0)
				{
					Reciver_dt.DefaultView.RowFilter = "code =" + cmbReciever.SelectedValue;
					jcLetter.receiver_full_title = Reciver_dt.DefaultView[0]["full_name"].ToString();
				}
				jcLetter.urgency = Convert.ToInt32(cmbUrgency.SelectedValue);
				jcLetter.send_type = ClassLibrary.Domains.JCommunication.JSendType.Automation;
				jcLetter.minute_register_date = JDateTime.Now();
                jcLetter.LetterText = txtContent.Text;
				jcLetter.html = txtContent.Content;
                jcLetter.NormalLetterText = txtContent.Text;
                ///این کد دستی پر شد به خاطر خطا در اتوماسیون شرکت
                ///جدولی به نام Secrete... 
                /// وجود دارد که باید شخص بر اساس دسترسی بتواند از دبیرخانه انتخابی استفاده کند 
                jcLetter.secretariat_code = (new Employment.JEOrganizationChart(jcLetter.sender_post_code)).secretariat_code;

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
				Communication.Letter.JCLetterCopy jcLetterCopy = new Communication.Letter.JCLetterCopy();
				jcLetterCopy.DeleteByLetterCode(int.Parse(hfCode.Value));
				foreach (Communication.Letter.JCLetterCopy objCopy in arrJcLetterCopy)
				{
					objCopy.letter_code = int.Parse(hfCode.Value);
					objCopy.Insert();
				}
				ViewState["arrJcLetterCopy"] = arrJcLetterCopy;
				WebClassLibrary.JWebManager.ShowMessage("ذخیره با موفقیت انجام شد");
                //  hfCode.Value = int.Parse(hfCode.Value).ToString();

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
				   Communication.JCLetter._ConstClassName, 0, int.Parse(hfCode.Value)
							  , _DT
							  , int.Parse(hfReferCode.Value), "ارجاع نامه داخلی");
                ///به صلاح دید مهندس زرین
                ///به علت استفاده از همین کد در نرم افزار ویندوز
                ///با اینکه منطق اشتباه است و این متد اولین ارجاع را می آورد
                ///Findrefer حذف نشد
                //   hfReferCode.Value = (new Automation.JARefer()).FindRefer(Communication.JCLetter._ConstClassName, int.Parse(hfCode.Value), 0).ToString();

                //btnReference.Enabled = false;
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
		#endregion Methods

	}
}