using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassLibrary;
using BusManagment.Zone;
using BusManagment.Line;

namespace WebBusManagement.FormsManagement
{
    public partial class JBusDeviceSettingsUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBus();
                LoadBusOwner();
                LoadZones();
                LoadLines();
                LoadBusSettings();
                LoadGridFromMySql();
            }
            else
            {
                //btnSave_Click(null, null);
                LoadGridFromMySql();
            }
        }

        public void LoadBusOwner()
        {
            DataTable dt = BusManagment.Bus.JBusOwners.GetBusOwners();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            p.Insert(0, new { Code = -1, Name = "-" });
            cmbOwner.DataSource = p;
            cmbOwner.DataTextField = "Name";
            cmbOwner.DataValueField = "Code";
            cmbOwner.DataBind();
        }

        public void LoadZones()
        {
            DataTable dt = JZones.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbZone.DataSource = p;
            cmbZone.DataTextField = "Name";
            cmbZone.DataValueField = "Code";
            cmbZone.DataBind();
        }

        public void LoadLines()
        {
            DataTable dt = JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, lineName = "همه" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        public void LoadBus()
        {
           
             DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus where IsValid=1 Order By BusNumber");

            //            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"Select a.Code,cast(a.BusNumber as nvarchar) + ' - ' 
            //                                                                        +cast((select top 1 IMEI from AUTHeaderTransaction where BusSerial = a.BUSNumber order by Date desc) as nvarchar) BusNumber
            //                                                                        from AUTBus a where a.BUSNumber < 999999 Order By a.BusNumber");
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "همه" });
            p.Insert(0, new { Code = -1, BUSNumber = "-" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }


        public void LoadBusSettings()
        {
            DataTable DtBusFailureType = new DataTable();
            DtBusFailureType = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name,Value from AUTConsoleSettings order by Code");
            cmbSettings.DataSource = DtBusFailureType;
            cmbSettings.DataTextField = "Name";
            cmbSettings.DataValueField = "Code";
            cmbSettings.DataBind();
            cmbSettings.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("-", "-1"));
        }

        public void GetReport(int ZoneCode = 0, int LineNumber = 0, int BusNumber = 0, int OwnerCode = 0, int SettingCode = 0)
        {
            if (SettingCode == -1 || (OwnerCode == -1 && BusNumber <= 0) || (OwnerCode <= 0 && BusNumber == -1))
                return;
            string WhereStr = "";

            if (ZoneCode > 0)
                WhereStr += @" and AZ.Code=" + ZoneCode;

            if (LineNumber > 0)
                WhereStr += @" and AL.Code=" + LineNumber;

            if (OwnerCode > 0)
            {
                WhereStr += @" and AO.CodePerson = " + OwnerCode;
            }

            if (BusNumber > 0)
                WhereStr += @" and AB.Code=" + BusNumber;

            DataTable DtSettingCode = WebClassLibrary.JWebDataBase.GetDataTable(@"select Value from AUTConsoleSettings where Code = " + SettingCode);

            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select AB.BUSNumber as BUSNumber
                                                                        from 
                                                                        [dbo].[AUTBus] AB 
	                                                                    left join [dbo].[AUTBusOwner] AO ON AO.BusCode = AB.Code AND AO.IsActive=1
                                                                        left join [dbo].[AUTLine] AL on AB.LastLineNumber = AL.LineNumber
                                                                        left join [dbo].[AUTZone] AZ on AL.ZoneCode = AZ.Code 
                                                                        left join [dbo].[clsAllPerson] CAP on AO.CodePerson = CAP.Code
                                                                        where len(ab.BUSNumber) = 4 and ab.BUSNumber > 1000 and ab.BUSNumber < 10000
	                                                                    and AB.IsValid = 1
                                                                        " + WhereStr + @"
                                                                        GROUP BY AB.BUSNumber");
            int j = 1;
            string MySqlQuery = "";
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            mysqlDB.setQuery(@"SELECT IFNULL(max( `Code` ),0) AS max_value FROM `getsettings`");
            DataTable MySqlMaxCode = mysqlDB.Query_DataTable();
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    j = Convert.ToInt32(MySqlMaxCode.Rows[0]["max_value"].ToString());
                    MySqlQuery += @"INSERT INTO `getsettings`(`Code`, `busserial`, `Field`, `Value`, `State`, `StartDate`) VALUES ";
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        j = j + 1;
                        MySqlQuery += @" (" + j + @" , " + Dt.Rows[i]["BUSNumber"].ToString() + @" , 
                        '" + DtSettingCode.Rows[0]["Value"].ToString() + @"','" + txtSettingValue.Text + @"',0,'"
                        + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + @" " + DateTime.Now.Hour + @":" + DateTime.Now.Minute + @":" + DateTime.Now.Second + @"') , ";
                        j++;
                    }
                }
            }
      if (MySqlQuery.Length > 3)
                MySqlQuery = MySqlQuery.Substring(0, MySqlQuery.Length - 3);
            mysqlDB.setQuery(MySqlQuery);
            if (mysqlDB.Query_Execute() >= 0)
            {
                LoadGridFromMySql();
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
            }
            else { WebClassLibrary.JWebManager.RunClientScript("alert('خطا در ثبت اطلاعات');", "ConfirmDialog"); }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSettingValue.Text != "")
            {
                GetReport(Convert.ToInt32(cmbZone.SelectedValue),
                          Convert.ToInt32(cmbLine.SelectedValue),
                          Convert.ToInt32(cmbBus.SelectedValue),
                          Convert.ToInt32(cmbOwner.SelectedValue),
                          Convert.ToInt32(cmbSettings.SelectedValue));
            }
        }


        protected void cmbZone_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbZone.SelectedValue) > 0)
            {
                DataTable dtLines = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],convert(nvarchar,[LineNumber])+' - - > '+[LineName] as [lineName],LineNumber FROM AUTLine Where ZoneCode = " + cmbZone.SelectedValue + " Order By LineNumber ASC");
                var p = (from v in dtLines.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, lineName = "همه" });
                cmbLine.DataSource = p;
                cmbLine.DataTextField = "lineName";
                cmbLine.DataValueField = "Code";
                cmbLine.DataBind();

                DataTable dtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus Where Active = 1 
                                                                              and LastLineNumber in (SELECT LineNumber FROM AUTLine 
                                                                              Where ZoneCode = " + cmbZone.SelectedValue + ") Order By BusNumber ASC");
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
                LoadLines();
                LoadBus();
            }
        }

        protected void cmbLine_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbLine.SelectedValue) > 0)
            {
                DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
                    (Select ZoneCode From AutLine Where Code = " + cmbLine.SelectedValue + ")");
                var p = (from v in dtZones.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, Name = "همه" });
                cmbZone.DataSource = p;
                cmbZone.DataTextField = "Name";
                cmbZone.DataValueField = "Code";
                cmbZone.DataBind();

                DataTable dtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus Where Active = 1 
                                                                              and LastLineNumber in (SELECT LineNumber FROM AUTLine 
                                                                              Where Code = " + cmbLine.SelectedValue + ") Order By BusNumber ASC");
                var p2 = (from v in dtBus.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), BusNumber = v["BUSNumber"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, BusNumber = "همه" });
                cmbBus.DataSource = p2;
                cmbBus.DataTextField = "BusNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
            }
            else
            {
                LoadZones();
                LoadBus();
            }
        }

        protected void cmbBus_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbBus.SelectedValue) > 0)
            {
                DataTable dtLines = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],convert(nvarchar,[LineNumber])+' - - > '+[LineName] as [lineName],LineNumber FROM AUTLine Where LineNumber = (Select LastLineNumber From AutBus Where Code = " + cmbBus.SelectedValue + ") Order By LineNumber ASC");
                var p = (from v in dtLines.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, lineName = "همه" });
                cmbLine.DataSource = p;
                cmbLine.DataTextField = "lineName";
                cmbLine.DataValueField = "Code";
                cmbLine.DataBind();

                DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
                    (Select top 1 ZoneCode From AutLine Where LineNumber = (Select LastLineNumber From AutBus Where Code = " + cmbBus.SelectedValue + "))");
                var p2 = (from v in dtZones.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, Name = "همه" });
                cmbZone.DataSource = p2;
                cmbZone.DataTextField = "Name";
                cmbZone.DataValueField = "Code";
                cmbZone.DataBind();
            }
            else
            {
                LoadZones();
                LoadLines();
            }
        }


        public void LoadGridFromMySql()
        {
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            mysqlDB.setQuery(@"SELECT `Code`,`BusSerial`,`Field`,`Value`,case `State` when 1 then N'اعمال شده' else N'اعمال نشده' end as State,`StartDate` As FDate FROM `getsettings` Order By `StartDate` Desc");
            DataTable Dt = mysqlDB.Query_DataTable();
            RadGridReport1.DataSource = Dt;
            RadGridReport1.DataBind();
        }


        protected void RadGridReport1_PreRender(object sender, EventArgs e)
        {
            if (RadGridReport1.DataSource == null) return;
            foreach (DataColumn col in (RadGridReport1.DataSource as DataTable).Columns)
            {
                if (col.ColumnName != "FDate")
                    RadGridReport1.MasterTableView.GetColumn(col.ColumnName).HeaderText = ClassLibrary.JLanguages._Text(col.ColumnName);
                //  if (col.ColumnName == "Code")
                //{
                //    RadGridReport1.MasterTableView.GetColumn(col.ColumnName).Visible = false;
                //}
            }
            RadGridReport1.MasterTableView.Rebind();
        }


    }
}