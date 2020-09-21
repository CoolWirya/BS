<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.SessionState;
//public class Handler : IHttpHandler, IRequiresSessionState
//{
//    public void ProcessRequest(HttpContext context)
//    {
//        context.Response.Clear();
//        context.Session["STORED_IMAGE"] = "";
//        if (context.Request.QueryString.Count != 0 && context.Request.QueryString["picUrl"] != null && context.Request.QueryString["picName"] != null)
//        {
//            string picUrl = context.Request.QueryString["picUrl"].ToString();
//            string picName = context.Request.QueryString["picName"].ToString();
//            HttpPostedFile postedFile = context.Request.Files["uploadfile"];
//            if (postedFile != null)
//            {
//                if (postedFile.ContentLength < 1000000000 )
//                {
//                  //context.Session["HttpPostedFile"] = context.Request.Files["uploadfile"];
//                    postedFile.SaveAs(context.Server.MapPath(picUrl+"NewsPic" + picName + ".jpg"));
//                }
//                else
//                    context.Response.Write("<script>alert('حجم فايل زياد است')</script>");
//            }
//        }
//    }
//    public bool IsReusable
//    {
//        get
//        {
//            return false;
//        }
//    }
//    private Image GetImage(byte[] storedImage)
//    {
//        var stream = new MemoryStream(storedImage);
//        return Image.FromStream(stream);
//    }

//    private byte[] ReadFile(HttpPostedFile file)
//    {
//        byte[] data = new Byte[file.ContentLength];
//        file.InputStream.Read(data, 0, file.ContentLength);
//        return data;
//    }

//}



public class UploadHandler : IHttpHandler
{

    //public void ProcessRequest(HttpContext context)
    //{

    //    if (context.Request.Files.Count > 0)
    //    {

    //        HttpFileCollection SelectedFiles = context.Request.Files;

    //        for (int i = 0; i < SelectedFiles.Count; i++)
    //        {

    //            HttpPostedFile PostedFile = SelectedFiles[i];

    //            string FileName = context.Server.MapPath("~/UploadedFiles/" + PostedFile.FileName);

    //            PostedFile.SaveAs(FileName);

    //        }

    //    }



    //    else
    //    {

    //        context.Response.ContentType = "text/plain";

    //        context.Response.Write("Please Select Files");

    //    }



    //    context.Response.ContentType = "text/plain";

    //    context.Response.Write("Files Uploaded Successfully!!");

    //}



    //public bool IsReusable
    //{

    //    get
    //    {

    //        return false;

    //    }

    //}

    public void ProcessRequest(HttpContext context)
    {
        if (context.Request.Files.Count > 0)
        {
            HttpFileCollection files = context.Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                string fname = context.Server.MapPath("../test/" + file.FileName);
                file.SaveAs(fname);
            }
        }
        context.Response.ContentType = "text/plain";
        context.Response.Write("File(s) Uploaded Successfully!");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}