using Estates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEstate.Land.Land
{
	public partial class JNewLandsControl : System.Web.UI.UserControl
	{
		private JLand newLand;
		int code = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			newLand = new JLand();
			(archiveControl as WebControllers.ArchiveDocument.JArchiveControl).ClassName = newLand.GetType().FullName;
			if (!int.TryParse(Request["Code"], out code))
				return;
			FillForm();
			(archiveControl as WebControllers.ArchiveDocument.JArchiveControl).ObjectCode = code;
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			#region btnOK_Settings
			JJson.JsonResponse btnOK_res = new JJson.JsonResponse();
			btnOK_res.Type = JJson.JsonResponseType.Item;
			btnOK_res.Params = new List<JJson.JsonResponseParam>();
			btnOK_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Condition, ReturnField = "return field", Condition = new List<JJson.JsonConditionParam>() { new JJson.JsonConditionParam() { Condition = "=='true'", Action = JJson.JsonAction.CloseWindowAndRefreshGrid, Message = "" }, new JJson.JsonConditionParam() { Condition = "=='false'", Action = JJson.JsonAction.ConditionalMessage, Message = "عملیات با خطا مواجه شده است. لطفاً مجددا سعی نمایید" } } });
			btnOK.OnSuccessControlsAction =new List<JJson.JsonResponse>(){ btnOK_res};
			JJson.JsonRequest btnOK_req = new JJson.JsonRequest();
			btnOK_req.URL = "JJsonService/JJsonService.asmx/Run";
			btnOK_req.Type = JJson.JsonRequestType.Classes;
			btnOK_req.data = "JJsonAdditionalLibrary.WebEstate.Land.Land.JLands->Insert";
			btnOK_req.Params = new List<JJson.JsonRequestParam>();
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Code", Type = JJson.JsonAction.Html, ControlID = lblCode.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Name", Type = JJson.JsonAction.Value, ControlID = txtName.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Area", Type = JJson.JsonAction.Value, ControlID = numArea.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Section", Type = JJson.JsonAction.Value, ControlID = txtSection.ClientID });
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Plaque", Type = JJson.JsonAction.Value, ControlID = txtPlaque.ClientID });
			btnOK.Request =new List<JJson.JsonRequest>(){ btnOK_req};
			JJson.JsonResponse btnOK_error = new JJson.JsonResponse();
			btnOK_error.Params = new List<JJson.JsonResponseParam>();
			btnOK_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			btnOK.OnErrorControlsAction =new List<JJson.JsonResponse>(){ btnOK_error};
			#endregion

			
		}

		void FillForm()
		{
			newLand = new JLand(code);
			lblCode.Text = newLand.Code.ToString();
			txtName.Text = newLand.Name;
			txtPlaque.Text = newLand.Plaque;
			numArea.Text = newLand.Area.ToString();
			txtSection.Text = newLand.Section;
		}

		protected void btnExit_Click(object sender, EventArgs e)
		{
			WebClassLibrary.JWebManager.CloseWindow();
		}
	}
}