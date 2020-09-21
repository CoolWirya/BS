using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JGroundDeviceTicketReportShowDataReportControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public string StrDate = "";
        public void _SetForm()
        {
            if (Code > 0)
            {
                ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
                Db.setQuery(@"select convert (varchar(max),[Data],2) PackData from AUTGroundDeviceTicket where code =" + Code);
                System.Data.DataTable Dt = Db.Query_DataTable();
                    if(Dt!=null & Dt.Rows.Count > 0)
                    {
                        StrDate = Dt.Rows[0]["PackData"].ToString();
                    }
            }
        }
    }
}