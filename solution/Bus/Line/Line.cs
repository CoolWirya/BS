using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace BusManagment.Line
{
    public class JLine : JSystem
    {
        public int Code { get; set; }
        public string LineName { get; set; }
        public double LineNumber { get; set; }
        public int Fleet { get; set; }
        public int ZoneCode { get; set; }
        public int LineType { get; set; }
        public int NumOfServicePerDay { get; set; }
        public int TimeOfService { get; set; }
        public bool Status { get; set; }
        public bool Rotate { get; set; }
        public float Distance { get; set; }

        public int Insert(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Line.JLine.Insert"))
                return 0;
            LineTable AT = new LineTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JLines.GetDataTable(Code));
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JLine", Code, 0, 0, 0, "ثبت خطوط", "", 0);
            return Code;
        }
        public JLine()
        {
        }
        public JLine(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public JLine(string pLineNumber)
        {
            if (pLineNumber.Length > 0)
                this.GetData(pLineNumber);
        }
        public bool Update(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Line.JLine.Update"))
                return false;
            LineTable AT = new LineTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JLines.GetDataTable(Code).Rows[0]);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                //jHistory.Save("BusManagment.JLine", AT.Code, 0, 0, 0, "ویرایش خطوط", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Line.JLine.Delete"))
                return false;
            LineTable AT = new LineTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JLine", AT.Code, 0, 0, 0, "حذف خطوط", "", 0);
                return true;
            }
            else return false;
        }
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTLine where code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public bool GetData(string pLineNumber)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AUTLine where LineNumber=" + pLineNumber);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public static JNode GetTreeNode()
        {
            JNode Node = new JNode(0, 0);
            Node.Name = "Line";
            Node.MouseClickAction = new JAction("Line", "BusManagment.Line.JLines.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Line.JLine");

            JPopupMenu pMenu = new JPopupMenu("BusManagment.Line.JLines", Node.Code);
            JAction deleteAction = new JAction("delete...", "BusManagment.Line.JLine.Delete", null, new object[] { (int)pRow["Code"] });
            JAction editAction = new JAction("Edit...", "BusManagment.Line.FormLine.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction newAction = new JAction("new...", "BusManagment.Line.FormLine.ShowDialog", null, null);

            Node.MouseDBClickAction = editAction;
            pMenu.Insert(deleteAction);
            pMenu.Insert(editAction);
            pMenu.Insert(newAction);

            Node.Popup = pMenu;
            Node.MouseDBClickAction = editAction;
            return Node;

        }
    }

    public class JLines : JSystem
    {

        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable(0);
            JSystem.Nodes.ObjectBase = new JAction("Line", "BusManagment.Line.JLine.GetNode");

            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.Line.FormLine.ShowDialog");

            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = ActInsertAutombile;
            InsertAutombile.Icon = JImageIndex.Add;

            JSystem.Nodes.AddToolbar(InsertAutombile);
        }

        public JNode[] TreeView()
        {
            return null;
        }

        public static DataTable GetDataTable(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"
                                    SELECT 
	                                    L.[Code]
	                                    ,l.[LineName]
	                                    ,l.[LineNumber]
	                                    ,Z.[Name] AS 'ZoneName'
	                                    ,F.[Name] AS 'FleetName'
	                                    ,D.[name] AS 'LineType'
	                                    ,L.[Status]
	                                    ,l.[Rotate]
                                        ,l.[Distance]
										,(Select Name From AUTStation WHERE Code = (Select  Top 1  StationCode  from AUTLineStation WHERE LineCode = L.Code AND IsBack = 0 Order BY Priority )) Source
										,(Select Name From AUTStation WHERE Code = (Select  Top 1  StationCode  from AUTLineStation WHERE LineCode = L.Code AND IsBack = 0 Order BY Priority Desc )) Destination
                                    FROM AUTLine L
                                    INNER JOIN AUTZone Z ON L.ZoneCode = Z.Code
                                    INNER JOIN AUTFleet F ON L.Fleet = F.Code
                                    INNER JOIN subdefine D ON L.LineType = D.Code
                                "
                + " Where " + JPermission.getObjectSql("BusManagment.Line.JLines.GetDataTable", "L.Code");
                if (pCode > 0)
                    query += " AND  L.Code = " + pCode;
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static DataTable GetWebDataTable(int pCode)
        {

            string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Line.JLines.GetWebDataTable", "Code");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            JDataBase DB = new JDataBase();
            try
            {
                string query = @"SELECT [Code],convert(nvarchar,[LineNumber])+' --> '+[LineName] as [lineName],LineNumber,(cast(Code as varchar)+' - '+cast(LineNumber as varchar))LineNumberWithCode FROM AUTLine ";
                if (pCode > 0)
                {
                    query += " WHERE Code = " + pCode + PermitionSql + " Order By LineNumber ASC";
                }
                else
                {
                    query += " WHERE 1 = 1 " + PermitionSql + " Order By LineNumber ASC";
                }
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static DataTable GetSimpletWebDataTable(int pCode)
        {

            string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Line.JLines.GetWebDataTable", "Code");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            JDataBase DB = new JDataBase();
            try
            {
                string query = @"SELECT [Code],[LineNumber] as [lineName],LineNumber FROM AUTLine ";
                if (pCode > 0)
                {
                    query += " WHERE Code = " + pCode + PermitionSql + " Order By LineNumber ASC";
                }
                else
                {
                    query += " WHERE 1 = 1 " + PermitionSql + " Order By LineNumber ASC";
                }
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static string GetWebQuery()
        {
            return @"SELECT top 100 percent
	                    L.[Code]
	                    ,l.[LineName]
	                    ,l.[LineNumber]
	                    ,Z.[Name] AS 'ZoneName'
	                    ,F.[Name] AS 'FleetName'
	                    ,D.[name] AS 'LineType'
                        ,L.[NumOfServicePerDay]
                        ,L.[TimeOfService]
	                    ,L.[Status] as N'وضعیت - فعال / غیرفعال'
	                    ,l.[Rotate] as N'چرخشی'
                        ,L.[Distance]
                    FROM AUTLine L
                    INNER JOIN AUTZone Z ON L.ZoneCode = Z.Code
                    INNER JOIN AUTFleet F ON L.Fleet = F.Code
                    INNER JOIN subdefine D ON L.LineType = D.Code";
        }


        public static string GetWebReportQuery(int ZoneCode = 0, int LineNumber = 0, int DayType = -1, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int CardType = -1, int FleetCode = 0)
        {

            string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetWebBusTransactionReportQuery", "adp.BusCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            string CardTypePermitionSql = JPermission.getObjectSql("BusManagment.Card.JCards.GetDataTable", "Code");
            string FinalCardType = "";
            if (CardTypePermitionSql == " 1 = 1 ")
            {
                CardTypePermitionSql = "";
            }
            else
            {
                JDataBase mydb = new JDataBase();
                mydb.setQuery("Select Type From AutCardType Where " + CardTypePermitionSql);
                DataTable DtCardType = mydb.Query_DataTable();
                FinalCardType = "and adp.CardType in (" + String.Join(",", JDataBase.DataTableToStringtArray(DtCardType, "Type")) + ")";
            }

            string Query = "", WhereStr = "", FleetWhereStr = "";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
            DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
            if (ZoneCode > 0 || LineNumber > 0 || StartEventDate.HasValue == true || CardType > -1 || DayType > -1 || FleetCode > 0)
            {

                WhereStr = " where adp.TCount > 0 and adp.Price > 0 and adp.TicketPrice > 0 and adp.Error = 0 ";

                if (ZoneCode > 0)
                    WhereStr += @" and az.Code=" + ZoneCode;

                if (FleetCode > 0)
                    FleetWhereStr += " and FleetCode = " + FleetCode;

                if (LineNumber > 0)
                    WhereStr += @" and al.Code=" + LineNumber;

                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {
                    WhereStr += @" and adp.Date between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + @" 23:59:59'";
                }

                if (CardType > -1)
                    WhereStr += @" and adp.CardType=" + CardType;

                if (DayType > -1)
                    WhereStr += " and adp.IsHoliDay = " + DayType;

            }

            Query = @"select top 100 percent max(adp.Code)Code,af.Name FleetName,az.Name ZoneName,adp.LineNumber,adp.CardType,
                        cast(adp.TicketPrice * 10.0 as float)TicketPrice,cast(sum(adp.Tcount)as float)TransactionCount,sum(cast(adp.Price as float)) * 10.0   InCome from  
                        (select * from AUTDailyPerformanceRportOnBus where BusCode in (select Code from AUTBus where 1 = 1 " + FleetWhereStr + @")) adp
                        left join AUTLine al on al.LineNumber = adp.LineNumber
                        left join AUTZone az on az.Code = al.ZoneCode
                        left join AUTFleet af on af.Code = al.Fleet
                       " + WhereStr + FinalCardType + PermitionSql + @"
                        group by af.Name,az.Name,adp.LineNumber,adp.CardType,adp.TicketPrice";
            return Query;
        }

    }
}
