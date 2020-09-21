using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebEstate.Land.Ground.Usage.Handler
{
    /// <summary>
    /// Summary description for Handler2
    /// </summary>
    public class Handler2 : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string guid = Guid.NewGuid().ToString();
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                //for (int i = 0; i < files.Count; i++)
                //{
                //HttpPostedFile file = files[i];
                HttpPostedFile file = files[0];
                string fname = context.Server.MapPath("../test/" + guid + file.FileName.Substring(file.FileName.LastIndexOf(".")));
                file.SaveAs(fname);
                //}
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(guid);
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