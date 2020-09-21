using ClassLibrary;
using Communication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAutomation.WebCommunication
{
	public partial class JExportedLetterUpdateControl : System.Web.UI.UserControl
	{
		#region Init

		protected global::WebControllers.ArchiveDocument.JArchiveControl JArchiveControl;
		protected global::WebAutomation.Refer.JReferViewControl JReferViewControl;
		//int int.Parse(hfCode.Value);
		//int int.Parse(hfReferCode.Value);
		List<Communication.Letter.JCLetterCopy> arrJcLetterCopy;

		#endregion Init

		#region Events
		///-------------------------------------------------------------------------------------------------------------------------
		protected void Page_Load(object sender, EventArgs e)
		{
			//Page.GetPostBackEventReference(SignHiddenButton);
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

				arrJcLetterCopy = new List<Communication.Letter.JCLetterCopy>();
				ViewState["arrJcLetterCopy"] = arrJcLetterCopy;

				Session["Sign"] = false;
				_SetForm();

			}

			JArchiveControl.ClassName = Communication.JCExportedLetter._ConstClassName;
			JArchiveControl.ObjectCode = int.Parse(hfCode.Value);
			JArchiveControl.LoadArchive();

			if (int.Parse(hfCode.Value) > 0 && int.Parse(hfReferCode.Value) == 0)
			{
				///به صلاح دید مهندس زرین
				///به علت استفاده از همین کد در نرم افزار ویندوز
				///با اینکه منطق اشتباه است و این متد اولین ارجاع را می آورد
				///Findrefer حذف نشد
				hfReferCode.Value = (new Automation.JARefer()).FindRefer(Communication.JCExportedLetter._ConstClassName, int.Parse(hfCode.Value), 0).ToString();
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
		///-------------------------------------------------------------------------------------------------------------------------       
		protected void btnSave_Click(object sender, EventArgs e)
		{
			if (Save())
				WebClassLibrary.JWebManager.RefreshGrid();
		}
		///-------------------------------------------------------------------------------------------------------------------------
        //protected void cmbSender_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        //    if (cmbSender.SelectedValue == null) return;
        //    ////  ---------------------- Set ComboBox Receiver --------------------------
        //    Employment.JEOrganizationChart jeOrgChart = new Employment.JEOrganizationChart();
        //    DataTable dt;

        //    dt = jeOrgChart.GetChart(Convert.ToInt32(cmbSender.SelectedValue), 1);

        //    (dt as ClassLibrary.JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);
        //    //cmbCopyReceiver.DataSource = dt.Copy();
        //    //cmbCopyReceiver.DataBind();
        //    jeOrgChart = new Employment.JEOrganizationChart(int.Parse(cmbSender.SelectedValue.ToString()));
        //    if (jeOrgChart.is_unit)
        //        lblSignStatus.Text = "نامه هنوز امضا نشده است.";
        //    else
        //        lblSignStatus.Text = "فرستنده حق امضاء ندارد.";
        //    if (JMainFrame.CurrentPostCode == int.Parse(cmbSender.SelectedValue.ToString()))
        //    {
        //        btnSign.Visible = true;
        //    }
        //    else
        //        btnSign.Visible = false;

        //    arrJcLetterCopy = (List<Communication.Letter.JCLetterCopy>)ViewState["arrJcLetterCopy"];
        //    grvCopies.DataSource = arrJcLetterCopy;
        //    grvCopies.DataBind();
        //}
		///-------------------------------------------------------------------------------------------------------------------------
		protected void btnSign_Click(object sender, EventArgs e)
		{
			LetterState.Value = ClassLibrary.Domains.JCommunication.JLetterStatus.Minute.ToString();
			if (Save())
			{
				WebClassLibrary.JWebManager.RefreshGrid();
				Communication.JCLetter jcLetter = new Communication.JCLetter(int.Parse(hfCode.Value));
				if (!jcLetter.isSigned)
				{
					jcLetter.letter_status = ClassLibrary.Domains.JCommunication.JLetterStatus.Accept;
					jcLetter.isSigned = true;
					jcLetter.letter_no = txtLetterNo.Text;
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
		protected void btnAddCopyReceiver_Click(object sender, EventArgs e)
		{
			arrJcLetterCopy = (List<Communication.Letter.JCLetterCopy>)ViewState["arrJcLetterCopy"];
			Communication.JCLetter jlet = new Communication.JCLetter();
			Employment.JEOrganizationChart jeOrgChart = new Employment.JEOrganizationChart();
			DataTable Reciver_dt = jeOrgChart.GetChart(Convert.ToInt32(cmbSender.SelectedValue), 1);
			(Reciver_dt as ClassLibrary.JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);

            Reciver_dt.DefaultView.RowFilter = "code =" + cmbCopyReceiver.SelectedValue; //cmbCopyReceiver.Items[cmbCopyReceiver.SelectedIndex].Value
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
		protected void btnReference_Click(object sender, EventArgs e)
		{
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
		protected void rtabExportedLetter_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
		{
			if (int.Parse(hfCode.Value) <= 0)
			{
				rtabExportedLetter.Tabs.FindTabByValue("rpvLetterInfo").Selected = true;
				rpageExportedLetter.FindPageViewByID("rpvLetterInfo").Selected = true;
				//  WebClassLibrary.JWebManager.ShowMessage("ابتدا نامه را به ثبت رسانید");

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
		}
		///-------------------------------------------------------------------------------------------------------------------------
		#endregion Events

		#region Grid Events
		///-------------------------------------------------------------------------------------------------------------------------
		protected void grvCopies_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
		{
			arrJcLetterCopy = (List<Communication.Letter.JCLetterCopy>)ViewState["arrJcLetterCopy"];
			grvCopies.DataSource = arrJcLetterCopy;
			// grvCopies.DataBind();
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
			DataTable _dt;
			DataTable dt_chart;
			Communication.JCLetter jcLetter;
			txtYear.Text = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now()).ToString();
			arrJcLetterCopy = (List<Communication.Letter.JCLetterCopy>)ViewState["arrJcLetterCopy"];
			//  ---------------------- Set ComboBox DeliveryType --------------------------

			_dt = ClassLibrary.Domains.JCommunication.JSendType.GetData();
			cmbDeliveryType.DataSource = _dt;
			cmbDeliveryType.DataBind();

			//  ---------------------- Set ComboBox Sender --------------------------

			_dt = (new Employment.JEOrganizationChart()).GetParents(ClassLibrary.JMainFrame.CurrentPostCode);
			(_dt as ClassLibrary.JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);
			cmbSender.DataSource = _dt;
			cmbSender.DataBind();
			//  ---------------------- Set ComboBox Urgency --------------------------
			cmbUrgency.DataSource = ClassLibrary.Domains.JGlobal.JUrgency.GetData();
			cmbUrgency.SelectedValue = ClassLibrary.Domains.JGlobal.JUrgency.Normal.ToString();
			cmbUrgency.DataBind();

			////  ---------------------- Set ComboBox Receiver --------------------------

            //Employment.JEOrganizationChart jeOrgChart = new Employment.JEOrganizationChart();

            //dt_chart = jeOrgChart.GetChart(Convert.ToInt32(cmbSender.SelectedValue), 1);
            //(dt_chart as ClassLibrary.JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);
            //cmbCopyReceiver.DataSource = dt_chart.Copy();
            //cmbCopyReceiver.DataBind();

			if (int.Parse(hfCode.Value) > 0)
			{
				jcLetter = new Communication.JCLetter(int.Parse(hfCode.Value));

				#region Set Control Properties

				txtSubject.Text = jcLetter.subject;
				txtLetterNo.Text = jcLetter.letter_no;

				if (cmbSender.FindItemByValue(jcLetter.sender_code.ToString()) != null)
					cmbSender.FindItemByValue(jcLetter.sender_code.ToString()).Selected = true;

				if (cmbDeliveryType.FindItemByValue(jcLetter.DeliveryType.ToString()) != null)
					cmbDeliveryType.FindItemByValue(jcLetter.DeliveryType.ToString()).Selected = true;

				if (cmbUrgency.FindItemByValue(jcLetter.urgency.ToString()) != null)
					cmbUrgency.FindItemByValue(jcLetter.urgency.ToString()).Selected = true;

				if (jcLetter.DeliveryDate != null)
					((WebControllers.MainControls.Date.JDateControl)dteDelivery).SetDate(jcLetter.DeliveryDate);

				LetterState.Value = jcLetter.letter_status.ToString();
				txtReciever.Text = jcLetter.receiver_full_title;


				txtContent.Content = jcLetter.html;

				txtDeliveryPerson.Text = jcLetter.DeliveryPerson;

				if (jcLetter.isSigned)
				{
					rpvLetterInfo.Enabled = false;
					Session["Sign"] = true;
					lblSignStatus.Text = "نامه در تاریخ " + JDateTime.FarsiDate(jcLetter.SignDate) + " " + jcLetter.SignDate.Hour.ToString("00") + ":" + jcLetter.SignDate.Minute.ToString("00") + ":" + jcLetter.SignDate.Second.ToString("00")
							   + " امضا شده است";
					txtContent.EditModes = Telerik.Web.UI.EditModes.Preview;
					btnSign.Visible = false;
					((WebControllers.ArchiveDocument.JArchiveControl)JArchiveControl).CanUploadFile = false;
					((WebControllers.ArchiveDocument.JArchiveControl)JArchiveControl).CanDeleteFile = false;
				}
				else
				{
					rpvLetterInfo.Enabled = true;
					txtContent.EditModes = Telerik.Web.UI.EditModes.All;
					Session["Sign"] = false;
				}
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

				#endregion Set Control Properties
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

				if (int.Parse(hfCode.Value) == 0)
					jcLetter = new Communication.JCLetter();
				else
					jcLetter = new Communication.JCLetter(int.Parse(hfCode.Value));

				#region CheckValidate
				if (jcLetter.isSigned)
				{
					WebClassLibrary.JWebManager.ShowMessage("نامه امضا شده است و قابل تغییر نیست");
					return true;
				}
				if (cmbSender.SelectedValue == null)
				{
					WebClassLibrary.JWebManager.ShowMessage("فرستنده انتخاب نشده است");
					return false;
				}
				if (txtReciever.Text.Trim().Length < 3)
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

				jcLetter.letter_type = ClassLibrary.Domains.JCommunication.JLetterType.Export; // نامه صادره
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
				Sender_dt.DefaultView.RowFilter = "code =" + cmbSender.SelectedValue;
				jcLetter.sender_full_title = Sender_dt.DefaultView[0]["full_name"].ToString();
				jcLetter.receiver_post_code = 0;
				jcLetter.receiver_code = 0;
				jcLetter.receiver_full_title = txtReciever.Text;
				jcLetter.urgency = Convert.ToInt32(cmbUrgency.SelectedValue);
				jcLetter.send_type = ClassLibrary.Domains.JCommunication.JSendType.Automation;
				jcLetter.minute_register_date = JDateTime.Now();

				jcLetter.LetterText = txtContent.Text;
				jcLetter.html = txtContent.Content;

				jcLetter.NormalLetterText = txtContent.Text;
				jcLetter.DeliveryType = Convert.ToInt32(cmbDeliveryType.SelectedValue);
				jcLetter.DeliveryDate = ((WebControllers.MainControls.Date.JDateControl)dteDelivery).GetDate();
				jcLetter.DeliveryPerson = txtDeliveryPerson.Text;
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
				string _PostCode = "";
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
				  Communication.JCExportedLetter._ConstClassName, 0, int.Parse(hfCode.Value)
							  , _DT
							  , int.Parse(hfReferCode.Value), "ارجاع نامه های صادره");
				///به صلاح دید مهندس زرین
				///به علت استفاده از همین کد در نرم افزار ویندوز
				///با اینکه منطق اشتباه است و این متد اولین ارجاع را می آورد
				///Findrefer حذف نشد
				hfReferCode.Value = (new Automation.JARefer()).FindRefer(Communication.JCExportedLetter._ConstClassName, int.Parse(hfCode.Value), 0).ToString();

				btnReference.Enabled = false;
			}
		}

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

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

		///-------------------------------------------------------------------------------------------------------------------------
		#endregion Methods

	}
}