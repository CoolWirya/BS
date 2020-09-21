using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSClassLibrary.Components;
using System.Reflection;

namespace CMS.TemplateManagement.Templates.Beez
{
    public partial class index : System.Web.UI.Page
    {
        JMenu menu;
        JSlider slider;
        JContentManager cm;
        CMSClassLibrary.Controls.JList list;
        protected void Page_Load(object sender, EventArgs e)
        {
            Core.Base TManager = new Core.Base();
            List<CMSClassLibrary.Module.JModule> modules = TManager.Render(this.Page, this);
            if(modules != null)
            {
                for(int i=0;i<modules.Count;i++)
                {
                    CMSClassLibrary.Extension.JExtension extension = new CMSClassLibrary.Extension.JExtension();
                    extension.GetData(modules[i].ExtCode);
                    if (extension.ClassName == "CMSClassLibrary.Components.JMenu")
                        menu = this.Page.FindControl(modules[i].Name) as JMenu;
                    if (extension.ClassName == "CMSClassLibrary.Components.JSlider")
                        slider = this.Page.FindControl(modules[i].Name) as JSlider;
                    if (extension.ClassName == "CMSClassLibrary.Components.JContentManager")
                        cm = this.Page.FindControl("home") as JContentManager ;
                    if (extension.ClassName == "CMSClassLibrary.Controls.JList")
                        list = this.Page.FindControl("news") as CMSClassLibrary.Controls.JList;
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
           
            #region menu_Settings
            JJson.JsonResponse menu_res = new JJson.JsonResponse();
            menu_res.Type = JJson.JsonResponseType.Item;
            menu_res.Params = new List<JJson.JsonResponseParam>();
            menu_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.JText, ControlToSet = cm.ClientID + "_text", Value = "fadeOut('slow',function(){$('#" + cm.ClientID + "_text').html(value);$('#" + cm.ClientID + "_text').fadeIn('slow');});" });
           // menu_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = cm.ClientID, Action = JJson.JsonAction.Content, ReturnField = "Return_Field_Name_On_Response" });
            JJson.JsonResponse menu_res2 = new JJson.JsonResponse();
            menu_res2.Type = JJson.JsonResponseType.Item;
            menu_res2.Params = new List<JJson.JsonResponseParam>();
            menu_res2.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Condition, ReturnField = "Return_Field_Name_On_Response", Condition = new List<JJson.JsonConditionParam>() { new JJson.JsonConditionParam() { Condition = "=='true'", Action = JJson.JsonAction.ConditionalValue, Message = slider.ClientID + "|fadeOut('slow')" }, new JJson.JsonConditionParam() { Condition = "=='false'", Action = JJson.JsonAction.ConditionalValue, Message = slider.ClientID + "|fadeIn('slow')" } } });
            menu.OnSuccessControlsAction = new List<JJson.JsonResponse>() { menu_res, menu_res2 };
            JJson.JsonRequest menu_req = new JJson.JsonRequest();
            menu_req.URL = "../../../JJsonService/JJsonService.asmx/Run";
            menu_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->getContent";
            menu_req.Type = JJson.JsonRequestType.Classes;
            menu_req.Params = new List<JJson.JsonRequestParam>();
            menu_req.Params.Add(new JJson.JsonRequestParam() { Name = "ModuleId", Type = JJson.JsonAction.Gender, ControlID = menu.ClientID });
            // menu_req.Params.Add(new JJson.JsonRequestParam() { Name = "PlaceId", Type = JJson.JsonAction.Constant,Value=signupPlace.ClientID });
            JJson.JsonRequest menu_req2 = new JJson.JsonRequest();
            menu_req2.URL = "../../../JJsonService/JJsonService.asmx/Run";
            menu_req2.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->IsHome";
            menu_req2.Type = JJson.JsonRequestType.Classes;
            menu_req2.Params = new List<JJson.JsonRequestParam>();
            menu_req2.Params.Add(new JJson.JsonRequestParam() { Name = "ModuleId", Type = JJson.JsonAction.Gender, ControlID = menu.ClientID });
            menu.Request = new List<JJson.JsonRequest>() { menu_req, menu_req2 };
            JJson.JsonResponse menu_error = new JJson.JsonResponse();
            menu_error.Params = new List<JJson.JsonResponseParam>();
            menu_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            menu.OnErrorControlsAction = new List<JJson.JsonResponse>() { menu_error };
            #endregion

            
            #region list_Settings
            if (list != null)
            {
                JJson.JsonResponse list_res = new JJson.JsonResponse();
                list_res.Type = JJson.JsonResponseType.Item;
                list_res.Params = new List<JJson.JsonResponseParam>();
                list_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.JText, ControlToSet = cm.ClientID + "_text", Value = "fadeOut('slow',function(){$('#" + cm.ClientID + "_text').html(value);$('#" + cm.ClientID + "_text').fadeIn('slow');});" });
                //list_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = cm.ClientID, Action = JJson.JsonAction.Content, ReturnField = "Return_Field_Name_On_Response" });
                list.OnSuccessControlsAction = new List<JJson.JsonResponse>() { list_res };
                JJson.JsonRequest list_req = new JJson.JsonRequest();
                list_req.URL = "../../../JJsonService/JJsonService.asmx/Run";
                list_req.Type = JJson.JsonRequestType.Classes;
                list_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->getText";
                list_req.Params = new List<JJson.JsonRequestParam>();
                list_req.Params.Add(new JJson.JsonRequestParam() { Name = "ContentId", Type = JJson.JsonAction.Gender, ControlID = list.ClientID });
                list.Request = new List<JJson.JsonRequest>() { list_req };
                JJson.JsonResponse list_error = new JJson.JsonResponse();
                list_error.Params = new List<JJson.JsonResponseParam>();
                list_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
                list.OnErrorControlsAction = new List<JJson.JsonResponse>() { list_error };
            }
            #endregion
			
        }
    }
}