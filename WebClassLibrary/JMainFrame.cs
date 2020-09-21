using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebClassLibrary
{
    [Serializable()]
    public partial class JMainFrame : ISerializable
    {
        public JMainFrame() { }
        //Deserialization constructor.
        public JMainFrame(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            CurrentUserCode = (int)info.GetValue("CurrentUserCode", typeof(int));
            CurrentPostCode = (int)info.GetValue("CurrentPostCode", typeof(int));
            IsAdmin = (bool)info.GetValue("IsAdmin", typeof(bool));
            CurrentPersonCode = (int)info.GetValue("CurrentPersonCode", typeof(int));
            CurrentPostTitle = (string)info.GetValue("CurrentPostTitle", typeof(string));
            CurrentPersonName = (string)info.GetValue("CurrentPersonName", typeof(string));
            DomainName = (string)info.GetValue("DomainName", typeof(string));
            TimeLogin = (int)info.GetValue("TimeLogin", typeof(int));
            Terminated = (int)info.GetValue("Terminated", typeof(int));
            CompanyDefault = (int)info.GetValue("CompanyDefault", typeof(int));
            BaseCurrentPostCode = (int)info.GetValue("BaseCurrentPostCode", typeof(int));
            Successor = (bool)info.GetValue("Successor", typeof(bool));
            BaseCurrentPostTitle = (string)info.GetValue("BaseCurrentPostTitle", typeof(string));
            GuidCode = Guid.Parse((string)info.GetValue("GuidCode", typeof(string)));
        }
        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("CurrentUserCode", CurrentUserCode);
            info.AddValue("CurrentPostCode", CurrentPostCode);
            info.AddValue("CurrentPersonCode", CurrentPersonCode);
            info.AddValue("CurrentPostTitle", CurrentPostTitle);
            info.AddValue("CurrentPersonName", CurrentPersonName);
            info.AddValue("DomainName", DomainName);
            info.AddValue("TimeLogin", TimeLogin);
            info.AddValue("Terminated", Terminated);
            info.AddValue("CompanyDefault", CompanyDefault);
            info.AddValue("BaseCurrentPostCode", BaseCurrentPostCode);
            info.AddValue("Successor", Successor);
            info.AddValue("BaseCurrentPostTitle", BaseCurrentPostTitle);
            info.AddValue("GuidCode", GuidCode.ToString());
            info.AddValue("GlobalTable", GlobalTable);
            info.AddValue("IsAdmin", IsAdmin);
        }
        public int CurrentUserCode { get; set; }

        public int CurrentPostCode { get; set; }
        public int CurrentPersonCode { get; set; }
        public string CurrentPostTitle { get; set; }
        public string CurrentPersonName { get; set; }
        public string DomainName { get; set; }
        public int TimeLogin { get; set; }
        public int Terminated { get; set; }
        public int CompanyDefault { get; set; }
        public int BaseCurrentPostCode { get; set; }
        public bool Successor { get; set; }
        public string BaseCurrentPostTitle { get; set; }
        public ClassLibrary.JDataBase GlobalDataBase { get; set; }
        public Guid GuidCode { get; set; }

		private ClassLibrary.JException _Except;
		public ClassLibrary.JException Except
		{
			get
			{
				if (_Except == null)
					_Except = new ClassLibrary.JException();
				return _Except;
			}
			set
			{
				_Except = value;
			}
		}
        public System.Data.DataTable GlobalTable { get; set; }
        public bool IsAdmin { get; set; }
        public bool isAuthenticatedBySUID(string SUID)
        {
            if (Convert.ToBoolean(SessionManager.Current.Objects.Get("Authentication_" + SUID)) == true)
                return isAuthenticated;
            return true;
        }

        public bool isAuthenticated
        {
            get
            {
                if (System.Web.HttpContext.Current.Request.Url.Host.ToLower() == DomainName)
                    return CurrentPersonCode > 0 ? true : false;
                return false;
            }
        }

		public string GetUrlAuthority
		{
			get
			{
				return SessionManager.Current.Objects.Get("UrlAuthority").ToString();
			}
		}

        private Globals.JUser _CurrentUser;
        public Globals.JUser CurrentUser
        {
            get
            {
                if (_CurrentUser == null)
                    _CurrentUser = new Globals.JUser(CurrentUserCode);
                else
                    if(_CurrentUser.code != CurrentUserCode)
                    _CurrentUser.GetData(CurrentUserCode);

                return _CurrentUser;
            }
        }

        public ClassLibrary.JPerson _CurrentPerson;
        public ClassLibrary.JPerson CurrentPerson
        {
            get
            {
                if (_CurrentPerson == null)
                    _CurrentPerson = new ClassLibrary.JPerson(CurrentPersonCode);
                else
                   if (_CurrentPerson.Code != CurrentPersonCode)
                    _CurrentPerson.getData(CurrentPersonCode);
                return _CurrentPerson;
            }
        }

        public void Save()
        {
            SessionManager.Current.MainFrame = this;
        }
    }
}
