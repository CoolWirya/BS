using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebManagementShare.Forms
{
    public partial class JShowNewsControl : System.Web.UI.UserControl
    {
        int Code;
        public string StrNews = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            StrNews = GetData(Code);
        }

        public string GetData(int Code)
        {
            Entertainment.JNews News = new Entertainment.JNews();
            News.GetData(Code);
            return "عنوان خبر : " + News.Title + " " + "<br /><br />" + "شرح خبر : " + News.Body + "<br /><br />" + "تاریخ خبر : " + ClassLibrary.JDateTime.FarsiDate(News.Date);
        }
    }
}