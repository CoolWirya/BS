using BusManagment.Line;
using BusManagment.Zone;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JGetQueryUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBus();
                LoadZones();
                LoadLines();
                LoadQueries();
                LoadGrid();
            }
            else
                LoadGrid();
        }

        void LoadQueries()
        {
            DataTable dt = BusManagment.Query.JQueries.GetDataTable();
            cmbQuery.DataSource = dt;
            cmbQuery.DataTextField = "name";
            cmbQuery.DataValueField = "Code";
            cmbQuery.DataBind();
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
//            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select AB.BUSNumber as BUSNumber,AB.CODE CODE
//                                                                        from [dbo].[AUTShiftDriver] DP
//                                                                        left join [dbo].[AUTBus] AB on DP.BusNumber = AB.BUSNumber
//                                                                        left join [dbo].[AUTLine] AL on DP.LineNumber = AL.LineNumber
//                                                                        left join [dbo].[AUTZone] AZ on AL.ZoneCode = AZ.Code 
//                                                                        where len(ab.BUSNumber) = 4 and ab.BUSNumber > 1000 and ab.BUSNumber < 6999
//                                                                        GROUP BY AB.BUSNumber,AB.CODE
//                                                                        order by Ab.BUSNumber");
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["CODE"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "CODE";
            cmbBus.DataBind();
        }

        public void GetReport(int QueryCode, int ZoneCode = 0, int LineNumber = 0, int BusCode = 0)
        {
            string WhereStr = "";

            if (ZoneCode > 0)
                WhereStr += @" and AZ.Code= " + ZoneCode;

            if (LineNumber > 0)
                WhereStr += @" and AL.Code= " + LineNumber;

            if (BusCode > 0)
                WhereStr += @" and AB.Code= " + BusCode;

            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select AB.BUSNumber as BUSNumber
                                                                        from [dbo].[AUTBus] AB
                                                                        left join [dbo].[AUTLine] AL on AB.LastLineNumber = AL.LineNumber
                                                                        left join [dbo].[AUTZone] AZ on AL.ZoneCode = AZ.Code 
                                                                        where 1=1 " + WhereStr + @"
                                                                        GROUP BY AB.BUSNumber");
            string QueryText, SqlQuery = "";
            BusManagment.Query.JQuery Query = new BusManagment.Query.JQuery();
            Query.GetData(QueryCode);
            QueryText = Query.QueryText;

            JDataBase DB = new JDataBase();

            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    int Count = 0;
                    SqlQuery = @"INSERT INTO [dbo].[AUTConsoleQuerySendStatus] ([BusNumber],[QueryCode],[QueryText],[DataBaseName],[Status],[InsertDate]) VALUES ";
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        Count++;
                        SqlQuery += @" (" + Dt.Rows[i]["BUSNumber"].ToString() + " , 0, '" + QueryText.Replace("'", "''") + @"','" + cmbDataBase.SelectedValue + @"', 0, GetDate()) , ";
                        if(Count > 100)
                        {
                            SqlQuery = SqlQuery.Substring(0, SqlQuery.Length - 3);
                            DB.setQuery(SqlQuery);

                            if (!(DB.Query_Execute() >= 0))
                            {
                                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در ثبت اطلاعات');", "ConfirmDialog");
                                return;
                            }
                            Count = 0;
                            SqlQuery = @"INSERT INTO [dbo].[AUTConsoleQuerySendStatus] ([BusNumber],[QueryCode],[QueryText],[DataBaseName],[Status],[InsertDate]) VALUES ";
                        }
                    }
                    SqlQuery = SqlQuery.Substring(0, SqlQuery.Length - 3);
                }
            }
            DB.setQuery(SqlQuery);

            if (DB.Query_Execute() >= 0)
            {
                LoadGrid();
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
            }
            else { WebClassLibrary.JWebManager.RunClientScript("alert('خطا در ثبت اطلاعات');", "ConfirmDialog"); }
        }

        public void LoadGrid()
        {
            JDataBase DB = new JDataBase();
            DB.setQuery("SELECT Code, BusNumber, QueryText, DataBaseName, case  when Status = 2 then N'اعمال شده' else N'اعمال نشده' end State FROM [dbo].[AUTConsoleQuerySendStatus] where QueryCode = 0 Order By Code desc");
            DataTable Dt = DB.Query_DataTable();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbQuery.SelectedValue != "")
            {
                GetReport(Convert.ToInt32(cmbQuery.SelectedValue),
                    Convert.ToInt32(cmbZone.SelectedValue),
                          Convert.ToInt32(cmbLine.SelectedValue),
                          Convert.ToInt32(cmbBus.SelectedValue));
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

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


        protected void cmbBus_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbBus.SelectedValue) > 0)
            {
                DataTable dtLines = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],convert(nvarchar,[LineNumber])+' -> '+[LineName] as [lineName],LineNumber FROM AUTLine Where LineNumber = (Select LastLineNumber From AutBus Where Code = " + cmbBus.SelectedValue + ") Order By LineNumber ASC");
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
                          select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, BUSNumber = "همه" });
                cmbBus.DataSource = p2;
                cmbBus.DataTextField = "BUSNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
            }
            else
            {
                LoadZones();
                LoadBus();
            }
        }
    }
}