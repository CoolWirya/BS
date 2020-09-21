using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using CMSClassLibrary.Module;
using System.Data;
using CMSClassLibrary.BaseControls;
using System.Reflection;
using CMSClassLibrary.Components;
using System.Web.UI;
using System.IO;
using System.Text;
using CMSClassLibrary.Site;
using System.Web.UI.HtmlControls;


namespace CMSClassLibrary.Core
{
    public class Base
    {
        private string TemplatePath; // Template file path
        private string URL;  // Website url
        private string TemplateName; // Template name
        private string[] Params; // Template parameters
        private string ScriptFolder; // Path to store template scripts
        private string StyleFolder; // Path to store template styles
        HtmlDocument TemplateDoc;
        public Base()
        {
            // These properties should be set from database
           //TemplatePath = "C:/Amini/ERP/WebERP/CMS/TemplateManagement/Templates/Beez/index.html";
            URL = "moblart.ir";
           //ScriptFolder = "C:/Amini/ERP/WebERP/WebERP/Script/Template/";
           //StyleFolder = "C:/Amini/ERP/WebERP/WebERP/Style/Template/";
            TemplatePath = HttpContext.Current.Server.MapPath("~/TemplateManagement/Templates/Beez/index.aspx");
            ScriptFolder = "~/CMS/Script/Template/";
            StyleFolder = "~/CMS/Style/Template/";
           TemplateDoc = new HtmlDocument();
           TemplateDoc.Load(TemplatePath);
 
        }

        // Cunstruct html output to render

        public void Render(Page page, Control control)
        {
            this.SetHeadLink(page);
            this.SetHeadScript(page);

            HtmlNodeCollection nodes = TemplateDoc.DocumentNode.SelectNodes("//jdoc");
            CMSClassLibrary.Extension.JExtension extension=new Extension.JExtension();
            foreach (HtmlNode node in nodes)
            {

                string PositionAttr = node.GetAttributeValue("name", "NOTFOUND");
                DataTable result = JModules.GetDataTable("Position='" + PositionAttr + "'");
                if (result != null)
                {
                    foreach (DataRow dr in result.Rows)
                    {
                        JModule module = new JModule();
                        module.Code = Int32.Parse(dr["Code"].ToString());
                        module.Name = dr["Name"].ToString();
                        module.Parameters = dr["Parameters"].ToString();
                        module.Position = dr["Position"].ToString();
                        module.PosOrder = Int32.Parse(dr["PosOrder"].ToString());
                        module.Site = Int32.Parse(dr["Site"].ToString());
                        module.State = bool.Parse(dr["State"].ToString());
                        module.ExtCode = Int32.Parse(dr["ExtCode"].ToString());
                        extension.GetData(module.ExtCode);

                        // NodeString is a html output from module manager
                        Control ctr = GetModuleHTML(extension.ClassName,module.Parameters,control) as Control;
                        page.FindControl(PositionAttr + "place").Controls.Add(ctr);
                        //string NodeString = GetModuleHTML(extension.ClassName,module.Parameters, control);
                        //HtmlNode NewNode = HtmlNode.CreateNode(NodeString);
                        //node.ParentNode.ReplaceChild(NewNode, node);
                    }
                }

            }
            LiteralControl newcontrol = new LiteralControl(TemplateDoc.DocumentNode.InnerHtml);
            control.Controls.Add(newcontrol);

        }

        public string Invoke(Page page, Control c, string typeName, string methodName)
        {
            Type type = Type.GetType(typeName);
            object instance = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod(methodName);
            Control control = page.LoadControl(type, null);
            //c.Controls.Add(control);
            //return control.ToString();
            var sb = new StringBuilder();
            var htw = new HtmlTextWriter(new System.IO.StringWriter(sb, System.Globalization.CultureInfo.InvariantCulture));
            control.RenderControl(htw);
            return sb.ToString();
        }

