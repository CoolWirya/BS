using ClassLibrary;
using Legal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebLegal.Contract.Forms.SubjectContract
{
	public partial class SubjectControl : System.Web.UI.UserControl
	{
		public int FinanceCode
		{
			get
			{
				if (ViewState["FinanceCode"] == null)
					return string.IsNullOrEmpty(hdnFinanceCode.Value) ? 0 : int.Parse(hdnFinanceCode.Value);
				return (int)ViewState["FinanceCode"];
			}
			set
			{
				ViewState["FinanceCode"] = value;
				hdnFinanceCode.Value = value.ToString();
			}
		}
		int Code = 0;
		int DynamicContractType;
		JContractForms ContractForms;
		private void Fill_Data()
		{
			try
			{
				FillCombo();

				if (ContractForms.Contract.Code > 0)
				{
					Set_Form();
					if (Code > 0)
					{
						txtdateStart.Date = ContractForms.Contract.StartDate;
						txtdateEnd.Date = ContractForms.Contract.EndDate;
						txtDate.Date = ContractForms.Contract.Date;
						txtContractNumber.Text = "0";
						txtInfo.Text = "";
					}
				}
				else
				{
					if (ContractForms.Contract.FinanceCode > 0)
					{
						Finance.JAsset asset = new Finance.JAsset(ContractForms.Contract.FinanceCode);
						SetCommentText(asset.ClassName, asset.ObjectCode);
						FinanceCode = ContractForms.Contract.FinanceCode;
					}

				}
				txtdateStart.Visible = (Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["HasStartDate"])));
				lbldateStart.Visible = (Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["HasStartDate"])));

				txtdateEnd.Visible = (Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["HasEndDate"])));
				lbldateEnd.Visible = (Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["HasEndDate"])));

				txtDateDeliver.Visible = (Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["HasDeliverDate"])));
				lbldateDaliver.Visible = (Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["HasDeliverDate"])));

				bool noContract = Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["NoContract"]));
				bool noFinance = Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["NoFinance"]));
				hdnNoFinance.Value = noFinance.ToString();
				btnSearchGround.Enabled = !noFinance;
				lblMaxCount.Enabled = !noContract;
				txtMaxCount.Enabled = !noContract;
			}
			catch (Exception ex)
			{
			}
		}

		#region Methods

		private void SetCommentText(string pClassName, int pObjectCode)
		{
			JAction CommentAction = new JAction("GetAssetType", pClassName + ".GetAssetComment", new object[] { pObjectCode }, null);
			string Comment = (string)CommentAction.run();

			JAction unitAction = new JAction("GetAssetType", pClassName + ".GetAssetUnit");
			string unit = (string)unitAction.run();

			txtbSubjectComment.Text = Comment;

		}

		private void FillCombo()
		{
			try
			{
				//cmbLocation.DisplayMember = "name";
				//cmbLocation.ValueMember = "Code";
				//cmbLocation.DataSource = (new JOrganizations()).GetOrganization(0);

				JContractLocations locations = new JContractLocations();
				JSubBaseDefine nullDeff = new JSubBaseDefine(0);
				nullDeff.Code = -1;
				nullDeff.Name = "-----------";
				//cmbLocation.BaseCode = JBaseDefineLegal.ContractLocations;
				try
				{
					//خواندن محل انجام قرارداد پیشفرض از رجیستری
					object loc = Globals.JRegistry.Read("Legal.JSubjectContract.DefaultLocation");
					locations.SetDropDownList(cmbLocation, ContractForms != null ? ContractForms.Contract.Location : 0);
					//if (this.State == JStateContractForm.Insert)
					if (Code > 0)
						cmbLocation.SelectedValue = loc.ToString();

					object copyCount = Globals.JRegistry.Read("Legal.JSubjectContract.DefaultCopyCount");
					txtCopycount.Text = copyCount.ToString();
				}
				catch
				{
				}


				cmbSubject.DataTextField = "Title";
				cmbSubject.DataValueField = "Code";
				string query = "select Code,Title from legContractType where 1=1";
				query += ContractForms != null ? " AND ContractType=" + ContractForms.Contract.ContractType.Code : "";
				cmbSubject.DataSource = WebClassLibrary.JWebDataBase.GetDataTable(query);
				//JContractdefines.GetDataTable(0, ContractForms != null ? ContractForms.Contract.ContractType.Code : 0, null);
				cmbSubject.DataBind();
				//ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("Legal.ContractType"));
			}
			catch (Exception ex)
			{
				//JSystem.Except.AddException(ex);
			}
		}

		private void Set_Form()
		{
			try
			{
				JSubjectContract tmp = ContractForms.Contract;
				cmbSubject.SelectedValue = ContractForms.Contract.Type.ToString();
				txtContractNumber.Text = tmp.Number;
				txtDate.Date = tmp.Date;
				txtDateDeliver.Date = tmp.DateDeliver;
				txtdateStart.Date = tmp.StartDate;
				txtdateEnd.Date = tmp.EndDate;
				txtContractTitle.Text = tmp.ContractTitle;
				txtInfo.Text = tmp.Description;
				txtCopycount.Text = ContractForms.Contract.CopyCount.ToString();

				if (ContractForms.Contract.Code > 0)
				{
					(archiveControl as WebControllers.ArchiveDocument.JArchiveControl).ObjectCode = ContractForms.Contract.Code;
					Finance.JAsset asset = new Finance.JAsset(ContractForms.Contract.FinanceCode);
					SetCommentText(asset.ClassName, asset.ObjectCode);
					FinanceCode = asset.Code;
				}

				if (ContractForms.Contract.FinanceCode > 0)
				{
					Finance.JAsset asset = new Finance.JAsset(ContractForms.Contract.FinanceCode);
					SetCommentText(asset.ClassName, asset.ObjectCode);
					FinanceCode = ContractForms.Contract.FinanceCode;
				}

				//if (State == JStateContractForm.View)
				//{
				//	txtbSubjectComment.ReadOnly = true;
				//	txtContractNumber.ReadOnly = true;
				//	txtDate.ReadOnly = true;
				//	txtDateDeliver.ReadOnly = true;
				//	txtdateEnd.ReadOnly = true;
				//	txtdateStart.ReadOnly = true;
				//	txtInfo.ReadOnly = true;

				//	cmbLocation.Enabled = false;
				//	cmbSubject.Enabled = false;
				//	txtCopycount.Enabled = false;

				//	jArchiveListContract.AllowUserAddFile = false;
				//	jArchiveListContract.AllowUserAddFromArchive = false;
				//	jArchiveListContract.AllowUserAddImage = false;
				//	jArchiveListContract.AllowUserDeleteFile = false;
				//}
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
			}
		}

		private bool ApplyData()
		{
			try
			{
				//ApplyDataSet = true;
				ContractForms.Contract.FinanceCode = FinanceCode;
				if ((Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType == Finance.JOwnershipType.Rentals)
				{
					if (Code <= 0)
						if (JTransferAssetAfterContract.AssetHasRentContract(ContractForms.Contract.FinanceCode, txtdateStart.Date))
						{
							WebClassLibrary.JWebManager.ShowMessage("این دارایی دارای قرارداد اجاره فعال است. امکان ثبت قرارداد اجاره جدید وجود ندارد. ", WebClassLibrary.MessageType.Information);
							return false;
						}
				}
				ContractForms.Contract.Type = Convert.ToInt32(cmbSubject.SelectedValue);
				ContractForms.Contract.Number = txtContractNumber.Text.Trim();
				ContractForms.Contract.Date = txtDate.Date;
				ContractForms.Contract.DateDeliver = txtDateDeliver.Date;
				ContractForms.Contract.StartDate = txtdateStart.Date;
				ContractForms.Contract.EndDate = txtdateEnd.Date;
				ContractForms.Contract.Location = Convert.ToInt32(cmbLocation.SelectedValue);// Convert.ToInt32(cmbLocation.SelectedValue);
				ContractForms.Contract.Description = txtInfo.Text.Trim();
				ContractForms.Contract.CopyCount = Convert.ToInt32(txtCopycount.Text);
				ContractForms.Contract.ContractTitle = txtContractTitle.Text;

				Globals.JRegistry.Write("Legal.JSubjectContract.DefaultLocation", Convert.ToInt32(cmbLocation.SelectedValue));
				Globals.JRegistry.Write("Legal.JSubjectContract.DefaultCopyCount", Convert.ToInt32(txtCopycount.Text));
				return true;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				JMessages.Error("با مدیر سیستم تماس بگیرید", "خطا");
				return false;
			}
		}

		//public override bool SavePreview(DataTable pDt)
		//{
		//	return SavePreview(pDt, true, false);
		//}
		//public override bool SavePreview(DataTable pDt, bool pSetValue)
		//{
		//	return SavePreview(pDt, pSetValue, false);
		//}
		//public override bool SavePreview(DataTable pDt, bool pSetValue, bool pOffline)
		//{
		//	try
		//	{
		//		pDt.Columns.Add("Type");
		//		pDt.Columns.Add("TitleContract");
		//		pDt.Columns.Add("ContractNo");
		//		pDt.Columns.Add("Date");
		//		pDt.Columns.Add("StringDate");

		//		pDt.Columns.Add("DateDeliver");
		//		pDt.Columns.Add("StringDateDeliver");

		//		pDt.Columns.Add("StartDate");
		//		pDt.Columns.Add("StringStartDate");

		//		pDt.Columns.Add("EndDate");
		//		pDt.Columns.Add("StringEndDate");

		//		pDt.Columns.Add("Location");
		//		pDt.Columns.Add("FinanceCode");
		//		pDt.Columns.Add("Description");
		//		pDt.Columns.Add("Guarantee");
		//		pDt.Columns.Add("Condition");

		//		pDt.Columns.Add("T1Title");
		//		pDt.Columns.Add("T2Title");
		//		pDt.Columns.Add("CopyCount");

		//		pDt.Columns.Add("DateNow");

		//		if (pSetValue)
		//		{
		//			if (pOffline)
		//				Fill_Data();

		//			pDt.Rows[0]["Type"] = cmbSubject.Text;
		//			pDt.Rows[0]["TitleContract"] = txtContractTitle.Text;

		//			//((ClassLibrary.JKeyValue)(cmbSubject.SelectedValue)).Value
		//			pDt.Rows[0]["ContractNo"] = txtContractNumber.Text.Trim();
		//			/// تاریخ به عدد و حروف
		//			pDt.Rows[0]["Date"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtDate.Date));
		//			pDt.Rows[0]["DateNow"] = JGeneral.ReverseDate(JDateTime.FarsiDate(DateTime.Now));
		//			pDt.Rows[0]["StringDate"] = JDateTime.StringDate(txtDate.Text);
		//			/// تاریخ تحویل به عدد و حروف
		//			pDt.Rows[0]["DateDeliver"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtDateDeliver.Date));
		//			pDt.Rows[0]["StringDateDeliver"] = JDateTime.StringDate(txtDateDeliver.Text);
		//			/// تاریخ شروع به عدد و حروف
		//			pDt.Rows[0]["StartDate"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtdateStart.Date));
		//			pDt.Rows[0]["StringStartDate"] = JDateTime.StringDate(txtdateStart.Text);
		//			/// تاریخ پایان به عدد و حروف
		//			pDt.Rows[0]["EndDate"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtdateEnd.Date));
		//			pDt.Rows[0]["StringEndDate"] = JDateTime.StringDate(txtdateEnd.Text);

		//			pDt.Rows[0]["Location"] = cmbLocation.Text;
		//			pDt.Rows[0]["FinanceCode"] = _FinanceCode;
		//			pDt.Rows[0]["Description"] = txtInfo.Text.Trim();
		//			/// عنوان طرف اول و دوم
		//			pDt.Rows[0]["T1Title"] = ContractForms.Settings.Items["T1Lable"];
		//			pDt.Rows[0]["T2Title"] = ContractForms.Settings.Items["T2Lable"];
		//			pDt.Rows[0]["CopyCount"] = txtCopycount.Value.ToString();
		//		}

		//		return true;
		//	}
		//	catch (Exception ex)
		//	{
		//		JSystem.Except.AddException(ex);
		//		return false;
		//	}
		//}

		//public override bool Save(JDataBase DB)
		//{
		//	try
		//	{
		//		if (ContractForms.Contract.Code <= 0)
		//		{
		//			if (ContractForms.Contract.Code != 0)
		//				ContractForms.Contract.PreContract = ContractForms.Contract.Code;
		//			ContractForms.Contract.Code = 0;
		//		}
		//		if (ContractForms.Contract.Code > 0)
		//		{
		//			if (ContractForms.Contract.Update(DB))
		//			{
		//				(archiveControl as WebControllers.ArchiveDocument.JArchiveControl).ObjectCode = ContractForms.Contract.Code;
		//				(archiveControl as WebControllers.ArchiveDocument.JArchiveControl).SaveToArchive();
		//				return true;
		//			}
		//			else
		//				return false;
		//		}
		//		else
		//		{
		//			ContractForms.Contract.Code = ContractForms.Contract.Insert(DB);
		//			if (ContractForms.Contract.Code > 0)
		//			{
		//				(archiveControl as WebControllers.ArchiveDocument.JArchiveControl).ObjectCode = ContractForms.Contract.Code;
		//				(archiveControl as WebControllers.ArchiveDocument.JArchiveControl).SaveToArchive();
		//				return true;
		//			}
		//			else
		//				return false;
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		JSystem.Except.AddException(ex);
		//		return false;
		//	}
		//}

		//public bool CheckData()
		//{
		//	try
		//	{
		//		btmSearchGround_Click(null, null);

		//		if (!(Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["NoFinance"]))))
		//			if (_FinanceCode <= 0)
		//			{
		//				JMessages.Information("Please Enter FinanceCode", "Information");
		//				return false;
		//			}
		//		if (cmbSubject.SelectedValue == null)
		//		{
		//			JMessages.Information("Please Enter Subject", "Information");
		//			return false;
		//		}
		//		/// در صورتی که قرارداد باید با شماره و تاریخ ثبت شود (در تنظیمات نوع قرارداد مشخص میشود)
		//		if (txtContractNumber.Enabled)
		//		{
		//			if (txtContractNumber.Text.Trim() == "")
		//			{
		//				JMessages.Information("لطفا شماره قرارداد را وارد کنید", "Information");
		//				return false;
		//			}

		//			if (txtdateEnd.Visible && txtdateStart.Visible)
		//				if (DateTime.Compare(txtdateStart.Date, txtdateEnd.Date) >= 0)
		//				{
		//					JMessages.Information("Please Enter Campare Date", "Information");
		//					return false;
		//				}
		//			if (txtDate.Date.Date == DateTime.MinValue)
		//			{
		//				JMessages.Information("Please Enter Date", "Information");
		//				return false;
		//			}
		//			//if (txtDateDeliver.Visible)
		//			//    if (txtDateDeliver.Date == DateTime.MinValue)
		//			//{
		//			//    JMessages.Information("Please Enter DateDeliver", "Information");
		//			//    return false;
		//			//}
		//			if (txtdateStart.Visible)
		//				if (txtdateStart.Date == DateTime.MinValue)
		//				{
		//					JMessages.Information("Please Enter StartDate", "Information");
		//					return false;
		//				}
		//			if (txtdateEnd.Visible)
		//				if (txtdateEnd.Date == DateTime.MinValue)
		//				{
		//					JMessages.Information("Please Enter EndDate", "Information");
		//					return false;
		//				}
		//			if (cmbSubject.SelectedValue == null)
		//			{
		//				JMessages.Information("Please Enter Subject", "Information");
		//				return false;
		//			}
		//			if (cmbLocation.SelectedItem == null)
		//			{
		//				JMessages.Information("Please Enter Location", "Information");
		//				return false;
		//			}
		//			if (!(Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["NoFinance"]))))
		//				if (JDistraint.CheckAssetIsBlock(_FinanceCode, txtDate.Date))
		//				{
		//					JMessages.Error("این دارایی توقیف شده است. امکان ثبت قرارداد وجود ندارد", "خطا");
		//					return false;
		//				}
		//		}
		//		return true;
		//	}
		//	catch (Exception ex)
		//	{
		//		JSystem.Except.AddException(ex);
		//		JMessages.Error("با مدیر سیستم تماس بگیرید", "خطا");
		//		return false;
		//	}
		//}

		#endregion Methods

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			JDialog1.DivForLoad = JAssetSearchControl_Div.ClientID;
			JDialog1.AutoOpen = false;
			JDialog1.IsModal = true;
			//(JAssetSearchControl as WebControllers.MainControls.JUserControl).ControlToSet = hdnFinanceCode.ClientID;
			//(JAssetSearchControl as WebControllers.MainControls.JUserControl).PropertyToSet = "value";
			//(JAssetSearchControl as WebControllers.MainControls.JUserControl).ExtraField = "Code";
			JDialog1.Buttons = new List<JJson.JDialogButton>();
			JDialog1.Buttons.Add(new JJson.JDialogButton() { Caption = "انتخاب", Actions = new List<JJson.JsonResponse>() { new JJson.JsonResponse() { Params = new List<JJson.JsonResponseParam>() { new JJson.JsonResponseParam() { Action = JJson.JsonAction.Value, ControlToSet = hdnPersonId.ClientID } } } } });

			#region btnSearchGround_Settings
			JJson.JsonResponse btnSearchGround_res = new JJson.JsonResponse();
			btnSearchGround_res.Type = JJson.JsonResponseType.Row;
			btnSearchGround_res.Params = new List<JJson.JsonResponseParam>();
			btnSearchGround_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Condition, ReturnField = "ClassName", Condition = new List<JJson.JsonConditionParam>() { new JJson.JsonConditionParam() { Condition = "=='-1'", Action = JJson.JsonAction.ConditionalMessage, Message = "خطا رخداده است" } } });
			btnSearchGround_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = hdnSearchGroundResultClassName.ClientID, Action = JJson.JsonAction.Value, ReturnField = "ClassName", Name = "ClassName" });
			btnSearchGround_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = hdnSearchGroundResultCode.ClientID, Action = JJson.JsonAction.Value, Name = "Code", ReturnField = "Code" });
			btnSearchGround.OnSuccessControlsAction = new List<JJson.JsonResponse>() { btnSearchGround_res };
			JJson.JsonRequest btnSearchGround_req = new JJson.JsonRequest();
			btnSearchGround_req.URL = "JJsonService/JJsonService.asmx/Run";
			btnSearchGround_req.Type = JJson.JsonRequestType.Classes;
			btnSearchGround_req.data = "JJsonAdditionalLibrary.WebLegal.Contract.Forms.SubjectContract.JSubjectContract->PreSearchGround";
			btnSearchGround_req.Params = new List<JJson.JsonRequestParam>();
			//btnSearchGround_req.Params.Add(new JJson.JsonRequestParam() { Name = "FinanceCode", Type = JJson.JsonAction.Value, ControlID = hdnFinanceCode.ClientID });
			//btnSearchGround_req.Params.Add(new JJson.JsonRequestParam() { Name = "NoFinance", Type = JJson.JsonAction.Value, ControlID = hdnNoFinance.ClientID });
			btnSearchGround_req.Params.Add(new JJson.JsonRequestParam() { Name = "SubjectCode", Type = JJson.JsonAction.Value, ControlID = cmbSubject.ClientID });
			btnSearchGround.Request = new List<JJson.JsonRequest>() { btnSearchGround_req };

			JJson.JsonResponse btnSearchGround_res2 = new JJson.JsonResponse();
			btnSearchGround_res2.Type = JJson.JsonResponseType.Item;
			btnSearchGround_res2.Params = new List<JJson.JsonResponseParam>();
			btnSearchGround_res2.Params.Add(new JJson.JsonResponseParam() { ControlToSet = "dialogDiv", Action = JJson.JsonAction.Message });
			btnSearchGround.OnSuccessControlsAction.Add(btnSearchGround_res2);
			JJson.JsonRequest btnSearchGround_req2 = new JJson.JsonRequest();
			btnSearchGround_req2.URL = "JJsonService/JJsonService.asmx/Run";
			btnSearchGround_req2.Type = JJson.JsonRequestType.LoadControl;
			//btnSearchGround_req2.data = "WebFinance/Asset/JAssetSearchControl.ascx";
			btnSearchGround_req2.Params = new List<JJson.JsonRequestParam>();
			btnSearchGround_req2.Params.Add(new JJson.JsonRequestParam() { ControlID = JAssetSearchControl_Div.ClientID });
			//btnSearchGround_req2.Params.Add(new JJson.JsonRequestParam() { Name = "uc", Type = JJson.JsonAction.Constant, Value = "http://localhost:6366/WebFinance/Asset/JAssetSearchControl.ascx" });
			//btnSearchGround_req2.Params.Add(new JJson.JsonRequestParam() { Name = "pCheckActiveAssetShares", Type = JJson.JsonAction.Constant, Value = "false" });
			//btnSearchGround_req2.Params.Add(new JJson.JsonRequestParam() { Name = "pClassName", Type = JJson.JsonAction.Value, ControlID = hdnSearchGroundResultClassName.ClientID });
			//btnSearchGround_req2.Params.Add(new JJson.JsonRequestParam() { Name = "pContractTypeCode", Type = JJson.JsonAction.Value, ControlID = hdnSearchGroundResultCode.ClientID });
			btnSearchGround.Request.Add(btnSearchGround_req2);

			List<JJson.JsonValidation> btnSearchGround_validations = new List<JJson.JsonValidation>();
			//btnSearchGround_validations.Add(new JJson.JsonValidation() { ControlID = Control.ClientID, ValueType = JJson.JsonAction.Value, Message = "Validation message", RegexType = JJson.JsonRegexType.Alphanumeric });
			//btnSearchGround.Validations = btnSearchGround_validations;
			JJson.JsonResponse btnSearchGround_error = new JJson.JsonResponse();
			btnSearchGround_error.Params = new List<JJson.JsonResponseParam>();
			btnSearchGround_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			btnSearchGround.OnErrorControlsAction = new List<JJson.JsonResponse>() { btnSearchGround_error };
			#endregion
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			lblCode.Text = "0";
			Fill_Data();
			if (!int.TryParse(Request["Code"], out Code))
				return;
			//Contract = new JSubjectContract(Code);
			lblCode.Text = Code.ToString();
			ContractForms = new JContractForms(Code);
		}

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			txtbSubjectComment.Text = txtDate.Date.ToString();
		}
	}
}