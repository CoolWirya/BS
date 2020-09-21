using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.Bus
{
    public class JBus : JSystem
    {
        public int Code { get; set; }
        /// <summary>
        /// Car Code
        /// </summary>
        public int CarCode { get; set; }
        /// <summary>
        /// BUS Number
        /// </summary>
        public double BUSNumber { get; set; }
        public bool Active { get; set; }
        public int FleetCode { get; set; } //ناوگان

        public JBus()
        {
        }
        public JBus(int pCode)
        {
            if (pCode > 0)
                GetData(pCode);
        }
        public JBus(string pBusNumber)
        {
            if (pBusNumber.Length > 0)
                GetData(pBusNumber);
        }
        public int Insert(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Bus.JBus.Insert"))
                return 0;
            JBusTable AT = new JBusTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JBus", Code, 0, 0, 0, "ثبت اتوبوس", "", 0);
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JBuses.GetDataTable(Code));
            return Code;
        }

        public bool Delete(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Bus.JBus.Delete"))
                return false;
            JBusTable AT = new JBusTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JBus", AT.Code, 0, 0, 0, "حذف اتوبوس", "", 0);
                return true;
            }
            else return false;
        }
        public bool Update(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Bus.JBus.Update"))
                return false;
            JBusTable AT = new JBusTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JBuses.GetDataTable(Code).Rows[0]);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JBus", AT.Code, 0, 0, 0, "ویرایش اتوبوس", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTBus where code=" + pCode.ToString());
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

        public bool GetData(string pBusNumber)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AUTBus where BUSNumber=" + pBusNumber);
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
            Node.Name = "Bus";
            Node.MouseClickAction = new JAction("Bus", "BusManagment.Bus.JBuses.ListView");

            return Node;
        }
        public void ShowDialog(int pCode)
        {
            JBusForm form = new JBusForm(pCode);
            form.ShowDialog();
        }
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "BusManagment.Bus.JBuses");
            Node.MouseDBClickAction = new JAction("EditAutomobile", "BusManagment.Bus.JBusForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JPopupMenu pMenu = new JPopupMenu("BusManagment.Bus.JBuses", Node.Code);

            JAction deleteAction = new JAction("delete...", "BusManagment.Bus.JBus.Delete", null, new object[] { (int)pRow["Code"] });
            JAction editAction = new JAction("edit...", "BusManagment.Bus.JBus.ShowDialog", new object[] { (int)pRow["Code"] }, null);
            JAction newAction = new JAction("new...", "BusManagment.Bus.JBus.ShowDialog", new object[] { 0 }, null);

            pMenu.Insert(deleteAction);
            pMenu.Insert(editAction);
            pMenu.Insert(newAction);

            Node.Popup = pMenu;
            return Node;

        }

        public void DeleteItem(int pCode, bool RefreshList = true)
        {
            if (JMessages.Question("از حذف این مورد مطمئن هستید؟", "حذف") != System.Windows.Forms.DialogResult.Yes)
                return;

            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Delete From AUTBus Where Code=" + pCode.ToString());
                db.Query_Execute();
                if (RefreshList)
                    JSystem.Nodes.RefreshDataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

    }

    public class JBuses : JSystem
    {
        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable();
            JSystem.Nodes.ObjectBase = new JAction("Bus", "BusManagment.Bus.JBus.GetNode");

            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.Bus.JBusForm.ShowDialog");

            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = ActInsertAutombile;
            InsertAutombile.Icon = JImageIndex.Add;

            JSystem.Nodes.AddToolbar(InsertAutombile);
        }

        public JNode[] TreeView()
        {
            return null;
        }

        public static DataTable GetDataTable(int pCode = 0)
        {
            if (!JPermission.CheckPermission("BusManagment.Bus.JBuses.GetDataTable"))
                return null;
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"Select AUTBus.Code 
		,  AUTAutomobile.Plaque	
		, AUTBus.BUSNumber
		, AUTFleet.Name FleetName
		, AUTBus.Active  
		, (Select IMEI FROM AUTDevice WHERE Code = (Select TOP 1 DeviceCode FROM AUTBusDevise WHERE BusCode = AUTBus .Code Order by StartDate Desc )) GSMSerial
		, (Select Tel FROM AUTDevice WHERE Code = (Select TOP 1 DeviceCode FROM AUTBusDevise WHERE BusCode = AUTBus .Code Order by StartDate Desc )) Mobile
		,(Select Fa_Date From StaticDates Where En_date =  (Select TOP 1 StartDate  FROM AUTBusDevise WHERE BusCode = AUTBus .Code Order by StartDate Desc )) StateChangeDate
        ,Properties.*
		from AUTBus 
		inner join AUTFleet  on AUTFleet.Code = AUTBus.FleetCode
		inner join AUTAutomobile  on AUTAutomobile.code = AUTBus.CarCode 
		left join [Propperty_ClassName_BusManagment.JBus_1] Properties ON Properties.ObjectCode = AUTBus.Code WHERE 1 = 1 "
                + " AND " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetDataTable", "AUTBus.Code");
                if (pCode > 0)
                    query += " AND AUTBus.Code = " + pCode;
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




        public static DataTable GetAllBusesOnly()
        {
            string BusQuery = "";
            JDataBase DB = new JDataBase();
            DB.setQuery(@"select ISNULL(IsAdmin,0)IsAdmin from users where Code = " + ClassLibrary.JMainFrame.CurrentUserCode);
            DataTable DtBusCheck = DB.Query_DataTable();
            if (DtBusCheck.Rows[0]["IsAdmin"].ToString() != "True")
            {
                BusQuery = " and len(BusNumber)=4 and BusNumber < 6999 ";
            }

            try
            {
                string query = "";
                string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "Code");
                if (PermitionSql.Length > 5)
                    query = @"Select Code,BusNumber from AUTBus Where Active = 1 and IsValid = 1 " + PermitionSql + BusQuery + " Order By BusNumber ASC";
                else
                    query = @"Select Code,BusNumber from AUTBus Where Active = 1 and IsValid = 1 " + BusQuery + " Order By BusNumber ASC";
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

        public static int GetBusCode(int BusNumber)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @" Select AUTBus.Code from AUTBus 
                                    Where AUTBus.BUSNumber = '" + BusNumber + "'";
                DB.setQuery(query);
                DataTable dt = DB.Query_DataTable();
                if (dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static bool CheckExists(int pCode, int pBusNumber)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = string.Format(@" Select AUTBus.Code from AUTBus WHERE Code <> {0}
                                    AND AUTBus.BUSNumber = '{1}'", pCode, pBusNumber);
                DB.setQuery(query);
                DataTable dt = DB.Query_DataTable();
                return (dt.Rows.Count > 0);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static int GetBusOwnerCode(uint BusNumber)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"select AUTBusOwner.Code from AUTBusOwner
                                inner join AUTBus on AUTBus.Code = AUTBusOwner.BusCode
                                where AUTBus.BUSNumber = '" + BusNumber + "'";
                DB.setQuery(query);
                DataTable dt = DB.Query_DataTable();
                if (dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static string GetWebQuery()
        {
            string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetWebQuery", "AUTBus.Code");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }
            return @"Select top 100 percent AUTBus.Code 
		,  AUTAutomobile.Plaque	
		, AUTBus.BUSNumber
		,cap.Name as OwnerName
		, AUTFleet.Name FleetName
		, AUTBus.Active  
				, (Select IMEI FROM AUTDevice WHERE Code = (Select TOP 1 DeviceCode FROM AUTBusDevise WHERE DeviceCode in (select Code from AUTDevice where Type = 1) and BusCode = AUTBus .Code Order by StartDate Desc )) GSMSerial
		, (Select ID FROM AUTDevice WHERE Code = (Select TOP 1 DeviceCode FROM AUTBusDevise WHERE DeviceCode in (select Code from AUTDevice where Type = 2) and BusCode = AUTBus .Code Order by StartDate Desc )) Reader1Serial
		, (Select ID FROM AUTDevice WHERE Code = (Select TOP 1 DeviceCode FROM AUTBusDevise WHERE DeviceCode in (select Code from AUTDevice where Type = 2) and BusCode = AUTBus .Code Order by StartDate asc )) Reader2Serial
		from AUTBus 
		left join AUTFleet  on AUTFleet.Code = AUTBus.FleetCode
		left join AUTAutomobile  on AUTAutomobile.code = AUTBus.CarCode 
		left join AUTBusOwner abo on AUTBus.Code = abo.BusCode
		left join clsAllPerson cap on cap.Code = abo.CodePerson
        where 1=1 " + PermitionSql;
        }


        public static string GetWebBusTransactionReportQuery(int ZoneCode = 0, int LineNumber = 0, int PersonelCode = 0, int BUSNumber = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, TimeSpan? StartTime = null, TimeSpan? EndTime = null, int CardType = -1, int DayType = -1, int FleetCode = 0)
        {
            string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetWebBusTransactionReportQuery", "dbo.AUTTicketTransaction.BusCode");
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
                FinalCardType = "and dbo.AUTTicketTransaction.CardType in (" + String.Join(",", JDataBase.DataTableToStringtArray(DtCardType, "Type")) + ")";
            }

            string Query = "", WhereStr = @" where 1=1 and dbo.AUTTicketTransaction.CardType = 0 and dbo.AUTTicketTransaction.TicketPrice > 0 
                                                        and len(dbo.AUTTicketTransaction.busnumber)=4
						                                and dbo.AUTTicketTransaction.Code in (select max(code)code from AUTTicketTransaction
										                group by cast(EventDate as date) , BusNumber,DriverCardSerial,LineNumber
                                                        ,FleetCode,BusCode,PassengerCardSerial,CardType,TicketPrice,RemainPrice,ReaderId)";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (ZoneCode > 0 || LineNumber > 0 || PersonelCode > 0 || BUSNumber > 0 || StartEventDate.HasValue == true || StartTime.HasValue == true || CardType > -1 || DayType > -1 || FleetCode > 0)
            {
                if (ZoneCode > 0)
                    WhereStr += @" and AUTTicketTransaction.ZoneCode = " + ZoneCode;

                if (FleetCode > 0)
                    WhereStr += " and AutLine.Fleet = " + FleetCode;

                if (LineNumber > 0)
                    WhereStr += @" and AutLine.Code = " + LineNumber;

                if (PersonelCode > 0)
                    WhereStr += @" and dbo.AUTTicketTransaction.DriverPersonCode=" + PersonelCode;

                if (BUSNumber > 0)
                    WhereStr += @" and dbo.AUTTicketTransaction.BusCode=" + BUSNumber;

                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && !StartTime.HasValue)
                    WhereStr += @" and convert(date,dbo.AUTTicketTransaction.EventDate) between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '" + EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";

                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && StartTime.HasValue)
                {
                    DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, StartTime.Value.Hours, StartTime.Value.Minutes, StartTime.Value.Seconds);
                    DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day, EndTime.Value.Hours, EndTime.Value.Minutes, EndTime.Value.Seconds);
                    WhereStr += @" and dbo.AUTTicketTransaction.EventDate between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'";
                }

                if (DayType > -1)
                {
                    if (DayType == 0)
                        WhereStr += " and cast(dbo.AUTTicketTransaction.EventDate as date) not in (select Date from AutHolidays)";
                    if (DayType == 1)
                        WhereStr += " and cast(dbo.AUTTicketTransaction.EventDate as date) in (select Date from AutHolidays)";
                }

                if (CardType > -1)
                    WhereStr += @" and AUTTicketTransaction.CardType = " + CardType;

            }

            Query = @"SELECT top 100 percent
                        dbo.AUTTicketTransaction.Code, dbo.AUTTicketTransaction.TransactionId,dbo.AUTTicketTransaction.FleetName,
                        dbo.AUTTicketTransaction.LineNumber, dbo.AUTTicketTransaction.BUSNumber,
                        dbo.AUTTicketTransaction.DriverPersonName as DriverName, dbo.AUTTicketTransaction.PassengerCardSerial, 
                        dbo.AUTTicketTransaction.CardType,
                        dbo.AUTTicketTransaction.TicketPrice * 10 as TicketPrice,
                        dbo.AUTTicketTransaction.RemainPrice * 10 RemainPrice, 
                        dbo.AUTTicketTransaction.EventDate,
                        dbo.AUTTicketTransaction.RecievedDate
                        FROM       dbo.AUTTicketTransaction Left Join AutLine on AUTTicketTransaction.LineNumber = AutLine.LineNumber" + WhereStr + PermitionSql;

            return Query;
        }

        public static string GetWebBusPerPerformanceReportQueryWithMuliBus(int ZoneCode = 0, int LineNumber = 0, int[] BusNumebr = null, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int OwnerCode = 0, int CardType = -1)
        {
            string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetWebQuery", "DP.BusCode");
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
                FinalCardType = "and DP.CardType in (" + String.Join(",", JDataBase.DataTableToStringtArray(DtCardType, "Type")) + ")";
            }

            string Query = "", WhereStr = " where 1=1 ";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue == true || BusNumebr.Length > 0 || ZoneCode > 0 || LineNumber > 0 || OwnerCode > 0 || CardType > -1)
            {
                if (BusNumebr.Length > 0)
                {
                    WhereStr += @" and DP.BusCode in (";
                    for (int i = 0; i < BusNumebr.Length; i++)
                    {
                        WhereStr += @"" + BusNumebr[i].ToString() + @",";
                    }
                    WhereStr = WhereStr.Remove(WhereStr.Length - 1, 1);
                    WhereStr += ") ";
                }

                if (ZoneCode > 0)
                    WhereStr += " and AZ.Code = " + ZoneCode;

                if (LineNumber > 0)
                    WhereStr += " and AL.Code = " + LineNumber;

                if (OwnerCode > 0)
                    WhereStr += " and DP.OwnerCode = " + OwnerCode;

                if (CardType > -1)
                    WhereStr += " and DP.CardType = " + CardType;


                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {
                    DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
                    DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
                    WhereStr += @" and DP.[Date] between '" + StartDTime.ToShortDateString() + "' and '" + EndDTime.ToShortDateString() + "'";
                }



            }


            Query = @"select top 100 percent max(DP.Code) as Code,AF.Name as FleetName,AZ.Name as ZoneName,
                            DP.LineNumber,AB.BUSNumber,DP.CardType,sum(DP.TCount) as TransactionCount,sum(DP.Price) * 10 as InCome,
                            (N''+cast(AB.BUSNumber as varchar)+N' - کارت نوع '+cast(DP.CardType as varchar)) as ColumnName
                            from [dbo].[AUTDailyPerformanceRportOnBus] DP
                            left join [dbo].[AUTBus] AB on DP.BusCode = AB.Code
                            left join [dbo].[AUTLine] AL on DP.LineNumber = AL.LineNumber
                            left join [dbo].[AUTZone] AZ on AL.ZoneCode = AZ.Code
                            left join [dbo].[AUTFleet] AF on AL.Fleet = AF.Code  
                            " + WhereStr + PermitionSql + FinalCardType + @"
							group by AB.BUSNumber,AF.Name,AZ.Name,DP.LineNumber,DP.CardType ";


            return Query;
        }


        public static string GetWebBusPerformanceReportQuery(int ZoneCode = 0, int LineNumber = 0, int BusNumebr = 0, int DayType = -1, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int OwnerCode = 0, bool CalcService = false, int TransactionType = 0, int CardType = -1, int FleetCode = 0)
        {
            string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetWebBusPerformanceReportQuery", "DP.BusCode");
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
                FinalCardType = "and DP.CardType in (" + String.Join(",", JDataBase.DataTableToStringtArray(DtCardType, "Type")) + ")";
            }

            DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
            DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
            string Query = "", WhereStr = " where DP.TCount > 0 and DP.Error = 0 and DP.TicketPrice > 0 and DP.Price > 0 and ab.Active = 1 and ab.IsValid = 1 ";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (ZoneCode > 0 || LineNumber > 0 || BusNumebr > 0 || DayType > -1 || StartEventDate.HasValue == true || OwnerCode > 0 || CalcService == true || TransactionType > 0 || CardType > -1 || FleetCode > 0)
            {
                if (ZoneCode > 0)
                    WhereStr += @" and AZ.Code=" + ZoneCode;

                if (LineNumber > 0)
                    WhereStr += @" and AL.Code=" + LineNumber;

                if (FleetCode > 0)
                    WhereStr += " and AB.FleetCode = " + FleetCode;

                if (OwnerCode > 0)
                {
                    WhereStr += @" and DP.OwnerCode = " + OwnerCode;
                }
                else
                {
                    if (BusNumebr > 0)
                        WhereStr += @" and DP.BusCode=" + BusNumebr;
                }

                if (DayType > -1)
                    WhereStr += " and DP.IsHoliday = " + DayType;


                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {

                    WhereStr += @" and DP.[Date] between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59'";
                }

                //if(CalcService==true)

                if (TransactionType > 0)
                {
                    if (TransactionType == 1)
                        WhereStr += @" and DP.DocumentCode = 0";
                    if (TransactionType == 2)
                        WhereStr += @" and DP.DocumentCode > 0";
                }

                if (CardType > -1)
                    WhereStr += @" and DP.CardType=" + CardType;

            }



            Query = @"select top 100 percent max(DP.Code) AS Code,AF.Name as FleetName,AZ.Name as ZoneName,
                            DP.LineNumber,AB.BUSNumber,CAP.Name,DP.CardType,DP.TicketPrice * 10 as TicketPrice,sum(DP.TCount) as TransactionCount,sum(DP.Price) * 10 as InCome
                            ,(sum(DP.DocumentCode) / TicketPrice) as PaymentTicketCount
                            ,sum(DP.DocumentCode) * 10 PaymentIncome
							,(sum(DP.TCount) - (sum(DP.DocumentCode) / TicketPrice))Mandeh
                            from [dbo].[AUTDailyPerformanceRportOnBus] DP
                            left join [dbo].[AUTBus] AB on DP.BusCode = AB.Code
                            left join [dbo].[AUTLine] AL on DP.LineNumber = AL.LineNumber
                            left join [dbo].[AUTZone] AZ on AL.ZoneCode = AZ.Code
                            left join [dbo].[AUTFleet] AF on AB.FleetCode = AF.Code   
							left join [dbo].[clsAllPerson] CAP on DP.OwnerCode = CAP.Code
                            " + WhereStr + PermitionSql + FinalCardType + @"
							GROUP BY dp.CardType,AF.Name,AZ.Name,DP.LineNumber,AB.BUSNumber,CAP.Name,DP.TicketPrice,DP.BusCode,DP.OwnerCode";


            return Query;
        }

        public static string GetMulFunctionOfBusQuery()
        {
            return @"select ab.Code,ab.BusNumber,af.Name as FleetName,ab.LastLineNumber as LineNumber,
                        ab.LastDate as AvlLastDate,ab.TicketLastDate,ab.LastSimCardCharge from AutBus ab
                        left join AutFleet af on ab.FleetCode = af.Code
                        where LEN(ab.BusNumber)=4 and ab.BusNumber < 7999";
        }

    }
}