        public object GetModuleHTML(string className,string parameters,Control c)
        {
            Assembly assembly = Assembly.Load(className.Split('.')[0]);
            Type type = assembly.GetType(className);
            object instance = Activator.CreateInstance(type, parameters);
            return instance;
            using (Page page = new Page())
            {
                
                Control cc = instance as Control;
                cc.ID = Guid.NewGuid().ToString();
                page.Controls.Add(instance as Control);
                using (StringWriter writer = new StringWriter())
                {
                    HtmlForm f = new HtmlForm();
                    f.Attributes.Add("runat", "server");
                    f.ID = "form1";
                    page.Controls.Add(f);
                    page.FindControl("form1").Controls.Add(instance as Control);
                    HttpContext.Current.Server.Execute(page, writer, false);
                    return writer.ToString();
                }
            }
            
        }

        public IEnumerable<HtmlNode> GetElementByTagName(HtmlNode parent,string name)
        {
            return parent.Descendants(name);
        }

        // Add styleshett and script 

        public void SetHeadScript(Page page)
        {
            HtmlNodeCollection Nodes;
            string src;
            string scriptPath;
                Nodes = TemplateDoc.DocumentNode.SelectNodes("//head//script");
            if(Nodes != null)
            {
                foreach (HtmlNode Node in Nodes)
                {
                        src = Node.GetAttributeValue("src", "NOTFOUND");
                    if (src != "NOTFOUND")
                    {
                        try
                        {
                            scriptPath = Path.GetFullPath(ScriptFolder + src);
                            bool exists = File.Exists(scriptPath);
                            FileInfo info = new FileInfo(scriptPath);
                            if (exists)
                            {
                                //string content = File.ReadAllText(scriptPath);
                                //if (type == "script")
                                //    scriptFolderRealPath = Path.GetFullPath(ScriptFolder + info.Name);
                                //else
                                //    scriptFolderRealPath = Path.GetFullPath(StyleFolder + info.Name);
                                //FileStream NewScript = File.Create(scriptFolderRealPath);
                                //NewScript.Close();
                                //File.WriteAllText(scriptFolderRealPath, content);
                               
                                //script.Remove();
                                // add script node to head element of page
                                LiteralControl l = new LiteralControl();
                                l.Text = "<script src=\"Script/Template/" + info.Name +"\"></script>";
                                page.Header.Controls.Add(l);
                                Node.Remove();
                            }
                            
                        }
                        catch (Exception e)
                        {
                            HttpContext.Current.Response.Write("<script>alert('Script file does not exist.');</script>");
                        }
                        
                    }

                }
            }
            
        }

        public void SetHeadLink(Page page)
        {
            HtmlNodeCollection Nodes;
            string src;
            string scriptPath;
            Nodes = TemplateDoc.DocumentNode.SelectNodes("//head//link");
            if (Nodes != null)
            {
                foreach (HtmlNode Node in Nodes)
                {
                    src = Node.GetAttributeValue("href", "NOTFOUND");
                    if (src != "NOTFOUND")
                    {
                        try
                        {
                           scriptPath = Path.GetFullPath(StyleFolder + src);
                            bool exists = File.Exists(scriptPath);
                            FileInfo info = new FileInfo(scriptPath);
                            if (exists)
                            {
                                // add script node to head element of page
                                System.Web.UI.HtmlControls.HtmlLink Link = new System.Web.UI.HtmlControls.HtmlLink();
                                Link.Href = "Style/Template/" + info.Name;
                                Link.Attributes["rel"] = "stylesheet";
                                page.Header.Controls.Add(Link);
                                Node.Remove();
                            }

                        }
                        catch (Exception e)
                        {
                            HttpContext.Current.Response.Write("<script>alert('Script file does not exist.');</script>");
                        }

                    }

                }
            }
        }
        public int GetSite(string domain)
        {
            int code = 0;
            DataTable result = JSites.GetDataTable("Domain='" + domain + "'");
            if(result != null)
            {
                DataRow dr = result.Rows[0];
                code = Int32.Parse(dr["Code"].ToString());
            }
            return code;
        }
    }
}
