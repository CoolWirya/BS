using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CMSClassLibrary.BaseControls;
using JJson;
using System.Reflection;
using System.IO;
using System.Web;

namespace CMSClassLibrary.Components
{
    public class JContentManager : JBaseCompositeControl
    {
        Controls.JJsonEditor Editor;
        Label c;
        Controls.JJsonButton btnEdit;
        Controls.JJsonButton btnSave;
        Controls.JJsonButton btnCancel;
        HiddenField contentId;
        public string content
        {
            get;
            set;
        }
        public JCManager Mode { get; set; }
        public string Name { get; set; }
        public JContentManager()
        {
            Editor = new Controls.JJsonEditor();
            btnEdit = new Controls.JJsonButton();
            btnCancel = new Controls.JJsonButton();
            btnSave=new Controls.JJsonButton();
            this.Mode = JCManager.View;
            contentId = new HiddenField();
            c = new Label();
           
        }
        public JContentManager(string param)
        {
            Editor = new Controls.JJsonEditor();
            btnEdit = new Controls.JJsonButton();
            btnCancel = new Controls.JJsonButton();
            btnSave = new Controls.JJsonButton();
            CMSClassLibrary.Extension.JExtension ModuleExtension = new CMSClassLibrary.Extension.JExtension();
            this.Mode = JCManager.View;
            contentId = new HiddenField();
            c = new Label();
            this.Mode = JCManager.View;
            if (param != null)
            {
                int index = param.IndexOf("[ModuleId=");
                if (index < 0)
                {
                    int ContentId = Int32.Parse(param);
                    CMSClassLibrary.Content.JContent cm = new Content.JContent();
                    cm.GetData(ContentId);
                    this.content = cm.Text;
                    this.Name = cm.Title;
                }
            }
            //else
            //{
            //    string mid = param.Substring(index + 10,(param.IndexOf(';',index)-(index+10)));
            //    CMSClassLibrary.Module.JModule oneModule = new Module.JModule();
            //    oneModule.GetData(Int32.Parse(mid));
            //    ModuleExtension.GetData(Int32.Parse(oneModule.ExtCode.ToString()));
            //    Assembly assembly = Assembly.Load(ModuleExtension.ClassName.Split('.')[0]);
            //    Type type = assembly.GetType(ModuleExtension.ClassName);
            //    object instance = Activator.CreateInstance(type, oneModule.Parameters.ToString());
            //    using (Page page = new Page())
            //    {
            //      //  UserControl userControl = (UserControl)page.LoadControl("Message.ascx");
            //        //(userControl.FindControl("lblMessage") as Label).Text = message;
            //        page.Controls.Add(instance);
            //        using (StringWriter writer = new StringWriter())
            //        {
            //            page.Controls.Add(instance);
            //            HttpContext.Current.Server.Execute(page, writer, false);
            //            return writer.ToString();
            //        }
            //    }
            //}
        }
       
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.Event = JsonCompositeEvent.OnEdited;
            c.ID = this.ClientID + "_text";
            c.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            Controls.Add(c);
            Editor.ID = this.ClientID + "_editor";
            Editor.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            Controls.Add(Editor);
            c.Visible = false;
            Editor.Visible = false;
            if(this.Mode == JCManager.View)
            {
                c.Visible = true;
                c.Text = content;

            }
            else
            {
                Editor.Visible = true;
                Methods.RegisterSetContentScript(this.Page, this.Editor.ClientID, this.content);

            }
            Controls.Add(contentId);
            
            //Controls.Add(Text);
           // Controls.Add(Editor);
           // btnEdit.Text = "Edit";
           // btnEdit.ID = this.ClientID + "_edit";
           // btnEdit.ClientIDMode = System.Web.UI.ClientIDMode.Static;
           // btnSave.Text = "Save";
           // btnSave.ID = this.ClientID + "_save";
           // btnSave.ClientIDMode = System.Web.UI.ClientIDMode.Static;
           // btnCancel.Text = "Cancel";
           // btnCancel.ID = this.ClientID + "_cancel";
           // btnCancel.ClientIDMode = System.Web.UI.ClientIDMode.Static;
           // //if(Mode==JCManager.View)
           //     Controls.Add(btnEdit);
           ////else
           //// {
           //     Controls.Add(btnCancel);
           //     Controls.Add(btnSave);
           //// }
        }

        
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Methods.RegisterCreateWidget(this.Page, this.ClientID);
           // Methods.RegisterEditorContentScript(this.Page, txtText.ClientID, elrteText.ClientID, hdnDateForInsert.ClientID, hdnDateForUpdate.ClientID, UpdateMode.ToString());
            //if(this.Mode == JCManager.Edit)
            //{
            //    #region Value_Settings
            //    JJson.JsonResponse Value_res = new JJson.JsonResponse();
            //    Value_res.Type = JJson.JsonResponseType.Item;
            //    Value_res.Params = new List<JJson.JsonResponseParam>();
            //    Value_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = Editor.ClientID + "_editor", Action = JJson.JsonAction.Editor, ReturnField = "Return_Field_Name_On_Response" });
            //    Value.OnSuccessControlsAction = new List<JsonResponse>() { Value_res };
            //    JJson.JsonRequest Value_req = new JJson.JsonRequest();
            //    Value_req.URL = "WebControllers/JJsonServices/JJsonService.asmx/Run";
            //    Value_req.Type = JsonRequestType.Classes;
            //    Value_req.data = "CMSClassLibrary.Components.JContentManager->changeText";
            //    Value_req.Params = new List<JJson.JsonRequestParam>();
            //    Value_req.Params.Add(new JJson.JsonRequestParam() { Name = "content", Type = JJson.JsonAction.Value, ControlID = Value.ClientID });
            //    Value.Request = new List<JsonRequest>() { Value_req };
            //    JJson.JsonResponse Value_error = new JJson.JsonResponse();
            //    Value_error.Params = new List<JJson.JsonResponseParam>();
            //    Value_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            //    Value.OnErrorControlsAction = new List<JsonResponse>() { Value_error };
            //    #endregion
            //}
            
			
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            Methods.RegisterJsonScript(Request,OnSuccessControlsAction,OnErrorControlsAction,Validations,this.Page,this.ClientID,this.Event.ToString(),true);
        }

      

        public string changeText()
        {
            return content;
        }
       
    }
}
