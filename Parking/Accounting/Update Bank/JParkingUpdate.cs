using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data.SqlClient;
using Janus.Windows.UI.CommandBars;
using System.Data.SqlClient;

namespace Parking
{
   public  class JParkingConfigure:JParking
    {
      
       System.Data.SqlClient.SqlConnectionStringBuilder SqlBuilder;
       public JParkingConfigure()
       {
           JConnection conn = new JConnection();
           SqlBuilder = conn.GetSQlServerConnection("Parking.JDayProfile", 0);
           
       }
      

       /// <summary>
       /// برگرداندن شماره کارت
       /// </summary>
       /// <param name="rfidcard"></param>
       /// <param name="_idcard"></param>
       /// <returns></returns>
       public System.Data.DataTable RetriveTraffic(DateTime Dtin, DateTime DateOut)
       {
           JDataBase jdb = new JDataBase(SqlBuilder);
           try
           {
               jdb.setQuery("SELECT     dbo.PrkGroups.TypeGroup, dbo.PrkGate.Name AS Gatein,"+JDataBase.SQLMiladiToShamsi("dbo.Traffic.DateIn","DateIN")+", dbo.Traffic.TimeIn, PrkGate_1.Name AS Gateout,"+JDataBase.SQLMiladiToShamsi("dbo.Traffic.DateOut","DateOut")+", "+
                      "dbo.Traffic.TimeOut, dbo.Traffic.Amount "+
"FROM         dbo.Traffic INNER JOIN "+
                      "dbo.PrkGate ON dbo.Traffic.GateIn = dbo.PrkGate.Code INNER JOIN "+
                      "dbo.PrkGate AS PrkGate_1 ON dbo.Traffic.GateOut = PrkGate_1.Code LEFT OUTER JOIN "+
                      "dbo.PrkGroups ON dbo.Traffic.GroupCard = dbo.PrkGroups.GroupNumber where dbo.Traffic.DateOut  between '" + Dtin.ToString("yyyy/MM/dd") + "' And " + " '" + DateOut.ToString("yyyy/MM/dd") + "'"); 
               return jdb.Query_DataTable();
               
           }
           catch
           {
               return null;
           }
           finally
           {
               jdb.Dispose();
           }

       }
       public System.Data.DataTable GetCardHistory(Int64 RfidNumber)
       {
           JDataBase jdb = new JDataBase(SqlBuilder);
           try
           {
               jdb.setQuery("SELECT     dbo.Traffic.Code, PrkGate_1.Name AS gatein," + JDataBase.SQLMiladiToShamsi("dbo.Traffic.DateIn", "DateIn") + " ,dbo.Traffic.UserInTitle,dbo.Traffic.TimeIn AS Timein,dbo.PrkGate.Name AS Gateout," + JDataBase.SQLMiladiToShamsi("dbo.Traffic.DateOut", "DateOut") + ", dbo.Traffic.TimeOut,dbo.Traffic.UserOutTitle, dbo.ParkingData.FullNamePerson, " +
                    "  dbo.ParkingData.TypeCar, dbo.ParkingData.Color, dbo.ParkingData.Plaque "+
"FROM         dbo.Traffic INNER JOIN dbo.PrkGate ON dbo.Traffic.GateOut = dbo.PrkGate.Code LEFT OUTER JOIN  dbo.ParkingData ON dbo.Traffic.IDCard = dbo.ParkingData.RfidNumber LEFT OUTER JOIN "+
                      "dbo.PrkGate AS PrkGate_1 ON dbo.Traffic.GateIn = PrkGate_1.Code where IDCard='" + RfidNumber.ToString() + "'");
               return jdb.Query_DataTable();
           }
           catch
           {
               return null;
           }
           finally
           {
               jdb.Dispose();
           }
       }
       #region Function
       public Boolean RetriveCardID(string rfidcard, ref int _idcard)
       {
           JDataBase jdb = new JDataBase(SqlBuilder);
           try
           {
               jdb.setQuery("select max(IDCardParking) from Traffic where RfidNumber='" + rfidcard + "'");
               _idcard = Convert.ToInt32(jdb.Query_ExecutSacler());
               return true;
           }
           catch
           {
               return false;
           }
           finally
           {
               jdb.Dispose();
           }
       }

      

