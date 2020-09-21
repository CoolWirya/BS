using CMSClassLibrary.BaseControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using JJson;


namespace CMSClassLibrary.Controls
{
    public class JImageUploader : JBaseCompositeControl
    {
        public string Path { get; set; }

       
        public JUploaderType Type { get; set; }

        FileUpload FileUploader;
        Button submit;
        HtmlImage Image;
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Methods.RegisterUploaderScript(this.Page, this.ClientID, "");
        }

        protected override void CreateChildControls()
        {
            this.Event = JsonCompositeEvent.OnUploadCompleted;
            FileUploader = new FileUpload();
            FileUploader.ID = this.ClientID + "_Uploader1";
            FileUploader.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            submit = new Button();
            submit.ID = this.ClientID + "_submit1";
            submit.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            submit.Text = "Submit File";
            Image = new HtmlImage();
            //base.CreateChildControls();
            Controls.Add(FileUploader);
            Controls.Add(submit);
            if (Type == JUploaderType.Image)
            {
                Image.ID = this.ClientID + "_img";
                Image.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                Image.Width = 200;
                Image.Height = 80;
                Controls.Add(Image);
            }
            //Controls.Add(Submit);

        }
       
        public override void RenderControl(System.Web.UI.HtmlTextWriter writer)
        {
         // writer.Write("<input type=\"file\" id=\"" + this.ClientID + "\" name=\"" + this.ClientID + "\" />");
            Methods.RegisterJsonScript(Request, OnSuccessControlsAction, OnErrorControlsAction, Validations, this.Page, this.ClientID, this.Event.ToString(), true);
            base.RenderControl(writer);
        }
    }
}
