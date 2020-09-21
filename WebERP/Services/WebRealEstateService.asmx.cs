using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using ClassLibrary;
using RealEstate;

namespace WebERP.Services
{
	/// <summary>
	/// Summary description for WebRealEstateService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class WebRealEstateService : System.Web.Services.WebService
	{

		[WebMethod(EnableSession = true)]
		public string AddJoint(string code, string type, string marketCode)
		{
			int _code = 0, _marketCode = 0;
			if (!int.TryParse(marketCode, out _marketCode))
				return "خطا در عملیات...!";
			int.TryParse(code, out _code);
			JJoint jJoint = new JJoint();
			if (_code > 0)
			{
				jJoint.Code = _code;
				jJoint.GetData(_code);
			}
			jJoint.Type = type;
			jJoint.MarketCode = _marketCode;
			if (_code == 0)
				if (jJoint.Insert() > 0)
					return "ثبت با موفقیت انجام شد";
				else
					return "خطا در ثبت اطلاعات...!";
			else
				if (jJoint.Update())
					return "ویرایش با موفقیت انجام شد";
				else
					return "خطا در ویرایش اطلاعات...!";
		}

		#region Default Owners
		[WebMethod(EnableSession = true)]
		public string AddOwner(string code, string pCode, string shareCount)
		{
			int _code = 0, _shareCount = 0, _PCode = 0;
			if (!int.TryParse(pCode, out _PCode) || (!int.TryParse(shareCount, out _shareCount) && _shareCount <= 0))
			{
				return "Error";
			}
			int.TryParse(code, out _code);
			JDefaultOwner jdo = new JDefaultOwner();
			jdo.PCode = _PCode;
			jdo.Share = _shareCount;
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				if (_code > 0)
				{
					jdo.Code = _code;
					jdo.GetData(_code);
				}
				if (_code == 0)
					if (jdo.Insert(DB) > 0)
						return "ثبت با موفقیت انجام شد";
					else
						return "Error";
				else
					if (jdo.Update(DB))
						return "ویرایش با موفقیت انجام شد";
					else
						return "Error";
			}
			catch
			{
				return "Error";
			}
			finally
			{
				DB.Dispose();
			}
		}

		[WebMethod(EnableSession = true)]
		public string RemoveOwner(string code)
		{
			int _code = 0;
			if (!int.TryParse(code, out _code))
			{
				return "Error";
			}
			JDefaultOwner jdo = new JDefaultOwner();
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				if (_code > 0)
				{
					jdo.Code = _code;
					jdo.GetData(_code);
				}
				if (jdo.Delete(DB))
					return "حذف با موفقیت انجام شد";
				else
					return "Error";
			}
			catch
			{
				return "Error";
			}
			finally
			{
				DB.Dispose();
			}
		}
		#endregion

		[WebMethod(EnableSession = true)]
		public string GetSearchUnitSQL(string type, string market, string plaque, string floor, string number)
		{
			int unitType = 0;
			int.TryParse(type, out unitType);
			int MarketCode = 0;
			int.TryParse(market, out MarketCode);
			int FloorCode = 0;
			int.TryParse(floor, out FloorCode);
			string query = JUnitBuilds.GetSearchSql(0, unitType, MarketCode, plaque, number, FloorCode);
			return query;
		}

		[WebMethod(EnableSession = true)]
		public string getPersons(string query, string sf, string prefix)
		{
			DataSet ds = new DataSet();
			JDataBase db = JGlobal.MainFrame.GetDBO();
			query = "select * from (" + query.Replace("?!?", "'") + ")t1 where " + sf + " like N'%" + prefix + "%'";
			db.setQuery(query);
			ds.Tables.Add(db.Query_DataTable());
			return ds.GetXml();
		}
	}
}
