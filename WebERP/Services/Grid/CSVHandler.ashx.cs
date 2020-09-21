using ClassLibrary;
using ClassLibrary.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using WebClassLibrary;

namespace WebERP.Services
{
	/// <summary>
	/// Summary description for PdfHandler
	/// </summary>
    public class CSVHandler : IHttpHandler, IReadOnlySessionState
    {
        [WebMethod(EnableSession = true)]
		public void ProcessRequest(HttpContext context)
		{
			string s = "";
			string className = context.Request.QueryString["className"];
			int objectCode = int.Parse(context.Request.QueryString["objectCode"]);
			string parameters = context.Request.QueryString["parameters"];
			object[] _params = parameters.Split(',').Select(x => Convert.ChangeType(x, typeof(object))).ToArray();
            string sql = "";//context.Request.QueryString["sql"].Replace("?!?", "'");
			JQuery jQuery = new JQuery(className, objectCode, _params);
			sql = string.IsNullOrWhiteSpace(jQuery.QueryText) ? sql : jQuery.QueryText;
			DataTable table = JWebDataBase.GetDataTable(sql);
			HttpContext.Current.Response.Buffer = true;
			context.Response.AddHeader("Content-type", "text/plain");
			context.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.txt");
			int columnscount = table.Columns.Count;
			for (int j = 0; j < columnscount; j++)
				s += JLanguages._Text(table.Columns[j].ColumnName) + ",";
			s += "\r\n";
			foreach (DataRow row in table.Rows)
			{
				for (int i = 0; i < table.Columns.Count; i++)
					s += row[i].ToString() + ",";

				s += "\r\n";
			}
			byte[] bytes = new byte[s.Length * sizeof(char)];
			System.Buffer.BlockCopy(s.ToCharArray(), 0, bytes, 0, bytes.Length);
			try
			{
				context.Response.Write(s);
				context.Response.Flush();
				context.Response.End();
			}
			catch (Exception ex)
			{
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