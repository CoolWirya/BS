using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JSendMessageToConsoleUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
                LoadBus();
            LoadLines();
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = dt;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }


        public void LoadLines()
        {
            DataTable dt = BusManagment.Line.JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, lineName = "همه" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        protected void cmbLine_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbLine.SelectedValue) > 0)
            {
                DataTable dtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus Where Active = 1 and isValid=1
                                                                              and LastLineNumber in (SELECT LineNumber FROM AUTLine 
                                                                              Where Code = " + cmbLine.SelectedValue + ") Order By BusNumber ASC");
                var p2 = (from v in dtBus.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, BUSNumber = "همه" });
                cmbBus.DataSource = p2;
                cmbBus.DataTextField = "BUSNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
            }
            else
            {

                LoadBus();
            }
        }
        string WhereStr = "";
        public bool Save()
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            //ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);

            if (cmbLine.SelectedItem.Value != "0")
            {
                WhereStr += " and LastLineNumber = (select LineNumber from AUTLine where Code = " + cmbLine.SelectedItem.Value+")";
            }
            if (cmbBus.SelectedItem.Value != "0")
            {

                WhereStr += " and Code = " + cmbBus.SelectedItem.Value;
            }

            Db.setQuery(@"Select BusNumber from AUTbus where Active=1  and isValid=1 " + WhereStr + @"");

            DataTable dt = Db.Query_DataTable();
            foreach (DataRow row in dt.Rows)
            {
                Db.setQuery(@"INSERT INTO [dbo].[AutConsoleMessage]
                                           ([BusNumber]
                                           ,[MessageText]
                                           ,[UserCode]
                                           ,[InsertDate])
                                     VALUES
                                           (" + row[0].ToString() + @"
                                           ,N'" + txtMessageText.Text + @"'
                                           ," + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode + @"
                                           ,getdate())");
                if (Db.Query_Execute() >= 0)
                {
                }
            }
            return true;
        }
        public void GetReport(int BusNumber, int LineNumber, DateTime InsertDate, int total = 0)
        {
            string WhereStr = "";
            //string WhereStr2 = ""; string WhereStr3 = "";

            if (BusNumber > 0)
                WhereStr += " and AUTBus.BusNumber = " + BusNumber;

            WhereStr += " and AUTLine.LineNumber = " + LineNumber;




        }
        protected void btnSave_Click(object sender, EventArgs e)
        {



            if (Save())
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در ثبت اطلاعات');", "ConfirmDialog");

        }

        //WebClassLibrary.JWebManager.CloseAndRefresh();


    } }

