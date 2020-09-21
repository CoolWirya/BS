using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using JJson.BaseControls;

namespace JJson.Components
{
    public class JContentManager : JBaseCompositeControl
    {
        Controls.JJsonEditor Editor;
        Literal Text;
        Controls.JJsonButton btnEdit;
        Controls.JJsonButton btnSave;
        Controls.JJsonButton btnCancel;
        public JCManager Mode { get; set; }
        public JContentManager()
        {
            Editor = new Controls.JJsonEditor();
            Text = new Literal();
            btnEdit = new Controls.JJsonButton();
            btnCancel = new Controls.JJsonButton();
            btnSave=new Controls.JJsonButton();
            this.Mode = JCManager.View;
        }
        
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.Event = JsonCompositeEvent.OnEdited;
            Text.Text = "<div id=\"editor\"><div id=\"" + this.ClientID + "_content\">some content</div></div>";
            Controls.Add(Text);
            btnEdit.Text = "Edit";
            btnEdit.ID = this.ClientID + "_edit";
            btnEdit.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            btnSave.Text = "Save";
            btnSave.ID = this.ClientID + "_save";
            btnSave.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            btnCancel.Text = "Cancel";
            btnCancel.ID = this.ClientID + "_cancel";
            btnCancel.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            //if(Mode==JCManager.View)
                Controls.Add(btnEdit);
           //else
           // {
                Controls.Add(btnCancel);
                Controls.Add(btnSave);
           // }
        }

        
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Methods.RegisterCreateWidget(this.Page, this.ClientID);
          
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            Methods.RegisterJsonScript(Request,OnSuccessControlsAction,OnErrorControlsAction,Validations,this.Page,this.ClientID,this.Event.ToString(),true);
        }
       
    }
}
