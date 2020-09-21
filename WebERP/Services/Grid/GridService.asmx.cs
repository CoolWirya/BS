using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ClassLibrary.DataBase;

namespace WebERP.Services.Grid
{
	/// <summary>
	/// Summary description for GridService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following  line. 
	[System.Web.Script.Services.ScriptService]
	public class GridService : System.Web.Services.WebService
	{
		[WebMethod(EnableSession = true)]
		public void SaveGridQuery(string className, string objectCode, string query)
		{
			if (string.IsNullOrWhiteSpace(className))
			{
				throw new Exception();
				return;
			}
			int _objectCode = 0;
			int.TryParse(objectCode, out _objectCode);
			JQuery jQuery = new JQuery(className, "", _objectCode);
			jQuery.QueryText = query;
			jQuery.Update();
		}
	}
}