       private String QueryGateInsert(string PCode, string Name, string Market, string TypeGate, string DeviceName, string Ip, string IpCamera, string IpCenter, string IpSystem, string MarketName, string SubIp, string Port, int State)
       {
           string StrBuilder = "";
           StrBuilder = "INSERT INTO [dbo].[PrkGate] ([Code],[Name],[Market],[TypeGate],[DeviceName],[Ip],[IpCamera],[IpCenter],[IpSystem],[MarketName],[SubIp],[Port],[State]) " +
             "VALUES " +
            "('" + PCode + "','" + Name + "','" + Market + "','" + TypeGate + "','" + DeviceName + "','" + Ip + "','" + IpCamera + "','" + IpCenter + "','" + IpSystem + "','" + MarketName + "','" + SubIp + "','" + Port + "','" + State.ToString() + "') \r\n";

           return StrBuilder;
       }

       private String QueryGroupInsert(string PCode, string pTypeGroup, string pFirstAmount, string pSecondAmount, int pAmountReceived, string pMarketCode, string pAbate, string pOffers, string pRound, int pPayIsElectronic, string pUnitTime, int pUpRound, int pGroupNumber, int pPayByDialy, string pDailyPrice, int pIsActive, int pIsDailyApart, int pIsFirstHourApart)
       {
           string StrBuilder = "";
           StrBuilder = "INSERT INTO [dbo].[PrkGroups] ([Code],[TypeGroup],[FirstAmount],[SecondAmount],[AmountReceived],[MarketCode],[Abate],[Offers],[Round],[PayIsElectronic],[UnitTime],[UpRound],[GroupNumber],[PayByDialy],[DailyPrice],[IsActive],[IsDailyApart],[IsFirstHourApart]) " +
             "VALUES " +
            "('" + PCode + "','" + pTypeGroup + "','" + pFirstAmount + "','" + pSecondAmount + "','" + pAmountReceived + "','" + pMarketCode + "','" + pAbate + "','" + pOffers + "','" + pRound + "','" + pPayIsElectronic + "','" + pUnitTime + "','" + pUpRound + "','" + pGroupNumber + "','" + pPayByDialy + "','" + pDailyPrice + "','" + pIsActive + "','" + pIsDailyApart + "','" + pIsFirstHourApart + "') \r\n";

           return StrBuilder;
       }

