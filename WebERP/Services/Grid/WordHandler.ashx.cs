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
	/// Summary description for WordHandler
	/// </summary>
    public class WordHandler : IHttpHandler, IReadOnlySessionState
    {
        [WebMethod(EnableSession = true)]
		public void ProcessRequest(HttpContext context)
		{string s = "";
			string className = context.Request.QueryString["className"];
			int objectCode = int.Parse(context.Request.QueryString["objectCode"]);
			string parameters = context.Request.QueryString["parameters"];
			object[] _params = parameters.Split(',').Select(x => Convert.ChangeType(x, typeof(object))).ToArray();
            string sql = "";//context.Request.QueryString["sql"].Replace("?!?", "'");
			            
            JQuery jQuery = new JQuery(className, objectCode, _params);
			sql = string.IsNullOrWhiteSpace(jQuery.QueryText) ? sql : jQuery.QueryText;
			DataTable table = JWebDataBase.GetDataTable(sql);
			HttpContext.Current.Response.Buffer = true;
			//HttpContext.Current.Response.ContentType = "application/ms-excel";
			s += @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">";
			context.Response.AddHeader("Content-type", "application/msword");
			context.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.doc");
			//HttpContext.Current.Response.Charset = "utf-8";
			//HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
			s += "<font style='font-size:10.0pt; font-family:Calibri;'>";
			s += "<BR><BR><BR>";
			s += "<Table border='1' bgColor='#ffffff' " +
			  "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
			  "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>";
			int columnscount = table.Columns.Count;
			for (int j = 0; j < columnscount; j++)
			{
				s += "<Td>";
				s += "<B>";
				s += JLanguages._Text(table.Columns[j].ColumnName);
				s += "</B>";
				s += "</Td>";
			}
			s += "</TR>";
			foreach (DataRow row in table.Rows)
			{
				s += "<TR>";
				for (int i = 0; i < table.Columns.Count; i++)
				{
					s += "<Td>";
					s += row[i].ToString();
					s += "</Td>";
				}

				s += "</TR>";
			}
			s += "</Table>";
			s += "</font>";
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