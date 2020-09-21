using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSClassLibrary;
using CMSClassLibrary.Components;
using CMSClassLibrary.Controls;
using System.Data;
using JJson;
using System.Reflection;

namespace CMS
{
    public partial class Index : System.Web.UI.UserControl
    {
        JSignup signup;
        JLogin login;
        JSlider slider;
        JMenu menu;
        //Image logo1;
        Image logo;
        Label title;
        JJsonTabs News;
        public string URL;
        JContentManager cManager;
        JContentManager jside1;
        JContentManager jside2;
        JContentManager jside3;
        int sCode;
        object[] controls = new object[50];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
               URL = HttpContext.Current.Request.Url.AbsoluteUri;

                //URL = "footwearcluster.ir";
                DataTable sites = CMSClassLibrary.Site.JSites.GetDataTable("Domain like '%" + URL + "%'");
                if (sites != null)
                    if (sites.Rows.Count > 0)
                    {
                        WebClassLibrary.SessionManager.Current.Session.Add("SiteCode", sites.Rows[0]["Code"]);
                    }
                if(WebClassLibrary.SessionManager.Current.Session["SiteCode"] != null)
                {
                    sCode = Int32.Parse(WebClassLibrary.SessionManager.Current.Session["SiteCode"].ToString());
                    DataTable AllModules = CMSClassLibrary.Module.JModules.GetDataTable("Site=" + sCode.ToString());
                    CMSClassLibrary.Extension.JExtension ModuleExtension = new CMSClassLibrary.Extension.JExtension();
                    if (AllModules != null)
                        if (AllModules.Rows.Count > 0)
                        {
                            for(int i=0;i<AllModules.Rows.Count;i++)
                            {
                                ModuleExtension.GetData(Int32.Parse(AllModules.Rows[i]["ExtCode"].ToString()));
                                Assembly assembly =Assembly.Load(ModuleExtension.ClassName.Split('.')[0]);
                                Type type = assembly.GetType(ModuleExtension.ClassName);
                                object instance = Activator.CreateInstance(type,AllModules.Rows[i]["Parameters"].ToString());
                                controls[i] = instance;
                            }
                        }
                }
                //top position
                slider = (CMSClassLibrary.Components.JSlider)controls[0];
                // content position
                if (controls[1] is CMSClassLibrary.Components.JMenu)
                    menu = (CMSClassLibrary.Components.JMenu)controls[1];
                else if (controls[1] is JContentManager)
                {
                    jside1 = (JContentManager)controls[1];
                    esteellbl.Text = ClassLibrary.JLanguages._Text(jside1.Name);
                }
                //side position
                if (controls[2] is JContentManager)
                {
                    jside1 = (JContentManager)controls[2];
                    esteellbl.Text = ClassLibrary.JLanguages._Text(jside1.Name);
                }
               
                if(controls[3] is JContentManager)
                {
                    jside2 = (JContentManager)controls[3];
                    Rahatilbl.Text = ClassLibrary.JLanguages._Text(jside2.Name);

                }
                if(controls[4] is JContentManager)
                {
                    jside3 = (JContentManager)controls[4];
                    khablbl.Text = ClassLibrary.JLanguages._Text(jside3.Name);

                }
                else if (controls[4] is JMenu)
                    menu = (JMenu)controls[4];

                signup = new JSignup();
                login = new JLogin();
                News = new JJsonTabs();
                logo = new Image();
                title = new Label();

                cManager = new JContentManager();
                CMSClassLibrary.Content.JContent content = new CMSClassLibrary.Content.JContent();
                content.GetData(8);
                cManager.Mode = JJson.JCManager.View;
                cManager.content = content.Text;

                logo.Width = 100;
                logo.Height = 100;
                logo.ImageUrl = "Images/n.jpg";

                Loginlbl.Text = ClassLibrary.JLanguages._Text("Login");
               // Edarilbl.Text = ClassLibrary.JLanguages._Text("مبلمان اداری و دفتری");
               
            }
        }

        protected override void CreateChildControls()
        {
           // base.CreateChildControls();
            if(sCode == 2)
                signupPlace.Controls.Add(cManager);
            loginPlace.Controls.Add(login);
            if(slider != null)
                sliderPlace.Controls.Add(slider);
            if(menu != null)
                menuPlace.Controls.Add(menu);
            System.Web.UI.Page page = new Page();
            if(sCode ==1)
                Logo2.Controls.Add(logo);
            if(jside1 != null)
                Side1.Controls.Add(jside1);
            if(jside2 != null)
                Side2.Controls.Add(jside2);
            if(jside3 != null)
                Side3.Controls.Add(jside3);
            //CMSClassLibrary.Core.Base TManager = new CMSClassLibrary.Core.Base();
           // TManager.Render(this.Page,this);
           
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            JJson.Methods.RegisterTabScript(this.Page,this.ClientID);
            #region menu_Settings
            JJson.JsonResponse menu_res = new JJson.JsonResponse();
            menu_res.Type = JJson.JsonResponseType.Item;
            menu_res.Params = new List<JJson.JsonResponseParam>();
            menu_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.JText, ControlToSet = cManager.ClientID + "_text", Value = "show();" });
            menu_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = cManager.ClientID, Action = JJson.JsonAction.Content, ReturnField = "Return_Field_Name_On_Response" });
            JJson.JsonResponse menu_res2 = new JJson.JsonResponse();
            menu_res2.Type = JJson.JsonResponseType.Item;
            menu_res2.Params = new List<JJson.JsonResponseParam>();
            menu_res2.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Condition, ReturnField = "Return_Field_Name_On_Response", Condition = new List<JJson.JsonConditionParam>() { new JJson.JsonConditionParam() { Condition = "=='true'", Action = JJson.JsonAction.ConditionalValue, Message = slider.ClientID + "|hide()" }, new JJson.JsonConditionParam() { Condition = "=='false'", Action = JJson.JsonAction.ConditionalValue, Message = slider.ClientID + "|show()" } } });
            menu.OnSuccessControlsAction = new List<JJson.JsonResponse>() { menu_res, menu_res2 };
            JJson.JsonRequest menu_req = new JJson.JsonRequest();
            menu_req.URL = "../JJsonService/JJsonService.asmx/Run";
            // menu_req.URL = "C:/www/moblart/moblart.ir/wwwroot/jjsonService/JJsonService.asmx/Run";
            menu_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->getContent";
            menu_req.Type = JJson.JsonRequestType.Classes;
            menu_req.Params = new List<JJson.JsonRequestParam>();
            menu_req.Params.Add(new JJson.JsonRequestParam() { Name = "ModuleId", Type = JJson.JsonAction.Gender, ControlID = menu.ClientID });
            // menu_req.Params.Add(new JJson.JsonRequestParam() { Name = "PlaceId", Type = JJson.JsonAction.Constant,Value=signupPlace.ClientID });
            JJson.JsonRequest menu_req2 = new JJson.JsonRequest();
            menu_req2.URL = "../JJsonService/JJsonService.asmx/Run";
            //menu_req2.URL = "C:/www/moblart/moblart.ir/wwwroot/jjsonService/JJsonService.asmx/Run";
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

			
			
        }

        
    }
}