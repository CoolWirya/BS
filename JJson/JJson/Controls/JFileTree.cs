using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJson.BaseControls;
using System.Web.UI.WebControls;


namespace JJson.Controls
{
    public class JFileTree : JBaseCompositeControl
    {
        Literal FileList;
        Literal FileTree;

        public JFileTree()
        {
            FileList = new Literal();
            FileTree = new Literal();
        }
        protected override void CreateChildControls()
        {
            //base.CreateChildControls();
          //  FileTree.Text = "<div class=\"cont\"><div id=\"" + this.ClientID + "_fileTree\" class=\"demo\"></div><div class=\"PicContainer\"></div></div>";
            FileTree.Text = "<div style=\"width:1024px; height:768px\" id=\"" + this.ClientID + "_fileManager\"></div>";
            //string dir;
            //if (Page.Request.Form["dir"] == null || Page.Request.Form["dir"].Length <= 0)
            //    dir = "/";
            //else
            //    dir = Page.Server.UrlDecode(Page.Request.Form["dir"]);
            //System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(dir);
            //FileList.Text="<ul class=\"jqueryFileTree\" style=\"display: none;\">\n";
            //foreach (System.IO.DirectoryInfo di_child in di.GetDirectories())
            //    FileList.Text = FileList.Text + "\t<li class=\"directory collapsed\"><a href=\"#\" rel=\"" + dir + di_child.Name + "/\">" + di_child.Name + "</a></li>\n";
            //foreach (System.IO.FileInfo fi in di.GetFiles())
            //{
            //    string ext = "";
            //    if (fi.Extension.Length > 1)
            //        ext = fi.Extension.Substring(1).ToLower();

            //    FileList.Text = FileList.Text + "\t<li class=\"file ext_" + ext + "\"><a href=\"#\" rel=\"" + dir + fi.Name + "\">" + fi.Name + "</a></li>\n";
            //}
            //FileList.Text = FileList.Text + "</ul>";
            this.Controls.Add(FileTree);
            //this.Controls.Add(FileList);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Methods.RegisterFileTreeScript(this.Page, this.ClientID,0);
        }
    }
}
