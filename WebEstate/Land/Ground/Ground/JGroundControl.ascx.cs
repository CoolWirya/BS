using ClassLibrary;
using Estates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEstate.Land.Ground.Ground
{
	public partial class JGroundControl : System.Web.UI.UserControl
	{
		int code = 0;
		public Estates.JGround _newGround = new Estates.JGround();
		private void FillComboBox()
		{
			cmbLand.ClearSelection();
			cmbUsage.ClearSelection();
			cmbDocumentType.ClearSelection();
			cmbEstateType.ClearSelection();
			JLands lands = new JLands();
			for (int i = 0; i < lands.Items.Count(); i++)
				cmbLand.Items.Add(new ListItem() { Text = lands.Items[i].Name, Value = lands.Items[i].Code.ToString(), Selected = i == 0 });
			JUsageGrounds Usages = new JUsageGrounds();
			Usages.GetData();
			for (int i = 0; i < Usages.items.Count(); i++)
				cmbUsage.Items.Add(new ListItem() { Text = Usages.items[i].Name, Value = Usages.items[i].Code.ToString(), Selected = i == 0 });
			txtArea.Text = Convert.ToString(_newGround.Area);
			JEstateTypes EsType = new JEstateTypes();
			EsType.SetDropDownList(cmbEstateType, _newGround.EstateType);
			//foreach (JSubBaseDefine Type in EsType.Items)
			//{
			//    cmbEstateType.Items.Add(Type);
			//    if (_newGround.EstateType != 0 && _newGround.EstateType == Type.Code)
			//        cmbEstateType.SelectedItem = Type;
			//}

			JDocumentTypes DTypes = new JDocumentTypes();
			DTypes.SetDropDownList(cmbDocumentType, _newGround.DocumentType);
			//foreach (JSubBaseDefine DType in DTypes.Items)
			//{
			//    cmbDocumentType.Items.Add(DType);
			//    if (_newGround.DocumentType != 0 && _newGround.DocumentType == DType.Code)
			//        cmbDocumentType.SelectedItem=DType;
			//}
		}
		private void FillForm()
		{
			_newGround = new Estates.JGround(code);
			lblCode.Text = _newGround.Code.ToString();
			txtMainAve.Text = _newGround.MainAve;
			txtSubAve.Text = _newGround.SubNo;
			txtBlockNum.Text = _newGround.BlockNum;
			txtPartNum.Text = _newGround.PartNum;
			txtArea.Text = _newGround.Area.ToString();
			edtDescriptionEditor.Content = _newGround.Comment;
			if (_newGround.EstateType != null && _newGround.EstateType > 0)
				cmbEstateType.SelectedValue = _newGround.EstateType.ToString();
			if (_newGround.DocumentType != null && _newGround.DocumentType > 0)
				cmbDocumentType.SelectedValue = _newGround.DocumentType.ToString();
			txtCost.Text = _newGround.Cost.ToString();
			if (_newGround.DocumentNumber != null)
				txtNumDocument.Text = _newGround.DocumentNumber.ToString();
			chkRightRoot.Checked = _newGround.RightRoot;
			gvPrimaryOwners.DataSource = _newGround.PrimeryOwners;
			gvPrimaryOwners.DataBind();
			////RadTabStrip1.SelectedIndex = 5;
			//if ((gvContractDefinition.DataSource != null) && ((gvContractDefinition.DataSource as DataTable).Rows.Count > 0))
			//{
			//	btnAddPrimaryOwner.Enabled = false;
			//	btnRemovePrimaryOwner.Enabled = false;
			//}
			////RadTabStrip1.SelectedIndex = 0;

		}
		private void SetDefinitContractGrid(int pAssetCode)
		{
			gvOwnersMainContract.DataSource = Legal.JSubjectContracts.ContractHistory(pAssetCode, Finance.JOwnershipType.Definitive);
			(gvOwnersMainContract.DataSource as DataTable).Select("Share <> 0");
			//gvOwnersMainContract.Columns["StartDate"].Visible = false;
			//gvOwnersMainContract.Columns["EndDate"].Visible = false;
			//gvOwnersMainContract.Columns["GoodwillPrice"].Visible = false;
			//gvOwnersMainContract.Columns["Price"].Visible = false;
			//gvOwnersMainContract.Columns["PriceMonth"].Visible = false;
		}
		private void SetRentContractGrid(int pAssetCode)
		{
			gvOwnersRentalContract.DataSource = Legal.JSubjectContracts.ContractHistory(pAssetCode, Finance.JOwnershipType.Rentals);
			//gvOwnersRentalContract.Columns["TotalPrice"].Visible = false;
			//gvOwnersRentalContract.Columns["GoodwillPrice"].Visible = false;
			//gvOwnersRentalContract.Columns["Share"].Visible = false;
		}
		private List<JAction> CreateActions(int pContractCode, int pPersonCode)
		{
			List<JAction> actions = new List<JAction>();
			/// اکشن مشاهده قرارداد
			if (pContractCode > 0)
			{
				Legal.JSubjectContract contract = new Legal.JSubjectContract(pContractCode);
				Legal.JContractdefine contractDefine = new Legal.JContractdefine(contract.Type);
				Legal.JContractDynamicType DynamicType = new Legal.JContractDynamicType(contractDefine.ContractType);

				JAction splitter = new JAction("-", "");
				//JAction ReapirAction = new JAction("RepairContract...", "Legal.JRepairContractForm.Show", null, new object[] { contract.Code });
				//actions.Add(ReapirAction);

				///// تعیین قرارداد جاری
				//JAction SetAsCurrentContract = new JAction("SetAsCurrentContract...", "Legal.JSubjectContract.SetAsCurrentContract", new object[] { contract.FinanceCode, contract.Code, DynamicType.AssetTransferType }, null);
				//actions.Add(SetAsCurrentContract);

				//actions.Add(splitter);

				if (JPermission.CheckPermission("Legal.JGeneralContract.ShowForms", contractDefine.ContractType, JMainFrame.CurrentPostCode, false))
				{
					//JAction ShowWordCurrentContract = OfficeWord.JWordForm.getAction("Legal.JContractForms", pContractCode, true);
					//actions.Add(ShowWordCurrentContract);
				}
				JAction CancelAction = new JAction("Dissolution...", "Legal.JSubjectContract.CancelContract", null, new object[] { contract.Code });
				actions.Add(CancelAction);

				JAction editContract = new JAction("EditContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, false });
				actions.Add(editContract);

				JAction viewContract = new JAction("viewContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, true });
				actions.Add(viewContract);

				actions.Add(splitter);

				JAction HistoryOwner = new JAction("HistoryOwner...", "Estates.Land.Ground.Ground.HistoryOwner.FormHistoryOwner.ShowDialog", null, new object[] { pContractCode, pPersonCode }, true);
				actions.Add(HistoryOwner);

			}
			///  مشخصات شخص
			int pCode = pPersonCode;
			JAction personAction = new JAction();
			JAllPerson allPerson = new JAllPerson(pCode);
			if (allPerson.PersonType == JPersonTypes.RealPerson)
				personAction = new JAction("PersonInfo...", "ClassLibrary.JPerson.ShowDialog", new object[] { true }, new object[] { pCode });
			else if (allPerson.PersonType == JPersonTypes.LegalPerson)
				personAction = new JAction("PersonInfo...", "ClassLibrary.JOrganization.ShowDialog", new object[] { true }, new object[] { pCode });
			actions.Add(personAction);
			return actions;
		}
		private List<JAction> CreateOwnersActions(int pContractCode, int pPersonCode)
		{
			List<JAction> actions = new List<JAction>();
			/// اکشن مشاهده قرارداد
			if (pContractCode > 0)
			{
				Legal.JSubjectContract contract = new Legal.JSubjectContract(pContractCode);
				Legal.JContractdefine contractDefine = new Legal.JContractdefine(contract.Type);
				Legal.JContractDynamicType DynamicType = new Legal.JContractDynamicType(contractDefine.ContractType);
				JAction viewContract = new JAction("ContractInformation...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, false });
				actions.Add(viewContract);
			}
			/// اکشن فسخ قرارداد
			if (pContractCode > 0)
			{
				Legal.JSubjectContract contract = new Legal.JSubjectContract(pContractCode);
				Legal.JContractdefine contractDefine = new Legal.JContractdefine(contract.Type);
				Legal.JContractDynamicType DynamicType = new Legal.JContractDynamicType(contractDefine.ContractType);
				JAction CancelAction = new JAction("Dissolution...", "Legal.JSubjectContract.CancelContract", null, new object[] { contract.Code });
				actions.Add(CancelAction);
			}
			///  مشخصات شخص
			int pCode = pPersonCode;
			JAction personAction = new JAction();
			JAllPerson allPerson = new JAllPerson(pCode);
			if (allPerson.PersonType == JPersonTypes.RealPerson)
				personAction = new JAction("PersonInfo...", "ClassLibrary.JPerson.ShowDialog", new object[] { true }, new object[] { pCode });
			else if (allPerson.PersonType == JPersonTypes.LegalPerson)
				personAction = new JAction("PersonInfo...", "ClassLibrary.JOrganization.ShowDialog", new object[] { true }, new object[] { pCode });
			actions.Add(personAction);
			return actions;
			///  مشخصات تعرفه
			if (pContractCode > 0)
			{
				//JAction viewContract = new JAction("TarefeInformation...", "Estates.JSheetGroundForm.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, false });
				//actions.Add(viewContract);
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			#region cmbLand_Settings
			JJson.JsonResponse cmbLand_res = new JJson.JsonResponse();
			cmbLand_res.Type = JJson.JsonResponseType.Item;
			cmbLand_res.Params = new List<JJson.JsonResponseParam>();
			cmbLand_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = txtSection.ClientID, Action = JJson.JsonAction.Value });
			cmbLand.OnSuccessControlsAction = new List<JJson.JsonResponse>() { cmbLand_res };
			JJson.JsonRequest cmbLand_req = new JJson.JsonRequest();
			cmbLand_req.URL = "JJsonService/JJsonService.asmx/Run";
			cmbLand_req.Type = JJson.JsonRequestType.Classes;
			cmbLand_req.data = "JJsonAdditionalLibrary.WebEstate.Land.Ground.Ground.JGround->cmbLand_OnChanged";
			cmbLand_req.Params = new List<JJson.JsonRequestParam>();
			cmbLand_req.Params.Add(new JJson.JsonRequestParam() { Name = "Land", Type = JJson.JsonAction.Value, ControlID = cmbLand.ClientID });
			cmbLand.Request = new List<JJson.JsonRequest>() { cmbLand_req };
			JJson.JsonResponse cmbLand_error = new JJson.JsonResponse();
			cmbLand_error.Params = new List<JJson.JsonResponseParam>();
			cmbLand_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			cmbLand.OnErrorControlsAction = new List<JJson.JsonResponse>() { cmbLand_error };
			#endregion

			#region btnOK_Settings
			JJson.JsonResponse btnOK_res = new JJson.JsonResponse();
			btnOK_res.Type = JJson.JsonResponseType.RefreshGridAndClose;
			btnOK_res.Params = new List<JJson.JsonResponseParam>();
			btnOK_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message, ReturnField = "Return_Field_Name_On_Response" });
			btnOk.OnSuccessControlsAction = new List<JJson.JsonResponse>() { btnOK_res };
			JJson.JsonRequest btnOK_req = new JJson.JsonRequest();
			btnOK_req.URL = "JJsonService/JJsonService.asmx/Run";
			btnOK_req.Type = JJson.JsonRequestType.Classes;
			btnOK_req.data = "JJsonAdditionalLibrary.WebEstate.Land.Ground.Ground.JGround->Insert";
			btnOK_req.Params = new List<JJson.JsonRequestParam>();
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Code", Type = JJson.JsonAction.Html, ControlID = lblCode.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Land", Type = JJson.JsonAction.Value, ControlID = cmbLand.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "MainAve", Type = JJson.JsonAction.Value, ControlID = txtMainAve.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "SubNo", Type = JJson.JsonAction.Value, ControlID = txtSubAve.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "PartNum", Type = JJson.JsonAction.Value, ControlID = txtPartNum.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "BlockNum", Type = JJson.JsonAction.Value, ControlID = txtBlockNum.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Usage", Type = JJson.JsonAction.Value, ControlID = cmbUsage.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Area", Type = JJson.JsonAction.Value, ControlID = txtArea.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Comment", Type = JJson.JsonAction.Html, ControlID = edtDescriptionEditor.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "EstateType", Type = JJson.JsonAction.Value, ControlID = cmbEstateType.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "DocumentType", Type = JJson.JsonAction.Value, ControlID = cmbDocumentType.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "RightRoot", Type = JJson.JsonAction.CheckState, ControlID = chkRightRoot.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Cost", Type = JJson.JsonAction.Value, ControlID = txtCost.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "DocumentNumber", Type = JJson.JsonAction.Value, ControlID = txtNumDocument.ClientID });
			btnOk.Request = new List<JJson.JsonRequest>() { btnOK_req };
			List<JJson.JsonValidation> btnOK_validations = new List<JJson.JsonValidation>();
			btnOK_validations.Add(new JJson.JsonValidation() { ControlID = cmbLand.ClientID, ValueType = JJson.JsonAction.Value, Message = "اراضی مشخص نشده است", RegexType = JJson.JsonRegexType.Alphanumeric });
			btnOK_validations.Add(new JJson.JsonValidation() { ControlID = cmbUsage.ClientID, ValueType = JJson.JsonAction.Value, Message = "کاربری مشخص نشده است", RegexType = JJson.JsonRegexType.Alphanumeric });
			btnOK_validations.Add(new JJson.JsonValidation() { ControlID = txtMainAve.ClientID, ValueType = JJson.JsonAction.Value, Message = "پلاک اصلی را وارد کنید", RegexType = JJson.JsonRegexType.Alphanumeric });
			btnOK_validations.Add(new JJson.JsonValidation() { ControlID = txtArea.ClientID, ValueType = JJson.JsonAction.Value, Message = "مساحت زمین برابر صفر می باشد", RegexType = JJson.JsonRegexType.NonZeroDecimal });
			btnOk.Validations = new List<List<JJson.JsonValidation>>() { btnOK_validations };
			JJson.JsonResponse btnOK_error = new JJson.JsonResponse();
			btnOK_error.Params = new List<JJson.JsonResponseParam>();
			btnOK_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			btnOk.OnErrorControlsAction = new List<JJson.JsonResponse>() { btnOK_error };
			#endregion

			#region btnAddPrimaryOwner_Settings
			//JJson.JsonResponse btnAddPrimaryOwner_res = new JJson.JsonResponse();
			//btnAddPrimaryOwner_res.Type = JJson.JsonResponseType.Dialog;
			//btnAddPrimaryOwner_res.Params = new List<JJson.JsonResponseParam>();
			//btnAddPrimaryOwner_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = "dialogDiv", Action = JJson.JsonAction.Html });
			//btnAddPrimaryOwner.OnSuccessControlsAction = btnAddPrimaryOwner_res;
			//JJson.JsonRequest btnAddPrimaryOwner_req = new JJson.JsonRequest();
			//btnAddPrimaryOwner_req.URL = "WebControllers/JJsonServices/JJsonService.asmx/Run";
			//btnAddPrimaryOwner_req.Type = JJson.JsonRequestType.LoadControl;
			//btnAddPrimaryOwner_req.Params = new List<JJson.JsonRequestParam>();
			//btnAddPrimaryOwner_req.Params.Add(new JJson.JsonRequestParam() { Name = "uc", Type = JJson.JsonAction.Constant, Value = "MainControls/Persons/JSearchPersonControl.ascx" });
			//btnAddPrimaryOwner.Request = btnAddPrimaryOwner_req;
			//JJson.JsonResponse btnAddPrimaryOwner_error = new JJson.JsonResponse();
			//btnAddPrimaryOwner_error.Params = new List<JJson.JsonResponseParam>();
			//btnAddPrimaryOwner_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			//btnAddPrimaryOwner.OnErrorControlsAction = btnAddPrimaryOwner_error;
			#endregion

			#region btnAddPrimaryOwner_Sahm_Settings
			JJson.JsonResponse btnAddPrimaryOwner_Sahm_res = new JJson.JsonResponse();
			btnAddPrimaryOwner_Sahm_res.Type = JJson.JsonResponseType.RefreshGridAndClose;
			btnAddPrimaryOwner_Sahm_res.Params = new List<JJson.JsonResponseParam>();
			btnAddPrimaryOwner_Sahm_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message, ReturnField = "Return_Field_Name_On_Response" });
			btnAddPrimaryOwner_Sahm.OnSuccessControlsAction = new List<JJson.JsonResponse>() { btnAddPrimaryOwner_Sahm_res };
			JJson.JsonRequest btnAddPrimaryOwner_Sahm_req = new JJson.JsonRequest();
			btnAddPrimaryOwner_Sahm_req.URL = "JJsonService/JJsonService.asmx/Run";
			btnAddPrimaryOwner_Sahm_req.Type = JJson.JsonRequestType.Classes;
			btnAddPrimaryOwner_Sahm_req.data = "JJsonAdditionalLibrary.WebEstate.Land.Ground.Ground.JGround->AddPrimaryOwner";
			btnAddPrimaryOwner_Sahm_req.Params = new List<JJson.JsonRequestParam>();
			btnAddPrimaryOwner_Sahm_req.Params.Add(new JJson.JsonRequestParam() { Name = "POCode", Type = JJson.JsonAction.Value, ControlID = hdnPersonId.ClientID });
			btnAddPrimaryOwner_Sahm_req.Params.Add(new JJson.JsonRequestParam() { Name = "POShare", Type = JJson.JsonAction.Value, ControlID = txtSahm.ClientID });
			btnAddPrimaryOwner_Sahm_req.Params.Add(new JJson.JsonRequestParam() { Name = "POGroundCode", Type = JJson.JsonAction.Html, ControlID = lblCode.ClientID });
			btnAddPrimaryOwner_Sahm.Request = new List<JJson.JsonRequest>() { btnAddPrimaryOwner_Sahm_req };
			List<JJson.JsonValidation> btnAddPrimaryOwner_Sahm_validations = new List<JJson.JsonValidation>();
			btnAddPrimaryOwner_Sahm_validations.Add(new JJson.JsonValidation() { ControlID = txtSahm.ClientID, ValueType = JJson.JsonAction.Value, Message = "مقدار سهم وارد نشده است", RegexType = JJson.JsonRegexType.Numeric });
			btnAddPrimaryOwner_Sahm.Validations = new List<List<JJson.JsonValidation>>() { btnAddPrimaryOwner_Sahm_validations };
			JJson.JsonResponse btnAddPrimaryOwner_Sahm_error = new JJson.JsonResponse();
			btnAddPrimaryOwner_Sahm_error.Params = new List<JJson.JsonResponseParam>();
			btnAddPrimaryOwner_Sahm_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			btnAddPrimaryOwner_Sahm.OnErrorControlsAction = new List<JJson.JsonResponse>() { btnAddPrimaryOwner_Sahm_error };
			#endregion
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			//btnAddPrimaryOwner.OnClientClick = "SearchPersonDialog";
			//(JPersonListControl as WebControllers.MainControls.JPersonListControl).ControlToSet = hdnPersonId.ClientID;
			FillComboBox();
			lblCode.Text = "0";
			if (!int.TryParse(Request["Code"], out code))
				return;
			FillForm();
		}

		protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
		{
			if (e.Tab.PageViewID.ToLower() == "rpvcontractshistory")
			{
				Finance.JAsset Asset = new Finance.JAsset("Estates.JGround", _newGround.Code);
				SetDefinitContractGrid(Asset.Code);
				SetRentContractGrid(Asset.Code);
			}
			else if (e.Tab.PageViewID.ToLower() == "rpvowners")
			{
				gvOwnersMainContract.DataSource = Finance.JAssetTransfer.GetAssetShare(_newGround.Code, "Estates.JGround", Finance.JOwnershipType.Definitive);
				gvOwnersMainContract.DataBind();
				//if (gvOwnersMainContract.Items.Count > 0)
				//{
				//	List<JAction> actions = CreateActions(Convert.ToInt32(gvOwnersMainContract.Items[0].Cells["ContractCode"].Value),
				//	  Convert.ToInt32(gvOwnersMainContract.Items[0].Cells["PCode"].Value));
				//	foreach (JAction action in actions)
				//	{
				//		gvOwnersMainContract.AddAction(action);
				//		gvOwnersMainContract.Columns["ContractCode"].Visible = false;
				//	}
				//}
			}
		}
	}
}