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


namespace CMS.Core
{
    public class Base
    {
        private string TemplatePath; // Template file path
        private string URL;  // Website url
        private string TemplateName; // Template name
        private string[] Params; // Template parameters
        private string ScriptFolder; // Path to store template scripts
        private string StyleFolder; // Path to store template styles
        private int sCode;// Current Site Code
        HtmlDocument TemplateDoc;
        public Base()
        {
            // These properties should be set from database
           //TemplatePath = "C:/Amini/ERP/WebERP/CMS/TemplateManagement/Templates/Beez/index.html";
           // URL = "moblart.ir";
            URL = HttpContext.Current.Request.Url.AbsoluteUri;
           //ScriptFolder = "C:/Amini/ERP/WebERP/WebERP/Script/Template/";
           //StyleFolder = "C:/Amini/ERP/WebERP/WebERP/Style/Template/";
            TemplatePath = HttpContext.Current.Server.MapPath("~/administrator/CMS/TemplateManagement/Templates/Beez/index.aspx");
            ScriptFolder = "~/CMS/Script/Template/";
            StyleFolder = "~/CMS/Style/Template/";
           TemplateDoc = new HtmlDocument();
           TemplateDoc.Load(TemplatePath);
          // HttpContext.Current.Server.Transfer("~/TemplateManagement/Templates/Beez/index.aspx");
 
        }

        // Cunstruct html output to render

        public List<JModule> Render(Page page, Control control)
        {
                DataTable sites = CMSClassLibrary.Site.JSites.GetDataTable("Domain like '%" + URL + "%'");
                if (sites != null)
                    if (sites.Rows.Count > 0)
                    {
                        WebClassLibrary.SessionManager.Current.Session.Add("SiteCode", sites.Rows[0]["Code"]);
                    }
                if (WebClassLibrary.SessionManager.Current.Session["SiteCode"] != null)
                {
                    sCode = Int32.Parse(WebClassLibrary.SessionManager.Current.Session["SiteCode"].ToString());
                    this.SetHeadLink(page);
                    this.SetHeadScript(page);
                    List<JModule> AllModules = new List<JModule>();
                    HtmlNodeCollection nodes = TemplateDoc.DocumentNode.SelectNodes("//jdoc");
                    foreach (HtmlNode node in nodes)
                    {
                        string PositionAttr = node.GetAttributeValue("name", "NOTFOUND");
                        DataTable result = JModules.GetDataTable("Position='" + PositionAttr + "' and Site=" + sCode + "and Home='True'");
                        if (result != null)
                        {
                            JModule[] ModulesTable = new JModule[result.Rows.Count];
                            int[] ModulesIndex = new int[result.Rows.Count];
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
                                ModulesTable[result.Rows.IndexOf(dr)] = module;
                                ModulesIndex[result.Rows.IndexOf(dr)] = module.PosOrder;
                            }
                            Array.Sort(ModulesIndex, ModulesTable);
                            for (int i = 0; i < ModulesTable.Length; i++)
                            {
                                 GetModuleHTML(page,ModulesTable[i]);
                                AllModules.Add(ModulesTable[i]);
                            }
                            node.ParentNode.RemoveChild(node);
                        }

                    }
                    return AllModules;
                }
                else
                    return null;

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

        public void GetModuleHTML(Page page,JModule module)
        {
            CMSClassLibrary.Extension.JExtension extension = new CMSClassLibrary.Extension.JExtension();
            extension.GetData(module.ExtCode);
            Assembly assembly = Assembly.Load(extension.ClassName.Split('.')[0]);
            Type type = assembly.GetType(extension.ClassName);
            LiteralControl TextCtr = new LiteralControl();
            if (module.Parameters == "")
                module.Parameters = null;
            object instance = Activator.CreateInstance(type, module.Parameters);
            CMSClassLibrary.Content.JContent cnt = new CMSClassLibrary.Content.JContent();
            Control newCtr = instance as Control;
            newCtr.ID = module.Name;
           
            if (page.FindControl(module.Position + "place") != null)
            {
                page.FindControl(module.Position + "place").Controls.Add(newCtr);
            }
            

            //if (className == "CMSClassLibrary.Components.JContentManager")
            //{
            //    cnt.GetData(Int32.Parse(parameters));
            //    TextCtr.Text = cnt.Text;
            //   // return cnt.Text;
            //}
            
            //using (CMSClassLibrary.Core.JPage page=new CMSClassLibrary.Core.JPage() )
            //{
            //    Control cc = instance as Control;
            //    cc.ID = Guid.NewGuid().ToString();
            //    page.Controls.Add(instance as Control);
            //    using (StringWriter writer = new StringWriter())
            //    {
            //        page.Controls.Add(instance as Control);
            //       // HttpContext.Current.Server.Execute(page, writer, false);
            //       // return instance;
            //        //return writer.ToString();

            //    }
            //}
            
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
            CMSClassLibrary.Extension.JSiteTemplate st=new CMSClassLibrary.Extension.JSiteTemplate();
            int StyleCode = 0;
            DataTable styles = CMSClassLibrary.Extension.JSiteTemplates.GetDataTable("SiteCode=" + sCode);
            if(styles != null)
                if(styles.Rows.Count > 0)
                {
                    foreach  (DataRow dr in styles.Rows)
                    {
                        StyleCode = Int32.Parse(dr["StyleCode"].ToString());
                        CMSClassLibrary.Template.JTemplate temp = new CMSClassLibrary.Template.JTemplate(StyleCode);
                        System.Web.UI.HtmlControls.HtmlLink Link = new System.Web.UI.HtmlControls.HtmlLink();
                        Link.Href = "../../../" + temp.Path;
                        Link.Attributes["rel"] = "stylesheet";
                        page.Header.Controls.Add(Link);
                    }
                   
                }
            
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

    public class ModuleString
    {
        public int Order { get; set; }
        public string NodeString { get; set; }
    }
}
