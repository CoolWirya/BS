using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JComponents
{
	[ToolboxData("<{0}:FileUploader runat=server></{0}:FileUploader>")]
	public class FileUploader : CompositeControl, ISerializable
	{
		private FileUpload fileUploader;
		private Button uploadButton;
		private TextBox description;
		private Button saveButton;

		private List<string> acs;
		private List<string> guids;
		private List<string> exts;
		private IDictionary<string, int[]> eos;

		public FileUploader()
		{
		}

		public FileUploader(SerializationInfo info, StreamingContext ctxt)
		{
			ID = (string)info.GetValue("ID", typeof(string));
			//ServiceURL = (string)info.GetValue("ServiceURL", typeof(string));
			//UploadPath = (string)info.GetValue("UploadPath", typeof(string));
			DataBaseClassName = (string)info.GetValue("DataBaseClassName", typeof(string));
			DataBaseObjectCode = (int)info.GetValue("DataBaseObjectCode", typeof(int));
			ClassName = (string)info.GetValue("ClassName", typeof(string));
			ObjectCode = (int)info.GetValue("ObjectCode", typeof(int));
		}

		public void LoadArchivedFiles()
		{
			acs = new List<string>();
			guids = new List<string>();
			exts = new List<string>();
			ArchivedDocuments.JArchiveDocument jArchiveDocument = new ArchivedDocuments.JArchiveDocument(DataBaseClassName, DataBaseObjectCode);
			DataTable dt = jArchiveDocument.RetrieveForWeb(ClassName, ObjectCode, eos);
			dt = WebClassLibrary.JWebDataBase.ConvertDateTimeColumns(dt, false);
			if (dt == null)
				return;
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				string guid = Guid.NewGuid().ToString();
				ClassLibrary.JFile jFile = jArchiveDocument.RetrieveContent(Convert.ToInt32(dt.Rows[i]["ArchiveCode"]));
				System.IO.File.WriteAllBytes(this.Page.Server.MapPath("./Services/FileUploader/" + UploadPath + guid + jFile.Extension), jFile.Content);
				acs.Add(dt.Rows[i]["ArchiveCode"].ToString());
				guids.Add(guid);
				exts.Add(jFile.Extension);
				jFile.Dispose();
			}
			jArchiveDocument.Dispose();
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("ID", ID);
			info.AddValue("ServiceURL", ServiceURL);
			info.AddValue("UploadPath", UploadPath);
			info.AddValue("DataBaseClassName", DataBaseClassName);
			info.AddValue("DataBaseObjectCode", DataBaseObjectCode);
			info.AddValue("ClassName", ClassName);
			info.AddValue("ObjectCode", ObjectCode);
		}

		protected override void CreateChildControls()
		{
			base.CreateChildControls();
			fileUploader = new FileUpload();
			fileUploader.ID = this.ClientID + "_fileUploader1";
			fileUploader.ClientIDMode = System.Web.UI.ClientIDMode.Static;
			Controls.Add(fileUploader);
			description = new TextBox();
			description.ID = this.ClientID + "_description1";
			description.ClientIDMode = System.Web.UI.ClientIDMode.Static;
			Controls.Add(description);
			uploadButton = new Button();
			uploadButton.Text = "ارسال";
			uploadButton.ID = this.ClientID + "_uploadButton1";
			uploadButton.ClientIDMode = System.Web.UI.ClientIDMode.Static;
			Controls.Add(uploadButton);
			saveButton = new Button();
			saveButton.Text = "ذخیره";
			saveButton.ID = this.ClientID + "_saveButton1";
			saveButton.ClientIDMode = System.Web.UI.ClientIDMode.Static;
			Controls.Add(saveButton);
		}
		protected override void RecreateChildControls()
		{
			base.RecreateChildControls();
			EnsureChildControls();
		}
		void writeScript()
		{
			string files = "";
			for (int i = 0; i < guids.Count; i++)
				files += (string.IsNullOrWhiteSpace(acs[i]) ? guids[i] : acs[i]) + exts[i] + ",";
			string s = "$(document).ready(function(){" +
				"$('#" + this.ClientID + "').attr('owner','630N');" + "$('#" + this.ClientID + "').val('" + files + "');" +
				//"$(\"#" + this.ClientID + "\").attr('ServiceURL','" + ServiceURL + "');" +
			 "$(\"#" + this.ClientID + "_uploadButton1\").click(function(){C630N_Uploader('" + this.ClientID + "_fileUploader1','" + this.ClientID + "_ResponseTable','" + description.Text + "','" + ServiceURL + "','" + UploadPath + "','" + DataBaseClassName + "'," + DataBaseObjectCode + ",'" + ClassName + "'," + ObjectCode + ");return false; });" +
			 "$(\"#" + this.ClientID + "_saveButton1\").click(function(){" +
				//C630N_ArchiveUploadedFiles('" + this.ClientID + "','" + UploadPath + "','" + ClassName + "','" + ObjectCode + "');
			"$.ajax({" +
				"type: 'POST'," +
				"url: '../Services/FileUploader/UploaderService.asmx/ArchiveUploadedFiles'," +
				"data: '{\"files\": \"' + $('#" + this.ClientID + "').val() + '\", \"path\": \"" + UploadPath + "\", \"className\": \"" + ClassName + "\", \"objectCode\": \"" + ObjectCode + "\"}'," +
										@"contentType: 'application/json; charset=utf-8',
										dataType: 'json',
										success: function (response) {" +
											"if (response.data) $('#" + this.ClientID + "').val(response.data);" +
										@"},
										failure: function (response) {
											alert(response.d);
										},
										error: function (response) {
											alert(response.d);
										}" +
				"});" +
			"return false; });" +
			 "});";
			if (!this.Page.ClientScript.IsStartupScriptRegistered(this.ClientID + "_Uploader_Script"))
				this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), this.ClientID + "_Uploader_Script", s, true);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			LoadArchivedFiles();
			writeScript();
		}

		protected override void Render(HtmlTextWriter writer)
		{
			AddAttributesToRender(writer);

			writer.AddAttribute(
				HtmlTextWriterAttribute.Cellpadding,
				"1", false);
			writer.RenderBeginTag(HtmlTextWriterTag.Table);

			writer.RenderBeginTag(HtmlTextWriterTag.Tr);

			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			fileUploader.RenderControl(writer);
			writer.RenderEndTag();

			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			description.RenderControl(writer);
			writer.RenderEndTag();

			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			uploadButton.RenderControl(writer);
			writer.RenderEndTag();

			writer.RenderEndTag();

			writer.RenderEndTag();

			////////////////////////////////////////////////////////////////////////////////////

			writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "3", false);
			writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID + "_ResponseTable");
			writer.RenderBeginTag(HtmlTextWriterTag.Table);
			writer.AddAttribute(HtmlTextWriterAttribute.Style, "border-bottom:1px solid black;");
			writer.RenderBeginTag(HtmlTextWriterTag.Tr);
			writer.AddAttribute(HtmlTextWriterAttribute.Align, "center");
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			writer.Write("نام فایل");
			writer.RenderEndTag();
			writer.AddAttribute(HtmlTextWriterAttribute.Align, "center");
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			writer.Write("پیش نمایش");
			writer.RenderEndTag();
			writer.AddAttribute(HtmlTextWriterAttribute.Align, "center");
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			writer.Write("عملیات");
			writer.RenderEndTag();

			writer.RenderEndTag();
			////////////////////////////////////////////////////////////////////////////////////
			for (int i = 0; i < acs.Count; i++)
			{
				writer.AddAttribute(HtmlTextWriterAttribute.Style, "border-bottom:1px solid black;");
				writer.AddAttribute(HtmlTextWriterAttribute.Id, guids[i]);
				writer.AddAttribute("archiveCode", acs[i]);
				writer.RenderBeginTag(HtmlTextWriterTag.Tr);
				writer.AddAttribute(HtmlTextWriterAttribute.Align, "center");
				writer.RenderBeginTag(HtmlTextWriterTag.Td);
				writer.Write(guids[i] + exts[i]);
				writer.RenderEndTag();
				writer.AddAttribute(HtmlTextWriterAttribute.Align, "center");
				writer.RenderBeginTag(HtmlTextWriterTag.Td);
				writer.Write("<img src=\"./Services/FileUploader/" + UploadPath + guids[i] + exts[i] + "\" alt=\"\" height=\"42\" width=\"42\"/>");
				writer.RenderEndTag();
				writer.AddAttribute(HtmlTextWriterAttribute.Align, "center");
				writer.RenderBeginTag(HtmlTextWriterTag.Td);
				writer.Write("<a href=\"#\" onclick=\"if (confirm('آیا از حذف این فایل اطمینان دارید؟')) {removeUploadedFile('" + guids[i] + "','" + exts[i] + "','" + UploadPath + "','" + this.ClientID + "','" + this.ClientID + "_ResponseTable','" + ServiceURL.Replace("C630N_UploadHandler", "C630N_RemoveHandler") + "','" + ClassName + "','" + ObjectCode + "');}return false;\">حذف</a>");
				writer.RenderEndTag();
				writer.RenderEndTag();
			}
			////////////////////////////////////////////////////////////////////////////////////
			writer.RenderEndTag();

			////////////////////////////////////////////////////////////////////////////////////

			writer.Write("<br />");
			saveButton.RenderControl(writer);
		}

		#region Properties
		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public string ServiceURL
		{
			get
			{
				//if (ViewState["ServiceURL"] != null)
				//	return ViewState["ServiceURL"].ToString();
				return "../Services/FileUploader/C630N_UploadHandler.ashx";
			}
			//set
			//{
			//	ViewState["ServiceURL"] = value;
			//}
		}

		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public string UploadPath
		{
			get
			{
				//if (ViewState["UploadPath"] != null)
				//	return ViewState["UploadPath"].ToString();
				return "./TempArchiveFiles/";
			}
			//set
			//{
			//	ViewState["UploadPath"] = value;
			//}
		}

		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public string DataBaseClassName
		{
			get
			{
				if (ViewState["DataBaseClassName"] != null)
					return ViewState["DataBaseClassName"].ToString();
				return null;
			}
			set
			{
				ViewState["DataBaseClassName"] = value;
			}
		}

		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public int DataBaseObjectCode
		{
			get
			{
				if (ViewState["DataBaseObjectCode"] != null)
					return (int)ViewState["DataBaseObjectCode"];
				return -1;
			}
			set
			{
				ViewState["DataBaseObjectCode"] = value;
			}
		}

		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public string ClassName
		{
			get
			{
				if (ViewState["ClassName"] != null)
					return ViewState["ClassName"].ToString();
				return null;
			}
			set
			{
				ViewState["ClassName"] = value;
			}
		}

		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public int ObjectCode
		{
			get
			{
				if (ViewState["ObjectCode"] != null)
					return (int)ViewState["ObjectCode"];
				return -1;
			}
			set
			{
				ViewState["ObjectCode"] = value;
			}
		}
		#endregion
	}
}