       public System.Data.DataTable CreateParkingTable()
       {
           JDataBase jdb = new JDataBase();
           JDataBase JdbParking = JdbParking = new JDataBase(SqlBuilder);
           //string Query = "";
           try
           {
          
           //try
           //{
           //    jdb.setQuery("SELECT     dbo.PrkCardParking.Code AS CodeParking, ISNULL(dbo.PrkCardParking.DateExpire, dbo.SmElectronicCard.DateExpire) AS DateExpireParking, dbo.PrkCardParking.DateActive AS DateActiveParking, dbo.PrkCardParking.CodeGroup, dbo.PrkCardParking.StatusParking, dbo.SmElectronicCard.Code, dbo.SmElectronicCard.DateExpire AS DateExpireElectronicCard, dbo.SmElectronicCard.SerialCard, dbo.PrkGroups.TypeGroup, dbo.SmElectronicCard.IDCardParking, ISNULL(dbo.SmElectronicCard.RfidNumber, '0') AS RfidNumber, dbo.SmElectronicCard.Market, dbo.SmElectronicCard.TypeCard, dbo.SmElectronicCard.DateActive, dbo.SmElectronicCard.StatusCard, subdefine_2.name AS InactiveDuoParking, dbo.estMarket.Title AS Markettitle,  subdefine_3.name AS InactiveDueElectronicCard, dbo.SmElectronicCard.StatusCard FROM         dbo.PrkCardParking INNER JOIN  dbo.SmElectronicCard ON dbo.PrkCardParking.IDCardParking = dbo.SmElectronicCard.Code INNER JOIN  dbo.PrkGroups ON dbo.PrkCardParking.CodeGroup = dbo.PrkGroups.Code INNER JOIN dbo.subdefine AS subdefine_2 ON dbo.PrkCardParking.InactiveDue = subdefine_2.Code INNER JOIN dbo.estMarket ON dbo.SmElectronicCard.Market = dbo.estMarket.Code INNER JOIN dbo.subdefine AS subdefine_3 ON dbo.SmElectronicCard.InactiveDue = subdefine_3.Code  Where dbo.SmElectronicCard.TypeCard='" + Convert.ToInt32(SmartCards.TypeCard.Custromers) + "' \r\n " +
           //        "SELECT     dbo.PrkCardParking.DateExpire AS DateExpireParking, dbo.PrkCardParking.DateActive AS DateActiveParking, dbo.PrkCardParking.CodeGroup, dbo.PrkCardParking.StatusParking, dbo.SmElectronicCard.Code, dbo.SmElectronicCard.DateExpire AS DateExpireElectronicCard, ISNULL(dbo.SmElectronicCard.RfidNumber, '0') AS RfidNumber, dbo.PrkCardParking.Code AS CodeParking, dbo.PrkCar.Plaque, dbo.PrkCar.CarOwner,  dbo.subdefine.name AS Color, subdefine_1.name AS TypeCar, dbo.SmElectronicCard.SerialCard, dbo.PrkGroups.TypeGroup, dbo.SmElectronicCard.IDCardParking, dbo.SmElectronicCard.Market, dbo.SmElectronicCard.TypeCard, dbo.SmElectronicCard.DateActive, dbo.SmElectronicCard.StatusCard,ISNULL(dbo.SmSellers.EndDateContract, dbo.SmElectronicCard.DateExpire) AS EndDateContract, dbo.clsPerson.Name + ' ' + dbo.clsPerson.Fam AS FullNamePerson,  dbo.finAsset.Comment, subdefine_2.name AS InactiveDuoParking, dbo.estMarket.Title AS Markettitle, subdefine_3.name AS InactiveDueElectronicCard, dbo.SmElectronicCard.StatusCard FROM         dbo.PrkCardParking INNER JOIN dbo.SmElectronicCard ON dbo.PrkCardParking.IDCardParking = dbo.SmElectronicCard.Code INNER JOIN dbo.PrkCar ON dbo.PrkCardParking.Code = dbo.PrkCar.IDCardParking INNER JOIN  dbo.subdefine ON dbo.PrkCar.CarColor = dbo.subdefine.Code INNER JOIN   dbo.subdefine AS subdefine_1 ON dbo.PrkCar.TypeCar = subdefine_1.Code AND dbo.PrkCar.Defult = 'True' INNER JOIN  dbo.PrkGroups ON dbo.PrkCardParking.CodeGroup = dbo.PrkGroups.Code INNER JOIN   dbo.SmSellers ON dbo.SmElectronicCard.Code = dbo.SmSellers.CodeBaseCard INNER JOIN dbo.clsPerson ON dbo.SmSellers.IdPerson = dbo.clsPerson.Code INNER JOIN dbo.finAsset ON dbo.SmSellers.IDAsset = dbo.finAsset.Code INNER JOIN  dbo.subdefine AS subdefine_2 ON dbo.PrkCardParking.InactiveDue = subdefine_2.Code INNER JOIN  dbo.estMarket ON dbo.SmElectronicCard.Market = dbo.estMarket.Code INNER JOIN  dbo.subdefine AS subdefine_3 ON dbo.SmElectronicCard.InactiveDue = subdefine_3.Code  Where dbo.SmElectronicCard.TypeCard='" + Convert.ToInt32(SmartCards.TypeCard.Sellers) + "'  \r\n" +
           //        "SELECT     dbo.PrkCardParking.DateExpire AS DateExpireParking, dbo.PrkCardParking.DateActive AS DateActiveParking, dbo.PrkCardParking.CodeGroup, dbo.PrkCardParking.StatusParking, dbo.SmElectronicCard.Code, dbo.SmElectronicCard.DateExpire AS DateExpireElectronicCard, ISNULL(dbo.SmElectronicCard.RfidNumber, '0') AS RfidNumber, dbo.PrkCardParking.Code AS CodeParking, dbo.PrkCar.Plaque, dbo.PrkCar.CarOwner,  dbo.subdefine.name AS Color, subdefine_1.name AS TypeCar, dbo.SmElectronicCard.SerialCard, dbo.PrkGroups.TypeGroup, dbo.SmElectronicCard.IDCardParking, dbo.SmElectronicCard.Market, dbo.SmElectronicCard.TypeCard, dbo.SmElectronicCard.DateActive, dbo.SmElectronicCard.StatusCard,                       dbo.SmPersonalCard.EndDateContract, dbo.clsPerson.Name + ' ' + dbo.clsPerson.Fam AS FullNamePerson, subdefine_2.name AS InactiveDuoParking,  dbo.estMarket.Title AS Markettitle, subdefine_3.name AS InactiveDueElectronicCard, dbo.SmElectronicCard.StatusCard FROM  dbo.PrkCardParking INNER JOIN  dbo.SmElectronicCard ON dbo.PrkCardParking.IDCardParking = dbo.SmElectronicCard.Code INNER JOIN  dbo.PrkCar ON dbo.PrkCardParking.Code = dbo.PrkCar.IDCardParking INNER JOIN dbo.subdefine ON dbo.PrkCar.CarColor = dbo.subdefine.Code INNER JOIN  dbo.subdefine AS subdefine_1 ON dbo.PrkCar.TypeCar = subdefine_1.Code AND dbo.PrkCar.Defult = 'True' INNER JOIN  dbo.PrkGroups ON dbo.PrkCardParking.CodeGroup = dbo.PrkGroups.Code INNER JOIN  dbo.SmPersonalCard ON dbo.SmElectronicCard.Code = dbo.SmPersonalCard.CodeBaseCard INNER JOIN  dbo.clsPerson ON dbo.SmPersonalCard.IdPerson = dbo.clsPerson.Code INNER JOIN  dbo.subdefine AS subdefine_2 ON dbo.PrkCardParking.InactiveDue = subdefine_2.Code INNER JOIN  dbo.estMarket ON dbo.SmElectronicCard.Market = dbo.estMarket.Code INNER JOIN   dbo.subdefine AS subdefine_3 ON dbo.SmElectronicCard.InactiveDue = subdefine_3.Code   Where dbo.SmElectronicCard.TypeCard='" + Convert.ToInt32(SmartCards.TypeCard.Persons) + "'");

           //    jdb.Query_DataSet();
           //    System.Data.DataSet Ds = jdb.DataSet;
           //    foreach (System.Data.DataRow dr in Ds.Tables[0].Rows)
           //    {
           //        try
           //        {
           //            Query = Query + QueryParkingInsert(dr["CodeParking"].ToString(), Convert.ToDateTime(dr["DateExpireParking"]).ToString("yyyy/MM/dd"), dr["CodeGroup"].ToString(), dr["StatusParking"].ToString(), Convert.ToDateTime(dr["DateExpireElectronicCard"]).ToString("yyyy/MM/dd"), "---", "---", "---", "---", dr["SerialCard"].ToString(), dr["TypeGroup"].ToString(), dr["IDCardParking"].ToString(), dr["Market"].ToString(), dr["TypeCard"].ToString(), dr["InactiveDuoParking"].ToString(), "مشتري", "---", Convert.ToDateTime(dr["DateExpireElectronicCard"]).ToString("yyyy/MM/dd"), dr["RfidNumber"].ToString(), dr["Markettitle"].ToString(), dr["InactiveDueElectronicCard"].ToString(), dr["StatusCard"].ToString());
           //        }
           //        catch
           //        {
           //        }
           //    }
           //    SqlConnection cnn = new SqlConnection(SqlBuilder.ConnectionString);
           //    cnn.Open();
           //    SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[ParkingData]\r\n " + Query + " \r\n Select * From ParkingData", cnn);
           //    cmd.CommandType = System.Data.CommandType.Text;
           //    int i = cmd.ExecuteNonQuery();
           //    cnn.Close();
           //    Query = "";
           //    foreach (System.Data.DataRow dr in Ds.Tables[1].Rows)
           //    {
           //        try
           //        {
           //            Query = Query + QueryParkingInsert(dr["CodeParking"].ToString(), Convert.ToDateTime(dr["DateExpireParking"]).ToString("yyyy/MM/dd"), dr["CodeGroup"].ToString(), dr["StatusParking"].ToString(), Convert.ToDateTime(dr["DateExpireElectronicCard"]).ToString("yyyy/MM/dd"), dr["Plaque"].ToString(), dr["CarOwner"].ToString(), dr["Color"].ToString(), dr["TypeCar"].ToString(), dr["SerialCard"].ToString(), dr["TypeGroup"].ToString(), dr["IDCardParking"].ToString(), dr["Market"].ToString(), dr["TypeCard"].ToString(), dr["InactiveDuoParking"].ToString(), dr["FullNamePerson"].ToString(), dr["Comment"].ToString(), Convert.ToDateTime(dr["EndDateContract"]).ToString("yyyy/MM/dd"), dr["RfidNumber"].ToString(), dr["Markettitle"].ToString(), dr["InactiveDueElectronicCard"].ToString(), dr["StatusCard"].ToString());
           //        }
           //        catch
           //        {
           //        }
           //    }
           //    cnn = new SqlConnection(SqlBuilder.ConnectionString);
           //    cnn.Open();
           //    cmd = new SqlCommand(Query + " \r\n Select * From ParkingData", cnn);
           //    cmd.CommandType = System.Data.CommandType.Text;
           //    i = cmd.ExecuteNonQuery();
           //    cnn.Close();
           //    Query = "";
           //    foreach (System.Data.DataRow dr in Ds.Tables[2].Rows)
           //    {
           //        try
           //        {
           //            Query = Query + QueryParkingInsert(dr["CodeParking"].ToString(), Convert.ToDateTime(dr["DateExpireParking"]).ToString("yyyy/MM/dd"), dr["CodeGroup"].ToString(), dr["StatusParking"].ToString(), Convert.ToDateTime(dr["DateExpireElectronicCard"]).ToString("yyyy/MM/dd"), dr["Plaque"].ToString(), dr["CarOwner"].ToString(), dr["Color"].ToString(), dr["TypeCar"].ToString(), dr["SerialCard"].ToString(), dr["TypeGroup"].ToString(), dr["IDCardParking"].ToString(), dr["Market"].ToString(), dr["TypeCard"].ToString(), dr["InactiveDuoParking"].ToString(), dr["FullNamePerson"].ToString(), "قسمت اداري", Convert.ToDateTime(dr["EndDateContract"]).ToString("yyyy/MM/dd"), dr["RfidNumber"].ToString(), dr["Markettitle"].ToString(), dr["InactiveDueElectronicCard"].ToString(), dr["StatusCard"].ToString());
           //        }
           //        catch
           //        {
           //        }
           //    }

           //    cnn = new SqlConnection(SqlBuilder.ConnectionString);
           //    cnn.Open();
           //    cmd = new SqlCommand( Query + " \r\n Select * From ParkingData", cnn);
           //    cmd.CommandType = System.Data.CommandType.Text;
           //    i = cmd.ExecuteNonQuery();
           //    cnn.Close();
           //    Query = "";
          
         
           JdbParking.setQuery(" select * From ParkingData");
           return JdbParking.Query_DataTable();
               
                 
                   
                
           }
           catch
           {
              
               return null;
           }
           finally
           {
               //jdb.Dispose();
               JdbParking.Dispose();
           }
       }
       private String QueryParkingInsert(string PCode, string DateExpireParking, string CodeGroup, string StatusParking, string DateExpireElectronicCard, string Plaque, string CarOwner, string Color, string TypeCar, string SerialCard, string TypeGroup, string IDCardParking, string Market, string TypeCard, string InactiveDuoParking, string FullNamePerson, string AssetCommand, string EndDateContract, string RfidNummber, string MarketTitle, string InactiveDueElectronicCard, string StatusCard)
       {
           string StrBuilder = "";
           return StrBuilder = "INSERT INTO [dbo].[ParkingData] ([Code],[DateExpireParking],[CodeGroup],[StatusParking],[CodeElectronic],[DateExpireElectronicCard],[Plaque],[CarOwner],[Color],[TypeCar],[SerialCard],[TypeGroup],[IDCardParking],[Market] " + ",[TypeCard],[InactiveDuoParking],[FullNamePerson],[AssetCommand],[EndDateContract],[RfidNumber],[MarketTitle],[InactiveDueElectronicCard],[StatusCard]) " +
             "VALUES " +
            "('" + PCode + "','" + DateExpireParking + "','" + CodeGroup + "','" + StatusParking + "','" + CodeGroup + "','" + DateExpireElectronicCard + "','" + Plaque + "','" + CarOwner + "','" + Color + "','" + TypeCar + "','" + SerialCard + "','" + TypeGroup + "','" + IDCardParking + "','" + Market + "','" + TypeCard + "','" + InactiveDuoParking + "','" + FullNamePerson + "','" + AssetCommand + "','" + EndDateContract + "','" + RfidNummber + "','" + MarketTitle + "','" + InactiveDueElectronicCard + "','" + StatusCard + "') \r\n";
       }
       public System.Data.DataTable CreateGateTable()
       {
           string Query = "";
           JDataBase jdb = new JDataBase();
           JDataBase JdbParking = new JDataBase(SqlBuilder);
           try
           {
               jdb.setQuery("SELECT * FROM [dbo].[PrkGate]");
               jdb.Query_DataTable();
               System.Data.DataTable Dt = jdb.datatable;
               for (int i = 0; i < Dt.Rows.Count; i++)
               {
                   try
                   {
                       Query = Query + QueryGateInsert(Dt.Rows[i]["Code"].ToString(), Dt.Rows[i]["Name"].ToString(), Dt.Rows[i]["Market"].ToString(), Dt.Rows[i]["TypeGate"].ToString(), Dt.Rows[i]["DeviceName"].ToString(), Dt.Rows[i]["Ip"].ToString(), Dt.Rows[i]["IpCamera"].ToString(), Dt.Rows[i]["IpCenter"].ToString(), Dt.Rows[i]["IpSystem"].ToString(), Dt.Rows[i]["MarketName"].ToString(), Dt.Rows[i]["SubIp"].ToString(), Dt.Rows[i]["Port"].ToString(), Convert.ToInt32(Dt.Rows[i]["State"]));
                   }
                   catch
                   {
                   }
               }

               JdbParking.setQuery("DELETE FROM [dbo].[PrkGate]\r\n " + Query + " \r\n Select * From PrkGate");
               return JdbParking.Query_DataTable();
           }
           catch
           {
               return null;
           }
           finally
           {
               jdb.Dispose();
               JdbParking.Dispose();
           }
       }

