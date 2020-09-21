using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebERP.Services.FileUploader
{
	public class C630N_RemoveHandler : IHttpHandler, IRequiresSessionState
	{
		public void ProcessRequest(HttpContext context)
		{
			if (context.Request != null)
			{
				string filePath = context.Server.MapPath(context.Request["path"]);
				if (System.IO.File.Exists(filePath))
				{
					int archiveCode = 0;
					if (int.TryParse(context.Request["ArchiveCode"], out archiveCode) && archiveCode > 0)
					{
						ArchivedDocuments.JArchiveDocument jArchiveDocument = new ArchivedDocuments.JArchiveDocument();
						jArchiveDocument.GetData(archiveCode, true);
						if (jArchiveDocument.DeleteArchive(jArchiveDocument.Code, true))
							System.IO.File.Delete(filePath);
						else
							throw new Exception("خطا در حذف فایل...!");
						jArchiveDocument.Dispose();
					}
				}
				else
					throw new Exception("فایل موجود نیست");
				//}
				//else
				//{
				//jArchiveDocument.ClassName = context.Request["ClassName"];
				//jArchiveDocument.ObjectCode = int.Parse(context.Request["ObjectCode"]);
				//ClassLibrary.JFile jFile = new ClassLibrary.JFile();
				//jFile.Content = WebClassLibrary.JDataManager.ReadToEnd(file.InputStream);
				//jFile.FileName = file.FileName;
				//jFile.Extension = ext;
				//jFile.FileText = file.ContentType;
				//int code = jArchiveDocument.ArchiveDocument(jFile, context.Request["ClassName"], int.Parse(context.Request["ObjectCode"]), context.Request["Description"], false);
				//jArchiveDocument.Dispose();
				//context.Response.Write(code.ToString());
				//}
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