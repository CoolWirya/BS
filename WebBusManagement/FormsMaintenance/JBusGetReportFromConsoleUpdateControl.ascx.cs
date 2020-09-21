using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusGetReportFromConsoleUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now.AddMonths(-2));
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
                _SetForm();
            }
        }
        public void LoadBus()
        {
            //DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            //cmbBus.DataSource = dt;
            //cmbBus.DataTextField = "BUSNumber";
            //cmbBus.DataValueField = "BUSNumber";
            //cmbBus.DataBind();
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = v["BUSNumber"].ToString(), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = "0", BUSNumber = "همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.JBusPrintReport TransactionPrint = new BusManagment.JBusPrintReport();
                TransactionPrint.GetData(Code);
                cmbBus.SelectedValue = TransactionPrint.BusNumber.ToString();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(TransactionPrint.StartDate);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(TransactionPrint.EndDate);
            }
        }

        public int Save(DateTime StartDate, DateTime EndDate)
        {
            BusManagment.JBusPrintReport TransactionPrint = new BusManagment.JBusPrintReport();
            TransactionPrint.Code = Code;
            TransactionPrint.BusNumber = Convert.ToInt32(cmbBus.SelectedValue);
            TransactionPrint.StartDate = StartDate;
            TransactionPrint.EndDate = EndDate;
            TransactionPrint.TicketCount = 0;
            TransactionPrint.TicketSent = 0;
            TransactionPrint.State = 0;
            if (Code > 0)
                if (TransactionPrint.Update())
                    return 1;
                else
                    return 0;
            else
                return TransactionPrint.Insert();
        }

        public bool SaveInMySql(int Code, DateTime StartDate, DateTime EndDate)
        {
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            mysqlDB.setQuery(@"SELECT  IFNULL(max( `Code` ),0) AS max_value FROM `getdataticket`");
            DataTable MySqlMaxCode = mysqlDB.Query_DataTable();
            int MaxCodeMySql = Convert.ToInt32(MySqlMaxCode.Rows[0]["max_value"].ToString());
            MaxCodeMySql++;
            string IsSent = "0";
            if (RbSendTransaction.SelectedValue == "1")
                IsSent = "1";
            //ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            mysqlDB.setQuery(@"INSERT INTO `getdataticket`(`Code`, `busserial`, `state`, `startdate`, `enddate`, `isSent`, `RowCount`, `RowSent`) 
                               VALUES (" + Code + @"," + cmbBus.SelectedValue.ToString() + @",0,'" + StartDate.Year + "/" + StartDate.Month + @"/" + StartDate.Day + @" 00:00:00',
                               '" + EndDate.Year + "/" + EndDate.Month + "/" + EndDate.Day + @" 23:59:59'," + IsSent + @",0,0)");
            return mysqlDB.Query_Execute() >= 0 ? true : false;
        }

        public bool SaveInMySql(int Code, DateTime StartDate, DateTime EndDate, int BusNumber, ClassLibrary.JMySQLDataBase mysqlDB)
        {
            string IsSent = "0";
            if (RbSendTransaction.SelectedValue == "1")
                IsSent = "1";
            mysqlDB.setQuery(@"INSERT INTO `getdataticket`(`Code`, `busserial`, `state`, `startdate`, `enddate`, `isSent`, `RowCount`, `RowSent`) 
                               VALUES (" + Code + @"," + BusNumber + @",0,'" + StartDate.Year + "/" + StartDate.Month + @"/" + StartDate.Day + @" 00:00:00',
                               '" + EndDate.Year + "/" + EndDate.Month + "/" + EndDate.Day + @" 23:59:59'," + IsSent + @",0,0)");
            return mysqlDB.Query_Execute() >= 0 ? true : false;
        }


        public List<DateTime> GetAllDateBetweenToDates(DateTime start, DateTime end)
        {
            var dates = new List<DateTime>();

            for (var dt = start; dt <= end; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }
            return dates;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string MySqlQuery = "";
            int LastInsertCode = 0;
            var dates = GetAllDateBetweenToDates(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            if (Convert.ToInt32(cmbBus.SelectedValue) > 0)
            {
                for (int i = 0; i < dates.Count; i++)
                {
                    LastInsertCode = Save(dates[i], dates[i]);
                    SaveInMySql(LastInsertCode, dates[i], dates[i]);
                }
            }
            else
            {
                ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
                string SqlQuery = "";
                DateTime StartDate = DateTime.Now;
                DateTime EndDate = DateTime.Now;
                string IsSent = "0";
                if (RbSendTransaction.SelectedValue == "1")
                    IsSent = "1";
                ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
                mysqlDB.setQuery(@"SELECT  IFNULL(max( `Code` ),0) AS max_value FROM `getdataticket`");
                DataTable MySqlMaxCode = mysqlDB.Query_DataTable();
                int MaxCodeMySql = Convert.ToInt32(MySqlMaxCode.Rows[0]["max_value"].ToString());
                DataTable DtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,BUSNumber from autbus where len(BUSNumber)=4 and active = 1 and isvalid = 1 and BUSNumber < 6999
                                                                                and TicketLastDate > DATEADD(day,-7,getdate())
                                                                                order by TicketLastDate desc");
                if (DtBus != null)
                {
                    if (DtBus.Rows.Count > 0)
                    {
                        MySqlQuery = @"INSERT INTO `getdataticket`(`Code`, `busserial`, `state`, `startdate`, `enddate`, `isSent`, `RowCount`, `RowSent`) VALUES ";
                        SqlQuery = @"INSERT INTO [dbo].[AUTPrinterRporte] 
                        ([Code],[BusNumber],[StartDate],[EndDate],[TicketCount],[TicketSent],[State],[GetTicket],[DailyCode],[ShiftDriverCode],[RequestCount],[Date],[RequestDate]) VALUES ";
                        for (int i = 0; i < DtBus.Rows.Count; i++)
                        {
                            for (int j = 0; j < dates.Count; j++)
                            {
                                MaxCodeMySql++;
                                StartDate = dates[j];
                                EndDate = dates[j];
                                MySqlQuery += @" (" + MaxCodeMySql + @"," + DtBus.Rows[i]["BUSNumber"].ToString() + @",0,'" + StartDate.Year + @"/" + StartDate.Month + @"/" + StartDate.Day + @" 00:00:00',
                               '" + EndDate.Year + @"/" + EndDate.Month + @"/" + EndDate.Day + @" 23:59:59'," + IsSent + @",0,0) , ";
                                SqlQuery += @"(" + MaxCodeMySql + @"," + DtBus.Rows[i]["BUSNumber"].ToString() + @"
                                               ,'" + StartDate.ToShortDateString() + @" 00:00:00','" + EndDate.ToShortDateString() + @" 23:59:59',0
                                               ,0,0,0,0
                                               ,0,0,getdate(),getdate()) , ";
                            }
                        }
                        MySqlQuery = MySqlQuery.Substring(0, MySqlQuery.Length - 3);
                        SqlQuery = SqlQuery.Substring(0, SqlQuery.Length - 3);
                        mysqlDB.setQuery(MySqlQuery);
                        if (mysqlDB.Query_Execute() >= 0)
                        {
                            Db.setQuery(SqlQuery);
                            if (Db.Query_Execute() >= 0)
                            {
                                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "OKDialog");
                            }
                        }
                        else
                        {
                            WebClassLibrary.JWebManager.RunClientScript("alert('خطا در ثبت اطلاعات');", "OKDialog");
                        }
                    }
                }
            }
            //WebClassLibrary.JWebManager.RunClientScript("alert('OK');", "OKDialog");
            WebClassLibrary.JWebManager.CloseAndRefresh();
        }

    }
}