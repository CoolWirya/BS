using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using ClassLibrary;
using ClassLibrary.DataBase;
using System.Drawing;

namespace WebERP.Services
{

	/// <summary>
	/// Summary description for JUserService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class WebBaseDefineService : System.Web.Services.WebService, System.Web.SessionState.IRequiresSessionState
	{
		#region User
		[WebMethod(EnableSession = true)]
		public bool SaveUser(string code, string username, string pass1, string pass2, string status, string personCode)
		{
            if (!WebClassLibrary.SessionManager.Current.MainFrame.isAuthenticated)
                return false;
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
            if (pass1.Length > 0)
            {
                user.password = pass1;
                user.LastPassChangeDate = DateTime.Now;
            }

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
			JPermissionDefineGroup pgd = null;
			if (_code > 0)
				pgd = new JPermissionDefineGroup(_code);
			else
				pgd = new JPermissionDefineGroup();
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
		public void RemoveUserFromGroup(string groupCode, string userPostCode)
		{
			int _usercode = 0;
			int _groupcode = 0;
			if (!int.TryParse(userPostCode, out _usercode) || !int.TryParse(groupCode, out _groupcode))
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
		public void AddUserToGroup(string groupCode, string userPostCode)
		{
			int _usercode = 0;
			int _groupcode = 0;
			if (!int.TryParse(userPostCode, out _usercode) || !int.TryParse(groupCode, out _groupcode))
			{
				throw new Exception();
				return;
			}
			JPermissionGroupUsers gu = new JPermissionGroupUsers();
			gu.GroupCode = _groupcode;
			gu.User_Post_Code = _usercode;
			gu.Insert();
		}

		[WebMethod(EnableSession = true)]
		public string GetAllUsersPosts(string className, string objectCode, string parameters)
		{
			int _objectCode = 0;
			int.TryParse(objectCode, out _objectCode);
			if (_objectCode < 0 || string.IsNullOrWhiteSpace(className))
				return "خطا در پارامترهای ارسالی...!";
			object[] _params = parameters.Split(',').Select(x => Convert.ChangeType(x, typeof(object))).ToArray();
			JQuery jQuery = new JQuery(className, _objectCode, _params);
			string sql = "";
			if (string.IsNullOrWhiteSpace(jQuery.QueryText))
				sql = string.Format("select code,full_title from VOrganizationChart where code not in (select user_post_code from PermissionGroupUsers where groupcode = {0}) order by full_title", parameters);
			else
				sql = jQuery.QueryText;
			DataSet ds = new DataSet();
			ds.Tables.Add(WebClassLibrary.JWebDataBase.GetDataTable(sql));
			return ds.GetXml();
		}

		[WebMethod(EnableSession = true)]
		public string GetGroupUsersPosts(string className, string objectCode, string parameters)
		{
			int _objectCode = 0;
			int.TryParse(objectCode, out _objectCode);
			if (_objectCode < 0 || string.IsNullOrWhiteSpace(className))
				return "خطا در پارامترهای ارسالی...!";
			object[] _params = parameters.Split(',').Select(x => Convert.ChangeType(x, typeof(object))).ToArray();
			JQuery jQuery = new JQuery(className, _objectCode, _params);
			string sql = "";
			if (string.IsNullOrWhiteSpace(jQuery.QueryText))
				sql = string.Format("select code,full_title from VOrganizationChart where code in (select user_post_code from PermissionGroupUsers where groupcode = {0}) order by full_title", parameters);
			else
				sql = jQuery.QueryText;
			DataSet ds = new DataSet();
			ds.Tables.Add(WebClassLibrary.JWebDataBase.GetDataTable(sql));
			return ds.GetXml();
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


		#region JComponent Methods

		[WebMethod(EnableSession = true)]
		public string GetAutoCompleteResult(string query, string sf, string prefix)
		{
			DataSet ds = new DataSet();
			JDataBase db = JGlobal.MainFrame.GetDBO();
            try { query = "select * from (" + query.Replace("?!?", "'") + ")GetAutoCompleteResult_t1 where " + sf + " like N'%" + prefix + "%'";
                db.setQuery(query);
                ds.Tables.Add(db.Query_DataTable());
                return ds.GetXml();
            }
            finally
            {
                db.Dispose();
            }
		}

        #endregion


        #region WebAVL methods

        [WebMethod(EnableSession = true)]
        public string getInfoAndroid(string Data)
        {
            String res ="";
            //Data is IMEI
            AVL.RegisterDevice.JRegisterDevice device = new AVL.RegisterDevice.JRegisterDevice(int.Parse(Data));
            res = string.Format("{0},{1}", device.Name, device.lastSendDate.ToString());
            return res;
        }

        [WebMethod(EnableSession = true)]
        public string getInfo(string id, string groupIDs, bool offline = false)
        {
            /*
             * 
             * To get html string of any type should define a method named GetHtmlString
             * then here will be invoked automatically and will be sent to Map object.
             * 
             */
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();

            try
            {
                List<object> param = new List<object>();
                string Method = "";
                string query = "";
                id = id.Replace("Bus_","");
                string[] s = groupIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (!offline)
                {
                    if (s.Length > 1)
                    {
                        query = "select ad.code,AB.ClassName,AB.ObjectCode from AVLDevice AD left join AVLDeviceObjectHistory ADH ON ADH.devicecode=AD.Code left join AVLObjectList AB on ADH.ObjectCode=AB.Code where AD.Code in (" + groupIDs + ")  and ADH.EndDate is null";
                    }
                    else
                        query = "select top 1 ad.code,AB.ClassName,AB.ObjectCode from AVLDevice AD left join AVLDeviceObjectHistory ADH ON ADH.devicecode=AD.Code left join AVLObjectList AB on ADH.ObjectCode=AB.Code where AD.Code in  (" + id + ") and ADH.EndDate is null";
                }
                else
                {
                    //query = @"select top 1 ad.code,AB.ClassName,AB.ObjectCode
                    //        from AVLDevice AD 
                    //        inner join AVLCoordinate AC on AC.devicecode = AD.Code
                    //        left join AVLDeviceObjectHistory ADH ON ADH.devicecode=AD.Code and AC.DeviceSendDateTime between ADH.StartDate AND ADH.EndDate
                    //        left join AVLObjectList AB on ADH.ObjectCode=AB.Code 
                    //        where AC.code=" + id + "";
                query= @"select top 1 ad.code,AB.ClassName,AC.code as ObjectCode
                            from AVLDevice AD
                            inner
                            join AVLCoordinate AC on AC.devicecode = AD.Code
                            left
                            join AVLObjectList AB on ad.ObjectCode = AB.Code
                            where AC.code = "+id;
                }
                DB.setQuery(query);
                System.Data.DataTable dt = DB.Query_DataTable();

                //System.Data.DataRow dr = dt.Rows[0];
                string res = "";
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    int tCode = (int)dr["Code"];
                    WebClassLibrary.JActionsInfo action = new WebClassLibrary.JActionsInfo();
                    if (int.Parse(id) < 0)
                    {
                        Method = "AVL.Coordinate.JCoordinate.GetHtmlString";
                        param.Add((-1 * int.Parse(id)).ToString());
                    }
                    else
                    {
                        Method = tCode.ToString() + ".GetHtmlString";  // dr["ClassName"].ToString() + ".GetHtmlString";
                        param.Add(dr["ObjectCode"].ToString());

                    }

                    int tObjectCode = 0;
                    int.TryParse(param[0].ToString(), out tObjectCode);
                    JQuery Q = new JQuery(Method, tObjectCode);
                    if (Q.QueryText == null || Q.QueryText.Length == 0)
                    {
                        if (!offline)
                        {
                            Q.QueryText = @"select top 1 AD.Code, isnull(CP.Name+' '+CP.Fam ,'')+'('+isnull(AD.Name,'')+')' Name,AD.lastSendDate,
                                        AD.LastLat,AD.LastLng,AD.lastSpeed,CP.PersonImageCode PicCode from AVLDevice AD
										left join AVLDeviceObjectHistory ADH ON ADH.devicecode=AD.Code
                                        left join AVLObjectList AL ON AL.Code=ADH.ObjectCode AND AL.ClassName =N'ClassLibrary.JPerson'
left join users u on u.code = AD.personCode
                                        left join clsperson CP ON u.pCode=CP.Code
                                        where AD.code={0} and ADH.EndDate is null order by ADH.StartDate desc";
                        }
                        else
                        {
                            Q.QueryText = @"select top 1 AD.Code, isnull(CP.Name+' '+CP.Fam ,'')+'('+isnull(AD.Name,'')+')' Name,AD.lastSendDate,
                                        AD.LastLat,AD.LastLng,AD.lastSpeed,CP.PersonImageCode PicCode,
                                        AC.DeviceSendDateTime,AC.Speed,AC.lat,AC.lng,AC.Battery from AVLDevice AD
										inner join AVLCoordinate AC on AC.devicecode = AD.Code
										left join AVLDeviceObjectHistory ADH ON ADH.devicecode=AD.Code  and AC.DeviceSendDateTime between ADH.StartDate AND ADH.EndDate
                                        left join AVLObjectList AL ON AL.Code=ADH.ObjectCode AND AL.ClassName =N'ClassLibrary.JPerson'
left join users u on u.code = AD.personCode
                                        left join clsperson CP ON u.pCode=CP.Code
                                        where AD.code={0} and AC.Code=" + id + " order by ADH.StartDate desc";
                        }
                    }
                    Q.QueryText = string.Format(Q.QueryText, tCode);
                    DB.setQuery(Q.QueryText);
                    DataTable dtTemp = DB.Query_DataTable();
                    if (dtTemp != null && dtTemp.Rows.Count == 1)
                    {
                        //action.Method = Method;
                        //action.ParameterValue = param;
                        //DB.Dispose();
                        //object Oret = action.runAction();
                        //if (Oret != null)
                        int PicCode = 0;
                        JKeyValue[] List = JDataBase.DataTableColumnToKeyValueArray(dtTemp);
                        if (List.Length > 0)
                        {
                            res += "<table>";
                            foreach (JKeyValue KV in List)
                            {
                                if (KV.Key == "PicCode" && KV.Value.ToString().Length > 0)
                                    PicCode = (int)KV.Value;
                                else
                                {
                                    if (KV.Value is DateTime)

                                        res += "<tr><td>" + JLanguages._Text(KV.Key) + "</td><td>" + JDateTime.FarsiDate((DateTime)KV.Value) + "</td></tr>";
                                    else
                                        res += "<tr><td>" + JLanguages._Text(KV.Key) + "</td><td>" + KV.Value + "</td></tr>";
                                }
                            }
                            res += "</table>";
                            if (PicCode > 0)
                            {
                                res += string.Format("<img width='100px' height='110px' src='/getIcon.aspx?id={0}&t={1}'/>", PicCode, "PicCode");
                            }
                        }
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return ex.Message;
            }
            finally
            {
                DB.Dispose();
            }
        }

        [WebMethod(EnableSession = true)]
        public string getInfoBus(string id, string groupIDs, bool offline = false)
        {
            int Code = Convert.ToInt32(id.Split('_')[1]);
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                if (id.Split('_')[0] == "Bus")
                {
                    List<object> param = new List<object>();
                    string query = "";
                    string[] s = groupIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (!offline)
                    {
                        if (s.Length > 1)
                        {
                            query = "select * from AUTBUS AB where AB.Code in (" + groupIDs + ")";
                        }
                        else
                            query = @"
                                select top 1 
	                            bus.BUSNumber 'شماره اتوبوس', person.Name 'راننده', bus.LastLineNumber 'خط', bus.LastSpeed 'سرعت', 
                                (450 - 2*bus.LastCourse)%360 'زاویه', 
	                            STR(bus.LastLongitude,9,6) 'طول جغرافیایی',STR(bus.LastLatitude,9,6) 'عرض جغرافیایی', bus.LastDate 'آخرین مشاهده', 
	                            (
		                            select top 1 ticket.EventDate 
		                            from AUTTicketTransaction ticket 
		                            where ticket.EventDate between cast(cast(GETDATE() as date) as datetime) and DATEADD(minute,20,getdate()) and ticket.BusCode in  (" + Code + @")
		                            order by ticket.EventDate desc
	                            ) 'آخرین تراکنش بلیط',
	                            (
		                            select count(*) 
		                            from AUTAvlTransaction avl 
		                            where avl.EventDate between cast(cast(GETDATE() as date) as datetime) and DATEADD(minute,20,getdate()) and avl.BusCode in  (" + Code + @")
	                            ) 'تعداد تراکنش کنسول',
	                            bus.TicketCount 'تعداد تراکنش بلیط', bus.LastDriverPersonCode
                            from AUTBUS bus
                            left join clsAllPerson person on person.Code = bus.LastDriverPersonCode
                            where bus.Code in  (" + Code + ")";
                    }
                    else
                    {
                        query = @"
                                select top 1 
	                            bus.BUSNumber 'شماره اتوبوس', person.Name 'راننده', bus.LastLineNumber 'خط', bus.LastSpeed 'سرعت', 
                                (450 - 2*bus.LastCourse)%360 'زاویه', 
	                            STR(bus.LastLongitude,9,6) 'طول جغرافیایی',STR(bus.LastLatitude,9,6) 'عرض جغرافیایی', bus.LastDate 'آخرین مشاهده',  
	                            (
		                            select top 1 ticket.EventDate 
		                            from AUTTicketTransaction ticket 
		                            where ticket.EventDate between cast(cast(GETDATE() as date) as datetime) and DATEADD(minute,20,getdate()) and ticket.BusCode in  (" + Code + @")
		                            order by ticket.EventDate desc
	                            ) 'آخرین تراکنش بلیط',
	                            (
		                            select count(*) 
		                            from AUTAvlTransaction avl 
		                            where avl.EventDate between cast(cast(GETDATE() as date) as datetime) and DATEADD(minute,20,getdate()) and avl.BusCode in  (" + Code + @")
	                            ) 'تعداد تراکنش کنسول',
	                            bus.TicketCount 'تعداد تراکنش بلیط', bus.LastDriverPersonCode
                            from AUTBUS bus
                            left join clsAllPerson person on person.Code = bus.LastDriverPersonCode
                            where bus.Code in  (" + Code + ")";
                    }
                    DB.setQuery(query);
                    System.Data.DataTable dtTemp = DB.Query_DataTable();
                    string res = "";
                    if (dtTemp != null && dtTemp.Rows.Count == 1)
                    {
                        int DriverPCode = 0;
                        JKeyValue[] List = JDataBase.DataTableColumnToKeyValueArray(dtTemp);
                        if (List.Length > 0)
                        {
                            foreach (JKeyValue KV in List)
                            {
                                if (KV.Key == "LastDriverPersonCode" && KV.Value.ToString().Length > 0)
                                    DriverPCode = (int)KV.Value;
                                else
                                {
                                    if (KV.Value is DateTime)

                                        res += "<tr><td>" + JLanguages._Text(KV.Key) + "</td><td style = 'width: 130px'>" + JDateTime.FarsiDate((DateTime)KV.Value) + "</td></tr>";
                                    else
                                        res += "<tr><td>" + JLanguages._Text(KV.Key) + "</td><td style = 'width: 130px'>" + KV.Value + "</td></tr>";
                                }
                            }
                            res = "<table><tr><td><div style = ''><table>" + res + "</table><div></td><td style='vertical-align: top'>";
                            if (DriverPCode > 0)
                                res += string.Format("<img width='100px' height='100px' src='/getIcon.aspx?id={0}&tb={1}'/>", DriverPCode, "DriverPCode");
                            else
                                res += "<img width='100px' height='100px' src='/" + WebClassLibrary.JDomains.Images.ControlImages.NoPersonImage + "'/>";
                            res += "</td></tr></table>";

                            return res;
                        }
                    }
                    return "";
                }
                else if (id.Split('_')[0] == "Lyr0" || id.Split('_')[0] == "Lyr1")
                {
                    JDataBase db = new JDataBase();
                    db.setQuery(@"
                        select LineNumber
                        ,ISNULL(s_last.Code, 0) LastStationCode, cast(dbo.GetDistance2Points(s.Lng, s.Lat, s_last.Lng, s_last.Lat) as int) LastStationDistance
                        ,ISNULL(s_next.Code, 0) NextStationCode, cast(dbo.GetDistance2Points(s.Lng, s.Lat, s_next.Lng, s_next.Lat) as int) NextStationDistance
                        from
                        (
	                        select LineCode, StationCode, IsBack, Priority
	                        , (select MAX(Priority) from AUTLineStation where LineCode = ls.LineCode and IsBack = ls.IsBack) PriorityMax
	                        from AUTLineStation ls where StationCode = "+Code+@"
                        ) ls
                        left join AUTStation s on s.Code = ls.StationCode
                        left join AUTLineStation ls_last on ls_last.LineCode = ls.LineCode and ls_last.IsBack = ls.IsBack and ls_last.Priority = ls.Priority - 1 and ls.Priority > 1
                        left join AUTStation s_last on s_last.Code = ls_last.StationCode
                        left join AUTLineStation ls_next on ls_next.LineCode = ls.LineCode and ls_next.IsBack = ls.IsBack and ls_next.Priority = ls.Priority + 1 and ls.Priority < ls.PriorityMax
                        left join AUTStation s_next on s_next.Code = ls_next.StationCode
                        inner join AUTLine line on line.Code = ls.LineCode
                        order by LineNumber");
                    DataTable dt = db.Query_DataTable();
                    string res = "";
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            res += "<tr><td>خط " + row["LineNumber"] + "</td></tr>";
                            if(row["LastStationCode"].ToString() != "0")
                                res += "<tr><td style = 'width: 130px'>فاصله تا ایستگاه قبل</td><td style = 'width: 80px'>" + row["LastStationDistance"] + " متر</td></tr>";
                            if (row["NextStationCode"].ToString() != "0")
                                res += "<tr><td style = 'width: 130px'>فاصله تا ایستگاه بعد</td><td style = 'width: 80px'>" + row["NextStationDistance"] + " متر</td></tr>";
                        }
                    }
                    BusManagment.Station.JStation Station = new BusManagment.Station.JStation(Code);
                    string StationName = "<tr><td><center>" + Station.Name + "</center></td></tr>";
                    string StationImage = "";
                    if (Station.ImageCode > 0)
                    {
                        StationImage = string.Format("<tr><td style='vertical-align: top'><img src='/getIcon.aspx?id={0}&tb={1}'/></td></tr>", Station.ImageCode, "StationImageCode");
                        //res += "<div style = 'padding-right: 30px;'>" + Station.Name + "</div>";
                    }
                    res = "<table>" + StationName + StationImage + "<tr><td><div style = 'max-height:120px; overflow-y:auto'><table>" + res + "</table><div></td></tr>";
                    res += "</table>";
                    return res;
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return ex.Message;
            }
            finally
            {
                DB.Dispose();
            }
        }


        [WebMethod(EnableSession = true)]
        public String GetMobileConfig(string IMEI)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select Config from  AVLDevice WHERE IMEI='" + IMEI + "'");
                DataTable dt = DB.Query_DataTable();
                if(dt!=null && dt.Rows.Count==1)
                {
                    return dt.Rows[0]["Config"].ToString();
                }
                return "";
            }
            catch
            {

            }
            finally
            {
                DB.Dispose();
            }
            return "";
        }

        [WebMethod(EnableSession = true)]
        public AVL.Controls.Map.GetMarkersOutput GetMarkers(string bounds, string zoom)
        {
            string imei = (zoom.Contains(",")) ? zoom.Split(',')[1] : null;
            AVL.Controls.Map.GetMarkersOutput ret_date = new AVL.Controls.Map.GetMarkersOutput();
            List<AVL.Controls.Map.GCommunicateObject> objects = new List<AVL.Controls.Map.GCommunicateObject>();
            if (WebClassLibrary.SessionManager.Current.MainFrame == null)
                return ret_date;

            string LastParam = "", SavedParam = "";
            int pastDaysCount = 7;
            LastParam = "";
            string seas = "";
            try
            {
                if (!string.IsNullOrEmpty(WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"].ToString()))
                {
                    seas = WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"].ToString();
                    pastDaysCount = 1000;
                }

                if (WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"] != null)
                    WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"] = "";
            }
            catch
            {
            }

            if (WebClassLibrary.SessionManager.Current.Session["WebAVL_Forms_GoogleMap_createGridNORMAL.0.OnlineMapLastFilter"] != null
                && WebClassLibrary.SessionManager.Current.Session["WebAVL_Forms_GoogleMap_createGridNORMAL.0.OnlineMapLastFilter"].ToString().Length > 0)
            {
                LastParam += WebClassLibrary.SessionManager.Current.Session["WebAVL_Forms_GoogleMap_createGridNORMAL.0.OnlineMapLastFilter"].ToString();
                pastDaysCount = 1000;
            }
            if (WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapSavedFilter"] != null)
                SavedParam = WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapSavedFilter"].ToString();

            System.Data.DataTable dt;
            string query = "";
            if (string.IsNullOrEmpty(imei))
            {
                if ((WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin || ClassLibrary.JPermission.CheckPermission("WebAVL.JWebAVL._isMarketer")) && String.IsNullOrEmpty(imei))
                {

                    query = string.Format(@"select * from AVLDevice where Code in(
SELECT jd.childDeviceCode FROM[AVLDB].[dbo].[AVLDevice] d right join 
AVLJoinDevice jd on d.Code=jd.parentDeviceCode ) and lastSendDate BETWEEN '{0}' AND '{1}' {2}",
DateTime.Now.AddDays((-1*  pastDaysCount)),
DateTime.Now.AddHours(4), 
LastParam);
                    //  dt = AVL.RegisterDevice.JRegisterDevices.GetDataTable(false, string.Format(" AND lastSendDate BETWEEN '{0}' AND '{1}'", DateTime.Now.AddHours((-1 * DateTime.Now.Hour)), DateTime.Now.AddHours(4)) + LastParam, 0);
                }
                else
                {
                    query = string.Format(@"select * from AVLDevice where Code in(
SELECT jd.childDeviceCode FROM[AVLDB].[dbo].[AVLDevice] d right join 
AVLJoinDevice jd on d.Code=jd.parentDeviceCode where d.personCode={0}) and lastSendDate BETWEEN '{1}' AND '{2}' {3}",
WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode,
DateTime.Now.AddDays(-1 *  pastDaysCount),
DateTime.Now.AddHours(4) ,
LastParam);
                    // dt = AVL.RegisterDevice.JRegisterDevices.GetDataTable(false, string.Format(" AND lastSendDate BETWEEN '{0}' AND '{1}'", DateTime.Now.AddHours((-1 * DateTime.Now.Hour)), DateTime.Now.AddHours(4)) + LastParam, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
                }
            }
            else
            {
                query = string.Format(@"select * from AVLDevice where 
Code in
(select childDeviceCode from AVLJoinDevice where parentDeviceCode in 
(select ad.Code from AVLDevice ad left join AVLCash c on ad.personCode=c.userCode where c.paid>0 and ad.Code in
(SELECT jd.parentDeviceCode FROM[AVLDB].[dbo].[AVLDevice] d right join 
AVLJoinDevice jd on d.Code=jd.childDeviceCode where d.personCode in
( select personCode from AVLDevice where IMEI='{0}'))
and (ad.justAdminSee='false' or ad.IMEI='{0}') ))

and Code not in

(select ad.Code from AVLDevice ad left join AVLCash c on ad.personCode=c.userCode where   ad.visibility<>'true' and ad.Code in
(SELECT jd.parentDeviceCode FROM[AVLDB].[dbo].[AVLDevice] d right join 
AVLJoinDevice jd on d.Code=jd.childDeviceCode where d.personCode in
( select personCode from AVLDevice where IMEI='{0}'))
)", imei);
            }
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try {
                DB.setQuery(query);
                dt = DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
            
            ret_date.ClearAllMarkers = LastParam != SavedParam;

            WebClassLibrary.SessionManager.Current.Session.Add("WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapSavedFilter", LastParam);
            if (dt == null)
                return ret_date;

            AVL.Controls.Map.BoundsObject NESW = AVL.Controls.Map.GCommunicateObject.BoundsStringtoPoints(bounds);
            //First item of returned array from BoundsStringtoPoints method is alwas South West, and second one is always North East
            AVL.Controls.Map.Point SW = NESW.SouthWest;
            AVL.Controls.Map.Point NE = NESW.NorthEast;
            //Loop through objects returned from AVLObjectList table.
            double x = 0;
            double y = 0;
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Create a point object with latitude and longitude of current row.
                //zarrin
                try
                {
                    double tX, tY;
                    double.TryParse(dt.Rows[i]["LastLat"].ToString(), out tX);
                    double.TryParse(dt.Rows[i]["LastLng"].ToString(), out tY);
                    x = tX;
                    y = tY;
                    
                }
                catch
                {
                    x = 0;
                    y = 0;
                }
                AVL.Controls.Map.PointD p = new AVL.Controls.Map.PointD(x, y);
                //Geofence using a circle. Specify whether point is in the area or not.
                //There is some other types of geofence methods in AVL.Geofence.JGeofence
                //Note that distance between 2 coordinate in map is so small.
                if (x > 0.0 && y > 0.0 &&
                    ((seas.Length != 0 && dt.Rows[i]["Code"].ToString().Trim() == seas) ||
                    ret_date.ClearAllMarkers ||
                    WebClassLibrary.SessionManager.Current.Session["FirstLoadMad"] == null ||
                    (seas.Length == 0 && AVL.Geofence.JGeofence.IsInTheCircle(
                                 new AVL.Controls.Map.Point() { Latitude = SW.Latitude + (NE.Latitude - SW.Latitude) / 2, Longitude = SW.Longitude + (NE.Longitude - SW.Longitude) / 2 },
                                 ((NE.Latitude - SW.Latitude) / 2) > ((NE.Longitude - SW.Longitude) / 2) ? ((NE.Latitude - SW.Latitude) / 2) : ((NE.Longitude - SW.Longitude) / 2),
                                 new AVL.Controls.Map.Point() { Latitude = p.X, Longitude = p.Y })))
                    )
                {
                    //If point is in the area, it is allowed to pass through google map,
                    objects.Add(new AVL.Controls.Map.GCommunicateObject()
                    {
                        Description = ((WebClassLibrary.SessionManager.Current.Session["FirstLoadMad"]) == null) ? "center" : "default",
                        ID = "Bus_" + dt.Rows[i]["Code"].ToString(),
                        Location = p,
                        Course = (int)dt.Rows[i]["lastAngle"],
                        Title = dt.Rows[i]["Name"].ToString(),
                        PCode = new Globals.JUser(int.Parse(dt.Rows[i]["personCode"].ToString())).PCode,
                        date = dt.Rows[i]["lastSendDate"].ToString(),
                      Speed =int.Parse( dt.Rows[i]["lastSpeed"].ToString())
                        //Icon = new WebClassLibrary.JActionsInfo()
                        //{
                        //    Method = new AVL.ObjectList.JObjectList(int.Parse(dt.Rows[i]["ObjectCode"].ToString())).ClassName.ToString() + ".GetIcon",
                        //    ParameterValue = new List<object>() { dt.Rows[i]["ObjectCode"].ToString() }
                        //}.runAction().ToString()
                    });
                    if (!String.IsNullOrEmpty(imei))
                        objects[objects.Count - 1].Title = dt.Rows[i]["Name"].ToString()+ "," +DateTime.Parse( dt.Rows[i]["lastSendDate"].ToString()).ToString("HH:MM");

                }
            }
            try
            {
                if (!string.IsNullOrEmpty(seas) || ret_date.ClearAllMarkers)//OnlineMapCenter= ID
                {
                    if (seas.Length > 0)
                        objects.Find(x1 => x1.ID == "Bus_" + seas.Split(',')[0]).Description = "center";
                    else
                        foreach(AVL.Controls.Map.GCommunicateObject O in objects)
                        {
                            O.Description = "center";
                        }

                }
            }
            catch(Exception e)//Marker is not in map, we add it to map
            {
                AVL.RegisterDevice.JRegisterDevice d = new AVL.RegisterDevice.JRegisterDevice(int.Parse(seas));
                objects.Add(new AVL.Controls.Map.GCommunicateObject()
                {
                    Description = ((WebClassLibrary.SessionManager.Current.Session["FirstLoadMad"]) == null) ? "center" : "default",
                    ID = "Bus_" + d.Code.ToString(),
                    Location = new AVL.Controls.Map.PointD(d.LastLat, d.LastLng),
                    Course = d.lastAngle,
                    Title = d.Name,
                    PCode = new Globals.JUser(d.personCode).PCode,
                    date = d.lastSendDate.ToString(),
                      Speed = (int)d.lastSpeed
                });
            }
            if (objects.Count == 0)
                return ret_date;
            //AVL.Controls.Map.GCommunicateObject[] objectsArray = AVL.Controls.Map.NewMapControl.NewGoogleMap.JoinMarkers(objects, int.Parse(zoom));
            AVL.Controls.Map.GCommunicateObject[] objectsArray = objects.ToArray();
            //if (int.Parse(zoom) > 15)
            int count = 0;
            
            {
                foreach (AVL.Controls.Map.GCommunicateObject g in objectsArray)
                {
                    try
                    {
                        if(!String.IsNullOrEmpty(imei))
                        g.ID=g.ID.Replace("Bus_", "");
                        count = g.GroupIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
                        if (count <= 1)
                        {
                            g.Icon = "getIcon.aspx?t=p&";
                            if (DateTime.Parse(g.date) >= DateTime.Today)
                                g.Icon += "d=t&";//today
                            else
                                g.Icon += "d=p&";//past
                            g.Icon+="id=" + g.ID.Replace("Bus_","");
                        }
                        else
                        {
                            //g.GroupIDs = g.GroupIDs.Remove(g.GroupIDs.Length - 1);
                            g.Icon = "getIcon.aspx?t=g&n=" + count;
                        }
                    }
                    catch
                    {

                    }
                }
                ret_date.ChangingMarkers = AVL.Controls.Map.NewMapControl.NewGoogleMap.SeparateFixMarkers(objectsArray);
                WebClassLibrary.SessionManager.Current.Session.Add("FirstLoadMad", 1);
                return ret_date;
            }
            //int count = 0;
            //foreach (AVL.Controls.Map.GCommunicateObject g in objectsArray)
            //{
            //    count = g.GroupIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
            //    if (count > 1)
            //    {
            //        g.GroupIDs = g.GroupIDs.Remove(g.GroupIDs.Length - 1);
            //        g.Icon = "getIcon.aspx?t=g&n=" + count;
            //    }
            //}
            //return objectsArray;
        }



        //static Dictionary<string, string[]> objects = new Dictionary<string, string[]>();


        //[WebMethod(EnableSession = true)]
        //public object[] GetCoordinates(string bounds, string id)
        //{
        //    string[] bb = { };
        //    int currentUserCode=WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
        //    if (id == "-1")
        //    {
        //        try
        //        {
        //            List<AVL.Controls.Map.GCommunicateObject> __datas = new List<AVL.Controls.Map.GCommunicateObject>();
        //            //Clear __datas data, and fill it with new data arrived from database.
        //            __datas.Clear();
        //            bb = AVL.Coordinate.JCoordinate.GetObjects(bounds);
        //            if (!objects.ContainsKey(currentUserCode.ToString()))
        //                objects.Add(currentUserCode.ToString(), bb);
        //            else
        //                objects[currentUserCode.ToString()] = bb;
        //            return bb;
        //        }
        //        catch
        //        {
        //            return new string[0];
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            List<AVL.Controls.Map.GCommunicateObject> s = AVL.Coordinate.JCoordinate.GetCommunicationObjects(bounds,id, objects, currentUserCode);
        //            return s.ToArray();
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //    return null;

        //} 


        //[WebMethod(EnableSession = true)]
        //public string GetInfo(int id)
        //{
        //    /*
        //     * 
        //     * To get html string of any type should define a method named GetHtmlString
        //     * then here will be invoked automatically and will be sent to Map object.
        //     * 
        //     */
        //    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();

        //    try
        //    {
        //        List<object> param = new List<object>();
        //        string Method="";
        //        string query="";
        //        if (id < 0)//it means request from Offline map, and a simple marker info request                
        //            query = @"select a.* from (SELECT row_number() over(order by [DeviceSendDateTime]  ) as Row, *  FROM [AVLCoordinate] ) as a where a.Code=" + (-1 * id).ToString();                
        //        else//Online map request
        //            query = @"SELECT top 1  [ClassName],ObjectCode FROM AVLObjectList where Code=" + id;

        //        DB.setQuery(query);
        //        System.Data.DataTable dt = DB.Query_DataTable();

        //        System.Data.DataRow dr = dt.Rows[0];
        //        WebClassLibrary.JActionsInfo action = new WebClassLibrary.JActionsInfo();
        //        if (id < 0)
        //        {
        //            Method = "AVL.Coordinate.JCoordinate.GetHtmlString";
        //            param.Add((-1 * id).ToString());
        //        }
        //        else
        //        {
        //            Method = dr[0].ToString() + ".GetHtmlString";
        //            param.Add(dr[1].ToString());
        //        }
        //        action.Method = Method;
        //        action.ParameterValue = param;
        //        DB.Dispose();
        //        return action.runAction().ToString();


        //    }
        //    catch (Exception ex)
        //    {
        //        ClassLibrary.JSystem.Except.AddException(ex);
        //        return ex.Message;
        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //    }
        //}
        [WebMethod(EnableSession = true)]
        public AVL.Controls.Map.GCommunicateObject[] GetDirectionForAndroid(string pcode, string startdate, string enddate,string startrow,string lastrow)
        {
            Globals.JUser u = new Globals.JUser(int.Parse(pcode), true);
            AVL.RegisterDevice.JRegisterDevice device = new AVL.RegisterDevice.JRegisterDevice();
            device.GetData(u.code);
            //check if someone paid for this device
            bool haspaid = false;
            foreach (DataRow dr in AVL.JoinDevice.JJoinDevices.GetData(device.Code).Rows)
                if (new Accounting.Cash.JCash(0,new AVL.RegisterDevice.JRegisterDevice(int.Parse(dr["parentDeviceCode"].ToString())).personCode).paid > 0)
                {
                    //someone paid for this device, so we do not need to check other parents
                    haspaid = true;
                    break;
                }
            if (!haspaid)
                return new AVL.Controls.Map.GCommunicateObject[0];
            device.GetData(u.code);
            System.Data.DataTable dt = AVL.Coordinate.JCoordinates.GetDataTablePoints(device.Code.ToString(), startdate, enddate,startrow,lastrow,false);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            List<AVL.Controls.Map.GCommunicateObject> objects = new List<AVL.Controls.Map.GCommunicateObject>();

            foreach (DataRow dr in dt.Rows)
            {
                objects.Add(new AVL.Controls.Map.GCommunicateObject()
                {
                    Location = new AVL.Controls.Map.PointD(double.Parse(dr["lat"].ToString()), double.Parse(dr["lng"].ToString())),                   
                });
            }
            return objects.ToArray();
        }
        [WebMethod(EnableSession = true)]
        public AVL.Controls.Map.GCommunicateObject[] GetDirection(string devicecode, string startdate, string enddate, string lastrow)
        {
            string tLastRow = (int.Parse(lastrow) + 100).ToString();
            System.Data.DataTable dt = AVL.Coordinate.JCoordinates.GetDataTablePoints(devicecode, startdate, enddate, (int.Parse(lastrow)+1).ToString(), tLastRow);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            List<AVL.Controls.Map.GCommunicateObject> objects = new List<AVL.Controls.Map.GCommunicateObject>();
            int index = int.Parse(lastrow);
            AVL.Controls.Map.GCommunicateObject LastSpeedZero = new AVL.Controls.Map.GCommunicateObject();
            int a = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if(int.Parse(dr["Speed"].ToString()) == 0)
                a++;
                double dis = AVL.Geofence.JGeofence.distance(
                        new AVL.Controls.Map.Point() { Latitude = double.Parse(dr["lat"].ToString()), Longitude = double.Parse(dr["lng"].ToString()) },
                        new AVL.Controls.Map.Point() { Latitude = LastSpeedZero.Location.X, Longitude = LastSpeedZero.Location.Y });
                if ((int.Parse(dr["Speed"].ToString()) == 0 && (LastSpeedZero.ID == "Bus_" + 0 || dis > 100 ) ) || int.Parse(dr["Speed"].ToString()) != 0 || (a >= 10 ))
                {
                    objects.Add(new AVL.Controls.Map.GCommunicateObject()
                    {
                        Description = ((WebClassLibrary.SessionManager.Current.Session["FirstLoadMad"]) == null) ? "center" : "default",
                        ID = "Bus_" + dr["Code"].ToString(),
                        Location = new AVL.Controls.Map.PointD(double.Parse(dr["lat"].ToString()), double.Parse(dr["lng"].ToString())),
                        row = int.Parse(dr["row"].ToString()),
                        Speed = int.Parse(dr["Speed"].ToString()),
                        Icon = (int.Parse(dr["Speed"].ToString())<2 ? "/WebAVL/Icons/current_location_Stop.png" : "/WebAVL/Icons/current_location.png")
                    });
                    if (int.Parse(dr["Speed"].ToString()) < 2)
                    {
                        LastSpeedZero.Description = ((WebClassLibrary.SessionManager.Current.Session["FirstLoadMad"]) == null) ? "center" : "default";
                        LastSpeedZero.ID = "Bus_" + dr["Code"].ToString();
                        LastSpeedZero.Location = new AVL.Controls.Map.PointD(double.Parse(dr["lat"].ToString()), double.Parse(dr["lng"].ToString()));
                        LastSpeedZero.row = int.Parse(dr["row"].ToString());
                        LastSpeedZero.Speed = int.Parse(dr["Speed"].ToString());
                        LastSpeedZero.Icon = "/WebAVL/Icons/current_location_Stop.png";
                    }
                    a = 0;
                }
                index++;
            }
            if (objects.Count == 0)
                return GetDirection(devicecode, startdate, enddate, lastrow + index);
            else
            {
                objects[objects.Count - 1].row = index;
                return objects.ToArray();
            }
        }



        [WebMethod(EnableSession = true)]
        public string ObjectCheckedChange(string ids, string status)
        {
            string lastPart = "";
            string checkked;
            if (status.Contains("checked"))
                checkked = "true";
            else
                checkked = "false";
            if (ids.Contains(","))
                lastPart = " IN(" + ids.Remove(ids.Length - 1) + ")";
            else
                lastPart = "=" + ids;

            if (WebClassLibrary.JWebDataBase.ExecuteQuery("UPDATE AVLObjectList SET isActive='" + checkked + "' WHERE Code " + lastPart) > 0)
                return "ثبت شد.";
            else
                return "خطا در ثبت ...!";
        }
        
            
        [WebMethod(EnableSession = true)]
        public string UserObjectCheckedChange(string ids, string status,string ParentUserCode,string userCode)
        {
            try
            {
                AVL.SubUserObjects.jSubUserObjects subUserObjects = new AVL.SubUserObjects.jSubUserObjects(ParentUserCode, userCode);

                if (status.Contains("checked"))
                    subUserObjects.objects += ids + ",";
                else
                {
                    subUserObjects.objects = subUserObjects.objects.Remove(subUserObjects.objects.IndexOf(ids), ids.Length + 1);
                }
                subUserObjects.parentUserCode =int.Parse( ParentUserCode);
                subUserObjects.userCode =int.Parse( userCode);
                if (subUserObjects.Code > 0)
                    subUserObjects.Update();
                else
                    subUserObjects.Insert(false, true);

                return "ثبت شد.";
            }
            catch
            {
                return "خطا در ثبت ...!";
            }
        }
        [WebMethod(EnableSession = true)]
        public bool SaveDevice(string code, string imei, string deviceType, string SendType, string dataFormat, string registerDateTime, string speed,string Name,string ObjectCode,string config)
        {
            try
            {//if (!WebClassLibrary.SessionManager.Current.RebuildSessions())
                //	return false;
                int _code = 0;
                config = config.Replace("checked", "1").Replace("undefined", "0");
                int.TryParse(code, out _code);
                AVL.RegisterDevice.JRegisterDevice device;
                if (_code > 0)
                    device = new AVL.RegisterDevice.JRegisterDevice(_code);
                else
                {
                    device = new AVL.RegisterDevice.JRegisterDevice(imei);   
                }
                _code = device.Code;
                //  device.Code = 1;
                if (ObjectCode.Length > 0)
                    device.ObjectCode = int.Parse(ObjectCode);
                //if (device.ObjectCode == 0)
                    //device.ObjectCode = 0;//new AVL.ObjectList.JObjectList(0, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode).Code;
                device.IMEI = long.Parse(imei);
                device.Name = Name;
                device.DeviceType = byte.Parse(deviceType);
                device.SendType = byte.Parse(SendType);
                device.DataFormat = dataFormat;
                device.speed = int.Parse(speed);
                device.RegisterDateTime = DateTime.Parse(registerDateTime);
                if (_code <= 0)
                {
                    device.personCode = -1;
                }
                else
                    device.personCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                device.Config = config;
                bool res = false;
                if (_code > 0)
                    res= device.Update(true);
                else
                    res= device.Insert(Accounting.Config.getTaxPercentage(),Accounting.Config.getDeviceRegisterPrice(),true) > 0;
                if (device.personCode == -1)
                {
                    string key = GenerateJoinKey(imei);
                    SetMessage("شما به گروه ---- دعوت شدید. در صورت تمایل کد را در قسمت چت وارد کنید. " + key, imei, "0", "1");
                }
                if (_code > 0 && res)
                {
                    AVL.RegisterDevice.DeviceObjectHistory.JDeviceObjectHistory doh = new AVL.RegisterDevice.DeviceObjectHistory.JDeviceObjectHistory();
                    if (!string.IsNullOrEmpty(ObjectCode) && int.Parse(ObjectCode) > 0)
                    {
                        System.Data.DataTable dt = AVL.RegisterDevice.DeviceObjectHistory.JDeviceObjectHistories.GetDataTable(_code);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (System.Data.DataRow dr in dt.Rows)
                                if (string.IsNullOrEmpty(dr["EndDate"].ToString()) && ObjectCode != dr["ObjectCode"].ToString())
                                {
                                    doh.Code = int.Parse(dr["Code"].ToString());
                                    doh.DeviceCode = int.Parse(dr["DeviceCode"].ToString());
                                    doh.EndDate = DateTime.Today;
                                    doh.ObjectCode = int.Parse(dr["ObjectCode"].ToString());
                                    doh.StartDate = DateTime.Parse(dr["StartDate"].ToString());
                                    doh.Update();
                                    doh = new AVL.RegisterDevice.DeviceObjectHistory.JDeviceObjectHistory();
                                    doh.StartDate = DateTime.Today;
                                    doh.ObjectCode = int.Parse(ObjectCode);
                                    doh.DeviceCode = _code;
                                    doh.Insert();
                                    break;
                                }
                        }
                        else
                        {
                            doh.DeviceCode = _code;
                            doh.StartDate = DateTime.Today;
                            doh.ObjectCode = int.Parse(ObjectCode);
                            doh.Insert();
                        }
                    }
                }
                return res;
            }
            catch (Exception e)
            {
                return false;
            }
        }
      

        [WebMethod(EnableSession = true)]
        public string NewsFeed(string IMEI)
        {
            return "خبرخوان فعال نمی باشد.";
        }
        [WebMethod(EnableSession = true)]
        public string PurhaseDetails(string Data)
        {
            AVL.RegisterDevice.JRegisterDevice device = new AVL.RegisterDevice.JRegisterDevice(Data);
            Accounting.Cash.JCash cash = new Accounting.Cash.JCash(0, device.personCode);
            DataTable dt= AVL.JoinDevice.JJoinDevices.GetData(0, device.Code);
            AVL.RegisterDevice.JRegisterDevice childDevice;
            AVL.Device.JDeviceModel model;
            float price = 0;
            int counter = 0;
            foreach (DataRow dr in dt.Rows)
            {
                childDevice = new AVL.RegisterDevice.JRegisterDevice(int.Parse(dr["childDeviceCode"].ToString()));
                if (childDevice.Code == device.Code)
                    continue;
                model = new AVL.Device.JDeviceModel();
                model.GetData(childDevice.DeviceType.ToString());
                price += model.UnitPrice;
                counter++;
            }
            //day,group count,cash amount
            //تعداد روزی که مانده تا صندوق خالی شود.
            return ((int)cash.paid/  price ).ToString()+","+counter+","+cash.paid;
        }
        
        private Globals.JUser addPersonanduser(string IMEI)
        {
            ClassLibrary.JPerson person = new ClassLibrary.JPerson();
            person.Name = IMEI;
            person.Fam = "";
            person.ShMeli = "";
            person.FatherName = "";
            person.ShSh = "";
            person.PDesc = "";

            Globals.JUser user = new Globals.JUser();
            user.Active = true;
            user.PCode = person.insertAVL(false, false);
            user.username = IMEI;
            user.password = (rnd.Next(10000, 99999) + long.Parse(IMEI.Substring(0, 4))).ToString();
            user.code = user.insertAVL(false);

            ClassLibrary.JPersonAddress pa = new ClassLibrary.JPersonAddress();
            pa.Email = "";
            pa.Mobile = "";
            pa.PCode = user.PCode;
            pa.Address = "";
            pa.AddressType = ClassLibrary.JAddressTypes.Work;
            pa.PostalCode = "";
            pa.Tel = "";
            pa.WebSite = "";
            pa.Fax = "";
            pa.ClassName = "AVL";
            //user.code = user.insertAVL(false);
            pa.Insert();
            Employment.JEOrganizationChart oc = new Employment.JEOrganizationChart();
            oc.user_code = user.code;
            oc.parentcode = 0;
            oc.InsertNode();// false);
            ClassLibrary.JPermissionGroupUsers gu = new ClassLibrary.JPermissionGroupUsers();
            gu.User_Post_Code = oc.code;
            gu.GroupCode = 1;// کد گروه
            gu.Insert(false);


            return user;
        }
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public AVL.RegistrationKey CheckRegistration(string pData)
        {
            string[] Data = pData.Split(new char[] { '/' });
            if (Data.Length != 2)
                return null;
            string IMEI = Data[0];
            string IMEIDec = Data[1]!=null? Data[1]:"";


            AVL.RegisterDevice.JRegisterDevice device = new AVL.RegisterDevice.JRegisterDevice(IMEI);
            if (device.Code < 1 )//اگر دستگاه ثبت نشده بود ، یک کاربر جدید با دستگاهش ثبت شود.
            {
                Globals.JUser user=addPersonanduser(IMEI);
                    device.IMEI = long.Parse(IMEI);
                    device.Name = "نام خود را وارد کنید";
                    device.DeviceType = 2;
                    device.SendType = 0;
                    device.DataFormat = "0";
                    device.speed = 0;
                    device.PurchasePlanCode = 1;
                    device.RegisterDateTime = DateTime.Now;
                    device.personCode = user.code;
                    device.Config = "1,1,1,1,1,1,1,8,22,600";
                    device.PurchasePlanCode = 1;
                    device.visibility = true;
                    device.Insert(false, false);
                
                    device.personCode = user.code;
                    device.Update();
                AVL.JoinDevice.JJoinDevice jd = new AVL.JoinDevice.JJoinDevice();
                jd.registerDate = DateTime.Now;
                jd.parentDeviceCode = jd.childDeviceCode = device.Code;
                jd.Insert();

                Accounting.Cash.JCash jCash = new Accounting.Cash.JCash();
                jCash.paid = (50000);
                jCash.userCode = (user.code);
                jCash.Insert(false, true);
            }
            else
            {
                if(device.personCode ==-1)
                {
                    device.personCode = addPersonanduser(IMEI).code;
                    device.Update(false, false);
                }
                AVL.JoinDevice.JJoinDevice jd = new AVL.JoinDevice.JJoinDevice();
                if (!jd.GetData(string.Format("parentDeviceCode={0} and childDeviceCode={0}",device.Code)))
                {
                    jd.registerDate = DateTime.Now;
                    jd.parentDeviceCode = jd.childDeviceCode = device.Code;
                    jd.Insert();
                }
            }
            if (device.keyPass != null && device.keyPass.Length > 0)
            {
                if (IMEIDec != device.keyPass)
                    ;// return null;
            }

            AVL.RegistrationKey res = new AVL.RegistrationKey();
            if (string.IsNullOrEmpty(device.keyPass))
            {
                string key = "";
                Random r = new Random();
                for (int i = 0; i < 10; i++)
                    key += r.Next(0, 9);
                device.keyPass = key;
                device.Update(true,false);
                res.key = key;
            }
            else
                res.key = "true";
            res.sendRate = device.Config.Split(',')[9];
            res.pmsg = "روزانه مبلغ 250 تومان از حساب کاربری شما به ازای هر کاربر عضو گروه شما کم می شود.";
            res.visibility = (device.visibility) ? "1" : "0";
            //1 = mellat gateway,   0=bazar gateway
            res.ptype = (device.marketerCode > 0) ? "1":"0";
            res.justadminsee= (device.justAdminSee) ? "1" : "0";
            return res;
        }


        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string GeofenceOperations(string imei,string clientCode, string center,string radius,string name,string operation)
        {
            try {
                AVL.RegisterDevice.JRegisterDevice d = new AVL.RegisterDevice.JRegisterDevice(imei);
                if (operation == "1")//Add new geofence
                {
                    //AVL.Purchase.JPurchasePlan plan = new AVL.Purchase.JPurchasePlan(d.PurchasePlanCode.ToString());
                    //DataTable areas = AVL.Area.JAreas.GetAreas(d.Code, d.personCode);
                    //if (areas.Rows.Count >= plan.geoCount)
                    //    return "-1," + areas.Rows.Count;
                    Accounting.Cash.JCash cash = new Accounting.Cash.JCash(0, d.personCode);
                    if (cash.paid <= 0)
                        return "-1,";
                    AVL.Area.JArea area = new AVL.Area.JArea();
                    area.isCircle = true;
                    area.Name = name;
                    area.Points = center;
                    area.radius = decimal.Parse(radius);
                    area.IsGeofence = true;
                    area.personCode = d.personCode;
                    area.deviceCode = d.Code;
                    area.clientAreaCode = int.Parse(clientCode);
                    DataTable childdevices = AVL.JoinDevice.JJoinDevices.GetData(0, d.Code);
                    string s = "";
                    foreach (DataRow dr in childdevices.Rows)
                        s += new AVL.RegisterDevice.JRegisterDevice(int.Parse(dr["childDeviceCode"].ToString())).ObjectCode + ",";
                    area.ObjectsCodes = s;
                    if (area.Insert() > 0)
                        //                               Name~Points~radius~clientAreaCode~ownerDeviceCOde
                        return area.Name + "~" + area.Points + "~" + area.radius + "~" + area.clientAreaCode+"~"+d.Code;
                    else
                        return "0";
                }
                else if (operation == "2")//Edit Geofence
                {
                    AVL.Area.JArea area = new AVL.Area.JArea();
                    area.GetData(d.Code.ToString(), d.personCode,name);
                    area.Points = center;
                    area.radius = decimal.Parse(radius);
                    area.isCircle = true;
                    area.IsGeofence = true;
                    area.Name = name;
                    area.deviceCode = d.Code;
                    DataTable childdevices = AVL.JoinDevice.JJoinDevices.GetData(0, d.Code);
                    string s = "";
                    foreach (DataRow dr in childdevices.Rows)
                        s += new AVL.RegisterDevice.JRegisterDevice(int.Parse(dr["childDeviceCode"].ToString())).ObjectCode + ",";
                    area.ObjectsCodes = s;
                    area.Update();
                }
                else if (operation == "3")//Delete Geofence
                {
                    AVL.Area.JArea area = new AVL.Area.JArea();
                    area.GetData(d.Code.ToString(), d.personCode,name);
                    area.Delete();
                }
                else if (operation == "4")
                {
                    DataTable joins = AVL.JoinDevice.JJoinDevices.GetData(d.Code, 0);
                    string data = "";
                    string isOwner = "0";
                    foreach (DataRow join in joins.Rows)
                    {
                        if (d.Code == int.Parse(join["parentDeviceCode"].ToString()))
                            isOwner = "1";
                        else
                            isOwner = "0";
                        DataTable dt = AVL.Area.JAreas.GetAreas(int.Parse(join["parentDeviceCode"].ToString()),0);
                        foreach (DataRow dr in dt.Rows)//Name~Points~radius~clientAreaCode~0 or 1|
                            data += dr["Name"].ToString() + "~" + dr["Points"].ToString() + "~" + dr["radius"].ToString() + "~" + dr["clientAreaCode"].ToString() +"~"+isOwner+ "~"+ join["parentDeviceCode"].ToString() + "|";
                    }
                    return data;
                }
                return "1";
            }
            catch(Exception er)
            {
                return er.Message;
            }
        }

        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string GeofenceEvent(string message, string imei, string areaOwnerCode){
            Chat.JChat C;
            AVL.RegisterDevice.JRegisterDevice d = new AVL.RegisterDevice.JRegisterDevice(imei);
            AVL.RegisterDevice.JRegisterDevice otherDevice;
            AVL.RegisterDevice.JRegisterDevice parent = new AVL.RegisterDevice.JRegisterDevice(int.Parse(areaOwnerCode));
            if (new Accounting.Cash.JCash(0, parent.personCode).paid < 1)
                return "-1";
           DataTable dt2 = AVL.JoinDevice.JJoinDevices.GetData(0, parent.Code);
            foreach (DataRow dr2 in dt2.Rows)
            {
                if (d.Code == int.Parse(dr2["childDeviceCode"].ToString()))
                    continue;
                otherDevice = new AVL.RegisterDevice.JRegisterDevice(int.Parse(dr2["childDeviceCode"].ToString()));
                C = new Chat.JChat();
                C.message = message;
                C.sender = imei;
                C.senderName = d.Name;
                C.receiver = otherDevice.IMEI.ToString();
                C.registerDate = DateTime.Now;
                C.GroupID = parent.Code;
                C.messageType = -1;
                C.Insert();
            }
            return "1";
        }
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string SetMessage(string message, string imei,string gpID,string msgtype)
        {
            try {
                //get device which generated event or message
                AVL.RegisterDevice.JRegisterDevice d = new AVL.RegisterDevice.JRegisterDevice(imei);
                //if (gpID=="0")
                //{
                //    gpID = d.Code.ToString();
                //}
                
                //get all device which d is their child
                DataTable dt = AVL.JoinDevice.JJoinDevices.GetData(d.Code, 0);
                if (dt == null || dt.Rows.Count == 0)
                    return "0";
                Chat.JChat C;
                AVL.RegisterDevice.JRegisterDevice otherDevice,parent;
                DataTable dt2;
                foreach (DataRow dr in dt.Rows)
                {
                    //if gpID=0 (means it is event) and gpID == parentdevice (means it is event sender) continue
                    if (int.Parse(gpID)!=0&&int.Parse(gpID) != int.Parse(dr["parentDeviceCode"].ToString()))
                        continue;
                    //get parentdevice as a RegisterDevice object
                    parent = new AVL.RegisterDevice.JRegisterDevice(int.Parse(dr["parentDeviceCode"].ToString()));
                    //check if parent has enough charge, if not, go to next loop
                    if (new Accounting.Cash.JCash(0,parent.personCode).paid < 1)
                        continue;
                    // get all the childs of parent
                    dt2 = AVL.JoinDevice.JJoinDevices.GetData(0, parent.Code);
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        //check if child is  event generator, 
                        if (d.Code == int.Parse(dr2["childDeviceCode"].ToString()))
                            continue;
                        //get child as Registerdevice object
                        otherDevice = new AVL.RegisterDevice.JRegisterDevice(int.Parse(dr2["childDeviceCode"].ToString()));
                        //creat a chat and insert to chat table in database
                        C = new Chat.JChat();
                        C.message = message;
                        C.sender = imei;
                        C.senderName = d.Name;
                        C.receiver = otherDevice.IMEI.ToString();
                        C.registerDate = DateTime.Now;
                        C.GroupID = int.Parse(gpID);
                        C.messageType = int.Parse(msgtype);
                        C.Insert();
                    }
                }
                return "1";
            }
            catch(Exception er)
            {
                return er.Message;
            }
        }

        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string GroupsList(string Data)
        {
            AVL.RegisterDevice.JRegisterDevice d = new AVL.RegisterDevice.JRegisterDevice(Data);
            //get all the group which device is joined before using childDeviceCode
            //childDeviceCode
            DataTable dt = AVL.JoinDevice.JJoinDevices.GetData(d.Code,0);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            string gps ="";
            AVL.RegisterDevice.JRegisterDevice parentDevice;
            DataTable dt2;
            foreach (DataRow dr in dt.Rows)
            {
                parentDevice = new AVL.RegisterDevice.JRegisterDevice(int.Parse(dr["parentDeviceCode"].ToString()));

                Accounting.Cash.JCash cash = new Accounting.Cash.JCash(0, parentDevice.personCode);
                if (cash.paid <= 0)
                    continue;
                gps += parentDevice.Code + "~" + parentDevice.Name;
                if (int.Parse(dr["parentDeviceCode"].ToString()) == int.Parse(dr["childDeviceCode"].ToString()))
                    gps += ";;;";//this means arrived imei is owner of group
                gps+= "~" + new Globals.JUser(parentDevice.personCode).PCode;
                dt2 = AVL.JoinDevice.JJoinDevices.GetData(0, parentDevice.Code);
                if (dt2 != null)
                {
                    gps += "~";
                foreach (DataRow dr2 in dt2.Rows)
                        gps += dr2["childDeviceCode"].ToString()+"-"+new AVL.RegisterDevice.JRegisterDevice(int.Parse(dr2["childDeviceCode"].ToString())).Name+";";
                }
                gps += ",";
            }
            return gps;
        }
        private T requestToServer<T>(T data, String url, string parameters)
        {
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();

            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            if (!String.IsNullOrEmpty(parameters))
            {
                byte[] d = System.Text.Encoding.ASCII.GetBytes(parameters);

                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = d.Length;

                using (var stream = req.GetRequestStream())
                {
                    stream.Write(d, 0, d.Length);
                }
            }
            try
            {
            System.IO.StreamReader reader = new System.IO.StreamReader(req.GetResponse().GetResponseStream());
            
                data = js.Deserialize<T>(reader.ReadToEnd());
            }
            catch (Exception)
            {
               
            }
                return data;
        }
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string Purchase(string gateway,string price,string Data,string imei)
        {
            if (gateway == "bazar")// Data is json string
            {
            AVL.RegisterDevice.JRegisterDevice devie = new AVL.RegisterDevice.JRegisterDevice(imei);
                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                AVL.AndroidBazarPurchaseJson.JAndroidBazarPurchaseJson parsedData= js.Deserialize<AVL.AndroidBazarPurchaseJson.JAndroidBazarPurchaseJson>(Data);
                parsedData.deviceCode = devie.Code;
                //get token
                //
                AVL.AndroidBazarPurchaseJson.BazarTokenData token = new AVL.AndroidBazarPurchaseJson.BazarTokenData();
               token= requestToServer<AVL.AndroidBazarPurchaseJson.BazarTokenData>(token, "https://pardakht.cafebazaar.ir/devapi/v2/auth/token/", string.Format("grant_type=refresh_token&client_id={1}&client_secret={2}&refresh_token={0}", "ugsvpbHqVykb7Iy5yIYpA8gZZWpgwS", "6BabqRWpFjupJev0rZzvxVggm5YlQl7qwCp0sczI", "Wr4XbtyFzoZXTJujfFD2p8NMoKNmvV4D653cnl2O8bVJggLPWat2v9wItFaL", "http://tstracker.ir/test"));
                if (token.access_token!=null && token.access_token.Length > 2)
                {
                    //varify from bazar
                    AVL.AndroidBazarPurchaseJson.BazaarPurchaseVarifyData data = new AVL.AndroidBazarPurchaseJson.BazaarPurchaseVarifyData();
                    data = requestToServer(data, string.Format("https://pardakht.cafebazaar.ir/devapi/v2/api/validate/ir.tsip.tracker.zarrintracker/inapp/{0}/purchases/{1}/?access_token={2}", parsedData.productId, parsedData.purchaseToken,token.access_token), null);
                    if (data.purchaseState !=null &&data.purchaseTime.Equals(parsedData.purchaseTime) && data.purchaseState.Equals("0"))
                    {
                        if (new AVL.AndroidBazarPurchaseJson.JAndroidBazarPurchaseJson().GetData(" [purchaseToken]='"+parsedData.purchaseToken+"'"))
                            return "ERROR";
                        parsedData.Insert();
                     // AVL.Purchase.JPurchasePlan plan = new AVL.Purchase.JPurchasePlan(devie.PurchasePlanCode);
                        Accounting.Factor.JFactor jfactor = new Accounting.Factor.JFactor();
                        jfactor.Discount = 0;
                        jfactor.Number = 0;
                        jfactor.payState = true;
                        jfactor.RegisterDate = DateTime.Now;
                        jfactor.Tax = 0;
                        jfactor.Total = decimal.Parse(price);
                        jfactor.userCode = devie.personCode;
                        jfactor.Insert();
                        Accounting.Cash.JCash cash = new Accounting.Cash.JCash(0, devie.personCode);
                        cash.paid += decimal.Parse(price);
                        cash.Update(true, false);
                      //  devie.PurchasePlanCode = plan.code;
                        devie.Update(true, false);

                        return "1";
                    }
                }
                return "error";
            }
            return "0";
        }

        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string SaveImage(string Data )
        {
            Byte[] binary =Convert.FromBase64String(Data);
            byte[] _imei = new byte[binary[0]];
            System.Buffer.BlockCopy(binary, 1, _imei, 0, _imei.Length);
            string imei = System.Text.Encoding.UTF8.GetString(_imei,0,_imei.Length);
            Byte[] bytes = new byte[binary.Length - (_imei.Length+1)];
            System.Buffer.BlockCopy(binary, _imei.Length + 1, bytes, 0, binary.Length - (_imei.Length + 1));
            AVL.RegisterDevice.JRegisterDevice devie = new AVL.RegisterDevice.JRegisterDevice(imei);
            ClassLibrary.JPerson person = new ClassLibrary.JPerson(new Globals.JUser(devie.personCode,false).PCode);
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                ClassLibrary.JFile jFile = new ClassLibrary.JFile();
                jFile.Content = bytes;
                jFile.FileName = "profilePhoto.jpg";
                jFile.Extension = System.IO.Path.GetExtension(jFile.FileName);
                jFile.FileText = jFile.FileName;
                if (person.PersonImageCode > 0 && archive.Retrieve(person.PersonImageCode))
                    archive.UpdateArchive(jFile, archive.Code, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, "تصویر شخص");
                else
                    person.PersonImageCode = archive.ArchiveDocument(jFile, person.GetType().FullName, person.Code, JLanguages._Text("PersonPicture"), true);
                person.UpdateAvl();
            }
            catch { }
            return "1";
        }
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string KickUser(string Data)
        {
            try
            {
                int devicecode = int.Parse(Data.Split(',')[0]);
                int groupcode = int.Parse(Data.Split(',')[1]);
                AVL.JoinDevice.JJoinDevice jd = new AVL.JoinDevice.JJoinDevice();
                jd.GetData(string.Format(" parentDeviceCode={0} AND childDeviceCode={1} ", groupcode, devicecode));
                if (jd.Delete())
                {
                    return groupcode.ToString();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string LeaveGroup(string imei,string gpID)
        {
            try
            {
                AVL.RegisterDevice.JRegisterDevice d = new AVL.RegisterDevice.JRegisterDevice(imei);
                AVL.JoinDevice.JJoinDevice jd = new AVL.JoinDevice.JJoinDevice();
                jd.GetData(string.Format(" parentDeviceCode={0} AND childDeviceCode={1} ", int.Parse(gpID), d.Code));
                if (jd.Delete())
                {
                    return gpID;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string loadprofile(string Data)
        {
            //devicename;;;phone;;;email
            string res = "";
            AVL.RegisterDevice.JRegisterDevice devie = new AVL.RegisterDevice.JRegisterDevice(Data);
            res = devie.Name + ";;;";
            ClassLibrary.JPersonAddress pa = new JPersonAddress(new Globals.JUser(devie.personCode, false).PCode);
            res += pa.Mobile + ";;;" + pa.Email;

            res += ";;;" + new Globals.JUser(devie.marketerCode).username;
            return res;
        }

        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string LoadImageById(string Data)
        {
            ClassLibrary.JPerson person = new ClassLibrary.JPerson(int.Parse(Data));
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                if (archive.Retrieve(person.PersonImageCode))
                {
                    ClassLibrary.JFile image = archive.Content;
                    if (image != null)
                    {
                        string s = Data+";;;"+ Convert.ToBase64String( image.Content);
                        return s;
                    }
                }
            }
            catch { }
            return "NOIMAGE";
        }


        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string loadimage(string Data)
        {
            AVL.RegisterDevice.JRegisterDevice devie = new AVL.RegisterDevice.JRegisterDevice(Data);
            ClassLibrary.JPerson person = new ClassLibrary.JPerson(new Globals.JUser(devie.personCode, false).PCode);
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                if (archive.Retrieve(person.PersonImageCode))
                {
                    ClassLibrary.JFile image = archive.Content;
                    if (image != null)
                    {
                        string s = Convert.ToBase64String(image.Content);
                        return s;
                    }
                }
            }
            catch { }
            return "NOIMAGE";
        }
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string[] GetMessage(string imei, String gpID)
        {
            //msgtype=0            get all messages
            //msgtype=1,2,3,...    get chat messages of specified group
            //msgtype=-1           get geofenceEvents
            //msgtype=-2           get sos event
            //msgtype=-3           get gps events
            //msgtype=-4           get pause events
            //msgtype=-10

            DataTable dt = Chat.JChats.GetMessages(long.Parse(imei).ToString(), gpID);
            if (dt == null || dt.Rows.Count == 0)
                return null;// new string[] { string.Format(@"SELECT *  FROM AVLChat where receiver='{0}' AND GroupID={1}", imei, gpID) };

            string[] msgs = new string[dt.Rows.Count];
            try
            {
                int i = 0;
                int msgtype = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(dr["senderName"].ToString()))
                    {
                        msgs[i] = "";
                        try
                        {
                            msgs[i] += new Globals.JUser(new AVL.RegisterDevice.JRegisterDevice(dr["sender"].ToString()).personCode).PCode.ToString();
                        }
                        catch (Exception er)
                        {

                        }
                        msgs[i] += "~~~";
                        if (dr["sender"].ToString() == dr["receiver"].ToString())
                            msgs[i] += "~~ME~~";
                        msgtype = int.Parse(dr["messageType"].ToString());
                        //[C||E||G](date) [from] : message
                        if (msgtype == -10)
                            msgs[i] += "[G]";
                        else if (msgtype == -1)
                            msgs[i] += "[E-area]";
                        else if (msgtype == -2)
                            msgs[i] += "[E-sos]";
                        else if (msgtype == -3)
                            msgs[i] += "[E-gps]";
                        else if (msgtype == -4)
                            msgs[i] += "[E-pause]";
                        else if (msgtype < 0)
                            msgs[i] += "[E]";
                        else
                            msgs[i] += "[C]";
                        msgs[i] += "!" + dr["GroupID"].ToString() + "!";
                        msgs[i++] += "(" + dr["registerDate"].ToString() + ") [" +
                            dr["senderName"].ToString() + "] : " +
                            dr["message"].ToString();
                    }
                    new Chat.JChat().Delete(int.Parse(dr["code"].ToString()));
                }
            }
            catch (Exception er)
            {
                System.IO.File.AppendAllText(@"C:\123\getMessagesWebServiceErrors.txt", er.Message + " [" + DateTime.Now + "](StackTrace" + er.StackTrace + ")" + Environment.NewLine + Environment.NewLine);

            }
            return msgs;
        }
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string justadminsee(string Data)
        {
            AVL.RegisterDevice.JRegisterDevice device = new AVL.RegisterDevice.JRegisterDevice(Data);
            device.justAdminSee = !device.justAdminSee;
            device.Update(true, false);
            return "1";
        }
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string VisibilityState(string Data)
        {
            AVL.RegisterDevice.JRegisterDevice device = new AVL.RegisterDevice.JRegisterDevice(Data);
            device.visibility = !device.visibility;
            device.Update(true,false);
            return "1";
        }
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string AddDevice(string key,string imei)
        {
            AVL.AndroidKeys.JAndroidKey akey = new AVL.AndroidKeys.JAndroidKey();
            if (akey.GetValidByKey(key))
            {
                AVL.JoinDevice.JJoinDevice jd = new AVL.JoinDevice.JJoinDevice();
                AVL.RegisterDevice.JRegisterDevice child = new AVL.RegisterDevice.JRegisterDevice(imei);
                jd.childDeviceCode = child.Code;
                AVL.AndroidKeys.JAndroidKey k = new AVL.AndroidKeys.JAndroidKey();
                k.GetData(" RegKey ='" + key + "'");
                AVL.RegisterDevice.JRegisterDevice parent = new AVL.RegisterDevice.JRegisterDevice(k.IMEI);
                jd.parentDeviceCode = parent.Code;
                jd.registerDate = DateTime.Now;
                //below if statement check if device doesnt joined to group before
                if (!new AVL.JoinDevice.JJoinDevice().GetData("parentDeviceCode=" + jd.parentDeviceCode + " AND childDeviceCode =" + jd.childDeviceCode))
                    if (jd.Insert() > 0)
                    {
                        if(parent.marketerCode>0 && child.marketerCode<1)
                        {
                            child.marketerCode = parent.marketerCode;
                            child.Update(true,false);
                        }
                        return "1";
                    }
                return "-1";
            }
            return "0";
        }

        [WebMethod(EnableSession = true)]
        public string DeviceDetails(string Data)
        {
            try
            {
                string[] datas = Data.Split(',');
                AVL.RegisterDevice.JRegisterDevice device = new AVL.RegisterDevice.JRegisterDevice(datas[0]);

                device.IMEI = long.Parse(datas[0]);
                device.DeviceType =(byte) AVL.DeviceType.Person;
                device.SendType = (byte) AVL.SendType.WebService;
                device.speed =0;
                device.RegisterDateTime = DateTime.Now;
                device.Factory = datas[1];
                device.Model = datas[2];
                device.OSVersion = datas[3];
                device.personCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                if (device.Code > 0)
                     device.Update(true);
                else
                    device.Insert() ;
                return "1";
            }
            catch
            {
                return "0";
            }
        }

        static Random rnd = new Random();
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string GenerateJoinKey(string imei)
        {
            return AVL.JoinDevice.JJoinDevice.GenerateJoinKey(imei);
            //AVL.RegisterDevice.JRegisterDevice d = new AVL.RegisterDevice.JRegisterDevice(imei);
            ////AVL.Purchase.JPurchasePlan plan = new AVL.Purchase.JPurchasePlan(d.PurchasePlanCode.ToString());
            ////DataTable childs = AVL.JoinDevice.JJoinDevices.GetData(0,d.Code);
            ////if (childs.Rows.Count >= plan.personCount)
            ////    return "-1," + childs.Rows.Count;
            //Accounting.Cash.JCash cash = new Accounting.Cash.JCash(0, d.personCode);
            //if (cash.paid <= 0)
            //    return "-1,";
            //AVL.AndroidKeys.JAndroidKey k = new AVL.AndroidKeys.JAndroidKey();
            //k.ExpireDate = DateTime.Now.AddMinutes(15);
            //k.IMEI = imei;
            //k.RegKey =rnd.Next(100000,999999).ToString();
            //if (k.Insert() > 0)
            //{
            //    //add device itself to its own group
            //    //AVL.JoinDevice.JJoinDevice jd = new AVL.JoinDevice.JJoinDevice();
            //    //AVL.RegisterDevice.JRegisterDevice d = new AVL.RegisterDevice.JRegisterDevice(imei);
            //    //if (!jd.GetData(" parentDeviceCode= " + d.Code))//check if group made before
            //    //{
            //    //    jd.registerDate = DateTime.Now;
            //    //    jd.parentDeviceCode = jd.childDeviceCode = d.Code;
            //    //    jd.Insert();
            //    //}
            //    return k.RegKey;
            //}
            //return "0";
        }

        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string SaveProfile(string Data)
        {
            Data = HttpUtility.UrlDecode(Data);
            string[] Param = Data.Split(new string[] { ";;;" } , StringSplitOptions.None);
            string IMEI = Param[0];
            string Name = Param[1];
            string Phone = Param[2];
            string Email = Param[3];
            string ActiveCode = Param[4];

            JDataBase DB = new JDataBase();
            try
            {
                Globals.JUser u = new Globals.JUser();
               
                string marketercode = "";
                if (u.GetDataByMarketerCode(ActiveCode))
                    marketercode = " ,marketerCode= "+u.code;
                DB.setQuery("UPDATE AVLDevice set Name=N'" + Name + "'"+marketercode+" where IMEI='" + IMEI + "'");
                DB.Query_Execute();
                DB.setQuery(string.Format( @"UPDATE clsPersonAddress set Mobile='{0}',Email='{1}' where PCode=(
SELECT PCode from users
where Code = (select top 1 personCode from AVLDevice
where IMEI ='{2}'))",Phone,Email,IMEI));
                DB.Query_Execute();
                return "1";
            }
            catch
            {
                return "0";
            }
            finally
            {
                DB.Dispose();
            }
        }

            
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string SaveAvlMobile(string Data)
        {
            System.Threading.Thread T = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(SaveAvlMobileThread));

            Object[] Send =new Object[] {Data,T};
            T.Start(Send);
            return "1";
        }

        public void SaveAvlMobileThread(object pData)
        {

            try
            {
            string Data = (string)(pData as Object[])[0];
            //System.IO.File.AppendAllText("C:\\123\\data.txt", Data);
            //System.Threading.Thread T = (System.Threading.Thread)(pData as Object[])[1];
            string[] d= Data.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            Data = d[1];
            string IMEI = d[0];
                string[] dataArray = Data.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                string[] gpsData;
                AVL.RegisterDevice.JRegisterDevice device;//= new AVL.RegisterDevice.JRegisterDevice();
                device = new AVL.RegisterDevice.JRegisterDevice(IMEI);
                if (device == null || device.Code == 0 || device.keyPass == null || device.keyPass.Length ==0 )
                    return;

                //Data = ClassLibrary.JEnryption.DecryptStr(Data, device.keyPass);

                AVL.ObjectList.JObjectList ol = new AVL.ObjectList.JObjectList();
                AVL.Coordinate.JCoordinate coordinate = new AVL.Coordinate.JCoordinate();
                bool deviceUpdate = false;
                foreach (string s in dataArray)
                {
                    gpsData = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (device.Code > 0)
                    {
                        coordinate.Altitude = float.Parse(gpsData[2]);
                        coordinate.Angle = Convert.ToInt32(float.Parse(gpsData[4]));
                        coordinate.DeviceCode = device.Code;
                        coordinate.DeviceSendDateTime = DateTime.Parse(gpsData[5]);
                        coordinate.IMEI = IMEI;
                        coordinate.lat = float.Parse(gpsData[0]);
                        coordinate.lng = float.Parse(gpsData[1]);
                        coordinate.ObjectCode = device.ObjectCode;
                        coordinate.RegisterDateTime = DateTime.Now;
                        coordinate.Speed = float.Parse(gpsData[3]);
                        coordinate.Battery = ((int)float.Parse(gpsData[6])).ToString();
                        if (gpsData.Length > 7)
                            coordinate.location = gpsData[7];
                        if (coordinate.Insert(true, false) > 0)
                        {
                            if (device.lastSendDate < coordinate.DeviceSendDateTime)
                            {
                                deviceUpdate = true;
                                device.LastBattery = coordinate.Battery;
                                device.lastAltitude = coordinate.Altitude;
                                device.lastAngle = coordinate.Angle;
                                device.LastLat = coordinate.lat;
                                device.LastLng = coordinate.lng;
                                device.lastSpeed = coordinate.Speed;
                                device.lastSendDate = coordinate.DeviceSendDateTime;

                            }
                        }
                        else
                        {
                            //AVL.Tools.AvlTestInsert((string)(pData as Object[])[0], JDateTime.FarsiDate(DateTime.Now));
                        }
                    }
                }
                if (deviceUpdate && !device.Update(true, false))
                {
                    deviceUpdate = false;
                    //AVL.Tools.AvlTestInsert("deviceUpdated", "data");
                }
            }
            catch (Exception ex)
            {
                //AVL.Tools.AvlTestInsert(er.Message, "Catch AVLSaveDevice");
                ClassLibrary.JMainFrame.Except.AddException(ex);
                //AVL.Tools.AvlTestInsert((string)(pData as Object[])[0], JDateTime.FarsiDate(DateTime.Now));
            }
            finally
            {
                try
                {
                    //T.Abort();
                    //T = null;
                    GC.Collect();
                }
                catch
                {

                }
            }

        }


        [WebMethod(EnableSession = true)]
        public object GetGPSData(string[] Data)
        {
            AVL.RegisterDevice.JRegisterDevice device = new AVL.RegisterDevice.JRegisterDevice("IMEI");
            if (device.Code <= 0)
                return "NO DEVICE";
            Accounting.Cash.JCash cash = new Accounting.Cash.JCash(0, device.personCode);
            AVL.Device.JDeviceModel model = new AVL.Device.JDeviceModel();
            if (!model.GetData(device.DeviceType.ToString()))
                return "NO DEVICE MDOEL";
            if (cash.paid <= (decimal)(-1 * (model.UnitPrice * 7)))
                return "NO ENOUGH CHARGE";
            AVL.GPSData.JDataKeeper dataKeeper = new AVL.GPSData.JDataKeeper(model.Code);
            if (dataKeeper.Code <= 0)
                return "NO DATA FOR EXTRACTION";
            WebClassLibrary.JActionsInfo action = new WebClassLibrary.JActionsInfo();
            action.Method = dataKeeper.ExtractorMethod;
            if (bool.Parse(action.runAction().ToString()))
                return "SUCCESFULL";
            else
                return "SOMTHING GOES WRONG";
            return 0;
        }

        #endregion


        #region Bus

        [WebMethod(EnableSession = true)]
        public void ToggleStyle(string StyleName, bool AddingStyle)
        {
            if (AddingStyle)
            {
                if (WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastStyle"] == null)
                {
                    WebClassLibrary.SessionManager.Current.Session.Add("WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastStyle"
                        , new List<string>() { StyleName });
                }
                else
                {
                    List<string> styles = (List<string>)
                        WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastStyle"];
                    styles.Add(StyleName);
                    //WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastStyle"]
                    //    = styles;
                }
            }
            else // when removing a style
            {
                if (WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastStyle"] != null)
                {
                    List<string> styles = (List<string>)
                        WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastStyle"];
                    if (styles.Where(p => p == StyleName).Count() > 0)
                    {
                        styles.Remove(styles.Where(p => p == StyleName).First());
                        //WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastStyle"]
                        //    = styles;
                    }
                }
            }
        }
        [WebMethod(EnableSession = true)]
        public AVL.Controls.Map.GetBusesOutput[] GetBuses(int LineCode)
        {
            List<AVL.Controls.Map.GetBusesOutput> ret_data = new List<AVL.Controls.Map.GetBusesOutput>();
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            DataTable dt = new DataTable();
            string[] Param = new string[1] { "@LineCode" };
            try
            {
                dt = Db.ExecuteProcedure_Query("[dbo].[SP_OnlinePathData]", Param, LineCode.ToString());
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                Db.Dispose();
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    ret_data.Add(
                    new AVL.Controls.Map.GetBusesOutput()
                    {
                        BusCode = Convert.ToInt32(row["BusCode"]),
                        BusNumber = Convert.ToInt32(row["BusNumber"]),
                        MovePercent = Convert.ToDouble(row["MovePercent"]),
                        IsBack = Convert.ToBoolean(row["IsBack"]),
                        StationCode = Convert.ToInt32(row["StationCode"]),
                        Priority = Convert.ToInt16(row["Priority"]),
                        NextStationIsBack = Convert.ToBoolean(row["NextStationIsBack"]),
                        NextStationCode = Convert.ToInt32(row["NextStationCode"]),
                        NextStationPriority = Convert.ToInt16(row["NextStationPriority"]),
                        PathChanging = Convert.ToBoolean(row["PathChanging"])
                    });

                }
            }
            return ret_data.ToArray();
        }
        [WebMethod(EnableSession = true)]
        public AVL.Controls.Map.GetLineStationsOutput GetLineStations(int LineCode) 
        {
            AVL.Controls.Map.GetLineStationsOutput ret_data = new AVL.Controls.Map.GetLineStationsOutput();
            List<AVL.Controls.Map.Station> GoStations = new List<AVL.Controls.Map.Station>();
            List<AVL.Controls.Map.Station> BackStations = new List<AVL.Controls.Map.Station>();
            System.Data.DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("select ls.StationCode, ls.IsBack, ls.Priority, s.Name from autlinestation ls inner join autstation s on s.Code = ls.StationCode where LineCode = " + LineCode + " order by ls.IsBack, ls.Priority");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    if (Convert.ToBoolean(row["IsBack"]))
                    {
                        BackStations.Add(
                        new AVL.Controls.Map.Station()
                        {
                            Code = Convert.ToInt32(row["StationCode"]),
                            Priority = Convert.ToInt32(row["Priority"]),
                            Name = row["Name"].ToString()
                        });
                    }
                    else
                    {
                        GoStations.Add(
                        new AVL.Controls.Map.Station()
                        {
                            Code = Convert.ToInt32(row["StationCode"]),
                            Priority = Convert.ToInt32(row["Priority"]),
                            Name = row["Name"].ToString()
                        });
                    }
                }
                ret_data.GoStations = GoStations.ToArray();
                ret_data.BackStations = BackStations.ToArray();
            }
            return ret_data;
        }
        [WebMethod(EnableSession = true)]
        public AVL.Controls.Map.GetLayerOutput GetStationsGo()
        {
            AVL.Controls.Map.GetLayerOutput ret_date = new AVL.Controls.Map.GetLayerOutput();
            List<AVL.Controls.Map.LayerMarker> objects = new List<AVL.Controls.Map.LayerMarker>();
            List<string> Labels = new List<string>();
            ret_date.HasLabel = true;
            string LastParam = "";
            if (WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastFilter"] != null
                && WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastFilter"].ToString().Length > 0)
            {
                LastParam += WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastFilter"].ToString();
            }
            System.Data.DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select distinct s.Code, Lat, Lng, l.color, s.Name
                from AUTStation s
                inner join AUTLineStation ls on  ls.StationCode = s.Code
                inner join AUTLine l on l.Code=ls.LineCode
                inner join AUTBus b on b.LastLineNumber = l.LineNumber
                where b.Code in 
                (
                    SELECT Code FROM
                            (
                                SELECT bus.Code
	                            ,bus.LastDate
	                            ,bus.BUSNumber
							    ,bus.LastLineNumber LineNumber
	                            ,bus.LastPersonCode DriverPersonCode
							    ,driver.Name DriverName
							    ,BusOwner.Name OwnerName
	                            ,bus.LastLatitude Latitude
	                            ,bus.LastLongitude Longitude
	                            ,bus.lastAltitude Altitude
	                            ,bus.lastCourse Course
	                            ,bus.lastSpeed Speed
                                FROM AUTBus bus 
                                LEFT JOIN AUTBusOwner owner ON owner.BusCode = bus.Code
							    LEFT JOIN CLSAllPerson driver ON driver.Code = bus.LastDriverPersonCode
							    LEFT JOIN CLSAllPerson BusOwner ON BusOwner.Code = owner.CodePerson
                                WHERE bus.Active = 1 AND bus.IsValid = 1
                            )tbl1 WHERE 1=1" + LastParam + @"
                ) and ls.IsBack = 0");
            if (dt == null)
                return ret_date;

            double x;
            double y;
            int color;

            // setting image url and image size
            string IconUrl = "../WebBusManagement/Images/station_s32.png";
            string ImagePath = Server.MapPath(IconUrl);
            Bitmap Icon = new Bitmap(ImagePath);
            ret_date.IconSize = Icon.Size;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x = 0;
                y = 0;
                color = -1;
                try
                {
                    double.TryParse(dt.Rows[i]["Lat"].ToString(), out x);
                    double.TryParse(dt.Rows[i]["Lng"].ToString(), out y);
                    Int32.TryParse(dt.Rows[i]["color"].ToString(), out color);

                }
                catch
                {
                }
                AVL.Controls.Map.PointD p = new AVL.Controls.Map.PointD(x, y);
                if (x > 0.0 && y > 0.0)
                {
                    AVL.Controls.Map.LayerMarker obj = new AVL.Controls.Map.LayerMarker()
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["Code"].ToString()),
                        Location = p,
                        IconUrl = "getIcon.aspx?t=s&color=" + color
                    };
                    Labels.Add(dt.Rows[i]["Name"].ToString());
                    objects.Add(obj);
                }
            }
            ret_date.Labels = Labels.ToArray();
            ret_date.Markers = objects.ToArray();
            return ret_date;
        }
        [WebMethod(EnableSession = true)]
        public AVL.Controls.Map.GetLayerOutput GetStationsBack()
        {
            AVL.Controls.Map.GetLayerOutput ret_date = new AVL.Controls.Map.GetLayerOutput();
            List<AVL.Controls.Map.LayerMarker> objects = new List<AVL.Controls.Map.LayerMarker>();
            List<string> Labels = new List<string>();
            ret_date.HasLabel = true;
            string LastParam = "";
            if (WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastFilter"] != null
                && WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastFilter"].ToString().Length > 0)
            {
                LastParam += WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastFilter"].ToString();
            }
            System.Data.DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select distinct s.Code, Lat, Lng, l.color, s.Name
                from AUTStation s
                inner join AUTLineStation ls on  ls.StationCode = s.Code
                inner join AUTLine l on l.Code=ls.LineCode
                inner join AUTBus b on b.LastLineNumber = l.LineNumber
                where b.Code in 
                (
                    SELECT Code FROM
                            (
                                SELECT bus.Code
	                            ,bus.LastDate
	                            ,bus.BUSNumber
							    ,bus.LastLineNumber LineNumber
	                            ,bus.LastPersonCode DriverPersonCode
							    ,driver.Name DriverName
							    ,BusOwner.Name OwnerName
	                            ,bus.LastLatitude Latitude
	                            ,bus.LastLongitude Longitude
	                            ,bus.lastAltitude Altitude
	                            ,bus.lastCourse Course
	                            ,bus.lastSpeed Speed
                                FROM AUTBus bus 
                                LEFT JOIN AUTBusOwner owner ON owner.BusCode = bus.Code
							    LEFT JOIN CLSAllPerson driver ON driver.Code = bus.LastDriverPersonCode
							    LEFT JOIN CLSAllPerson BusOwner ON BusOwner.Code = owner.CodePerson
                                WHERE bus.Active = 1 AND bus.IsValid = 1
                            )tbl1 WHERE 1=1" + LastParam + @"
                ) and ls.IsBack = 1");
            if (dt == null)
                return ret_date;

            double x;
            double y;
            int color;

            // setting image url and image size
            string IconUrl = "../WebBusManagement/Images/station_s32.png";
            string ImagePath = Server.MapPath(IconUrl);
            Bitmap Icon = new Bitmap(ImagePath);
            ret_date.IconSize = Icon.Size;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x = 0;
                y = 0;
                color = -1;
                try
                {
                    double.TryParse(dt.Rows[i]["Lat"].ToString(), out x);
                    double.TryParse(dt.Rows[i]["Lng"].ToString(), out y);
                    Int32.TryParse(dt.Rows[i]["color"].ToString(), out color);

                }
                catch
                {
                }
                AVL.Controls.Map.PointD p = new AVL.Controls.Map.PointD(x, y);
                if (x > 0.0 && y > 0.0)
                {
                    AVL.Controls.Map.LayerMarker obj = new AVL.Controls.Map.LayerMarker()
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["Code"].ToString()),
                        Location = p,
                        IconUrl = "getIcon.aspx?t=s&color=" + color
                    };
                    Labels.Add(dt.Rows[i]["Name"].ToString());
                    objects.Add(obj);
                }
            }
            ret_date.Labels = Labels.ToArray();
            ret_date.Markers = objects.ToArray();
            return ret_date;
        }
        [WebMethod(EnableSession = true)]
        public AVL.Controls.Map.GetMarkersOutput GetBusMarkers(string bounds, string zoom)
        {
            AVL.Controls.Map.GetMarkersOutput ret_date = new AVL.Controls.Map.GetMarkersOutput();
            List<AVL.Controls.Map.GCommunicateObject> objects = new List<AVL.Controls.Map.GCommunicateObject>();
            if (WebClassLibrary.SessionManager.Current.MainFrame == null)
                return ret_date;

            string LastParam = "", SavedParam = "", RulesQuery = "", RulesName = "";
            List<string> LastStyle = new List<string>(); 
            if (WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastStyle"] != null)
            {
                LastStyle = (List<string>)WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastStyle"];
            }
            string StyleWhere = "";
            foreach(string style in LastStyle)
            {
                StyleWhere += " and " + style + " = N'بلی'";
            }

            if (WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastFilter"] != null)
            {
                LastParam = WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastFilter"].ToString();
            }
            if (WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapSavedFilter"] != null)
                SavedParam = WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapSavedFilter"].ToString();
            if (WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.RulesQuery"] != null)
                RulesQuery = WebClassLibrary.SessionManager.Current.Session
                    ["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.RulesQuery"].ToString();
            if (WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.RulesName"] != null)
                RulesName = WebClassLibrary.SessionManager.Current.Session
                    ["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.RulesName"].ToString();
            ret_date.ClearAllMarkers = LastParam + StyleWhere != SavedParam;
            WebClassLibrary.SessionManager.Current.Session.Add("WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapSavedFilter", LastParam + StyleWhere);

            string LatLngLimit = " AND Latitude BETWEEN @CountryMinLat AND @CountryMaxLat AND Longitude BETWEEN @CountryMinLng AND @CountryMaxLng"
                .Replace("@CountryMinLat", JConfig.CountryMinLat.ToString()).Replace("@CountryMaxLat", JConfig.CountryMaxLat.ToString())
                .Replace("@CountryMinLng", JConfig.CountryMinLng.ToString()).Replace("@CountryMaxLng", JConfig.CountryMaxLng.ToString());
            System.Data.DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(
                 @"SELECT * FROM
                            (
                                SELECT bus.Code
	                            ,bus.LastDate
	                            ,bus.BUSNumber
							    ,bus.LastLineNumber LineNumber
	                            ,bus.LastDriverPersonCode DriverPersonCode
							    ,isnull(driver.Name,'') DriverName
							    ,BusOwner.Name OwnerName
	                            ,bus.LastLatitude Latitude
	                            ,bus.LastLongitude Longitude
	                            ,bus.lastAltitude Altitude
	                            ,bus.lastCourse Course
                                " + RulesQuery + @"
                                FROM AUTBus bus 
                                LEFT JOIN AUTBusOwner owner ON owner.BusCode = bus.Code
							    LEFT JOIN CLSAllPerson driver ON driver.Code = bus.LastDriverPersonCode
							    LEFT JOIN CLSAllPerson BusOwner ON BusOwner.Code = owner.CodePerson
                                WHERE bus.Active = 1 AND bus.IsValid = 1 AND bus.LastDate > DATEADD(hour,-24,getdate())
                                AND " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetDataTable", "bus.Code") + @"
                            )tbl1 WHERE 1=1" + LastParam + StyleWhere + LatLngLimit);
            if (dt == null)
                return ret_date;
            AVL.Controls.Map.BoundsObject NESW = AVL.Controls.Map.GCommunicateObject.BoundsStringtoPoints(bounds);
            //First item of returned array from BoundsStringtoPoints method is alwas South West, and second one is always North East
            AVL.Controls.Map.Point SW = NESW.SouthWest;
            AVL.Controls.Map.Point NE = NESW.NorthEast;
            //Loop through objects returned from AVLObjectList table.
            double x = 0;
            double y = 0;
            int course = 0;
            string seas = "";
            try
            {
                if (WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"] != null)
                    seas = WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"].ToString();

                if (WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"] != null)
                    WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"] = "";
            }
            catch
            {
            }
            List<int> LastSeriBusesCode = AVL.Controls.Map.NewMapControl.NewGoogleMap.LastSeriBusesCode();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Create a point object with latitude and longitude of current row.
                //zarrin
                try
                {
                    double tX, tY;
                    int tCourse;
                    double.TryParse(dt.Rows[i]["Latitude"].ToString(), out tX);
                    double.TryParse(dt.Rows[i]["Longitude"].ToString(), out tY);
                    Int32.TryParse(dt.Rows[i]["Course"].ToString(), out tCourse);
                    x = tX;
                    y = tY;
                    course = (-tCourse * 2 + 450) % 360;

                }
                catch
                {
                    x = 0;
                    y = 0;
                    course = 0;
                }
                AVL.Controls.Map.PointD p = new AVL.Controls.Map.PointD(x, y);
                //Geofence using a circle. Specify whether point is in the area or not.
                //There is some other types of geofence methods in AVL.Geofence.JGeofence
                //Note that distance between 2 coordinate in map is so small.
                if (x > 0.0 && y > 0.0)
                {
                    string Style = "";
                    if (!string.IsNullOrEmpty(RulesName))
                    {
                        string[] _RuluesName = RulesName.Split(',');
                        for (int j = 0; j < _RuluesName.Count(); j++)
                        {
                            if (dt.Rows[i][_RuluesName[j]].ToString() == "بلی")
                                Style += _RuluesName[j] + ",";
                        }
                    }

                    if ((seas.Length != 0 && dt.Rows[i]["Code"].ToString().Trim() == seas) ||
                    WebClassLibrary.SessionManager.Current.Session["FirstLoadMad"] == null ||
                    (seas.Length == 0 &&
                            AVL.Geofence.JGeofence.IsInTheCircle(
                                 new AVL.Controls.Map.Point() { Latitude = SW.Latitude + (NE.Latitude - SW.Latitude) / 2, Longitude = SW.Longitude + (NE.Longitude - SW.Longitude) / 2 },
                                 ((NE.Latitude - SW.Latitude) / 2) > ((NE.Longitude - SW.Longitude) / 2) ? ((NE.Latitude - SW.Latitude) / 2) : ((NE.Longitude - SW.Longitude) / 2),
                                 new AVL.Controls.Map.Point() { Latitude = p.X, Longitude = p.Y })
                        ))
                    {
                        AVL.Controls.Map.GCommunicateObject obj = new AVL.Controls.Map.GCommunicateObject()
                        {
                            Description = ((WebClassLibrary.SessionManager.Current.Session["FirstLoadMad"]) == null) ? "center" : "default",
                            ID = "Bus_" + dt.Rows[i]["Code"].ToString(),
                            Location = p,
                            Course = course,
                            Title = dt.Rows[i]["BusNumber"].ToString(),
                            Style = Style,
                            Series = 0
                        };
                        objects.Add(obj);
                    }
                    else if (seas.Length == 0 && LastSeriBusesCode.Contains(Convert.ToInt32(dt.Rows[i]["Code"].ToString().Trim())))
                    {
                        AVL.Controls.Map.GCommunicateObject obj = new AVL.Controls.Map.GCommunicateObject()
                        {
                            Description = ((WebClassLibrary.SessionManager.Current.Session["FirstLoadMad"]) == null) ? "center" : "default",
                            ID = "Bus_" + dt.Rows[i]["Code"].ToString(),
                            Location = p,
                            Course = course,
                            Title = dt.Rows[i]["BusNumber"].ToString(),
                            Style = Style,
                            Series = -1
                        };
                        objects.Add(obj);
                    }
                }
            }
            try
            {
                if (!string.IsNullOrEmpty(seas) || ret_date.ClearAllMarkers)//OnlineMapCenter= ID
                {
                    objects.Find(x1 => x1.ID == "Bus_" + seas.Split(',')[0]).Description = "center";
                }
            }
            catch
            {

            }
            if (objects.Count == 0)
                return ret_date;
            //AVL.Controls.Map.GCommunicateObject[] objectsArray = AVL.Controls.Map.NewMapControl.NewGoogleMap.JoinMarkers(objects, int.Parse(zoom));
            AVL.Controls.Map.GCommunicateObject[] objectsArray = objects.ToArray();
            //if (int.Parse(zoom) > 15)
            int count = 0;
            {
                foreach (AVL.Controls.Map.GCommunicateObject g in objectsArray)
                {
                    try
                    {
                        count = g.GroupIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
                        if (count <= 1)
                        {
                            g.Icon = "getIcon.aspx?t=a&AngleIndex=0&Style=";
                        }
                        else
                        {
                            g.GroupIDs = g.GroupIDs.Remove(g.GroupIDs.Length - 1);
                            g.Icon = "http://128.140.29.12/WebBusManagement/Images/bus_s64_right.png";
                        }
                    }
                    catch
                    {

                    }

                }
                ret_date.ChangingMarkers = AVL.Controls.Map.NewMapControl.NewGoogleMap.SeparateFixMarkers(objectsArray);
                WebClassLibrary.SessionManager.Current.Session.Add("FirstLoadMad", 1);
                return ret_date;
            }
            //int count = 0;
            //foreach (AVL.Controls.Map.GCommunicateObject g in objectsArray)
            //{
            //    count = g.GroupIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
            //    if (count > 1)
            //    {
            //        g.GroupIDs = g.GroupIDs.Remove(g.GroupIDs.Length - 1);
            //        g.Icon = "getIcon.aspx?t=g&n=" + count;
            //    }
            //}
            //return objectsArray;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod]
        //[WebMethod(EnableSession = true)]
        public object[] GetCarsNew(string bounds, string id)
        {

            //List<AVL.Controls.Map.GCommunicateObject> busses = new List<AVL.Controls.Map.GCommunicateObject>();

            string ImgUrl = "";
            List<AVL.Controls.Map.GCommunicateObject> o = new List<AVL.Controls.Map.GCommunicateObject>();
            if (id == "-1")
            {
                System.Data.DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("select Code,BUSNumber,LastLatitude,LastLongitude,LastCourse from AUTBus where Active = 1 and IsValid = 1 and LastDate > DATEADD(hour,-24,getdate())");
                AVL.Controls.Map.GCommunicateObject[] buses = new AVL.Controls.Map.GCommunicateObject[dt.Rows.Count];
                AVL.Controls.Map.BoundsObject SwNe = AVL.Controls.Map.GCommunicateObject.BoundsStringtoPoints(bounds);
                AVL.Controls.Map.Point SW = SwNe.SouthWest;
                AVL.Controls.Map.Point NE = SwNe.NorthEast;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    AVL.Controls.Map.PointD p = new AVL.Controls.Map.PointD(
                            Convert.ToDouble(dt.Rows[i]["LastLongitude"].ToString()),
                             Convert.ToDouble(dt.Rows[i]["LastLatitude"].ToString()));
                    if (AVL.Geofence.JGeofence.IsInTheCircle(
                                     new AVL.Controls.Map.Point() { Latitude = SW.Latitude + (NE.Latitude - SW.Latitude) / 2, Longitude = SW.Longitude + (NE.Longitude - SW.Longitude) / 2 },
                                     ((NE.Latitude - SW.Latitude) / 2) > ((NE.Longitude - SW.Longitude) / 2) ? ((NE.Latitude - SW.Latitude) / 2) : ((NE.Longitude - SW.Longitude) / 2),
                                     new AVL.Controls.Map.Point() { Latitude = p.Y, Longitude = p.X }))
                    {
                        o.Add(new AVL.Controls.Map.GCommunicateObject()
                        {
                            ID = "Bus_" + dt.Rows[i]["Code"].ToString(),
                            Location = p
                        });
                    }
                }


                List<string> bb = new List<string>();
                foreach (AVL.Controls.Map.GCommunicateObject g in AVL.Controls.Map.Marker.JoinMarkers(NE.Longitude - SW.Longitude, o.ToArray(), 100))// o) //
                    bb.Add(g.ID.ToString());
               return bb.ToArray();
            }
            else
            {
                System.Data.DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("select Code,BUSNumber,LastLatitude,LastLongitude,LastCourse from AUTBus where Active = 1 and IsValid = 1 and LastDate > DATEADD(hour,-24,getdate())");
                //اگر کد این قسمت اجرا شود به این معنی است که کنترل مشخصات یک مارکر را که آی دی آن را داده است درخواست کرده.
                //int _id = int.Parse(id);

                List<AVL.Controls.Map.GCommunicateObject> s = new List<AVL.Controls.Map.GCommunicateObject>();
                //آی دی
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AVL.Controls.Map.BoundsObject SwNe = AVL.Controls.Map.GCommunicateObject.BoundsStringtoPoints(bounds);
                    AVL.Controls.Map.Point SW = SwNe.SouthWest;
                    AVL.Controls.Map.Point NE = SwNe.NorthEast;
                    AVL.Controls.Map.PointD p = new AVL.Controls.Map.PointD(
                            Convert.ToDouble(dt.Rows[i]["LastLongitude"].ToString()),
                             Convert.ToDouble(dt.Rows[i]["LastLatitude"].ToString()));
                    if (AVL.Geofence.JGeofence.IsInTheCircle(
                                     new AVL.Controls.Map.Point() { Latitude = SW.Latitude + (NE.Latitude - SW.Latitude) / 2, Longitude = SW.Longitude + (NE.Longitude - SW.Longitude) / 2 },
                                     ((NE.Latitude - SW.Latitude) / 2) > ((NE.Longitude - SW.Longitude) / 2) ? ((NE.Latitude - SW.Latitude) / 2) : ((NE.Longitude - SW.Longitude) / 2),
                                     new AVL.Controls.Map.Point() { Latitude = p.Y, Longitude = p.X }))
                    {
                        AVL.Controls.Map.GCommunicateObject gObject = new AVL.Controls.Map.GCommunicateObject();
                        gObject.ID = "Bus_" + dt.Rows[i]["Code"].ToString();
                        // تایتل یا لیبل
                        gObject.Title = gObject.ID.ToString();

                        if (Convert.ToInt32(dt.Rows[i]["LastCourse"].ToString()) < 150)
                        {
                            ImgUrl = "http://128.140.29.12/WebBusManagement/Images/bus_s64_right.png";
                        }
                        else
                        {
                            ImgUrl = "http://128.140.29.12/WebBusManagement/Images/bus_s64.png";
                        }
                        gObject.Icon = ImgUrl;
                        // مختصات جدید مارکر
                        gObject.Location = new AVL.Controls.Map.PointD()
                        {
                            // NEW Longitude
                            X = Convert.ToDouble(dt.Rows[i]["LastLongitude"].ToString()),
                            //NEW Latitude
                            Y = Convert.ToDouble(dt.Rows[i]["LastLatitude"].ToString())
                        };
                        s.Add(gObject);
                    }
                }
                return s.ToArray();
            }
            return null;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod]
        public string GetPoupuoCars(string id)
        {
            return id.ToString();// string.Format("<strong>SAMPLE {0}</strong>", id);
        }
		#endregion


        #region Share        
        [WebMethod(EnableSession = true)]
        public string GetPersons(string SearchText)
        {
            string ret_data = "";
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("Select Code, Name from clsAllPerson Where Name like N'%" + SearchText.Replace("'", "''") + "%' order by Name", true);
            DataSet ds = new DataSet();
            if (dt != null && dt.Rows.Count > 0)
            {
                ds.Tables.Add(dt);
                ret_data = ds.GetXml();
            }
            return ret_data;
        }
        #endregion



        #region PublicAction
        //[WebMethod(EnableSession = true)]
        //public string RunAction(string pActionName)
        //{
        //	return "1234";
        //}
        [WebMethod(EnableSession = true)]
        public object[] RunAction(string actionString, string[] param)
        {
            actionString = WebClassLibrary.JDataManager.DecryptString(actionString);
            ClassLibrary.JAction action = new ClassLibrary.JAction("", actionString, new object[] { param }, null);
            return (object[])action.run();
        }
        #endregion
        [WebMethod(EnableSession = true)]
        public object[] MapRequest(string actionString, string[] param)
        {
            //if ((JMainFrame)Context.Session["JMainFrame"] == null || ((JMainFrame)Context.Session["JMainFrame"]).CurrentPersonCode == 0)
            //    return null;
            actionString = ClassLibrary.JEnryption.DecryptStr(actionString, WebClassLibrary.SessionManager.Current.SessionID);
            ClassLibrary.JAction action = new ClassLibrary.JAction("", actionString, new object[] { param }, null);
            return (object[])action.run();
        }

        /// <summary>
        /// ورود به سیستم
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string Login(string UserName, string Password)
        {
            Globals.JUser user = new Globals.JUser();
            try
            {
                WebClassLibrary.Authentication.Authentication.Authenticate(UserName, Password);
                //PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
                if (WebClassLibrary.SessionManager.Current.MainFrame.GuidCode == Guid.Empty)
                    return "Failed";
                user = new Globals.JUser(user.findPerson(WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode));
                user.LoginedFromAndroid = true;
                user.Update();
                return WebClassLibrary.SessionManager.Current.MainFrame.GuidCode.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                WebClassLibrary.SessionManager.Current.Dispose();
                user.Dispose();
            }
        }

        [WebMethod(EnableSession = true)]
        public string GetWorkForTelegramRobot(DateTime pDate, string pGuid)
        {
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            return BusManagment.Bus.JBuses.GetWorkForTelegramRobot(pDate, PersonCode);
        }

        [WebMethod(EnableSession = true)]
        public string GetFinanceForTelegramRobot(DateTime pDate, string pGuid)
        {
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            return BusManagment.Bus.JBuses.GetFinanceForTelegramRobot(pDate, PersonCode);
        }

    }
}
