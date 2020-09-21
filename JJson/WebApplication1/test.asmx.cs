using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
	/// <summary>
	/// Summary description for test
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class test : System.Web.Services.WebService
	{
		[WebMethod(EnableSession = true)]
		public string test1(string data, JJson.JsonRequestType requestType, JJson.JsonResponseType responseType)
		{
			if (requestType == JJson.JsonRequestType.Direct)
				return data.Split('|')[0].Split(':')[1];
			if (responseType == JJson.JsonResponseType.Table)
				return getDT(data);
			else if (responseType == JJson.JsonResponseType.Row)
				return data.Replace("|", "?!?");
			else if (responseType == JJson.JsonResponseType.Item)
				return data.Split('|')[0].Split(':')[1];//data.Contains("|") ? data.Split('|')[0].Contains(":") ? data.Split('|')[0].Split(':')[1] : data.Split('|')[0] :data.Split(':')[1] : data.Split('|')[0] ;
			//if (requestType == JJson.JsonRequestType.SQL)
			//	return data;
			//if (data.Contains("|"))
			return data.Split('|')[0].Split(':')[1];
			//	return data.Split(':')[1];
		}

		#region Service
		[WebMethod(EnableSession = true)]
		public string Run(string data, JJson.JsonRequestType requestType, JJson.JsonResponseType responseType)
		{
			string response = "";
			switch (requestType)
			{
				case JJson.JsonRequestType.SQL:
					switch (responseType)
					{
						case JJson.JsonResponseType.Table:
							response = GetJson(ExecuteQuery(data));
							break;
						case JJson.JsonResponseType.Row:
							response = GetJson(ExecuteQuery(data), 0);
							break;
						case JJson.JsonResponseType.Item:
							response = GetJson(ExecuteQuery(data), 0, 0);
							break;
						default:
							break;
					}
					break;
				case JJson.JsonRequestType.Direct:
					response = data;
					break;
				case JJson.JsonRequestType.Other:
					response = data;
					break;
				default:
					break;
			}
			return response;
		}
		private DataTable ExecuteQuery(string query)
		{
			DataTable dt = null;
			return dt;
		}

		private string GetJson(DataTable dt)
		{
			System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
			List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
			Dictionary<string, object> row = null;
			foreach (DataRow dr in dt.Rows)
			{
				row = new Dictionary<string, object>();
				foreach (DataColumn col in dt.Columns)
					row.Add(col.ColumnName, dr[col]);
				rows.Add(row);
			}
			return serializer.Serialize(rows);
		}
		private string GetJson(DataTable dt, int rowIndex)
		{
			System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
			List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
			Dictionary<string, object> row = null;
			DataRow dr = dt.Rows[rowIndex];
			row = new Dictionary<string, object>();
			foreach (DataColumn col in dt.Columns)
				row.Add(col.ColumnName, dr[col]);
			return serializer.Serialize(row);
		}
		private string GetJson(DataTable dt, int rowIndex, int colIndex)
		{
			System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
			List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
			Dictionary<string, object> row = null;
			DataRow dr = dt.Rows[rowIndex];
			row = new Dictionary<string, object>();
			row.Add(dt.Columns[colIndex].ColumnName, dr[colIndex]);
			return serializer.Serialize(row);
		}
		#endregion

		[WebMethod(EnableSession = true)]
		public string getDT(string code)
		{
			//System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
			DataTable dt = new DataTable();
			dt.Columns.Add("col1", typeof(int));
			dt.Columns.Add("col2", typeof(float));
			dt.Columns.Add("col3", typeof(string));
			DataRow dr = dt.NewRow();
			dr.ItemArray = new object[] { 1, 1.5, "red" };
			//dr.AcceptChanges();
			dt.Rows.Add(dr);
			dt.AcceptChanges();
			dr = dt.NewRow();
			dr.ItemArray = new object[] { 2, 2.5, "green" };
			//dr.AcceptChanges();
			dt.Rows.Add(dr);
			dt.AcceptChanges();
			DataSet ds = new DataSet();
			ds.Tables.Add(dt);
			//return ds.GetXml();
			return GetJson(dt);
		}
	}
}
