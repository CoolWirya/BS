using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebERP.Services.FileUploader
{
	/// <summary>
	/// Summary description for UploaderService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class UploaderService : System.Web.Services.WebService, System.Web.SessionState.IRequiresSessionState
	{
		[WebMethod(EnableSession = true)]
		public string ArchiveUploadedFiles(string files, string path, string className, string objectCode)
		{
			if (string.IsNullOrWhiteSpace(files))
				return "";
			string response = "";
			int counter = 0;
			string[] filesArray = files.Split(',');
			int code = 0;
			int oc = 0;
			for (int i = 0; i < filesArray.Length; i++)
			{
				if (string.IsNullOrWhiteSpace(filesArray[i]))
				{
					counter++;
					continue;
				}
				string ext = filesArray[i].Substring(filesArray[i].LastIndexOf("."));
				string file = filesArray[i].Replace(ext, "");
				if (int.TryParse(file, out code))
					counter++;
			}
			if (counter != filesArray.Length || !int.TryParse(objectCode, out oc))
				return "";
			for (int i = 0; i < filesArray.Length; i++)
				if (oc > 0)
				{
					ArchivedDocuments.JArchiveDocument jArchiveDocument = new ArchivedDocuments.JArchiveDocument();
					jArchiveDocument.ClassName = className;
					jArchiveDocument.ObjectCode = oc;
					ClassLibrary.JFile jFile = new ClassLibrary.JFile();
					string filePath = Server.MapPath(path + "/" + filesArray[i]);
					System.IO.FileInfo fi = new System.IO.FileInfo(filePath);
					jFile.Content = System.IO.File.ReadAllBytes(filePath);
					jFile.FileName = fi.Name;
					jFile.Extension = "." + fi.Extension;
					code = jArchiveDocument.ArchiveDocument(jFile, className, oc, "", false);
					jArchiveDocument.GetData(code);
					code = jArchiveDocument.ArchiveCode;
					jArchiveDocument.Dispose();
					response += code + jFile.Extension + ",";
				}
			return response;
		}
	}
}
