using System;
using System.Web;
using System.Web.SessionState;

namespace WebERP.Services.FileUploader
{
	public class C630N_UploadHandler : IHttpHandler, IRequiresSessionState
	{
		private bool isImage(string ext)
		{
			switch (ext.Replace(".", "").ToLower())
			{
				case "jpg":
				case "png":
				case "gif":
					return true;
				default:
					return false;
			}
		}
		public void ProcessRequest(HttpContext context)
		{
			if (context.Request.Files.Count > 0)
			{
				string guid = Guid.NewGuid().ToString();
				HttpPostedFile file = context.Request.Files[0];
				string ext = file.FileName.Substring(file.FileName.LastIndexOf("."));
				context.Response.ContentType = "text/plain";
				//if (!string.IsNullOrWhiteSpace(context.Request["path"]))
				//{
				string filePath = context.Server.MapPath(context.Request["path"] + guid + ext);
				file.SaveAs(filePath);
				//}
				//else
				//{
				int code = 0;
				int objectCode = 0;
				if (int.TryParse(context.Request["ObjectCode"], out objectCode) && objectCode > 0)
				{
					ArchivedDocuments.JArchiveDocument jArchiveDocument = new ArchivedDocuments.JArchiveDocument(context.Request["DataBaseClassName"], int.Parse(context.Request["DataBaseObjectCode"]));
					jArchiveDocument.ClassName = context.Request["ClassName"];
					jArchiveDocument.ObjectCode = objectCode;
					ClassLibrary.JFile jFile = new ClassLibrary.JFile();
					jFile.Content = WebClassLibrary.JDataManager.ReadToEnd(file.InputStream);
					jFile.FileName = file.FileName;
					jFile.Extension = ext;
					jFile.FileText = file.ContentType;
					code = jArchiveDocument.ArchiveDocument(jFile, context.Request["ClassName"], objectCode, context.Request["Description"], false);
					jArchiveDocument.GetData(code);
					code = jArchiveDocument.ArchiveCode;
					jArchiveDocument.Dispose();
				}
				//context.Response.Write(code.ToString());
				//}
				context.Response.Write((code > 0 && objectCode > 0 ? code.ToString() : guid) + ext + ",?!?<tr id=\"" + guid + "\" archiveCode=\"" + code + "\"><td align=\"center\">" + file.FileName + "</td><td align=\"center\">" + (isImage(ext) ? "<img src=\"../Services/FileUploader/" + context.Request["path"] + guid + ext + "\" alt=\"\" height=\"42\" width=\"42\"/> " : "") + "</td><td align=\"center\"><a href=\"#\" onclick=\"if (confirm('آیا از حذف این فایل اطمینان دارید؟')) {removeUploadedFile('" + guid + "','" + ext + "','" + context.Request["path"] + "','" + context.Request["MainUploader"] + "','" + context.Request["ResponseTag"] + "','" + context.Request["ServiceUrl"].Replace("C630N_UploadHandler", "C630N_RemoveHandler") + "','" + context.Request["ClassName"] + "','" + context.Request["ObjectCode"] + "');}return false;\">حذف</a></td></tr>");
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
}