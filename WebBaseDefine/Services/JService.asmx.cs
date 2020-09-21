using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using ClassLibrary;

namespace WebBaseDefine.Services
{
	/// <summary>
	/// Summary description for JUserService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class JService : System.Web.Services.WebService, System.Web.SessionState.IRequiresSessionState
	{
		#region User
		[WebMethod(EnableSession = true)]
		public bool SaveUser(string code, string username, string pass1, string pass2, string status, string personCode)
		{
			//if (!WebClassLibrary.SessionManager.Current.RebuildSessions())
			//	return false;
			int _code = 0;
			int.TryParse(code, out _code);
			Globals.JUser user;
			if (_code > 0)
				user = new Globals.JUser(_code);
			else
				user = new Globals.JUser();
			user.username = username;
			user.Active = status == "فعال";
			user.PCode = int.Parse(personCode);
			if (_code == 0 && pass1.Length == 0) return false;
			if (pass1.Length > 0) user.password = pass1;

			if (_code > 0)
				return user.Update();
			else
				return user.insert() > 0;
		}
		#endregion

		#region Group

		[WebMethod(EnableSession = true)]
		public bool AddGroup(string code, string groupName)
		{
			if (string.IsNullOrWhiteSpace(groupName))
			{
				throw new Exception();
				return false;
			}
			int _code = 0;
			int.TryParse(code, out _code);
			JPermissionGroupDefine pgd = null;
			if (_code > 0)
				pgd = new JPermissionGroupDefine(_code);
			else
				pgd = new JPermissionGroupDefine();
			pgd.GroupName = groupName;
			if (_code > 0)
				return pgd.Update();
			else
				return pgd.Insert() > 0;
		}

		[WebMethod(EnableSession = true)]
		public string AddDecision(string code, string decisionName, string classCode)
		{
			if (string.IsNullOrWhiteSpace(decisionName) || string.IsNullOrWhiteSpace(classCode))
			{
				throw new Exception();
				return "";
			}
			int _code = 0;
			int.TryParse(code, out _code);
			JPermissionDecision pd = null;
			if (_code > 0)
				pd = new JPermissionDecision(_code);
			else
				pd = new JPermissionDecision();
			pd.PermissionDefineCode = int.Parse(classCode);
			pd.Name = decisionName;
			if (_code > 0)
				pd.Update();
			else
				pd.Insert();
			DataTable dt = JPermissionDecisions.GetDataTable(pd.PermissionDefineCode);
			DataSet ds = new DataSet();
			ds.Tables.Add(dt);
			return ds.GetXml();
		}

		[WebMethod(EnableSession = true)]
		public bool AddClass(string code, string className, string sql, string parentCode)
		{
			int _code = 0;
			int.TryParse(code, out _code);
			JPermissionDefineClass cls;
			if (_code > 0)
				cls = new JPermissionDefineClass(_code);
			else
				cls = new JPermissionDefineClass();
			cls.ClassName = className;
			cls.SQL = sql;
			//if (_code == 0)
			cls.ParentCode = int.Parse(parentCode);
			if (_code == 0 && className.Length == 0) return false;
			if (_code > 0)
				return cls.Update();
			else
				return cls.Insert() > 0;
		}

		[WebMethod(EnableSession = true)]
		public void _RemoveUserFromGroup(string groupCode, string userCode)
		{
			int _usercode = 0;
			int _groupcode = 0;
			if (!int.TryParse(userCode, out _usercode) || !int.TryParse(groupCode, out _groupcode))
			{
				throw new Exception();
				return;
			}
			JPermissionGroupUsers gu = new JPermissionGroupUsers();
			gu.GroupCode = _groupcode;
			gu.User_Post_Code = _usercode;
			gu.delete();
		}

		[WebMethod(EnableSession = true)]
		public void _AddUserToGroup(string groupCode, string userCode)
		{
			int _usercode = 0;
			int _groupcode = 0;
			if (!int.TryParse(userCode, out _usercode) || !int.TryParse(groupCode, out _groupcode))
			{
				throw new Exception();
				return;
			}
			JPermissionGroupUsers gu = new JPermissionGroupUsers();
			gu.GroupCode = _groupcode;
			gu.User_Post_Code = _usercode;
			gu.Insert();
		}
		#endregion

		#region Other Person
		[WebMethod(EnableSession = true)]
		public bool SaveOtherPerson(string code, string title, string tel, string address, string desc)
		{
			//if (!WebClassLibrary.SessionManager.Current.RebuildSessions())
			//	return false;
			if (String.IsNullOrWhiteSpace(title))
				throw new Exception();
			int _code = 0;
			int.TryParse(code, out _code);
			JOtherPerson person = null;
			if (_code > 0)
				person = new JOtherPerson(_code);
			else
				person = new JOtherPerson();
			#region Set Control Values To Properties
			person.Phone = tel;
			person.Title = title;
			person.Description = desc;
			person.Address = address;
			#endregion Set Control Values To Properties
			if (_code > 0)
				return person.Update();
			else
			{
				_code = person.insert();
				if (_code <= 0)
					return false;
				person.Code = _code;
				return person.Update(false);
			}
		}
		#endregion

		#region Successor
		[WebMethod(EnableSession = true)]
		public string SaveSuccessor(string code, string postCode, string fromDate, string toDate, string status)
		{
			//if (!WebClassLibrary.SessionManager.Current.RebuildSessions())
			//	return "خطا در اجرا";
			int _code = 0;
			int.TryParse(code, out _code);
			JSuccessor tmpSuccessor = null;
			if (_code > 0)
				tmpSuccessor = new JSuccessor(_code);
			else
				tmpSuccessor = new JSuccessor();
			tmpSuccessor.Successer_post_code = Convert.ToInt32(postCode);
			tmpSuccessor.Person_post_code = JMainFrame.CurrentPostCode;
			tmpSuccessor.Start_date_time = JDateTime.GregorianDate(fromDate);
			tmpSuccessor.End_date_time = JDateTime.GregorianDate(toDate);
			tmpSuccessor.Active = status.ToLower() == "checked";
			if (_code == 0)
				if (tmpSuccessor.Insert() > 0)
					return "ثبت با موفقیت انجام شد";
				else
					return "خطا در ثبت اطلاعات...!";
			else
				if (tmpSuccessor.Update())
					return "ویرایش با موفقیت انجام شد";
				else
					return "خطا در ویرایش اطلاعات...!";
		}

		[WebMethod(EnableSession = true)]
		public string SuccessorPermission(string objectCode, string userPostCode, string fromDate, string toDate, string status)
		{
			//if (!WebClassLibrary.SessionManager.Current.RebuildSessions())
			//	return "خطا در اجرا";
			int _ObjectCode = 0;
			int.TryParse(objectCode, out _ObjectCode);
			JPermissionSuccessor tmp = new JPermissionSuccessor();
			if (_ObjectCode <= 0 || userPostCode.Trim() == "0")
				return "خطا در اجرا";
			tmp.User_Post_Code = int.Parse(userPostCode);
			tmp.Start_Date = JDateTime.GregorianDate(fromDate);
			tmp.End_Date = JDateTime.GregorianDate(toDate);
			tmp.Creator = JMainFrame.CurrentPostCode;
			JPermissionUser pu = new JPermissionUser(_ObjectCode);
			tmp.ObjectCode = pu.ObjectCode;
			tmp.HasPermission = true;
			tmp.DecisionCode = pu.DecisionCode;
			if (status.ToLower() == "checked")
				if (tmp.Insert() > 0)
					return "ثبت دسترسی با موفقیت انجام شد";
				else
					return "خطا در ثبت دسترسی...!";
			else
				if (!tmp.delete())
					return "خطا در حذف دسترسی...!";
				else
					return "حذف با موفقیت انجام شد";
		}
		#endregion
	}
}
