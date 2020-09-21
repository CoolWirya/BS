using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JBusSendLineUpdateControl : System.Web.UI.UserControl
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
            if (cbAllEvents.Checked)
            {
                BusCode = 0;
                LineNumber = -2;
            }

            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            DataTable dtLine = new DataTable();
            DataTable dtPath = new DataTable();
            DataTable dtStation = new DataTable();

            try
            {
                string Query = "";
                string Str = "SELECT [LineNumber] Code,[LineNumber] Name FROM [dbo].[AUTLine]";
                if (Code > 0)
                    Str += " WHERE Code = " + Code.ToString();
                db.setQuery(Str);
                dtLine = db.Query_DataTable();

                Str = "SELECT Code,Name,Lat,Lng FROM [dbo].[AUTStation] S where lat <>0 and lng<>0";
                if (Code > 0)
                    Str += " and exists(select 1 from AUTLineStation AL inner join AUTLine A on A.code=AL.LineCode where StationCode=S.Code and A.code = " + Code.ToString() + ")";
                db.setQuery(Str);
                dtStation = db.Query_DataTable();

                Str = "select AL.Code,LineNumber,StationCode,Priority,IsBack+1 Dir from AUTLineStation AL inner join AUTLine A on A.code=AL.LineCode";
                if (Code > 0)
                    Str += " WHERE A.Code = " + Code.ToString();
                db.setQuery(Str);
                dtPath = db.Query_DataTable();

                for (int i = 0; i < dtLine.Rows.Count; i++)
                {
                    string LineQuery = "insert into line(''code'',''name'') values(" + dtLine.Rows[i]["Code"] + @",''" + dtLine.Rows[i]["Name"] + @"'');";
                    Query += @"
                            INSERT INTO [dbo].[AUTConsoleQueryAuto]
                                        (Code
                                        ,[Name]
                                        ,[QueryText]
                                        ,[InsertDate]
                                        ,[DataBaseName]
                                        ,[LineNumber]
                                        ,[BusCode])
                                 VALUES
                                       ((select max([Code]) from AUTConsoleQueryAuto)+1
                                       ,'Send Line'
                                       ,N'" + LineQuery + @"'
                                       ,getdate()
                                       ,'Local_Bus_Sqlite'
                                       ," + (LineNumber > -1 ? LineNumber.ToString() : "null") + @"
                                       ," + (BusCode > 0 ? BusCode.ToString() : "null") + @")";
                }

                for (int i = 0; i < dtStation.Rows.Count; i++)
                {
                    string StationQuery = "insert into Station(''code'',''name'',''Lat'',''Lon'') values("
                        + dtStation.Rows[i]["Code"] + @",''" + dtStation.Rows[i]["Name"] + @"'',''" + dtStation.Rows[i]["Lat"] + @"'',''" + dtStation.Rows[i]["Lng"] + @"'');";
                    Query += @"
                            INSERT INTO [dbo].[AUTConsoleQueryAuto]
                                        ([Code]
                                        ,[Name]
                                        ,[QueryText]
                                        ,[InsertDate]
                                        ,[DataBaseName]
                                        ,[LineNumber]
                                        ,[BusCode])
                                 VALUES
                                       ((select max([Code]) from AUTConsoleQueryAuto)+1
                                       ,'Send Station'
                                       ,N'" + StationQuery + @"'
                                       ,getdate()
                                       ,'Local_Bus_Sqlite'
                                       ," + (LineNumber > -1 ? LineNumber.ToString() : "null") + @"
                                       ," + (BusCode > 0 ? BusCode.ToString() : "null") + @")";
                }

                for (int i = 0; i < dtPath.Rows.Count; i++)
                {
                    string StationQuery = "insert into Path(''code'',''LineCode'',''StationCode'',''Ordered'',''Direction'') values("
                        + dtPath.Rows[i]["Code"]
                        + @",''" + dtPath.Rows[i]["LineNumber"]
                        + @"'',''" + dtPath.Rows[i]["StationCode"]
                        + @"'',''" + dtPath.Rows[i]["Priority"]
                        + @"'',''" + dtPath.Rows[i]["Dir"]
                        + @"'');";

                    Query += @"
                            INSERT INTO [dbo].[AUTConsoleQueryAuto]
                                        ([Code]
                                        ,[Name]
                                        ,[QueryText]
                                        ,[InsertDate]
                                        ,[DataBaseName]
                                        ,[LineNumber]
                                        ,[BusCode])
                                 VALUES
                                       ((select max([Code]) from AUTConsoleQueryAuto)+1
                                       ,'Send LinePath'
                                       ,N'" + StationQuery + @"'
                                       ,getdate()
                                       ,'Local_Bus_Sqlite'
                                       ," + (LineNumber > -1 ? LineNumber.ToString() : "null") + @"
                                       ," + (BusCode > 0 ? BusCode.ToString() : "null") + @")";
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