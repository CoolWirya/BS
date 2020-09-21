using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace TccoTabrizBus
{
    public class User : MonoCP.Telegram.Types.User
    {
        private string _credentialUsername;
        private string _credentialPassword;
        private StateEnum _state;

        public User()
        {
            _state = StateEnum.Guest;
            Location = LocationEnum.GuestHomePage;
        }

        public string ChatId { get; set; }
        public StateEnum State { get { return _state; }set { _state = value; } }
        public LocationEnum Location { get; set; }

        public string LastMessage { get; set; }

        public Guid Token { get; set; }
        public DateTime ReportDate { get; set; }
        public string PersianReportDate { get; set; }
        public PersianCalendar pc { get; set; }
        public string CredentialUsername
        {
            get { return _credentialUsername; }
            set
            {
                _credentialUsername = value;
            }
        }
        public string CredentialPassword
        {
            get { return _credentialPassword; }
            set
            {
                _credentialPassword = value;
            }
        }

        public string GetFullName()
        {
            return first_name + " " + last_name;
        }
        public async Task<bool> Login()
        {
            Dictionary<string, string> values = new Dictionary<string, string>
            {
               { "UserName", CredentialUsername },
               { "Password", CredentialPassword }
            };
            bool res = false;
            try
            {
                Token = Guid.Parse(await NetManager.CallWebService("Login", values));
                res = true;

            }
            catch (Exception er)
            {
                res = false;
            }
            if (res) _state = StateEnum.LoggedIn;
            else _state = StateEnum.Guest;
            return res;
        }

        public async Task<string> GetWroksReport()
        {
            Dictionary<string, string> values = new Dictionary<string, string>
            {
               { "pDate", ReportDate.ToString("yyyy-MM-dd")},
               { "pGuid", Token.ToString() }
            };
            string s = await NetManager.CallWebService("GetWorkForTelegramRobot", values);
            return s;
        }
        public async Task<string> GetFinanceReport()
        {
            Dictionary<string, string> values = new Dictionary<string, string>
            {
               { "pDate", ReportDate.ToString("yyyy-MM-dd")},
               { "pGuid", Token.ToString() }
            };
            string s = await NetManager.CallWebService("GetFinanceForTelegramRobot", values);
            return s;
        }
        
        //private void R_ResponseEvent(MonoCP.Net.ResponseEventArgs e)
        //{
        //    if (e.Stream != null)
        //    {
        //        string a = new System.IO.StreamReader(e.Stream).ReadToEnd();
        //    }
        //}

        public bool Logout()
        {
            if (State != StateEnum.LoggedIn)
            {
                AsGuest();
            }
            else          //server interaction
            {
                AsGuest();
            }
            return true;
        }

        private void AsGuest()
        {
            _state = StateEnum.Guest;
            Location = LocationEnum.GuestHomePage;
        }

    }
}
