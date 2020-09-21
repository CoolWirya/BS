using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Reflection;

namespace WebERP.Services.DynamicUserControlLoader
{
	public class C630NPage : System.Web.UI.Page
	{
		public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
		{
		}
		public override bool EnableEventValidation
		{
			get
			{
				return base.EnableEventValidation;
			}
			set
			{
				base.EnableEventValidation = false;
			}
		}
		//public string script = "";
	}
    /// <summary>
    /// Summary description for DynamicLoadUserControlService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class DynamicLoadUserControlService : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public string RenderControl(string controlName)
        {
			Page page = new C630NPage();
			HtmlForm form = new HtmlForm();
			UserControl control = page.LoadControl(controlName) as UserControl;
			control.EnableViewState = true;
			form.Controls.Add(control);
			page.Controls.Add(form);
			StringWriter writer = new StringWriter();
			HttpContext.Current.Server.Execute(page, writer, false);
			return writer.ToString();

			//C630NPage pageHolder = new C630NPage();
			//Assembly asm = Assembly.LoadFile(Server.MapPath("~/bin/" + controlName.Substring(0, controlName.IndexOf("/")) + ".dll"));
			//controlName = controlName.Replace('/', '.');
			//Type t = asm.GetType(controlName.Substring(0, controlName.Length - 5));
			//Control ControlToRender = (Control)Activator.CreateInstance(t, null);
			//HtmlForm form = new HtmlForm();
			//form.Controls.Add(ControlToRender);
			////pageHolder.Controls.Add(new HtmlHead("header"));
			////form.Controls.Add(new ScriptManager());
			//StringWriter writer = new StringWriter();
			////pageHolder.Controls.Add(ControlToRender);
			//pageHolder.Controls.Add(form);
			//HttpContext.Current.Server.Execute(pageHolder, writer, false);
			//return writer.ToString();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