       public System.Data.DataTable CreateGroupTable()
       {
           string Query = "";
           JDataBase jdb = new JDataBase();
           JDataBase JdbParking = new JDataBase(SqlBuilder);
           try
           {
               jdb.setQuery("SELECT * FROM [dbo].[PrkGroups]");
               jdb.Query_DataTable();
               System.Data.DataTable Dt = jdb.datatable;
               for (int i = 0; i < Dt.Rows.Count; i++)
               {
                   try
                   {
                       Query = Query + QueryGroupInsert(Dt.Rows[i]["Code"].ToString(), Dt.Rows[i]["TypeGroup"].ToString(), Dt.Rows[i]["FirstAmount"].ToString(), Dt.Rows[i]["SecondAmount"].ToString(), Convert.ToInt32(Dt.Rows[i]["AmountReceived"]), Dt.Rows[i]["MarketCode"].ToString(), Dt.Rows[i]["Abate"].ToString(), Dt.Rows[i]["Offers"].ToString(), Dt.Rows[i]["Round"].ToString(), Convert.ToInt32(Dt.Rows[i]["PayIsElectronic"]), Dt.Rows[i]["UnitTime"].ToString(), Convert.ToInt32(Dt.Rows[i]["UpRound"]), Convert.ToInt32(Dt.Rows[i]["GroupNumber"]), Convert.ToInt32(Dt.Rows[i]["PayByDialy"]), Dt.Rows[i]["DailyPrice"].ToString(), Convert.ToInt32(Dt.Rows[i]["IsActive"]), Convert.ToInt32(Dt.Rows[i]["IsDailyApart"]), Convert.ToInt32(Dt.Rows[i]["IsFirstHourApart"]));
                   }
                   catch
                   {
                   }
               }

               JdbParking.setQuery("DELETE FROM [dbo].[PrkGroups]\r\n " + Query + " \r\n Select * From PrkGroups");
               return JdbParking.Query_DataTable();
           }
           catch
           {
               return null;
           }
           finally
           {
               jdb.Dispose();
               JdbParking.Dispose();
           }
       }

       public System.Data.DataTable GetRecordParking(uint RfidNumber)
       {
           JDataBase jdb = new JDataBase(SqlBuilder);
           try
           {
               jdb.setQuery("select * from ParkingData where RfidNumber='" + RfidNumber.ToString() + "'");
               return jdb.Query_DataTable();
           }
           catch
           {
               return null;
           }
           finally
           {
               jdb.Dispose();
           }
       }

       #endregion
    }
   public class JParkingConfigures : JParking
   {
       public void ListView()
       {
           JfrmParkingUpdate showform = new JfrmParkingUpdate();
           showform.ShowDialog();
          
       }
   }
}
