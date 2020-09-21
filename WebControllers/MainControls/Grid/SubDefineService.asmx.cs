using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebControllers.MainControls.Grid
{
	/// <summary>
	/// Summary description for SubDefineService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class SubDefineService : System.Web.Services.WebService
	{

		[WebMethod(EnableSession = true)]
		public bool DeleteSubDefine(string code, string bCode)
		{
			int _code, _bCode;
			if (!int.TryParse(code, out _code))
				return false;
			if (!int.TryParse(bCode, out _bCode) || _bCode <= 0)
				return false;
			ClassLibrary.JSubBaseDefine jSubBaseDefine = new ClassLibrary.JSubBaseDefine(_bCode);
			return jSubBaseDefine.Delete(_code);
		}

		[WebMethod(EnableSession = true)]
		public bool SaveSubDefine(string code, string bCode, string text)
		{
			int _code, _bCode;
			int.TryParse(code, out _code);
			if (!int.TryParse(bCode, out _bCode) || _bCode <= 0)
				return false;
			ClassLibrary.JSubBaseDefine jSubBaseDefine = new ClassLibrary.JSubBaseDefine(_bCode, _code);
			jSubBaseDefine.BCode = _bCode;
			jSubBaseDefine.Name = text;

			if (_code > 0)
				return jSubBaseDefine.Update();
			else
				return jSubBaseDefine.Insert() > 0;
		}
	}
}
