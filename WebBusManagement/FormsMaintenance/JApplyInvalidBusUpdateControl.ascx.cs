using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JApplyInvalidBusUpdateControl : System.Web.UI.UserControl
    {
        public string Decription = "";
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            try
            {
                UpdateIsValidBus(Code);
            }
            catch { }
        }

        public int UpdateIsValidBus(int BusCode)
        {
            System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from autbus where isvalid = 0 and code = " + BusCode);
            System.Data.DataTable DtBusNumber = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from autbus where code = " + BusCode);
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    Db.setQuery(@"update autbus set isvalid=1,active = 1,carcode=112 where isvalid = 0 and code = " + BusCode);
                    if (Db.Query_Execute() >= 0)
                    {
                        Decription = "اتوبوس " + Dt.Rows[0]["BusNumber"].ToString() + @" با موفقیت معتبر و تایید شد";
                        return 1;
                    }
                }
                else
                {
                    Db.setQuery(@"update autbus set isvalid=0,active = 0,carcode=112 where isvalid = 1 and code = " + BusCode);
                    if (Db.Query_Execute() >= 0)
                    {
                        Decription = "اتوبوس " + DtBusNumber.Rows[0]["BusNumber"].ToString() + @" با موفقیت نامعتبر و غیر فعال شد";
                        return 1;
                    }
                }
            }
            else
            {
                Db.setQuery(@"update autbus set isvalid=0,active = 0 where isvalid = 1 and code = " + BusCode);
                if (Db.Query_Execute() >= 0)
                {
                    Decription = "اتوبوس " + DtBusNumber.Rows[0]["BusNumber"].ToString() + @" با موفقیت نامعتبر و غیر فعال شد";
                    return 1;
                }
            }
            return 0;
        }
    }
}