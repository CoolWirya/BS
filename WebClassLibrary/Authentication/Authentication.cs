using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebClassLibrary.Authentication
{
    public class Authentication
    {
        public static bool Authenticate(string userName, string password)
        {
            Globals.JUser jUser = new Globals.JUser();
            int userCode = jUser.CheckUserPass(userName, password);
            if (userCode == 0) return false;
            JMainFrame jMainFrame = new JMainFrame();
            jMainFrame.DomainName = System.Web.HttpContext.Current.Request.Url.Host;
            jMainFrame.Save();
            int postCode = 0;
            System.Data.DataTable dt = JWebDataBase.GetDataTable("select Code,full_title from VOrganizationChart where user_code = " + userCode);
            if (dt != null && dt.Rows.Count > 0)
            {
                postCode = Convert.ToInt32(dt.Rows[0]["Code"]);
            }
            jUser.Login(userName, password, postCode);
			WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode = postCode;
			WebClassLibrary.SessionManager.Current.MainFrame.BaseCurrentPostCode = postCode;
            return true;
        }

        public static bool Authenticate(Guid pGuid)
        {
            Globals.JUser jUser = new Globals.JUser();
            if (jUser.GetData(pGuid))
            {
                JMainFrame jMainFrame = new JMainFrame();
                jMainFrame.DomainName = System.Web.HttpContext.Current.Request.Url.Host;
                int postCode = 0;
                System.Data.DataTable dt = JWebDataBase.GetDataTable("select Code,full_title from VOrganizationChart where user_code = " + jUser.code);

                if (dt != null && dt.Rows.Count > 0)
                {
                    postCode = Convert.ToInt32(dt.Rows[0]["Code"]);
                }

                jMainFrame.CurrentUserCode = jUser.code;
                jMainFrame.CurrentPersonCode = jUser.PCode;
                jMainFrame.CurrentPostCode = postCode;
                Employment.JEOrganizationChart jeOrgChart = new Employment.JEOrganizationChart(postCode);
                jMainFrame.CurrentPostTitle = jeOrgChart.full_title;
                jMainFrame.BaseCurrentPostCode = postCode;
                jMainFrame.IsAdmin = jUser.IsAdmin;
                jMainFrame.Save();

                return true;
            }
            return false;

        }

        public static bool VerifyUser(string userName, string password)
        {
            Globals.JUser jUser = new Globals.JUser();
            int userCode = jUser.CheckUserPass(userName, password);
            if (userCode == 0) return false;
            return true;
        }

        public static bool ChangeUserPassword(string newPassword)
        {
            var user = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUser;
            user.password = newPassword;
            return user.Update();
        }
    }
}
