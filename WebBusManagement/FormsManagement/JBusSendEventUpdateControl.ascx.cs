using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JBusSendEventUpdateControl : System.Web.UI.UserControl
    {
        int Code = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLines();
                LoadBus();
            }
            int.TryParse(Request["Code"], out Code);
        }
        public void LoadLines()
        {
            DataTable dt = BusManagment.Line.JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { lineNumber = Convert.ToInt32(v["lineNumber"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { lineNumber = -1, lineName = "همه" });
            p.Insert(0, new { lineNumber = -2, lineName = "-" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "lineNumber";
            cmbLine.DataBind();
        }
        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "همه" });
            p.Insert(0, new { Code = -1, BUSNumber = "-" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }
        public bool Save(int BusCode = 0, int LineNumber = 0)
        {
            //if ((BusCode == -1 && LineNumber!=-2) || (LineNumber != -2 && BusCode > 0))
            { 
                if(LineNumber == -2) LineNumber = -1;
                if (cbAllEvents.Checked)
                {
                    ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
                    DataTable dtEvents = new DataTable();
                    DataTable dtEventDetails = new DataTable();
                    string DeleteQuery = "delete from eventdetails; delete from events;";
                    string Query = @"
                        Declare @query_code int = (select isnull(max(Code),0) from [dbo].[AUTConsoleQueryAuto])
                        Set @query_code = @query_code + 1
                        INSERT INTO [dbo].[AUTConsoleQueryAuto]
                                   ([Code]
                                   ,[Name]
                                   ,[QueryText]
                                   ,[InsertDate]
                                   ,[DataBaseName]
                                   ,[LineNumber]
                                   ,[BusCode])
                             VALUES
                                   (@query_code
                                   ,'Reset Event'
                                   ,N'" + DeleteQuery + @"'
                                   ,getdate()
                                   ,'Local_Bus_Sqlite'
                                   ," + (LineNumber > -1 ? LineNumber.ToString() : "null") + @"
                                   ," + (BusCode > 0 ? BusCode.ToString() : "null") + @")";
                    db.setQuery("SELECT [Code],[Name] FROM [dbo].[AUTBusEvent]");
                    try 
                    {
                        dtEvents = db.Query_DataTable();
                        db.setQuery("SELECT [Code],[Name], [BusEventCode] FROM [dbo].[AUTBusEventDetailes]");
                        dtEventDetails = db.Query_DataTable();
                        if (dtEvents == null || dtEvents.Rows.Count == 0 || dtEventDetails == null)
                            return false;
                        for (int i = 0; i < dtEvents.Rows.Count; i++)
                        {
                            string EventsQuery = "insert into events(''code'',''name'') values(" + dtEvents.Rows[i]["Code"] + @",''" + dtEvents.Rows[i]["Name"] + @"'');";
                            Query += @"
                            Set @query_code = @query_code + 1
                            INSERT INTO [dbo].[AUTConsoleQueryAuto]
                                        ([Code]
                                        ,[Name]
                                        ,[QueryText]
                                        ,[InsertDate]
                                        ,[DataBaseName]
                                        ,[LineNumber]
                                        ,[BusCode])
                                 VALUES
                                       (@query_code
                                       ,'Reset Event'
                                       ,N'" + EventsQuery + @"'
                                       ,getdate()
                                       ,'Local_Bus_Sqlite'
                                       ," + (LineNumber > -1 ? LineNumber.ToString() : "null") + @"
                                       ," + (BusCode > 0 ? BusCode.ToString() : "null") + @")";
                            var EventDetails = dtEventDetails.Select("BusEventCode = " + dtEvents.Rows[i]["Code"]).ToList();
                            foreach (DataRow row in EventDetails)
                            {
                                string EventDetailsQuery = "insert into eventdetails(''code'',''name'',''eventcode'') values(" + row["Code"] + @",''" + row["Name"] + @"''," + dtEvents.Rows[i]["Code"] + ");";
                                Query += @"
                                Set @query_code = @query_code + 1
                                INSERT INTO [dbo].[AUTConsoleQueryAuto]
                                            ([Code]
                                            ,[Name]
                                            ,[QueryText]
                                            ,[InsertDate]
                                            ,[DataBaseName]
                                            ,[LineNumber]
                                            ,[BusCode])
                                     VALUES
                                       (@query_code
                                       ,'Reset Event'
                                       ,N'" + EventDetailsQuery + @"'
                                       ,getdate()
                                       ,'Local_Bus_Sqlite'
                                       ," + (LineNumber > -1 ? LineNumber.ToString() : "null") + @"
                                       ," + (BusCode > 0 ? BusCode.ToString() : "null") + @")";
                            }
                        }
                        db.setQuery(Query);
                        if (db.Query_Execute() >= 0)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        ClassLibrary.JSystem.Except.AddException(ex);
                        return false;
                    }
                    finally
                    {
                        db.Dispose();
                    }
                }
                else
                {
                    if (Code == 0) return false;

                    BusManagment.BusEvent.JBusEvent Event = new BusManagment.BusEvent.JBusEvent();
                    Event.GetData(Code);

                    ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
                    DataTable dt = new DataTable();
                    db.setQuery("SELECT [Code],[Name], [BusEventCode] FROM [dbo].[AUTBusEventDetailes] WHERE [BusEventCode] = " + Code.ToString());

                    string DeleteQuery = @"delete from eventdetails where ""eventcode"" = "+ Code + @"; delete from events where ""code"" = " + Code +";";
                    string Query = @"
                        Declare @query_code int = (select isnull(max(Code),0) from [dbo].[AUTConsoleQueryAuto])
                        Set @query_code = @query_code + 1
                        INSERT INTO [dbo].[AUTConsoleQueryAuto]
                                   ([Code]
                                   ,[Name]
                                   ,[QueryText]
                                   ,[InsertDate]
                                   ,[DataBaseName]
                                   ,[LineNumber]
                                   ,[BusCode])
                             VALUES
                                   (@query_code
                                   ,'Reset Event'
                                   ,N'" + DeleteQuery + @"'
                                   ,getdate()
                                   ,'Local_Bus_Sqlite'
                                   ," + (LineNumber > -1 ? LineNumber.ToString() : "null") + @"
                                   ," + (BusCode > 0 ? BusCode.ToString() : "null") + @")";

                    string EventQuery = @"insert into events(''code'',''name'') values(" + Code.ToString() + @",''" + Event.Name + "'');";
                    Query += @"
                        Set @query_code = @query_code + 1
                        INSERT INTO [dbo].[AUTConsoleQueryAuto]
                                   ([Code]
                                   ,[Name]
                                   ,[QueryText]
                                   ,[InsertDate]
                                   ,[DataBaseName]
                                   ,[LineNumber]
                                   ,[BusCode])
                             VALUES
                                   (@query_code
                                   ,'Reset Event'
                                   ,N'" + EventQuery + @"'
                                   ,getdate()
                                   ,'Local_Bus_Sqlite'
                                   ," + (LineNumber > -1 ? LineNumber.ToString() : "null") + @"
                                   ," + (BusCode > 0 ? BusCode.ToString() : "null") + @")";

                    try
                    {
                        dt = db.Query_DataTable();
                        if (dt == null || dt.Rows.Count == 0)
                            return false;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string EventDetailsQuery = "insert into eventdetails(''code'',''name'',''eventcode'') values(" + dt.Rows[i]["Code"] + @",''" + dt.Rows[i]["Name"] + @"''," + Code.ToString() + ");";
                            Query += @"
                            Set @query_code = @query_code + 1
                            INSERT INTO [dbo].[AUTConsoleQueryAuto]
                                       ([Code]
                                       ,[Name]
                                       ,[QueryText]
                                       ,[InsertDate]
                                       ,[DataBaseName]
                                       ,[LineNumber]
                                       ,[BusCode])
                                 VALUES
                                       (@query_code
                                       ,'Reset Event'
                                       ,N'" + EventDetailsQuery + @"'
                                       ,getdate()
                                       ,'Local_Bus_Sqlite'
                                       ," + (LineNumber > -1 ? LineNumber.ToString() : "null") + @"
                                       ," + (BusCode > 0 ? BusCode.ToString() : "null") + @")";
                        }
                        //Query = Query.Remove(Query.Length - 1);
                        db.setQuery(Query);
                        if (db.Query_Execute() >= 0)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        ClassLibrary.JSystem.Except.AddException(ex);
                        return false;
                    }
                    finally
                    {
                        db.Dispose();
                    }
                }
            }
            return false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save(Convert.ToInt32(cmbBus.SelectedItem.Value), Convert.ToInt32(cmbLine.SelectedItem.Value)))
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");

        }
        protected void cmbLine_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbLine.SelectedValue) > 0)
            {
                DataTable dtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus Where Active = 1 
                                                                              and LastLineNumber = " + cmbLine.SelectedValue + " Order By BusNumber ASC");
                var p = (from v in dtBus.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, BUSNumber = "همه" });
                p.Insert(0, new { Code = -1, BUSNumber = "-" });
                cmbBus.DataSource = p;
                cmbBus.DataTextField = "BUSNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
            }
            else
            {
                LoadBus();
            }
        }

        protected void cmbBus_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbBus.SelectedValue) > 0)
            {
                DataTable dtLines = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [LineNumber],convert(nvarchar,[LineNumber])+' - - > '+[LineName] as [lineName],LineNumber FROM AUTLine Where LineNumber = (Select LastLineNumber From AutBus Where Code = " + cmbBus.SelectedValue + ") Order By LineNumber ASC");
                var p = (from v in dtLines.AsEnumerable()
                         select new { LineNumber = Convert.ToInt32(v["LineNumber"]), lineName = v["lineName"].ToString() }).ToList();
                p.Insert(0, new { LineNumber = -1, lineName = "همه" });
                p.Insert(0, new { LineNumber = -2, lineName = "-" });
                cmbLine.DataSource = p;
                cmbLine.DataTextField = "lineName";
                cmbLine.DataValueField = "LineNumber";
                cmbLine.DataBind();
            }
            else
            {
                LoadLines();
            }
        }
    }
}