using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.ContentManagement
{
    public partial class test : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
            #region btnok_Settings
            JJson.JsonResponse btnok_res = new JJson.JsonResponse();
            btnok_res.Type = JJson.JsonResponseType.Item;
            btnok_res.Params = new List<JJson.JsonResponseParam>();
            btnok_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = txtname.ClientID, Action = JJson.JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
            btnok.OnSuccessControlsAction = new List<JJson.JsonResponse>() { btnok_res};
            JJson.JsonRequest btnok_req = new JJson.JsonRequest();
            btnok_req.URL = "JJsonService/JJsonService.asmx/Run";
            btnok_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->getusername";
            btnok_req.Type = JJson.JsonRequestType.Classes;
            btnok_req.Params = new List<JJson.JsonRequestParam>();
            btnok_req.Params.Add(new JJson.JsonRequestParam() { Name = "UserName", Type = JJson.JsonAction.Value, ControlID = txtlist.ClientID });
            btnok.Request = new List<JJson.JsonRequest>() { btnok_req};
            JJson.JsonResponse btnok_error = new JJson.JsonResponse();
            btnok_error.Params = new List<JJson.JsonResponseParam>();
            btnok_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            btnok.OnErrorControlsAction = new List<JJson.JsonResponse>() { btnok_error};
            #endregion
			
        }
    }
}