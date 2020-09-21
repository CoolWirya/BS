using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebReport.Viewer
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            if (action == "AddReport")
                AddReport(context.Request);


            //context.Response.ContentType = "text/json";
            //System.IO.Stream body = context.Request.InputStream;
            //System.Text.Encoding encoding = context.Request.ContentEncoding;
            //System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
            //string s = reader.ReadToEnd();
            //DataClass publicacion = JsonConvert.DeserializeObject<DataClass>(s);
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
        }

        void AddReport(HttpRequest Request)
        {
            System.IO.Stream body = Request.InputStream;
            System.Text.Encoding encoding = Request.ContentEncoding;
            System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
            string s = reader.ReadToEnd();
            ReportInput Data = Serializer.Deserialize<ReportInput>(s);
            JReport jReport = new JReport();
            jReport.ClassName = Data.ClassName;
            jReport.Name = Data.Name + '_' + ClassLibrary.JDateTime.FarsiDate(DateTime.Now);
            jReport.ObjectCode = Data.ObjectCode;
            int rptCode = jReport.Insert();
            if (rptCode > 0)
            {
                //JReportManager.DesignReport(false, Data.SUID, Data.ClassName, Data.ObjectCode, rptCode, WebClassLibrary.WindowTarget.NewWindow);
                //JReportManager.DesignReport(false, reportSUID, rptCode, WebClassLibrary.WindowTarget.CurrentWindow);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    public class ReportInput
    {
        public string ClassName { get; set; }
        public string Name { get; set; }
        public int ObjectCode { get; set; }
        public string SUID { get; set; }
    }
}